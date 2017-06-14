using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Seader
{
    public partial class FormMain : Form
    {
        private FeedTreeManager feedTreeManager;
        private SettingsManager settingsManager;

        public FormMain()
        {
            // 強制言語変更
            //System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture("en");

            InitializeComponent();

            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            System.Version version = asm.GetName().Version;
            Text += " " + version;

            this.feedTreeManager = new FeedTreeManager();
            this.settingsManager = new SettingsManager();

            // ToolStrip の右端の影をフラットにする
            ToolStripProfessionalRenderer renderer = new ToolStripProfessionalRenderer();
            renderer.RoundedEdges = false;
            toolStripMain.Renderer = renderer;

            // ブラウザのエラー表示が鬱陶しいので OFF にする
            // https://stackoverflow.com/questions/2476360/disable-javascript-error-in-webbrowser-control
            // 一部 JavaScript の動作にも影響がでるそうだが、今回の用途だとまぁ問題なさそう
            // エラーが出る原因としては内部的には IE7 相当のエンジンで動いているらしい
            webBrowserPreviewFeed.ScriptErrorsSuppressed = true;

            ReadSettings();

            Hashtable workerArgs = new Hashtable();
            workerArgs["ExpandAll"] = true;
            backgroundWorkerUpdateFeed.RunWorkerAsync(workerArgs);
        }

        /// <summary>
        /// 設定ファイルの読み込みと読み込んだ設定の反映を行います。
        /// </summary>
        private void ReadSettings()
        {
            // 初期状態ではブラウザを閉じる
            splitContainerMain.Panel2Collapsed = true;

            // 設定の読み込みと反映
            settingsManager.Read();
            this.Width = settingsManager.Setting.FormSize.Width;
            this.Height = settingsManager.Setting.FormSize.Height;
            this.splitContainerMain.SplitterDistance = settingsManager.Setting.SplitterDistance;
            this.splitContainerMain.Orientation = settingsManager.Setting.Orientation;

            toolStripMenuItemOrientationHorizontal.Checked = (this.splitContainerMain.Orientation == Orientation.Horizontal);
            toolStripMenuItemOrientationVertical.Checked = (this.splitContainerMain.Orientation == Orientation.Vertical);

            // 既定の時間以外が設定されていたら、値を補正する
            bool validInterval = false;
            for (var i = 0; i < Constants.GetIntervalList.Length; ++i)
            {
                if (this.settingsManager.Setting.FeedsUpdateInterval == Constants.GetIntervalList[i])
                {
                    validInterval = true;
                    break;
                }
            }
            if (false == validInterval)
            {
                this.settingsManager.Setting.FeedsUpdateInterval = Constants.GetIntervalList[3];
            }

            timerUpdateFeed.Enabled = true;
            timerUpdateFeed.Interval = 1000 * 60 * this.settingsManager.Setting.FeedsUpdateInterval;
            timerUpdateFeed.Start();

            // メニューの構築
            for (var i = 0; i < Constants.GetIntervalList.Length; ++i)
            {
                var menuItem = toolStripDropDownButtonUpdateInterval.DropDownItems.Add(Constants.GetIntervalList[i].ToString());
                menuItem.Click += toolStripButtonUpdateInterval_Click;
                if (settingsManager.Setting.FeedsUpdateInterval == Constants.GetIntervalList[i])
                {
                    ((ToolStripMenuItem)menuItem).Checked = true;
                }
            }
        }

        /// <summary>
        /// フォームが閉じられた時のイベントです。
        /// 設定データのセットと書き込みを行います。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            settingsManager.Setting.FormSize = new Size(this.Width, this.Height);
            settingsManager.Setting.SplitterDistance = splitContainerMain.SplitterDistance;
            settingsManager.Setting.Orientation = splitContainerMain.Orientation;

            if (false == settingsManager.Write())
            {
                //MessageBox.Show(this.resources.GetString("SaveErrorDialogBody") + "\n\n" + settingsManager.FilePath, this.resources.GetString("SaveErrorDialogTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Failed to save the settings file.\n\n\"" + settingsManager.FilePath + "\"\n\nWrite to this path may not have been allowed.", "File save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region バックグラウンド処理
        /// <summary>
        /// バックグラウンドでの処理を行います。
        /// フィードの更新処理を行います。
        /// 設定パラメータは Hashtable で指定します。
        /// Hashtable["Url"]       ... フィードのURLを指定します。指定がない場合、全フィードの更新を行います。
        /// Hashtable["ExpandAll"] ... true の場合、読み込み後に全ツリーノードを開きます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerUpdateFeed_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            worker.ReportProgress(0);

            Hashtable args = (Hashtable)e.Argument;
            if (args == null)
            {
                args = new Hashtable();
            }

            Feed.FeedReader feedReader = new Feed.FeedReader();

            if (args.ContainsKey("Url"))
            {
                Uri uri = new Uri((string)args["Url"]);
                Feed.FeedInfo info = feedReader.Read(uri, settingsManager.Setting.DummyUserAgent);

                if (null == info)
                {
                    args["Error"] = true;
                }
                else
                {
                    if (false == this.feedTreeManager.UpdateFeed(info))
                    {
                        args["Error"] = true;
                    }
                }
            }
            else
            {
                foreach (var url in settingsManager.Setting.FeedUrls)
                {
                    var uri = new Uri(url);
                    var feed = feedReader.Read(uri, settingsManager.Setting.DummyUserAgent);
                    this.feedTreeManager.UpdateFeed(feed);
                }
            }

            e.Result = args;
        }

        /// <summary>
        /// バックグラウンドでの処理の進捗イベントです。
        /// 現在は開始時点の通知のみに使用されています。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerUpdateFeed_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                toolStripLabelLoading.Visible = true;
                toolStripButtonUpdateFeeds.Enabled = false;
            }
        }

        /// <summary>
        /// バックグラウンドの処理が完了した時のイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerUpdateFeed_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripLabelLoading.Visible = false;
            toolStripButtonUpdateFeeds.Enabled = true;

            if (e.Cancelled)
            {

            }
            else
            {
                this.feedTreeManager.ReflectTreeView(ref treeViewFeeds);

                Hashtable args = (Hashtable)e.Result;
                if (args.ContainsKey("ExpandAll") && (bool)args["ExpandAll"])
                {
                    treeViewFeeds.ExpandAll();
                    // 上へスクロール
                    if (treeViewFeeds.Nodes.Count > 0)
                    {
                        treeViewFeeds.Nodes[0].EnsureVisible();
                    }
                }

                // URL が指定された時は追加の時なので、
                // もしエラーなどなければ、ここで設定オブジェクトに追加する
                if (args.ContainsKey("Url") && (false == args.ContainsKey("Error") || false == (bool)args["Error"]))
                {
                    string url = (string)args["Url"];
                    if (settingsManager.Setting.FeedUrls.IndexOf(url) == -1)
                    {
                        settingsManager.Setting.FeedUrls.Add(url);
                    }
                }
            }
        }
        #endregion

        #region UIイベント
        /// <summary>
        /// ツリービューのノードがクリックされた時のイベントです。
        /// ノードの記事をプレビュー用のブラウザで開きます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewFeeds_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (null != e.Node.Parent)
            {
                FeedTreeManager.FeedTreeNode node = (FeedTreeManager.FeedTreeNode)e.Node;

                string documentText = string.Empty;
                if (node.Content != null)
                {
                    documentText = node.Content; 
                }
                else if (node.Summary != null)
                {
                    documentText = node.Summary; 
                }
                else if (node.Description != null)
                {
                    documentText = node.Description; 
                }

                if (documentText.Length > 0)
                {
                    splitContainerMain.Panel2Collapsed = false;
                    webBrowserPreviewFeed.DocumentText = documentText;
                }
            }
        }

        /// <summary>
        /// ツリービューのノードがダブルクリックされた時のイベントです。
        /// ノードの記事を既読にし、記事を既定のブラウザで開きます。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewFeeds_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (null != e.Node.Parent)
            {
                FeedTreeManager.FeedTreeNode node = (FeedTreeManager.FeedTreeNode)e.Node;
                if (node.Url.ToString().Length > 0)
                {
                    System.Diagnostics.Process.Start(node.Url.ToString());
                    node.Read = true;

                    TreeView tree = (TreeView)sender;
                    tree.Nodes.Remove(e.Node);
                }
            }
        }

        /// <summary>
        /// ブラウザ上の閉じるボタンが押された時のイベントです。
        /// ブラウザを非表示にします。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFeedPreviewClose_Click(object sender, EventArgs e)
        {
            splitContainerMain.Panel2Collapsed = true;
            webBrowserPreviewFeed.Stop();
        }

        /// <summary>
        /// 設定したタイマーのイベントが発生した時のイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerUpdateFeed_Tick(object sender, EventArgs e)
        {
            if (false == backgroundWorkerUpdateFeed.IsBusy)
            {
                backgroundWorkerUpdateFeed.RunWorkerAsync();
            }
        }
        /// <summary>
        /// フィードの追加ボタンを押した時のイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAddFeed_Click(object sender, EventArgs e)
        {
            string url = string.Empty;
            if (ShowInputDialog(ref url) == DialogResult.OK)
            {
                try
                {
                    Uri uri = new Uri(url);

                    Hashtable workerArgs = new Hashtable();
                    workerArgs["Url"] = uri.ToString();
                    backgroundWorkerUpdateFeed.RunWorkerAsync(workerArgs);
                }
                catch (Exception)
                {

                }
            }
        }

        /// <summary>
        /// フィードの更新ボタンを押した時のイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonUpdateFeeds_Click(object sender, EventArgs e)
        {
            if (false == backgroundWorkerUpdateFeed.IsBusy)
            {
                backgroundWorkerUpdateFeed.RunWorkerAsync();
            }
        }

        /// <summary>
        /// 更新インターバルメニューを操作した時のイベントです。
        /// チェックの入れ替えを行います。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonUpdateInterval_Click(object sender, EventArgs e)
        {
            timerUpdateFeed.Stop();

            var clickItem = (ToolStripMenuItem)sender;
            int index = 0;
            foreach (var item in toolStripDropDownButtonUpdateInterval.DropDownItems)
            {
                if (((ToolStripMenuItem)item).Checked = (clickItem == item))
                {
                    this.settingsManager.Setting.FeedsUpdateInterval = Constants.GetIntervalList[index];
                }
                ++index;
            }

            timerUpdateFeed.Interval = 1000 * 60 * this.settingsManager.Setting.FeedsUpdateInterval;
            timerUpdateFeed.Start();
        }

        /// <summary>
        /// 分割方向メニューがクリックされた時のイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemOrientation_Click(object sender, EventArgs e)
        {
            toolStripMenuItemOrientationHorizontal.Checked = false;
            toolStripMenuItemOrientationVertical.Checked = false;
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            item.Checked = true;
            splitContainerMain.Orientation = (item == toolStripMenuItemOrientationHorizontal) ? Orientation.Horizontal : Orientation.Vertical;
        }
        #endregion

        #region コンテキストメニュー
        /// <summary>
        /// コンテキストメニューを開く時のイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStripTreeView_Opening(object sender, CancelEventArgs e)
        {
            if (null == treeViewFeeds.SelectedNode)
            {
                e.Cancel = true;
            }
            else
            {
                if (null == treeViewFeeds.SelectedNode.Parent)
                {
                    toolStripMenuItemRemoveFeed.Visible = true;
                    toolStripMenuItemAlreadyReadAll.Visible = true;
                    toolStripMenuItemAlreadyRead.Visible = false;
                }
                else
                {
                    toolStripMenuItemRemoveFeed.Visible = false;
                    toolStripMenuItemAlreadyReadAll.Visible = false;
                    toolStripMenuItemAlreadyRead.Visible = true;
                }
            }
        }


        /// <summary>
        /// コンテキストメニューの開くを押した時のイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemOpenBrowser_Click(object sender, EventArgs e)
        {
            FeedTreeManager.FeedTreeNode node = (FeedTreeManager.FeedTreeNode)treeViewFeeds.SelectedNode;
            if (node.Url.ToString().Length > 0)
            {
                System.Diagnostics.Process.Start(node.Url.ToString());
                node.Read = true;
                treeViewFeeds.Nodes.Remove(node);
            }
        }

        /// <summary>
        /// コンテキストメニューのフィード削除を押した時のイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemRemoveFeed_Click(object sender, EventArgs e)
        {
            FeedTreeManager.FeedTreeNode node = (FeedTreeManager.FeedTreeNode)treeViewFeeds.SelectedNode;
            treeViewFeeds.Nodes.Remove(treeViewFeeds.SelectedNode);
            this.feedTreeManager.RemoveFeed(node);
            this.settingsManager.Setting.FeedUrls.Remove(node.Url.ToString());
        }

        /// <summary>
        /// コンテキストメニューの既読を押した時のイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAlreadyRead_Click(object sender, EventArgs e)
        {
            FeedTreeManager.FeedTreeNode node = (FeedTreeManager.FeedTreeNode)treeViewFeeds.SelectedNode;
            node.Read = true;
            node.Parent.Nodes.Remove(node);
        }

        /// <summary>
        /// コンテキストメニューのすべて既読を押した時のイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAlreadyReadAll_Click(object sender, EventArgs e)
        {
            FeedTreeManager.FeedTreeNode node = (FeedTreeManager.FeedTreeNode)treeViewFeeds.SelectedNode;
            this.feedTreeManager.ReadAll(node);
        }
        
        /// <summary>
        /// タイトルをコピーします。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemCopyTitle_Click(object sender, EventArgs e)
        {
            FeedTreeManager.FeedTreeNode node = (FeedTreeManager.FeedTreeNode)treeViewFeeds.SelectedNode;
            Clipboard.SetDataObject(node.Title, true);
        }

        /// <summary>
        /// URLをコピーします。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemCopyUrl_Click(object sender, EventArgs e)
        {
            FeedTreeManager.FeedTreeNode node = (FeedTreeManager.FeedTreeNode)treeViewFeeds.SelectedNode;
            Clipboard.SetDataObject(node.Url.ToString(), true);
        }
        #endregion

        /// <summary>
        /// Feed を追加するときのダイアログを作成・表示します。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(220, 70);
            Form inputBox = new Form();

            inputBox.Icon = Icon;
            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.MaximizeBox = false;
            inputBox.ClientSize = size;
            inputBox.Text = "Feed URL";
            inputBox.StartPosition = FormStartPosition.CenterParent;

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 20, 23);
            textBox.Location = new System.Drawing.Point(10, 10);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK(&O)";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel(&C)";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }
    }
}

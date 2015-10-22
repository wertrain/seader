namespace Seader
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.treeViewFeeds = new System.Windows.Forms.TreeView();
            this.contextMenuStripTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOpenBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRemoveFeed = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAlreadyRead = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAlreadyReadAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemCopyTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCopyUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.buttonFeedPreviewClose = new System.Windows.Forms.Button();
            this.webBrowserPreviewFeed = new System.Windows.Forms.WebBrowser();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddFeed = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUpdateFeeds = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButtonUpdateInterval = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButtonConfig = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemOrientation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOrientationHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOrientationVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabelLoading = new System.Windows.Forms.ToolStripLabel();
            this.backgroundWorkerUpdateFeed = new System.ComponentModel.BackgroundWorker();
            this.timerUpdateFeed = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.contextMenuStripTreeView.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            resources.ApplyResources(this.splitContainerMain, "splitContainerMain");
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.treeViewFeeds);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.buttonFeedPreviewClose);
            this.splitContainerMain.Panel2.Controls.Add(this.webBrowserPreviewFeed);
            // 
            // treeViewFeeds
            // 
            this.treeViewFeeds.ContextMenuStrip = this.contextMenuStripTreeView;
            resources.ApplyResources(this.treeViewFeeds, "treeViewFeeds");
            this.treeViewFeeds.ImageList = this.imageListTreeView;
            this.treeViewFeeds.Name = "treeViewFeeds";
            this.treeViewFeeds.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewFeeds_NodeMouseClick);
            this.treeViewFeeds.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewFeeds_NodeMouseDoubleClick);
            // 
            // contextMenuStripTreeView
            // 
            this.contextMenuStripTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenBrowser,
            this.toolStripMenuItemRemoveFeed,
            this.toolStripMenuItemAlreadyRead,
            this.toolStripMenuItemAlreadyReadAll,
            this.toolStripSeparator1,
            this.toolStripMenuItemCopyTitle,
            this.toolStripMenuItemCopyUrl});
            this.contextMenuStripTreeView.Name = "contextMenuStripTreeView";
            resources.ApplyResources(this.contextMenuStripTreeView, "contextMenuStripTreeView");
            this.contextMenuStripTreeView.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripTreeView_Opening);
            // 
            // toolStripMenuItemOpenBrowser
            // 
            resources.ApplyResources(this.toolStripMenuItemOpenBrowser, "toolStripMenuItemOpenBrowser");
            this.toolStripMenuItemOpenBrowser.Name = "toolStripMenuItemOpenBrowser";
            this.toolStripMenuItemOpenBrowser.Click += new System.EventHandler(this.toolStripMenuItemOpenBrowser_Click);
            // 
            // toolStripMenuItemRemoveFeed
            // 
            resources.ApplyResources(this.toolStripMenuItemRemoveFeed, "toolStripMenuItemRemoveFeed");
            this.toolStripMenuItemRemoveFeed.Name = "toolStripMenuItemRemoveFeed";
            this.toolStripMenuItemRemoveFeed.Click += new System.EventHandler(this.toolStripMenuItemRemoveFeed_Click);
            // 
            // toolStripMenuItemAlreadyRead
            // 
            resources.ApplyResources(this.toolStripMenuItemAlreadyRead, "toolStripMenuItemAlreadyRead");
            this.toolStripMenuItemAlreadyRead.Name = "toolStripMenuItemAlreadyRead";
            this.toolStripMenuItemAlreadyRead.Click += new System.EventHandler(this.toolStripMenuItemAlreadyRead_Click);
            // 
            // toolStripMenuItemAlreadyReadAll
            // 
            resources.ApplyResources(this.toolStripMenuItemAlreadyReadAll, "toolStripMenuItemAlreadyReadAll");
            this.toolStripMenuItemAlreadyReadAll.Name = "toolStripMenuItemAlreadyReadAll";
            this.toolStripMenuItemAlreadyReadAll.Click += new System.EventHandler(this.toolStripMenuItemAlreadyReadAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripMenuItemCopyTitle
            // 
            resources.ApplyResources(this.toolStripMenuItemCopyTitle, "toolStripMenuItemCopyTitle");
            this.toolStripMenuItemCopyTitle.Name = "toolStripMenuItemCopyTitle";
            this.toolStripMenuItemCopyTitle.Click += new System.EventHandler(this.toolStripMenuItemCopyTitle_Click);
            // 
            // toolStripMenuItemCopyUrl
            // 
            resources.ApplyResources(this.toolStripMenuItemCopyUrl, "toolStripMenuItemCopyUrl");
            this.toolStripMenuItemCopyUrl.Name = "toolStripMenuItemCopyUrl";
            this.toolStripMenuItemCopyUrl.Click += new System.EventHandler(this.toolStripMenuItemCopyUrl_Click);
            // 
            // imageListTreeView
            // 
            this.imageListTreeView.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageListTreeView, "imageListTreeView");
            this.imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // buttonFeedPreviewClose
            // 
            resources.ApplyResources(this.buttonFeedPreviewClose, "buttonFeedPreviewClose");
            this.buttonFeedPreviewClose.Name = "buttonFeedPreviewClose";
            this.buttonFeedPreviewClose.UseVisualStyleBackColor = true;
            this.buttonFeedPreviewClose.Click += new System.EventHandler(this.buttonFeedPreviewClose_Click);
            // 
            // webBrowserPreviewFeed
            // 
            resources.ApplyResources(this.webBrowserPreviewFeed, "webBrowserPreviewFeed");
            this.webBrowserPreviewFeed.Name = "webBrowserPreviewFeed";
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddFeed,
            this.toolStripButtonUpdateFeeds,
            this.toolStripSeparator2,
            this.toolStripDropDownButtonUpdateInterval,
            this.toolStripDropDownButtonConfig,
            this.toolStripLabelLoading});
            resources.ApplyResources(this.toolStripMain, "toolStripMain");
            this.toolStripMain.Name = "toolStripMain";
            // 
            // toolStripButtonAddFeed
            // 
            this.toolStripButtonAddFeed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonAddFeed, "toolStripButtonAddFeed");
            this.toolStripButtonAddFeed.Name = "toolStripButtonAddFeed";
            this.toolStripButtonAddFeed.Click += new System.EventHandler(this.toolStripButtonAddFeed_Click);
            // 
            // toolStripButtonUpdateFeeds
            // 
            this.toolStripButtonUpdateFeeds.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonUpdateFeeds, "toolStripButtonUpdateFeeds");
            this.toolStripButtonUpdateFeeds.Name = "toolStripButtonUpdateFeeds";
            this.toolStripButtonUpdateFeeds.Click += new System.EventHandler(this.toolStripButtonUpdateFeeds_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripDropDownButtonUpdateInterval
            // 
            this.toolStripDropDownButtonUpdateInterval.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripDropDownButtonUpdateInterval, "toolStripDropDownButtonUpdateInterval");
            this.toolStripDropDownButtonUpdateInterval.Name = "toolStripDropDownButtonUpdateInterval";
            // 
            // toolStripDropDownButtonConfig
            // 
            this.toolStripDropDownButtonConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOrientation});
            resources.ApplyResources(this.toolStripDropDownButtonConfig, "toolStripDropDownButtonConfig");
            this.toolStripDropDownButtonConfig.Name = "toolStripDropDownButtonConfig";
            // 
            // toolStripMenuItemOrientation
            // 
            this.toolStripMenuItemOrientation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOrientationHorizontal,
            this.toolStripMenuItemOrientationVertical});
            resources.ApplyResources(this.toolStripMenuItemOrientation, "toolStripMenuItemOrientation");
            this.toolStripMenuItemOrientation.Name = "toolStripMenuItemOrientation";
            // 
            // toolStripMenuItemOrientationHorizontal
            // 
            resources.ApplyResources(this.toolStripMenuItemOrientationHorizontal, "toolStripMenuItemOrientationHorizontal");
            this.toolStripMenuItemOrientationHorizontal.Name = "toolStripMenuItemOrientationHorizontal";
            this.toolStripMenuItemOrientationHorizontal.Click += new System.EventHandler(this.toolStripMenuItemOrientation_Click);
            // 
            // toolStripMenuItemOrientationVertical
            // 
            resources.ApplyResources(this.toolStripMenuItemOrientationVertical, "toolStripMenuItemOrientationVertical");
            this.toolStripMenuItemOrientationVertical.Name = "toolStripMenuItemOrientationVertical";
            this.toolStripMenuItemOrientationVertical.Click += new System.EventHandler(this.toolStripMenuItemOrientation_Click);
            // 
            // toolStripLabelLoading
            // 
            this.toolStripLabelLoading.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.toolStripLabelLoading, "toolStripLabelLoading");
            this.toolStripLabelLoading.Name = "toolStripLabelLoading";
            // 
            // backgroundWorkerUpdateFeed
            // 
            this.backgroundWorkerUpdateFeed.WorkerReportsProgress = true;
            this.backgroundWorkerUpdateFeed.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUpdateFeed_DoWork);
            this.backgroundWorkerUpdateFeed.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerUpdateFeed_ProgressChanged);
            this.backgroundWorkerUpdateFeed.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUpdateFeed_RunWorkerCompleted);
            // 
            // timerUpdateFeed
            // 
            this.timerUpdateFeed.Tick += new System.EventHandler(this.timerUpdateFeed_Tick);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.toolStripMain);
            this.Name = "FormMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.contextMenuStripTreeView.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TreeView treeViewFeeds;
        private System.Windows.Forms.WebBrowser webBrowserPreviewFeed;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUpdateFeed;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddFeed;
        private System.Windows.Forms.ToolStripButton toolStripButtonUpdateFeeds;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonUpdateInterval;
        private System.Windows.Forms.Timer timerUpdateFeed;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonConfig;
        private System.Windows.Forms.ToolStripLabel toolStripLabelLoading;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOrientation;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOrientationHorizontal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOrientationVertical;
        private System.Windows.Forms.ImageList imageListTreeView;
        private System.Windows.Forms.Button buttonFeedPreviewClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTreeView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveFeed;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAlreadyReadAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAlreadyRead;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyTitle;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyUrl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenBrowser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}


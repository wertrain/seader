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
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddFeed = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUpdateFeeds = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonUpdateInterval = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButtonConfig = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemOrientation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOrientationHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOrientationVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabelLoading = new System.Windows.Forms.ToolStripLabel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.treeViewFeeds = new System.Windows.Forms.TreeView();
            this.contextMenuStripTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemRemoveFeed = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAlreadyRead = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAlreadyReadAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemCopyTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCopyUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.buttonFeedPreviewClose = new System.Windows.Forms.Button();
            this.webBrowserPreviewFeed = new System.Windows.Forms.WebBrowser();
            this.backgroundWorkerUpdateFeed = new System.ComponentModel.BackgroundWorker();
            this.timerUpdateFeed = new System.Windows.Forms.Timer(this.components);
            this.toolStripMenuItemOpenBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.contextMenuStripTreeView.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddFeed,
            this.toolStripButtonUpdateFeeds,
            this.toolStripDropDownButtonUpdateInterval,
            this.toolStripDropDownButtonConfig,
            this.toolStripLabelLoading});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(484, 25);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // toolStripButtonAddFeed
            // 
            this.toolStripButtonAddFeed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddFeed.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddFeed.Image")));
            this.toolStripButtonAddFeed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddFeed.Name = "toolStripButtonAddFeed";
            this.toolStripButtonAddFeed.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddFeed.Text = "Add Feed";
            this.toolStripButtonAddFeed.Click += new System.EventHandler(this.toolStripButtonAddFeed_Click);
            // 
            // toolStripButtonUpdateFeeds
            // 
            this.toolStripButtonUpdateFeeds.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUpdateFeeds.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUpdateFeeds.Image")));
            this.toolStripButtonUpdateFeeds.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUpdateFeeds.Name = "toolStripButtonUpdateFeeds";
            this.toolStripButtonUpdateFeeds.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUpdateFeeds.Text = "Update Feeds";
            this.toolStripButtonUpdateFeeds.Click += new System.EventHandler(this.toolStripButtonUpdateFeeds_Click);
            // 
            // toolStripDropDownButtonUpdateInterval
            // 
            this.toolStripDropDownButtonUpdateInterval.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonUpdateInterval.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonUpdateInterval.Image")));
            this.toolStripDropDownButtonUpdateInterval.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonUpdateInterval.Name = "toolStripDropDownButtonUpdateInterval";
            this.toolStripDropDownButtonUpdateInterval.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButtonUpdateInterval.Text = "Update Interval";
            // 
            // toolStripDropDownButtonConfig
            // 
            this.toolStripDropDownButtonConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOrientation});
            this.toolStripDropDownButtonConfig.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonConfig.Image")));
            this.toolStripDropDownButtonConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonConfig.Name = "toolStripDropDownButtonConfig";
            this.toolStripDropDownButtonConfig.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButtonConfig.Text = "Config";
            // 
            // toolStripMenuItemOrientation
            // 
            this.toolStripMenuItemOrientation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOrientationHorizontal,
            this.toolStripMenuItemOrientationVertical});
            this.toolStripMenuItemOrientation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemOrientation.Image")));
            this.toolStripMenuItemOrientation.Name = "toolStripMenuItemOrientation";
            this.toolStripMenuItemOrientation.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItemOrientation.Text = "Orientation(&O)";
            // 
            // toolStripMenuItemOrientationHorizontal
            // 
            this.toolStripMenuItemOrientationHorizontal.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemOrientationHorizontal.Image")));
            this.toolStripMenuItemOrientationHorizontal.Name = "toolStripMenuItemOrientationHorizontal";
            this.toolStripMenuItemOrientationHorizontal.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemOrientationHorizontal.Text = "Horizontal(&H)";
            this.toolStripMenuItemOrientationHorizontal.Click += new System.EventHandler(this.toolStripMenuItemOrientation_Click);
            // 
            // toolStripMenuItemOrientationVertical
            // 
            this.toolStripMenuItemOrientationVertical.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemOrientationVertical.Image")));
            this.toolStripMenuItemOrientationVertical.Name = "toolStripMenuItemOrientationVertical";
            this.toolStripMenuItemOrientationVertical.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemOrientationVertical.Text = "Vertical(&V)";
            this.toolStripMenuItemOrientationVertical.Click += new System.EventHandler(this.toolStripMenuItemOrientation_Click);
            // 
            // toolStripLabelLoading
            // 
            this.toolStripLabelLoading.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelLoading.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabelLoading.Image")));
            this.toolStripLabelLoading.Name = "toolStripLabelLoading";
            this.toolStripLabelLoading.Size = new System.Drawing.Size(26, 22);
            this.toolStripLabelLoading.Text = " ";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 25);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.treeViewFeeds);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.buttonFeedPreviewClose);
            this.splitContainerMain.Panel2.Controls.Add(this.webBrowserPreviewFeed);
            this.splitContainerMain.Size = new System.Drawing.Size(484, 536);
            this.splitContainerMain.SplitterDistance = 249;
            this.splitContainerMain.TabIndex = 1;
            // 
            // treeViewFeeds
            // 
            this.treeViewFeeds.ContextMenuStrip = this.contextMenuStripTreeView;
            this.treeViewFeeds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFeeds.ImageIndex = 0;
            this.treeViewFeeds.ImageList = this.imageListTreeView;
            this.treeViewFeeds.Location = new System.Drawing.Point(0, 0);
            this.treeViewFeeds.Name = "treeViewFeeds";
            this.treeViewFeeds.SelectedImageIndex = 0;
            this.treeViewFeeds.Size = new System.Drawing.Size(484, 249);
            this.treeViewFeeds.TabIndex = 0;
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
            this.contextMenuStripTreeView.Size = new System.Drawing.Size(175, 142);
            this.contextMenuStripTreeView.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripTreeView_Opening);
            // 
            // toolStripMenuItemRemoveFeed
            // 
            this.toolStripMenuItemRemoveFeed.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemRemoveFeed.Image")));
            this.toolStripMenuItemRemoveFeed.Name = "toolStripMenuItemRemoveFeed";
            this.toolStripMenuItemRemoveFeed.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuItemRemoveFeed.Text = "Remove Feed(&R)";
            this.toolStripMenuItemRemoveFeed.Click += new System.EventHandler(this.toolStripMenuItemRemoveFeed_Click);
            // 
            // toolStripMenuItemAlreadyRead
            // 
            this.toolStripMenuItemAlreadyRead.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemAlreadyRead.Image")));
            this.toolStripMenuItemAlreadyRead.Name = "toolStripMenuItemAlreadyRead";
            this.toolStripMenuItemAlreadyRead.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuItemAlreadyRead.Text = "Already Read(&E)";
            this.toolStripMenuItemAlreadyRead.Click += new System.EventHandler(this.toolStripMenuItemAlreadyRead_Click);
            // 
            // toolStripMenuItemAlreadyReadAll
            // 
            this.toolStripMenuItemAlreadyReadAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemAlreadyReadAll.Image")));
            this.toolStripMenuItemAlreadyReadAll.Name = "toolStripMenuItemAlreadyReadAll";
            this.toolStripMenuItemAlreadyReadAll.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuItemAlreadyReadAll.Text = "Already Read All(&E)";
            this.toolStripMenuItemAlreadyReadAll.Click += new System.EventHandler(this.toolStripMenuItemAlreadyReadAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // toolStripMenuItemCopyTitle
            // 
            this.toolStripMenuItemCopyTitle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemCopyTitle.Image")));
            this.toolStripMenuItemCopyTitle.Name = "toolStripMenuItemCopyTitle";
            this.toolStripMenuItemCopyTitle.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuItemCopyTitle.Text = "Copy Title(&T)";
            this.toolStripMenuItemCopyTitle.Click += new System.EventHandler(this.toolStripMenuItemCopyTitle_Click);
            // 
            // toolStripMenuItemCopyUrl
            // 
            this.toolStripMenuItemCopyUrl.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemCopyUrl.Image")));
            this.toolStripMenuItemCopyUrl.Name = "toolStripMenuItemCopyUrl";
            this.toolStripMenuItemCopyUrl.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuItemCopyUrl.Text = "Copy URL(&U)";
            this.toolStripMenuItemCopyUrl.Click += new System.EventHandler(this.toolStripMenuItemCopyUrl_Click);
            // 
            // imageListTreeView
            // 
            this.imageListTreeView.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListTreeView.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // buttonFeedPreviewClose
            // 
            this.buttonFeedPreviewClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFeedPreviewClose.Image = ((System.Drawing.Image)(resources.GetObject("buttonFeedPreviewClose.Image")));
            this.buttonFeedPreviewClose.Location = new System.Drawing.Point(446, 1);
            this.buttonFeedPreviewClose.Name = "buttonFeedPreviewClose";
            this.buttonFeedPreviewClose.Size = new System.Drawing.Size(20, 20);
            this.buttonFeedPreviewClose.TabIndex = 1;
            this.buttonFeedPreviewClose.UseVisualStyleBackColor = true;
            this.buttonFeedPreviewClose.Click += new System.EventHandler(this.buttonFeedPreviewClose_Click);
            // 
            // webBrowserPreviewFeed
            // 
            this.webBrowserPreviewFeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserPreviewFeed.Location = new System.Drawing.Point(0, 0);
            this.webBrowserPreviewFeed.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPreviewFeed.Name = "webBrowserPreviewFeed";
            this.webBrowserPreviewFeed.Size = new System.Drawing.Size(484, 283);
            this.webBrowserPreviewFeed.TabIndex = 0;
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
            // toolStripMenuItemOpenBrowser
            // 
            this.toolStripMenuItemOpenBrowser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemOpenBrowser.Image")));
            this.toolStripMenuItemOpenBrowser.Name = "toolStripMenuItemOpenBrowser";
            this.toolStripMenuItemOpenBrowser.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuItemOpenBrowser.Text = "Open(&O)";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.toolStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Seader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.contextMenuStripTreeView.ResumeLayout(false);
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
    }
}


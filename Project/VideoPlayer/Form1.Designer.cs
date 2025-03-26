namespace VideoPlayer
{
    partial class frmMediaPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMediaPlayer));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tblMediaPlayer = new System.Windows.Forms.TableLayoutPanel();
            this.VideoPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.tblVideoInformation = new System.Windows.Forms.TableLayoutPanel();
            this.lblVideoTitle = new System.Windows.Forms.Label();
            this.tabVideoInformation = new System.Windows.Forms.TabControl();
            this.tabVideos = new System.Windows.Forms.TabPage();
            this.PlayList = new System.Windows.Forms.ListBox();
            this.tblSearchVideos = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearchVideos = new System.Windows.Forms.TextBox();
            this.btnSearchVideos = new System.Windows.Forms.Button();
            this.tabCategory = new System.Windows.Forms.TabPage();
            this.tblCategory = new System.Windows.Forms.TableLayoutPanel();
            this.lstVideosWithCategory = new System.Windows.Forms.ListBox();
            this.lblCategoryPlaylist = new System.Windows.Forms.Label();
            this.tabTags = new System.Windows.Forms.TabPage();
            this.tblTags = new System.Windows.Forms.TableLayoutPanel();
            this.lblVideosWithSameTag = new System.Windows.Forms.Label();
            this.lblVideoTags = new System.Windows.Forms.Label();
            this.lstVideoTags = new System.Windows.Forms.ListBox();
            this.lstVideosWithSameTag = new System.Windows.Forms.ListBox();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.tblMediaPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayer)).BeginInit();
            this.tblVideoInformation.SuspendLayout();
            this.tabVideoInformation.SuspendLayout();
            this.tabVideos.SuspendLayout();
            this.tblSearchVideos.SuspendLayout();
            this.tabCategory.SuspendLayout();
            this.tblCategory.SuspendLayout();
            this.tabTags.SuspendLayout();
            this.tblTags.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.manageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1141, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(49, 27);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFileEvent);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriesToolStripMenuItem,
            this.tagsToolStripMenuItem,
            this.videosToolStripMenuItem});
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(86, 27);
            this.manageToolStripMenuItem.Text = "&Manage";
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(175, 28);
            this.categoriesToolStripMenuItem.Text = "Categories";
            // 
            // tagsToolStripMenuItem
            // 
            this.tagsToolStripMenuItem.Name = "tagsToolStripMenuItem";
            this.tagsToolStripMenuItem.Size = new System.Drawing.Size(175, 28);
            this.tagsToolStripMenuItem.Text = "Tags";
            // 
            // videosToolStripMenuItem
            // 
            this.videosToolStripMenuItem.Name = "videosToolStripMenuItem";
            this.videosToolStripMenuItem.Size = new System.Drawing.Size(175, 28);
            this.videosToolStripMenuItem.Text = "Videos";
            // 
            // tblMediaPlayer
            // 
            this.tblMediaPlayer.AutoSize = true;
            this.tblMediaPlayer.ColumnCount = 2;
            this.tblMediaPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblMediaPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblMediaPlayer.Controls.Add(this.VideoPlayer, 0, 0);
            this.tblMediaPlayer.Controls.Add(this.tblVideoInformation, 1, 0);
            this.tblMediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMediaPlayer.Location = new System.Drawing.Point(0, 29);
            this.tblMediaPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.tblMediaPlayer.Name = "tblMediaPlayer";
            this.tblMediaPlayer.RowCount = 1;
            this.tblMediaPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMediaPlayer.Size = new System.Drawing.Size(1141, 532);
            this.tblMediaPlayer.TabIndex = 5;
            // 
            // VideoPlayer
            // 
            this.VideoPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoPlayer.Enabled = true;
            this.VideoPlayer.Location = new System.Drawing.Point(0, 0);
            this.VideoPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.VideoPlayer.Name = "VideoPlayer";
            this.VideoPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VideoPlayer.OcxState")));
            this.VideoPlayer.Size = new System.Drawing.Size(798, 532);
            this.VideoPlayer.TabIndex = 5;
            // 
            // tblVideoInformation
            // 
            this.tblVideoInformation.ColumnCount = 1;
            this.tblVideoInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblVideoInformation.Controls.Add(this.lblVideoTitle, 0, 0);
            this.tblVideoInformation.Controls.Add(this.tabVideoInformation, 0, 1);
            this.tblVideoInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblVideoInformation.Location = new System.Drawing.Point(801, 1);
            this.tblVideoInformation.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tblVideoInformation.Name = "tblVideoInformation";
            this.tblVideoInformation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tblVideoInformation.RowCount = 2;
            this.tblVideoInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.890499F));
            this.tblVideoInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.1095F));
            this.tblVideoInformation.Size = new System.Drawing.Size(337, 530);
            this.tblVideoInformation.TabIndex = 6;
            // 
            // lblVideoTitle
            // 
            this.lblVideoTitle.AutoSize = true;
            this.lblVideoTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblVideoTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVideoTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideoTitle.Location = new System.Drawing.Point(5, 5);
            this.lblVideoTitle.Margin = new System.Windows.Forms.Padding(5);
            this.lblVideoTitle.Name = "lblVideoTitle";
            this.lblVideoTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblVideoTitle.Size = new System.Drawing.Size(327, 31);
            this.lblVideoTitle.TabIndex = 8;
            this.lblVideoTitle.Text = "label1";
            this.lblVideoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabVideoInformation
            // 
            this.tabVideoInformation.Controls.Add(this.tabVideos);
            this.tabVideoInformation.Controls.Add(this.tabCategory);
            this.tabVideoInformation.Controls.Add(this.tabTags);
            this.tabVideoInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVideoInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabVideoInformation.Location = new System.Drawing.Point(3, 42);
            this.tabVideoInformation.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tabVideoInformation.Name = "tabVideoInformation";
            this.tabVideoInformation.SelectedIndex = 0;
            this.tabVideoInformation.Size = new System.Drawing.Size(331, 487);
            this.tabVideoInformation.TabIndex = 7;
            // 
            // tabVideos
            // 
            this.tabVideos.Controls.Add(this.PlayList);
            this.tabVideos.Controls.Add(this.tblSearchVideos);
            this.tabVideos.Location = new System.Drawing.Point(4, 35);
            this.tabVideos.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tabVideos.Name = "tabVideos";
            this.tabVideos.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tabVideos.Size = new System.Drawing.Size(323, 448);
            this.tabVideos.TabIndex = 2;
            this.tabVideos.Text = "Videos";
            this.tabVideos.UseVisualStyleBackColor = true;
            // 
            // PlayList
            // 
            this.PlayList.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PlayList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayList.FormattingEnabled = true;
            this.PlayList.HorizontalScrollbar = true;
            this.PlayList.ItemHeight = 26;
            this.PlayList.Location = new System.Drawing.Point(3, 1);
            this.PlayList.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.PlayList.Name = "PlayList";
            this.PlayList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PlayList.ScrollAlwaysVisible = true;
            this.PlayList.Size = new System.Drawing.Size(317, 446);
            this.PlayList.TabIndex = 1;
            this.PlayList.SelectedIndexChanged += new System.EventHandler(this.PlayList_SelectedIndexChanged);
            // 
            // tblSearchVideos
            // 
            this.tblSearchVideos.ColumnCount = 2;
            this.tblSearchVideos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.42241F));
            this.tblSearchVideos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.57758F));
            this.tblSearchVideos.Controls.Add(this.txtSearchVideos, 1, 0);
            this.tblSearchVideos.Controls.Add(this.btnSearchVideos, 0, 0);
            this.tblSearchVideos.Location = new System.Drawing.Point(3, 6);
            this.tblSearchVideos.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tblSearchVideos.Name = "tblSearchVideos";
            this.tblSearchVideos.RowCount = 1;
            this.tblSearchVideos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSearchVideos.Size = new System.Drawing.Size(464, 52);
            this.tblSearchVideos.TabIndex = 0;
            // 
            // txtSearchVideos
            // 
            this.txtSearchVideos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchVideos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchVideos.Location = new System.Drawing.Point(5, 5);
            this.txtSearchVideos.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearchVideos.Name = "txtSearchVideos";
            this.txtSearchVideos.Size = new System.Drawing.Size(402, 34);
            this.txtSearchVideos.TabIndex = 0;
            // 
            // btnSearchVideos
            // 
            this.btnSearchVideos.AutoSize = true;
            this.btnSearchVideos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchVideos.BackgroundImage")));
            this.btnSearchVideos.Location = new System.Drawing.Point(416, 1);
            this.btnSearchVideos.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnSearchVideos.Name = "btnSearchVideos";
            this.btnSearchVideos.Size = new System.Drawing.Size(45, 36);
            this.btnSearchVideos.TabIndex = 1;
            this.btnSearchVideos.UseVisualStyleBackColor = true;
            // 
            // tabCategory
            // 
            this.tabCategory.Controls.Add(this.tblCategory);
            this.tabCategory.Location = new System.Drawing.Point(4, 35);
            this.tabCategory.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.tabCategory.Name = "tabCategory";
            this.tabCategory.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tabCategory.Size = new System.Drawing.Size(323, 447);
            this.tabCategory.TabIndex = 0;
            this.tabCategory.Text = "Category";
            this.tabCategory.UseVisualStyleBackColor = true;
            // 
            // tblCategory
            // 
            this.tblCategory.ColumnCount = 1;
            this.tblCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCategory.Controls.Add(this.lstVideosWithCategory, 0, 1);
            this.tblCategory.Controls.Add(this.lblCategoryPlaylist, 0, 0);
            this.tblCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCategory.Location = new System.Drawing.Point(3, 1);
            this.tblCategory.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tblCategory.Name = "tblCategory";
            this.tblCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tblCategory.RowCount = 4;
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblCategory.Size = new System.Drawing.Size(317, 445);
            this.tblCategory.TabIndex = 0;
            // 
            // lstVideosWithCategory
            // 
            this.lstVideosWithCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVideosWithCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVideosWithCategory.FormattingEnabled = true;
            this.lstVideosWithCategory.HorizontalScrollbar = true;
            this.lstVideosWithCategory.ItemHeight = 25;
            this.lstVideosWithCategory.Location = new System.Drawing.Point(3, 69);
            this.lstVideosWithCategory.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lstVideosWithCategory.Name = "lstVideosWithCategory";
            this.lstVideosWithCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstVideosWithCategory.ScrollAlwaysVisible = true;
            this.lstVideosWithCategory.Size = new System.Drawing.Size(311, 375);
            this.lstVideosWithCategory.TabIndex = 1;
            // 
            // lblCategoryPlaylist
            // 
            this.lblCategoryPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategoryPlaylist.AutoSize = true;
            this.lblCategoryPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryPlaylist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCategoryPlaylist.Location = new System.Drawing.Point(5, 5);
            this.lblCategoryPlaylist.Margin = new System.Windows.Forms.Padding(5);
            this.lblCategoryPlaylist.Name = "lblCategoryPlaylist";
            this.lblCategoryPlaylist.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCategoryPlaylist.Size = new System.Drawing.Size(307, 58);
            this.lblCategoryPlaylist.TabIndex = 0;
            this.lblCategoryPlaylist.Text = "Videos with Same Category";
            this.lblCategoryPlaylist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabTags
            // 
            this.tabTags.Controls.Add(this.tblTags);
            this.tabTags.Location = new System.Drawing.Point(4, 35);
            this.tabTags.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tabTags.Name = "tabTags";
            this.tabTags.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tabTags.Size = new System.Drawing.Size(323, 448);
            this.tabTags.TabIndex = 1;
            this.tabTags.Text = "Tags";
            this.tabTags.UseVisualStyleBackColor = true;
            // 
            // tblTags
            // 
            this.tblTags.ColumnCount = 1;
            this.tblTags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblTags.Controls.Add(this.lblVideosWithSameTag, 0, 2);
            this.tblTags.Controls.Add(this.lblVideoTags, 0, 0);
            this.tblTags.Controls.Add(this.lstVideoTags, 0, 1);
            this.tblTags.Controls.Add(this.lstVideosWithSameTag, 0, 3);
            this.tblTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTags.Location = new System.Drawing.Point(3, 1);
            this.tblTags.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tblTags.Name = "tblTags";
            this.tblTags.RowCount = 6;
            this.tblTags.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblTags.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.77359F));
            this.tblTags.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.018868F));
            this.tblTags.Size = new System.Drawing.Size(317, 446);
            this.tblTags.TabIndex = 0;
            // 
            // lblVideosWithSameTag
            // 
            this.lblVideosWithSameTag.AutoSize = true;
            this.lblVideosWithSameTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVideosWithSameTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideosWithSameTag.Location = new System.Drawing.Point(5, 166);
            this.lblVideosWithSameTag.Margin = new System.Windows.Forms.Padding(5);
            this.lblVideosWithSameTag.Name = "lblVideosWithSameTag";
            this.lblVideosWithSameTag.Size = new System.Drawing.Size(307, 29);
            this.lblVideosWithSameTag.TabIndex = 3;
            this.lblVideosWithSameTag.Text = "Videos with Same Tag";
            this.lblVideosWithSameTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVideoTags
            // 
            this.lblVideoTags.AutoSize = true;
            this.lblVideoTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVideoTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideoTags.Location = new System.Drawing.Point(5, 5);
            this.lblVideoTags.Margin = new System.Windows.Forms.Padding(5);
            this.lblVideoTags.Name = "lblVideoTags";
            this.lblVideoTags.Size = new System.Drawing.Size(307, 29);
            this.lblVideoTags.TabIndex = 1;
            this.lblVideoTags.Text = "Video\'s Tags";
            this.lblVideoTags.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lstVideoTags
            // 
            this.lstVideoTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVideoTags.FormattingEnabled = true;
            this.lstVideoTags.ItemHeight = 26;
            this.lstVideoTags.Location = new System.Drawing.Point(3, 40);
            this.lstVideoTags.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lstVideoTags.Name = "lstVideoTags";
            this.lstVideoTags.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstVideoTags.ScrollAlwaysVisible = true;
            this.lstVideoTags.Size = new System.Drawing.Size(311, 120);
            this.lstVideoTags.TabIndex = 2;
            // 
            // lstVideosWithSameTag
            // 
            this.lstVideosWithSameTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVideosWithSameTag.FormattingEnabled = true;
            this.lstVideosWithSameTag.HorizontalScrollbar = true;
            this.lstVideosWithSameTag.ItemHeight = 26;
            this.lstVideosWithSameTag.Location = new System.Drawing.Point(3, 201);
            this.lstVideosWithSameTag.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lstVideosWithSameTag.Name = "lstVideosWithSameTag";
            this.lstVideosWithSameTag.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstVideosWithSameTag.ScrollAlwaysVisible = true;
            this.lstVideosWithSameTag.Size = new System.Drawing.Size(311, 232);
            this.lstVideosWithSameTag.TabIndex = 4;
            // 
            // frmMediaPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1141, 561);
            this.Controls.Add(this.tblMediaPlayer);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "frmMediaPlayer";
            this.Text = "Media Player";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tblMediaPlayer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayer)).EndInit();
            this.tblVideoInformation.ResumeLayout(false);
            this.tblVideoInformation.PerformLayout();
            this.tabVideoInformation.ResumeLayout(false);
            this.tabVideos.ResumeLayout(false);
            this.tblSearchVideos.ResumeLayout(false);
            this.tblSearchVideos.PerformLayout();
            this.tabCategory.ResumeLayout(false);
            this.tblCategory.ResumeLayout(false);
            this.tblCategory.PerformLayout();
            this.tabTags.ResumeLayout(false);
            this.tblTags.ResumeLayout(false);
            this.tblTags.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tblMediaPlayer;
        private AxWMPLib.AxWindowsMediaPlayer VideoPlayer;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tagsToolStripMenuItem;
        private System.Windows.Forms.Timer tmrTimer;
        private System.Windows.Forms.TableLayoutPanel tblVideoInformation;
        private System.Windows.Forms.TabControl tabVideoInformation;
        private System.Windows.Forms.TabPage tabVideos;
        private System.Windows.Forms.ListBox PlayList;
        private System.Windows.Forms.TableLayoutPanel tblSearchVideos;
        private System.Windows.Forms.TextBox txtSearchVideos;
        private System.Windows.Forms.Button btnSearchVideos;
        private System.Windows.Forms.TabPage tabCategory;
        private System.Windows.Forms.TableLayoutPanel tblCategory;
        private System.Windows.Forms.Label lblCategoryPlaylist;
        private System.Windows.Forms.ListBox lstVideosWithCategory;
        private System.Windows.Forms.TabPage tabTags;
        private System.Windows.Forms.TableLayoutPanel tblTags;
        private System.Windows.Forms.Label lblVideosWithSameTag;
        private System.Windows.Forms.ListBox lstVideoTags;
        private System.Windows.Forms.ListBox lstVideosWithSameTag;
        private System.Windows.Forms.Label lblVideoTitle;
        private System.Windows.Forms.ToolStripMenuItem videosToolStripMenuItem;
        private System.Windows.Forms.Label lblVideoTags;
    }
}


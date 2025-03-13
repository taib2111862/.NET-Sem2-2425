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
            this.tblMediaPlayer = new System.Windows.Forms.TableLayoutPanel();
            this.VideoPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.tblVideoInformation = new System.Windows.Forms.TableLayoutPanel();
            this.tabVideoInformation = new System.Windows.Forms.TabControl();
            this.tabVideos = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tblSearchVideos = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearchVideos = new System.Windows.Forms.TextBox();
            this.btnSearchVideos = new System.Windows.Forms.Button();
            this.tabCategory = new System.Windows.Forms.TabPage();
            this.tblCategory = new System.Windows.Forms.TableLayoutPanel();
            this.lblCategoryPlaylist = new System.Windows.Forms.Label();
            this.lstVideosWithCategory = new System.Windows.Forms.ListBox();
            this.lblChangeCategory = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCharactersLimit = new System.Windows.Forms.Label();
            this.txtNewCategory = new System.Windows.Forms.TextBox();
            this.lblNewCategory = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabTags = new System.Windows.Forms.TabPage();
            this.tblTags = new System.Windows.Forms.TableLayoutPanel();
            this.lblVideosWithSameTag = new System.Windows.Forms.Label();
            this.lblVideoTags = new System.Windows.Forms.Label();
            this.lstVideoTags = new System.Windows.Forms.ListBox();
            this.lstVideosWithSameTag = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAddTag = new System.Windows.Forms.Label();
            this.lblVideoTitle = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tblMediaPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayer)).BeginInit();
            this.tblVideoInformation.SuspendLayout();
            this.tabVideoInformation.SuspendLayout();
            this.tabVideos.SuspendLayout();
            this.tblSearchVideos.SuspendLayout();
            this.tabCategory.SuspendLayout();
            this.tblCategory.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabTags.SuspendLayout();
            this.tblTags.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1582, 31);
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFileEvent);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriesToolStripMenuItem,
            this.tagsToolStripMenuItem});
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
            // tblMediaPlayer
            // 
            this.tblMediaPlayer.AutoSize = true;
            this.tblMediaPlayer.ColumnCount = 2;
            this.tblMediaPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.20892F));
            this.tblMediaPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 507F));
            this.tblMediaPlayer.Controls.Add(this.VideoPlayer, 0, 0);
            this.tblMediaPlayer.Controls.Add(this.tblVideoInformation, 1, 0);
            this.tblMediaPlayer.Location = new System.Drawing.Point(0, 31);
            this.tblMediaPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.tblMediaPlayer.Name = "tblMediaPlayer";
            this.tblMediaPlayer.RowCount = 1;
            this.tblMediaPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.67347F));
            this.tblMediaPlayer.Size = new System.Drawing.Size(1573, 630);
            this.tblMediaPlayer.TabIndex = 5;
            // 
            // VideoPlayer
            // 
            this.VideoPlayer.Enabled = true;
            this.VideoPlayer.Location = new System.Drawing.Point(0, 0);
            this.VideoPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.VideoPlayer.Name = "VideoPlayer";
            this.VideoPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VideoPlayer.OcxState")));
            this.VideoPlayer.Size = new System.Drawing.Size(1066, 618);
            this.VideoPlayer.TabIndex = 5;
            // 
            // tmrTimer
            // 
            this.tmrTimer.Tick += new System.EventHandler(this.TimerEvent);
            // 
            // tblVideoInformation
            // 
            this.tblVideoInformation.ColumnCount = 1;
            this.tblVideoInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblVideoInformation.Controls.Add(this.tabVideoInformation, 0, 1);
            this.tblVideoInformation.Controls.Add(this.lblVideoTitle, 0, 0);
            this.tblVideoInformation.Location = new System.Drawing.Point(1069, 3);
            this.tblVideoInformation.Name = "tblVideoInformation";
            this.tblVideoInformation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tblVideoInformation.RowCount = 2;
            this.tblVideoInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.890499F));
            this.tblVideoInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.1095F));
            this.tblVideoInformation.Size = new System.Drawing.Size(501, 624);
            this.tblVideoInformation.TabIndex = 6;
            // 
            // tabVideoInformation
            // 
            this.tabVideoInformation.Controls.Add(this.tabVideos);
            this.tabVideoInformation.Controls.Add(this.tabCategory);
            this.tabVideoInformation.Controls.Add(this.tabTags);
            this.tabVideoInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabVideoInformation.Location = new System.Drawing.Point(17, 52);
            this.tabVideoInformation.Name = "tabVideoInformation";
            this.tabVideoInformation.SelectedIndex = 0;
            this.tabVideoInformation.Size = new System.Drawing.Size(481, 560);
            this.tabVideoInformation.TabIndex = 7;
            // 
            // tabVideos
            // 
            this.tabVideos.Controls.Add(this.listBox1);
            this.tabVideos.Controls.Add(this.tblSearchVideos);
            this.tabVideos.Location = new System.Drawing.Point(4, 35);
            this.tabVideos.Name = "tabVideos";
            this.tabVideos.Padding = new System.Windows.Forms.Padding(3);
            this.tabVideos.Size = new System.Drawing.Size(473, 521);
            this.tabVideos.TabIndex = 2;
            this.tabVideos.Text = "Videos";
            this.tabVideos.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 26;
            this.listBox1.Location = new System.Drawing.Point(3, 61);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(464, 446);
            this.listBox1.TabIndex = 1;
            // 
            // tblSearchVideos
            // 
            this.tblSearchVideos.ColumnCount = 2;
            this.tblSearchVideos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.42241F));
            this.tblSearchVideos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.57758F));
            this.tblSearchVideos.Controls.Add(this.txtSearchVideos, 1, 0);
            this.tblSearchVideos.Controls.Add(this.btnSearchVideos, 0, 0);
            this.tblSearchVideos.Location = new System.Drawing.Point(3, 6);
            this.tblSearchVideos.Name = "tblSearchVideos";
            this.tblSearchVideos.RowCount = 1;
            this.tblSearchVideos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSearchVideos.Size = new System.Drawing.Size(464, 52);
            this.tblSearchVideos.TabIndex = 0;
            // 
            // txtSearchVideos
            // 
            this.txtSearchVideos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchVideos.Location = new System.Drawing.Point(5, 5);
            this.txtSearchVideos.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearchVideos.Name = "txtSearchVideos";
            this.txtSearchVideos.Size = new System.Drawing.Size(401, 34);
            this.txtSearchVideos.TabIndex = 0;
            // 
            // btnSearchVideos
            // 
            this.btnSearchVideos.AutoSize = true;
            this.btnSearchVideos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchVideos.BackgroundImage")));
            this.btnSearchVideos.Location = new System.Drawing.Point(414, 3);
            this.btnSearchVideos.Name = "btnSearchVideos";
            this.btnSearchVideos.Size = new System.Drawing.Size(47, 36);
            this.btnSearchVideos.TabIndex = 1;
            this.btnSearchVideos.UseVisualStyleBackColor = true;
            // 
            // tabCategory
            // 
            this.tabCategory.Controls.Add(this.tblCategory);
            this.tabCategory.Location = new System.Drawing.Point(4, 35);
            this.tabCategory.Margin = new System.Windows.Forms.Padding(10);
            this.tabCategory.Name = "tabCategory";
            this.tabCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategory.Size = new System.Drawing.Size(473, 521);
            this.tabCategory.TabIndex = 0;
            this.tabCategory.Text = "Category";
            this.tabCategory.UseVisualStyleBackColor = true;
            // 
            // tblCategory
            // 
            this.tblCategory.ColumnCount = 1;
            this.tblCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCategory.Controls.Add(this.lblCategoryPlaylist, 0, 0);
            this.tblCategory.Controls.Add(this.lstVideosWithCategory, 0, 1);
            this.tblCategory.Controls.Add(this.lblChangeCategory, 0, 2);
            this.tblCategory.Controls.Add(this.tableLayoutPanel4, 0, 7);
            this.tblCategory.Controls.Add(this.lblCharactersLimit, 0, 5);
            this.tblCategory.Controls.Add(this.txtNewCategory, 0, 6);
            this.tblCategory.Controls.Add(this.lblNewCategory, 0, 4);
            this.tblCategory.Controls.Add(this.comboBox1, 0, 3);
            this.tblCategory.Location = new System.Drawing.Point(6, 6);
            this.tblCategory.Name = "tblCategory";
            this.tblCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tblCategory.RowCount = 8;
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.66667F));
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.33334F));
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tblCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tblCategory.Size = new System.Drawing.Size(461, 538);
            this.tblCategory.TabIndex = 0;
            // 
            // lblCategoryPlaylist
            // 
            this.lblCategoryPlaylist.AutoSize = true;
            this.lblCategoryPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryPlaylist.Location = new System.Drawing.Point(83, 5);
            this.lblCategoryPlaylist.Margin = new System.Windows.Forms.Padding(5);
            this.lblCategoryPlaylist.Name = "lblCategoryPlaylist";
            this.lblCategoryPlaylist.Size = new System.Drawing.Size(373, 31);
            this.lblCategoryPlaylist.TabIndex = 0;
            this.lblCategoryPlaylist.Text = "Videos with Same Category";
            // 
            // lstVideosWithCategory
            // 
            this.lstVideosWithCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVideosWithCategory.FormattingEnabled = true;
            this.lstVideosWithCategory.ItemHeight = 29;
            this.lstVideosWithCategory.Location = new System.Drawing.Point(7, 66);
            this.lstVideosWithCategory.Name = "lstVideosWithCategory";
            this.lstVideosWithCategory.Size = new System.Drawing.Size(451, 149);
            this.lstVideosWithCategory.TabIndex = 1;
            // 
            // lblChangeCategory
            // 
            this.lblChangeCategory.AutoSize = true;
            this.lblChangeCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeCategory.Location = new System.Drawing.Point(214, 225);
            this.lblChangeCategory.Margin = new System.Windows.Forms.Padding(5);
            this.lblChangeCategory.Name = "lblChangeCategory";
            this.lblChangeCategory.Size = new System.Drawing.Size(242, 31);
            this.lblChangeCategory.TabIndex = 2;
            this.lblChangeCategory.Text = "Change Category";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btnSave, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnCancel, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(13, 462);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(445, 67);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(70, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(150, 50);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(292, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 50);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblCharactersLimit
            // 
            this.lblCharactersLimit.AutoSize = true;
            this.lblCharactersLimit.Location = new System.Drawing.Point(390, 375);
            this.lblCharactersLimit.Margin = new System.Windows.Forms.Padding(5);
            this.lblCharactersLimit.Name = "lblCharactersLimit";
            this.lblCharactersLimit.Size = new System.Drawing.Size(66, 26);
            this.lblCharactersLimit.TabIndex = 7;
            this.lblCharactersLimit.Text = "0/255";
            // 
            // txtNewCategory
            // 
            this.txtNewCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewCategory.Location = new System.Drawing.Point(5, 415);
            this.txtNewCategory.Margin = new System.Windows.Forms.Padding(5);
            this.txtNewCategory.Name = "txtNewCategory";
            this.txtNewCategory.Size = new System.Drawing.Size(451, 34);
            this.txtNewCategory.TabIndex = 8;
            // 
            // lblNewCategory
            // 
            this.lblNewCategory.AutoSize = true;
            this.lblNewCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCategory.Location = new System.Drawing.Point(257, 328);
            this.lblNewCategory.Margin = new System.Windows.Forms.Padding(5);
            this.lblNewCategory.Name = "lblNewCategory";
            this.lblNewCategory.Size = new System.Drawing.Size(199, 31);
            this.lblNewCategory.TabIndex = 4;
            this.lblNewCategory.Text = "New Category";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(5, 274);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(451, 34);
            this.comboBox1.TabIndex = 3;
            // 
            // tabTags
            // 
            this.tabTags.Controls.Add(this.tblTags);
            this.tabTags.Location = new System.Drawing.Point(4, 35);
            this.tabTags.Name = "tabTags";
            this.tabTags.Padding = new System.Windows.Forms.Padding(3);
            this.tabTags.Size = new System.Drawing.Size(473, 521);
            this.tabTags.TabIndex = 1;
            this.tabTags.Text = "Tags";
            this.tabTags.UseVisualStyleBackColor = true;
            // 
            // tblTags
            // 
            this.tblTags.ColumnCount = 1;
            this.tblTags.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTags.Controls.Add(this.lblVideosWithSameTag, 0, 2);
            this.tblTags.Controls.Add(this.lblVideoTags, 0, 0);
            this.tblTags.Controls.Add(this.lstVideoTags, 0, 1);
            this.tblTags.Controls.Add(this.lstVideosWithSameTag, 0, 3);
            this.tblTags.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tblTags.Location = new System.Drawing.Point(6, 6);
            this.tblTags.Name = "tblTags";
            this.tblTags.RowCount = 5;
            this.tblTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.28571F));
            this.tblTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.71429F));
            this.tblTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tblTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tblTags.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 405F));
            this.tblTags.Size = new System.Drawing.Size(461, 711);
            this.tblTags.TabIndex = 0;
            // 
            // lblVideosWithSameTag
            // 
            this.lblVideosWithSameTag.AutoSize = true;
            this.lblVideosWithSameTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideosWithSameTag.Location = new System.Drawing.Point(152, 153);
            this.lblVideosWithSameTag.Margin = new System.Windows.Forms.Padding(5);
            this.lblVideosWithSameTag.Name = "lblVideosWithSameTag";
            this.lblVideosWithSameTag.Size = new System.Drawing.Size(304, 31);
            this.lblVideosWithSameTag.TabIndex = 3;
            this.lblVideosWithSameTag.Text = "Videos with Same Tag";
            // 
            // lblVideoTags
            // 
            this.lblVideoTags.AutoSize = true;
            this.lblVideoTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideoTags.Location = new System.Drawing.Point(274, 5);
            this.lblVideoTags.Margin = new System.Windows.Forms.Padding(5);
            this.lblVideoTags.Name = "lblVideoTags";
            this.lblVideoTags.Size = new System.Drawing.Size(182, 31);
            this.lblVideoTags.TabIndex = 1;
            this.lblVideoTags.Text = "Video\'s Tags";
            // 
            // lstVideoTags
            // 
            this.lstVideoTags.FormattingEnabled = true;
            this.lstVideoTags.ItemHeight = 26;
            this.lstVideoTags.Location = new System.Drawing.Point(3, 61);
            this.lstVideoTags.Name = "lstVideoTags";
            this.lstVideoTags.Size = new System.Drawing.Size(455, 82);
            this.lstVideoTags.TabIndex = 2;
            // 
            // lstVideosWithSameTag
            // 
            this.lstVideosWithSameTag.FormattingEnabled = true;
            this.lstVideosWithSameTag.ItemHeight = 26;
            this.lstVideosWithSameTag.Location = new System.Drawing.Point(3, 193);
            this.lstVideosWithSameTag.Name = "lstVideosWithSameTag";
            this.lstVideosWithSameTag.Size = new System.Drawing.Size(455, 108);
            this.lstVideosWithSameTag.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblAddTag, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 308);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.41414F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.58586F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(455, 201);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // lblAddTag
            // 
            this.lblAddTag.AutoSize = true;
            this.lblAddTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddTag.Location = new System.Drawing.Point(327, 5);
            this.lblAddTag.Margin = new System.Windows.Forms.Padding(5);
            this.lblAddTag.Name = "lblAddTag";
            this.lblAddTag.Size = new System.Drawing.Size(123, 31);
            this.lblAddTag.TabIndex = 4;
            this.lblAddTag.Text = "Add Tag";
            // 
            // lblVideoTitle
            // 
            this.lblVideoTitle.AutoSize = true;
            this.lblVideoTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideoTitle.Location = new System.Drawing.Point(410, 5);
            this.lblVideoTitle.Margin = new System.Windows.Forms.Padding(5);
            this.lblVideoTitle.Name = "lblVideoTitle";
            this.lblVideoTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblVideoTitle.Size = new System.Drawing.Size(86, 31);
            this.lblVideoTitle.TabIndex = 8;
            this.lblVideoTitle.Text = "label1";
            this.lblVideoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmMediaPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1582, 659);
            this.Controls.Add(this.tblMediaPlayer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tabTags.ResumeLayout(false);
            this.tblTags.ResumeLayout(false);
            this.tblTags.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TableLayoutPanel tblSearchVideos;
        private System.Windows.Forms.TextBox txtSearchVideos;
        private System.Windows.Forms.Button btnSearchVideos;
        private System.Windows.Forms.TabPage tabCategory;
        private System.Windows.Forms.TableLayoutPanel tblCategory;
        private System.Windows.Forms.Label lblCategoryPlaylist;
        private System.Windows.Forms.ListBox lstVideosWithCategory;
        private System.Windows.Forms.Label lblChangeCategory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCharactersLimit;
        private System.Windows.Forms.TextBox txtNewCategory;
        private System.Windows.Forms.Label lblNewCategory;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabTags;
        private System.Windows.Forms.TableLayoutPanel tblTags;
        private System.Windows.Forms.Label lblVideosWithSameTag;
        private System.Windows.Forms.Label lblVideoTags;
        private System.Windows.Forms.ListBox lstVideoTags;
        private System.Windows.Forms.ListBox lstVideosWithSameTag;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblAddTag;
        private System.Windows.Forms.Label lblVideoTitle;
    }
}


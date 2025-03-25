namespace VideoPlayer
{
    partial class ManageForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.ManageTabControl = new System.Windows.Forms.TabControl();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.tabTags = new System.Windows.Forms.TabPage();
            this.tabVideos = new System.Windows.Forms.TabPage();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnUpdateCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.dgvTags = new System.Windows.Forms.DataGridView();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.btnUpdateTag = new System.Windows.Forms.Button();
            this.btnDeleteTag = new System.Windows.Forms.Button();
            this.dgvVideos = new System.Windows.Forms.DataGridView();
            this.btnAddVideo = new System.Windows.Forms.Button();
            this.btnUpdateVideo = new System.Windows.Forms.Button();
            this.btnDeleteVideo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideos)).BeginInit();
            this.tabCategories.SuspendLayout();
            this.tabTags.SuspendLayout();
            this.tabVideos.SuspendLayout();
            this.ManageTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ManageTabControl
            // 
            this.ManageTabControl.Controls.Add(this.tabCategories);
            this.ManageTabControl.Controls.Add(this.tabTags);
            this.ManageTabControl.Controls.Add(this.tabVideos);
            this.ManageTabControl.Location = new System.Drawing.Point(12, 12);
            this.ManageTabControl.Name = "ManageTabControl";
            this.ManageTabControl.SelectedIndex = 0;
            this.ManageTabControl.Size = new System.Drawing.Size(776, 426);
            this.ManageTabControl.TabIndex = 0;
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.dgvCategories);
            this.tabCategories.Controls.Add(this.btnAddCategory);
            this.tabCategories.Controls.Add(this.btnUpdateCategory);
            this.tabCategories.Controls.Add(this.btnDeleteCategory);
            this.tabCategories.Location = new System.Drawing.Point(4, 22);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategories.Size = new System.Drawing.Size(768, 400);
            this.tabCategories.TabIndex = 0;
            this.tabCategories.Text = "Categories";
            this.tabCategories.UseVisualStyleBackColor = true;
            // 
            // tabTags
            // 
            this.tabTags.Controls.Add(this.dgvTags);
            this.tabTags.Controls.Add(this.btnAddTag);
            this.tabTags.Controls.Add(this.btnUpdateTag);
            this.tabTags.Controls.Add(this.btnDeleteTag);
            this.tabTags.Location = new System.Drawing.Point(4, 22);
            this.tabTags.Name = "tabTags";
            this.tabTags.Padding = new System.Windows.Forms.Padding(3);
            this.tabTags.Size = new System.Drawing.Size(768, 400);
            this.tabTags.TabIndex = 1;
            this.tabTags.Text = "Tags";
            this.tabTags.UseVisualStyleBackColor = true;
            // 
            // tabVideos
            // 
            this.tabVideos.Controls.Add(this.dgvVideos);
            this.tabVideos.Controls.Add(this.btnAddVideo);
            this.tabVideos.Controls.Add(this.btnUpdateVideo);
            this.tabVideos.Controls.Add(this.btnDeleteVideo);
            this.tabVideos.Location = new System.Drawing.Point(4, 22);
            this.tabVideos.Name = "tabVideos";
            this.tabVideos.Padding = new System.Windows.Forms.Padding(3);
            this.tabVideos.Size = new System.Drawing.Size(768, 400);
            this.tabVideos.TabIndex = 2;
            this.tabVideos.Text = "Videos";
            this.tabVideos.UseVisualStyleBackColor = true;
            // 
            // dgvCategories
            // 
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Location = new System.Drawing.Point(6, 6);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.Size = new System.Drawing.Size(756, 340);
            this.dgvCategories.TabIndex = 0;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(6, 352);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(75, 23);
            this.btnAddCategory.TabIndex = 1;
            this.btnAddCategory.Text = "Add";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnUpdateCategory
            // 
            this.btnUpdateCategory.Location = new System.Drawing.Point(87, 352);
            this.btnUpdateCategory.Name = "btnUpdateCategory";
            this.btnUpdateCategory.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateCategory.TabIndex = 2;
            this.btnUpdateCategory.Text = "Update";
            this.btnUpdateCategory.UseVisualStyleBackColor = true;
            this.btnUpdateCategory.Click += new System.EventHandler(this.btnUpdateCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(168, 352);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCategory.TabIndex = 3;
            this.btnDeleteCategory.Text = "Delete";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // dgvTags
            // 
            this.dgvTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTags.Location = new System.Drawing.Point(6, 6);
            this.dgvTags.Name = "dgvTags";
            this.dgvTags.Size = new System.Drawing.Size(756, 340);
            this.dgvTags.TabIndex = 0;
            // 
            // btnAddTag
            // 
            this.btnAddTag.Location = new System.Drawing.Point(6, 352);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(75, 23);
            this.btnAddTag.TabIndex = 1;
            this.btnAddTag.Text = "Add";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // btnUpdateTag
            // 
            this.btnUpdateTag.Location = new System.Drawing.Point(87, 352);
            this.btnUpdateTag.Name = "btnUpdateTag";
            this.btnUpdateTag.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateTag.TabIndex = 2;
            this.btnUpdateTag.Text = "Update";
            this.btnUpdateTag.UseVisualStyleBackColor = true;
            this.btnUpdateTag.Click += new System.EventHandler(this.btnUpdateTag_Click);
            // 
            // btnDeleteTag
            // 
            this.btnDeleteTag.Location = new System.Drawing.Point(168, 352);
            this.btnDeleteTag.Name = "btnDeleteTag";
            this.btnDeleteTag.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTag.TabIndex = 3;
            this.btnDeleteTag.Text = "Delete";
            this.btnDeleteTag.UseVisualStyleBackColor = true;
            this.btnDeleteTag.Click += new System.EventHandler(this.btnDeleteTag_Click);
            // 
            // dgvVideos
            // 
            this.dgvVideos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVideos.Location = new System.Drawing.Point(6, 6);
            this.dgvVideos.Name = "dgvVideos";
            this.dgvVideos.Size = new System.Drawing.Size(756, 340);
            this.dgvVideos.TabIndex = 0;
            // 
            // btnAddVideo
            // 
            this.btnAddVideo.Location = new System.Drawing.Point(6, 352);
            this.btnAddVideo.Name = "btnAddVideo";
            this.btnAddVideo.Size = new System.Drawing.Size(75, 23);
            this.btnAddVideo.TabIndex = 1;
            this.btnAddVideo.Text = "Add";
            this.btnAddVideo.UseVisualStyleBackColor = true;
            this.btnAddVideo.Click += new System.EventHandler(this.btnAddVideo_Click);
            // 
            // btnUpdateVideo
            // 
            this.btnUpdateVideo.Location = new System.Drawing.Point(87, 352);
            this.btnUpdateVideo.Name = "btnUpdateVideo";
            this.btnUpdateVideo.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateVideo.TabIndex = 2;
            this.btnUpdateVideo.Text = "Update";
            this.btnUpdateVideo.UseVisualStyleBackColor = true;
            this.btnUpdateVideo.Click += new System.EventHandler(this.btnUpdateVideo_Click);
            // 
            // btnDeleteVideo
            // 
            this.btnDeleteVideo.Location = new System.Drawing.Point(168, 352);
            this.btnDeleteVideo.Name = "btnDeleteVideo";
            this.btnDeleteVideo.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteVideo.TabIndex = 3;
            this.btnDeleteVideo.Text = "Delete";
            this.btnDeleteVideo.UseVisualStyleBackColor = true;
            this.btnDeleteVideo.Click += new System.EventHandler(this.btnDeleteVideo_Click);
            // 
            // ManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ManageTabControl);
            this.Name = "ManageForm";
            this.Text = "Manage Categories, Tags, and Videos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideos)).EndInit();
            this.tabCategories.ResumeLayout(false);
            this.tabTags.ResumeLayout(false);
            this.tabVideos.ResumeLayout(false);
            this.ManageTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl ManageTabControl;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.TabPage tabTags;
        private System.Windows.Forms.TabPage tabVideos;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnUpdateCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.DataGridView dgvTags;
        private System.Windows.Forms.Button btnAddTag;
        private System.Windows.Forms.Button btnUpdateTag;
        private System.Windows.Forms.Button btnDeleteTag;
        private System.Windows.Forms.DataGridView dgvVideos;
        private System.Windows.Forms.Button btnAddVideo;
        private System.Windows.Forms.Button btnUpdateVideo;
        private System.Windows.Forms.Button btnDeleteVideo;
    }
}
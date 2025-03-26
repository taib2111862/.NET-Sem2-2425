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
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnUpdateCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.tabTags = new System.Windows.Forms.TabPage();
            this.dgvTags = new System.Windows.Forms.DataGridView();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.btnUpdateTag = new System.Windows.Forms.Button();
            this.btnDeleteTag = new System.Windows.Forms.Button();
            this.tabVideos = new System.Windows.Forms.TabPage();
            this.dgvVideos = new System.Windows.Forms.DataGridView();
            this.btnAddVideo = new System.Windows.Forms.Button();
            this.btnUpdateVideo = new System.Windows.Forms.Button();
            this.btnDeleteVideo = new System.Windows.Forms.Button();
            this.ManageTabControl.SuspendLayout();
            this.tabCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.tabTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).BeginInit();
            this.tabVideos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideos)).BeginInit();
            this.SuspendLayout();
            // 
            // ManageTabControl
            // 
            this.ManageTabControl.Controls.Add(this.tabCategories);
            this.ManageTabControl.Controls.Add(this.tabTags);
            this.ManageTabControl.Controls.Add(this.tabVideos);
            this.ManageTabControl.Location = new System.Drawing.Point(16, 15);
            this.ManageTabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ManageTabControl.Name = "ManageTabControl";
            this.ManageTabControl.SelectedIndex = 0;
            this.ManageTabControl.Size = new System.Drawing.Size(1035, 524);
            this.ManageTabControl.TabIndex = 0;
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.dgvCategories);
            this.tabCategories.Controls.Add(this.btnAddCategory);
            this.tabCategories.Controls.Add(this.btnUpdateCategory);
            this.tabCategories.Controls.Add(this.btnDeleteCategory);
            this.tabCategories.Location = new System.Drawing.Point(4, 25);
            this.tabCategories.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCategories.Size = new System.Drawing.Size(1027, 495);
            this.tabCategories.TabIndex = 0;
            this.tabCategories.Text = "Categories";
            this.tabCategories.UseVisualStyleBackColor = true;
            // 
            // dgvCategories
            // 
            this.dgvCategories.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Location = new System.Drawing.Point(8, 7);
            this.dgvCategories.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.RowHeadersWidth = 51;
            this.dgvCategories.Size = new System.Drawing.Size(1008, 418);
            this.dgvCategories.TabIndex = 0;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(8, 433);
            this.btnAddCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(100, 28);
            this.btnAddCategory.TabIndex = 1;
            this.btnAddCategory.Text = "Add";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnUpdateCategory
            // 
            this.btnUpdateCategory.Location = new System.Drawing.Point(116, 433);
            this.btnUpdateCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateCategory.Name = "btnUpdateCategory";
            this.btnUpdateCategory.Size = new System.Drawing.Size(100, 28);
            this.btnUpdateCategory.TabIndex = 2;
            this.btnUpdateCategory.Text = "Update";
            this.btnUpdateCategory.UseVisualStyleBackColor = true;
            this.btnUpdateCategory.Click += new System.EventHandler(this.btnUpdateCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(224, 433);
            this.btnDeleteCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteCategory.TabIndex = 3;
            this.btnDeleteCategory.Text = "Delete";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // tabTags
            // 
            this.tabTags.Controls.Add(this.dgvTags);
            this.tabTags.Controls.Add(this.btnAddTag);
            this.tabTags.Controls.Add(this.btnUpdateTag);
            this.tabTags.Controls.Add(this.btnDeleteTag);
            this.tabTags.Location = new System.Drawing.Point(4, 25);
            this.tabTags.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabTags.Name = "tabTags";
            this.tabTags.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabTags.Size = new System.Drawing.Size(1027, 495);
            this.tabTags.TabIndex = 1;
            this.tabTags.Text = "Tags";
            this.tabTags.UseVisualStyleBackColor = true;
            // 
            // dgvTags
            // 
            this.dgvTags.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTags.Location = new System.Drawing.Point(8, 7);
            this.dgvTags.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTags.Name = "dgvTags";
            this.dgvTags.RowHeadersWidth = 51;
            this.dgvTags.Size = new System.Drawing.Size(1008, 418);
            this.dgvTags.TabIndex = 0;
            // 
            // btnAddTag
            // 
            this.btnAddTag.Location = new System.Drawing.Point(8, 433);
            this.btnAddTag.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(100, 28);
            this.btnAddTag.TabIndex = 1;
            this.btnAddTag.Text = "Add";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // btnUpdateTag
            // 
            this.btnUpdateTag.Location = new System.Drawing.Point(116, 433);
            this.btnUpdateTag.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateTag.Name = "btnUpdateTag";
            this.btnUpdateTag.Size = new System.Drawing.Size(100, 28);
            this.btnUpdateTag.TabIndex = 2;
            this.btnUpdateTag.Text = "Update";
            this.btnUpdateTag.UseVisualStyleBackColor = true;
            this.btnUpdateTag.Click += new System.EventHandler(this.btnUpdateTag_Click);
            // 
            // btnDeleteTag
            // 
            this.btnDeleteTag.Location = new System.Drawing.Point(224, 433);
            this.btnDeleteTag.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteTag.Name = "btnDeleteTag";
            this.btnDeleteTag.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteTag.TabIndex = 3;
            this.btnDeleteTag.Text = "Delete";
            this.btnDeleteTag.UseVisualStyleBackColor = true;
            this.btnDeleteTag.Click += new System.EventHandler(this.btnDeleteTag_Click);
            // 
            // tabVideos
            // 
            this.tabVideos.Controls.Add(this.dgvVideos);
            this.tabVideos.Controls.Add(this.btnAddVideo);
            this.tabVideos.Controls.Add(this.btnUpdateVideo);
            this.tabVideos.Controls.Add(this.btnDeleteVideo);
            this.tabVideos.Location = new System.Drawing.Point(4, 25);
            this.tabVideos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabVideos.Name = "tabVideos";
            this.tabVideos.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabVideos.Size = new System.Drawing.Size(1027, 495);
            this.tabVideos.TabIndex = 2;
            this.tabVideos.Text = "Videos";
            this.tabVideos.UseVisualStyleBackColor = true;
            // 
            // dgvVideos
            // 
            this.dgvVideos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvVideos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVideos.Location = new System.Drawing.Point(8, 7);
            this.dgvVideos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvVideos.Name = "dgvVideos";
            this.dgvVideos.RowHeadersWidth = 51;
            this.dgvVideos.Size = new System.Drawing.Size(1008, 418);
            this.dgvVideos.TabIndex = 0;
            // 
            // btnAddVideo
            // 
            this.btnAddVideo.Location = new System.Drawing.Point(8, 433);
            this.btnAddVideo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddVideo.Name = "btnAddVideo";
            this.btnAddVideo.Size = new System.Drawing.Size(100, 28);
            this.btnAddVideo.TabIndex = 1;
            this.btnAddVideo.Text = "Add";
            this.btnAddVideo.UseVisualStyleBackColor = true;
            this.btnAddVideo.Click += new System.EventHandler(this.btnAddVideo_Click);
            // 
            // btnUpdateVideo
            // 
            this.btnUpdateVideo.Location = new System.Drawing.Point(116, 433);
            this.btnUpdateVideo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateVideo.Name = "btnUpdateVideo";
            this.btnUpdateVideo.Size = new System.Drawing.Size(100, 28);
            this.btnUpdateVideo.TabIndex = 2;
            this.btnUpdateVideo.Text = "Update";
            this.btnUpdateVideo.UseVisualStyleBackColor = true;
            this.btnUpdateVideo.Click += new System.EventHandler(this.btnUpdateVideo_Click);
            // 
            // btnDeleteVideo
            // 
            this.btnDeleteVideo.Location = new System.Drawing.Point(224, 433);
            this.btnDeleteVideo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteVideo.Name = "btnDeleteVideo";
            this.btnDeleteVideo.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteVideo.TabIndex = 3;
            this.btnDeleteVideo.Text = "Delete";
            this.btnDeleteVideo.UseVisualStyleBackColor = true;
            this.btnDeleteVideo.Click += new System.EventHandler(this.btnDeleteVideo_Click);
            // 
            // ManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.ManageTabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ManageForm";
            this.Text = "Manage Categories, Tags, and Videos";
            this.ManageTabControl.ResumeLayout(false);
            this.tabCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.tabTags.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).EndInit();
            this.tabVideos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideos)).EndInit();
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
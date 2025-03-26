using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VideoPlayer
{
    public partial class ManageForm : Form
    {
        private VideoDatabaseManager dbManager;
        private DataTable dtCategories;
        private DataTable dtTags;
        private DataTable dtVideos;
        public bool HasChanges { get; private set; }

        public ManageForm(int selectedTabIndex = 0)
        {
            InitializeComponent();
            dbManager = new VideoDatabaseManager();
            HasChanges = false;

            // Thêm cột STT cho các DataGridView
            AddSttColumn(dgvCategories);
            AddSttColumn(dgvTags);
            AddSttColumn(dgvVideos);

            // Thêm cột TagsDisplay cho dgvVideos
            if (dgvVideos.Columns["TagsDisplay"] == null)
            {
                DataGridViewTextBoxColumn tagsDisplayColumn = new DataGridViewTextBoxColumn
                {
                    Name = "TagsDisplay",
                    HeaderText = "Tags",
                    ReadOnly = true
                };
                dgvVideos.Columns.Add(tagsDisplayColumn);
            }

            // Sự kiện CellFormatting để hiển thị danh sách tag
            dgvVideos.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex == dgvVideos.Columns["TagsDisplay"].Index && e.RowIndex >= 0)
                {
                    DataRow row = (dgvVideos.Rows[e.RowIndex].DataBoundItem as DataRowView)?.Row;
                    if (row != null)
                    {
                        string tagIds = row["TagIds"]?.ToString();
                        if (!string.IsNullOrEmpty(tagIds))
                        {
                            var tagIdList = tagIds.Split(',').Select(id => int.Parse(id)).ToList();
                            var tagNames = dtTags.AsEnumerable()
                                .Where(r => tagIdList.Contains(r.Field<int>("tag_id")))
                                .Select(r => r.Field<string>("tag_name"))
                                .ToList();
                            e.Value = string.Join(", ", tagNames);
                        }
                        else
                        {
                            e.Value = "";
                        }
                    }
                    else
                    {
                        e.Value = "";
                    }
                }
                // Hiển thị STT
                if (e.ColumnIndex == dgvVideos.Columns["STT"].Index && e.RowIndex >= 0)
                {
                    e.Value = (e.RowIndex + 1).ToString();
                }
            };

            // Sự kiện CellFormatting cho dgvCategories và dgvTags để hiển thị STT
            dgvCategories.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex == dgvCategories.Columns["STT"].Index && e.RowIndex >= 0)
                {
                    e.Value = (e.RowIndex + 1).ToString();
                }
            };

            dgvTags.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex == dgvTags.Columns["STT"].Index && e.RowIndex >= 0)
                {
                    e.Value = (e.RowIndex + 1).ToString();
                }
            };

            LoadCategories();
            LoadTags();
            LoadVideos();
            ManageTabControl.SelectedIndex = selectedTabIndex;
        }

        // Phương thức để thêm cột STT vào DataGridView
        private void AddSttColumn(DataGridView dgv)
        {
            if (dgv.Columns["STT"] == null)
            {
                DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                {
                    Name = "STT",
                    HeaderText = "STT",
                    ReadOnly = true,
                    Width = 50
                };
                dgv.Columns.Add(sttColumn);
            }
        }

        private void LoadCategories()
        {
            dtCategories = dbManager.GetAllCategories();
            dgvCategories.DataSource = dtCategories;

            // Ẩn cột cat_id
            if (dgvCategories.Columns["cat_id"] != null)
            {
                dgvCategories.Columns["cat_id"].Visible = false;
            }

            // Đặt cột STT làm cột đầu tiên
            if (dgvCategories.Columns["STT"] != null)
            {
                dgvCategories.Columns["STT"].DisplayIndex = 0;
            }

            // Đổi tên cột cat_name thành "Category Name"
            if (dgvCategories.Columns["cat_name"] != null)
            {
                dgvCategories.Columns["cat_name"].HeaderText = "Category Name";
            }
        }

        private void LoadTags()
        {
            dtTags = dbManager.GetAllTags();
            dgvTags.DataSource = dtTags;

            // Ẩn cột tag_id
            if (dgvTags.Columns["tag_id"] != null)
            {
                dgvTags.Columns["tag_id"].Visible = false;
            }

            // Đặt cột STT làm cột đầu tiên
            if (dgvTags.Columns["STT"] != null)
            {
                dgvTags.Columns["STT"].DisplayIndex = 0;
            }

            // Đổi tên cột tag_name thành "Tag Name"
            if (dgvTags.Columns["tag_name"] != null)
            {
                dgvTags.Columns["tag_name"].HeaderText = "Tag Name";
            }
        }

        private void LoadVideos()
        {
            dtVideos = dbManager.GetVideosForDataGrid();
            dgvVideos.DataSource = dtVideos;

            // Ẩn các cột không cần thiết
            if (dgvVideos.Columns["vid_id"] != null)
            {
                dgvVideos.Columns["vid_id"].Visible = false;
            }
            if (dgvVideos.Columns["TagIds"] != null)
            {
                dgvVideos.Columns["TagIds"].Visible = false;
            }
            if (dgvVideos.Columns["cat_id"] != null)
            {
                dgvVideos.Columns["cat_id"].Visible = false;
            }

            // Đặt cột STT làm cột đầu tiên
            if (dgvVideos.Columns["STT"] != null)
            {
                dgvVideos.Columns["STT"].DisplayIndex = 0;
            }

            // Đổi tên cột và sắp xếp lại
            if (dgvVideos.Columns["vid_title"] != null)
            {
                dgvVideos.Columns["vid_title"].HeaderText = "Title";
                dgvVideos.Columns["vid_title"].DisplayIndex = 1;
            }
            if (dgvVideos.Columns["vid_filepath"] != null)
            {
                dgvVideos.Columns["vid_filepath"].HeaderText = "File Path";
                dgvVideos.Columns["vid_filepath"].DisplayIndex = 2;
            }
            if (dgvVideos.Columns["vid_description"] != null)
            {
                dgvVideos.Columns["vid_description"].HeaderText = "Description";
                dgvVideos.Columns["vid_description"].DisplayIndex = 3;
            }
            if (dgvVideos.Columns["vid_duration"] != null)
            {
                dgvVideos.Columns["vid_duration"].HeaderText = "Duration";
                dgvVideos.Columns["vid_duration"].DisplayIndex = 4;
            }
            if (dgvVideos.Columns["CategoryName"] != null)
            {
                dgvVideos.Columns["CategoryName"].HeaderText = "Category";
                dgvVideos.Columns["CategoryName"].DisplayIndex = 5;
            }
            if (dgvVideos.Columns["TagsDisplay"] != null)
            {
                dgvVideos.Columns["TagsDisplay"].HeaderText = "Tags";
                dgvVideos.Columns["TagsDisplay"].DisplayIndex = 6; // Đặt sau cột Category
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var inputForm = new InputForm("Enter new category name:", "Add Category", "New Category", isVideoButton: false);
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                string newCategoryName = inputForm.InputValue;
                if (string.IsNullOrWhiteSpace(newCategoryName))
                {
                    MessageBox.Show("Category name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dbManager.InsertCategoryToDatabase(newCategoryName);
                LoadCategories();
                LoadVideos();
                HasChanges = true;
                MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int catId = Convert.ToInt32(dgvCategories.SelectedRows[0].Cells["cat_id"].Value);
                    dbManager.DeleteCategoryFromDatabase(catId);
                    LoadCategories();
                    LoadVideos();
                    HasChanges = true;
                    MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a category to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                int catId = Convert.ToInt32(dgvCategories.SelectedRows[0].Cells["cat_id"].Value);
                string currentName = dgvCategories.SelectedRows[0].Cells["cat_name"].Value.ToString();
                var inputForm = new InputForm("Enter updated category name:", "Update Category", currentName, isVideoButton: false);
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string updatedName = inputForm.InputValue;
                    if (string.IsNullOrWhiteSpace(updatedName))
                    {
                        MessageBox.Show("Category name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dbManager.UpdateCategory(catId, updatedName);
                    LoadCategories();
                    LoadVideos();
                    HasChanges = true;
                    MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a category to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            var inputForm = new InputForm("Enter new tag name:", "Add Tag", "New Tag", isVideoButton: false);
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                string newTagName = inputForm.InputValue;
                if (string.IsNullOrWhiteSpace(newTagName))
                {
                    MessageBox.Show("Tag name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dbManager.InsertTagToDatabase(newTagName);
                LoadTags();
                LoadVideos();
                HasChanges = true;
                MessageBox.Show("Tag added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteTag_Click(object sender, EventArgs e)
        {
            if (dgvTags.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this tag?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int tagId = Convert.ToInt32(dgvTags.SelectedRows[0].Cells["tag_id"].Value);
                    dbManager.DeleteTagFromDatabase(tagId);
                    LoadTags();
                    LoadVideos();
                    HasChanges = true;
                    MessageBox.Show("Tag deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a tag to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateTag_Click(object sender, EventArgs e)
        {
            if (dgvTags.SelectedRows.Count > 0)
            {
                int tagId = Convert.ToInt32(dgvTags.SelectedRows[0].Cells["tag_id"].Value);
                string currentName = dgvTags.SelectedRows[0].Cells["tag_name"].Value.ToString();
                var inputForm = new InputForm("Enter updated tag name:", "Update Tag", currentName , isVideoButton: false);
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string updatedName = inputForm.InputValue;
                    if (string.IsNullOrWhiteSpace(updatedName))
                    {
                        MessageBox.Show("Tag name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dbManager.UpdateTag(tagId, updatedName);
                    LoadTags();
                    LoadVideos();
                    HasChanges = true;
                    MessageBox.Show("Tag updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a tag to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Video Files|*.mp4;*.avi;*.mkv|All Files|*.*",
                Title = "Select a Video File"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                var titleForm = new InputForm("Enter video title:", "Add Video Title", Path.GetFileNameWithoutExtension(filePath), isVideoButton:true,  dtCategories);
                if (titleForm.ShowDialog() == DialogResult.OK)
                {
                    string title = titleForm.InputValue;
                    string description = titleForm.Description;
                    if (string.IsNullOrWhiteSpace(title))
                    {
                        MessageBox.Show("Video title cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (dtCategories.Rows.Count == 0)
                    {
                        MessageBox.Show("Please add at least one category before adding a video!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int catId = titleForm.SelectedCatId;
                    if (catId == -1)
                    {
                        MessageBox.Show("Please select a category for the video!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    List<int> tagIds = new List<int>();
                    var selectTagsForm = new SelectTagsForm(dtTags, tagIds);
                    if (selectTagsForm.ShowDialog() == DialogResult.OK)
                    {
                        tagIds = selectTagsForm.SelectedTagIds;
                    }

                    try
                    {
                        dbManager.InsertVideoForDataGrid(filePath, title, catId, tagIds, description);
                        LoadVideos();
                        HasChanges = true;
                        MessageBox.Show("Video added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDeleteVideo_Click(object sender, EventArgs e)
        {
            if (dgvVideos.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this video?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string filePath = dgvVideos.SelectedRows[0].Cells["vid_filepath"].Value.ToString();
                    dbManager.DeleteVideoFromDatabase(filePath);
                    LoadVideos();
                    HasChanges = true;
                    MessageBox.Show("Video deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a video to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateVideo_Click(object sender, EventArgs e)
        {
            if (dgvVideos.SelectedRows.Count > 0)
            {
                DataRow row = (dgvVideos.SelectedRows[0].DataBoundItem as DataRowView)?.Row;
                if (row == null)
                {
                    MessageBox.Show("Không thể lấy dữ liệu của dòng được chọn!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int vidId = Convert.ToInt32(row["vid_id"]);
                string currentTitle = row["vid_title"].ToString();
                int currentCatId = row["cat_id"] != DBNull.Value ? Convert.ToInt32(row["cat_id"]) : 0;
                string tagIds = row["TagIds"]?.ToString();
                List<int> currentTagIds = string.IsNullOrEmpty(tagIds)
                    ? new List<int>()
                    : tagIds.Split(',').Select(id => int.Parse(id)).ToList();

                var updateForm = new UpdateVideoForm(currentTitle, currentCatId, currentTagIds, dtCategories, dtTags);
                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    dbManager.UpdateVideo(vidId, updateForm.UpdatedTitle, updateForm.UpdatedCatId, updateForm.UpdatedTagIds);
                    LoadVideos();
                    HasChanges = true;
                    MessageBox.Show("Video updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a video to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
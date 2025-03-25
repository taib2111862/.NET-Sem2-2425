using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoPlayer
{
    public partial class ManageForm : Form
    {
        private VideoDatabaseManager dbManager;
        private DataTable dtCategories;
        private DataTable dtTags;
        private DataTable dtVideos;

        public ManageForm(int selectedTabIndex = 0)
        {
            InitializeComponent();
            dbManager = new VideoDatabaseManager();

            // Load data from database
            LoadCategories();
            LoadTags();

            // Add TagsDisplay column only once
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

            // Handle CellFormatting to display tag names
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
            };

            // Load videos after setting up columns
            LoadVideos();

            // Select tab based on parameter
            ManageTabControl.SelectedIndex = selectedTabIndex;
        }

        private void LoadCategories()
        {
            dtCategories = dbManager.GetAllCategories();
            dgvCategories.DataSource = dtCategories;
        }

        private void LoadTags()
        {
            dtTags = dbManager.GetAllTags();
            dgvTags.DataSource = dtTags;
        }

        private void LoadVideos()
        {
            dtVideos = dbManager.GetVideosForDataGrid();
            // Remove the default TagIds column (if it exists)
            if (dgvVideos.Columns["TagIds"] != null)
            {
                dgvVideos.Columns.Remove("TagIds");
            }

            // Remove the cat_id column (we'll display CategoryName instead)
            if (dgvVideos.Columns["cat_id"] != null)
            {
                dgvVideos.Columns.Remove("cat_id");
            }

            // Rename CategoryName to Category
            if (dgvVideos.Columns["CategoryName"] != null)
            {
                dgvVideos.Columns["CategoryName"].HeaderText = "Category";
            }

            // Bind the DataTable to the DataGridView
            dgvVideos.DataSource = dtVideos;
        }

        // Categories Tab - Add, Update, Delete
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var inputForm = new InputForm("Enter new category name:", "Add Category", "New Category");
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
                LoadVideos(); // Cần tải lại videos vì cat_id có thể bị thay đổi
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
                    LoadVideos(); // Cần tải lại videos vì cat_id có thể bị thay đổi
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
                var inputForm = new InputForm("Enter updated category name:", "Update Category", currentName);
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
                    LoadVideos(); // Cần tải lại videos để cập nhật tên category
                    MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a category to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tags Tab - Add, Update, Delete
        private void btnAddTag_Click(object sender, EventArgs e)
        {
            var inputForm = new InputForm("Enter new tag name:", "Add Tag", "New Tag");
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
                LoadVideos(); // Cần tải lại videos để cập nhật danh sách tags
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
                    LoadVideos(); // Cần tải lại videos vì tags có thể bị thay đổi
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
                var inputForm = new InputForm("Enter updated tag name:", "Update Tag", currentName);
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
                    LoadVideos(); // Cần tải lại videos để cập nhật tên tag
                    MessageBox.Show("Tag updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a tag to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Videos Tab - Add, Update, Delete
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
                var titleForm = new InputForm("Enter video title:", "Add Video Title", Path.GetFileNameWithoutExtension(filePath));
                if (titleForm.ShowDialog() == DialogResult.OK)
                {
                    string title = titleForm.InputValue;
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
                    int catId = Convert.ToInt32(dtCategories.Rows[0]["cat_id"]);
                    List<int> tagIds = new List<int>();

                    var selectTagsForm = new SelectTagsForm(dtTags, tagIds);
                    if (selectTagsForm.ShowDialog() == DialogResult.OK)
                    {
                        tagIds = selectTagsForm.SelectedTagIds;
                    }

                    try
                    {
                        dbManager.InsertVideoForDataGrid(filePath, title, catId, tagIds);
                        LoadVideos();
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
                // Lấy DataRow từ DataTable
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

                // Hiển thị form cập nhật video
                var updateForm = new UpdateVideoForm(currentTitle, currentCatId, currentTagIds, dtCategories, dtTags);
                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    dbManager.UpdateVideo(vidId, updateForm.UpdatedTitle, updateForm.UpdatedCatId, updateForm.UpdatedTagIds);
                    LoadVideos();
                    MessageBox.Show("Video updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a video to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public List<int> TagIds { get; set; }
    }
}
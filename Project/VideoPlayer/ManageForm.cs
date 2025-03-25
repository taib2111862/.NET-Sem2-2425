using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace VideoPlayer
{
    public partial class ManageForm : Form
    {
        private List<Category> categories;
        private List<Tag> tags;
        private List<Video> videos;

        public ManageForm(int selectedTabIndex = 0)
        {
            InitializeComponent();

            // Initialize sample data
            categories = new List<Category>
            {
                new Category { Id = 1, Name = "Action" },
                new Category { Id = 2, Name = "Comedy" },
                new Category { Id = 3, Name = "Drama" }
            };

            tags = new List<Tag>
            {
                new Tag { Id = 1, Name = "Funny" },
                new Tag { Id = 2, Name = "Thriller" },
                new Tag { Id = 3, Name = "Romantic" }
            };

            videos = new List<Video>
            {
                new Video { Id = 1, Title = "The Matrix", CategoryId = 1, TagIds = new List<int> { 2 } },
                new Video { Id = 2, Title = "Home Alone", CategoryId = 2, TagIds = new List<int> { 1 } },
                new Video { Id = 3, Title = "Titanic", CategoryId = 3, TagIds = new List<int> { 3 } }
            };

            // Bind data to DataGridViews
            dgvCategories.DataSource = categories;
            dgvTags.DataSource = tags;
            dgvVideos.DataSource = videos;

            // Remove the default TagIds column (it will be replaced)
            if (dgvVideos.Columns["TagIds"] != null)
            {
                dgvVideos.Columns.Remove("TagIds");
            }

            // Add a column to display tag names
            DataGridViewTextBoxColumn tagsDisplayColumn = new DataGridViewTextBoxColumn
            {
                Name = "TagsDisplay",
                HeaderText = "Tags",
                ReadOnly = true
            };
            dgvVideos.Columns.Add(tagsDisplayColumn);

            // Add a button column to select tags
            DataGridViewButtonColumn btnSelectTagsColumn = new DataGridViewButtonColumn
            {
                Name = "SelectTags",
                HeaderText = "Select Tags",
                Text = "Select",
                UseColumnTextForButtonValue = true
            };
            dgvVideos.Columns.Add(btnSelectTagsColumn);

            // Set up ComboBox column for categories in dgvVideos
            DataGridViewComboBoxColumn categoryColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "CategoryId",
                HeaderText = "Category",
                DataSource = categories,
                ValueMember = "Id",
                DisplayMember = "Name"
            };
            dgvVideos.Columns.Add(categoryColumn);

            // Handle CellFormatting to display tag names
            dgvVideos.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex == dgvVideos.Columns["TagsDisplay"].Index && e.RowIndex >= 0)
                {
                    var video = videos[e.RowIndex];
                    var tagNames = video.TagIds.Select(tagId => tags.FirstOrDefault(t => t.Id == tagId)?.Name ?? "Unknown").ToList();
                    e.Value = string.Join(", ", tagNames);
                }
            };

            // Handle button click to select tags
            dgvVideos.CellContentClick += (sender, e) =>
            {
                if (e.ColumnIndex == dgvVideos.Columns["SelectTags"].Index && e.RowIndex >= 0)
                {
                    var video = videos[e.RowIndex];
                    var selectTagsForm = new SelectTagsForm(tags, video.TagIds);
                    if (selectTagsForm.ShowDialog() == DialogResult.OK)
                    {
                        video.TagIds = selectTagsForm.SelectedTagIds;
                        dgvVideos.Refresh();
                    }
                }
            };

            // Select tab based on parameter
            ManageTabControl.SelectedIndex = selectedTabIndex;
        }

        // Categories Tab - Add, Update, Delete
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string newCategoryName = Interaction.InputBox("Enter new category name:", "Add Category", "New Category");
            if (string.IsNullOrWhiteSpace(newCategoryName))
            {
                MessageBox.Show("Category name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            categories.Add(new Category { Id = categories.Count + 1, Name = newCategoryName });
            dgvCategories.DataSource = null;
            dgvCategories.DataSource = categories;
            MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    categories.RemoveAt(dgvCategories.SelectedRows[0].Index);
                    dgvCategories.DataSource = null;
                    dgvCategories.DataSource = categories;
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
                var selectedCategory = categories[dgvCategories.SelectedRows[0].Index];
                string updatedName = Interaction.InputBox("Enter updated category name:", "Update Category", selectedCategory.Name);
                if (string.IsNullOrWhiteSpace(updatedName))
                {
                    MessageBox.Show("Category name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                selectedCategory.Name = updatedName;
                dgvCategories.DataSource = null;
                dgvCategories.DataSource = categories;
                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a category to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tags Tab - Add, Update, Delete
        private void btnAddTag_Click(object sender, EventArgs e)
        {
            string newTagName = Interaction.InputBox("Enter new tag name:", "Add Tag", "New Tag");
            if (string.IsNullOrWhiteSpace(newTagName))
            {
                MessageBox.Show("Tag name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tags.Add(new Tag { Id = tags.Count + 1, Name = newTagName });
            dgvTags.DataSource = null;
            dgvTags.DataSource = tags;
            MessageBox.Show("Tag added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteTag_Click(object sender, EventArgs e)
        {
            if (dgvTags.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this tag?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    tags.RemoveAt(dgvTags.SelectedRows[0].Index);
                    dgvTags.DataSource = null;
                    dgvTags.DataSource = tags;
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
                var selectedTag = tags[dgvTags.SelectedRows[0].Index];
                string updatedName = Interaction.InputBox("Enter updated tag name:", "Update Tag", selectedTag.Name);
                if (string.IsNullOrWhiteSpace(updatedName))
                {
                    MessageBox.Show("Tag name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                selectedTag.Name = updatedName;
                dgvTags.DataSource = null;
                dgvTags.DataSource = tags;
                MessageBox.Show("Tag updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a tag to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Videos Tab - Add, Update, Delete
        private void btnAddVideo_Click(object sender, EventArgs e)
        {
            string newVideoTitle = Interaction.InputBox("Enter new video title:", "Add Video", "New Video");
            if (string.IsNullOrWhiteSpace(newVideoTitle))
            {
                MessageBox.Show("Video title cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newVideo = new Video
            {
                Id = videos.Count + 1,
                Title = newVideoTitle,
                CategoryId = categories.First().Id, // Default category
                TagIds = new List<int>()
            };

            var selectTagsForm = new SelectTagsForm(tags, newVideo.TagIds);
            if (selectTagsForm.ShowDialog() == DialogResult.OK)
            {
                newVideo.TagIds = selectTagsForm.SelectedTagIds;
            }

            videos.Add(newVideo);
            dgvVideos.DataSource = null;
            dgvVideos.DataSource = videos;
            MessageBox.Show("Video added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteVideo_Click(object sender, EventArgs e)
        {
            if (dgvVideos.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this video?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    videos.RemoveAt(dgvVideos.SelectedRows[0].Index);
                    dgvVideos.DataSource = null;
                    dgvVideos.DataSource = videos;
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
                var selectedVideo = videos[dgvVideos.SelectedRows[0].Index];
                string updatedTitle = Interaction.InputBox("Enter updated video title:", "Update Video", selectedVideo.Title);
                if (string.IsNullOrWhiteSpace(updatedTitle))
                {
                    MessageBox.Show("Video title cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                selectedVideo.Title = updatedTitle;
                dgvVideos.DataSource = null;
                dgvVideos.DataSource = videos;
                MessageBox.Show("Video updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
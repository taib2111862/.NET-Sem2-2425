using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace VideoPlayer
{
    public partial class UpdateVideoForm : Form
    {
        private DataTable dtCategories;
        private DataTable dtTags;
        private string currentTitle;
        private int currentCatId;
        private List<int> currentTagIds;

        public string UpdatedTitle { get; private set; }
        public int UpdatedCatId { get; private set; }
        public List<int> UpdatedTagIds { get; private set; }

        public UpdateVideoForm(string currentTitle, int currentCatId, List<int> currentTagIds, DataTable dtCategories, DataTable dtTags)
        {
            InitializeComponent();
            this.currentTitle = currentTitle;
            this.currentCatId = currentCatId;
            this.currentTagIds = currentTagIds ?? new List<int>();
            this.dtCategories = dtCategories;
            this.dtTags = dtTags;

            // Thiết lập giao diện
            txtTitle.Text = currentTitle;

            cbCategories.DataSource = dtCategories;
            cbCategories.DisplayMember = "cat_name";
            cbCategories.ValueMember = "cat_id";
            cbCategories.SelectedValue = currentCatId;

            foreach (DataRow row in dtTags.Rows)
            {
                int tagId = row.Field<int>("tag_id");
                string tagName = row.Field<string>("tag_name");
                clbTags.Items.Add(tagName, this.currentTagIds.Contains(tagId));
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            UpdatedTitle = txtTitle.Text;
            if (string.IsNullOrWhiteSpace(UpdatedTitle))
            {
                MessageBox.Show("Video title cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdatedCatId = Convert.ToInt32(cbCategories.SelectedValue);

            UpdatedTagIds = new List<int>();
            for (int i = 0; i < clbTags.Items.Count; i++)
            {
                if (clbTags.GetItemChecked(i))
                {
                    int tagId = dtTags.Rows[i].Field<int>("tag_id");
                    UpdatedTagIds.Add(tagId);
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
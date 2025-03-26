using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoPlayer
{
    public partial class SelectTagsForm : Form
    {
        public List<int> SelectedTagIds { get; private set; }
        private DataTable tags;

        public SelectTagsForm(DataTable tags, List<int> selectedTagIds)
        {
            InitializeComponent();

            this.tags = tags;
            SelectedTagIds = selectedTagIds ?? new List<int>();

            // Populate CheckedListBox with tags
            foreach (DataRow row in tags.Rows)
            {
                int tagId = row.Field<int>("tag_id");
                string tagName = row.Field<string>("tag_name");
                clbTags.Items.Add(tagName, SelectedTagIds.Contains(tagId));
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedTagIds = new List<int>();
            for (int i = 0; i < clbTags.Items.Count; i++)
            {
                if (clbTags.GetItemChecked(i))
                {
                    int tagId = tags.Rows[i].Field<int>("tag_id");
                    SelectedTagIds.Add(tagId);
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
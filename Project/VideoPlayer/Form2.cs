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
        private List<Tag> tags;

        public SelectTagsForm(List<Tag> tags, List<int> selectedTagIds)
        {
            InitializeComponent();

            this.tags = tags;
            SelectedTagIds = selectedTagIds ?? new List<int>();

            // Populate CheckedListBox with tags
            foreach (var tag in tags)
            {
                clbTags.Items.Add(tag.Name, SelectedTagIds.Contains(tag.Id));
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Get selected tag IDs
            SelectedTagIds = new List<int>();
            for (int i = 0; i < clbTags.Items.Count; i++)
            {
                if (clbTags.GetItemChecked(i))
                {
                    var tag = tags[i];
                    SelectedTagIds.Add(tag.Id);
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
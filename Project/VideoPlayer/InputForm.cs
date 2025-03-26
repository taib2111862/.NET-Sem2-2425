using System;
using System.Data;
using System.Windows.Forms;

namespace VideoPlayer
{
    public partial class InputForm : Form
    {
        public string InputValue { get; private set; } // Tiêu đề video
        public string Description { get; private set; } // Mô tả video
        public int SelectedCatId { get; private set; } // Category ID được chọn

        public InputForm(string prompt, string title, string defaultValue, DataTable categories = null)
        {
            InitializeComponent();
            this.Text = title;

            // Gán giá trị mặc định cho TextBox
            txtInput.Text = defaultValue;
            txtDescription.Text = "Chưa có mô tả"; // Giá trị mặc định cho mô tả

            // Nếu có danh sách categories, gán DataSource cho ComboBox
            if (categories != null && categories.Rows.Count > 0)
            {
                cbCategories.DataSource = categories;
                cbCategories.DisplayMember = "cat_name";
                cbCategories.ValueMember = "cat_id";
            }
            else
            {
                // Ẩn ComboBox và Label nếu không có category
                lblCategory.Visible = false;
                cbCategories.Visible = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            InputValue = txtInput.Text;
            Description = txtDescription.Text;
            if (cbCategories.Visible && cbCategories.SelectedValue != null)
            {
                SelectedCatId = Convert.ToInt32(cbCategories.SelectedValue);
            }
            else
            {
                SelectedCatId = -1; // Giá trị mặc định nếu không có category
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
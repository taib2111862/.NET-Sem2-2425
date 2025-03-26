using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace VideoPlayer
{
    public partial class InputForm : Form
    {
        public string InputValue { get; private set; } // Tiêu đề video
        public string Description { get; private set; } // Mô tả video
        public int SelectedCatId { get; private set; } // Category ID được chọn

        public InputForm(string prompt, string title, string defaultValue, bool isVideoButton = true,DataTable categories = null)
        {
            InitializeComponent();

            this.Text = title;

            // Gán giá trị mặc định cho TextBox
            lblPrompt.Text = prompt;
            txtInput.Text = defaultValue;

            if (isVideoButton)
            {
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
            else
            {
                txtDescription.Visible = false;
                lblDescription.Visible = false;
                lblCategory.Visible = false;
                txtDescription.Visible = false;

                // Điều chỉnh kích thước form cho nhỏ lại
                this.ClientSize = new Size(284, 100);
                btnOK.Location = new Point(117, 60);
                btnCancel.Location = new Point(197, 60);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Kiểm tra độ dài của Description (nếu là video)
            if (lblDescription.Visible && txtDescription.Text.Length > 500) // Giả sử cột vid_description trong database là NVARCHAR(500)
            {
                MessageBox.Show("Description cannot be longer than 500 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InputValue = txtInput.Text;
            if (lblDescription.Visible)
            {
                Description = txtDescription.Text;
            }
            else
            {
                Description = null; // Không cần mô tả cho tag/category
            }

            if (cbCategories.Visible && cbCategories.SelectedValue != null)
            {
                SelectedCatId = Convert.ToInt32(cbCategories.SelectedValue);
            }
            else
            {
                SelectedCatId = -1; // Giá trị mặc định nếu không có category
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
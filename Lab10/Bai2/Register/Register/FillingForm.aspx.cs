using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Register
{
	public partial class FillingForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }
        protected void btnDangky_Click(object sender, EventArgs e)
        {
            clsDatabase db = new clsDatabase();
            try
            {
                db.OpenConnection();

                string query = "INSERT INTO KhachHang VALUES (@TenDN, @MatKhau, @HoTen, @NgaySinh, @GioiTinh, @Email, @ThuNhap)";
                SqlCommand cmd = new SqlCommand(query, db.connection);

                cmd.Parameters.AddWithValue("@TenDN", txtTenDN.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txtMK.Text);
                cmd.Parameters.AddWithValue("@HoTen", txtKH.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", DateTime.Parse(txtNgaySinh.Text));
                cmd.Parameters.AddWithValue("@GioiTinh", radNam.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@ThuNhap", double.Parse(txtThuNhap.Text));

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    lblThongBao.Text = "Đăng ký thành công";
                else
                    lblThongBao.Text = "Đăng ký thất bại";
            }
            catch (Exception ex)
            {
                lblThongBao.Text = "Lỗi: " + ex.Message;
            }
            finally
            {
                db.CloseConnection();
            }
        }

        protected void txtTenDN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
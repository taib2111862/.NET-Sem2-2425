using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Register
{
    public partial class CustomerList : System.Web.UI.Page
    {
        // Đối tượng cơ sở dữ liệu để kết nối và thực hiện truy vấn
        clsDatabase db = new clsDatabase();
        // Hàm lấy danh sách khách hàng từ database và hiển thị lên GridView
        void getKhachHang()
        {
            db.OpenConnection();
            string query = "SELECT TenDN, HoTen, NgaySinh, GioiTinh, Email FROM KhachHang;";
            SqlCommand cmd = new SqlCommand(query, db.connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            grvKH.DataSource = dt;
            grvKH.DataBind();
        }
        // Sự kiện khi trang được tải
        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra nếu trang không phải là PostBack thì mới gọi getKhachHang()
            if (!IsPostBack) { getKhachHang(); }
        }
        // Xử lý phân trang cho GridView
        protected void grvKH_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvKH.PageIndex = e.NewPageIndex;
            getKhachHang();
        }
        // Xử lý sự kiện xóa một hàng trong GridView
        protected void grvKH_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Lấy giá trị khóa chính (TenDN - Tên đăng nhập)
            string TenDN = grvKH.DataKeys[e.RowIndex].Value.ToString();

            // Câu lệnh SQL xóa khách hàng có TenDN tương ứng
            string query = "DELETE FROM KhachHang WHERE TenDN = @TenDN";

            // Thực thi câu lệnh SQL xoá dữ liệu 1 hàng
            db.OpenConnection();
            using (SqlCommand cmd = new SqlCommand(query, db.connection))
            {
                cmd.Parameters.AddWithValue("@TenDN", TenDN);

                cmd.ExecuteNonQuery();
            }
            db.CloseConnection();

            // Cập nhật lại danh sách khách hàng sau khi xóa
            getKhachHang();
        }
        // Xử lý sự kiện cập nhật thông tin khách hàng trong GridView
        protected void grvKH_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Lấy hàng cần chỉnh sửa
            GridViewRow row = grvKH.Rows[e.RowIndex];

            // Lấy giá trị khóa chính (Tên đăng nhập)
            string tenDN = grvKH.DataKeys[e.RowIndex].Value.ToString();
            
            // Lấy các giá trị cập nhật từ ô nhập liệu
            string hoTen = ((TextBox)row.Cells[1].Controls[0]).Text; // Họ tên
            string ngaySinh = ((TextBox)row.Cells[2].Controls[0]).Text; // Ngày sinh
            string email = ((TextBox)row.Cells[4].Controls[0]).Text; // Email

            // Lấy giá trị giới tính từ Checkbox
            CheckBox chkGender = (CheckBox)row.FindControl("chkGenderEdit");
            string gioiTinh = chkGender.Checked ? "1" : "0"; // Chuyển đổi giá trị checkbox thành 1/0
            // Danh sách lỗi khi kiểm tra dữ liệu
            List<string> errors = new List<string>();

            // Kiểm tra định dạng Email hợp lệ
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errors.Add("Email không hợp lệ.");
            }

            // Kiểm tra Ngày sinh có đúng định dạng "dd/MM/yyyy hh:mm:ss tt" hay không
            DateTime dt;
            if (!DateTime.TryParseExact(ngaySinh, "dd/MM/yyyy hh:mm:ss tt", new CultureInfo("vi-VN"), DateTimeStyles.None, out dt))
            {
                errors.Add("Ngày sinh không đúng định dạng (dd/MM/yyyy hh:mm:ss tt).");
            }

            // Nếu có lỗi, hiển thị lên ValidationSummary và hủy cập nhật
            if (errors.Count > 0)
            {
                foreach (var error in errors)
                {
                    CustomValidator validator = new CustomValidator
                    {
                        ErrorMessage = error,
                        IsValid = false
                    };
                    Page.Validators.Add(validator);
                }
                e.Cancel = true; // Hủy cập nhật nếu có lỗi
                return;
            }

            // Câu lệnh SQL cập nhật dữ liệu khách hàng
            string query = "UPDATE KhachHang SET HoTen = @HoTen, NgaySinh = @NgaySinh," +
                "GioiTinh = @GioiTinh, Email = @Email WHERE TenDN = @TenDN";
            db.OpenConnection();
            // Thực thi câu lệnh SQL cập nhật dữ liệu 1 hàng
            using (SqlCommand cmd = new SqlCommand(query, db.connection))
            {
                cmd.Parameters.AddWithValue("@TenDN", tenDN);
                cmd.Parameters.AddWithValue("@HoTen", hoTen);
                cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.ExecuteNonQuery();
            }
            db.CloseConnection();
            // Thoát khỏi chế độ chỉnh sửa và cập nhật lại danh sách
            grvKH.EditIndex = -1;
            getKhachHang();
        }
        // Xử lý sự kiện chuyển hàng sang chế độ chỉnh sửa
        protected void grvKH_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvKH.EditIndex = e.NewEditIndex; // Thiết lập hàng vào chế độ chỉnh sửa
            getKhachHang();
        }
        // Xử lý sự kiện hủy chỉnh sửa một hàng trong GridView
        protected void grvKH_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvKH.EditIndex = -1; // Thoát khỏi chế độ chỉnh sửa
            getKhachHang();
        }
        // Xử lý sự kiện chọn hàng trong GridView
        protected void grvKH_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            grvKH.DataKeys[e.NewSelectedIndex].Value.ToString();
        }
    }
}
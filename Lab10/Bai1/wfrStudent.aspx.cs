using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bai1
{
    public partial class wfrStudent : System.Web.UI.Page
    {
        // Đối tượng cơ sở dữ liệu để kết nối và thực hiện truy vấn
        clsDatabase db = new clsDatabase();

        // TẢI DỮ LIỆU TỪ BẢNG SinhVien LÊN DataGridView
        void loadData()
        {
            db.OpenConnection(); // 1. Mở kết nối CSDL
            string query = "SELECT * FROM SinhVien;"; // 2. Tạo truy vấn SQL
            SqlCommand cmd = new SqlCommand(query, db.con); // 3. Tạo đối tượng SqlCommand để thực hiện truy vấn
            SqlDataAdapter adapter = new SqlDataAdapter(cmd); // 4. Tạo đối tượng SqlDataAdapter để
                                                              // lấy dữ liệu và lưu vào DataTable
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            grvStudent.DataSource = dt; // 5. Gán DataTable đã được lưu dữ liệu vào DataGridView
            grvStudent.DataBind(); // 6. Hiển thị dữ liệu lên DataGridView
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) { loadData(); } // Khi tải trang, tải DataGridView
        }

        // XỬ LÝ SỰ KIỆN CHUYỂN TRANG
        protected void grvStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvStudent.PageIndex = e.NewPageIndex; // Cập nhật PageIndex của GridView bằng e.NewPageIndex
            loadData(); // Cập nhật lại DataGridView
        }

        // XỬ LÝ SỰ KIỆN CHỈNH SỬA DỮ LIỆU 1 DÒNG
        protected void grvStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvStudent.EditIndex = e.NewEditIndex; // Thiết lập dòng vào trạng thái Edit
            loadData(); // Cập nhật lại DataGridView
        }

        // XỬ LÝ SỰ KIỆN CẬP NHẬT DỮ LIỆU 1 DÒNG
        protected void grvStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grvStudent.Rows[e.RowIndex]; // Lấy hàng đang được chỉnh sửa

            // Lấy MaSV (khoá chính của hàng)
            string maSV = grvStudent.DataKeys[e.RowIndex].Value.ToString();

            // Lấy các giá trị tại các cột khác
            string tenSV = ((TextBox)row.Cells[1].Controls[0]).Text;
            string lop = ((TextBox)row.Cells[3].Controls[0]).Text.Trim();
            lop = lop.Length > 10 ? lop.Substring(0, 10) : lop; // Giới hạn lại độ dài của lớp được cập nhật
                                                                // vì theo cấu trúc CSDL, độ dài tên lớp <= 10

            // Lấy giá trị của Phái (cột CheckBox)
            CheckBox chkGender = (CheckBox)row.FindControl("chkGenderEdit");
            string phai = chkGender.Checked ? "1" : "0"; // Chuyển thành 1/0

            // Câu lệnh SQL cập nhật dữ liệu
            string query = "UPDATE SinhVien SET TenSV = @TenSV, Lop = @Lop, Phai = @Phai WHERE MaSV = @MaSV";
            // Mở kết nối CSDL
            db.OpenConnection();
            // Thực thi cập nhật SQL (4 tham số: maSV, tenSV, lop, phai)
            using (SqlCommand cmd = new SqlCommand(query, db.con))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@TenSV", tenSV);
                cmd.Parameters.AddWithValue("@Lop", lop);
                cmd.Parameters.AddWithValue("@Phai", phai);
                cmd.ExecuteNonQuery(); // Thực thi mà không trả về dữ liệu gì (Delete, Update,...)
            }
            // Đóng kết nối CSDL
            db.CloseConnection();
            // Thoát khỏi trạng thái Edit
            grvStudent.EditIndex = -1;
            // Cập nhật lại DataGridView
            loadData();
        }
        
        // XỬ LÝ SỰ KIỆN XOÁ 1 DÒNG
        protected void grvStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Lấy MaSV (khoá chính của hàng)
            string maSV = grvStudent.DataKeys[e.RowIndex].Value.ToString();

            // Câu lệnh SQL xoá dữ liệu 1 hàng
            string query = "DELETE FROM SinhVien WHERE MaSV = @MaSV";
            
            // Mở kết nối CSDL
            db.OpenConnection();

            // Thực thi cậu lệnh SQL xoá dữ liệu (1 tham số: maSV)
            using (SqlCommand cmd = new SqlCommand(query, db.con))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.ExecuteNonQuery(); // Thực thi mà không trả về dữ liệu gì (Delete, Update,...)
            }
            // Đóng kết nối CSDL
            db.CloseConnection();
            // Cập nhật lại DataGridView
            loadData();
        }
        
        // XỬ LÝ SỰ KIỆN CHỌN 1 DÒNG KHÁC
        protected void grvStudent_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            grvStudent.DataKeys[e.NewSelectedIndex].Value.ToString();
        }

        // XỬ LÝ SỰ KIỆN HUỶ BỎ CHỈNH SỬA 1 DÒNG
        protected void grvStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvStudent.EditIndex = -1; // Hủy trạng thái chỉnh sửa
            loadData(); // Cập nhật lại DataGridView
        }
    }
}
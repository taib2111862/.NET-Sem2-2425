using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Register
{
    public partial class CustomerList : System.Web.UI.Page
    {
        clsDatabase db = new clsDatabase();
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { getKhachHang(); }
        }

        protected void grvKH_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvKH.PageIndex = e.NewPageIndex;
            getKhachHang();
        }
        protected void grvKH_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the primary key (Student ID)
            string TenDN = grvKH.DataKeys[e.RowIndex].Value.ToString();

            // Delete Query
            string query = "DELETE FROM KhachHang WHERE TenDN = @TenDN";

            // Execute SQL Delete
            db.OpenConnection();
            using (SqlCommand cmd = new SqlCommand(query, db.connection))
            {
                cmd.Parameters.AddWithValue("@MaSV", TenDN);

                cmd.ExecuteNonQuery();
            }
            db.CloseConnection();

            // Reload data after deleting
            getKhachHang();
        }

        protected void grvKH_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grvKH.Rows[e.RowIndex];
            string tenDN = grvKH.DataKeys[e.RowIndex].Value.ToString();
            // Get other updated values
            string hoTen = ((TextBox)row.Cells[1].Controls[0]).Text;
            string ngaySinh = ((TextBox)row.Cells[2].Controls[0]).Text;
            string email = ((TextBox)row.Cells[4].Controls[0]).Text;

            // Get Checkbox Value
            CheckBox chkGender = (CheckBox)row.FindControl("chkGenderEdit");
            string gioiTinh = chkGender.Checked ? "1" : "0"; // Convert checkbox to 1 or 0

            // Update Query
            string query = "UPDATE KhachHang SET HoTen = @HoTen, NgaySinh = @NgaySinh," +
                "GioiTinh = @GioiTinh, Email = @Email WHERE TenDN = @TenDN";
            db.OpenConnection();
            // Execute SQL Update
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
            // Exit edit mode and refresh data
            grvKH.EditIndex = -1;
            getKhachHang();
        }

        protected void grvKH_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvKH.EditIndex = e.NewEditIndex; // Set row to edit mode
            getKhachHang();
        }

        protected void grvKH_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvKH.EditIndex = -1;
            getKhachHang();
        }

        protected void grvKH_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            grvKH.DataKeys[e.NewSelectedIndex].Value.ToString();
        }
    }
}
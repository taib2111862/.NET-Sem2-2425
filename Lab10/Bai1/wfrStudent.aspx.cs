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
        clsDatabase db = new clsDatabase();

        void loadData()
        {
            db.OpenConnection();
            string query = "SELECT * FROM SinhVien;";
            SqlCommand cmd = new SqlCommand(query, db.con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            grvStudent.DataSource = dt;
            grvStudent.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) { loadData(); }
        }

        protected void grvStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvStudent.PageIndex = e.NewPageIndex;
            loadData();
        }

        protected void grvStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvStudent.EditIndex = e.NewEditIndex; // Set row to edit mode
            loadData();
        }

        protected void grvStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grvStudent.Rows[e.RowIndex];

            // Get Student ID (Primary Key)
            string maSV = ((TextBox)row.Cells[0].Controls[0]).Text;

            // Get other updated values
            string tenSV = ((TextBox)row.Cells[1].Controls[0]).Text;
            string lop = ((TextBox)row.Cells[3].Controls[0]).Text.Trim();
            lop = lop.Length > 10 ? lop.Substring(0, 10) : lop; // Limit string length

            // Get Checkbox Value
            CheckBox chkGender = (CheckBox)row.FindControl("chkGenderEdit");
            string phai = chkGender.Checked ? "1" : "0"; // Convert checkbox to 1 or 0

            // Update Query
            string query = "UPDATE SinhVien SET TenSV = @TenSV, Lop = @Lop, Phai = @Phai WHERE MaSV = @MaSV";
            db.OpenConnection();
            // Execute SQL Update
            using (SqlCommand cmd = new SqlCommand(query, db.con))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@TenSV", tenSV);
                cmd.Parameters.AddWithValue("@Lop", lop);
                cmd.Parameters.AddWithValue("@Phai", phai);
                cmd.ExecuteNonQuery();
            }
            db.CloseConnection();
            // Exit edit mode and refresh data
            grvStudent.EditIndex = -1;
            loadData();
        }

        protected void grvStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the primary key (Student ID)
            string maSV = grvStudent.DataKeys[e.RowIndex].Value.ToString();

            // Delete Query
            string query = "DELETE FROM SinhVien WHERE MaSV = @MaSV";

            // Execute SQL Delete
                db.OpenConnection();
            using (SqlCommand cmd = new SqlCommand(query, db.con))
            {
                cmd.Parameters.AddWithValue("@MaSV", maSV);

                cmd.ExecuteNonQuery();
            }
                db.CloseConnection();

            // Reload data after deleting
            loadData();
        }

        protected void grvStudent_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            grvStudent.DataKeys[e.NewSelectedIndex].Value.ToString();
        }

        protected void grvStudent_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
        {
            grvStudent.EditIndex = -1;
            loadData();
        }
    }
}
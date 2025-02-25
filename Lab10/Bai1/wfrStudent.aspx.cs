using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
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

        }

        protected void grvStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void grvStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grvStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void grvStudent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkGender = (CheckBox)e.Row.FindControl("chkGender");
                if (chkGender != null)
                {
                    // Phái "1" là Nam, Phái "0" là Nữ
                    string phaiValue = DataBinder.Eval(e.Row.DataItem, "Phai").ToString().Trim();
                    chkGender.Checked = phaiValue == "1";
                }
            }
        }

        protected void grvStudent_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            grvStudent.DataKeys[e.NewSelectedIndex].Value.ToString();
        }
    }
}
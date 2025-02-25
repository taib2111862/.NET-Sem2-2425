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
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace code
{
    public partial class wfrStudent : System.Web.UI.Page
    {
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            //clsDatabase.OpenConnection();
            //SqlCommand com = new SqlCommand("Select MaSV 'Mã sinh viên', TenSV 'Họ tên', Phai 'Phái', Lop 'Lớp' from SinhVien;", clsDatabase.con);
        }
        
        protected void loadData()
        {
            try
            {
                clsDatabase.OpenConnection();
                SqlCommand com = new SqlCommand("Select MaSV 'Mã sinh viên', TenSV 'Họ tên', Phai 'Phái', Lop 'Lớp' from SinhVien;", clsDatabase.con);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DataSet dataSet = new DataSet();

                dataSet.Tables.Add(dt);

                // tbl.DataSource = dataSet.Tables[0];

                if (dt.Rows.Count > 0)

                {
                    GridView1.DataSource = dataSet.Tables[0];
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Không có dữ liệu!');</script>");
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                

                clsDatabase.CloseConnection();
            }
            catch (Exception ex)
            {

            }   
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int genderColumnIndex = 3;
                string genderValue = e.Row.Cells[genderColumnIndex].Text.Trim();

                System.Web.UI.WebControls.CheckBox chkGender = new System.Web.UI.WebControls.CheckBox();
                chkGender.Enabled = false;


                if(genderValue == "0")
                {
                    chkGender.Checked = true;
                }

                e.Row.Cells[genderColumnIndex].Controls.Clear();
                e.Row.Cells[genderColumnIndex ].Controls.Add(chkGender);
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            loadData();
           
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string studentID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            GridViewRow row = GridView1.Rows[e.RowIndex];

            string tenSV = ((System.Web.UI.WebControls.TextBox)row.Cells[1].Controls[0]).Text;
            System.Web.UI.WebControls.CheckBox chGenderEdit = (System.Web.UI.WebControls.CheckBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];
            int phai = chGenderEdit.Checked ? 1:0;
            string lop = ((System.Web.UI.WebControls.TextBox)row.Cells[2].Controls[0]).Text;

            clsDatabase.OpenConnection();
                string query = "UPDATE SinhVien SET TenSV = @TenSV, Phai = @phai, Lop = @Lop WHERE StudentID = @studentID";
                using (SqlCommand cmd = new SqlCommand(query, clsDatabase.con))
                {
                cmd.Parameters.AddWithValue("@studentID",studentID);
                    cmd.Parameters.AddWithValue("@TenSV", tenSV);
                    cmd.Parameters.AddWithValue("@Phai", phai);
                    cmd.Parameters.AddWithValue("@Lop", lop);
                    cmd.ExecuteNonQuery();
                }
            clsDatabase.CloseConnection();
       

            GridView1.EditIndex = -1;
            loadData();
        }

    }
    

}
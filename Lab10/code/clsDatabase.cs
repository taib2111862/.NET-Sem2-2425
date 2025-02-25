using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace code
{
    public class clsDatabase
    {
        public static SqlConnection con;

        public static bool OpenConnection()
        {
            try
            {
                con = new SqlConnection("Data Source=TaiPham;Initial Catalog=QLSV;Integrated Security=True");
                con.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        public static bool CloseConnection()
        {
            try
            {
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
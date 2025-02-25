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
                con = new SqlConnection("Server=DESKTOP-NCPHGNK; Database=DVDLibrary; uid=mylogin; pwd=mylogin;");
                con.Open();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Could not open connection: " + ex.Message);
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
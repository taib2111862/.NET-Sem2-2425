using System;
using System.Data.SqlClient;

class clsDatabase
{
    private readonly string connectionString = "Data Source=TAIPHAM;Initial Catalog=QLSV;Integrated Security=True";
    public SqlConnection con;

    public SqlConnection OpenConnection()
    {
        try
        {
            con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool CloseConnection()
    {
        try
        {
            if (con != null && con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}

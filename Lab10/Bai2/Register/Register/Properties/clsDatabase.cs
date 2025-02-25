using System.Data.SqlClient;

public class clsDatabase
{
    private string connectionString;
    public SqlConnection connection;

    public clsDatabase()
    {
        connectionString = "Data Source=TAIPHAM;Initial Catalog=QLKhachHang;Integrated Security=True";

        connection = new SqlConnection(connectionString);
    }

    public void OpenConnection()
    {
        if (connection.State == System.Data.ConnectionState.Closed)
            connection.Open();
    }

    public void CloseConnection()
    {
        if (connection.State == System.Data.ConnectionState.Open)
            connection.Close();
    }

}
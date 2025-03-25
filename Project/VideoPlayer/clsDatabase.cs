using System;
using System.Data.SqlClient;

public class clsDatabase
{
    private readonly string connectionString = "Data Source=LAPTOP-TQ7FJ0PB;Initial Catalog=Video;Integrated Security=True;Encrypt=False";
    public SqlConnection con; // lưu trữ kết nối đến SQL Server

    // Hàm mở kết nối
    public SqlConnection OpenConnection()
    {
        try
        {
            con = new SqlConnection(connectionString); // Tạo kết nối mới
            con.Open(); // Mở kết nối
            return con; // Trả về đối tượng kết nối nếu thành công
        }
        catch (Exception ex)
        {
            return null; // Nếu có lỗi, trả về null
        }
    }
    // Hàm đóng kết nối
    public bool CloseConnection()
    {
        try
        {
            if (con != null && con.State == System.Data.ConnectionState.Open)
            {
                con.Close(); // Đóng kết nối nếu đang mở
            }
            return true; // Trả về true nếu đóng thành công
        }
        catch (Exception ex)
        {
            return false; // Trả về false nếu có lỗi
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib; 
using System.IO;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
namespace VideoPlayer
{
    public class VideoDatabaseManager
    {
        clsDatabase db = new clsDatabase();

        // nhóm các tính năng Get 
        public DataTable GetAllVideos()
        {
            string query = "SELECT vid_filepath, vid_title, last_opened FROM Videos order by last_opened desc";
            try
            {
                db.OpenConnection();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, db.con))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    db.CloseConnection();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception("Lỗi khi tải danh sách video từ database: " + ex.Message);
            }
        }

        // nhóm các tính năng Delete 

        // nhóm các tính năng Update 

        // nhóm các tinh năng insert
        public void InsertVideoToDatabase(string filePath)
        {
            string vidTitle = Path.GetFileNameWithoutExtension(filePath);
            string vidDescription = "Chưa có mô tả";
            TimeSpan vidDuration = GetVideoDuration(filePath);
            string formattedDuration = vidDuration.ToString(@"hh\:mm\:ss");

            string query = @"INSERT INTO Videos (vid_title, vid_filepath, vid_description, vid_duration)
                        VALUES (@title, @filepath, @description, @duration)";
            try
            {
                db.OpenConnection(); // Mở kết nối
                using (SqlCommand cmd = new SqlCommand(query, db.con))
                {
                    cmd.Parameters.AddWithValue("@title", vidTitle);
                    cmd.Parameters.AddWithValue("@filepath", filePath);
                    cmd.Parameters.AddWithValue("@description", vidDescription);
                    cmd.Parameters.AddWithValue("@duration", formattedDuration);

                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection(); // Đóng kết nối
            }
            catch (Exception ex)
            {
                db.CloseConnection(); // Đảm bảo đóng kết nối nếu có lỗi
                throw new Exception("Lỗi khi thêm video vào database: " + ex.Message);
            }
        }

        public void UpdateLastOpened(string filePath)
        {
            string query = @"UPDATE Videos 
                            SET last_opened = @lastOpened 
                            WHERE vid_filepath = @filepath";

            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, db.con))
                {
                    cmd.Parameters.AddWithValue("@lastOpened", DateTime.Now);
                    cmd.Parameters.AddWithValue("@filepath", filePath);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("Không tìm thấy video với đường dẫn này trong database.");
                    }
                }
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception("Lỗi khi cập nhật last_opened: " + ex.Message);
            }
        }

        public bool CheckFilePathExists(string filePath)
        {
            string query = "SELECT COUNT(*) FROM Videos WHERE vid_filepath = @filepath";

            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, db.con))
                {
                    cmd.Parameters.AddWithValue("@filepath", filePath);
                    int count = (int)cmd.ExecuteScalar();
                    db.CloseConnection();
                    return count > 0; // Trả về true nếu tồn tại, false nếu không
                }
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception("Lỗi khi kiểm tra filepath trong database: " + ex.Message);
            }
        }

        private TimeSpan GetVideoDuration(string filePath)
        {
            try
            {
                WindowsMediaPlayer wmp = new WindowsMediaPlayer();
                IWMPMedia media = wmp.newMedia(filePath);
                return TimeSpan.FromSeconds(media.duration);
            }
            catch (Exception)
            {
                return TimeSpan.Zero; // Trả về 0 nếu lỗi
            }
        }
        
    }
    }

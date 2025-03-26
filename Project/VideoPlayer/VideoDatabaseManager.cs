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

        // Nhóm các tính năng Get (hàm hiện tại của bạn, giữ nguyên)
        public DataTable GetAllVideos()
        {
            string query = "SELECT vid_filepath, vid_title, last_opened FROM Videos ORDER BY last_opened DESC";
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

        // Nhóm lấy danh sách video cho theo Category
        public DataTable GetVideosByCategory(int catId)
        {
            string query = @"SELECT vid_filepath, vid_title, last_opened, cat_id FROM Videos 
                            where cat_id = @catId
                            ORDER BY last_opened DESC;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, db.con))
                {
                    cmd.Parameters.AddWithValue("@catId", catId);
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        db.CloseConnection();
                        return dt;
                    }
               
                }
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception("Lỗi khi tải danh sách video theo Category: " + ex.Message);
            }
        }

        // Nhóm lấy danh sách video cho theo Tag
        public DataTable GetVideosByTag(int tagId)
        {
            string query = @"SELECT v.vid_filepath, v.vid_title, v.last_opened FROM Videos as v
                        join Videotags as vt on vt.vid_id = v.vid_id
                        where vt.tag_id = @tagId
                        ORDER BY last_opened DESC;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, db.con))
                {
                    cmd.Parameters.AddWithValue("@tagId", tagId);
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        db.CloseConnection();
                        return dt;
                    }

                }
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception("Lỗi khi tải danh sách video theo Tag: " + ex.Message);
            }
        }

        // Hàm mới: Lấy danh sách video cho DataGridView
        public DataTable GetVideosForDataGrid()
        {
            string query = @"
        SELECT v.vid_id, v.vid_title, v.vid_filepath, v.vid_description,v.vid_duration,v.cat_id, c.cat_name AS CategoryName
        FROM Videos v
        LEFT JOIN Categories c ON v.cat_id = c.cat_id
        ORDER BY v.last_opened DESC";

            DataTable dt = new DataTable();
            try
            {
                db.OpenConnection(); // Mở kết nối một lần duy nhất

                // Lấy danh sách video
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, db.con))
                {
                    adapter.Fill(dt);
                }

                // Thêm cột TagIds để lưu danh sách tag_id dưới dạng chuỗi
                dt.Columns.Add("TagIds", typeof(string));

                // Lấy tất cả tag_id cho các video trong một truy vấn duy nhất
                string tagQuery = @"
            SELECT vt.vid_id, vt.tag_id
            FROM VideoTags vt
            WHERE vt.vid_id IN (SELECT vid_id FROM Videos)";
                Dictionary<int, List<int>> videoTags = new Dictionary<int, List<int>>();

                using (SqlCommand cmd = new SqlCommand(tagQuery, db.con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int vidId = reader.GetInt32(0);
                            int tagId = reader.GetInt32(1);

                            if (!videoTags.ContainsKey(vidId))
                            {
                                videoTags[vidId] = new List<int>();
                            }
                            videoTags[vidId].Add(tagId);
                        }
                    }
                }

                // Gán danh sách tag_id vào cột TagIds
                foreach (DataRow row in dt.Rows)
                {
                    int vidId = Convert.ToInt32(row["vid_id"]);
                    if (videoTags.ContainsKey(vidId))
                    {
                        row["TagIds"] = string.Join(",", videoTags[vidId]);
                    }
                    else
                    {
                        row["TagIds"] = string.Empty;
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải danh sách video cho DataGridView từ database: " + ex.Message);
            }
            finally
            {
                db.CloseConnection(); // Đảm bảo kết nối luôn được đóng
            }
        }

        // Lấy danh sách Categories
        public DataTable GetAllCategories()
        {
            string query = "SELECT cat_id, cat_name FROM Categories";
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
                throw new Exception("Lỗi khi tải danh sách category từ database: " + ex.Message);
            }
        }



        // Lấy danh sách Tags
        public DataTable GetAllTags()
        {
            string query = "SELECT tag_id, tag_name FROM Tags";
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
                throw new Exception("Lỗi khi tải danh sách tag từ database: " + ex.Message);
            }
        }




        // Nhóm các tính năng Insert (hàm hiện tại của bạn, giữ nguyên)
        public void InsertVideoToDatabase(string filePath)
        {
            // Kiểm tra xem vid_filepath đã tồn tại hay chưa
            string checkQuery = "SELECT COUNT(*) FROM Videos WHERE vid_filepath = @filepath";
            db.OpenConnection();
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, db.con))
            {
                checkCmd.Parameters.AddWithValue("@filepath", filePath);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    db.CloseConnection();
                    throw new Exception($"Video với đường dẫn '{filePath}' đã tồn tại trong database. Vui lòng chọn một video khác.");
                }
            }

            string vidTitle = Path.GetFileNameWithoutExtension(filePath);
            string vidDescription = "Chưa có mô tả";
            TimeSpan vidDuration = GetVideoDuration(filePath);
            string formattedDuration = vidDuration.ToString(@"hh\:mm\:ss");

            string query = @"
        INSERT INTO Videos (vid_title, vid_filepath, vid_description, vid_duration)
        VALUES (@title, @filepath, @description, @duration)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, db.con))
                {
                    cmd.Parameters.AddWithValue("@title", vidTitle);
                    cmd.Parameters.AddWithValue("@filepath", filePath);
                    cmd.Parameters.AddWithValue("@description", vidDescription);
                    cmd.Parameters.AddWithValue("@duration", formattedDuration);

                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception("Lỗi khi thêm video vào database: " + ex.Message);
            }
        }


        // Hàm mới: Thêm video cho DataGridView
        public int InsertVideoForDataGrid(string filePath, string title, int catId, List<int> tagIds, string vidDescription = "Chưa có mô tả")
        {
            // Kiểm tra xem vid_filepath đã tồn tại hay chưa
            string checkQuery = "SELECT COUNT(*) FROM Videos WHERE vid_filepath = @filepath";
            db.OpenConnection();
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, db.con))
            {
                checkCmd.Parameters.AddWithValue("@filepath", filePath);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    db.CloseConnection();
                    throw new Exception($"Video với đường dẫn '{filePath}' đã tồn tại trong database. Vui lòng chọn một video khác.");
                }
            }

            TimeSpan vidDuration = GetVideoDuration(filePath);
            string formattedDuration = vidDuration.ToString(@"hh\:mm\:ss");

            string query = @"
                INSERT INTO Videos (vid_title, vid_filepath, vid_description, vid_duration, cat_id)
                VALUES (@title, @filepath, @description, @duration, @catId);
                SELECT SCOPE_IDENTITY();"; // Trả về ID của video vừa thêm

            try
            {
                int vidId;
                using (SqlCommand cmd = new SqlCommand(query, db.con))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@filepath", filePath);
                    cmd.Parameters.AddWithValue("@description", vidDescription); // Sử dụng vid_description
                    cmd.Parameters.AddWithValue("@duration", formattedDuration);
                    cmd.Parameters.AddWithValue("@catId", catId);

                    vidId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Thêm tags cho video
                if (tagIds != null && tagIds.Count > 0)
                {
                    InsertVideoTagsToDatabase(vidId, tagIds);
                }

                db.CloseConnection();
                return vidId;
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception("Lỗi khi thêm video cho DataGridView vào database: " + ex.Message);
            }
        }

        public void InsertVideoTagsToDatabase(int videoId, List<int> tagIds)
        {
            string query = "INSERT INTO VideoTags (vid_id, tag_id) VALUES (@vidId, @tagId)";
            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, db.con))
                {
                    foreach (int tagId in tagIds)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@vidId", videoId);
                        cmd.Parameters.AddWithValue("@tagId", tagId);
                        cmd.ExecuteNonQuery();
                    }
                }
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception("Lỗi khi thêm tags vào database: " + ex.Message);
            }
        }

        public void InsertTagToDatabase(string tagName)
        {
            string query = "INSERT INTO Tags (tag_name) VALUES (@tagName)";
            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, db.con))
                {
                    cmd.Parameters.AddWithValue("@tagName", tagName);
                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception("Lỗi khi thêm tag vào database: " + ex.Message);
            }
        }

        public void InsertCategoryToDatabase(string categoryName)
        {
            string query = "INSERT INTO Categories (cat_name) VALUES (@catName)";
            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, db.con))
                {
                    cmd.Parameters.AddWithValue("@catName", categoryName);
                    cmd.ExecuteNonQuery();
                }
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception("Lỗi khi thêm category vào database: " + ex.Message);
            }
        }

        // Nhóm các tính năng Delete
        public void DeleteVideoFromDatabase(string filePath)
        {
            string getVidIdQuery = "SELECT vid_id FROM Videos WHERE vid_filepath = @filepath";
            string deleteVideoTagsQuery = "DELETE FROM VideoTags WHERE vid_id = @vidId";
            string deleteVideoQuery = "DELETE FROM Videos WHERE vid_filepath = @filepath";

            try
            {
                db.OpenConnection();

                // Lấy vid_id
                int vidId;
                using (SqlCommand cmd = new SqlCommand(getVidIdQuery, db.con))
                {
                    cmd.Parameters.AddWithValue("@filepath", filePath);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        throw new Exception("Không tìm thấy video với đường dẫn này trong database.");
                    }
                    vidId = Convert.ToInt32(result);
                }

                // Xóa các bản ghi trong VideoTags
                using (SqlCommand cmd = new SqlCommand(deleteVideoTagsQuery, db.con))
                {
                    cmd.Parameters.AddWithValue("@vidId", vidId);
                    cmd.ExecuteNonQuery();
                }

                // Xóa video
                using (SqlCommand cmd = new SqlCommand(deleteVideoQuery, db.con))
                {
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
                throw new Exception("Lỗi khi xóa video từ database: " + ex.Message);
            }
        }

        public void DeleteTagFromDatabase(int tagId)
        {
            string deleteVideoTagsQuery = "DELETE FROM VideoTags WHERE tag_id = @tagId";
            string deleteTagQuery = "DELETE FROM Tags WHERE tag_id = @tagId";

            try
            {
                db.OpenConnection();

                // Xóa các bản ghi trong VideoTags
                using (SqlCommand cmd = new SqlCommand(deleteVideoTagsQuery, db.con))
                {
                    cmd.Parameters.AddWithValue("@tagId", tagId);
                    cmd.ExecuteNonQuery();
                }

                // Xóa tag
                using (SqlCommand cmd = new SqlCommand(deleteTagQuery, db.con))
                {
                    cmd.Parameters.AddWithValue("@tagId", tagId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("Không tìm thấy tag với ID này trong database.");
                    }
                }

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception("Lỗi khi xóa tag từ database: " + ex.Message);
            }
        }

        public void DeleteCategoryFromDatabase(int catId)
        {
            string updateVideosQuery = "UPDATE Videos SET cat_id = NULL WHERE cat_id = @catId";
            string deleteCategoryQuery = "DELETE FROM Categories WHERE cat_id = @catId";

            try
            {
                db.OpenConnection();

                // Đặt cat_id về NULL cho các video liên quan
                using (SqlCommand cmd = new SqlCommand(updateVideosQuery, db.con))
                {
                    cmd.Parameters.AddWithValue("@catId", catId);
                    cmd.ExecuteNonQuery();
                }

                // Xóa category
                using (SqlCommand cmd = new SqlCommand(deleteCategoryQuery, db.con))
                {
                    cmd.Parameters.AddWithValue("@catId", catId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("Không tìm thấy category với ID này trong database.");
                    }
                }

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception("Lỗi khi xóa category từ database: " + ex.Message);
            }
        }

        // Nhóm các tính năng Update
        public void UpdateLastOpened(string filePath)
        {
            string query = @"
                UPDATE Videos 
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

        public void UpdateCategory(int catId, string catName)
        {
            string query = "UPDATE Categories SET cat_name = @catName WHERE cat_id = @catId";
            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, db.con))
                {
                    cmd.Parameters.AddWithValue("@catName", catName);
                    cmd.Parameters.AddWithValue("@catId", catId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("Không tìm thấy category với ID này để cập nhật.");
                    }
                }
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception("Lỗi khi cập nhật category trong database: " + ex.Message);
            }
        }

        public void UpdateTag(int tagId, string tagName)
        {
            string query = "UPDATE Tags SET tag_name = @tagName WHERE tag_id = @tagId";
            try
            {
                db.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, db.con))
                {
                    cmd.Parameters.AddWithValue("@tagName", tagName);
                    cmd.Parameters.AddWithValue("@tagId", tagId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("Không tìm thấy tag với ID này để cập nhật.");
                    }
                }
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception("Lỗi khi cập nhật tag trong database: " + ex.Message);
            }
        }

        public void UpdateVideo(int vidId, string title, int catId, List<int> tagIds)
        {
            string updateVideoQuery = @"
                UPDATE Videos 
                SET vid_title = @title, cat_id = @catId 
                WHERE vid_id = @vidId";
            string deleteTagsQuery = "DELETE FROM VideoTags WHERE vid_id = @vidId";
            string insertTagsQuery = "INSERT INTO VideoTags (vid_id, tag_id) VALUES (@vidId, @tagId)";

            try
            {
                db.OpenConnection();

                // Cập nhật tiêu đề và category của video
                using (SqlCommand cmd = new SqlCommand(updateVideoQuery, db.con))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@catId", catId);
                    cmd.Parameters.AddWithValue("@vidId", vidId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("Không tìm thấy video với ID này để cập nhật.");
                    }
                }

                // Xóa tags cũ
                using (SqlCommand cmd = new SqlCommand(deleteTagsQuery, db.con))
                {
                    cmd.Parameters.AddWithValue("@vidId", vidId);
                    cmd.ExecuteNonQuery();
                }

                // Thêm tags mới
                using (SqlCommand cmd = new SqlCommand(insertTagsQuery, db.con))
                {
                    foreach (int tagId in tagIds)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@vidId", vidId);
                        cmd.Parameters.AddWithValue("@tagId", tagId);
                        cmd.ExecuteNonQuery();
                    }
                }

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                db.CloseConnection();
                throw new Exception("Lỗi khi cập nhật video trong database: " + ex.Message);
            }
        }

        // Nhóm các tính năng Check
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
                    return count > 0;
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
                return TimeSpan.Zero;
            }
        }
    }
}
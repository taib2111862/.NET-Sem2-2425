using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace VideoPlayer
{
    public partial class frmMediaPlayer : Form
    {
        List<string> filteredFiles = new List<string>();
        int currentFile = 0;

        List<string> categoryFilteredFiles = new List<string>(); // Danh sách video trong tab "Category"
        int categoryCurrentFile = 0; // Chỉ số video hiện tại trong tab "Category"

        List<string> tagFilteredFiles = new List<string>(); // Danh sách video trong tab "Tags"
        int tagCurrentFile = 0;

        OpenFileDialog browser = new OpenFileDialog();
        private VideoDatabaseManager dbManager; 

        public frmMediaPlayer()
        {
            InitializeComponent();

            categoriesToolStripMenuItem.Click += new EventHandler(categoriesToolStripMenuItem_Click);
            tagsToolStripMenuItem.Click += new EventHandler(tagsToolStripMenuItem_Click);
            videosToolStripMenuItem.Click += new EventHandler(videosToolStripMenuItem_Click);



            // thiêt lập event cho tab control khi chuyển tab
            tabVideoInformation.SelectedIndexChanged += new EventHandler(tabVideoInformation_SelectedIndexChanged);
            lstVideosWithCategory.SelectedIndexChanged += new EventHandler(lstVideosWithCategory_SelectedIndexChanged);
            lstVideoTags.SelectedIndexChanged += new EventHandler(lstVideoTags_SelectedIndexChanged);
            lstVideosWithSameTag.SelectedIndexChanged += new EventHandler(lstVideosWithSameTag_SelectedIndexChanged);

            dbManager = new VideoDatabaseManager();

            // Hiển thị tooltip (title day du) khi di chuột qua các video trong Playlist
            ToolTip toolTip = new ToolTip();
            PlayList.MouseMove += (sender, e) =>
            {
                int index = PlayList.IndexFromPoint(e.Location);
                if (index >= 0 && index < PlayList.Items.Count)
                {
                    string title = PlayList.Items[index].ToString();
                    toolTip.SetToolTip(PlayList, title);
                }
            };

            LoadVideosFromDatabase();
        }

        private void OpenFileEvent(object sender, EventArgs e)
        {
            VideoPlayer.Ctlcontrols.stop();
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Video Files (*.mp4;*.avi;*.mkv)|*.mp4;*.avi;*.mkv|All Files (*.*)|*.*", 
                Multiselect = true, 
                Title = "Chọn video để upload"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                int addCount = 0;
                string lastURl = "";// Lưu trữ url cuối cùng sẽ được play sau khi thêm vao database
                foreach (string filePath in openFileDialog.FileNames)
                {
                    try
                    {
                        if (!dbManager.CheckFilePathExists(filePath)) // Kiểm tra filepath
                        {
                            dbManager.InsertVideoToDatabase(filePath);
                            filteredFiles.Add(filePath);
                            addCount++;
                        }
                        else
                        {
                            dbManager.UpdateLastOpened(filePath); // Cập nhật last_opened nếu đã tồn tại
                            MessageBox.Show($"Video đã tồn tại, cập nhật last_opened: {Path.GetFileName(filePath)}");
                        }
                        lastURl = filePath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                if(addCount > 0)
                {
                    MessageBox.Show("Video đã được thêm vào database!");
                }
                PlayFile(lastURl);
                LoadVideosFromDatabase();
            }
        }
        private void LoadVideosFromDatabase()
        {
            try
            {
                DataTable videos = dbManager.GetAllVideos();
                filteredFiles.Clear();
                PlayList.Items.Clear();
                VideoPlayer.currentPlaylist = VideoPlayer.newPlaylist("PlayList", "");

                foreach (DataRow row in videos.Rows)
                {
                    string filePath = row["vid_filepath"].ToString();
                    string title = row["vid_title"].ToString();
                    if (File.Exists(filePath)) // Kiểm tra file tồn tại
                    {
                        filteredFiles.Add(filePath);
                        PlayList.Items.Add(title); // Hiển thị tiêu đề trong ListBox
                        VideoPlayer.currentPlaylist.appendItem(VideoPlayer.newMedia(filePath));
                    }
                }

                if (PlayList.Items.Count > 0)
                {
                    currentFile = 0; // Đặt currentFile về 0 nếu danh sách không rỗng
                    PlayList.SelectedIndex = currentFile;
                    PlayFile(filteredFiles[currentFile]); // Phát video đầu tiên
                    lblVideoTitle.Text = PlayList.Items[currentFile].ToString();
                }
                else
                {
                    currentFile = -1; // Đặt currentFile về -1 nếu không có video
                    MessageBox.Show("No videos found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadVideosByTagFromDatabase()
        {
            try
            {
                DataTable videos = dbManager.GetAllVideos();
                filteredFiles.Clear();
                PlayList.Items.Clear();
                VideoPlayer.currentPlaylist = VideoPlayer.newPlaylist("PlayList", "");

                foreach (DataRow row in videos.Rows)
                {
                    string filePath = row["vid_filepath"].ToString();
                    string title = row["vid_title"].ToString();
                    if (File.Exists(filePath)) // Kiểm tra file tồn tại
                    {
                        filteredFiles.Add(filePath);
                        PlayList.Items.Add(title); // Hiển thị tiêu đề trong ListBox
                        VideoPlayer.currentPlaylist.appendItem(VideoPlayer.newMedia(filePath));
                    }
                }

                if (PlayList.Items.Count > 0)
                {
                    PlayList.SelectedIndex = currentFile;
                    PlayFile(filteredFiles[currentFile]); // Phát video đầu tiên
                    lblVideoTitle.Text = PlayList.Items[currentFile].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadVideosByCatgoryFromDatabase()
        {
            try
            {
                // Kiểm tra xem filteredFiles có rỗng hay không
                if (filteredFiles.Count == 0 || currentFile < 0 || currentFile >= filteredFiles.Count)
                {
                    MessageBox.Show("No video is currently selected. Please select a video from the Videos tab first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy đường dẫn của video hiện tại trong tab "Videos"
                string currentVideoFilePath = filteredFiles[currentFile];

                // Lấy category của video hiện tại
                DataTable category = dbManager.GetCategoryByVideo(currentVideoFilePath);
                if (category.Rows.Count == 0)
                {
                    MessageBox.Show("No category found for the current video.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int cat_id = category.Rows[0].Field<int>("cat_id");
                string cat_name = category.Rows[0].Field<string>("cat_name");

                // Hiển thị tên category trên giao diện
                lblCategoryPlaylist.Text = $"Videos in Category: {cat_name}";

                // Lấy danh sách video theo category
                DataTable videos = dbManager.GetVideosByCategory(cat_id);
                categoryFilteredFiles.Clear();
                lstVideosWithCategory.Items.Clear();

                foreach (DataRow row in videos.Rows)
                {
                    string filePath = row["vid_filepath"].ToString();
                    string title = row["vid_title"].ToString();
                    if (File.Exists(filePath)) // Kiểm tra file tồn tại
                    {
                        categoryFilteredFiles.Add(filePath);
                        lstVideosWithCategory.Items.Add(title); // Hiển thị tiêu đề trong ListBox
                    }
                }

                if (lstVideosWithCategory.Items.Count > 0)
                {
                    // Tìm chỉ số của video hiện tại trong danh sách category (nếu có)
                    int newIndex = categoryFilteredFiles.IndexOf(currentVideoFilePath);
                    if (newIndex >= 0)
                    {
                        categoryCurrentFile = newIndex; // Giữ video hiện tại nếu nó có trong danh sách
                    }
                    else
                    {
                        categoryCurrentFile = 0; // Nếu không tìm thấy, chọn video đầu tiên
                    }

                    lstVideosWithCategory.SelectedIndex = categoryCurrentFile;
                    lblVideoTitle.Text = lstVideosWithCategory.Items[categoryCurrentFile].ToString();

                    // Kiểm tra xem video hiện tại có đang phát hay không
                    string selectedFilePath = categoryFilteredFiles[categoryCurrentFile];
                    if (VideoPlayer.URL != selectedFilePath)
                    {
                        PlayFile(selectedFilePath); // Chỉ phát nếu video khác với video đang phát
                    }
                }
                else
                {
                    MessageBox.Show($"No videos found in category: {cat_name}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading videos by category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadTagsByVideo()
        {
            try
            {
                // Kiểm tra xem filteredFiles có rỗng hay không
                if (filteredFiles.Count == 0 || currentFile < 0 || currentFile >= filteredFiles.Count)
                {
                    MessageBox.Show("No video is currently selected. Please select a video from the Videos tab first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy đường dẫn của video hiện tại
                string currentVideoFilePath = filteredFiles[currentFile];

                // Lấy danh sách tag của video hiện tại
                DataTable tags = dbManager.GetTagsByVideo(currentVideoFilePath);
                lstVideoTags.Items.Clear();

                foreach (DataRow row in tags.Rows)
                {
                    string tagName = row["tag_name"].ToString();
                    lstVideoTags.Items.Add(new TagItem { TagId = row.Field<int>("tag_id"), TagName = tagName });
                }

                // Nếu có tag, chọn tag đầu tiên và tải danh sách video có cùng tag
                if (lstVideoTags.Items.Count > 0)
                {
                    lstVideoTags.SelectedIndex = 0; // Chọn tag đầu tiên
                }
                else
                {
                    lstVideosWithSameTag.Items.Clear();
                    tagFilteredFiles.Clear();
                    MessageBox.Show("No tags found for the current video.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tags for video: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PlayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlayList.SelectedIndex >= 0)
            {
                currentFile = PlayList.SelectedIndex;
                string selectedFilePath = filteredFiles[currentFile];
                PlayFile(selectedFilePath);
                lblVideoTitle.Text = PlayList.Items[currentFile].ToString();
            }
        }
        private void lstVideosWithCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVideosWithCategory.SelectedIndex >= 0)
            {
                categoryCurrentFile = lstVideosWithCategory.SelectedIndex;
                string selectedFilePath = categoryFilteredFiles[categoryCurrentFile];
                PlayFile(selectedFilePath);
                lblVideoTitle.Text = lstVideosWithCategory.Items[categoryCurrentFile].ToString();

                // Đồng bộ currentFile với tab "Videos"
                int newIndex = filteredFiles.IndexOf(selectedFilePath);
                if (newIndex >= 0)
                {
                    currentFile = newIndex;
                    PlayList.SelectedIndex = currentFile;
                }
            }
        }

        private void lstVideoTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVideoTags.SelectedIndex >= 0)
            {
                // Lấy tag được chọn
                TagItem selectedTag = (TagItem)lstVideoTags.SelectedItem;
                int tagId = selectedTag.TagId;

                try
                {
                    // Lấy danh sách video có cùng tag
                    DataTable videos = dbManager.GetVideosByTag(tagId);
                    tagFilteredFiles.Clear();
                    lstVideosWithSameTag.Items.Clear();

                    foreach (DataRow row in videos.Rows)
                    {
                        string filePath = row["vid_filepath"].ToString();
                        string title = row["vid_title"].ToString();
                        if (File.Exists(filePath)) // Kiểm tra file tồn tại
                        {
                            tagFilteredFiles.Add(filePath);
                            lstVideosWithSameTag.Items.Add(title);
                        }
                    }

                    if (lstVideosWithSameTag.Items.Count > 0)
                    {
                        // Tìm chỉ số của video hiện tại trong danh sách tag (nếu có)
                        string currentVideoFilePath = filteredFiles[currentFile];
                        int newIndex = tagFilteredFiles.IndexOf(currentVideoFilePath);
                        if (newIndex >= 0)
                        {
                            tagCurrentFile = newIndex; // Giữ video hiện tại nếu nó có trong danh sách
                        }
                        else
                        {
                            tagCurrentFile = 0; // Nếu không tìm thấy, chọn video đầu tiên
                        }

                        // Cập nhật giao diện
                        lstVideosWithSameTag.SelectedIndex = tagCurrentFile;
                        lblVideoTitle.Text = lstVideosWithSameTag.Items[tagCurrentFile].ToString();

                        // Kiểm tra xem video hiện tại có đang phát hay không
                        string selectedFilePath = tagFilteredFiles[tagCurrentFile];
                        if (VideoPlayer.URL != selectedFilePath)
                        {
                            PlayFile(selectedFilePath); // Chỉ phát nếu video khác với video đang phát
                        }
                    }
                    else
                    {
                        MessageBox.Show($"No videos found with tag: {selectedTag.TagName}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading videos by tag: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lstVideosWithSameTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVideosWithSameTag.SelectedIndex >= 0)
            {
                tagCurrentFile = lstVideosWithSameTag.SelectedIndex;
                string selectedFilePath = tagFilteredFiles[tagCurrentFile];
                PlayFile(selectedFilePath);
                lblVideoTitle.Text = lstVideosWithSameTag.Items[tagCurrentFile].ToString();

                // Đồng bộ currentFile với tab "Videos"
                int newIndex = filteredFiles.IndexOf(selectedFilePath);
                if (newIndex >= 0)
                {
                    currentFile = newIndex;
                    PlayList.SelectedIndex = currentFile;
                }
            }
        }

        private void PlayFile(string url)
        {
            // Kiểm tra xem video có đang phát hay không
            if (VideoPlayer.URL != url)
            {
                VideoPlayer.URL = url;
            }

            dbManager.UpdateLastOpened(url);

            // Đồng bộ currentFile và categoryCurrentFile
            int newIndexInVideos = filteredFiles.IndexOf(url);
            if (newIndexInVideos >= 0)
            {
                currentFile = newIndexInVideos;
                PlayList.SelectedIndex = currentFile;
            }

            int newIndexInCategory = categoryFilteredFiles.IndexOf(url);
            if (newIndexInCategory >= 0)
            {
                categoryCurrentFile = newIndexInCategory;
                lstVideosWithCategory.SelectedIndex = categoryCurrentFile;
            }
        }






        private void tabVideoInformation_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu tab hiện tại là tab "Category"
            if (tabVideoInformation.SelectedTab == tabCategory)
            {
                LoadVideosByCatgoryFromDatabase();
            }
            // Kiểm tra nếu tab hiện tại là tab "Tags"
            else if (tabVideoInformation.SelectedTab == tabTags)
            {
                LoadTagsByVideo();
            }
        }

        private void VideoPlayerStateChangeEvent(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

        }

        private void TimerEvent(object sender, EventArgs e)
        {

        }

        private void LoadCategory()
        {

        }

        private void LoadTags() {
        
        }

        private void VideoPlayer_Enter(object sender, EventArgs e)
        {

        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở ManageForm và chọn tab Categories (index 0)
            VideoPlayer.Ctlcontrols.stop();
            //ShowDialog() mở ManageForm dưới dạng một cửa sổ modal, nghĩa là người dùng phải đóng ManageForm trước khi có thể tương tác lại với frmMediaPlayer.
            using (ManageForm manageForm = new ManageForm(0))
            {
                manageForm.ShowDialog();
            }
            LoadVideosFromDatabase();
        }

        private void tagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở ManageForm và chọn tab Tags (index 1)
            VideoPlayer.Ctlcontrols.stop();
            using (ManageForm manageForm = new ManageForm(1))
            {
                manageForm.ShowDialog();
            }
            LoadVideosFromDatabase();
        }

        private void videosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở ManageForm và chọn tab Videos (index 2)
            VideoPlayer.Ctlcontrols.stop();
            using (ManageForm manageForm = new ManageForm(2))
            {
                manageForm.ShowDialog();
            }
            LoadVideosFromDatabase(); 
        }

        public class TagItem
        {
            public int TagId { get; set; }
            public string TagName { get; set; }

            public override string ToString()
            {
                return TagName; // Hiển thị tag_name trong ListBox
            }
        }
    }
}

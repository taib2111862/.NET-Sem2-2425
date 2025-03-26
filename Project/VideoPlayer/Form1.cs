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
        OpenFileDialog browser = new OpenFileDialog();
        private VideoDatabaseManager dbManager; 

        public frmMediaPlayer()
        {
            InitializeComponent();

            categoriesToolStripMenuItem.Click += new EventHandler(categoriesToolStripMenuItem_Click);
            tagsToolStripMenuItem.Click += new EventHandler(tagsToolStripMenuItem_Click);
            videosToolStripMenuItem.Click += new EventHandler(videosToolStripMenuItem_Click);

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

        private void PlayFile(string url)
        {
            VideoPlayer.URL = url;
            dbManager.UpdateLastOpened(url);
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
    }
}

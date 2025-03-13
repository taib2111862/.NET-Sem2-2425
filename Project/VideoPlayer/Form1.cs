using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        FolderBrowserDialog browser = new FolderBrowserDialog();

        public frmMediaPlayer()
        {
            InitializeComponent();
        }

        private void OpenFileEvent(object sender, EventArgs e)
        {
            VideoPlayer.Ctlcontrols.stop();
            if (filteredFiles.Count > 1)
            {
                filteredFiles.Clear();
                filteredFiles = null;
                PlayList.Items.Clear();
                currentFile = 0;
            }
            DialogResult result = browser.ShowDialog();
            if (result == DialogResult.OK)
            {
                filteredFiles = Directory.GetFiles(browser.SelectedPath, "*.*")
                    .Where(file => file.ToLower().EndsWith("webm") ||
                                   file.ToLower().EndsWith("mp4") ||
                                   file.ToLower().EndsWith("wmv") ||
                                   file.ToLower().EndsWith("mkv") ||
                                   file.ToLower().EndsWith("avi"))
                    .ToList();
                LoadPlayList();
            }
        }
        private void LoadPlayList()
        {
            VideoPlayer.currentPlaylist = VideoPlayer.newPlaylist("PlayList", "");
            foreach (string videos in filteredFiles)
            {
                VideoPlayer.currentPlaylist.appendItem(VideoPlayer.newMedia(videos));
                PlayList.Items.Add(videos);
            }
            if (filteredFiles.Count > 0)
            {
                
                PlayList.SelectedIndex = currentFile;
                PlayFile(PlayList.SelectedItem.ToString());
                
            }
            else
            {
                MessageBox.Show("No Video Files Found in this folder");
            }
        }

        private void PlayFile(string url)
        {
            VideoPlayer.URL = url;
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
    }
}

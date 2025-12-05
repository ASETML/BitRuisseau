using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using TagLib.IFD.Tags;

namespace BitRuisseau
{
    public partial class HomeForm : Form
    {
        private string _songFolder;

        public HomeForm()
        {
            InitializeComponent();

            //Load the last used song path
            if (Path.Exists(Config.LASTUSEDPATHFILE))
            {
                _songFolder = File.ReadAllText(Config.LASTUSEDPATHFILE);
                this.lbl_selectedFolder.Text = _songFolder;
                Program.songs = LoadSongs(GetDirectoryAudioFiles(_songFolder));
                Program.songs.ForEach(s => flp_localList.Controls.Add(new SongCard(s)));
            }

            Protocol.SayOnline();
        }

        /// <summary>
        /// Get all the audio file (mp3, wav, ogg) of a folder
        /// </summary>
        /// <param name="dir">The folder to search</param>
        /// <returns>A list of all audio file path</returns>
        public List<string> GetDirectoryAudioFiles(string dir)
        {
            EnumerationOptions options = new EnumerationOptions();
            options.RecurseSubdirectories = true;
            return Directory.GetFileSystemEntries(dir, "*", options).ToList().Where(e => IsAudioFile(e)).ToList();
        }

        /// <summary>
        /// Indicate if a path is an audio file
        /// </summary>
        /// <param name="path">The path to check</param>
        /// <returns>true if it is an audio file, else false</returns>
        public bool IsAudioFile(string path)
        {
            foreach (string extension in Config.SUPPORTEDFILETYPES)
            {
                if (path.EndsWith(extension) && File.Exists(path))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Transform a list of file path into a list of song
        /// </summary>
        /// <param name="audioFiles">The list that contains the path of all audio files</param>
        /// <returns>A list of songs</returns>
        public List<Song> LoadSongs(List<string> audioFiles)
        {
            return audioFiles.Select(f => new Song(f)).ToList();
        }

        /// <summary>
        /// Open the FolderBrowserDialog to select the folder to open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_selectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();

            openFolderDialog.InitialDirectory = $"c:\\Users\\{Environment.UserName}\\Music";

            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                _songFolder = openFolderDialog.SelectedPath;
                this.lbl_selectedFolder.Text = _songFolder;
                File.WriteAllText(Config.LASTUSEDPATHFILE, _songFolder);
                Program.songs.Clear();
                Program.songs = LoadSongs(GetDirectoryAudioFiles(_songFolder));

                flp_localList.Controls.Clear();
                Program.songs.ForEach(s => flp_localList.Controls.Add(new SongCard(s)));
            }
        }

        private async void btn_loadMediatheques_Click(object sender, EventArgs e)
        {
            Program.mediathequeSongs.Clear();

            await Protocol.GetOnlineMediatheque();

            Thread.Sleep(200);

            flp_mediathequesList.Controls.Clear();
            foreach (KeyValuePair<string, List<ISong>> mediatheque in Program.mediathequeSongs)
            {
                flp_mediathequesList.Controls.Add(new MediathequeCard(mediatheque.Key));
            }
        }
    }
}

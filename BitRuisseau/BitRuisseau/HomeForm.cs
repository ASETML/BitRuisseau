using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using TagLib.IFD.Tags;

namespace BitRuisseau
{
    public partial class HomeForm : Form
    {
        public List<Song> songs { get; set; }
        private string _songFolder;
        //TODO: move to a config class
        private string[] supportedFileTypes = ["mp3", "wav", "ogg"]; 

        public HomeForm()
        {
            InitializeComponent();

            //Load the last used song path
            if (Path.Exists("path.txt"))
            {
                _songFolder = File.ReadAllText("path.txt");
                this.lbl_selectedFolder.Text = _songFolder;
                songs = LoadSongs(GetDirectoryAudioFiles(_songFolder));

                //TEMP
                songs.ForEach(s => Trace.WriteLine(JsonSerializer.Serialize(s)));
            }

            File.WriteAllText("txt.txt", JsonSerializer.Serialize(new Message { Action = "online", Recipient = "0.0.0.0", Sender = "ME" }));

            Song s = new Song("song.mp3");
            Trace.WriteLine(s.Hash);
            Trace.WriteLine(JsonSerializer.Serialize(s));
            new MqttService();
        }

        /// <summary>
        /// Get all the audio file (mp3, wav, ogg) of a folder
        /// </summary>
        /// <param name="dir">The folder to search</param>
        /// <returns>A list of all audio file path</returns>
        public List<string> GetDirectoryAudioFiles(string dir)
        {
            return Directory.GetFileSystemEntries(dir).ToList().Where(e => IsAudioFile(e)).ToList();
        }

        /// <summary>
        /// Indicate if a path is an audio file
        /// </summary>
        /// <param name="path">The path to check</param>
        /// <returns>true if it is an audio file, else false</returns>
        public bool IsAudioFile(string path)
        {
            foreach (string extension in supportedFileTypes)
            {
                return path.EndsWith(extension) && File.Exists(path) ? true : false;
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
                File.WriteAllText("path.txt", _songFolder);
                songs = LoadSongs(GetDirectoryAudioFiles(_songFolder));
            }
        }
    }
}

using System.Diagnostics;
using System.Text.Json;
using TagLib.IFD.Tags;

namespace BitRuisseau
{
    public partial class HomeForm : Form
    {
        public readonly List<Song> songs;
        private string _songFolder;

        public HomeForm()
        {
            InitializeComponent();

            if (Path.Exists("path.txt"))
            {
                _songFolder = File.ReadAllText("path.txt");
                this.lbl_selectedFolder.Text = _songFolder;
            }

            File.WriteAllText("txt.txt", JsonSerializer.Serialize(new Message { Action = "online", Recipient = "0.0.0.0", Sender = "ME" }));

            Song s = new Song("song.mp3");
            Trace.WriteLine(s.Hash);
            Trace.WriteLine(JsonSerializer.Serialize(s));
            new MqttService();
        }

        /// <summary>
        /// Open the FileDialog to select the file to import
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImportFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();

            openFolderDialog.InitialDirectory = "c:\\";

            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                _songFolder = openFolderDialog.SelectedPath;
                this.lbl_selectedFolder.Text = _songFolder;
                File.WriteAllText("path.txt", _songFolder);
            }
        }
    }
}

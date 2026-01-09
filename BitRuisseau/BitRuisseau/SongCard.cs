using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BitRuisseau
{
    /// <summary>
    /// Display a song
    /// </summary>
    public partial class SongCard : UserControl
    {
        private readonly Song song; //The song to display
        public SongCard(Song s)
        {
            InitializeComponent();
            this.song = s;
            this.lbl_title_artist.Text = $"{song.Title} - {song.Artist}";
            this.lbl_year_duration_size.Text = $"{song.Year} - {song.Duration.Minutes}:{song.Duration.Seconds} - {(song.Size / 1024f / 1024f).ToString("0.00")}MB";
            this.lbl_featuring.Text = $"{(song.Featuring.Length > 0 ? song.Featuring.First() : string.Empty)}";
        }

        /// <summary>
        /// Send an event when the download button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_download_Click(object sender, EventArgs e)
        {
            string name = Program.mediathequeSongs.Where(m => m.Value.Contains(song)).First().Key;
            Trace.WriteLine(song.Hash + " :" + name + " :" + song.Size);
            await Protocol.AskMedia(song.Hash, name, 0, song.Size); //TEMP name
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitRuisseau
{
    public partial class SongCard : UserControl
    {
        private readonly Song song;
        public SongCard(Song s)
        {
            InitializeComponent();
            this.song = s;
            this.lbl_title_artist.Text = $"{song.Title} - {song.Artist}";
            this.lbl_year_duration_size.Text = $"{song.Year} - {song.Duration.Minutes}:{song.Duration.Seconds} - {(song.Size / 1024f / 1024f).ToString("0.00")}MB";
            this.lbl_featuring.Text = $"{(song.Featuring.Length > 0 ? song.Featuring.First() : string.Empty)}";
        }
    }
}

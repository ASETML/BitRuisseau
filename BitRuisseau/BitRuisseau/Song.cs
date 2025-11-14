using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitRuisseau
{
    public class Song : ISong
    {
        /// <summary>
        /// The song title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The song artist
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// The song release date
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// The song duration in milliseconde
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// The song file size in bytes
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The song featuring artists
        /// </summary>
        public string[] Featuring { get; set; }

        /// <summary>
        /// The hash of the file content
        /// </summary>
        public string Hash { get; }

        /// <summary>
        /// The song path on disk
        /// </summary>
        [JsonIgnore]
        public string Path { get; set; }

        public Song(string path)
        {
            TagLib.File tagFile = TagLib.File.Create(path);
            Title = tagFile.Tag.Title;
            Artist = tagFile.Tag.FirstAlbumArtist;
            Year = Int32.Parse(tagFile.Tag.Year.ToString());
            Duration = tagFile.Properties.Duration;
            Size = Int32.Parse(new FileInfo(path).Length.ToString());
            Featuring = tagFile.Tag.Artists;
            Hash = Helper.HashFile(path);
        }
    }
}

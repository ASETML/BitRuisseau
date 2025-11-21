using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau
{
    public interface ISong
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
        /// The file format of the song
        /// </summary>
        public string Extension { get; }
    }
}

using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitRuisseau
{
    public class Message
    {
        /// <summary>
        /// The message recipient
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// The message sender
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// What this message is for
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// The starting byte
        /// </summary>
        public int ?StartByte { get; set; }

        /// <summary>
        /// The ending Byte
        /// </summary>
        public int ?EndByte { get; set; }

        /// <summary>
        /// The list of song metadata
        /// </summary>
        public List<ISong> ?SongList { get; set; }

        /// <summary>
        /// The base64 encoded byte array of the audio file
        /// </summary>
        public string ?SongData { get; set; }

        /// <summary>
        /// The hash of the file asked/sent
        /// </summary>
        public string ?Hash { get; set; }
    }
}

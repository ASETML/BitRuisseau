using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau
{
    public static class Config
    {
        //The supported formats of the audio
        public static string[] SUPPORTEDFILETYPES = { "mp3", "wav", "ogg" };

        //The name of the file that store the last used directory
        public static string LASTUSEDPATHFILE = "lastUsedPath.txt";

        //The topic on which the communication happens
        public const string TOPIC = "BitRuisseau";
    }
}

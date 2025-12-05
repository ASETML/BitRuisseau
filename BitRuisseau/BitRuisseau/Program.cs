using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
namespace BitRuisseau
{
    internal static class Program
    {
        //The list of local songs
        public static List<Song> songs { get; set; } = new List<Song>();

        //The list of mediatheques and their songs
        public static Dictionary<string, List<ISong>> mediathequeSongs { get; set; } = new Dictionary<string, List<ISong>>();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new HomeForm());
        }
    }
}
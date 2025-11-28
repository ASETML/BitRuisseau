using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BitRuisseau
{
    public static class Protocol
    {
        private static MqttService mqttService = new MqttService();
        /// <summary>
        /// Get the list of all online mediatheque
        /// </summary>
        /// <returns>An array of mediatheque name/ip</returns>
        public static string[] GetOnlineMediatheque()
        {
            mqttService.SendMessage(new Message() { Action = "askOnline", Recipient = "0.0.0.0", Sender = System.Net.Dns.GetHostName() });
            return null;
        }

        /// <summary>
        /// Send an "I'm online" message
        /// </summary>
        public static void SayOnline()
        {
            mqttService.SendMessage(new Message() { Action = "online", Recipient = "0.0.0.0", Sender = System.Net.Dns.GetHostName() });
        }

        /// <summary>
        /// Ask for the catalog of a specific mediatheque
        /// </summary>
        /// <param name="name">The name/ip of the mediatheque</param>
        /// <returns>A list of songs</returns>
        public static List<ISong> AskCatalog(string name) { return null; }

        /// <summary>
        /// Send our catalog to a specific mediatheque
        /// </summary>
        /// <param name="name">The name/ip of the mediatheque</param>
        public static void SendCatalog(string name)
        {
            mqttService.SendMessage(new Message() { Action = "sendCatalog", Recipient = name, Sender = System.Net.Dns.GetHostName(), SongList = Program.songs });
        }

        /// <summary>
        /// Download the media from a mediatheque
        /// </summary>
        /// <param name="song">The song to download</param>
        /// <param name="startByte">The first byte you need</param>
        /// <param name="endByte">The last byte you need</param>
        /// <param name="name">The name/ip of the mediatheque</param>
        public static void AskMedia(ISong song, string name, int startByte, int endByte) { }

        /// <summary>
        /// Send the media to someone
        /// </summary>
        /// <param name="song">The song to send</param>
        /// <param name="startByte">The first byte they need</param>
        /// <param name="endByte">The last byte they need</param>
        /// <param name="name">The name/ip of the mediatheque</param>
        public static void SendMedia(ISong song, string name, int startByte, int endByte) { }
    }
}

using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BitRuisseau
{
    public static class Protocol
    {
        //The service used to send messages
        private static MqttService mqttService = new MqttService();

        /// <summary>
        /// Get the list of all online mediatheque
        /// </summary>
        /// <returns>An array of mediatheque name/ip</returns>
        public async static Task GetOnlineMediatheque()
        {
            await mqttService.SendMessage(new Message() { Action = "askOnline", Recipient = "0.0.0.0", Sender = System.Net.Dns.GetHostName() });
        }

        /// <summary>
        /// Send an "I'm online" message
        /// </summary>
        public async static void SayOnline()
        {
            await mqttService.SendMessage(new Message() { Action = "online", Recipient = "0.0.0.0", Sender = System.Net.Dns.GetHostName() });
        }

        /// <summary>
        /// Ask for the catalog of a specific mediatheque
        /// </summary>
        /// <param name="name">The name/ip of the mediatheque</param>
        /// <returns>A list of songs</returns>
        public async static void AskCatalog(string name)
        {
            await mqttService.SendMessage(new Message() { Action = "sendCatalog", Recipient = name, Sender = System.Net.Dns.GetHostName(), SongList = Program.songs });
        }

        /// <summary>
        /// Send our catalog to a specific mediatheque
        /// </summary>
        /// <param name="name">The name/ip of the mediatheque</param>
        public async static void SendCatalog(string name)
        {
            await mqttService.SendMessage(new Message() { Action = "sendCatalog", Recipient = name, Sender = System.Net.Dns.GetHostName(), SongList = Program.songs });
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
        /// <param name="hash">The hash of the song to send</param>
        /// <param name="startByte">The first byte they need</param>
        /// <param name="endByte">The last byte they need</param>
        /// <param name="name">The name/ip of the mediatheque</param>
        public async static void SendMedia(string hash, string name, int startByte, int endByte)
        {
            byte[] bytes = File.ReadAllBytes(Program.songs.Where(s => s.Hash == hash).First().Path);
            string b64 = Convert.ToBase64String(bytes.Skip(startByte).Take(endByte - startByte).ToArray());
            Trace.WriteLine(b64);

            bytes = null; //Free memory doesnt seem to work https://stackoverflow.com/questions/20859373/clear-array-after-is-used-c-sharp

            await mqttService.SendMessage(new Message { Action = "sendMedia", Sender = System.Net.Dns.GetHostName(), Recipient = name, EndByte = endByte, StartByte = startByte, Hash = hash, SongData = b64 });
        }
    }
}

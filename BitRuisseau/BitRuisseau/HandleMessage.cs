using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BitRuisseau
{
    public static class HandleMessage
    {
        public static void Handle(Message message)
        {
            if (message.Recipient == "0.0.0.0" || message.Recipient == System.Net.Dns.GetHostName())
            {
                switch (message.Action)
                {
                    case "online":
                        if (!Program.mediathequeSongs.ContainsKey(message.Sender))
                        {
                            Program.mediathequeSongs.Add(message.Sender, new List<Song>());
                        }
                        break;

                    case "askOnline":
                        Protocol.SayOnline();
                        break;

                    case "askCatalog":
                        Protocol.SendCatalog(message.Sender);
                        break;

                    case "sendCatalog":
                        if (!Program.mediathequeSongs.ContainsKey(message.Sender))
                        {
                            Program.mediathequeSongs.Add(message.Sender, message.SongList);
                        }
                        else
                        {
                            Program.mediathequeSongs[message.Sender] = message.SongList;
                        }
                        break;

                    case "askMedia":
                        Protocol.SendMedia(message.Hash, message.Sender, int.Parse(message.StartByte.ToString()), int.Parse(message.EndByte.ToString()));
                        break;

                    default:
                        Trace.WriteLine($"Invalid message received at {DateTime.Now}: {JsonSerializer.Serialize(message)}");
                        break;
                }
            }
        }
    }
}

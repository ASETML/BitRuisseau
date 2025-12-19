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
                        if (message.Recipient == System.Net.Dns.GetHostName())
                        {
                            Protocol.SendMedia(message.Hash, message.Sender, int.Parse(message.StartByte.ToString()), int.Parse(message.EndByte.ToString()));
                        }

                        break;

                    case "sendMedia":
                        if (message.Recipient == System.Net.Dns.GetHostName())
                        {
                            List<Song> temp = Program.mediathequeSongs.Where(m => m.Key == message.Sender).First().Value;
                            Song s = temp.Where(s => s.Hash == message.Hash.ToUpper()).First();

                            string extension = s.Extension;
                            if (extension.StartsWith('.'))
                            {
                                extension.Remove(0, 1);
                            }

                            //Save to tmp
                            if (!Path.Exists(File.ReadAllText(Config.LASTUSEDPATHFILE) + @"\tmp-bitruisseau"))
                            {
                                Directory.CreateDirectory(File.ReadAllText(Config.LASTUSEDPATHFILE) + @"\tmp-bitruisseau");
                            }
                            File.Create(File.ReadAllText(Config.LASTUSEDPATHFILE) + @$"\tmp-bitruisseau\{message.Hash}").Close();
                            byte[] decodedBytes = Convert.FromBase64String(message.SongData);
                            FileStream fileStream = File.OpenWrite(File.ReadAllText(Config.LASTUSEDPATHFILE) + @$"\tmp-bitruisseau\{message.Hash}.{extension}");
                            fileStream.Write(decodedBytes, (int)message.StartByte, (int)message.EndByte - (int)message.StartByte);
                            fileStream.Close();

                            //Get song info

                            Song song = new Song(File.ReadAllText(Config.LASTUSEDPATHFILE) + @$"\tmp-bitruisseau\{message.Hash}.{extension}");
                            Program.songs.Add(song);

                            File.Move(File.ReadAllText(Config.LASTUSEDPATHFILE) + @$"\tmp-bitruisseau\{message.Hash}.{extension}", File.ReadAllText(Config.LASTUSEDPATHFILE) + @$"\{s.Title}.{extension}");

                            //Move when done
                        }
                        break;

                    default:
                        Trace.WriteLine($"Invalid message received at {DateTime.Now}: {JsonSerializer.Serialize(message)}");
                        break;
                }
            }
        }
    }
}

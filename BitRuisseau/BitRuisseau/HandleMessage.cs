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
    /// <summary>
    /// Dispatch the messages depending on they type
    /// </summary>
    public static class HandleMessage
    {
        /// <summary>
        /// Dispatch a message depending on its type
        /// </summary>
        /// <param name="message">The message to dispatch</param>
        public static void Handle(Message message)
        {
            //Only dispatch the messages that are for everyone or ourself
            if (message.Recipient == "0.0.0.0" || message.Recipient == System.Net.Dns.GetHostName())
            {
                switch (message.Action)
                {
                    //Add the mediatheque to the know list
                    case "online":
                        if (!Program.mediathequeSongs.ContainsKey(message.Sender))
                        {
                            Program.mediathequeSongs.Add(message.Sender, new List<Song>());
                        }
                        break;

                    //Answer the question
                    case "askOnline":
                        Protocol.SayOnline();
                        break;

                    //Send our catalog
                    case "askCatalog":
                        Protocol.SendCatalog(message.Sender);
                        break;

                    //Store the catalog of another mediatheque
                    case "sendCatalog":
                        if (!Program.mediathequeSongs.ContainsKey(message.Sender))
                        {
                            Program.mediathequeSongs.Add(message.Sender, message.SongList);
                        }
                        Program.mediathequeSongs[message.Sender] = message.SongList;
                        break;

                    //Send the asked song
                    case "askMedia":
                        if (message.Recipient == System.Net.Dns.GetHostName())
                        {
                            Protocol.SendMedia(message.Hash, message.Sender, int.Parse(message.StartByte.ToString()), int.Parse(message.EndByte.ToString()));
                        }

                        break;

                    //Download the song we asked
                    case "sendMedia":
                        //Get the song extension
                        List<Song> temp = Program.mediathequeSongs.Where(m => m.Key == message.Sender).First().Value;
                        Song s = temp.Where(s => s.Hash == message.Hash.ToUpper()).First();
                        string extension = s.Extension;

                        if (extension.StartsWith('.'))
                        {
                            extension.Remove(0, 1);
                        }

                        //Save to tmp
                        //Create directory if not exists
                        if (!Path.Exists(File.ReadAllText(Config.LASTUSEDPATHFILE) + @"\tmp-bitruisseau"))
                        {
                            Directory.CreateDirectory(File.ReadAllText(Config.LASTUSEDPATHFILE) + @"\tmp-bitruisseau");
                        }

                        //Decode song data
                        byte[] decodedBytes = Convert.FromBase64String(message.SongData);

                        //Open and create the file
                        FileStream fileStream = File.OpenWrite(File.ReadAllText(Config.LASTUSEDPATHFILE) + @$"\tmp-bitruisseau\{message.Hash}.{extension}");

                        //Write the data to file
                        fileStream.Write(decodedBytes, (int)message.StartByte, (int)message.EndByte - (int)message.StartByte);
                        fileStream.Close();

                        //Store song in our song list
                        Song song = new Song(File.ReadAllText(Config.LASTUSEDPATHFILE) + @$"\tmp-bitruisseau\{message.Hash}.{extension}");
                        Program.songs.Add(song);

                        //Move when done
                        File.Move(File.ReadAllText(Config.LASTUSEDPATHFILE) + @$"\tmp-bitruisseau\{message.Hash}.{extension}", File.ReadAllText(Config.LASTUSEDPATHFILE) + @$"\{s.Title}.{extension}");

                        //Remove temp file
                        File.Delete(File.ReadAllText(Config.LASTUSEDPATHFILE) + @$"\tmp-bitruisseau\{message.Hash}");
                        break;

                    default:
                        Trace.WriteLine($"Invalid message received at {DateTime.Now}: {JsonSerializer.Serialize(message)}");
                        break;
                }
            }
        }
    }
}

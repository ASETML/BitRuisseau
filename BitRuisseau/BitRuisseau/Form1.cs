using System.Diagnostics;
using System.Text.Json;
using TagLib.IFD.Tags;

namespace BitRuisseau
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            File.WriteAllText("txt.txt", JsonSerializer.Serialize(new Message { Action = "online", Recipient = "0.0.0.0", Sender = "ME" }));

            Song s = new Song("song.mp3");
            Trace.WriteLine(s.Hash);
            Trace.WriteLine(JsonSerializer.Serialize(s));
            new MqttService();
        }
    }
}

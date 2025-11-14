using System.Text.Json;

namespace BitRuisseau
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            File.WriteAllText("txt.txt", JsonSerializer.Serialize(new Message { Action = "online", Recipient = "0.0.0.0", Sender = "ME" }));
        }
    }
}

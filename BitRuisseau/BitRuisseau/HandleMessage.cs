using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
                        Trace.WriteLine(message.Sender + " isonline");
                        break;

                    case "askOnline":
                        Protocol.SayOnline();
                        break;

                    case "askCatalog":
                        Protocol.SendCatalog(message.Sender);
                        break;
                }
            }
        }
    }
}

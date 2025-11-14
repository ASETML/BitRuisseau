using HiveMQtt.Client;
using HiveMQtt.Client.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BitRuisseau
{
    public class MqttService
    {
        HiveMQClientOptions options = new HiveMQClientOptions();
        HiveMQClient client;

        public MqttService()
        {
            AppSettingsReader env = new AppSettingsReader();

            options.UserName = env.GetValue("username", typeof(string)).ToString();
            SecureString pwd = new SecureString();
            env.GetValue("password", typeof(string)).ToString().ToList().ForEach(c => pwd.AppendChar(c));
            options.Password = pwd;
            options.Host = env.GetValue("host", typeof(string)).ToString();
            client = new HiveMQClient(options);
            Connect();
            SendMessage(new Message { Action = "online", Recipient = "0.0.0.0", Sender = "ME" });
        }

        public async void Connect()
        {
            await client.ConnectAsync().ConfigureAwait(false);
        }

        public async void SendMessage(Message msg)
        {
            await client.PublishAsync("BitRuisseau", JsonSerializer.Serialize(msg)).ConfigureAwait(false);
        }
    }
}

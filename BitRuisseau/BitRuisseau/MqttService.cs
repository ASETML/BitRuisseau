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
        }

        public async void Connect()
        {
            await client.ConnectAsync().ConfigureAwait(false);
            client.OnMessageReceived += (sender, args) =>
            {
                try {
                    HandleMessage.Handle(JsonSerializer.Deserialize<Message>(args.PublishMessage.PayloadAsString));
                    Trace.WriteLine("Message Received: {} " + args.PublishMessage.PayloadAsString);
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e);
                }
                
            };
            client.SubscribeAsync(Config.TOPIC).ConfigureAwait(false);
        }

        public async void SendMessage(Message msg)
        {
            await client.PublishAsync(Config.TOPIC, JsonSerializer.Serialize(msg)).ConfigureAwait(false);
        }
    }
}

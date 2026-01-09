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
    /// <summary>
    /// The service used to connect to the broker
    /// </summary>
    public class MqttService
    {
        HiveMQClientOptions options = new HiveMQClientOptions();
        HiveMQClient client;

        public MqttService()
        {
            //Set the connection options from the app.config
            AppSettingsReader env = new AppSettingsReader();

            options.UserName = env.GetValue("username", typeof(string)).ToString();
            SecureString pwd = new SecureString();
            env.GetValue("password", typeof(string)).ToString().ToList().ForEach(c => pwd.AppendChar(c));
            options.Password = pwd;
            options.Host = env.GetValue("host", typeof(string)).ToString();

            //Connect to the broker
            client = new HiveMQClient(options);
            Connect();
        }

        /// <summary>
        /// Connect to the broker, set the function executed when a message is received and listen to the topic
        /// </summary>
        public async void Connect()
        {
            await client.ConnectAsync().ConfigureAwait(false);
            client.OnMessageReceived += (sender, args) =>
            {
                try {
                    HandleMessage.Handle(JsonSerializer.Deserialize<Message>(args.PublishMessage.PayloadAsString));
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e);
                }
                
            };
            client.SubscribeAsync(Config.TOPIC).ConfigureAwait(false);
        }

        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="msg">The message to send</param>
        /// <returns></returns>
        public async Task SendMessage(Message msg)
        {
            await client.PublishAsync(Config.TOPIC, JsonSerializer.Serialize(msg)).ConfigureAwait(false);
        }
    }
}

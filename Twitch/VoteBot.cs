using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Client;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace ViewerInteractivity.Twitch
{
    public class VoteBot
    {
        public TwitchClient client;

        string _channelName;

        public event TwitchChatEventHandler OnChatCommand = delegate { };
        public delegate void TwitchChatEventHandler(string user, string cmd, string[] args);

        public VoteBot(string channelName, string UserLoginName, string AuthToken)
        {
            _channelName = channelName;
            var recon = new ReconnectionPolicy(1, 3, 9999);

            ConnectionCredentials credentials = new ConnectionCredentials(UserLoginName, AuthToken);
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 1500,
                ThrottlingPeriod = TimeSpan.FromSeconds(30),
                ReconnectionPolicy = recon
            };

            WebSocketClient customClient = new WebSocketClient(clientOptions);
            client = new TwitchClient(customClient);
            client.Initialize(credentials, channelName, '#', '#', true);
            
            client.OnLog += Client_OnLog;
            client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnWhisperReceived += Client_OnWhisperReceived;
            client.OnNewSubscriber += Client_OnNewSubscriber;
            client.OnConnected += Client_OnConnected;
            client.OnChatCommandReceived += Client_OnChatCommandReceived;
            client.OnReconnected += Client_OnReconnected;

            client.Connect();
        }

        public void SendChatMessage(string message)
        {
            try
            {
                client.SendMessage(_channelName, message);
            }
            catch { }
        }

        private void Client_OnReconnected(object sender, TwitchLib.Communication.Events.OnReconnectedEventArgs e)
        {
            try
            {
                client.SendMessage(_channelName, "[DRG] Twitch Integration reconnected!");
            }
            catch { }
        }

        public void Stop()
        {
            client.Disconnect();
            client = null;
        }

        private void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            if (OnChatCommand != null)
                OnChatCommand(e.Command.ChatMessage.Username, e.Command.CommandText, e.Command.ArgumentsAsList.ToArray());
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
           
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            try
            {
                client.SendMessage(e.Channel, "[DRG] Twitch Integration is connected!");
            }
            catch { }
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
        }

        private void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
        }

        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
        }
    }
}
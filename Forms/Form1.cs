using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using TwitchIntegration.API;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;
using ViewerInteractivity.Twitch;
using ViewerInteractivity.Settings;

namespace ViewerInteractivity
{
    public partial class Form1 : Form
    {
        const string RedirectURL = @"https://twitchapps.com/tokengen/";
        const string ClientID = ""; // SECRET <- I REMOVED IT FOR SECURITY.
        const string ChatBufferFilename = @"TwitchMod\ChatBuffer.txt";
        const string EventBufferFilename = @"TwitchMod\EventBuffer.txt";
        public string UserLoginName { get; set; }
        public string AuthToken { get; set; }
        public string ChannelID { get; set; }

        public string ModsDirectory { get; set; }
        
        private List<string> channelEvents;
        private List<string> chatCommands;

        private System.Windows.Forms.Timer bufferTimer;

        private VoteBot voteBot2;

        public static TwitchPubSub PubSub;

        private bool UserPressedDisconnected = false;

        public Form1()
        {
            AuthToken = string.Empty;
            UserLoginName = string.Empty;
            ModsDirectory = @"C:\Program Files (x86)\Steam\steamapps\common\Deep Rock Galactic\FSD\Mods\";
            channelEvents = new List<string>();
            chatCommands = new List<string>();

            InitializeComponent();
        }

        private void Form1_LoadAsync(object sender, EventArgs e)
        {
            LoadUserSettings();

            bufferTimer = new System.Windows.Forms.Timer();
            bufferTimer.Interval = 1000;
            bufferTimer.Tick += bufferTimer_Tick;
            bufferTimer.Start();
        }

        private async void startBotButton_Click(object sender, EventArgs e)
        {
            UserPressedDisconnected = true;

            if (voteBot2 != null)
            {
                voteBot2.Stop();
                voteBot2 = null;
            }
            
            if (PubSub != null)
            {
                try
                {
                    PubSub.Disconnect();
                    PubSub = null;
                }
                catch { }
            }

            if (authTokenTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"Please enter an Authentication Token.", @"Authentication Token");
                return;
            }

            //Get twitch user
            AuthToken = authTokenTextBox.Text.Trim();
            TwitchUser tUser = TwitchHelpers.GetTwitchUser(ClientID, AuthToken);

            if (tUser == null)
            {
                MessageBox.Show(@"Invalid authentication token.", @"Authentication Token");
                return;
            }

            ChannelID = tUser.id;
            UserLoginName = tUser.login;

            SaveUserSettings();

            //Start VoteBot
            voteBot2 = new VoteBot(UserLoginName, UserLoginName, AuthToken);
            voteBot2.OnChatCommand += VoteBot2_OnChatCommand;

            //Set up twitchlib pubsub
            PubSub = new TwitchPubSub();
            PubSub.OnListenResponse += OnListenResponse;
            PubSub.OnPubSubServiceConnected += OnPubSubServiceConnected;
            PubSub.OnPubSubServiceClosed += OnPubSubServiceClosed;
            PubSub.OnPubSubServiceError += OnPubSubServiceError;

            //setup topics
            PubSub.ListenToChannelPoints(ChannelID);
            PubSub.ListenToSubscriptions(ChannelID);
            PubSub.ListenToBitsEventsV2(ChannelID);
            PubSub.ListenToFollows(ChannelID);

            PubSub.OnChannelPointsRewardRedeemed += PubSub_OnChannelPointsRewardRedeemed;
            PubSub.OnChannelSubscription += PubSub_OnChannelSubscription;
            PubSub.OnBitsReceivedV2 += PubSub_OnBitsReceivedV2;
            PubSub.OnFollow += PubSub_OnFollow;
            PubSub.Connect();
        }

        private void stopBotButton_Click(object sender, EventArgs e)
        {
            UserPressedDisconnected = true;

            if (voteBot2 != null)
            {
                voteBot2.Stop();
                voteBot2 = null;
            }

            if (PubSub != null)
            {
                try
                {
                    PubSub.Disconnect();
                    PubSub = null;
                }
                catch { }
            }

            chatCommands.Clear();
            channelEvents.Clear();

            SetStatus("Not Connected");
            UpdateQueue();
        }

        // PubSub Service Events -

        private void OnPubSubServiceError(object sender, OnPubSubServiceErrorArgs e)
        {
            if (UserPressedDisconnected is false)
            {
                //Try reconnect
                startBotButton_Click(sender, e);
            }
        }

        private void OnPubSubServiceClosed(object sender, EventArgs e)
        {
            if (UserPressedDisconnected is false)
            {
                //Try reconnect
                startBotButton_Click(sender, e);
            }
        }

        private void OnPubSubServiceConnected(object sender, EventArgs e)
        {
            UserPressedDisconnected = false;

            PubSub.SendTopics(AuthToken);
            SetStatus("Connected!");
        }

        private void OnListenResponse(object sender, OnListenResponseArgs e)
        {
            if (!e.Successful)
            {
                
            }
        }

        // Channel Events -

        private void PubSub_OnChannelSubscription(object sender, OnChannelSubscriptionArgs e)
        {
            string plan = e.Subscription.SubscriptionPlanName ?? "";
            //Enum.GetName(typeof(TwitchLib.PubSub.Enums.SubscriptionPlan), e.Subscription.SubscriptionPlan) ?? "";
            bool isGift = e.Subscription.IsGift ?? false;

            string subMessage = e.Subscription.SubMessage.Message ?? "";
            string months = (e.Subscription.CumulativeMonths ?? 0).ToString() ?? "0";
            string username = e.Subscription.DisplayName ?? "";
            string recipient = e.Subscription.RecipientDisplayName ?? "";

            bool isAnon = string.IsNullOrEmpty(username) ? true : false;

            string context = e.Subscription.Context ?? "resub";

            switch (context)
            {
                case "sub": AddChannelEvent("sub", username, subMessage, plan, months, "", ""); break;
                case "resub": AddChannelEvent("sub", username, subMessage, plan, months, "", ""); break;
                case "subgift": AddChannelEvent("giftsub", recipient, subMessage, plan, months, "", ""); break;
                case "anonsubgift": AddChannelEvent("giftsub", recipient, subMessage, plan, months, "", ""); break;
                case "resubgift": AddChannelEvent("giftsub", recipient, subMessage, plan, months, "", ""); break;
                case "anonresubgift": AddChannelEvent("giftsub", recipient, subMessage, plan, months, "", ""); break;
                default: break;
            }
        
            UpdateQueue();
        }

        private void PubSub_OnChannelPointsRewardRedeemed(object sender, OnChannelPointsRewardRedeemedArgs e)
        {
            var redemption = e.RewardRedeemed.Redemption;
            var reward = e.RewardRedeemed.Redemption.Reward.Title;
            var redeemedUser = e.RewardRedeemed.Redemption.User.DisplayName;
            var userPrompt = e.RewardRedeemed.Redemption.UserInput;
            var cost = e.RewardRedeemed.Redemption.Reward.Cost.ToString();
            var cooldown = e.RewardRedeemed.Redemption.Reward.GlobalCooldown.GlobalCooldownSeconds.ToString();
            
            AddChannelEvent("reward", 
                redeemedUser ?? "", 
                userPrompt ?? "",
                reward ?? "", 
                cost ?? "0",
                cooldown ?? "0",
                "");
        }

        private void PubSub_OnBitsReceivedV2(object sender, OnBitsReceivedV2Args e)
        {
            if (e.IsAnonymous)
            {
                AddChannelEvent(
                    "bitscheer",
                    "Anonymous",
                    e.ChatMessage ?? "",
                    e.IsAnonymous.ToString(),
                    e.BitsUsed.ToString() ?? "1",
                    "",
                    "");
            }
            else
            {
                AddChannelEvent(
                    "bitscheer", 
                    e.UserName ?? "Anonymous", 
                    e.ChatMessage ?? "",
                    e.IsAnonymous.ToString(),
                    e.BitsUsed.ToString() ?? "1",
                    "",
                    "");
            }
        }

        private void PubSub_OnFollow(object sender, OnFollowArgs e)
        {
            AddChannelEvent("follow", e.DisplayName ?? "Anonymous", "", "", "", "", "");
        }

        // Channel Commands -

        private void VoteBot2_OnChatCommand(string user, string cmd, string[] args)
        {
            if (string.IsNullOrEmpty(cmd))
                return;

            AddChatCommand(user, cmd, args);

            UpdateQueue();
        }

        // App -

        private void browseDirButton_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.Description = @"Choose DRG mods directory... \steamapps\common\Deep Rock Galactic\FSD\Mods\";
            dialog.RootFolder = Environment.SpecialFolder.MyComputer;
            dialog.SelectedPath = ModsDirectory;
            dialog.ShowNewFolderButton = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(dialog.SelectedPath) is false) return;

                ModsDirectory = dialog.SelectedPath;

                modsDirTextBox.Text = ModsDirectory;

                SaveUserSettings();
            }
        }

        private void clearQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chatCommands.Clear();
            channelEvents.Clear();
            UpdateQueue();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                $@"Twitch Integration mod and application developed by GoldBl4d3. Visit the DRG Modding discord for more information.",
                @"About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"https://id.twitch.tv/oauth2/authorize?response_type=token&client_id={ClientID}" +
                $"&redirect_uri={RedirectURL}&scope=chat%3Aread%20chat%3Aedit%20bits%3Aread%20channel%3Aread%3Aredemptions%20channel%3Aread%3Asubscriptions");
        }

        private void WriteChatBuffer()
        {
            try
            {
                string filepath = GetChatBufferFilePath();

                // Check for valid filepath
                if (!File.Exists(filepath)) return;

                // If buffer is not empty, return
                if (!string.IsNullOrWhiteSpace(File.ReadAllText(filepath))) return;

                // Return if no commands are queued
                if (chatCommands.Count == 0) return;

                string buff = string.Join(",", chatCommands.ToArray());

                // Write to buffer file
                File.WriteAllText(filepath, buff);

                // Clear commands
                chatCommands.Clear();

                UpdateQueue();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        
        private void WriteEventBuffer()
        {

            try
            {
                string eventFilePath = GetEventBufferFilePath();

                if (!File.Exists(eventFilePath)) return;

                if (!string.IsNullOrWhiteSpace(File.ReadAllText(eventFilePath))) return;

                if (channelEvents.Count == 0) return;

                string buff = string.Join(",", channelEvents.ToArray());
                // Write to buffer file
                File.WriteAllText(eventFilePath, buff);

                // Clear viewer votes
                channelEvents.Clear();

                UpdateQueue();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void bufferTimer_Tick(object sender, EventArgs e)
        {
            WriteChatBuffer();
            WriteEventBuffer();

        }

        public string GetChatBufferFilePath()
        {
            return Path.Combine(ModsDirectory, ChatBufferFilename);
        }
        
        public string GetEventBufferFilePath()
        {
            return Path.Combine(ModsDirectory, EventBufferFilename);
        }

        public void SetStatus(string status)
        {
            toolStripStatusLabel1.Text = @"Status: " + status;
        }

        public void UpdateQueue()
        {
            toolStripStatusLabel2.Text = $@"Queue: {chatCommands.Count + channelEvents.Count}";
        }

        public void LoadUserSettings()
        {
            try
            {
                string jsonString = File.ReadAllText(
                    Path.Combine(Application.StartupPath, "UserSettings.json"));

                var usersettings = JsonConvert.DeserializeObject<AppUserSettings>(jsonString);

                AuthToken = usersettings.AuthToken;
                ModsDirectory = usersettings.ModsDirectory;

                authTokenTextBox.Text = AuthToken;
                modsDirTextBox.Text = ModsDirectory;
            }
            catch
            {
            }
        }

        public bool SaveUserSettings()
        {
            try
            {
                AuthToken = authTokenTextBox.Text.Trim();
                ModsDirectory = modsDirTextBox.Text.Trim();

                var usersettings = new AppUserSettings()
                {
                    AuthToken = AuthToken,
                    ModsDirectory = ModsDirectory
                };

                string jsonString = JsonConvert.SerializeObject(usersettings);

                File.WriteAllText(
                    Path.Combine(Application.StartupPath, "UserSettings.json"),
                    jsonString);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void AddChatCommand(string username, string command, params string[] args)
        {
            chatCommands.Add(string.Join("|",
                (username == string.Empty ? "" : username).Replace(",", "").Replace("~", "").Replace("|", ""),
                (command == string.Empty ? "" : command).Replace(",", "").Replace("~", "").Replace("|", ""),
                string.Join("|", args)));

            UpdateQueue();
        }

        public void AddChannelEvent(string eventType, string username, string usermsg, string arg1, string arg2, string arg3, string arg4)
        {
            channelEvents.Add(string.Join("|", 
                eventType == string.Empty ? "" : eventType, 
                (username == string.Empty ? "" : username).Replace(",", "").Replace("~", "").Replace("|", ""),
                (usermsg == string.Empty ? "" : usermsg).Replace(",","").Replace("~", "").Replace("|", ""),
                arg1 == string.Empty ? "0" : arg1,
                arg2 == string.Empty ? "0" : arg2,
                arg3 == string.Empty ? "0" : arg3,
                arg4 == string.Empty ? "0" : arg4));

            UpdateQueue();
        }

        private void voteAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddChatCommand("Karl", "a");
        }

        private void voteBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddChatCommand("Karl", "b");
        }

        private void rewardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddChannelEvent("reward", "Karl", "", "Test", "150", "0", "");
        }

        private void cheerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddChannelEvent("bitscheer", "Karl", "", "false", "89", "", "");
        }
       
        private void cheeranonymousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddChannelEvent("bitscheer", "Anonymous", "", "true", "89", "", "");
        }

        private void subscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddChannelEvent("sub", "Karl", "", "1000", "4", "", "");
        }

        private void giftSubscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddChannelEvent("giftsub", "Karl", "", "1000", "4", "", "");
        }
    }
}

namespace TwitchIntegration.API
{
    public class TwitchUserDatum
    {
        public List<TwitchUser> data { get; set; }
    }

    public class TwitchUser
    {
        public string id { get; set; }
        public string login { get; set; }
        public string display_name { get; set; }
        public string type { get; set; }
        public string broadcaster_type { get; set; }
        public string description { get; set; }
        public string profile_image_url { get; set; }
        public string offline_image_url { get; set; }
        public int view_count { get; set; }
        public DateTime created_at { get; set; }
    }

    public class ChannelSearchResult
    {
        public string broadcaster_language { get; set; }
        public string broadcaster_login { get; set; }
        public string display_name { get; set; }
        public string game_id { get; set; }
        public string game_name { get; set; }
        public string id { get; set; }
        public bool is_live { get; set; }
        public List<object> tag_ids { get; set; }
        public string thumbnail_url { get; set; }
        public string title { get; set; }
        public string started_at { get; set; }
    }

    public class ChannelSearchPagination
    {
        public string cursor { get; set; }
    }

    public class ChannelSearchDatum
    {
        public List<ChannelSearchResult> data { get; set; }
        public ChannelSearchPagination pagination { get; set; }
    }

    public static class TwitchHelpers
    {
        public static TwitchUser GetTwitchUser(string clientID, string oauth)
        {
            try
            {
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest
                .Create($"https://api.twitch.tv/helix/users");
                webrequest.Method = "GET";
                webrequest.ContentType = "application/x-www-form-urlencoded";
                webrequest.Headers.Add("Authorization", $"Bearer {oauth}");
                webrequest.Headers.Add("Client-Id", clientID);
                HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
                string result = string.Empty;
                result = responseStream.ReadToEnd();
                webresponse.Close();

                TwitchUserDatum myDeserializedClass = JsonConvert.DeserializeObject<TwitchUserDatum>(result);

                return myDeserializedClass.data.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static ChannelSearchResult[] SearchForChannels(string username, string clientID, string oauth)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest
                .Create($"https://api.twitch.tv/helix/search/channels?query={username}");
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            webrequest.Headers.Add("Authorization", $"Bearer {oauth}");
            webrequest.Headers.Add("Client-Id", clientID);
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();


            ChannelSearchDatum myDeserializedClass = JsonConvert
                .DeserializeObject<ChannelSearchDatum>(result);

            if (myDeserializedClass != null)
            {
                return myDeserializedClass.data.ToArray();
            }
            else return new ChannelSearchResult[0];

        }
    
    
    }

}
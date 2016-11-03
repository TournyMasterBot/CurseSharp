using CurseSharp.UI.Commands.BanPhrases;
using CurseSharp.UI.FormControls;
using CurseSharp.UI.Service;
using System;
using System.Windows.Forms;
using System.Timers;
using CurseSharp.CurseClient.Models;
using CurseSharp.CurseClient.Sessions;
using System.Drawing;
using System.IO;
using CurseSharp.CurseClient.Models.BotModels;
using Newtonsoft.Json;
using System.Text;
using CurseSharp.CurseClient.Endpoints;
using System.Linq;

namespace CurseSharp.UI
{
    public partial class Main : Form
    {
        private static string userLoginPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\CurseSharp\Save\UserLogin.ini";
        private static string botStatsPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\CurseSharp\Save\BotStats.ini";
        private static string saveDirectory = Path.GetDirectoryName(userLoginPath);
        private static System.Timers.Timer UpdateConnectionStatusTimer;
        private static BanPhraseSimpleControl banPhraseManager;
        private static string previousState = string.Empty;
        private static bool saveLoginDetails = false;

        public Main()
        {
            InitializeBotSettings();
            banPhraseManager = new BanPhraseSimpleControl();
            InitializeComponent();
            LoadUserLoginData();
            UpdateConnectionStatusTimer = new System.Timers.Timer(3000);
            UpdateConnectionStatusTimer.Elapsed += UpdateConnectionStatusLabel;
            UpdateConnectionStatusTimer.Start();

            PasswordText.PasswordChar = '*';

            ContentSplitContainer.Panel2.Controls.Add(banPhraseManager);
        }

        private void UpdateConnectionStatusLabel(object sender, ElapsedEventArgs e)
        {
            if(ConnectionStatusText.InvokeRequired)
            {
                ConnectionStatusText.Invoke(new Action(() =>
                {
                    var currentState = GetConnectionStatus();

                    if(currentState != previousState)
                    {
                        ConnectionStatusText.Text = currentState;
                        if(ConnectionStatusText.Text == "Connected")
                        {
                            ConnectionStatusText.ForeColor = Color.Green;
                            ConnectButton.Text = "Reconnect";
                            RefreshRolesButton.Enabled = true;
                        }
                        else if(ConnectionStatusText.Text == "Disconnected")
                        {
                            ConnectionStatusText.ForeColor = Color.Red;
                            ConnectButton.Text = "Connect";
                            RefreshRolesButton.Enabled = false;
                        }
                    }
                }));
            }
            else
            {
                var currentState = GetConnectionStatus();
                if(currentState != previousState)
                {
                    ConnectionStatusText.Text = currentState;
                    if(ConnectionStatusText.Text == "Connected")
                    {
                        ConnectionStatusText.ForeColor = Color.Green;
                        ConnectButton.Text = "Reconnect";
                        RefreshRolesButton.Enabled = true;
                    }
                    else if(ConnectionStatusText.Text == "Disconnected")
                    {
                        ConnectionStatusText.ForeColor = Color.Red;
                        ConnectButton.Text = "Connect";
                        RefreshRolesButton.Enabled = false;
                    }
                }
                
            }

            try
            {
                UpdateBotStats();
            }
            catch(Exception ex)
            {
                Logging.Log.Error(ex.ToString());
            }
        }

        private string GetConnectionStatus()
        {
            return Enum.GetName(typeof(BotConnectionStatus), SessionState.ConnectionStatus);
        }

        private void InitializeBotSettings()
        {
            BanPhraseManager.LoadBanPhrases();
        }

        private void LoadUserLoginData()
        {
            try
            {
                // Load User Login Data
                if(Directory.Exists(saveDirectory) && File.Exists(userLoginPath))
                {
                    using(var filestream = new FileStream(userLoginPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using(var reader = new StreamReader(filestream, Encoding.UTF8))
                        {
                            var data = reader.ReadToEnd();

                            try
                            {
                                var userLogin = JsonConvert.DeserializeObject<UserLoginModel>(data);
                                if(!string.IsNullOrWhiteSpace(userLogin.Username))
                                {
                                    if(UsernameText.InvokeRequired)
                                    {
                                        UsernameText.Invoke(new Action(() => { UsernameText.Text = userLogin.Username; }));
                                    }
                                    else
                                    {
                                        UsernameText.Text = userLogin.Username;
                                    }
                                    SaveLoginDetailsCheckbox.Checked = true;
                                }

                                if(!string.IsNullOrWhiteSpace(userLogin.Password))
                                {
                                    if(PasswordText.InvokeRequired)
                                    {
                                        PasswordText.Invoke(new Action(() => { PasswordText.Text = userLogin.Password; }));
                                    }
                                    else
                                    {
                                        PasswordText.Text = userLogin.Password;
                                    }
                                }
                            }
                            catch(Exception)
                            {
                                // Nomnom, invalid data
                            }
                        }
                    }
                }

                // Load Bot Stats
                if(Directory.Exists(saveDirectory) && File.Exists(botStatsPath))
                {
                    using(var filestream = new FileStream(botStatsPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using(var reader = new StreamReader(filestream, Encoding.UTF8))
                        {
                            var data = reader.ReadToEnd();

                            try
                            {
                                var botStats = JsonConvert.DeserializeObject<BotStatisticsModel>(data);
                                if(botStats != null)
                                {
                                    SessionState.BotStats = botStats;
                                }
                            }
                            catch(Exception)
                            {
                                SessionState.BotStats = new BotStatisticsModel();
                            }
                        }
                    }
                }
                else
                {
                    SessionState.BotStats = new BotStatisticsModel();
                }

                UpdateBotStats();
            }
            catch(Exception ex)
            {
                Logging.Log.Error(ex.ToString());
            }
        }

        private void UpdateBotStats()
        {
            if(EditText.InvokeRequired)
            {
                EditText.Invoke(new Action(() => { EditText.Text = SessionState.BotStats.MessagesEdited.ToString(); }));
            }
            else
            {
                EditText.Text = SessionState.BotStats.MessagesEdited.ToString();
            }

            if(DeletedText.InvokeRequired)
            {
                DeletedText.Invoke(new Action(() => { DeletedText.Text = SessionState.BotStats.MessagesDeleted.ToString(); }));
            }
            else
            {
                DeletedText.Text = SessionState.BotStats.MessagesDeleted.ToString();
            }

            if(DeleteAndBanText.InvokeRequired)
            {
                DeleteAndBanText.Invoke(new Action(() => { DeleteAndBanText.Text = SessionState.BotStats.UsersBanned.ToString(); }));
            }
            else
            {
                DeleteAndBanText.Text = SessionState.BotStats.UsersBanned.ToString();
            }
        }

        private void UpdateConnectionStatus(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static bool StartBot(string username, string password)
        {
            Bot.Client = new CurseClient.Bot.BotManager();
            try
            {
                Bot.Client.Run(username, password);
                Bot.InitializeBot();
                // Todo later: Support multiple servers by not using '.First()' here
                Bot.Groups = GroupsEndpoint.GetServerGroups(Bot.Client.Account, Bot.Channels.Keys.First());
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show($@"Failed to log in: {ex.Message}");
                return false;
            }
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            var started = StartBot(UsernameText.Text, PasswordText.Text);
            if(started)
            {
                if(saveLoginDetails)
                {
                    try
                    {
                        if(!Directory.Exists(saveDirectory))
                        {
                            Directory.CreateDirectory(saveDirectory);
                        }
                        File.WriteAllText(userLoginPath, JsonConvert.SerializeObject(new UserLoginModel() { Username = this.UsernameText.Text, Password = this.PasswordText.Text }), Encoding.UTF8);
                    }
                    catch(Exception ex)
                    {
                        Logging.Log.Error(ex.ToString());
                        MessageBox.Show($@"Unable to save login detail changes, {ex.Message.ToString()}");
                    }
                }
            }
        }

        private void SaveLoginDetailsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            saveLoginDetails = SaveLoginDetailsCheckbox.Checked;

            try
            {
                if(!Directory.Exists(saveDirectory))
                {
                    Directory.CreateDirectory(saveDirectory);
                }
                // Wipe existing data if we uncheck the save box
                if(!SaveLoginDetailsCheckbox.Checked)
                {
                    File.WriteAllText(userLoginPath, "");
                }

                // Only write the saved login data if the bot status is currently connected
                if(SaveLoginDetailsCheckbox.Checked && SessionState.ConnectionStatus == BotConnectionStatus.Connected)
                {
                    File.WriteAllText(userLoginPath, JsonConvert.SerializeObject(new UserLoginModel() { Username = this.UsernameText.Text, Password = this.PasswordText.Text }), Encoding.UTF8);
                }
            }
            catch(Exception ex)
            {
                Logging.Log.Error(ex.ToString());
                MessageBox.Show($@"Unable to save login detail changes, {ex.Message.ToString()}");
            }
        }

        #region POPULATED USING A CUSTOM "IList" DATASOURCE
        private void PopulateDropdown()
        {
            
        }

        #endregion

        private void RefreshRolesButton_Click(object sender, EventArgs e)
        {
            if(SessionState.ConnectionStatus == BotConnectionStatus.Connected)
            {
                Bot.Groups = GroupsEndpoint.GetServerGroups(Bot.Client.Account, Bot.Channels.Keys.First());
            }
        }
    }
}

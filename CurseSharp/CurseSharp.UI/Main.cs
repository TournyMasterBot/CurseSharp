using CurseSharp.CurseClient.Endpoints;
using CurseSharp.UI.Commands;
using CurseSharp.UI.Commands.BanPhrases;
using CurseSharp.UI.Forms;
using CurseSharp.UI.Service;
using System;
using System.Windows.Forms;

namespace CurseSharp.UI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitializeBotSettings();

            PasswordText.PasswordChar = '*';
        }

        private void InitializeBotSettings()
        {
            BanPhraseManager.LoadBanPhrases();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            StartBot(UsernameText.Text, PasswordText.Text);
            Bot.InitializeBot();
        }

        private void SendTestMessage_Click(object sender, EventArgs e)
        {
            try
            {
                MessageEndpoint.SendChatMessage(Bot.Client.Account, Bot.TestChannel, $"Test <{Guid.NewGuid()}>"); // NewGuid just for debugging.
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DeleteMessageText_Click(object sender, EventArgs e)
        {
            try
            {
                MessageEndpoint.DeleteMessage(Bot.Client.Account, Bot.TestChannel, MessageIDText.Text, TimestampText.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EditMessage_Click(object sender, EventArgs e)
        {
            try
            {
                MessageEndpoint.EditMessage(Bot.Client.Account, Bot.TestChannel, MessageIDText.Text, TimestampText.Text, EditMessageText.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static void StartBot(string username, string password)
        {
            Bot.Client = new CurseClient.Bot.BotManager();
            Bot.Client.Run(username, password);
        }

        private void ManageBannedPhrasesMenuItem_Click(object sender, EventArgs e)
        {
            var banPhraseForm = new BanPhraseForm();
            banPhraseForm.Show();
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

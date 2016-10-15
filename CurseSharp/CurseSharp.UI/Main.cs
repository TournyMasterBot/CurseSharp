using CurseSharp.CurseClient.Endpoints;
using CurseSharp.UI.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurseSharp.UI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            PasswordText.PasswordChar = '*';
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                StartBot(UsernameText.Text, PasswordText.Text);
                Bot.AssignTestChannel();
            });
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
    }
}

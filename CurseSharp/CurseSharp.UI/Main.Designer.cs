namespace CurseSharp.UI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageProfilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageBannedPhrasesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageCustomCommandsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendTestMessage = new System.Windows.Forms.Button();
            this.DeleteMessageText = new System.Windows.Forms.Button();
            this.ConversationIDText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MessageIDText = new System.Windows.Forms.TextBox();
            this.TimestampText = new System.Windows.Forms.TextBox();
            this.EditMessage = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.EditMessageText = new System.Windows.Forms.TextBox();
            this.Connect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.UsernameText = new System.Windows.Forms.TextBox();
            this.PasswordText = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.SettingMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(606, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QuitMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileMenuItem.Text = "File";
            // 
            // QuitMenuItem
            // 
            this.QuitMenuItem.Name = "QuitMenuItem";
            this.QuitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.QuitMenuItem.Text = "Quit";
            // 
            // SettingMenuItem
            // 
            this.SettingMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManageProfilesMenuItem,
            this.ManageBannedPhrasesMenuItem,
            this.ManageCustomCommandsMenuItem});
            this.SettingMenuItem.Name = "SettingMenuItem";
            this.SettingMenuItem.Size = new System.Drawing.Size(61, 20);
            this.SettingMenuItem.Text = "Settings";
            // 
            // ManageProfilesMenuItem
            // 
            this.ManageProfilesMenuItem.Name = "ManageProfilesMenuItem";
            this.ManageProfilesMenuItem.Size = new System.Drawing.Size(227, 22);
            this.ManageProfilesMenuItem.Text = "Manage Profiles";
            // 
            // ManageBannedPhrasesMenuItem
            // 
            this.ManageBannedPhrasesMenuItem.Name = "ManageBannedPhrasesMenuItem";
            this.ManageBannedPhrasesMenuItem.Size = new System.Drawing.Size(227, 22);
            this.ManageBannedPhrasesMenuItem.Text = "Manage Banned Phrases";
            // 
            // ManageCustomCommandsMenuItem
            // 
            this.ManageCustomCommandsMenuItem.Name = "ManageCustomCommandsMenuItem";
            this.ManageCustomCommandsMenuItem.Size = new System.Drawing.Size(227, 22);
            this.ManageCustomCommandsMenuItem.Text = "Manage Custom Commands";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // SendTestMessage
            // 
            this.SendTestMessage.Location = new System.Drawing.Point(12, 28);
            this.SendTestMessage.Name = "SendTestMessage";
            this.SendTestMessage.Size = new System.Drawing.Size(115, 23);
            this.SendTestMessage.TabIndex = 1;
            this.SendTestMessage.Text = "Send Test Message";
            this.SendTestMessage.UseVisualStyleBackColor = true;
            this.SendTestMessage.Click += new System.EventHandler(this.SendTestMessage_Click);
            // 
            // DeleteMessageText
            // 
            this.DeleteMessageText.Location = new System.Drawing.Point(12, 57);
            this.DeleteMessageText.Name = "DeleteMessageText";
            this.DeleteMessageText.Size = new System.Drawing.Size(115, 23);
            this.DeleteMessageText.TabIndex = 2;
            this.DeleteMessageText.Text = "Delete Message";
            this.DeleteMessageText.UseVisualStyleBackColor = true;
            this.DeleteMessageText.Click += new System.EventHandler(this.DeleteMessageText_Click);
            // 
            // ConversationIDText
            // 
            this.ConversationIDText.Location = new System.Drawing.Point(101, 119);
            this.ConversationIDText.Name = "ConversationIDText";
            this.ConversationIDText.Size = new System.Drawing.Size(100, 20);
            this.ConversationIDText.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Conversation ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "MessageID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Timestamp";
            // 
            // MessageIDText
            // 
            this.MessageIDText.Location = new System.Drawing.Point(101, 150);
            this.MessageIDText.Name = "MessageIDText";
            this.MessageIDText.Size = new System.Drawing.Size(100, 20);
            this.MessageIDText.TabIndex = 7;
            // 
            // TimestampText
            // 
            this.TimestampText.Location = new System.Drawing.Point(101, 176);
            this.TimestampText.Name = "TimestampText";
            this.TimestampText.Size = new System.Drawing.Size(100, 20);
            this.TimestampText.TabIndex = 8;
            // 
            // EditMessage
            // 
            this.EditMessage.Location = new System.Drawing.Point(12, 86);
            this.EditMessage.Name = "EditMessage";
            this.EditMessage.Size = new System.Drawing.Size(115, 23);
            this.EditMessage.TabIndex = 9;
            this.EditMessage.Text = "Edit Message";
            this.EditMessage.UseVisualStyleBackColor = true;
            this.EditMessage.Click += new System.EventHandler(this.EditMessage_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Edit Message";
            // 
            // EditMessageText
            // 
            this.EditMessageText.Location = new System.Drawing.Point(101, 204);
            this.EditMessageText.Name = "EditMessageText";
            this.EditMessageText.Size = new System.Drawing.Size(100, 20);
            this.EditMessageText.TabIndex = 10;
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(479, 85);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(115, 23);
            this.Connect.TabIndex = 12;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(433, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(433, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Password";
            // 
            // UsernameText
            // 
            this.UsernameText.Location = new System.Drawing.Point(494, 25);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(100, 20);
            this.UsernameText.TabIndex = 15;
            // 
            // PasswordText
            // 
            this.PasswordText.Location = new System.Drawing.Point(494, 59);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.Size = new System.Drawing.Size(100, 20);
            this.PasswordText.TabIndex = 16;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 460);
            this.Controls.Add(this.PasswordText);
            this.Controls.Add(this.UsernameText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EditMessageText);
            this.Controls.Add(this.EditMessage);
            this.Controls.Add(this.TimestampText);
            this.Controls.Add(this.MessageIDText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConversationIDText);
            this.Controls.Add(this.DeleteMessageText);
            this.Controls.Add(this.SendTestMessage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "CurseSharp";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageProfilesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageBannedPhrasesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageCustomCommandsMenuItem;
        private System.Windows.Forms.Button SendTestMessage;
        private System.Windows.Forms.Button DeleteMessageText;
        private System.Windows.Forms.TextBox ConversationIDText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MessageIDText;
        private System.Windows.Forms.TextBox TimestampText;
        private System.Windows.Forms.Button EditMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EditMessageText;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox UsernameText;
        private System.Windows.Forms.TextBox PasswordText;
    }
}


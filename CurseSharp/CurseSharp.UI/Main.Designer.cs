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
            this.ContentSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ConnectionStatusText = new System.Windows.Forms.Label();
            this.LoginDetailsLabel = new System.Windows.Forms.Label();
            this.DeleteAndBanText = new System.Windows.Forms.TextBox();
            this.DeleteAndBanLabel = new System.Windows.Forms.Label();
            this.DeletedText = new System.Windows.Forms.TextBox();
            this.DeletedLabel = new System.Windows.Forms.Label();
            this.EditText = new System.Windows.Forms.TextBox();
            this.EditLabel = new System.Windows.Forms.Label();
            this.StatsLabel = new System.Windows.Forms.Label();
            this.ConnectionStatusLabel = new System.Windows.Forms.Label();
            this.SaveLoginDetailsCheckbox = new System.Windows.Forms.CheckBox();
            this.PasswordText = new System.Windows.Forms.TextBox();
            this.UsernameText = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NavMenu = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.ContentSplitContainer)).BeginInit();
            this.ContentSplitContainer.Panel1.SuspendLayout();
            this.ContentSplitContainer.SuspendLayout();
            this.NavMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentSplitContainer
            // 
            this.ContentSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ContentSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ContentSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.ContentSplitContainer.Name = "ContentSplitContainer";
            // 
            // ContentSplitContainer.Panel1
            // 
            this.ContentSplitContainer.Panel1.Controls.Add(this.ConnectionStatusText);
            this.ContentSplitContainer.Panel1.Controls.Add(this.LoginDetailsLabel);
            this.ContentSplitContainer.Panel1.Controls.Add(this.DeleteAndBanText);
            this.ContentSplitContainer.Panel1.Controls.Add(this.DeleteAndBanLabel);
            this.ContentSplitContainer.Panel1.Controls.Add(this.DeletedText);
            this.ContentSplitContainer.Panel1.Controls.Add(this.DeletedLabel);
            this.ContentSplitContainer.Panel1.Controls.Add(this.EditText);
            this.ContentSplitContainer.Panel1.Controls.Add(this.EditLabel);
            this.ContentSplitContainer.Panel1.Controls.Add(this.StatsLabel);
            this.ContentSplitContainer.Panel1.Controls.Add(this.ConnectionStatusLabel);
            this.ContentSplitContainer.Panel1.Controls.Add(this.SaveLoginDetailsCheckbox);
            this.ContentSplitContainer.Panel1.Controls.Add(this.PasswordText);
            this.ContentSplitContainer.Panel1.Controls.Add(this.UsernameText);
            this.ContentSplitContainer.Panel1.Controls.Add(this.PasswordLabel);
            this.ContentSplitContainer.Panel1.Controls.Add(this.UsernameLabel);
            this.ContentSplitContainer.Panel1.Controls.Add(this.ConnectButton);
            this.ContentSplitContainer.Size = new System.Drawing.Size(784, 537);
            this.ContentSplitContainer.SplitterDistance = 219;
            this.ContentSplitContainer.TabIndex = 17;
            // 
            // ConnectionStatusText
            // 
            this.ConnectionStatusText.AutoSize = true;
            this.ConnectionStatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionStatusText.ForeColor = System.Drawing.Color.Red;
            this.ConnectionStatusText.Location = new System.Drawing.Point(56, 194);
            this.ConnectionStatusText.Name = "ConnectionStatusText";
            this.ConnectionStatusText.Size = new System.Drawing.Size(107, 20);
            this.ConnectionStatusText.TabIndex = 33;
            this.ConnectionStatusText.Text = "Disconnected";
            // 
            // LoginDetailsLabel
            // 
            this.LoginDetailsLabel.AutoSize = true;
            this.LoginDetailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginDetailsLabel.Location = new System.Drawing.Point(16, 12);
            this.LoginDetailsLabel.Name = "LoginDetailsLabel";
            this.LoginDetailsLabel.Size = new System.Drawing.Size(130, 24);
            this.LoginDetailsLabel.TabIndex = 32;
            this.LoginDetailsLabel.Text = "Login Details";
            // 
            // DeleteAndBanText
            // 
            this.DeleteAndBanText.Location = new System.Drawing.Point(90, 326);
            this.DeleteAndBanText.Name = "DeleteAndBanText";
            this.DeleteAndBanText.ReadOnly = true;
            this.DeleteAndBanText.Size = new System.Drawing.Size(116, 20);
            this.DeleteAndBanText.TabIndex = 31;
            this.DeleteAndBanText.TabStop = false;
            // 
            // DeleteAndBanLabel
            // 
            this.DeleteAndBanLabel.AutoSize = true;
            this.DeleteAndBanLabel.Location = new System.Drawing.Point(18, 329);
            this.DeleteAndBanLabel.Name = "DeleteAndBanLabel";
            this.DeleteAndBanLabel.Size = new System.Drawing.Size(66, 13);
            this.DeleteAndBanLabel.TabIndex = 30;
            this.DeleteAndBanLabel.Text = "Delete+Ban:";
            // 
            // DeletedText
            // 
            this.DeletedText.Location = new System.Drawing.Point(90, 300);
            this.DeletedText.Name = "DeletedText";
            this.DeletedText.ReadOnly = true;
            this.DeletedText.Size = new System.Drawing.Size(116, 20);
            this.DeletedText.TabIndex = 29;
            this.DeletedText.TabStop = false;
            // 
            // DeletedLabel
            // 
            this.DeletedLabel.AutoSize = true;
            this.DeletedLabel.Location = new System.Drawing.Point(18, 303);
            this.DeletedLabel.Name = "DeletedLabel";
            this.DeletedLabel.Size = new System.Drawing.Size(47, 13);
            this.DeletedLabel.TabIndex = 28;
            this.DeletedLabel.Text = "Deleted:";
            // 
            // EditText
            // 
            this.EditText.Location = new System.Drawing.Point(90, 274);
            this.EditText.Name = "EditText";
            this.EditText.ReadOnly = true;
            this.EditText.Size = new System.Drawing.Size(116, 20);
            this.EditText.TabIndex = 27;
            this.EditText.TabStop = false;
            // 
            // EditLabel
            // 
            this.EditLabel.AutoSize = true;
            this.EditLabel.Location = new System.Drawing.Point(18, 277);
            this.EditLabel.Name = "EditLabel";
            this.EditLabel.Size = new System.Drawing.Size(28, 13);
            this.EditLabel.TabIndex = 26;
            this.EditLabel.Text = "Edit:";
            // 
            // StatsLabel
            // 
            this.StatsLabel.AutoSize = true;
            this.StatsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatsLabel.Location = new System.Drawing.Point(17, 238);
            this.StatsLabel.Name = "StatsLabel";
            this.StatsLabel.Size = new System.Drawing.Size(90, 24);
            this.StatsLabel.TabIndex = 25;
            this.StatsLabel.Text = "Bot Stats";
            // 
            // ConnectionStatusLabel
            // 
            this.ConnectionStatusLabel.AutoSize = true;
            this.ConnectionStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionStatusLabel.Location = new System.Drawing.Point(17, 161);
            this.ConnectionStatusLabel.Name = "ConnectionStatusLabel";
            this.ConnectionStatusLabel.Size = new System.Drawing.Size(179, 24);
            this.ConnectionStatusLabel.TabIndex = 23;
            this.ConnectionStatusLabel.Text = "Connection Status";
            // 
            // SaveLoginDetailsCheckbox
            // 
            this.SaveLoginDetailsCheckbox.AutoSize = true;
            this.SaveLoginDetailsCheckbox.Location = new System.Drawing.Point(20, 100);
            this.SaveLoginDetailsCheckbox.Name = "SaveLoginDetailsCheckbox";
            this.SaveLoginDetailsCheckbox.Size = new System.Drawing.Size(157, 17);
            this.SaveLoginDetailsCheckbox.TabIndex = 3;
            this.SaveLoginDetailsCheckbox.Text = "SaveLoginDetailsCheckbox";
            this.SaveLoginDetailsCheckbox.UseVisualStyleBackColor = true;
            this.SaveLoginDetailsCheckbox.CheckedChanged += new System.EventHandler(this.SaveLoginDetailsCheckbox_CheckedChanged);
            // 
            // PasswordText
            // 
            this.PasswordText.Location = new System.Drawing.Point(78, 74);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.Size = new System.Drawing.Size(127, 20);
            this.PasswordText.TabIndex = 2;
            // 
            // UsernameText
            // 
            this.UsernameText.Location = new System.Drawing.Point(78, 48);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(127, 20);
            this.UsernameText.TabIndex = 1;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(17, 81);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 19;
            this.PasswordLabel.Text = "Password";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(17, 51);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameLabel.TabIndex = 18;
            this.UsernameLabel.Text = "Username";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(20, 123);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(185, 23);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
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
            this.SettingMenuItem.Name = "SettingMenuItem";
            this.SettingMenuItem.Size = new System.Drawing.Size(61, 20);
            this.SettingMenuItem.Text = "Settings";
            this.SettingMenuItem.Visible = false;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Visible = false;
            // 
            // NavMenu
            // 
            this.NavMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.SettingMenuItem,
            this.helpToolStripMenuItem});
            this.NavMenu.Location = new System.Drawing.Point(0, 0);
            this.NavMenu.Name = "NavMenu";
            this.NavMenu.Size = new System.Drawing.Size(784, 24);
            this.NavMenu.TabIndex = 0;
            this.NavMenu.Text = "menuStrip1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ContentSplitContainer);
            this.Controls.Add(this.NavMenu);
            this.MainMenuStrip = this.NavMenu;
            this.Name = "Main";
            this.Text = "CurseSharp";
            this.ContentSplitContainer.Panel1.ResumeLayout(false);
            this.ContentSplitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContentSplitContainer)).EndInit();
            this.ContentSplitContainer.ResumeLayout(false);
            this.NavMenu.ResumeLayout(false);
            this.NavMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer ContentSplitContainer;
        private System.Windows.Forms.CheckBox SaveLoginDetailsCheckbox;
        private System.Windows.Forms.TextBox PasswordText;
        private System.Windows.Forms.TextBox UsernameText;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.MenuStrip NavMenu;
        private System.Windows.Forms.Label ConnectionStatusLabel;
        private System.Windows.Forms.TextBox DeleteAndBanText;
        private System.Windows.Forms.Label DeleteAndBanLabel;
        private System.Windows.Forms.TextBox DeletedText;
        private System.Windows.Forms.Label DeletedLabel;
        private System.Windows.Forms.TextBox EditText;
        private System.Windows.Forms.Label EditLabel;
        private System.Windows.Forms.Label StatsLabel;
        private System.Windows.Forms.Label LoginDetailsLabel;
        private System.Windows.Forms.Label ConnectionStatusText;
    }
}


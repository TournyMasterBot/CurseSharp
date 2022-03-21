namespace CurseSharp.UI.FormControls
{
    partial class BanPhraseSimpleControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NormalizedBanPhraseText = new System.Windows.Forms.TextBox();
            this.SaveBanPhrase = new System.Windows.Forms.Button();
            this.PunishmentDurationText = new System.Windows.Forms.TextBox();
            this.MatchStyleGroupBox = new System.Windows.Forms.GroupBox();
            this.ContainsMatchRadio = new System.Windows.Forms.RadioButton();
            this.ExactMatchRadio = new System.Windows.Forms.RadioButton();
            this.BanPhraseKeywordText = new System.Windows.Forms.TextBox();
            this.PhraseOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.BanPhraseOptions = new System.Windows.Forms.CheckedListBox();
            this.EditOrDeleteGroupBox = new System.Windows.Forms.GroupBox();
            this.BanRadio = new System.Windows.Forms.RadioButton();
            this.DeleteRadio = new System.Windows.Forms.RadioButton();
            this.CensorRadio = new System.Windows.Forms.RadioButton();
            this.NormalizedLabel = new System.Windows.Forms.Label();
            this.PunishmentDurationLabel = new System.Windows.Forms.Label();
            this.BanPhraseLabel = new System.Windows.Forms.Label();
            this.LoadBanPhrase = new System.Windows.Forms.Button();
            this.DeleteSelectedBanPhraseButton = new System.Windows.Forms.Button();
            this.CreateNewBanPhraseButton = new System.Windows.Forms.Button();
            this.BanPhraseListContentManagementPanel = new System.Windows.Forms.Panel();
            this.BanPhraseListContentPanel = new System.Windows.Forms.Panel();
            this.PhraseDisplayGrid = new System.Windows.Forms.DataGridView();
            this.BanPhraseListSplitContainer = new System.Windows.Forms.SplitContainer();
            this.PhrasesLabel = new System.Windows.Forms.Label();
            this.BanPhraseSimpleSplitContainer = new System.Windows.Forms.SplitContainer();
            this.BanPhraseSimpleContentArea = new System.Windows.Forms.Panel();
            this.CreateEditLabel = new System.Windows.Forms.Label();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MatchStyleGroupBox.SuspendLayout();
            this.PhraseOptionsGroupBox.SuspendLayout();
            this.EditOrDeleteGroupBox.SuspendLayout();
            this.BanPhraseListContentManagementPanel.SuspendLayout();
            this.BanPhraseListContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhraseDisplayGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BanPhraseListSplitContainer)).BeginInit();
            this.BanPhraseListSplitContainer.Panel1.SuspendLayout();
            this.BanPhraseListSplitContainer.Panel2.SuspendLayout();
            this.BanPhraseListSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BanPhraseSimpleSplitContainer)).BeginInit();
            this.BanPhraseSimpleSplitContainer.Panel1.SuspendLayout();
            this.BanPhraseSimpleSplitContainer.Panel2.SuspendLayout();
            this.BanPhraseSimpleSplitContainer.SuspendLayout();
            this.BanPhraseSimpleContentArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // NormalizedBanPhraseText
            // 
            this.NormalizedBanPhraseText.Location = new System.Drawing.Point(74, 360);
            this.NormalizedBanPhraseText.MaxLength = 255;
            this.NormalizedBanPhraseText.Name = "NormalizedBanPhraseText";
            this.NormalizedBanPhraseText.ReadOnly = true;
            this.NormalizedBanPhraseText.Size = new System.Drawing.Size(170, 20);
            this.NormalizedBanPhraseText.TabIndex = 10;
            this.NormalizedBanPhraseText.TabStop = false;
            // 
            // SaveBanPhrase
            // 
            this.SaveBanPhrase.Location = new System.Drawing.Point(16, 332);
            this.SaveBanPhrase.Name = "SaveBanPhrase";
            this.SaveBanPhrase.Size = new System.Drawing.Size(231, 23);
            this.SaveBanPhrase.TabIndex = 8;
            this.SaveBanPhrase.Text = "Save";
            this.SaveBanPhrase.UseVisualStyleBackColor = true;
            this.SaveBanPhrase.Click += new System.EventHandler(this.SaveBanPhrase_Click);
            // 
            // PunishmentDurationText
            // 
            this.PunishmentDurationText.Location = new System.Drawing.Point(127, 306);
            this.PunishmentDurationText.MaxLength = 9;
            this.PunishmentDurationText.Name = "PunishmentDurationText";
            this.PunishmentDurationText.Size = new System.Drawing.Size(120, 20);
            this.PunishmentDurationText.TabIndex = 7;
            // 
            // MatchStyleGroupBox
            // 
            this.MatchStyleGroupBox.Controls.Add(this.ContainsMatchRadio);
            this.MatchStyleGroupBox.Controls.Add(this.ExactMatchRadio);
            this.MatchStyleGroupBox.Location = new System.Drawing.Point(9, 167);
            this.MatchStyleGroupBox.Name = "MatchStyleGroupBox";
            this.MatchStyleGroupBox.Size = new System.Drawing.Size(241, 65);
            this.MatchStyleGroupBox.TabIndex = 5;
            this.MatchStyleGroupBox.TabStop = false;
            this.MatchStyleGroupBox.Text = "Banned Phrase Action";
            // 
            // ContainsMatchRadio
            // 
            this.ContainsMatchRadio.AutoSize = true;
            this.ContainsMatchRadio.Location = new System.Drawing.Point(7, 42);
            this.ContainsMatchRadio.Name = "ContainsMatchRadio";
            this.ContainsMatchRadio.Size = new System.Drawing.Size(191, 17);
            this.ContainsMatchRadio.TabIndex = 1;
            this.ContainsMatchRadio.TabStop = true;
            this.ContainsMatchRadio.Text = "Contains Match (Classic -> Clbuttic)";
            this.ContainsMatchRadio.UseVisualStyleBackColor = true;
            // 
            // ExactMatchRadio
            // 
            this.ExactMatchRadio.AutoSize = true;
            this.ExactMatchRadio.Location = new System.Drawing.Point(7, 20);
            this.ExactMatchRadio.Name = "ExactMatchRadio";
            this.ExactMatchRadio.Size = new System.Drawing.Size(109, 17);
            this.ExactMatchRadio.TabIndex = 0;
            this.ExactMatchRadio.TabStop = true;
            this.ExactMatchRadio.Text = "Exact Match Only";
            this.ExactMatchRadio.UseVisualStyleBackColor = true;
            // 
            // BanPhraseKeywordText
            // 
            this.BanPhraseKeywordText.Location = new System.Drawing.Point(77, 50);
            this.BanPhraseKeywordText.MaxLength = 255;
            this.BanPhraseKeywordText.Name = "BanPhraseKeywordText";
            this.BanPhraseKeywordText.Size = new System.Drawing.Size(170, 20);
            this.BanPhraseKeywordText.TabIndex = 1;
            // 
            // PhraseOptionsGroupBox
            // 
            this.PhraseOptionsGroupBox.Controls.Add(this.BanPhraseOptions);
            this.PhraseOptionsGroupBox.Location = new System.Drawing.Point(9, 238);
            this.PhraseOptionsGroupBox.Name = "PhraseOptionsGroupBox";
            this.PhraseOptionsGroupBox.Size = new System.Drawing.Size(241, 62);
            this.PhraseOptionsGroupBox.TabIndex = 5;
            this.PhraseOptionsGroupBox.TabStop = false;
            this.PhraseOptionsGroupBox.Text = "Ban Phrase Options";
            // 
            // BanPhraseOptions
            // 
            this.BanPhraseOptions.BackColor = System.Drawing.SystemColors.Control;
            this.BanPhraseOptions.CheckOnClick = true;
            this.BanPhraseOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BanPhraseOptions.FormattingEnabled = true;
            this.BanPhraseOptions.Items.AddRange(new object[] {
            "Check For Common Spelling Variants",
            "Log Actions Taken"});
            this.BanPhraseOptions.Location = new System.Drawing.Point(3, 16);
            this.BanPhraseOptions.Name = "BanPhraseOptions";
            this.BanPhraseOptions.Size = new System.Drawing.Size(235, 43);
            this.BanPhraseOptions.TabIndex = 0;
            // 
            // EditOrDeleteGroupBox
            // 
            this.EditOrDeleteGroupBox.Controls.Add(this.BanRadio);
            this.EditOrDeleteGroupBox.Controls.Add(this.DeleteRadio);
            this.EditOrDeleteGroupBox.Controls.Add(this.CensorRadio);
            this.EditOrDeleteGroupBox.Location = new System.Drawing.Point(9, 76);
            this.EditOrDeleteGroupBox.Name = "EditOrDeleteGroupBox";
            this.EditOrDeleteGroupBox.Size = new System.Drawing.Size(241, 85);
            this.EditOrDeleteGroupBox.TabIndex = 4;
            this.EditOrDeleteGroupBox.TabStop = false;
            this.EditOrDeleteGroupBox.Text = "Banned Phrase Action";
            // 
            // BanRadio
            // 
            this.BanRadio.AutoSize = true;
            this.BanRadio.Location = new System.Drawing.Point(7, 62);
            this.BanRadio.Name = "BanRadio";
            this.BanRadio.Size = new System.Drawing.Size(148, 17);
            this.BanRadio.TabIndex = 2;
            this.BanRadio.TabStop = true;
            this.BanRadio.Text = "Delete Phrase + Ban User";
            this.BanRadio.UseVisualStyleBackColor = true;
            // 
            // DeleteRadio
            // 
            this.DeleteRadio.AutoSize = true;
            this.DeleteRadio.Location = new System.Drawing.Point(7, 42);
            this.DeleteRadio.Name = "DeleteRadio";
            this.DeleteRadio.Size = new System.Drawing.Size(92, 17);
            this.DeleteRadio.TabIndex = 1;
            this.DeleteRadio.TabStop = true;
            this.DeleteRadio.Text = "Delete Phrase";
            this.DeleteRadio.UseVisualStyleBackColor = true;
            // 
            // CensorRadio
            // 
            this.CensorRadio.AutoSize = true;
            this.CensorRadio.Location = new System.Drawing.Point(7, 20);
            this.CensorRadio.Name = "CensorRadio";
            this.CensorRadio.Size = new System.Drawing.Size(94, 17);
            this.CensorRadio.TabIndex = 0;
            this.CensorRadio.TabStop = true;
            this.CensorRadio.Text = "Censor Phrase";
            this.CensorRadio.UseVisualStyleBackColor = true;
            // 
            // NormalizedLabel
            // 
            this.NormalizedLabel.AutoSize = true;
            this.NormalizedLabel.Location = new System.Drawing.Point(6, 363);
            this.NormalizedLabel.Name = "NormalizedLabel";
            this.NormalizedLabel.Size = new System.Drawing.Size(62, 13);
            this.NormalizedLabel.TabIndex = 9;
            this.NormalizedLabel.Text = "Normalized:";
            // 
            // PunishmentDurationLabel
            // 
            this.PunishmentDurationLabel.AutoSize = true;
            this.PunishmentDurationLabel.Location = new System.Drawing.Point(13, 309);
            this.PunishmentDurationLabel.Name = "PunishmentDurationLabel";
            this.PunishmentDurationLabel.Size = new System.Drawing.Size(108, 13);
            this.PunishmentDurationLabel.TabIndex = 6;
            this.PunishmentDurationLabel.Text = "Punishment Duration:";
            // 
            // BanPhraseLabel
            // 
            this.BanPhraseLabel.AutoSize = true;
            this.BanPhraseLabel.Location = new System.Drawing.Point(6, 53);
            this.BanPhraseLabel.Name = "BanPhraseLabel";
            this.BanPhraseLabel.Size = new System.Drawing.Size(65, 13);
            this.BanPhraseLabel.TabIndex = 0;
            this.BanPhraseLabel.Text = "Ban Phrase:";
            // 
            // LoadBanPhrase
            // 
            this.LoadBanPhrase.Location = new System.Drawing.Point(25, 60);
            this.LoadBanPhrase.Name = "LoadBanPhrase";
            this.LoadBanPhrase.Size = new System.Drawing.Size(120, 23);
            this.LoadBanPhrase.TabIndex = 3;
            this.LoadBanPhrase.Text = "Bulk Load Phrases";
            this.LoadBanPhrase.UseVisualStyleBackColor = true;
            this.LoadBanPhrase.Click += new System.EventHandler(this.LoadBanPhrase_Click);
            // 
            // DeleteSelectedBanPhraseButton
            // 
            this.DeleteSelectedBanPhraseButton.Location = new System.Drawing.Point(25, 31);
            this.DeleteSelectedBanPhraseButton.Name = "DeleteSelectedBanPhraseButton";
            this.DeleteSelectedBanPhraseButton.Size = new System.Drawing.Size(120, 23);
            this.DeleteSelectedBanPhraseButton.TabIndex = 2;
            this.DeleteSelectedBanPhraseButton.Text = "Delete Selected";
            this.DeleteSelectedBanPhraseButton.UseVisualStyleBackColor = true;
            this.DeleteSelectedBanPhraseButton.Click += new System.EventHandler(this.DeleteSelectedBanPhraseButton_Click);
            // 
            // CreateNewBanPhraseButton
            // 
            this.CreateNewBanPhraseButton.Location = new System.Drawing.Point(25, 2);
            this.CreateNewBanPhraseButton.Name = "CreateNewBanPhraseButton";
            this.CreateNewBanPhraseButton.Size = new System.Drawing.Size(120, 23);
            this.CreateNewBanPhraseButton.TabIndex = 0;
            this.CreateNewBanPhraseButton.Text = "New Ban Phrase";
            this.CreateNewBanPhraseButton.UseVisualStyleBackColor = true;
            this.CreateNewBanPhraseButton.Click += new System.EventHandler(this.CreateNewBanPhraseButton_Click);
            // 
            // BanPhraseListContentManagementPanel
            // 
            this.BanPhraseListContentManagementPanel.Controls.Add(this.LoadBanPhrase);
            this.BanPhraseListContentManagementPanel.Controls.Add(this.DeleteSelectedBanPhraseButton);
            this.BanPhraseListContentManagementPanel.Controls.Add(this.CreateNewBanPhraseButton);
            this.BanPhraseListContentManagementPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BanPhraseListContentManagementPanel.Location = new System.Drawing.Point(0, 0);
            this.BanPhraseListContentManagementPanel.Name = "BanPhraseListContentManagementPanel";
            this.BanPhraseListContentManagementPanel.Size = new System.Drawing.Size(148, 142);
            this.BanPhraseListContentManagementPanel.TabIndex = 0;
            // 
            // BanPhraseListContentPanel
            // 
            this.BanPhraseListContentPanel.Controls.Add(this.PhraseDisplayGrid);
            this.BanPhraseListContentPanel.Location = new System.Drawing.Point(25, 44);
            this.BanPhraseListContentPanel.Name = "BanPhraseListContentPanel";
            this.BanPhraseListContentPanel.Size = new System.Drawing.Size(123, 290);
            this.BanPhraseListContentPanel.TabIndex = 0;
            // 
            // PhraseDisplayGrid
            // 
            this.PhraseDisplayGrid.AllowUserToAddRows = false;
            this.PhraseDisplayGrid.AllowUserToDeleteRows = false;
            this.PhraseDisplayGrid.AllowUserToResizeColumns = false;
            this.PhraseDisplayGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PhraseDisplayGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PhraseDisplayGrid.Location = new System.Drawing.Point(0, 0);
            this.PhraseDisplayGrid.MultiSelect = false;
            this.PhraseDisplayGrid.Name = "PhraseDisplayGrid";
            this.PhraseDisplayGrid.ReadOnly = true;
            this.PhraseDisplayGrid.Size = new System.Drawing.Size(123, 290);
            this.PhraseDisplayGrid.TabIndex = 1;
            this.PhraseDisplayGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PhraseDisplayGrid_CellClick);
            // 
            // BanPhraseListSplitContainer
            // 
            this.BanPhraseListSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BanPhraseListSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.BanPhraseListSplitContainer.Name = "BanPhraseListSplitContainer";
            this.BanPhraseListSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // BanPhraseListSplitContainer.Panel1
            // 
            this.BanPhraseListSplitContainer.Panel1.Controls.Add(this.PhrasesLabel);
            this.BanPhraseListSplitContainer.Panel1.Controls.Add(this.BanPhraseListContentPanel);
            // 
            // BanPhraseListSplitContainer.Panel2
            // 
            this.BanPhraseListSplitContainer.Panel2.Controls.Add(this.BanPhraseListContentManagementPanel);
            this.BanPhraseListSplitContainer.Size = new System.Drawing.Size(148, 480);
            this.BanPhraseListSplitContainer.SplitterDistance = 334;
            this.BanPhraseListSplitContainer.TabIndex = 0;
            // 
            // PhrasesLabel
            // 
            this.PhrasesLabel.AutoSize = true;
            this.PhrasesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhrasesLabel.Location = new System.Drawing.Point(21, 17);
            this.PhrasesLabel.Name = "PhrasesLabel";
            this.PhrasesLabel.Size = new System.Drawing.Size(85, 24);
            this.PhrasesLabel.TabIndex = 1;
            this.PhrasesLabel.Text = "Phrases";
            // 
            // BanPhraseSimpleSplitContainer
            // 
            this.BanPhraseSimpleSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BanPhraseSimpleSplitContainer.IsSplitterFixed = true;
            this.BanPhraseSimpleSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.BanPhraseSimpleSplitContainer.Name = "BanPhraseSimpleSplitContainer";
            // 
            // BanPhraseSimpleSplitContainer.Panel1
            // 
            this.BanPhraseSimpleSplitContainer.Panel1.Controls.Add(this.BanPhraseListSplitContainer);
            // 
            // BanPhraseSimpleSplitContainer.Panel2
            // 
            this.BanPhraseSimpleSplitContainer.Panel2.Controls.Add(this.BanPhraseSimpleContentArea);
            this.BanPhraseSimpleSplitContainer.Size = new System.Drawing.Size(449, 480);
            this.BanPhraseSimpleSplitContainer.SplitterDistance = 148;
            this.BanPhraseSimpleSplitContainer.TabIndex = 1;
            // 
            // BanPhraseSimpleContentArea
            // 
            this.BanPhraseSimpleContentArea.Controls.Add(this.CreateEditLabel);
            this.BanPhraseSimpleContentArea.Controls.Add(this.NormalizedBanPhraseText);
            this.BanPhraseSimpleContentArea.Controls.Add(this.NormalizedLabel);
            this.BanPhraseSimpleContentArea.Controls.Add(this.SaveBanPhrase);
            this.BanPhraseSimpleContentArea.Controls.Add(this.PunishmentDurationText);
            this.BanPhraseSimpleContentArea.Controls.Add(this.PunishmentDurationLabel);
            this.BanPhraseSimpleContentArea.Controls.Add(this.MatchStyleGroupBox);
            this.BanPhraseSimpleContentArea.Controls.Add(this.PhraseOptionsGroupBox);
            this.BanPhraseSimpleContentArea.Controls.Add(this.EditOrDeleteGroupBox);
            this.BanPhraseSimpleContentArea.Controls.Add(this.BanPhraseKeywordText);
            this.BanPhraseSimpleContentArea.Controls.Add(this.BanPhraseLabel);
            this.BanPhraseSimpleContentArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BanPhraseSimpleContentArea.Location = new System.Drawing.Point(0, 0);
            this.BanPhraseSimpleContentArea.Name = "BanPhraseSimpleContentArea";
            this.BanPhraseSimpleContentArea.Size = new System.Drawing.Size(297, 480);
            this.BanPhraseSimpleContentArea.TabIndex = 0;
            // 
            // CreateEditLabel
            // 
            this.CreateEditLabel.AutoSize = true;
            this.CreateEditLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateEditLabel.Location = new System.Drawing.Point(5, 17);
            this.CreateEditLabel.Name = "CreateEditLabel";
            this.CreateEditLabel.Size = new System.Drawing.Size(125, 24);
            this.CreateEditLabel.TabIndex = 2;
            this.CreateEditLabel.Text = "Create / Edit";
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "OpenFileDialog";
            // 
            // BanPhraseSimpleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BanPhraseSimpleSplitContainer);
            this.Name = "BanPhraseSimpleControl";
            this.Size = new System.Drawing.Size(449, 480);
            this.MatchStyleGroupBox.ResumeLayout(false);
            this.MatchStyleGroupBox.PerformLayout();
            this.PhraseOptionsGroupBox.ResumeLayout(false);
            this.EditOrDeleteGroupBox.ResumeLayout(false);
            this.EditOrDeleteGroupBox.PerformLayout();
            this.BanPhraseListContentManagementPanel.ResumeLayout(false);
            this.BanPhraseListContentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PhraseDisplayGrid)).EndInit();
            this.BanPhraseListSplitContainer.Panel1.ResumeLayout(false);
            this.BanPhraseListSplitContainer.Panel1.PerformLayout();
            this.BanPhraseListSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BanPhraseListSplitContainer)).EndInit();
            this.BanPhraseListSplitContainer.ResumeLayout(false);
            this.BanPhraseSimpleSplitContainer.Panel1.ResumeLayout(false);
            this.BanPhraseSimpleSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BanPhraseSimpleSplitContainer)).EndInit();
            this.BanPhraseSimpleSplitContainer.ResumeLayout(false);
            this.BanPhraseSimpleContentArea.ResumeLayout(false);
            this.BanPhraseSimpleContentArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox NormalizedBanPhraseText;
        private System.Windows.Forms.Button SaveBanPhrase;
        private System.Windows.Forms.TextBox PunishmentDurationText;
        private System.Windows.Forms.GroupBox MatchStyleGroupBox;
        private System.Windows.Forms.RadioButton ContainsMatchRadio;
        private System.Windows.Forms.RadioButton ExactMatchRadio;
        private System.Windows.Forms.TextBox BanPhraseKeywordText;
        private System.Windows.Forms.GroupBox PhraseOptionsGroupBox;
        private System.Windows.Forms.CheckedListBox BanPhraseOptions;
        private System.Windows.Forms.GroupBox EditOrDeleteGroupBox;
        private System.Windows.Forms.RadioButton BanRadio;
        private System.Windows.Forms.RadioButton DeleteRadio;
        private System.Windows.Forms.RadioButton CensorRadio;
        private System.Windows.Forms.Label NormalizedLabel;
        private System.Windows.Forms.Label PunishmentDurationLabel;
        private System.Windows.Forms.Label BanPhraseLabel;
        private System.Windows.Forms.Button LoadBanPhrase;
        private System.Windows.Forms.Button DeleteSelectedBanPhraseButton;
        private System.Windows.Forms.Button CreateNewBanPhraseButton;
        private System.Windows.Forms.Panel BanPhraseListContentManagementPanel;
        private System.Windows.Forms.Panel BanPhraseListContentPanel;
        private System.Windows.Forms.SplitContainer BanPhraseListSplitContainer;
        private System.Windows.Forms.SplitContainer BanPhraseSimpleSplitContainer;
        private System.Windows.Forms.Panel BanPhraseSimpleContentArea;
        private System.Windows.Forms.Label PhrasesLabel;
        private System.Windows.Forms.Label CreateEditLabel;
        private System.Windows.Forms.DataGridView PhraseDisplayGrid;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
    }
}

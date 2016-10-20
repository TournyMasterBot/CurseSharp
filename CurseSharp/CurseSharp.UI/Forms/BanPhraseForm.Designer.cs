namespace CurseSharp.UI.Forms
{
    partial class BanPhraseForm
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
            this.BanPhraseSplitContainer = new System.Windows.Forms.SplitContainer();
            this.BanPhraseContentPanel = new System.Windows.Forms.Panel();
            this.ControlSwitchContent = new System.Windows.Forms.Button();
            this.BanPhraseInnerContentPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BanPhraseSplitContainer)).BeginInit();
            this.BanPhraseSplitContainer.Panel1.SuspendLayout();
            this.BanPhraseSplitContainer.Panel2.SuspendLayout();
            this.BanPhraseSplitContainer.SuspendLayout();
            this.BanPhraseContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BanPhraseSplitContainer
            // 
            this.BanPhraseSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BanPhraseSplitContainer.IsSplitterFixed = true;
            this.BanPhraseSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.BanPhraseSplitContainer.Name = "BanPhraseSplitContainer";
            this.BanPhraseSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // BanPhraseSplitContainer.Panel1
            // 
            this.BanPhraseSplitContainer.Panel1.Controls.Add(this.BanPhraseContentPanel);
            // 
            // BanPhraseSplitContainer.Panel2
            // 
            this.BanPhraseSplitContainer.Panel2.Controls.Add(this.BanPhraseInnerContentPanel);
            this.BanPhraseSplitContainer.Size = new System.Drawing.Size(404, 441);
            this.BanPhraseSplitContainer.SplitterDistance = 30;
            this.BanPhraseSplitContainer.TabIndex = 0;
            // 
            // BanPhraseContentPanel
            // 
            this.BanPhraseContentPanel.Controls.Add(this.label1);
            this.BanPhraseContentPanel.Controls.Add(this.ControlSwitchContent);
            this.BanPhraseContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BanPhraseContentPanel.Location = new System.Drawing.Point(0, 0);
            this.BanPhraseContentPanel.Name = "BanPhraseContentPanel";
            this.BanPhraseContentPanel.Size = new System.Drawing.Size(404, 30);
            this.BanPhraseContentPanel.TabIndex = 1;
            // 
            // ControlSwitchContent
            // 
            this.ControlSwitchContent.Enabled = false;
            this.ControlSwitchContent.Location = new System.Drawing.Point(317, 4);
            this.ControlSwitchContent.Name = "ControlSwitchContent";
            this.ControlSwitchContent.Size = new System.Drawing.Size(75, 23);
            this.ControlSwitchContent.TabIndex = 0;
            this.ControlSwitchContent.Text = "Advanced";
            this.ControlSwitchContent.UseVisualStyleBackColor = true;
            this.ControlSwitchContent.Click += new System.EventHandler(this.ControlSwitchContent_Click);
            // 
            // BanPhraseInnerContentPanel
            // 
            this.BanPhraseInnerContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BanPhraseInnerContentPanel.Location = new System.Drawing.Point(0, 0);
            this.BanPhraseInnerContentPanel.Name = "BanPhraseInnerContentPanel";
            this.BanPhraseInnerContentPanel.Padding = new System.Windows.Forms.Padding(10);
            this.BanPhraseInnerContentPanel.Size = new System.Drawing.Size(404, 407);
            this.BanPhraseInnerContentPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Simple Form";
            // 
            // BanPhraseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 441);
            this.Controls.Add(this.BanPhraseSplitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(420, 480);
            this.Name = "BanPhraseForm";
            this.Text = "Ban Phrase Manager";
            this.BanPhraseSplitContainer.Panel1.ResumeLayout(false);
            this.BanPhraseSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BanPhraseSplitContainer)).EndInit();
            this.BanPhraseSplitContainer.ResumeLayout(false);
            this.BanPhraseContentPanel.ResumeLayout(false);
            this.BanPhraseContentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer BanPhraseSplitContainer;
        private System.Windows.Forms.Panel BanPhraseContentPanel;
        private System.Windows.Forms.Button ControlSwitchContent;
        private System.Windows.Forms.Panel BanPhraseInnerContentPanel;
        private System.Windows.Forms.Label label1;
    }
}
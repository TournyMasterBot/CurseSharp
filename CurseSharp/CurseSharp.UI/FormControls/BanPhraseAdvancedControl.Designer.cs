namespace CurseSharp.UI.FormControls
{
    partial class BanPhraseAdvancedControl
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
            this.BanPhraseAdvancedSplitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.BanPhraseAdvancedSplitContainer)).BeginInit();
            this.BanPhraseAdvancedSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // BanPhraseAdvancedSplitContainer
            // 
            this.BanPhraseAdvancedSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BanPhraseAdvancedSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.BanPhraseAdvancedSplitContainer.Name = "BanPhraseAdvancedSplitContainer";
            this.BanPhraseAdvancedSplitContainer.Size = new System.Drawing.Size(624, 441);
            this.BanPhraseAdvancedSplitContainer.SplitterDistance = 208;
            this.BanPhraseAdvancedSplitContainer.TabIndex = 0;
            // 
            // BanPhraseAdvancedControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BanPhraseAdvancedSplitContainer);
            this.Name = "BanPhraseAdvancedControl";
            this.Size = new System.Drawing.Size(624, 441);
            ((System.ComponentModel.ISupportInitialize)(this.BanPhraseAdvancedSplitContainer)).EndInit();
            this.BanPhraseAdvancedSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer BanPhraseAdvancedSplitContainer;
    }
}

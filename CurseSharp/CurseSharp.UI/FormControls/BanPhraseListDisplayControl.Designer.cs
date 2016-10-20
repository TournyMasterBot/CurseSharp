namespace CurseSharp.UI.FormControls
{
    partial class BanPhraseListDisplayControl
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
            this.PhraseDisplayGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.PhraseDisplayGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // PhraseDisplayGrid
            // 
            this.PhraseDisplayGrid.AllowUserToAddRows = false;
            this.PhraseDisplayGrid.AllowUserToDeleteRows = false;
            this.PhraseDisplayGrid.AllowUserToResizeColumns = false;
            this.PhraseDisplayGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PhraseDisplayGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PhraseDisplayGrid.Location = new System.Drawing.Point(0, 0);
            this.PhraseDisplayGrid.Name = "PhraseDisplayGrid";
            this.PhraseDisplayGrid.ReadOnly = true;
            this.PhraseDisplayGrid.Size = new System.Drawing.Size(142, 279);
            this.PhraseDisplayGrid.TabIndex = 0;
            this.PhraseDisplayGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PhraseDisplayGrid_CellClick);
            // 
            // BanPhraseListDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PhraseDisplayGrid);
            this.Name = "BanPhraseListDisplayControl";
            this.Size = new System.Drawing.Size(142, 279);
            ((System.ComponentModel.ISupportInitialize)(this.PhraseDisplayGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PhraseDisplayGrid;
    }
}

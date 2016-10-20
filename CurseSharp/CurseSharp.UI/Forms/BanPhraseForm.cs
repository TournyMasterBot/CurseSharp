using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurseSharp.UI.Forms
{
    public partial class BanPhraseForm : Form
    {
        private string currentControl = "simple";
        Control simpleControl = new FormControls.BanPhraseSimpleControl();
        Control advancedControl = new FormControls.BanPhraseAdvancedControl();

        public BanPhraseForm()
        {
            InitializeComponent();
            simpleControl.Dock = DockStyle.Fill;
            advancedControl.Dock = DockStyle.Fill;
            BanPhraseInnerContentPanel.Controls.Add(simpleControl);
        }

        private void ControlSwitchContent_Click(object sender, EventArgs e)
        {
            if(currentControl == "simple")
            {
                BanPhraseInnerContentPanel.Controls.Add(advancedControl);
                BanPhraseInnerContentPanel.Controls.Remove(simpleControl);
                currentControl = "advanced";
                ControlSwitchContent.Text = "Simple";
            }
            else
            {
                BanPhraseInnerContentPanel.Controls.Add(simpleControl);
                BanPhraseInnerContentPanel.Controls.Remove(advancedControl);
                currentControl = "simple";
                ControlSwitchContent.Text = "Advanced";
            }
        }
    }
}

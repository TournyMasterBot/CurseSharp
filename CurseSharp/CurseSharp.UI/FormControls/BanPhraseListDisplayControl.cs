using System.Data;
using System.Linq;
using System.Windows.Forms;
using CurseSharp.UI.Commands.BanPhrases;
using CurseSharp.CurseClient.Helpers;
using System;
using CurseSharp.CurseClient.Models.BotModels;

namespace CurseSharp.UI.FormControls
{
    public partial class BanPhraseListDisplayControl : UserControl
    {
        private BanPhraseModel banData = new BanPhraseModel();

        public BanPhraseListDisplayControl()
        {
            InitializeComponent();
            PopulateBanPhraseDisplayGrid();
        }

        public void PopulateBanPhraseDisplayGrid()
        {
            var phrases = BanPhraseManager.GetBanPhrases().Select(x => new { Phrase = x.BadPhrase }).ToArray();
            var data = DataTableHelper.CreateDataTable(phrases);
            var binding = new BindingSource();
            binding.DataSource = data;
            PhraseDisplayGrid.Columns.Clear();
            PhraseDisplayGrid.DataSource = binding;
            PhraseDisplayGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PhraseDisplayGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            PhraseDisplayGrid.AllowUserToResizeRows = false;
            PhraseDisplayGrid.AllowUserToResizeColumns = false;
            PhraseDisplayGrid.RowHeadersVisible = false;
            PhraseDisplayGrid.ScrollBars = ScrollBars.Vertical;
            PhraseDisplayGrid.CellClick += new DataGridViewCellEventHandler(PhraseDisplayGrid_CellClick);
        }

        private void LoadDisplayPanel(string banphrase)
        {
            BanPhraseModel localBan = null;
            if(string.IsNullOrWhiteSpace(banphrase))
            {
                localBan = BanPhraseManager.GetBanPhrases().FirstOrDefault();
            }
            else
            {
                localBan = BanPhraseManager.GetBanPhrases().FirstOrDefault(x => x.BadPhrase == banphrase);
            }
            // Protection in case ban phrase gets deleted
            if(localBan == null)
            {
                banData = new BanPhraseModel();
            }
            else
            {
                banData = localBan;
            }
        }

        public void ClearSelectedBanPhrase()
        {
            banData = new BanPhraseModel();
        }

        public BanPhraseModel GetCurrentSelectedBanPhrase()
        {
            if(string.IsNullOrWhiteSpace(banData.BadPhrase))
            {
                LoadDisplayPanel(null);
            }
            return banData;
        }

        private void PhraseDisplayGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDisplayPanel(PhraseDisplayGrid[e.ColumnIndex, e.RowIndex].Value.ToString());
        }
    }
}

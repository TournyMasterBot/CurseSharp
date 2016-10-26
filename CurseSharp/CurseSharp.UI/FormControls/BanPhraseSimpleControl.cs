using CurseSharp.CurseClient.Extensions;
using CurseSharp.CurseClient.Helpers;
using CurseSharp.CurseClient.Models;
using CurseSharp.CurseClient.Models.BotModels;
using CurseSharp.UI.Commands.BanPhrases;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CurseSharp.UI.FormControls
{
    public partial class BanPhraseSimpleControl : UserControl
    {
        private BanPhraseModel banData = new BanPhraseModel();

        public BanPhraseSimpleControl()
        {
            InitializeComponent();
            PopulateBanPhraseDisplayGrid();
        }

        private void PunishmentDurationText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Updates the form to match the passed content, for radios checks most destructive
        /// item first and only applies one radio check in case you have been manually editing the ini file
        /// </summary>
        private void ResetForm(BanPhraseModel content, bool isEdit)
        {
            if(string.IsNullOrWhiteSpace(content.BadPhrase))
            {
                BanPhraseKeywordText.Text = "";
            }
            else
            {
                BanPhraseKeywordText.Text = content.BadPhrase;
            }
            if(content.Response.HasFlag(BanPhraseResponse.Delete))
            {
                DeleteRadio.Checked = true;
            }
            else if(content.Response.HasFlag(BanPhraseResponse.Edit))
            {
                CensorRadio.Checked = true;
            }
            // wipe content
            if(!content.Response.HasFlag(BanPhraseResponse.Delete))
            {
                DeleteRadio.Checked = false;
            }
            if(!content.Response.HasFlag(BanPhraseResponse.Edit))
            {
                CensorRadio.Checked = false;
            }

            if(content.CheckType.HasFlag(BanPhraseCheckType.ExactMatch))
            {
                ExactMatchRadio.Checked = true;
            }
            else
            {
                ExactMatchRadio.Checked = false;
            }

            if(content.CheckType.HasFlag(BanPhraseCheckType.ContainsMatch))
            {
                ContainsMatchRadio.Checked = true;
            }
            else
            {
                ContainsMatchRadio.Checked = false;
            }

            // wipe checks
            if(!content.CheckType.HasFlag(BanPhraseCheckType.ExactMatch))
            {
                ExactMatchRadio.Checked = false;
            }
            if(!content.CheckType.HasFlag(BanPhraseCheckType.ContainsMatch))
            {
                ContainsMatchRadio.Checked = false;
            }

            if(content.Response.HasFlag(BanPhraseResponse.Ban))
            {
                BanRadio.Checked = true;
            }
            else
            {
                BanRadio.Checked = false;
            }

            if(content.BanPhraseOptions.HasFlag(CurseClient.Models.BanPhraseOptions.CheckForCommonSpellingVariants))
            {
                BanPhraseOptions.SetItemChecked(0, true);
            }
            else
            {
                BanPhraseOptions.SetItemChecked(0, false);
            }

            if(content.BanPhraseOptions.HasFlag(CurseClient.Models.BanPhraseOptions.LogActionsTaken))
            {
                BanPhraseOptions.SetItemChecked(1, true);
            }
            else
            {
                BanPhraseOptions.SetItemChecked(1, false);
            }

            if(content.ResponseDuration >= 0)
            {
                PunishmentDurationText.Text = content.ResponseDuration.ToString();
            }
            else
            {
                PunishmentDurationText.Text = "";
            }

            RemovePlaceholderRowGrid();
            if(!isEdit)
            {
                // Add a placeholder row on 'phrase' grid
                AddPlaceholderRowGrid();
            }

        }

        private void PopulateBanPhraseDisplayGrid()
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

        public void AddPlaceholderRowGrid()
        {
            RemovePlaceholderRowGrid();
            BanPhraseManager.CreateBanPhrase(new BanPhraseModel()
            {
                BadPhrase = "",
                BadPhraseOriginal = "",
                BanPhraseOptions = CurseClient.Models.BanPhraseOptions.None,
                CheckType = BanPhraseCheckType.ExactMatch,
                LogAction = false,
                Response = BanPhraseResponse.DoNothing,
                ResponseDuration = 0 
            });
            RefreshDisplay();
        }

        public void RemovePlaceholderRowGrid()
        {
            var foundMatch = false;
            DataGridViewRow rowToDelete = null;
            var i = 0;
            do
            {
                if(i < PhraseDisplayGrid.Rows.Count)
                {
                    var row = PhraseDisplayGrid.Rows[i];
                    if(row.Cells[0].Value.ToString() == "")
                    {
                        foundMatch = true;
                        rowToDelete = row;
                    }
                }
                i++;
            } while(!foundMatch && i <= PhraseDisplayGrid.Rows.Count);

            if(foundMatch && rowToDelete != null)
            {
                PhraseDisplayGrid.Rows.Remove(rowToDelete);
            }
        }

        private void LoadDisplayPanel(string banphrase)
        {
            BanPhraseModel localBan = null;
            localBan = BanPhraseManager.GetBanPhrases().FirstOrDefault(x => x.BadPhrase == banphrase);
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

        public void PhraseDisplayGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDisplayPanel(PhraseDisplayGrid[e.ColumnIndex, e.RowIndex].Value.ToString());
            BanPhraseModel phrase = GetCurrentSelectedBanPhrase();

            if(!string.IsNullOrWhiteSpace(phrase.BadPhrase))
            {
                ResetForm(phrase, true);
            }
        }

        private void SaveBanPhrase_Click(object sender, System.EventArgs e)
        {
            var errorList = new StringBuilder();
            int errorCount = 1;

            if(string.IsNullOrWhiteSpace(BanPhraseKeywordText.Text))
            {
                errorList.AppendLine($@"{errorCount}. Enter a ban phrase.");
                errorCount++;
            }

            if(!CensorRadio.Checked && !DeleteRadio.Checked && !BanRadio.Checked)
            {
                errorList.AppendLine($@"{errorCount}. Select whether to censor (edit) the phrase, or delete it.");
                errorCount++;
            }

            if(!ExactMatchRadio.Checked && !ContainsMatchRadio.Checked)
            {
                errorList.AppendLine($@"{errorCount}. Select whether you want to match only the exact phrase, or if it should be a partial match. (Warning: Partial matches can result in odd censoring)");
                errorCount++;
            }

            if(string.IsNullOrWhiteSpace(PunishmentDurationText.Text))
            {
                errorList.AppendLine($@"{errorCount}. Enter a timeout duration (in seconds) that the user should be banned for. (0 is valid.)");
                errorCount++;
            }

            int tryValidate;
            int.TryParse(PunishmentDurationText.Text, out tryValidate);
            if(tryValidate == 0 && PunishmentDurationText.Text != "0")
            {
                errorList.AppendLine($@"{errorCount}. Enter a punishment duration between '0' and '{int.MaxValue}'.");
                errorCount++;
            }

            if(!string.IsNullOrWhiteSpace(errorList.ToString()))
            {
                MessageBox.Show(errorList.ToString(), "Error Saving Ban Phrase");
                return;
            }

            var banPhraseData = new BanPhraseModel();
            banPhraseData.BadPhraseOriginal = BanPhraseKeywordText.Text;
            banPhraseData.BadPhrase = BanPhraseKeywordText.Text.NormalizeForComparison();
            if(CensorRadio.Checked)
            {
                banPhraseData.Response = BanPhraseResponse.Edit;
            }
            if(DeleteRadio.Checked)
            {
                banPhraseData.Response = BanPhraseResponse.Delete;
            }
            // Ban User
            if(BanRadio.Checked)
            {
                banPhraseData.Response = BanPhraseResponse.Ban;
            }

            if(ExactMatchRadio.Checked)
            {
                banPhraseData.CheckType = BanPhraseCheckType.ExactMatch;
            }
            else if(ContainsMatchRadio.Checked)
            {
                banPhraseData.CheckType = BanPhraseCheckType.ContainsMatch;
            }

            banPhraseData.BanPhraseOptions = CurseClient.Models.BanPhraseOptions.None;
            // Common spelling variants
            if(BanPhraseOptions.GetItemCheckState(0).ToString() == "Checked")
            {
                banPhraseData.BanPhraseOptions |= CurseClient.Models.BanPhraseOptions.CheckForCommonSpellingVariants;
            }

            // Log Actions
            if(BanPhraseOptions.GetItemCheckState(1).ToString() == "Checked")
            {
                banPhraseData.BanPhraseOptions |= CurseClient.Models.BanPhraseOptions.LogActionsTaken;
            }

            try
            {
                BanPhraseManager.CreateBanPhrase(banPhraseData);
                BanPhraseManager.SaveBanPhrases();
                RefreshDisplay();
            }
            catch(Exception ex)
            {
                Logging.Log.Error(ex.ToString());
            }
        }

        private void BanPhraseKeywordText_Leave(object sender, EventArgs e)
        {
            NormalizedBanPhraseText.Text = BanPhraseKeywordText.Text.NormalizeForComparison();
        }

        private void RefreshDisplay()
        {
            PopulateBanPhraseDisplayGrid();
        }

        private void LoadBanPhrase_Click(object sender, EventArgs e)
        {
            DialogResult result = OpenFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                try
                {
                    using(var filestream = new FileStream(OpenFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using(var reader = new StreamReader(filestream, Encoding.UTF8))
                        {
                            var data = reader.ReadToEnd();
                            var lines = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                            foreach(var line in lines)
                            {
                                if(!string.IsNullOrWhiteSpace(line))
                                {
                                    var banPhraseData = new BanPhraseModel();
                                    banPhraseData.BadPhraseOriginal = line;
                                    banPhraseData.BadPhrase = line.NormalizeForComparison();
                                    banPhraseData.Response = BanPhraseResponse.Edit;
                                    banPhraseData.CheckType = BanPhraseCheckType.ExactMatch;
                                    banPhraseData.BanPhraseOptions = CurseClient.Models.BanPhraseOptions.None;

                                    try
                                    {
                                        BanPhraseManager.CreateBanPhrase(banPhraseData);
                                        BanPhraseManager.SaveBanPhrases();
                                    }
                                    catch(Exception ex)
                                    {
                                        Logging.Log.Error(ex.ToString());
                                    }
                                }
                            }
                            RefreshDisplay();
                        }
                    }
                }
                catch(Exception ex)
                {
                    Logging.Log.Error(ex.ToString());
                    MessageBox.Show($@"An error occurred while trying to load ban phrases. {ex.Message}");
                }
            }
        }

        private void CreateNewBanPhraseButton_Click(object sender, EventArgs e)
        {
            ResetForm(new BanPhraseModel(), false);
        }

        private void DeleteSelectedBanPhraseButton_Click(object sender, EventArgs e)
        {
            try
            {
                BanPhraseModel phrase = GetCurrentSelectedBanPhrase();
                if(phrase != null && phrase.BadPhrase != null)
                {
                    BanPhraseManager.DeleteBanPhrase(phrase);
                }
                ClearSelectedBanPhrase();
                RefreshDisplay();
            }
            catch(Exception ex)
            {
                Logging.Log.Error(ex.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using QurrexMatch.Lib.Util;
using QurrexMatch.LoadApp.Model;
using QurrexMatch.LoadApp.Utility;

namespace QurrexMatch.LoadApp.Dialogs
{
    public partial class MoneyManagementDialog : Form
    {
        private readonly TradersSettings settings;

        public MoneyManagementDialog()
        {
            InitializeComponent();
            settings = TradersSettings.ReadSettings();
            tbContracts.Text = JsonConvert.SerializeObject(settings.MoneyManagementSets.Tickers, Formatting.Indented);
            cbTradeRandomContract.Checked = settings.MoneyManagementSets.TradeRandomTicker;
            tbFixedContractId.Text = settings.MoneyManagementSets.FixedTickerIndex.ToString();
            tbLotsMin.Text = settings.MoneyManagementSets.LotsMin.ToStringDefault();
            tbLotsMax.Text = settings.MoneyManagementSets.LotsMax.ToStringDefault();

            ControlsValidation.SetupErrorProvider(out tbLotsMinErrorProvider, tbLotsMin);
            ControlsValidation.SetupErrorProvider(out tbLotsMaxErrorProvider, tbLotsMax);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!IsTbLotsMinValid() || !IsTbLotsMaxValid())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            settings.MoneyManagementSets.Tickers = JsonConvert.DeserializeObject<List<Ticker>>(tbContracts.Text);
            settings.MoneyManagementSets.TradeRandomTicker = cbTradeRandomContract.Checked;
            settings.MoneyManagementSets.FixedTickerIndex = tbFixedContractId.Text.ToInt();
            settings.MoneyManagementSets.LotsMin = tbLotsMin.Text.ToInt();
            settings.MoneyManagementSets.LotsMax = tbLotsMax.Text.ToInt();
            settings.SaveSettings();
            DialogResult = DialogResult.OK;
        }

        private void cbTradeRandomContract_CheckedChanged(object sender, EventArgs e)
        {
            tbFixedContractId.Enabled = !cbTradeRandomContract.Checked;
        }

        private void tbLotsMin_Validated(object sender, EventArgs e)
        {
            IsTbLotsMinValid();
        }

        private void tbLotsMax_Validated(object sender, EventArgs e)
        {
            IsTbLotsMaxValid();
        }

        private bool IsTbLotsMinValid()
        {
            return ControlsValidation.TextBoxRangeValidation(tbLotsMin, "order volume: from", tbLotsMinErrorProvider, 1, 10000, typeof(int));
        }

        private bool IsTbLotsMaxValid()
        {
            return ControlsValidation.TextBoxRangeValidation(tbLotsMax, "order volume: to", tbLotsMaxErrorProvider, 1, 10000, typeof(int));
        }
    }
}


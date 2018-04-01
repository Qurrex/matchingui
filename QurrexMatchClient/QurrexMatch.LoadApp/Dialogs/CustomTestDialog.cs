using System;
using System.Windows.Forms;
using QurrexMatch.LoadApp.Model;

namespace QurrexMatch.LoadApp.Dialogs
{
    public partial class CustomTestDialog : Form
    {
        public CustomTestDialog()
        {
            InitializeComponent();
        }

        private void btnLoadSettings_Click(object sender, EventArgs e)
        {
            var sets = TradersSettings.ReadSettings();
            var dlg = new LoadSettingsDialog(sets);
            dlg.ShowDialog();
        }

        private void btnPricingSets_Click(object sender, EventArgs e)
        {
            var sets = TradersSettings.ReadSettings();
            var dlg = new PricingSettingsDialog(sets);
            dlg.ShowDialog();
        }

        private void btnTradingSets_Click(object sender, EventArgs e)
        {
            var sets = TradersSettings.ReadSettings();
            var dlg = new TradingSettingsDialog(sets);
            dlg.ShowDialog();
        }

        private void btnMoneyManagement_Click(object sender, EventArgs e)
        {
            new MoneyManagementDialog().ShowDialog();
        }
    }
}

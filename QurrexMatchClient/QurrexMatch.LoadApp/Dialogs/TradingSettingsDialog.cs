using System;
using System.Windows.Forms;
using QurrexMatch.Lib.Util;
using QurrexMatch.LoadApp.Model;
using QurrexMatch.LoadApp.Utility;

namespace QurrexMatch.LoadApp.Dialogs
{
    public partial class TradingSettingsDialog : Form
    {
        private readonly TradersSettings sets;

        public TradingSettingsDialog()
        {
            InitializeComponent();

            ControlsValidation.SetupErrorProvider(out tbMakersCountErrorProvider, tbMakersCount);
            ControlsValidation.SetupErrorProvider(out tbOneShotCountErrorProvider, tbOneShotCount);
            ControlsValidation.SetupErrorProvider(out tbRandomPercCancelErrorProvider, tbRandomPercCancel);
            ControlsValidation.SetupErrorProvider(out tbRandomPercMassErrorProvider, tbRandomPercMass);
        }

        public TradingSettingsDialog(TradersSettings sets) : this()
        {
            this.sets = sets;

            tbRandomPercNew.Text = sets.TradeSets.ProbOfNewOrder.ToStringDefault();
            tbRandomPercCancel.Text = sets.TradeSets.ProbOfCancelOrder.ToStringDefault();
            int randomPercCancel = 0;
            if(int.TryParse(sets.TradeSets.ProbOfCancelOrder.ToStringDefault(), out randomPercCancel))
                trbRandomPercCancel.Value = randomPercCancel;

            tbRandomPercMass.Text = sets.TradeSets.ProbOfMassCancel.ToStringDefault();
            int randomPercMass = 0;
            if (int.TryParse(sets.TradeSets.ProbOfMassCancel.ToStringDefault(), out randomPercMass))
                trbRandomPercMass.Value = randomPercMass;
            tbErrorReqPerc.Text = sets.TradeSets.ProbErrorRequest.ToStringDefault();
            tbMakersCount.Text = sets.TradeSets.MakersCount.ToStringDefault();
            tbOneShotCount.Text = sets.TradeSets.OneShotTradersCount.ToStringDefault();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!FormValid())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            sets.TradeSets.ProbOfNewOrder = tbRandomPercNew.Text.ToDecimal();
            sets.TradeSets.ProbOfCancelOrder = tbRandomPercCancel.Text.ToDecimal();
            sets.TradeSets.ProbOfMassCancel = tbRandomPercMass.Text.ToDecimal();
            sets.TradeSets.ProbErrorRequest = tbErrorReqPerc.Text.ToDecimal();
            sets.TradeSets.MakersCount = tbMakersCount.Text.ToInt();
            sets.TradeSets.OneShotTradersCount = tbOneShotCount.Text.ToInt();
            sets.SaveSettings();
            DialogResult = DialogResult.OK;
        }

        private bool FormValid()
        {
            var isSumOfOrderCancelAndMassValid = IsSumOfOrderCancelAndMassValid();
            
            var isTbOneShotCountValid = IsTbOneShotCountValid();
            var isTbMakersCountValid = IsTbMakersCountValid();
            var isTbErrorReqPercValid = IsTbErrorReqPercValid();
            
            return isSumOfOrderCancelAndMassValid && isTbOneShotCountValid && isTbMakersCountValid && isTbErrorReqPercValid;
        }

        private void btnSetupStrategies_Click(object sender, EventArgs e)
        {
            new SetupStrategiesDialog(sets).ShowDialog();
        }
        
        private void tbOneShotCount_Validated(object sender, EventArgs e)
        {
            IsTbOneShotCountValid();
        }

        private bool IsTbOneShotCountValid()
        {
            return ControlsValidation.TextBoxRangeValidation(tbOneShotCount, "iterations to skip", tbOneShotCountErrorProvider, 0, 10, typeof(int));
        }

        private bool IsSumOfOrderCancelAndMassValid()
        {
            int randomPercCancel = 0;
            int randomPercMass = 0;

            int.TryParse(tbRandomPercCancel.Text, out randomPercCancel);
            int.TryParse(tbRandomPercMass.Text, out randomPercMass);

            if (randomPercCancel + randomPercMass < 50)
            {
                tbRandomPercCancelErrorProvider.SetError(this.tbRandomPercCancel, String.Empty);
                tbRandomPercMassErrorProvider.SetError(this.tbRandomPercMass, String.Empty);

                return true;
            }

            var message = "Sum of order cancel and order mass cancel should be less then 50";
            tbRandomPercCancelErrorProvider.SetError(this.tbRandomPercCancel, message);
            tbRandomPercMassErrorProvider.SetError(this.tbRandomPercMass, message);
            return false;
        }

        private void tbMakersCount_Validated(object sender, EventArgs e)
        {
            IsTbMakersCountValid();
        }

        private bool IsTbMakersCountValid()
        {
            return ControlsValidation.TextBoxRangeValidation(tbMakersCount, "makers count", tbMakersCountErrorProvider, 0, 10, typeof(int));
        }

        private void trbRandomPercCancel_ValueChanged(object sender, EventArgs e)
        {
            tbRandomPercCancel.Text = trbRandomPercCancel.Value.ToString();
            tbRandomPercNew.Text = (100 - trbRandomPercCancel.Value - trbRandomPercMass.Value).ToString();
        }

        private void trbRandomPercMass_ValueChanged(object sender, EventArgs e)
        {
            tbRandomPercMass.Text = trbRandomPercMass.Value.ToString();
            tbRandomPercNew.Text = (100 - trbRandomPercCancel.Value - trbRandomPercMass.Value).ToString();
        }

        private void tbErrorReqPerc_Validated(object sender, EventArgs e)
        {
            IsTbErrorReqPercValid();
        }

        private bool IsTbErrorReqPercValid()
        {
            return ControlsValidation.TextBoxRangeValidation(tbErrorReqPerc, "percent of errors", tbErrorReqPercErrorProvider, 0, 100, typeof(int));
        }
    }
}

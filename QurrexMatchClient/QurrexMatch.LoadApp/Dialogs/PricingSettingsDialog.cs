using System;
using System.Windows.Forms;
using QurrexMatch.Lib.Util;
using QurrexMatch.LoadApp.Model;
using QurrexMatch.LoadApp.Utility;

namespace QurrexMatch.LoadApp.Dialogs
{
    public partial class PricingSettingsDialog : Form
    {
        private readonly TradersSettings sets;

        public PricingSettingsDialog()
        {
            InitializeComponent();

            ControlsValidation.SetupErrorProvider(out amplitudeErrorProvider, tbAmplitude);
        }

        public PricingSettingsDialog(TradersSettings sets) : this()
        {
            this.sets = sets;

            tbAmplitude.Text = sets.PricingSets.SinusAmplitudePercent.ToStringDefault();
            cbSinusPeriod.Text = sets.PricingSets.SinusPeriodMs.ToStringDefault();
            if (sets.PricingSets.PricingMode == PricingSettingsMode.Fixed)
                rbPriceFixed.Checked = true;
            else if (sets.PricingSets.PricingMode == PricingSettingsMode.Sinusoidal)
                rbPriceSinusoidal.Checked = true;
        }

        private void tbDistrEven_CheckedChanged(object sender, EventArgs e)
        {
            var isSin = rbPriceSinusoidal.Checked;
            panelPriceSinus.Visible = isSin;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rbPriceSinusoidal.Checked && !IsTbAmplitudeValid())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            sets.PricingSets.PricingMode = rbPriceFixed.Checked ? PricingSettingsMode.Fixed
                : /*rbPriceSinusoidal.Checked ? */PricingSettingsMode.Sinusoidal;
            sets.PricingSets.SinusAmplitudePercent = tbAmplitude.Text.ToDecimal();
            sets.PricingSets.SinusPeriodMs = cbSinusPeriod.Text.ToInt();

            sets.SaveSettings();
            DialogResult = DialogResult.OK;
        }

        private void rbPriceFixed_ClientSizeChanged(object sender, EventArgs e)
        {
            panelPriceFixed.Visible = rbPriceFixed.Checked;
            panelPriceSinus.Visible = rbPriceSinusoidal.Checked;
        }

        private void tbAmplitude_Validated(object sender, System.EventArgs e)
        {
            IsTbAmplitudeValid();
        }

        private bool IsTbAmplitudeValid()
        {
            return ControlsValidation.TextBoxRangeValidation(tbAmplitude, "amplitude", amplitudeErrorProvider, 0, 100, typeof(int));
        }
    }
}

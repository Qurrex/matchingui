﻿using System;
using System.Windows.Forms;
using QurrexMatch.Lib.Util;
using QurrexMatch.LoadApp.Model;
using QurrexMatch.LoadApp.Utility;

namespace QurrexMatch.LoadApp.Dialogs
{
    public partial class LoadSettingsDialog : Form
    {
        private readonly TradersSettings sets;

        public LoadSettingsDialog()
        {
            InitializeComponent();

            ControlsValidation.SetupErrorProvider(out tbThreadsCountErrorProvider, tbThreadsCount);
            ControlsValidation.SetupErrorProvider(out tbConnectionsCountErrorProvider, tbConnectionsCount);
            ControlsValidation.SetupErrorProvider(out tbIntervalMsErrorProvider, tbIntervalMs);
            ControlsValidation.SetupErrorProvider(out tbPropOfPlacingOrderErrorProvider, tbPropOfPlacingOrder);
            ControlsValidation.SetupErrorProvider(out tbFadeInPeriodErrorProvider, tbFadeInPeriod);
            ControlsValidation.SetupErrorProvider(out tbPayloadSinusPeriodMsErrorProvider, tbPayloadSinusPeriodMs);
        }

        public LoadSettingsDialog(TradersSettings sets) : this()
        {
            this.sets = sets;
            tbConnectionsCount.Text = sets.PayloadSets.ConnectionsCount.ToString();
            tbIntervalMs.Text = sets.PayloadSets.SleepInterval.ToString();
            tbThreadsCount.Text = sets.PayloadSets.TradersCount.ToString();
            tbPropOfPlacingOrder.Text = sets.PayloadSets.RequestPerIterationProb.ToStringDefault();
            tbPayloadSinusPeriodMs.Text = sets.PayloadSets.SinusoidPeriodMs.ToStringDefault();
            tbFadeInPeriod.Text = sets.PayloadSets.FadingInSeconds.ToStringDefault();
            tbStairsCount.Text = sets.PayloadSets.StepsCount.ToStringDefault();
            tbStairInterval.Text = sets.PayloadSets.SecondsPerStep.ToStringDefault();
            if (sets.PayloadSets.Mode == PayloadSettingsMode.Even)
                tbDistrEven.Checked = true;
            else if (sets.PayloadSets.Mode == PayloadSettingsMode.Sinusoidal)
                tbDistrSinus.Checked = true;
            else if (sets.PayloadSets.Mode == PayloadSettingsMode.FadeIn)
                tbModeFadeIn.Checked = true;
            else if (sets.PayloadSets.Mode == PayloadSettingsMode.Stairs)
                tbModeSteps.Checked = true;
            else
                tbModeStairsDown.Checked = true;
        }

        private void tbDistrEven_CheckedChanged(object sender, EventArgs e)
        {
            panelDistrSinus.Visible = tbDistrSinus.Checked;
            panelFadeIn.Visible = tbModeFadeIn.Checked;
            panelSetsSteps.Visible = tbModeSteps.Checked || tbModeStairsDown.Checked;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!IsTbThreadsCountValid() || !IsTbConnectionsCountValid() || !IsTbIntervalMsValid()
                || !IsTbPropOfPlacingOrderValid() || !IsTbFadeInPeriodValid() || !IsTbPayloadSinusPeriodMsValid())
            {
                DialogResult = DialogResult.None;
                return;
            }

            sets.PayloadSets.ConnectionsCount = Int32.Parse(tbConnectionsCount.Text);
            sets.PayloadSets.SleepInterval = Int32.Parse(tbIntervalMs.Text);
            sets.PayloadSets.TradersCount = Int32.Parse(tbThreadsCount.Text);
            sets.PayloadSets.RequestPerIterationProb = tbPropOfPlacingOrder.Text.ToDecimal();
            sets.PayloadSets.SinusoidPeriodMs = tbPayloadSinusPeriodMs.Text.ToInt();
            sets.PayloadSets.FadingInSeconds = tbFadeInPeriod.Text.ToInt();
            sets.PayloadSets.StepsCount = tbStairsCount.Text.ToInt();
            sets.PayloadSets.SecondsPerStep = tbStairInterval.Text.ToInt();
            sets.PayloadSets.Mode = tbDistrSinus.Checked ? PayloadSettingsMode.Sinusoidal :
                tbModeFadeIn.Checked ? PayloadSettingsMode.FadeIn :
                tbModeSteps.Checked ? PayloadSettingsMode.Stairs :
                tbModeStairsDown.Checked ? PayloadSettingsMode.StairsDown :
                PayloadSettingsMode.Even;
            sets.SaveSettings();
            DialogResult = DialogResult.OK;
        }

        private void tbThreadsCount_Validated(object sender, EventArgs e)
        {
            IsTbThreadsCountValid();
        }

        private bool IsTbThreadsCountValid()
        {
            return ControlsValidation.TexBoxTypeValidation(tbThreadsCount, "threads count", tbThreadsCountErrorProvider, typeof(int));
        }

        private void tbConnectionsCount_Validated(object sender, EventArgs e)
        {
            IsTbConnectionsCountValid();
        }

        private bool IsTbConnectionsCountValid()
        {
            return ControlsValidation.TexBoxTypeValidation(tbConnectionsCount, "connections count", tbConnectionsCountErrorProvider, typeof(int));
        }

        private void tbIntervalMs_Validated(object sender, EventArgs e)
        {
            IsTbIntervalMsValid();
        }

        private bool IsTbIntervalMsValid()
        {
            return ControlsValidation.TexBoxTypeValidation(tbIntervalMs, "interval", tbIntervalMsErrorProvider, typeof(int));
        }

        private void tbPropOfPlacingOrder_Validated(object sender, EventArgs e)
        {
            IsTbPropOfPlacingOrderValid();
        }

        private bool IsTbPropOfPlacingOrderValid()
        {
            return ControlsValidation.TextBoxRangeValidation(tbPropOfPlacingOrder, "prob of placing", tbPropOfPlacingOrderErrorProvider, 0, 100, typeof(int));
        }

        private void tbFadeInPeriod_Validated(object sender, EventArgs e)
        {
            IsTbFadeInPeriodValid();
        }

        private bool IsTbFadeInPeriodValid()
        {
            return ControlsValidation.TexBoxTypeValidation(tbFadeInPeriod, "period", tbFadeInPeriodErrorProvider, typeof(int));
        }

        private void tbPayloadSinusPeriodMs_Validated(object sender, EventArgs e)
        {
            IsTbPayloadSinusPeriodMsValid();
        }

        private bool IsTbPayloadSinusPeriodMsValid()
        {
            return ControlsValidation.TexBoxTypeValidation(tbPayloadSinusPeriodMs, "period", tbPayloadSinusPeriodMsErrorProvider, typeof(int));
        }

        private void LoadSettingsDialog_Load(object sender, EventArgs e)
        {

        }

        private void gbPayloadDistr_Enter(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Windows.Forms;
using QurrexMatch.Lib.Util;
using QurrexMatch.LoadApp.Model;
using QurrexMatch.LoadApp.Utility;

namespace QurrexMatch.LoadApp.Dialogs
{
    public partial class SetupStrategiesDialog : Form
    {
        private readonly TradersSettings settings;

        public SetupStrategiesDialog()
        {
            InitializeComponent();

            ControlsValidation.SetupErrorProvider(out tbShotIterationsErrorProvider, tbShotIterations);
            ControlsValidation.SetupErrorProvider(out tbShotProbOfTakeErrorProvider, tbShotProbOfTake);
            ControlsValidation.SetupErrorProvider(out tbMMOrdersCountErrorProvider, tbMMOrdersCount);
            ControlsValidation.SetupErrorProvider(out tbMMActionIntervalErrorProvider, tbMMActionInterval);
            ControlsValidation.SetupErrorProvider(out tbMMlotsPerOrderErrorProvider, tbMMlotsPerOrder);
        }

        public SetupStrategiesDialog(TradersSettings settings) : this()
        {
            this.settings = settings;
            tbShotIterations.Text = settings.TradeSets.RequestsBeforeGrabTheBook.ToStringDefault();
            tbShotProbOfTake.Text = settings.TradeSets.ProbOfGrabTheBook.ToStringDefault();
            tbMMActionInterval.Text = settings.TradeSets.MilisecondsBeforUpdateMMLevels.ToStringDefault();
            tbMMOrdersCount.Text = settings.TradeSets.MarketLevelsCount.ToStringDefault();
            tbMMlotsPerOrder.Text = settings.TradeSets.MarketMakerOrderLots.ToStringDefault();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!IsTbMMActionIntervalValid() || !IsTbMMOrdersCountValid() ||
                !IsTbShotIterationsValid() || !IsTbShotProbOfTakeValid() ||
                !IsTbMMlotsPerOrderValid())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            settings.TradeSets.RequestsBeforeGrabTheBook = tbShotIterations.Text.ToInt();
            settings.TradeSets.ProbOfGrabTheBook = tbShotProbOfTake.Text.ToDecimal();
            settings.TradeSets.MilisecondsBeforUpdateMMLevels = tbMMActionInterval.Text.ToInt();
            settings.TradeSets.MarketLevelsCount = tbMMOrdersCount.Text.ToInt();
            settings.TradeSets.MarketMakerOrderLots = tbMMlotsPerOrder.Text.ToInt();

            DialogResult = DialogResult.OK;
        }

        private void tbShotIterations_Validated(object sender, EventArgs e)
        {
            IsTbShotIterationsValid();
        }

        private void tbShotProbOfTake_Validated(object sender, EventArgs e)
        {
            IsTbShotProbOfTakeValid();
        }

        private void tbMMOrdersCount_Validated(object sender, EventArgs e)
        {
            IsTbMMOrdersCountValid();
        }

        private void tbMMActionInterval_Validated(object sender, EventArgs e)
        {
            IsTbMMActionIntervalValid();
        }

        private void tbMMlotsPerOrder_Validated(object sender, EventArgs e)
        {
            IsTbMMlotsPerOrderValid();
        }

        private bool IsTbMMlotsPerOrderValid()
        {
            return ControlsValidation.TextBoxRangeValidation(tbMMlotsPerOrder, "lots per order", tbMMlotsPerOrderErrorProvider, 1, 10000, typeof(int));
        }

        private bool IsTbMMOrdersCountValid()
        {
            return ControlsValidation.TextBoxRangeValidation(tbMMOrdersCount, "count of orders", tbMMOrdersCountErrorProvider, 1, 1000, typeof(int));
        }

        private bool IsTbMMActionIntervalValid()
        {
            return ControlsValidation.TextBoxRangeValidation(tbMMActionInterval, "interval, ms, between", tbMMActionIntervalErrorProvider, 1, 10000, typeof(int));
        }

        private bool IsTbShotProbOfTakeValid()
        {
            return ControlsValidation.TextBoxRangeValidation(tbShotProbOfTake, "probability of taking the book", tbShotProbOfTakeErrorProvider, 0, 100, typeof(double));
        }

        private bool IsTbShotIterationsValid()
        {
            return ControlsValidation.TextBoxRangeValidation(tbShotIterations, "iterations to skip", tbShotIterationsErrorProvider, 0, 10000, typeof(int));
        }

        private void tbShotIterations_TextChanged(object sender, EventArgs e)
        {
            int value;
            var parsed = int.TryParse(tbShotIterations.Text, out value);

            if (IsTbShotIterationsValid() && parsed && value != 0)
            {
                tbShotProbOfTake.Enabled = false;
            }
            else
            {
                tbShotProbOfTake.Enabled = true;
            }
        }
    }
}

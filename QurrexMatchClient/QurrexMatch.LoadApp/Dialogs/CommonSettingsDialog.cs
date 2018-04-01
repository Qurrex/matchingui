using System;
using System.Linq;
using System.Windows.Forms;
using QurrexMatch.Lib.Model.Enumerations;
using QurrexMatch.Lib.Util;
using QurrexMatch.LoadApp.Model;
using QurrexMatch.LoadApp.Utility;

namespace QurrexMatch.LoadApp.Dialogs
{
    public partial class CommonSettingsDialog : Form
    {
        private readonly TradersSettings settings;

        public CommonSettingsDialog()
        {
            InitializeComponent();
            settings = TradersSettings.ReadSettings();

            var logTypes = Enum.GetValues(typeof(LoggingLevel)).Cast<object>().ToArray();
            cbLoggingLevel.Items.AddRange(logTypes);
            cbLoggingLevel.SelectedItem = settings.LoggingLevel;
            cbSaveServersStat.Checked = settings.LogServerStatistics;

            tbStatTimeframe.Text = settings.StatisticsTimeframeSeconds.ToStringDefault();
            tbTestDuration.Text = settings.TestDurationSeconds.ToStringDefault();

            ControlsValidation.SetupErrorProvider(out tbStatTimeframeErrorProvider, tbStatTimeframe);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!IsTbStatTimeframeValid())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            settings.StatisticsTimeframeSeconds = tbStatTimeframe.Text.ToInt();
            settings.LoggingLevel = (LoggingLevel) cbLoggingLevel.SelectedItem;
            settings.LogServerStatistics = cbSaveServersStat.Checked;
            settings.TestDurationSeconds = tbTestDuration.Text.ToInt();
            settings.SaveSettings();
            DialogResult = DialogResult.OK;
        }

        private void tbStatTimeframe_Validated(object sender, EventArgs e)
        {
            IsTbStatTimeframeValid();
        }

        private bool IsTbStatTimeframeValid()
        {
            return ControlsValidation.TextBoxRangeValidation(tbStatTimeframe, "charts timeframe", tbStatTimeframeErrorProvider, 1, 600, typeof(int));
        }
    }
}

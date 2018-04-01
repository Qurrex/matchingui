using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QurrexMatch.LoadApp.Dialogs;
using QurrexMatch.LoadApp.Model;
using QurrexMatch.LoadApp.Model.Presets;
using QurrexMatch.LoadApp.Model.ProcessingStatistics;

namespace QurrexMatch.LoadApp
{
    public partial class LoadTestForm : Form
    {
        /// <summary>
        /// the object used to conduct a load testing session
        /// </summary>
        private TraderPool pool;

        /// <summary>
        /// when the log is too long it is truncated
        /// </summary>
        private int logLinesCount;

        /// <summary>
        /// predefined test scenarios' buttons
        /// </summary>
        private List<Button> presetButtons;

        public LoadTestForm()
        {
            InitializeComponent();
            SetupPresets();
        }

        /// <summary>
        /// append some text to the log window in a thread-safe manner
        /// </summary>
        private void LogSafe(string msg)
        {
            var appendFlag = true;
            logLinesCount++;
            if (logLinesCount > 100)
            {
                logLinesCount = 0;
                appendFlag = false;
            }
            try
            {
                BeginInvoke(new Action<string>(s =>
                {
                    var text = $"[{DateTime.Now:HH:mm:ss.fff}] " + s + Environment.NewLine;
                    if (appendFlag)
                        tbLog.AppendText(text);
                    else
                        tbLog.Text = text;
                }), msg);
            }
            catch (InvalidOperationException)
            { // the form is closing - do nothing
            }
        }

        /// <summary>
        /// show the connection's settings dialog
        /// and apply the settings provided by the user
        /// </summary>
        private void btnSetupConnection_Click(object sender, EventArgs e)
        {
            if (pool != null) return;
            var sets = TradersSettings.ReadSettings();
            var dlg = new ConnectionSettingsDialog
            {
                MatchingURI = sets.Uri,
                StatusURI = sets.StatUri
            };
            dlg.ShowDialog();
            if (dlg.DialogResult != DialogResult.OK) return;
            sets.Uri = dlg.MatchingURI;
            sets.StatUri = dlg.StatusURI;
            sets.SaveSettings();
        }

        /// <summary>
        /// shows test's common settings dialog
        /// </summary>
        private void btnCommonSets_Click(object sender, EventArgs e)
        {
            if (pool != null) return;
            new CommonSettingsDialog().ShowDialog();
        }

        /// <summary>
        /// handle tab's changing
        /// re-read the reports combobox
        /// </summary>
        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabPageReport)
                InitReportsPicker();
        }

        /// <summary>
        /// fill the reports combobox items
        /// </summary>
        private void InitReportsPicker()
        {
            var times = TestReportBuilder.ReadReportsTimes();
            cbReports.Items.Clear();
            cbReports.Items.AddRange(times.Cast<object>().ToArray());
            if (cbReports.Items.Count > 0)
                cbReports.SelectedIndex = 0;
        }

        /// <summary>
        /// open selected report in the default browser
        /// </summary>
        private void btnOpenReport_Click(object sender, EventArgs e)
        {
            if (cbReports.SelectedIndex < 0) return;
            var time = (DateTime) cbReports.SelectedItem;
            TestReportBuilder.OpenReport(time);
        }

        /// <summary>
        /// set up predefined test scenarios' buttons
        /// </summary>
        private void SetupPresets()
        {
            var defSets = TradersSettings.ReadSettings();
            SettingsPreset.Presets = new SettingsPreset[]
            {
                new TakerPoolPreset(defSets),
                new MakerTakerEven(defSets),
                new SimpleFadeInPreset(defSets),
                new OneShotPreset(defSets),
                new SinusoidalPreset(defSets),
                new SlowLoadGrowthPreset(defSets),
                new StairsPreset(defSets),
                new StairsDownPreset(defSets)
            };

            presetButtons = new List<Button>
            {
                btnPreset01, btnPreset02, btnPreset03, btnPreset04, btnPreset05, btnPreset06, btnPreset07, btnPreset08
            };

            for (var i = 0; i < presetButtons.Count; i++)
            {
                var preset = SettingsPreset.Presets[i];
                presetButtons[i].Tag = i;
                presetButtons[i].ImageIndex = preset.ImageIndex;
                toolTip.SetToolTip(presetButtons[i], preset.Description);

                // setup and run the test on the button's click
                presetButtons[i].Click += (sender, args) =>
                {
                    if (pool != null) return;
                    var presetIndex = (int) ((Button) sender).Tag;
                    var dlg = new PresetDialog(SettingsPreset.GetPresetByIndex(presetIndex));
                    if (dlg.ShowDialog() != DialogResult.OK) return;
                    StartTest();
                };
            }

            toolTip.SetToolTip(btnStop, "Stop the test");
            toolTip.SetToolTip(btnManTest, "Manually set up and start a test");
        }

        /// <summary>
        /// perform a test set up without using one of the predefined scenarios
        /// </summary>
        private void btnManualTest_Click(object sender, EventArgs e)
        {
            // pool (testing object) is already created - stop the test
            if (pool != null)
                return;

            if (new CustomTestDialog().ShowDialog() != DialogResult.OK) return;
            StartTest();
        }

        /// <summary>
        /// start a test (in a number of separate threads)
        /// </summary>
        private void StartTest()
        {
            // create the pool object and start the test
            pool = new TraderPool(LogSafe, OnConnected);
            pool.Start(OnPoolStop);
            lblConnectionStatus.Text = "connecting...";
            lblConnectionStatus.Visible = true;
            btnStop.Enabled = true;
        }

        /// <summary>
        /// update the connection status label
        /// </summary>
        private void OnConnected()
        {
            BeginInvoke(new Action(() =>
            {
                lblConnectionStatus.Text = "connected";
            }));
        }

        /// <summary>
        /// stop the test (if there is a test in progress)
        /// </summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (pool == null) return;
            pool.Stop();
        }

        /// <summary>
        /// handle the test's finish
        /// </summary>
        private void OnPoolStop()
        {
            LogSafe("Stopping...");
            Invoke(new Action(() =>
            {
                TestReportBuilder.BuildReport(pool);
                pool = null;
                btnStop.Enabled = false;
                lblConnectionStatus.Visible = false;
            }));
            LogSafe("Stopped");
        }
    }
}

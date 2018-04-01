using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QurrexMatch.LoadApp.Model.Presets;

namespace QurrexMatch.LoadApp.Dialogs
{
    public partial class PresetDialog : Form
    {
        private readonly SettingsPreset preset;

        public PresetDialog()
        {
            InitializeComponent();
        }

        public PresetDialog(SettingsPreset preset) : this()
        {
            this.preset = preset;
            ApplyPreset();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var sets = preset.Build(tbPayload.Value);
            sets.SaveSettings();
            DialogResult = DialogResult.OK;
        }

        private void ApplyPreset()
        {
            tbDescription.Text = preset.Description;
            Text = preset.Title;
            UpdateGuiOnScroll();
        }

        private void tbPayload_Scroll(object sender, EventArgs e)
        {
            UpdateGuiOnScroll();
        }

        private void UpdateGuiOnScroll()
        {
            var desc = preset.MakeDescription(tbPayload.Value);
            tbPayloadHint.Text = desc;
            var colors = Enumerable.Range(0, 10).Select(i => Color.FromArgb(i * 15, 0, 0)).ToList();
            tbPayloadHint.ForeColor = colors[tbPayload.Value - 1];
        }
    }
}

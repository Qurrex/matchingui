using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QurrexMatch.LoadApp.Utility;

namespace QurrexMatch.LoadApp.Dialogs
{
    public partial class ConnectionSettingsDialog : Form
    {
        public string MatchingURI
        {
            get => tbUri.Text;
            set => tbUri.Text = value;
        }

        public string StatusURI
        {
            get => tbServerStatusURI.Text;
            set => tbServerStatusURI.Text = value;
        }

        public ConnectionSettingsDialog()
        {
            InitializeComponent();
        }

        private void tbUri_Validated(object sender, System.EventArgs e)
        {
            uriErrorProvider.SetError(tbUri, BothUrisValid() ? String.Empty : "Wrong URI format");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!BothUrisValid())
                DialogResult = DialogResult.None;
        }

        private bool BothUrisValid()
        {
            return CheckUriValid(tbUri.Text)/* && CheckUriValid(tbServerStatusURI.Text)*/;
        }

        private bool CheckUriValid(string uri)
        {
            var uriReg = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}:\d{1,5}$");
            return uriReg.IsMatch(uri);
        }
    }
}

using System;
using System.Linq;
using System.Windows.Forms;
using QurrexMatch.Lib.Model;
using QurrexMatch.Lib.Model.Enumerations;
using QurrexMatch.Lib.Model.QurrexConnection;
using QurrexMatch.Lib.Model.Request;

namespace QurrexMatchClient
{
    public partial class MainForm : Form
    {
        private AppSets sets;

        private Connection connection;

        public MainForm()
        {
            InitializeComponent();
        }

        private void LogSafe(string msg)
        {
            BeginInvoke(new Action<string>(s => tbLog.AppendText($"[{DateTime.Now:HH:mm:ss.fff}] " + s + Environment.NewLine)), msg);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            sets = AppSets.ReadSettingsFromFile() ?? new AppSets
            {
                uri = tbUri.Text
            };
            tbUri.Text = sets.uri;

            FillListCombo(typeof(OrderSide), cbSide);
            FillListCombo(typeof(OrderSide), cbCancelSide);
            FillListCombo(typeof(OrderType), cbType);
            FillListCombo(typeof(TimeInForce), cbTimeInForce);
            FillListCombo(typeof(AutoCancel), cbAutoCancel);
            FillListCombo(typeof(MassCancelMode), cbMassCancelMode);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (connection == null)
            {
                sets.uri = tbUri.Text;
                connection = new Connection(sets.uri, new Logger(LogSafe, LoggingLevel.Error), 0);
                connection.Open();
                btnConnect.Text = "Disconnect";
                return;
            }

            connection.Close();
            connection = null;
            btnConnect.Text = "Connect";
        }

        private void btnSendOrderReq_Click(object sender, EventArgs e)
        {
            if (connection == null) return;
            var id1 = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            LogSafe($"Sending a new order request");
            connection.SendRequest(new OrderRequest
            {
                Amount = int.Parse(tbAmount.Text),
                Price = long.Parse(tbPrice.Text),
                Comment = tbComment.Text,
                AutoCancel = (AutoCancel) cbAutoCancel.SelectedItem,
                OrderType = (OrderType) cbType.SelectedItem,
                OrderSide = (OrderSide) cbSide.SelectedItem,
                TimeInForce = (TimeInForce) cbTimeInForce.SelectedItem,
                InstrumentId = int.Parse(tbInstrument.Text),
                ClearingAccountId = tbClearingAcc.Text,
                TraderAccountId = tbTradingApp.Text,
                Flags = ulong.Parse(tbFlags.Text),
                RequestId = id1
            });
        }

        private void btnSendOrderCancel_Click(object sender, EventArgs e)
        {
            if (connection == null) return;
            var id1 = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            LogSafe($"Sending a cancel order request");
            connection.SendRequest(new CancelOrderRequest
            {
                OrderSide = (OrderSide)cbCancelSide.SelectedItem,
                InstrumentId = int.Parse(tbCancelInstr.Text),
                ClearingAccountId = tbCancelClearing.Text,
                TraderAccountId = tbCancelTrading.Text,
                RequestId = id1,
                ExchangeOrderId = long.Parse(tbCancelExOrdId.Text),
                OriginRequestId = tbCancelOriginReq.Text
            });
        }

        private static void FillListCombo(Type t, ComboBox box)
        {
            box.Items.AddRange(Enum.GetValues(t).Cast<object>().ToArray());
            box.SelectedIndex = 0;
        }

        private void btnSendMassCancel_Click(object sender, EventArgs e)
        {
            if (connection == null) return;
            var id1 = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            LogSafe($"Sending a mass cancel order request");
            connection.SendRequest(new MassCancelRequest
            {
                InstrumentId = int.Parse(tbMassInstrumentId.Text),
                ClearingAccountId = tbMassClearingAccount.Text,
                TraderAccountId = tbMassTradingAccount.Text,
                RequestId = id1,
                CancelMode = (MassCancelMode) cbMassCancelMode.SelectedItem
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.Threading;

namespace DRRMIS_GSM_Client
{
    public partial class SerialMonitorForm : Form
    {
        MainForm frmMain;

        string dataReceived = string.Empty;
        private delegate void SetTextDeleg(string text);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public SerialMonitorForm() {
            InitializeComponent();
        }

        public MainForm MainForm {
            get { return frmMain; }
            set { frmMain = value; }
        }

        public string SerialMonitorFeedback {
            get { return txtFeedback.Text; }
            set {
                this.BeginInvoke(new SetTextDeleg(DataReceived), new object[] { value });
            }
        }

        private void DataReceived(string data)  {
            dataReceived = data.Trim();
            txtFeedback.AppendText(dataReceived + "\r\n");
        }

        private void btnWriteSerial_Click(object sender, EventArgs e) {
            frmMain.comPort.WriteLine(txtSerialWrite.Text);
            txtSerialWrite.Text = string.Empty;
        }

        private void txtSerialWrite_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char) Keys.Enter) {
                frmMain.comPort.WriteLine(txtSerialWrite.Text);
                txtSerialWrite.Text = string.Empty;
            }
        }

        private void SerialMonitorForm_VisibleChanged(object sender, EventArgs e) {
            this.CenterToScreen();
        }

        private void SerialMonitorForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            this.Visible = false;
        }

        private void toolStripMain_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Visible = false;
        }

        private void btnClearFeedback_Click(object sender, EventArgs e) {
            txtFeedback.Text = string.Empty;
        }
    }
}

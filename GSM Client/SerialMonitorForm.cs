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
        private static MainForm frmMain;

        string dataReceived = string.Empty;
        private delegate void SetTextDeleg(string text);
        AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();

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
            txtFeedback.AppendText(data);
        }

        private string GetAppendLineEnding() {
            string lineEnding = toolStripSelLineEnding.SelectedItem.ToString();
            string appendLineEnding;

            switch (lineEnding) {
                case "No line ending":
                    appendLineEnding = "";
                    break;
                case "Newline":
                    appendLineEnding = "\n";
                    break;
                case "Carriage return":
                    appendLineEnding = "\r";
                    break;
                case "Both NL & CR":
                    appendLineEnding = "\r\n";
                    break;
                default:
                    appendLineEnding = "";
                    break;
            }

            return appendLineEnding;
        }


        /* Serial monitor form
         */

        private void SerialMonitorForm_VisibleChanged(object sender, EventArgs e) {
            txtSerialWrite.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSerialWrite.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSerialWrite.AutoCompleteCustomSource = autoComplete;

            this.CenterToScreen();
            txtSerialWrite.Text = string.Empty;
            txtFeedback.Text = string.Empty;
            toolStripSelLineEnding.SelectedItem = "Newline";
        }

        private void SerialMonitorForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            this.Visible = false;
        }



        /* Serial monitor components
         */

        private void TxtSerialWrite_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                frmMain.comPort.Write(txtSerialWrite.Text + GetAppendLineEnding());
                autoComplete.Add(txtSerialWrite.Text);
                txtSerialWrite.Text = string.Empty;
            }
        }

        private void BtnWriteSerial_Click(object sender, EventArgs e) {
            frmMain.comPort.Write(txtSerialWrite.Text + GetAppendLineEnding());
            autoComplete.Add(txtSerialWrite.Text);
            txtSerialWrite.Text = string.Empty;
        }

        private void BtnClearFeedback_Click(object sender, EventArgs e) {
            txtFeedback.Text = string.Empty;
        }


        /* Main tool strip menu
         */

        private void ToolStripMain_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BtnMinimize_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnClose_Click(object sender, EventArgs e) {
            this.Visible = false;
        }
    }
}

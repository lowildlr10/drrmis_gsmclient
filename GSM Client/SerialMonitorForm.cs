using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace GSM_Client
{
    public partial class SerialMonitorForm : Form
    {
        string dataReceived = string.Empty;
        private delegate void SetTextDeleg(string text);

        MainForm frmMain;

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

        private void SerialMonitorForm_Load(object sender, EventArgs e) {
            //frmMain.comPort.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
        }

        /*
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            try {
                Thread.Sleep(100);
                //string receivedChar = Convert.ToChar(frmMain.comPort.ReadChar()).ToString();
                string dataReceived = frmMain.comPort.ReadLine();
                this.BeginInvoke(new SetTextDeleg(DataReceived), new object[] { dataReceived });
            } catch {
            }
        }*/

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

        private void btnClearFeedback_Click(object sender, EventArgs e) {
            txtFeedback.Text = string.Empty;
        }

        private void SerialMonitorForm_VisibleChanged(object sender, EventArgs e) {
            this.CenterToScreen();
        }

        private void SerialMonitorForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            this.Visible = false;
        }
    }
}

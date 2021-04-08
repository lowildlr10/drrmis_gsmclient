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

namespace GSM_Client
{
    public partial class MainForm : Form
    {
        SelectSerialForm frmSelectSerial;
        SerialMonitorForm frmSerialMonitor;
        AboutBoxForm frmAboutBox;

        public string PortName {
            get { return comPort.PortName; }
            set { comPort.PortName = value; }
        }

        public int BaudRate {
            get { return comPort.BaudRate; }
            set { comPort.BaudRate = value; }
        }

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            refreshDisplays();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            disconnectCOM();
        }

        private void btnConnectSerial_Click(object sender, EventArgs e) {
            connectCOM();
        }

        private void toolStripMenuConnect_Click(object sender, EventArgs e) {
            connectCOM();
        }

        private void btnDisconnectSerial_Click(object sender, EventArgs e) {
            disconnectCOM();
        }

        private void toolStripMenuDisconnect_Click(object sender, EventArgs e) {
            disconnectCOM();
        }

        private void btnSettings_Click(object sender, EventArgs e) {
            frmSelectSerial = new SelectSerialForm();
            frmSelectSerial.MainForm = this;
            frmSelectSerial.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            frmAboutBox = new AboutBoxForm();
            frmAboutBox.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            exitApplication();
        }

        public void connectCOM() {
            if (!comPort.IsOpen) {
                try {
                    comPort.Open();
                    comPort.WriteLine("3");
                    comPort.WriteLine("5");
                    comPort.WriteLine("6");
                   
                    toolStripMenuConnect.Visible = false;
                    toolStripMenuDisconnect.Visible = true;
                    btnConnectSerial.Visible = false;
                    btnDisconnectSerial.Visible = true;
                    btnSerialMonitor.Visible = true;
                    btnSettings.Enabled = false;
                    btnSend.Enabled = true;
                    serialMonitorToolStripMenuItem.Enabled = true;

                    MessageBox.Show(comPort.PortName +
                                    " is now connected with a baud rate of '" +
                                    comPort.BaudRate + "'.");

                    lblStatus.Text = "Connected";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    toolStripStatusLabel.Text = "Connected";
                    toolStripIconConnected.Visible = true;
                    toolStripIconDisconnected.Visible = false;
                } catch (Exception) {
                    MessageBox.Show("Invalid parameters.");
                }
            } else {
                disconnectCOM();
            }
        }

        private void disconnectCOM() {
            if (comPort.IsOpen) {
                try {
                    comPort.Close();

                    toolStripMenuConnect.Visible = true;
                    toolStripMenuDisconnect.Visible = false;
                    btnConnectSerial.Visible = true;
                    btnDisconnectSerial.Visible = false;
                    btnSerialMonitor.Visible = false;
                    btnSettings.Enabled = true;
                    btnSend.Enabled = false;
                    serialMonitorToolStripMenuItem.Enabled = false;

                    MessageBox.Show(comPort.PortName + " is now disconnected.");

                    lblStatus.Text = "Disconnected";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    toolStripStatusLabel.Text = "Disconnected";
                    toolStripIconConnected.Visible = false;
                    toolStripIconDisconnected.Visible = true;
                } catch (Exception) {
                }
            } else {
                //disconnectCOM();
            }
        }

        private void exitApplication() {
            if (System.Windows.Forms.Application.MessageLoop) {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            } else {
                // Console app
                System.Environment.Exit(1);
            }
        }

        public void refreshDisplays() {
            string serialStatus = "Disconnected";
            string portName = !string.IsNullOrEmpty(comPort.PortName.Trim()) ? 
                               comPort.PortName : "N/A";
            int baudRate = comPort.BaudRate;

            lblStatus.Text = serialStatus;
            lblPortName.Text = portName;
            lblBaudRate.Text = baudRate.ToString();
        }

        private void btnSerialMonitor_Click(object sender, EventArgs e) {
            SerialMonitorForm frmSerialMonitor = new SerialMonitorForm();
            frmSerialMonitor.Show();
        }

        private void serialMonitorToolStripMenuItem_Click(object sender, EventArgs e) {
            SerialMonitorForm frmSerialMonitor = new SerialMonitorForm();
            frmSerialMonitor.Show();
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

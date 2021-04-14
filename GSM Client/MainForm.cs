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
        RecipientForm frmRecipient;
        SelectSerialForm frmSelectSerial;
        SerialMonitorForm frmSerialMonitor;
        AboutBoxForm frmAboutBox;

        private delegate void _ConnectSerialPort();
        private delegate void _DisconnectSerialPort();
        private delegate void _SendMessage(string[] recipients, string message);
        private bool isLoading = true;

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
            RefreshDisplays();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            DisconnectSerialPort();
        }

        private void btnConnectSerial_Click(object sender, EventArgs e) {
            this.BeginInvoke(new _ConnectSerialPort(ConnectSerialPort), new object[] { });
        }

        private void toolStripMenuConnect_Click(object sender, EventArgs e) {
            this.BeginInvoke(new _ConnectSerialPort(ConnectSerialPort), new object[] { });
        }

        private void btnDisconnectSerial_Click(object sender, EventArgs e) {
            this.BeginInvoke(new _DisconnectSerialPort(DisconnectSerialPort), new object[] { });
        }

        private void toolStripMenuDisconnect_Click(object sender, EventArgs e) {
            this.BeginInvoke(new _DisconnectSerialPort(DisconnectSerialPort), new object[] { });
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
            ExitApplication();
        }

        public void ConnectSerialPort() {
            isLoading = true;
            
            if (!comPort.IsOpen) {
                try {
                    while (!comPort.IsOpen) {
                        lblStatus.ForeColor = System.Drawing.Color.Black;
                        lblStatus.Text = "Connecting...";
                        toolStripStatusLabel.Text = "Connecting...";
                        toolStripIconLoading.Visible = true;
                        toolStripIconConnected.Visible = false;
                        toolStripIconDisconnected.Visible = false;

                        comPort.Open();
                    }

                    MessageBox.Show(comPort.PortName +
                                    " is now connected with a baud rate of '" +
                                    comPort.BaudRate + "'.", "Success!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception) {
                    MessageBox.Show("Invalid parameters.", "Warning!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } else {
                DisconnectSerialPort();
            }

            timerMonitorPort.Enabled = true;
            isLoading = false;
        }

        private void DisconnectSerialPort() {
            isLoading = true;

            if (comPort.IsOpen) {
                try {
                    while (comPort.IsOpen) {
                        lblStatus.ForeColor = System.Drawing.Color.Black;
                        lblStatus.Text = "Disconnecting...";
                        toolStripStatusLabel.Text = "Disconnecting...";
                        toolStripIconLoading.Visible = true;
                        toolStripIconConnected.Visible = false;
                        toolStripIconDisconnected.Visible = false;

                        comPort.Close();
                    }

                    MessageBox.Show(comPort.PortName + " is now disconnected.", "Success!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception) {
                    MessageBox.Show("Unknown error has occured. Try again.", "Failed!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            timerMonitorPort.Enabled = false;
            isLoading = false;
        }

        private void ExitApplication() {
            if (System.Windows.Forms.Application.MessageLoop) {
                System.Windows.Forms.Application.Exit();
            } else {
                System.Environment.Exit(1);
            }
        }

        public void RefreshDisplays() {
            bool isPortConnected = comPort.IsOpen ? true : false;
            string serialStatus = isPortConnected ? "Connected" : "Disconnected";
            var serialStatusColor = isPortConnected ? System.Drawing.Color.Green : 
                                    System.Drawing.Color.Red;
            string portName = !string.IsNullOrEmpty(comPort.PortName.Trim()) ? 
                               comPort.PortName : "N/A";
            int baudRate = comPort.BaudRate;
            int recipientCount = selRecipients.Items.Count;
            int messageCount = txtMessage.Text.Trim().Length;

            if (!isLoading) {
                toolStripMenuConnect.Visible = isPortConnected ? false : true;
                toolStripMenuDisconnect.Visible = isPortConnected ? true : false;
                settingsToolStripMenuItem.Enabled = isPortConnected ? false : true;
                serialMonitorToolStripMenuItem.Enabled = isPortConnected ? true : false;

                btnConnectSerial.Visible = isPortConnected ? false : true;
                btnDisconnectSerial.Visible = isPortConnected ? true : false;
                btnRecipients.Enabled = isPortConnected ? true : false;
                btnSerialMonitor.Visible = isPortConnected ? true : false;
                btnSettings.Enabled = isPortConnected ? false : true;

                lblStatus.ForeColor = isPortConnected ? System.Drawing.Color.Green : 
                                      System.Drawing.Color.Red;
                lblStatus.Text = isPortConnected ? "Connected" : "Disconnected";

                toolStripStatusLabel.Text = isPortConnected ? "Connected" : "Disconnected";
                toolStripIconLoading.Visible = false;
                toolStripIconConnected.Visible = isPortConnected ? true : false;
                toolStripIconDisconnected.Visible = isPortConnected ? false : true;

                lblPortName.Text = portName;
                lblBaudRate.Text = baudRate.ToString();

                if (recipientCount > 1 && messageCount > 0) {
                    btnSend.Enabled = true;
                } else {
                    btnSend.Enabled = false;
                }

                if (btnRecipients.Enabled == true) {
                    lblRecipientsCount.Cursor = Cursors.Hand;
                } else {
                    lblRecipientsCount.Cursor = Cursors.Default;
                }

                lblRecipientsCount.Text = "Recipients Count: " + recipientCount.ToString();
                lblMsgCount.Text = "Message Characters: " + messageCount.ToString();
            }
        }

        private void btnSerialMonitor_Click(object sender, EventArgs e) {
            frmSerialMonitor = new SerialMonitorForm();
            frmSerialMonitor.MainForm = this;
            frmSerialMonitor.Show();
        }

        private void serialMonitorToolStripMenuItem_Click(object sender, EventArgs e) {
            frmSerialMonitor = new SerialMonitorForm();
            frmSerialMonitor.MainForm = this;
            frmSerialMonitor.Show();
        }

        private void timerMonitorPort_Tick(object sender, EventArgs e) {
            if (!comPort.IsOpen) {
                timerMonitorPort.Enabled = false;
                DisconnectSerialPort();
            }

            RefreshDisplays();
        }

        private void btnRecipients_Click(object sender, EventArgs e) {
            frmRecipient = new RecipientForm();
            frmRecipient.MainForm = this;
            frmRecipient.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            frmSelectSerial = new SelectSerialForm();
            frmSelectSerial.MainForm = this;
            frmSelectSerial.ShowDialog();
        }

        private void SendMessage(string[] recipients, string message) {
            if (comPort.IsOpen) {
                foreach (string phoneNo in recipients) {
                    
                }
                comPort.WriteLine(message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e) {
            var recipients = selRecipients.Items;
            int recipientCount = selRecipients.Items.Count;
            String message = txtMessage.Text;
            int selectedIndex = int.Parse(selRecipients.SelectedIndex.ToString());

            if (recipientCount > 1) {
                if (selectedIndex == 0) {
                    this.BeginInvoke(new _SendMessage(SendMessage), 
                                     new object[] { recipients, message });
                    
                } else {
                    var phoneNo = selRecipients.SelectedItem;
                    string[] phoneNos = { phoneNo.ToString().Trim() };

                    this.BeginInvoke(new _SendMessage(SendMessage),
                                     new object[] { phoneNos, message });
                }
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e) {
            int messageCount = txtMessage.Text.Trim().Length;
            lblMsgCount.Text = "Message Characters: " + messageCount.ToString();
        }

        private void lblRecipientsCount_Click(object sender, EventArgs e) {
            if (btnRecipients.Enabled == true) {
                frmRecipient = new RecipientForm();
                frmRecipient.MainForm = this;
                frmRecipient.ShowDialog();
            }
        }
    }
}

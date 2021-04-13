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
            timerMonitorPort.Enabled = false;
            disconnectCOM();
        }

        private void btnConnectSerial_Click(object sender, EventArgs e) {
            connectCOM();
        }

        private void toolStripMenuConnect_Click(object sender, EventArgs e) {
            connectCOM();
        }

        private void btnDisconnectSerial_Click(object sender, EventArgs e) {
            timerMonitorPort.Enabled = false;
            disconnectCOM();
        }

        private void toolStripMenuDisconnect_Click(object sender, EventArgs e) {
            timerMonitorPort.Enabled = false;
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

                    timerMonitorPort.Enabled = true;

                    toolStripMenuConnect.Visible = false;
                    toolStripMenuDisconnect.Visible = true;
                    settingsToolStripMenuItem.Enabled = false;
                    btnConnectSerial.Visible = false;
                    btnDisconnectSerial.Visible = true;
                    btnSerialMonitor.Visible = true;
                    btnSettings.Enabled = false;
                    btnRecipients.Enabled = true;
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
            if (!string.IsNullOrEmpty(comPort.PortName) &&
                !string.IsNullOrWhiteSpace(comPort.PortName) &&
                comPort.PortName != "N/A" &&
                comPort.IsOpen)
            {
                MessageBox.Show(comPort.PortName + " is now disconnected.");
            }

            if (comPort.IsOpen) {
                try {
                    comPort.Close();
                } catch (Exception) {
                }
            }

            toolStripMenuConnect.Visible = true;
            toolStripMenuDisconnect.Visible = false;
            settingsToolStripMenuItem.Enabled = true;
            btnConnectSerial.Visible = true;
            btnDisconnectSerial.Visible = false;
            btnSerialMonitor.Visible = false;
            btnSettings.Enabled = true;
            btnSend.Enabled = false;
            btnRecipients.Enabled = false;
            serialMonitorToolStripMenuItem.Enabled = false;

            lblStatus.Text = "Disconnected";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            toolStripStatusLabel.Text = "Disconnected";
            toolStripIconConnected.Visible = false;
            toolStripIconDisconnected.Visible = true;
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
            string serialStatus = comPort.IsOpen ? "Connected" : "Disconnected";
            string portName = !string.IsNullOrEmpty(comPort.PortName.Trim()) ? 
                               comPort.PortName : "N/A";
            int baudRate = comPort.BaudRate;
            int recipientCount = selRecipients.Items.Count;
            int messageCount = txtMessage.Text.Trim().Length;

            lblStatus.Text = serialStatus;
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
                disconnectCOM();
            }
            refreshDisplays();
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

        private void sendMessage(string phoneNo, string message) {
            if (comPort.IsOpen) {
                comPort.WriteLine(message);
                //MessageBox.Show(comPort.ReadLine());
            }
        }

        private void btnSend_Click(object sender, EventArgs e) {
            var recipients = selRecipients.Items;
            int recipientCount = selRecipients.Items.Count;
            String message = txtMessage.Text;
            int selectedIndex = int.Parse(selRecipients.SelectedIndex.ToString());

            if (recipientCount > 1) {
                if (selectedIndex == 0) {
                    foreach (string phoneNo in recipients) {
                        sendMessage(phoneNo.Trim(), message);
                    }
                } else {
                    var phoneNo = selRecipients.SelectedItem;
                    sendMessage(phoneNo.ToString().Trim(), message);
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

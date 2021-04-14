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
    public partial class MainForm : Form
    {
        RecipientForm frmRecipient;
        SelectSerialForm frmSelectSerial;
        SerialMonitorForm frmSerialMonitor;
        AboutBoxForm frmAboutBox;

        private delegate void _ConnectSerialPort();
        private delegate void _DisconnectSerialPort();
        private delegate void _SendMessage(string[] recipients, string message);
        private delegate void _InitGSM(string data);
        private delegate void _GetSignalStrength(string data);
        private bool isLoading = true;
        private bool isInitGSM = false;
        private bool isSignalAwait = true;
        private bool isSending = false;
        private bool isSendingProcess = false;
        private List<string> sendMessageLogs;

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
                        comPort.WriteLine("get_gsm_stat|");
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
            isInitGSM = false;

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
            string gsmStatus = isInitGSM ? "Connected" : "Disconnected";
            var gsmStatusColor = isInitGSM ? System.Drawing.Color.Green :
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
                lblStatusGSM.ForeColor = gsmStatusColor;
                lblStatusGSM.Text = gsmStatus;

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
                timerRefreshSignal.Enabled = isInitGSM ? true : false;
                lblSignalStrength.Text = !isInitGSM ? "0%" : lblSignalStrength.Text;
                
                if (isSendingProcess) {
                    toolStripStatusLabel.Text = "Sending...";
                    toolStripIconLoading.Visible = true;
                    toolStripIconConnected.Visible = false;
                    toolStripIconDisconnected.Visible = false;

                    btnSend.Enabled = false;
                    txtMessage.Text = string.Empty;
                    txtMessage.Enabled = false;
                } else {
                    txtMessage.Enabled = true;
                }
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
                isLoading = true;
                isSendingProcess = true;

                foreach (string phoneNo in recipients) {
                    string cmd = "send_msg|" + phoneNo.ToString().Trim() + ":" + message;
                    isSending = true;
                    comPort.WriteLine(cmd);

                    
                }

                //sendMessageLogs.Clear();
                isSendingProcess = false;
                isLoading = false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e) {
            string[] recipients = new string[selRecipients.Items.Count];
            int recipientCount = selRecipients.Items.Count;
            String message = txtMessage.Text;
            int selectedIndex = int.Parse(selRecipients.SelectedIndex.ToString());

            for (int key = 0; key < selRecipients.Items.Count; key++)  {
                recipients[key] = selRecipients.Items[key].ToString();
            }

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

        private void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            try {
                Thread.Sleep(300);
                string dataReceived = comPort.ReadLine();

                if (dataReceived.Trim().Contains("signal_str:")) {
                    this.BeginInvoke(new _GetSignalStrength(GetSignalStrength), new object[] { dataReceived });
                } else if (dataReceived.Trim().Contains("message_stat:")) {
                    //sendMessageLogs.Add(dataReceived.ToString().Trim());
                    isSending = false;
                } else if (dataReceived.Trim().Contains("gsm_init_success")) {
                    if (!isInitGSM) {
                        this.BeginInvoke(new _InitGSM(InitGSM), new object[] { dataReceived });
                    }
                }
            } catch {
            }
        }

        private void InitGSM(string data) {
            if (data.Trim() == "gsm_init_success") {
                isInitGSM = true;
            }
        }

        private void GetSignalStrength(string data) {
            string[] signalArray = data.Split(':');
            double signalValue = double.Parse(signalArray[1]);
            double signalPercentage = Math.Round((signalValue / 30) * 100, 2);
            string signalCondition = "";

            if (signalValue > 0 && signalValue <= 9) {
                signalCondition = "Marginal";
            } else if (signalValue >= 10 && signalValue <= 14) {
                signalCondition = "OK";
            } else if (signalValue >= 15 && signalValue <= 19) {
                signalCondition = "Good";
            } else if (signalValue >= 20 && signalValue <= 30) {
                signalCondition = "Excellent";
            } else {
                signalCondition = "Error";
            }
            
            lblSignalStrength.Text = signalPercentage.ToString() + "% (" + signalCondition + ")";
            isSignalAwait = true;
        }

        private void timerRefreshSignal_Tick(object sender, EventArgs e) {
            if (isInitGSM && isSignalAwait) {
                comPort.WriteLine("get_signal_str|");
                isSignalAwait = false;
            }
        }
    }
}

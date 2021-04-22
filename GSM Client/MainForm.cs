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
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace DRRMIS_GSM_Client
{
    public partial class MainForm : Form
    {
        LoginForm frmLogin = new LoginForm();
        RecipientForm frmRecipient;
        SelectSerialForm frmSelectSerial;
        SerialMonitorForm frmSerialMonitor = new SerialMonitorForm();
        AboutBoxForm frmAboutBox;

        private delegate void _ConnectSerialPort();
        private delegate void _DisconnectSerialPort();
        private delegate void _SendMessage(string[] recipients, string message);
        private delegate void _InitGSM(string data);
        private delegate void _GetSignalStrength(string data);
        private bool isInitialApplicationExec = true;
        private bool isLoading = true;
        private bool isInitGSM = false;
        private bool isSignalAwait = true;
        private bool isSending = false;
        private bool isSendingProcess = false;
        private bool isLogout = false;
        private List<string> sendMessageLogs = new List<string>();
        private int countSent = 0;
        private int logoutRetriesLeft = 3;

        private static Dictionary<string, dynamic> userResources;
        private int userID;
        private string firstname;
        private string lastname;
        private string username;
        private string token;
        private string baseURL;
        private bool userWithError = true;

        public string PortName {
            get { return comPort.PortName; }
            set { comPort.PortName = value; }
        }

        public int BaudRate {
            get { return comPort.BaudRate; }
            set { comPort.BaudRate = value; }
        }

        public Dictionary<string, dynamic> UserResources {
            get { return userResources; }
            set { userResources = value; }
        }

        public MainForm() {
            InitializeComponent();
        }

        private void RefreshForm() {
            isInitialApplicationExec = true;
            logoutRetriesLeft = 3;

            comPort.PortName = " ";
            comPort.BaudRate = 9600;

            if (userResources.Count > 0) {
                userID = int.Parse(userResources["user_id"].ToString());
                firstname = userResources["firstname"].ToString();
                lastname = userResources["lastname"].ToString();
                username = userResources["username"].ToString();
                token = userResources["token"].ToString();
                baseURL = userResources["base_url"].ToString();
                userWithError = Convert.ToBoolean(userResources["with_error"]);
            }

            frmSerialMonitor.MainForm = this;
            frmSerialMonitor.Show();
            frmSerialMonitor.Visible = false;

            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Normal;
            this.Focus(); 
            this.Show();

            toolStripMenuUsername.Text = "Profile: " + username.ToUpper();
            MessageBox.Show("Welcome " + firstname.ToUpper() + " " + lastname.ToUpper() +
                            "!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshDisplays();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            RefreshForm();
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult msgClosing = MessageBox.Show("Are you sure you want to exit the application?",
                                              "Exit Application", MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
            e.Cancel = true;

            if (msgClosing == DialogResult.Yes) {
                bool isLogoutSuccess = await Logout();

                if (isLogoutSuccess) {
                    DisconnectSerialPort();
                    ExitApplication();
                }
            }
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
            this.Close();
        }

        public void ConnectSerialPort() {
            isLoading = true;
            isInitialApplicationExec = false;
            isSignalAwait = true;

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
                    string portName = comPort.PortName.Trim();
                    string baudRate = comPort.BaudRate.ToString().Trim();

                    if (string.IsNullOrEmpty(portName) || string.IsNullOrEmpty(baudRate)) {
                        MessageBox.Show("Invalid parameters.", "Warning!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else if (!string.IsNullOrEmpty(portName) && !string.IsNullOrEmpty(baudRate)) {
                        MessageBox.Show("There is a problem connecting to the serial port. Try again.", 
                                        "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else {
                        MessageBox.Show("Invalid parameters.", "Warning!",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
            } else {
                DisconnectSerialPort();
            }

            isLoading = false;
        }

        private void DisconnectSerialPort() {
            isLoading = true;
            isInitGSM = false;
            isSendingProcess = false;

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

            isLoading = false;
        }

        private void ExitApplication() {
            Environment.Exit(0);
        }

        public void RefreshDisplays() {
            bool isPortConnected = comPort.IsOpen ? true : false;
            string serialStatus = isPortConnected ? "Connected" : "Disconnected";
            var serialStatusColor = isPortConnected ? System.Drawing.Color.Green : 
                                    System.Drawing.Color.Red;
            string gsmStatus = isInitGSM ? "Connected" : "Disconnected";
            var gsmStatusColor = isInitGSM ? System.Drawing.Color.Green :
                                 System.Drawing.Color.Red;
            string signalStatus = isInitGSM ? lblSignalStrength.Text : "0% (No Signal)";
            string portName = !string.IsNullOrEmpty(comPort.PortName.Trim()) ? 
                               comPort.PortName : "N/A";
            int baudRate = comPort.BaudRate;
            int recipientCount = selRecipients.Items.Count > 0 ? 
                                 selRecipients.Items.Count - 1 : 0;
            int messageCount = txtMessage.Text.Length;

            bool isSignalRefresh = isInitGSM && !isSendingProcess ? true : false;
            bool isConnectControlVisible = isPortConnected ? false : true;
            bool isIconConnectedVisible = !isInitialApplicationExec && !isConnectControlVisible &&
                                          !isSendingProcess && !isLogout ? true : false;
            bool isIconDisconnectedVisible = !isInitialApplicationExec && isConnectControlVisible &&
                                             !isSendingProcess && !isLogout ? true : false;
            bool isSendControlEnabled = isPortConnected && isInitGSM && !isSendingProcess &&
                                        messageCount > 0 && recipientCount > 0 ? true : false;
            bool isComposeMessageReadOnly =  isSendingProcess ? true : false;
            bool isRecipientControlEnabled = isPortConnected && isInitGSM && !isSendingProcess ? 
                                             true : false;
            string statusText = string.Empty;

            if (!isLogout) {
                if (!isInitialApplicationExec && !isLoading && isConnectControlVisible) {
                    statusText = "Disconnected";
                } else if (!isInitialApplicationExec && !isLoading && !isConnectControlVisible) {
                    statusText = "Connected";
                } else if (!isInitialApplicationExec && isLoading && isSendingProcess) {
                    statusText = "Sending... (" + countSent + " msg/s sent)";
                } else {
                    statusText = "Ready";
                }
            } else {
                statusText = "Signing Off...";
            }

            // Device details
            lblStatus.ForeColor = serialStatusColor;
            lblStatus.Text = serialStatus;
            lblPortName.Text = portName;
            lblBaudRate.Text = baudRate.ToString().Trim();
            lblStatusGSM.ForeColor = gsmStatusColor;
            lblStatusGSM.Text = gsmStatus;
            lblSignalStrength.Text = signalStatus;
            picSignalStatus.Image = !isInitGSM ? 
                                    (Bitmap)Properties.Resources.ResourceManager.GetObject("signal-slash-32px") :
                                    picSignalStatus.Image;
            timerRefreshSignal.Enabled = isSignalRefresh;

            // Compose message
            btnSend.Enabled = isSendControlEnabled;
            btnRecipients.Enabled = isRecipientControlEnabled;
            selRecipients.Enabled = isRecipientControlEnabled;
            lblRecipientsCount.Enabled = isRecipientControlEnabled;
            lblRecipientsCount.Text = (recipientCount <= 1 ? "Recipient: " : "Recipients: ") + 
                                      recipientCount.ToString();
            lblRecipientsCount.Cursor = isRecipientControlEnabled ? Cursors.Hand : Cursors.Default;
            lblMsgCount.Text = (messageCount <= 1 ? "Message Character: " : "Message Characters: ") + 
                               messageCount.ToString();
            txtMessage.ReadOnly = isComposeMessageReadOnly;
            txtMessage.Text = isComposeMessageReadOnly ? "" : txtMessage.Text;

            // Connect/disconnect
            toolStripMenuConnect.Visible = isConnectControlVisible;
            toolStripMenuDisconnect.Visible = !isConnectControlVisible;
            serialMonitorToolStripMenuItem.Enabled = !isConnectControlVisible;
            settingsToolStripMenuItem.Enabled = isConnectControlVisible;

            btnConnectSerial.Visible = isConnectControlVisible;
            btnDisconnectSerial.Visible = !isConnectControlVisible;
            btnSerialMonitor.Visible = !isConnectControlVisible;
            btnSettings.Enabled = isConnectControlVisible;

            // Status display
            toolStripIconLoading.Visible = isLoading;
            toolStripIconConnected.Visible = isIconConnectedVisible;
            toolStripIconDisconnected.Visible = isIconDisconnectedVisible;
            toolStripStatusLabel.Text = statusText;

            // User
            this.Enabled = isLogout && !userWithError ? 
                           false : true;
        }

        private void btnSerialMonitor_Click(object sender, EventArgs e) {
            frmSerialMonitor.Visible = true;
            frmSerialMonitor.Focus();
        }

        private void serialMonitorToolStripMenuItem_Click(object sender, EventArgs e) {
            frmSerialMonitor.Visible = true;
            frmSerialMonitor.Focus();
        }

        private void timerMonitorPort_Tick(object sender, EventArgs e) {
            if (!comPort.IsOpen) {
                //timerMonitorPort.Enabled = false;
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

        async void RunAsyncMsgSending(string[] recipients, string message) {
            await Task.Run(() => {
                isLoading = true;
                isSendingProcess = true;
                isSignalAwait = false;

                while (timerRefreshSignal.Enabled == true) { }

                MessageBox.Show("Sending message/s...", "",  MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);

                if (comPort.IsOpen) {
                    foreach (string phoneNo in recipients) {
                        string cmd = "send_msg|" + phoneNo.ToString().Trim() + ":" + message;
                        isSending = true;
                        comPort.WriteLine(cmd);

                        while (isSending) { }
                    }

                    sendMessageLogs.Clear();
                }

                isSendingProcess = false;
                isLoading = false;
                isSignalAwait = true;
                countSent = 0;
            });
        }

        private void btnSend_Click(object sender, EventArgs e) {
            string[] recipients = new string[selRecipients.Items.Count - 1];
            int recipientCount = selRecipients.Items.Count;
            String message = txtMessage.Text;
            int selectedIndex = int.Parse(selRecipients.SelectedIndex.ToString());

            if (recipientCount > 1) {
                for (int key = 1; key < selRecipients.Items.Count; key++) {
                    recipients[key - 1] = selRecipients.Items[key].ToString();
                }

                if (selectedIndex == 0) {
                    RunAsyncMsgSending(recipients, message);
                } else {
                    var phoneNo = selRecipients.SelectedItem;
                    string[] phoneNos = { phoneNo.ToString().Trim() };

                    RunAsyncMsgSending(phoneNos, message);
                }
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e) {
            int messageCount = txtMessage.Text.Length;
            lblMsgCount.Text = (messageCount <= 1 ? "Message Character: " : "Message Characters: ") +
                               messageCount.ToString();
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
                //Thread.Sleep(100);

                string dataReceived = comPort.ReadLine().ToString();
                frmSerialMonitor.SerialMonitorFeedback = dataReceived;

                if (dataReceived.Trim().Contains("signal_str:")) {
                    this.BeginInvoke(new _GetSignalStrength(GetSignalStrength), new object[] { dataReceived });
                } else if (dataReceived.Trim().Contains("message_stat:")) {
                    sendMessageLogs.Add(dataReceived.ToString().Trim());
                    countSent++;
                    isSending = false;
                } else if (dataReceived.Trim().Contains("gsm_init_success")) {
                    if (!isInitGSM) {
                        //this.BeginInvoke(new _InitGSM(InitGSM), new object[] { dataReceived });
                        InitGSM(dataReceived);
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
            string signalCondition = "No Signal";
            var imgSignal = (Bitmap)Properties.Resources.ResourceManager.GetObject("signal-slash-32px");

            if (signalValue > 1 && signalValue <= 9) {
                signalCondition = "Marginal";
                imgSignal = (Bitmap)Properties.Resources.ResourceManager.GetObject("signal-1-32px");
            } else if (signalValue >= 10 && signalValue <= 14) {
                signalCondition = "OK";
                imgSignal = (Bitmap)Properties.Resources.ResourceManager.GetObject("signal-2-32px");
            } else if (signalValue >= 15 && signalValue <= 19) {
                signalCondition = "Good";
                imgSignal = (Bitmap)Properties.Resources.ResourceManager.GetObject("signal-3-32px");
            } else if (signalValue >= 20 && signalValue <= 25) {
                signalCondition = "Excellent";
                imgSignal = (Bitmap)Properties.Resources.ResourceManager.GetObject("signal-4-32px");
            } else if (signalValue >= 26 && signalValue <= 30) {
                signalCondition = "Excellent";
                imgSignal = (Bitmap)Properties.Resources.ResourceManager.GetObject("signal-5-32px");
            } else {
                signalCondition = "No Signal";
                imgSignal = (Bitmap)Properties.Resources.ResourceManager.GetObject("signal-slash-32px");
            }

            lblSignalStrength.Text = signalPercentage.ToString() + "% (" + signalCondition + ")";
            picSignalStatus.Image = imgSignal;
            isSignalAwait = true;
        }

        private void timerRefreshSignal_Tick(object sender, EventArgs e) {
            if (isInitGSM && isSignalAwait) {
                comPort.WriteLine("get_signal_str|");
                isSignalAwait = false;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            ExitApplication();
        }

        private StringContent ParseJson(object _data) {
            string json = JsonConvert.SerializeObject(_data);
            StringContent data = new StringContent(
                json, Encoding.UTF8, "application/json"
            );

            return data;
        }

        private async Task<string> RunAsyncLogout() {
            string result = null;
            string apiURL = baseURL + "/api/logout/" + userID;
            Uri url = new Uri(apiURL);

            var _data = new {
                token = token
            };
            StringContent data = ParseJson(_data);

            try {
                using (var httpClient = new HttpClient()) {
                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    var response = await httpClient.PostAsync(url, data).ConfigureAwait(false);
                    result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    httpClient.Dispose();
                }
            }
            catch (Exception) {
                MessageBox.Show("There is an error accessing the server. Please try again.", "Critical",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        private async Task<bool> Logout() {
            bool isLogoutSuccess = false;

            await Task.Run(async () => {
                isLoading = true;
                isLogout = true;

                while (logoutRetriesLeft != -1) {
                    if (logoutRetriesLeft == 0) {
                        DialogResult msgRetry = MessageBox.Show(
                            "Retry signing off?", "Logout Failed",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning
                        );

                        if (msgRetry == DialogResult.Yes) {
                            logoutRetriesLeft = 3;
                        } else if (msgRetry == DialogResult.No) {
                            isLogoutSuccess = true;
                        } else {
                            logoutRetriesLeft = 3;
                            break;
                        }
                    }

                    if (isLogoutSuccess) {
                        break;
                    }

                    string logoutResult = await RunAsyncLogout();

                    if (!string.IsNullOrEmpty(logoutResult)) {
                        var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(logoutResult);
                        bool isSuccess = json.ContainsKey("success");

                        isLogoutSuccess = isSuccess;
                    }

                    logoutRetriesLeft--;
                }

                isLoading = false;
                isLogout = false;
            });

            return isLogoutSuccess;
        }

        private void OpenLoginForm() {
            this.Hide();
            userWithError = true;
            frmLogin.MainForm = this;

            if (frmLogin.ShowDialog() == DialogResult.OK) {
                this.Show();
                RefreshForm();
            } else {
                ExitApplication();
            }
        }

        private async void toolStripMenuLogout_Click(object sender, EventArgs e) {
            DialogResult msgClosing = MessageBox.Show("Are you sure you want to logout your account?",
                                                      "Logout", MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);
            if (msgClosing == DialogResult.Yes) {
                bool isLogoutSuccess = await Logout();

                if (isLogoutSuccess) {
                    DisconnectSerialPort();
                    OpenLoginForm();
                }
            }
        }
    }
}

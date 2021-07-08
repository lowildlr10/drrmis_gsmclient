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
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace DRRMIS_GSM_Client
{
    public partial class MainForm : Form
    {
        private User user;
        private static readonly GsmModule sms = new GsmModule();
        private static readonly LoginForm frmLogin = new LoginForm();
        private static readonly RecipientForm frmRecipient = new RecipientForm();
        private static readonly SelectSerialForm frmSelectSerial = new SelectSerialForm();
        private static readonly SerialMonitorForm frmSerialMonitor = new SerialMonitorForm();
        private static readonly AboutBoxForm frmAboutBox = new AboutBoxForm();

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
        private readonly List<string> sendMessageLogs = new List<string>();
        private int countSent = 0;
        private int logoutRetriesLeft = 3;

        private int userID;
        private string firstname;
        private string lastname;
        private string username;
        private string token;
        private string baseURL;
        private bool userWithError = true;
        private static string messageMode = "Text";

        private string serialDataResult = "";
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public string PortName {
            get { return comPort.PortName; }
            set { comPort.PortName = value; }
        }

        public int BaudRate {
            get { return comPort.BaudRate; }
            set { comPort.BaudRate = value; }
        }

        public string MessageMode {
            get { return messageMode; }
            set { messageMode = value; }
        }

        public MainForm(dynamic _user = null) {
            InitializeComponent();

            user = _user;
        }

        public User User {
            get { return user; }
            set { user = value; }
        }

        private void RefreshForm() {
            isInitialApplicationExec = true;
            logoutRetriesLeft = 3;

            comPort.PortName = " ";
            comPort.BaudRate = 9600;

            userID = user.Id;
            firstname = user.Firstname;
            lastname = user.Lastname;
            username = user.Username;
            token = user.Token;
            baseURL = user.BaseUrl;
            userWithError = user.HasError;

            notifyIcon.Visible = true;

            frmSerialMonitor.MainForm = this;
            frmSerialMonitor.Show();
            frmSerialMonitor.Visible = false;

            this.WindowState = FormWindowState.Normal;
            this.Focus(); 
            this.Show();

            toolStripMenuUsername.Text = "Profile: " + username.ToUpper();
            MessageBox.Show("Welcome " + firstname.ToUpper() + " " + lastname.ToUpper() +
                            "!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshDisplays();
        }

        private async void ClosingApplication() {
            bool isLogoutSuccess = false;
            DialogResult msgClosing = MessageBox.Show("Are you sure you want to exit the application?",
                                              "Exit Application", MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if (msgClosing == DialogResult.Yes) {
                if (user.Username != "Guest") {
                    isLogoutSuccess = await Logout();
                } else {
                    isLogoutSuccess = true;
                }

                if (isLogoutSuccess) {
                    notifyIcon.Dispose();
                    DisconnectSerialPort();
                    ExitApplication();
                }
            }
        }

        private void FlushSerial() {
            comPort.DiscardInBuffer();
            comPort.DiscardOutBuffer();
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
                        isInitGSM = false;
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
            bool isPortConnected = comPort.IsOpen;
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
            string statusText;

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
            toolStripMenuItemSerialStatus.Text = "COM Status: " + serialStatus;
            lblPortName.Text = portName;
            lblBaudRate.Text = baudRate.ToString().Trim();
            lblStatusGSM.ForeColor = gsmStatusColor;
            lblStatusGSM.Text = gsmStatus;
            toolStripMenuItemGsmStatus.Text = "GSM Status: " + gsmStatus;
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
            toolStripMenuItemConnectSerial.Visible = isConnectControlVisible;
            toolStripMenuItemDisonnectSerial.Visible = !isConnectControlVisible;
            toolStripMenuSerialMonitor.Enabled = !isConnectControlVisible;
            toolStripMenuSettings.Enabled = isConnectControlVisible;

            btnConnectSerial.Visible = isConnectControlVisible;
            btnDisconnectSerial.Visible = !isConnectControlVisible;
            btnSerialMonitor.Visible = !isConnectControlVisible;
            btnSettings.Enabled = isConnectControlVisible;
            toolStripMenuItemSettings.Enabled = isConnectControlVisible;

            // Status display
            toolStripIconLoading.Visible = isLoading;
            toolStripIconConnected.Visible = isIconConnectedVisible;
            toolStripIconDisconnected.Visible = isIconDisconnectedVisible;
            toolStripStatusLabel.Text = statusText;

            // User
            this.Enabled = isLogout && !userWithError ? 
                           false : true;
        }

        private async void RunAsyncMsgSending(string[] recipients, string message, string filename = null) {
            string[] textMessages = await sms.ChunkTextMsgs(messageMode, message.Trim());

            await Task.Run(() => {
                isLoading = true;
                isSendingProcess = true;
                isSignalAwait = false;

                while (timerRefreshSignal.Enabled == true) { }

                Thread.Sleep(2000);

                if (comPort.IsOpen) {
                    foreach (string phoneNo in recipients) {
                        int msgChunkCtr = 1;

                        foreach (string msg in textMessages) {
                            string cmd = "";

                            Thread.Sleep(500);

                            if (messageMode == "Text") {
                                cmd = "send_txt_msg|" + phoneNo.ToString().Trim() + "|" + msg;
                            } else {
                                Dictionary<string, string> encodedPDU = sms.GetEncodedMsgPDU(
                                    phoneNo, msg, textMessages.Length, msgChunkCtr
                                );
                                cmd = "send_pdu_msg|" + encodedPDU["total_msg_length"] + "|" +
                                      encodedPDU["encoded_pdu_msg"];
                            }

                            isSending = true;
                            comPort.WriteLine(cmd);

                            while (isSending) { }

                            msgChunkCtr++;
                        }
                    }
                }

                isSendingProcess = false;
                isLoading = false;
                isSignalAwait = true;
                countSent = 0;
            });

            if (!string.IsNullOrEmpty(filename)) {
                string result;

                try {
                    result = await sms.DisposeSentMessages(token, filename);
                } catch (Exception) {
                    result = "error-connection";
                }
                
                if (result == "no-error") {
                    notifyIcon.Text = "DRRMIS GSM Client";
                    notifyIcon.BalloonTipTitle = "Message Sending Completed";
                    notifyIcon.BalloonTipText = "Application has completed sending a batch of message from DRRMIS.";
                    notifyIcon.ShowBalloonTip(3000);
                }
            } else {
                notifyIcon.Text = "DRRMIS GSM Client";
                notifyIcon.BalloonTipTitle = "Message Sending Completed";
                notifyIcon.BalloonTipText = "Application has completed sending message/s.";
                notifyIcon.ShowBalloonTip(3000);
            }

            string storeSentResult;

            try {
                storeSentResult = await sms.StoreSentMessages(token, sendMessageLogs, message);
            } catch (Exception) {
                storeSentResult = "error-connection";
            }

            if (storeSentResult == "no-error") {
                notifyIcon.BalloonTipTitle = "Message Logs Stored";
                notifyIcon.BalloonTipText = "Application successfully stored the message logs to the DRRMIS server.";
                notifyIcon.ShowBalloonTip(3000);
            } else {
                notifyIcon.BalloonTipTitle = "Message Logs Storing Error";
                notifyIcon.BalloonTipText = "Application encountered an error storing the message logs to the DRRMIS server.";
                notifyIcon.ShowBalloonTip(3000);
            }

            sendMessageLogs.Clear();
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
            string signalCondition;
            Bitmap imgSignal;

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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            ExitApplication();
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

                    string logoutResult = await user.Logout();

                    if (logoutResult == "no-error") {
                        isLogoutSuccess = true;
                    } else if (logoutResult == "error-connection") {
                        MessageBox.Show("There is an error accessing the server. Please try again.", "Critical",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                frmLogin.RefreshDisplays();
                this.Show();
                RefreshForm();
            } else {
                ExitApplication();
            }
        }

        private void MinimizeTOTray(bool toMinimize) {
            if (toMinimize) {
                this.Hide();
                notifyIcon.BalloonTipTitle = "Minimized";
                notifyIcon.BalloonTipText = "Application is running in the background.";
                notifyIcon.ShowBalloonTip(3000);
            } else {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Focus();
            }
        }


        /* Main form
         */

        private void MainForm_Load(object sender, EventArgs e) {
            RefreshForm();
            timerSendApi.Enabled = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            MinimizeTOTray(true);
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
            MinimizeTOTray(true);
        }


        /* Main menu strip 
         */

        private void ToolStripMenuConnect_Click(object sender, EventArgs e) {
            this.BeginInvoke(new _ConnectSerialPort(ConnectSerialPort), new object[] { });
        }

        private void ToolStripMenuDisconnect_Click(object sender, EventArgs e){
            this.BeginInvoke(new _DisconnectSerialPort(DisconnectSerialPort), new object[] { });
        }

        private void ToolStripMenuSettings_Click(object sender, EventArgs e){
            frmSelectSerial.MainForm = this;
            frmSelectSerial.ShowDialog();
        }

        private void ToolStripMenuExit_Click(object sender, EventArgs e){
            ClosingApplication();
        }

        private void ToolStripMenuSerialMonitor_Click(object sender, EventArgs e) {
            frmSerialMonitor.Visible = true;
            frmSerialMonitor.Focus();
        }

        private void ToolStripMenuAbout_Click(object sender, EventArgs e) {
            frmAboutBox.ShowDialog();
        }


        /* Tool strip menu
         */

        private void BtnSend_Click(object sender, EventArgs e) {
            string[] recipients = new string[selRecipients.Items.Count - 1];
            int recipientCount = selRecipients.Items.Count;
            String message = txtMessage.Text;
            int selectedIndex = int.Parse(selRecipients.SelectedIndex.ToString());

            if (recipientCount > 1) {
                for (int key = 1; key < selRecipients.Items.Count; key++) {
                    recipients[key - 1] = selRecipients.Items[key].ToString();
                }

                notifyIcon.Text = "DRRMIS GSM Client Sending...";
                notifyIcon.BalloonTipTitle = "Message Sending";
                notifyIcon.BalloonTipText = "Application is sending a message/s.";
                notifyIcon.ShowBalloonTip(3000);

                if (selectedIndex == 0) {
                    RunAsyncMsgSending(recipients, message);
                } else {
                    var phoneNo = selRecipients.SelectedItem;
                    string[] phoneNos = { phoneNo.ToString().Trim() };

                    RunAsyncMsgSending(phoneNos, message);
                }
            }
        }

        private void BtnRecipients_Click(object sender, EventArgs e) {
            frmRecipient.MainForm = this;
            frmRecipient.ShowDialog();
        }

        private void BtnConnectSerial_Click(object sender, EventArgs e) {
            this.BeginInvoke(new _ConnectSerialPort(ConnectSerialPort), new object[] { });
        }

        private void BtnDisconnectSerial_Click(object sender, EventArgs e) {
            this.BeginInvoke(new _DisconnectSerialPort(DisconnectSerialPort), new object[] { });
        }

        private void BtnSerialMonitor_Click(object sender, EventArgs e) {
            frmSerialMonitor.Visible = true;
            frmSerialMonitor.Focus();
        }

        private void BtnSettings_Click(object sender, EventArgs e) {
            frmSelectSerial.MainForm = this;
            frmSelectSerial.ShowDialog();
        }

        private async void ToolStripMenuLogout_Click(object sender, EventArgs e) {
            bool isLogoutSuccess = false;
            DialogResult msgClosing = MessageBox.Show("Are you sure you want to logout your account?",
                                                      "Logout", MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);
            if (msgClosing == DialogResult.Yes) {
                if (user.Username != "Guest") {
                    isLogoutSuccess = await Logout();
                } else {
                    isLogoutSuccess = true;
                }

                if (isLogoutSuccess) {
                    notifyIcon.Visible = false;
                    DisconnectSerialPort();
                    OpenLoginForm();
                }
            }
        }


        /* Compose message fields
         */

        private void LblRecipientsCount_Click(object sender, EventArgs e) {
            if (btnRecipients.Enabled == true) {
                frmRecipient.MainForm = this;
                frmRecipient.ShowDialog();
            }
        }

        private void TxtMessage_TextChanged(object sender, EventArgs e) {
            int messageCount = txtMessage.Text.Length;
            lblMsgCount.Text = (messageCount <= 1 ? "Message Character: " : "Message Characters: ") +
                               messageCount.ToString();
        }

        private void TxtMessage_KeyDown(object sender, KeyEventArgs e) {
            // For debugging
            /*if (e.KeyCode == Keys.Enter) {
                string txt = txtMessage.Text;
                string[] textMessages = await sms.ChunkTextMsgs(txt.Trim());

                foreach (string phoneNo in new string[] { "09129527475" }) {
                    int msgChunkCtr = 1;

                    foreach (string msg in textMessages) {
                        Dictionary<string, string> encodedPDU = sms.GetEncodedMsgPDU(
                            phoneNo, msg, textMessages.Length, msgChunkCtr
                        );

                        txtMessage.AppendText("Length: " + encodedPDU["total_msg_length"] +
                                              "\nPDU Content: " + encodedPDU["encoded_pdu_msg"]);

                        txtMessage.AppendText("\n\n\n\n");

                        msgChunkCtr++;
                    }
                }
            }*/
        }


        /* Timers
         */

        private void TimerRefreshSignal_Tick(object sender, EventArgs e) {
            if (isInitGSM && isSignalAwait) {
                comPort.WriteLine("get_signal_str|");
                isSignalAwait = false;
            }
        }

        private void TimerMonitorPort_Tick(object sender, EventArgs e) {
            if (!comPort.IsOpen) {
                DisconnectSerialPort();
            }

            RefreshDisplays();
        }

        private async void TimerSendApi_Tick(object sender, EventArgs e) {
            if (isInitGSM && !isSendingProcess) {
                string getQueueResult;
                sms.BaseUrl = baseURL;

                try  {
                    getQueueResult = await sms.GetQueueMessages(token);
                } catch (Exception) {
                    getQueueResult = "error-connection";
                }

                if (getQueueResult != "error-connection" && !isSendingProcess) {
                    var jsonSuccess = JsonConvert.DeserializeObject<Dictionary<string, object>>(getQueueResult);
                    string phoneNumber = jsonSuccess["phone_numbers"].ToString();
                    string[] phoneNumbers = phoneNumber.Split(',');
                    string message = jsonSuccess["message"].ToString();
                    string filename = jsonSuccess["filename"].ToString();

                    notifyIcon.Text = "DRRMIS GSM Client Sending...";
                    notifyIcon.BalloonTipTitle = "Message Sending from DRRMIS";
                    notifyIcon.BalloonTipText = "Application is sending a batch of message/s in the background.";
                    notifyIcon.ShowBalloonTip(3000);

                    RunAsyncMsgSending(phoneNumbers, message, filename);
                }
            }
        }


        /* COM Port
         */

        private void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            try {
                string dataReceived = comPort.ReadLine();
                frmSerialMonitor.SerialMonitorFeedback = dataReceived + "\n";

                if (dataReceived.Trim().Contains("signal_str:")) {
                    this.BeginInvoke(new _GetSignalStrength(GetSignalStrength), new object[] { dataReceived });
                } else if (dataReceived.Trim().Contains("message_txt_stat:")) {
                    sendMessageLogs.Add(dataReceived.ToString().Trim());
                    countSent++;
                    isSending = false;
                } else if (dataReceived.Trim().Contains("message_pdu_stat:")) {
                    sendMessageLogs.Add(dataReceived.ToString().Trim());
                    countSent++;
                    isSending = false;
                } else if (dataReceived.Trim().Contains("gsm_init_success")) {
                    if (!isInitGSM) {
                        InitGSM(dataReceived);
                    }
                }

                FlushSerial();
            } catch {
            }
        }


        /* Notify icon
         */

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            MinimizeTOTray(false);
        }

        private void ToolStripMenuItemShowForm_Click(object sender, EventArgs e) {
            MinimizeTOTray(false);
        }

        private void ToolStripMenuItemConnectSerial_Click(object sender, EventArgs e) {
            this.BeginInvoke(new _ConnectSerialPort(ConnectSerialPort), new object[] { });
        }

        private void ToolStripMenuItemDisonnectSerial_Click(object sender, EventArgs e) {
            this.BeginInvoke(new _DisconnectSerialPort(DisconnectSerialPort), new object[] { });
        }

        private void ToolStripMenuItemSettings_Click(object sender, EventArgs e) {
            frmSelectSerial.MainForm = this;
            frmSelectSerial.ShowDialog();
        }

        private void ToolStripMenuItemExitApp_Click(object sender, EventArgs e) {
            ClosingApplication();
        }
    }
}

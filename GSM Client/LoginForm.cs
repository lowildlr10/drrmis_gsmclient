using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace DRRMIS_GSM_Client
{
    public partial class LoginForm : Form
    {
        private static MainForm frmMain;
        private static readonly User user = new User();

        private bool isLogin = false;
        private string baseURL = "http://drrmis.dostcar.ph";

        private delegate void RefreshDisplaysThread();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public MainForm MainForm {
            get { return frmMain; }
            set { frmMain = value; }
        }

        public void RefreshDisplays() {
            if (!isLogin) {
                toolStripIconStatus.Visible = false;
                toolStripStatusLabel.Visible = false;
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
                btnLogin.Enabled = true;
                txtUsername.Focus();
            } else {
                toolStripIconStatus.Visible = true;
                toolStripStatusLabel.Visible = true;
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
                btnLogin.Enabled = false;
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }

        private async void Login() {
            string loginResult = null;
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            
            if (string.IsNullOrEmpty(username) &&
                !string.IsNullOrEmpty(password)) {
                MessageBox.Show("Username should not be empty.", "Empty Username",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
            } else if (!string.IsNullOrEmpty(username) &&
                     string.IsNullOrEmpty(password)) {
                MessageBox.Show("Password should not be empty.", "Empty Password",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
            } else if (string.IsNullOrEmpty(username) &&
                     string.IsNullOrEmpty(password)) {
                MessageBox.Show("Username and Password should not be empty.", "Empty Username & Password", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
            } else {
                isLogin = true;
                this.BeginInvoke(new RefreshDisplaysThread(RefreshDisplays), new object[] { });

                try {
                    loginResult = await user.Login(username, password);
                } catch (Exception) {
                    loginResult = "error-connection";
                }

                if (loginResult == "no-error") {
                    if (!user.HasError) {
                        CloseForm();
                    }
                } else if (loginResult == "error-connection") {
                    MessageBox.Show("There is an error accessing the server. Please try again.", "Critical",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else if (loginResult == "error-credentials") {
                    MessageBox.Show("Incorrect username or password. Try again.", "Login Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                isLogin = false;
                this.BeginInvoke(new RefreshDisplaysThread(RefreshDisplays), new object[] { });
            }
        }

        private void GuestLogin() {
            user.Id = 0;
            user.Firstname = "Guest";
            user.Lastname = "Account";
            user.Username = "Guest";
            user.Token = "";
            user.HasError = false;
            RefreshDisplays();
            CloseForm();
        }

        private void CloseForm() {
            frmMain.User = user;
            this.DialogResult = DialogResult.OK;
            RefreshDisplays();
            this.Close();
        }

        private void SaveSettings() {
            this.baseURL = txtBaseURL.Text.Trim();
            user.BaseUrl = baseURL;
            MessageBox.Show("Settings saved.", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }


        /* Login form
         */

        public LoginForm() {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Normal;
            this.Focus();
            this.Show();
        }


        /* Main tool strip menu
         */

        private void ToolStripMain_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }


        /* Settings components
         */

        private void TxtBaseURL_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                SaveSettings();
            }
        }

        private void ToolTipItem_Click(object sender, EventArgs e) {
            SaveSettings();
        }

        private void ToolStripMenuSaveSettings_Click(object sender, EventArgs e) {
            SaveSettings();
        }


        /* Login components
         */


        private void TxtUsername_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                Login();
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                Login();
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e) {
            Login();
        }

        private void LinkGuestLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            GuestLogin();
        }
    }
}
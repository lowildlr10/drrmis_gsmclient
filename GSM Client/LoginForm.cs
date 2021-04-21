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
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;

namespace DRRMIS_GSM_Client
{
    public partial class LoginForm : Form
    {
        private bool isLogin = false;

        private delegate void refreshDisplaysThread();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public class DataObject {
            public string Name { get; set; }
        }

        public LoginForm() {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }

        private void toolStripLogin_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void refreshDisplays() {
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
            }
        }

        async void RunAsyncLogin(string username, string password) {
            await Task.Run(async () => {
                string baseURL = "http://localhost:8000/api/login";
                string paramURL = "";
                Uri url = new Uri(baseURL + paramURL);
                //username = "dostregioncar";
                //password = "dostCAR1116";

                var _data = new
                {
                    login = username,
                    password = password
                };
                string json = JsonConvert.SerializeObject(_data);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

                isLogin = true;
                this.BeginInvoke(new refreshDisplaysThread(refreshDisplays), new object[] { });

                try {
                    var httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

                    var authCredentials = System.Text.Encoding.ASCII.GetBytes($"{ username }:{password}");
                    string encodedAuth = System.Convert.ToBase64String(authCredentials);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuth);

                    HttpResponseMessage response = httpClient.PostAsync(url, data).Result;

                    // ... Read the string.
                    string result = await response.Content.ReadAsStringAsync();

                    MessageBox.Show(result);

                    //close out the client
                    httpClient.Dispose();
                } catch (Exception e) {
                    MessageBox.Show("There is an error accessing the server. Please try again.", "Critical",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                isLogin = false;
                this.BeginInvoke(new refreshDisplaysThread(refreshDisplays), new object[] { });
            });
        }

        private void loginForm() {
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
                RunAsyncLogin(username, password);

                txtUsername.Clear();
                txtPassword.Clear();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            loginForm();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                loginForm();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                loginForm();
            }
        }
    }
}

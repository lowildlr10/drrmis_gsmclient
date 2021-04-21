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
        private bool isLogin = false;

        private delegate void RefreshDisplaysThread();
        private delegate void _RunMainForm(Dictionary<string, dynamic> userResources);

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

        private void LoginForm_Load(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Normal;
            this.Focus();
            this.Show();
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

        private void RefreshDisplays() {
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

        private StringContent ParseJson(object _data) {
            string json = JsonConvert.SerializeObject(_data);
            StringContent data = new StringContent(
                json, Encoding.UTF8, "application/json"
            );

            return data;
        }

        private async Task<string> RunAsyncLogin(string username, string password) {
            string result = null;
            string apiURL = "http://localhost:8000/api/login";
            Uri url = new Uri(apiURL);

            var _data = new {
                login = username,
                password = password
            };
            StringContent data = ParseJson(_data);

            isLogin = true;
            this.BeginInvoke(new RefreshDisplaysThread(RefreshDisplays), new object[] { });

            try {
                using (var httpClient = new HttpClient()) {
                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

                    var authCredentials = System.Text.Encoding.ASCII.GetBytes($"{ username }:{password}");
                    string encodedAuth = System.Convert.ToBase64String(authCredentials);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuth);

                    var response = await httpClient.PostAsync(url, data).ConfigureAwait(false);
                    result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    httpClient.Dispose();
                }
            } catch (Exception) {
                MessageBox.Show("There is an error accessing the server. Please try again.", "Critical",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isLogin = false;
            this.BeginInvoke(new RefreshDisplaysThread(RefreshDisplays), new object[] { });

            return result;
        }

        private async Task<string> GetUser(string token) {
            string result = null;
            string apiURL = "http://localhost:8000/api/user-info";
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
            } catch (Exception) { }

            return result;
        }

        private async Task<string> Login() {
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
                loginResult = await RunAsyncLogin(username, password);
            }

            return loginResult;
        }

        private async Task<Dictionary<string, dynamic>> ParseUserData(string jsonString) {
            var usrDict = new Dictionary<string, dynamic>();
            usrDict["with_error"] = true;

            var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
            bool isSuccess = json.ContainsKey("success");

            if (isSuccess) {
                string successVal = json["success"].ToString();
                var jsonSuccess = JsonConvert.DeserializeObject<Dictionary<string, object>>(successVal);
                string token = jsonSuccess["token"].ToString();

                string userResult = await GetUser(token);
                var jsonUser = JsonConvert.DeserializeObject<Dictionary<string, object>>(userResult);
                bool isUserSuccess = jsonUser.ContainsKey("success");

                usrDict["token"] = token;

                if (isUserSuccess) {
                    successVal = jsonUser["success"].ToString();
                    jsonSuccess = JsonConvert.DeserializeObject<Dictionary<string, object>>(successVal);
                    int usrID = int.Parse(jsonSuccess["id"].ToString());
                    string usrFirstname = jsonSuccess["first_name"].ToString();
                    string usrLastname = jsonSuccess["last_name"].ToString();
                    string usrUsername = jsonSuccess["username"].ToString();

                    usrDict["user_id"] = usrID;
                    usrDict["firstname"] = usrFirstname;
                    usrDict["lastname"] = usrLastname;
                    usrDict["username"] = usrUsername;
                    usrDict["with_error"] = false;
                } else {

                }
            } else {
                MessageBox.Show("Incorrect username or password. Try again.", "Login Failed", 
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return usrDict;
        }

        private async void btnLogin_Click(object sender, EventArgs e) {
            string loginResult = await Login();

            if (!string.IsNullOrEmpty(loginResult)) {
                Dictionary<string, dynamic> userResources = await ParseUserData(loginResult);
                bool userHasError = Convert.ToBoolean(userResources["with_error"]);

                if (!userHasError) {
                    CloseForm(userResources);
                }
            }
        }

        private async void txtUsername_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                string loginResult = await Login();

                if (!string.IsNullOrEmpty(loginResult)) {
                    Dictionary<string, dynamic> userResources = await ParseUserData(loginResult);
                    bool userHasError = Convert.ToBoolean(userResources["with_error"]);

                    if (!userHasError) {
                        CloseForm(userResources);
                    }
                }
            }
        }

        private async void txtPassword_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                string loginResult = await Login();

                if (!string.IsNullOrEmpty(loginResult)) {
                    Dictionary<string, dynamic> userResources = await ParseUserData(loginResult);
                    bool userHasError = Convert.ToBoolean(userResources["with_error"]);

                    if (!userHasError) {
                        CloseForm(userResources);
                    }
                }
            }
        }

        private void CloseForm(Dictionary<string, dynamic> userResources) {
            this.Hide();
            MainForm frmMain = new MainForm(userResources);
            frmMain.Show();
            Application.Exit();
        }
    }
}
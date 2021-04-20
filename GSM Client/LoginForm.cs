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

namespace DRRMIS_GSM_Client
{
    public partial class LoginForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        private string urlAPI = "http://philsensors.asti.dost.gov.ph/api/data/";
        private string urlParameters = "?api_key=123";

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

        async void RunAsyncLogin(string username, string password) {
            var byteArray = Encoding.ASCII.GetBytes("dostregioncar:dostCAR1116");
            string resultString = "";

            await Task.Run(async () => {
                using (var client = new HttpClient()) {
                    client.BaseAddress = new Uri(urlAPI);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json")
                    );
                    client.DefaultRequestHeaders.Authorization = 
                        new System.Net.Http.Headers.AuthenticationHeaderValue(
                            "Basic", Convert.ToBase64String(byteArray)
                        );

                    HttpResponseMessage response = await client.GetAsync(urlAPI);
                    HttpContent content = response.Content;

                    // ... Check Status Code
                    resultString = "Response StatusCode: " + ((int)response.StatusCode).ToString();
                    MessageBox.Show(resultString);

                    // ... Read the string.
                    string result = await content.ReadAsStringAsync();

                    // ... Display the result.
                    if (result != null && result.Length >= 50) {
                        resultString = result.Substring(0, 50) + "...";

                        MessageBox.Show(resultString);
                    }
                }
                //MessageBox.Show("Username: " + username + " Password: " + password);
            });
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) &&
                !string.IsNullOrEmpty(password)) {
                txtUsername.Focus();
            } else if (!string.IsNullOrEmpty(username) &&
                       string.IsNullOrEmpty(password)) {
                txtPassword.Focus();
            } else if (string.IsNullOrEmpty(username) &&
                       string.IsNullOrEmpty(password)) {
                txtUsername.Focus();
            } else {
                RunAsyncLogin(username, password);
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }
    }
}

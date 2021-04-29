using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DRRMIS_GSM_Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid)) {
                if (!mutex.WaitOne(0, false)) {
                    MessageBox.Show("Application is already running.", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                LoadingScreenForm.ShowLoadingScreen();
                LoadingScreenForm.CloseForm();

                LoginForm frmLogin = new LoginForm();
                MainForm frmMain = new MainForm();

                frmLogin.MainForm = frmMain;

                if (frmLogin.ShowDialog() == DialogResult.OK) {
                    Application.Run(frmMain);
                } else {
                    Application.Exit();
                }
            }
        }

        private static string appGuid = "28a677a0-1aca-42a3-8750-648c66ed0bc9";
    }
}

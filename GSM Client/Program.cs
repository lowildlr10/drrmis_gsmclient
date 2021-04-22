using System;
using System.Collections.Generic;
using System.Linq;
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
        static void Main()
        {
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
}

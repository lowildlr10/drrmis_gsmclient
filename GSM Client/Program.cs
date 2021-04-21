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
            LoginForm frmLogin = new LoginForm();
            LoadingScreenForm.CloseForm();
            Application.Run(frmLogin);
        }
    }
}

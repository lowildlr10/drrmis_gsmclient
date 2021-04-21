using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace DRRMIS_GSM_Client
{
    public partial class LoadingScreenForm : Form
    {
        private delegate void CloseDelegate();
        private static LoadingScreenForm frmLoadingScreen;

        public LoadingScreenForm() {
            InitializeComponent();
        }

        static public void ShowLoadingScreen() {  
            if (frmLoadingScreen != null) return;
            frmLoadingScreen = new LoadingScreenForm();
            Thread thread = new Thread(new ThreadStart(LoadingScreenForm.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static private void ShowForm() {
            if (frmLoadingScreen != null) {
                Application.Run(frmLoadingScreen);
            }
        }

        static public void CloseForm() {
            Thread.Sleep(3000);
            frmLoadingScreen?.Invoke(
                new CloseDelegate(LoadingScreenForm.CloseFormInternal)
            );
        }

        static private void CloseFormInternal() {
            if (frmLoadingScreen != null) {
                frmLoadingScreen.Close();
                frmLoadingScreen = null;
            };
        }
    }
}

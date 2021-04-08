using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSM_Client
{
    public partial class MainForm : Form
    {
        SelectSerialForm frmSelectSerial = new SelectSerialForm();

        public MainForm() {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            exitApplication();
        }

        private void exitApplication() {
            if (System.Windows.Forms.Application.MessageLoop) {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            } else {
                // Console app
                System.Environment.Exit(1);
            }
        }

        private void mainForm_Load(object sender, EventArgs e) {
            
        }

        private void FrmSelectSerial_FormClosing(object sender, FormClosingEventArgs e) {
            comPort.PortName = frmSelectSerial.GetSelectedSerialPort;
            comPort.BaudRate = frmSelectSerial.GetBaudRate;
            connectCOM();
        }

        private void btnConnectSerial_Click(object sender, EventArgs e) {
            frmSelectSerial.FormClosing += FrmSelectSerial_FormClosing;
            frmSelectSerial.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutBoxForm frmAboutBox = new AboutBoxForm();
            frmAboutBox.ShowDialog();
        }

        private void toolStripMenuConnect_Click(object sender, EventArgs e) {
            frmSelectSerial.ShowDialog();
        }
        
        public void connectCOM() {
            if (comPort.IsOpen) {
            } else {
                comPort.Open();
                comPort.WriteLine("3");
                comPort.WriteLine("5");
                comPort.WriteLine("6");
            }

            toolStripMenuConnect.Visible = false;
            toolStripMenuDisconnect.Visible = true;
            btnConnectSerial.Visible = false;
            btnDisconnectSerial.Visible = true;

            MessageBox.Show(comPort.PortName + 
                            " is now connected with a baud rate of '" + 
                            comPort.BaudRate + "'.");
        }

        private void disconnectCOM() {
            while (comPort.IsOpen) {
                comPort.Write("5");
                comPort.Close(); 
            }

            toolStripMenuConnect.Visible = true;
            toolStripMenuDisconnect.Visible = false;
            btnConnectSerial.Visible = true;
            btnDisconnectSerial.Visible = false;

            MessageBox.Show(comPort.PortName + " is now disconnected.");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            disconnectCOM();
        }

        private void btnDisconnectSerial_Click(object sender, EventArgs e) {
            disconnectCOM();
        }

        private void toolStripMenuDisconnect_Click(object sender, EventArgs e) {
            disconnectCOM();
        }
    }
}

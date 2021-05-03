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

namespace DRRMIS_GSM_Client
{
    public partial class SelectSerialForm : Form
    {
        MainForm frmMain;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public SelectSerialForm() {
            InitializeComponent();
        }

        public MainForm MainForm {
            get { return frmMain; }
            set { frmMain = value; }
        }

        private void RefreshPortList() {
            string[] ports = SerialPort.GetPortNames();

            selSerialPort.Items.Clear();

            foreach (string port in ports) {
                selSerialPort.Items.Add(port);
            }

            selSerialPort.SelectedItem = frmMain.comPort.PortName;
            selMessageMode.SelectedItem = frmMain.MessageMode;
        }

        private void SelectSerialForm_Load(object sender, EventArgs e) {
            RefreshPortList();

            txtBaudRate.Text = frmMain.comPort.BaudRate.ToString();
        }

        private void txtBaudRate_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void selSerialPort_Click(object sender, EventArgs e) {
            RefreshPortList();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnConSelSerial_Click(object sender, EventArgs e) {
            var serialPort = selSerialPort.SelectedItem;
            string baudRate = txtBaudRate.Text.Trim();
            var messageMode = selMessageMode.SelectedItem;

            if (serialPort != null && !string.IsNullOrEmpty(baudRate) && messageMode == null) {

            } else {
                if (serialPort == null) {
                    MessageBox.Show("Please select a serial port.", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    selSerialPort.Focus();
                }

                if (string.IsNullOrEmpty(baudRate)) {
                    MessageBox.Show("Please select a baud rate.", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBaudRate.Focus();
                }

                if (messageMode == null) {
                    MessageBox.Show("Please select a message mode.", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    selMessageMode.Focus();
                }

                return;
            }

            frmMain.comPort.PortName = serialPort.ToString();
            frmMain.comPort.BaudRate = int.Parse(baudRate);
            frmMain.MessageMode = messageMode.ToString();
            frmMain.RefreshDisplays();

            this.Close();
        }

        private void toolStripMain_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

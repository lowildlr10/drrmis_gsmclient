using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace DRRMIS_GSM_Client
{
    public partial class SelectSerialForm : Form
    {
        MainForm frmMain;

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
        }

        private void SelectSerialForm_Load(object sender, EventArgs e) {
            Font fntSerialPort = new Font("Segoe UI", 11, FontStyle.Regular);
            Font fntBaudRate = new Font("Segoe UI", 11, FontStyle.Regular);

            RefreshPortList();

            selSerialPort.Font = fntSerialPort;
            txtBaudRate.Text = frmMain.comPort.BaudRate.ToString();
            txtBaudRate.Font = fntBaudRate;
        }

        private void btnConSelSerial_Click(object sender, EventArgs e) {
            var serialPort = selSerialPort.SelectedItem;
            string baudRate = txtBaudRate.Text.Trim();
            //frmMain = new MainForm();

            if (serialPort != null && !string.IsNullOrEmpty(baudRate)) {
                
            } else {
                if (serialPort == null) {
                    MessageBox.Show("Please select a serial port.");
                    selSerialPort.Focus();
                }

                if (string.IsNullOrEmpty(baudRate)) {
                    MessageBox.Show("Please select a baud rate.");
                    txtBaudRate.Focus();
                }

                return;
            }

            frmMain.comPort.PortName = serialPort.ToString();
            frmMain.comPort.BaudRate = int.Parse(baudRate);
            frmMain.RefreshDisplays();

            this.Close();
        }

        private void txtBaudRate_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void selSerialPort_Click(object sender, EventArgs e) {
            RefreshPortList();
        }
    }
}

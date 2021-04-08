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

namespace GSM_Client
{
    public partial class SelectSerialForm : Form
    {
        public SelectSerialForm() {
            InitializeComponent();
        }

        public string GetSelectedSerialPort {
            get {
                var serialPort = selSerialPort.SelectedItem;
                return serialPort.ToString(); 
            }
        }
        public int GetBaudRate {
            get {
                string baudRate = txtBaudRate.Text.Trim();
                return int.Parse(baudRate);
            }
        }

        private void SelectSerialForm_Load(object sender, EventArgs e) {
            Font fntSerialPort = new Font("Segoe UI", 11, FontStyle.Regular);
            Font fntBaudRate = new Font("Segoe UI", 11, FontStyle.Regular);
            string[] ports = SerialPort.GetPortNames();

            selSerialPort.Items.Clear();

            foreach (string port in ports) {
                selSerialPort.Items.Add(port);
            }

            selSerialPort.Font = fntSerialPort;
            txtBaudRate.Font = fntBaudRate;
        }

        private void btnConSelSerial_Click(object sender, EventArgs e) {
            var serialPort = selSerialPort.SelectedItem;
            string baudRate = txtBaudRate.Text.Trim();

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

            this.Close();
        }

        private void txtBaudRate_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
    }
}

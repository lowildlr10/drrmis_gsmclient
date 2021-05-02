﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;

namespace DRRMIS_GSM_Client
{
    public partial class RecipientForm : Form
    {
        MainForm frmMain;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public RecipientForm() {
            InitializeComponent();
        }

        private void RecipientForm_Load(object sender, EventArgs e) {
            if (frmMain.selRecipients.Items.Count > 0) {
                for (int rowCtr = 0; rowCtr < frmMain.selRecipients.Items.Count; rowCtr++) {
                    if (rowCtr > 0) {
                        dataRecipients.Rows.Add(frmMain.selRecipients.Items[rowCtr]);
                    }
                }
            }
        }

        public MainForm MainForm {
            get { return frmMain; }
            set { frmMain = value; }
        }

        private void btnImportCSV_Click(object sender, EventArgs e) {
            GsmModule sms = new GsmModule();
            openFileDialog.FilterIndex = 1;
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog.FileName = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string delimiter = ",";
                string filename = openFileDialog.FileName;

                StreamReader sr = new StreamReader(filename);

                string allData = sr.ReadToEnd();
                string[] rows = allData.Split("\r".ToCharArray());

                dataRecipients.Rows.Clear();

                for (int rowCtr = 0; rowCtr < rows.Length; rowCtr++) {
                    if (rowCtr > 0) {
                        string[] __items = rows[rowCtr].Split(delimiter.ToCharArray());
                        List<string> _items = new List<string>();
                        int numCtr = 0;

                        foreach (string item in __items) {
                            string formatedPhoneNo = sms.FormatPhoneNumber(__items[numCtr].Trim());

                            if (formatedPhoneNo != "not-valid") {
                                _items.Add(formatedPhoneNo);
                            }
                        }

                        if (_items.Count > 0) {
                            string[] items = _items.ToArray();
                            dataRecipients.Rows.Add(items);
                        }
                    }
                }
                
                MessageBox.Show(filename + " was successfully imported.", "Success!", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnApplyRecipients_Click(object sender, EventArgs e) {
            var list = new List<string>(dataRecipients.Rows.Count);

            frmMain.selRecipients.Items.Clear();
            frmMain.selRecipients.Items.Add("-- send-to-all --");

            foreach (DataGridViewRow row in dataRecipients.Rows) {
                String phoneNo = null;

                foreach (DataGridViewCell cell in row.Cells) {
                    if (cell.Value != null) {
                        phoneNo = cell.Value.ToString().Trim();
                    }
                }

                if (!String.IsNullOrEmpty(phoneNo)) {
                    GsmModule sms = new GsmModule();
                    phoneNo = sms.FormatPhoneNumber(phoneNo);
                    frmMain.selRecipients.Items.Add(phoneNo);
                }
            }

            frmMain.selRecipients.SelectedIndex = 0;
            frmMain.RefreshDisplays();

            this.Close();
        }

        private void Control_KeyDown(object sender, KeyEventArgs e) {
            var cell = (DataGridViewTextBoxEditingControl)sender;

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back) {
                try {
                    if (string.IsNullOrEmpty(cell.Text.Trim())) {
                        dataRecipients.Rows.RemoveAt(cell.EditingControlRowIndex);
                        e.Handled = true;
                    }
                } catch (Exception) { }
            }
        }

        private void dataRecipients_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            var txtBox = e.Control as TextBox;

            if (txtBox != null) {
                txtBox.KeyDown -= new KeyEventHandler(Control_KeyDown);
                txtBox.KeyDown += new KeyEventHandler(Control_KeyDown);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
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

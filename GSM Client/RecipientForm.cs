using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace GSM_Client
{
    public partial class RecipientForm : Form
    {
        MainForm frmMain;

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

        private string FormatPhoneNumber(string phoneNo) {
            string formatedPhoneNo = Regex.Replace(phoneNo, "/[^+0-9]/", "");
            int digitCount = formatedPhoneNo.Length;
            bool isValidNumber = false;

            if (digitCount < 10 && digitCount > 13) {
                return "not-valid";
            }

            if (digitCount <= 0) {
                return "not-valid";
            }

            if (formatedPhoneNo.Substring(0, 1) == "9" && digitCount == 10) {
                formatedPhoneNo = "0" + formatedPhoneNo;
                isValidNumber = true;
            }

            if (formatedPhoneNo.Substring(0, 2) == "09" && digitCount == 11) {
                isValidNumber = true;
            }

            if (formatedPhoneNo.Substring(0, 3) == "639" && digitCount == 12) {
                formatedPhoneNo = "+" + formatedPhoneNo;
                formatedPhoneNo = formatedPhoneNo.Replace("+63", "0");
                isValidNumber = true;
            }

            if (formatedPhoneNo.Substring(0, 4) == "+639" && digitCount == 13) {
                formatedPhoneNo = formatedPhoneNo.Replace("+63", "0");
                isValidNumber = true;
            }

            if (!isValidNumber) {
                return "not-valid";
            }

            return formatedPhoneNo;
        }

        private void btnImportCSV_Click(object sender, EventArgs e) {
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
                            string formatedPhoneNo = FormatPhoneNumber(__items[numCtr].Trim());

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
                    phoneNo = FormatPhoneNumber(phoneNo);
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
    }
}

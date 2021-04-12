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

        private void btnImportCSV_Click(object sender, EventArgs e) {
            openFileDialog.FilterIndex = 1;
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string delimiter = ",";
                string filename = openFileDialog.FileName;

                StreamReader sr = new StreamReader(filename);

                string allData = sr.ReadToEnd();
                string[] rows = allData.Split("\r".ToCharArray());

                dataRecipients.Rows.Clear();

                for (int rowCtr = 0; rowCtr < rows.Length; rowCtr++) {
                    if (rowCtr > 0) {
                        string[] items = rows[rowCtr].Split(delimiter.ToCharArray());
                        dataRecipients.Rows.Add(items);
                    }
                }
                
                MessageBox.Show(filename + " was successfully imported.", "Success!", MessageBoxButtons.OK);
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
                    frmMain.selRecipients.Items.Add(phoneNo);
                }
            }

            frmMain.selRecipients.SelectedIndex = 0;
            frmMain.refreshDisplays();

            this.Close();
        }
    }
}

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
    public partial class LoadingScreenForm : Form
    {
        Timer timer;

        public LoadingScreenForm() {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e) {
            timer.Stop();
            this.Hide();
        }

        private void LoadingScreenForm_Shown(object sender, EventArgs e) {
            timer = new Timer();
            timer.Interval = 3000;
            timer.Start();
            timer.Tick += timer_Tick;
        }
    }
}

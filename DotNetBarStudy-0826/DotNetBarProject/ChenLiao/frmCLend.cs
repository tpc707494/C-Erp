using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetBarProject.ChenLiao
{
    public partial class frmCLend : Form
    {
        private Timer timeClose = new Timer();
        private int StopSec = 5;
        public frmCLend()
        {
            this.InitializeComponent();
        }

        private void this_Load(object sender, EventArgs e)
        {
            this.KeyUp += new KeyEventHandler(this.this_KeyUp);
            this.timeClose.Interval = 1000;
            this.timeClose.Tick += new EventHandler(this.timeClose_Tick);
        }

        private void this_Shown(object sender, EventArgs e)
        {
            this.timeClose.Start();
        }

        private void this_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            this.DialogResult = DialogResult.OK;
        }

        private void timeClose_Tick(object sender, EventArgs e)
        {
            --this.StopSec;
            this.lblEnter.Text = "“确认”退出 (" + this.StopSec.ToString() + ")";
            if (this.StopSec != 0)
                return;
            this.DialogResult = DialogResult.OK;
        }
    }
}

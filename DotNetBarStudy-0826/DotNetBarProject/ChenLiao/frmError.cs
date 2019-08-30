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
    public partial class frmError : Form
    {
        public frmError(string strTS)
        {
            this.InitializeComponent();
            this.lblTS.Text = strTS;
        }

        private void this_Load(object sender, EventArgs e)
        {
        }

        private void this_Shown(object sender, EventArgs e)
        {
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

        private void lblEnter_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

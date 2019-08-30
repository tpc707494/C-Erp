using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    public partial class FrmError : Form
    {
        public FrmError(string strTS)
        {
            InitializeComponent();
            this.lblTS.Text = strTS;
        }

        private void frmError_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            this.DialogResult = DialogResult.OK;
        }

        private void lblEnter_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

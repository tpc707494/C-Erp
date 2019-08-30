using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetBarProject.DL
{
    public partial class frmTS : Form
    {
        private int keyLen = 0;
        private Keys cancelKey;
        public frmTS(
          string _RLname,
          int _chengNum,
          int _dtNum,
          string _strTS,
          string _lblEnter,
          string _lblCancel,
          Keys _cancelKey)
        {
            this.InitializeComponent();
            this.KeyUp += new KeyEventHandler(this.this_KeyUp);
            this.lblRL.Text = _RLname;
            this.lblTP.Text = (_chengNum + 1).ToString();
            this.lblDT.Text = (_dtNum + 1).ToString();
            this.lblTS.Text = _strTS;
            this.lblEnter.Text = _lblEnter;
            this.lblCancel.Text = _lblCancel;
            this.cancelKey = _cancelKey;
        }
        private void this_Load(object sender, EventArgs e)
        {
        }

        private void this_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            ++this.keyLen;
            if (e.KeyCode == Keys.Return)
            {
                if (this.keyLen == 1)
                    this.DialogResult = DialogResult.OK;
                this.keyLen = 0;
            }
            else
            {
                if (e.KeyCode != this.cancelKey)
                    return;
                this.DialogResult = DialogResult.Cancel;
                this.keyLen = 0;
            }
        }

        private void LblCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void LblEnter_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

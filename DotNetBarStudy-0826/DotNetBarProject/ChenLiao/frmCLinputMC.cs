using DotNetBarProject.view.custom.data;
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
    public partial class frmCLinputMC : Form
    {
        private Keys cancelKey;
        private Decimal CLmbzl = new Decimal(0);
        public frmCLinputMC(Decimal _CLmbzl, string _lblEnter, string _lblCancel, Keys _cancelKey)
        {
            this.InitializeComponent();
            this.CLmbzl = _CLmbzl;
            this.cancelKey = _cancelKey;
            this.lblTS.Text = "请输入免称重量 ( 0 <= 数值 <= " + this.CLmbzl.ToString("0.####") + " )";
            this.lblEnter.Text = _lblEnter;
            this.lblCancel.Text = _lblCancel;
        }

        private void this_Load(object sender, EventArgs e)
        {
            this.txtZL.Focus();
            this.txtZL.LostFocus += new EventHandler(this.txtSch_LostFocus);
        }

        private void this_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void txtSch_LostFocus(object sender, EventArgs e)
        {
            this.txtZL.Focus();
        }

        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.txtZL.Text = this.txtZL.Text.Trim();
                if (this.txtZL.Text == "" || !UserProc.IsNumeric(this.txtZL.Text) || Convert.ToDecimal(this.txtZL.Text) < new Decimal(0) || Convert.ToDecimal(this.txtZL.Text) > this.CLmbzl)
                {
                    this.txtZL.SelectAll();
                    this.txtZL.Focus();
                }
                else
                    this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (e.KeyCode != this.cancelKey)
                    return;
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}

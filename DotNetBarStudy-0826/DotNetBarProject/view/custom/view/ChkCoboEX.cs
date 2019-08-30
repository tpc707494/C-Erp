using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetBarProject.view.custom.data;

namespace DotNetBarProject.view.custom.view
{
    public partial class ChkCoboEX : UserControl
    {
        private ErrorProvider errP = new ErrorProvider();
        private int _txtLen = 50;
        private bool _allowEmpty = false;
        private bool _txtISbyte = false;
        private bool _allowInput = true;
        private int _jiange = 0;
        public ChkCoboEX()
        {
            InitializeComponent();
        }
        public Font chkFont
        {
            get
            {
                return this.chk.Font;
            }
            set
            {
                this.chk.Font = value;
                this.thisResize();
            }
        }

        public string chkText
        {
            get
            {
                return this.chk.Text;
            }
            set
            {
                this.chk.Text = value;
                this.thisResize();
            }
        }

        public bool chkSel
        {
            get
            {
                return this.chk.Checked;
            }
            set
            {
                this.chk.Checked = value;
            }
        }

        public Font coboFont
        {
            get
            {
                return this.coboex.Font;
            }
            set
            {
                this.coboex.Font = value;
                this.thisResize();
            }
        }

        public FlatStyle coboFlatStyle
        {
            get
            {
                return this.coboex.FlatStyle;
            }
            set
            {
                this.coboex.FlatStyle = value;
            }
        }

        public int txtLen
        {
            get
            {
                return this._txtLen;
            }
            set
            {
                this._txtLen = value;
            }
        }

        public bool allowEmpty
        {
            get
            {
                return this._allowEmpty;
            }
            set
            {
                this._allowEmpty = value;
            }
        }

        public bool txtISbyte
        {
            get
            {
                return this._txtISbyte;
            }
            set
            {
                this._txtISbyte = value;
            }
        }

        public bool allowInput
        {
            get
            {
                return this._allowInput;
            }
            set
            {
                this._allowInput = value;
                this.coboex.DropDownStyle = this._allowInput ? ComboBoxStyle.DropDown : ComboBoxStyle.DropDownList;
            }
        }

        public int jiange
        {
            get
            {
                return this._jiange;
            }
            set
            {
                this._jiange = value;
                this.thisResize();
            }
        }

        private void this_Load(object sender, EventArgs e)
        {
            this.chk.CheckedChanged += new EventHandler(this.chk_CheckedChanged);
            this.coboex.Validating += new CancelEventHandler(this.coboEX_Validating);
            this.thisResize();
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk.Checked)
            {
                this.coboex.BackColor = Color.White;
                this.coboex.Enabled = true;
                this.coboex.Focus();
            }
            else
            {
                this.coboex.EmptyText();
                this.coboex.BackColor = SystemColors.Control;
                this.coboex.Enabled = false;
                this.errP.SetError((Control)this, "");
            }
        }

        private void coboEX_Validating(object sender, CancelEventArgs e)
        {
            if (this.chk.Checked)
            {
                if (this._allowInput)
                    this.coboex.Text = this.coboex.Text.Trim();
                if (this.coboex.Text == "" && !this._allowEmpty)
                {
                    e.Cancel = true;
                    this.errP.SetError((Control)this, "输入数据");
                    return;
                }
                if (this.coboex.Text.Length > this._txtLen)
                {
                    e.Cancel = true;
                    this.errP.SetError((Control)this, "字数不能大于:" + this._txtLen.ToString());
                    return;
                }
                if (this._txtISbyte && (!UserProc.IsInt(this.coboex.Text) || Convert.ToInt16(this.coboex.Text) >= (short)256))
                {
                    e.Cancel = true;
                    this.errP.SetError((Control)this, "小于256的整数");
                    return;
                }
            }
            this.errP.SetError((Control)this, "");
        }

        private void thisResize()
        {
            Graphics graphics = CreateGraphics();

            SizeF sizeF = graphics.MeasureString(chk.Text, chk.Font);
            SuspendLayout();
            Resize -= new EventHandler(this_Resize);
            Height = coboex.Height;
            chk.Left = 0;
            //chk.Top = (coboex.Height - chk.Height) / 2;
            //chk.Width = Convert.ToInt32(sizeF.Width) + Convert.ToInt32(sizeF.Width / chk.Text.Length);
            //coboex.Left = chk.Width + _jiange;
            coboex.Top = 0;
            //coboex.Width = this.Width - this.chk.Width - this._jiange;

            ResumeLayout(false);
            PerformLayout();

            Resize += new EventHandler(this.this_Resize);
        }
        private void this_Resize(object sender, EventArgs e)
        {
            this.thisResize();
        }
    }
}

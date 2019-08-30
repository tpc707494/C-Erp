using DotNetBarProject.view.custom.data;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{

    public partial class ChkTxt : UserControl
    {
        private ErrorProvider errP = new ErrorProvider();
        private int _txtLen = 50;
        private bool _allowEmpty = false;
        private bool _txtISid = false;
        private bool _txtISint = false;
        private bool _txtISmoney = false;
        private int _jiange = 0;
        private bool _txtTop = true;
        

        

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

        public Font txtFont
        {
            get
            {
                return this.txt.Font;
            }
            set
            {
                this.txt.Font = value;
                this.thisResize();
            }
        }

        public bool txtMulLine
        {
            get
            {
                return this.txt.Multiline;
            }
            set
            {
                this.txt.Multiline = value;
            }
        }

        public BorderStyle txtBorderStyle
        {
            get
            {
                return this.txt.BorderStyle;
            }
            set
            {
                this.txt.BorderStyle = value;
                this.thisResize();
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

        public bool txtISid
        {
            get
            {
                return this._txtISid;
            }
            set
            {
                this._txtISid = value;
            }
        }

        public bool txtISint
        {
            get
            {
                return this._txtISint;
            }
            set
            {
                this._txtISint = value;
            }
        }

        public bool txtISmoney
        {
            get
            {
                return this._txtISmoney;
            }
            set
            {
                this._txtISmoney = value;
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

        public bool txtTop
        {
            get
            {
                return this._txtTop;
            }
            set
            {
                this._txtTop = value;
                this.thisResize();
            }
        }

        public bool ReadOnly
        {
            get
            {
                return !this.chk.AutoCheck;
            }
            set
            {
                this.chk.AutoCheck = !value;
                this.txt.ReadOnly = value;
            }
        }

        public ChkTxt()
        {
            this.InitializeComponent();
            this.errP.ContainerControl = (ContainerControl)this.FindForm();
            this.errP.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            this.errP.Icon = new Icon(SystemIcons.Error, 50, 50);
            this.chk.CausesValidation = false;
        }

        private void this_Load(object sender, EventArgs e)
        {
            this.chk.CheckedChanged += new EventHandler(this.Chk_CheckedChanged);
            this.txt.Validating += new CancelEventHandler(this.Txt_Validating);
            this.thisResize();
        }

        private void thisResize()
        {
            this.Resize -= new EventHandler(this.this_Resize);
            if (this._txtTop)
            {
                this.chk.Left = 0;
                this.txt.Top = 0;
                this.txt.Left = this.chk.Width + this._jiange;
                this.txt.Width = this.Width - this.chk.Width - this._jiange;
                if (!this.txt.Multiline)
                {
                    this.chk.Top = (this.txt.Height - this.chk.Height) / 2;
                }
                else
                {
                    this.chk.Top = 0;
                    this.txt.Height = this.Height;
                }
            }
            else
            {
                this.chk.Left = 0;
                this.chk.Top = 0;
                this.txt.Left = 0;
                this.txt.Top = this.chk.Height;
                this.txt.Width = this.Width;
                if (this.txt.Multiline)
                    this.txt.Height = this.Height - this.chk.Height;
            }
            this.Resize += new EventHandler(this.this_Resize);
        }

        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk.Checked)
            {
                this.txt.Enabled = true;
                this.txt.BackColor = Color.White;
                this.txt.Focus();
            }
            else
            {
                this.txt.Text = "";
                this.txt.Enabled = false;
                this.txt.BackColor = SystemColors.Control;
                this.errP.SetError((Control)this, "");
            }
        }

        private void Txt_Validating(object sender, CancelEventArgs e)
        {
            if (this.chk.Checked)
            {
                this.txt.Text = this.txt.Text.Trim();
                if (this.txt.Text == "" && !this._allowEmpty)
                {
                    e.Cancel = true;
                    this.errP.SetError((Control)this, "输入数据");
                    return;
                }
                if (this.txt.Text.Length > 0)
                {
                    if (this.txt.Text.Length > this._txtLen)
                    {
                        e.Cancel = true;
                        this.errP.SetError((Control)this, "字数不能大于:" + this._txtLen.ToString());
                        return;
                    }
                    if (this._txtISid && !Regex.IsMatch(this.txt.Text, "[A-Z0-9-]{" + this.txt.Text.Length.ToString() + "}"))
                    {
                        e.Cancel = true;
                        this.errP.SetError((Control)this, "大写字母、数字、- 的组合");
                        return;
                    }
                    if (this._txtISint && !UserProc.IsInt(this.txt.Text))
                    {
                        e.Cancel = true;
                        this.errP.SetError((Control)this, "整数");
                        return;
                    }
                    if (this._txtISmoney && !UserProc.IsNumeric(this.txt.Text))
                    {
                        e.Cancel = true;
                        this.errP.SetError((Control)this, "数值型");
                        return;
                    }
                }
            }
            this.errP.SetError((Control)this, "");
        }

        private void this_Resize(object sender, EventArgs e)
        {
            this.thisResize();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DotNetBarProject.view.custom.data;

namespace DotNetBarProject.view.custom.view
{
    public partial class LblTxt : UserControl
    {
        private ErrorProvider errP = new ErrorProvider();

        private int _jiange = 5;

        private int _txtLen = 50;

        private bool _txtISid = false;

        private bool _txtISint = false;

        private bool _txtISmoney = false;
        private bool _upperZero = false;
        private bool _txtUpper = false;

        private bool _txtTop = true;


        public bool ReadOnly
        {
            get
            {
                return this.txt.ReadOnly;
            }
            set
            {
                this.txt.ReadOnly = value;
                if (this.txt.ReadOnly)
                    this.txt.BackColor = SystemColors.Control;
                else
                    this.txt.BackColor = SystemColors.Window;
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

        public Font lblFont
        {
            get
            {
                return this.lbl.Font;
            }
            set
            {
                this.lbl.Font = value;
                this.thisResize();
            }
        }

        public string lblText
        {
            get
            {
                return this.lbl.Text;
            }
            set
            {
                this.lbl.Text = value;
                this.thisResize();
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
        public bool upperZero
        {
            get
            {
                return this._upperZero;
            }
            set
            {
                this._upperZero = value;
            }
        }
        public bool txtUpper
        {
            get
            {
                return this._txtUpper;
            }
            set
            {
                this._txtUpper = value;
            }
        }
        public Color txtBackColor
        {
            get
            {
                return this.txt.BackColor;
            }
            set
            {
                this.txt.BackColor = value;
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
                if (this.txt.Multiline)
                {
                    this.txt.ScrollBars = ScrollBars.Vertical;
                }
                else
                {
                    this.txt.ScrollBars = ScrollBars.None;
                }
            }
        }

        public bool txtReadonly
        {
            get
            {
                return this.txt.ReadOnly;
            }
            set
            {
                this.txt.ReadOnly = value;
            }
        }

        public LblTxt()
        {
            this.InitializeComponent();
            this.errP.ContainerControl = base.FindForm();
            this.errP.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            this.errP.Icon = new Icon(SystemIcons.Error, 100, 100);
            base.Size = new Size(this.lbl.Width + this._jiange + this.txt.Width, this.txt.Height);
        }

        private void this_Load(object sender, EventArgs e)
        {
            this.txt.Validating += new CancelEventHandler(this.Txt_Validating);
            this.thisResize();
        }

        private void thisResize()
        {
            base.Resize -= new EventHandler(this.this_Resize);
            if (this.txtTop)
            {
                this.lbl.Left = 0;
                this.txt.Top = 0;
                this.txt.Left = this.lbl.Width + this._jiange;
                this.txt.Width = base.Width - this.lbl.Width - this._jiange;
                if (this.txt.Multiline)
                {
                    this.txt.Height = base.Height;
                }
                if (this.txt.BorderStyle == BorderStyle.None)
                {
                    this.lbl.Top = 0;
                }
                else
                {
                    this.lbl.Top = (this.txt.Height - this.lbl.Height) / 2;
                }
            }
            else
            {
                this.lbl.Left = 0;
                this.lbl.Top = 0;
                this.txt.Left = 0;
                this.txt.Top = this.lbl.Height + this._jiange;
                this.txt.Width = base.Width;
                if (this.txt.Multiline)
                {
                    this.txt.Height = base.Height - this.lbl.Height - this._jiange;
                }
            }
            base.Resize += new EventHandler(this.this_Resize);
        }

        private void this_Resize(object sender, EventArgs e)
        {
            this.thisResize();
        }

        private void Txt_Validating(object sender, CancelEventArgs e)
        {
            this.txt.Text = this.txt.Text.Trim();
            if (this.txt.Text.Length > 0)
            {
                if (this.txt.Text.Length > this._txtLen)
                {
                    e.Cancel = true;
                    this.errP.SetError(this, "字数不能大于:" + this._txtLen.ToString());
                    return;
                }
                if (this._txtISid && !Regex.IsMatch(this.txt.Text, "[A-Z0-9-]{" + this.txt.Text.Length.ToString() + "}"))
                {
                    e.Cancel = true;
                    this.errP.SetError(this, "大写字母、数字、- 的组合");
                    return;
                }
                if (this._txtISint && !UserProc.IsInt(this.txt.Text))
                {
                    e.Cancel = true;
                    this.errP.SetError(this, "整数");
                    return;
                }
                if (this._txtISmoney && !UserProc.IsNumeric(this.txt.Text))
                {
                    e.Cancel = true;
                    this.errP.SetError(this, "数值");
                    return;
                }
            }
            this.errP.SetError(this, "");
        }
    }
}

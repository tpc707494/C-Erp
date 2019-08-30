using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    public partial class ChkDtime : UserControl
    {
        private ErrorProvider errP = new ErrorProvider();
        private DateTimePickerFormat _dtimeFormat = DateTimePickerFormat.Custom;
        private string _dtimeFromatStr = "yyyy-MM-dd HH:mm";
        private bool _dtimeShowUpDown = false;
        private int _jiange = 0;
        public ChkDtime()
        {
            InitializeComponent();
            this.errP.ContainerControl = (ContainerControl)this.FindForm();
            this.errP.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            this.errP.Icon = new Icon(SystemIcons.Error, 50, 50);
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
                this.lblTo.Font = value;
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

        public Color lblColor
        {
            get
            {
                return this.lbl.ForeColor;
            }
            set
            {
                this.lbl.ForeColor = value;
            }
        }

        public Font dtimeFont
        {
            get
            {
                return this.dtimeF.Font;
            }
            set
            {
                this.dtimeF.Font = value;
                this.dtimeT.Font = value;
                this.thisResize();
            }
        }

        public DateTimePickerFormat dtimeFormat
        {
            get
            {
                return this._dtimeFormat;
            }
            set
            {
                this._dtimeFormat = value;
                this.dtimeF.Format = this._dtimeFormat;
                this.dtimeT.Format = this._dtimeFormat;
            }
        }

        public string dtimeFormatStr
        {
            get
            {
                return this._dtimeFromatStr;
            }
            set
            {
                this._dtimeFromatStr = value;
                this.dtimeF.CustomFormat = this._dtimeFromatStr;
                this.dtimeT.CustomFormat = this._dtimeFromatStr;
            }
        }

        public bool dtimeShowUpDown
        {
            get
            {
                return this._dtimeShowUpDown;
            }
            set
            {
                this._dtimeShowUpDown = value;
                this.dtimeF.ShowUpDown = this._dtimeShowUpDown;
                this.dtimeT.ShowUpDown = this._dtimeShowUpDown;
            }
        }

        public bool chkFsel
        {
            get
            {
                return this.chkF.Checked;
            }
            set
            {
                this.chkF.Checked = value;
            }
        }

        public bool chkTsel
        {
            get
            {
                return this.chkT.Checked;
            }
            set
            {
                this.chkT.Checked = value;
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

        private void thisResize()
        {
            this.Resize -= new EventHandler(this.this_Resize);
            this.SuspendLayout();
            this.lbl.Top = (this.dtimeF.Height - this.lbl.Height) / 2;
            this.lbl.Left = 0;
            this.chkF.Top = (this.dtimeF.Height - this.chkF.Height) / 2;
            this.chkF.Left = this.lbl.Width + this._jiange;
            this.dtimeF.Top = 0;
            this.dtimeF.Left = this.chkF.Left + this.chkF.Width;
            //this.dtimeF.Width = (this.Width - this.lbl.Width - this._jiange - this.chkF.Width * 2 - this.lblTo.Width) / 2;
            this.lblTo.Top = (this.dtimeF.Height - this.lblTo.Height) / 2;
            this.lblTo.Left = this.dtimeF.Left + this.dtimeF.Width;
            this.chkT.Top = this.chkF.Top;
            this.chkT.Left = this.lblTo.Left + this.lblTo.Width;
            this.dtimeT.Top = 0;
            this.dtimeT.Left = this.chkT.Left + this.chkT.Width;
            //this.dtimeT.Width = this.dtimeF.Width;
            this.ResumeLayout(false);
            //Width = lbl.Width + chkF.Width + dtimeF.Width + lblTo.Width + chkT.Width + dtimeF.Width;
            this.PerformLayout();
            this.Resize += new EventHandler(this.this_Resize);
        }

        private void chkF_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("选中"+chkF.Checked);
            if (chkF.Checked)
            {
                this.dtimeF.Enabled = true;
                this.dtimeF.Value = DateTime.Today;
                this.dtimeF.Focus();
            }
            else
                dtimeF.Enabled = false;
        }

        private void chkT_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("选中" + chkT.Checked);
            if (this.chkT.Checked)
            {
                this.dtimeT.Enabled = true;
                this.dtimeT.Value = DateTime.Today.AddDays(1.0);
                this.dtimeT.Focus();
            }
            else
                this.dtimeT.Enabled = false;
        }

        private void this_Resize(object sender, EventArgs e)
        {
            this.thisResize();
        }

        private void this_Validating(object sender, CancelEventArgs e)
        {
            if (this.chkF.Checked && this.chkT.Checked && this.dtimeF.Value > this.dtimeT.Value)
            {
                e.Cancel = true;
                this.errP.SetError((Control)this, "起始不能大于结束");
            }
            else
                this.errP.SetError((Control)this, "");
        }

        private void ChkDtime_Load(object sender, EventArgs e)
        {
            this.chkF.CheckedChanged += new EventHandler(this.chkF_CheckedChanged);
            this.chkT.CheckedChanged += new EventHandler(this.chkT_CheckedChanged);
            this.Validating += new CancelEventHandler(this.this_Validating);
            this.thisResize();
        }
    }
}

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
    public partial class ChkCoboDGV : UserControl
    {
        private ErrorProvider errP = new ErrorProvider();
        private string _SeparatorChar = " ";
        private bool _allowEmpty = false;
        private bool _allowInput = true;
        private int _jiange = 0;
        public ChkCoboDGV()
        {
            InitializeComponent();
            this.errP.ContainerControl = (ContainerControl)this.FindForm();
            this.errP.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            this.errP.Icon = new Icon(SystemIcons.Error, 100, 100);
            this.chk.CausesValidation = false;
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

        public Font cobodgvFont
        {
            get
            {
                return this.cobodgv.Font;
            }
            set
            {
                this.cobodgv.Font = value;
                this.thisResize();
            }
        }

        public FlatStyle coboFlatStyle
        {
            get
            {
                return this.cobodgv.FlatStyle;
            }
            set
            {
                this.cobodgv.FlatStyle = value;
            }
        }

        public string SeparatorChar
        {
            set
            {
                this._SeparatorChar = value;
                this.cobodgv.SeparatorChar = value;
            }
            get
            {
                return this.cobodgv.SeparatorChar;
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

        public bool allowInput
        {
            get
            {
                return this._allowInput;
            }
            set
            {
                this._allowInput = value;
                this.cobodgv.allowInput = this._allowInput;
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
                //this.thisResize();
            }
        }
        private void this_Load(object sender, EventArgs e)
        {
            this.chk.CheckedChanged += new EventHandler(this.chk_CheckedChanged);
            this.cobodgv.Validating += new CancelEventHandler(this.cobodgv_Validating);
            //this.thisResize();
        }
        private void thisResize()
        {
            Graphics graphics = CreateGraphics();

            SizeF sizeF = graphics.MeasureString(chk.Text, chk.Font);
            SuspendLayout();
            Resize -= new EventHandler(this_Resize);
            Height = cobodgv.Height;
            chk.Left = 0;
            //chk.Top = (cobodgv.Height - chk.Height) / 2;
            //chk.Width = Convert.ToInt32(sizeF.Width) + Convert.ToInt32(sizeF.Width /chk.Text.Length);
            //cobodgv.Left = chk.Width + _jiange;
            cobodgv.Top = 0;
            //cobodgv.Width = this.Width - this.chk.Width - this._jiange;
            
            ResumeLayout(false);
            PerformLayout();
            
            Resize += new EventHandler(this.this_Resize);
        }
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk.Checked)
            {
                this.cobodgv.Enabled = true;
                this.cobodgv.Focus();
            }
            else
            {
                this.cobodgv.Text = "";
                this.cobodgv.Enabled = false;
                this.errP.SetError((Control)this, "");
            }
        }

        private void cobodgv_Validating(object sender, CancelEventArgs e)
        {
            if (this.chk.Checked)
            {
                if (this.allowInput)
                    this.cobodgv.Text = this.cobodgv.Text.Trim();
                if (this.cobodgv.Text == "" && !this._allowEmpty)
                {
                    e.Cancel = true;
                    this.errP.SetError((Control)this, "输入数据");
                    return;
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    public partial class LblCoboEX : UserControl
    {
        private bool _allowInput = true;
        private int _jiange = 5;
        public LblCoboEX()
        {
            InitializeComponent();
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

        public Font coboFont
        {
            get
            {
                return this.coboEX1.Font;
            }
            set
            {
                this.coboEX1.Font = value;
                this.thisResize();
            }
        }

        public FlatStyle coboFlatStyle
        {
            get
            {
                return this.coboEX1.FlatStyle;
            }
            set
            {
                this.coboEX1.FlatStyle = value;
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
                this.coboEX1.DropDownStyle = this._allowInput ? ComboBoxStyle.DropDown : ComboBoxStyle.DropDownList;
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
        private void cobo_Validating(object sender, CancelEventArgs e)
        {
            if (!this.allowInput)
                return;
            this.coboEX1.Text = this.coboEX1.Text.Trim();
        }
        private void LblCoboEX_Load(object sender, EventArgs e)
        {
            coboEX1.Validating += new CancelEventHandler(this.cobo_Validating);
            thisResize();
        }
        private void this_Resize(object sender, EventArgs e)
        {
            this.thisResize();
        }
        private void thisResize()
        {
            Resize -= new EventHandler(this.this_Resize);
            SuspendLayout();
            lbl.Left = 0;
            lbl.Top = (this.coboEX1.Height - this.lbl.Height) / 2;
            coboEX1.Left = this.lbl.Width + this._jiange;
            coboEX1.Top = 0;
            coboEX1.Width = this.Width - this.lbl.Width - this._jiange;
            ResumeLayout(false);
            PerformLayout();
            Resize += new EventHandler(this.this_Resize);
        }
    }
}

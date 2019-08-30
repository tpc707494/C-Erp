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
    public partial class lblDGV : UserControl
    {
        private string _SeparatorChar = " ";
        private bool _allowInput = true;
        private int _jiange = 5;
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
                this.thisResize();
            }
        }

        public lblDGV()
        {
            this.InitializeComponent();
            
        }

        private void this_Load(object sender, EventArgs e)
        {
            this.cobodgv.Validating += new CancelEventHandler(this.cobodgv_Validating);
            this.thisResize();
            cobodgv.TextUpdate += Cobodgv_TextUpdate;
        }

        private void Cobodgv_TextUpdate(object sender, EventArgs e)
        {
            if (cobodgv.Text.Length != 0)
            {
                cobodgv.ShowDropDown();
                cobodgv.Focus();
                cobodgv.SelectionStart = this.cobodgv.Text.Length;
            }
        }

        private void thisResize()
        {
            this.Resize -= new EventHandler(this.this_Resize);
            this.SuspendLayout();
            this.lbl.Left = 0;
            this.lbl.Top = (this.cobodgv.Height - this.lbl.Height) / 2;
            this.cobodgv.Left = this.lbl.Width + this._jiange;
            this.cobodgv.Top = 0;
            this.cobodgv.Width = this.Width - this.lbl.Width - this._jiange;
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Resize += new EventHandler(this.this_Resize);
        }

        private void this_Resize(object sender, EventArgs e)
        {
            this.thisResize();
        }

        private void cobodgv_Validating(object sender, CancelEventArgs e)
        {
            if (!this.allowInput)
                return;
            this.cobodgv.Text = this.cobodgv.Text.Trim();
        }
    }
}

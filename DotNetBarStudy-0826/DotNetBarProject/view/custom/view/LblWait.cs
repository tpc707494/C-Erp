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
    public partial class LblWait : UserControl
    {
        
        public LblWait(Form _frm)
        {
            this.InitializeComponent();
            this.Visible = false;
            this.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.frm = _frm;
            this.frm.Controls.Add((Control)this);
            this.BringToFront();
        }

        public void showme()
        {
            this.Visible = true;
            this.Left = (this.frm.ClientSize.Width - this.Width) / 2;
            this.Top = (this.frm.ClientSize.Height - this.Height) / 2;
            Application.DoEvents();
            Application.DoEvents();
        }

        public void hideme()
        {
            this.Visible = false;
        }
    }
}

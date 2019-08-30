using DotNetBarProject.view.custom.data;
using System;
using System.Windows.Forms;

namespace DotNetBarProject.view.about
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.lblGS.Text = UserProc.GSname;
            this.lblBB.Text = UserProc.StrVer;
        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

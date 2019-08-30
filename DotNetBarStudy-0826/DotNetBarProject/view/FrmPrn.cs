using DotNetBarProject.view.custom.data;
using System;
using System.Windows.Forms;

namespace DotNetBarProject.view
{
    public partial class FrmPrn : Form
    {

        public FrmPrn()
        {
            InitializeComponent();

            rptView.Messages = new ReportViewerMessage();
            //this.Text = "-----------测试打印-------";
        }
        

        private void FrmPrn_Load(object sender, EventArgs e)
        {
        }

        private void FrmPrn_FormClosing(object sender, FormClosingEventArgs e)
        {
            rptView.Dispose();
        }
        

        private void FrmPrn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.P))
            {
                rptView.PrintDialog();
            }
            else if (e.KeyData == Keys.R)
            {
                rptView.RefreshReport();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    public partial class dgvEXprnOptions : Form
    {
        private Dictionary<string, bool> chkVal;

        private List<string> chkCol = new List<string>();


        internal Label lblColumnsToPrint;

        private RadioButton optPaperH;

        private RadioButton optPaperZ;

        private CheckBox chkFitToPageWidth;

        private GroupBox gboxRowsToPrint;

        private Button btnOK;

        private Button btnCancel;

        private CheckedListBox chklst;

        public bool PaperZ
        {
            get
            {
                return this.optPaperZ.Checked;
            }
        }

        public bool FitToPageWidth
        {
            get
            {
                return this.chkFitToPageWidth.Checked;
            }
        }

        public dgvEXprnOptions(DataGridView dgv, ref Dictionary<string, bool> chkval, bool paperZ, bool fitpaperwidth)
        {
            this.InitializeComponent();
            this.chkVal = chkval;
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                if (dgv.Columns[i].Visible)
                {
                    this.chklst.Items.Add(dgv.Columns[i].HeaderText, this.chkVal[dgv.Columns[i].Name]);
                    this.chkCol.Add(dgv.Columns[i].Name);
                }
            }
            if (paperZ)
            {
                this.optPaperZ.Checked = true;
            }
            else
            {
                this.optPaperH.Checked = true;
            }
            this.chkFitToPageWidth.Checked = fitpaperwidth;
        }

        private void PrintOtions_Load(object sender, EventArgs e)
        {
            this.chklst.ItemCheck += new ItemCheckEventHandler(this.chklst_ItemCheck);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void chklst_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.chkVal[this.chkCol[e.Index]] = (e.NewValue == CheckState.Checked);
        }
    }
}

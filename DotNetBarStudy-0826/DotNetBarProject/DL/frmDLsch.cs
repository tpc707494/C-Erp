using DotNetBarProject.Properties;
using DotNetBarProject.view.custom.data;
using SqlSugar;
using System;
using System.Data;
using System.Windows.Forms;

namespace DotNetBarProject.DL
{
    public partial class frmDLsch : Form
    {
        private Keys cancelKey;
        private SqlSugarClient db = null;
        public frmDLsch(string _lblCancel, Keys _cancelKey)
        {
            this.InitializeComponent();
            this.lblCancel.Text = _lblCancel;
            this.cancelKey = _cancelKey;
            if(db==null)
                db = SqlBase.GetInstance();
        }

        private void this_Load(object sender, EventArgs e)
        {
            this.txtSch.Focus();
            this.txtSch.LostFocus += new EventHandler(this.txtSch_LostFocus);
        }

        private void this_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void txtSch_LostFocus(object sender, EventArgs e)
        {
            this.txtSch.Focus();
            this.txtSch.Select(this.txtSch.Text.Length, 0);
            this.txtSch.ScrollToCaret();
        }

        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.txtSch.Text = this.txtSch.Text.Trim();
                if (this.txtSch.Text == "")
                {
                    frmError frmError = new frmError("无料单号,无法显示!!!");
                    int num = (int)frmError.ShowDialog((IWin32Window)this);
                    frmError.Close();
                }
                else
                {
                    DataTable dataTable1 = new DataTable();
                    DataTable dataTable2 = new DataTable();
                    //using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DBconn))
                    {
                        //sqlConnection.Open();
                        //SqlCommand command = sqlConnection.CreateCommand();
                        //command.CommandTimeout = 300;
                        string CommandText = "select 1 from T_PFmain where danhao = '" + this.txtSch.Text + "' and sta = '已审核.ToString()'";
                        //SqlDataReader sqlDataReader1 = command.ExecuteReader();
                        dataTable1 = db.Ado.GetDataTable(CommandText);
                        if (dataTable1.Rows.Count != 1)
                        {
                            //sqlDataReader1.Close();
                            //sqlDataReader1.Dispose();
                            //command.Dispose();
                            dataTable1.Dispose();
                            dataTable2.Dispose();
                            frmError frmError = new frmError("无法找到此料单数据!!!");
                            int num = (int)frmError.ShowDialog((IWin32Window)this);
                            frmError.Close();
                            return;
                        }
                        string sql = "";
                        if (this.txtSch.Text.StartsWith("LD") || this.txtSch.Text.Length == 10 && this.txtSch.Text.StartsWith("8"))
                            sql = "select 1 from T_PFdata a join T_Base b on a.ranliao = b.item0 and b.leibie = '滴料头' and b.bianhao = '" + Settings.Default.DLjihao + "' where a.danhao = '" + this.txtSch.Text + "' and a.yongliang > 0 order by b.itemName";
                        else
                            sql = "select 1 from T_PFdata a join T_Base b on a.ranliao = b.item0 and b.leibie = '滴料头' and b.bianhao = '" + Settings.Default.DLjihao + "' where a.danhao = '" + this.txtSch.Text + "' and a.JLyongliang > 0 order by b.itemName";
                        //SqlDataReader sqlDataReader2 = command.ExecuteReader();
                        dataTable2 = db.Ado.GetDataTable(sql);
                        //sqlDataReader2.Close();
                        //sqlDataReader2.Dispose();
                        //command.Dispose();
                    }
                    if (dataTable2.Rows.Count == 0)
                    {
                        dataTable1.Dispose();
                        dataTable2.Dispose();
                        frmError frmError = new frmError("无法找到此料单用量数据!!!");
                        int num = (int)frmError.ShowDialog((IWin32Window)this);
                        frmError.Close();
                    }
                    else
                        this.DialogResult = DialogResult.OK;
                }
            }
            else if (e.KeyCode == this.cancelKey)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                if (e.KeyCode != Keys.Prior && e.KeyCode != Keys.Next)
                    return;
                if (this.lblTS.Text == "查询料单号（扫描输入）")
                {
                    this.lblTS.Text = "查询料单号（键盘输入）";
                    this.txtSch.Text = "8" + DateTime.Today.ToString("yyMM");
                    this.txtSch.Select(this.txtSch.Text.Length, 0);
                    this.txtSch.ScrollToCaret();
                }
                else
                {
                    this.lblTS.Text = "查询料单号（扫描输入）";
                    this.txtSch.Text = "";
                }
            }
        }
    }
}

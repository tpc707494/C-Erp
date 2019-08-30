using DotNetBarProject.view.custom.data;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetBarProject.ChenLiao
{
    public partial class frmCLsch : Form
    {
        private Keys cancelKey;

        private SqlSugarClient db = null;
        public frmCLsch(string _lblCancel, Keys _cancelKey)
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

                        string CommandText = "select 1 from T_PFmain where danhao = '" + this.txtSch.Text + "' and sta = '已审核'";
                        //SqlDataReader sqlDataReader1 = command.ExecuteReader();
                        dataTable1 = db.Ado.GetDataTable(CommandText);
                        if (dataTable1.Rows.Count != 1)
                        {
                            //sqlDataReader1.Close();
                            //sqlDataReader1.Dispose();
                            //command.Dispose();
                            dataTable1.Dispose();
                            dataTable2.Dispose();
                            frmError frmError = new frmError("此料单单号不存在或者未审核!!!");
                            int num = (int)frmError.ShowDialog((IWin32Window)this);
                            frmError.Close();
                            return;
                        }
                        string sql;
                        if (this.txtSch.Text.StartsWith("LD") || this.txtSch.Text.Length == 10 && this.txtSch.Text.StartsWith("8"))
                            sql = "select * from T_PFdata a where a.danhao = '" + this.txtSch.Text + "' and a.ranliao in(select item0 from T_Base where leibie = '染料名称') and a.yongliang > 0";
                        else
                            sql = "select * from T_PFdata a where a.danhao = '" + this.txtSch.Text + "' and a.ranliao in(select item0 from T_Base where leibie = '染料名称') and a.JLyongliang > 0";
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

        private void LblCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void LblEnter_Click(object sender, EventArgs e)
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

                    string CommandText = "select 1 from T_PFmain where danhao = '" + this.txtSch.Text + "' and sta = '已审核'";
                    //SqlDataReader sqlDataReader1 = command.ExecuteReader();
                    dataTable1 = db.Ado.GetDataTable(CommandText);
                    if (dataTable1.Rows.Count != 1)
                    {
                        //sqlDataReader1.Close();
                        //sqlDataReader1.Dispose();
                        //command.Dispose();
                        dataTable1.Dispose();
                        dataTable2.Dispose();
                        frmError frmError = new frmError("此料单单号不存在或者未审核!!!");
                        int num = (int)frmError.ShowDialog((IWin32Window)this);
                        frmError.Close();
                        return;
                    }
                    string sql;
                    if (this.txtSch.Text.StartsWith("LD") || this.txtSch.Text.Length == 10 && this.txtSch.Text.StartsWith("8"))
                        sql = "select * from T_PFdata a where a.danhao = '" + this.txtSch.Text + "' and a.ranliao in(select item0 from T_Base where leibie = '染料名称') and a.yongliang > 0";
                    else
                        sql = "select * from T_PFdata a where a.danhao = '" + this.txtSch.Text + "' and a.ranliao in(select item0 from T_Base where leibie = '染料名称') and a.JLyongliang > 0";
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
    }
}

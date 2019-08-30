using BarcodeLib;
using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using DotNetBarProject.view.custom.view;
using Microsoft.Reporting.WinForms;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DotNetBarProject.view.RanHuaCB
{
    public partial class FrmPFCB : Office2007Form
    {
        public SqlSugarClient db;
        private LblWait lblwait;
        private string strSch = "";
        private string showLDH = "";
        private BindingSource bsSch;
        private BindingSource bsShowMain;
        private BindingSource bsShowData;
        public FrmPFCB()
        {
            InitializeComponent();
            db = SqlBase.GetInstance();
            this.lblwait = new LblWait((Form)this);


            this.bsSch = new BindingSource();
            this.bsShowMain = new BindingSource();
            this.bsShowData = new BindingSource();
            this.mainDgv.AutoGenerateColumns = false;
            this.mainDgv.Dock = DockStyle.Fill;
            this.editDgvMain.Dock = DockStyle.Fill;
            this.dgvSum();
            this.lblwait = new LblWait((Form)this);
            this.editTxtDJ.txt.TextAlign = HorizontalAlignment.Center;
            this.editTxtKZ.txt.TextAlign = HorizontalAlignment.Center;
            this.editTxtMS.txt.TextAlign = HorizontalAlignment.Center;
            this.editTxtJH.txt.TextAlign = HorizontalAlignment.Center;
            this.editTxtSL.txt.TextAlign = HorizontalAlignment.Center;
            this.editTxtZL.txt.TextAlign = HorizontalAlignment.Center;
            this.editTxtJLCS.txt.TextAlign = HorizontalAlignment.Center;
            this.editTxtDJ.txt.ForeColor = Color.DarkRed;
            this.editTxtKZ.txt.ForeColor = Color.DarkRed;
            this.editTxtMS.txt.ForeColor = Color.DarkRed;
            this.editTxtSL.txt.ForeColor = Color.DarkRed;
            this.editTxtZL.txt.ForeColor = Color.DarkRed;
            this.editTxtJLCS.txt.ForeColor = Color.DarkRed;
            this.editDgvMain.AutoGenerateColumns = false;
            this.editColBL.ValueType = typeof(Decimal);
            this.editColYL.ValueType = typeof(Decimal);
            this.editColJL.ValueType = typeof(Decimal);
            this.editColJLYL.ValueType = typeof(Decimal);
            editColGX.Tag = "总行:";
            editColJE.Tag = "合计金额:";

        }
        private void this_Load(object sender, EventArgs e)
        {
            this.refSch();
            this.showLD();
        }
        private bool showLD()
        {
            this.emptyLDmain();
            this.emptyLDdata();
            this.editBtnPrn.Enabled = false;
            if (this.showLDH == "")
                return false;
            DataTable dataTable1 = new DataTable();
            DataTable dataTable2 = new DataTable();
            //using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DBconn))
            {
                //sqlConnection.Open();
                //SqlCommand command = sqlConnection.CreateCommand();
                //command.CommandTimeout = 300;
                string CommandText = "select * from T_PFmain where danhao = '" + this.showLDH + "'";

                dataTable1 = db.Ado.GetDataTable(CommandText);
                if (dataTable1.Rows.Count != 1)
                {
                    //sqlDataReader1.Close();
                    //sqlDataReader1.Dispose();
                    //command.Dispose();
                    dataTable1.Dispose();
                    dataTable2.Dispose();
                    int num = (int)MessageBox.Show((IWin32Window)this, "无法找到此料单主数据!!!", "提示");
                    return false;
                }
                string sql = "";
                if (this.showLDH.StartsWith("LD") || this.showLDH.StartsWith("8") && this.showLDH.Length == 10)
                {
                    this.editLblShowLB.Text = "配方单成本";
                    this.editColJL.Visible = false;
                    this.editColJLYL.Visible = false;
                    this.editColJLDW.Visible = false;
                    sql = "select a.*,danjia=cast(b.item1 as money),jine=case when a.yongliangDW in('g','mL') then cast(cast(b.item1 as money)*a.yongliang/1000 as decimal(10,2)) else cast(cast(b.item1 as money)*a.yongliang as decimal(10,2)) end from T_PFdata a left join T_Base b on a.ranliao = b.item0 and (b.leibie = '染料名称' or b.leibie = '助剂名称') and a.yongliang > 0 where a.danhao = '" + dataTable1.Rows[0].Field<string>("danhao") + "' order by a.SN";
                }
                else
                {
                    this.editLblShowLB.Text = "加料单成本";
                    this.editColJL.Visible = true;
                    this.editColJLYL.Visible = true;
                    this.editColJLDW.Visible = true;
                    sql = "select a.*,danjia=cast(b.item1 as money),jine=case when a.JLyongliangDW in('g','mL') then cast(cast(b.item1 as money)*a.JLyongliang/1000 as decimal(10,2)) else cast(cast(b.item1 as money)*a.JLyongliang as decimal(10,2)) end from T_PFdata a left join T_Base b on a.ranliao = b.item0 and (b.leibie = '染料名称' or b.leibie = '助剂名称') and a.JLyongliang > 0 where a.danhao = '" + dataTable1.Rows[0].Field<string>("danhao") + "' order by a.SN";
                }
                //SqlDataReader sqlDataReader2 = command.ExecuteReader();
                dataTable2 = db.Ado.GetDataTable(sql);
                //sqlDataReader2.Close();
                ///sqlDataReader2.Dispose();
                //command.Dispose();
            }
            if (dataTable2.Rows.Count == 0)
            {
                dataTable1.Dispose();
                dataTable2.Dispose();
                int num = (int)MessageBox.Show((IWin32Window)this, "无法找到此料单行数据!!!", "提示");
                return false;
            }
            this.editImgLDH.Image = this.showLDH.Length != 11 || !this.showLDH.StartsWith("8") ? UserProc.GetBarcode(this.editImgLDH.Height, this.editImgLDH.Width, TYPE.CODE128, this.showLDH) : UserProc.GetBarcode(this.editImgLDH.Height, this.editImgLDH.Width * 62 / 100, TYPE.CODE128, this.showLDH);
            this.editImgLDH.Tag = (object)this.showLDH;
            this.editTxtKH.txt.Text = dataTable1.Rows[0].Field<string>("kehu");
            this.editTxtSZ.txt.Text = dataTable1.Rows[0].Field<string>("shazhong");
            this.editTxtSH.txt.Text = dataTable1.Rows[0].Field<string>("sehao");
            this.editTxtYS.txt.Text = dataTable1.Rows[0].Field<string>("yanse");
            this.editTxtDDH.txt.Text = dataTable1.Rows[0].Field<string>("dingdan");
            this.editTxtDY.txt.Text = dataTable1.Rows[0].Field<string>("dayang");
            this.editTxtZC.txt.Text = dataTable1.Rows[0].Field<string>("zhuche");
            this.editTxtDJ.txt.Text = dataTable1.Rows[0].Field<Decimal>("danjia").ToString("0.###;-0.###;\"\"");
            TextBox txt1 = this.editTxtKZ.txt;
            //Decimal num1 = dataTable1.Rows[0].Field<Decimal>("kezhong");
            //string str1 = num1.ToString("0.###;-0.###;\"\"");
            string str1 = dataTable1.Rows[0].Field<string>("kezhong");
            txt1.Text = str1;
            TextBox txt2 = this.editTxtMS.txt;
            Decimal num1 = dataTable1.Rows[0].Field<Decimal>("mishu");
            string str2 = num1.ToString("0.###;-0.###;\"\"");
            txt2.Text = str2;
            this.editTxtJH.txt.Text = dataTable1.Rows[0].Field<string>("jihao");
            TextBox txt3 = this.editTxtSL.txt;
            num1 = dataTable1.Rows[0].Field<Decimal>("shuiliang");
            string str3 = num1.ToString("0.####;-0.####;\"\"");
            txt3.Text = str3;
            TextBox txt4 = this.editTxtZL.txt;
            num1 = dataTable1.Rows[0].Field<Decimal>("zhongliang");
            string str4 = num1.ToString("0.####;-0.####;\"\"");
            txt4.Text = str4;
            this.editTxtBZ.txt.Text = dataTable1.Rows[0].Field<string>("beizhu");
            this.editTxtJLCS.txt.Text = dataTable1.Rows[0].Field<int>("JLciHJ").ToString("0");
            for (int index = 0; index < dataTable2.Rows.Count; ++index)
            {
                this.editDgvMain.Rows.Add();
                DataGridViewRow row = this.editDgvMain.Rows[this.editDgvMain.RowCount - 1];
                row.Cells[this.editColSN.Name].Value = (object)dataTable2.Rows[index].Field<long>("SN");
                row.Cells[this.editColGX.Name].Value = (object)dataTable2.Rows[index].Field<string>("gongxu");
                row.Cells[this.editColRL.Name].Value = (object)dataTable2.Rows[index].Field<string>("ranliao");
                row.Cells[this.editColBL.Name].Value = (object)dataTable2.Rows[index].Field<Decimal>("bili");
                row.Cells[this.editColBLDW.Name].Value = (object)dataTable2.Rows[index].Field<string>("biliDW");
                row.Cells[this.editColYL.Name].Value = (object)dataTable2.Rows[index].Field<Decimal>("yongliang");
                row.Cells[this.editColYLDW.Name].Value = (object)dataTable2.Rows[index].Field<string>("yongliangDW");
                row.Cells[this.editColGY.Name].Value = (object)dataTable2.Rows[index].Field<string>("yaoqiu");
                row.Cells[this.editColJL.Name].Value = (object)dataTable2.Rows[index].Field<Decimal>("JLbili");
                row.Cells[this.editColJLYL.Name].Value = (object)dataTable2.Rows[index].Field<Decimal>("JLyongliang");
                row.Cells[this.editColJLDW.Name].Value = (object)dataTable2.Rows[index].Field<string>("JLyongliangDW");
                row.Cells[this.editColSNld.Name].Value = (object)dataTable2.Rows[index].Field<long>("SNld");
                row.Cells[this.editColDJ.Name].Value = (object)dataTable2.Rows[index].Field<Decimal?>("danjia");
                row.Cells[this.editColJE.Name].Value = (object)dataTable2.Rows[index].Field<Decimal?>("jine");
            }
            this.editDgvMain.HeJi();
            this.editBtnPrn.Enabled = true;
            this.bsShowMain.DataSource = (object)dataTable1;
            this.bsShowData.DataSource = (object)dataTable2;
            dataTable1.Dispose();
            dataTable2.Dispose();
            return true;
        }
        private void emptyLDmain()
        {
            this.editImgLDH.Image = (Image)null;
            this.editTxtDDH.txt.Text = "";
            this.editTxtKH.txt.Text = "";
            this.editTxtSZ.txt.Text = "";
            this.editTxtSH.txt.Text = "";
            this.editTxtYS.txt.Text = "";
            this.editTxtDY.txt.Text = "";
            this.editTxtZC.txt.Text = "";
            this.editTxtDJ.txt.Text = "";
            this.editTxtKZ.txt.Text = "";
            this.editTxtMS.txt.Text = "";
            this.editTxtJH.txt.Text = "";
            this.editTxtSL.txt.Text = "";
            this.editTxtZL.txt.Text = "";
            this.editTxtBZ.txt.Text = "";
            this.editTxtJLCS.txt.Text = "";
            this.editTxtDDH.txt.Text = "";
        }

        private void emptyLDdata()
        {
            this.editDgvMain.Rows.Clear();
        }
        private void editBtnPrn_Click(object sender, EventArgs e)
        {
            if (this.showLDH == "")
                return;
            this.lblwait.showme();
            FrmPrn frmPrn = new FrmPrn();
            frmPrn.rptView.LocalReport.ReportEmbeddedResource = "DotNetBarProject.view.RDLC.rptSchCB.rdlc";
            frmPrn.rptView.LocalReport.DataSources.Clear();
            ReportDataSource reportDataSource1 = new ReportDataSource();
            reportDataSource1.Name = "ldmain";
            reportDataSource1.Value = (object)this.bsShowMain;
            ReportDataSource reportDataSource2 = new ReportDataSource();
            reportDataSource2.Name = "lddata";
            DataTable dataTable = (DataTable)bsShowData.DataSource;
            List<T_PFdataT> list_T_PFdataT = new List<T_PFdataT>();
            for (var i=0;i< dataTable.Rows.Count; i++)
            {
                T_PFdataT t_PFdataT = new T_PFdataT();
                var a = dataTable.Rows[i]; 
                t_PFdataT.gongxu = a.Field<string>("gongxu");
                t_PFdataT.ranliao = a.Field<string>("ranliao");
                t_PFdataT.bili = a.Field<Decimal>("bili");
                t_PFdataT.biliDW = a.Field<string>("biliDW");
                t_PFdataT.yongliang = a.Field<Decimal>("yongliang");
                t_PFdataT.yongliangDW = a.Field<string>("yongliangDW");
                t_PFdataT.yaoqiu = a.Field<string>("yaoqiu");
                t_PFdataT.JLbili = a.Field<Decimal>("JLbili");
                t_PFdataT.JLyongliang = a.Field<Decimal>("JLyongliang");
                t_PFdataT.JLyongliangDW = a.Field<string>("JLyongliangDW");
                t_PFdataT.SNld = a.Field<long>("SNld");
                t_PFdataT.danjia = a.Field<Decimal?>("danjia");
                t_PFdataT.jine = a.Field<Decimal?>("jine");
                list_T_PFdataT.Add(t_PFdataT);
            }
            reportDataSource2.Value = (object)list_T_PFdataT;
            frmPrn.rptView.LocalReport.DataSources.Add(reportDataSource1);
            frmPrn.rptView.LocalReport.DataSources.Add(reportDataSource2);
            string filename = Application.StartupPath + "\\imgLDH.Bmp";
            this.editImgLDH.Image.Save(filename, ImageFormat.Bmp);
            string str = "file:///" + filename.Replace("\\", "/");
            frmPrn.rptView.LocalReport.EnableExternalImages = true;
            ReportParameter reportParameter1 = new ReportParameter("LDH", str);
            ReportParameter reportParameter2 = new ReportParameter("GSname", UserProc.GSname);
            frmPrn.rptView.LocalReport.SetParameters((IEnumerable<ReportParameter>)new ReportParameter[2]
            {
                reportParameter1,
                reportParameter2
            });
            frmPrn.rptView.RefreshReport();
            int num = (int)frmPrn.ShowDialog();
            frmPrn.Close();
            this.lblwait.hideme();
        }
        private void btnSch_Click(object sender, EventArgs e)
        {
            this.schData();
            this.lblwait.showme();
            this.refData();
            this.lblwait.hideme();
        }
        private void schData()
        {
            this.strSch = "";
            string str1 = this.schMohu.Checked ? "%" : "";
            if (this.schKH.chkSel)
                this.strSch = this.strSch + "and kehu like '" + str1 + this.schKH.cobodgv.Text + str1 + "' ";
            if (this.schSZ.chkSel)
                this.strSch = this.strSch + "and shazhong like '" + str1 + this.schSZ.cobodgv.Text + str1 + "' ";
            if (this.schSH.chkSel)
                this.strSch = this.strSch + "and sehao like '" + str1 + this.schSH.txt.Text + str1 + "' ";
            if (this.schYS.chkSel)
                this.strSch = this.strSch + "and yanse like '" + str1 + this.schYS.txt.Text + str1 + "' ";
            if (this.schLD.chkSel)
                this.strSch = this.strSch + "and danhao like '" + str1 + this.schLD.txt.Text + str1 + "' ";
            if (this.schJH.chkSel)
                this.strSch = this.strSch + "and jihao like '" + this.schJH.cobodgv.Text + "' ";
            if (this.schDDH.chkSel)
                this.strSch = this.strSch + "and dingdan like '" + str1 + this.schDDH.txt.Text + str1 + "%' ";
            DateTime dateTime;
            string str2 = "", str3 = "";
            if (this.schRQsave.chkFsel)
            {
                string strSch = this.strSch;
                dateTime = this.schRQsave.dtimeF.Value;
                str2 = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                this.strSch = strSch + "and riqiSave >= '" + str2 + "' ";
            }
            if (this.schRQsave.chkTsel)
            {
                string strSch = this.strSch;
                dateTime = this.schRQsave.dtimeT.Value;
                str3 = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                this.strSch = strSch + "and riqiSave < '" + str2 + "' ";
                UserProc.CheckTime = str2 + " - " + str3;
            }
            if (this.schLBLD.Checked != this.schLBJL.Checked)
            {
                if (this.schLBLD.Checked)
                    this.strSch += "and ((danhao like 'LD%') or (danhao like '8%' and len(danhao) = 10)) ";
                if (this.schLBJL.Checked)
                    this.strSch += "and not((danhao like 'LD%') or (danhao like '8%' and len(danhao) = 10)) ";
            }
            this.strSch = "select * from T_PFmain where sta = '已审核' and leibie='生产单' " + this.strSch + "order by kehu,sehao,ganghao,JLci";
        }
        private void refData()
        {
            //using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DBconn))
            {
                //sqlConnection.Open();
                //SqlCommand command = sqlConnection.CreateCommand();
                //command.CommandTimeout = 300;
                //command.CommandText = this.strSch;
                //SqlDataReader sqlDataReader = command.ExecuteReader();
                DataTable dataTable = db.Ado.GetDataTable(strSch);
                if (dataTable == null) return;
                //dataTable.Load((IDataReader)sqlDataReader);
                this.bsSch.DataSource = dataTable;
                this.mainDgv.DataSource = (object)this.bsSch;
                this.mainDgv.HeJi();
                //sqlDataReader.Close();
                //sqlDataReader.Dispose();
                //command.Dispose();
                dataTable.Dispose();
            }
        }
        private void mainDgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || this.mainDgv.CurrentRow.Index != e.RowIndex)
                return;
            this.lblwait.showme();
            this.showLDH = this.mainDgv.CurrentRow.Cells[this.mainColBH.Name].Value.ToString();
            if (this.showLD())
                this.tabPages.SelectedTab = this.tpEdit;
            this.lblwait.hideme();
        }
        private void mainDgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex < 0 || !this.mainDgv.Rows[e.RowIndex].Cells[this.mainColBH.Name].Value.ToString().StartsWith("7"))
                return;
            this.mainDgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = UserProc.colorJL;
        }
        private void refSch()
        {
            this.schKH.cobodgv.RefList(coboDGV.leibie.客户);
            this.schSZ.cobodgv.RefList(coboDGV.leibie.品名);
            this.schJH.cobodgv.RefList(coboDGV.leibie.机号);
        }
        private void dgvSum()
        {
            this.mainColSZ.Tag = (object)"行:";
            mainColZL.Tag = "重量合计:";
            mainColPS.Tag = "匹数合计:";
            mainColMS.Tag = "米数合计:";
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mainDgv.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.mainDgv.Print("配方成本", UserProc.CheckTime);
            this.lblwait.hideme();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mainDgv.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.mainDgv.saveExcel("配方成本");
            this.lblwait.hideme();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.schData();
            this.lblwait.showme();
            this.refData();
            this.lblwait.hideme();
        }

        private void 打印ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (this.mainDgv.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.mainDgv.Print("配方成本",UserProc.CheckTime);
            this.lblwait.hideme();
        }

        private void 导出ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (this.mainDgv.Rows.Count == 0)
                return;
            lblwait.showme();
            this.mainDgv.saveExcel("配方成本");
            lblwait.hideme();
        }
    }
}   

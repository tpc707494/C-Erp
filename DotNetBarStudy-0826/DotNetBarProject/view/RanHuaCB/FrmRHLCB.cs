using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.view;
using SqlSugar;
using System;
using System.Data;
using System.Windows.Forms;

namespace DotNetBarProject.view.RanHuaCB
{
    public partial class FrmRHLCB : Office2007Form
    {

        public SqlSugarClient db;
        private LblWait lblwait;
        private BindingSource bsSch;

        public FrmRHLCB()
        {
            InitializeComponent();
            bsSch = new BindingSource();
            lblwait = new LblWait(this);
            db = SqlBase.GetInstance();

        }
        private void this_Load(object sender, EventArgs e)
        {
            this.refSch();
            this.creatTmpRLYL();
        }
        private void creatTmpRLYL()
        {
            try
            {
                db.Ado.ExecuteCommand("drop table tmpRLYL");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            string a = "CREATE TABLE tmpRLYL([SN] [bigint] IDENTITY(1,1) NOT NULL,[ranliao][nvarchar](100) not NULL default '',[yongliang] [decimal](18,6) not null default 0,[yongliangCL] [decimal](18,6) not null default 0,[riqi] [datetime] not null)";
            db.Ado.ExecuteCommand(a);
            string b  = "alter table tmpRLYL add PRIMARY KEY([ranliao],[SN])";
            db.Ado.ExecuteCommand(b);
            
        }
        private void refSch()
        {
            this.schKH.cobodgv.RefList(coboDGV.leibie.客户);
            this.schSZ.cobodgv.RefList(coboDGV.leibie.品名);
            this.schJH.cobodgv.RefList(coboDGV.leibie.机号);
            this.schRL.cobodgv.RefList(coboDGV.leibie.染化料名称);
            mainColBH.Tag = "总行:";
            this.mainColYL.Tag = (object)"合计:";
            this.mainColJE.Tag = (object)"合计:";
            this.mainColYLcl.Tag = (object)"合计:";
            this.mainColJEcl.Tag = (object)"合计:";
        }
        private void menu导出Excel_Click(object sender, EventArgs e)
        {
            if (this.mainDgv.RowCount == 0)
                return;
            lblwait.showme();
            this.mainDgv.saveExcel("染化料用量");
            lblwait.hideme();
        }
        private void menu打印_Click(object sender, EventArgs e)
        {
            if (this.mainDgv.RowCount == 0)
                return;
            lblwait.showme();
            this.mainDgv.Print("一统一车间染化料用量", UserProc.CheckTime);
            lblwait.hideme();
        }
        private void btnSch_Click(object sender, EventArgs e)
        {
            UserProc.CheckTime = "";
            if (!this.schLBLD.Checked && !this.schLBJL.Checked)
            {
                int num1 = (int)MessageBox.Show((IWin32Window)this, "生产配方与加料配方请至少选一个!!!", "提示");
            }
            else if (!this.schLBRL.Checked && !this.schLBZJ.Checked)
            {
                int num2 = (int)MessageBox.Show((IWin32Window)this, "染料与助剂请至少选一个!!!", "提示");
            }
            else
            {
                db.Ado.ExecuteCommand("delete from tmpRLYL");
                this.lblwait.showme();
                string str1 = "";
                string str2 = this.schMohu.Checked ? "%" : "";
                if (this.schKH.chkSel)
                    str1 = str1 + "and a.kehu like '" + str2 + this.schKH.cobodgv.Text + str2 + "' ";
                if (this.schSZ.chkSel)
                    str1 = str1 + "and a.shazhong like '" + str2 + this.schSZ.cobodgv.Text + str2 + "' ";
                if (this.schSH.chkSel)
                    str1 = str1 + "and a.sehao like '" + str2 + this.schSH.txt.Text + str2 + "' ";
                if (this.schYS.chkSel)
                    str1 = str1 + "and a.yanse like '" + str2 + this.schYS.txt.Text + str2 + "' ";
                if (this.schJH.chkSel)
                    str1 = str1 + "and a.jihao like '" + this.schJH.cobodgv.Text + "' ";
                if (this.schDDH.chkSel)
                    str1 = str1 + "and a.dingdan like '" + str2 + this.schDDH.txt.Text + str2 + "' ";
                if (this.schRL.chkSel)
                    str1 = str1 + "and b.ranliao like '" + str2 + this.schRL.cobodgv.Text + str2 + "' ";
                //this.myComm.CommandText = "delete from #tmpRLYL";
                //this.myComm.ExecuteNonQuery();
                if (this.schLBLD.Checked)
                {
                    db.Ado.ExecuteCommand("insert into tmpRLYL(ranliao,yongliang,yongliangCL, riqi) select b.ranliao,yongliang=case when b.yongliangDW in('g','mL') then b.yongliang/1000 else b.yongliang end,yongliangCL=isnull((select sum(chengliang+chengmian-chengpi)/1000 from T_PFcheng where SNdata=b.SN),0), a.riqiShen from T_PFmain a join T_PFdata b on a.danhao = b.danhao where a.sta = '已审核' and ((a.danhao like 'LD%') or (a.danhao like '8%' and len(a.danhao) = 10)) and b.yongliang > 0 " + str1);
                    //this.myComm.CommandText = "insert into #tmpRLYL(ranliao,yongliang,yongliangCL) select b.ranliao,yongliang=case when b.yongliangDW in('g','mL') then b.yongliang/1000 else b.yongliang end,yongliangCL=isnull((select sum(chengliang+chengmian-chengpi)/1000 from T_PFcheng where SNdata=b.SN),0) from T_PFmain a join T_PFdata b on a.danhao = b.danhao where a.sta = '" + PeiFang.LiaoDan.leibie.staPF.已审核.ToString() + "' and ((a.danhao like 'LD%') or (a.danhao like '8%' and len(a.danhao) = 10)) and b.yongliang > 0 " + str1;
                    //this.myComm.ExecuteNonQuery();
                }
                if (this.schLBJL.Checked)
                {
                    db.Ado.ExecuteCommand("insert into tmpRLYL(ranliao,yongliang,yongliangCL, riqi) select b.ranliao,yongliang=case when b.JLyongliangDW in('g','mL') then b.JLyongliang/1000 else b.JLyongliang end,yongliangCL=isnull((select sum(chengliang+chengmian-chengpi)/1000 from T_PFcheng where SNdata=b.SN),0), a.riqiShen from T_PFmain a join T_PFdata b on a.danhao = b.danhao where a.sta = '已审核' and not((a.danhao like 'LD%') or (a.danhao like '8%' and len(a.danhao) = 10)) and b.yongliang > 0 " + str1);
                    //this.myComm.CommandText = "insert into #tmpRLYL(ranliao,yongliang,yongliangCL) select b.ranliao,yongliang=case when b.JLyongliangDW in('g','mL') then b.JLyongliang/1000 else b.JLyongliang end,yongliangCL=isnull((select sum(chengliang+chengmian-chengpi)/1000 from T_PFcheng where SNdata=b.SN),0) from T_PFmain a join T_PFdata b on a.danhao = b.danhao where a.sta = '" + PeiFang.LiaoDan.leibie.staPF.已审核.ToString() + "' and not((a.danhao like 'LD%') or (a.danhao like '8%' and len(a.danhao) = 10)) and b.yongliang > 0 " + str1;
                    //this.myComm.ExecuteNonQuery();
                }
                DateTime dateTime;
                string str_riqi = "";
                string str3 = "", str4 = "";
                string str1_riqi2 = " b.riqi >= '1970-01-01 00:00:00'", str2_riqi2 = " and b.riqi <'"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"'";
                if (this.schRQsave.chkFsel)
                {
                    dateTime = this.schRQsave.dtimeF.Value;
                    str3 = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    str1_riqi2 = " riqi >= '" + str3 + "' ";
                }
                if (this.schRQsave.chkTsel)
                {
                    dateTime = this.schRQsave.dtimeT.Value;
                    str4 = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    str2_riqi2 = " and riqi <'" + str4 + "' ";
                    str_riqi = str1_riqi2 + str2_riqi2;
                    UserProc.CheckTime = str3 + " - " + str4;
                }
                string a = "";
                if (str_riqi.Length == 0)
                {
                    //a = "select b.bianhao,a.ranliao,b.leibie,nameAll=b.item0,danjia=b.item1,a.shuliang,jine=cast(b.item1 as money)*a.shuliang,a.shuliangCL,jineCL=cast(b.item1 as money)*a.shuliangCL from (select ranliao,shuliang=sum(yongliang),shuliangCL=sum(yongliangCL) from tmpRLYL group by ranliao) as a left join T_Base b on a.ranliao = b.item0 and (b.leibie = '染料名称' or b.leibie = '助剂名称') order by b.bianhao,a.ranliao";
                    a = "select b.bianhao,b.item3,b.leibie,nameAll=b.item0,danjia=b.item1,a.shuliang,jine=cast(b.item1 as money)*a.shuliang,a.shuliangCL,jineCL=cast(b.item1 as money)*a.shuliangCL from (select ranliao,shuliang=sum(yongliang),shuliangCL=sum(yongliangCL) from tmpRLYL group by ranliao) as a left join T_Base b on a.ranliao = b.item0 and (b.leibie = '染料名称' or b.leibie = '助剂名称') order by b.bianhao,a.ranliao";
                }
                else
                {
                    a = "select b.bianhao,b.item3,b.leibie,nameAll=b.item0,danjia=b.item1,a.shuliang,jine=cast(b.item1 as money)*a.shuliang,a.shuliangCL,jineCL=cast(b.item1 as money)*a.shuliangCL from (select ranliao,shuliang=sum(yongliang),shuliangCL=sum(yongliangCL) from tmpRLYL " + " where " + str_riqi + "  group by ranliao) as a left join T_Base b on a.ranliao = b.item0 and (b.leibie = '染料名称' or b.leibie = '助剂名称') order by b.bianhao,a.ranliao";
                }
                Console.WriteLine(a);
                DataTable dataTable = db.Ado.GetDataTable(a);
                this.bsSch.DataSource = (object)dataTable;
                if (this.schLBRL.Checked != this.schLBZJ.Checked)
                {
                    if (this.schLBRL.Checked)
                        this.bsSch.Filter = "leibie='染料名称'";
                    if (this.schLBZJ.Checked)
                        this.bsSch.Filter = "leibie='助剂名称'";
                }
                else
                    this.bsSch.Filter = "";
                this.mainDgv.DataSource = (object)this.bsSch;
                this.mainDgv.HeJi();
                dataTable.Dispose();
                this.lblwait.hideme();
            }
        }
    }
}

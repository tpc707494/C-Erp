using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.view;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetBarProject.view.RanHuaCB
{
    public partial class FrmDLJL : Office2007Form
    {
        private LblWait lblwait;
        private BindingSource bsSch;

        public SqlSugarClient db;
        public FrmDLJL()
        {
            InitializeComponent();
            db = SqlBase.GetInstance();
            this.lblwait = new LblWait((Form)this);
            this.bsSch = new BindingSource();
            mainColRL.Tag = "总行:";
            Search();
        }
        private void menu导出Excel_Click(object sender, EventArgs e)
        {
            if (this.mainDgv.RowCount == 0)
                return;
            lblwait.showme();
            this.mainDgv.saveExcel("滴料记录");
            lblwait.hideme();
        }

        private void menu打印_Click(object sender, EventArgs e)
        {
            if (this.mainDgv.RowCount == 0)
                return;
            lblwait.showme();
            this.mainDgv.Print("滴料记录", UserProc.CheckTime);
            lblwait.hideme();
        }
        private void btnSch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void dgvSum()
        {
            this.mainColDL.Tag = (object)"滴料合计";
        }
        private void Search()
        {
            UserProc.CheckTime = "";
            this.lblwait.showme();
            string time1 = "", time2 = "";
            string str1 = "";
            string str2 = this.schMohu.Checked ? "%" : "";
            if (this.schRQ.chkFsel)
            {
                time1 = this.schRQ.dtimeF.Value.ToString("yyyy-MM-dd HH:mm:ss");
                str1 = str1 + "and a.riqicheng >= '" + time1 + "' ";
            }
            if (this.schRQ.chkTsel)
            {
                time2 = this.schRQ.dtimeT.Value.ToString("yyyy-MM-dd HH:mm:ss");
                str1 = str1 + "and a.riqicheng < '" + this.schRQ.dtimeT.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                UserProc.CheckTime = time1 + " - " + time2;

            }
            if (this.schRL.chkSel)
                str1 = str1 + "and b.ranliao like '" + str2 + this.schRL.cobodgv.Text + str2 + "' ";
            if (this.schKH.chkSel)
                str1 = str1 + "and c.kehu like '" + str2 + this.schKH.cobodgv.Text + str2 + "' ";
            if (this.schSZ.chkSel)
                str1 = str1 + "and c.shazhong like '" + str2 + this.schSZ.cobodgv.Text + str2 + "' ";
            if (this.schSH.chkSel)
                str1 = str1 + "and c.sehao like '" + str2 + this.schSH.txt.Text + str2 + "' ";
            if (this.schYS.chkSel)
                str1 = str1 + "and c.yanse like '" + str2 + this.schYS.txt.Text + str2 + "' ";
            if (this.schJH.chkSel)
                str1 = str1 + "and c.jihao like '" + this.schJH.cobodgv.Text + "' ";
            if (this.schDH.chkSel)
                str1 = str1 + "and c.danhao like '" + str2 + this.schDH.txt.Text + str2 + "' ";
            if (this.schDDH.chkSel)
                str1 = str1 + "and c.dingdan like '" + str2 + this.schDDH.txt.Text + str2 + "' ";
            if (str1 != "")
                str1 = "where " + str1.Substring(3);
            string str3 = "select a.riqicheng,a.ranliao,diliao=a.chengliang/1000,a.danhao,c.kehu,c.shazhong,c.sehao,c.yanse,c.jihao,c.dingdan,d.bianhao,nameAll=d.item0 from T_PFcheng a left join T_PFdata b on a.SNdata = b.SN left join T_PFmain c on a.danhao = c.danhao left join T_Base d on a.ranliao = d.item0 and (d.leibie = '" + leibie.enumLB.染料.ToString() + "' or d.leibie = '" + leibie.enumLB.助剂.ToString() + "') " + str1 + " order by a.riqicheng";
            try
            {
                var a = db.Ado.GetDataTable(str3);
                bsSch.DataSource = (object)a;
                mainDgv.DataSource = (object)this.bsSch;
                mainDgv.HeJi();
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "提示");
            }
            this.lblwait.hideme();

        }
    }
}

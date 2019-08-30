using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
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

namespace DotNetBarProject.view.RecipeManager.XiaoYangPeiF
{
    public partial class Search : Office2007Form
    {
        public lck.LckBarSearch.DoubleList doublelist;
        private LblWait lblwait;
        string XYD = leibie.enumPFLB.小样单.ToString();
        SqlSugarClient db;
        public Search()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Location = new Point(0, 0);
            db = SqlBase.GetInstance();
            lblwait = new LblWait((Form)this);
            Column3.Tag = (object)"行:";
        }
        private List<T_PFmain> schData()
        {
            var exp = Expressionable.Create<T_PFmain>().And(it => it.leibie == XYD);
            List<T_PFmain> getAll = null;
            if (schMohu.Checked)
            {
                if (schKH.chkSel)
                    exp.And(it => it.kehu.Contains(schKH.cobodgv.Text));
                if (schSZ.chkSel)
                    exp.And(it => it.shazhong.Contains(schSZ.cobodgv.Text));
                if (schSH.chkSel)
                    exp.And(it => it.sehao.Contains(schSH.cobodgv.Text));
                if (schYS.chkSel)
                    exp.And(it => it.yanse.Contains(schYS.cobodgv.Text));
                if (schLD.chkSel)
                    exp.And(it => it.danhao.Contains(schLD.txt.Text));
                if (schDY.chkSel)
                    exp.And(it => it.dayang.Contains(schDY.txt.Text));
                if (schDDH.chkSel)
                    exp.And(it => it.dingdan.Contains(schDDH.txt.Text));
            }
            else
            {
                if (schKH.chkSel)
                    exp.And(it => it.kehu == (schKH.cobodgv.Text));
                if (schSZ.chkSel)
                    exp.And(it => it.shazhong == (schSZ.cobodgv.Text));
                if (schSH.chkSel)
                    exp.And(it => it.sehao == (schSH.cobodgv.Text));
                if (schYS.chkSel)
                    exp.And(it => it.yanse == (schYS.cobodgv.Text));
                if (schLD.chkSel)
                    exp.And(it => it.danhao == (schLD.txt.Text));
                if (schDY.chkSel)
                    exp.And(it => it.dayang == (schDY.txt.Text));
                if (schDDH.chkSel)
                    exp.And(it => it.dingdan == (schDDH.txt.Text));
            }
            DateTime dateTime;
            string str1 = "1970-01-01 00:00:00", str2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (this.schRQsave.chkFsel)
            {
                dateTime = schRQsave.dtimeF.Value;
                str1 = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (this.schRQsave.chkTsel)
            {
                dateTime = schRQsave.dtimeT.Value;
                str2 = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                exp.And(it => SqlFunc.Between(it.riqiSave, str1, str2));
            }
            getAll = db.Queryable<T_PFmain>().Where(exp.ToExpression()).OrderBy(it=>it.SN, OrderByType.Desc).ToList();
            return getAll;
        }
        private void refView(List<T_PFmain> getAll)
        {
            dgvEX1.Rows.Clear();
            for (var i = 0; i < getAll.Count; i++)
            {
                T_PFmain dataRowCollection = getAll[i];
                int index = dgvEX1.Rows.Add();
                dgvEX1.Rows[index].Tag = dataRowCollection.SN;
                dgvEX1.Rows[index].Cells[0].Value = dataRowCollection.danhao;

                dgvEX1.Rows[index].Cells[1].Value = dataRowCollection.kehu;
                dgvEX1.Rows[index].Cells[2].Value = dataRowCollection.shazhong;
                dgvEX1.Rows[index].Cells[3].Value = dataRowCollection.sehao;
                dgvEX1.Rows[index].Cells[4].Value = dataRowCollection.yanse;
                dgvEX1.Rows[index].Cells[5].Value = dataRowCollection.dingdan;
                dgvEX1.Rows[index].Cells[6].Value = dataRowCollection.riqiSave;//.ObjToString("yyyy-MM-dd HH:mm:ss");
                dgvEX1.Rows[index].Cells[7].Value = dataRowCollection.peifang;
                dgvEX1.Rows[index].Cells[8].Value = dataRowCollection.riqiShen;//.ObjToString("yyyy-MM-dd HH:mm:ss");
                dgvEX1.Rows[index].Cells[9].Value = dataRowCollection.fuhe;
                dgvEX1.Rows[index].Cells[10].Value = dataRowCollection.dayang;
                dgvEX1.Rows[index].Cells[11].Value = dataRowCollection.beizhu;
                dgvEX1.Rows[index].Cells[mainColSta.Name].Value = dataRowCollection.sta;
                dgvEX1.Rows[index].Cells[13].Value = dataRowCollection.SN;
            }
            dgvEX1.HeJi();
        }
        private void Search_Load(object sender, EventArgs e)
        {

            lblwait.showme();
            refView(schData());
            lblwait.hideme();
        }

        private void dgvEX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            string str = dgvEX1.Rows[e.RowIndex].Cells[mainColSta.Name].Value.ToString();
            if (str == leibie.staPF.未审核.ToString())
            {
                this.dgvEX1.Rows[e.RowIndex].DefaultCellStyle.BackColor = UserProc.colorWSH;
            }
            else
            {
                if (!(str == leibie.staPF.已删除.ToString()))
                    return;
                this.dgvEX1.Rows[e.RowIndex].DefaultCellStyle.BackColor = UserProc.colorDel;
                this.dgvEX1.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("宋体", 9f, FontStyle.Strikeout);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblwait.showme();
            refView(schData());
            lblwait.hideme();
        }
        public void ReFlsh()
        {
            lblwait.showme();
            refView(schData());
            lblwait.hideme();
        }

        private void dgvEX1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvEX1.CurrentRow.Index != e.RowIndex)
                return;
            lblwait.showme();
            string showLDH = dgvEX1.CurrentRow.Cells[13].Value.ToString();
            doublelist(this, showLDH);
            lblwait.hideme();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

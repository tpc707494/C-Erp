using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace DotNetBarProject.view.lck
{
    public partial class LckBarSearch : Office2007Form
    {
        SqlSugarClient db = null;
        bool showflag = false;
        public delegate void DoubleList(Office2007Form asd, Object lCKA);
        public DoubleList doublelist;
        public LckBarSearch()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Location = new Point(0, 0);

            db = SqlBase.GetInstance();
            serRL();
        }
        private void Initgrid(Tuple<List<LCKA>, List<CP_TABLE>> getAll)
        {
            dataGridViewX1.Rows.Clear();
            if (getAll == null) return;
            for (int i = 0; i < getAll.Item1.Count; i++)
            {

                int index = dataGridViewX1.Rows.Add();
                LCKA dataRowCollection = getAll.Item1[i];
                CP_TABLE cp_table = getAll.Item2[i];
                dataGridViewX1.Rows[index].Tag = dataRowCollection.SN;
                dataGridViewX1.Rows[index].Cells[0].Value = dataRowCollection.liushuihao;
                dataGridViewX1.Rows[index].Cells[1].Value = dataRowCollection.kehu;
                dataGridViewX1.Rows[index].Cells[2].Value = dataRowCollection.peiming;
                dataGridViewX1.Rows[index].Cells[3].Value = dataRowCollection.peishu;
                dataGridViewX1.Rows[index].Cells[4].Value = dataRowCollection.daihao;
                dataGridViewX1.Rows[index].Cells[5].Value = dataRowCollection.sebie;
                dataGridViewX1.Rows[index].Cells[6].Value = dataRowCollection.sehao;
                dataGridViewX1.Rows[index].Cells[7].Value = dataRowCollection.fukuan;
                dataGridViewX1.Rows[index].Cells[8].Value = dataRowCollection.kezhong;
                dataGridViewX1.Rows[index].Cells[9].Value = dataRowCollection.cangwei;
                dataGridViewX1.Rows[index].Cells[10].Value = dataRowCollection.zonggangshu;
                dataGridViewX1.Rows[index].Cells[11].Value = dataRowCollection.riqiZhidan;
                dataGridViewX1.Rows[index].Cells[12].Value = dataRowCollection.zhongliang.Trim();
                dataGridViewX1.Rows[index].Cells[13].Value = cp_table.status;
            }
            dataGridViewX1.HeJi();
        }
        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridViewX1.CurrentRow != null)
            {
                if (this.dataGridViewX1.CurrentRow.Index == e.RowIndex)
                {

                    doublelist(this,dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Tag);
                }
            }
            //datagrid.Rows[e.RowIndex]
        }

        private void LckBarSearch_VisibleChanged(object sender, EventArgs e)
        {
            showflag = !showflag;
            if (showflag)
            {
                //var getAll = db.Queryable<LCKA>().ToList();
                //initgrid(getAll);
                //serRL();
            }
            else
            {
                if(db != null)
                {
                    //db.Close();
                }
            }
        }
        private void serRL()
        {
            chkCoboDGV2.cobodgv.RefList(custom.view.coboDGV.leibie.客户);
            chkCoboDGV1.cobodgv.RefList(custom.view.coboDGV.leibie.品名);
            chkCoboDGV3.cobodgv.RefList(custom.view.coboDGV.leibie.颜色);
            Column1.Tag = "总行:";
            Column13.Tag = "合计:";
            Column4.Tag = "合计:";

        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            Initgrid(Check());
        }

        private Tuple<List<LCKA>, List<CP_TABLE>> Check()
        {
            UserProc.CheckTime = "";
               var exp = Expressionable.Create<LCKA, CP_TABLE>();
            if (checkBoxX1.Checked)
            {
                if (textBox1.chk.Checked)
                {
                    exp.And((it,b) => it.liushuihao.Contains(textBox1.txt.Text));
                }
                if (chkCoboDGV2.chk.Checked)
                {
                    exp.And((it, b) => it.kehu.Contains(chkCoboDGV2.cobodgv.Text));
                }
                if (chkCoboDGV1.chk.Checked)
                {
                    exp.And((it, b) => it.peiming.Contains(chkCoboDGV1.cobodgv.Text));
                }
                if (chkCoboDGV3.chk.Checked)
                {
                    exp.And((it, b) => it.sebie.Contains(chkCoboDGV3.cobodgv.Text));
                }
            }
            else
            {
                if (textBox1.chk.Checked)
                {
                    exp.And((it, b) => it.liushuihao==(textBox1.txt.Text));
                }
                if (chkCoboDGV2.chk.Checked)
                {
                    exp.And((it, b) => it.kehu == (chkCoboDGV2.cobodgv.Text));
                }
                if (chkCoboDGV1.chk.Checked)
                {
                    exp.And((it, b) => it.peiming == (chkCoboDGV1.cobodgv.Text));
                }
                if (chkCoboDGV3.chk.Checked)
                {
                    exp.And((it, b) => it.sebie == (chkCoboDGV3.cobodgv.Text));
                }
            }
            DateTime dateTime;
            string str1 = "1970-01-01 00:00:00", str2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (this.chkDtime1.chkFsel)
            {
                dateTime = chkDtime1.dtimeF.Value;
                str1 = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (this.chkDtime1.chkTsel)
            {
                dateTime = chkDtime1.dtimeT.Value;
                str2 = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                exp.And((it, b) => SqlFunc.Between(it.riqiZhidan,str1, str2));
                UserProc.CheckTime = str1 + " - " + str2;
            }
            //exp.And((it, b) => b.status == "2");
           var getAll = db.Queryable<LCKA, CP_TABLE>((it, b) => new object[] {
               JoinType.Left,it.liushuihao == b.ganghao && b.status == "2"
           })
           .Where(exp.ToExpression())//.OrderBy(it => it.SN, OrderByType.Desc)
           .OrderBy((it, b) =>it.riqiZhidan, OrderByType.Desc)
           .Select((it, b) => new { lcka = it, cp_table = b })
           .ToList();
            List<LCKA> lcka = new List<LCKA>();
            List<CP_TABLE> cp_table = new List<CP_TABLE>();
            for (var i = 0; i< getAll.Count; i++)
            {
                lcka.Add(getAll[i].lcka);
                cp_table.Add(getAll[i].cp_table);
            }

            Tuple<List<LCKA>, List<CP_TABLE>> tup = new Tuple<List<LCKA>, List<CP_TABLE>>(lcka, cp_table);
            return tup;
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewX1.Rows.Count == 0)
                return;
            //this.lblwait.showme();
            this.dataGridViewX1.Print("一统一车间流程卡", UserProc.CheckTime);
            //this.lblwait.hideme();
        }

        private void 导出ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewX1.Rows.Count == 0)
                return;
            //lblwait.showme();
            this.dataGridViewX1.saveExcel("流程卡");
            //lblwait.hideme();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initgrid(Check());
        }
        private void dgvMain_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dataGridViewX1.Rows[e.RowIndex].Cells[13].Value == null) return;
            string str = dataGridViewX1.Rows[e.RowIndex].Cells[13].Value.ToString();
            if (str == "2")
            {
                this.dataGridViewX1.Rows[e.RowIndex].DefaultCellStyle.BackColor = UserProc.colorDel;
            }
        }
    }


    public static class DoubleBuffered

    {

        public static void DoubleBuffered1(DataGridViewX dgv, bool setting)

        {

            Type dgvType = dgv.GetType();

            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

            pi.SetValue(dgv, setting, null);

        }

    }
}

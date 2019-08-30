using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using DotNetBarProject.view.custom.view;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.peibucang
{
    public partial class JinDuCha : Office2007Form
    {

        private LblWait lblwait;
        public lck.LckBarSearch.DoubleList doublelist;
        public SqlSugarClient db;
        private long SN_SN = -1L;
        public JinDuCha()
        {
            InitializeComponent();
            lblwait = new LblWait(this);
            TopLevel = false;
            Location = new Point(0, 0);
            db = SqlBase.GetInstance();

            chkKehu.cobodgv.RefList(coboDGV.leibie.客户);
            chkPinmin.cobodgv.RefList(coboDGV.leibie.品名);
            chkCoboDGV1.cobodgv.RefList(coboDGV.leibie.生产工序);
            chkZZ.cobodgv.RefList(coboDGV.leibie.颜色);
            chkPS.cobodgv.RefList(coboDGV.leibie.色号);

        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //doublelist(this, -1L);
        }

        private void dgvEX1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (groupPanel1.Visible)
            //{
            //    return;
            //}
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvEX1.Rows[e.RowIndex].Selected == false)
                    {
                        dgvEX1.ClearSelection();
                        dgvEX1.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dgvEX1.SelectedRows.Count == 1)
                    {
                        dgvEX1.CurrentCell = dgvEX1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //修改ToolStripMenuItem.Enabled = true;
                    删除ToolStripMenuItem.Enabled = true;
                    //SN_SN = (long)dgvEX1.Rows[e.RowIndex].Tag;
                    SN_SN = Convert.ToInt64(dgvEX1.Rows[e.RowIndex].Tag);
                }
                //弹出操作菜单
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void contextMenuStrip1_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            //修改ToolStripMenuItem.Enabled = false;
            删除ToolStripMenuItem.Enabled = false;
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long asd = (long)dgvEX1.Rows[dgvEX1.CurrentRow.Index].Tag;
            //doublelist(this, asd);
        }
        private void RLdata(DataTable asdf)
        {
            dgvEX1.Rows.Clear();
            //if (asdf == null || baseIList == null) return;
            for (var i = 0; i < asdf.Rows.Count; i++)
            {
                //BaseIList baseIList = asdf[i];
                //int index = dgvEX1.Rows.Add();
                int index = dgvEX1.Rows.Add();
                dgvEX1.Rows[index].Tag = asdf.Rows[index]["SN"];
                dgvEX1.Rows[index].Cells[0].Value = asdf.Rows[index]["dingdanhao"];
                dgvEX1.Rows[index].Cells[1].Value = asdf.Rows[index]["kehu"];
                dgvEX1.Rows[index].Cells[2].Value = asdf.Rows[index]["pingmin"];
                dgvEX1.Rows[index].Cells[3].Value = asdf.Rows[index]["item1"];
                dgvEX1.Rows[index].Cells[4].Value = asdf.Rows[index]["seming"];
                dgvEX1.Rows[index].Cells[5].Value = asdf.Rows[index]["sehao"];
                string dingdanhao = asdf.Rows[index]["dingdanhao"].ToString();
                var asd = db.Queryable<LCKA>().Where(it => it.liushuihao == dingdanhao).First();
                if (asd != null)
                {
                    dgvEX1.Rows[index].Cells[6].Value = asd.fukuan;
                    dgvEX1.Rows[index].Cells[7].Value = asd.kezhong;

                    dgvEX1.Rows[index].Cells[8].Value = asdf.Rows[index]["pishu"];
                    dgvEX1.Rows[index].Cells[9].Value = asdf.Rows[index]["zongliang"];
                    dgvEX1.Rows[index].Cells[10].Value = asdf.Rows[index]["riqi"]; ;
                    dgvEX1.Rows[index].Cells[11].Value = asdf.Rows[index]["SN"];
                }
            }
            dgvEX1.HeJi(); 
        }

        private void JInCangChaXun_Load(object sender, EventArgs e)
        {
            Column3.Tag = "总行:";
            Column8.Tag = "合计";
            Column10.Tag = "合计";
            //RLdata(schData());
        }

        private void dgvEX1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvEX2.Rows.Clear();
            long asd = (long)dgvEX1.Rows[dgvEX1.CurrentRow.Index].Tag;
            var asd1 = db.Queryable<BaseIList>().Where(it=>it.SN == asd).First();
            var fd = db.Queryable<BaseIList>().Where(it => it.dingdanhao == asd1.dingdanhao).ToList();
            for(int i = 0; i < fd.Count; i++)
            {
                int index = dgvEX2.Rows.Add();
                var asdf = fd[index];
                if (asdf.item1 == null || asdf.item1.Length == 0) continue;
                dgvEX2.Rows[index].Cells[0].Value = asdf.dingdanhao;
                dgvEX2.Rows[index].Cells[1].Value = asdf.kehu;
                dgvEX2.Rows[index].Cells[2].Value = asdf.pingmin;
                dgvEX2.Rows[index].Cells[3].Value = asdf.item1;
                dgvEX2.Rows[index].Cells[4].Value = asdf.seming;
                dgvEX2.Rows[index].Cells[5].Value = asdf.sehao;
                dgvEX2.Rows[index].Cells[6].Value = asdf.menfu;
                dgvEX2.Rows[index].Cells[7].Value = asdf.kezong;

                dgvEX2.Rows[index].Cells[8].Value = asdf.pishu;
                dgvEX2.Rows[index].Cells[9].Value = asdf.zongliang;
                dgvEX2.Rows[index].Cells[10].Value = asdf.riqi;
                dgvEX2.Rows[index].Cells[11].Value = asdf.SN;
            }
            panel2.Visible = true;
            //doublelist(this, asd);
        }

        private void dgvEX1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }
        private DataTable schData()
        {
            UserProc.CheckTime = "";

            string strSch = "";
            string str1 = this.checkMohu.Checked ? "%" : "";

            if (this.chkDanHao.chkSel)
                strSch = strSch + "and dingdanhao like '" + str1 + this.chkDanHao.txt.Text + str1 + "' ";
            if (this.chkKehu.chkSel)
                strSch = strSch + "and kehu like '" + str1 + this.chkKehu.cobodgv.Text + str1 + "' ";
            if (this.chkPinmin.chkSel)
                strSch = strSch + "and pingmin like '" + str1 + this.chkPinmin.cobodgv.Text + str1 + "' ";
            if (this.chkCoboDGV1.chkSel)
                strSch = strSch + "and item1 like '" + str1 + this.chkCoboDGV1.cobodgv.Text + str1 + "' ";
            if (this.chkZPS.chkSel)
                strSch = strSch + "and pishu like '" + str1 + this.chkZPS.txt.Text + str1 + "' ";
            if (this.chkZZ.chkSel)
                strSch = strSch + "and seming like '" + this.chkZZ.cobodgv.Text + "' ";
            if (this.chkPS.chkSel)
                strSch = strSch + "and sehao like '" + str1 + this.chkPS.cobodgv.Text + str1 + "' ";
            if (this.chkTxt3.chkSel)
                strSch = strSch + "and menfu like '" + str1 + this.chkTxt3.txt.Text + str1 + "' ";
            if (this.chkTxt1.chkSel)
                strSch = strSch + "and kezong like '" + str1 + this.chkTxt1.txt.Text + str1 + "' ";
            if (this.chkTxt2.chkSel)
                strSch = strSch + "and zongliang like '" + str1 + this.chkTxt2.txt.Text + str1 + "' ";
            DateTime dateTime;
            string str_riqi = "";
            string tim1 = "", tim2="";
            string str1_riqi2 = " b.riqi >= '1970-01-01 00:00:00'", str2_riqi2 = " and b.riqi <'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            if (this.chkDtime1.chkFsel)
            {
                dateTime = this.chkDtime1.dtimeF.Value;
                tim1 = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                str1_riqi2 = " riqi >= '" + tim1 + "' ";
            }
            if (this.chkDtime1.chkTsel)
            {
                dateTime = this.chkDtime1.dtimeT.Value;
                tim2 = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                str2_riqi2 = " and riqi <'" + tim2 + "' ";
                str_riqi = str1_riqi2 + str2_riqi2;
                UserProc.CheckTime = tim1 + " - " + tim1;
            }
            if (str_riqi.Length == 0)
            {
                strSch = "select * from(select *,ROW_NUMBER() over(PARTITION by dingdanhao order by SN desc) rownum from BaseIList  WHERE item1 <> '')t where rownum = 1 and leibie = '产量登记'" + strSch + " ORDER BY riqi DESC";
            }
            else
            {
                strSch = "select * from(select *,ROW_NUMBER() over(PARTITION by dingdanhao order by SN desc) rownum from BaseIList  WHERE item1 <> '')t where rownum = 1 and leibie = '产量登记' and " + str_riqi+ " " + strSch + " ORDER BY riqi DESC"; ;
            }
            var getAll1 = db.Ado.GetDataTable(strSch);
            //getAll[]
            return getAll1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReFlsh();
        }

        public void ReFlsh()
        {
            lblwait.showme();
            RLdata(schData());
            lblwait.hideme();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReFlsh();
        }
        
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long sn = (long)dgvEX1.Rows[dgvEX1.CurrentRow.Index].Tag;
            if (sn<0)
            {
                return;
            }
            if (MessageBox.Show(this, "删除数据不可恢复，是否删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
            {
                var asd = db.Deleteable<BaseIList>().Where(it => it.SN == sn).ExecuteCommand();
                if (asd > 0)
                {
                    MessageBox.Show(this, "删除成功!");
                    ReFlsh();
                }
            }
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.dgvEX1.Print("进度查询", UserProc.CheckTime);
            this.lblwait.hideme();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.dgvEX1.saveExcel("进度查询");
            this.lblwait.hideme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            dgvEX2.Rows.Clear();
        }

        private void ChkCoboDGV1_Load(object sender, EventArgs e)
        {

        }
    }
}

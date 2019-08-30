using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using DotNetBarProject.view.custom.view;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.peibucang
{
    public partial class JHBChaXun : Office2007Form
    {

        private LblWait lblwait;
        public lck.LckBarSearch.DoubleList doublelist;
        public SqlSugarClient db;
        private long SN_SN = -1L;
        public JHBChaXun()
        {
            InitializeComponent();
            lblwait = new LblWait(this);
            TopLevel = false;
            Location = new Point(0, 0);
            db = SqlBase.GetInstance();
            Rl();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doublelist(this, -1L);
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
                    修改ToolStripMenuItem.Enabled = true;
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
            修改ToolStripMenuItem.Enabled = false;
            删除ToolStripMenuItem.Enabled = false;
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long asd = (long)dgvEX1.Rows[dgvEX1.CurrentRow.Index].Tag;
            doublelist(this, asd);
        }
        private void RLdata(List<BaseIList> asdf)
        {
            dgvEX1.Rows.Clear();
            //if (asdf == null || baseIList == null) return;
            for (var i = 0; i < asdf.Count; i++)
            {
                BaseIList baseIList = asdf[i];

                int index = dgvEX1.Rows.Add();
                dgvEX1.Rows[index].Tag = baseIList.SN;
                dgvEX1.Rows[index].Cells[0].Value = baseIList.dingdanhao;
                dgvEX1.Rows[index].Cells[1].Value = baseIList.kehu;
                dgvEX1.Rows[index].Cells[2].Value = baseIList.pingmin;
                dgvEX1.Rows[index].Cells[3].Value = baseIList.seming;
                dgvEX1.Rows[index].Cells[4].Value = baseIList.sehao;
                dgvEX1.Rows[index].Cells[5].Value = baseIList.pishu;
                dgvEX1.Rows[index].Cells[6].Value = baseIList.zongliang;

                dgvEX1.Rows[index].Cells[7].Value = baseIList.item0;
                dgvEX1.Rows[index].Cells[8].Value = baseIList.item3;
                dgvEX1.Rows[index].Cells[9].Value = baseIList.riqi;
            }
            dgvEX1.HeJi(); 
        }

        private void JInCangChaXun_Load(object sender, EventArgs e)
        {
            Column1.Tag = "总行:";
            Column6.Tag = "匹数合计:";
            Column7.Tag = "重量合计:";
            RLdata(schData());
        }
        private void Rl()
        {
            chkKehu.cobodgv.RefList(coboDGV.leibie.客户);
            chkPinmin.cobodgv.RefList(coboDGV.leibie.品名);
            chkZZ.cobodgv.RefList(coboDGV.leibie.颜色);
            chkPS.cobodgv.RefList(coboDGV.leibie.色号);

        }

        private void dgvEX1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long asd = (long)dgvEX1.Rows[dgvEX1.CurrentRow.Index].Tag;
            doublelist(this, asd);
        }

        private void dgvEX1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }
        private List<BaseIList> schData()
        {

            UserProc.CheckTime = "";
            var exp = Expressionable.Create<BaseIList>().And((b)=>b.leibie == "计划表");
            
            
            if (checkMohu.Checked)
            {
                if (chkDanHao.chkSel)
                    exp.And((b) => b.dingdanhao.Contains(chkDanHao.txt.Text));
                if (chkKehu.chkSel)
                    exp.And((b) => b.kehu.Contains(chkKehu.cobodgv.Text));
                if (chkPinmin.chkSel)
                    exp.And((b) => b.pingmin.Contains(chkPinmin.cobodgv.Text));
                if (chkZPS.chkSel)
                    exp.And((b) => b.pishu.Contains(chkZPS.txt.Text));
                if (chkZZ.chkSel)
                    exp.And((b) => b.seming.Contains(chkZZ.cobodgv.Text));
                if (chkPS.chkSel)
                    exp.And((b) => b.sehao.Contains(chkPS.cobodgv.Text));
                if (chkTxt1.chkSel)
                    exp.And((b) => b.item0.Contains(chkTxt1.txt.Text));
                if (chkTxt2.chkSel)
                    exp.And((b) => b.zongliang.Contains(chkTxt2.txt.Text));
            }
            else
            {
                if (chkDanHao.chkSel)
                    exp.And((b) => b.dingdanhao == (chkDanHao.txt.Text));
                if (chkKehu.chkSel)
                    exp.And((b) => b.kehu == (chkKehu.cobodgv.Text));
                if (chkPinmin.chkSel)
                    exp.And((b) => b.pingmin == (chkPinmin.cobodgv.Text));
                if (chkZPS.chkSel)
                    exp.And((b) => b.pishu == (chkZPS.txt.Text));
                if (chkZZ.chkSel)
                    exp.And((b) => b.seming == (chkZZ.cobodgv.Text));
                if (chkPS.chkSel)
                    exp.And((b) => b.sehao == (chkPS.cobodgv.Text));
                if (chkTxt1.chkSel)
                    exp.And((b) => b.item0 == (chkTxt1.txt.Text));
                if (chkTxt2.chkSel)
                    exp.And((b) => b.zongliang == (chkTxt2.txt.Text));
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
                exp.And((b) => SqlFunc.Between(b.riqi, str1, str2));
                UserProc.CheckTime = str1 + " - " + str2;
            }
            var getAll1 = db.Queryable<BaseIList>()
                .Where(exp.ToExpression())
                .OrderBy((b) => b.riqi, OrderByType.Desc)
                .ToList();
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
            Rl();
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
            this.dgvEX1.Print("计划表", UserProc.CheckTime);
            this.lblwait.hideme();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            lblwait.showme();
            this.dgvEX1.saveExcel("计划表");
            lblwait.hideme();
        }
    }
}

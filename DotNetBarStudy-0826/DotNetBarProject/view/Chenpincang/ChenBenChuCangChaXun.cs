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
    public partial class ChenBenChuCangChaXun : Office2007Form
    {

        private LblWait lblwait;
        public SqlSugarClient db;
        private long SN_SN = -1L;
        public ChenBenChuCangChaXun()
        {
            InitializeComponent();
            lblwait = new LblWait(this);
            TopLevel = false;
            Location = new Point(0, 0);
            db = SqlBase.GetInstance();
            Column3.Tag = "总行:";
            //dgvEX1.Columns[2].Tag = "行:";
            InitTab2();
            chkPinmin.cobodgv.RefList(coboDGV.leibie.品名);
            chkKehu.cobodgv.RefList(coboDGV.leibie.客户);
            chkJCY.cobodgv.RefList(coboDGV.leibie.员工);
            chkYWY.cobodgv.RefList(coboDGV.leibie.业务员);

            lblKH.RefList(coboDGV.leibie.客户);
            lblPM.RefList(coboDGV.leibie.品名);
            lblYWY.RefList(coboDGV.leibie.业务员);
            lblJCY.RefList(coboDGV.leibie.员工);
            

        }
        ///tab1
        ///tab1
        ///设置搜索数据
        private List<CP_TABLE> schData()
        {
            UserProc.CheckTime = "";
            var exp = Expressionable.Create<CP_TABLE>().And(it=>it.status == "2");


            if (checkMohu.Checked)
            {
                if (chkDanHao.chkSel)
                    exp.And((b) => b.ganghao.Contains(chkDanHao.txt.Text));
                if (chkKehu.chkSel)
                    exp.And((b) => b.kehu.Contains(chkKehu.cobodgv.Text));
                if (chkPinmin.chkSel)
                    exp.And((b) => b.pinming.Contains(chkPinmin.cobodgv.Text));
                if (chkPS.chkSel)
                    exp.And((b) => b.pishu.Contains(chkPS.txt.Text));
                if (chkCW.chkSel)
                    exp.And((b) => b.cangwei.Contains(chkCW.txt.Text));
                if (chkRKDH.chkSel)
                    exp.And((b) => b.rukudanhao.Contains(chkRKDH.txt.Text));
                if (chkDDH.chkSel)
                    exp.And((b) => b.dingdanhao.Contains(chkDDH.txt.Text));
                if (chkYWY.chkSel)
                    exp.And((b) => b.yewuyuan.Contains(chkYWY.cobodgv.Text));
                if (chkZL.chkSel)
                    exp.And((b) => b.zhongliang.Contains(chkZL.txt.Text));
                if (chkJCY.chkSel)
                    exp.And((b) => b.jincangyuan.Contains(chkJCY.cobodgv.Text));
            }
            else
            {
                if (chkDanHao.chkSel)
                    exp.And((b) => b.ganghao == (chkDanHao.txt.Text));
                if (chkKehu.chkSel)
                    exp.And((b) => b.kehu == (chkKehu.cobodgv.Text));
                if (chkPinmin.chkSel)
                    exp.And((b) => b.pinming == (chkPinmin.cobodgv.Text));
                if (chkPS.chkSel)
                    exp.And((b) => b.pishu == (chkPS.txt.Text));
                if (chkCW.chkSel)
                    exp.And((b) => b.cangwei == (chkCW.txt.Text));
                if (chkRKDH.chkSel)
                    exp.And((b) => b.rukudanhao == (chkRKDH.txt.Text));
                if (chkDDH.chkSel)
                    exp.And((b) => b.dingdanhao == (chkDDH.txt.Text));
                if (chkYWY.chkSel)
                    exp.And((b) => b.yewuyuan == (chkYWY.cobodgv.Text));
                if (chkZL.chkSel)
                    exp.And((b) => b.zhongliang == (chkZL.txt.Text));
                if (chkJCY.chkSel)
                    exp.And((b) => b.jincangyuan == (chkJCY.cobodgv.Text));
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
            var getAll1 = db.Queryable<CP_TABLE>()
                .Where(exp.ToExpression())
                .OrderBy((b) => b.riqi, OrderByType.Desc)
                .ToList();
            return getAll1;
        }

        ///填充数据
        private void RLdata(List<CP_TABLE> asdf)
        {
            dgvEX1.Rows.Clear();
            //if (asdf == null || baseIList == null) return;
            for (var i = 0; i < asdf.Count; i++)
            {
                CP_TABLE baseIList = asdf[i];

                int index = dgvEX1.Rows.Add();
                dgvEX1.Rows[index].Tag = baseIList.SN;
                dgvEX1.Rows[index].Cells[0].Value = baseIList.riqi;
                dgvEX1.Rows[index].Cells[1].Value = baseIList.rukudanhao;
                dgvEX1.Rows[index].Cells[2].Value = baseIList.ganghao;
                dgvEX1.Rows[index].Cells[3].Value = baseIList.kehu;
                dgvEX1.Rows[index].Cells[4].Value = baseIList.pinming;
                dgvEX1.Rows[index].Cells[5].Value = baseIList.cangwei;
                dgvEX1.Rows[index].Cells[6].Value = baseIList.pishu;
                dgvEX1.Rows[index].Cells[7].Value = baseIList.zhongliang;
                dgvEX1.Rows[index].Cells[8].Value = baseIList.yewuyuan;
                dgvEX1.Rows[index].Cells[9].Value = baseIList.dingdanhao;
                dgvEX1.Rows[index].Cells[10].Value = baseIList.jincangyuan;
                dgvEX1.Rows[index].Cells[11].Value = baseIList.beizu;

            }
            dgvEX1.HeJi();
        }

        ///刷新数据
        public void ReFlsh()
        {
            lblwait.showme();
            RLdata(schData());
            lblwait.hideme();
        }

        ///点击刷新按钮
        private void button1_Click(object sender, EventArgs e)
        {
            ReFlsh();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SN_SN = -1L;
            tabEx1.SelectedIndex = 1;
            Query(SN_SN);
            lblRKDH.txt.Text = SetDH();
        }
        private string SetDH()
        {
            string lsh;
            string yy = DateTime.Now.ToString("yy");
            string nian1 = yy.Substring(1);
            string nian = "C"+ nian1 + DateTime.Now.ToString("MM")
                            + DateTime.Now.ToString("dd");
            CP_TABLE result = db.Queryable<CP_TABLE>()
                            .Where(it=>it.status == "2")
                            .OrderBy(it => it.SN, OrderByType.Desc)
                            .First();
            if (result == null)
            {
                lsh = nian + "001";
                return lsh;
            }
            string liushuihao = result.rukudanhao;
            if (liushuihao.IndexOf(nian) == -1)
            {
                liushuihao = "001";
            }
            else
            {
                string liushuihao1 = liushuihao.Substring(6);
                int a = int.Parse(liushuihao1) + 1;
                liushuihao = a.ToString("000");

            }
            lsh = nian + liushuihao;
            return lsh;
        }
        private void dgvEX1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long asd = (long)dgvEX1.Rows[dgvEX1.CurrentRow.Index].Tag;
            //doublelist(this, asd);
            SN_SN = asd;
            tabEx1.SelectedIndex = 1;
            Query(SN_SN);
        }

        private void dgvEX1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }
        private void dgvEX1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
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
            //doublelist(this, asd);
            SN_SN = asd;
            tabEx1.SelectedIndex = 1;
            Query(SN_SN);
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = true;
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
                var asd = db.Deleteable<CP_TABLE>().Where(it => it.SN == sn).ExecuteCommand();
                if (asd > 0)
                {
                    MessageBox.Show(this, "删除成功!");
                    ReFlsh();
                }
            }
        }

        ///tab2
        ///tab2
        ///
        private void InitTab2()
        {
            lblGH.txt.TextChanged += Txt_TextChanged;
            lblGH.txt.KeyPress += Textbox1_KeyPress;
        }
        public void Textbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Txt_TextChanged(sender, e);
            }
        }
        private void Txt_TextChanged(object sender, EventArgs e)
        {
            if (lblGH.txt.Text.Length < 8)
            {
                EmptyInput(1);
                return;
            }
            Query(lblGH.txt.Text);
        }
        //查询
        private void Query(long sn)
        {
            var baseIList = db.Queryable<CP_TABLE>()
                    .Where(aa => aa.SN == sn)
                    .First();
            if (baseIList != null)
            {
                lblGH.txt.Text = baseIList.ganghao;
                //lblRKDH.txt.Text = baseIList.rukudanhao;
                lblKH.cobodgv.Text = baseIList.kehu;
                riqi.Value = baseIList.riqi;
                lblPM.cobodgv.Text = baseIList.pinming;
                lblCW.txt.Text = baseIList.cangwei;
                lblYWY.cobodgv.Text = baseIList.yewuyuan;
                lblDDH.txt.Text = baseIList.dingdanhao;
                lblPS.txt.Text = baseIList.pishu;
                lblJCY.cobodgv.Text = baseIList.jincangyuan;
                lblZL.txt.Text = baseIList.zhongliang;
                lblBZ.txt.Text = baseIList.beizu;
            }
            else
            {
                EmptyInput(0);
            }
        }
        //查询
        private void Query(string sn)
        {
            //try
            {
                var baseIList = db.Queryable<CP_TABLE>()
                    .Where(aa => aa.ganghao == sn && aa.status == "1")
                    .First();
                if (baseIList != null)
                {
                    lblRKDH.txt.Text = baseIList.rukudanhao;
                    lblKH.cobodgv.Text = baseIList.kehu;
                    riqi.Value = baseIList.riqi;
                    lblPM.cobodgv.Text = baseIList.pinming;
                    lblCW.txt.Text = baseIList.cangwei;
                    lblYWY.cobodgv.Text = baseIList.yewuyuan;
                    lblDDH.txt.Text = baseIList.dingdanhao;
                    lblPS.txt.Text = baseIList.pishu;
                    lblJCY.cobodgv.Text = baseIList.jincangyuan;
                    lblZL.txt.Text = baseIList.zhongliang;
                    lblBZ.txt.Text = baseIList.beizu;
                }
                else
                {
                    MessageBox.Show("请先进行入仓", "提示");

                }
            }
            //catch (Exception ex)
            {
            //    MessageBoxEx.Show(ex.Message);
            //    return;
            }
        }
        //置空
        private void EmptyInput(int index)
        {
            if (index == 0)
            {
                lblGH.txt.Text = "";
                lblRKDH.txt.Text = "";
            }
            lblKH.cobodgv.Text = "";
            riqi.Value = DateTime.Now;
            lblPM.cobodgv.Text = "";
            lblCW.txt.Text = "";
            lblYWY.cobodgv.Text = "";
            lblDDH.txt.Text = "";
            lblPS.txt.Text = "";
            lblJCY.cobodgv.Text = "";
            lblZL.txt.Text = "";
            lblBZ.txt.Text = "";
        }
        private bool Save()
        {
            var all1 = db.Queryable<CP_TABLE>()
                    .Where(it => int.Parse(it.ganghao) == int.Parse(lblGH.txt.Text) && it.status == "1")
                    .ToList();
            if (all1 == null)
            {
                MessageBoxEx.Show("请先入库");
                return false;
            }
            else
            {
                int a_pishu = 0;
                for (var i = 0; i < all1.Count; i++)
                {
                    a_pishu += Convert.ToInt32(all1[i].pishu);
                }

                var aa = db.Queryable<CP_TABLE>().Where(it => it.kehu == lblGH.txt.Text && it.status == "2").ToList();
                int d = 0;
                for(var i = 0; i < aa.Count; i++)
                {
                    d += Convert.ToInt32(aa[i].pishu);
                }
                if((d + Convert.ToInt32(lblPS.txt.Text)) > a_pishu)
                {
                    MessageBoxEx.Show("出仓匹数超过仓库内总匹数，总匹数:"+ a_pishu, "提示");
                    return false;
                }
                int input = Convert.ToInt32(lblPS.txt.Text);
                for (var i=0;i< all1.Count; i++)
                {
                    if(input > Convert.ToInt32(all1[i].pishu))
                    {
                        all1[i].pishu = "0";
                        input -= Convert.ToInt32(all1[i].pishu);
                    }
                    else
                    {
                        all1[i].pishu = (Convert.ToInt32(all1[i].pishu) - input) + "";
                    }
                    db.Updateable<CP_TABLE>(all1[i]).ExecuteCommand();
                }
                
                CP_TABLE a = new CP_TABLE()
                {
                    ganghao = lblGH.txt.Text,
                    rukudanhao = lblRKDH.txt.Text,
                    kehu = lblKH.cobodgv.Text,
                    riqi = riqi.Value,
                    pinming = lblPM.cobodgv.Text,
                    cangwei = lblCW.txt.Text,
                    yewuyuan = lblYWY.cobodgv.Text,
                    dingdanhao = lblDDH.txt.Text,
                    pishu = lblPS.txt.Text,
                    jincangyuan = lblJCY.cobodgv.Text,
                    zhongliang = lblZL.txt.Text,
                    beizu = lblBZ.txt.Text,
                    status = "2",
                };
                db.Insertable<CP_TABLE>(a).ExecuteCommand();
                return true;
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (SN_SN == -1L)
            {
                if (Save())
                {
                    MessageBoxEx.Show("保存成功", "提示");
                }
            }
            else
            {
                MessageBoxEx.Show("已出缸数据不可修改", "提示");
            }
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.dgvEX1.Print("成品出仓", UserProc.CheckTime);
            this.lblwait.hideme();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.dgvEX1.saveExcel("成品出仓");
            this.lblwait.hideme();
        }

        private void ourButton1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = true;
            lblGH.txt.Enabled = true;
            lblRKDH.txt.Text = SetDH();
        }

        private void ourButton4_Click(object sender, EventArgs e)
        {
            if(lblGH.txt.Text.Length == 0)
            {
                MessageBoxEx.Show("请先点击新建按钮", "提示");
                return;
            }
            if (SN_SN == -1L)
            {
                if (Save())
                {
                    MessageBoxEx.Show("保存成功", "提示");
                }
            }
            else
            {
                MessageBoxEx.Show("已出缸数据不可修改", "提示");
            }
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = false;
            EmptyInput(0);
            lblGH.txt.Enabled = false;
        }

        private void ourButton5_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = false;
            EmptyInput(0);
            lblGH.txt.Enabled = false;
        }
    }
}

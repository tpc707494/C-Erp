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
    public partial class PBLin : Office2007Form
    {
        string benleibie = "Peibu";
        private LblWait lblwait;
        public SqlSugarClient db;
        private long SN_SN = -1L;
        public PBLin()
        {
            InitializeComponent();
            lblwait = new LblWait(this);
            TopLevel = false;
            Location = new Point(0, 0);
            db = SqlBase.GetInstance();
            InitTab2();
        }

        /// <summary>
        /// table1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private List<PeibuCang> schData()
        {

            UserProc.CheckTime = "";
            var exp = Expressionable.Create<PeibuCang>().And(it=>it.status== "2");


            if (checkMohu.Checked)
            {
                if (chkRKDH.chkSel)
                    exp.And((b) => b.danhao.Contains(chkRKDH.txt.Text));
                if (chkKH.chkSel)
                    exp.And((b) => b.kehu.Contains(chkKH.cobodgv.Text));
                if (chkPM.chkSel)
                    exp.And((b) => b.pinming.Contains(chkPM.cobodgv.Text));
                if (chkCW.chkSel)
                    exp.And((b) => b.cangwei.Contains(chkCW.cobodgv.Text));
                if (chkPS.chkSel)
                    exp.And((b) => b.pishu.Contains(chkPS.txt.Text));
                if (chkZPS.chkSel)
                    exp.And((b) => b.zongpishu.Contains(chkZPS.txt.Text));
                if (chkZZ.chkSel)
                    exp.And((b) => b.zongzhong.Contains(chkZZ.txt.Text));
                if (chkPH.chkSel)
                    exp.And((b) => b.pihao.Contains(chkPH.txt.Text));
                if (chkYWY.chkSel)
                    exp.And((b) => b.yewuyuan.Contains(chkYWY.cobodgv.Text));
            }
            else
            {

                if (chkRKDH.chkSel)
                    exp.And((b) => b.danhao==(chkRKDH.txt.Text));
                if (chkKH.chkSel)
                    exp.And((b) => b.kehu==(chkKH.cobodgv.Text));
                if (chkPM.chkSel)
                    exp.And((b) => b.pinming==(chkPM.cobodgv.Text));
                if (chkCW.chkSel)
                    exp.And((b) => b.cangwei==(chkCW.cobodgv.Text));
                if (chkPS.chkSel)
                    exp.And((b) => b.pishu==(chkPS.txt.Text));
                if (chkZPS.chkSel)
                    exp.And((b) => b.zongpishu==(chkZPS.txt.Text));
                if (chkZZ.chkSel)
                    exp.And((b) => b.zongzhong==(chkZZ.txt.Text));
                if (chkPH.chkSel)
                    exp.And((b) => b.pihao==(chkPH.txt.Text));
                if (chkYWY.chkSel)
                    exp.And((b) => b.yewuyuan==(chkYWY.cobodgv.Text));
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
                exp.And((b) => SqlFunc.Between(b.riqimake, str1, str2));
                UserProc.CheckTime = str1 + " - " + str2;
            }
            

            var getAll1 = db.Queryable<PeibuCang>()
                .Where(exp.ToExpression())
            .OrderBy((b) => b.riqimake, OrderByType.Desc)
            .ToList();
            return getAll1;
        }

        private void RLdata(List<PeibuCang> asdf)
        {
            dgvEX1.Rows.Clear();
            //if (asdf == null || baseIList == null) return;
            for (var i = 0; i < asdf.Count; i++)
            {
                PeibuCang baseIList = asdf[i];

                int index = dgvEX1.Rows.Add();
                dgvEX1.Rows[index].Tag = baseIList.SN;
                dgvEX1.Rows[index].Cells[0].Value = baseIList.riqimake;
                dgvEX1.Rows[index].Cells[1].Value = baseIList.danhao;
                dgvEX1.Rows[index].Cells[2].Value = baseIList.kehu;
                dgvEX1.Rows[index].Cells[3].Value = baseIList.pinming;
                dgvEX1.Rows[index].Cells[4].Value = baseIList.zongpishu;
                dgvEX1.Rows[index].Cells[5].Value = baseIList.zongzhong;
                dgvEX1.Rows[index].Cells[6].Value = baseIList.pishu;

                dgvEX1.Rows[index].Cells[7].Value = baseIList.yewuyuan;
                dgvEX1.Rows[index].Cells[8].Value = baseIList.pihao;
                dgvEX1.Rows[index].Cells[9].Value = baseIList.cangwei;
                dgvEX1.Rows[index].Cells[10].Value = baseIList.beizhu1;

            }
            dgvEX1.HeJi();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmptyInput(0);
            lblRKDH.txt.Text = jisuandanhao();
            tabEx1.SelectedIndex = 1;
            SN_SN = -1;
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
            SN_SN = asd;
            showInput();

            tabEx1.SelectedIndex = 1;
            EnableInput(true);

            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = true;

        }
        private void showInput()
        {
            lblKCDH.txt.TextChanged -= Txt_TextChanged;
            lblKCDH.txt.KeyPress -= Textbox1_KeyPress;
            var ad = db.Queryable<PeibuCang>().Where(it => it.SN == SN_SN).First();
            lblKCDH.txt.Text = ad.beizhu2;
            lblRKDH.txt.Text = ad.danhao;
            riqi.Value = DateTime.Now;
            lblKH.cobodgv.Text = ad.kehu;
            lblPM.cobodgv.Text = ad.pinming;

            lblZPS.txt.Text = ad.zongpishu;
            lblYWY.cobodgv.Text = ad.yewuyuan;
            lblPS.txt.Text = ad.pishu;

            lblCW.cobodgv.Text = ad.cangwei;
            lblZZ.txt.Text = ad.zongzhong;

            lblPH.txt.Text = ad.pihao;
            lblBZ1.txt.Text = ad.beizhu1;
            lblDH.txt.Text = ad.item0;

            lblKCDH.txt.TextChanged += Txt_TextChanged;
            lblKCDH.txt.KeyPress += Textbox1_KeyPress;
        }

        private void JInCangChaXun_Load(object sender, EventArgs e)
        {
            Column2.Tag = "总行:";
            Column5.Tag = "总匹数合计:";
            Column6.Tag = "领用总重合计:";
            Column7.Tag = "领用匹数合计:";
        }

        private void dgvEX1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long asd = (long)dgvEX1.Rows[dgvEX1.CurrentRow.Index].Tag;
            SN_SN = asd;
            query1(SN_SN);
            tabEx1.SelectedIndex = 1;
        }

        private void dgvEX1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
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
            //long sn = (long)dgvEX1.Rows[dgvEX1.CurrentRow.Index].Tag;
            if (SN_SN<0)
            {
                return;
            }
            if (MessageBox.Show(this, "删除数据不可恢复，是否删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
            {
                var asd = db.Deleteable<PeibuCang>().Where(it => it.SN == SN_SN && it.status=="2").ExecuteCommand();
                if (asd > 0)
                {
                    MessageBox.Show(this, "删除成功!");
                    ReFlsh();
                }
            }
        }
        /// <summary>
        /// tabl2
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// 
        private void InitTab2()
        {
            lblKCDH.txt.TextChanged += Txt_TextChanged;
            lblKCDH.txt.KeyPress += Textbox1_KeyPress;
            lblKH.RefList(coboDGV.leibie.客户);
            lblPM.RefList(coboDGV.leibie.品名);
            lblYWY.RefList(coboDGV.leibie.业务员);
            lblCW.RefList(coboDGV.leibie.仓位);

            chkKH.cobodgv.RefList(coboDGV.leibie.客户);
            chkPM.cobodgv.RefList(coboDGV.leibie.品名);
            chkYWY.cobodgv.RefList(coboDGV.leibie.业务员);
            chkCW.cobodgv.RefList(coboDGV.leibie.仓位);


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
            if (lblKCDH.txt.Text.Length < 8)
            {
                EnableInput(false);
                EmptyInput(1);
                return;
            }
            Query(lblKCDH.txt.Text);
        }
        private void Query(string sn)
        {
            try
            {
                var baseIList = db.Queryable<PeibuCang>()
                    .Where(aa => aa.danhao == sn && aa.status == "1")
                    .First();
                if (baseIList != null)
                {
                    //lblRKDH.txt.Text = baseIList.danhao;
                    lblKH.cobodgv.Text = baseIList.kehu;
                    lblPM.cobodgv.Text = baseIList.pinming;
                    riqi.Value = baseIList.riqimake;

                    lblZPS.txt.Text = baseIList.zongpishu;
                    lblYWY.cobodgv.Text = baseIList.yewuyuan;
                    lblPS.txt.Text = baseIList.pishu;

                    lblCW.cobodgv.Text = baseIList.cangwei;
                    lblZZ.txt.Text = baseIList.zongzhong;

                    lblPH.txt.Text = baseIList.pihao;
                    lblDH.txt.Text = baseIList.item0;
                    EnableInput(true);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
                return;
            }
        }
        private void query1(long sn)
        {
            var baseIList = db.Queryable<PeibuCang>()
                    .Where(aa => aa.SN == sn)
                    .First();
            if (baseIList != null)
            {
                lblRKDH.txt.Text = baseIList.danhao;
                lblKH.cobodgv.Text = baseIList.kehu;
                lblPM.cobodgv.Text = baseIList.pinming;
                riqi.Value = baseIList.riqimake;

                lblZPS.txt.Text = baseIList.zongpishu;
                lblYWY.cobodgv.Text = baseIList.yewuyuan;
                lblPS.txt.Text = baseIList.pishu;

                lblCW.cobodgv.Text = baseIList.cangwei;
                lblZZ.txt.Text = baseIList.zongzhong;

                lblPH.txt.Text = baseIList.pihao;
                lblBZ1.txt.Text = baseIList.beizhu1;
                lblDH.txt.Text = baseIList.item0;
            }
            else
            {
                MessageBoxEx.Show("此码单未发现", "提示");
            }
        }
        private string jisuandanhao()
        {
            string result = "";
            string yy = DateTime.Now.ToString("yy");
            string nian = yy.Substring(1);
            string a = "L"+ nian + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd");
            var b = db.Queryable<PeibuCang>()
                .Where(it => it.danhao.Contains(a))
                .OrderBy(it => it.danhao, OrderByType.Desc)
                .First();
            string lsh;
            if (b == null)
            {
                lsh = a + "001";
                return lsh;
            }
            string liushuihao = b.danhao;
            if (liushuihao.IndexOf(a) == -1)
            {
                liushuihao = "001";
            }
            else
            {
                string liushuihao1 = liushuihao.Substring(6);
                int c = int.Parse(liushuihao1) + 1;
                liushuihao = c.ToString("000");

            }
            result = a + liushuihao;
            return result;
        }
        //使能
        private void EnableInput(bool flag)
        {
            lblRKDH.txt.Enabled = flag;
            lblKH.cobodgv.Enabled = flag;
            lblPM.cobodgv.Enabled = flag;
            riqi.Enabled = flag;

            lblZPS.txt.Enabled = flag;
            lblYWY.cobodgv.Enabled = flag;
            lblPS.txt.Enabled = flag;

            lblCW.cobodgv.Enabled = flag;
            lblZZ.txt.Enabled = flag;

            lblPH.txt.Enabled = flag;
            lblBZ1.txt.Enabled = flag;
            lblDH.txt.Enabled = flag;
        }
        //置空
        private void EmptyInput(int index)
        {
            //lblRKDH.txt.Text = "";
            lblKH.cobodgv.Text = "";
            lblPM.cobodgv.Text = "";
            riqi.Value = DateTime.Now;

            lblZPS.txt.Text = "";
            lblYWY.cobodgv.Text = "";
            lblPS.txt.Text = "";

            lblCW.cobodgv.Text = "";
            lblZZ.txt.Text = "";

            lblPH.txt.Text = "";
            lblBZ1.txt.Text = "";
            lblDH.txt.Text = "";
        }
        private bool Edit()
        {
            var all1 = db.Queryable<PeibuCang>()
                    .Where(it => it.SN == SN_SN)
                    .OrderBy(it => it.SN, OrderByType.Desc)
                    .First();
            if (all1 == null)
            {
                MessageBoxEx.Show("这没有发现,重新选择","提示");
                return false;
            }
            else
            {
                //PeibuCang baseIList = new PeibuCang()
                {
                    all1.riqimake = DateTime.Now;
                    all1.kehu = lblKH.cobodgv.Text;

                    //all1.danhao = lblRKDH.txt.Text;
                    all1.pinming = lblPM.cobodgv.Text;
                    all1.zongpishu = lblZPS.txt.Text;
                    all1.yewuyuan = lblYWY.cobodgv.Text;
                    all1.pishu = lblPS.txt.Text;
                    all1.cangwei = lblCW.cobodgv.Text;
                    all1.zongzhong = lblZZ.txt.Text;
                    all1.pihao = lblPH.txt.Text;
                    all1.beizhu1 = lblBZ1.txt.Text;
                    all1.item0 = lblDH.txt.Text;
                };
                try
                {
                    db.Updateable<PeibuCang>(all1).ExecuteCommand();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show(ex.Message, "提示");
                    return false;
                }
            }
        }
        private bool Save()
        {
            if(lblKCDH.txt.Text.Length == 0)
            {
                MessageBoxEx.Show("请选择领用胚布", "提示");
                return false;
            }
            var all1 = db.Queryable<PeibuCang>()
                    .Where(it => it.danhao == lblKCDH.txt.Text)
                    .OrderBy(it => it.SN, OrderByType.Desc)
                    .First();
            if (all1 == null)
            {
                MessageBoxEx.Show("没有发现此该胚布,重新选择");
                return false;
            }
            else
            {
                var a = db.Queryable<PeibuCang>()
                    .Where(it => it.danhao == lblKCDH.txt.Text && it.status == "1")
                    .First();
                if (lblZZ.txt.Text.Length == 0)
                {
                    MessageBoxEx.Show("重量必须输入", "提示");
                    return false;
                }


                if(Int32.Parse(a.pishu) == 0)
                {
                    MessageBoxEx.Show("该胚布已被领完", "提示");
                    return false;
                }
                if (Int32.Parse(a.pishu) < Int32.Parse(lblPS.txt.Text))
                {
                    MessageBoxEx.Show("领用匹数不超过总匹数", "提示");
                    return false;
                }

                if (Int32.Parse(a.zongzhong) == 0)
                {
                    MessageBoxEx.Show("该胚布已被领完", "提示");
                    return false;
                }
                if (Int32.Parse(a.zongzhong) < Int32.Parse(lblZZ.txt.Text))
                {
                    MessageBoxEx.Show("领用重量不能超过总重", "提示");
                    return false;
                }
                int ps = (Int32.Parse(a.pishu) - Int32.Parse(lblPS.txt.Text));
                int zz = (Int32.Parse(a.zongzhong) - Int32.Parse(lblZZ.txt.Text));
                if ((ps != 0 && zz == 0) || (ps == 0 && zz != 0))
                {
                    MessageBoxEx.Show("领用匹数和重量应该同时为0", "提示");
                    return false;
                }
                PeibuCang baseIList = new PeibuCang()
                {
                    riqimake = DateTime.Now,
                    kehu = lblKH.cobodgv.Text,
                    beizhu2 = lblKCDH.txt.Text,
                    danhao = lblRKDH.txt.Text,
                    pinming = lblPM.cobodgv.Text,
                    zongpishu = lblZPS.txt.Text,
                    yewuyuan = lblYWY.cobodgv.Text,
                    pishu = lblPS.txt.Text,
                    cangwei = lblCW.cobodgv.Text,
                    zongzhong = lblZZ.txt.Text,
                    pihao = lblPH.txt.Text,
                    beizhu1 = lblBZ1.txt.Text,
                    item0 = lblDH.txt.Text,
                    status = "2",
            };
                try
                {
                    db.Insertable<PeibuCang>(baseIList).ExecuteCommand();
                    a.pishu = (Int32.Parse(a.pishu) - Int32.Parse(lblPS.txt.Text)) + "";
                    a.zongzhong = (Int32.Parse(a.zongzhong) - Int32.Parse(lblZZ.txt.Text)) + "";
                    db.Updateable<PeibuCang>(a).ExecuteCommand();
                    return true;
                }catch(Exception ex)
                {
                    MessageBoxEx.Show(ex.Message, "提示");
                    return false;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void ourButton1_Click(object sender, EventArgs e)
        {
            EmptyInput(0);
            EnableInput(true);
            lblRKDH.txt.Text = jisuandanhao();
            SN_SN = -1;
            flowLayoutPanel2.Visible = true;
            flowLayoutPanel1.Visible = false;
        }

        private void ourButton2_Click(object sender, EventArgs e)
        {
            EnableInput(true);
        }

        private void ourButton3_Click(object sender, EventArgs e)
        {
            tabEx1.SelectedIndex = 0;
        }

        private void ourButton4_Click(object sender, EventArgs e)
        {
            //if (Mode != 0)
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
                    if (Edit())
                    {
                        MessageBoxEx.Show("修改成功", "提示");
                    }
                }
            }
            EmptyInput(0);
            EnableInput(false);
            tabEx1.SelectedIndex = 0;
            SN_SN = -1;
            flowLayoutPanel2.Visible = true;
            flowLayoutPanel1.Visible = false;
        }

        private void ourButton5_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = false;
            EmptyInput(0);
            EnableInput(false);
            tabEx1.SelectedIndex = 0;
            SN_SN = -1;
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.dgvEX1.Print("胚布领用", UserProc.CheckTime);
            this.lblwait.hideme();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            lblwait.showme();
            this.dgvEX1.saveExcel("胚布领用");
            lblwait.hideme();
        }

        private void dgvEX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEX1.CurrentRow.Index < 0) return;
            long asd = (long)dgvEX1.Rows[dgvEX1.CurrentRow.Index].Tag;
            SN_SN = asd;
            showInput();
            tabEx1.SelectedIndex = 1;
            EnableInput(true);
        }
    }
}

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
    public partial class Frm_SYDJ : Office2007Form
    {
        string LieBie = "送样单号";
        private LblWait lblwait;
        public SqlSugarClient db;
        private long SN_SN = -1L;
        public Frm_SYDJ()
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
        private List<BaseIList> schData()
        {
            UserProc.CheckTime = "";
            var exp = Expressionable.Create<BaseIList>().And(it=>it.leibie== LieBie);


            if (checkMohu.Checked)
            {
                if (chkSYDH.chkSel)
                    exp.And((b) => b.kezong.Contains(chkSYDH.txt.Text));
                if (chkKH.chkSel)
                    exp.And((b) => b.kehu.Contains(chkKH.cobodgv.Text));
                if (chkPM.chkSel)
                    exp.And((b) => b.pingmin.Contains(chkPM.cobodgv.Text));

                if (chkSYGS.chkSel)
                    exp.And((b) => b.item0.Contains(chkSYGS.txt.Text));
                if (chkDYY.chkSel)
                    exp.And((b) => b.item1.Contains(chkDYY.cobodgv.Text));
                if (chkRHLB.chkSel)
                    exp.And((b) => b.item2.Contains(chkRHLB.cobodgv.Text));
                if (chkLYDH.chkSel)
                    exp.And((b) => b.dingdanhao.Contains(chkLYDH.txt.Text));
            }
            else
            {
                if (chkSYDH.chkSel)
                    exp.And((b) => b.kezong == (chkSYDH.txt.Text));
                if (chkKH.chkSel)
                    exp.And((b) => b.kehu == (chkKH.cobodgv.Text));
                if (chkPM.chkSel)
                    exp.And((b) => b.pingmin == (chkPM.cobodgv.Text));

                if (chkSYGS.chkSel)
                    exp.And((b) => b.item0 == (chkSYGS.txt.Text));
                if (chkDYY.chkSel)
                    exp.And((b) => b.item1 == (chkDYY.cobodgv.Text));
                if (chkRHLB.chkSel)
                    exp.And((b) => b.item2 == (chkRHLB.cobodgv.Text));
                if (chkLYDH.chkSel)
                    exp.And((b) => b.dingdanhao == (chkLYDH.txt.Text));
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
                dgvEX1.Rows[index].Cells[1].Value = baseIList.kezong;
                dgvEX1.Rows[index].Cells[2].Value = baseIList.kehu;
                dgvEX1.Rows[index].Cells[3].Value = baseIList.pingmin;
                dgvEX1.Rows[index].Cells[4].Value = baseIList.item0;
                dgvEX1.Rows[index].Cells[5].Value = baseIList.item1;

                dgvEX1.Rows[index].Cells[6].Value = baseIList.item2;
                dgvEX1.Rows[index].Cells[7].Value = baseIList.item3;
                dgvEX1.Rows[index].Cells[8].Value = baseIList.riqi;
                dgvEX1.Rows[index].Cells[9].Value = baseIList.SN;

            }
            dgvEX1.HeJi();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmptyInput(0);
            lblSYDH.txt.Text = jisuandanhao();
            tabEx1.SelectedIndex = 1;
            SN_SN = -1;

            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = true;
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
            lblLYDH.txt.TextChanged -= Txt_TextChanged;
            lblLYDH.txt.KeyPress -= Textbox1_KeyPress;

            var ad = db.Queryable<BaseIList>().Where(it => it.SN == SN_SN).First();

            lblLYDH.txt.Text = ad.dingdanhao;

            riqi.Value = DateTime.Now;
            lblKH.cobodgv.Text = ad.kehu;

            lblSYDH.txt.Text = ad.kezong;
            lblPM.cobodgv.Text = ad.pingmin;

            lblSYGS.txt.Text = ad.item0;
            lblRHLB.cobodgv.Text = ad.item2;

            lblDYY.cobodgv.Text = ad.item1;

            lblBZ1.txt.Text = ad.item3;

            lblLYDH.txt.TextChanged += Txt_TextChanged;
            lblLYDH.txt.KeyPress += Textbox1_KeyPress;
        }

        private void JInCangChaXun_Load(object sender, EventArgs e)
        {
            Column2.Tag = "总行:";
            Column6.Tag = "合计:";
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
                var asd = db.Deleteable<BaseIList>().Where(it => it.SN == SN_SN && it.leibie==LieBie).ExecuteCommand();
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
            lblLYDH.txt.TextChanged += Txt_TextChanged;
            lblLYDH.txt.KeyPress += Textbox1_KeyPress;
            lblKH.RefList(coboDGV.leibie.客户);
            lblPM.RefList(coboDGV.leibie.品名);
            lblRHLB.RefList(coboDGV.leibie.染化类别);
            lblDYY.RefList(coboDGV.leibie.员工);

            chkKH.cobodgv.RefList(coboDGV.leibie.客户);
            chkPM.cobodgv.RefList(coboDGV.leibie.品名);
            chkRHLB.cobodgv.RefList(coboDGV.leibie.染化类别);
            chkDYY.cobodgv.RefList(coboDGV.leibie.员工);


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
            if (lblLYDH.txt.Text.Length < 8)
            {
                //EnableInput(false);
                EmptyInput(0);
                return;
            }
            Query(lblLYDH.txt.Text);
        }
        private void Query(string sn)
        {
            try
            {
                var baseIList = db.Queryable<BaseIList>()
                    .Where(aa => aa.dingdanhao == sn && aa.leibie == "来样个数")
                    .First();
                if (baseIList != null)
                {
                    //lblRKDH.txt.Text = baseIList.danhao;
                    //lblLYDH.txt.Text = ad.dingdanhao;

                    riqi.Value = baseIList.riqi;
                    lblKH.cobodgv.Text = baseIList.kehu;

                    //lblSYDH.txt.Text = baseIList.kezong;
                    lblPM.cobodgv.Text = baseIList.pingmin;

                    lblSYGS.txt.Text = baseIList.item2;
                    lblRHLB.cobodgv.Text = baseIList.item0;

                    lblDYY.cobodgv.Text = baseIList.item1;

                    //lblBZ1.txt.Text = baseIList.item3;
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
            var baseIList = db.Queryable<BaseIList>()
                    .Where(aa => aa.SN == sn)
                    .First();
            if (baseIList != null)
            {
                lblLYDH.txt.Text = baseIList.dingdanhao;
                riqi.Value = baseIList.riqi;
                lblKH.cobodgv.Text = baseIList.kehu;

                lblSYDH.txt.Text = baseIList.kezong;
                lblPM.cobodgv.Text = baseIList.pingmin;

                lblSYGS.txt.Text = baseIList.item0;
                lblRHLB.cobodgv.Text = baseIList.item2;

                lblDYY.cobodgv.Text = baseIList.item1;

                lblBZ1.txt.Text = baseIList.item3;
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
            string a = "S"+ nian + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd");
            var b = db.Queryable<BaseIList>()
                .Where(it => it.kezong.Contains(a))
                .OrderBy(it => it.kezong, OrderByType.Desc)
                .First();
            string lsh;
            if (b == null)
            {
                lsh = a + "001";
                return lsh;
            }
            string liushuihao = b.kezong;
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

            lblLYDH.txt.Enabled = flag;
            riqi.Enabled = flag;
            lblKH.cobodgv.Enabled = flag;

            lblSYDH.txt.Enabled = flag;
            lblPM.cobodgv.Enabled = flag;

            lblSYGS.txt.Enabled = flag;
            lblRHLB.cobodgv.Enabled = flag;

            lblDYY.cobodgv.Enabled = flag;

            lblBZ1.txt.Enabled = flag;
        }
        //置空
        private void EmptyInput(int index)
        {
            riqi.Value = DateTime.Now;
            lblKH.cobodgv.Text = "";
            if(index != 0)
            {
                lblLYDH.txt.Text = "";
                lblSYDH.txt.Text = "";
            }
            lblPM.cobodgv.Text = "";

            lblSYGS.txt.Text = "";
            lblRHLB.cobodgv.Text = "";

            lblDYY.cobodgv.Text = "";

            lblBZ1.txt.Text = "";
        }
        private bool Edit()
        {
            var all1 = db.Queryable<BaseIList>()
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
                //BaseIList baseIList = new BaseIList()
                {

                    all1.dingdanhao = lblLYDH.txt.Text;

                    all1.riqi = DateTime.Now;
                    all1.kehu = lblKH.cobodgv.Text;

                    all1.kezong = lblSYDH.txt.Text;
                    all1.pingmin = lblPM.cobodgv.Text;

                    all1.item0 = lblSYGS.txt.Text;
                    all1.item2 = lblRHLB.cobodgv.Text;

                    all1.item1 = lblDYY.cobodgv.Text;

                    all1.item3 = lblBZ1.txt.Text;
                };
                try
                {
                    db.Updateable<BaseIList>(all1).ExecuteCommand();
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
            if(lblLYDH.txt.Text.Length == 0)
            {
                MessageBoxEx.Show("请选择领用胚布", "提示");
                return false;
            }
            var all1 = db.Queryable<BaseIList>()
                    .Where(it => it.dingdanhao == lblLYDH.txt.Text)
                    .OrderBy(it => it.SN, OrderByType.Desc)
                    .First();
            if (all1 == null)
            {
                MessageBoxEx.Show("没有发现此该胚布,重新选择");
                return false;
            }
            else
            {
                BaseIList baseIList = new BaseIList()
                {
                    dingdanhao = lblLYDH.txt.Text,

                    riqi = DateTime.Now,
                    kehu = lblKH.cobodgv.Text,

                    kezong = lblSYDH.txt.Text,
                    pingmin = lblPM.cobodgv.Text,

                    item0 = lblSYGS.txt.Text,
                    item2 = lblRHLB.cobodgv.Text,

                    item1 = lblDYY.cobodgv.Text,

                    item3 = lblBZ1.txt.Text,
                    leibie = LieBie,
                };
                try
                {
                    db.Insertable<BaseIList>(baseIList).ExecuteCommand();
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
            lblSYDH.txt.Text = jisuandanhao();
            SN_SN = -1;
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = true;
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
            EmptyInput(1);
            EnableInput(false);
            tabEx1.SelectedIndex = 0;
            SN_SN = -1;

            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = false;
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
            this.dgvEX1.Print("送样查询", UserProc.CheckTime);
            this.lblwait.hideme();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            lblwait.showme();
            this.dgvEX1.saveExcel("送样查询");
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

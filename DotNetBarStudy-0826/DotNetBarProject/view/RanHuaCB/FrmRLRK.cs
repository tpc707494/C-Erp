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
    public partial class FrmRLRK : Office2007Form
    {
        string benleibie = "Peibu";
        private LblWait lblwait;
        public SqlSugarClient db;
        private long SN_SN = -1L;
        public FrmRLRK()
        {
            InitializeComponent();
            lblwait = new LblWait(this);
            TopLevel = false;
            Location = new Point(0, 0);
            db = SqlBase.GetInstance();
            Column2.Tag = "总行:";
            Column6.Tag = "剩余总重合计";
            Column7.Tag = "剩余匹数合计";
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
            var exp = Expressionable.Create<BaseIList>().And(it=>it.leibie== "染料入库");


            if (checkMohu.Checked)
            {
                if (chkRKDH.chkSel)
                    exp.And((b) => b.dingdanhao.Contains(chkRKDH.txt.Text));
                if (chkSL.chkSel)
                    exp.And((b) => b.seming.Contains(chkSL.txt.Text));
                if (chkDJ.chkSel)
                    exp.And((b) => b.item0.Contains(chkDJ.txt.Text));
                if (chkZL.chkSel)
                    exp.And((b) => b.pishu.Contains(chkZL.txt.Text));
                if (chkRHLB.chkSel)
                    exp.And((b) => b.item1.Contains(chkRHLB.cobodgv.Text));
                if (chkGYS.chkSel)
                    exp.And((b) => b.item2.Contains(chkGYS.txt.Text));
                if (chkRHMC.chkSel)
                    exp.And((b) => b.item3.Contains(chkRHMC.cobodgv.Text));
            }
            else
            {

                if (chkRKDH.chkSel)
                    exp.And((b) => b.dingdanhao == (chkRKDH.txt.Text));
                if (chkSL.chkSel)
                    exp.And((b) => b.seming == (chkSL.txt.Text));
                if (chkDJ.chkSel)
                    exp.And((b) => b.item0 == (chkDJ.txt.Text));
                if (chkZL.chkSel)
                    exp.And((b) => b.pishu==(chkZL.txt.Text));
                if (chkRHLB.chkSel)
                    exp.And((b) => b.item1 == (chkRHLB.cobodgv.Text));
                if (chkGYS.chkSel)
                    exp.And((b) => b.item2 == (chkGYS.txt.Text));
                if (chkRHMC.chkSel)
                    exp.And((b) => b.item3 == (chkRHMC.cobodgv.Text));
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
                dgvEX1.Rows[index].Cells[1].Value = baseIList.item1;
                dgvEX1.Rows[index].Cells[2].Value = baseIList.item3;
                dgvEX1.Rows[index].Cells[3].Value = baseIList.item0;
                dgvEX1.Rows[index].Cells[4].Value = baseIList.item2;
                dgvEX1.Rows[index].Cells[5].Value = baseIList.kezong;
                dgvEX1.Rows[index].Cells[6].Value = baseIList.zongliang;
                dgvEX1.Rows[index].Cells[7].Value = baseIList.seming;
                dgvEX1.Rows[index].Cells[8].Value = baseIList.pishu;

                dgvEX1.Rows[index].Cells[9].Value = baseIList.riqi;
                dgvEX1.Rows[index].Cells[10].Value = baseIList.menfu;

            }
            dgvEX1.HeJi();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmptyInput();
            lblRKDH.txt.Text = jisuandanhao();
            tabEx1.SelectedIndex = 1;
            SN_SN = -1;
            EnableInput(true);
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
            var ad = db.Queryable<BaseIList>().Where(it => it.SN == SN_SN).First();
            //lblKCDH.txt.Text = ad.beizhu2;
            lblRKDH.txt.Text = ad.dingdanhao;
            riqi.Value = DateTime.Now;
            lblRHMC.cobodgv.Text = ad.item3;

            lblRHLB.cobodgv.Text = ad.item1;
            lblDJ.txt.Text = ad.item0;
            
            lblGHS.txt.Text = ad.item2;

            lblSL.txt.Text = ad.seming;
            lblZL.txt.Text = ad.pishu;
            lblBZ.txt.Text = ad.menfu;
            
        }

        private void JInCangChaXun_Load(object sender, EventArgs e)
        {
            Column3.Tag = "总行:";
            Column9.Tag = "总数合计";
            Column10.Tag = "总重合计";
            //RLdata(schData());
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
                var asd = db.Deleteable<BaseIList>().Where(it => it.SN == SN_SN).ExecuteCommand();
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
            lblRHMC.RefList(coboDGV.leibie.染化料名称);
            lblRHLB.RefList(coboDGV.leibie.染化类别);

            chkRHMC.cobodgv.RefList(coboDGV.leibie.染化料名称);
            chkRHLB.cobodgv.RefList(coboDGV.leibie.染化类别);
        }
        private void query1(long sn)
        {
            var baseIList = db.Queryable<BaseIList>()
                    .Where(aa => aa.SN == sn)
                    .First();
            if (baseIList != null)
            {


                lblRKDH.txt.Text = baseIList.dingdanhao;
                riqi.Value = DateTime.Now;
                lblRHMC.cobodgv.Text = baseIList.item3;

                lblRHLB.cobodgv.Text = baseIList.item1;
                lblDJ.txt.Text = baseIList.item0;
                lblGHS.txt.Text = baseIList.item2;

                lblSL.txt.Text = baseIList.seming;
                lblZL.txt.Text = baseIList.pishu;
                lblBZ.txt.Text = baseIList.menfu;
                
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
            string a = "A"+ nian + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd");
            var b = db.Queryable<BaseIList>()
                .Where(it => it.dingdanhao.Contains(a))
                .OrderBy(it => it.dingdanhao, OrderByType.Desc)
                .First();
            string lsh;
            if (b == null)
            {
                lsh = a + "001";
                return lsh;
            }
            string liushuihao = b.dingdanhao;
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
            lblRHMC.cobodgv.Enabled = flag;
            riqi.Enabled = flag;

            lblRHLB.cobodgv.Enabled = flag;
            lblDJ.txt.Enabled = flag;            
            lblGHS.txt.Enabled = flag;

            lblSL.txt.Enabled = flag;
            lblZL.txt.Enabled = flag;
            lblBZ.txt.Enabled = flag;
        }
        //置空
        private void EmptyInput()
        {
            lblRKDH.txt.Text = "";
            lblRHMC.cobodgv.Text = "";
            riqi.Value = DateTime.Now;

            lblRHLB.cobodgv.Text = "";
            lblDJ.txt.Text = "";        
            lblGHS.txt.Text = "";

            lblSL.txt.Text = "";
            lblZL.txt.Text = "";
            lblBZ.txt.Text = "";
        }
        private bool Edit()
        {
            var all1 = db.Queryable<BaseIList>()
                    .Where(it => it.SN == SN_SN)
                    .OrderBy(it => it.SN, OrderByType.Desc)
                    .First();
            if (all1 == null)
            {
                MessageBoxEx.Show("这没有发现,重新选择", "提示");
                return false;
            }
            else
            {



                //PeibuCang baseIList = new PeibuCang()
                {

                    all1.dingdanhao = lblRKDH.txt.Text;
                    all1.riqi = DateTime.Now;
                    all1.item3 = lblRHMC.cobodgv.Text;

                    all1.item1 = lblRHLB.cobodgv.Text;
                    all1.item0 = lblDJ.txt.Text;
                    all1.item2 = lblGHS.txt.Text;

                    all1.seming = lblSL.txt.Text;
                    all1.pishu = lblZL.txt.Text;
                    all1.menfu = lblBZ.txt.Text;
                    all1.kezong = lblSL.txt.Text;
                    all1.zongliang = lblZL.txt.Text;
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
            /*
            var all1 = db.Queryable<PeibuCang>()
                    .Where(it => int.Parse(it.liushuihao) == int.Parse(lblGH.txt.Text))
                    .OrderBy(it => it.liushuihao, OrderByType.Desc)
                    .First();
            if (all1 == null)
            {
                MessageBoxEx.Show("这没有发现此缸号重新选择");
                return false;
            }
            else
            */
            {
                BaseIList baseIList = new BaseIList()
                {
                    dingdanhao = lblRKDH.txt.Text,
                    riqi = DateTime.Now,
                    item3 = lblRHMC.cobodgv.Text,

                    item1 = lblRHLB.cobodgv.Text,
                    item0 = lblDJ.txt.Text,
                    item2 = lblGHS.txt.Text,

                    seming = lblSL.txt.Text,
                    pishu = lblZL.txt.Text,
                    menfu = lblBZ.txt.Text,
                    kezong = lblSL.txt.Text,
                    zongliang = lblZL.txt.Text,
                    leibie = "染料入库",
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
            EmptyInput();
            lblRKDH.txt.Text = jisuandanhao();
            //tabEx1.SelectedIndex = 1;
            SN_SN = -1;
            EnableInput(true);
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = true;
        }

        private void ourButton2_Click(object sender, EventArgs e)
        {
            EnableInput(true);
            //flowLayoutPanel1.Visible = false;
            //flowLayoutPanel2.Visible = true;
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
            EmptyInput();
            EnableInput(false);
            tabEx1.SelectedIndex = 0;
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = false;
        }

        private void ourButton5_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = false;
            EmptyInput();
            EnableInput(false);
            tabEx1.SelectedIndex = 0;
            //Mode = 0;
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.dgvEX1.Print("染料入库", UserProc.CheckTime);
            this.lblwait.hideme();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            lblwait.showme();
            this.dgvEX1.saveExcel("染料入库");
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
            //Mode = 1;
        }
    }
}

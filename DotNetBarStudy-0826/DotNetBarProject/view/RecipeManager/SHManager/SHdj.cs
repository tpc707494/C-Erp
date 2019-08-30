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
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.view.baseinfo
{
    public partial class SHdj : Office2007Form
    {
        string YanSe = leibie.enumLB.色号.ToString();
        private LblWait lblwait;
        private SqlSugarClient db;
        private long SN_SN = -1L;
        public SHdj()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Location = new Point(0, 0);
            db = SqlBase.GetInstance();

            lblwait = new LblWait((Form)this);
            groupPanel1.ResumeLayout(false);
            groupPanel1.PerformLayout();
            Column1.Tag = "总行";

            var getAll = db.Queryable<BaseIList>()
                .Where(it => it.leibie == YanSe)
                .ToList();
            ShowData(getAll);
        }

        private void ShowData(List<BaseIList> getAll)
        {
            if (getAll == null) return;
            dgvEX1.Rows.Clear();
            for (var i = 0; i < getAll.Count; i++)
            {
                BaseIList dataRowCollection = getAll[i];
                int index = dgvEX1.Rows.Add();
                dgvEX1.Rows[index].Tag = dataRowCollection.SN;
                dgvEX1.Rows[index].Cells[0].Value = dataRowCollection.menfu;
                dgvEX1.Rows[index].Cells[1].Value = dataRowCollection.item2;
                dgvEX1.Rows[index].Cells[2].Value = dataRowCollection.item3;
                dgvEX1.Rows[index].Cells[3].Value = dataRowCollection.seming;
                dgvEX1.Rows[index].Cells[4].Value = dataRowCollection.item1;
                dgvEX1.Rows[index].Cells[5].Value = dataRowCollection.item0;
                dgvEX1.Rows[index].Cells[6].Value = dataRowCollection.riqi;

            }
            dgvEX1.HeJi();
        }
        private List<BaseIList> schText()
        {
            UserProc.CheckTime = "";
            List<BaseIList> getAll = null;
            var exp = Expressionable.Create<BaseIList>().And(it => it.leibie == YanSe);
            if (checkMohu.Checked)
            {
                if (chkSHLB.chkSel)
                    exp.And(it => it.item0.Contains(chkSHLB.cobodgv.Text));
                if (chkPM.chkSel)
                    exp.And(it => it.item1.Contains(chkPM.cobodgv.Text));
                if (chkKH.chkSel)
                    exp.And(it => it.item2.Contains(chkKH.cobodgv.Text));
                if (chkSH.chkSel)
                    exp.And(it => it.item3.Contains(chkSH.txt.Text));
                if (chkSM.chkSel)
                    exp.And(it => it.seming.Contains(chkSM.cobodgv.Text));
            }
            else
            {
                if (chkSHLB.chkSel)
                    exp.And(it => it.item0 == (chkSHLB.cobodgv.Text));
                if (chkPM.chkSel)
                    exp.And(it => it.item1 == (chkPM.cobodgv.Text));
                if (chkKH.chkSel)
                    exp.And(it => it.item2 == (chkKH.cobodgv.Text));
                if (chkSH.chkSel)
                    exp.And(it => it.item3 == (chkSH.txt.Text));
                if (chkSM.chkSel)
                    exp.And(it => it.seming == (chkSM.cobodgv.Text));
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
                exp.And(b => SqlFunc.Between(b.riqi, str1, str2));
                UserProc.CheckTime = str1 + " - " + str2;
            }
            getAll = db.Queryable<BaseIList>()
                .Where(exp.ToExpression())
                .OrderBy(it=>it.riqi, OrderByType.Desc)
                .ToList();
            return getAll;
        }
        private void datagrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (groupPanel1.Visible)
            {
                return;
            }

            if (e.RowIndex == -1) return;
            SN_SN = Convert.ToInt64(dgvEX1.Rows[e.RowIndex].Tag);
            isShow(true);
            groupPanel1.Text = "修改数据";
            PopRow(0);

        }
        private bool YanZheng()
        {
            if (lblSHLB.cobodgv.Text == "")
            {
                int num = (int)MessageBox.Show((IWin32Window)this, this.lblSHLB.lblText + " 不能空白!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblSHLB.cobodgv.Focus();
                return false;
            }
            return true;
        }
        private bool Insert()
        {
            bool flag = false;
            if (!YanZheng())
            {
                return flag;
            }
            try
            {
                var insertObj = new BaseIList()
                {
                    leibie = YanSe,
                    item0 = lblSHLB.cobodgv.Text,
                    item1 = lblPM.cobodgv.Text,
                    item2 = lblKH.cobodgv.Text,
                    item3 = lblSH.txt.Text,
                    menfu = lblBH.txt.Text,
                    seming = lblSM.cobodgv.Text,
                    riqi = DateTime.Now,


                };
                var t2 = db.Insertable<BaseIList>(insertObj).ExecuteReturnIdentity();
                if (t2 > 0)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return flag;
        }
        private bool editRow()
        {
            bool flag = false;
            if (!YanZheng())
            {
                return flag;
            }

            try
            {
                var dsa = db.Queryable<BaseIList>().Where(it => it.SN == SN_SN).First();
                if (dsa != null)
                {
                    dsa.item0 = lblSHLB.cobodgv.Text;
                    dsa.item1 = lblPM.cobodgv.Text;
                    dsa.item2 = lblKH.cobodgv.Text;
                    dsa.item3 = lblSH.txt.Text;
                    dsa.menfu = lblBH.txt.Text;
                    dsa.seming = lblSM.cobodgv.Text;
                    var t2 = db.Updateable<BaseIList>(dsa).ExecuteCommand();
                    if (t2 > 0)
                    {
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }
            return flag;
        }
        private void isShow(bool flag)
        {
            groupPanel1.Visible = flag;
            
        }

        private void datagrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (groupPanel1.Visible)
            {
                return;
            }
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
                    //增加同行ToolStripMenuItem.Enabled = true;
                    修改ToolStripMenuItem.Enabled = true;
                    删除ToolStripMenuItem.Enabled = true;
                    新增复制ToolStripMenuItem.Enabled = true;
                    //SN_SN = (long)dgvEX1.Rows[e.RowIndex].Tag;
                    SN_SN = Convert.ToInt64(dgvEX1.Rows[e.RowIndex].Tag);
                }
                //弹出操作菜单
                CmsMenu.Show(MousePosition.X, MousePosition.Y);
            }
        }


        private void dgvEX1_MouseDown(object sender, MouseEventArgs e)
        {
            if (groupPanel1.Visible)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                CmsMenu.Show(MousePosition.X, MousePosition.Y);
            }
        }
        private void CmsMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            //增加同行ToolStripMenuItem.Enabled = false;
            修改ToolStripMenuItem.Enabled = false;
            删除ToolStripMenuItem.Enabled = false;
            新增复制ToolStripMenuItem.Enabled = false;
        }
        private void EmptyRow()
        {
            this.lblSHLB.cobodgv.Text = "";
            this.lblPM.cobodgv.Text = "";
            this.lblKH.cobodgv.Text = "";
            this.lblSH.txt.Text = "";
            this.lblBH.txt.Text = "";
            lblSM.cobodgv.Text = "";
        }
        private void PopRow(int index)
        {
            SN_SN = Convert.ToInt64(dgvEX1.Rows[dgvEX1.CurrentRow.Index].Tag);
            var getAll = db.Queryable<BaseIList>()
                   .Where(it => it.leibie == YanSe && it.SN==SN_SN)
                   .ToList();
            if(getAll.Count != 1)
            {
                MessageBox.Show("不存在,请重新选择!");
            }
            var current = getAll[0];
            if (index == 0)
            {
                lblSM.cobodgv.Text = current.seming;
                this.lblSHLB.cobodgv.Text = current.item3;
                this.lblSH.txt.Text = current.item3;
                this.lblBH.txt.Text = current.menfu;
            }
            this.lblPM.cobodgv.Text = current.item1;
            this.lblKH.cobodgv.Text = current.item2;
        }

        private void 增加空白行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SN_SN = -1L;
            isShow(true);
            groupPanel1.Text = "增加数据";
            EmptyRow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isShow(false);
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void 增加同行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isShow(true);
            groupPanel1.Text = "增加数据";
            PopRow(1);
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isShow(true);
            groupPanel1.Text = "修改数据";
            PopRow(0);
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblwait.showme();
            List<BaseIList> asd = schText();
            ShowData(asd);
            lblwait.hideme();
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.dgvEX1.Print(YanSe, UserProc.CheckTime);
            this.lblwait.hideme();
        }

        private void 导出ExcleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            lblwait.showme();
            this.dgvEX1.saveExcel(YanSe);
            lblwait.hideme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblwait.showme();
            List<BaseIList>  asd = schText();
            ShowData(asd);
            lblwait.hideme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (groupPanel1.Text == "修改数据")
            {
                if (editRow())
                {
                    if (MessageBox.Show(this, "修改成功", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.No)
                    {
                        groupPanel1.Visible = false;
                    }
                }
            }
            else
            {
                if (Insert())
                {
                    if (MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.No)
                    {
                        groupPanel1.Visible = false;
                    }
                }
            }
            var getAll = db.Queryable<BaseIList>()
                .Where(it => it.leibie == YanSe)
                .ToList();
            ShowData(getAll);

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确定删除吗?删除后将不可恢复!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
            {
                db.Deleteable<BaseIList>().Where(it => it.SN == SN_SN).ExecuteCommand();
                MessageBox.Show(this, "删除成功!", "提示");
                var getAll = db.Queryable<BaseIList>()
                    .Where(it => it.leibie == YanSe)
                    .ToList();
                ShowData(getAll);
            }

        }
        private void SetRL()
        {
            chkSHLB.cobodgv.RefList(coboDGV.leibie.色号类别);
            chkPM.cobodgv.RefList(coboDGV.leibie.品名);
            chkKH.cobodgv.RefList(coboDGV.leibie.客户);
            chkSM.cobodgv.RefList(coboDGV.leibie.颜色);

            lblSHLB.RefList(coboDGV.leibie.色号类别);
            lblPM.RefList(coboDGV.leibie.品名);
            lblKH.RefList(coboDGV.leibie.客户);
            lblSM.RefList(coboDGV.leibie.颜色);
            lblSHLB.cobodgv.doublelist += Cobodgv_updata;
        }

        private void Cobodgv_updata(string asd, string cou2)
        {
            string d = "";
            string a = DateTime.Now.ToString("yy").Remove(0, 1);
            var b = db.Queryable<BaseIList>().Where(it => it.leibie == YanSe).OrderBy(it => it.riqi, OrderByType.Desc).First();
            if (b == null)
            {
                d = asd + a + (1).ToString("00000");
               // d = asd + (1).ToString("00000");
            }
            else
            {
                var c = b.item3.Substring(b.item3.Length - 5, 5);
                d = asd + a + (int.Parse(c) + 1).ToString("00000");
                //d = asd + (int.Parse(c) + 1).ToString("00000");
            }
            lblSH.txt.Text = d;
        }
        private void ColorName_Load(object sender, EventArgs e)
        {

            Column2.Tag = "总行:";
            var getAll = db.Queryable<BaseIList>()
                .Where(it => it.leibie == YanSe)
                .ToList();
            ShowData(getAll);
            SetRL();


        }

        private void 新增复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmptyRow();
            isShow(true);
            groupPanel1.Text = "增加数据";
            PopRow(1);
        }
    }
}

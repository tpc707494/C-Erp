using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using DotNetBarProject.view.custom.view;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DotNetBarProject.view.RanHuaCB
{
    public partial class FrmRLRK1 : Office2007Form
    {
        private LblWait lblwait;
        public SqlSugarClient db;
        bool _EditMode = false;
        long SN_SN = -1L;
        public FrmRLRK1()
        {
            InitializeComponent();
            db = SqlBase.GetInstance();
            this.lblwait = new LblWait((Form)this);
            EditMode = false;
            SearchMode = false;
            RL();
        }
        private bool EditMode
        {
            get
            {
                return _EditMode;
            }
            set
            {
                _EditMode = value;
                groupPanel1.Visible = value;
                if (!value)
                {
                    SN_SN = -1L;
                    RF();
                }
                else
                {
                    if (SN_SN != -1L)
                    {
                        SetEidt();
                    }
                    else
                    {
                        Empty();
                    }
                }
            }
        }
        private bool SearchMode
        {
            get
            {
                return _EditMode;
            }
            set
            {
                _EditMode = value;
                panel1.Visible = value;
            }
        }
        private void Showg(List<BaseIList> a)
        {
            if (a == null) return;
            dgvEX1.Rows.Clear();
            for (var i = 0; i < a.Count; i++)
            {
                int index = dgvEX1.Rows.Add();
                BaseIList baseIList = a[i];
                dgvEX1.Rows[index].Tag = baseIList.SN;
                dgvEX1.Rows[index].Cells[0].Value = baseIList.SN;
                dgvEX1.Rows[index].Cells[1].Value = baseIList.item0;
                dgvEX1.Rows[index].Cells[2].Value = baseIList.item1;
                dgvEX1.Rows[index].Cells[3].Value = baseIList.item2;
                dgvEX1.Rows[index].Cells[4].Value = baseIList.riqi.ToString("yyyy-MM-dd HH:mm:ss");
                dgvEX1.Rows[index].Cells[5].Value = baseIList.item3;
            }
        }
        private List<BaseIList> SeachInput()
        {
            UserProc.CheckTime = "";
               var exp = Expressionable.Create<BaseIList>().And(it=>it.leibie == "染料入库");
            if (checkMohu.Checked)
            {
                if (chkRLMC.chkSel)
                    exp.And(b => b.item0.Contains(chkRLMC.cobodgv.Text));
                if (chkDJ.chkSel)
                    exp.And(b => b.item1.Contains(chkDJ.txt.Text));
                if (chkGHS.chkSel)
                    exp.And(b => b.item2.Contains(chkGHS.txt.Text));
            }
            else
            {
                if (chkRLMC.chkSel)
                    exp.And(b => b.item0 == (chkRLMC.cobodgv.Text));
                if (chkDJ.chkSel)
                    exp.And(b => b.item1 == (chkDJ.txt.Text));
                if (chkGHS.chkSel)
                    exp.And(b => b.item2 == (chkGHS.txt.Text));
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
                exp.And(b=> SqlFunc.Between(b.riqi, str1, str2));
                UserProc.CheckTime = str1 + " - " + str2;
            }
            var getAll1 = db.Queryable<BaseIList>().Where(exp.ToExpression()).OrderBy(it=>it.SN).ToList();
            return getAll1;
        }

        private void 新增ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            EditMode = true;
            groupPanel1.Text = "新建染料入库";
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            EditMode = false;
        }
        private void Empty()
        {
            lblRLMC.cobodgv.Text = "";
            lblDJ.txt.Text = "";
            lblGHS.txt.Text = "";
            lblBZ.txt.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }
        private void RF()
        {
            lblwait.showme();
            Showg(SeachInput());
            lblwait.hideme();

        }
        private void SetEidt()
        {
            var a = db.Queryable<BaseIList>().Where(it => it.SN == SN_SN).First();
            if (a == null)
            {
                if (MessageBoxEx.Show(this, "数据错误，是否重新打开", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
                {
                    EditMode = false;
                    RF();
                }
            }
            else
            {
                lblRLMC.cobodgv.Text = a.item0;
                lblDJ.txt.Text = a.item1;
                lblGHS.txt.Text = a.item2;
                lblBZ.txt.Text = a.item3;
                dateTimePicker1.Value = DateTime.Now;
            }
        }
        private void Edit()
        {
            var a = db.Queryable<BaseIList>().Where(it => it.SN == SN_SN).First();
            if (a == null)
            {
                if (MessageBoxEx.Show(this, "数据错误，是否重新打开", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
                {
                    EditMode = false;
                    RF();
                }
            }
            else
            {
                a.item0 = lblRLMC.cobodgv.Text;
                a.item1 = lblDJ.txt.Text;
                a.item2 = lblGHS.txt.Text;
                a.item3 = lblBZ.txt.Text;
                a.riqi = dateTimePicker1.Value;
                db.Updateable<BaseIList>(a).ExecuteCommand();
                if (MessageBoxEx.Show(this, "修改成功是否退出编辑?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
                {
                    EditMode = false;
                }
                RF();
            }
        }
        private void Save()
        {
            try
            {
                BaseIList baseIList = new BaseIList()
                {
                    item0 = lblRLMC.cobodgv.Text,
                    item1 = lblDJ.txt.Text,
                    item2 = lblGHS.txt.Text,
                    item3 = lblBZ.txt.Text,
                    riqi = dateTimePicker1.Value,
                    leibie = "染料入库",
                };
                db.Insertable<BaseIList>(baseIList).ExecuteCommand();
                if (MessageBoxEx.Show(this, "保存成功是否退出编辑?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
                {
                    EditMode = false;
                }
                RF();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, "提示");
            }
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            if (SN_SN != -1L)
            {
                Edit();
            }
            else
            {
                Save();
            }
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            SearchMode = false;
        }

        private void 查询ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SearchMode = true;
        }

        private void dgvEX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (EditMode) return;
            if (e.RowIndex < 0) return;
            SN_SN = (long)dgvEX1.Rows[e.RowIndex].Tag;
            EditMode = true;

        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SN_SN = Convert.ToInt64(dgvEX1.Rows[dgvEX1.CurrentRow.Index].Tag);
            groupPanel1.Text = "修改染料入库";
        }

        private void dgvEX1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (EditMode) return;
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

        private void dgvEX1_MouseDown(object sender, MouseEventArgs e)
        {
            if (EditMode) return;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }                
        }

        private void contextMenuStrip1_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            修改ToolStripMenuItem.Enabled = false;
            删除ToolStripMenuItem.Enabled = false;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var s = Convert.ToInt64(dgvEX1.Rows[dgvEX1.CurrentRow.Index].Tag);
            try
            {
                db.Deleteable<BaseIList>().Where(it => it.SN == s).ExecuteCommand();
                MessageBoxEx.Show(this, "删除成功", "提示");
                RF();
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show(this, ex.Message, "提示");
            }

        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RF();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            RF();
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.RowCount == 0)
                return;
            lblwait.showme();
            this.dgvEX1.Print("染料入库", UserProc.CheckTime);
            lblwait.hideme();
        }
        private void RL()
        {
            lblRLMC.RefList(coboDGV.leibie.染料);
        }
        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.RowCount == 0)
                return;
            lblwait.showme();
            this.dgvEX1.saveExcel("染料入库");
            lblwait.hideme();
        }
    }
}

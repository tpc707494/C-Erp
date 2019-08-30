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
    public partial class ColorName : Office2007Form
    {
        string YanSe = leibie.enumLB.颜色.ToString();
        private LblWait lblwait;
        private SqlSugarClient db;
        private long SN_SN = -1L;
        public ColorName()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Location = new Point(0, 0);
            db = SqlBase.GetInstance();

            lblwait = new LblWait((Form)this);
            groupPanel1.ResumeLayout(false);
            groupPanel1.PerformLayout();

            Rectangle ScreenArea = Screen.GetWorkingArea(this);
            
            dgvEX1.BackgroundColor = SystemColors.Window;
            dgvEX1.AutoGenerateColumns = false;
            dgvEX1.AllowUserToAddRows = false;
            dgvEX1.AllowUserToDeleteRows = false;
            dgvEX1.AllowUserToResizeRows = false;
            dgvEX1.AllowUserToAddRows = false;//删除最后一条空白
            dgvEX1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;//行高不可变
            dgvEX1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvEX1.MultiSelect = false;
            dgvEX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEX1.EditMode = DataGridViewEditMode.EditProgrammatically;

            var getAll = db.Queryable<T_Base>()
                .Where(it => it.leibie == YanSe)
                .ToList();
            ShowData(getAll);
        }

        private void ShowData(List<T_Base> getAll)
        {
            dgvEX1.Rows.Clear();
            for (var i = 0; i < getAll.Count; i++)
            {
                T_Base dataRowCollection = getAll[i];
                int index = dgvEX1.Rows.Add();
                dgvEX1.Rows[index].Tag = dataRowCollection.SN;
                dgvEX1.Rows[index].Cells[0].Value = dataRowCollection.bianhao;

                dgvEX1.Rows[index].Cells[1].Value = dataRowCollection.itemName;

            }
            dgvEX1.HeJi();
        }
        private List<T_Base> schText()
        {
            List<T_Base> getAll = null;
            var exp = Expressionable.Create<T_Base>().And(it => it.leibie == YanSe);
                //.And(it => it.Id == 1)
                //.ToExpression();//拼接表达式
            if (chkTxt2.chk.Checked)
            {
                exp.And(it => it.bianhao.Contains(chkTxt2.txt.Text));
            }
            if (chkTxt1.chk.Checked)
            {
                exp.And(it => it.itemName.Contains(chkTxt1.txt.Text));
            }
            getAll = db.Queryable<T_Base>()
                        .Where(exp.ToExpression())
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
            PopRow();

        }
        private bool YanZheng()
        {
            if (lblTxt1.txt.Text == "")
            {
                int num = (int)MessageBox.Show((IWin32Window)this, this.lblTxt1.lblText + " 不能空白!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblTxt1.txt.Focus();
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
                var get = db.Queryable<T_Base>().Where(it => it.leibie == YanSe && it.bianhao == lblTxt1.txt.Text).Count();
                if (get != 0)
                {
                    int num = (int)MessageBox.Show(lblTxt1.lblText + " 已存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return flag;
                }
                var insertObj = new T_Base()
                {
                    leibie = YanSe,
                    bianhao = lblTxt1.txt.Text,
                    itemName = lblTxt2.txt.Text,

                };
                var t2 = db.Insertable<T_Base>(insertObj).ExecuteReturnIdentity();
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

                var get = db.Queryable<T_Base>().Where(it => it.leibie == YanSe && it.bianhao == lblTxt1.txt.Text && (it.SN != SN_SN)).Count();
                if (get != 0)
                {
                    int num = (int)MessageBox.Show(lblTxt1.lblText + " 已存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return flag;
                }
                var dsa = db.Queryable<T_Base>().Where(it => it.SN == SN_SN).First();
                if (dsa != null)
                {
                    dsa.bianhao = lblTxt1.txt.Text;
                    dsa.itemName = lblTxt2.txt.Text;
                    var t2 = db.Updateable<T_Base>(dsa).ExecuteCommand();
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
        }
        private void EmptyRow()
        {
            this.lblTxt1.txt.Text = "";
            this.lblTxt2.txt.Text = "";
        }
        private void PopRow()
        {
            SN_SN = Convert.ToInt64(dgvEX1.Rows[dgvEX1.CurrentRow.Index].Tag);
            var getAll = db.Queryable<T_Base>()
                   .Where(it => it.leibie == YanSe && it.SN==SN_SN)
                   .ToList();
            if(getAll.Count != 1)
            {
                MessageBox.Show("不存在,请重新选择!");
            }
            var current = getAll[0];
            lblTxt1.txt.Text = current.bianhao;
            lblTxt2.txt.Text = current.itemName;
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
            PopRow();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isShow(true);
            groupPanel1.Text = "修改数据";
            PopRow();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblwait.showme();
            List<T_Base> asd = schText();
            ShowData(asd);
            lblwait.hideme();
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.dgvEX1.Print(YanSe, "");
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
            List<T_Base>  asd = schText();
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
            var getAll = db.Queryable<T_Base>()
                .Where(it => it.leibie == YanSe)
                .ToList();
            ShowData(getAll);

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确定删除吗?删除后将不可恢复!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
            {
                db.Deleteable<T_Base>().Where(it => it.SN == SN_SN).ExecuteCommand();
                MessageBox.Show(this, "删除成功!", "提示");
                var getAll = db.Queryable<T_Base>()
                    .Where(it => it.leibie == YanSe)
                    .ToList();
                ShowData(getAll);
            }

        }

        private void ColorName_Load(object sender, EventArgs e)
        {

            Column2.Tag = "总行:";
            var getAll = db.Queryable<T_Base>()
                .Where(it => it.leibie == YanSe)
                .ToList();
            ShowData(getAll);
        }
    }
}

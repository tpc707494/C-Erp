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
    public partial class Customer : Office2007Form
    {
        private LblWait lblwait;
        private SqlSugarClient db;
        private long SN_SN = -1L;
        public Customer()
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

        }

        private void ShowData(List<T_Base> getAll)
        {
            if (getAll == null) return;
            dgvEX1.Rows.Clear();
            for (var i = 0; i < getAll.Count; i++)
            {
                T_Base dataRowCollection = getAll[i];
                int index = dgvEX1.Rows.Add();
                dgvEX1.Rows[index].Tag = dataRowCollection.SN;
                dgvEX1.Rows[index].Cells[0].Value = dataRowCollection.bianhao;

                dgvEX1.Rows[index].Cells[1].Value = dataRowCollection.itemName;
                dgvEX1.Rows[index].Cells[2].Value = dataRowCollection.item0;
                dgvEX1.Rows[index].Cells[3].Value = dataRowCollection.item5;
                dgvEX1.Rows[index].Cells[4].Value = dataRowCollection.item1;
                dgvEX1.Rows[index].Cells[5].Value = dataRowCollection.item2;
                dgvEX1.Rows[index].Cells[6].Value = dataRowCollection.item3;
                dgvEX1.Rows[index].Cells[7].Value = dataRowCollection.item4;
                dgvEX1.Rows[index].Cells[8].Value = dataRowCollection.beizhu;

            }
            dgvEX1.HeJi();
        }
        private List<T_Base> schText()
        {
            List<T_Base> getAll = null;
            var exp = Expressionable.Create<T_Base>().And(it => it.leibie == "客户");
            if (checkBox4.Checked)
            {
                if (chkTxt2.chk.Checked)
                {
                    exp.And(it => it.itemName.Contains(chkTxt2.cobodgv.Text));
                }
                if (chkTxt1.chk.Checked)
                {
                    exp.And(it => it.item5.Contains(chkTxt1.cobodgv.Text));
                }
                if (chkTxt3.chk.Checked)
                {
                    exp.And(it => it.item0.Contains(chkTxt3.cobodgv.Text));
                }
                if (chkTxt4.chk.Checked)
                {
                    exp.And(it => it.item1.Contains(chkTxt4.txt.Text));
                }
            }
            else
            {
                if (chkTxt2.chk.Checked)
                {
                    exp.And(it=>it.itemName == chkTxt2.cobodgv.Text);
                }
                if (chkTxt1.chk.Checked)
                {
                    exp.And(it => it.item5 == chkTxt1.cobodgv.Text);
                }
                if (chkTxt3.chk.Checked)
                {
                    exp.And(it => it.item0 == chkTxt3.cobodgv.Text);
                }
                if (chkTxt4.chk.Checked)
                {
                    exp.And(it => it.item1 == chkTxt4.txt.Text);
                }
            }
            try
            {
                getAll = db.Queryable<T_Base>()
                           .Where(exp.ToExpression())
                           .ToList();
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }
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
            if (lblTxt4.txt.Text.Length != 0)
                return true;
            int num1 = (int)MessageBox.Show((IWin32Window)this, this.lblTxt4.lblText + " 不能空白!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            lblTxt4.txt.Focus();
            return false;
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
                var get = db.Queryable<T_Base>().Where(it => it.leibie == "客户" && it.bianhao == lblTxt1.txt.Text).Count();
                if (get != 0)
                {
                    int num = (int)MessageBox.Show(lblTxt1.lblText + " 已存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return flag;
                }
                get = db.Queryable<T_Base>().Where(it => it.leibie == "客户" && it.itemName == lblTxt4.txt.Text).Count();
                if (get != 0)
                {
                    int num = (int)MessageBox.Show(lblTxt4.lblText + " 已存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return flag;
                }
                var insertObj = new T_Base()
                {
                    leibie = "客户",
                    bianhao = lblTxt1.txt.Text,
                    itemName = lblTxt4.txt.Text,
                    item0 = lblTxt2.txt.Text,
                    item1 = lblTxt5.txt.Text,
                    item2 = lblTxt3.txt.Text,
                    item3 = lblTxt6.txt.Text,
                    item4 = lblTxt8.txt.Text,
                    item5 = lblCoboDGV1.cobodgv.Text,
                    beizhu = lblTxt7.txt.Text

                };
                var t2 = db.Insertable<T_Base>(insertObj).ExecuteReturnIdentity();
                if(t2 > 0)
                {
                    flag = true;
                }
            }
            catch(Exception ex)
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
                return false;
            }
            try
            {
                var get = db.Queryable<T_Base>().Where(it => it.leibie == "客户" && it.bianhao == lblTxt1.txt.Text && (it.SN != SN_SN)).Count();
                if (get != 0)
                {
                    int num = (int)MessageBox.Show(lblTxt1.lblText + " 已存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                get = db.Queryable<T_Base>().Where(it => it.leibie == "客户" && it.itemName == lblTxt4.txt.Text && (it.SN != SN_SN)).Count();
                if (get != 0)
                {
                    int num = (int)MessageBox.Show(lblTxt4.lblText + " 已存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                var dsa = db.Queryable<T_Base>().Where(it => it.SN == SN_SN).First();
                if (dsa != null)
                {
                    dsa.bianhao = lblTxt1.txt.Text;
                    dsa.itemName = lblTxt4.txt.Text;
                    dsa.item0 = lblTxt2.txt.Text;
                    dsa.item1 = lblTxt5.txt.Text;
                    dsa.item2 = lblTxt3.txt.Text;
                    dsa.item3 = lblTxt6.txt.Text;
                    dsa.item4 = lblTxt8.txt.Text;
                    dsa.item5 = lblCoboDGV1.cobodgv.Text;
                    dsa.beizhu = lblTxt7.txt.Text;
                    var t2 = db.Updateable<T_Base>(dsa).ExecuteCommand();
                    if (t2 > 0)
                    {
                        flag = true;
                    }
                }
            }
            catch(Exception ex)
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
                    修改ToolStripMenuItem.Enabled = true;
                    删除ToolStripMenuItem.Enabled = true;
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
            修改ToolStripMenuItem.Enabled = false;
            删除ToolStripMenuItem.Enabled = false;
        }
        private void EmptyRow()
        {
            lblTxt1.txt.Text = "";
            lblTxt4.txt.Text = "";
            lblTxt2.txt.Text = "";
            lblTxt5.txt.Text = "";
            lblTxt3.txt.Text = "";
            lblTxt6.txt.Text = "";
            lblTxt8.txt.Text = "";
            lblTxt7.txt.Text = "";
            lblCoboDGV1.cobodgv.Text = "";
        }
        private void PopRow()
        {
            var getAll = db.Queryable<T_Base>()
                   .Where(it => it.leibie == "客户" && it.SN==SN_SN)
                   .ToList();
            if(getAll.Count != 1)
            {
                MessageBox.Show("不存在,请重新选择!");
                return;
            }
            var current = getAll[0];
            lblTxt1.txt.Text = current.bianhao;
            lblTxt4.txt.Text = current.itemName;
            lblTxt2.txt.Text = current.item0;
            lblTxt5.txt.Text = current.item1;
            lblTxt3.txt.Text = current.item2;
            lblTxt6.txt.Text = current.item3;
            lblTxt8.txt.Text = current.item4;
            lblCoboDGV1.cobodgv.Text = current.item5;
            lblTxt7.txt.Text = current.beizhu;
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
            panelEx1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelEx1.Visible = false;
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
            this.dgvEX1.Print("客户", "");
            this.lblwait.hideme();
        }

        private void 导出ExcleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            lblwait.showme();
            this.dgvEX1.saveExcel("客户");
            lblwait.hideme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblwait.showme();
            List<T_Base>  asd = schText();
            ShowData(asd);
            lblwait.hideme();
        }
        private void ref_txt()
        {
            chkTxt1.cobodgv.RefList(coboDGV.leibie.业务员);
            lblCoboDGV1.RefList(coboDGV.leibie.业务员);
            chkTxt2.cobodgv.RefList(coboDGV.leibie.客户简称);
            chkTxt3.cobodgv.RefList(coboDGV.leibie.客户全称);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (SN_SN != -1L)
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
                .Where(it => it.leibie == "客户")
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
                    .Where(it => it.leibie == "客户")
                    .ToList();
                ShowData(getAll);
            }

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            Column1.Tag = "总行:";
            var getAll = db.Queryable<T_Base>()
                .Where(it => it.leibie == "客户")
                .ToList();
            ShowData(getAll);
            ref_txt();
        }
    }
}

﻿using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using DotNetBarProject.view.custom.view;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.view.baseinfo
{
    public partial class ShenChanGx : Office2007Form
    {
        string SHENGCHANGX = leibie.enumLB.生产工序.ToString();
        private LblWait lblwait;
        private SqlSugarClient db;
        private long SN_SN = -1L;
        //初始化
        public ShenChanGx()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Location = new Point(0, 0);
            db = SqlBase.GetInstance();

            lblwait = new LblWait((Form)this);
            groupPanel1.ResumeLayout(false);
            groupPanel1.PerformLayout();
            
        }
        /*
         * 点击事件
        */
        //双击表格
        private void datagrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (groupPanel1.Visible)
            {
                return;
            }
            if (e.RowIndex == -1) return;
            dgvEX1.CurrentCell = dgvEX1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            isShow(true);
            groupPanel1.Text = "修改数据";
            PopRow();

        }
        //右击
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
                    //SN_SN = (long)dgvEX1.Rows[e.RowIndex].Tag;
                    SN_SN = Convert.ToInt64(dgvEX1.Rows[e.RowIndex].Tag);
                }
                //弹出操作菜单
                CmsMenu.Show(MousePosition.X, MousePosition.Y);
            }
        }

        //右键
        private void dgvEX1_MouseClick(object sender, MouseEventArgs e)
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
        //增加空白
        private void 增加空白行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SN_SN = -1L;
            isShow(true);
            groupPanel1.Text = "增加数据";
            EmptyRow();
        }
        //增加修改 取消按钮
        private void button3_Click(object sender, EventArgs e)
        {
            isShow(false);
        }
        //查询item按钮
        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }
        //查询取消按钮
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            chkBianhao.chk.Checked = false;
            chkType.chk.Checked = false;

        }
        //修改按钮
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isShow(true);
            groupPanel1.Text = "修改数据";
            PopRow();
        }
        //刷新按钮
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblwait.showme();
            List<T_Base> asd = schText();
            ShowData(asd);
            lblwait.hideme();
        }
        //打印按钮
        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.dgvEX1.Print(SHENGCHANGX, "");
            this.lblwait.hideme();
        }
        //导出按钮
        private void 导出ExcleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            lblwait.showme();
            this.dgvEX1.saveExcel(SHENGCHANGX);
            lblwait.hideme();
        }
        //查询按钮
        private void button1_Click(object sender, EventArgs e)
        {
            lblwait.showme();
            List<T_Base> asd = schText();
            ShowData(asd);
            lblwait.hideme();
        }
        //增加修改确定按钮
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
                .Where(it => it.leibie == SHENGCHANGX)
                .ToList();
            ShowData(getAll);

        }
        //删除按钮
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确定删除吗?删除后将不可恢复!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
            {
                db.Deleteable<T_Base>().Where(it => it.SN == SN_SN).ExecuteCommand();
                MessageBox.Show(this, "删除成功!", "提示");
                var getAll = db.Queryable<T_Base>()
                    .Where(it => it.leibie == SHENGCHANGX)
                    .ToList();
                ShowData(getAll);
            }

        }
        //过渡函数

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
            try
            {
                var exp = Expressionable.Create<T_Base>().And(it => it.leibie == SHENGCHANGX);
                //.And(it => it.Id == 1)
                //.ToExpression();//拼接表达式
                if (chkBianhao.chk.Checked)
                {
                    exp.And(it => it.itemName == chkBianhao.txt.Text);
                    //itemName = chkTxt2.txt.Text;
                }
                if (chkType.chk.Checked)
                {
                    exp.And(it => it.itemName == chkType.txt.Text);
                    //item2 = chkTxt1.txt.Text;
                }
                getAll = db.Queryable<T_Base>()
                            .Where(exp.ToExpression())
                            .ToList();

            }catch(Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }


            return getAll;
        }
        //验证是否为空
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
        //插入数据
        private bool Insert()
        {
            bool flag = false;
            if (!YanZheng())
            {
                return flag;
            }
            try
            {
                var get = db.Queryable<T_Base>().Where(it => it.leibie == SHENGCHANGX && it.bianhao == lblTxt1.txt.Text).Count();
                if (get != 0)
                {
                    int num = (int)MessageBox.Show(lblTxt1.lblText + " 已存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return flag;
                }
                var insertObj = new T_Base()
                {
                    leibie = SHENGCHANGX,
                    bianhao = lblTxt1.txt.Text,
                    itemName = lblTxt2.txt.Text,
                    item0 = "",
                    item1 = "",
                    item2 = "",
                    item3 = "",
                    item4 = "",
                    item5 = "",
                    item6 = "",
                    item7 = "",
                    item8 = "",
                    item9 = "",
                    beizhu = ""
                };
                var t2 = db.Insertable<T_Base>(insertObj).ExecuteReturnIdentity();
                if (t2 > 0)
                {
                    flag = true;
                }
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }
            return flag;
        }
        //修改数据
        private bool editRow()
        {
            bool flag = false;
            if (!YanZheng())
            {
                return flag;
            }

            try
            {
                var get = db.Queryable<T_Base>().Where(it => it.leibie == SHENGCHANGX && it.bianhao == lblTxt1.txt.Text && (it.SN != SN_SN)).Count();
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

        
        //置为空
        private void EmptyRow()
        {
            this.lblTxt1.txt.Text = "";
            this.lblTxt2.txt.Text = "";
        }
        //编辑打开初始化
        private void PopRow()
        {
            SN_SN = Convert.ToInt64(dgvEX1.Rows[dgvEX1.CurrentRow.Index].Tag);
            var getAll = db.Queryable<T_Base>()
                   .Where(it => it.leibie == SHENGCHANGX && it.SN==SN_SN)
                   .ToList();
            if(getAll.Count != 1)
            {
                MessageBox.Show("不存在,请重新选择!");
            }
            var current = getAll[0];
            lblTxt1.txt.Text = current.bianhao;
            lblTxt2.txt.Text = current.itemName;
        }
        //关闭的时候
        private void CmsMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            修改ToolStripMenuItem.Enabled = false;
            删除ToolStripMenuItem.Enabled = false;
        }

        private void ShenChanGx_Load(object sender, EventArgs e)
        {

            Column2.Tag = "总行:";
            var getAll = db.Queryable<T_Base>()
                .Where(it => it.leibie == SHENGCHANGX)
                .ToList();
            ShowData(getAll);
        }
    }
}

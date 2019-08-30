using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using Microsoft.Reporting.WinForms;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.RenShiManager
{
    public partial class Tongxunlu : Office2007Form
    {
        SqlSugarClient db = null;
        long sn_sn = -1L;
        public Tongxunlu()
        {
            InitializeComponent();
            TopLevel = false;
            Location = new Point(0, 0);
            db = SqlBase.GetInstance();


            Rectangle ScreenArea = Screen.GetWorkingArea(this);

            Console.WriteLine("计算宽度:"+(ScreenArea.Width - JianLi.Width) / 2);
            //JianLi.Location = new Point((ScreenArea.Width- JianLi.Width)/2, 6);

            var all = db.Queryable<RSManage>().ToList();
            SN.Tag = "总行:";
            InitdgvEX1(all);
            chkCoboEX1.coboex.Items.Add("男");
            chkCoboEX1.coboex.Items.Add("女");
        }
        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            删除ToolStripMenuItem.Enabled = false;
        }
        /*
         * 
         * 展示面板
         * 
         */
        private void InitdgvEX1(List<RSManage> all)
        {
            dgvEX1.Rows.Clear();
            foreach (RSManage rSManage in all)
            {
                int index = dgvEX1.Rows.Add();
                dgvEX1.Rows[index].Tag = rSManage.SN;
                string[] xinbie = rSManage.Xingbie.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

                dgvEX1.Rows[index].Cells[0].Value = rSManage.SN;
                dgvEX1.Rows[index].Cells[1].Value = rSManage.Name;
                dgvEX1.Rows[index].Cells[2].Value = xinbie[0];
                dgvEX1.Rows[index].Cells[3].Value = rSManage.JiGuan;
                dgvEX1.Rows[index].Cells[4].Value = rSManage.born;
                dgvEX1.Rows[index].Cells[5].Value = rSManage.phone;
                dgvEX1.Rows[index].Cells[6].Value = rSManage.EMail;
                dgvEX1.Rows[index].Cells[7].Value = xinbie.Length==1?"":xinbie[1];
            }
            dgvEX1.HeJi();
        }

        //删除
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sn = (long)dgvEX1.CurrentRow.Tag;
            if (MessageBox.Show(this, "确定删除吗?删除后将不可恢复!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
            {
                db.Deleteable<RSManage>().Where(it => it.SN == sn).ExecuteCommand();
                MessageBox.Show(this, "删除成功!", "提示");
            }
            button1_Click(sender, e);

        }

        private void contextMenuStrip1_Closed_1(object sender, ToolStripDropDownClosedEventArgs e)
        {
            删除ToolStripMenuItem.Enabled = false;
        }
        private void dgvEX1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.Button == MouseButtons.Right)
            {
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
                sn_sn = (long)dgvEX1.CurrentRow.Tag;
                删除ToolStripMenuItem.Enabled = true;
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void dgvEX1_MouseDown(object sender, MouseEventArgs e)
        {
        }
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var exp = Expressionable.Create<RSManage>();
            if (chkTxt1.chk.Checked)
            {
                exp.And(it => SqlFunc.ToString(it.SN).Contains(chkTxt1.txt.Text));
            }
            if (chkTxt3.chk.Checked)
            {
                exp.And(it => it.Name.Contains(chkTxt3.txt.Text));
            }
            if (chkCoboEX1.chk.Checked)
            {
                exp.And(it => it.Xingbie.Contains(chkCoboEX1.coboex.Text));
            }
            if (chkTxt2.chk.Checked)
            {
                exp.And(it => it.JiGuan.Contains(chkTxt2.txt.Text));
            }
            if (chkTxt4.chk.Checked)
            {
                exp.And(it => it.phone.Contains(chkTxt4.txt.Text));
            }
            if (chkTxt5.chk.Checked)
            {
                exp.And(it => it.EMail.Contains(chkTxt5.txt.Text));
            }
            var getAll = db.Queryable<RSManage>()
                        .Where(exp.ToExpression())
                        .OrderBy(it=>it.SN, OrderByType.Desc)
                        .ToList();
            InitdgvEX1(getAll);
        }
        //修改
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TongXunLuPanel.Visible = false;
            JianLi.Visible = true;
            sn_sn = (long)dgvEX1.CurrentRow.Tag;
            var asd = db.Queryable<RSManage>().Where(it => it.SN == sn_sn).ToList();
            JianLiInit();
            if (asd.Count > 0)
            {
                JianLiInitSet(asd[0]);
                JianLiSet(true);
            }
            else
            {
                if (MessageBox.Show(this, "查询错误请重新查看", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.No)
                {
                    TongXunLuPanel.Visible = true;
                    JianLi.Visible = false;
                    JianLiInit();
                }
            }
        }
        private void 新建ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            TongXunLuPanel.Visible = false;
            JianLi.Visible = true;
            JianLiInit();
            JianLiEmpty();
        }

        //双击打开
        private void dgvEX1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TongXunLuPanel.Visible = false;
            JianLi.Visible = true;
            sn_sn = (long)dgvEX1.CurrentRow.Tag;
            var asd = db.Queryable<RSManage>().Where(it => it.SN == sn_sn).ToList();
            JianLiInit();
            if (asd.Count > 0)
            {
                JianLiInitSet(asd[0]);
            }
            else
            {
                if (MessageBox.Show(this, "查询错误请重新查看", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.No)
                {
                    TongXunLuPanel.Visible = true;
                    JianLi.Visible = false;
                    JianLiInit();
                }
            }
        }

        private void JianLiEmpty()
        {
            lblName.txt.Text = "";
            lblBorn.txt.Text = "";
            lblJiGuan.txt.Text = "";
            lblPhone.txt.Text = "";


            lblSex.txt.Text = "";
            lblTxt1.txt.Text = "";
            lblEmil.txt.Text = "";
            lblYxiang.txt.Text = "";
            lblAddr.txt.Text = "";

            lblJySj.txt.Text = "";
            lbllblJyXx.txt.Text = "";
            lbllblJyZy.txt.Text = "";
            lbllblJyNr.txt.Text = "";

            lblGzSj.txt.Text = "";
            lblGzgs.txt.Text = "";
            lblGzzw.txt.Text = "";
            lblGzNr.txt.Text = "";

            lblXmsj.txt.Text = "";
            lblXmm.txt.Text = "";
            lblXmzw.txt.Text = "";
            lblXmnr.txt.Text = "";

            lblZwPJ.txt.Text = "";
        }
        /*
         * 
         * 简历面板
         * 
         */

        private void JianLiInitSet(RSManage sn_sn)
        {
            lblName.txt.Text = sn_sn.Name;
            lblBorn.txt.Text = sn_sn.born;
            lblJiGuan.txt.Text = sn_sn.JiGuan;
            lblPhone.txt.Text = sn_sn.phone;
            string[] xinbie = sn_sn.Xingbie.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

            lblSex.txt.Text = xinbie[0];
            lblTxt1.txt.Text = xinbie.Length == 1 ? "" : xinbie[1];
            lblEmil.txt.Text = sn_sn.EMail;
            lblYxiang.txt.Text = sn_sn.Yixiang;
            lblAddr.txt.Text = sn_sn.Addr;

            string[] jy = sn_sn.JiaoYu.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

            lblJySj.txt.Text = jy[0] == "null" ? "" : jy[0];
            lbllblJyXx.txt.Text = jy[1] == "null" ? "" : jy[1];
            lbllblJyZy.txt.Text = jy[2] == "null" ? "" : jy[2];
            lbllblJyNr.txt.Text = jy[3] == "null" ? "" : jy[3];

            string[] gzjy = sn_sn.gzjy.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            lblGzSj.txt.Text = gzjy[0] == "null" ? "" : gzjy[0];
            lblGzgs.txt.Text = gzjy[1] == "null" ? "" : gzjy[1];
            lblGzzw.txt.Text = gzjy[2] == "null" ? "" : gzjy[2];
            lblGzNr.txt.Text = gzjy[3] == "null" ? "" : gzjy[3];

            string[] JiNeng = sn_sn.JiNeng.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            lblXmsj.txt.Text = JiNeng[0] == "null" ? "" : JiNeng[0];
            lblXmm.txt.Text = JiNeng[1] == "null" ? "" : JiNeng[1];
            lblXmzw.txt.Text = JiNeng[2] == "null" ? "" : JiNeng[2];
            lblXmnr.txt.Text = JiNeng[3] == "null" ? "" : JiNeng[3];

            lblZwPJ.txt.Text = sn_sn.Ziwopngjia;
        }
        private void JianLiSet(bool sn_sn)
        {
            lblName.txt.Enabled = sn_sn;
            lblBorn.txt.Enabled = sn_sn;
            lblJiGuan.txt.Enabled = sn_sn;
            lblPhone.txt.Enabled = sn_sn;
            lblSex.txt.Enabled = sn_sn;
            lblTxt1.txt.Enabled = sn_sn;
            lblEmil.txt.Enabled = sn_sn;
            lblYxiang.txt.Enabled = sn_sn;
            lblAddr.txt.Enabled = sn_sn;


            lblJySj.txt.Enabled = sn_sn;
            lbllblJyXx.txt.Enabled = sn_sn;
            lbllblJyZy.txt.Enabled = sn_sn;
            lbllblJyNr.txt.Enabled = sn_sn;

            lblGzSj.txt.Enabled = sn_sn;
            lblGzgs.txt.Enabled = sn_sn;
            lblGzzw.txt.Enabled = sn_sn;
            lblGzNr.txt.Enabled = sn_sn;

            lblXmsj.txt.Enabled = sn_sn;
            lblXmm.txt.Enabled = sn_sn;
            lblXmzw.txt.Enabled = sn_sn;
            lblXmnr.txt.Enabled = sn_sn;

            lblZwPJ.txt.Enabled = sn_sn;
            if (sn_sn)
            {
                pictureBox1.Click += new System.EventHandler(openIamge);
            }
            else
            {
                pictureBox1.Click -= new System.EventHandler(openIamge);
            }
        }
        private void openIamge(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();

            if (openfile.ShowDialog() == DialogResult.OK && (openfile.FileName != ""))
            {
                pictureBox1.ImageLocation = openfile.FileName;
                Console.WriteLine(openfile.FileName);
            }
            openfile.Dispose();
        }
        private void JianLiInit()
        {
            if(sn_sn == -1L)
            {
                JianLiSet(true);
            }
            else
            {

            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

            TongXunLuPanel.Visible = true;
            JianLi.Visible = false;
            JianLiInit();
            button1_Click(sender, e);
        }
        //保存简历
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lblName.txt.Enabled == false) return;
            RSManage rSManage = null;
            if (sn_sn == -1L)
            {
                rSManage = new RSManage();
                rSManage.Name = lblName.txt.Text;
                rSManage.Yixiang = lblYxiang.txt.Text;
                rSManage.Addr = lblAddr.txt.Text;
                rSManage.phone = lblPhone.txt.Text;
                rSManage.EMail = lblEmil.txt.Text;
                rSManage.born = lblBorn.txt.Text;
                rSManage.JiGuan = lblJiGuan.txt.Text;
                rSManage.Xingbie = lblSex.txt.Text + "||" + lblTxt1.txt.Text;


                rSManage.JiaoYu = (lblJySj.txt.Text.Length == 0 ? "null" : lblJySj.txt.Text) + "||" +
                                   (lbllblJyXx.txt.Text.Length == 0 ? "null" : lbllblJyXx.txt.Text) + "||" +
                                   (lbllblJyZy.txt.Text.Length == 0 ? "null" : lbllblJyZy.txt.Text) + "||" +
                                   (lbllblJyNr.txt.Text.Length == 0 ? "null" : lbllblJyNr.txt.Text);

                rSManage.gzjy = (lblGzSj.txt.Text.Length == 0 ? "null" : lblGzSj.txt.Text) + "||" +
                               (lblGzgs.txt.Text.Length == 0 ? "null" : lblGzgs.txt.Text) + "||" +
                               (lblGzzw.txt.Text.Length == 0 ? "null" : lblGzzw.txt.Text) + "||" +
                               (lblGzNr.txt.Text.Length == 0 ? "null" : lblGzNr.txt.Text);

                rSManage.JiNeng = (lblXmsj.txt.Text.Length == 0 ? "null" : lblXmsj.txt.Text) + "||" +
                               (lblXmm.txt.Text.Length == 0 ? "null" : lblXmm.txt.Text) + "||" +
                               (lblXmzw.txt.Text.Length == 0 ? "null" : lblXmzw.txt.Text) + "||" +
                               (lblXmnr.txt.Text.Length == 0 ? "null" : lblXmnr.txt.Text);

                rSManage.Ziwopngjia = lblZwPJ.txt.Text;
                db.Insertable<RSManage>(rSManage).ExecuteCommand();
                if (MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    TongXunLuPanel.Visible = false;
                    JianLi.Visible = true;
                    JianLiInit();
                }
            }
            else
            {
                var all = db.Queryable<RSManage>()
                    .Where(it => it.SN == sn_sn)
                    .ToList();
                if(all.Count > 0)
                {
                    rSManage = all[0];
                    rSManage.Name = lblName.txt.Text;
                    rSManage.Yixiang = lblYxiang.txt.Text;
                    rSManage.Addr = lblAddr.txt.Text;
                    rSManage.phone = lblPhone.txt.Text;
                    rSManage.EMail = lblEmil.txt.Text;
                    rSManage.born = lblBorn.txt.Text;
                    rSManage.JiGuan = lblJiGuan.txt.Text;
                    //rSManage.Xingbie = lblSex.txt.Text;
                    rSManage.Xingbie = lblSex.txt.Text + "||" + lblTxt1.txt.Text;


                    rSManage.JiaoYu = (lblJySj.txt.Text.Length == 0 ? "null": lblJySj.txt.Text) + "||" +
                                   (lbllblJyXx.txt.Text.Length == 0 ? "null" : lbllblJyXx.txt.Text) + "||" +
                                   (lbllblJyZy.txt.Text.Length == 0 ? "null" : lbllblJyZy.txt.Text) + "||" +
                                   (lbllblJyNr.txt.Text.Length == 0 ? "null" : lbllblJyNr.txt.Text);

                    rSManage.gzjy = (lblGzSj.txt.Text.Length == 0 ? "null" : lblGzSj.txt.Text) + "||" +
                                   (lblGzgs.txt.Text.Length == 0 ? "null" : lblGzgs.txt.Text) + "||" +
                                   (lblGzzw.txt.Text.Length == 0 ? "null" : lblGzzw.txt.Text) + "||" +
                                   (lblGzNr.txt.Text.Length == 0 ? "null" : lblGzNr.txt.Text);

                    rSManage.JiNeng = (lblXmsj.txt.Text.Length == 0 ? "null" : lblXmsj.txt.Text) + "||" +
                                   (lblXmm.txt.Text.Length == 0 ? "null" : lblXmm.txt.Text) + "||" +
                                   (lblXmzw.txt.Text.Length == 0 ? "null" : lblXmzw.txt.Text) + "||" +
                                   (lblXmnr.txt.Text.Length == 0 ? "null" : lblXmnr.txt.Text);

                    rSManage.Ziwopngjia = lblZwPJ.txt.Text;
                    db.Updateable<RSManage>(rSManage).ExecuteCommand();

                    if (MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
                    {
                        TongXunLuPanel.Visible = true;
                        JianLi.Visible = false;
                        JianLiInit();
                    }
                }
                else
                {
                    MessageBoxEx.Show("请退出重新编辑");
                }

            }
            button1_Click(sender, e);
        }

        private void 打印通讯录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            //this.lblwait.showme();
            this.dgvEX1.Print("通讯录", "");
            //this.lblwait.hideme();
        }

        private void 导出ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            //lblwait.showme();
            this.dgvEX1.saveExcel("通讯录");
            //lblwait.hideme();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 打印简历ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserProc.WaitStart(this);
            RSManage rSManage = db.Queryable<RSManage>().Where(it => it.SN == sn_sn).First();
            if (rSManage == null)
            {
                MessageBox.Show("请先选择要打印的行");
            }
            else
            {
                RSManage1 rSManage1 = new RSManage1();
                string[] xinbie = rSManage.Xingbie.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

                rSManage1.SN = rSManage.SN;
                rSManage1.Name = rSManage.Name;
                rSManage1.Yixiang = rSManage.Yixiang;
                rSManage1.Addr = rSManage.Addr;
                rSManage1.phone = rSManage.phone;
                rSManage1.EMail = rSManage.EMail;
                rSManage1.born = rSManage.born;
                rSManage1.JiGuan = rSManage.JiGuan;
                rSManage1.Xingbie = rSManage.Xingbie;
                rSManage1.Ziwopngjia = rSManage.Ziwopngjia;


                rSManage1.Xingbie = xinbie.Length == 0 ? "" : xinbie[0];
                rSManage1.sf = xinbie.Length == 1 ? "" : xinbie[1];

                string[] jy = rSManage.JiaoYu.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

                rSManage1.JiaoYu1 = jy[0] == "null" ? "" : jy[0];
                rSManage1.JiaoYu2 = jy[1] == "null" ? "" : jy[1];
                rSManage1.JiaoYu3 = jy[2] == "null" ? "" : jy[2];
                rSManage1.JiaoYu4 = jy[3] == "null" ? "" : jy[3];

                string[] gzjy = rSManage.gzjy.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                rSManage1.gzjy1 = gzjy[0] == "null" ? "" : gzjy[0];
                rSManage1.gzjy2 = gzjy[1] == "null" ? "" : gzjy[1];
                rSManage1.gzjy3 = gzjy[2] == "null" ? "" : gzjy[2];
                rSManage1.gzjy4 = gzjy[3] == "null" ? "" : gzjy[3];

                string[] JiNeng = rSManage.JiNeng.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                rSManage1.JiNeng1 = JiNeng[0] == "null" ? "" : JiNeng[0];
                rSManage1.JiNeng2 = JiNeng[1] == "null" ? "" : JiNeng[1];
                rSManage1.JiNeng3 = JiNeng[2] == "null" ? "" : JiNeng[2];
                rSManage1.JiNeng4 = JiNeng[3] == "null" ? "" : JiNeng[3];


                FrmPrn frmPrn = new FrmPrn();
                frmPrn.rptView.LocalReport.ReportEmbeddedResource = "DotNetBarProject.view.RDLC.rptTXL.rdlc";
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = rSManage1;
                ReportDataSource reportDataSource = new ReportDataSource();
                
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = bindingSource;
                frmPrn.rptView.LocalReport.DataSources.Clear();
                frmPrn.rptView.LocalReport.DataSources.Add(reportDataSource);
                var a = frmPrn.rptView.LocalReport.DataSources;
                frmPrn.rptView.RefreshReport();
                frmPrn.ShowDialog();
                frmPrn.Close();
                UserProc.WaitEnd(this);

            }

        }
    }
}

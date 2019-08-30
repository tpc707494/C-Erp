using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using DotNetBarProject.view.custom.view;
using Microsoft.Reporting.WinForms;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.peibucang
{
    public partial class MaDanChaXun : Office2007Form
    {
        string benleibie = "码单";
        private LblWait lblwait;
        public SqlSugarClient db;
        private long SN_SN = -1L;
        int Mode = 0; //0 默认，1新建，2修改
        List<String> list_value = new List<string>(50);
        public MaDanChaXun()
        {
            InitializeComponent();
            lblwait = new LblWait(this);
            TopLevel = false;
            Location = new Point(0, 0);
            db = SqlBase.GetInstance();
            //tabEx1.SelectedIndexChanged += TabEx1_SelectedIndexChanged;
            InitTab2();

            InitdataGridView(true);
            lblTxt5.txt.Text = ClsLogUser.XinMing;

        }
        private void InitdataGridView(bool flag)
        {
            dataGridView1.Rows.Clear();
            if (flag)
            {
                list_value.Clear();
                for (var i = 0; i < 50; i++)
                {
                    list_value.Add("-");

                }
            }
            for (var i = 1; i <= 10; i++)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value =i;
                dataGridView1.Rows[index].Cells[1].Value = list_value[i - 1] == "-" ? "" : list_value[i - 1];
                dataGridView1.Rows[index].Cells[2].Value = i+10;
                dataGridView1.Rows[index].Cells[3].Value = list_value[i + 10 - 1] == "-" ? "" : list_value[i + 10 - 1];
                dataGridView1.Rows[index].Cells[4].Value = i+20;
                dataGridView1.Rows[index].Cells[5].Value = list_value[i + 20 - 1] == "-" ? "" : list_value[i + 20 - 1];
                dataGridView1.Rows[index].Cells[6].Value = i+30;
                dataGridView1.Rows[index].Cells[7].Value = list_value[i + 30 - 1] == "-" ? "" : list_value[i + 30 - 1];
                dataGridView1.Rows[index].Cells[8].Value = i+40;
                dataGridView1.Rows[index].Cells[9].Value = list_value[i + 40 - 1] == "-" ? "" : list_value[i + 40 - 1];
            }
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
            var exp = Expressionable.Create<BaseIList>().And(it=>it.leibie== benleibie);


            if (checkMohu.Checked)
            {
                if (chkGH.chkSel)
                    exp.And((b) => b.item0.Contains(chkGH.txt.Text));
                if (chkKehu.chkSel)
                    exp.And((b) => b.kehu.Contains(chkKehu.cobodgv.Text));
                if (chkPinmin.chkSel)
                    exp.And((b) => b.pingmin.Contains(chkPinmin.cobodgv.Text));
                if (chkZL.chkSel)
                    exp.And((b) => b.zongliang.Contains(chkZL.txt.Text));
                if (chkPS.chkSel)
                    exp.And((b) => b.pishu.Contains(chkPS.txt.Text));
                if (chkSH.chkSel)
                    exp.And((b) => b.sehao.Contains(chkSH.cobodgv.Text));
                if (chkSM.chkSel)
                    exp.And((b) => b.seming.Contains(chkSM.cobodgv.Text));
                if (chkDDH.chkSel)
                    exp.And((b) => b.dingdanhao.Contains(chkDDH.txt.Text));
                if (chkMF.chkSel)
                    exp.And((b) => b.menfu.Contains(chkMF.txt.Text));
                if (chkKZ.chkSel)
                    exp.And((b) => b.kezong.Contains(chkKZ.txt.Text));
            }
            else
            {
                if (chkGH.chkSel)
                    exp.And((b) => b.item0 == (chkGH.txt.Text));
                if (chkKehu.chkSel)
                    exp.And((b) => b.kehu == (chkKehu.cobodgv.Text));
                if (chkPinmin.chkSel)
                    exp.And((b) => b.pingmin == (chkPinmin.cobodgv.Text));
                if (chkZL.chkSel)
                    exp.And((b) => b.zongliang == (chkZL.txt.Text));
                if (chkPS.chkSel)
                    exp.And((b) => b.pishu == (chkPS.txt.Text));
                if (chkSH.chkSel)
                    exp.And((b) => b.sehao == (chkSH.cobodgv.Text));
                if (chkSM.chkSel)
                    exp.And((b) => b.seming == (chkSM.cobodgv.Text));
                if (chkDDH.chkSel)
                    exp.And((b) => b.dingdanhao == (chkDDH.txt.Text));
                if (chkMF.chkSel)
                    exp.And((b) => b.menfu == (chkMF.txt.Text));
                if (chkKZ.chkSel)
                    exp.And((b) => b.kezong == (chkKZ.txt.Text));
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
            .OrderBy((b) => b.SN, OrderByType.Desc)
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
                dgvEX1.Rows[index].Cells[0].Value = baseIList.kehu;
                dgvEX1.Rows[index].Cells[1].Value = baseIList.item0;
                dgvEX1.Rows[index].Cells[2].Value = baseIList.pingmin;
                dgvEX1.Rows[index].Cells[3].Value = baseIList.riqi;
                dgvEX1.Rows[index].Cells[4].Value = baseIList.seming;
                dgvEX1.Rows[index].Cells[5].Value = baseIList.sehao;
                dgvEX1.Rows[index].Cells[6].Value = baseIList.pishu;

                dgvEX1.Rows[index].Cells[7].Value = baseIList.zongliang;
                dgvEX1.Rows[index].Cells[8].Value = baseIList.dingdanhao;
                dgvEX1.Rows[index].Cells[9].Value = baseIList.menfu;
                dgvEX1.Rows[index].Cells[10].Value = baseIList.kezong;
                dgvEX1.Rows[index].Cells[11].Value = baseIList.item1;

            }
            dgvEX1.HeJi();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            //long asd = (long)dgvEX1.Rows[dgvEX1.CurrentRow.Index].Tag;
            //SN_SN = asd;
            tabEx1.SelectedIndex = 1;
        }
        

        private void JInCangChaXun_Load(object sender, EventArgs e)
        {
            Column3.Tag = "总行:";
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
        private void query1(long sn)
        {
            var baseIList = db.Queryable<BaseIList>()
                    .Where(aa => aa.SN == sn)
                    .First();
            if (baseIList != null)
            {
                lblGH.txt.Text = baseIList.item0;
                lblKH.txt.Text = baseIList.kehu;
                lblDDH.txt.Text = baseIList.dingdanhao;
                riqi.Value = baseIList.riqi;

                lblPM.txt.Text = baseIList.pingmin;
                lblSM.txt.Text = baseIList.seming;
                lblMF.txt.Text = baseIList.menfu;

                lblSH.txt.Text = baseIList.sehao;
                lblPS.txt.Text = baseIList.pishu;
                lblKZ.txt.Text = baseIList.kezong;

                lblZL.txt.Text = baseIList.zongliang;
                
                string list_value_c = baseIList.item3;
                if (list_value_c != null)
                {
                    list_value = new List<string>(list_value_c.Split("||".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                    InitdataGridView(false);
                }
                else
                {
                    InitdataGridView(true);
                }
                
                lblBZ.txt.Text = baseIList.item1;
                lblTxt1.txt.Text = baseIList.item2;
            }
            else
            {
                MessageBoxEx.Show("此码单未发现", "提示");
            }
        }
        private void Query(string sn)
        {
            //try
            {
                var baseIList = db.Queryable<BaseIList>()
                    .Where(aa => aa.item0 == sn)
                    .First();
                if (baseIList != null)
                {
                    lblKH.txt.Text = baseIList.kehu;
                    lblDDH.txt.Text = baseIList.dingdanhao;
                    riqi.Value = baseIList.riqi;

                    lblPM.txt.Text = baseIList.pingmin;
                    lblSM.txt.Text = baseIList.seming;
                    lblMF.txt.Text = baseIList.menfu;

                    lblSH.txt.Text = baseIList.sehao;
                    lblPS.txt.Text = baseIList.pishu;
                    lblKZ.txt.Text = baseIList.kezong;

                    lblZL.txt.Text = baseIList.zongliang;
                    lblTxt1.txt.Text = baseIList.item2;
                    string list_value_c = baseIList.item3;
                    if (list_value_c != null)
                    {
                        list_value = new List<string>(list_value_c.Split("||".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                        InitdataGridView(false);
                    }
                    else
                    {
                        InitdataGridView(true);
                    }
                    SN_SN = baseIList.SN;

                    lblBZ.txt.Text = baseIList.item1;
                }
                else
                {
                    var lcak = db.Queryable<LCKA>()
                        .Where(aa => aa.liushuihao == sn)
                        .First();
                    if (lcak != null)
                    {
                        lblKH.txt.Text = lcak.kehu;
                        lblPM.txt.Text = lcak.peiming;
                        lblSM.txt.Text = lcak.sebie;

                        lblDDH.txt.Text = lcak.dingdanhao;
                        lblMF.txt.Text = lcak.fukuan;
                        lblSH.txt.Text = lcak.sehao;

                        lblKZ.txt.Text = lcak.kezhong;
                        lblZL.txt.Text = lcak.zhongliang;
                        lblPS.txt.Text = lcak.peishu;

                        riqi.Value = DateTime.Now;
                        lblTxt1.txt.Text = lblZL.txt.Text;
                        //list_value = new List<string>(50);
                        InitdataGridView(true);
                    }

                }
            }
            //catch (Exception ex)
            {
               // MessageBoxEx.Show(ex.Message);
///return;
            }
        }
        //使能
        private void EnableInput(bool flag)
        {
            lblGH.txt.Enabled = flag;
            lblKH.txt.Enabled = flag;
            lblDDH.txt.Enabled = flag;
            riqi.Value = DateTime.Now;

            lblPM.txt.Enabled = flag;
            lblSM.txt.Enabled = flag;
            lblMF.txt.Enabled = flag;

            lblSH.txt.Enabled = flag;
            lblPS.txt.Enabled = flag;
            lblKZ.txt.Enabled = flag;

            lblZL.txt.Enabled = flag;
            lblTxt1.txt.Enabled = flag;
            lblBZ.txt.Enabled = flag;
        }
        //置空
        private void EmptyInput(int index)
        {
            if (index == 0) lblGH.txt.Text = "";
            lblKH.txt.Text = "";
            lblDDH.txt.Text = "";
            riqi.Value = DateTime.Now;

            lblPM.txt.Text = "";
            lblSM.txt.Text = "";
            lblMF.txt.Text = "";

            lblSH.txt.Text = "";
            lblPS.txt.Text = "";
            lblKZ.txt.Text = "";

            lblZL.txt.Text = "";

            lblBZ.txt.Text = "";
            lblTxt1.txt.Text = "";
            //list_value = new List<string>(50);
            InitdataGridView(true);
        }
        private bool Edit()
        {
            var all1 = db.Queryable<BaseIList>()
                    .Where(it => it.SN == SN_SN)
                    .OrderBy(it => it.item0, OrderByType.Desc)
                    .First();
            if (all1 == null)
            {
                MessageBoxEx.Show("这没有发现此缸号重新选择");
                return false;
            }
            else
            {
                //BaseIList baseIList = new BaseIList()
                {
                    all1.item0 = lblGH.txt.Text;
                    all1.kehu = lblKH.txt.Text;
                    all1.dingdanhao = lblDDH.txt.Text;
                    all1.riqi = DateTime.Now;
                    all1.pingmin = lblPM.txt.Text;
                    all1.seming = lblSM.txt.Text;
                    all1.menfu = lblMF.txt.Text;
                    all1.sehao = lblSH.txt.Text;
                    all1.pishu = lblPS.txt.Text;
                    all1.kezong = lblKZ.txt.Text;
                    all1.zongliang = lblZL.txt.Text;
                    all1.item1 = lblBZ.txt.Text;
                    all1.item2 = lblTxt1.txt.Text;
                    all1.item3 = string.Join("||", list_value.ToArray());
                    all1.leibie = benleibie;
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
            var all1 = db.Queryable<LCKA>()
                    .Where(it => int.Parse(it.liushuihao) == int.Parse(lblGH.txt.Text))
                    .OrderBy(it => it.liushuihao, OrderByType.Desc)
                    .First();
            if (all1 == null)
            {
                MessageBoxEx.Show("这没有发现此缸号重新选择");
                return false;
            }
            else
            {
                BaseIList baseIList = new BaseIList()
                {
                    item0 = lblGH.txt.Text,
                    kehu = lblKH.txt.Text,
                    dingdanhao = lblDDH.txt.Text,
                    riqi = DateTime.Now,
                    pingmin = lblPM.txt.Text,
                    seming = lblSM.txt.Text,
                    menfu = lblMF.txt.Text,
                    sehao = lblSH.txt.Text,
                    pishu = lblPS.txt.Text,
                    kezong = lblKZ.txt.Text,
                    zongliang = lblZL.txt.Text,
                    item1 = lblBZ.txt.Text,
                    item2 = lblTxt1.txt.Text,
                    
                    item3 = string.Join("||", list_value.ToArray()),
                    leibie = benleibie,
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
            Mode = 1;
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = true;
            InitdataGridView(true);
        }

        private void ourButton2_Click(object sender, EventArgs e)
        {
            EnableInput(true);
            Mode = 2;
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = true;
        }

        private void ourButton3_Click(object sender, EventArgs e)
        {
            tabEx1.SelectedIndex = 0;
            Mode = 0;
        }

        private void ourButton4_Click(object sender, EventArgs e)
        {
            if (Mode != 0)
            {
                if (SN_SN == -1L)
                {
                    if (Save())
                    {
                        MessageBoxEx.Show("保存成功", "提示");
                        flowLayoutPanel1.Visible = true;
                        flowLayoutPanel2.Visible = false;
                        EnableInput(false);
                    }
                }
                else
                {
                    if (Edit())
                    {
                        MessageBoxEx.Show("修改成功", "提示");
                        flowLayoutPanel1.Visible = true;
                        flowLayoutPanel2.Visible = false;
                        EnableInput(false);
                        Mode = 0;
                    }
                }
            }
            InitdataGridView(true);
        }

        private void ourButton5_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = false;
            EmptyInput(0);
            EnableInput(false);
            Mode = 0;
            InitdataGridView(true);
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.dgvEX1.Print("码单", UserProc.CheckTime);
            this.lblwait.hideme();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvEX1.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.dgvEX1.saveExcel("码单");
            this.lblwait.hideme();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int c_value = e.ColumnIndex;
            int r_value = e.RowIndex;
            if (c_value % 2 != 1) return;
            object asd = dataGridView1.Rows[r_value].Cells[c_value].Value;
            string value = "-";
            if (asd != null)
            {
                value = asd.ToString();
            }
            list_value[(c_value / 2) * 10 + r_value] = value;
            double a = 0.0;
            for(var i=0;i< list_value.Count; i++)
            {
                string sa = "0";
                if (list_value[i].Equals("-"))
                {
                    sa = "0";
                }
                else
                {
                    sa = list_value[i];
                }
                try
                {
                    a += Convert.ToDouble(list_value[i]);
                }catch(Exception ex)
                {
                    a += 0;
                }
            }
            lblZL.txt.Text = a+"";
            lblTxt1.txt.Text = a + "";
        }

        private void ourButton2_Click_1(object sender, EventArgs e)
        {

            UserProc.WaitStart(this);
            var das = db.Queryable<BaseIList>().Where(it => it.leibie == benleibie && it.SN == SN_SN).First();
            if(das != null)
            {
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = das;
                FrmPrn frmPrn = new FrmPrn();
                frmPrn.rptView.LocalReport.ReportEmbeddedResource = "DotNetBarProject.view.RDLC.rptMD.rdlc";
                string[] asdf = das.item3.Split("||".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                float[] a = {0, 0, 0, 0, 0};
                for (var i = 0; i < asdf.Length; i++)
                {
                    asdf[i] = asdf[i] == "-" ? " " : asdf[i];
                    int www = (int)Math.Floor((double)i / 12);
                    a[www] += asdf[i] == " " ? 0 : float.Parse(asdf[i]);
                }
                string[] b = new string[5];
                for(int i = 0; i < a.Length; i++)
                {
                    b[i] = a[i] + "";
                    b[i] = b[i] == "0" ? " " : b[i];
                }

                
                ReportParameter parameters2 = new ReportParameter("P2", asdf);
                ReportParameter parameters3 = new ReportParameter("P3", ClsLogUser.XinMing);
                ReportParameter parameters4 = new ReportParameter("P4", b);
                frmPrn.rptView.LocalReport.SetParameters(parameters2);
                frmPrn.rptView.LocalReport.SetParameters(parameters3);
                frmPrn.rptView.LocalReport.SetParameters(parameters4);
                frmPrn.rptView.LocalReport.DataSources.Clear();
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = bindingSource;
                frmPrn.rptView.LocalReport.DataSources.Clear();
                frmPrn.rptView.LocalReport.DataSources.Add(reportDataSource);
                frmPrn.rptView.RefreshReport();
                frmPrn.ShowDialog();
                frmPrn.Close();
            }
            else
            {
                MessageBox.Show("数据错误，请重新选择在打印", "提示");
            }
            UserProc.WaitEnd(this);
        }
    }
}

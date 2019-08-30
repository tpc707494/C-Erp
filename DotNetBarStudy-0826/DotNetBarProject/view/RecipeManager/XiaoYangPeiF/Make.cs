using BarcodeLib;
using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using DotNetBarProject.view.custom.view;
using Microsoft.Reporting.WinForms;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetBarProject.view.RecipeManager.XiaoYangPeiF
{
    public partial class Make : Office2007Form
    {
        public lck.LckBarSearch.DoubleList doublelist;
        private LblWait lblwait;
        string XYD = leibie.enumPFLB.小样单.ToString();
        SqlSugarClient db;
        BindingSource bsKH, bsYanse, bsSeH, bsDY, bsGx, bsRl, bsNd, bsPM;

        private BindingSource bsShowMain;
        private BindingSource bsShowData;
        long SN_SN = -1L;
        public Make()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            db = SqlBase.GetInstance();
            lblwait = new LblWait((Form)this);
            ///Column3.Tag = (object)"行:";
            initEvent();
            refList();
            bsShowMain = new BindingSource();
            bsShowData = new BindingSource();
        }
        private void initEvent()
        {
            bsKH = new BindingSource();
            bsYanse = new BindingSource();
            bsSeH = new BindingSource();
            bsDY = new BindingSource();
            bsGx = new BindingSource();
            bsRl = new BindingSource();
            bsNd = new BindingSource();
            bsPM = new BindingSource();
            lblTxt1.txt.GotFocus += Txt_GotFocus;
            lblTxt3.txt.GotFocus += lblTxt3_GotFocus;
            lblTxt5.txt.GotFocus += lblTxt5_GotFocus;
            lblTxt6.txt.GotFocus += lblTxt6_GotFocus;
            lblTxt4.txt.GotFocus += lblTxt4_GotFocus;
            //lblTxt2.txt.GotFocus += Txt_GotFocus;
            dgvEX2.CellMouseClick += new DataGridViewCellMouseEventHandler(this.editDgvList_CellMouseClick);
            dgvEX1.CellEnter += new DataGridViewCellEventHandler(this.editDgvMain_CellEnter);
            dgvEX1.CellValidating += new DataGridViewCellValidatingEventHandler(this.editDgvMain_CellValidating);


        }
        private void editDgvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            switch (dgvEX1.Columns[e.ColumnIndex].Name)
            {
                case "Column1":
                    if (dgvEX2.DataSource == this.bsGx)
                        break;
                    dgvEX2.DataSource = (object)null;
                    bsGx.Filter = "";
                    dgvEX2.DataSource = (object)this.bsGx;
                    break;
                case "Column2":
                    if (dgvEX2.DataSource == this.bsRl)
                        break;
                    dgvEX2.DataSource = (object)null;
                    this.bsRl.Filter = "";
                    dgvEX2.DataSource = (object)this.bsRl;
                    break;
                case "Column4":
                    if (dgvEX2.DataSource == this.bsNd)
                        break;
                    dgvEX2.DataSource = (object)null;
                    this.bsNd.Filter = "";
                    dgvEX2.DataSource = (object)this.bsNd;
                    break;
            }

            for (var i = 0; i < dgvEX2.Columns.Count; i++)
            {
                dgvEX2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvEX2.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void lblTxt6_GotFocus(object sender, EventArgs e)
        {
            if (dgvEX2.DataSource == bsSeH)
                return;
            dgvEX2.Columns.Clear();
            dgvEX2.DataSource = null;
            bsSeH.Filter = "";
            dgvEX2.DataSource = (object)this.bsSeH;
            for (var i = 0; i < dgvEX2.Columns.Count; i++)
            {
                dgvEX2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvEX2.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void lblTxt4_GotFocus(object sender, EventArgs e)
        {
            if (dgvEX2.DataSource == bsPM)
                return;
            dgvEX2.Columns.Clear();
            dgvEX2.DataSource = null;
            bsPM.Filter = "";
            dgvEX2.DataSource = (object)this.bsPM;
            for (var i = 0; i < dgvEX2.Columns.Count; i++)
            {
                dgvEX2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvEX2.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void lblTxt5_GotFocus(object sender, EventArgs e)
        {
            if (dgvEX2.DataSource == bsDY)
                return;
            dgvEX2.Columns.Clear();
            dgvEX2.DataSource = null;
            bsDY.Filter = "";
            dgvEX2.DataSource = (object)this.bsDY;
            for (var i = 0; i < dgvEX2.Columns.Count; i++)
            {
                dgvEX2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvEX2.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void lblTxt3_GotFocus(object sender, EventArgs e)
        {
            if (dgvEX2.DataSource == bsYanse)
                return;
            dgvEX2.Columns.Clear();
            dgvEX2.DataSource = null;
            bsYanse.Filter = "";
            dgvEX2.DataSource = (object)this.bsYanse;
            for (var i = 0; i < dgvEX2.Columns.Count; i++)
            {
                dgvEX2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvEX2.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void Txt_GotFocus(object sender, EventArgs e)
        {
            if (dgvEX2.DataSource == bsKH)
                return;
            dgvEX2.Columns.Clear();
            dgvEX2.DataSource = null;
            bsKH.Filter = "";
            dgvEX2.DataSource = (object)this.bsKH;
            for (var i = 0; i < dgvEX2.Columns.Count; i++)
            {
                dgvEX2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvEX2.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel2.Visible)
                dgvEX1.Rows.RemoveAt(dgvEX1.CurrentRow.Index);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel2.Visible)
            {
                if (dgvEX1.CurrentRow == null)
                    return;
                DataGridViewRow currentRow = dgvEX1.CurrentRow;
                if (currentRow.Index == 0)
                    return;
                dgvEX1.Rows.Insert(currentRow.Index - 1, 1);
                DataGridViewRow row = dgvEX1.Rows[currentRow.Index - 2];
                for (int index = 0; index < dgvEX1.ColumnCount; ++index)
                    row.Cells[index].Value = currentRow.Cells[index].Value;
                dgvEX1.CurrentCell = row.Cells[dgvEX1.CurrentCell.ColumnIndex];
                dgvEX1.Rows.Remove(currentRow);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel2.Visible)
            {
                if (dgvEX1.CurrentRow == null)
                    return;
                DataGridViewRow currentRow = dgvEX1.CurrentRow;
                if (currentRow.Index == dgvEX1.RowCount - 1)
                    return;
                dgvEX1.Rows.Insert(currentRow.Index + 2, 1);
                DataGridViewRow row = dgvEX1.Rows[currentRow.Index + 2];
                for (int index = 0; index < dgvEX1.ColumnCount; ++index)
                    row.Cells[index].Value = currentRow.Cells[index].Value;
                dgvEX1.CurrentCell = row.Cells[dgvEX1.CurrentCell.ColumnIndex];
                dgvEX1.Rows.Remove(currentRow);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = true;
            Empty();
            setPict(jisuandanhao());
            SetReadOnly(false);
            panel1.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show((IWin32Window)this, "确认取消吗 ?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;
            //this.ExeMode = frmXY.exeMode.显示料单;
            //this.showLD();
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = false;
            SetReadOnly(true);
            panel1.Visible = false;
            SetData(SN_SN);
        }
        private bool Save()
        {
            if (editImgLDH.Image == null || editImgLDH.Tag == null)
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "生成单号失败,请检查!!!", "提示");
                return false;
            }
            try
            {
                T_PFmain entity = new T_PFmain()
                {
                    leibie = leibie.enumPFLB.小样单.ToString(),
                    danhao = this.editImgLDH.Tag.ToString(),
                    ganghao = "",
                    JLci = 0,
                    shazhong = lblTxt4.txt.Text,
                    guige = "",
                    pihao = "",
                    kehu = lblTxt1.txt.Text,
                    dingdan = lblTxt2.txt.Text,
                    sehao = lblTxt6.txt.Text,
                    yanse = lblTxt3.txt.Text,
                    jihao = "",
                    shuiliang = new Decimal(0),
                    zhongliang = new Decimal(0),
                    jiagong = "",
                    yewuyuan = "",
                    dayang = lblTxt5.txt.Text,
                    zhuche = "",
                    peifang = ClsLogUser.XinMing,
                    fuhe = "",
                    mishu = new Decimal(0),
                    kezhong = "0",
                    danjia = new Decimal(0),
                    beizhu = lblTxt7.txt.Text,
                    riqiSave = new DateTime?(DateTime.Now),
                    riqiShen = new DateTime?(),
                    riqiCheng = new DateTime?(),
                    JLciHJ = 0,
                    sta = leibie.staPF.未审核.ToString(),
                    editrec = DateTime.Now.ToString("yy-MM-dd HH:mm") + ClsLogUser.XinMing + "建立。"
                };
                var d = db.Insertable<T_PFmain>(entity).ExecuteCommand();
                for (int index = 0; index < dgvEX1.RowCount; ++index)
                {
                    T_PFdata a = new T_PFdata()
                    {
                        danhao = entity.danhao,
                        gongxu = dgvEX1.Rows[index].Cells[0].FormattedValue.ToString(),
                        ranliao = dgvEX1.Rows[index].Cells[1].FormattedValue.ToString(),
                        ranliaoBZ = "",
                        bili = dgvEX1.Rows[index].Cells[2].FormattedValue.ToString() == "" ? new Decimal(0) : Convert.ToDecimal(dgvEX1.Rows[index].Cells[2].FormattedValue.ToString()),
                        biliDW = dgvEX1.Rows[index].Cells[3].FormattedValue.ToString(),
                        yaoqiu = dgvEX1.Rows[index].Cells[4].FormattedValue.ToString(),
                        yongliang = new Decimal(0),
                        yongliangDW = "",
                        JLbili = new Decimal(0),
                        JLyongliang = new Decimal(0),
                        JLyongliangDW = "",
                        SNld = -1L
                    };
                    var e = db.Insertable<T_PFdata>(a).ExecuteCommand();
                }
                return true;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show((IWin32Window)this, ex.Message + "\r\n\r\n   保存失败,请核查原因再试一次!", "提示");
                return false;
            }
        }
        private bool editLD()
        {
            try
            {
                var a = db.Queryable<T_PFmain>().Where(it => it.danhao == editImgLDH.Tag.ToString()).First();
                if (a == null || a.sta != editLblStaLD.Text)
                {
                    int num2 = (int)MessageBox.Show((IWin32Window)this, "本小样配方已不存在或状态发生改变!请核查!", "提示");
                    return false;
                }
                a.kehu = lblTxt1.txt.Text;
                a.shazhong = lblTxt4.txt.Text;
                a.sehao = lblTxt6.txt.Text;
                a.dingdan = lblTxt2.txt.Text;
                a.yanse = lblTxt3.txt.Text;
                a.dayang = lblTxt5.txt.Text;
                a.peifang = ClsLogUser.XinMing;
                a.beizhu = lblTxt7.txt.Text;
                a.riqiSave = new DateTime();
                a.editrec = a.editrec + DateTime.Now.ToString("yy-MM-dd HH:mm") + ClsLogUser.XinMing + "修改。";
                db.Deleteable<T_PFdata>().Where(it => it.danhao == a.danhao).ExecuteCommand();
                for (int index = 0; index < dgvEX1.RowCount; ++index)
                {
                    T_PFdata b = new T_PFdata()
                    {
                        danhao = a.danhao,
                        gongxu = dgvEX1.Rows[index].Cells[0].FormattedValue.ToString(),
                        ranliao = dgvEX1.Rows[index].Cells[1].FormattedValue.ToString(),
                        ranliaoBZ = "",
                        bili = dgvEX1.Rows[index].Cells[2].FormattedValue.ToString() == "" ? new Decimal(0) : Convert.ToDecimal(dgvEX1.Rows[index].Cells[2].FormattedValue.ToString()),
                        biliDW = dgvEX1.Rows[index].Cells[3].FormattedValue.ToString(),
                        yaoqiu = dgvEX1.Rows[index].Cells[4].FormattedValue.ToString(),
                        yongliang = new Decimal(0),
                        yongliangDW = "",
                        JLbili = new Decimal(0),
                        JLyongliang = new Decimal(0),
                        JLyongliangDW = "",
                        SNld = -1L
                    };
                    var e = db.Insertable<T_PFdata>(b).ExecuteCommand();
                }
                return true;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show((IWin32Window)this, ex.Message + "\r\n\r\n   修改失败,请核查原因再试一次!", "提示");
                return false;
            }
        }
        private bool yanzheng()
        {
            this.bsGx.Filter = "";
            this.bsRl.Filter = "";
            if (this.lblTxt6.txt.Text == "")
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "请输入 " + this.lblTxt6.lblText + " !!!", "提示");
                this.lblTxt6.txt.Focus();
                return false;
            }
            for (int index = 0; index < dgvEX1.RowCount; ++index)
            {
                string str1 = dgvEX1.Rows[index].Cells[0].FormattedValue.ToString();
                if (str1 == "")
                {
                    dgvEX1.CurrentCell = dgvEX1.Rows[index].Cells[0];
                    int num = (int)MessageBox.Show((IWin32Window)this, "请输入 工序 !!!", "提示");
                    dgvEX1.Focus();
                    return false;
                }
                if (this.bsGx.Find("生产工序", (object)str1) < 0)
                {
                    dgvEX1.CurrentCell = dgvEX1.Rows[index].Cells[0];
                    int num = (int)MessageBox.Show((IWin32Window)this, "工序不在列表中,请正确输入!!!", "提示");
                    dgvEX1.Focus();
                    return false;
                }
                string str2 = dgvEX1.Rows[index].Cells[1].FormattedValue.ToString();
                if (str2 == "")
                {
                    dgvEX1.CurrentCell = dgvEX1.Rows[index].Cells[1];
                    int num = (int)MessageBox.Show((IWin32Window)this, "请输入 染料 !!!", "提示");
                    dgvEX1.Focus();
                    return false;
                }
                if (this.bsRl.Find("染料", (object)str2) < 0)
                {
                    dgvEX1.CurrentCell = dgvEX1.Rows[index].Cells[1];
                    int num = (int)MessageBox.Show((IWin32Window)this, "染料不在列表中,请正确输入!!!", "提示");
                    dgvEX1.Focus();
                    return false;
                }
                string str3 = dgvEX1.Rows[index].Cells[3].FormattedValue.ToString();
                if (dgvEX1.Rows[index].Cells[2].FormattedValue.ToString() != "" && str3 == "")
                {
                    dgvEX1.CurrentCell = dgvEX1.Rows[index].Cells[3];
                    int num = (int)MessageBox.Show((IWin32Window)this, "请输入 浓度单位 !!!", "提示");
                    dgvEX1.Focus();
                    return false;
                }
                if (str3 != "" && str3 != "owf" && (str3 != "g/L" && str3 != "mL/L") && str3 != "g" && str3 != "Kg")
                {
                    dgvEX1.CurrentCell = dgvEX1.Rows[index].Cells[3];
                    int num = (int)MessageBox.Show((IWin32Window)this, "请输入正确 浓度单位 !!!", "提示");
                    dgvEX1.Focus();
                    return false;
                }
            }
            return true;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show((IWin32Window)this, "确认 保存 吗 ?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No || !this.yanzheng())
                return;
            lblwait.showme();
            if (editBtnSave.Text == "保存")
            {
                if (Save())
                {
                    int num = (int)MessageBox.Show((IWin32Window)this, "保存成功!!!", "提示");
                    doublelist(this, -1L);
                    SetReadOnly(true);
                    Close();
                }
            }
            else if (this.editBtnSave.Text == "修改" && this.editLD())
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "修改成功!!!", "提示");
                doublelist(this, -1L);
                SetReadOnly(true);
                Close();
            }
            panel1.Visible = false;
            lblwait.hideme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel2.Visible)
            {
                dgvEX1.Rows.Add();
            }
        }
        private void Empty()
        {
            lblTxt1.txt.Text = "";
            lblTxt2.txt.Text = "";
            lblTxt3.txt.Text = "";
            lblTxt4.txt.Text = "";
            lblTxt5.txt.Text = "";
            lblTxt6.txt.Text = "";
            lblTxt7.txt.Text = "";
            editLblStaLD.Text = "";
            dgvEX1.Rows.Clear();
            Graphics dc = editImgLDH.CreateGraphics();
            dc.Clear(Color.White);
        }
        private string jisuandanhao()
        {
            string result = "";
            string a = DateTime.Now.ToString("yy").Substring(1) + DateTime.Now.ToString("MM");
            var b = db.Queryable<T_PFmain>()
                .Where(it => it.danhao.Substring(0, 3) == (a))
                .OrderBy(it => it.danhao, OrderByType.Desc)
                .First();
            string lsh;
            if (b == null)
            {
                lsh = a + "00001";
                return lsh;
            }
            string liushuihao = b.danhao;
            if (liushuihao.IndexOf(a) == -1)
            {
                liushuihao = "00001";
            }
            else
            {
                string liushuihao1 = liushuihao.Substring(5);
                int c = int.Parse(liushuihao1) + 1;
                liushuihao = c.ToString("00000");

            }
            result = a + liushuihao;
            return result;
        }
        private void SetReadOnly(bool flag)
        {
            lblTxt1.txt.ReadOnly = flag;
            lblTxt2.txt.ReadOnly = flag;
            lblTxt3.txt.ReadOnly = flag;
            lblTxt4.txt.ReadOnly = flag;
            lblTxt5.txt.ReadOnly = flag;
            lblTxt6.txt.ReadOnly = flag;
            lblTxt7.txt.ReadOnly = flag;
            dgvEX1.ReadOnly = flag;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var a = db.Queryable<T_PFmain>().Where(it => it.danhao == editImgLDH.Tag.ToString()).First();
            if (a == null || a.sta != editLblStaLD.Text)
            {
                int num2 = (int)MessageBox.Show((IWin32Window)this, "本料小样配方已不存在或状态发生改变!请核查!", "提示");
            }
            else
            {
                editBtnSave.Text = "修改";
                lblTxt1.txt.Focus();
                SetReadOnly(false);
                flowLayoutPanel1.Visible = false;
                flowLayoutPanel2.Visible = true;
            }
            panel1.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show((IWin32Window)this, "确定删除本小样配方吗?将不可恢复!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;
            var a = db.Queryable<T_PFmain>().Where(it => it.danhao == editImgLDH.Tag.ToString()).First();
            if (a == null || a.sta != editLblStaLD.Text)
            {
                int num2 = (int)MessageBox.Show((IWin32Window)this, "本小样配方已不存在或状态发生改变!请核查!", "提示");
            }
            else
            {
                lblwait.showme();
                a.fuhe = ClsLogUser.XinMing;
                a.riqiShen = new DateTime?(DateTime.Now);
                a.sta = leibie.staPF.已删除.ToString();
                db.Updateable<T_PFmain>(a).ExecuteCommand();
                int num2 = (int)MessageBox.Show((IWin32Window)this, "删除成功!!!", "提示");
                this.lblwait.hideme();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.lblwait.showme();
            var a = db.Queryable<T_PFmain>().Where(it => it.danhao == editImgLDH.Tag.ToString()).First();
            if (a == null || a.sta != this.editLblStaLD.Text)
            {
                this.lblwait.hideme();
                int num2 = (int)MessageBox.Show((IWin32Window)this, "本小样配方已不存在或料单状态发生改变!请核查!", "提示");
            }
            else
            {
                string str;
                if (a.sta == leibie.staPF.未审核.ToString())
                {
                    for (int index = 0; index < dgvEX1.RowCount; ++index)
                    {
                        if (dgvEX1.Rows[index].Cells[2].FormattedValue.ToString() == "" || dgvEX1.Rows[index].Cells[3].FormattedValue.ToString() == "")
                        {
                            this.lblwait.hideme();
                            dgvEX1.CurrentCell = dgvEX1.Rows[index].Cells[2];
                            int num2 = (int)MessageBox.Show((IWin32Window)this, "比例或比例单位不存在,无法审核 !!!", "提示");
                            dgvEX1.Focus();
                            return;
                        }
                    }
                    a.riqiShen = new DateTime?(DateTime.Now);
                    a.sta = leibie.staPF.已审核.ToString();
                    str = "审核";
                }
                else
                {
                    a.fuhe = "";
                    a.riqiShen = new DateTime?();
                    a.sta = leibie.staPF.未审核.ToString();
                    str = "消审";
                }
                try
                {
                    db.Updateable<T_PFmain>(a).ExecuteCommand();
                }
                catch (Exception ex)
                {
                    int num4 = (int)MessageBox.Show((IWin32Window)this, ex.Message, "提示");
                    return;
                }
                this.lblwait.hideme();
                int num3 = (int)MessageBox.Show((IWin32Window)this, str + " 成功!!!", "提示");
                doublelist(this, -1L);
                Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            editBtnSave.Text = "保存";
            for (int index = 0; index < this.dgvEX1.RowCount; ++index)
                this.dgvEX1.Rows[index].Cells[Column6.Name].Value = (object)-1;
            refList();
            setPict(jisuandanhao());
            lblTxt1.txt.Focus();
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = true;
            panel1.Visible = true;
        }
        //打印
        private void editBtnPrn_Click(object sender, EventArgs e)
        {
            if ((string)editImgLDH.Tag == "")
                return;
            this.lblwait.showme();
            FrmPrn frmPrn = new FrmPrn();
            frmPrn.rptView.LocalReport.ReportEmbeddedResource = "DotNetBarProject.view.rptXY.rdlc";
            frmPrn.rptView.LocalReport.DataSources.Clear();
            ReportDataSource reportDataSource1 = new ReportDataSource();
            reportDataSource1.Name = "ldmain";
            reportDataSource1.Value = (object)this.bsShowMain;
            ReportDataSource reportDataSource2 = new ReportDataSource();
            reportDataSource2.Name = "lddata";
            reportDataSource2.Value = (object)this.bsShowData;
            frmPrn.rptView.LocalReport.DataSources.Add(reportDataSource1);
            frmPrn.rptView.LocalReport.DataSources.Add(reportDataSource2);
            string filename = Application.StartupPath + "\\imgLDH.Bmp";
            this.editImgLDH.Image.Save(filename, ImageFormat.Bmp);
            string str = "file:///" + filename.Replace("\\", "/");
            frmPrn.rptView.LocalReport.EnableExternalImages = true;
            ReportParameter reportParameter1 = new ReportParameter("LDH", str);
            ReportParameter reportParameter2 = new ReportParameter("GSname", UserProc.GSname);
            frmPrn.rptView.LocalReport.SetParameters((IEnumerable<ReportParameter>)new ReportParameter[2]
            {
                reportParameter1,
                reportParameter2
            });
            frmPrn.rptView.RefreshReport();
            int num = (int)frmPrn.ShowDialog();
            frmPrn.Close();
            this.lblwait.hideme();
        }

        private void setPict(string code)
        {
            editImgLDH.Image = UserProc.GetBarcode(this.editImgLDH.Height, this.editImgLDH.Width, TYPE.CODE128, code);
            editImgLDH.Tag = (object)code;
        }
        public void SetData(object sn)
        {
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = false;
            Empty();
            SetReadOnly(true);
            SN_SN = Convert.ToInt64(sn);
            if (SN_SN == -1L) return;
            else
            {
                var a = db.Queryable<T_PFmain>().Where(it => it.SN == SN_SN).First();
                if (a == null) return;
                else
                {
                    var b = db.Queryable<T_PFdata>().Where(it => it.danhao == a.danhao).ToList();
                    if (b == null) return;
                    setInput(a, b);
                }
            }
        }
        private void setInput(T_PFmain a, List<T_PFdata> b)
        {
            lblTxt1.txt.Text = a.kehu;
            lblTxt2.txt.Text = a.dingdan;
            lblTxt3.txt.Text = a.yanse;
            lblTxt4.txt.Text = a.shazhong;
            lblTxt5.txt.Text = a.dayang;
            lblTxt6.txt.Text = a.sehao;
            lblTxt7.txt.Text = a.beizhu;
            for (var i = 0; i < b.Count; i++)
            {
                var t_PFdata = b[i];
                int index = dgvEX1.Rows.Add();
                dgvEX1.Rows[index].Cells[0].Value = t_PFdata.gongxu;
                dgvEX1.Rows[index].Cells[1].Value = t_PFdata.ranliao;
                dgvEX1.Rows[index].Cells[2].Value = t_PFdata.bili;
                dgvEX1.Rows[index].Cells[3].Value = t_PFdata.biliDW;
                dgvEX1.Rows[index].Cells[4].Value = t_PFdata.yaoqiu;
                dgvEX1.Rows[index].Cells[5].Value = t_PFdata.SN;
            }
            string code = a.danhao;
            setPict(code);
            editLblStaLD.Text = a.sta;
            if (this.editLblStaLD.Text == leibie.staPF.未审核.ToString())
            {
                editBtnSH.Text = "审核";
                this.editBtnSH.Enabled = true;
                this.editBtnEdit.Enabled = true;
                this.editBtnDel.Enabled = true;
                this.editBtnPrn.Enabled = false;
            }
            else
            {
                this.editBtnSH.Text = "消审";
                this.editBtnSH.Enabled = true;
                this.editBtnPrn.Enabled = true;
                this.editBtnDel.Enabled = false;
                this.editBtnEdit.Enabled = false;
            }
            this.bsShowMain.DataSource = (object)a;
            this.bsShowData.DataSource = (object)b;
        }
        private void editDgvList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvEX2.DataSource == bsKH)
            {
                if (lblTxt1.txt.ReadOnly)
                    return;
                lblTxt1.txt.Text = dgvEX2.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                lblTxt1.txt.Focus();
            }
            else if (dgvEX2.DataSource == bsYanse)
            {
                if (lblTxt3.txt.ReadOnly)
                    return;
                lblTxt3.txt.Text = dgvEX2.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                lblTxt3.txt.Focus();
            }
            else if (dgvEX2.DataSource == bsSeH)
            {
                if (lblTxt6.txt.ReadOnly)
                    return;
                lblTxt6.txt.Text = dgvEX2.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                lblTxt6.txt.Focus();
            }
            else if (dgvEX2.DataSource == bsDY)
            {
                if (lblTxt5.txt.ReadOnly)
                    return;
                lblTxt5.txt.Text = dgvEX2.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                lblTxt5.txt.Focus();
            }
            else if (dgvEX2.DataSource == bsPM)
            {
                if (lblTxt4.txt.ReadOnly)
                    return;
                lblTxt4.txt.Text = dgvEX2.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                lblTxt4.txt.Focus();
            }
            else if (dgvEX2.DataSource == bsGx)
            {
                dgvEX1.CurrentCell.Value = (object)dgvEX2.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                dgvEX1.Focus();
            }
            else if (dgvEX2.DataSource == bsRl)
            {
                dgvEX1.CurrentCell.Value = (object)dgvEX2.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                dgvEX1.Focus();
            }
            else if (dgvEX2.DataSource == bsNd)
            {
                dgvEX1.CurrentCell.Value = (object)dgvEX2.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                dgvEX1.Focus();
            }
        }
        private void refOne()
        {
            DataTable dataTable = new DataTable("tblBLDW");
            dataTable.Columns.Add(new DataColumn("编号", typeof(string)));
            dataTable.Columns.Add(new DataColumn("浓度单位", typeof(string)));
            dataTable.Rows.Add((object)"1", (object)"owf");
            dataTable.Rows.Add((object)"2", (object)"g/L");
            dataTable.Rows.Add((object)"3", (object)"mL/L");
            dataTable.Rows.Add((object)"4", (object)"g");
            dataTable.Rows.Add((object)"5", (object)"Kg");
            bsNd.DataSource = (object)dataTable;
            dataTable.Dispose();
        }
        private void refList()
        {
            refOne();
            var asd = db.Ado.GetDataTable("select 编号=bianhao,客户=itemname,全称=item0 from T_Base where leibie = '" + leibie.enumLB.客户.ToString() + "' order by 编号");
            bsKH.DataSource = asd;
            var asd1 = db.Ado.GetDataTable("select 编号=bianhao,颜色=itemName from T_Base where leibie = '" + leibie.enumLB.颜色.ToString() + "' order by 编号");
            bsYanse.DataSource = asd1;
            var asd2 = db.Ado.GetDataTable("select 编号=bianhao,色号类别=itemName from T_Base where leibie = '" + leibie.enumLB.色号类别.ToString() + "' order by 编号");
            bsSeH.DataSource = asd2;
            var asd3 = db.Ado.GetDataTable("select 编号=bianhao,员工=itemName from T_Base where leibie = '" + leibie.enumLB.员工.ToString() + "' order by 编号");
            bsDY.DataSource = asd3;
            var asd4 = db.Ado.GetDataTable("select 编号=bianhao,生产工序=itemName from T_Base where leibie = '" + leibie.enumLB.生产工序.ToString() + "' order by 编号");
            bsGx.DataSource = asd4;
            var asd5 = db.Ado.GetDataTable("select 编号=bianhao,染料=itemName,全称=item0,类别=leibie from T_Base where leibie = '" + leibie.enumLB.染料.ToString() + "' or leibie = '" + leibie.enumLB.助剂.ToString() + "' order by 类别,编号");
            bsRl.DataSource = asd5;
            var asd6 = db.Ado.GetDataTable("select 编号=bianhao,品名=itemName from T_Base where leibie = '" + leibie.enumLB.纱种.ToString() + "' order by 编号");
            bsPM.DataSource = asd6;
        }
        private void editDgvMain_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvEX1.ReadOnly || dgvEX1.CurrentCell == null || !dgvEX1.CurrentCell.IsInEditMode)
                return;
            string str = dgvEX1.CurrentCell.EditedFormattedValue.ToString();
            if (str == "")
                return;
            switch (dgvEX1.Columns[e.ColumnIndex].Name)
            {
                case "Column3":
                    if (UserProc.IsNumeric(str) && !(Convert.ToDecimal(str) < new Decimal(0)))
                        break;
                    int num1 = (int)MessageBox.Show((IWin32Window)this, "请输入正确 <比例>( >= 0数值 )!!!", "提示");
                    e.Cancel = true;
                    break;
                case "Column4":
                    if (!(str != "owf") || !(str != "g/L") || !(str != "mL/L"))
                        break;
                    int num2 = (int)MessageBox.Show((IWin32Window)this, "请输入正确 <浓度单位>!!!", "提示");
                    e.Cancel = true;
                    break;
            }
        }
    }
}

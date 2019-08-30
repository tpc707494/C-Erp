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
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace DotNetBarProject.view.RecipeManager.XiaoYangPeiF
{
    public partial class FrmXY : Office2007Form
    {
        private LblWait lblwait;
        SqlSugarClient db;
        private string strQX = "";
        private string strSch = "";
        private string showLDH = "";
        private exeMode _ExeMode = exeMode.显示料单;


        private BindingSource bsKH;
        private BindingSource bsSZ;
        private BindingSource bsDY;
        private BindingSource bsRL;
        private BindingSource bsSH;
        private BindingSource bsGX;
        private BindingSource bsBLDW;
        private BindingSource bsShowMain;
        private BindingSource bsShowData;
        private BindingSource bsYS;
        private BindingSource bsSch;
        private exeMode ExeMode
        {
            get
            {
                return this._ExeMode;
            }
            set
            {
                this._ExeMode = value;
                switch (this._ExeMode)
                {
                    case exeMode.显示料单:
                        this.editBtnNew.Visible = true;
                        this.editBtnNewNow.Visible = true;
                        this.editBtnSH.Visible = true;
                        this.editBtnPrn.Visible = true;
                        this.editBtnEdit.Visible = true;
                        this.editBtnDel.Visible = true;
                        this.editBtnSave.Visible = false;
                        this.editBtnCancel.Visible = false;
                        this.editBtnAddRow.Visible = false;
                        this.editBtnDelRow.Visible = false;
                        this.editBtnRowUP.Visible = false;
                        this.editBtnRowDN.Visible = false;
                        this.editLblStaLD.Visible = true;
                        this.editLblStaExe.Visible = false;
                        this.editTxtKH.ReadOnly = true;
                        this.editTxtSZ.ReadOnly = true;
                        this.editTxtSH.ReadOnly = true;
                        this.editTxtDDH.ReadOnly = true;
                        this.editTxtYS.ReadOnly = true;
                        this.editTxtDY.ReadOnly = true;
                        this.editTxtBZ.ReadOnly = true;
                        this.editDgvMain.ReadOnly = true;
                        break;
                    case exeMode.料单编辑:
                        this.editBtnNew.Visible = false;
                        this.editBtnNewNow.Visible = false;
                        this.editBtnSH.Visible = false;
                        this.editBtnPrn.Visible = false;
                        this.editBtnEdit.Visible = false;
                        this.editBtnDel.Visible = false;
                        this.editBtnSave.Visible = true;
                        this.editBtnCancel.Visible = true;
                        this.editBtnAddRow.Visible = true;
                        this.editBtnDelRow.Visible = true;
                        this.editBtnRowUP.Visible = true;
                        this.editBtnRowDN.Visible = true;
                        this.editLblStaLD.Visible = false;
                        this.editLblStaExe.Visible = true;
                        this.editLblStaExe.Text = "小样单编辑";
                        this.editTxtKH.ReadOnly = false;
                        this.editTxtSZ.ReadOnly = false;
                        this.editTxtSH.ReadOnly = false;
                        this.editTxtDDH.ReadOnly = false;
                        this.editTxtYS.ReadOnly = false;
                        this.editTxtDY.ReadOnly = false;
                        this.editTxtBZ.ReadOnly = false;
                        this.editDgvMain.ReadOnly = false;
                        break;
                }
            }
        }
        public FrmXY()
        {
            InitializeComponent();
            db = SqlBase.GetInstance();
            lblwait = new LblWait((Form)this);


            this.bsKH = new BindingSource();
            this.bsSZ = new BindingSource();
            this.bsDY = new BindingSource();
            this.bsSH = new BindingSource();
            this.bsRL = new BindingSource();
            this.bsGX = new BindingSource();
            this.bsBLDW = new BindingSource();
            this.bsSch = new BindingSource();
            this.bsShowMain = new BindingSource();
            this.bsShowData = new BindingSource();
            this.bsYS = new BindingSource();
            mainColBH.Tag = "总行:";
        }
        private void menuList刷新_Click(object sender, EventArgs e)
        {
            this.refSch();
            this.refList();
            this.bsKH.Filter = "";
            this.bsSZ.Filter = "";
            this.bsDY.Filter = "";
            this.bsGX.Filter = "";
            this.bsRL.Filter = "";
        }
        private void refSch()
        {
            this.schKH.cobodgv.RefList(coboDGV.leibie.客户);
            this.schSZ.cobodgv.RefList(coboDGV.leibie.纱种);
        }
        private void refList()
        {
            //using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DBconn))
            {
                string a = "select 编号=bianhao,客户=itemname,全称=item0 from T_Base where leibie = '" + leibie.enumLB.客户.ToString() + "' order by 编号";
                this.bsKH.DataSource = db.Ado.GetDataTable(a);

                string b = "select 编号=bianhao,品名=itemname from T_Base where leibie = '" + leibie.enumLB.纱种.ToString() + "' order by 编号";
                this.bsSZ.DataSource = db.Ado.GetDataTable(b);

                string c = "select 编号=bianhao,颜色=itemname from T_Base where leibie = '" + leibie.enumLB.颜色.ToString() + "' order by 编号";
                this.bsYS.DataSource = db.Ado.GetDataTable(c);

                string s = "select 编号=SN,色号=item3,客户=item2,色名=seming,品名=item1  from BaseIList where leibie = '" + leibie.enumLB.色号.ToString() + "' order by 编号";
                DataTable dataTable = db.Ado.GetDataTable(s);
                DataTable dataTable1 = new DataTable();

                dataTable1.Columns.Add("编号");
                dataTable1.Columns.Add("色号");
                dataTable1.Columns.Add("客户");
                dataTable1.Columns.Add("色名");
                dataTable1.Columns.Add("品名");
                for (var i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow newRow = dataTable1.NewRow();
                    string s_a = dataTable.Rows[i]["编号"] + "";
                    newRow["编号"] = s_a;
                    string s_b = dataTable.Rows[i]["色号"] + "";
                    newRow["色号"] = s_b;
                    string s_b1 = dataTable.Rows[i]["客户"] + "";
                    newRow["客户"] = s_b1;
                    string s_b2 = dataTable.Rows[i]["色名"] + "";
                    newRow["色名"] = s_b2;
                    string s_b3 = dataTable.Rows[i]["品名"] + "";
                    newRow["品名"] = s_b3;
                    dataTable1.Rows.Add(newRow);
                }
                this.bsSH.DataSource = dataTable1;

                string d = "select 编号=bianhao,员工=itemname from T_Base where leibie = '" + leibie.enumLB.员工.ToString() + "' order by 编号";
                this.bsDY.DataSource = db.Ado.GetDataTable(d);

                string f = "select 编号=bianhao,染化类别=itemname from T_Base where leibie = '" + leibie.enumLB.染化类别.ToString() + "' order by 编号";
                this.bsGX.DataSource = db.Ado.GetDataTable(f);

                string g = "select 编号=bianhao,染料简称=item3,全称=item0,类别=itemName from T_Base where leibie = '" + leibie.enumLB.染料名称.ToString() + "' or leibie = '" + leibie.enumLB.助剂名称.ToString() + "' order by 类别,编号";
                this.bsRL.DataSource = db.Ado.GetDataTable(g);
            }
        }
        private void mainDgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || this.mainDgv.CurrentRow.Index != e.RowIndex || this.ExeMode == exeMode.料单编辑 && MessageBox.Show((IWin32Window)this, "配方编辑 正处于操作状态,显示配方信息将清除你编辑的数据,确认吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;
            this.lblwait.showme();
            this.showLDH = this.mainDgv.CurrentRow.Cells[this.mainColBH.Name].Value.ToString();
            this.ExeMode = exeMode.显示料单;
            if (this.showLD())
                this.tabPages.SelectedTab = this.tpEdit;
            this.lblwait.hideme();
        }
        private void emptyLDmain()
        {
            this.editImgLDH.Image = (Image)null;
            this.editImgLDH.Tag = (object)null;
            this.editTxtKH.txt.Text = "";
            this.editTxtSZ.txt.Text = "";
            this.editTxtSH.txt.Text = "";
            this.editTxtDDH.txt.Text = "";
            this.editTxtYS.txt.Text = "";
            this.editTxtDY.txt.Text = "";
            this.editTxtBZ.txt.Text = "";
            this.editLblStaLD.Text = "";
        }
        private void emptyLDdata()
        {
            this.editDgvMain.Rows.Clear();
        }
        private bool showLD()
        {
            this.emptyLDmain();
            this.emptyLDdata();
            this.editBtnSH.Enabled = false;
            this.editBtnPrn.Enabled = false;
            this.editBtnEdit.Enabled = false;
            this.editBtnDel.Enabled = false;
            if (this.showLDH == "")
                return false;
            //DBpf dbpf = new DBpf(Settings.Default.DBconn);
            //T_PFmain tPfmain = dbpf.T_PFmain.Where<T_PFmain>((Expression<Func<T_PFmain, bool>>)(a => a.danhao == this.showLDH)).SingleOrDefault<T_PFmain>();
            T_PFmain tPfmain = db.Queryable<T_PFmain>().Where(a => a.danhao == this.showLDH).First();
            if (tPfmain == null)
            {
                //dbpf.Dispose();
                int num = (int)MessageBox.Show((IWin32Window)this, "无法找到此小样配方主数据!!!", "提示");
                return false;
            }
            List<T_PFdata> list = db.Queryable<T_PFdata>().Where(a => a.danhao == this.showLDH).OrderBy(a => a.SN).ToList();
            this.editImgLDH.Image = UserProc.GetBarcode(this.editImgLDH.Height, this.editImgLDH.Width, TYPE.CODE128, tPfmain.danhao);
            this.editImgLDH.Tag = (object)tPfmain.danhao;
            this.editTxtKH.txt.Text = tPfmain.kehu;
            this.editTxtSZ.txt.Text = tPfmain.shazhong;
            this.editTxtSH.txt.Text = tPfmain.sehao;
            this.editTxtDDH.txt.Text = tPfmain.dingdan;
            this.editTxtYS.txt.Text = tPfmain.yanse;
            this.editTxtDY.txt.Text = tPfmain.dayang;
            this.editTxtBZ.txt.Text = tPfmain.beizhu;
            this.editLblStaLD.Text = tPfmain.sta;
            for (int index = 0; index < list.Count<T_PFdata>(); ++index)
            {
                this.editDgvMain.Rows.Add();
                DataGridViewRow row = this.editDgvMain.Rows[this.editDgvMain.RowCount - 1];
                row.Cells[this.editColSN.Name].Value = (object)list[index].SN;
                row.Cells[this.editColGX.Name].Value = (object)list[index].gongxu;
                row.Cells[this.editColRL.Name].Value = (object)list[index].ranliao;
                row.Cells[this.editColBL.Name].Value = (object)list[index].bili;
                row.Cells[this.editColBLDW.Name].Value = (object)list[index].biliDW;
                row.Cells[this.editColGY.Name].Value = (object)list[index].yaoqiu;
            }
            //dbpf.Dispose();
            if (this.editLblStaLD.Text == leibie.staPF.未审核.ToString())
            {
                this.editBtnSH.Text = "审核";
                this.editBtnSH.Enabled = true;
                this.editBtnEdit.Enabled = true;
                this.editBtnDel.Enabled = true;
            }
            else if (this.editLblStaLD.Text == leibie.staPF.已审核.ToString())
            {
                this.editBtnSH.Text = "消审";
                this.editBtnSH.Enabled = true;
                this.editBtnPrn.Enabled = true;
            }
            this.bsShowMain.DataSource = (object)tPfmain;
            this.bsShowData.DataSource = (object)list;
            return true;
        }
        private void mainDgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            string str = this.mainDgv.Rows[e.RowIndex].Cells[this.mainColSta.Name].Value.ToString();
            if (str == leibie.staPF.未审核.ToString())
            {
                this.mainDgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = UserProc.colorWSH;
            }
            else
            {
                if (!(str == leibie.staPF.已删除.ToString()))
                    return;
                this.mainDgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = UserProc.colorDel;
                this.mainDgv.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("宋体", 9f, FontStyle.Strikeout);
            }
        }
        private void schData()
        {
            UserProc.CheckTime = "";
            this.strSch = "";
            string str1 = this.schMohu.Checked ? "%" : "";
            if (this.schKH.chkSel)
                this.strSch = this.strSch + "and kehu like '" + str1 + this.schKH.cobodgv.Text + str1 + "' ";
            if (this.schSZ.chkSel)
                this.strSch = this.strSch + "and shazhong like '" + str1 + this.schSZ.cobodgv.Text + str1 + "' ";
            if (this.schSH.chkSel)
                this.strSch = this.strSch + "and sehao like '" + str1 + this.schSH.txt.Text + str1 + "' ";
            if (this.schYS.chkSel)
                this.strSch = this.strSch + "and yanse like '" + str1 + this.schYS.txt.Text + str1 + "' ";
            if (this.schLD.chkSel)
                this.strSch = this.strSch + "and danhao like '" + str1 + this.schLD.txt.Text + str1 + "' ";
            if (this.schDY.chkSel)
                this.strSch = this.strSch + "and dayang like '" + str1 + this.schDY.txt.Text + str1 + "' ";
            if (this.schDDH.chkSel)
                this.strSch = this.strSch + "and dingdan like '" + str1 + this.schDDH.txt.Text + str1 + "' ";
            DateTime dateTime;
            string str5 = "", str6 = "";
            if (this.schRQsave.chkFsel)
            {
                string strSch = this.strSch;
                dateTime = this.schRQsave.dtimeF.Value;
                str5 = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                this.strSch = strSch + "and riqiSave >= '" + str5 + "' ";
            }
            if (this.schRQsave.chkTsel)
            {
                string strSch = this.strSch;
                dateTime = this.schRQsave.dtimeT.Value;
                str6 = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                this.strSch = strSch + "and riqiSave < '" + str6 + "' ";

                UserProc.CheckTime = str5 + " - " + str6;
            }
            if (!this.schDel.Checked)
                this.strSch += "and sta <> '已删除' ";
            this.strSch = "select * from T_PFmain where leibie = '" + leibie.enumPFLB.小样单.ToString() + "' " + this.strSch + " order by riqiSave desc";
        }
        private void btnSch_Click(object sender, EventArgs e)
        {
            this.schData();
            this.lblwait.showme();
            this.refData();
            this.lblwait.hideme();
        }
        private void refData()
        {
            //using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DBconn))
            {
                var asa = this.strSch;
                DataTable dataTable = db.Ado.GetDataTable(strSch);
                this.bsSch.DataSource = dataTable;

                //this.mainDgv.DataSource = (object)this.bsSch;
                asd(dataTable);
                dataTable.Dispose();
            }
        }
        private void asd(DataTable dataTable)
        {
            mainDgv.Rows.Clear();
            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                int index = mainDgv.Rows.Add();
                mainDgv.Rows[index].Cells[mainColBH.Name].Value = dataTable.Rows[index]["danhao"];
                mainDgv.Rows[index].Cells[mainColKH.Name].Value = dataTable.Rows[index]["kehu"];
                mainDgv.Rows[index].Cells[mainColSZ.Name].Value = dataTable.Rows[index]["shazhong"];
                mainDgv.Rows[index].Cells[mainColSH.Name].Value = dataTable.Rows[index]["sehao"];
                mainDgv.Rows[index].Cells[mainColYS.Name].Value = dataTable.Rows[index]["yanse"];
                mainDgv.Rows[index].Cells[mainColDDH.Name].Value = dataTable.Rows[index]["dingdan"];
                mainDgv.Rows[index].Cells[mainColRQBC.Name].Value = dataTable.Rows[index]["riqiSave"];
                mainDgv.Rows[index].Cells[mainColPF.Name].Value = dataTable.Rows[index]["peifang"];
                mainDgv.Rows[index].Cells[mainColRQSH.Name].Value = dataTable.Rows[index]["riqiShen"];
                mainDgv.Rows[index].Cells[mainColFH.Name].Value = dataTable.Rows[index]["fuhe"];
                mainDgv.Rows[index].Cells[mainColDY.Name].Value = dataTable.Rows[index]["dayang"];
                mainDgv.Rows[index].Cells[mainColBZ.Name].Value = dataTable.Rows[index]["beizhu"];
                mainDgv.Rows[index].Cells[mainColSN.Name].Value = dataTable.Rows[index]["SN"];
                mainDgv.Rows[index].Cells[mainColSta.Name].Value = dataTable.Rows[index]["sta"];
            }
            mainDgv.HeJi();
        }
        private void editBtnRowDN_Click(object sender, EventArgs e)
        {
            if (this.editDgvMain.CurrentRow == null)
                return;
            DataGridViewRow currentRow = this.editDgvMain.CurrentRow;
            if (currentRow.Index == this.editDgvMain.RowCount - 1)
                return;
            this.editDgvMain.Rows.Insert(currentRow.Index + 2, 1);
            DataGridViewRow row = this.editDgvMain.Rows[currentRow.Index + 2];
            for (int index = 0; index < this.editDgvMain.ColumnCount; ++index)
                row.Cells[index].Value = currentRow.Cells[index].Value;
            this.editDgvMain.CurrentCell = row.Cells[this.editDgvMain.CurrentCell.ColumnIndex];
            this.editDgvMain.Rows.Remove(currentRow);
        }
        private void editBtnRowUP_Click(object sender, EventArgs e)
        {
            if (this.editDgvMain.CurrentRow == null)
                return;
            DataGridViewRow currentRow = this.editDgvMain.CurrentRow;
            if (currentRow.Index == 0)
                return;
            this.editDgvMain.Rows.Insert(currentRow.Index - 1, 1);
            DataGridViewRow row = this.editDgvMain.Rows[currentRow.Index - 2];
            for (int index = 0; index < this.editDgvMain.ColumnCount; ++index)
                row.Cells[index].Value = currentRow.Cells[index].Value;
            this.editDgvMain.CurrentCell = row.Cells[this.editDgvMain.CurrentCell.ColumnIndex];
            this.editDgvMain.Rows.Remove(currentRow);
        }
        private void editBtnDelRow_Click(object sender, EventArgs e)
        {
            if (this.editDgvMain.CurrentRow == null || MessageBox.Show((IWin32Window)this, "删除本行数据吗?不可逆转!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;
            this.editDgvMain.Rows.Remove(this.editDgvMain.CurrentRow);
        }
        private void editBtnAddRow_Click(object sender, EventArgs e)
        {
            if (this.editDgvMain.RowCount == 0 || this.editDgvMain.CurrentCell == null || this.editDgvMain.CurrentCell.RowIndex == this.editDgvMain.RowCount - 1)
            {
                this.editDgvMain.Rows.Add();
                this.editDgvMain.CurrentCell = this.editDgvMain.Rows[this.editDgvMain.RowCount - 1].Cells[this.editDgvMain.FirstDisplayedCell.ColumnIndex];
            }
            else
            {
                this.editDgvMain.Rows.Insert(this.editDgvMain.CurrentCell.RowIndex + 1, 1);
                this.editDgvMain.CurrentCell = this.editDgvMain.Rows[this.editDgvMain.CurrentCell.RowIndex + 1].Cells[this.editDgvMain.FirstDisplayedCell.ColumnIndex];
            }
            this.editDgvMain.CurrentRow.Cells[this.editColSN.Name].Value = (object)-1;
            this.editDgvMain.Focus();
        }
        private void editBtnEdit_Click(object sender, EventArgs e)
        {
            //if (!this.strQX.Contains("管理"))
            //{
            //    int num1 = (int)MessageBox.Show((IWin32Window)this, "权限不足!!!", "提示");
            //}
            //else
            {
                //DBpf dbpf = new DBpf(Settings.Default.DBconn);
                //T_PFmain tPfmain = dbpf.T_PFmain.Where<T_PFmain>((Expression<Func<T_PFmain, bool>>)(a => a.danhao == this.editImgLDH.Tag.ToString())).SingleOrDefault<T_PFmain>();
                T_PFmain tPfmain = db.Queryable<T_PFmain>().Where(a => a.danhao == this.editImgLDH.Tag.ToString()).First();
                if (tPfmain == null || tPfmain.sta != this.editLblStaLD.Text)
                {
                    //dbpf.Dispose();
                    int num2 = (int)MessageBox.Show((IWin32Window)this, "本料小样配方已不存在或状态发生改变!请核查!", "提示");
                }
                else
                {
                    //dbpf.Dispose();
                    this.ExeMode = exeMode.料单编辑;
                    for (int index = 0; index < this.editDgvMain.RowCount; ++index)
                        this.editDgvMain.Rows[index].Cells[this.editColSN.Name].Value = (object)-1;
                    this.editBtnSave.Text = "修改";
                    this.refList();
                    this.editTxtKH.txt.Focus();
                }
            }
        }
        private void editBtnDel_Click(object sender, EventArgs e)
        {
            //if (!this.strQX.Contains("管理"))
            {
                //    int num1 = (int)MessageBox.Show((IWin32Window)this, "权限不足!!!", "提示");
            }
            //else
            {
                if (MessageBox.Show((IWin32Window)this, "确定删除本小样配方吗?将不可恢复!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                //DBpf dbpf = new DBpf(Settings.Default.DBconn);
                //T_PFmain tPfmain = dbpf.T_PFmain.Where<T_PFmain>((Expression<Func<T_PFmain, bool>>)(a => a.danhao == this.editImgLDH.Tag.ToString())).SingleOrDefault<T_PFmain>();
                T_PFmain tPfmain = db.Queryable<T_PFmain>().Where(a => a.danhao == this.editImgLDH.Tag.ToString()).First();
                if (tPfmain == null || tPfmain.sta != this.editLblStaLD.Text)
                {
                    //dbpf.Dispose();
                    int num2 = (int)MessageBox.Show((IWin32Window)this, "本小样配方已不存在或状态发生改变!请核查!", "提示");
                }
                else
                {
                    this.lblwait.showme();
                    tPfmain.fuhe = ClsLogUser.XinMing;
                    tPfmain.riqiShen = new DateTime?(DateTime.Now);
                    tPfmain.sta = leibie.staPF.已删除.ToString();
                    db.Updateable<T_PFmain>(tPfmain).ExecuteCommand();
                    //dbpf.SubmitChanges();
                    //dbpf.Dispose();
                    this.showLD();
                    this.lblwait.hideme();
                    int num2 = (int)MessageBox.Show((IWin32Window)this, "删除成功!!!", "提示");
                }
            }
        }
        private void editBtnPrn_Click(object sender, EventArgs e)
        {
            if (this.showLDH == "")
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
        private void editBtnNew_Click(object sender, EventArgs e)
        {
            //if (!this.strQX.Contains("管理"))
            {
                //    int num1 = (int)MessageBox.Show((IWin32Window)this, "权限不足!!!", "提示");
            }
            //else
            {
                this.ExeMode = exeMode.料单编辑;
                this.editBtnSave.Text = "保存";
                this.emptyLDmain();
                this.emptyLDdata();
                this.refList();
                if (!this.getLDH())
                {
                    int num2 = (int)MessageBox.Show((IWin32Window)this, "单号生成失败,请检查!!!", "提示");
                }
                this.editTxtKH.txt.Focus();
            }
        }
        private bool getLDH()
        {
            try
            {
                //DBpf dbpf = new DBpf(Settings.Default.DBconn);
                string tmpStr = "9" + DateTime.Today.ToString("yyMM");
                //IOrderedQueryable<T_PFmain> source = dbpf.T_PFmain.Where<T_PFmain>((Expression<Func<T_PFmain, bool>>)(a => a.danhao.StartsWith(tmpStr))).OrderBy<T_PFmain, string>((Expression<Func<T_PFmain, string>>)(a => a.danhao));
                List<T_PFmain> source = db.Queryable<T_PFmain>().Where(a => a.danhao.StartsWith(tmpStr)).OrderBy(a => a.danhao).ToList();
                string code;
                if (source.Count<T_PFmain>() == 0)
                {
                    code = tmpStr + "00001";
                }
                else
                {
                    int int32 = Convert.ToInt32(source.AsEnumerable<T_PFmain>().Last<T_PFmain>().danhao.Substring(5));
                    if (int32 >= 99999)
                    {
                        //dbpf.Dispose();
                        return false;
                    }
                    code = tmpStr + (int32 + 1).ToString("00000");
                }
                //dbpf.Dispose();
                this.editImgLDH.Image = UserProc.GetBarcode(this.editImgLDH.Height, this.editImgLDH.Width, TYPE.CODE128, code);
                this.editImgLDH.Tag = (object)code;
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void editBtnSH_Click(object sender, EventArgs e)
        {
            //if (!this.strQX.Contains("审核"))
            {
                //    int num1 = (int)MessageBox.Show((IWin32Window)this, "权限不足!!!", "提示");
            }
            //else
            {
                this.lblwait.showme();
                //DBpf dbpf = new DBpf(Settings.Default.DBconn);
                //T_PFmain tPfmain = dbpf.T_PFmain.Where<T_PFmain>((Expression<Func<T_PFmain, bool>>)(a => a.danhao == this.editImgLDH.Tag.ToString())).SingleOrDefault<T_PFmain>();
                T_PFmain tPfmain = db.Queryable<T_PFmain>()
                    .Where(a => a.danhao == this.editImgLDH.Tag.ToString())
                    .First();
                if (tPfmain == null || tPfmain.sta != this.editLblStaLD.Text)
                {
                    //dbpf.Dispose();
                    this.lblwait.hideme();
                    int num2 = (int)MessageBox.Show((IWin32Window)this, "本小样配方已不存在或料单状态发生改变!请核查!", "提示");
                }
                else
                {
                    string str;
                    if (tPfmain.sta == leibie.staPF.未审核.ToString())
                    {
                        for (int index = 0; index < this.editDgvMain.RowCount; ++index)
                        {
                            if (this.editDgvMain.Rows[index].Cells[this.editColBL.Name].FormattedValue.ToString() == "" || this.editDgvMain.Rows[index].Cells[this.editColBLDW.Name].FormattedValue.ToString() == "")
                            {
                                //dbpf.Dispose();
                                this.lblwait.hideme();
                                this.editDgvMain.CurrentCell = this.editDgvMain.Rows[index].Cells[this.editColBL.Name];
                                int num2 = (int)MessageBox.Show((IWin32Window)this, "比例或比例单位不存在,无法审核 !!!", "提示");
                                this.editDgvMain.Focus();
                                return;
                            }
                        }
                        tPfmain.fuhe = ClsLogUser.XinMing;
                        tPfmain.riqiShen = new DateTime?(DateTime.Now);
                        tPfmain.sta = leibie.staPF.已审核.ToString();
                        str = "审核";
                    }
                    else
                    {
                        tPfmain.fuhe = "";
                        tPfmain.riqiShen = new DateTime?();
                        tPfmain.sta = leibie.staPF.未审核.ToString();
                        str = "消审";
                    }
                    db.Updateable<T_PFmain>(tPfmain).ExecuteCommand();
                    //dbpf.SubmitChanges();
                    //dbpf.Dispose();
                    this.showLD();
                    this.lblwait.hideme();
                    int num3 = (int)MessageBox.Show((IWin32Window)this, str + " 成功!!!", "提示");
                }
            }
        }
        private bool yanzheng()
        {
            this.bsGX.Filter = "";
            this.bsRL.Filter = "";
            if (this.editTxtSH.txt.Text == "")
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "请输入 " + this.editTxtSH.lblText + " !!!", "提示");
                this.editTxtSH.txt.Focus();
                return false;
            }
            for (int index = 0; index < this.editDgvMain.RowCount; ++index)
            {
                string str1 = this.editDgvMain.Rows[index].Cells[this.editColGX.Name].FormattedValue.ToString();
                if (str1 == "")
                {
                    this.editDgvMain.CurrentCell = this.editDgvMain.Rows[index].Cells[this.editColGX.Name];
                    int num = (int)MessageBox.Show((IWin32Window)this, "请输入 工序 !!!", "提示");
                    this.editDgvMain.Focus();
                    return false;
                }
                if (this.bsGX.Find("染化类别", (object)str1) < 0)
                {
                    this.editDgvMain.CurrentCell = this.editDgvMain.Rows[index].Cells[this.editColGX.Name];
                    int num = (int)MessageBox.Show((IWin32Window)this, "工序不在列表中,请正确输入!!!", "提示");
                    this.editDgvMain.Focus();
                    return false;
                }
                string str2 = this.editDgvMain.Rows[index].Cells[this.editColRL.Name].FormattedValue.ToString();
                if (str2 == "")
                {
                    this.editDgvMain.CurrentCell = this.editDgvMain.Rows[index].Cells[this.editColRL.Name];
                    int num = (int)MessageBox.Show((IWin32Window)this, "请输入 染料 !!!", "提示");
                    this.editDgvMain.Focus();
                    return false;
                }
                if (this.bsRL.Find("全称", (object)str2) < 0)
                {
                    this.editDgvMain.CurrentCell = this.editDgvMain.Rows[index].Cells[this.editColRL.Name];
                    int num = (int)MessageBox.Show((IWin32Window)this, "染料不在列表中,请正确输入!!!", "提示");
                    this.editDgvMain.Focus();
                    return false;
                }
                string str3 = this.editDgvMain.Rows[index].Cells[this.editColBLDW.Name].FormattedValue.ToString();
                if (this.editDgvMain.Rows[index].Cells[this.editColBL.Name].FormattedValue.ToString() != "" && str3 == "")
                {
                    this.editDgvMain.CurrentCell = this.editDgvMain.Rows[index].Cells[this.editColBLDW.Name];
                    int num = (int)MessageBox.Show((IWin32Window)this, "请输入 浓度单位 !!!", "提示");
                    this.editDgvMain.Focus();
                    return false;
                }
                if (str3 != "" && str3 != "owf" && (str3 != "g/L" && str3 != "mL/L") && str3 != "g" && str3 != "Kg")
                {
                    this.editDgvMain.CurrentCell = this.editDgvMain.Rows[index].Cells[this.editColBLDW.Name];
                    int num = (int)MessageBox.Show((IWin32Window)this, "请输入正确 浓度单位 !!!", "提示");
                    this.editDgvMain.Focus();
                    return false;
                }
            }
            return true;
        }
        private void editBtnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show((IWin32Window)this, "确认 保存 吗 ?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No || !this.yanzheng())
                return;
            this.lblwait.showme();
            if (this.editBtnSave.Text == "保存")
            {
                if (this.saveLD())
                {
                    this.showLDH = this.editImgLDH.Tag.ToString();
                    this.ExeMode = exeMode.显示料单;
                    this.showLD();
                    int num = (int)MessageBox.Show((IWin32Window)this, "保存成功!!!", "提示");
                }
            }
            else if (this.editBtnSave.Text == "修改" && this.editLD())
            {
                if (this.editLD())
                {
                    this.showLDH = this.editImgLDH.Tag.ToString();
                    this.ExeMode = exeMode.显示料单;
                    this.showLD();
                    int num = (int)MessageBox.Show((IWin32Window)this, "修改成功!!!", "提示");
                }

            }
            this.lblwait.hideme();
        }
        private bool saveLD()
        {
            //DBpf dbpf = new DBpf(Settings.Default.DBconn);
            var ass = db.Queryable<T_PFmain>()
                .Where(a => a.leibie == "小样单" && a.kehu == this.editTxtKH.txt.Text && a.shazhong == this.editTxtSZ.txt.Text && a.sehao == this.editTxtSH.txt.Text)
                .ToList();
            if (ass.Count() > 0 && MessageBox.Show((IWin32Window)this, "本 <客户/品名/色号> 小样配方已存在,确认继续增加吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                //dbpf.Dispose();
                return false;
            }
            if (!this.getLDH() || this.editImgLDH.Image == null || this.editImgLDH.Tag == null)
            {
                //dbpf.Dispose();
                int num = (int)MessageBox.Show((IWin32Window)this, "生成单号失败,请检查!!!", "提示");
                return false;
            }
            try
            {
                //using (TransactionScope transactionScope = new TransactionScope())
                {
                    T_PFmain entity = new T_PFmain()
                    {
                        leibie = leibie.enumPFLB.小样单.ToString(),
                        danhao = this.editImgLDH.Tag.ToString(),
                        ganghao = "",
                        JLci = 0,
                        shazhong = this.editTxtSZ.txt.Text,
                        guige = "",
                        pihao = "",
                        kehu = this.editTxtKH.txt.Text,
                        dingdan = this.editTxtDDH.txt.Text,
                        sehao = this.editTxtSH.txt.Text,
                        yanse = this.editTxtYS.txt.Text,
                        jihao = "",
                        shuiliang = new Decimal(0),
                        zhongliang = new Decimal(0),
                        jiagong = "",
                        yewuyuan = "",
                        dayang = this.editTxtDY.txt.Text,
                        zhuche = "",
                        peifang = ClsLogUser.XinMing,
                        fuhe = "",
                        mishu = new Decimal(0),
                        kezhong = "",
                        danjia = new Decimal(0),
                        beizhu = this.editTxtBZ.txt.Text,
                        riqiSave = new DateTime?(DateTime.Now),
                        riqiShen = new DateTime?(),
                        riqiCheng = new DateTime?(),
                        JLciHJ = 0,
                        sta = leibie.staPF.未审核.ToString(),
                        editrec = DateTime.Now.ToString("yy-MM-dd HH:mm") + ClsLogUser.XinMing + "建立。"
                    };
                    db.Insertable<T_PFmain>(entity).ExecuteCommand();
                    //dbpf.T_PFmain.InsertOnSubmit(entity);
                    //dbpf.SubmitChanges();
                    for (int index = 0; index < this.editDgvMain.RowCount; ++index)
                    {
                        db.Insertable<T_PFdata>(new T_PFdata()
                        {
                            danhao = entity.danhao,
                            gongxu = this.editDgvMain.Rows[index].Cells[this.editColGX.Name].FormattedValue.ToString(),
                            ranliao = this.editDgvMain.Rows[index].Cells[this.editColRL.Name].FormattedValue.ToString(),
                            ranliaoBZ = "",
                            bili = this.editDgvMain.Rows[index].Cells[this.editColBL.Name].FormattedValue.ToString() == "" ? new Decimal(0) : Convert.ToDecimal(this.editDgvMain.Rows[index].Cells[this.editColBL.Name].FormattedValue.ToString()),
                            biliDW = this.editDgvMain.Rows[index].Cells[this.editColBLDW.Name].FormattedValue.ToString(),
                            yaoqiu = this.editDgvMain.Rows[index].Cells[this.editColGY.Name].FormattedValue.ToString(),
                            yongliang = new Decimal(0),
                            yongliangDW = "",
                            JLbili = new Decimal(0),
                            JLyongliang = new Decimal(0),
                            JLyongliangDW = "",
                            SNld = -1L
                        }).ExecuteCommand();
                        //dbpf.SubmitChanges();
                    }
                    //transactionScope.Complete();
                    //dbpf.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {
                //dbpf?.Dispose();
                int num = (int)MessageBox.Show((IWin32Window)this, ex.Message + "\r\n\r\n   保存失败,请核查原因再试一次!", "提示");
                return false;
            }
        }
        private bool editLD()
        {
            //DBpf dbpf = new DBpf(Settings.Default.DBconn);
            T_PFmain rowmain = db.Queryable<T_PFmain>()
                .Where(a => a.danhao == this.editImgLDH.Tag.ToString())
                .First();
            if (rowmain == null || rowmain.sta != this.editLblStaLD.Text)
            {
                //dbpf.Dispose();
                int num = (int)MessageBox.Show((IWin32Window)this, "本小样配方已不存在或状态发生改变!请核查!", "提示");
                return false;
            }
            try
            {
                //using (TransactionScope transactionScope = new TransactionScope())
                {
                    rowmain.kehu = this.editTxtKH.txt.Text;
                    rowmain.shazhong = this.editTxtSZ.txt.Text;
                    rowmain.sehao = this.editTxtSH.txt.Text;
                    rowmain.dingdan = this.editTxtDDH.txt.Text;
                    rowmain.yanse = this.editTxtYS.txt.Text;
                    rowmain.dayang = this.editTxtDY.txt.Text;
                    rowmain.peifang = ClsLogUser.XinMing;
                    rowmain.beizhu = this.editTxtBZ.txt.Text;
                    rowmain.riqiSave = new DateTime?(DateTime.Now);
                    rowmain.editrec = rowmain.editrec + DateTime.Now.ToString("yy-MM-dd HH:mm") + ClsLogUser.XinMing + "修改。";
                    db.Updateable<T_PFmain>(rowmain).ExecuteCommand();
                    //dbpf.SubmitChanges();
                    //dbpf.T_PFdata.DeleteAllOnSubmit<T_PFdata>(dbpf.T_PFdata.Where<T_PFdata>((Expression<Func<T_PFdata, bool>>)(a => a.danhao == rowmain.danhao)).AsEnumerable<T_PFdata>());
                    //dbpf.SubmitChanges();
                    db.Deleteable<T_PFdata>().Where(a => a.danhao == rowmain.danhao).ExecuteCommand();
                    for (int index = 0; index < this.editDgvMain.RowCount; ++index)
                    {
                        db.Insertable<T_PFdata>(new T_PFdata()
                        {
                            danhao = rowmain.danhao,
                            gongxu = this.editDgvMain.Rows[index].Cells[this.editColGX.Name].FormattedValue.ToString(),
                            ranliao = this.editDgvMain.Rows[index].Cells[this.editColRL.Name].FormattedValue.ToString(),
                            ranliaoBZ = "",
                            bili = this.editDgvMain.Rows[index].Cells[this.editColBL.Name].FormattedValue.ToString() == "" ? new Decimal(0) : Convert.ToDecimal(this.editDgvMain.Rows[index].Cells[this.editColBL.Name].FormattedValue.ToString()),
                            biliDW = this.editDgvMain.Rows[index].Cells[this.editColBLDW.Name].FormattedValue.ToString(),
                            yaoqiu = this.editDgvMain.Rows[index].Cells[this.editColGY.Name].FormattedValue.ToString(),
                            yongliang = new Decimal(0),
                            yongliangDW = "",
                            JLbili = new Decimal(0),
                            JLyongliang = new Decimal(0),
                            JLyongliangDW = "",
                            SNld = -1L
                        }).ExecuteCommand();
                        //dbpf.SubmitChanges();
                    }
                    //transactionScope.Complete();
                    //dbpf.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {
                //dbpf?.Dispose();
                int num = (int)MessageBox.Show((IWin32Window)this, ex.Message + "\r\n\r\n   修改失败,请核查原因再试一次!", "提示");
                return false;
            }
        }
        private void editBtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show((IWin32Window)this, "确认取消吗 ?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;
            this.ExeMode = exeMode.显示料单;
            this.showLD();
        }
        private void this_Load(object sender, EventArgs e)
        {
            this.refSch();
            this.refList();
            //this.setQX();
            this.refOne();
            this.ExeMode = exeMode.显示料单;
            this.showLD();

            this.editDgvList.AutoGenerateColumns = true;
            this.editDgvMain.AutoGenerateColumns = false;
            this.editColBL.ValueType = typeof(Decimal);
            this.editTxtKH.txt.GotFocus += new EventHandler(this.editTxtKH_GotFocus);
            this.editTxtSZ.txt.GotFocus += new EventHandler(this.editTxtSZ_GotFocus);
            this.editTxtYS.txt.GotFocus += new EventHandler(this.editTxtYS_GotFocus);
            this.editTxtDY.txt.GotFocus += new EventHandler(this.editTxtDY_GotFocus);
            this.editTxtSH.txt.GotFocus += new EventHandler(this.editTxtSH_GotFocus);
            this.editDgvMain.CellEnter += new DataGridViewCellEventHandler(this.editDgvMain_CellEnter);
            this.editTxtKH.txt.KeyUp += new KeyEventHandler(this.editTxtKH_KeyUp);
            this.editTxtSZ.txt.KeyUp += new KeyEventHandler(this.editTxtSZ_KeyUp);
            this.editTxtSH.txt.KeyUp += new KeyEventHandler(this.editTxtSH_KeyUp);
            //this.editTxtDDH.txt.KeyUp += new KeyEventHandler(this.editTxtDDH_KeyUp);
            this.editTxtYS.txt.KeyUp += new KeyEventHandler(this.editTxtYS_KeyUp);
            this.editTxtDY.txt.KeyUp += new KeyEventHandler(this.editTxtDY_KeyUp);
            this.editTxtBZ.txt.KeyUp += new KeyEventHandler(this.editTxtBZ_KeyUp);
            this.editDgvMain.cellKeyUp += new dgvEX.cellKeyUpEventHandler(this.editDgvMain_cellKeyUp);
            this.editDgvMain.CellValidating += new DataGridViewCellValidatingEventHandler(this.editDgvMain_CellValidating);
            this.editDgvList.CellMouseClick += new DataGridViewCellMouseEventHandler(this.editDgvList_CellMouseClick);
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
            this.bsBLDW.DataSource = (object)dataTable;
            dataTable.Dispose();
        }
        private void editTxtSH_GotFocus(object sender, EventArgs e)
        {
            if (this.editDgvList.DataSource == this.bsSH)
                return;
            this.editDgvList.DataSource = (object)null;
            this.bsSH.Filter = "";
            this.editDgvList.DataSource = (object)this.bsSH;
            this.editDgvList.Columns[0].Width = 50;
            this.editDgvList.Columns[1].Width = 120;
            this.editDgvList.Columns[2].Width = 120;
            this.editDgvList.Columns[3].Width = 120;
            this.editDgvList.Columns[4].Width = 120;
            this.editDgvList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void editTxtKH_GotFocus(object sender, EventArgs e)
        {
            if (this.editDgvList.DataSource == this.bsKH)
                return;
            this.editDgvList.DataSource = (object)null;
            this.bsKH.Filter = "";
            this.editDgvList.DataSource = (object)this.bsKH;
            this.editDgvList.Columns[0].Width = 50;
            this.editDgvList.Columns[1].Width = 120;
            this.editDgvList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.editDgvList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void editTxtSZ_GotFocus(object sender, EventArgs e)
        {
            if (this.editDgvList.DataSource == this.bsSZ)
                return;
            this.editDgvList.DataSource = (object)null;
            this.bsSZ.Filter = "";
            this.editDgvList.DataSource = (object)this.bsSZ;
            this.editDgvList.Columns[0].Width = 50;
            this.editDgvList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.editDgvList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void editTxtYS_GotFocus(object sender, EventArgs e)
        {
            if (this.editDgvList.DataSource == this.bsYS)
                return;
            this.editDgvList.DataSource = (object)null;
            this.bsYS.Filter = "";
            this.editDgvList.DataSource = (object)this.bsYS;
            this.editDgvList.Columns[0].Width = 50;
            this.editDgvList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.editDgvList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void editTxtDY_GotFocus(object sender, EventArgs e)
        {
            if (this.editDgvList.DataSource == this.bsDY)
                return;
            this.editDgvList.DataSource = (object)null;
            this.bsDY.Filter = "";
            this.editDgvList.DataSource = (object)this.bsDY;
            this.editDgvList.Columns[0].Width = 50;
            this.editDgvList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.editDgvList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void editDgvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            switch (this.editDgvMain.Columns[e.ColumnIndex].Name)
            {
                case "editColGX":
                    if (this.editDgvList.DataSource == this.bsGX)
                        break;
                    this.editDgvList.DataSource = (object)null;
                    this.bsGX.Filter = "";
                    this.editDgvList.DataSource = (object)this.bsGX;
                    this.editDgvList.Columns[0].Width = 50;
                    this.editDgvList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.editDgvList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    break;
                case "editColRL":
                    if (this.editDgvList.DataSource == this.bsRL)
                        break;
                    this.editDgvList.DataSource = (object)null;
                    this.bsRL.Filter = "";
                    this.editDgvList.DataSource = (object)this.bsRL;
                    this.editDgvList.Columns[0].Width = 50;
                    this.editDgvList.Columns[1].Width = 100;
                    this.editDgvList.Columns[2].Width = 100;
                    this.editDgvList.Columns[3].Width = 100;
                    this.editDgvList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.editDgvList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    break;
                case "editColBLDW":
                    if (this.editDgvList.DataSource == this.bsBLDW)
                        break;
                    this.editDgvList.DataSource = (object)null;
                    this.editDgvList.DataSource = (object)this.bsBLDW;
                    this.editDgvList.Columns[0].Width = 50;
                    this.editDgvList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.editDgvList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    break;
            }
        }

        private void editTxtKH_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtKH.ReadOnly)
                return;
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                if (Regex.IsMatch(this.editTxtKH.txt.Text, "[A-Z0-9-]{" + this.editTxtKH.txt.Text.Length.ToString() + "}") && this.editDgvList.RowCount > 0 && this.editTxtKH.txt.Text == this.editDgvList.Rows[0].Cells[0].FormattedValue.ToString())
                    this.editTxtKH.txt.Text = this.editDgvList.Rows[0].Cells[1].FormattedValue.ToString();
                this.editTxtSZ.txt.Focus();
            }
            else
                this.bsKH.Filter = "编号 like '" + this.editTxtKH.txt.Text + "%' or 客户 like '" + this.editTxtKH.txt.Text + "%'";
        }

        private void editTxtSZ_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtSZ.ReadOnly)
                return;
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                if (Regex.IsMatch(this.editTxtSZ.txt.Text, "[A-Z0-9-]{" + this.editTxtSZ.txt.Text.Length.ToString() + "}") && this.editDgvList.RowCount > 0 && this.editTxtSZ.txt.Text == this.editDgvList.Rows[0].Cells[0].FormattedValue.ToString())
                    this.editTxtSZ.txt.Text = this.editDgvList.Rows[0].Cells[1].FormattedValue.ToString();
                this.editTxtSH.txt.Focus();
            }
            else
                this.bsSZ.Filter = "编号 like '" + this.editTxtSZ.txt.Text + "%' or 品名 like '" + this.editTxtSZ.txt.Text + "%'";
        }

        private void editTxtSH_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtSH.ReadOnly)
                return;
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                //if (Regex.IsMatch(this.editTxtSH.txt.Text, "[A-Z0-9-]{" + this.editTxtSH.txt.Text.Length.ToString() + "}") && this.editDgvList.RowCount > 0 && this.editTxtSH.txt.Text == this.editDgvList.Rows[0].Cells[0].FormattedValue.ToString())
                if (this.editDgvList.RowCount > 0)
                {
                    this.editTxtSH.txt.Text = this.editDgvList.Rows[0].Cells[1].FormattedValue.ToString();
                    string bianhao = this.editDgvList.Rows[0].Cells[1].FormattedValue.ToString();
                    var asd = db.Queryable<BaseIList>().Where(it => it.item3 == bianhao).First();
                    editTxtYS.txt.Text = asd.seming;
                    editTxtKH.txt.Text = asd.item2;
                    editTxtSZ.txt.Text = asd.item1;
                }
                this.editTxtYS.txt.Focus();
            }
            else
                this.bsSH.Filter = "编号 like '" + this.editTxtSH.txt.Text + "%' or 色号 like '" + this.editTxtSH.txt.Text + "%'";

        }

        private void editTxtDDH_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtDDH.ReadOnly || e.KeyCode != System.Windows.Forms.Keys.Return)
                return;
            string var1 = editTxtDDH.txt.Text;
            var a = db.Queryable<LCKA>().Where(b => b.liushuihao == var1).First();
            if (a != null)
            {
                editTxtKH.txt.Text = a.kehu;
                editTxtSZ.txt.Text = a.peiming;
                editTxtSH.txt.Text = a.sehao;
                editTxtYS.txt.Text = a.sebie;
            }
            this.editTxtYS.txt.Focus();
        }

        private void editTxtYS_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtYS.ReadOnly)
                return;
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                if (Regex.IsMatch(this.editTxtYS.txt.Text, "[A-Z0-9-]{" + this.editTxtYS.txt.Text.Length.ToString() + "}") && this.editDgvList.RowCount > 0 && this.editTxtYS.txt.Text == this.editDgvList.Rows[0].Cells[0].FormattedValue.ToString())
                    this.editTxtYS.txt.Text = this.editDgvList.Rows[0].Cells[1].FormattedValue.ToString();
                this.editTxtDY.txt.Focus();
            }
            else
                this.bsYS.Filter = "编号 like '" + this.editTxtYS.txt.Text + "%' or 颜色 like '" + this.editTxtYS.txt.Text + "%'";
        }

        private void editTxtDY_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtDY.ReadOnly)
                return;
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                if (Regex.IsMatch(this.editTxtDY.txt.Text, "[A-Z0-9-]{" + this.editTxtDY.txt.Text.Length.ToString() + "}") && this.editDgvList.RowCount > 0 && this.editTxtDY.txt.Text == this.editDgvList.Rows[0].Cells[0].FormattedValue.ToString())
                    this.editTxtDY.txt.Text = this.editDgvList.Rows[0].Cells[1].FormattedValue.ToString();
                this.editTxtBZ.txt.Focus();
            }
            else
                this.bsDY.Filter = "编号 like '" + this.editTxtDY.txt.Text + "%' or 员工 like '" + this.editTxtDY.txt.Text + "%'";
        }

        private void editTxtBZ_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtBZ.ReadOnly)
                ;
        }

        private void editDgvMain_cellKeyUp(object sender, KeyEventArgs e)
        {
            if (this.editDgvMain.ReadOnly || this.editDgvMain.CurrentCell == null)
                return;
            string input = this.editDgvMain.CurrentCell.EditedFormattedValue.ToString();
            switch (this.editDgvMain.Columns[this.editDgvMain.CurrentCell.ColumnIndex].Name)
            {
                case "editColGX":
                    if (!this.editDgvMain.CurrentCell.IsInEditMode)
                        break;
                    if (e.KeyCode == System.Windows.Forms.Keys.Return)
                    {
                        if (!Regex.IsMatch(input, "[A-Z0-9-]{" + input.Length.ToString() + "}") || this.editDgvList.RowCount <= 0 || !(input == this.editDgvList.Rows[0].Cells[0].FormattedValue.ToString()))
                            break;
                        this.editDgvMain.EndEdit();
                        this.editDgvMain.CurrentCell.Value = (object)this.editDgvList.Rows[0].Cells[1].FormattedValue.ToString();
                        break;
                    }
                    this.bsGX.Filter = "编号 like '" + input + "%'";
                    break;
                case "editColRL":
                    if (!this.editDgvMain.CurrentCell.IsInEditMode)
                        break;
                    if (e.KeyCode == System.Windows.Forms.Keys.Return)
                    {
                        if (!Regex.IsMatch(input, "[A-Z0-9-]{" + input.Length.ToString() + "}") || this.editDgvList.RowCount <= 0 || !(input == this.editDgvList.Rows[0].Cells[0].FormattedValue.ToString()))
                            break;
                        this.editDgvMain.EndEdit();
                        this.editDgvMain.CurrentCell.Value = (object)this.editDgvList.Rows[0].Cells[2].FormattedValue.ToString();
                        break;
                    }
                    this.bsRL.Filter = "编号 like '" + input + "%' or 染料简称 like '" + input + "%'";
                    break;
                case "editColBLDW":
                    if (!this.editDgvMain.CurrentCell.IsInEditMode)
                        break;
                    switch (input)
                    {
                        case "1":
                            this.editDgvMain.EndEdit();
                            this.editDgvMain.CurrentCell.Value = (object)"owf";
                            return;
                        case "2":
                            this.editDgvMain.EndEdit();
                            this.editDgvMain.CurrentCell.Value = (object)"g/L";
                            return;
                        case "3":
                            this.editDgvMain.EndEdit();
                            this.editDgvMain.CurrentCell.Value = (object)"mL/L";
                            return;
                        case "4":
                            this.editDgvMain.EndEdit();
                            this.editDgvMain.CurrentCell.Value = (object)"g";
                            return;
                        case "5":
                            this.editDgvMain.EndEdit();
                            this.editDgvMain.CurrentCell.Value = (object)"Kg";
                            return;
                        case null:
                            return;
                        default:
                            return;
                    }
                case "editColGY":
                    if (e.KeyCode != System.Windows.Forms.Keys.Return || this.editDgvMain.CurrentCell.RowIndex != this.editDgvMain.RowCount - 1)
                        break;
                    this.editDgvMain.Rows.Add();
                    this.editDgvMain.Rows[this.editDgvMain.RowCount - 1].Cells[this.editColSN.Name].Value = (object)-1;
                    break;
            }
        }

        private void editDgvMain_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (this.editDgvMain.ReadOnly || this.editDgvMain.CurrentCell == null || !this.editDgvMain.CurrentCell.IsInEditMode)
                return;
            string str = this.editDgvMain.CurrentCell.EditedFormattedValue.ToString();
            if (str == "")
                return;
            switch (this.editDgvMain.Columns[e.ColumnIndex].Name)
            {
                case "editColBL":
                    if (UserProc.IsNumeric(str) && !(Convert.ToDecimal(str) < new Decimal(0)))
                        break;
                    int num1 = (int)MessageBox.Show((IWin32Window)this, "请输入正确 <比例>( >= 0数值 )!!!", "提示");
                    e.Cancel = true;
                    break;
                case "editColBLDW":
                    if (!(str != "owf") || !(str != "g/L") || !(str != "mL/L"))
                        break;
                    int num2 = (int)MessageBox.Show((IWin32Window)this, "请输入正确 <浓度单位>!!!", "提示");
                    e.Cancel = true;
                    break;
            }
        }
        private void editDgvList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.ExeMode == exeMode.显示料单 || (e.ColumnIndex < 0 || e.RowIndex < 0))
                return;
            if (this.editDgvList.DataSource == this.bsKH)
            {
                if (this.editTxtKH.ReadOnly)
                    return;
                this.editTxtKH.txt.Text = this.editDgvList.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                this.editTxtKH.txt.Focus();
            }
            else if (this.editDgvList.DataSource == this.bsSZ)
            {
                if (this.editTxtSZ.ReadOnly)
                    return;
                this.editTxtSZ.txt.Text = this.editDgvList.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                this.editTxtSZ.txt.Focus();
            }
            else if (this.editDgvList.DataSource == this.bsSH)
            {
                if (this.editTxtSH.ReadOnly)
                    return;
                this.editTxtSH.txt.Text = this.editDgvList.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                string bianhao = this.editDgvList.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                var asd = db.Queryable<BaseIList>().Where(it => it.item3 == bianhao).First();
                editTxtYS.txt.Text = asd.seming;
                editTxtKH.txt.Text = asd.item2;
                editTxtSZ.txt.Text = asd.item1;

                this.editTxtSH.txt.Focus();
            }
            else if (this.editDgvList.DataSource == this.bsYS)
            {
                if (this.editTxtYS.ReadOnly)
                    return;
                this.editTxtYS.txt.Text = this.editDgvList.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                this.editTxtYS.txt.Focus();
            }
            else if (this.editDgvList.DataSource == this.bsDY)
            {
                if (this.editTxtDY.ReadOnly)
                    return;
                this.editTxtDY.txt.Text = this.editDgvList.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                this.editTxtDY.txt.Focus();
            }
            else if (this.editDgvList.DataSource == this.bsGX)
            {
                if (this.editDgvMain.ReadOnly || this.editDgvMain.CurrentCell == null || this.editDgvMain.CurrentCell.ColumnIndex != this.editColGX.Index || this.editDgvMain.CurrentRow.Cells[this.editColSN.Name].FormattedValue.ToString() != "-1")
                    return;
                this.editDgvMain.CurrentCell.Value = (object)this.editDgvList.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                this.editDgvMain.Focus();
            }
            else if (this.editDgvList.DataSource == this.bsRL)
            {
                if (this.editDgvMain.ReadOnly || this.editDgvMain.CurrentCell == null || this.editDgvMain.CurrentCell.ColumnIndex != this.editColRL.Index || this.editDgvMain.CurrentRow.Cells[this.editColSN.Name].FormattedValue.ToString() != "-1")
                    return;
                this.editDgvMain.CurrentCell.Value = (object)this.editDgvList.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                this.editDgvMain.Focus();
            }
            else
            {
                if (this.editDgvList.DataSource != this.bsBLDW || (this.editDgvMain.ReadOnly || this.editDgvMain.CurrentCell == null || this.editDgvMain.CurrentCell.ColumnIndex != this.editColBLDW.Index || this.editDgvMain.CurrentRow.Cells[this.editColSN.Name].FormattedValue.ToString() != "-1"))
                    return;
                this.editDgvMain.CurrentCell.Value = (object)this.editDgvList.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                this.editDgvMain.Focus();
            }
        }
        private enum exeMode
        {
            显示料单,
            料单编辑,
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mainDgv.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.mainDgv.Print("小样表", UserProc.CheckTime);
            this.lblwait.hideme();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mainDgv.Rows.Count == 0)
                return;
            lblwait.showme();
            this.mainDgv.saveExcel("小样表");
            lblwait.hideme();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mainDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || this.mainDgv.CurrentRow.Index != e.RowIndex || this.ExeMode == exeMode.料单编辑 && MessageBox.Show((IWin32Window)this, "配方编辑 正处于操作状态,显示配方信息将清除你编辑的数据,确认吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;
            this.lblwait.showme();
            this.showLDH = this.mainDgv.CurrentRow.Cells[this.mainColBH.Name].Value.ToString();
            this.ExeMode = exeMode.显示料单;
            if (this.showLD())
                this.tabPages.SelectedTab = this.tpEdit;
            this.lblwait.hideme();
        }

        private void editBtnNewNow_Click(object sender, EventArgs e)
        {
            ExeMode = exeMode.料单编辑;
            this.editBtnSave.Text = "保存";
            this.refList();
            if (!this.getLDH())
            {
                int num2 = (int)MessageBox.Show((IWin32Window)this, "单号生成失败,请检查!!!", "提示");
            }
            this.editTxtKH.txt.Focus();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.schData();
            this.lblwait.showme();
            this.refData();
            this.lblwait.hideme();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tmpLDH = this.mainDgv.CurrentRow.Cells[this.mainColBH.Name].FormattedValue.ToString();
            if (MessageBox.Show((IWin32Window)this, "确定删除本小样配方(单号:" + tmpLDH + ")?将不可恢复!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;
            //DBpf dbpf = new DBpf(Settings.Default.DBconn);
            //T_PFmain tPfmain = dbpf.T_PFmain.Where<T_PFmain>((Expression<Func<T_PFmain, bool>>)(a => a.danhao == this.editImgLDH.Tag.ToString())).SingleOrDefault<T_PFmain>();
            T_PFmain tPfmain = db.Queryable<T_PFmain>().Where(a => a.danhao == tmpLDH).First();
            string sta = this.mainDgv.CurrentRow.Cells[this.mainColSta.Name].FormattedValue.ToString();
            if (tPfmain == null || sta == leibie.staPF.已审核.ToString() || sta == leibie.staPF.已删除.ToString())
            {
                //dbpf.Dispose();
                int num2 = (int)MessageBox.Show((IWin32Window)this, "本小样配方已审核或者已删除", "提示");
            }
            else
            {
                this.lblwait.showme();
                tPfmain.fuhe = ClsLogUser.XinMing;
                tPfmain.riqiShen = new DateTime?(DateTime.Now);
                tPfmain.sta = leibie.staPF.已删除.ToString();
                db.Updateable<T_PFmain>(tPfmain).ExecuteCommand();
                //dbpf.SubmitChanges();
                //dbpf.Dispose();
                this.schData();
                this.refData();
                this.lblwait.hideme();
                int num2 = (int)MessageBox.Show((IWin32Window)this, "删除成功!!!", "提示");

            }
        }
    }
}

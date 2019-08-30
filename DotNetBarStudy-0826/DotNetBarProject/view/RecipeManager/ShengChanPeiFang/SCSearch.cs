using BarcodeLib;
using DevComponents.DotNetBar;
using DotNetBarProject.Properties;
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
    public partial class SCSearch : Office2007Form
    {
        exeMode _ExeMode = SCSearch.exeMode.显示料单;

        public lck.LckBarSearch.DoubleList doublelist;
        private LblWait lblwait;
        string XYD = leibie.enumPFLB.小样单.ToString();

        string YSH = leibie.staPF.已审核.ToString();
        string WSH = leibie.staPF.未审核.ToString();
        string YSC = leibie.staPF.已删除.ToString();
        SqlSugarClient db;

        private BindingSource bsZC;
        private BindingSource bsGX;
        private BindingSource bsBLDW;
        private BindingSource bsYLDW;
        private BindingSource bsKH;
        private BindingSource bsSZ;
        private BindingSource bsDY;
        private BindingSource bsJH;
        private BindingSource bsRL;
        private BindingSource bsSch;
        private BindingSource bsShowMain;
        private BindingSource bsShowData;
        private BindingSource bsSH;
        private BindingSource bsYS;
        private string strSch = "";
        private string showLDH = "";
        public SCSearch()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Location = new Point(0, 0);
            db = SqlBase.GetInstance();
            lblwait = new LblWait((Form)this);
            Init();
        }
        private void Init()
        {
            this.bsKH = new BindingSource();
            this.bsSZ = new BindingSource();
            this.bsDY = new BindingSource();
            this.bsJH = new BindingSource();
            this.bsRL = new BindingSource();
            this.bsZC = new BindingSource();
            this.bsGX = new BindingSource();
            this.bsBLDW = new BindingSource();
            this.bsYLDW = new BindingSource();
            this.bsSch = new BindingSource();
            this.bsShowMain = new BindingSource();
            this.bsShowData = new BindingSource();
            this.bsSH = new BindingSource();
            this.bsYS = new BindingSource();
            this.editTxtKH.txt.GotFocus += new EventHandler(this.editTxtKH_GotFocus);
            this.editTxtSZ.txt.GotFocus += new EventHandler(this.editTxtSZ_GotFocus);
            this.editTxtSH.txt.GotFocus += new EventHandler(this.editTxtSH_GotFocus);
            this.editTxtYS.txt.GotFocus += new EventHandler(this.editTxtYS_GotFocus);
            this.editTxtDY.txt.GotFocus += new EventHandler(this.editTxtDY_GotFocus);
            this.editTxtZC.txt.GotFocus += new EventHandler(this.editTxtZC_GotFocus);
            this.editTxtJH.txt.GotFocus += new EventHandler(this.editTxtJH_GotFocus);
            this.editDgvMain.CellEnter += new DataGridViewCellEventHandler(this.editDgvMain_CellEnter);
            this.editTxtKH.txt.KeyUp += new KeyEventHandler(this.editTxtKH_KeyUp);
            this.editTxtSZ.txt.KeyUp += new KeyEventHandler(this.editTxtSZ_KeyUp);
            this.editTxtSH.txt.KeyUp += new KeyEventHandler(this.editTxtSH_KeyUp);
            this.editTxtYS.txt.KeyUp += new KeyEventHandler(this.editTxtYS_KeyUp);
            this.editTxtDDH.txt.KeyUp += new KeyEventHandler(this.editTxtDDH_KeyUp);
            this.editTxtDY.txt.KeyUp += new KeyEventHandler(this.editTxtDY_KeyUp);
            this.editTxtZC.txt.KeyUp += new KeyEventHandler(this.editTxtZC_KeyUp);
            this.editTxtDJ.txt.KeyUp += new KeyEventHandler(this.editTxtPS_KeyUp);
            this.editTxtKZ.txt.KeyUp += new KeyEventHandler(this.eidtTxtKZ_KeyUp);
            this.editTxtMS.txt.KeyUp += new KeyEventHandler(this.editTxtMS_KeyUp);
            this.editTxtJH.txt.KeyUp += new KeyEventHandler(this.editTxtJH_KeyUp);
            this.editTxtSL.txt.KeyUp += new KeyEventHandler(this.editTxtSL_KeyUp);
            this.editTxtZL.txt.KeyUp += new KeyEventHandler(this.editTxtZL_KeyUp);
            this.editTxtBZ.txt.KeyUp += new KeyEventHandler(this.editTxtBZ_KeyUp);
            this.editTxtKZ.txt.Validated += new EventHandler(this.editTxtKZ_Validated);
            this.editTxtMS.txt.Validated += new EventHandler(this.editTxtMS_Validated);
            this.editTxtSL.txt.Validated += new EventHandler(this.editTxtSL_Validated);
            this.editTxtZL.txt.Validated += new EventHandler(this.editTxtZL_Validated);
            this.editDgvMain.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.editDgvMain_CellBeginEdit);
            this.editDgvMain.cellKeyUp += new dgvEX.cellKeyUpEventHandler(this.editDgvMain_cellKeyUp);
            this.editDgvMain.CellValidating += new DataGridViewCellValidatingEventHandler(this.editDgvMain_CellValidating);
            this.editDgvMain.CellValidated += new DataGridViewCellEventHandler(this.editDgvMain_CellValidated);
            this.editDgvMain.RowPostPaint += new DataGridViewRowPostPaintEventHandler(this.editDgvMain_RowPostPaint);
            this.editDgvList.CellMouseClick += new DataGridViewCellMouseEventHandler(this.editDgvList_CellMouseClick);
            this.refSch();
            this.refList();
            //this.setQX();
            this.refOne();
            ExeMode = exeMode.显示料单;
            showLD();
            mainColDH.Tag = "总行:";
            mainColZL.Tag = "总量合计:";
            mainColMS.Tag = "米数合计:";

        }
        private void getYL(int rowidx)
        {
            Decimal num1 = this.editTxtSL.txt.Text == "" ? new Decimal(0) : Convert.ToDecimal(this.editTxtSL.txt.Text);
            Decimal num2 = this.editTxtZL.txt.Text == "" ? new Decimal(0) : Convert.ToDecimal(this.editTxtZL.txt.Text);
            Decimal num3 = this.editDgvMain.Rows[rowidx].Cells[this.editColBL.Name].FormattedValue.ToString() == "" ? new Decimal(0) : Convert.ToDecimal(this.editDgvMain.Rows[rowidx].Cells[this.editColBL.Name].FormattedValue.ToString());
            string str1 = this.editDgvMain.Rows[rowidx].Cells[this.editColBLDW.Name].FormattedValue.ToString();
            Decimal num4 = this.editDgvMain.Rows[rowidx].Cells[this.editColYL.Name].FormattedValue.ToString() == "" ? new Decimal(0) : Convert.ToDecimal(this.editDgvMain.Rows[rowidx].Cells[this.editColYL.Name].FormattedValue.ToString());
            this.editDgvMain.Rows[rowidx].Cells[this.editColYLDW.Name].FormattedValue.ToString();
            if (!(num3 != new Decimal(0)) && !(str1 != ""))
                return;
            Decimal d;
            string str2;
            if (str1 == "")
            {
                d = new Decimal(0);
                str2 = "";
            }
            else if (str1 == "owf")
            {
                d = num2 * num3 * new Decimal(10);
                str2 = d > new Decimal(0) ? "g" : "";
            }
            else
            {
                d = num1 * num3;
                str2 = d > new Decimal(0) ? (str1 == "g/L" ? "g" : "mL") : "";
            }
            Decimal num5 = !(str2 == "g") && !(str2 == "mL") ? Math.Round(d, 1) : (!(d >= (Decimal)Convert.ToInt16(Settings.Default.PFroundYL)) ? Math.Round(d, 1) : Math.Round(d, 1));
            this.editDgvMain.Rows[rowidx].Cells[this.editColYL.Name].Value = (object)num5;
            this.editDgvMain.Rows[rowidx].Cells[this.editColYLDW.Name].Value = (object)str2;
        }
        private bool showFromXY(long _SN)
        {

            T_PFmain rowmain = db.Queryable<T_PFmain>()
                .Where(a => a.SN == _SN)
                .First();// = dbpf.T_PFmain.Where<T_PFmain>((Expression<Func<T_PFmain, bool>>)(a => a.SN == _SN)).SingleOrDefault<T_PFmain>();
            if (rowmain == null)
            {
                //dbpf.Dispose();
                int num = (int)MessageBox.Show((IWin32Window)this, "无法找到此小样配方主数据!!!", "提示");
                return false;
            }
            if (editTxtDDH.txt.Text.Length != 0)
            {
            }
            else
            {
                this.editTxtKH.txt.Text = "";
                this.editTxtSZ.txt.Text = "";
                this.editTxtSH.txt.Text = "";
                this.editTxtYS.txt.Text = "";
                this.editTxtDDH.txt.Text = "";

                this.editTxtDY.txt.Text = "";
                this.editTxtZC.txt.Text = "";
                this.editTxtDJ.txt.Text = "";
                this.editTxtKZ.txt.Text = "";
                this.editTxtMS.txt.Text = "";

                this.editTxtJH.txt.Text = "";
                this.editTxtSL.txt.Text = "";
                this.editTxtZL.txt.Text = "";
                this.editTxtBZ.txt.Text = "";


                this.editTxtKH.txt.Text = rowmain.kehu;
                this.editTxtSZ.txt.Text = rowmain.shazhong;
                this.editTxtYS.txt.Text = rowmain.yanse;
                this.editTxtDY.txt.Text = rowmain.dayang;
            }
            this.editTxtSH.txt.Text = rowmain.sehao;
            this.editDgvMain.Rows.Clear();

            List<T_PFdata> list = db.Queryable<T_PFdata>()
                .Where(a => a.danhao == rowmain.danhao)
                .OrderBy(a => a.SN)
                .ToList();//dbpf.T_PFdata.Where<T_PFdata>((Expression<Func<T_PFdata, bool>>)(a => a.danhao == rowmain.danhao)).OrderBy<T_PFdata, long>((Expression<Func<T_PFdata, long>>)(a => a.SN)).ToList<T_PFdata>();
            
            for (int rowidx = 0; rowidx < list.Count<T_PFdata>(); ++rowidx)
            {
                this.editDgvMain.Rows.Add();
                DataGridViewRow row = this.editDgvMain.Rows[this.editDgvMain.RowCount - 1];
                row.Cells[this.editColSN.Name].Value = (object)-1;
                row.Cells[this.editColGX.Name].Value = (object)list[rowidx].gongxu;
                row.Cells[this.editColRL.Name].Value = (object)list[rowidx].ranliao;
                if (list[rowidx].biliDW == "g" || list[rowidx].biliDW == "Kg")
                {
                    row.Cells[this.editColBL.Name].Value = (object)0;
                    row.Cells[this.editColBLDW.Name].Value = (object)"";
                    row.Cells[this.editColYL.Name].Value = (object)list[rowidx].bili;
                    row.Cells[this.editColYL.Name].Tag = (object)list[rowidx].bili;
                    row.Cells[this.editColYLDW.Name].Value = (object)list[rowidx].biliDW;
                }
                else
                {
                    row.Cells[this.editColBL.Name].Value = (object)list[rowidx].bili;
                    row.Cells[this.editColBLDW.Name].Value = (object)list[rowidx].biliDW;
                    row.Cells[this.editColYL.Name].Value = (object)0;
                    row.Cells[this.editColYLDW.Name].Value = (object)"";
                }
                row.Cells[this.editColGY.Name].Value = (object)list[rowidx].yaoqiu;
                row.Cells[this.editColJL.Name].Value = (object)0;
                row.Cells[this.editColJLYL.Name].Value = (object)0;
                row.Cells[this.editColJLDW.Name].Value = (object)"";
                row.Cells[this.editColSNld.Name].Value = (object)-1;
                this.getYL(rowidx);
            }
            //dbpf.Dispose();
            return true;
        }
        private void editDgvList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.ExeMode == exeMode.显示料单 || this.ExeMode == exeMode.显示加料 || (e.ColumnIndex < 0 || e.RowIndex < 0))
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
                editTxtSH.txt.Text = this.editDgvList.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.showFromXY(Convert.ToInt64(this.editDgvList.Rows[e.RowIndex].Cells[6].Value));
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
            else if (this.editDgvList.DataSource == this.bsZC)
            {
                if (this.editTxtZC.ReadOnly)
                    return;
                this.editTxtZC.txt.Text = this.editDgvList.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                this.editTxtZC.txt.Focus();
            }
            else if (this.editDgvList.DataSource == this.bsJH)
            {
                if (this.editTxtJH.ReadOnly)
                    return;
                this.editTxtJH.txt.Text = this.editDgvList.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                this.editTxtSL.txt.Text = this.editDgvList.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                this.editTxtSL.txt.Focus();
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
                this.getYL(this.editDgvMain.CurrentCell.RowIndex);
                this.editDgvMain.Focus();
            }
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

        private void editTxtSH_GotFocus(object sender, EventArgs e)
        {
            if (this.editDgvList.DataSource == this.bsSH)
                return;
            this.editDgvList.DataSource = (object)null;
            this.bsSH.Filter = "";
            this.editDgvList.DataSource = (object)this.bsSH;
            this.editDgvList.Columns[0].Width = 45;
            this.editDgvList.Columns[1].Width = 80;
            this.editDgvList.Columns[2].Width = 80;
            this.editDgvList.Columns[3].Width = 45;
            this.editDgvList.Columns[4].Width = 75;
            this.editDgvList.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.editDgvList.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.editDgvList.Columns[5].Width = 80;
            this.editDgvList.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.editDgvList.Columns[6].Visible = false;
            /*
            if (this.editDgvList.DataSource == this.bsSH)
                return;
            //using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DBconn))
            {
                string CommandText = "select 编号=SN,色号=item3 from BaseIList where leibie = '色号' order by SN desc";
                DataTable dataTable = db.Ado.GetDataTable(CommandText);
                DataTable dataTable1 = new DataTable();

                dataTable1.Columns.Add("编号");
                dataTable1.Columns.Add("色号");
                for (var i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow newRow = dataTable1.NewRow();
                    string s_a = dataTable.Rows[i]["编号"] + "";
                    newRow["编号"] = s_a;
                    string s_b = dataTable.Rows[i]["色号"] + "";
                    newRow["色号"] = s_b;
                    dataTable1.Rows.Add(newRow);
                }
                this.bsSH.DataSource = dataTable1;
            }
            this.editDgvList.DataSource = (object)null;
            this.bsSH.Filter = "";
            this.editDgvList.DataSource = (object)this.bsSH;
            this.editDgvList.Columns[0].Width = 100;
            this.editDgvList.Columns[1].Width = 100;
            /*
            this.editDgvList.Columns[2].Width = 80;
            this.editDgvList.Columns[3].Width = 45;
            this.editDgvList.Columns[4].Width = 75;
            this.editDgvList.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.editDgvList.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.editDgvList.Columns[5].Width = 80;
            this.editDgvList.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.editDgvList.Columns[6].Visible = false;
            */
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

        private void editTxtZC_GotFocus(object sender, EventArgs e)
        {
            if (this.editDgvList.DataSource == this.bsZC)
                return;
            this.editDgvList.DataSource = (object)null;
            this.bsZC.Filter = "";
            this.editDgvList.DataSource = (object)this.bsZC;
            this.editDgvList.Columns[0].Width = 50;
            this.editDgvList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.editDgvList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void editTxtJH_GotFocus(object sender, EventArgs e)
        {
            if (this.editDgvList.DataSource == this.bsJH)
                return;
            this.editDgvList.DataSource = (object)null;
            this.bsJH.Filter = "";
            this.editDgvList.DataSource = (object)this.bsJH;
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
                case "editColYLDW":
                case "editColJLDW":
                    if (this.editDgvList.DataSource == this.bsYLDW)
                        break;
                    this.editDgvList.DataSource = (object)null;
                    this.editDgvList.DataSource = (object)this.bsYLDW;
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
                if (editDgvList.Rows.Count == 0) return;
                if (this.editDgvList.RowCount > 0)
                    editTxtSH.txt.Text = this.editDgvList.Rows[0].Cells[1].Value.ToString();
                this.showFromXY(Convert.ToInt64(this.editDgvList.Rows[0].Cells[6].Value));
                this.editTxtYS.txt.Focus();
            }
            else
                this.bsSH.Filter = "色号 like '" + this.editTxtSH.txt.Text + "*' or 小样单号 like '" + this.editTxtSH.txt.Text + "*'";
        }

        private void editTxtYS_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtYS.ReadOnly)
                return;
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                if (Regex.IsMatch(this.editTxtYS.txt.Text, "[A-Z0-9-]{" + this.editTxtYS.txt.Text.Length.ToString() + "}") && this.editDgvList.RowCount > 0 && this.editTxtYS.txt.Text == this.editDgvList.Rows[0].Cells[0].FormattedValue.ToString())
                    this.editTxtYS.txt.Text = this.editDgvList.Rows[0].Cells[1].FormattedValue.ToString();
                this.editTxtDDH.txt.Focus();
            }
            else
                this.bsYS.Filter = "编号 like '" + this.editTxtYS.txt.Text + "%' or 颜色 like '" + this.editTxtYS.txt.Text + "%'";
        }

        private void editTxtDDH_KeyUp(object sender, KeyEventArgs e)
        {
            //Console.WriteLine(editTxtDDH.txt.Text);
            //if (this.editTxtDDH.ReadOnly || e.KeyCode != System.Windows.Forms.Keys.Return)
            //return;90225001
            if (editTxtSH.txt.Text.Length != 0) return;
            if (editTxtDDH.txt.Text.Length != 8) return;
            /*
            if (editTxtDDH.txt.Text.Length == 0)
            {
                this.editTxtKH.txt.Text = "";
                this.editTxtSZ.txt.Text = "";
                this.editTxtSH.txt.Text = "";
                this.editTxtYS.txt.Text = "";
                this.editTxtDDH.txt.Text = "";

                this.editTxtDY.txt.Text = "";
                this.editTxtZC.txt.Text = "";
                this.editTxtDJ.txt.Text = "";
                this.editTxtKZ.txt.Text = "";
                this.editTxtMS.txt.Text = "";

                this.editTxtJH.txt.Text = "";
                this.editTxtSL.txt.Text = "";
                this.editTxtZL.txt.Text = "";
                this.editTxtBZ.txt.Text = "";
            }
            */
            string var1 = editTxtDDH.txt.Text;
            var a = db.Queryable<LCKA>().Where(b=> b.liushuihao == var1).First();
            if (a == null) return;
            else
            {
                if (a.sehao.Length == 0)
                {
                    MessageBox.Show("此缸号的色号为空，请从色号选择");
                    editTxtSH.txt.Focus();
                    return;
                }
                var b = db.Queryable<T_PFmain>()
                    .Where(it => (it.leibie == "小样单" && it.sta == YSH) && (it.sehao.Contains(a.sehao) || it.danhao.Contains(a.sehao)))
                    .ToList();

                editTxtKH.txt.Text = a.kehu;
                editTxtSZ.txt.Text = a.peiming;
                editTxtYS.txt.Text = a.sebie;
                editTxtDJ.txt.Text = a.peishu;
                editTxtKZ.txt.Text = a.kezhong;
                editTxtMS.txt.Text = a.michang;
                editTxtZL.txt.Text = a.zhongliang;
                editTxtJH.txt.Text = a.jihao;
                editTxtSH.txt.Focus();
                if (b.Count() == 0)
                {
                    MessageBox.Show("此缸号的色号不在小样配方中或者在小样配方中未审核，请检查或者从色号选择");
                    return;
                }
                if (b.Count() > 1)
                {
                    if (MessageBox.Show((IWin32Window)this, "此缸号的色号对应多个小样配方,是否删除此缸号从色号选择?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
                    {
                        editTxtDDH.txt.Text = "";
                    }
                    return;
                }
                editTxtSH.txt.Text = a.sehao;
                this.showFromXY(Convert.ToInt64(b[0].SN));


                this.editTxtDY.txt.Focus();
            }
        }

        private void editTxtDY_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtDY.ReadOnly)
                return;
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                if (Regex.IsMatch(this.editTxtDY.txt.Text, "[A-Z0-9-]{" + this.editTxtDY.txt.Text.Length.ToString() + "}") && this.editDgvList.RowCount > 0 && this.editTxtDY.txt.Text == this.editDgvList.Rows[0].Cells[0].FormattedValue.ToString())
                    this.editTxtDY.txt.Text = this.editDgvList.Rows[0].Cells[1].FormattedValue.ToString();
                this.editTxtZC.txt.Focus();
            }
            else
                this.bsDY.Filter = "编号 like '" + this.editTxtDY.txt.Text + "%' or 员工 like '" + this.editTxtDY.txt.Text + "%'";
        }

        private void editTxtZC_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtZC.ReadOnly)
                return;
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                if (Regex.IsMatch(this.editTxtZC.txt.Text, "[A-Z0-9-]{" + this.editTxtZC.txt.Text.Length.ToString() + "}") && this.editDgvList.RowCount > 0 && this.editTxtZC.txt.Text == this.editDgvList.Rows[0].Cells[0].FormattedValue.ToString())
                    this.editTxtZC.txt.Text = this.editDgvList.Rows[0].Cells[1].FormattedValue.ToString();
                this.editTxtDJ.txt.Focus();
            }
            else
                this.bsZC.Filter = "编号 like '" + this.editTxtZC.txt.Text + "%' or 员工 like '" + this.editTxtZC.txt.Text + "%'";
        }

        private void editTxtPS_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtDJ.ReadOnly || e.KeyCode != System.Windows.Forms.Keys.Return)
                return;
            this.editTxtKZ.txt.Focus();
        }

        private void eidtTxtKZ_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtKZ.ReadOnly || e.KeyCode != System.Windows.Forms.Keys.Return)
                return;
            this.editTxtMS.txt.Focus();
        }

        private void editTxtMS_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtMS.ReadOnly || e.KeyCode != System.Windows.Forms.Keys.Return)
                return;
            this.editTxtJH.txt.Focus();
        }

        private void editTxtJH_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtJH.ReadOnly)
                return;
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                if (Regex.IsMatch(this.editTxtJH.txt.Text, "[A-Z0-9-]{" + this.editTxtJH.txt.Text.Length.ToString() + "}") && this.editDgvList.RowCount > 0 && this.editTxtJH.txt.Text == this.editDgvList.Rows[0].Cells[0].FormattedValue.ToString())
                    this.editTxtSL.txt.Text = this.editDgvList.Rows[0].Cells[1].FormattedValue.ToString();
                this.editTxtSL.txt.Focus();
            }
            else
                this.bsJH.Filter = "编号 like '" + this.editTxtJH.txt.Text + "%'";
        }

        private void editTxtSL_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtSL.ReadOnly || e.KeyCode != System.Windows.Forms.Keys.Return)
                return;
            this.editTxtZL.txt.Focus();
        }

        private void editTxtZL_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtZL.ReadOnly || e.KeyCode != System.Windows.Forms.Keys.Return)
                return;
            this.editTxtBZ.txt.Focus();
        }

        private void editTxtBZ_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.editTxtBZ.ReadOnly)
                ;
        }
        private void getZL()
        {
            this.editTxtZL.txt.Text = ((this.editTxtKZ.txt.Text == "" ? new Decimal(0) : Convert.ToDecimal(this.editTxtKZ.txt.Text)) * (this.editTxtMS.txt.Text == "" ? new Decimal(0) : Convert.ToDecimal(this.editTxtMS.txt.Text)) / new Decimal(1000)).ToString("0.###;-0.###;\"\"");
        }
        private void editTxtKZ_Validated(object sender, EventArgs e)
        {
            if (this.editTxtKZ.ReadOnly)
                return;
            this.getZL();
            for (int rowidx = 0; rowidx < this.editDgvMain.RowCount; ++rowidx)
            {
                if (this.editDgvMain.Rows[rowidx].Cells[this.editColBLDW.Name].FormattedValue.ToString() == "owf")
                    this.getYL(rowidx);
            }
        }

        private void editTxtMS_Validated(object sender, EventArgs e)
        {
            if (this.editTxtMS.ReadOnly)
                return;
            this.getZL();
            for (int rowidx = 0; rowidx < this.editDgvMain.RowCount; ++rowidx)
            {
                if (this.editDgvMain.Rows[rowidx].Cells[this.editColBLDW.Name].FormattedValue.ToString() == "owf")
                    this.getYL(rowidx);
            }
        }

        private void editTxtSL_Validated(object sender, EventArgs e)
        {
            if (this.editTxtSL.ReadOnly)
                return;
            for (int rowidx = 0; rowidx < this.editDgvMain.RowCount; ++rowidx)
                this.getYL(rowidx);
        }

        private void editTxtZL_Validated(object sender, EventArgs e)
        {
            if (this.editTxtZL.ReadOnly)
                return;
            for (int rowidx = 0; rowidx < this.editDgvMain.RowCount; ++rowidx)
                this.getYL(rowidx);
        }

        private void editDgvMain_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (this.editDgvMain.ReadOnly || this.editDgvMain.CurrentCell == null)
                return;
            switch (this.editDgvMain.Columns[e.ColumnIndex].Name)
            {
                case "editColGX":
                case "editColRL":
                    if (!(this.editDgvMain.CurrentRow.Cells[this.editColSNld.Name].FormattedValue.ToString() != "-1"))
                        break;
                    int num1 = (int)MessageBox.Show((IWin32Window)this, "原始料单数据无法编辑!!!", "提示");
                    e.Cancel = true;
                    break;
                case "editColBL":
                case "editColBLDW":
                    if (this.ExeMode != exeMode.编辑加料)
                        break;
                    int num2 = (int)MessageBox.Show((IWin32Window)this, "加料单编辑时,该列无法编辑!!!", "提示");
                    e.Cancel = true;
                    break;
                case "editColYL":
                case "editColYLDW":
                    if (this.ExeMode == exeMode.编辑加料)
                    {
                        int num3 = (int)MessageBox.Show((IWin32Window)this, "加料单编辑时,该列无法编辑!!!", "提示");
                        e.Cancel = true;
                        break;
                    }
                    if (!(this.editDgvMain.CurrentRow.Cells[this.editColBL.Name].FormattedValue.ToString() != ""))
                        break;
                    int num4 = (int)MessageBox.Show((IWin32Window)this, "当有 <比例> 值存在时, <用量> 与 <用量单位> 无法编辑!!!", "提示");
                    e.Cancel = true;
                    break;
                case "editColJLYL":
                case "editColJLDW":
                    if (!(this.editDgvMain.CurrentRow.Cells[this.editColJL.Name].FormattedValue.ToString() != ""))
                        break;
                    int num5 = (int)MessageBox.Show((IWin32Window)this, "当有 <加料比例> 值存在时, <加料用量> 与 <加料单位> 无法编辑!!!", "提示");
                    e.Cancel = true;
                    break;
            }
        }

        private void editDgvMain_cellKeyUp(object sender, KeyEventArgs e)
        {
            if (this.editDgvMain.ReadOnly || this.editDgvMain.CurrentCell == null)
                return;
            string str = this.editDgvMain.CurrentCell.EditedFormattedValue.ToString();
            switch (this.editDgvMain.Columns[this.editDgvMain.CurrentCell.ColumnIndex].Name)
            {
                case "editColGX":
                    if (!this.editDgvMain.CurrentCell.IsInEditMode)
                        break;
                    if (e.KeyCode == System.Windows.Forms.Keys.Return)
                    {
                        if (!Regex.IsMatch(str, "[A-Z0-9-]{" + str.Length.ToString() + "}") || this.editDgvList.RowCount <= 0 || !(str == this.editDgvList.Rows[0].Cells[0].FormattedValue.ToString()))
                            break;
                        this.editDgvMain.EndEdit();
                        this.editDgvMain.CurrentCell.Value = (object)this.editDgvList.Rows[0].Cells[1].FormattedValue.ToString();
                        break;
                    }
                    this.bsGX.Filter = "编号 like '" + str + "%'";
                    break;
                case "editColRL":
                    if (!this.editDgvMain.CurrentCell.IsInEditMode)
                        break;
                    if (e.KeyCode == System.Windows.Forms.Keys.Return)
                    {
                        if (!Regex.IsMatch(str, "[A-Z0-9-]{" + str.Length.ToString() + "}") || this.editDgvList.RowCount <= 0 || !(str == this.editDgvList.Rows[0].Cells[0].FormattedValue.ToString()))
                            break;
                        this.editDgvMain.EndEdit();
                        this.editDgvMain.CurrentCell.Value = (object)this.editDgvList.Rows[0].Cells[2].FormattedValue.ToString();
                        break;
                    }
                    if (!str.Contains<char>('%'))
                        this.bsRL.Filter = "编号 like '" + str + "%' or 染料简称 like '" + str + "%'";
                    break;
                case "editColBLDW":
                    if (!this.editDgvMain.CurrentCell.IsInEditMode)
                        break;
                    switch (str)
                    {
                        case "1":
                            this.editDgvMain.EndEdit();
                            this.editDgvMain.CurrentCell.Value = (object)"owf";
                            this.getYL(this.editDgvMain.CurrentCell.RowIndex);
                            return;
                        case "2":
                            this.editDgvMain.EndEdit();
                            this.editDgvMain.CurrentCell.Value = (object)"g/L";
                            this.getYL(this.editDgvMain.CurrentCell.RowIndex);
                            return;
                        case "3":
                            this.editDgvMain.EndEdit();
                            this.editDgvMain.CurrentCell.Value = (object)"mL/L";
                            this.getYL(this.editDgvMain.CurrentCell.RowIndex);
                            return;
                        case null:
                            return;
                        default:
                            return;
                    }
                case "editColYLDW":
                case "editColJLDW":
                    if (!this.editDgvMain.CurrentCell.IsInEditMode)
                        break;
                    switch (str)
                    {
                        case "1":
                            this.editDgvMain.EndEdit();
                            this.editDgvMain.CurrentCell.Value = (object)"g";
                            return;
                        case "2":
                            this.editDgvMain.EndEdit();
                            this.editDgvMain.CurrentCell.Value = (object)"Kg";
                            return;
                        case "3":
                            this.editDgvMain.EndEdit();
                            this.editDgvMain.CurrentCell.Value = (object)"mL";
                            return;
                        case "4":
                            this.editDgvMain.EndEdit();
                            this.editDgvMain.CurrentCell.Value = (object)"L";
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
                    this.editDgvMain.Rows[this.editDgvMain.RowCount - 1].Cells[this.editColSNld.Name].Value = (object)-1;
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
                case "editColYL":
                    if (UserProc.IsNumeric(str) && !(Convert.ToDecimal(str) < new Decimal(0)))
                        break;
                    int num3 = (int)MessageBox.Show((IWin32Window)this, "请输入正确 <用量>( >=0数值 )!!!", "提示");
                    e.Cancel = true;
                    break;
                case "editColYLDW":
                    if (!(str != "g") || !(str != "Kg") || !(str != "mL") || !(str != "L"))
                        break;
                    int num4 = (int)MessageBox.Show((IWin32Window)this, "请输入正确 <用量单位>!!!", "提示");
                    e.Cancel = true;
                    break;
                case "editColJL":
                    if (UserProc.IsNumeric(str) && !(Convert.ToDecimal(str) < new Decimal(0)))
                        break;
                    int num5 = (int)MessageBox.Show((IWin32Window)this, "请输入正确 <加料占比>( >= 0数值 )!!!", "提示");
                    e.Cancel = true;
                    break;
                case "editColJLYL":
                    if (UserProc.IsNumeric(str) && !(Convert.ToDecimal(str) < new Decimal(0)))
                        break;
                    int num6 = (int)MessageBox.Show((IWin32Window)this, "请输入正确 <加料用量>( >=0数值 )!!!", "提示");
                    e.Cancel = true;
                    break;
                case "editColJLDW":
                    if (!(str != "g") || !(str != "Kg") || !(str != "mL") || !(str != "L"))
                        break;
                    int num7 = (int)MessageBox.Show((IWin32Window)this, "请输入正确 <加料单位>!!!", "提示");
                    e.Cancel = true;
                    break;
            }
        }

        private void editDgvMain_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (this.editDgvMain.ReadOnly || this.editDgvMain.CurrentCell == null || !this.editDgvMain.CurrentCell.IsInEditMode)
                return;
            switch (this.editDgvMain.Columns[e.ColumnIndex].Name)
            {
                case "editColBL":
                case "editColBLDW":
                    this.getYL(e.RowIndex);
                    break;
                case "editColJL":
                    this.getJL(e.RowIndex);
                    break;
            }
        }
        private void getJL(int rowidx)
        {
            Decimal num1 = this.editDgvMain.Rows[rowidx].Cells[this.editColYL.Name].FormattedValue.ToString() == "" ? new Decimal(0) : Convert.ToDecimal(this.editDgvMain.Rows[rowidx].Cells[this.editColYL.Name].FormattedValue.ToString());
            string str1 = this.editDgvMain.Rows[rowidx].Cells[this.editColYLDW.Name].FormattedValue.ToString();
            Decimal num2 = this.editDgvMain.Rows[rowidx].Cells[this.editColJL.Name].FormattedValue.ToString() == "" ? new Decimal(0) : Convert.ToDecimal(this.editDgvMain.Rows[rowidx].Cells[this.editColJL.Name].FormattedValue.ToString());
            Decimal num3 = new Decimal(0);
            Decimal d = num1 * num2 / new Decimal(100);
            if (str1 == "Kg" || str1 == "L")
                d *= new Decimal(1000);
            string str2 = !(str1 == "") ? (!(str1 == "g") && !(str1 == "Kg") ? "mL" : "g") : "";
            if (d == new Decimal(0))
                str2 = "";
            Decimal num4 = !(str2 == "g") && !(str2 == "mL") ? Math.Round(d, 1) : (!(d >= (Decimal)Convert.ToInt16(Settings.Default.PFroundYL)) ? Math.Round(d, 1) : Math.Round(d, 1));
            this.editDgvMain.Rows[rowidx].Cells[this.editColJLYL.Name].Value = (object)num4;
            this.editDgvMain.Rows[rowidx].Cells[this.editColJLDW.Name].Value = (object)str2;
        }
        private void editDgvMain_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex < 0 || this.editImgLDH.Tag==null|| this.editImgLDH.Tag.ToString().Length == 10 || !(this.editDgvMain.Rows[e.RowIndex].Cells[this.editColSNld.Name].FormattedValue.ToString() == "-1"))
                return;
            this.editDgvMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = UserProc.colorWSH;
        }


        private void refOne()
        {
            DataTable dataTable1 = new DataTable("tblBLDW");
            dataTable1.Columns.Add(new DataColumn("编号", typeof(string)));
            dataTable1.Columns.Add(new DataColumn("浓度单位", typeof(string)));
            dataTable1.Rows.Add((object)"1", (object)"owf");
            dataTable1.Rows.Add((object)"2", (object)"g/L");
            dataTable1.Rows.Add((object)"3", (object)"mL/L");
            dataTable1.Rows.Add((object)"4", (object)"g");
            dataTable1.Rows.Add((object)"5", (object)"Kg");
            this.bsBLDW.DataSource = (object)dataTable1;
            dataTable1.Dispose();
            DataTable dataTable2 = new DataTable("tblYLDW");
            dataTable2.Columns.Add(new DataColumn("编号", typeof(string)));
            dataTable2.Columns.Add(new DataColumn("用量单位", typeof(string)));
            dataTable2.Rows.Add((object)"1", (object)"g");
            dataTable2.Rows.Add((object)"2", (object)"Kg");
            dataTable2.Rows.Add((object)"3", (object)"mL");
            dataTable2.Rows.Add((object)"4", (object)"L");
            this.bsYLDW.DataSource = (object)dataTable2;
            dataTable2.Dispose();
        }

        private void dgvSum()
        {
            this.mainColSZ.Tag = (object)"行:";
            this.mainColZL.Tag = (object)"sum";
        }
        private void refSch()
        {
            this.schKH.cobodgv.RefList(coboDGV.leibie.客户);
            this.schSZ.cobodgv.RefList(coboDGV.leibie.纱种);
            this.schJH.cobodgv.RefList(coboDGV.leibie.机号);
            //this.schSH.cobodgv.RefList(coboDGV.leibie.色号);
        }
        private void btnSch_Click(object sender, EventArgs e)
        {
            this.schData();
            this.lblwait.showme();
            this.refData();
            this.lblwait.hideme();
        }


        private void editBtnJL_Click(object sender, EventArgs e)
        {
            /*
            if (!this.strQX.Contains("加料管理"))
            {
                int num1 = (int)MessageBox.Show((IWin32Window)this, "权限不足!!!", "提示");
            }
            else
            */
            {
                var asd = db.Queryable<T_PFmain>()
                    .Where(a => a.danhao.StartsWith(this.editImgLDH.Tag.ToString().Substring(0, 10)) && a.sta == WSH)
                    .ToList();
                if (asd.Count < 0)
                {
                    int num2 = (int)MessageBox.Show((IWin32Window)this, "前期存在未审核原配方或加料单!请核查!", "提示");
                }
                else
                {
                    ExeMode = exeMode.编辑加料;
                    this.editBtnSave.Text = "保存";
                    for (int index = 0; index < this.editDgvMain.RowCount; ++index)
                    {
                        this.editDgvMain.Rows[index].Cells[this.editColJL.Name].Value = (object)0;
                        this.editDgvMain.Rows[index].Cells[this.editColJLYL.Name].Value = (object)0;
                        this.editDgvMain.Rows[index].Cells[this.editColJLDW.Name].Value = (object)"";
                        this.editDgvMain.Rows[index].Cells[this.editColSNld.Name].Value = this.editDgvMain.Rows[index].Cells[this.editColSN.Name].Value;
                    }
                    this.refList();
                    if (!this.getLDH())
                    {
                        this.editTxtJLCS.txt.Text = "";
                        int num2 = (int)MessageBox.Show((IWin32Window)this, "单号生成失败,请检查!!!", "提示");
                    }
                    else
                        this.editTxtJLCS.txt.Text = Convert.ToInt16(this.editImgLDH.Tag.ToString().Substring(10)).ToString();
                    this.editDgvMain.CurrentCell = this.editDgvMain.Rows[0].Cells[0];
                    this.editDgvMain.Focus();
                }
            }
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
            if (this.editDgvMain.CurrentRow.Cells[this.editColSNld.Name].FormattedValue.ToString() != "-1")
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "原始料单数据无法删除!!!", "提示");
            }
            else
            {
                if (this.editDgvMain.CurrentRow == null || MessageBox.Show((IWin32Window)this, "删除本行数据吗?不可逆转!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                this.editDgvMain.Rows.Remove(this.editDgvMain.CurrentRow);
            }
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
            this.editDgvMain.CurrentRow.Cells[this.editColSNld.Name].Value = (object)-1;
            this.editDgvMain.Focus();
        }
        private void editBtnNewNow_Click(object sender, EventArgs e)
        {
            /*
            if (!this.strQX.Contains("料单管理"))
            {
                int num1 = (int)MessageBox.Show((IWin32Window)this, "权限不足!!!", "提示");
            }
            else
            */
            {
                this.ExeMode = exeMode.编辑料单;
                this.editBtnSave.Text = "保存";
                for (int index = 0; index < this.editDgvMain.RowCount; ++index)
                {
                    this.editDgvMain.Rows[index].Cells[this.editColSN.Name].Value = (object)-1;
                    this.editDgvMain.Rows[index].Cells[this.editColSNld.Name].Value = (object)-1;
                }
                this.refList();
                if (!this.getLDH())
                {
                    int num2 = (int)MessageBox.Show((IWin32Window)this, "单号生成失败,请检查!!!", "提示");
                }
                this.editTxtKH.txt.Focus();
            }
        }
        private void editBtnEdit_Click(object sender, EventArgs e)
        {
            /*
            if (this.editImgLDH.Tag.ToString().Length == 10 && !this.strQX.Contains("料单管理"))
            {
                int num1 = (int)MessageBox.Show((IWin32Window)this, "权限不足!!!", "提示");
            }
            else if (this.editImgLDH.Tag.ToString().Length > 10 && !this.strQX.Contains("加料管理"))
            {
                int num2 = (int)MessageBox.Show((IWin32Window)this, "权限不足!!!", "提示");
            }
            else
            */
            {
                var tPfmain = db.Queryable<T_PFmain>()
                    .Where(a => a.danhao == this.editImgLDH.Tag.ToString())
                    .First();
                if (tPfmain == null || tPfmain.sta != this.editLblStaLD.Text)
                {
                    int num3 = (int)MessageBox.Show((IWin32Window)this, "本料单已不存在或料单状态发生改变!请核查!", "提示");
                }
                else
                {
                    if (this.editImgLDH.Tag.ToString().Length == 10)
                    {
                        this.ExeMode = exeMode.编辑料单;
                        for (int index = 0; index < this.editDgvMain.RowCount; ++index)
                        {
                            this.editDgvMain.Rows[index].Cells[this.editColSN.Name].Value = (object)-1;
                            this.editDgvMain.Rows[index].Cells[this.editColSNld.Name].Value = (object)-1;
                        }
                    }
                    else
                    {
                        this.ExeMode = exeMode.编辑加料;
                        for (int index = 0; index < this.editDgvMain.RowCount; ++index)
                            this.editDgvMain.Rows[index].Cells[this.editColSN.Name].Value = (object)-1;
                    }
                    this.editBtnSave.Text = "修改";
                    this.refList();
                    this.editTxtKH.txt.Focus();
                }
            }
        }
        private void editBtnDel_Click(object sender, EventArgs e)
        {
            /*
            if (this.editImgLDH.Tag.ToString().Length == 10 && !this.strQX.Contains("料单管理"))
            {
                int num1 = (int)MessageBox.Show((IWin32Window)this, "权限不足!!!", "提示");
            }
            else if (this.editImgLDH.Tag.ToString().Length > 10 && !this.strQX.Contains("加料管理"))
            {
                int num2 = (int)MessageBox.Show((IWin32Window)this, "权限不足!!!", "提示");
            }
            else
            */
            {
                if (MessageBox.Show((IWin32Window)this, "确定删除本料单吗?将不可恢复!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                var tPfmain = db.Queryable<T_PFmain>()
                    .Where(a => a.danhao == this.editImgLDH.Tag.ToString())
                    .First();
                if (tPfmain == null || tPfmain.sta != this.editLblStaLD.Text)
                {
                    int num3 = (int)MessageBox.Show((IWin32Window)this, "本料单已不存在或料单状态发生改变!请核查!", "提示");
                }
                else
                {
                    this.lblwait.showme();
                    tPfmain.fuhe = ClsLogUser.XinMing;
                    tPfmain.riqiShen = new DateTime?(DateTime.Now);
                    tPfmain.sta = YSC;
                    db.Updateable<T_PFmain>(tPfmain).ExecuteCommand();
                    this.showLD();
                    this.lblwait.hideme();
                    int num3 = (int)MessageBox.Show((IWin32Window)this, "删除成功!!!", "提示");
                }
            }
        }
        private void editBtnPrn_Click(object sender, EventArgs e)
        {


            var all = db.Queryable<LCKA>().Where(it => it.liushuihao == editTxtDDH.txt.Text).First();
            if (all == null)
            {
                MessageBox.Show("缸号不存在,进度不能写入", "提示");
                return;
            }

            var asdfg = db.Queryable<BaseIList>()
                .Where(it => it.leibie == "产量登记" && it.item1 == "开单" && it.dingdanhao == editTxtDDH.txt.Text)
                .First();

            if (asdfg == null)
            {
                var sd = new BaseIList()
                {
                    leibie = "产量登记",
                    dingdanhao = editTxtDDH.txt.Text,
                    pingmin = editTxtSZ.txt.Text,
                    seming = editTxtYS.txt.Text,
                    sehao = editTxtSH.txt.Text,
                    item0 = ClsLogUser.XinMing,//操作人员
                    pishu = editTxtDJ.txt.Text,
                    item1 = "开单",//工序
                    zongliang = all.zhongliang,
                    item2 = "0%",//百分比
                    riqi = DateTime.Now,
                    item3 = "开单",
                    kehu = all.kehu,
                };
                db.Insertable<BaseIList>(sd).ExecuteCommand();
            }



            if (this.showLDH == "")
                return;
            this.lblwait.showme();
            FrmPrn frmPrn = new FrmPrn();
            int num1 = this.showLDH.StartsWith("LD") ? 0 : (this.showLDH.Length != 10 ? 1 : (!this.showLDH.StartsWith("8") ? 1 : 0));
            frmPrn.rptView.LocalReport.ReportEmbeddedResource = num1 != 0 ? "DotNetBarProject.view.RDLC.rptJLD.rdlc" : "DotNetBarProject.view.RDLC.rptLD.rdlc";
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
            frmPrn.rptView.LocalReport.SetParameters((IEnumerable<ReportParameter>) new ReportParameter[2]
            {
                reportParameter1,
                reportParameter2
            });
            frmPrn.rptView.RefreshReport();
            int num2 = (int)frmPrn.ShowDialog();
            frmPrn.Close();
            this.lblwait.hideme();
        }
        private void editBtnNew_Click(object sender, EventArgs e)
        {
            //if (!this.strQX.Contains("料单管理"))
            //{
            //    int num1 = (int)MessageBox.Show((IWin32Window)this, "权限不足!!!", "提示");
            //}
            //else
            {
                this.ExeMode = exeMode.编辑料单;
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
        private void editBtnSH_Click(object sender, EventArgs e)
        {
            /*
            if (!this.strQX.Contains("审核"))
            {
                int num1 = (int)MessageBox.Show((IWin32Window)this, "权限不足!!!", "提示");
            }
            else
            */
            {
                this.lblwait.showme();
                T_PFmain row = db.Queryable<T_PFmain>()
                    .Where(a => a.danhao == this.editImgLDH.Tag.ToString())
                    .First();
                if (row == null || row.sta != this.editLblStaLD.Text)
                {
                    this.lblwait.hideme();
                    int num2 = (int)MessageBox.Show((IWin32Window)this, "本料单已不存在或料单状态发生改变!请核查!", "提示");
                }
                else
                {
                    bool flag = false;
                    string str;
                    if (row.sta == WSH)
                    {
                        for (int index = 0; index < this.editDgvMain.RowCount; ++index)
                        {
                            if (this.editImgLDH.Tag.ToString().Length == 10)
                            {
                                if (this.editDgvMain.Rows[index].Cells[this.editColYL.Name].FormattedValue.ToString() == "" || this.editDgvMain.Rows[index].Cells[this.editColYLDW.Name].FormattedValue.ToString() == "")
                                {
                                    this.lblwait.hideme();
                                    this.editDgvMain.CurrentCell = this.editDgvMain.Rows[index].Cells[this.editColYL.Name];
                                    int num2 = (int)MessageBox.Show((IWin32Window)this, "用量或用量单位不存在,无法审核 !!!", "提示");
                                    this.editDgvMain.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                if (this.editDgvMain.Rows[index].Cells[this.editColJLYL.Name].FormattedValue.ToString() != "" != (this.editDgvMain.Rows[index].Cells[this.editColJLDW.Name].FormattedValue.ToString() != ""))
                                {
                                    this.lblwait.hideme();
                                    this.editDgvMain.CurrentCell = this.editDgvMain.Rows[index].Cells[this.editColJLYL.Name];
                                    int num2 = (int)MessageBox.Show((IWin32Window)this, "加料用量或加料单位须同时存在或不存在,无法审核 !!!", "提示");
                                    this.editDgvMain.Focus();
                                    return;
                                }
                                if (this.editDgvMain.Rows[index].Cells[this.editColJLYL.Name].FormattedValue.ToString() != "" && this.editDgvMain.Rows[index].Cells[this.editColJLDW.Name].FormattedValue.ToString() != "")
                                    flag = true;
                            }
                        }
                        if (this.editImgLDH.Tag.ToString().Length > 10 && !flag)
                        {
                            this.lblwait.hideme();
                            int num2 = (int)MessageBox.Show((IWin32Window)this, "加料数据不存在,无法审核 !!!", "提示");
                            return;
                        }
                        row.fuhe = ClsLogUser.XinMing;
                        row.riqiShen = new DateTime?(DateTime.Now);
                        row.sta = YSH;
                        str = "审核";
                    }
                    else
                    {
                        var aa = db.Queryable<T_PFmain>()
                            .Where(a => a.danhao.StartsWith(row.danhao.Substring(0, 10)) && Convert.ToInt64(a.danhao) > Convert.ToInt64(row.danhao) && a.sta != YSC)
                            .ToList();
                        if (aa.Count > 0)
                        {
                            this.lblwait.hideme();
                            int num2 = (int)MessageBox.Show((IWin32Window)this, "存在后续未删除加料单,不得更改!请核查!", "提示");
                            return;
                        }
                        var bb = db.Queryable<T_PFcheng>()
                           .Where(a => a.danhao == row.danhao)
                           .ToList();
                        if (bb.Count() > 0)
                        {
                            this.lblwait.hideme();
                            int num2 = (int)MessageBox.Show((IWin32Window)this, "已称料,不得更改!请核查!", "提示");
                            return;
                        }
                        row.fuhe = "";
                        row.riqiShen = new DateTime?();
                        row.sta = WSH;
                        str = "消审";
                    }
                    try
                    {
                        this.showLD();
                        if (str == "审核")
                        {
                            

                            db.Insertable<T_PFshijian>(new T_PFshijian()
                            {
                                danhao = row.danhao,
                                shijian = "审核通过",
                                riqiSJ = DateTime.Now,
                                prnOK = "",
                                riqiPRN = new DateTime?()
                            }).ExecuteCommand();
                        }
                        else
                        {
                            var ad = db.Queryable<T_PFshijian>().Where(it => it.prnOK == "" && it.danhao == row.danhao).First();
                            if (ad == null)
                            {
                            }
                            else
                            {
                                ad.prnOK = "无需打印";
                                ad.riqiPRN = DateTime.Now;
                                var aa = db.Updateable<T_PFshijian>(ad).ExecuteCommand();
                            }
                        }
                        db.Updateable<T_PFmain>(row).ExecuteCommand();
                        this.lblwait.hideme();
                        int num2 = (int)MessageBox.Show((IWin32Window)this, str + " 成功!!!", "提示");
                        if (str == "审核")
                        {
                            this.editBtnSH.Text = "消审";
                            this.editBtnSH.Enabled = true;
                            this.editBtnPrn.Enabled = true;
                            this.editBtnJL.Enabled = true;
                            this.editBtnEdit.Enabled = false;
                            this.editBtnDel.Enabled = false;
                            editLblStaLD.Text = "已审核";
                        }
                        else
                        {
                            this.editBtnSH.Text = "审核";
                            this.editBtnSH.Enabled = true;
                            this.editBtnPrn.Enabled = false;
                            this.editBtnEdit.Enabled = true;
                            this.editBtnJL.Enabled = false;
                            this.editBtnDel.Enabled = true;
                            editLblStaLD.Text = "未审核";
                        }
                    }
                    catch (Exception ex)
                    {
                        this.lblwait.hideme();
                        int num2 = (int)MessageBox.Show((IWin32Window)this, ex.Message + "\r\n\r\n请核对!!!", "提示");
                    }
                }
            }
        }
        private void editBtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show((IWin32Window)this, "确认取消吗 ?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;
            if (this.showLD())
            {
                if ((long)this.editDgvMain.Rows[0].Cells[this.editColSNld.Name].Value == -1L)
                    this.ExeMode = exeMode.显示料单;
                else
                    this.ExeMode = exeMode.显示加料;
            }
            else
                this.ExeMode = exeMode.显示料单;
        }
        private bool yanzheng()
        {
            this.bsGX.Filter = "";
            this.bsRL.Filter = "";
            if (this.editDgvMain.RowCount == 0)
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "无配方数据,请核对!!!", "提示");
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
                string str4 = this.editDgvMain.Rows[index].Cells[this.editColYLDW.Name].FormattedValue.ToString();
                if (this.editDgvMain.Rows[index].Cells[this.editColYL.Name].FormattedValue.ToString() != "" && str4 == "")
                {
                    this.editDgvMain.CurrentCell = this.editDgvMain.Rows[index].Cells[this.editColYLDW.Name];
                    int num = (int)MessageBox.Show((IWin32Window)this, "请输入 用量单位 !!!", "提示");
                    this.editDgvMain.Focus();
                    return false;
                }
                if (str4 != "" && str4 != "g" && (str4 != "Kg" && str4 != "mL") && str4 != "L")
                {
                    this.editDgvMain.CurrentCell = this.editDgvMain.Rows[index].Cells[this.editColBLDW.Name];
                    int num = (int)MessageBox.Show((IWin32Window)this, "请输入正确 用量单位 !!!", "提示");
                    this.editDgvMain.Focus();
                    return false;
                }
                string str5 = this.editDgvMain.Rows[index].Cells[this.editColJLDW.Name].FormattedValue.ToString();
                if (this.editDgvMain.Rows[index].Cells[this.editColJL.Name].FormattedValue.ToString() != "" && str5 == "")
                {
                    this.editDgvMain.CurrentCell = this.editDgvMain.Rows[index].Cells[this.editColJLDW.Name];
                    int num = (int)MessageBox.Show((IWin32Window)this, "请输入 加料单位 !!!", "提示");
                    this.editDgvMain.Focus();
                    return false;
                }
                if (str5 != "" && str5 != "g" && (str5 != "Kg" && str5 != "mL") && str5 != "L")
                {
                    this.editDgvMain.CurrentCell = this.editDgvMain.Rows[index].Cells[this.editColJLDW.Name];
                    int num = (int)MessageBox.Show((IWin32Window)this, "请输入正确 加料单位 !!!", "提示");
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
                    this.showLD();
                    this.ExeMode = (long)this.editDgvMain.Rows[0].Cells[this.editColSNld.Name].Value != -1L ? exeMode.显示加料 : exeMode.显示料单;
                    int num = (int)MessageBox.Show((IWin32Window)this, "保存成功!!!", "提示");
                }
            }
            else if (this.editBtnSave.Text == "修改" && this.editLD())
            {
                this.showLDH = this.editImgLDH.Tag.ToString();
                this.showLD();
                this.ExeMode = (long)this.editDgvMain.Rows[0].Cells[this.editColSNld.Name].Value != -1L ? exeMode.显示加料 : exeMode.显示料单;
                int num = (int)MessageBox.Show((IWin32Window)this, "修改成功!!!", "提示");
            }
            this.lblwait.hideme();
        }

        private bool saveLD()
        {
            if (!this.getLDH() || this.editImgLDH.Image == null || this.editImgLDH.Tag == null)
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "生成单号失败,请检查!!!", "提示");
                return false;
            }
            if (this.ExeMode == exeMode.编辑料单)
                this.editTxtJLCS.txt.Text = "0";
            if (this.ExeMode == exeMode.编辑加料)
            {
                var aa = db.Queryable<T_PFmain>()
                    .Where(a => a.danhao.StartsWith(this.editImgLDH.Tag.ToString().Substring(0, 10)) && a.sta == WSH)
                    .ToList();
                if (aa.Count > 0)
                {
                    int num = (int)MessageBox.Show((IWin32Window)this, "前期存在未审核原配方或加料单!请核查!", "提示");
                    return false;
                }
                this.editTxtJLCS.txt.Text = this.editImgLDH.Tag.ToString().Substring(10);
            }
            try
            {
                //using (TransactionScope transactionScope = new TransactionScope())
                {
                    T_PFmain entity = new T_PFmain()
                    {
                        leibie = "生产单",
                        danhao = this.editImgLDH.Tag.ToString(),
                        ganghao = this.editImgLDH.Tag.ToString().Substring(0, 10),
                        JLci = 0,
                        shazhong = this.editTxtSZ.txt.Text,
                        guige = "",
                        pihao = "",
                        kehu = this.editTxtKH.txt.Text,
                        dingdan = this.editTxtDDH.txt.Text,
                        sehao = this.editTxtSH.txt.Text,
                        yanse = this.editTxtYS.txt.Text,
                        jihao = this.editTxtJH.txt.Text,
                        shuiliang = this.editTxtSL.txt.Text == "" ? new Decimal(0) : Convert.ToDecimal(this.editTxtSL.txt.Text),
                        zhongliang = this.editTxtZL.txt.Text == "" ? new Decimal(0) : Convert.ToDecimal(this.editTxtZL.txt.Text),
                        jiagong = "",
                        yewuyuan = "",
                        dayang = this.editTxtDY.txt.Text,
                        zhuche = this.editTxtZC.txt.Text,
                        peifang = ClsLogUser.XinMing,
                        fuhe = "",
                        mishu = this.editTxtMS.txt.Text == "" ? new Decimal(0) : Convert.ToDecimal(this.editTxtMS.txt.Text),
                        kezhong = this.editTxtKZ.txt.Text == "" ? "0" : this.editTxtKZ.txt.Text,
                        danjia = this.editTxtDJ.txt.Text == "" ? new Decimal(0) : Convert.ToDecimal(this.editTxtDJ.txt.Text),
                        beizhu = this.editTxtBZ.txt.Text,
                        riqiSave = new DateTime?(DateTime.Now),
                        riqiShen = new DateTime?(),
                        riqiCheng = new DateTime?(),
                        JLciHJ = (int)Convert.ToInt16(this.editTxtJLCS.txt.Text),
                        sta = WSH,
                        editrec = DateTime.Now.ToString("yy-MM-dd HH:mm") + ClsLogUser.XinMing + "建立。"
                    };
                    db.Insertable<T_PFmain>(entity).ExecuteCommand();

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
                            yongliang = this.editDgvMain.Rows[index].Cells[this.editColYL.Name].FormattedValue.ToString() == "" ? new Decimal(0) : Convert.ToDecimal(this.editDgvMain.Rows[index].Cells[this.editColYL.Name].FormattedValue.ToString()),
                            yongliangDW = this.editDgvMain.Rows[index].Cells[this.editColYLDW.Name].FormattedValue.ToString(),
                            yaoqiu = this.editDgvMain.Rows[index].Cells[this.editColGY.Name].FormattedValue.ToString(),
                            JLbili = this.editDgvMain.Rows[index].Cells[this.editColJL.Name].FormattedValue.ToString() == "" ? new Decimal(0) : Convert.ToDecimal(this.editDgvMain.Rows[index].Cells[this.editColJL.Name].FormattedValue.ToString()),
                            JLyongliang = this.editDgvMain.Rows[index].Cells[this.editColJLYL.Name].FormattedValue.ToString() == "" ? new Decimal(0) : Convert.ToDecimal(this.editDgvMain.Rows[index].Cells[this.editColJLYL.Name].FormattedValue.ToString()),
                            JLyongliangDW = this.editDgvMain.Rows[index].Cells[this.editColJLDW.Name].FormattedValue.ToString(),
                            SNld = Convert.ToInt64(this.editDgvMain.Rows[index].Cells[this.editColSNld.Name].FormattedValue.ToString())
                        }).ExecuteCommand();
                    }
                    db.Ado.ExecuteCommand("update T_PFmain set JLciHJ = " + this.editTxtJLCS.txt.Text + " where danhao like '" + this.editImgLDH.Tag.ToString().Substring(0, 10) + "%'");
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
            T_PFmain rowmain = db.Queryable<T_PFmain>()
                .Where(a => a.danhao == this.editImgLDH.Tag.ToString())
                .First();
            if (rowmain == null || rowmain.sta != this.editLblStaLD.Text)
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "本料单已不存在或料单状态发生改变!请核查!", "提示");
                return false;
            }
            try
            {
                //using (TransactionScope transactionScope = new TransactionScope())
                {
                    rowmain.kehu = this.editTxtKH.txt.Text;
                    rowmain.shazhong = this.editTxtSZ.txt.Text;
                    rowmain.sehao = this.editTxtSH.txt.Text;
                    rowmain.yanse = this.editTxtYS.txt.Text;
                    rowmain.dingdan = this.editTxtDDH.txt.Text;
                    rowmain.dayang = this.editTxtDY.txt.Text;
                    rowmain.zhuche = this.editTxtZC.txt.Text;
                    rowmain.danjia = this.editTxtDJ.txt.Text == "" ? new Decimal(0) : Convert.ToDecimal(this.editTxtDJ.txt.Text);
                    rowmain.kezhong = this.editTxtKZ.txt.Text == "" ? "0" : this.editTxtKZ.txt.Text;
                    rowmain.mishu = this.editTxtMS.txt.Text == "" ? new Decimal(0) : Convert.ToDecimal(this.editTxtMS.txt.Text);
                    rowmain.jihao = this.editTxtJH.txt.Text;
                    rowmain.shuiliang = this.editTxtSL.txt.Text == "" ? new Decimal(0) : Convert.ToDecimal(this.editTxtSL.txt.Text);
                    rowmain.zhongliang = this.editTxtZL.txt.Text == "" ? new Decimal(0) : Convert.ToDecimal(this.editTxtZL.txt.Text);
                    rowmain.beizhu = this.editTxtBZ.txt.Text;
                    rowmain.peifang = ClsLogUser.XinMing;
                    rowmain.riqiSave = new DateTime?(DateTime.Now);
                    rowmain.editrec = rowmain.editrec + DateTime.Now.ToString("yy-MM-dd HH:mm") + ClsLogUser.XinMing + "修改。";
                    db.Updateable<T_PFmain>(rowmain).ExecuteCommand();

                    db.Deleteable<T_PFdata>()
                        .Where(a => a.danhao == rowmain.danhao)
                        .ExecuteCommand();
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
                            yongliang = this.editDgvMain.Rows[index].Cells[this.editColYL.Name].FormattedValue.ToString() == "" ? new Decimal(0) : Convert.ToDecimal(this.editDgvMain.Rows[index].Cells[this.editColYL.Name].FormattedValue.ToString()),
                            yongliangDW = this.editDgvMain.Rows[index].Cells[this.editColYLDW.Name].FormattedValue.ToString(),
                            yaoqiu = this.editDgvMain.Rows[index].Cells[this.editColGY.Name].FormattedValue.ToString(),
                            JLbili = this.editDgvMain.Rows[index].Cells[this.editColJL.Name].FormattedValue.ToString() == "" ? new Decimal(0) : Convert.ToDecimal(this.editDgvMain.Rows[index].Cells[this.editColJL.Name].FormattedValue.ToString()),
                            JLyongliang = this.editDgvMain.Rows[index].Cells[this.editColJLYL.Name].FormattedValue.ToString() == "" ? new Decimal(0) : Convert.ToDecimal(this.editDgvMain.Rows[index].Cells[this.editColJLYL.Name].FormattedValue.ToString()),
                            JLyongliangDW = this.editDgvMain.Rows[index].Cells[this.editColJLDW.Name].FormattedValue.ToString(),
                            SNld = Convert.ToInt64(this.editDgvMain.Rows[index].Cells[this.editColSNld.Name].FormattedValue.ToString())
                        }).ExecuteCommand();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show((IWin32Window)this, ex.Message + "\r\n\r\n   修改失败,请核查原因再试一次!", "提示");
                return false;
            }
        }

        private bool showLD()
        {
            this.emptyLDmain();
            this.emptyLDdata();
            this.editBtnSH.Enabled = false;
            this.editBtnPrn.Enabled = false;
            this.editBtnEdit.Enabled = false;
            this.editBtnDel.Enabled = false;
            this.editBtnJL.Enabled = false;
            if (this.showLDH == "")
                return false;
            DataTable dataTable1 = new DataTable();
            DataTable dataTable2 = new DataTable();
            //using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DBconn))
            {
                dataTable1 = db.Ado.GetDataTable("select * from T_PFmain where danhao = '" + this.showLDH + "'");
                dataTable2 = db.Ado.GetDataTable("select a.*,clval=(select sum(chengliang+chengmian-chengpi)/1000 from T_PFcheng where SNdata=a.SN) from T_PFdata a where a.danhao = '" + this.showLDH + "' order by a.SN");

            }
            if (dataTable1.Rows.Count != 1)
            {
                dataTable1.Dispose();
                dataTable2.Dispose();
                int num = (int)MessageBox.Show((IWin32Window)this, "无法找到此料单主数据!!!", "提示");
                return false;
            }
            if (dataTable2.Rows.Count == 0)
            {
                dataTable1.Dispose();
                dataTable2.Dispose();
                int num = (int)MessageBox.Show((IWin32Window)this, "无法找到此料单用料详细数据!!!", "提示");
                return false;
            }
            this.editImgLDH.Image = this.showLDH.Length != 11 || !this.showLDH.StartsWith("8") ? UserProc.GetBarcode(this.editImgLDH.Height, this.editImgLDH.Width, TYPE.CODE128, this.showLDH) : UserProc.GetBarcode(this.editImgLDH.Height, this.editImgLDH.Width * 62 / 100, TYPE.CODE128, this.showLDH);
            this.editImgLDH.Tag = (object)this.showLDH;
            this.editTxtKH.txt.Text = dataTable1.Rows[0].Field<string>("kehu");
            this.editTxtSZ.txt.Text = dataTable1.Rows[0].Field<string>("shazhong");
            this.editTxtSH.txt.Text = dataTable1.Rows[0].Field<string>("sehao");
            this.editTxtYS.txt.Text = dataTable1.Rows[0].Field<string>("yanse");
            this.editTxtDDH.txt.Text = dataTable1.Rows[0].Field<string>("dingdan");
            this.editTxtDY.txt.Text = dataTable1.Rows[0].Field<string>("dayang");
            this.editTxtZC.txt.Text = dataTable1.Rows[0].Field<string>("zhuche");
            this.editTxtDJ.txt.Text = dataTable1.Rows[0].Field<Decimal>("danjia").ToString("0.###;-0.###;\"\"");
            //this.editTxtKZ.txt.Text = dataTable1.Rows[0].Field<Decimal>("kezhong").ToString("0.###;-0.###;\"\"");
            TextBox txt1 = this.editTxtMS.txt;
            Decimal num1 = dataTable1.Rows[0].Field<Decimal>("mishu");
            string str1 = num1.ToString("0.###;-0.###;\"\"");
            txt1.Text = str1;
            this.editTxtJH.txt.Text = dataTable1.Rows[0].Field<string>("jihao");
            TextBox txt2 = this.editTxtSL.txt;
            num1 = dataTable1.Rows[0].Field<Decimal>("shuiliang");
            string str2 = num1.ToString("0.####;-0.####;\"\"");
            txt2.Text = str2;
            TextBox txt3 = this.editTxtZL.txt;
            num1 = dataTable1.Rows[0].Field<Decimal>("zhongliang");
            string str3 = num1.ToString("0.####;-0.####;\"\"");
            txt3.Text = str3;
            this.editTxtBZ.txt.Text = dataTable1.Rows[0].Field<string>("beizhu");
            this.editTxtJLCS.txt.Text = dataTable1.Rows[0].Field<int>("JLciHJ").ToString();
            this.editLblStaLD.Text = dataTable1.Rows[0].Field<string>("sta");
            for (int index = 0; index < dataTable2.Rows.Count; ++index)
            {
                this.editDgvMain.Rows.Add();
                DataGridViewRow row = this.editDgvMain.Rows[this.editDgvMain.RowCount - 1];
                row.Cells[this.editColSN.Name].Value = (object)dataTable2.Rows[index].Field<long>("SN");
                row.Cells[this.editColGX.Name].Value = (object)dataTable2.Rows[index].Field<string>("gongxu");
                row.Cells[this.editColRL.Name].Value = (object)dataTable2.Rows[index].Field<string>("ranliao");
                row.Cells[this.editColBL.Name].Value = (object)dataTable2.Rows[index].Field<Decimal>("bili");
                row.Cells[this.editColBLDW.Name].Value = (object)dataTable2.Rows[index].Field<string>("biliDW");
                row.Cells[this.editColYL.Name].Value = (object)dataTable2.Rows[index].Field<Decimal>("yongliang");
                row.Cells[this.editColYLDW.Name].Value = (object)dataTable2.Rows[index].Field<string>("yongliangDW");
                row.Cells[this.editColGY.Name].Value = (object)dataTable2.Rows[index].Field<string>("yaoqiu");
                row.Cells[this.editColJL.Name].Value = (object)dataTable2.Rows[index].Field<Decimal>("JLbili");
                row.Cells[this.editColJLYL.Name].Value = (object)dataTable2.Rows[index].Field<Decimal>("JLyongliang");
                row.Cells[this.editColJLDW.Name].Value = (object)dataTable2.Rows[index].Field<string>("JLyongliangDW");
                row.Cells[this.editColCLval.Name].Value = (object)dataTable2.Rows[index].Field<Decimal?>("clval");
                row.Cells[this.editColCLdw.Name].Value = (object)"Kg";
                row.Cells[this.editColSNld.Name].Value = (object)dataTable2.Rows[index].Field<long>("SNld");
            }
            if (this.editLblStaLD.Text == WSH)
            {
                this.editBtnSH.Text = "审核";
                this.editBtnSH.Enabled = true;
                this.editBtnEdit.Enabled = true;
                this.editBtnDel.Enabled = true;
            }
            else if (this.editLblStaLD.Text == YSH)
            {
                this.editBtnSH.Text = "消审";
                this.editBtnSH.Enabled = true;
                this.editBtnPrn.Enabled = true;
                this.editBtnJL.Enabled = true;
            }
            this.bsShowMain.DataSource = (object)dataTable1;
            this.bsShowData.DataSource = (object)dataTable2;
            return true;
        }
        private void emptyLDmain()
        {
            this.editImgLDH.Image = (Image)null;
            this.editImgLDH.Tag = (object)null;
            this.editTxtKH.txt.Text = "";
            this.editTxtSZ.txt.Text = "";
            this.editTxtSH.txt.Text = "";
            this.editTxtYS.txt.Text = "";
            this.editTxtDDH.txt.Text = "";
            this.editTxtDY.txt.Text = "";
            this.editTxtZC.txt.Text = "";
            this.editTxtDJ.txt.Text = "";
            this.editTxtKZ.txt.Text = "";
            this.editTxtMS.txt.Text = "";
            this.editTxtJH.txt.Text = "";
            this.editTxtSL.txt.Text = "";
            this.editTxtZL.txt.Text = "";
            this.editTxtBZ.txt.Text = "";
            this.editTxtJLCS.txt.Text = "";
            this.editLblStaLD.Text = "";
        }

        private void emptyLDdata()
        {
            this.editDgvMain.Rows.Clear();
        }
        private void refList()
        {
            //using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DBconn))
            {
                //sqlConnection.Open();
                //SqlCommand command = sqlConnection.CreateCommand();
                //command.CommandTimeout = 300;
                string a = "select 编号=bianhao,客户=itemname,全称=item0 from T_Base where leibie = '" + leibie.enumLB.客户.ToString() + "' order by 编号";
                this.bsKH.DataSource = db.Ado.GetDataTable(a);

                string b = "select 编号=bianhao,品名=itemname from T_Base where leibie = '" + leibie.enumLB.纱种.ToString() + "' order by 编号";
                this.bsSZ.DataSource = db.Ado.GetDataTable(b);

                string c = "select 编号=bianhao,颜色=itemname from T_Base where leibie = '" + leibie.enumLB.颜色.ToString() + "' order by 编号";
                this.bsYS.DataSource = db.Ado.GetDataTable(c);

                string d = "select 编号=bianhao,员工=itemname from T_Base where leibie = '" + leibie.enumLB.员工.ToString() + "' order by 编号";
                this.bsDY.DataSource = db.Ado.GetDataTable(d);

                string e = "select 编号=bianhao,员工=itemname from T_Base where leibie = '" + leibie.enumLB.员工.ToString() + "' order by 编号";
                this.bsZC.DataSource = db.Ado.GetDataTable(e);

                string f = "select 编号=bianhao,浴量=itemname from T_Base where leibie = '" + leibie.enumLB.机台浴量.ToString() + "' order by 编号";
                this.bsJH.DataSource = db.Ado.GetDataTable(f);

                string h = "select 编号=bianhao,染化类别=itemname from T_Base where leibie = '" + leibie.enumLB.染化类别.ToString() + "' order by 编号";
                this.bsGX.DataSource = db.Ado.GetDataTable(h);

                string i = "select 编号=bianhao,染料简称=item3,全称=item0,类别=itemName from T_Base where leibie = '" + leibie.enumLB.染料名称.ToString() + "' or leibie = '" + leibie.enumLB.助剂名称.ToString() + "' order by 类别,编号";
                this.bsRL.DataSource = db.Ado.GetDataTable(i);

                string CommandText = "select 客户=kehu,色号=sehao,品名=shazhong,颜色=yanse,日期=riqiSave,小样单号=danhao,SN from T_PFmain where leibie = '" + "小样单" + "' and sta = '" + YSH + "' order by 色号,日期 desc";
                this.bsSH.DataSource = db.Ado.GetDataTable(CommandText);
            }
        }
        private bool getLDH()
        {
            try
            {
                string code;
                if (this.ExeMode == exeMode.编辑料单)
                {
                    string tmpStr = "8" + DateTime.Today.ToString("yyMM");
                    var source = db.Queryable<T_PFmain>()
                        .Where(a => a.danhao.Length == 10 && a.danhao.StartsWith(tmpStr))
                        .OrderBy(a=>a.SN, OrderByType.Desc)
                        .First();

                    if (source == null)
                    {
                        code = tmpStr + "00001";
                    }
                    else
                    {
                        int int32 = Convert.ToInt32(source.danhao.Substring(5));
                        if (int32 >= 99999)
                        {
                            return false;
                        }
                        code = tmpStr + (int32 + 1).ToString("00000");
                    }
                    this.editImgLDH.Image = UserProc.GetBarcode(this.editImgLDH.Height, this.editImgLDH.Width, TYPE.CODE128, code);
                }
                else
                {
                    string tmpStr = this.editImgLDH.Tag.ToString().Substring(0, 10);
                    var source = db.Queryable<T_PFmain>()
                        .Where(a => a.danhao.StartsWith(tmpStr))
                        .OrderBy(a => a.danhao, OrderByType.Desc)
                        .ToList();

                    if (source.Count() == 1)
                    {
                        code = tmpStr + "1";
                    }
                    else
                    {
                        string danhao = source[0].danhao.Substring(10);
                        int int32 = Convert.ToInt32(danhao);
                        if (int32 >= 9)
                        {
                            return false;
                        }
                        code = tmpStr + (int32 + 1).ToString("0");
                    }
                    this.editImgLDH.Image = UserProc.GetBarcode(this.editImgLDH.Height, this.editImgLDH.Width * 62 / 100, TYPE.CODE128, code);
                }
                this.editImgLDH.Tag = (object)code;
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
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
                    case exeMode.显示加料:
                        this.editBtnNew.Visible = true;
                        this.editBtnNewNow.Visible = true;
                        this.editBtnSH.Visible = true;
                        this.editBtnPrn.Visible = true;
                        this.editBtnEdit.Visible = true;
                        this.editBtnDel.Visible = true;
                        this.editBtnSave.Visible = false;
                        this.editBtnCancel.Visible = false;
                        this.editBtnJL.Visible = true;
                        this.editBtnAddRow.Visible = false;
                        this.editBtnDelRow.Visible = false;
                        this.editBtnRowUP.Visible = false;
                        this.editBtnRowDN.Visible = false;
                        this.editLblStaLD.Visible = true;
                        this.editLblStaExe.Visible = false;
                        this.editTxtJLCS.Visible = true;
                        this.editColJL.Visible = this._ExeMode == exeMode.显示加料;
                        this.editColJLYL.Visible = this._ExeMode == exeMode.显示加料;
                        this.editColJLDW.Visible = this._ExeMode == exeMode.显示加料;
                        this.editColCLval.Visible = true;
                        this.editColCLdw.Visible = true;
                        this.editTxtKH.ReadOnly = true;
                        this.editTxtSZ.ReadOnly = true;
                        this.editTxtSH.ReadOnly = true;
                        this.editTxtYS.ReadOnly = true;
                        this.editTxtDDH.ReadOnly = true;
                        this.editTxtDY.ReadOnly = true;
                        this.editTxtZC.ReadOnly = true;
                        this.editTxtDJ.ReadOnly = true;
                        this.editTxtKZ.ReadOnly = true;
                        this.editTxtMS.ReadOnly = true;
                        this.editTxtJH.ReadOnly = true;
                        this.editTxtSL.ReadOnly = true;
                        this.editTxtZL.ReadOnly = true;
                        this.editTxtBZ.ReadOnly = true;
                        this.editDgvMain.ReadOnly = true;
                        break;
                    case exeMode.编辑料单:
                    case exeMode.编辑加料:
                        this.editBtnNew.Visible = false;
                        this.editBtnNewNow.Visible = false;
                        this.editBtnSH.Visible = false;
                        this.editBtnPrn.Visible = false;
                        this.editBtnEdit.Visible = false;
                        this.editBtnDel.Visible = false;
                        this.editBtnSave.Visible = true;
                        this.editBtnCancel.Visible = true;
                        this.editBtnJL.Visible = false;
                        this.editBtnAddRow.Visible = true;
                        this.editBtnDelRow.Visible = true;
                        this.editBtnRowUP.Visible = true;
                        this.editBtnRowDN.Visible = true;
                        this.editLblStaLD.Visible = false;
                        this.editLblStaExe.Visible = true;
                        this.editLblStaExe.Text = this._ExeMode.ToString();
                        this.editTxtJLCS.Visible = this._ExeMode == exeMode.编辑加料;
                        this.editColJL.Visible = this._ExeMode == exeMode.编辑加料;
                        this.editColJLYL.Visible = this._ExeMode == exeMode.编辑加料;
                        this.editColJLDW.Visible = this._ExeMode == exeMode.编辑加料;
                        this.editColCLval.Visible = false;
                        this.editColCLdw.Visible = false;
                        this.editTxtKH.ReadOnly = this._ExeMode == exeMode.编辑加料;
                        this.editTxtSZ.ReadOnly = this._ExeMode == exeMode.编辑加料;
                        this.editTxtSH.ReadOnly = this._ExeMode == exeMode.编辑加料;
                        this.editTxtYS.ReadOnly = this._ExeMode == exeMode.编辑加料;
                        this.editTxtDDH.ReadOnly = this._ExeMode == exeMode.编辑加料;
                        this.editTxtDY.ReadOnly = this._ExeMode == exeMode.编辑加料;
                        this.editTxtZC.ReadOnly = false;
                        this.editTxtDJ.ReadOnly = this._ExeMode == exeMode.编辑加料;
                        this.editTxtKZ.ReadOnly = this._ExeMode == exeMode.编辑加料;
                        this.editTxtMS.ReadOnly = this._ExeMode == exeMode.编辑加料;
                        this.editTxtJH.ReadOnly = this._ExeMode == exeMode.编辑加料;
                        this.editTxtSL.ReadOnly = this._ExeMode == exeMode.编辑加料;
                        this.editTxtZL.ReadOnly = this._ExeMode == exeMode.编辑加料;
                        this.editTxtBZ.ReadOnly = false;
                        this.editDgvMain.ReadOnly = false;
                        break;
                }
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
            if (this.schDH.chkSel)
                this.strSch = this.strSch + "and danhao like '" + str1 + this.schDH.txt.Text + str1 + "' ";
            if (this.schJH.chkSel)
                this.strSch = this.strSch + "and jihao like '" + this.schJH.cobodgv.Text + "' ";
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
            string str3 = "";
            if (this.schStaSH.Checked)
                str3 = str3 + "or sta = '" + YSH + "' ";
            if (this.schStaWS.Checked)
                str3 = str3 + "or sta = '" + WSH + "' ";
            if (this.schStaDel.Checked)
                str3 = str3 + "or sta = '" + YSC + "' ";
            if (str3 != "")
                this.strSch = this.strSch + "and (" + str3.Substring(2) + ") ";
            string str4 = "";
            if (this.schStaWCL.Checked != this.schStaYCL.Checked)
            {
                if (this.schStaWCL.Checked)
                    str4 += "b.chengliao = 0 ";
                if (this.schStaYCL.Checked)
                    str4 += "b.chengliao > 0 ";
            }
            if (str4 != "")
                str4 = "where " + str4;
            this.strSch = "select b.* from (select *,chengliao=(select count(*) from T_PFcheng where danhao=a.danhao),riqiCL=(select max(riqicheng) from T_PFcheng where danhao=a.danhao) from T_PFmain a  where leibie = '" + "生产单" + "' " + this.strSch + ") as b " + str4 + "order by riqiSave desc";
        }

        private void refData()
        {
            DataTable dataTable = db.Ado.GetDataTable(strSch);
            this.bsSch.DataSource = (object)dataTable;
            //this.dgvMain.DataSource = (object)this.bsSch;
            asd(dataTable);
        }
        private void asd(DataTable dataTable)
        {
            dgvMain.Rows.Clear();
            for (var i=0;i< dataTable.Rows.Count; i++)
            {
                int index = dgvMain.Rows.Add();
                dgvMain.Rows[index].Cells[mainColDH.Name].Value = dataTable.Rows[index]["danhao"];
                dgvMain.Rows[index].Cells[mainColKH.Name].Value = dataTable.Rows[index]["kehu"];
                dgvMain.Rows[index].Cells[mainColSZ.Name].Value = dataTable.Rows[index]["shazhong"];
                dgvMain.Rows[index].Cells[mainColSH.Name].Value = dataTable.Rows[index]["sehao"];
                dgvMain.Rows[index].Cells[mainColYS.Name].Value = dataTable.Rows[index]["yanse"];
                dgvMain.Rows[index].Cells[mainColDDH.Name].Value = dataTable.Rows[index]["dingdan"];
                dgvMain.Rows[index].Cells[mainColJH.Name].Value = dataTable.Rows[index]["jihao"];
                dgvMain.Rows[index].Cells[mainColZL.Name].Value = dataTable.Rows[index]["zhongliang"];
                dgvMain.Rows[index].Cells[mainColKZ.Name].Value = dataTable.Rows[index]["kezhong"];
                dgvMain.Rows[index].Cells[mainColMS.Name].Value = dataTable.Rows[index]["mishu"];
                dgvMain.Rows[index].Cells[mainColPS.Name].Value = dataTable.Rows[index]["danjia"];
                dgvMain.Rows[index].Cells[mainColJLCS.Name].Value = dataTable.Rows[index]["JLciHJ"];
                dgvMain.Rows[index].Cells[mainColRQBC.Name].Value = dataTable.Rows[index]["riqiSave"];
                dgvMain.Rows[index].Cells[mainColPF.Name].Value = dataTable.Rows[index]["peifang"];
                dgvMain.Rows[index].Cells[mainColRQSH.Name].Value = dataTable.Rows[index]["riqiShen"];
                dgvMain.Rows[index].Cells[mainColFH.Name].Value = dataTable.Rows[index]["fuhe"];
                dgvMain.Rows[index].Cells[mainColRQCL.Name].Value = dataTable.Rows[index]["riqiCL"];
                dgvMain.Rows[index].Cells[mainColSL.Name].Value = dataTable.Rows[index]["shuiliang"];
                dgvMain.Rows[index].Cells[mainColDY.Name].Value = dataTable.Rows[index]["dayang"];
                dgvMain.Rows[index].Cells[mainColZC.Name].Value = dataTable.Rows[index]["zhuche"];
                dgvMain.Rows[index].Cells[mainColBZ.Name].Value = dataTable.Rows[index]["beizhu"];
                dgvMain.Rows[index].Cells[mainColSN.Name].Value = dataTable.Rows[index]["SN"];
                dgvMain.Rows[index].Cells[mainColSta.Name].Value = dataTable.Rows[index]["sta"];
                dgvMain.Rows[index].Cells[mainColCL.Name].Value = dataTable.Rows[index]["chengliao"];
                dgvMain.Rows[index].Cells[mainColGH.Name].Value = dataTable.Rows[index]["ganghao"];
                dgvMain.Rows[index].Cells[mainColGG.Name].Value = dataTable.Rows[index]["guige"];
                dgvMain.Rows[index].Cells[mainColPH.Name].Value = dataTable.Rows[index]["pihao"];
                dgvMain.Rows[index].Cells[maiColJLCX.Name].Value = dataTable.Rows[index]["JLci"];
            }
            dgvMain.HeJi();
        }
        private void dgvMain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || this.dgvMain.CurrentRow.Index != e.RowIndex || (this.ExeMode == exeMode.编辑料单 || this.ExeMode == exeMode.编辑加料) && MessageBox.Show((IWin32Window)this, "料单编辑 正处于操作状态,显示料单信息将清除你编辑的数据,确认吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;
            this.lblwait.showme();
            this.showLDH = this.dgvMain.CurrentRow.Cells[this.mainColDH.Name].Value.ToString();
            if (this.showLD())
            {
                this.tabEx1.SelectedTab = this.tabPage2;
                this.ExeMode = !this.showLDH.StartsWith("LD") && (this.showLDH.Length != 10 || !this.showLDH.StartsWith("8")) ? exeMode.显示加料 : exeMode.显示料单;
            }
            this.lblwait.hideme();
        }
        private void dgvMain_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            string str = this.dgvMain.Rows[e.RowIndex].Cells[this.mainColSta.Name].Value.ToString();
            if (str == YSC)
            {
                this.dgvMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = UserProc.colorDel;
                this.dgvMain.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("宋体", 9f, FontStyle.Strikeout);
            }
            else if (str == WSH)
                this.dgvMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = UserProc.colorWSH;
            else if (str == YSH && (int)this.dgvMain.Rows[e.RowIndex].Cells[this.mainColCL.Name].Value > 0)
                this.dgvMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = UserProc.colorCL;
        }
        private void menuList刷新_Click(object sender, EventArgs e)
        {
            this.refSch();
            this.refList();
            this.bsKH.Filter = "";
            this.bsSZ.Filter = "";
            this.bsDY.Filter = "";
            this.bsZC.Filter = "";
            this.bsJH.Filter = "";
            this.bsGX.Filter = "";
            this.bsRL.Filter = "";
        }
        private void menu删除_Click(object sender, EventArgs e)
        {
            string tmpLDH = this.dgvMain.CurrentRow.Cells[this.mainColDH.Name].FormattedValue.ToString();
            //if (tmpLDH.Length == 10 && !this.strQX.Contains("料单管理"))
            {
            //    int num1 = (int)MessageBox.Show((IWin32Window)this, "权限不足!!!", "提示");
            }
            //else if (tmpLDH.Length > 10 && !this.strQX.Contains("加料管理"))
            {
            //    int num2 = (int)MessageBox.Show((IWin32Window)this, "权限不足!!!", "提示");
            }
            //else
            {
                if (MessageBox.Show((IWin32Window)this, "确定删除本料单吗(单号:" + tmpLDH + ")?将不可恢复!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                //DBpf dbpf = new DBpf(Settings.Default.DBconn);
                //T_PFmain tPfmain = dbpf.T_PFmain.Where<T_PFmain>((Expression<Func<T_PFmain, bool>>)(a => a.danhao == tmpLDH && a.sta != YSC)).SingleOrDefault<T_PFmain>();
                T_PFmain tPfmain = db.Queryable<T_PFmain>()
                    .Where(a => a.danhao == tmpLDH && a.sta != YSC)
                    .First();
                string sta = this.dgvMain.CurrentRow.Cells[this.mainColSta.Name].FormattedValue.ToString();
                if (tPfmain == null || sta == leibie.staPF.已审核.ToString() || sta == leibie.staPF.已删除.ToString())
                {
                    //dbpf.Dispose();
                    int num3 = (int)MessageBox.Show((IWin32Window)this, "本料单已不存在或料单状态发生改变!请核查!", "提示");
                }
                else
                {
                    this.lblwait.showme();
                    tPfmain.fuhe = ClsLogUser.XinMing;
                    tPfmain.riqiShen = new DateTime?(DateTime.Now);
                    tPfmain.sta = YSC;
                    db.Updateable<T_PFmain>(tPfmain).ExecuteCommand();
                    //dbpf.SubmitChanges();
                    //dbpf.Dispose();
                    this.refData();
                    this.lblwait.hideme();
                    int num3 = (int)MessageBox.Show((IWin32Window)this, "删除成功!!!", "提示");
                }
            }
        }
        private void menu导出Excel_Click(object sender, EventArgs e)
        {
            if (this.dgvMain.RowCount == 0)
                return;
            this.dgvMain.saveExcel("大样配方表");
        }
        private void menu打印_Click(object sender, EventArgs e)
        {
            if (this.dgvMain.RowCount == 0)
                return;
            this.dgvMain.Print("大样配方表", UserProc.CheckTime);
        }
        private enum exeMode
        {
            显示料单,
            显示加料,
            编辑料单,
            编辑加料,
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.schData();
            this.lblwait.showme();
            this.refData();
            this.lblwait.hideme();
        }
    }
}

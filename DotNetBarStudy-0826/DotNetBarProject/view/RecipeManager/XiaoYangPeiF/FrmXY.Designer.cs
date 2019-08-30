using DotNetBarProject.view.custom.view;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.RecipeManager.XiaoYangPeiF
{
    partial class FrmXY
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuList刷新 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPages = new DotNetBarProject.view.custom.view.TabEx();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.mainPanDGV = new System.Windows.Forms.Panel();
            this.mainDgv = new DotNetBarProject.view.custom.view.dgvEX();
            this.mainColBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColSZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColSH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColYS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColDDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColRQBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColRQSH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColFH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColDY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColBZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColSta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainPanSch = new System.Windows.Forms.Panel();
            this.schDDH = new DotNetBarProject.view.custom.view.ChkTxt();
            this.schDY = new DotNetBarProject.view.custom.view.ChkTxt();
            this.schDel = new System.Windows.Forms.CheckBox();
            this.schRQsave = new DotNetBarProject.view.custom.view.ChkDtime();
            this.schYS = new DotNetBarProject.view.custom.view.ChkTxt();
            this.schSH = new DotNetBarProject.view.custom.view.ChkTxt();
            this.schLD = new DotNetBarProject.view.custom.view.ChkTxt();
            this.schSZ = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.schKH = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.schMohu = new System.Windows.Forms.CheckBox();
            this.btnSch = new System.Windows.Forms.Button();
            this.tpEdit = new System.Windows.Forms.TabPage();
            this.editPanMain = new System.Windows.Forms.Panel();
            this.editDgvMain = new DotNetBarProject.view.custom.view.dgvEX();
            this.editColGX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColRL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColBL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColBLDW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColGY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editPanEdit = new System.Windows.Forms.Panel();
            this.editLblStaExe = new System.Windows.Forms.Label();
            this.editBtnRowDN = new System.Windows.Forms.Button();
            this.editBtnRowUP = new System.Windows.Forms.Button();
            this.editBtnDelRow = new System.Windows.Forms.Button();
            this.editBtnAddRow = new System.Windows.Forms.Button();
            this.editPanTop = new System.Windows.Forms.Panel();
            this.editDgvList = new DotNetBarProject.view.custom.view.dgvEX();
            this.editPanList = new System.Windows.Forms.Panel();
            this.editTxtDDH = new DotNetBarProject.view.custom.view.LblTxt();
            this.editImgLDH = new System.Windows.Forms.PictureBox();
            this.editBtnNewNow = new System.Windows.Forms.Button();
            this.editLblStaLD = new System.Windows.Forms.Label();
            this.editBtnEdit = new System.Windows.Forms.Button();
            this.editBtnDel = new System.Windows.Forms.Button();
            this.editBtnPrn = new System.Windows.Forms.Button();
            this.editBtnNew = new System.Windows.Forms.Button();
            this.editTxtBZ = new DotNetBarProject.view.custom.view.LblTxt();
            this.editBtnSH = new System.Windows.Forms.Button();
            this.editTxtDY = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtKH = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtYS = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtSZ = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtSH = new DotNetBarProject.view.custom.view.LblTxt();
            this.editBtnSave = new System.Windows.Forms.Button();
            this.editBtnCancel = new System.Windows.Forms.Button();
            this.menuList.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPages.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.mainPanDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDgv)).BeginInit();
            this.mainPanSch.SuspendLayout();
            this.tpEdit.SuspendLayout();
            this.editPanMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editDgvMain)).BeginInit();
            this.editPanEdit.SuspendLayout();
            this.editPanTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editDgvList)).BeginInit();
            this.editPanList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editImgLDH)).BeginInit();
            this.SuspendLayout();
            // 
            // menuList
            // 
            this.menuList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuList刷新});
            this.menuList.Name = "menuList";
            this.menuList.Size = new System.Drawing.Size(101, 26);
            // 
            // menuList刷新
            // 
            this.menuList刷新.Name = "menuList刷新";
            this.menuList刷新.Size = new System.Drawing.Size(100, 22);
            this.menuList刷新.Text = "刷新";
            this.menuList刷新.Click += new System.EventHandler(this.menuList刷新_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.刷新ToolStripMenuItem,
            this.toolStripSeparator1,
            this.打印ToolStripMenuItem,
            this.导出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 120);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Visible = false;
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打印ToolStripMenuItem.Text = "打印";
            this.打印ToolStripMenuItem.Click += new System.EventHandler(this.打印ToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // tabPages
            // 
            this.tabPages.Controls.Add(this.tpMain);
            this.tabPages.Controls.Add(this.tpEdit);
            this.tabPages.DisplayStyle = DotNetBarProject.view.custom.view.TabEx.enumDisplwyStyle.Angled;
            this.tabPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPages.HotTrack = true;
            this.tabPages.ItemSize = new System.Drawing.Size(180, 25);
            this.tabPages.Location = new System.Drawing.Point(0, 0);
            this.tabPages.Margin = new System.Windows.Forms.Padding(0);
            this.tabPages.Name = "tabPages";
            this.tabPages.Padding = new System.Drawing.Point(0, 0);
            this.tabPages.SelectedIndex = 0;
            this.tabPages.Size = new System.Drawing.Size(925, 450);
            this.tabPages.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabPages.TabIndex = 0;
            this.tabPages.XieLong = 12;
            this.tabPages.XieSuoLv = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // tpMain
            // 
            this.tpMain.BackColor = System.Drawing.SystemColors.Control;
            this.tpMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpMain.Controls.Add(this.mainPanDGV);
            this.tpMain.Controls.Add(this.mainPanSch);
            this.tpMain.Location = new System.Drawing.Point(4, 29);
            this.tpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(2);
            this.tpMain.Size = new System.Drawing.Size(917, 417);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "小样配方";
            // 
            // mainPanDGV
            // 
            this.mainPanDGV.Controls.Add(this.mainDgv);
            this.mainPanDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanDGV.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mainPanDGV.Location = new System.Drawing.Point(2, 78);
            this.mainPanDGV.Name = "mainPanDGV";
            this.mainPanDGV.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.mainPanDGV.Size = new System.Drawing.Size(911, 335);
            this.mainPanDGV.TabIndex = 1;
            // 
            // mainDgv
            // 
            this.mainDgv.AllowUserToAddRows = false;
            this.mainDgv.AllowUserToDeleteRows = false;
            this.mainDgv.AllowUserToResizeRows = false;
            this.mainDgv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.mainDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mainDgv.ColumnHeadersHeight = 30;
            this.mainDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.mainDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mainColBH,
            this.mainColKH,
            this.mainColSZ,
            this.mainColSH,
            this.mainColYS,
            this.mainColDDH,
            this.mainColRQBC,
            this.mainColPF,
            this.mainColRQSH,
            this.mainColFH,
            this.mainColDY,
            this.mainColBZ,
            this.mainColSN,
            this.mainColSta});
            this.mainDgv.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainDgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.mainDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.mainDgv.Location = new System.Drawing.Point(0, 2);
            this.mainDgv.MultiSelect = false;
            this.mainDgv.Name = "mainDgv";
            this.mainDgv.ReadOnly = true;
            this.mainDgv.RowHeadersWidth = 28;
            this.mainDgv.RowNumShow = false;
            this.mainDgv.RowTemplate.Height = 28;
            this.mainDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mainDgv.Size = new System.Drawing.Size(911, 333);
            this.mainDgv.TabIndex = 1;
            this.mainDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDgv_CellDoubleClick);
            this.mainDgv.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.mainDgv_CellMouseDoubleClick);
            this.mainDgv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.mainDgv_RowPostPaint);
            // 
            // mainColBH
            // 
            this.mainColBH.DataPropertyName = "danhao";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mainColBH.DefaultCellStyle = dataGridViewCellStyle2;
            this.mainColBH.HeaderText = "单号";
            this.mainColBH.MaxInputLength = 10;
            this.mainColBH.Name = "mainColBH";
            this.mainColBH.ReadOnly = true;
            this.mainColBH.Width = 75;
            // 
            // mainColKH
            // 
            this.mainColKH.DataPropertyName = "kehu";
            this.mainColKH.HeaderText = "客户";
            this.mainColKH.MaxInputLength = 10;
            this.mainColKH.Name = "mainColKH";
            this.mainColKH.ReadOnly = true;
            this.mainColKH.Width = 80;
            // 
            // mainColSZ
            // 
            this.mainColSZ.DataPropertyName = "shazhong";
            this.mainColSZ.HeaderText = "品名";
            this.mainColSZ.MaxInputLength = 5;
            this.mainColSZ.Name = "mainColSZ";
            this.mainColSZ.ReadOnly = true;
            this.mainColSZ.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.mainColSZ.Width = 120;
            // 
            // mainColSH
            // 
            this.mainColSH.DataPropertyName = "sehao";
            this.mainColSH.HeaderText = "色号";
            this.mainColSH.MaxInputLength = 10;
            this.mainColSH.Name = "mainColSH";
            this.mainColSH.ReadOnly = true;
            // 
            // mainColYS
            // 
            this.mainColYS.DataPropertyName = "yanse";
            this.mainColYS.HeaderText = "颜色";
            this.mainColYS.MaxInputLength = 5;
            this.mainColYS.Name = "mainColYS";
            this.mainColYS.ReadOnly = true;
            this.mainColYS.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.mainColYS.Width = 60;
            // 
            // mainColDDH
            // 
            this.mainColDDH.DataPropertyName = "dingdan";
            this.mainColDDH.HeaderText = "流程卡号";
            this.mainColDDH.MaxInputLength = 10;
            this.mainColDDH.Name = "mainColDDH";
            this.mainColDDH.ReadOnly = true;
            // 
            // mainColRQBC
            // 
            this.mainColRQBC.DataPropertyName = "riqiSave";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "yy-MM-dd HH:mm";
            this.mainColRQBC.DefaultCellStyle = dataGridViewCellStyle3;
            this.mainColRQBC.HeaderText = "保存日期";
            this.mainColRQBC.Name = "mainColRQBC";
            this.mainColRQBC.ReadOnly = true;
            this.mainColRQBC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // mainColPF
            // 
            this.mainColPF.DataPropertyName = "peifang";
            this.mainColPF.HeaderText = "配方";
            this.mainColPF.Name = "mainColPF";
            this.mainColPF.ReadOnly = true;
            this.mainColPF.Width = 60;
            // 
            // mainColRQSH
            // 
            this.mainColRQSH.DataPropertyName = "riqiShen";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "yy-MM-dd HH:mm";
            this.mainColRQSH.DefaultCellStyle = dataGridViewCellStyle4;
            this.mainColRQSH.HeaderText = "审核日期";
            this.mainColRQSH.Name = "mainColRQSH";
            this.mainColRQSH.ReadOnly = true;
            this.mainColRQSH.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // mainColFH
            // 
            this.mainColFH.DataPropertyName = "fuhe";
            this.mainColFH.HeaderText = "审核";
            this.mainColFH.Name = "mainColFH";
            this.mainColFH.ReadOnly = true;
            this.mainColFH.Width = 60;
            // 
            // mainColDY
            // 
            this.mainColDY.DataPropertyName = "dayang";
            this.mainColDY.HeaderText = "打样";
            this.mainColDY.MaxInputLength = 50;
            this.mainColDY.Name = "mainColDY";
            this.mainColDY.ReadOnly = true;
            this.mainColDY.Width = 60;
            // 
            // mainColBZ
            // 
            this.mainColBZ.DataPropertyName = "beizhu";
            this.mainColBZ.HeaderText = "备注";
            this.mainColBZ.Name = "mainColBZ";
            this.mainColBZ.ReadOnly = true;
            this.mainColBZ.Width = 300;
            // 
            // mainColSN
            // 
            this.mainColSN.DataPropertyName = "SN";
            this.mainColSN.HeaderText = "SN";
            this.mainColSN.Name = "mainColSN";
            this.mainColSN.ReadOnly = true;
            this.mainColSN.Visible = false;
            // 
            // mainColSta
            // 
            this.mainColSta.DataPropertyName = "sta";
            this.mainColSta.HeaderText = "sta";
            this.mainColSta.Name = "mainColSta";
            this.mainColSta.ReadOnly = true;
            this.mainColSta.Visible = false;
            // 
            // mainPanSch
            // 
            this.mainPanSch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.mainPanSch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanSch.Controls.Add(this.schDDH);
            this.mainPanSch.Controls.Add(this.schDY);
            this.mainPanSch.Controls.Add(this.schDel);
            this.mainPanSch.Controls.Add(this.schRQsave);
            this.mainPanSch.Controls.Add(this.schYS);
            this.mainPanSch.Controls.Add(this.schSH);
            this.mainPanSch.Controls.Add(this.schLD);
            this.mainPanSch.Controls.Add(this.schSZ);
            this.mainPanSch.Controls.Add(this.schKH);
            this.mainPanSch.Controls.Add(this.schMohu);
            this.mainPanSch.Controls.Add(this.btnSch);
            this.mainPanSch.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainPanSch.Location = new System.Drawing.Point(2, 2);
            this.mainPanSch.Name = "mainPanSch";
            this.mainPanSch.Size = new System.Drawing.Size(911, 76);
            this.mainPanSch.TabIndex = 0;
            // 
            // schDDH
            // 
            this.schDDH.allowEmpty = true;
            this.schDDH.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schDDH.chkSel = false;
            this.schDDH.chkText = "流程卡号";
            this.schDDH.jiange = 0;
            this.schDDH.Location = new System.Drawing.Point(600, 3);
            this.schDDH.Name = "schDDH";
            this.schDDH.ReadOnly = false;
            this.schDDH.Size = new System.Drawing.Size(180, 27);
            this.schDDH.TabIndex = 48;
            this.schDDH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schDDH.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schDDH.txtISid = false;
            this.schDDH.txtISint = false;
            this.schDDH.txtISmoney = false;
            this.schDDH.txtLen = 50;
            this.schDDH.txtMulLine = false;
            this.schDDH.txtTop = true;
            // 
            // schDY
            // 
            this.schDY.allowEmpty = true;
            this.schDY.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schDY.chkSel = false;
            this.schDY.chkText = "打样";
            this.schDY.jiange = 0;
            this.schDY.Location = new System.Drawing.Point(439, 26);
            this.schDY.Name = "schDY";
            this.schDY.ReadOnly = false;
            this.schDY.Size = new System.Drawing.Size(139, 27);
            this.schDY.TabIndex = 47;
            this.schDY.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schDY.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schDY.txtISid = false;
            this.schDY.txtISint = false;
            this.schDY.txtISmoney = false;
            this.schDY.txtLen = 50;
            this.schDY.txtMulLine = false;
            this.schDY.txtTop = true;
            // 
            // schDel
            // 
            this.schDel.AutoSize = true;
            this.schDel.Location = new System.Drawing.Point(600, 30);
            this.schDel.Name = "schDel";
            this.schDel.Size = new System.Drawing.Size(72, 16);
            this.schDel.TabIndex = 46;
            this.schDel.Text = "含已删除";
            this.schDel.UseVisualStyleBackColor = true;
            // 
            // schRQsave
            // 
            this.schRQsave.chkFsel = false;
            this.schRQsave.chkTsel = false;
            this.schRQsave.dtimeFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schRQsave.dtimeFormat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.schRQsave.dtimeFormatStr = "yyyy-MM-dd HH:mm";
            this.schRQsave.dtimeShowUpDown = false;
            this.schRQsave.jiange = 0;
            this.schRQsave.lblColor = System.Drawing.SystemColors.ControlText;
            this.schRQsave.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schRQsave.lblText = "保存日期";
            this.schRQsave.Location = new System.Drawing.Point(8, 49);
            this.schRQsave.Name = "schRQsave";
            this.schRQsave.Size = new System.Drawing.Size(454, 25);
            this.schRQsave.TabIndex = 45;
            // 
            // schYS
            // 
            this.schYS.allowEmpty = true;
            this.schYS.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schYS.chkSel = false;
            this.schYS.chkText = "颜色";
            this.schYS.jiange = 0;
            this.schYS.Location = new System.Drawing.Point(233, 26);
            this.schYS.Name = "schYS";
            this.schYS.ReadOnly = false;
            this.schYS.Size = new System.Drawing.Size(181, 27);
            this.schYS.TabIndex = 42;
            this.schYS.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schYS.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schYS.txtISid = false;
            this.schYS.txtISint = false;
            this.schYS.txtISmoney = false;
            this.schYS.txtLen = 50;
            this.schYS.txtMulLine = false;
            this.schYS.txtTop = true;
            // 
            // schSH
            // 
            this.schSH.allowEmpty = true;
            this.schSH.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schSH.chkSel = false;
            this.schSH.chkText = "色号";
            this.schSH.jiange = 0;
            this.schSH.Location = new System.Drawing.Point(233, 3);
            this.schSH.Name = "schSH";
            this.schSH.ReadOnly = false;
            this.schSH.Size = new System.Drawing.Size(181, 27);
            this.schSH.TabIndex = 36;
            this.schSH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schSH.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schSH.txtISid = false;
            this.schSH.txtISint = false;
            this.schSH.txtISmoney = false;
            this.schSH.txtLen = 50;
            this.schSH.txtMulLine = false;
            this.schSH.txtTop = true;
            // 
            // schLD
            // 
            this.schLD.allowEmpty = true;
            this.schLD.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schLD.chkSel = false;
            this.schLD.chkText = "单号";
            this.schLD.jiange = 0;
            this.schLD.Location = new System.Drawing.Point(439, 3);
            this.schLD.Name = "schLD";
            this.schLD.ReadOnly = false;
            this.schLD.Size = new System.Drawing.Size(139, 27);
            this.schLD.TabIndex = 41;
            this.schLD.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schLD.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schLD.txtISid = false;
            this.schLD.txtISint = false;
            this.schLD.txtISmoney = false;
            this.schLD.txtLen = 50;
            this.schLD.txtMulLine = false;
            this.schLD.txtTop = true;
            // 
            // schSZ
            // 
            this.schSZ.allowEmpty = true;
            this.schSZ.allowInput = true;
            this.schSZ.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schSZ.chkSel = false;
            this.schSZ.chkText = "品名";
            this.schSZ.cobodgvFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schSZ.coboFlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.schSZ.jiange = 0;
            this.schSZ.Location = new System.Drawing.Point(20, 26);
            this.schSZ.Name = "schSZ";
            this.schSZ.SeparatorChar = " ";
            this.schSZ.Size = new System.Drawing.Size(192, 20);
            this.schSZ.TabIndex = 32;
            // 
            // schKH
            // 
            this.schKH.allowEmpty = true;
            this.schKH.allowInput = true;
            this.schKH.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schKH.chkSel = false;
            this.schKH.chkText = "客户";
            this.schKH.cobodgvFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schKH.coboFlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.schKH.jiange = 0;
            this.schKH.Location = new System.Drawing.Point(20, 3);
            this.schKH.Name = "schKH";
            this.schKH.SeparatorChar = " ";
            this.schKH.Size = new System.Drawing.Size(192, 20);
            this.schKH.TabIndex = 31;
            // 
            // schMohu
            // 
            this.schMohu.AutoSize = true;
            this.schMohu.Checked = true;
            this.schMohu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.schMohu.Location = new System.Drawing.Point(721, 30);
            this.schMohu.Name = "schMohu";
            this.schMohu.Size = new System.Drawing.Size(48, 16);
            this.schMohu.TabIndex = 29;
            this.schMohu.Text = "模糊";
            this.schMohu.UseVisualStyleBackColor = true;
            // 
            // btnSch
            // 
            this.btnSch.AutoSize = true;
            this.btnSch.FlatAppearance.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown;
            this.btnSch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSch.Location = new System.Drawing.Point(818, 30);
            this.btnSch.Name = "btnSch";
            this.btnSch.Size = new System.Drawing.Size(53, 27);
            this.btnSch.TabIndex = 30;
            this.btnSch.Text = "查询";
            this.btnSch.UseVisualStyleBackColor = true;
            this.btnSch.Click += new System.EventHandler(this.btnSch_Click);
            // 
            // tpEdit
            // 
            this.tpEdit.BackColor = System.Drawing.SystemColors.Control;
            this.tpEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpEdit.Controls.Add(this.editPanMain);
            this.tpEdit.Controls.Add(this.editPanTop);
            this.tpEdit.Location = new System.Drawing.Point(4, 29);
            this.tpEdit.Margin = new System.Windows.Forms.Padding(0);
            this.tpEdit.Name = "tpEdit";
            this.tpEdit.Padding = new System.Windows.Forms.Padding(2);
            this.tpEdit.Size = new System.Drawing.Size(917, 417);
            this.tpEdit.TabIndex = 1;
            this.tpEdit.Text = "小样配方编辑";
            // 
            // editPanMain
            // 
            this.editPanMain.Controls.Add(this.editDgvMain);
            this.editPanMain.Controls.Add(this.editPanEdit);
            this.editPanMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editPanMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editPanMain.Location = new System.Drawing.Point(2, 249);
            this.editPanMain.Margin = new System.Windows.Forms.Padding(0);
            this.editPanMain.Name = "editPanMain";
            this.editPanMain.Size = new System.Drawing.Size(911, 164);
            this.editPanMain.TabIndex = 2;
            // 
            // editDgvMain
            // 
            this.editDgvMain.AllowUserToAddRows = false;
            this.editDgvMain.AllowUserToDeleteRows = false;
            this.editDgvMain.AllowUserToResizeRows = false;
            this.editDgvMain.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.editDgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.editDgvMain.ColumnHeadersHeight = 32;
            this.editDgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.editDgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.editColGX,
            this.editColRL,
            this.editColBL,
            this.editColBLDW,
            this.editColGY,
            this.editColSN});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.editDgvMain.DefaultCellStyle = dataGridViewCellStyle12;
            this.editDgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editDgvMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.editDgvMain.Location = new System.Drawing.Point(0, 30);
            this.editDgvMain.MultiSelect = false;
            this.editDgvMain.Name = "editDgvMain";
            this.editDgvMain.RowHeadersWidth = 28;
            this.editDgvMain.RowNumShow = false;
            this.editDgvMain.RowTemplate.Height = 28;
            this.editDgvMain.Size = new System.Drawing.Size(911, 134);
            this.editDgvMain.TabIndex = 0;
            // 
            // editColGX
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.editColGX.DefaultCellStyle = dataGridViewCellStyle7;
            this.editColGX.HeaderText = "染化类别";
            this.editColGX.MaxInputLength = 10;
            this.editColGX.Name = "editColGX";
            this.editColGX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.editColGX.Width = 120;
            // 
            // editColRL
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.editColRL.DefaultCellStyle = dataGridViewCellStyle8;
            this.editColRL.HeaderText = "染化料名称";
            this.editColRL.MaxInputLength = 50;
            this.editColRL.Name = "editColRL";
            this.editColRL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.editColRL.Width = 200;
            // 
            // editColBL
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "0.000000;-0.000000;\"\"";
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.editColBL.DefaultCellStyle = dataGridViewCellStyle9;
            this.editColBL.HeaderText = "比例(%)";
            this.editColBL.MaxInputLength = 10;
            this.editColBL.Name = "editColBL";
            this.editColBL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.editColBL.Width = 120;
            // 
            // editColBLDW
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.editColBLDW.DefaultCellStyle = dataGridViewCellStyle10;
            this.editColBLDW.HeaderText = "浓度单位";
            this.editColBLDW.MaxInputLength = 5;
            this.editColBLDW.Name = "editColBLDW";
            this.editColBLDW.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.editColBLDW.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.editColBLDW.Width = 80;
            // 
            // editColGY
            // 
            this.editColGY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.editColGY.DefaultCellStyle = dataGridViewCellStyle11;
            this.editColGY.HeaderText = "工艺要求";
            this.editColGY.MaxInputLength = 20;
            this.editColGY.Name = "editColGY";
            this.editColGY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // editColSN
            // 
            this.editColSN.HeaderText = "SN";
            this.editColSN.Name = "editColSN";
            this.editColSN.Visible = false;
            // 
            // editPanEdit
            // 
            this.editPanEdit.Controls.Add(this.editLblStaExe);
            this.editPanEdit.Controls.Add(this.editBtnRowDN);
            this.editPanEdit.Controls.Add(this.editBtnRowUP);
            this.editPanEdit.Controls.Add(this.editBtnDelRow);
            this.editPanEdit.Controls.Add(this.editBtnAddRow);
            this.editPanEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.editPanEdit.Location = new System.Drawing.Point(0, 0);
            this.editPanEdit.Margin = new System.Windows.Forms.Padding(0);
            this.editPanEdit.Name = "editPanEdit";
            this.editPanEdit.Size = new System.Drawing.Size(911, 30);
            this.editPanEdit.TabIndex = 0;
            // 
            // editLblStaExe
            // 
            this.editLblStaExe.AutoSize = true;
            this.editLblStaExe.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editLblStaExe.ForeColor = System.Drawing.Color.DarkRed;
            this.editLblStaExe.Location = new System.Drawing.Point(811, 6);
            this.editLblStaExe.Name = "editLblStaExe";
            this.editLblStaExe.Size = new System.Drawing.Size(76, 16);
            this.editLblStaExe.TabIndex = 24;
            this.editLblStaExe.Text = "操作状态";
            // 
            // editBtnRowDN
            // 
            this.editBtnRowDN.BackColor = System.Drawing.Color.Honeydew;
            this.editBtnRowDN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editBtnRowDN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.editBtnRowDN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.editBtnRowDN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtnRowDN.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editBtnRowDN.ForeColor = System.Drawing.Color.Maroon;
            this.editBtnRowDN.Location = new System.Drawing.Point(308, 2);
            this.editBtnRowDN.Name = "editBtnRowDN";
            this.editBtnRowDN.Size = new System.Drawing.Size(63, 25);
            this.editBtnRowDN.TabIndex = 18;
            this.editBtnRowDN.Text = "行下移";
            this.editBtnRowDN.UseVisualStyleBackColor = false;
            this.editBtnRowDN.Click += new System.EventHandler(this.editBtnRowDN_Click);
            // 
            // editBtnRowUP
            // 
            this.editBtnRowUP.BackColor = System.Drawing.Color.Honeydew;
            this.editBtnRowUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editBtnRowUP.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.editBtnRowUP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.editBtnRowUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtnRowUP.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editBtnRowUP.ForeColor = System.Drawing.Color.Maroon;
            this.editBtnRowUP.Location = new System.Drawing.Point(239, 2);
            this.editBtnRowUP.Name = "editBtnRowUP";
            this.editBtnRowUP.Size = new System.Drawing.Size(63, 25);
            this.editBtnRowUP.TabIndex = 17;
            this.editBtnRowUP.Text = "行上移";
            this.editBtnRowUP.UseVisualStyleBackColor = false;
            this.editBtnRowUP.Click += new System.EventHandler(this.editBtnRowUP_Click);
            // 
            // editBtnDelRow
            // 
            this.editBtnDelRow.BackColor = System.Drawing.Color.Honeydew;
            this.editBtnDelRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editBtnDelRow.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.editBtnDelRow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.editBtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtnDelRow.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editBtnDelRow.ForeColor = System.Drawing.Color.Maroon;
            this.editBtnDelRow.Location = new System.Drawing.Point(170, 2);
            this.editBtnDelRow.Name = "editBtnDelRow";
            this.editBtnDelRow.Size = new System.Drawing.Size(63, 25);
            this.editBtnDelRow.TabIndex = 14;
            this.editBtnDelRow.Text = "删除行";
            this.editBtnDelRow.UseVisualStyleBackColor = false;
            this.editBtnDelRow.Click += new System.EventHandler(this.editBtnDelRow_Click);
            // 
            // editBtnAddRow
            // 
            this.editBtnAddRow.BackColor = System.Drawing.Color.Honeydew;
            this.editBtnAddRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editBtnAddRow.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.editBtnAddRow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.editBtnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtnAddRow.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editBtnAddRow.ForeColor = System.Drawing.Color.Maroon;
            this.editBtnAddRow.Location = new System.Drawing.Point(101, 2);
            this.editBtnAddRow.Name = "editBtnAddRow";
            this.editBtnAddRow.Size = new System.Drawing.Size(63, 25);
            this.editBtnAddRow.TabIndex = 15;
            this.editBtnAddRow.Text = "插入行";
            this.editBtnAddRow.UseVisualStyleBackColor = false;
            this.editBtnAddRow.Click += new System.EventHandler(this.editBtnAddRow_Click);
            // 
            // editPanTop
            // 
            this.editPanTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editPanTop.Controls.Add(this.editDgvList);
            this.editPanTop.Controls.Add(this.editPanList);
            this.editPanTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.editPanTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editPanTop.Location = new System.Drawing.Point(2, 2);
            this.editPanTop.Name = "editPanTop";
            this.editPanTop.Size = new System.Drawing.Size(911, 247);
            this.editPanTop.TabIndex = 0;
            // 
            // editDgvList
            // 
            this.editDgvList.AllowUserToAddRows = false;
            this.editDgvList.AllowUserToDeleteRows = false;
            this.editDgvList.AllowUserToResizeRows = false;
            this.editDgvList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.editDgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.editDgvList.ColumnHeadersHeight = 25;
            this.editDgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.editDgvList.ContextMenuStrip = this.menuList;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.editDgvList.DefaultCellStyle = dataGridViewCellStyle14;
            this.editDgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editDgvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.editDgvList.Location = new System.Drawing.Point(531, 0);
            this.editDgvList.Margin = new System.Windows.Forms.Padding(0);
            this.editDgvList.MultiSelect = false;
            this.editDgvList.Name = "editDgvList";
            this.editDgvList.ReadOnly = true;
            this.editDgvList.RowHeadersWidth = 25;
            this.editDgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.editDgvList.RowNumShow = false;
            this.editDgvList.RowTemplate.Height = 25;
            this.editDgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.editDgvList.Size = new System.Drawing.Size(378, 245);
            this.editDgvList.TabIndex = 35;
            // 
            // editPanList
            // 
            this.editPanList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.editPanList.Controls.Add(this.editTxtDDH);
            this.editPanList.Controls.Add(this.editImgLDH);
            this.editPanList.Controls.Add(this.editBtnNewNow);
            this.editPanList.Controls.Add(this.editLblStaLD);
            this.editPanList.Controls.Add(this.editBtnEdit);
            this.editPanList.Controls.Add(this.editBtnDel);
            this.editPanList.Controls.Add(this.editBtnPrn);
            this.editPanList.Controls.Add(this.editBtnNew);
            this.editPanList.Controls.Add(this.editTxtBZ);
            this.editPanList.Controls.Add(this.editBtnSH);
            this.editPanList.Controls.Add(this.editTxtDY);
            this.editPanList.Controls.Add(this.editTxtKH);
            this.editPanList.Controls.Add(this.editTxtYS);
            this.editPanList.Controls.Add(this.editTxtSZ);
            this.editPanList.Controls.Add(this.editTxtSH);
            this.editPanList.Controls.Add(this.editBtnSave);
            this.editPanList.Controls.Add(this.editBtnCancel);
            this.editPanList.Dock = System.Windows.Forms.DockStyle.Left;
            this.editPanList.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editPanList.Location = new System.Drawing.Point(0, 0);
            this.editPanList.Name = "editPanList";
            this.editPanList.Padding = new System.Windows.Forms.Padding(2);
            this.editPanList.Size = new System.Drawing.Size(531, 245);
            this.editPanList.TabIndex = 36;
            // 
            // editTxtDDH
            // 
            this.editTxtDDH.BackColor = System.Drawing.Color.Transparent;
            this.editTxtDDH.jiange = 0;
            this.editTxtDDH.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtDDH.lblText = "缸号";
            this.editTxtDDH.Location = new System.Drawing.Point(270, 99);
            this.editTxtDDH.Name = "editTxtDDH";
            this.editTxtDDH.ReadOnly = false;
            this.editTxtDDH.Size = new System.Drawing.Size(143, 25);
            this.editTxtDDH.TabIndex = 3;
            this.editTxtDDH.txtBackColor = System.Drawing.SystemColors.Window;
            this.editTxtDDH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtDDH.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtDDH.txtISid = false;
            this.editTxtDDH.txtISint = false;
            this.editTxtDDH.txtISmoney = false;
            this.editTxtDDH.txtLen = 50;
            this.editTxtDDH.txtMulLine = false;
            this.editTxtDDH.txtReadonly = false;
            this.editTxtDDH.txtTop = true;
            this.editTxtDDH.txtUpper = false;
            this.editTxtDDH.upperZero = false;
            this.editTxtDDH.Visible = false;
            // 
            // editImgLDH
            // 
            this.editImgLDH.Location = new System.Drawing.Point(41, 21);
            this.editImgLDH.Name = "editImgLDH";
            this.editImgLDH.Size = new System.Drawing.Size(190, 65);
            this.editImgLDH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.editImgLDH.TabIndex = 48;
            this.editImgLDH.TabStop = false;
            // 
            // editBtnNewNow
            // 
            this.editBtnNewNow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editBtnNewNow.BackColor = System.Drawing.SystemColors.Control;
            this.editBtnNewNow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.editBtnNewNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtnNewNow.Location = new System.Drawing.Point(325, 3);
            this.editBtnNewNow.Name = "editBtnNewNow";
            this.editBtnNewNow.Size = new System.Drawing.Size(65, 25);
            this.editBtnNewNow.TabIndex = 17;
            this.editBtnNewNow.Text = "新建复制";
            this.editBtnNewNow.UseVisualStyleBackColor = false;
            this.editBtnNewNow.Click += new System.EventHandler(this.editBtnNewNow_Click);
            // 
            // editLblStaLD
            // 
            this.editLblStaLD.BackColor = System.Drawing.Color.PaleGreen;
            this.editLblStaLD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editLblStaLD.Font = new System.Drawing.Font("黑体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editLblStaLD.ForeColor = System.Drawing.Color.Red;
            this.editLblStaLD.Location = new System.Drawing.Point(422, 57);
            this.editLblStaLD.Name = "editLblStaLD";
            this.editLblStaLD.Size = new System.Drawing.Size(100, 40);
            this.editLblStaLD.TabIndex = 41;
            this.editLblStaLD.Text = "料单状态";
            this.editLblStaLD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editBtnEdit
            // 
            this.editBtnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editBtnEdit.BackColor = System.Drawing.SystemColors.Control;
            this.editBtnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.editBtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtnEdit.Location = new System.Drawing.Point(457, 3);
            this.editBtnEdit.Name = "editBtnEdit";
            this.editBtnEdit.Size = new System.Drawing.Size(65, 25);
            this.editBtnEdit.TabIndex = 18;
            this.editBtnEdit.Text = "修改";
            this.editBtnEdit.UseVisualStyleBackColor = false;
            this.editBtnEdit.Click += new System.EventHandler(this.editBtnEdit_Click);
            // 
            // editBtnDel
            // 
            this.editBtnDel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editBtnDel.BackColor = System.Drawing.SystemColors.Control;
            this.editBtnDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.editBtnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtnDel.Location = new System.Drawing.Point(457, 29);
            this.editBtnDel.Name = "editBtnDel";
            this.editBtnDel.Size = new System.Drawing.Size(65, 25);
            this.editBtnDel.TabIndex = 19;
            this.editBtnDel.Text = "删除";
            this.editBtnDel.UseVisualStyleBackColor = false;
            this.editBtnDel.Click += new System.EventHandler(this.editBtnDel_Click);
            // 
            // editBtnPrn
            // 
            this.editBtnPrn.BackColor = System.Drawing.SystemColors.Control;
            this.editBtnPrn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.editBtnPrn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtnPrn.Location = new System.Drawing.Point(391, 29);
            this.editBtnPrn.Name = "editBtnPrn";
            this.editBtnPrn.Size = new System.Drawing.Size(65, 25);
            this.editBtnPrn.TabIndex = 13;
            this.editBtnPrn.Text = "打印";
            this.editBtnPrn.UseVisualStyleBackColor = false;
            this.editBtnPrn.Click += new System.EventHandler(this.editBtnPrn_Click);
            // 
            // editBtnNew
            // 
            this.editBtnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editBtnNew.BackColor = System.Drawing.SystemColors.Control;
            this.editBtnNew.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.editBtnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.editBtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtnNew.Location = new System.Drawing.Point(259, 3);
            this.editBtnNew.Name = "editBtnNew";
            this.editBtnNew.Size = new System.Drawing.Size(65, 25);
            this.editBtnNew.TabIndex = 16;
            this.editBtnNew.Text = "新建空白";
            this.editBtnNew.UseVisualStyleBackColor = false;
            this.editBtnNew.Click += new System.EventHandler(this.editBtnNew_Click);
            // 
            // editTxtBZ
            // 
            this.editTxtBZ.BackColor = System.Drawing.Color.Transparent;
            this.editTxtBZ.jiange = 0;
            this.editTxtBZ.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtBZ.lblText = "备注";
            this.editTxtBZ.Location = new System.Drawing.Point(15, 189);
            this.editTxtBZ.Name = "editTxtBZ";
            this.editTxtBZ.ReadOnly = false;
            this.editTxtBZ.Size = new System.Drawing.Size(506, 48);
            this.editTxtBZ.TabIndex = 6;
            this.editTxtBZ.txtBackColor = System.Drawing.SystemColors.Window;
            this.editTxtBZ.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtBZ.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtBZ.txtISid = false;
            this.editTxtBZ.txtISint = false;
            this.editTxtBZ.txtISmoney = false;
            this.editTxtBZ.txtLen = 50;
            this.editTxtBZ.txtMulLine = true;
            this.editTxtBZ.txtReadonly = false;
            this.editTxtBZ.txtTop = true;
            this.editTxtBZ.txtUpper = false;
            this.editTxtBZ.upperZero = false;
            // 
            // editBtnSH
            // 
            this.editBtnSH.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editBtnSH.BackColor = System.Drawing.SystemColors.Control;
            this.editBtnSH.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.editBtnSH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtnSH.Location = new System.Drawing.Point(391, 3);
            this.editBtnSH.Name = "editBtnSH";
            this.editBtnSH.Size = new System.Drawing.Size(65, 25);
            this.editBtnSH.TabIndex = 20;
            this.editBtnSH.Text = "审核";
            this.editBtnSH.UseVisualStyleBackColor = false;
            this.editBtnSH.Click += new System.EventHandler(this.editBtnSH_Click);
            // 
            // editTxtDY
            // 
            this.editTxtDY.BackColor = System.Drawing.Color.Transparent;
            this.editTxtDY.jiange = 0;
            this.editTxtDY.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtDY.lblText = "打样";
            this.editTxtDY.Location = new System.Drawing.Point(270, 159);
            this.editTxtDY.Name = "editTxtDY";
            this.editTxtDY.ReadOnly = false;
            this.editTxtDY.Size = new System.Drawing.Size(143, 25);
            this.editTxtDY.TabIndex = 5;
            this.editTxtDY.txtBackColor = System.Drawing.SystemColors.Window;
            this.editTxtDY.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtDY.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtDY.txtISid = false;
            this.editTxtDY.txtISint = false;
            this.editTxtDY.txtISmoney = false;
            this.editTxtDY.txtLen = 50;
            this.editTxtDY.txtMulLine = false;
            this.editTxtDY.txtReadonly = false;
            this.editTxtDY.txtTop = true;
            this.editTxtDY.txtUpper = false;
            this.editTxtDY.upperZero = false;
            // 
            // editTxtKH
            // 
            this.editTxtKH.BackColor = System.Drawing.Color.Transparent;
            this.editTxtKH.jiange = 0;
            this.editTxtKH.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtKH.lblText = "客户";
            this.editTxtKH.Location = new System.Drawing.Point(15, 99);
            this.editTxtKH.Name = "editTxtKH";
            this.editTxtKH.ReadOnly = false;
            this.editTxtKH.Size = new System.Drawing.Size(217, 25);
            this.editTxtKH.TabIndex = 0;
            this.editTxtKH.txtBackColor = System.Drawing.SystemColors.Window;
            this.editTxtKH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtKH.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtKH.txtISid = false;
            this.editTxtKH.txtISint = false;
            this.editTxtKH.txtISmoney = false;
            this.editTxtKH.txtLen = 50;
            this.editTxtKH.txtMulLine = false;
            this.editTxtKH.txtReadonly = false;
            this.editTxtKH.txtTop = true;
            this.editTxtKH.txtUpper = false;
            this.editTxtKH.upperZero = false;
            // 
            // editTxtYS
            // 
            this.editTxtYS.BackColor = System.Drawing.Color.Transparent;
            this.editTxtYS.jiange = 0;
            this.editTxtYS.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtYS.lblText = "颜色";
            this.editTxtYS.Location = new System.Drawing.Point(270, 129);
            this.editTxtYS.Name = "editTxtYS";
            this.editTxtYS.ReadOnly = false;
            this.editTxtYS.Size = new System.Drawing.Size(143, 25);
            this.editTxtYS.TabIndex = 4;
            this.editTxtYS.txtBackColor = System.Drawing.SystemColors.Window;
            this.editTxtYS.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtYS.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtYS.txtISid = false;
            this.editTxtYS.txtISint = false;
            this.editTxtYS.txtISmoney = false;
            this.editTxtYS.txtLen = 50;
            this.editTxtYS.txtMulLine = false;
            this.editTxtYS.txtReadonly = false;
            this.editTxtYS.txtTop = true;
            this.editTxtYS.txtUpper = false;
            this.editTxtYS.upperZero = false;
            // 
            // editTxtSZ
            // 
            this.editTxtSZ.BackColor = System.Drawing.Color.Transparent;
            this.editTxtSZ.jiange = 0;
            this.editTxtSZ.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtSZ.lblText = "品名";
            this.editTxtSZ.Location = new System.Drawing.Point(15, 129);
            this.editTxtSZ.Name = "editTxtSZ";
            this.editTxtSZ.ReadOnly = false;
            this.editTxtSZ.Size = new System.Drawing.Size(217, 25);
            this.editTxtSZ.TabIndex = 1;
            this.editTxtSZ.txtBackColor = System.Drawing.SystemColors.Window;
            this.editTxtSZ.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtSZ.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtSZ.txtISid = false;
            this.editTxtSZ.txtISint = false;
            this.editTxtSZ.txtISmoney = false;
            this.editTxtSZ.txtLen = 50;
            this.editTxtSZ.txtMulLine = false;
            this.editTxtSZ.txtReadonly = false;
            this.editTxtSZ.txtTop = true;
            this.editTxtSZ.txtUpper = false;
            this.editTxtSZ.upperZero = false;
            // 
            // editTxtSH
            // 
            this.editTxtSH.BackColor = System.Drawing.Color.Transparent;
            this.editTxtSH.jiange = 0;
            this.editTxtSH.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtSH.lblText = "色号";
            this.editTxtSH.Location = new System.Drawing.Point(15, 159);
            this.editTxtSH.Name = "editTxtSH";
            this.editTxtSH.ReadOnly = false;
            this.editTxtSH.Size = new System.Drawing.Size(217, 25);
            this.editTxtSH.TabIndex = 2;
            this.editTxtSH.txtBackColor = System.Drawing.SystemColors.Window;
            this.editTxtSH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtSH.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtSH.txtISid = false;
            this.editTxtSH.txtISint = false;
            this.editTxtSH.txtISmoney = false;
            this.editTxtSH.txtLen = 50;
            this.editTxtSH.txtMulLine = false;
            this.editTxtSH.txtReadonly = false;
            this.editTxtSH.txtTop = true;
            this.editTxtSH.txtUpper = false;
            this.editTxtSH.upperZero = false;
            // 
            // editBtnSave
            // 
            this.editBtnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editBtnSave.BackColor = System.Drawing.SystemColors.Control;
            this.editBtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.editBtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtnSave.Location = new System.Drawing.Point(304, 26);
            this.editBtnSave.Name = "editBtnSave";
            this.editBtnSave.Size = new System.Drawing.Size(65, 25);
            this.editBtnSave.TabIndex = 38;
            this.editBtnSave.Text = "保存";
            this.editBtnSave.UseVisualStyleBackColor = false;
            this.editBtnSave.Click += new System.EventHandler(this.editBtnSave_Click);
            // 
            // editBtnCancel
            // 
            this.editBtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editBtnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.editBtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.editBtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtnCancel.Location = new System.Drawing.Point(375, 26);
            this.editBtnCancel.Name = "editBtnCancel";
            this.editBtnCancel.Size = new System.Drawing.Size(65, 25);
            this.editBtnCancel.TabIndex = 37;
            this.editBtnCancel.Text = "取消";
            this.editBtnCancel.UseVisualStyleBackColor = false;
            this.editBtnCancel.Click += new System.EventHandler(this.editBtnCancel_Click);
            // 
            // FrmXY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 450);
            this.Controls.Add(this.tabPages);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmXY";
            this.Text = "FrmXY";
            this.Load += new System.EventHandler(this.this_Load);
            this.menuList.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPages.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.mainPanDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDgv)).EndInit();
            this.mainPanSch.ResumeLayout(false);
            this.mainPanSch.PerformLayout();
            this.tpEdit.ResumeLayout(false);
            this.editPanMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editDgvMain)).EndInit();
            this.editPanEdit.ResumeLayout(false);
            this.editPanEdit.PerformLayout();
            this.editPanTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editDgvList)).EndInit();
            this.editPanList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editImgLDH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TabEx tabPages;
        private TabPage tpMain;
        private TabPage tpEdit;
        private Panel editPanMain;
        private dgvEX editDgvMain;
        private Panel editPanTop;
        private Button editBtnSH;
        private Button editBtnRowDN;
        private Button editBtnRowUP;
        private Button editBtnAddRow;
        private Button editBtnDelRow;
        private Button editBtnNew;
        private Button editBtnPrn;
        private Button editBtnDel;
        private Button editBtnEdit;
        private Button editBtnNewNow;
        private LblTxt editTxtSZ;
        private LblTxt editTxtKH;
        private LblTxt editTxtDY;
        private LblTxt editTxtYS;
        private LblTxt editTxtSH;
        private LblTxt editTxtBZ;
        private dgvEX editDgvList;
        private Panel editPanList;
        private Panel editPanEdit;
        private Button editBtnSave;
        private Button editBtnCancel;
        private Label editLblStaExe;
        private ContextMenuStrip menuList;
        private ToolStripMenuItem menuList刷新;
        private Panel mainPanDGV;
        private Panel mainPanSch;
        private CheckBox schMohu;
        private Button btnSch;
        private dgvEX mainDgv;
        private ChkTxt schYS;
        private ChkTxt schLD;
        private ChkTxt schSH;
        private ChkCoboDGV schSZ;
        private ChkCoboDGV schKH;
        private ChkDtime schRQsave;
        private Label editLblStaLD;
        private CheckBox schDel;
        private PictureBox editImgLDH;
        private LblTxt editTxtDDH;
        private DataGridViewTextBoxColumn mainColBH;
        private DataGridViewTextBoxColumn mainColKH;
        private DataGridViewTextBoxColumn mainColSZ;
        private DataGridViewTextBoxColumn mainColSH;
        private DataGridViewTextBoxColumn mainColYS;
        private DataGridViewTextBoxColumn mainColDDH;
        private DataGridViewTextBoxColumn mainColRQBC;
        private DataGridViewTextBoxColumn mainColPF;
        private DataGridViewTextBoxColumn mainColRQSH;
        private DataGridViewTextBoxColumn mainColFH;
        private DataGridViewTextBoxColumn mainColDY;
        private DataGridViewTextBoxColumn mainColBZ;
        private DataGridViewTextBoxColumn mainColSN;
        private DataGridViewTextBoxColumn mainColSta;
        private ChkTxt schDDH;
        private ChkTxt schDY;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 打印ToolStripMenuItem;
        private ToolStripMenuItem 导出ToolStripMenuItem;
        private ToolStripMenuItem 修改ToolStripMenuItem;
        private ToolStripMenuItem 删除ToolStripMenuItem;
        private ToolStripMenuItem 刷新ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private DataGridViewTextBoxColumn editColGX;
        private DataGridViewTextBoxColumn editColRL;
        private DataGridViewTextBoxColumn editColBL;
        private DataGridViewTextBoxColumn editColBLDW;
        private DataGridViewTextBoxColumn editColGY;
        private DataGridViewTextBoxColumn editColSN;
    }
}
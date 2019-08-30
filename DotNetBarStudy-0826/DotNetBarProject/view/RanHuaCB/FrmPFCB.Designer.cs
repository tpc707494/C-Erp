using DotNetBarProject.view.custom.view;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.RanHuaCB
{
    partial class FrmPFCB
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPages = new DotNetBarProject.view.custom.view.TabEx();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.mainPanDGV = new System.Windows.Forms.Panel();
            this.mainDgv = new DotNetBarProject.view.custom.view.dgvEX();
            this.mainColBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColSH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColYS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColSZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColDDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColJH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColZL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColKZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColJLCS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColRQBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColRQSH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColFH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColDY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColZC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColBZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColSta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColRQCL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanSch = new System.Windows.Forms.Panel();
            this.schLBJL = new System.Windows.Forms.CheckBox();
            this.schRQsave = new DotNetBarProject.view.custom.view.ChkDtime();
            this.schJH = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.schDDH = new DotNetBarProject.view.custom.view.ChkTxt();
            this.schLBLD = new System.Windows.Forms.CheckBox();
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
            this.editPanTop = new System.Windows.Forms.Panel();
            this.editImgLDH = new System.Windows.Forms.PictureBox();
            this.editTxtDDH = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtJLCS = new DotNetBarProject.view.custom.view.LblTxt();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.editLblShowLB = new System.Windows.Forms.Label();
            this.editTxtDJ = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtMS = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtKZ = new DotNetBarProject.view.custom.view.LblTxt();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editTxtBZ = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtZC = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtDY = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtZL = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtSL = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtJH = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtYS = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtSH = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtSZ = new DotNetBarProject.view.custom.view.LblTxt();
            this.editTxtKH = new DotNetBarProject.view.custom.view.LblTxt();
            this.editBtnPrn = new System.Windows.Forms.Button();
            this.editColGX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColRL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColBL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColBLDW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColYL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColYLDW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColJL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColJLYL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColJLDW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColDJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColJE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColGY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColSNld = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPages.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.mainPanDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDgv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.mainPanSch.SuspendLayout();
            this.tpEdit.SuspendLayout();
            this.editPanMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editDgvMain)).BeginInit();
            this.editPanTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editImgLDH)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPages
            // 
            this.tabPages.Controls.Add(this.tpMain);
            this.tabPages.Controls.Add(this.tpEdit);
            this.tabPages.DisplayStyle = DotNetBarProject.view.custom.view.TabEx.enumDisplwyStyle.Angled;
            this.tabPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPages.HotTrack = true;
            this.tabPages.ItemSize = new System.Drawing.Size(150, 18);
            this.tabPages.Location = new System.Drawing.Point(0, 0);
            this.tabPages.Margin = new System.Windows.Forms.Padding(0);
            this.tabPages.Name = "tabPages";
            this.tabPages.Padding = new System.Drawing.Point(0, 0);
            this.tabPages.SelectedIndex = 0;
            this.tabPages.Size = new System.Drawing.Size(984, 462);
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
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(2);
            this.tpMain.Size = new System.Drawing.Size(976, 436);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "配方查询";
            // 
            // mainPanDGV
            // 
            this.mainPanDGV.Controls.Add(this.mainDgv);
            this.mainPanDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanDGV.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mainPanDGV.Location = new System.Drawing.Point(2, 77);
            this.mainPanDGV.Name = "mainPanDGV";
            this.mainPanDGV.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.mainPanDGV.Size = new System.Drawing.Size(970, 355);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.mainDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mainDgv.ColumnHeadersHeight = 30;
            this.mainDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.mainDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mainColBH,
            this.mainColKH,
            this.mainColSH,
            this.mainColYS,
            this.mainColSZ,
            this.mainColDDH,
            this.mainColJH,
            this.mainColSL,
            this.mainColZL,
            this.mainColKZ,
            this.mainColMS,
            this.mainColPS,
            this.mainColJLCS,
            this.mainColRQBC,
            this.mainColPF,
            this.mainColRQSH,
            this.mainColFH,
            this.mainColDY,
            this.mainColZC,
            this.mainColBZ,
            this.mainColSN,
            this.mainColSta,
            this.mainColRQCL});
            this.mainDgv.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainDgv.DefaultCellStyle = dataGridViewCellStyle12;
            this.mainDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDgv.Location = new System.Drawing.Point(0, 2);
            this.mainDgv.MultiSelect = false;
            this.mainDgv.Name = "mainDgv";
            this.mainDgv.ReadOnly = true;
            this.mainDgv.RowHeadersWidth = 28;
            this.mainDgv.RowNumShow = false;
            this.mainDgv.RowTemplate.Height = 28;
            this.mainDgv.Size = new System.Drawing.Size(970, 353);
            this.mainDgv.TabIndex = 1;
            this.mainDgv.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.mainDgv_CellMouseDoubleClick);
            this.mainDgv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.mainDgv_RowPostPaint);
            // 
            // mainColBH
            // 
            this.mainColBH.DataPropertyName = "danhao";
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
            // mainColDDH
            // 
            this.mainColDDH.DataPropertyName = "dingdan";
            this.mainColDDH.HeaderText = "流程卡号";
            this.mainColDDH.MaxInputLength = 10;
            this.mainColDDH.Name = "mainColDDH";
            this.mainColDDH.ReadOnly = true;
            // 
            // mainColJH
            // 
            this.mainColJH.DataPropertyName = "jihao";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mainColJH.DefaultCellStyle = dataGridViewCellStyle2;
            this.mainColJH.HeaderText = "机号";
            this.mainColJH.Name = "mainColJH";
            this.mainColJH.ReadOnly = true;
            this.mainColJH.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.mainColJH.Width = 60;
            // 
            // mainColSL
            // 
            this.mainColSL.DataPropertyName = "shuiliang";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "0.####;-0.####;\"\"";
            this.mainColSL.DefaultCellStyle = dataGridViewCellStyle3;
            this.mainColSL.HeaderText = "浴量";
            this.mainColSL.Name = "mainColSL";
            this.mainColSL.ReadOnly = true;
            this.mainColSL.Width = 60;
            // 
            // mainColZL
            // 
            this.mainColZL.DataPropertyName = "zhongliang";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "0.####;-0.####;\"\"";
            this.mainColZL.DefaultCellStyle = dataGridViewCellStyle4;
            this.mainColZL.HeaderText = "重量";
            this.mainColZL.Name = "mainColZL";
            this.mainColZL.ReadOnly = true;
            // 
            // mainColKZ
            // 
            this.mainColKZ.DataPropertyName = "kezhong";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "0.###;-0.###;\"\"";
            this.mainColKZ.DefaultCellStyle = dataGridViewCellStyle5;
            this.mainColKZ.HeaderText = "克重";
            this.mainColKZ.Name = "mainColKZ";
            this.mainColKZ.ReadOnly = true;
            this.mainColKZ.Width = 60;
            // 
            // mainColMS
            // 
            this.mainColMS.DataPropertyName = "mishu";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "0.###;-0.###;\"\"";
            this.mainColMS.DefaultCellStyle = dataGridViewCellStyle6;
            this.mainColMS.HeaderText = "米数";
            this.mainColMS.Name = "mainColMS";
            this.mainColMS.ReadOnly = true;
            this.mainColMS.Width = 60;
            // 
            // mainColPS
            // 
            this.mainColPS.DataPropertyName = "danjia";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "0.###;-0.###;\"\"";
            this.mainColPS.DefaultCellStyle = dataGridViewCellStyle7;
            this.mainColPS.HeaderText = "匹数";
            this.mainColPS.Name = "mainColPS";
            this.mainColPS.ReadOnly = true;
            // 
            // mainColJLCS
            // 
            this.mainColJLCS.DataPropertyName = "JLciHJ";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "0;-0;\"\"";
            this.mainColJLCS.DefaultCellStyle = dataGridViewCellStyle8;
            this.mainColJLCS.HeaderText = "加料次数";
            this.mainColJLCS.Name = "mainColJLCS";
            this.mainColJLCS.ReadOnly = true;
            this.mainColJLCS.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.mainColJLCS.Width = 45;
            // 
            // mainColRQBC
            // 
            this.mainColRQBC.DataPropertyName = "riqiSave";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "yy-MM-dd HH:mm";
            this.mainColRQBC.DefaultCellStyle = dataGridViewCellStyle9;
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "yy-MM-dd HH:mm";
            this.mainColRQSH.DefaultCellStyle = dataGridViewCellStyle10;
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
            // mainColZC
            // 
            this.mainColZC.DataPropertyName = "zhuche";
            this.mainColZC.HeaderText = "对色";
            this.mainColZC.Name = "mainColZC";
            this.mainColZC.ReadOnly = true;
            this.mainColZC.Width = 60;
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
            // mainColRQCL
            // 
            this.mainColRQCL.DataPropertyName = "riqiCheng";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "yy-MM-dd HH:mm";
            this.mainColRQCL.DefaultCellStyle = dataGridViewCellStyle11;
            this.mainColRQCL.HeaderText = "称料日期";
            this.mainColRQCL.Name = "mainColRQCL";
            this.mainColRQCL.ReadOnly = true;
            this.mainColRQCL.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.mainColRQCL.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.toolStripSeparator1,
            this.打印ToolStripMenuItem,
            this.导出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 76);
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
            this.打印ToolStripMenuItem.Click += new System.EventHandler(this.打印ToolStripMenuItem_Click_1);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click_1);
            // 
            // mainPanSch
            // 
            this.mainPanSch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.mainPanSch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanSch.Controls.Add(this.schLBJL);
            this.mainPanSch.Controls.Add(this.schRQsave);
            this.mainPanSch.Controls.Add(this.schJH);
            this.mainPanSch.Controls.Add(this.schDDH);
            this.mainPanSch.Controls.Add(this.schLBLD);
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
            this.mainPanSch.Size = new System.Drawing.Size(970, 75);
            this.mainPanSch.TabIndex = 0;
            // 
            // schLBJL
            // 
            this.schLBJL.AutoSize = true;
            this.schLBJL.Checked = true;
            this.schLBJL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.schLBJL.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schLBJL.ForeColor = System.Drawing.Color.DarkRed;
            this.schLBJL.Location = new System.Drawing.Point(657, 39);
            this.schLBJL.Name = "schLBJL";
            this.schLBJL.Size = new System.Drawing.Size(76, 16);
            this.schLBJL.TabIndex = 48;
            this.schLBJL.Text = "加料配方";
            this.schLBJL.UseVisualStyleBackColor = true;
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
            this.schRQsave.Location = new System.Drawing.Point(20, 49);
            this.schRQsave.Name = "schRQsave";
            this.schRQsave.Size = new System.Drawing.Size(394, 25);
            this.schRQsave.TabIndex = 45;
            // 
            // schJH
            // 
            this.schJH.allowEmpty = true;
            this.schJH.allowInput = true;
            this.schJH.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schJH.chkSel = false;
            this.schJH.chkText = "机号";
            this.schJH.cobodgvFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schJH.coboFlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.schJH.jiange = 0;
            this.schJH.Location = new System.Drawing.Point(441, 26);
            this.schJH.Name = "schJH";
            this.schJH.SeparatorChar = " ";
            this.schJH.Size = new System.Drawing.Size(177, 20);
            this.schJH.TabIndex = 44;
            // 
            // schDDH
            // 
            this.schDDH.allowEmpty = true;
            this.schDDH.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schDDH.chkSel = false;
            this.schDDH.chkText = "流程卡号";
            this.schDDH.jiange = 0;
            this.schDDH.Location = new System.Drawing.Point(441, 49);
            this.schDDH.Name = "schDDH";
            this.schDDH.ReadOnly = false;
            this.schDDH.Size = new System.Drawing.Size(177, 27);
            this.schDDH.TabIndex = 38;
            this.schDDH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schDDH.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schDDH.txtISid = false;
            this.schDDH.txtISint = false;
            this.schDDH.txtISmoney = false;
            this.schDDH.txtLen = 50;
            this.schDDH.txtMulLine = false;
            this.schDDH.txtTop = true;
            // 
            // schLBLD
            // 
            this.schLBLD.AutoSize = true;
            this.schLBLD.Checked = true;
            this.schLBLD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.schLBLD.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schLBLD.ForeColor = System.Drawing.Color.DarkRed;
            this.schLBLD.Location = new System.Drawing.Point(657, 17);
            this.schLBLD.Name = "schLBLD";
            this.schLBLD.Size = new System.Drawing.Size(76, 16);
            this.schLBLD.TabIndex = 47;
            this.schLBLD.Text = "生产配方";
            this.schLBLD.UseVisualStyleBackColor = true;
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
            this.schLD.chkText = "料单号";
            this.schLD.jiange = 0;
            this.schLD.Location = new System.Drawing.Point(441, 3);
            this.schLD.Name = "schLD";
            this.schLD.ReadOnly = false;
            this.schLD.Size = new System.Drawing.Size(177, 27);
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
            this.schMohu.Location = new System.Drawing.Point(755, 29);
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
            this.btnSch.Location = new System.Drawing.Point(812, 22);
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
            this.tpEdit.Location = new System.Drawing.Point(4, 22);
            this.tpEdit.Margin = new System.Windows.Forms.Padding(0);
            this.tpEdit.Name = "tpEdit";
            this.tpEdit.Padding = new System.Windows.Forms.Padding(2);
            this.tpEdit.Size = new System.Drawing.Size(976, 436);
            this.tpEdit.TabIndex = 1;
            this.tpEdit.Text = "配方成本";
            // 
            // editPanMain
            // 
            this.editPanMain.Controls.Add(this.editDgvMain);
            this.editPanMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editPanMain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editPanMain.Location = new System.Drawing.Point(2, 184);
            this.editPanMain.Margin = new System.Windows.Forms.Padding(0);
            this.editPanMain.Name = "editPanMain";
            this.editPanMain.Size = new System.Drawing.Size(970, 248);
            this.editPanMain.TabIndex = 2;
            // 
            // editDgvMain
            // 
            this.editDgvMain.AllowUserToAddRows = false;
            this.editDgvMain.AllowUserToDeleteRows = false;
            this.editDgvMain.AllowUserToResizeRows = false;
            this.editDgvMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.editDgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.editDgvMain.ColumnHeadersHeight = 32;
            this.editDgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.editDgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.editColGX,
            this.editColRL,
            this.editColBL,
            this.editColBLDW,
            this.editColYL,
            this.editColYLDW,
            this.editColJL,
            this.editColJLYL,
            this.editColJLDW,
            this.editColDJ,
            this.editColJE,
            this.editColGY,
            this.editColSN,
            this.editColSNld});
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.editDgvMain.DefaultCellStyle = dataGridViewCellStyle26;
            this.editDgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editDgvMain.Location = new System.Drawing.Point(0, 0);
            this.editDgvMain.MultiSelect = false;
            this.editDgvMain.Name = "editDgvMain";
            this.editDgvMain.ReadOnly = true;
            this.editDgvMain.RowHeadersWidth = 28;
            this.editDgvMain.RowNumShow = false;
            this.editDgvMain.RowTemplate.Height = 28;
            this.editDgvMain.Size = new System.Drawing.Size(970, 248);
            this.editDgvMain.TabIndex = 0;
            // 
            // editPanTop
            // 
            this.editPanTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.editPanTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editPanTop.Controls.Add(this.editImgLDH);
            this.editPanTop.Controls.Add(this.editTxtDDH);
            this.editPanTop.Controls.Add(this.editTxtJLCS);
            this.editPanTop.Controls.Add(this.label4);
            this.editPanTop.Controls.Add(this.label3);
            this.editPanTop.Controls.Add(this.editLblShowLB);
            this.editPanTop.Controls.Add(this.editTxtDJ);
            this.editPanTop.Controls.Add(this.editTxtMS);
            this.editPanTop.Controls.Add(this.editTxtKZ);
            this.editPanTop.Controls.Add(this.label2);
            this.editPanTop.Controls.Add(this.label1);
            this.editPanTop.Controls.Add(this.editTxtBZ);
            this.editPanTop.Controls.Add(this.editTxtZC);
            this.editPanTop.Controls.Add(this.editTxtDY);
            this.editPanTop.Controls.Add(this.editTxtZL);
            this.editPanTop.Controls.Add(this.editTxtSL);
            this.editPanTop.Controls.Add(this.editTxtJH);
            this.editPanTop.Controls.Add(this.editTxtYS);
            this.editPanTop.Controls.Add(this.editTxtSH);
            this.editPanTop.Controls.Add(this.editTxtSZ);
            this.editPanTop.Controls.Add(this.editTxtKH);
            this.editPanTop.Controls.Add(this.editBtnPrn);
            this.editPanTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.editPanTop.Location = new System.Drawing.Point(2, 2);
            this.editPanTop.Name = "editPanTop";
            this.editPanTop.Size = new System.Drawing.Size(970, 182);
            this.editPanTop.TabIndex = 0;
            // 
            // editImgLDH
            // 
            this.editImgLDH.Location = new System.Drawing.Point(54, 3);
            this.editImgLDH.Name = "editImgLDH";
            this.editImgLDH.Size = new System.Drawing.Size(190, 65);
            this.editImgLDH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.editImgLDH.TabIndex = 48;
            this.editImgLDH.TabStop = false;
            // 
            // editTxtDDH
            // 
            this.editTxtDDH.BackColor = System.Drawing.Color.Transparent;
            this.editTxtDDH.jiange = 0;
            this.editTxtDDH.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtDDH.lblText = "流程卡号";
            this.editTxtDDH.Location = new System.Drawing.Point(252, 96);
            this.editTxtDDH.Name = "editTxtDDH";
            this.editTxtDDH.ReadOnly = true;
            this.editTxtDDH.Size = new System.Drawing.Size(237, 25);
            this.editTxtDDH.TabIndex = 1;
            this.editTxtDDH.txtBackColor = System.Drawing.SystemColors.Control;
            this.editTxtDDH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtDDH.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtDDH.txtISid = false;
            this.editTxtDDH.txtISint = false;
            this.editTxtDDH.txtISmoney = false;
            this.editTxtDDH.txtLen = 50;
            this.editTxtDDH.txtMulLine = false;
            this.editTxtDDH.txtReadonly = true;
            this.editTxtDDH.txtTop = true;
            this.editTxtDDH.txtUpper = false;
            this.editTxtDDH.upperZero = false;
            // 
            // editTxtJLCS
            // 
            this.editTxtJLCS.BackColor = System.Drawing.Color.Transparent;
            this.editTxtJLCS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.editTxtJLCS.jiange = 0;
            this.editTxtJLCS.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtJLCS.lblText = "总加料次数:";
            this.editTxtJLCS.Location = new System.Drawing.Point(755, 16);
            this.editTxtJLCS.Name = "editTxtJLCS";
            this.editTxtJLCS.ReadOnly = true;
            this.editTxtJLCS.Size = new System.Drawing.Size(141, 24);
            this.editTxtJLCS.TabIndex = 23;
            this.editTxtJLCS.txtBackColor = System.Drawing.SystemColors.Control;
            this.editTxtJLCS.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtJLCS.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtJLCS.txtISid = false;
            this.editTxtJLCS.txtISint = false;
            this.editTxtJLCS.txtISmoney = false;
            this.editTxtJLCS.txtLen = 50;
            this.editTxtJLCS.txtMulLine = false;
            this.editTxtJLCS.txtReadonly = true;
            this.editTxtJLCS.txtTop = true;
            this.editTxtJLCS.txtUpper = false;
            this.editTxtJLCS.upperZero = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(754, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 14);
            this.label4.TabIndex = 46;
            this.label4.Text = "g/m";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(754, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 15);
            this.label3.TabIndex = 45;
            this.label3.Text = "m";
            // 
            // editLblShowLB
            // 
            this.editLblShowLB.BackColor = System.Drawing.Color.PaleGreen;
            this.editLblShowLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editLblShowLB.Font = new System.Drawing.Font("黑体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editLblShowLB.ForeColor = System.Drawing.Color.Red;
            this.editLblShowLB.Location = new System.Drawing.Point(760, 129);
            this.editLblShowLB.Name = "editLblShowLB";
            this.editLblShowLB.Size = new System.Drawing.Size(136, 40);
            this.editLblShowLB.TabIndex = 41;
            this.editLblShowLB.Text = "配方成本";
            this.editLblShowLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editTxtDJ
            // 
            this.editTxtDJ.BackColor = System.Drawing.Color.Transparent;
            this.editTxtDJ.jiange = 0;
            this.editTxtDJ.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtDJ.lblText = "匹数";
            this.editTxtDJ.Location = new System.Drawing.Point(658, 42);
            this.editTxtDJ.Name = "editTxtDJ";
            this.editTxtDJ.ReadOnly = true;
            this.editTxtDJ.Size = new System.Drawing.Size(96, 25);
            this.editTxtDJ.TabIndex = 8;
            this.editTxtDJ.txtBackColor = System.Drawing.SystemColors.Control;
            this.editTxtDJ.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtDJ.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtDJ.txtISid = false;
            this.editTxtDJ.txtISint = false;
            this.editTxtDJ.txtISmoney = true;
            this.editTxtDJ.txtLen = 10;
            this.editTxtDJ.txtMulLine = false;
            this.editTxtDJ.txtReadonly = true;
            this.editTxtDJ.txtTop = true;
            this.editTxtDJ.txtUpper = false;
            this.editTxtDJ.upperZero = false;
            // 
            // editTxtMS
            // 
            this.editTxtMS.BackColor = System.Drawing.Color.Transparent;
            this.editTxtMS.jiange = 0;
            this.editTxtMS.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtMS.lblText = "米数";
            this.editTxtMS.Location = new System.Drawing.Point(658, 96);
            this.editTxtMS.Name = "editTxtMS";
            this.editTxtMS.ReadOnly = true;
            this.editTxtMS.Size = new System.Drawing.Size(96, 25);
            this.editTxtMS.TabIndex = 10;
            this.editTxtMS.txtBackColor = System.Drawing.SystemColors.Control;
            this.editTxtMS.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtMS.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtMS.txtISid = false;
            this.editTxtMS.txtISint = false;
            this.editTxtMS.txtISmoney = true;
            this.editTxtMS.txtLen = 10;
            this.editTxtMS.txtMulLine = false;
            this.editTxtMS.txtReadonly = true;
            this.editTxtMS.txtTop = true;
            this.editTxtMS.txtUpper = false;
            this.editTxtMS.upperZero = false;
            // 
            // editTxtKZ
            // 
            this.editTxtKZ.BackColor = System.Drawing.Color.Transparent;
            this.editTxtKZ.jiange = 0;
            this.editTxtKZ.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtKZ.lblText = "克重";
            this.editTxtKZ.Location = new System.Drawing.Point(658, 69);
            this.editTxtKZ.Name = "editTxtKZ";
            this.editTxtKZ.ReadOnly = true;
            this.editTxtKZ.Size = new System.Drawing.Size(96, 25);
            this.editTxtKZ.TabIndex = 9;
            this.editTxtKZ.txtBackColor = System.Drawing.SystemColors.Control;
            this.editTxtKZ.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtKZ.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtKZ.txtISid = false;
            this.editTxtKZ.txtISint = false;
            this.editTxtKZ.txtISmoney = true;
            this.editTxtKZ.txtLen = 10;
            this.editTxtKZ.txtMulLine = false;
            this.editTxtKZ.txtReadonly = true;
            this.editTxtKZ.txtTop = true;
            this.editTxtKZ.txtUpper = false;
            this.editTxtKZ.upperZero = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(899, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 12);
            this.label2.TabIndex = 40;
            this.label2.Text = "Kg";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(899, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "Kg";
            // 
            // editTxtBZ
            // 
            this.editTxtBZ.BackColor = System.Drawing.Color.Transparent;
            this.editTxtBZ.jiange = 0;
            this.editTxtBZ.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtBZ.lblText = "备注";
            this.editTxtBZ.Location = new System.Drawing.Point(23, 123);
            this.editTxtBZ.Name = "editTxtBZ";
            this.editTxtBZ.ReadOnly = true;
            this.editTxtBZ.Size = new System.Drawing.Size(731, 48);
            this.editTxtBZ.TabIndex = 14;
            this.editTxtBZ.txtBackColor = System.Drawing.SystemColors.Control;
            this.editTxtBZ.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtBZ.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtBZ.txtISid = false;
            this.editTxtBZ.txtISint = false;
            this.editTxtBZ.txtISmoney = false;
            this.editTxtBZ.txtLen = 50;
            this.editTxtBZ.txtMulLine = true;
            this.editTxtBZ.txtReadonly = true;
            this.editTxtBZ.txtTop = true;
            this.editTxtBZ.txtUpper = false;
            this.editTxtBZ.upperZero = false;
            // 
            // editTxtZC
            // 
            this.editTxtZC.BackColor = System.Drawing.Color.Transparent;
            this.editTxtZC.jiange = 0;
            this.editTxtZC.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtZC.lblText = "对色";
            this.editTxtZC.Location = new System.Drawing.Point(515, 69);
            this.editTxtZC.Name = "editTxtZC";
            this.editTxtZC.ReadOnly = true;
            this.editTxtZC.Size = new System.Drawing.Size(121, 25);
            this.editTxtZC.TabIndex = 7;
            this.editTxtZC.txtBackColor = System.Drawing.SystemColors.Control;
            this.editTxtZC.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtZC.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtZC.txtISid = false;
            this.editTxtZC.txtISint = false;
            this.editTxtZC.txtISmoney = false;
            this.editTxtZC.txtLen = 50;
            this.editTxtZC.txtMulLine = false;
            this.editTxtZC.txtReadonly = true;
            this.editTxtZC.txtTop = true;
            this.editTxtZC.txtUpper = false;
            this.editTxtZC.upperZero = false;
            // 
            // editTxtDY
            // 
            this.editTxtDY.BackColor = System.Drawing.Color.Transparent;
            this.editTxtDY.jiange = 0;
            this.editTxtDY.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtDY.lblText = "打样";
            this.editTxtDY.Location = new System.Drawing.Point(515, 42);
            this.editTxtDY.Name = "editTxtDY";
            this.editTxtDY.ReadOnly = true;
            this.editTxtDY.Size = new System.Drawing.Size(121, 25);
            this.editTxtDY.TabIndex = 6;
            this.editTxtDY.txtBackColor = System.Drawing.SystemColors.Control;
            this.editTxtDY.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtDY.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtDY.txtISid = false;
            this.editTxtDY.txtISint = false;
            this.editTxtDY.txtISmoney = false;
            this.editTxtDY.txtLen = 50;
            this.editTxtDY.txtMulLine = false;
            this.editTxtDY.txtReadonly = true;
            this.editTxtDY.txtTop = true;
            this.editTxtDY.txtUpper = false;
            this.editTxtDY.upperZero = false;
            // 
            // editTxtZL
            // 
            this.editTxtZL.BackColor = System.Drawing.Color.Transparent;
            this.editTxtZL.jiange = 0;
            this.editTxtZL.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtZL.lblText = "重量";
            this.editTxtZL.Location = new System.Drawing.Point(801, 96);
            this.editTxtZL.Name = "editTxtZL";
            this.editTxtZL.ReadOnly = true;
            this.editTxtZL.Size = new System.Drawing.Size(96, 25);
            this.editTxtZL.TabIndex = 13;
            this.editTxtZL.txtBackColor = System.Drawing.SystemColors.Control;
            this.editTxtZL.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtZL.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtZL.txtISid = false;
            this.editTxtZL.txtISint = false;
            this.editTxtZL.txtISmoney = true;
            this.editTxtZL.txtLen = 10;
            this.editTxtZL.txtMulLine = false;
            this.editTxtZL.txtReadonly = true;
            this.editTxtZL.txtTop = true;
            this.editTxtZL.txtUpper = false;
            this.editTxtZL.upperZero = false;
            // 
            // editTxtSL
            // 
            this.editTxtSL.BackColor = System.Drawing.Color.Transparent;
            this.editTxtSL.jiange = 0;
            this.editTxtSL.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtSL.lblText = "浴量";
            this.editTxtSL.Location = new System.Drawing.Point(801, 70);
            this.editTxtSL.Name = "editTxtSL";
            this.editTxtSL.ReadOnly = true;
            this.editTxtSL.Size = new System.Drawing.Size(96, 25);
            this.editTxtSL.TabIndex = 12;
            this.editTxtSL.txtBackColor = System.Drawing.SystemColors.Control;
            this.editTxtSL.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtSL.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtSL.txtISid = false;
            this.editTxtSL.txtISint = false;
            this.editTxtSL.txtISmoney = true;
            this.editTxtSL.txtLen = 10;
            this.editTxtSL.txtMulLine = false;
            this.editTxtSL.txtReadonly = true;
            this.editTxtSL.txtTop = true;
            this.editTxtSL.txtUpper = false;
            this.editTxtSL.upperZero = false;
            // 
            // editTxtJH
            // 
            this.editTxtJH.BackColor = System.Drawing.Color.Transparent;
            this.editTxtJH.jiange = 0;
            this.editTxtJH.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtJH.lblText = "机号";
            this.editTxtJH.Location = new System.Drawing.Point(801, 44);
            this.editTxtJH.Name = "editTxtJH";
            this.editTxtJH.ReadOnly = true;
            this.editTxtJH.Size = new System.Drawing.Size(96, 25);
            this.editTxtJH.TabIndex = 11;
            this.editTxtJH.txtBackColor = System.Drawing.SystemColors.Control;
            this.editTxtJH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtJH.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtJH.txtISid = false;
            this.editTxtJH.txtISint = true;
            this.editTxtJH.txtISmoney = false;
            this.editTxtJH.txtLen = 3;
            this.editTxtJH.txtMulLine = false;
            this.editTxtJH.txtReadonly = true;
            this.editTxtJH.txtTop = true;
            this.editTxtJH.txtUpper = false;
            this.editTxtJH.upperZero = false;
            // 
            // editTxtYS
            // 
            this.editTxtYS.BackColor = System.Drawing.Color.Transparent;
            this.editTxtYS.jiange = 0;
            this.editTxtYS.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtYS.lblText = "颜色";
            this.editTxtYS.Location = new System.Drawing.Point(278, 69);
            this.editTxtYS.Name = "editTxtYS";
            this.editTxtYS.ReadOnly = true;
            this.editTxtYS.Size = new System.Drawing.Size(211, 25);
            this.editTxtYS.TabIndex = 5;
            this.editTxtYS.txtBackColor = System.Drawing.SystemColors.Control;
            this.editTxtYS.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtYS.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtYS.txtISid = false;
            this.editTxtYS.txtISint = false;
            this.editTxtYS.txtISmoney = false;
            this.editTxtYS.txtLen = 50;
            this.editTxtYS.txtMulLine = false;
            this.editTxtYS.txtReadonly = true;
            this.editTxtYS.txtTop = true;
            this.editTxtYS.txtUpper = false;
            this.editTxtYS.upperZero = false;
            // 
            // editTxtSH
            // 
            this.editTxtSH.BackColor = System.Drawing.Color.Transparent;
            this.editTxtSH.jiange = 0;
            this.editTxtSH.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtSH.lblText = "色号";
            this.editTxtSH.Location = new System.Drawing.Point(278, 42);
            this.editTxtSH.Name = "editTxtSH";
            this.editTxtSH.ReadOnly = true;
            this.editTxtSH.Size = new System.Drawing.Size(211, 25);
            this.editTxtSH.TabIndex = 4;
            this.editTxtSH.txtBackColor = System.Drawing.SystemColors.Control;
            this.editTxtSH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtSH.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtSH.txtISid = false;
            this.editTxtSH.txtISint = false;
            this.editTxtSH.txtISmoney = false;
            this.editTxtSH.txtLen = 50;
            this.editTxtSH.txtMulLine = false;
            this.editTxtSH.txtReadonly = true;
            this.editTxtSH.txtTop = true;
            this.editTxtSH.txtUpper = false;
            this.editTxtSH.upperZero = false;
            // 
            // editTxtSZ
            // 
            this.editTxtSZ.BackColor = System.Drawing.Color.Transparent;
            this.editTxtSZ.jiange = 0;
            this.editTxtSZ.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtSZ.lblText = "品名";
            this.editTxtSZ.Location = new System.Drawing.Point(23, 96);
            this.editTxtSZ.Name = "editTxtSZ";
            this.editTxtSZ.ReadOnly = true;
            this.editTxtSZ.Size = new System.Drawing.Size(221, 25);
            this.editTxtSZ.TabIndex = 3;
            this.editTxtSZ.txtBackColor = System.Drawing.SystemColors.Control;
            this.editTxtSZ.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtSZ.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtSZ.txtISid = false;
            this.editTxtSZ.txtISint = false;
            this.editTxtSZ.txtISmoney = false;
            this.editTxtSZ.txtLen = 50;
            this.editTxtSZ.txtMulLine = false;
            this.editTxtSZ.txtReadonly = true;
            this.editTxtSZ.txtTop = true;
            this.editTxtSZ.txtUpper = false;
            this.editTxtSZ.upperZero = false;
            // 
            // editTxtKH
            // 
            this.editTxtKH.BackColor = System.Drawing.Color.Transparent;
            this.editTxtKH.jiange = 0;
            this.editTxtKH.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtKH.lblText = "客户";
            this.editTxtKH.Location = new System.Drawing.Point(23, 70);
            this.editTxtKH.Name = "editTxtKH";
            this.editTxtKH.ReadOnly = true;
            this.editTxtKH.Size = new System.Drawing.Size(221, 25);
            this.editTxtKH.TabIndex = 2;
            this.editTxtKH.txtBackColor = System.Drawing.SystemColors.Control;
            this.editTxtKH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTxtKH.txtFont = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.editTxtKH.txtISid = false;
            this.editTxtKH.txtISint = false;
            this.editTxtKH.txtISmoney = false;
            this.editTxtKH.txtLen = 50;
            this.editTxtKH.txtMulLine = false;
            this.editTxtKH.txtReadonly = true;
            this.editTxtKH.txtTop = true;
            this.editTxtKH.txtUpper = false;
            this.editTxtKH.upperZero = false;
            // 
            // editBtnPrn
            // 
            this.editBtnPrn.BackColor = System.Drawing.SystemColors.Control;
            this.editBtnPrn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.editBtnPrn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtnPrn.Location = new System.Drawing.Point(401, 1);
            this.editBtnPrn.Name = "editBtnPrn";
            this.editBtnPrn.Size = new System.Drawing.Size(65, 25);
            this.editBtnPrn.TabIndex = 13;
            this.editBtnPrn.Text = "打印";
            this.editBtnPrn.UseVisualStyleBackColor = false;
            this.editBtnPrn.Click += new System.EventHandler(this.editBtnPrn_Click);
            // 
            // editColGX
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.editColGX.DefaultCellStyle = dataGridViewCellStyle14;
            this.editColGX.HeaderText = "染化类别";
            this.editColGX.MaxInputLength = 10;
            this.editColGX.Name = "editColGX";
            this.editColGX.ReadOnly = true;
            this.editColGX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // editColRL
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.editColRL.DefaultCellStyle = dataGridViewCellStyle15;
            this.editColRL.HeaderText = "染化料名称";
            this.editColRL.MaxInputLength = 50;
            this.editColRL.Name = "editColRL";
            this.editColRL.ReadOnly = true;
            this.editColRL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.editColRL.Width = 120;
            // 
            // editColBL
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "0.000000;-0.000000;\"\"";
            dataGridViewCellStyle16.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.editColBL.DefaultCellStyle = dataGridViewCellStyle16;
            this.editColBL.HeaderText = "比例";
            this.editColBL.MaxInputLength = 10;
            this.editColBL.Name = "editColBL";
            this.editColBL.ReadOnly = true;
            this.editColBL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.editColBL.Width = 80;
            // 
            // editColBLDW
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.editColBLDW.DefaultCellStyle = dataGridViewCellStyle17;
            this.editColBLDW.HeaderText = "浓度单位";
            this.editColBLDW.MaxInputLength = 5;
            this.editColBLDW.Name = "editColBLDW";
            this.editColBLDW.ReadOnly = true;
            this.editColBLDW.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.editColBLDW.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.editColBLDW.Width = 45;
            // 
            // editColYL
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "0.0;-0.0;\"\"";
            dataGridViewCellStyle18.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.editColYL.DefaultCellStyle = dataGridViewCellStyle18;
            this.editColYL.HeaderText = "用量";
            this.editColYL.MaxInputLength = 10;
            this.editColYL.Name = "editColYL";
            this.editColYL.ReadOnly = true;
            this.editColYL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // editColYLDW
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.editColYLDW.DefaultCellStyle = dataGridViewCellStyle19;
            this.editColYLDW.HeaderText = "用量单位";
            this.editColYLDW.MaxInputLength = 5;
            this.editColYLDW.Name = "editColYLDW";
            this.editColYLDW.ReadOnly = true;
            this.editColYLDW.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.editColYLDW.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.editColYLDW.Width = 45;
            // 
            // editColJL
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.Format = "0.#;-0.#;\"\"";
            this.editColJL.DefaultCellStyle = dataGridViewCellStyle20;
            this.editColJL.HeaderText = "加料比例";
            this.editColJL.MaxInputLength = 10;
            this.editColJL.Name = "editColJL";
            this.editColJL.ReadOnly = true;
            this.editColJL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.editColJL.Width = 75;
            // 
            // editColJLYL
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "0.0;-0.0;\"\"";
            dataGridViewCellStyle21.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.editColJLYL.DefaultCellStyle = dataGridViewCellStyle21;
            this.editColJLYL.HeaderText = "加料用量";
            this.editColJLYL.MaxInputLength = 10;
            this.editColJLYL.Name = "editColJLYL";
            this.editColJLYL.ReadOnly = true;
            this.editColJLYL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.editColJLYL.Width = 80;
            // 
            // editColJLDW
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.editColJLDW.DefaultCellStyle = dataGridViewCellStyle22;
            this.editColJLDW.HeaderText = "加料单位";
            this.editColJLDW.MaxInputLength = 5;
            this.editColJLDW.Name = "editColJLDW";
            this.editColJLDW.ReadOnly = true;
            this.editColJLDW.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.editColJLDW.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.editColJLDW.Width = 45;
            // 
            // editColDJ
            // 
            this.editColDJ.DataPropertyName = "danjia";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.Format = "0.###;-0.###;\"\"";
            this.editColDJ.DefaultCellStyle = dataGridViewCellStyle23;
            this.editColDJ.HeaderText = "单价(元/Kg)";
            this.editColDJ.Name = "editColDJ";
            this.editColDJ.ReadOnly = true;
            this.editColDJ.Width = 60;
            // 
            // editColJE
            // 
            this.editColJE.DataPropertyName = "jine";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.Format = "0.###;-0.###;\"\"";
            this.editColJE.DefaultCellStyle = dataGridViewCellStyle24;
            this.editColJE.HeaderText = "金额";
            this.editColJE.Name = "editColJE";
            this.editColJE.ReadOnly = true;
            this.editColJE.Width = 60;
            // 
            // editColGY
            // 
            this.editColGY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.editColGY.DefaultCellStyle = dataGridViewCellStyle25;
            this.editColGY.HeaderText = "工艺要求";
            this.editColGY.MaxInputLength = 20;
            this.editColGY.Name = "editColGY";
            this.editColGY.ReadOnly = true;
            this.editColGY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // editColSN
            // 
            this.editColSN.HeaderText = "SN";
            this.editColSN.Name = "editColSN";
            this.editColSN.ReadOnly = true;
            this.editColSN.Visible = false;
            // 
            // editColSNld
            // 
            this.editColSNld.HeaderText = "SNld";
            this.editColSNld.Name = "editColSNld";
            this.editColSNld.ReadOnly = true;
            this.editColSNld.Visible = false;
            // 
            // FrmPFCB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.tabPages);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmPFCB";
            this.Text = "配方成本";
            this.Load += new System.EventHandler(this.this_Load);
            this.tabPages.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.mainPanDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDgv)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.mainPanSch.ResumeLayout(false);
            this.mainPanSch.PerformLayout();
            this.tpEdit.ResumeLayout(false);
            this.editPanMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editDgvMain)).EndInit();
            this.editPanTop.ResumeLayout(false);
            this.editPanTop.PerformLayout();
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
        private Button editBtnPrn;
        private LblTxt editTxtSZ;
        private LblTxt editTxtKH;
        private LblTxt editTxtDDH;
        private LblTxt editTxtZC;
        private LblTxt editTxtDY;
        private LblTxt editTxtZL;
        private LblTxt editTxtSL;
        private LblTxt editTxtJH;
        private LblTxt editTxtYS;
        private LblTxt editTxtSH;
        private LblTxt editTxtBZ;
        private LblTxt editTxtJLCS;
        private Label label2;
        private Label label1;
        private Panel mainPanDGV;
        private Panel mainPanSch;
        private CheckBox schMohu;
        private Button btnSch;
        private dgvEX mainDgv;
        private ChkTxt schYS;
        private ChkTxt schLD;
        private ChkTxt schDDH;
        private ChkTxt schSH;
        private ChkCoboDGV schSZ;
        private ChkCoboDGV schKH;
        private ChkCoboDGV schJH;
        private ChkDtime schRQsave;
        private Label editLblShowLB;
        private LblTxt editTxtDJ;
        private LblTxt editTxtMS;
        private LblTxt editTxtKZ;
        private Label label3;
        private Label label4;
        private CheckBox schLBJL;
        private CheckBox schLBLD;
        private PictureBox editImgLDH;
        private DataGridViewTextBoxColumn mainColBH;
        private DataGridViewTextBoxColumn mainColKH;
        private DataGridViewTextBoxColumn mainColSH;
        private DataGridViewTextBoxColumn mainColYS;
        private DataGridViewTextBoxColumn mainColSZ;
        private DataGridViewTextBoxColumn mainColDDH;
        private DataGridViewTextBoxColumn mainColJH;
        private DataGridViewTextBoxColumn mainColSL;
        private DataGridViewTextBoxColumn mainColZL;
        private DataGridViewTextBoxColumn mainColKZ;
        private DataGridViewTextBoxColumn mainColMS;
        private DataGridViewTextBoxColumn mainColPS;
        private DataGridViewTextBoxColumn mainColJLCS;
        private DataGridViewTextBoxColumn mainColRQBC;
        private DataGridViewTextBoxColumn mainColPF;
        private DataGridViewTextBoxColumn mainColRQSH;
        private DataGridViewTextBoxColumn mainColFH;
        private DataGridViewTextBoxColumn mainColDY;
        private DataGridViewTextBoxColumn mainColZC;
        private DataGridViewTextBoxColumn mainColBZ;
        private DataGridViewTextBoxColumn mainColSN;
        private DataGridViewTextBoxColumn mainColSta;
        private DataGridViewTextBoxColumn mainColRQCL;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 刷新ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem 打印ToolStripMenuItem;
        private ToolStripMenuItem 导出ToolStripMenuItem;
        private DataGridViewTextBoxColumn editColGX;
        private DataGridViewTextBoxColumn editColRL;
        private DataGridViewTextBoxColumn editColBL;
        private DataGridViewTextBoxColumn editColBLDW;
        private DataGridViewTextBoxColumn editColYL;
        private DataGridViewTextBoxColumn editColYLDW;
        private DataGridViewTextBoxColumn editColJL;
        private DataGridViewTextBoxColumn editColJLYL;
        private DataGridViewTextBoxColumn editColJLDW;
        private DataGridViewTextBoxColumn editColDJ;
        private DataGridViewTextBoxColumn editColJE;
        private DataGridViewTextBoxColumn editColGY;
        private DataGridViewTextBoxColumn editColSN;
        private DataGridViewTextBoxColumn editColSNld;
    }
}
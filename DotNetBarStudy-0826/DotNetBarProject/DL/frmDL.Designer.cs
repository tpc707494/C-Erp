using DotNetBarProject.view.custom.view;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.DL
{
    partial class frmDL
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
            DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
            this.panTop = new System.Windows.Forms.Panel();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblGS = new System.Windows.Forms.Label();
            this.lblBB = new System.Windows.Forms.Label();
            this.panBottom = new System.Windows.Forms.Panel();
            this.lblBtnSch = new System.Windows.Forms.Label();
            this.dgvDT = new System.Windows.Forms.DataGridView();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBtnZero = new System.Windows.Forms.Label();
            this.lblBtnZJDL = new System.Windows.Forms.Label();
            this.lblTS = new System.Windows.Forms.Label();
            this.lblPLCerr = new System.Windows.Forms.Label();
            this.lblTPerr = new System.Windows.Forms.Label();
            this.panMid = new System.Windows.Forms.Panel();
            this.panLD = new System.Windows.Forms.Panel();
            this.dgvData = new DotNetBarProject.view.custom.view.dgvEX();
            this.colBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDLdw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblKeyS = new System.Windows.Forms.Label();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtLDH = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKZ = new DotNetBarProject.view.custom.view.LblTxt();
            this.txtDJ = new DotNetBarProject.view.custom.view.LblTxt();
            this.txtMS = new DotNetBarProject.view.custom.view.LblTxt();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtZL = new DotNetBarProject.view.custom.view.LblTxt();
            this.txtSL = new DotNetBarProject.view.custom.view.LblTxt();
            this.txtJH = new DotNetBarProject.view.custom.view.LblTxt();
            this.txtYS = new DotNetBarProject.view.custom.view.LblTxt();
            this.txtSH = new DotNetBarProject.view.custom.view.LblTxt();
            this.txtSZ = new DotNetBarProject.view.custom.view.LblTxt();
            this.txtKH = new DotNetBarProject.view.custom.view.LblTxt();
            this.txtDDH = new DotNetBarProject.view.custom.view.LblTxt();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panCL = new System.Windows.Forms.Panel();
            this.lblDLzl = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.lblDLcheng = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.lblDLwc = new System.Windows.Forms.Label();
            this.lblDLmz = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDLwd = new System.Windows.Forms.Label();
            this.lblDLzlmb = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.pBarDL = new System.Windows.Forms.ProgressBar();
            this.lblDLyc = new System.Windows.Forms.Label();
            this.lblDLrlname = new System.Windows.Forms.Label();
            this.panDT = new System.Windows.Forms.Panel();
            this.lblDLdt = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.BackColor = Color.PowderBlue;
            this.panTop.BorderStyle = BorderStyle.FixedSingle;
            this.panTop.Controls.Add((Control)this.lblExit);
            this.panTop.Controls.Add((Control)this.lblDate);
            this.panTop.Controls.Add((Control)this.lblGS);
            this.panTop.Controls.Add((Control)this.lblBB);
            this.panTop.Dock = DockStyle.Top;
            this.panTop.Location = new Point(3, 3);
            this.panTop.Name = "panTop";
            this.panTop.Size = new Size(1016, 52);
            this.panTop.TabIndex = 99;
            // 
            // lblExit
            // 
            this.lblExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblExit.Location = new Point(964, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new Size(50, 50);
            this.lblExit.TabIndex = 26;
            this.lblExit.Text = "●";
            this.lblExit.TextAlign = ContentAlignment.MiddleCenter;
            this.lblExit.MouseClick += new MouseEventHandler(this.lblExit_MouseClick);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new Font("黑体", 14f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblDate.Location = new Point(700, 17);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new Size(248, 19);
            this.lblDate.TabIndex = 23;
            this.lblDate.Text = "2016年8月19日 10:14:30";
            // 
            // lblGS
            // 
            this.lblGS.AutoSize = true;
            this.lblGS.Font = new Font("黑体", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblGS.ForeColor = Color.DarkRed;
            this.lblGS.Location = new Point(20, 14);
            this.lblGS.Name = "lblGS";
            this.lblGS.Size = new Size(235, 24);
            this.lblGS.TabIndex = 0;
            this.lblGS.Text = "配方与滴料控制系统";
            // 
            // lblBB
            // 
            this.lblBB.AutoSize = true;
            this.lblBB.Location = new Point(419, 37);
            this.lblBB.Name = "lblBB";
            this.lblBB.Size = new Size(29, 12);
            this.lblBB.TabIndex = 25;
            this.lblBB.Text = "Ver:";
            // 
            // panBottom
            // 
            this.panBottom.Controls.Add((Control)this.lblBtnSch);
            this.panBottom.Controls.Add((Control)this.dgvDT);
            this.panBottom.Controls.Add((Control)this.lblBtnZero);
            this.panBottom.Controls.Add((Control)this.lblBtnZJDL);
            this.panBottom.Controls.Add((Control)this.lblTS);
            this.panBottom.Dock = DockStyle.Bottom;
            this.panBottom.Location = new Point(3, 543);
            this.panBottom.Name = "panBottom";
            this.panBottom.Padding = new Padding(3);
            this.panBottom.Size = new Size(1016, 220);
            this.panBottom.TabIndex = 0;
            // 
            // lblBtnSch
            // 
            this.lblBtnSch.BackColor = Color.DarkCyan;
            this.lblBtnSch.BorderStyle = BorderStyle.FixedSingle;
            this.lblBtnSch.Font = new Font("黑体", 14f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblBtnSch.ForeColor = Color.White;
            this.lblBtnSch.Location = new Point(9, 57);
            this.lblBtnSch.Name = "lblBtnSch";
            this.lblBtnSch.Size = new Size(160, 40);
            this.lblBtnSch.TabIndex = 2;
            this.lblBtnSch.Text = "查询料单( • )";
            this.lblBtnSch.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvDT
            // 
            this.dgvDT.AllowUserToAddRows = false;
            this.dgvDT.AllowUserToDeleteRows = false;
            this.dgvDT.AllowUserToResizeColumns = false;
            this.dgvDT.AllowUserToResizeRows = false;
            this.dgvDT.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvDT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDT.ColumnHeadersVisible = false;
            this.dgvDT.Columns.AddRange((DataGridViewColumn)this.col1, (DataGridViewColumn)this.col2, (DataGridViewColumn)this.col3, (DataGridViewColumn)this.col4);
            gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridViewCellStyle1.BackColor = SystemColors.Window;
            gridViewCellStyle1.Font = new Font("黑体", 14f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            gridViewCellStyle1.ForeColor = SystemColors.ControlText;
            gridViewCellStyle1.Padding = new Padding(10, 0, 0, 0);
            gridViewCellStyle1.SelectionBackColor = SystemColors.Window;
            gridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            gridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            this.dgvDT.DefaultCellStyle = gridViewCellStyle1;
            this.dgvDT.Enabled = false;
            this.dgvDT.Location = new Point(179, 46);
            this.dgvDT.MultiSelect = false;
            this.dgvDT.Name = "dgvDT";
            this.dgvDT.ReadOnly = true;
            this.dgvDT.RowHeadersVisible = false;
            this.dgvDT.RowTemplate.Height = 41;
            this.dgvDT.ScrollBars = ScrollBars.None;
            this.dgvDT.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dgvDT.Size = new Size(834, 171);
            this.dgvDT.TabIndex = 0;
            // 
            // col1
            // 
            this.col1.HeaderText = "col1";
            this.col1.Name = "col1";
            this.col1.ReadOnly = true;
            this.col1.Width = 333;
            // 
            // col2
            // 
            this.col2.HeaderText = "col2";
            this.col2.Name = "col2";
            this.col2.ReadOnly = true;
            this.col2.Width = 333;
            // 
            // col3
            // 
            this.col3.HeaderText = "col3";
            this.col3.Name = "col3";
            this.col3.ReadOnly = true;
            this.col3.Width = 339;
            // 
            // col4
            // 
            this.col4.HeaderText = "col4";
            this.col4.Name = "col4";
            this.col4.ReadOnly = true;
            // 
            // lblBtnZero
            // 
            this.lblBtnZero.BackColor = Color.DarkCyan;
            this.lblBtnZero.BorderStyle = BorderStyle.FixedSingle;
            this.lblBtnZero.Font = new Font("黑体", 14f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblBtnZero.ForeColor = Color.White;
            this.lblBtnZero.Location = new Point(9, 165);
            this.lblBtnZero.Name = "lblBtnZero";
            this.lblBtnZero.Size = new Size(160, 40);
            this.lblBtnZero.TabIndex = 5;
            this.lblBtnZero.Text = "称归零 ( ０ )";
            this.lblBtnZero.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBtnZJDL
            // 
            this.lblBtnZJDL.BackColor = Color.DarkCyan;
            this.lblBtnZJDL.BorderStyle = BorderStyle.FixedSingle;
            this.lblBtnZJDL.Font = new Font("黑体", 14f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblBtnZJDL.ForeColor = Color.White;
            this.lblBtnZJDL.Location = new Point(9, 112);
            this.lblBtnZJDL.Name = "lblBtnZJDL";
            this.lblBtnZJDL.Size = new Size(160, 40);
            this.lblBtnZJDL.TabIndex = 4;
            this.lblBtnZJDL.Text = "直接滴料( * )";
            this.lblBtnZJDL.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTS
            // 
            this.lblTS.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.lblTS.BackColor = Color.Yellow;
            this.lblTS.BorderStyle = BorderStyle.FixedSingle;
            this.lblTS.Font = new Font("黑体", 20f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblTS.ForeColor = Color.DarkRed;
            this.lblTS.Location = new Point(30, 2);
            this.lblTS.Name = "lblTS";
            this.lblTS.Size = new Size(950, 39);
            this.lblTS.TabIndex = 6;
            this.lblTS.Text = "提示";
            this.lblTS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPLCerr
            // 
            this.lblPLCerr.AutoSize = true;
            this.lblPLCerr.Location = new Point(13, 16);
            this.lblPLCerr.Name = "lblPLCerr";
            this.lblPLCerr.Size = new Size(11, 12);
            this.lblPLCerr.TabIndex = 32;
            this.lblPLCerr.Text = "0";
            // 
            // lblTPerr
            // 
            this.lblTPerr.AutoSize = true;
            this.lblTPerr.Location = new Point(2, 16);
            this.lblTPerr.Name = "lblTPerr";
            this.lblTPerr.Size = new Size(11, 12);
            this.lblTPerr.TabIndex = 31;
            this.lblTPerr.Text = "0";
            // 
            // panMid
            // 
            this.panMid.Controls.Add((Control)this.panLD);
            this.panMid.Controls.Add((Control)this.panCL);
            this.panMid.Dock = DockStyle.Fill;
            this.panMid.Location = new Point(3, 55);
            this.panMid.Name = "panMid";
            this.panMid.Padding = new Padding(3);
            this.panMid.Size = new Size(1016, 488);
            this.panMid.TabIndex = 0;
            // 
            // panLD
            // 
            this.panLD.Controls.Add((Control)this.dgvData);
            this.panLD.Controls.Add((Control)this.panel3);
            this.panLD.Controls.Add((Control)this.panel4);
            this.panLD.Dock = DockStyle.Fill;
            this.panLD.Location = new Point(3, 3);
            this.panLD.Name = "panLD";
            this.panLD.Padding = new Padding(2);
            this.panLD.Size = new Size(705, 482);
            this.panLD.TabIndex = 0;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridViewCellStyle2.BackColor = SystemColors.Control;
            gridViewCellStyle2.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            gridViewCellStyle2.ForeColor = SystemColors.WindowText;
            gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            gridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = gridViewCellStyle2;
            this.dgvData.ColumnHeadersHeight = 30;
            this.dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange((DataGridViewColumn)this.colBH, (DataGridViewColumn)this.colGX, (DataGridViewColumn)this.colRL, (DataGridViewColumn)this.colYL, (DataGridViewColumn)this.colDW, (DataGridViewColumn)this.colDL, (DataGridViewColumn)this.colDLdw, (DataGridViewColumn)this.colDT, (DataGridViewColumn)this.colSN);
            gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridViewCellStyle3.BackColor = SystemColors.Window;
            gridViewCellStyle3.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            gridViewCellStyle3.ForeColor = SystemColors.ControlText;
            gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            this.dgvData.DefaultCellStyle = gridViewCellStyle3;
            this.dgvData.Dock = DockStyle.Fill;
            this.dgvData.Enabled = false;
            this.dgvData.Location = new Point(2, 115);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvData.RowNumShow = false;
            this.dgvData.RowTemplate.Height = 30;
            this.dgvData.ScrollBars = ScrollBars.None;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.ShowCellToolTips = false;
            this.dgvData.ShowEditingIcon = false;
            this.dgvData.Size = new Size(701, 335);
            this.dgvData.TabIndex = 5;
            // 
            // colBH
            // 
            gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridViewCellStyle4.ForeColor = Color.DarkRed;
            this.colBH.DefaultCellStyle = gridViewCellStyle4;
            this.colBH.HeaderText = "序号";
            this.colBH.Name = "colBH";
            this.colBH.ReadOnly = true;
            this.colBH.Width = 50;
            // 
            // colGX
            // 
            this.colGX.HeaderText = "工序";
            this.colGX.Name = "colGX";
            this.colGX.ReadOnly = true;
            // 
            // colRL
            // 
            this.colRL.HeaderText = "染料助剂名称";
            this.colRL.Name = "colRL";
            this.colRL.ReadOnly = true;
            this.colRL.Width = 150;
            // 
            // colYL
            // 
            gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridViewCellStyle5.Font = new Font("宋体", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            gridViewCellStyle5.ForeColor = Color.DarkRed;
            gridViewCellStyle5.Format = "0.####;-0.####;\"\"";
            this.colYL.DefaultCellStyle = gridViewCellStyle5;
            this.colYL.HeaderText = "用量";
            this.colYL.Name = "colYL";
            this.colYL.ReadOnly = true;
            this.colYL.Width = 120;
            // 
            // colDW
            // 
            gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.colDW.DefaultCellStyle = gridViewCellStyle6;
            this.colDW.HeaderText = "";
            this.colDW.Name = "colDW";
            this.colDW.ReadOnly = true;
            this.colDW.Width = 40;
            // 
            // colDL
            // 
            this.colDL.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridViewCellStyle7.ForeColor = Color.DarkRed;
            gridViewCellStyle7.Format = "0.##;-0.##;\"\"";
            this.colDL.DefaultCellStyle = gridViewCellStyle7;
            this.colDL.HeaderText = "已存称重";
            this.colDL.Name = "colDL";
            this.colDL.ReadOnly = true;
            // 
            // colDLdw
            // 
            gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.colDLdw.DefaultCellStyle = gridViewCellStyle8;
            this.colDLdw.HeaderText = "";
            this.colDLdw.Name = "colDLdw";
            this.colDLdw.ReadOnly = true;
            this.colDLdw.Width = 40;
            // 
            // colDT
            // 
            gridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.colDT.DefaultCellStyle = gridViewCellStyle9;
            this.colDT.HeaderText = "滴头";
            this.colDT.Name = "colDT";
            this.colDT.ReadOnly = true;
            this.colDT.Width = 50;
            // 
            // colSN
            // 
            this.colSN.HeaderText = "SN";
            this.colSN.Name = "colSN";
            this.colSN.ReadOnly = true;
            this.colSN.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = BorderStyle.FixedSingle;
            this.panel3.Controls.Add((Control)this.lblPLCerr);
            this.panel3.Controls.Add((Control)this.lblKeyS);
            this.panel3.Controls.Add((Control)this.lblTPerr);
            this.panel3.Controls.Add((Control)this.lblRowCount);
            this.panel3.Dock = DockStyle.Bottom;
            this.panel3.Location = new Point(2, 450);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(701, 30);
            this.panel3.TabIndex = 4;
            // 
            // lblKeyS
            // 
            this.lblKeyS.AutoSize = true;
            this.lblKeyS.Location = new Point(25, 16);
            this.lblKeyS.Name = "lblKeyS";
            this.lblKeyS.Size = new Size(11, 12);
            this.lblKeyS.TabIndex = 30;
            this.lblKeyS.Text = "0";
            // 
            // lblRowCount
            // 
            this.lblRowCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Font = new Font("宋体", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblRowCount.Location = new Point(588, 6);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new Size(95, 16);
            this.lblRowCount.TabIndex = 0;
            this.lblRowCount.Text = "合计: 0 条";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = BorderStyle.FixedSingle;
            this.panel4.Controls.Add((Control)this.txtLDH);
            this.panel4.Controls.Add((Control)this.label4);
            this.panel4.Controls.Add((Control)this.txtKZ);
            this.panel4.Controls.Add((Control)this.txtDJ);
            this.panel4.Controls.Add((Control)this.txtMS);
            this.panel4.Controls.Add((Control)this.label6);
            this.panel4.Controls.Add((Control)this.label8);
            this.panel4.Controls.Add((Control)this.txtZL);
            this.panel4.Controls.Add((Control)this.txtSL);
            this.panel4.Controls.Add((Control)this.txtJH);
            this.panel4.Controls.Add((Control)this.txtYS);
            this.panel4.Controls.Add((Control)this.txtSH);
            this.panel4.Controls.Add((Control)this.txtSZ);
            this.panel4.Controls.Add((Control)this.txtKH);
            this.panel4.Controls.Add((Control)this.txtDDH);
            this.panel4.Controls.Add((Control)this.label5);
            this.panel4.Controls.Add((Control)this.label3);
            this.panel4.Dock = DockStyle.Top;
            this.panel4.Location = new Point(2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(701, 113);
            this.panel4.TabIndex = 0;
            // 
            // txtLDH
            // 
            this.txtLDH.AutoSize = true;
            this.txtLDH.Font = new Font("黑体", 20f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtLDH.ForeColor = Color.DarkRed;
            this.txtLDH.Location = new Point(55, 16);
            this.txtLDH.Name = "txtLDH";
            this.txtLDH.Size = new Size(177, 27);
            this.txtLDH.TabIndex = 0;
            this.txtLDH.Text = "81808000011";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.label4.Location = new Point(13, 24);
            this.label4.Name = "label4";
            this.label4.Size = new Size(45, 14);
            this.label4.TabIndex = 53;
            this.label4.Text = "单号:";
            // 
            // txtKZ
            //
            this.txtKZ.jiange = 0;
            this.txtKZ.lblFont = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtKZ.lblText = "克重";
            this.txtKZ.Location = new Point(551, 6);
            this.txtKZ.Name = "txtKZ";
            this.txtKZ.ReadOnly = true;
            this.txtKZ.Size = new Size(96, 25);
            this.txtKZ.TabIndex = 8;
            this.txtKZ.txtBackColor = SystemColors.Window;
            this.txtKZ.txtBorderStyle = BorderStyle.FixedSingle;
            this.txtKZ.txtFont = new Font("宋体", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.txtKZ.txtISid = false;
            this.txtKZ.txtISint = false;
            this.txtKZ.txtISmoney = false;
            this.txtKZ.txtLen = 50;
            this.txtKZ.txtMulLine = false;
            this.txtKZ.txtTop = true;
            this.txtKZ.txtUpper = false;
            this.txtKZ.upperZero = false;
            // 
            // txtDJ
            // 
            this.txtDJ.jiange = 0;
            this.txtDJ.lblFont = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtDJ.lblText = "匹数";
            this.txtDJ.Location = new Point(408, 83);
            this.txtDJ.Name = "txtDJ";
            this.txtDJ.ReadOnly = true;
            this.txtDJ.Size = new Size(95, 25);
            this.txtDJ.TabIndex = 7;
            this.txtDJ.txtBackColor = SystemColors.Window;
            this.txtDJ.txtBorderStyle = BorderStyle.FixedSingle;
            this.txtDJ.txtFont = new Font("宋体", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.txtDJ.txtISid = false;
            this.txtDJ.txtISint = false;
            this.txtDJ.txtISmoney = false;
            this.txtDJ.txtLen = 50;
            this.txtDJ.txtMulLine = false;
            this.txtDJ.txtTop = true;
            this.txtDJ.txtUpper = false;
            this.txtDJ.upperZero = false;
            // 
            // txtMS
            // 
            this.txtMS.jiange = 0;
            this.txtMS.lblFont = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtMS.lblText = "米数";
            this.txtMS.Location = new Point(275, 83);
            this.txtMS.Name = "txtMS";
            this.txtMS.ReadOnly = true;
            this.txtMS.Size = new Size(88, 25);
            this.txtMS.TabIndex = 6;
            this.txtMS.txtBackColor = SystemColors.Window;
            this.txtMS.txtBorderStyle = BorderStyle.FixedSingle;
            this.txtMS.txtFont = new Font("宋体", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.txtMS.txtISid = false;
            this.txtMS.txtISint = false;
            this.txtMS.txtISmoney = false;
            this.txtMS.txtLen = 50;
            this.txtMS.txtMulLine = false;
            this.txtMS.txtTop = true;
            this.txtMS.txtUpper = false;
            this.txtMS.upperZero = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.label6.Location = new Point(649, 69);
            this.label6.Name = "label6";
            this.label6.Size = new Size(19, 12);
            this.label6.TabIndex = 45;
            this.label6.Text = "Kg";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.label8.Location = new Point(649, 95);
            this.label8.Name = "label8";
            this.label8.Size = new Size(19, 12);
            this.label8.TabIndex = 44;
            this.label8.Text = "Kg";
            // 
            // txtZL
            // 
            this.txtZL.jiange = 0;
            this.txtZL.lblFont = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtZL.lblText = "重量";
            this.txtZL.Location = new Point(551, 84);
            this.txtZL.Name = "txtZL";
            this.txtZL.ReadOnly = true;
            this.txtZL.Size = new Size(96, 25);
            this.txtZL.TabIndex = 11;
            this.txtZL.txtBackColor = SystemColors.Window;
            this.txtZL.txtBorderStyle = BorderStyle.FixedSingle;
            this.txtZL.txtFont = new Font("宋体", 11f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtZL.txtISid = false;
            this.txtZL.txtISint = false;
            this.txtZL.txtISmoney = true;
            this.txtZL.txtLen = 10;
            this.txtZL.txtMulLine = false;
            this.txtZL.txtTop = true;
            this.txtZL.txtUpper = false;
            this.txtZL.upperZero = false;
            // 
            // txtSL
            // 
            this.txtSL.jiange = 0;
            this.txtSL.lblFont = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtSL.lblText = "浴量";
            this.txtSL.Location = new Point(551, 58);
            this.txtSL.Name = "txtSL";
            this.txtSL.ReadOnly = true;
            this.txtSL.Size = new Size(96, 25);
            this.txtSL.TabIndex = 10;
            this.txtSL.txtBackColor = SystemColors.Window;
            this.txtSL.txtBorderStyle = BorderStyle.FixedSingle;
            this.txtSL.txtFont = new Font("宋体", 11f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtSL.txtISid = false;
            this.txtSL.txtISint = false;
            this.txtSL.txtISmoney = true;
            this.txtSL.txtLen = 10;
            this.txtSL.txtMulLine = false;
            this.txtSL.txtTop = true;
            this.txtSL.txtUpper = false;
            this.txtSL.upperZero = false;
            // 
            // txtJH
            // 
            this.txtJH.jiange = 0;
            this.txtJH.lblFont = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtJH.lblText = "机号";
            this.txtJH.Location = new Point(551, 32);
            this.txtJH.Name = "txtJH";
            this.txtJH.ReadOnly = true;
            this.txtJH.Size = new Size(96, 25);
            this.txtJH.TabIndex = 9;
            this.txtJH.txtBackColor = SystemColors.Window;
            this.txtJH.txtBorderStyle = BorderStyle.FixedSingle;
            this.txtJH.txtFont = new Font("宋体", 11f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtJH.txtISid = false;
            this.txtJH.txtISint = true;
            this.txtJH.txtISmoney = false;
            this.txtJH.txtLen = 3;
            this.txtJH.txtMulLine = false;
            this.txtJH.txtTop = true;
            this.txtJH.txtUpper = false;
            this.txtJH.upperZero = false;
            // 
            // txtYS
            // 
            this.txtYS.jiange = 0;
            this.txtYS.lblFont = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtYS.lblText = "颜色";
            this.txtYS.Location = new Point(275, 57);
            this.txtYS.Name = "txtYS";
            this.txtYS.ReadOnly = true;
            this.txtYS.Size = new Size(228, 25);
            this.txtYS.TabIndex = 5;
            this.txtYS.txtBackColor = SystemColors.Window;
            this.txtYS.txtBorderStyle = BorderStyle.FixedSingle;
            this.txtYS.txtFont = new Font("宋体", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.txtYS.txtISid = false;
            this.txtYS.txtISint = false;
            this.txtYS.txtISmoney = false;
            this.txtYS.txtLen = 50;
            this.txtYS.txtMulLine = false;
            this.txtYS.txtTop = true;
            this.txtYS.txtUpper = false;
            this.txtYS.upperZero = false;
            // 
            // txtSH
            // 
            this.txtSH.jiange = 0;
            this.txtSH.lblFont = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtSH.lblText = "色号";
            this.txtSH.Location = new Point(275, 31);
            this.txtSH.Name = "txtSH";
            this.txtSH.ReadOnly = true;
            this.txtSH.Size = new Size(228, 25);
            this.txtSH.TabIndex = 4;
            this.txtSH.txtBackColor = SystemColors.Window;
            this.txtSH.txtBorderStyle = BorderStyle.FixedSingle;
            this.txtSH.txtFont = new Font("宋体", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.txtSH.txtISid = false;
            this.txtSH.txtISint = false;
            this.txtSH.txtISmoney = false;
            this.txtSH.txtLen = 50;
            this.txtSH.txtMulLine = false;
            this.txtSH.txtTop = true;
            this.txtSH.txtUpper = false;
            this.txtSH.upperZero = false;
            // 
            // txtSZ
            // 
            this.txtSZ.jiange = 0;
            this.txtSZ.lblFont = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtSZ.lblText = "品名";
            this.txtSZ.Location = new Point(18, 80);
            this.txtSZ.Name = "txtSZ";
            this.txtSZ.ReadOnly = true;
            this.txtSZ.Size = new Size(222, 25);
            this.txtSZ.TabIndex = 2;
            this.txtSZ.txtBackColor = SystemColors.Window;
            this.txtSZ.txtBorderStyle = BorderStyle.FixedSingle;
            this.txtSZ.txtFont = new Font("宋体", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.txtSZ.txtISid = false;
            this.txtSZ.txtISint = false;
            this.txtSZ.txtISmoney = false;
            this.txtSZ.txtLen = 50;
            this.txtSZ.txtMulLine = false;
            this.txtSZ.txtTop = true;
            this.txtSZ.txtUpper = false;
            this.txtSZ.upperZero = false;
            // 
            // txtKH
            // 
            this.txtKH.jiange = 0;
            this.txtKH.lblFont = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtKH.lblText = "客户";
            this.txtKH.Location = new Point(18, 51);
            this.txtKH.Name = "txtKH";
            this.txtKH.ReadOnly = true;
            this.txtKH.Size = new Size(222, 25);
            this.txtKH.TabIndex = 1;
            this.txtKH.txtBackColor = SystemColors.Window;
            this.txtKH.txtBorderStyle = BorderStyle.FixedSingle;
            this.txtKH.txtFont = new Font("宋体", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.txtKH.txtISid = false;
            this.txtKH.txtISint = false;
            this.txtKH.txtISmoney = false;
            this.txtKH.txtLen = 50;
            this.txtKH.txtMulLine = false;
            this.txtKH.txtTop = true;
            this.txtKH.txtUpper = false;
            this.txtKH.upperZero = false;
            // 
            // txtDDH
            // 
            this.txtDDH.jiange = 0;
            this.txtDDH.lblFont = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtDDH.lblText = "流程卡号";
            this.txtDDH.Location = new Point(249, 5);
            this.txtDDH.Name = "txtDDH";
            this.txtDDH.ReadOnly = true;
            this.txtDDH.Size = new Size(254, 25);
            this.txtDDH.TabIndex = 3;
            this.txtDDH.txtBackColor = SystemColors.Window;
            this.txtDDH.txtBorderStyle = BorderStyle.FixedSingle;
            this.txtDDH.txtFont = new Font("宋体", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            this.txtDDH.txtISid = false;
            this.txtDDH.txtISint = false;
            this.txtDDH.txtISmoney = false;
            this.txtDDH.txtLen = 50;
            this.txtDDH.txtMulLine = false;
            this.txtDDH.txtTop = true;
            this.txtDDH.txtUpper = false;
            this.txtDDH.upperZero = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new Font("宋体", 11f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.label5.Location = new Point(362, 88);
            this.label5.Name = "label5";
            this.label5.Size = new Size(16, 15);
            this.label5.TabIndex = 51;
            this.label5.Text = "m";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.label3.Location = new Point(646, 11);
            this.label3.Name = "label3";
            this.label3.Size = new Size(31, 14);
            this.label3.TabIndex = 52;
            this.label3.Text = "g/m";
            // 
            // panCL
            // 
            this.panCL.Controls.Add((Control)this.lblDLzl);
            this.panCL.Controls.Add((Control)this.panel11);
            this.panCL.Controls.Add((Control)this.panel12);
            this.panCL.Controls.Add((Control)this.lblDLzlmb);
            this.panCL.Controls.Add((Control)this.panel10);
            this.panCL.Controls.Add((Control)this.pBarDL);
            this.panCL.Controls.Add((Control)this.lblDLyc);
            this.panCL.Controls.Add((Control)this.lblDLrlname);
            this.panCL.Controls.Add((Control)this.panDT);
            this.panCL.Dock = DockStyle.Right;
            this.panCL.Location = new Point(708, 3);
            this.panCL.Name = "panCL";
            this.panCL.Padding = new Padding(2);
            this.panCL.Size = new Size(305, 482);
            this.panCL.TabIndex = 0;
            // 
            // lblDLzl
            // 
            this.lblDLzl.BackColor = SystemColors.Window;
            this.lblDLzl.Dock = DockStyle.Fill;
            this.lblDLzl.Font = new Font("黑体", 35.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblDLzl.ForeColor = Color.DarkRed;
            this.lblDLzl.Location = new Point(2, 313);
            this.lblDLzl.Name = "lblDLzl";
            this.lblDLzl.Size = new Size(301, 86);
            this.lblDLzl.TabIndex = 7;
            this.lblDLzl.Text = "10.00 Kg";
            this.lblDLzl.TextAlign = ContentAlignment.BottomRight;
            // 
            // panel11
            // 
            this.panel11.BackColor = Color.PaleTurquoise;
            this.panel11.BorderStyle = BorderStyle.FixedSingle;
            this.panel11.Controls.Add((Control)this.label16);
            this.panel11.Controls.Add((Control)this.lblDLcheng);
            this.panel11.Dock = DockStyle.Top;
            this.panel11.Location = new Point(2, 278);
            this.panel11.Name = "panel11";
            this.panel11.Size = new Size(301, 35);
            this.panel11.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = Color.Transparent;
            this.label16.Font = new Font("宋体", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.label16.ForeColor = Color.DarkRed;
            this.label16.Location = new Point(4, 6);
            this.label16.Name = "label16";
            this.label16.Size = new Size(93, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "实际重量";
            this.label16.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDLcheng
            // 
            this.lblDLcheng.AutoSize = true;
            this.lblDLcheng.Font = new Font("宋体", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblDLcheng.Location = new Point(96, 7);
            this.lblDLcheng.Name = "lblDLcheng";
            this.lblDLcheng.Size = new Size(106, 20);
            this.lblDLcheng.TabIndex = 2;
            this.lblDLcheng.Text = "( ? 号称)";
            // 
            // panel12
            // 
            this.panel12.BackColor = Color.White;
            this.panel12.Controls.Add((Control)this.lblDLwc);
            this.panel12.Controls.Add((Control)this.lblDLmz);
            this.panel12.Controls.Add((Control)this.label1);
            this.panel12.Controls.Add((Control)this.label2);
            this.panel12.Controls.Add((Control)this.lblDLwd);
            this.panel12.Dock = DockStyle.Bottom;
            this.panel12.Location = new Point(2, 399);
            this.panel12.Name = "panel12";
            this.panel12.Size = new Size(301, 51);
            this.panel12.TabIndex = 6;
            // 
            // lblDLwc
            // 
            this.lblDLwc.AutoSize = true;
            this.lblDLwc.Font = new Font("黑体", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblDLwc.ForeColor = Color.DarkRed;
            this.lblDLwc.Location = new Point(49, 28);
            this.lblDLwc.Name = "lblDLwc";
            this.lblDLwc.Size = new Size(80, 16);
            this.lblDLwc.TabIndex = 6;
            this.lblDLwc.Text = "10.00 Kg";
            this.lblDLwc.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDLmz
            // 
            this.lblDLmz.AutoSize = true;
            this.lblDLmz.Font = new Font("黑体", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblDLmz.ForeColor = Color.DarkRed;
            this.lblDLmz.Location = new Point(204, 28);
            this.lblDLmz.Name = "lblDLmz";
            this.lblDLmz.Size = new Size(80, 16);
            this.lblDLmz.TabIndex = 9;
            this.lblDLmz.Text = "10.00 Kg";
            this.lblDLmz.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("黑体", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.label1.ForeColor = Color.Black;
            this.label1.Location = new Point(159, 30);
            this.label1.Name = "label1";
            this.label1.Size = new Size(45, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "毛重:";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("黑体", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.label2.ForeColor = Color.Black;
            this.label2.Location = new Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new Size(45, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "剩余:";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDLwd
            // 
            this.lblDLwd.AutoSize = true;
            this.lblDLwd.Font = new Font("黑体", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblDLwd.ForeColor = Color.Green;
            this.lblDLwd.Location = new Point(227, 3);
            this.lblDLwd.Name = "lblDLwd";
            this.lblDLwd.Size = new Size(42, 16);
            this.lblDLwd.TabIndex = 7;
            this.lblDLwd.Text = "稳定";
            this.lblDLwd.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDLzlmb
            // 
            this.lblDLzlmb.BackColor = SystemColors.Window;
            this.lblDLzlmb.Dock = DockStyle.Top;
            this.lblDLzlmb.Font = new Font("黑体", 35.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblDLzlmb.Location = new Point(2, 200);
            this.lblDLzlmb.Name = "lblDLzlmb";
            this.lblDLzlmb.Size = new Size(301, 78);
            this.lblDLzlmb.TabIndex = 2;
            this.lblDLzlmb.Text = "10.00 Kg";
            this.lblDLzlmb.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel10
            // 
            this.panel10.BackColor = Color.PaleTurquoise;
            this.panel10.BorderStyle = BorderStyle.FixedSingle;
            this.panel10.Controls.Add((Control)this.label13);
            this.panel10.Dock = DockStyle.Top;
            this.panel10.Location = new Point(2, 165);
            this.panel10.Name = "panel10";
            this.panel10.Size = new Size(301, 35);
            this.panel10.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = Color.Transparent;
            this.label13.Font = new Font("宋体", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.label13.ForeColor = Color.DarkRed;
            this.label13.Location = new Point(4, 6);
            this.label13.Name = "label13";
            this.label13.Size = new Size(93, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "目标重量";
            this.label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pBarDL
            // 
            this.pBarDL.Dock = DockStyle.Bottom;
            this.pBarDL.Location = new Point(2, 450);
            this.pBarDL.Name = "pBarDL";
            this.pBarDL.Size = new Size(301, 30);
            this.pBarDL.Style = ProgressBarStyle.Continuous;
            this.pBarDL.TabIndex = 5;
            this.pBarDL.Value = 50;
            // 
            // lblDLyc
            // 
            this.lblDLyc.BackColor = Color.White;
            this.lblDLyc.Dock = DockStyle.Top;
            this.lblDLyc.Font = new Font("黑体", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblDLyc.ForeColor = Color.Green;
            this.lblDLyc.Location = new Point(2, 130);
            this.lblDLyc.Name = "lblDLyc";
            this.lblDLyc.Size = new Size(301, 35);
            this.lblDLyc.TabIndex = 8;
            this.lblDLyc.Text = "用量:10.00 Kg，已称:10.00 Kg";
            this.lblDLyc.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDLrlname
            // 
            this.lblDLrlname.BackColor = SystemColors.Window;
            this.lblDLrlname.Dock = DockStyle.Top;
            this.lblDLrlname.Font = new Font("宋体", 21.75f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblDLrlname.Location = new Point(2, 37);
            this.lblDLrlname.Name = "lblDLrlname";
            this.lblDLrlname.Size = new Size(301, 93);
            this.lblDLrlname.TabIndex = 1;
            this.lblDLrlname.Text = "染料助剂名称";
            this.lblDLrlname.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panDT
            // 
            this.panDT.BackColor = Color.PaleTurquoise;
            this.panDT.BorderStyle = BorderStyle.FixedSingle;
            this.panDT.Controls.Add((Control)this.lblDLdt);
            this.panDT.Controls.Add((Control)this.label10);
            this.panDT.Dock = DockStyle.Top;
            this.panDT.Location = new Point(2, 2);
            this.panDT.Name = "panDT";
            this.panDT.Size = new Size(301, 35);
            this.panDT.TabIndex = 2;
            // 
            // lblDLdt
            // 
            this.lblDLdt.AutoSize = true;
            this.lblDLdt.Font = new Font("宋体", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblDLdt.Location = new Point(141, 7);
            this.lblDLdt.Name = "lblDLdt";
            this.lblDLdt.Size = new Size(115, 20);
            this.lblDLdt.TabIndex = 1;
            this.lblDLdt.Text = "(几号滴头)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = Color.Transparent;
            this.label10.Font = new Font("宋体", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.label10.ForeColor = Color.DarkRed;
            this.label10.Location = new Point(4, 6);
            this.label10.Name = "label10";
            this.label10.Size = new Size(135, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "染料助剂名称";
            this.label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmDL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Silver;
            this.ClientSize = new Size(1022, 766);
            this.ControlBox = false;
            this.Controls.Add((Control)this.panMid);
            this.Controls.Add((Control)this.panBottom);
            this.Controls.Add((Control)this.panTop);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Padding = new Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Deactivate += new EventHandler(this.this_Deactivate);
            this.FormClosed += new FormClosedEventHandler(this.this_FormClosed);
            this.Load += new EventHandler(this.this_Load);
            this.Shown += new EventHandler(this.this_Shown);
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.panBottom.ResumeLayout(false);
            this.panMid.ResumeLayout(false);
            this.panLD.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panCL.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panDT.ResumeLayout(false);
            this.panDT.PerformLayout();
            this.ResumeLayout(false);

            this.Name = "frmDL";
            this.Text = "frmDL";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panTop;
        private Label lblGS;
        private Label lblDate;
        private Panel panBottom;
        private DataGridView dgvDT;
        private Label lblBtnSch;
        private Panel panMid;
        private Panel panCL;
        private Label label10;
        private Label lblBtnZJDL;
        private Panel panLD;
        private Panel panel3;
        private Label lblRowCount;
        private Panel panel4;
        private LblTxt txtDJ;
        private LblTxt txtMS;
        private Label label6;
        private Label label8;
        private LblTxt txtZL;
        private LblTxt txtSL;
        private LblTxt txtJH;
        private LblTxt txtYS;
        private LblTxt txtSH;
        private LblTxt txtSZ;
        private LblTxt txtKH;
        private LblTxt txtDDH;
        private dgvEX dgvData;
        private LblTxt txtKZ;
        private Label lblDLzlmb;
        private Label lblDLrlname;
        private Panel panDT;
        private Panel panel10;
        private Label label13;
        private Label lblDLdt;
        private Panel panel11;
        private Label lblDLcheng;
        private Label label16;
        private Panel panel12;
        private ProgressBar pBarDL;
        private Label lblDLzl;
        private Label lblDLwc;
        private Label lblDLwd;
        private Label label2;
        private Label lblBB;
        private Label label5;
        private Label label3;
        private Label lblDLyc;
        private Label lblBtnZero;
        private Label lblTS;
        private Label lblExit;
        private DataGridViewTextBoxColumn col1;
        private DataGridViewTextBoxColumn col2;
        private DataGridViewTextBoxColumn col3;
        private DataGridViewTextBoxColumn col4;
        private Label label1;
        private Label lblDLmz;
        private Label lblKeyS;
        private Label txtLDH;
        private Label label4;
        private DataGridViewTextBoxColumn colBH;
        private DataGridViewTextBoxColumn colGX;
        private DataGridViewTextBoxColumn colRL;
        private DataGridViewTextBoxColumn colYL;
        private DataGridViewTextBoxColumn colDW;
        private DataGridViewTextBoxColumn colDL;
        private DataGridViewTextBoxColumn colDLdw;
        private DataGridViewTextBoxColumn colDT;
        private DataGridViewTextBoxColumn colSN;
        private Label lblPLCerr;
        private Label lblTPerr;
    }
}
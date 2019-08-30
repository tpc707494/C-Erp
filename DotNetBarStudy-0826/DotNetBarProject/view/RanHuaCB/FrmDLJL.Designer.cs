using DotNetBarProject.view.custom.view;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.RanHuaCB
{
    partial class FrmDLJL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainPanDGV = new System.Windows.Forms.Panel();
            this.mainDgv = new DotNetBarProject.view.custom.view.dgvEX();
            this.mainColLB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColRL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColDL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.颜色 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColQC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuDGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu导出Excel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu打印 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanSch = new System.Windows.Forms.Panel();
            this.schDDH = new DotNetBarProject.view.custom.view.ChkTxt();
            this.schRL = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.schDH = new DotNetBarProject.view.custom.view.ChkTxt();
            this.schRQ = new DotNetBarProject.view.custom.view.ChkDtime();
            this.schJH = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.schYS = new DotNetBarProject.view.custom.view.ChkTxt();
            this.schSH = new DotNetBarProject.view.custom.view.ChkTxt();
            this.schSZ = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.schKH = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.schMohu = new System.Windows.Forms.CheckBox();
            this.btnSch = new System.Windows.Forms.Button();
            this.mainPanDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDgv)).BeginInit();
            this.menuDGV.SuspendLayout();
            this.mainPanSch.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanDGV
            // 
            this.mainPanDGV.Controls.Add(this.mainDgv);
            this.mainPanDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanDGV.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mainPanDGV.Location = new System.Drawing.Point(0, 105);
            this.mainPanDGV.Name = "mainPanDGV";
            this.mainPanDGV.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.mainPanDGV.Size = new System.Drawing.Size(1080, 362);
            this.mainPanDGV.TabIndex = 1;
            // 
            // mainDgv
            // 
            this.mainDgv.AllowUserToAddRows = false;
            this.mainDgv.AllowUserToDeleteRows = false;
            this.mainDgv.AllowUserToResizeRows = false;
            this.mainDgv.BackgroundColor = System.Drawing.SystemColors.Window;
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
            this.mainColLB,
            this.mainColRL,
            this.mainColDL,
            this.Column5,
            this.Column1,
            this.Column3,
            this.Column2,
            this.颜色,
            this.Column4,
            this.Column6,
            this.mainColBH,
            this.mainColQC});
            this.mainDgv.ContextMenuStrip = this.menuDGV;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainDgv.DefaultCellStyle = dataGridViewCellStyle6;
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
            this.mainDgv.Size = new System.Drawing.Size(1080, 360);
            this.mainDgv.TabIndex = 1;
            // 
            // mainColLB
            // 
            this.mainColLB.DataPropertyName = "riqicheng";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "yyyy-MM-dd HH:mm";
            this.mainColLB.DefaultCellStyle = dataGridViewCellStyle2;
            this.mainColLB.HeaderText = "滴料日期";
            this.mainColLB.MaxInputLength = 5;
            this.mainColLB.Name = "mainColLB";
            this.mainColLB.ReadOnly = true;
            this.mainColLB.Width = 88;
            // 
            // mainColRL
            // 
            this.mainColRL.DataPropertyName = "ranliao";
            this.mainColRL.HeaderText = "染化料名称";
            this.mainColRL.MaxInputLength = 10;
            this.mainColRL.Name = "mainColRL";
            this.mainColRL.ReadOnly = true;
            this.mainColRL.Width = 87;
            // 
            // mainColDL
            // 
            this.mainColDL.DataPropertyName = "diliao";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "0.####;-0.####;\"\"";
            this.mainColDL.DefaultCellStyle = dataGridViewCellStyle3;
            this.mainColDL.HeaderText = "滴料重量(Kg)";
            this.mainColDL.Name = "mainColDL";
            this.mainColDL.ReadOnly = true;
            this.mainColDL.Width = 88;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "danhao";
            this.Column5.HeaderText = "料单号";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 87;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "kehu";
            this.Column1.HeaderText = "客户";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 88;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "shazhong";
            this.Column3.HeaderText = "品名";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 87;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "sehao";
            this.Column2.HeaderText = "色号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 88;
            // 
            // 颜色
            // 
            this.颜色.DataPropertyName = "yanse";
            this.颜色.HeaderText = "颜色";
            this.颜色.Name = "颜色";
            this.颜色.ReadOnly = true;
            this.颜色.Width = 87;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "jihao";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.HeaderText = "机号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 88;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "dingdan";
            this.Column6.HeaderText = "流程卡号";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 87;
            // 
            // mainColBH
            // 
            this.mainColBH.DataPropertyName = "bianhao";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mainColBH.DefaultCellStyle = dataGridViewCellStyle5;
            this.mainColBH.HeaderText = "染料编号";
            this.mainColBH.MaxInputLength = 10;
            this.mainColBH.Name = "mainColBH";
            this.mainColBH.ReadOnly = true;
            this.mainColBH.Width = 88;
            // 
            // mainColQC
            // 
            this.mainColQC.DataPropertyName = "nameAll";
            this.mainColQC.HeaderText = "染化料全称";
            this.mainColQC.Name = "mainColQC";
            this.mainColQC.ReadOnly = true;
            this.mainColQC.Width = 87;
            // 
            // menuDGV
            // 
            this.menuDGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu导出Excel,
            this.toolStripSeparator1,
            this.menu打印});
            this.menuDGV.Name = "menuDGV";
            this.menuDGV.Size = new System.Drawing.Size(130, 54);
            // 
            // menu导出Excel
            // 
            this.menu导出Excel.Name = "menu导出Excel";
            this.menu导出Excel.Size = new System.Drawing.Size(129, 22);
            this.menu导出Excel.Text = "导出Excel";
            this.menu导出Excel.Click += new System.EventHandler(this.menu导出Excel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // menu打印
            // 
            this.menu打印.Name = "menu打印";
            this.menu打印.Size = new System.Drawing.Size(129, 22);
            this.menu打印.Text = "打印";
            this.menu打印.Click += new System.EventHandler(this.menu打印_Click);
            // 
            // mainPanSch
            // 
            this.mainPanSch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.mainPanSch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanSch.Controls.Add(this.schDDH);
            this.mainPanSch.Controls.Add(this.schRL);
            this.mainPanSch.Controls.Add(this.schDH);
            this.mainPanSch.Controls.Add(this.schRQ);
            this.mainPanSch.Controls.Add(this.schJH);
            this.mainPanSch.Controls.Add(this.schYS);
            this.mainPanSch.Controls.Add(this.schSH);
            this.mainPanSch.Controls.Add(this.schSZ);
            this.mainPanSch.Controls.Add(this.schKH);
            this.mainPanSch.Controls.Add(this.schMohu);
            this.mainPanSch.Controls.Add(this.btnSch);
            this.mainPanSch.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainPanSch.Location = new System.Drawing.Point(0, 0);
            this.mainPanSch.Name = "mainPanSch";
            this.mainPanSch.Size = new System.Drawing.Size(1080, 105);
            this.mainPanSch.TabIndex = 0;
            // 
            // schDDH
            // 
            this.schDDH.allowEmpty = true;
            this.schDDH.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schDDH.chkSel = false;
            this.schDDH.chkText = "流程卡号";
            this.schDDH.jiange = 0;
            this.schDDH.Location = new System.Drawing.Point(420, 68);
            this.schDDH.Name = "schDDH";
            this.schDDH.ReadOnly = false;
            this.schDDH.Size = new System.Drawing.Size(175, 21);
            this.schDDH.TabIndex = 56;
            this.schDDH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schDDH.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schDDH.txtISid = false;
            this.schDDH.txtISint = false;
            this.schDDH.txtISmoney = false;
            this.schDDH.txtLen = 50;
            this.schDDH.txtMulLine = false;
            this.schDDH.txtTop = true;
            // 
            // schRL
            // 
            this.schRL.allowEmpty = true;
            this.schRL.allowInput = true;
            this.schRL.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schRL.chkSel = false;
            this.schRL.chkText = "染料";
            this.schRL.cobodgvFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schRL.coboFlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.schRL.jiange = 0;
            this.schRL.Location = new System.Drawing.Point(420, 35);
            this.schRL.Name = "schRL";
            this.schRL.SeparatorChar = " ";
            this.schRL.Size = new System.Drawing.Size(175, 20);
            this.schRL.TabIndex = 51;
            // 
            // schDH
            // 
            this.schDH.allowEmpty = true;
            this.schDH.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schDH.chkSel = false;
            this.schDH.chkText = "单号";
            this.schDH.jiange = 0;
            this.schDH.Location = new System.Drawing.Point(601, 3);
            this.schDH.Name = "schDH";
            this.schDH.ReadOnly = false;
            this.schDH.Size = new System.Drawing.Size(181, 27);
            this.schDH.TabIndex = 52;
            this.schDH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schDH.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schDH.txtISid = false;
            this.schDH.txtISint = false;
            this.schDH.txtISmoney = false;
            this.schDH.txtLen = 50;
            this.schDH.txtMulLine = false;
            this.schDH.txtTop = true;
            // 
            // schRQ
            // 
            this.schRQ.chkFsel = false;
            this.schRQ.chkTsel = false;
            this.schRQ.dtimeFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schRQ.dtimeFormat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.schRQ.dtimeFormatStr = "yyyy-MM-dd HH:mm";
            this.schRQ.dtimeShowUpDown = false;
            this.schRQ.jiange = 0;
            this.schRQ.lblColor = System.Drawing.SystemColors.ControlText;
            this.schRQ.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schRQ.lblText = "滴料日期";
            this.schRQ.Location = new System.Drawing.Point(3, 68);
            this.schRQ.Name = "schRQ";
            this.schRQ.Size = new System.Drawing.Size(394, 21);
            this.schRQ.TabIndex = 45;
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
            this.schJH.Location = new System.Drawing.Point(420, 3);
            this.schJH.Name = "schJH";
            this.schJH.SeparatorChar = " ";
            this.schJH.Size = new System.Drawing.Size(175, 20);
            this.schJH.TabIndex = 44;
            // 
            // schYS
            // 
            this.schYS.allowEmpty = true;
            this.schYS.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schYS.chkSel = false;
            this.schYS.chkText = "颜色";
            this.schYS.jiange = 0;
            this.schYS.Location = new System.Drawing.Point(233, 34);
            this.schYS.Name = "schYS";
            this.schYS.ReadOnly = false;
            this.schYS.Size = new System.Drawing.Size(181, 21);
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
            this.schSZ.Location = new System.Drawing.Point(20, 35);
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
            this.schMohu.Location = new System.Drawing.Point(601, 36);
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
            this.btnSch.Location = new System.Drawing.Point(696, 35);
            this.btnSch.Name = "btnSch";
            this.btnSch.Size = new System.Drawing.Size(86, 35);
            this.btnSch.TabIndex = 30;
            this.btnSch.Text = "查询";
            this.btnSch.UseVisualStyleBackColor = true;
            this.btnSch.Click += new System.EventHandler(this.btnSch_Click);
            // 
            // FrmDLJL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1080, 467);
            this.Controls.Add(this.mainPanDGV);
            this.Controls.Add(this.mainPanSch);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmDLJL";
            this.Text = "FrmDLJL";
            this.mainPanDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDgv)).EndInit();
            this.menuDGV.ResumeLayout(false);
            this.mainPanSch.ResumeLayout(false);
            this.mainPanSch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel mainPanDGV;
        private Panel mainPanSch;
        private CheckBox schMohu;
        private Button btnSch;
        private dgvEX mainDgv;
        private ChkTxt schYS;
        private ChkTxt schSH;
        private ChkCoboDGV schSZ;
        private ChkCoboDGV schKH;
        private ChkCoboDGV schJH;
        private ChkDtime schRQ;
        private ChkCoboDGV schRL;
        private ContextMenuStrip menuDGV;
        private ToolStripMenuItem menu导出Excel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem menu打印;
        private ChkTxt schDH;
        private ChkTxt schDDH;
        private DataGridViewTextBoxColumn mainColLB;
        private DataGridViewTextBoxColumn mainColRL;
        private DataGridViewTextBoxColumn mainColDL;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn 颜色;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn mainColBH;
        private DataGridViewTextBoxColumn mainColQC;
    }
}
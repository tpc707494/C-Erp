using DotNetBarProject.view.custom.view;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.RanHuaCB
{
    partial class FrmRHLCB
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsSch = new System.Windows.Forms.BindingSource(this.components);
            this.mainPanDGV = new System.Windows.Forms.Panel();
            this.mainDgv = new DotNetBarProject.view.custom.view.dgvEX();
            this.mainColBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColRL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColQC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColLB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColDJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColYL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColJE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColYLcl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColJEcl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuDGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu导出Excel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu打印 = new System.Windows.Forms.ToolStripMenuItem();
            this.schDDH = new DotNetBarProject.view.custom.view.ChkTxt();
            this.mainPanSch = new System.Windows.Forms.Panel();
            this.schRL = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.schLBRL = new System.Windows.Forms.CheckBox();
            this.schLBZJ = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.schLBLD = new System.Windows.Forms.CheckBox();
            this.schLBJL = new System.Windows.Forms.CheckBox();
            this.schRQsave = new DotNetBarProject.view.custom.view.ChkDtime();
            this.schJH = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.schYS = new DotNetBarProject.view.custom.view.ChkTxt();
            this.schSH = new DotNetBarProject.view.custom.view.ChkTxt();
            this.schSZ = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.schKH = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.schMohu = new System.Windows.Forms.CheckBox();
            this.btnSch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsSch)).BeginInit();
            this.mainPanDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDgv)).BeginInit();
            this.menuDGV.SuspendLayout();
            this.mainPanSch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanDGV
            // 
            this.mainPanDGV.Controls.Add(this.mainDgv);
            this.mainPanDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanDGV.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mainPanDGV.Location = new System.Drawing.Point(0, 77);
            this.mainPanDGV.Name = "mainPanDGV";
            this.mainPanDGV.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.mainPanDGV.Size = new System.Drawing.Size(984, 343);
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
            this.mainColRL,
            this.mainColQC,
            this.mainColLB,
            this.mainColDJ,
            this.mainColYL,
            this.mainColJE,
            this.mainColYLcl,
            this.mainColJEcl});
            this.mainDgv.ContextMenuStrip = this.menuDGV;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainDgv.DefaultCellStyle = dataGridViewCellStyle9;
            this.mainDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDgv.Location = new System.Drawing.Point(0, 2);
            this.mainDgv.MultiSelect = false;
            this.mainDgv.Name = "mainDgv";
            this.mainDgv.ReadOnly = true;
            this.mainDgv.RowHeadersWidth = 28;
            this.mainDgv.RowNumShow = false;
            this.mainDgv.RowTemplate.Height = 28;
            this.mainDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mainDgv.Size = new System.Drawing.Size(984, 341);
            this.mainDgv.TabIndex = 1;
            // 
            // mainColBH
            // 
            this.mainColBH.DataPropertyName = "bianhao";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mainColBH.DefaultCellStyle = dataGridViewCellStyle2;
            this.mainColBH.HeaderText = "染料编号";
            this.mainColBH.MaxInputLength = 10;
            this.mainColBH.Name = "mainColBH";
            this.mainColBH.ReadOnly = true;
            this.mainColBH.Width = 106;
            // 
            // mainColRL
            // 
            this.mainColRL.DataPropertyName = "item3";
            this.mainColRL.HeaderText = "染化料简称";
            this.mainColRL.MaxInputLength = 10;
            this.mainColRL.Name = "mainColRL";
            this.mainColRL.ReadOnly = true;
            this.mainColRL.Width = 106;
            // 
            // mainColQC
            // 
            this.mainColQC.DataPropertyName = "nameAll";
            this.mainColQC.HeaderText = "染化料全称";
            this.mainColQC.Name = "mainColQC";
            this.mainColQC.ReadOnly = true;
            this.mainColQC.Width = 106;
            // 
            // mainColLB
            // 
            this.mainColLB.DataPropertyName = "leibie";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mainColLB.DefaultCellStyle = dataGridViewCellStyle3;
            this.mainColLB.HeaderText = "类别";
            this.mainColLB.MaxInputLength = 5;
            this.mainColLB.Name = "mainColLB";
            this.mainColLB.ReadOnly = true;
            this.mainColLB.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.mainColLB.Width = 106;
            // 
            // mainColDJ
            // 
            this.mainColDJ.DataPropertyName = "danjia";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "0.####;-0.####;\"\"";
            this.mainColDJ.DefaultCellStyle = dataGridViewCellStyle4;
            this.mainColDJ.HeaderText = "单价(元/Kg)";
            this.mainColDJ.Name = "mainColDJ";
            this.mainColDJ.ReadOnly = true;
            this.mainColDJ.Width = 106;
            // 
            // mainColYL
            // 
            this.mainColYL.DataPropertyName = "shuliang";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "0.####;-0.####;\"\"";
            this.mainColYL.DefaultCellStyle = dataGridViewCellStyle5;
            this.mainColYL.HeaderText = "料单用量(Kg)";
            this.mainColYL.Name = "mainColYL";
            this.mainColYL.ReadOnly = true;
            this.mainColYL.Width = 106;
            // 
            // mainColJE
            // 
            this.mainColJE.DataPropertyName = "jine";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "0.###;-0.###;\"\"";
            this.mainColJE.DefaultCellStyle = dataGridViewCellStyle6;
            this.mainColJE.HeaderText = "料单金额";
            this.mainColJE.Name = "mainColJE";
            this.mainColJE.ReadOnly = true;
            this.mainColJE.Width = 106;
            // 
            // mainColYLcl
            // 
            this.mainColYLcl.DataPropertyName = "shuliangCL";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle7.Format = "0.####;-0.####;\"\"";
            this.mainColYLcl.DefaultCellStyle = dataGridViewCellStyle7;
            this.mainColYLcl.HeaderText = "称料用量(Kg)";
            this.mainColYLcl.Name = "mainColYLcl";
            this.mainColYLcl.ReadOnly = true;
            this.mainColYLcl.Width = 106;
            // 
            // mainColJEcl
            // 
            this.mainColJEcl.DataPropertyName = "jineCL";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle8.Format = "0.####;-0.####;\"\"";
            this.mainColJEcl.DefaultCellStyle = dataGridViewCellStyle8;
            this.mainColJEcl.HeaderText = "称料金额";
            this.mainColJEcl.Name = "mainColJEcl";
            this.mainColJEcl.ReadOnly = true;
            this.mainColJEcl.Width = 106;
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
            // schDDH
            // 
            this.schDDH.allowEmpty = true;
            this.schDDH.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schDDH.chkSel = false;
            this.schDDH.chkText = "流程卡号";
            this.schDDH.jiange = 0;
            this.schDDH.Location = new System.Drawing.Point(434, 49);
            this.schDDH.Name = "schDDH";
            this.schDDH.ReadOnly = false;
            this.schDDH.Size = new System.Drawing.Size(192, 27);
            this.schDDH.TabIndex = 40;
            this.schDDH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schDDH.txtFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schDDH.txtISid = false;
            this.schDDH.txtISint = false;
            this.schDDH.txtISmoney = false;
            this.schDDH.txtLen = 50;
            this.schDDH.txtMulLine = false;
            this.schDDH.txtTop = true;
            // 
            // mainPanSch
            // 
            this.mainPanSch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanSch.Controls.Add(this.schRL);
            this.mainPanSch.Controls.Add(this.groupBox2);
            this.mainPanSch.Controls.Add(this.groupBox1);
            this.mainPanSch.Controls.Add(this.schDDH);
            this.mainPanSch.Controls.Add(this.schRQsave);
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
            this.mainPanSch.Size = new System.Drawing.Size(984, 77);
            this.mainPanSch.TabIndex = 0;
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
            this.schRL.Location = new System.Drawing.Point(434, 26);
            this.schRL.Name = "schRL";
            this.schRL.SeparatorChar = " ";
            this.schRL.Size = new System.Drawing.Size(192, 20);
            this.schRL.TabIndex = 51;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.schLBRL);
            this.groupBox2.Controls.Add(this.schLBZJ);
            this.groupBox2.Location = new System.Drawing.Point(758, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(72, 64);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            // 
            // schLBRL
            // 
            this.schLBRL.AutoSize = true;
            this.schLBRL.Checked = true;
            this.schLBRL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.schLBRL.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schLBRL.ForeColor = System.Drawing.Color.DarkRed;
            this.schLBRL.Location = new System.Drawing.Point(13, 19);
            this.schLBRL.Name = "schLBRL";
            this.schLBRL.Size = new System.Drawing.Size(50, 16);
            this.schLBRL.TabIndex = 47;
            this.schLBRL.Text = "染料";
            this.schLBRL.UseVisualStyleBackColor = true;
            // 
            // schLBZJ
            // 
            this.schLBZJ.AutoSize = true;
            this.schLBZJ.Checked = true;
            this.schLBZJ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.schLBZJ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schLBZJ.ForeColor = System.Drawing.Color.DarkRed;
            this.schLBZJ.Location = new System.Drawing.Point(13, 38);
            this.schLBZJ.Name = "schLBZJ";
            this.schLBZJ.Size = new System.Drawing.Size(50, 16);
            this.schLBZJ.TabIndex = 48;
            this.schLBZJ.Text = "助剂";
            this.schLBZJ.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.schLBLD);
            this.groupBox1.Controls.Add(this.schLBJL);
            this.groupBox1.Location = new System.Drawing.Point(646, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(100, 64);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // schLBLD
            // 
            this.schLBLD.AutoSize = true;
            this.schLBLD.Checked = true;
            this.schLBLD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.schLBLD.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schLBLD.ForeColor = System.Drawing.Color.DarkRed;
            this.schLBLD.Location = new System.Drawing.Point(12, 18);
            this.schLBLD.Name = "schLBLD";
            this.schLBLD.Size = new System.Drawing.Size(76, 16);
            this.schLBLD.TabIndex = 47;
            this.schLBLD.Text = "生产配方";
            this.schLBLD.UseVisualStyleBackColor = true;
            // 
            // schLBJL
            // 
            this.schLBJL.AutoSize = true;
            this.schLBJL.Checked = true;
            this.schLBJL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.schLBJL.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schLBJL.ForeColor = System.Drawing.Color.DarkRed;
            this.schLBJL.Location = new System.Drawing.Point(12, 37);
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
            this.schJH.Location = new System.Drawing.Point(434, 3);
            this.schJH.Name = "schJH";
            this.schJH.SeparatorChar = " ";
            this.schJH.Size = new System.Drawing.Size(192, 20);
            this.schJH.TabIndex = 44;
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
            this.schMohu.Location = new System.Drawing.Point(836, 30);
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
            this.btnSch.Location = new System.Drawing.Point(890, 26);
            this.btnSch.Name = "btnSch";
            this.btnSch.Size = new System.Drawing.Size(53, 27);
            this.btnSch.TabIndex = 30;
            this.btnSch.Text = "查询";
            this.btnSch.UseVisualStyleBackColor = true;
            this.btnSch.Click += new System.EventHandler(this.btnSch_Click);
            // 
            // FrmRHLCB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 420);
            this.Controls.Add(this.mainPanDGV);
            this.Controls.Add(this.mainPanSch);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmRHLCB";
            this.Text = "染化料用量";
            this.Load += new System.EventHandler(this.this_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsSch)).EndInit();
            this.mainPanDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDgv)).EndInit();
            this.menuDGV.ResumeLayout(false);
            this.mainPanSch.ResumeLayout(false);
            this.mainPanSch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel mainPanDGV;
        private Panel mainPanSch;
        private CheckBox schMohu;
        private Button btnSch;
        private dgvEX mainDgv;
        private ChkTxt schYS;
        private ChkTxt schDDH;
        private ChkTxt schSH;
        private ChkCoboDGV schSZ;
        private ChkCoboDGV schKH;
        private ChkCoboDGV schJH;
        private ChkDtime schRQsave;
        private CheckBox schLBJL;
        private CheckBox schLBLD;
        private GroupBox groupBox2;
        private CheckBox schLBRL;
        private CheckBox schLBZJ;
        private GroupBox groupBox1;
        private ChkCoboDGV schRL;
        private ContextMenuStrip menuDGV;
        private ToolStripMenuItem menu导出Excel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem menu打印;
        private DataGridViewTextBoxColumn mainColBH;
        private DataGridViewTextBoxColumn mainColRL;
        private DataGridViewTextBoxColumn mainColQC;
        private DataGridViewTextBoxColumn mainColLB;
        private DataGridViewTextBoxColumn mainColDJ;
        private DataGridViewTextBoxColumn mainColYL;
        private DataGridViewTextBoxColumn mainColJE;
        private DataGridViewTextBoxColumn mainColYLcl;
        private DataGridViewTextBoxColumn mainColJEcl;
    }
}
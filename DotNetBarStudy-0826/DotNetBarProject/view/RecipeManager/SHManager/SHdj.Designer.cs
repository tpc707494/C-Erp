using DotNetBarProject.view.custom.view;

namespace WindowsFormsApp1.view.baseinfo
{
    partial class SHdj
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.增加空白行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ExcleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblBH = new DotNetBarProject.view.custom.view.LblTxt();
            this.lblSM = new DotNetBarProject.view.custom.view.LblCoboDGV();
            this.lblSH = new DotNetBarProject.view.custom.view.LblTxt();
            this.lblSHLB = new DotNetBarProject.view.custom.view.LblCoboDGV();
            this.lblKH = new DotNetBarProject.view.custom.view.LblCoboDGV();
            this.lblPM = new DotNetBarProject.view.custom.view.LblCoboDGV();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkSM = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.chkSH = new DotNetBarProject.view.custom.view.ChkTxt();
            this.checkMohu = new System.Windows.Forms.CheckBox();
            this.chkDtime1 = new DotNetBarProject.view.custom.view.ChkDtime();
            this.chkKH = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.chkSHLB = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.chkPM = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.dgvEX1 = new DotNetBarProject.view.custom.view.dgvEX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmsMenu.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // CmsMenu
            // 
            this.CmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加空白行ToolStripMenuItem,
            this.新增复制ToolStripMenuItem,
            this.修改ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.toolStripSeparator1,
            this.查询ToolStripMenuItem,
            this.刷新ToolStripMenuItem,
            this.toolStripSeparator2,
            this.打印ToolStripMenuItem,
            this.导出ExcleToolStripMenuItem});
            this.CmsMenu.Name = "CmsMenu";
            this.CmsMenu.Size = new System.Drawing.Size(130, 192);
            this.CmsMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.CmsMenu_Closed);
            // 
            // 增加空白行ToolStripMenuItem
            // 
            this.增加空白行ToolStripMenuItem.Name = "增加空白行ToolStripMenuItem";
            this.增加空白行ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.增加空白行ToolStripMenuItem.Text = "新增";
            this.增加空白行ToolStripMenuItem.Click += new System.EventHandler(this.增加空白行ToolStripMenuItem_Click);
            // 
            // 新增复制ToolStripMenuItem
            // 
            this.新增复制ToolStripMenuItem.Enabled = false;
            this.新增复制ToolStripMenuItem.Name = "新增复制ToolStripMenuItem";
            this.新增复制ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.新增复制ToolStripMenuItem.Text = "新增复制";
            this.新增复制ToolStripMenuItem.Click += new System.EventHandler(this.新增复制ToolStripMenuItem_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Enabled = false;
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Enabled = false;
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(126, 6);
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.打印ToolStripMenuItem.Text = "打印";
            this.打印ToolStripMenuItem.Click += new System.EventHandler(this.打印ToolStripMenuItem_Click);
            // 
            // 导出ExcleToolStripMenuItem
            // 
            this.导出ExcleToolStripMenuItem.Name = "导出ExcleToolStripMenuItem";
            this.导出ExcleToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.导出ExcleToolStripMenuItem.Text = "导出Excel";
            this.导出ExcleToolStripMenuItem.Click += new System.EventHandler(this.导出ExcleToolStripMenuItem_Click);
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 8;
            this.columnHeader9.Text = "";
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 0;
            this.columnHeader1.Text = "编号";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Text = "简称";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 2;
            this.columnHeader3.Text = "全称";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 3;
            this.columnHeader4.Text = "地址";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 4;
            this.columnHeader5.Text = "联系人";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 5;
            this.columnHeader6.Text = "电话";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 6;
            this.columnHeader7.Text = "传真";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.DisplayIndex = 7;
            this.columnHeader8.Text = "备注";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 100;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(705, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 40);
            this.button2.TabIndex = 0;
            this.button2.Text = "确认";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(705, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 34);
            this.button3.TabIndex = 1;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.lblBH);
            this.groupPanel1.Controls.Add(this.lblSM);
            this.groupPanel1.Controls.Add(this.lblSH);
            this.groupPanel1.Controls.Add(this.lblSHLB);
            this.groupPanel1.Controls.Add(this.lblKH);
            this.groupPanel1.Controls.Add(this.lblPM);
            this.groupPanel1.Controls.Add(this.button3);
            this.groupPanel1.Controls.Add(this.button2);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel1.Location = new System.Drawing.Point(10, 446);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(912, 121);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 1;
            this.groupPanel1.Text = "增加数据";
            this.groupPanel1.Visible = false;
            // 
            // lblBH
            // 
            this.lblBH.BackColor = System.Drawing.Color.Transparent;
            this.lblBH.Font = new System.Drawing.Font("宋体", 10F);
            this.lblBH.jiange = 5;
            this.lblBH.lblFont = new System.Drawing.Font("宋体", 10F);
            this.lblBH.lblText = "编号";
            this.lblBH.Location = new System.Drawing.Point(473, 46);
            this.lblBH.Margin = new System.Windows.Forms.Padding(4);
            this.lblBH.Name = "lblBH";
            this.lblBH.ReadOnly = false;
            this.lblBH.Size = new System.Drawing.Size(205, 25);
            this.lblBH.TabIndex = 9;
            this.lblBH.txtBackColor = System.Drawing.SystemColors.Window;
            this.lblBH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblBH.txtFont = new System.Drawing.Font("宋体", 10F);
            this.lblBH.txtISid = false;
            this.lblBH.txtISint = false;
            this.lblBH.txtISmoney = false;
            this.lblBH.txtLen = 50;
            this.lblBH.txtMulLine = false;
            this.lblBH.txtReadonly = false;
            this.lblBH.txtTop = true;
            this.lblBH.txtUpper = false;
            this.lblBH.upperZero = false;
            // 
            // lblSM
            // 
            this.lblSM.allowInput = true;
            this.lblSM.cobodgvFont = new System.Drawing.Font("宋体", 10F);
            this.lblSM.jiange = 5;
            this.lblSM.lblFont = new System.Drawing.Font("宋体", 10F);
            this.lblSM.lblText = "色名";
            this.lblSM.Location = new System.Drawing.Point(473, 3);
            this.lblSM.Name = "lblSM";
            this.lblSM.Size = new System.Drawing.Size(205, 25);
            this.lblSM.TabIndex = 8;
            // 
            // lblSH
            // 
            this.lblSH.BackColor = System.Drawing.Color.Transparent;
            this.lblSH.Font = new System.Drawing.Font("宋体", 10F);
            this.lblSH.jiange = 5;
            this.lblSH.lblFont = new System.Drawing.Font("宋体", 10F);
            this.lblSH.lblText = "色号";
            this.lblSH.Location = new System.Drawing.Point(236, 46);
            this.lblSH.Margin = new System.Windows.Forms.Padding(4);
            this.lblSH.Name = "lblSH";
            this.lblSH.ReadOnly = false;
            this.lblSH.Size = new System.Drawing.Size(197, 25);
            this.lblSH.TabIndex = 7;
            this.lblSH.txtBackColor = System.Drawing.SystemColors.Window;
            this.lblSH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblSH.txtFont = new System.Drawing.Font("宋体", 10F);
            this.lblSH.txtISid = false;
            this.lblSH.txtISint = false;
            this.lblSH.txtISmoney = false;
            this.lblSH.txtLen = 50;
            this.lblSH.txtMulLine = false;
            this.lblSH.txtReadonly = false;
            this.lblSH.txtTop = true;
            this.lblSH.txtUpper = false;
            this.lblSH.upperZero = false;
            // 
            // lblSHLB
            // 
            this.lblSHLB.allowInput = true;
            this.lblSHLB.cobodgvFont = new System.Drawing.Font("宋体", 10F);
            this.lblSHLB.jiange = 5;
            this.lblSHLB.lblFont = new System.Drawing.Font("宋体", 10F);
            this.lblSHLB.lblText = "色号类别";
            this.lblSHLB.Location = new System.Drawing.Point(20, 46);
            this.lblSHLB.Name = "lblSHLB";
            this.lblSHLB.Size = new System.Drawing.Size(205, 25);
            this.lblSHLB.TabIndex = 6;
            // 
            // lblKH
            // 
            this.lblKH.allowInput = true;
            this.lblKH.cobodgvFont = new System.Drawing.Font("宋体", 10F);
            this.lblKH.jiange = 5;
            this.lblKH.lblFont = new System.Drawing.Font("宋体", 10F);
            this.lblKH.lblText = "客户";
            this.lblKH.Location = new System.Drawing.Point(53, 3);
            this.lblKH.Name = "lblKH";
            this.lblKH.Size = new System.Drawing.Size(172, 25);
            this.lblKH.TabIndex = 5;
            // 
            // lblPM
            // 
            this.lblPM.allowInput = true;
            this.lblPM.cobodgvFont = new System.Drawing.Font("宋体", 10F);
            this.lblPM.jiange = 5;
            this.lblPM.lblFont = new System.Drawing.Font("宋体", 10F);
            this.lblPM.lblText = "品名";
            this.lblPM.Location = new System.Drawing.Point(241, 3);
            this.lblPM.Name = "lblPM";
            this.lblPM.Size = new System.Drawing.Size(192, 25);
            this.lblPM.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(764, 41);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 24);
            this.button4.TabIndex = 9;
            this.button4.Text = "取消";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(647, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 24);
            this.button1.TabIndex = 8;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.chkSM);
            this.panel1.Controls.Add(this.chkSH);
            this.panel1.Controls.Add(this.checkMohu);
            this.panel1.Controls.Add(this.chkDtime1);
            this.panel1.Controls.Add(this.chkKH);
            this.panel1.Controls.Add(this.chkSHLB);
            this.panel1.Controls.Add(this.chkPM);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 102);
            this.panel1.TabIndex = 13;
            this.panel1.Visible = false;
            // 
            // chkSM
            // 
            this.chkSM.allowEmpty = false;
            this.chkSM.allowInput = true;
            this.chkSM.chkFont = new System.Drawing.Font("宋体", 10F);
            this.chkSM.chkSel = false;
            this.chkSM.chkText = "色名";
            this.chkSM.cobodgvFont = new System.Drawing.Font("宋体", 10F);
            this.chkSM.coboFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSM.jiange = 0;
            this.chkSM.Location = new System.Drawing.Point(415, 11);
            this.chkSM.Name = "chkSM";
            this.chkSM.SeparatorChar = " ";
            this.chkSM.Size = new System.Drawing.Size(208, 21);
            this.chkSM.TabIndex = 17;
            // 
            // chkSH
            // 
            this.chkSH.allowEmpty = false;
            this.chkSH.chkFont = new System.Drawing.Font("宋体", 10F);
            this.chkSH.chkSel = false;
            this.chkSH.chkText = "色号";
            this.chkSH.jiange = 0;
            this.chkSH.Location = new System.Drawing.Point(204, 44);
            this.chkSH.Name = "chkSH";
            this.chkSH.ReadOnly = false;
            this.chkSH.Size = new System.Drawing.Size(196, 24);
            this.chkSH.TabIndex = 16;
            this.chkSH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkSH.txtFont = new System.Drawing.Font("宋体", 10F);
            this.chkSH.txtISid = false;
            this.chkSH.txtISint = false;
            this.chkSH.txtISmoney = false;
            this.chkSH.txtLen = 50;
            this.chkSH.txtMulLine = false;
            this.chkSH.txtTop = true;
            // 
            // checkMohu
            // 
            this.checkMohu.AutoSize = true;
            this.checkMohu.Font = new System.Drawing.Font("宋体", 10F);
            this.checkMohu.Location = new System.Drawing.Point(569, 50);
            this.checkMohu.Name = "checkMohu";
            this.checkMohu.Size = new System.Drawing.Size(54, 18);
            this.checkMohu.TabIndex = 15;
            this.checkMohu.Text = "模糊";
            this.checkMohu.UseVisualStyleBackColor = true;
            // 
            // chkDtime1
            // 
            this.chkDtime1.chkFsel = false;
            this.chkDtime1.chkTsel = false;
            this.chkDtime1.dtimeFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDtime1.dtimeFormat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.chkDtime1.dtimeFormatStr = "yyyy-MM-dd HH:mm";
            this.chkDtime1.dtimeShowUpDown = false;
            this.chkDtime1.jiange = 0;
            this.chkDtime1.lblColor = System.Drawing.SystemColors.ControlText;
            this.chkDtime1.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDtime1.lblText = "时间";
            this.chkDtime1.Location = new System.Drawing.Point(3, 74);
            this.chkDtime1.Name = "chkDtime1";
            this.chkDtime1.Size = new System.Drawing.Size(467, 21);
            this.chkDtime1.TabIndex = 14;
            // 
            // chkKH
            // 
            this.chkKH.allowEmpty = false;
            this.chkKH.allowInput = true;
            this.chkKH.chkFont = new System.Drawing.Font("宋体", 10F);
            this.chkKH.chkSel = false;
            this.chkKH.chkText = "客户";
            this.chkKH.cobodgvFont = new System.Drawing.Font("宋体", 10F);
            this.chkKH.coboFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkKH.jiange = 0;
            this.chkKH.Location = new System.Drawing.Point(3, 10);
            this.chkKH.Name = "chkKH";
            this.chkKH.SeparatorChar = " ";
            this.chkKH.Size = new System.Drawing.Size(195, 21);
            this.chkKH.TabIndex = 13;
            // 
            // chkSHLB
            // 
            this.chkSHLB.allowEmpty = false;
            this.chkSHLB.allowInput = true;
            this.chkSHLB.chkFont = new System.Drawing.Font("宋体", 10F);
            this.chkSHLB.chkSel = false;
            this.chkSHLB.chkText = "色号类别";
            this.chkSHLB.cobodgvFont = new System.Drawing.Font("宋体", 10F);
            this.chkSHLB.coboFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSHLB.jiange = 0;
            this.chkSHLB.Location = new System.Drawing.Point(3, 44);
            this.chkSHLB.Name = "chkSHLB";
            this.chkSHLB.SeparatorChar = " ";
            this.chkSHLB.Size = new System.Drawing.Size(195, 21);
            this.chkSHLB.TabIndex = 12;
            // 
            // chkPM
            // 
            this.chkPM.allowEmpty = false;
            this.chkPM.allowInput = true;
            this.chkPM.chkFont = new System.Drawing.Font("宋体", 10F);
            this.chkPM.chkSel = false;
            this.chkPM.chkText = "品名";
            this.chkPM.cobodgvFont = new System.Drawing.Font("宋体", 10F);
            this.chkPM.coboFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPM.jiange = 0;
            this.chkPM.Location = new System.Drawing.Point(204, 10);
            this.chkPM.Name = "chkPM";
            this.chkPM.SeparatorChar = " ";
            this.chkPM.Size = new System.Drawing.Size(196, 21);
            this.chkPM.TabIndex = 10;
            // 
            // dgvEX1
            // 
            this.dgvEX1.AllowUserToAddRows = false;
            this.dgvEX1.AllowUserToDeleteRows = false;
            this.dgvEX1.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column7,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEX1.EnableHeadersVisualStyles = false;
            this.dgvEX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvEX1.Location = new System.Drawing.Point(10, 112);
            this.dgvEX1.Name = "dgvEX1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEX1.RowHeadersWidth = 60;
            this.dgvEX1.RowNumShow = true;
            this.dgvEX1.RowTemplate.Height = 23;
            this.dgvEX1.Size = new System.Drawing.Size(912, 455);
            this.dgvEX1.TabIndex = 2;
            this.dgvEX1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_CellDoubleClick);
            this.dgvEX1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.datagrid_CellMouseDown);
            this.dgvEX1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvEX1_MouseDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "编号";
            this.Column1.Name = "Column1";
            this.Column1.Width = 109;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "客户";
            this.Column2.Name = "Column2";
            this.Column2.Width = 109;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "色号";
            this.Column3.Name = "Column3";
            this.Column3.Width = 109;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "色名";
            this.Column7.Name = "Column7";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "品名";
            this.Column4.Name = "Column4";
            this.Column4.Width = 108;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "色号类别";
            this.Column5.Name = "Column5";
            this.Column5.Width = 109;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "日期";
            this.Column6.Name = "Column6";
            this.Column6.Width = 180;
            // 
            // SHdj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(932, 577);
            this.Controls.Add(this.dgvEX1);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SHdj";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.ColorName_Load);
            this.CmsMenu.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ContextMenuStrip CmsMenu;
        private System.Windows.Forms.ToolStripMenuItem 增加空白行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 打印ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ExcleToolStripMenuItem;
        private dgvEX dgvEX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private LblCoboDGV lblPM;
        private LblCoboDGV lblKH;
        private ChkCoboDGV chkPM;
        private LblCoboDGV lblSHLB;
        private ChkCoboDGV chkSHLB;
        private ChkCoboDGV chkKH;
        private ChkDtime chkDtime1;
        private System.Windows.Forms.CheckBox checkMohu;
        private LblTxt lblSH;
        private ChkTxt chkSH;
        private LblCoboDGV lblSM;
        private ChkCoboDGV chkSM;
        private System.Windows.Forms.ToolStripMenuItem 新增复制ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private LblTxt lblBH;
    }
}
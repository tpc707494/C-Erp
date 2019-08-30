using DotNetBarProject.view.custom.view;

namespace WindowsFormsApp1.view.baseinfo
{
    partial class RanHuaName
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
            this.lblTxt6 = new DotNetBarProject.view.custom.view.LblTxt();
            this.lblTxt2 = new DotNetBarProject.view.custom.view.LblCoboDGV();
            this.lblTxt5 = new DotNetBarProject.view.custom.view.LblTxt();
            this.lblTxt4 = new DotNetBarProject.view.custom.view.LblTxt();
            this.lblTxt3 = new DotNetBarProject.view.custom.view.LblTxt();
            this.lblTxt1 = new DotNetBarProject.view.custom.view.LblTxt();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkType = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkmingcheng = new DotNetBarProject.view.custom.view.ChkTxt();
            this.chkdanjia = new DotNetBarProject.view.custom.view.ChkTxt();
            this.chkgonghuoshang = new DotNetBarProject.view.custom.view.ChkTxt();
            this.chkBianhao = new DotNetBarProject.view.custom.view.ChkTxt();
            this.dgvEX1 = new DotNetBarProject.view.custom.view.dgvEX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.修改ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.toolStripSeparator1,
            this.查询ToolStripMenuItem,
            this.刷新ToolStripMenuItem,
            this.toolStripSeparator2,
            this.打印ToolStripMenuItem,
            this.导出ExcleToolStripMenuItem});
            this.CmsMenu.Name = "CmsMenu";
            this.CmsMenu.Size = new System.Drawing.Size(130, 170);
            this.CmsMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.CmsMenu_Closed);
            // 
            // 增加空白行ToolStripMenuItem
            // 
            this.增加空白行ToolStripMenuItem.Name = "增加空白行ToolStripMenuItem";
            this.增加空白行ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.增加空白行ToolStripMenuItem.Text = "新增";
            this.增加空白行ToolStripMenuItem.Click += new System.EventHandler(this.增加空白行ToolStripMenuItem_Click);
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
            this.button2.Location = new System.Drawing.Point(722, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 40);
            this.button2.TabIndex = 8;
            this.button2.Text = "确认";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(830, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 40);
            this.button3.TabIndex = 9;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.lblTxt6);
            this.groupPanel1.Controls.Add(this.lblTxt2);
            this.groupPanel1.Controls.Add(this.lblTxt5);
            this.groupPanel1.Controls.Add(this.lblTxt4);
            this.groupPanel1.Controls.Add(this.lblTxt3);
            this.groupPanel1.Controls.Add(this.lblTxt1);
            this.groupPanel1.Controls.Add(this.button3);
            this.groupPanel1.Controls.Add(this.button2);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel1.Location = new System.Drawing.Point(10, 393);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(933, 126);
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
            // lblTxt6
            // 
            this.lblTxt6.BackColor = System.Drawing.Color.Transparent;
            this.lblTxt6.Font = new System.Drawing.Font("宋体", 10F);
            this.lblTxt6.jiange = -5;
            this.lblTxt6.lblFont = new System.Drawing.Font("宋体", 10F);
            this.lblTxt6.lblText = "染料简称";
            this.lblTxt6.Location = new System.Drawing.Point(501, 2);
            this.lblTxt6.Margin = new System.Windows.Forms.Padding(4);
            this.lblTxt6.Name = "lblTxt6";
            this.lblTxt6.ReadOnly = false;
            this.lblTxt6.Size = new System.Drawing.Size(186, 25);
            this.lblTxt6.TabIndex = 6;
            this.lblTxt6.txtBackColor = System.Drawing.SystemColors.Window;
            this.lblTxt6.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTxt6.txtFont = new System.Drawing.Font("宋体", 12F);
            this.lblTxt6.txtISid = false;
            this.lblTxt6.txtISint = false;
            this.lblTxt6.txtISmoney = false;
            this.lblTxt6.txtLen = 50;
            this.lblTxt6.txtMulLine = false;
            this.lblTxt6.txtReadonly = false;
            this.lblTxt6.txtTop = true;
            this.lblTxt6.txtUpper = false;
            this.lblTxt6.upperZero = false;
            // 
            // lblTxt2
            // 
            this.lblTxt2.allowInput = true;
            this.lblTxt2.cobodgvFont = new System.Drawing.Font("宋体", 10F);
            this.lblTxt2.jiange = 5;
            this.lblTxt2.lblFont = new System.Drawing.Font("宋体", 10F);
            this.lblTxt2.lblText = "类别";
            this.lblTxt2.Location = new System.Drawing.Point(242, 3);
            this.lblTxt2.Name = "lblTxt2";
            this.lblTxt2.Size = new System.Drawing.Size(225, 24);
            this.lblTxt2.TabIndex = 3;
            // 
            // lblTxt5
            // 
            this.lblTxt5.BackColor = System.Drawing.Color.Transparent;
            this.lblTxt5.Font = new System.Drawing.Font("宋体", 10F);
            this.lblTxt5.jiange = -5;
            this.lblTxt5.lblFont = new System.Drawing.Font("宋体", 10F);
            this.lblTxt5.lblText = "供货商";
            this.lblTxt5.Location = new System.Drawing.Point(228, 49);
            this.lblTxt5.Margin = new System.Windows.Forms.Padding(4);
            this.lblTxt5.Name = "lblTxt5";
            this.lblTxt5.ReadOnly = false;
            this.lblTxt5.Size = new System.Drawing.Size(239, 25);
            this.lblTxt5.TabIndex = 5;
            this.lblTxt5.txtBackColor = System.Drawing.SystemColors.Window;
            this.lblTxt5.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTxt5.txtFont = new System.Drawing.Font("宋体", 12F);
            this.lblTxt5.txtISid = false;
            this.lblTxt5.txtISint = false;
            this.lblTxt5.txtISmoney = false;
            this.lblTxt5.txtLen = 50;
            this.lblTxt5.txtMulLine = false;
            this.lblTxt5.txtReadonly = false;
            this.lblTxt5.txtTop = true;
            this.lblTxt5.txtUpper = false;
            this.lblTxt5.upperZero = false;
            // 
            // lblTxt4
            // 
            this.lblTxt4.BackColor = System.Drawing.Color.Transparent;
            this.lblTxt4.jiange = -5;
            this.lblTxt4.lblFont = new System.Drawing.Font("宋体", 10F);
            this.lblTxt4.lblText = "单价";
            this.lblTxt4.Location = new System.Drawing.Point(20, 49);
            this.lblTxt4.Name = "lblTxt4";
            this.lblTxt4.ReadOnly = false;
            this.lblTxt4.Size = new System.Drawing.Size(174, 25);
            this.lblTxt4.TabIndex = 4;
            this.lblTxt4.txtBackColor = System.Drawing.SystemColors.Window;
            this.lblTxt4.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTxt4.txtFont = new System.Drawing.Font("宋体", 12F);
            this.lblTxt4.txtISid = false;
            this.lblTxt4.txtISint = false;
            this.lblTxt4.txtISmoney = false;
            this.lblTxt4.txtLen = 50;
            this.lblTxt4.txtMulLine = false;
            this.lblTxt4.txtReadonly = false;
            this.lblTxt4.txtTop = true;
            this.lblTxt4.txtUpper = false;
            this.lblTxt4.upperZero = false;
            // 
            // lblTxt3
            // 
            this.lblTxt3.BackColor = System.Drawing.Color.Transparent;
            this.lblTxt3.Font = new System.Drawing.Font("宋体", 1F);
            this.lblTxt3.jiange = -5;
            this.lblTxt3.lblFont = new System.Drawing.Font("宋体", 1F);
            this.lblTxt3.lblText = "染料名称";
            this.lblTxt3.Location = new System.Drawing.Point(501, 49);
            this.lblTxt3.Margin = new System.Windows.Forms.Padding(4);
            this.lblTxt3.Name = "lblTxt3";
            this.lblTxt3.ReadOnly = false;
            this.lblTxt3.Size = new System.Drawing.Size(186, 25);
            this.lblTxt3.TabIndex = 7;
            this.lblTxt3.txtBackColor = System.Drawing.SystemColors.Window;
            this.lblTxt3.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTxt3.txtFont = new System.Drawing.Font("宋体", 12F);
            this.lblTxt3.txtISid = false;
            this.lblTxt3.txtISint = false;
            this.lblTxt3.txtISmoney = false;
            this.lblTxt3.txtLen = 50;
            this.lblTxt3.txtMulLine = false;
            this.lblTxt3.txtReadonly = false;
            this.lblTxt3.txtTop = true;
            this.lblTxt3.txtUpper = false;
            this.lblTxt3.upperZero = false;
            // 
            // lblTxt1
            // 
            this.lblTxt1.BackColor = System.Drawing.Color.Transparent;
            this.lblTxt1.jiange = -5;
            this.lblTxt1.lblFont = new System.Drawing.Font("宋体", 10F);
            this.lblTxt1.lblText = "编号";
            this.lblTxt1.Location = new System.Drawing.Point(20, 3);
            this.lblTxt1.Name = "lblTxt1";
            this.lblTxt1.ReadOnly = false;
            this.lblTxt1.Size = new System.Drawing.Size(174, 25);
            this.lblTxt1.TabIndex = 2;
            this.lblTxt1.txtBackColor = System.Drawing.SystemColors.Window;
            this.lblTxt1.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTxt1.txtFont = new System.Drawing.Font("宋体", 12F);
            this.lblTxt1.txtISid = false;
            this.lblTxt1.txtISint = false;
            this.lblTxt1.txtISmoney = false;
            this.lblTxt1.txtLen = 50;
            this.lblTxt1.txtMulLine = false;
            this.lblTxt1.txtReadonly = false;
            this.lblTxt1.txtTop = true;
            this.lblTxt1.txtUpper = false;
            this.lblTxt1.upperZero = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(772, 53);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(138, 24);
            this.button4.TabIndex = 9;
            this.button4.Text = "取消";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(579, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 24);
            this.button1.TabIndex = 8;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.chkType);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.chkmingcheng);
            this.panel1.Controls.Add(this.chkdanjia);
            this.panel1.Controls.Add(this.chkgonghuoshang);
            this.panel1.Controls.Add(this.chkBianhao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 98);
            this.panel1.TabIndex = 13;
            // 
            // chkType
            // 
            this.chkType.allowEmpty = false;
            this.chkType.allowInput = true;
            this.chkType.chkFont = new System.Drawing.Font("宋体", 10F);
            this.chkType.chkSel = false;
            this.chkType.chkText = "类别";
            this.chkType.cobodgvFont = new System.Drawing.Font("宋体", 10F);
            this.chkType.coboFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkType.Font = new System.Drawing.Font("宋体", 12F);
            this.chkType.jiange = 0;
            this.chkType.Location = new System.Drawing.Point(245, 17);
            this.chkType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkType.Name = "chkType";
            this.chkType.SeparatorChar = " ";
            this.chkType.Size = new System.Drawing.Size(208, 21);
            this.chkType.TabIndex = 17;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.checkBox1.Location = new System.Drawing.Point(492, 61);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(54, 18);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "模糊";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chkmingcheng
            // 
            this.chkmingcheng.allowEmpty = false;
            this.chkmingcheng.chkFont = new System.Drawing.Font("宋体", 10F);
            this.chkmingcheng.chkSel = false;
            this.chkmingcheng.chkText = "染料名称";
            this.chkmingcheng.jiange = 0;
            this.chkmingcheng.Location = new System.Drawing.Point(492, 17);
            this.chkmingcheng.Name = "chkmingcheng";
            this.chkmingcheng.ReadOnly = false;
            this.chkmingcheng.Size = new System.Drawing.Size(225, 24);
            this.chkmingcheng.TabIndex = 15;
            this.chkmingcheng.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkmingcheng.txtFont = new System.Drawing.Font("宋体", 12F);
            this.chkmingcheng.txtISid = false;
            this.chkmingcheng.txtISint = false;
            this.chkmingcheng.txtISmoney = false;
            this.chkmingcheng.txtLen = 50;
            this.chkmingcheng.txtMulLine = false;
            this.chkmingcheng.txtTop = true;
            // 
            // chkdanjia
            // 
            this.chkdanjia.allowEmpty = false;
            this.chkdanjia.chkFont = new System.Drawing.Font("宋体", 10F);
            this.chkdanjia.chkSel = false;
            this.chkdanjia.chkText = "单价";
            this.chkdanjia.jiange = 0;
            this.chkdanjia.Location = new System.Drawing.Point(12, 53);
            this.chkdanjia.Name = "chkdanjia";
            this.chkdanjia.ReadOnly = false;
            this.chkdanjia.Size = new System.Drawing.Size(216, 24);
            this.chkdanjia.TabIndex = 14;
            this.chkdanjia.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkdanjia.txtFont = new System.Drawing.Font("宋体", 12F);
            this.chkdanjia.txtISid = false;
            this.chkdanjia.txtISint = false;
            this.chkdanjia.txtISmoney = false;
            this.chkdanjia.txtLen = 50;
            this.chkdanjia.txtMulLine = false;
            this.chkdanjia.txtTop = true;
            // 
            // chkgonghuoshang
            // 
            this.chkgonghuoshang.allowEmpty = false;
            this.chkgonghuoshang.chkFont = new System.Drawing.Font("宋体", 10F);
            this.chkgonghuoshang.chkSel = false;
            this.chkgonghuoshang.chkText = "供货商";
            this.chkgonghuoshang.jiange = 0;
            this.chkgonghuoshang.Location = new System.Drawing.Point(245, 53);
            this.chkgonghuoshang.Name = "chkgonghuoshang";
            this.chkgonghuoshang.ReadOnly = false;
            this.chkgonghuoshang.Size = new System.Drawing.Size(225, 24);
            this.chkgonghuoshang.TabIndex = 13;
            this.chkgonghuoshang.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkgonghuoshang.txtFont = new System.Drawing.Font("宋体", 12F);
            this.chkgonghuoshang.txtISid = false;
            this.chkgonghuoshang.txtISint = false;
            this.chkgonghuoshang.txtISmoney = false;
            this.chkgonghuoshang.txtLen = 50;
            this.chkgonghuoshang.txtMulLine = false;
            this.chkgonghuoshang.txtTop = true;
            // 
            // chkBianhao
            // 
            this.chkBianhao.allowEmpty = false;
            this.chkBianhao.chkFont = new System.Drawing.Font("宋体", 10F);
            this.chkBianhao.chkSel = false;
            this.chkBianhao.chkText = "编号";
            this.chkBianhao.jiange = 0;
            this.chkBianhao.Location = new System.Drawing.Point(12, 17);
            this.chkBianhao.Name = "chkBianhao";
            this.chkBianhao.ReadOnly = false;
            this.chkBianhao.Size = new System.Drawing.Size(216, 24);
            this.chkBianhao.TabIndex = 12;
            this.chkBianhao.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkBianhao.txtFont = new System.Drawing.Font("宋体", 12F);
            this.chkBianhao.txtISid = false;
            this.chkBianhao.txtISint = false;
            this.chkBianhao.txtISmoney = false;
            this.chkBianhao.txtLen = 50;
            this.chkBianhao.txtMulLine = false;
            this.chkBianhao.txtTop = true;
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
            this.Column6,
            this.Column3,
            this.Column4,
            this.Column5});
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
            this.dgvEX1.Location = new System.Drawing.Point(10, 108);
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
            this.dgvEX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEX1.Size = new System.Drawing.Size(933, 411);
            this.dgvEX1.TabIndex = 2;
            this.dgvEX1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_CellDoubleClick);
            this.dgvEX1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.datagrid_CellMouseDown);
            this.dgvEX1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvEX1_MouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "编号";
            this.Column1.Name = "Column1";
            this.Column1.Width = 174;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "类别";
            this.Column2.Name = "Column2";
            this.Column2.Width = 174;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "染料简称";
            this.Column6.Name = "Column6";
            this.Column6.Width = 175;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "染料名称";
            this.Column3.Name = "Column3";
            this.Column3.Width = 175;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "单价";
            this.Column4.Name = "Column4";
            this.Column4.Width = 174;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "供货商";
            this.Column5.Name = "Column5";
            this.Column5.Width = 174;
            // 
            // RanHuaName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(953, 529);
            this.Controls.Add(this.dgvEX1);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RanHuaName";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.RanHuaName_Load);
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
        private ChkTxt chkBianhao;
        private LblTxt lblTxt1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private ChkTxt chkdanjia;
        private ChkTxt chkgonghuoshang;
        private ChkTxt chkmingcheng;
        private LblTxt lblTxt3;
        private LblTxt lblTxt5;
        private LblTxt lblTxt4;
        private System.Windows.Forms.CheckBox checkBox1;
        private ChkCoboDGV chkType;
        private LblCoboDGV lblTxt2;
        private LblTxt lblTxt6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}
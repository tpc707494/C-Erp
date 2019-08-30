namespace DotNetBarProject.view.RanHuaCB
{
    partial class FrmRLRK1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkMohu = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.chkDtime1 = new DotNetBarProject.view.custom.view.ChkDtime();
            this.chkGHS = new DotNetBarProject.view.custom.view.ChkTxt();
            this.chkDJ = new DotNetBarProject.view.custom.view.ChkTxt();
            this.chkRLMC = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblBZ = new DotNetBarProject.view.custom.view.LblTxt();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGHS = new DotNetBarProject.view.custom.view.LblTxt();
            this.lblDJ = new DotNetBarProject.view.custom.view.LblTxt();
            this.lblRLMC = new DotNetBarProject.view.custom.view.LblCoboDGV();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvEX1 = new DotNetBarProject.view.custom.view.dgvEX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.checkMohu);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.chkDtime1);
            this.panel1.Controls.Add(this.chkGHS);
            this.panel1.Controls.Add(this.chkDJ);
            this.panel1.Controls.Add(this.chkRLMC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 100);
            this.panel1.TabIndex = 1;
            // 
            // checkMohu
            // 
            this.checkMohu.AutoSize = true;
            this.checkMohu.Location = new System.Drawing.Point(465, 43);
            this.checkMohu.Name = "checkMohu";
            this.checkMohu.Size = new System.Drawing.Size(48, 16);
            this.checkMohu.TabIndex = 10;
            this.checkMohu.Text = "模糊";
            this.checkMohu.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(544, 29);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 42);
            this.button3.TabIndex = 9;
            this.button3.Text = "确定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(662, 29);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 42);
            this.button4.TabIndex = 8;
            this.button4.Text = "取消";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            this.chkDtime1.Location = new System.Drawing.Point(4, 66);
            this.chkDtime1.Name = "chkDtime1";
            this.chkDtime1.Size = new System.Drawing.Size(430, 21);
            this.chkDtime1.TabIndex = 3;
            // 
            // chkGHS
            // 
            this.chkGHS.allowEmpty = false;
            this.chkGHS.chkFont = new System.Drawing.Font("宋体", 9F);
            this.chkGHS.chkSel = false;
            this.chkGHS.chkText = "供货商";
            this.chkGHS.Font = new System.Drawing.Font("宋体", 9F);
            this.chkGHS.jiange = 0;
            this.chkGHS.Location = new System.Drawing.Point(4, 35);
            this.chkGHS.Margin = new System.Windows.Forms.Padding(4);
            this.chkGHS.Name = "chkGHS";
            this.chkGHS.ReadOnly = false;
            this.chkGHS.Size = new System.Drawing.Size(228, 24);
            this.chkGHS.TabIndex = 2;
            this.chkGHS.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkGHS.txtFont = new System.Drawing.Font("宋体", 9F);
            this.chkGHS.txtISid = false;
            this.chkGHS.txtISint = false;
            this.chkGHS.txtISmoney = false;
            this.chkGHS.txtLen = 50;
            this.chkGHS.txtMulLine = false;
            this.chkGHS.txtTop = true;
            // 
            // chkDJ
            // 
            this.chkDJ.allowEmpty = false;
            this.chkDJ.chkFont = new System.Drawing.Font("宋体", 9F);
            this.chkDJ.chkSel = false;
            this.chkDJ.chkText = "单价";
            this.chkDJ.Font = new System.Drawing.Font("宋体", 9F);
            this.chkDJ.jiange = 0;
            this.chkDJ.Location = new System.Drawing.Point(259, 8);
            this.chkDJ.Margin = new System.Windows.Forms.Padding(4);
            this.chkDJ.Name = "chkDJ";
            this.chkDJ.ReadOnly = false;
            this.chkDJ.Size = new System.Drawing.Size(183, 24);
            this.chkDJ.TabIndex = 1;
            this.chkDJ.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkDJ.txtFont = new System.Drawing.Font("宋体", 9F);
            this.chkDJ.txtISid = false;
            this.chkDJ.txtISint = false;
            this.chkDJ.txtISmoney = false;
            this.chkDJ.txtLen = 50;
            this.chkDJ.txtMulLine = false;
            this.chkDJ.txtTop = true;
            // 
            // chkRLMC
            // 
            this.chkRLMC.allowEmpty = false;
            this.chkRLMC.allowInput = true;
            this.chkRLMC.chkFont = new System.Drawing.Font("宋体", 9F);
            this.chkRLMC.chkSel = false;
            this.chkRLMC.chkText = "染料名称";
            this.chkRLMC.cobodgvFont = new System.Drawing.Font("宋体", 9F);
            this.chkRLMC.coboFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRLMC.jiange = 0;
            this.chkRLMC.Location = new System.Drawing.Point(4, 8);
            this.chkRLMC.Name = "chkRLMC";
            this.chkRLMC.SeparatorChar = " ";
            this.chkRLMC.Size = new System.Drawing.Size(228, 20);
            this.chkRLMC.TabIndex = 0;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.button2);
            this.groupPanel1.Controls.Add(this.button1);
            this.groupPanel1.Controls.Add(this.lblBZ);
            this.groupPanel1.Controls.Add(this.dateTimePicker1);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.lblGHS);
            this.groupPanel1.Controls.Add(this.lblDJ);
            this.groupPanel1.Controls.Add(this.lblRLMC);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel1.Location = new System.Drawing.Point(0, 349);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(825, 165);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
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
            this.groupPanel1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(604, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 42);
            this.button2.TabIndex = 7;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(604, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblBZ
            // 
            this.lblBZ.BackColor = System.Drawing.Color.Transparent;
            this.lblBZ.jiange = 5;
            this.lblBZ.lblFont = new System.Drawing.Font("宋体", 9F);
            this.lblBZ.lblText = "备注";
            this.lblBZ.Location = new System.Drawing.Point(32, 72);
            this.lblBZ.Name = "lblBZ";
            this.lblBZ.ReadOnly = false;
            this.lblBZ.Size = new System.Drawing.Size(457, 66);
            this.lblBZ.TabIndex = 5;
            this.lblBZ.txtBackColor = System.Drawing.SystemColors.Window;
            this.lblBZ.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblBZ.txtFont = new System.Drawing.Font("宋体", 9F);
            this.lblBZ.txtISid = false;
            this.lblBZ.txtISint = false;
            this.lblBZ.txtISmoney = false;
            this.lblBZ.txtLen = 200;
            this.lblBZ.txtMulLine = true;
            this.lblBZ.txtReadonly = false;
            this.lblBZ.txtTop = false;
            this.lblBZ.txtUpper = false;
            this.lblBZ.upperZero = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(289, 45);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "时间";
            // 
            // lblGHS
            // 
            this.lblGHS.BackColor = System.Drawing.Color.Transparent;
            this.lblGHS.jiange = 5;
            this.lblGHS.lblFont = new System.Drawing.Font("宋体", 9F);
            this.lblGHS.lblText = "供货商";
            this.lblGHS.Location = new System.Drawing.Point(32, 45);
            this.lblGHS.Name = "lblGHS";
            this.lblGHS.ReadOnly = false;
            this.lblGHS.Size = new System.Drawing.Size(216, 21);
            this.lblGHS.TabIndex = 2;
            this.lblGHS.txtBackColor = System.Drawing.SystemColors.Window;
            this.lblGHS.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblGHS.txtFont = new System.Drawing.Font("宋体", 9F);
            this.lblGHS.txtISid = false;
            this.lblGHS.txtISint = false;
            this.lblGHS.txtISmoney = false;
            this.lblGHS.txtLen = 50;
            this.lblGHS.txtMulLine = false;
            this.lblGHS.txtReadonly = false;
            this.lblGHS.txtTop = true;
            this.lblGHS.txtUpper = false;
            this.lblGHS.upperZero = false;
            // 
            // lblDJ
            // 
            this.lblDJ.BackColor = System.Drawing.Color.Transparent;
            this.lblDJ.jiange = 0;
            this.lblDJ.lblFont = new System.Drawing.Font("宋体", 9F);
            this.lblDJ.lblText = " 单价 ";
            this.lblDJ.Location = new System.Drawing.Point(244, 8);
            this.lblDJ.Name = "lblDJ";
            this.lblDJ.ReadOnly = false;
            this.lblDJ.Size = new System.Drawing.Size(245, 21);
            this.lblDJ.TabIndex = 1;
            this.lblDJ.txtBackColor = System.Drawing.SystemColors.Window;
            this.lblDJ.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblDJ.txtFont = new System.Drawing.Font("宋体", 9F);
            this.lblDJ.txtISid = false;
            this.lblDJ.txtISint = false;
            this.lblDJ.txtISmoney = false;
            this.lblDJ.txtLen = 50;
            this.lblDJ.txtMulLine = false;
            this.lblDJ.txtReadonly = false;
            this.lblDJ.txtTop = true;
            this.lblDJ.txtUpper = false;
            this.lblDJ.upperZero = false;
            // 
            // lblRLMC
            // 
            this.lblRLMC.allowInput = true;
            this.lblRLMC.cobodgvFont = new System.Drawing.Font("宋体", 9F);
            this.lblRLMC.jiange = 5;
            this.lblRLMC.lblFont = new System.Drawing.Font("宋体", 9F);
            this.lblRLMC.lblText = "染料名称";
            this.lblRLMC.Location = new System.Drawing.Point(32, 3);
            this.lblRLMC.Name = "lblRLMC";
            this.lblRLMC.Size = new System.Drawing.Size(216, 26);
            this.lblRLMC.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增ToolStripMenuItem,
            this.修改ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.查询ToolStripMenuItem,
            this.刷新ToolStripMenuItem,
            this.toolStripSeparator1,
            this.打印ToolStripMenuItem,
            this.导出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 164);
            this.contextMenuStrip1.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.contextMenuStrip1_Closing);
            // 
            // 新增ToolStripMenuItem
            // 
            this.新增ToolStripMenuItem.Name = "新增ToolStripMenuItem";
            this.新增ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.新增ToolStripMenuItem.Text = "新增";
            this.新增ToolStripMenuItem.Click += new System.EventHandler(this.新增ToolStripMenuItem_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Enabled = false;
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.ShowShortcutKeys = false;
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Enabled = false;
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
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
            // dgvEX1
            // 
            this.dgvEX1.AllowUserToAddRows = false;
            this.dgvEX1.AllowUserToDeleteRows = false;
            this.dgvEX1.AllowUserToResizeColumns = false;
            this.dgvEX1.AllowUserToResizeRows = false;
            this.dgvEX1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvEX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvEX1.Location = new System.Drawing.Point(0, 100);
            this.dgvEX1.MultiSelect = false;
            this.dgvEX1.Name = "dgvEX1";
            this.dgvEX1.ReadOnly = true;
            this.dgvEX1.RowNumShow = false;
            this.dgvEX1.RowTemplate.Height = 23;
            this.dgvEX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEX1.Size = new System.Drawing.Size(825, 249);
            this.dgvEX1.TabIndex = 2;
            this.dgvEX1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEX1_CellDoubleClick);
            this.dgvEX1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEX1_CellMouseDown);
            this.dgvEX1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvEX1_MouseDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 130;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "染料名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 131;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "单价";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 130;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "供货商";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 130;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "时间";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 131;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "备注";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 130;
            // 
            // FrmRLRK1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 514);
            this.Controls.Add(this.dgvEX1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRLRK1";
            this.Text = "FrmRHLCB";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private custom.view.LblCoboDGV lblRLMC;
        private System.Windows.Forms.Panel panel1;
        private custom.view.dgvEX dgvEX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private custom.view.LblTxt lblGHS;
        private custom.view.LblTxt lblDJ;
        private custom.view.LblTxt lblBZ;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private custom.view.ChkCoboDGV chkRLMC;
        private custom.view.ChkTxt chkDJ;
        private custom.view.ChkTxt chkGHS;
        private custom.view.ChkDtime chkDtime1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkMohu;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新增ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 打印ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}
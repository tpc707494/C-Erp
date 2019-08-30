namespace DotNetBarProject.view.baseinfo
{
    partial class FrmUser
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvMain = new DotNetBarProject.view.custom.view.dgvEX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SNItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuDGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu增加空白 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu修改 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu删除 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menu打印 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu导出Excel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menu刷新 = new System.Windows.Forms.ToolStripMenuItem();
            this.Bottom_Group = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEXE = new System.Windows.Forms.Button();
            this.lblTxt5 = new DotNetBarProject.view.custom.view.LblTxt();
            this.lblTxt4 = new DotNetBarProject.view.custom.view.LblTxt();
            this.txtMK = new DotNetBarProject.view.custom.view.LblTxt();
            this.txtXM = new DotNetBarProject.view.custom.view.LblTxt();
            this.txtBH = new DotNetBarProject.view.custom.view.LblTxt();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeQX = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.选定节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.展开ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.收缩ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.权限全选ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.清除权限ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.选定节点ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.展开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.收缩ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.权限全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.权限清除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.menuDGV.SuspendLayout();
            this.Bottom_Group.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Silver;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(10, 10);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(904, 519);
            this.splitContainer1.SplitterDistance = 620;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.groupBox1.Controls.Add(this.dgvMain);
            this.groupBox1.Controls.Add(this.Bottom_Group);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 519);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户";
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.SNItem});
            this.dgvMain.ContextMenuStrip = this.menuDGV;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvMain.Location = new System.Drawing.Point(3, 17);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMain.RowNumShow = false;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(614, 387);
            this.dgvMain.TabIndex = 0;
            this.dgvMain.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellContentDoubleClick);
            this.dgvMain.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.datagrid_CellMouseDown);
            this.dgvMain.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_RowEnter);
            this.dgvMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvMain_MouseDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 143;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 143;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "部门";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 142;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "备注";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 143;
            // 
            // SNItem
            // 
            this.SNItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SNItem.HeaderText = "SN";
            this.SNItem.Name = "SNItem";
            this.SNItem.ReadOnly = true;
            this.SNItem.Visible = false;
            // 
            // menuDGV
            // 
            this.menuDGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu增加空白,
            this.menu修改,
            this.menu删除,
            this.toolStripSeparator4,
            this.menu打印,
            this.menu导出Excel,
            this.toolStripSeparator5,
            this.menu刷新});
            this.menuDGV.Name = "menuDGV";
            this.menuDGV.Size = new System.Drawing.Size(130, 148);
            this.menuDGV.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.menuDGV_Closing);
            // 
            // menu增加空白
            // 
            this.menu增加空白.Name = "menu增加空白";
            this.menu增加空白.Size = new System.Drawing.Size(129, 22);
            this.menu增加空白.Text = "新增";
            this.menu增加空白.Click += new System.EventHandler(this.menu增加空白_Click);
            // 
            // menu修改
            // 
            this.menu修改.Enabled = false;
            this.menu修改.Name = "menu修改";
            this.menu修改.Size = new System.Drawing.Size(129, 22);
            this.menu修改.Text = "修改";
            this.menu修改.Click += new System.EventHandler(this.menu修改_Click);
            // 
            // menu删除
            // 
            this.menu删除.Enabled = false;
            this.menu删除.Name = "menu删除";
            this.menu删除.Size = new System.Drawing.Size(129, 22);
            this.menu删除.Text = "删除";
            this.menu删除.Click += new System.EventHandler(this.menu删除_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(126, 6);
            // 
            // menu打印
            // 
            this.menu打印.Name = "menu打印";
            this.menu打印.Size = new System.Drawing.Size(129, 22);
            this.menu打印.Text = "打印";
            this.menu打印.Click += new System.EventHandler(this.menu打印_Click);
            // 
            // menu导出Excel
            // 
            this.menu导出Excel.Name = "menu导出Excel";
            this.menu导出Excel.Size = new System.Drawing.Size(129, 22);
            this.menu导出Excel.Text = "导出Excel";
            this.menu导出Excel.Click += new System.EventHandler(this.menu导出Excel_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(126, 6);
            // 
            // menu刷新
            // 
            this.menu刷新.Name = "menu刷新";
            this.menu刷新.Size = new System.Drawing.Size(129, 22);
            this.menu刷新.Text = "刷新";
            this.menu刷新.Click += new System.EventHandler(this.menu刷新_Click);
            // 
            // Bottom_Group
            // 
            this.Bottom_Group.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.Bottom_Group.Controls.Add(this.tableLayoutPanel1);
            this.Bottom_Group.Controls.Add(this.lblTxt5);
            this.Bottom_Group.Controls.Add(this.lblTxt4);
            this.Bottom_Group.Controls.Add(this.txtMK);
            this.Bottom_Group.Controls.Add(this.txtXM);
            this.Bottom_Group.Controls.Add(this.txtBH);
            this.Bottom_Group.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Bottom_Group.Location = new System.Drawing.Point(3, 404);
            this.Bottom_Group.Name = "Bottom_Group";
            this.Bottom_Group.Size = new System.Drawing.Size(614, 112);
            this.Bottom_Group.TabIndex = 0;
            this.Bottom_Group.TabStop = false;
            this.Bottom_Group.Text = "增加用户";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnEXE, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(524, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(90, 81);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(3, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 35);
            this.button2.TabIndex = 6;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEXE
            // 
            this.btnEXE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEXE.Location = new System.Drawing.Point(3, 3);
            this.btnEXE.Name = "btnEXE";
            this.btnEXE.Size = new System.Drawing.Size(84, 34);
            this.btnEXE.TabIndex = 5;
            this.btnEXE.Text = "确定";
            this.btnEXE.UseVisualStyleBackColor = true;
            this.btnEXE.Click += new System.EventHandler(this.btnEXE_Click);
            // 
            // lblTxt5
            // 
            this.lblTxt5.BackColor = System.Drawing.Color.Transparent;
            this.lblTxt5.Font = new System.Drawing.Font("宋体", 10F);
            this.lblTxt5.jiange = 0;
            this.lblTxt5.lblFont = new System.Drawing.Font("宋体", 10F);
            this.lblTxt5.lblText = "备注";
            this.lblTxt5.Location = new System.Drawing.Point(10, 79);
            this.lblTxt5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTxt5.Name = "lblTxt5";
            this.lblTxt5.ReadOnly = false;
            this.lblTxt5.Size = new System.Drawing.Size(507, 23);
            this.lblTxt5.TabIndex = 4;
            this.lblTxt5.txtBackColor = System.Drawing.SystemColors.Window;
            this.lblTxt5.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTxt5.txtFont = new System.Drawing.Font("宋体", 10F);
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
            this.lblTxt4.Font = new System.Drawing.Font("宋体", 10F);
            this.lblTxt4.jiange = 0;
            this.lblTxt4.lblFont = new System.Drawing.Font("宋体", 10F);
            this.lblTxt4.lblText = "部门";
            this.lblTxt4.Location = new System.Drawing.Point(10, 52);
            this.lblTxt4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTxt4.Name = "lblTxt4";
            this.lblTxt4.ReadOnly = false;
            this.lblTxt4.Size = new System.Drawing.Size(330, 23);
            this.lblTxt4.TabIndex = 3;
            this.lblTxt4.txtBackColor = System.Drawing.SystemColors.Window;
            this.lblTxt4.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTxt4.txtFont = new System.Drawing.Font("宋体", 10F);
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
            // txtMK
            // 
            this.txtMK.BackColor = System.Drawing.Color.Transparent;
            this.txtMK.Font = new System.Drawing.Font("宋体", 10F);
            this.txtMK.jiange = 0;
            this.txtMK.lblFont = new System.Drawing.Font("宋体", 10F);
            this.txtMK.lblText = "密码";
            this.txtMK.Location = new System.Drawing.Point(341, 21);
            this.txtMK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMK.Name = "txtMK";
            this.txtMK.ReadOnly = false;
            this.txtMK.Size = new System.Drawing.Size(153, 23);
            this.txtMK.TabIndex = 2;
            this.txtMK.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtMK.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMK.txtFont = new System.Drawing.Font("宋体", 10F);
            this.txtMK.txtISid = false;
            this.txtMK.txtISint = false;
            this.txtMK.txtISmoney = false;
            this.txtMK.txtLen = 50;
            this.txtMK.txtMulLine = false;
            this.txtMK.txtReadonly = false;
            this.txtMK.txtTop = true;
            this.txtMK.txtUpper = false;
            this.txtMK.upperZero = false;
            // 
            // txtXM
            // 
            this.txtXM.BackColor = System.Drawing.Color.Transparent;
            this.txtXM.Font = new System.Drawing.Font("宋体", 10F);
            this.txtXM.jiange = 0;
            this.txtXM.lblFont = new System.Drawing.Font("宋体", 10F);
            this.txtXM.lblText = "姓名";
            this.txtXM.Location = new System.Drawing.Point(174, 21);
            this.txtXM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtXM.Name = "txtXM";
            this.txtXM.ReadOnly = false;
            this.txtXM.Size = new System.Drawing.Size(153, 23);
            this.txtXM.TabIndex = 1;
            this.txtXM.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtXM.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtXM.txtFont = new System.Drawing.Font("宋体", 10F);
            this.txtXM.txtISid = false;
            this.txtXM.txtISint = false;
            this.txtXM.txtISmoney = false;
            this.txtXM.txtLen = 50;
            this.txtXM.txtMulLine = false;
            this.txtXM.txtReadonly = false;
            this.txtXM.txtTop = true;
            this.txtXM.txtUpper = false;
            this.txtXM.upperZero = false;
            // 
            // txtBH
            // 
            this.txtBH.BackColor = System.Drawing.Color.Transparent;
            this.txtBH.Font = new System.Drawing.Font("宋体", 10F);
            this.txtBH.jiange = 0;
            this.txtBH.lblFont = new System.Drawing.Font("宋体", 10F);
            this.txtBH.lblText = "编号";
            this.txtBH.Location = new System.Drawing.Point(10, 21);
            this.txtBH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBH.Name = "txtBH";
            this.txtBH.ReadOnly = false;
            this.txtBH.Size = new System.Drawing.Size(153, 23);
            this.txtBH.TabIndex = 0;
            this.txtBH.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtBH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBH.txtFont = new System.Drawing.Font("宋体", 10F);
            this.txtBH.txtISid = false;
            this.txtBH.txtISint = false;
            this.txtBH.txtISmoney = false;
            this.txtBH.txtLen = 50;
            this.txtBH.txtMulLine = false;
            this.txtBH.txtReadonly = false;
            this.txtBH.txtTop = true;
            this.txtBH.txtUpper = false;
            this.txtBH.upperZero = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.groupBox2.Controls.Add(this.treeQX);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 519);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "权限";
            // 
            // treeQX
            // 
            this.treeQX.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeQX.Location = new System.Drawing.Point(3, 17);
            this.treeQX.Name = "treeQX";
            this.treeQX.Size = new System.Drawing.Size(173, 499);
            this.treeQX.TabIndex = 0;
            this.treeQX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeQX_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选定节点ToolStripMenuItem,
            this.toolStripSeparator2,
            this.选定节点ToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 54);
            this.contextMenuStrip1.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.contextMenuStrip1_Closing);
            // 
            // 选定节点ToolStripMenuItem
            // 
            this.选定节点ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.展开ToolStripMenuItem1,
            this.收缩ToolStripMenuItem1,
            this.toolStripSeparator3,
            this.权限全选ToolStripMenuItem1,
            this.清除权限ToolStripMenuItem});
            this.选定节点ToolStripMenuItem.Name = "选定节点ToolStripMenuItem";
            this.选定节点ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.选定节点ToolStripMenuItem.Text = "选定节点";
            // 
            // 展开ToolStripMenuItem1
            // 
            this.展开ToolStripMenuItem1.Name = "展开ToolStripMenuItem1";
            this.展开ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.展开ToolStripMenuItem1.Text = "展开";
            // 
            // 收缩ToolStripMenuItem1
            // 
            this.收缩ToolStripMenuItem1.Name = "收缩ToolStripMenuItem1";
            this.收缩ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.收缩ToolStripMenuItem1.Text = "收缩";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(121, 6);
            // 
            // 权限全选ToolStripMenuItem1
            // 
            this.权限全选ToolStripMenuItem1.Name = "权限全选ToolStripMenuItem1";
            this.权限全选ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.权限全选ToolStripMenuItem1.Text = "权限全选";
            // 
            // 清除权限ToolStripMenuItem
            // 
            this.清除权限ToolStripMenuItem.Name = "清除权限ToolStripMenuItem";
            this.清除权限ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.清除权限ToolStripMenuItem.Text = "清除权限";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(121, 6);
            // 
            // 选定节点ToolStripMenuItem1
            // 
            this.选定节点ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.展开ToolStripMenuItem,
            this.收缩ToolStripMenuItem,
            this.toolStripSeparator1,
            this.权限全选ToolStripMenuItem,
            this.权限清除ToolStripMenuItem});
            this.选定节点ToolStripMenuItem1.Name = "选定节点ToolStripMenuItem1";
            this.选定节点ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.选定节点ToolStripMenuItem1.Text = "全部节点";
            // 
            // 展开ToolStripMenuItem
            // 
            this.展开ToolStripMenuItem.Name = "展开ToolStripMenuItem";
            this.展开ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.展开ToolStripMenuItem.Text = "展开";
            // 
            // 收缩ToolStripMenuItem
            // 
            this.收缩ToolStripMenuItem.Name = "收缩ToolStripMenuItem";
            this.收缩ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.收缩ToolStripMenuItem.Text = "收缩";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // 权限全选ToolStripMenuItem
            // 
            this.权限全选ToolStripMenuItem.Name = "权限全选ToolStripMenuItem";
            this.权限全选ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.权限全选ToolStripMenuItem.Text = "权限全选";
            // 
            // 权限清除ToolStripMenuItem
            // 
            this.权限清除ToolStripMenuItem.Name = "权限清除ToolStripMenuItem";
            this.权限清除ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.权限清除ToolStripMenuItem.Text = "清除权限";
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(924, 539);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUser";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmUser";
            this.Load += new System.EventHandler(this.FrmUser_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.menuDGV.ResumeLayout(false);
            this.Bottom_Group.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeQX;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选定节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选定节点ToolStripMenuItem1;
        private custom.view.dgvEX dgvMain;
        private System.Windows.Forms.ToolStripMenuItem 展开ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 收缩ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 权限全选ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 清除权限ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 展开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 收缩ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 权限全选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 权限清除ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip menuDGV;
        private System.Windows.Forms.ToolStripMenuItem menu增加空白;
        private System.Windows.Forms.ToolStripMenuItem menu修改;
        private System.Windows.Forms.ToolStripMenuItem menu删除;
        private System.Windows.Forms.ToolStripMenuItem menu打印;
        private System.Windows.Forms.ToolStripMenuItem menu导出Excel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menu刷新;
        private System.Windows.Forms.GroupBox Bottom_Group;
        private custom.view.LblTxt txtBH;
        private custom.view.LblTxt txtMK;
        private custom.view.LblTxt txtXM;
        private custom.view.LblTxt lblTxt5;
        private custom.view.LblTxt lblTxt4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnEXE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNItem;
    }
}
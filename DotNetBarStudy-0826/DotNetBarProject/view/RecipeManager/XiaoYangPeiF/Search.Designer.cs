namespace DotNetBarProject.view.RecipeManager.XiaoYangPeiF
{
    partial class Search
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.schYS = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.schSH = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.schSZ = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.schKH = new DotNetBarProject.view.custom.view.ChkCoboDGV();
            this.schRQsave = new DotNetBarProject.view.custom.view.ChkDtime();
            this.button1 = new System.Windows.Forms.Button();
            this.schMohu = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.schDel = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.schDY = new DotNetBarProject.view.custom.view.ChkTxt();
            this.schDDH = new DotNetBarProject.view.custom.view.ChkTxt();
            this.schLD = new DotNetBarProject.view.custom.view.ChkTxt();
            this.dgvEX1 = new DotNetBarProject.view.custom.view.dgvEX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainColSta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.schYS);
            this.panel1.Controls.Add(this.schSH);
            this.panel1.Controls.Add(this.schSZ);
            this.panel1.Controls.Add(this.schKH);
            this.panel1.Controls.Add(this.schRQsave);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.schMohu);
            this.panel1.Controls.Add(this.schDel);
            this.panel1.Controls.Add(this.schDY);
            this.panel1.Controls.Add(this.schDDH);
            this.panel1.Controls.Add(this.schLD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 96);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // schYS
            // 
            this.schYS.allowEmpty = false;
            this.schYS.allowInput = true;
            this.schYS.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schYS.chkSel = false;
            this.schYS.chkText = "颜色";
            this.schYS.cobodgvFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schYS.coboFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.schYS.jiange = 0;
            this.schYS.Location = new System.Drawing.Point(182, 42);
            this.schYS.Name = "schYS";
            this.schYS.SeparatorChar = " ";
            this.schYS.Size = new System.Drawing.Size(150, 20);
            this.schYS.TabIndex = 14;
            // 
            // schSH
            // 
            this.schSH.allowEmpty = false;
            this.schSH.allowInput = true;
            this.schSH.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schSH.chkSel = false;
            this.schSH.chkText = "色号";
            this.schSH.cobodgvFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schSH.coboFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.schSH.jiange = 0;
            this.schSH.Location = new System.Drawing.Point(182, 12);
            this.schSH.Name = "schSH";
            this.schSH.SeparatorChar = " ";
            this.schSH.Size = new System.Drawing.Size(150, 20);
            this.schSH.TabIndex = 15;
            // 
            // schSZ
            // 
            this.schSZ.allowEmpty = false;
            this.schSZ.allowInput = true;
            this.schSZ.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schSZ.chkSel = false;
            this.schSZ.chkText = "品名";
            this.schSZ.cobodgvFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schSZ.coboFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.schSZ.jiange = 0;
            this.schSZ.Location = new System.Drawing.Point(12, 42);
            this.schSZ.Name = "schSZ";
            this.schSZ.SeparatorChar = " ";
            this.schSZ.Size = new System.Drawing.Size(150, 20);
            this.schSZ.TabIndex = 3;
            // 
            // schKH
            // 
            this.schKH.allowEmpty = false;
            this.schKH.allowInput = true;
            this.schKH.chkFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schKH.chkSel = false;
            this.schKH.chkText = "客户";
            this.schKH.cobodgvFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schKH.coboFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.schKH.jiange = 0;
            this.schKH.Location = new System.Drawing.Point(12, 12);
            this.schKH.Name = "schKH";
            this.schKH.SeparatorChar = " ";
            this.schKH.Size = new System.Drawing.Size(150, 20);
            this.schKH.TabIndex = 13;
            // 
            // schRQsave
            // 
            this.schRQsave.chkFsel = false;
            this.schRQsave.chkTsel = false;
            this.schRQsave.dtimeFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schRQsave.dtimeFormat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.schRQsave.dtimeFormatStr = "yyyy-MM-dd HH:mm";
            this.schRQsave.dtimeShowUpDown = false;
            this.schRQsave.jiange = -5;
            this.schRQsave.lblColor = System.Drawing.SystemColors.ControlText;
            this.schRQsave.lblFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schRQsave.lblText = "保存日期";
            this.schRQsave.Location = new System.Drawing.Point(12, 66);
            this.schRQsave.Name = "schRQsave";
            this.schRQsave.Size = new System.Drawing.Size(417, 21);
            this.schRQsave.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(698, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // schMohu
            // 
            // 
            // 
            // 
            this.schMohu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.schMohu.Location = new System.Drawing.Point(709, 12);
            this.schMohu.Name = "schMohu";
            this.schMohu.Size = new System.Drawing.Size(49, 23);
            this.schMohu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.schMohu.TabIndex = 10;
            this.schMohu.Text = "模糊";
            // 
            // schDel
            // 
            // 
            // 
            // 
            this.schDel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.schDel.Location = new System.Drawing.Point(590, 45);
            this.schDel.Name = "schDel";
            this.schDel.Size = new System.Drawing.Size(76, 23);
            this.schDel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.schDel.TabIndex = 9;
            this.schDel.Text = "含已删除";
            // 
            // schDY
            // 
            this.schDY.allowEmpty = false;
            this.schDY.chkFont = new System.Drawing.Font("宋体", 10F);
            this.schDY.chkSel = false;
            this.schDY.chkText = "打样";
            this.schDY.jiange = -5;
            this.schDY.Location = new System.Drawing.Point(354, 42);
            this.schDY.Name = "schDY";
            this.schDY.ReadOnly = false;
            this.schDY.Size = new System.Drawing.Size(159, 20);
            this.schDY.TabIndex = 7;
            this.schDY.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schDY.txtFont = new System.Drawing.Font("宋体", 10F);
            this.schDY.txtISid = false;
            this.schDY.txtISint = false;
            this.schDY.txtISmoney = false;
            this.schDY.txtLen = 50;
            this.schDY.txtMulLine = false;
            this.schDY.txtTop = true;
            // 
            // schDDH
            // 
            this.schDDH.allowEmpty = false;
            this.schDDH.chkFont = new System.Drawing.Font("宋体", 10F);
            this.schDDH.chkSel = false;
            this.schDDH.chkText = "流程卡号";
            this.schDDH.jiange = -5;
            this.schDDH.Location = new System.Drawing.Point(519, 12);
            this.schDDH.Name = "schDDH";
            this.schDDH.ReadOnly = false;
            this.schDDH.Size = new System.Drawing.Size(159, 21);
            this.schDDH.TabIndex = 5;
            this.schDDH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schDDH.txtFont = new System.Drawing.Font("宋体", 10F);
            this.schDDH.txtISid = false;
            this.schDDH.txtISint = false;
            this.schDDH.txtISmoney = false;
            this.schDDH.txtLen = 50;
            this.schDDH.txtMulLine = false;
            this.schDDH.txtTop = true;
            // 
            // schLD
            // 
            this.schLD.allowEmpty = false;
            this.schLD.chkFont = new System.Drawing.Font("宋体", 10F);
            this.schLD.chkSel = false;
            this.schLD.chkText = "单号";
            this.schLD.jiange = -5;
            this.schLD.Location = new System.Drawing.Point(354, 12);
            this.schLD.Name = "schLD";
            this.schLD.ReadOnly = false;
            this.schLD.Size = new System.Drawing.Size(159, 21);
            this.schLD.TabIndex = 4;
            this.schLD.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schLD.txtFont = new System.Drawing.Font("宋体", 10F);
            this.schLD.txtISid = false;
            this.schLD.txtISint = false;
            this.schLD.txtISmoney = false;
            this.schLD.txtLen = 50;
            this.schLD.txtMulLine = false;
            this.schLD.txtTop = true;
            // 
            // dgvEX1
            // 
            this.dgvEX1.AllowUserToAddRows = false;
            this.dgvEX1.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEX1.ColumnHeadersHeight = 30;
            this.dgvEX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.mainColSta,
            this.Column13});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEX1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEX1.EnableHeadersVisualStyles = false;
            this.dgvEX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvEX1.Location = new System.Drawing.Point(10, 106);
            this.dgvEX1.MultiSelect = false;
            this.dgvEX1.Name = "dgvEX1";
            this.dgvEX1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvEX1.RowNumShow = false;
            this.dgvEX1.RowTemplate.Height = 35;
            this.dgvEX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEX1.Size = new System.Drawing.Size(780, 334);
            this.dgvEX1.TabIndex = 2;
            this.dgvEX1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEX1_CellContentDoubleClick);
            this.dgvEX1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvEX1_RowPostPaint);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "单号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 61;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "客户";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 62;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "品名";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 61;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "色号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 62;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "颜色";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 61;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "流程卡号";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 61;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "保存日期";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 62;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "配方";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 61;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "审核日期";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 62;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "审核";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 61;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "打样";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 62;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "备注";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 61;
            // 
            // mainColSta
            // 
            this.mainColSta.HeaderText = "shenheSta";
            this.mainColSta.Name = "mainColSta";
            this.mainColSta.ReadOnly = true;
            this.mainColSta.Visible = false;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "SN";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvEX1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Search";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private custom.view.ChkTxt schLD;
        private custom.view.ChkTxt schDDH;
        private custom.view.ChkTxt schDY;
        private DevComponents.DotNetBar.Controls.CheckBoxX schDel;
        private System.Windows.Forms.Button button1;
        private DevComponents.DotNetBar.Controls.CheckBoxX schMohu;
        private custom.view.ChkDtime schRQsave;
        private custom.view.dgvEX dgvEX1;
        private custom.view.ChkCoboDGV schKH;
        private custom.view.ChkCoboDGV schSZ;
        private custom.view.ChkCoboDGV schYS;
        private custom.view.ChkCoboDGV schSH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn mainColSta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
    }
}
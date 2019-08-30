using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.DL
{
    partial class frmZDsel
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
            this.lblEnter = new Label();
            this.panel1 = new Panel();
            this.labelxx = new Label();
            this.lblCheng = new Label();
            this.lblRL = new Label();
            this.label4 = new Label();
            this.txtZL = new TextBox();
            this.label3 = new Label();
            this.label2 = new Label();
            this.lblDT = new Label();
            this.label1 = new Label();
            this.lblUPDN = new Label();
            this.lblCancel = new Label();
            this.lblTS = new Label();
            this.dgvRL = new DataGridView();
            this.colDT = new DataGridViewTextBoxColumn();
            this.colRL = new DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            this.lblEnter.BackColor = Color.Yellow;
            this.lblEnter.BorderStyle = BorderStyle.FixedSingle;
            this.lblEnter.Font = new Font("黑体", 20f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblEnter.ForeColor = Color.DarkRed;
            this.lblEnter.Location = new Point(355, 280);
            this.lblEnter.Name = "lblEnter";
            this.lblEnter.Size = new Size(250, 45);
            this.lblEnter.TabIndex = 4;
            this.lblEnter.Text = "“确认”开始滴料";
            this.lblEnter.TextAlign = ContentAlignment.MiddleCenter;
            this.panel1.BackColor = Color.SkyBlue;
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add((Control)this.labelxx);
            this.panel1.Controls.Add((Control)this.lblCheng);
            this.panel1.Controls.Add((Control)this.lblRL);
            this.panel1.Controls.Add((Control)this.label4);
            this.panel1.Controls.Add((Control)this.txtZL);
            this.panel1.Controls.Add((Control)this.label3);
            this.panel1.Controls.Add((Control)this.label2);
            this.panel1.Controls.Add((Control)this.lblDT);
            this.panel1.Controls.Add((Control)this.label1);
            this.panel1.Controls.Add((Control)this.lblUPDN);
            this.panel1.Controls.Add((Control)this.lblCancel);
            this.panel1.Controls.Add((Control)this.lblTS);
            this.panel1.Controls.Add((Control)this.lblEnter);
            this.panel1.Controls.Add((Control)this.dgvRL);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(647, 417);
            this.panel1.TabIndex = 8;
            this.labelxx.AutoSize = true;
            this.labelxx.Font = new Font("黑体", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.labelxx.ForeColor = SystemColors.ControlText;
            this.labelxx.Location = new Point(337, 32);
            this.labelxx.Name = "labelxx";
            this.labelxx.Size = new Size(91, 22);
            this.labelxx.TabIndex = 22;
            this.labelxx.Text = "电子称:";
            this.labelxx.TextAlign = ContentAlignment.BottomCenter;
            this.lblCheng.AutoSize = true;
            this.lblCheng.Font = new Font("黑体", 24f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblCheng.ForeColor = Color.Red;
            this.lblCheng.Location = new Point(430, 26);
            this.lblCheng.Name = "lblCheng";
            this.lblCheng.Size = new Size(32, 33);
            this.lblCheng.TabIndex = 21;
            this.lblCheng.Text = "1";
            this.lblCheng.TextAlign = ContentAlignment.MiddleCenter;
            this.lblRL.AutoSize = true;
            this.lblRL.Font = new Font("黑体", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblRL.ForeColor = Color.Red;
            this.lblRL.Location = new Point(402, 72);
            this.lblRL.Name = "lblRL";
            this.lblRL.Size = new Size(160, 24);
            this.lblRL.TabIndex = 13;
            this.lblRL.Text = "染料助剂名称";
            this.lblRL.TextAlign = ContentAlignment.BottomCenter;
            this.label4.AutoSize = true;
            this.label4.Font = new Font("黑体", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.label4.ForeColor = Color.Red;
            this.label4.Location = new Point(541, 112);
            this.label4.Name = "label4";
            this.label4.Size = new Size(36, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "Kg";
            this.label4.TextAlign = ContentAlignment.MiddleCenter;
            this.txtZL.BorderStyle = BorderStyle.FixedSingle;
            this.txtZL.Font = new Font("黑体", 20f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtZL.ForeColor = Color.DarkRed;
            this.txtZL.Location = new Point(406, 104);
            this.txtZL.MaxLength = 20;
            this.txtZL.Name = "txtZL";
            this.txtZL.Size = new Size(133, 38);
            this.txtZL.TabIndex = 19;
            this.txtZL.TextAlign = HorizontalAlignment.Center;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("黑体", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.label3.ForeColor = SystemColors.ControlText;
            this.label3.Location = new Point(337, 111);
            this.label3.Name = "label3";
            this.label3.Size = new Size(68, 22);
            this.label3.TabIndex = 18;
            this.label3.Text = "重量:";
            this.label3.TextAlign = ContentAlignment.BottomCenter;
            this.label2.AutoSize = true;
            this.label2.Font = new Font("黑体", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.label2.ForeColor = SystemColors.ControlText;
            this.label2.Location = new Point(494, 32);
            this.label2.Name = "label2";
            this.label2.Size = new Size(68, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "滴头:";
            this.label2.TextAlign = ContentAlignment.BottomCenter;
            this.lblDT.AutoSize = true;
            this.lblDT.Font = new Font("黑体", 24f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblDT.ForeColor = Color.Red;
            this.lblDT.Location = new Point(568, 26);
            this.lblDT.Name = "lblDT";
            this.lblDT.Size = new Size(32, 33);
            this.lblDT.TabIndex = 14;
            this.lblDT.Text = "1";
            this.lblDT.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("黑体", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.label1.ForeColor = SystemColors.ControlText;
            this.label1.Location = new Point(337, 73);
            this.label1.Name = "label1";
            this.label1.Size = new Size(68, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "品名:";
            this.label1.TextAlign = ContentAlignment.BottomCenter;
            this.lblUPDN.BackColor = Color.DarkCyan;
            this.lblUPDN.BorderStyle = BorderStyle.FixedSingle;
            this.lblUPDN.Font = new Font("黑体", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblUPDN.Location = new Point(355, 216);
            this.lblUPDN.Name = "lblUPDN";
            this.lblUPDN.Size = new Size(250, 45);
            this.lblUPDN.TabIndex = 11;
            this.lblUPDN.Text = "“上翻/下翻”选择滴头";
            this.lblUPDN.TextAlign = ContentAlignment.MiddleCenter;
            this.lblCancel.BackColor = Color.DarkCyan;
            this.lblCancel.BorderStyle = BorderStyle.FixedSingle;
            this.lblCancel.Font = new Font("黑体", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblCancel.Location = new Point(355, 345);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new Size(250, 45);
            this.lblCancel.TabIndex = 10;
            this.lblCancel.Text = "取消滴料";
            this.lblCancel.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTS.BackColor = Color.Yellow;
            this.lblTS.BorderStyle = BorderStyle.FixedSingle;
            this.lblTS.Font = new Font("黑体", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblTS.ForeColor = Color.DarkRed;
            this.lblTS.Location = new Point(355, 153);
            this.lblTS.Name = "lblTS";
            this.lblTS.Size = new Size(250, 45);
            this.lblTS.TabIndex = 9;
            this.lblTS.Text = "请将空料桶置于称上";
            this.lblTS.TextAlign = ContentAlignment.MiddleCenter;
            this.dgvRL.AllowUserToAddRows = false;
            this.dgvRL.AllowUserToDeleteRows = false;
            this.dgvRL.AllowUserToOrderColumns = true;
            this.dgvRL.AllowUserToResizeColumns = false;
            this.dgvRL.AllowUserToResizeRows = false;
            this.dgvRL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRL.ColumnHeadersVisible = false;
            this.dgvRL.Columns.AddRange((DataGridViewColumn)this.colDT, (DataGridViewColumn)this.colRL);
            gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridViewCellStyle1.BackColor = SystemColors.Window;
            gridViewCellStyle1.Font = new Font("黑体", 14f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            gridViewCellStyle1.ForeColor = SystemColors.ControlText;
            gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            gridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            this.dgvRL.DefaultCellStyle = gridViewCellStyle1;
            this.dgvRL.Dock = DockStyle.Left;
            this.dgvRL.Enabled = false;
            this.dgvRL.Location = new Point(0, 0);
            this.dgvRL.MultiSelect = false;
            this.dgvRL.Name = "dgvRL";
            this.dgvRL.ReadOnly = true;
            this.dgvRL.RowHeadersVisible = false;
            this.dgvRL.RowHeadersWidth = 28;
            this.dgvRL.RowTemplate.Height = 34;
            this.dgvRL.ScrollBars = ScrollBars.None;
            this.dgvRL.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRL.Size = new Size(322, 415);
            this.dgvRL.TabIndex = 17;
            gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.colDT.DefaultCellStyle = gridViewCellStyle2;
            this.colDT.HeaderText = "colDT";
            this.colDT.Name = "colDT";
            this.colDT.ReadOnly = true;
            this.colDT.Width = 60;
            this.colRL.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.colRL.HeaderText = "colRL";
            this.colRL.Name = "colRL";
            this.colRL.ReadOnly = true;
            this.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.MidnightBlue;
            this.ClientSize = new Size(653, 423);
            this.ControlBox = false;
            this.Controls.Add((Control)this.panel1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = nameof(frmZDsel);
            this.Padding = new Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.TopMost = true;
            this.FormClosed += new FormClosedEventHandler(this.this_FormClosed);
            this.Load += new EventHandler(this.this_Load);
            this.Shown += new EventHandler(this.this_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label lblEnter;
        private Panel panel1;
        private Label lblTS;
        private Label lblUPDN;
        private Label lblCancel;
        private Label label1;
        private Label label2;
        private DataGridView dgvRL;
        private DataGridViewTextBoxColumn colDT;
        private DataGridViewTextBoxColumn colRL;
        private Label label3;
        private Label label4;
        public TextBox txtZL;
        public Label lblRL;
        public Label lblDT;
        private Label labelxx;
        public Label lblCheng;
    }
}
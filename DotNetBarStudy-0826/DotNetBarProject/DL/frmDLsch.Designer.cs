using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.DL
{
    partial class frmDLsch
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
            this.SuspendLayout();
            this.lblEnter = new Label();
            this.txtSch = new TextBox();
            this.lblTS = new Label();
            this.lblCancel = new Label();
            this.panel1 = new Panel();
            this.label2 = new Label();
            this.panel1.SuspendLayout();
            this.lblEnter.BackColor = Color.DarkCyan;
            this.lblEnter.BorderStyle = BorderStyle.FixedSingle;
            this.lblEnter.Font = new Font("黑体", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblEnter.ForeColor = Color.Black;
            this.lblEnter.Location = new Point(33, 141);
            this.lblEnter.Name = "lblEnter";
            this.lblEnter.Size = new Size(151, 45);
            this.lblEnter.TabIndex = 4;
            this.lblEnter.Text = "\"确认\"开始";
            this.lblEnter.TextAlign = ContentAlignment.MiddleCenter;
            this.txtSch.BorderStyle = BorderStyle.FixedSingle;
            this.txtSch.Font = new Font("黑体", 24f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtSch.ForeColor = Color.Black;
            this.txtSch.Location = new Point(33, 47);
            this.txtSch.MaxLength = 20;
            this.txtSch.Name = "txtSch";
            this.txtSch.Size = new Size(326, 44);
            this.txtSch.TabIndex = 5;
            this.lblTS.AutoSize = true;
            this.lblTS.Font = new Font("黑体", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblTS.ForeColor = Color.DarkRed;
            this.lblTS.Location = new Point(29, 18);
            this.lblTS.Name = "lblTS";
            this.lblTS.Size = new Size(285, 24);
            this.lblTS.TabIndex = 6;
            this.lblTS.Text = "查询料单号（扫描输入）";
            this.lblCancel.BackColor = Color.GreenYellow;
            this.lblCancel.BorderStyle = BorderStyle.FixedSingle;
            this.lblCancel.Font = new Font("黑体", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblCancel.ForeColor = Color.DarkRed;
            this.lblCancel.Location = new Point(208, 141);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new Size(151, 45);
            this.lblCancel.TabIndex = 7;
            this.lblCancel.Text = "\"取消\"退出";
            this.lblCancel.TextAlign = ContentAlignment.MiddleCenter;
            this.panel1.BackColor = Color.SkyBlue;
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add((Control)this.label2);
            this.panel1.Controls.Add((Control)this.lblTS);
            this.panel1.Controls.Add((Control)this.lblCancel);
            this.panel1.Controls.Add((Control)this.lblEnter);
            this.panel1.Controls.Add((Control)this.txtSch);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(392, 220);
            this.panel1.TabIndex = 8;
            this.label2.AutoSize = true;
            this.label2.Font = new Font("黑体", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.label2.ForeColor = Color.Indigo;
            this.label2.Location = new Point(49, 94);
            this.label2.Name = "label2";
            this.label2.Size = new Size(299, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "\"上翻/下翻\"更改输入方式";
            this.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.MidnightBlue;
            this.ClientSize = new Size(398, 226);
            this.ControlBox = false;
            this.Controls.Add((Control)this.panel1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = nameof(frmDLsch);
            this.Padding = new Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.TopMost = true;
            this.FormClosed += new FormClosedEventHandler(this.this_FormClosed);
            this.Load += new EventHandler(this.this_Load);
            this.KeyUp += new KeyEventHandler(this.this_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            // 
            // frmDLsch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 448);
            this.Name = "frmDLsch";
            this.Text = "frmDLsch";
            this.ResumeLayout(false);

        }

        #endregion
        private Label lblEnter;
        private Label lblTS;
        private Label lblCancel;
        public TextBox txtSch;
        private Panel panel1;
        private Label label2;
    }
}
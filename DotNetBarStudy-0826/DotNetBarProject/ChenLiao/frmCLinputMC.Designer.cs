using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.ChenLiao
{
    partial class frmCLinputMC
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
            this.lblEnter = new Label();
            this.txtZL = new TextBox();
            this.lblTS = new Label();
            this.lblCancel = new Label();
            this.panel1 = new Panel();
            this.label2 = new Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            this.lblEnter.BackColor = Color.DarkCyan;
            this.lblEnter.BorderStyle = BorderStyle.FixedSingle;
            this.lblEnter.Font = new Font("黑体", 14f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblEnter.Location = new Point(35, 121);
            this.lblEnter.Name = "lblEnter";
            this.lblEnter.Size = new Size(200, 45);
            this.lblEnter.TabIndex = 4;
            this.lblEnter.Text = "\"确认\"继续称料";
            this.lblEnter.TextAlign = ContentAlignment.MiddleCenter;
            this.txtZL.BorderStyle = BorderStyle.FixedSingle;
            this.txtZL.Font = new Font("黑体", 22f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.txtZL.ForeColor = Color.DarkRed;
            this.txtZL.Location = new Point(143, 62);
            this.txtZL.MaxLength = 20;
            this.txtZL.Name = "txtZL";
            this.txtZL.Size = new Size(192, 41);
            this.txtZL.TabIndex = 5;
            this.txtZL.TextAlign = HorizontalAlignment.Center;
            this.lblTS.AutoSize = true;
            this.lblTS.Font = new Font("黑体", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblTS.ForeColor = Color.DarkRed;
            this.lblTS.Location = new Point(5, 21);
            this.lblTS.Name = "lblTS";
            this.lblTS.Size = new Size(477, 21);
            this.lblTS.TabIndex = 6;
            this.lblTS.Text = "请输入免称重量 ( 0 <= 数值 <= 目标重量 )";
            this.lblCancel.BackColor = Color.DarkCyan;
            this.lblCancel.BorderStyle = BorderStyle.FixedSingle;
            this.lblCancel.Font = new Font("黑体", 14f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblCancel.Location = new Point(252, 121);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new Size(200, 45);
            this.lblCancel.TabIndex = 7;
            this.lblCancel.Text = "返回";
            this.lblCancel.TextAlign = ContentAlignment.MiddleCenter;
            this.panel1.BackColor = Color.SkyBlue;
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add((Control)this.label2);
            this.panel1.Controls.Add((Control)this.lblTS);
            this.panel1.Controls.Add((Control)this.lblCancel);
            this.panel1.Controls.Add((Control)this.lblEnter);
            this.panel1.Controls.Add((Control)this.txtZL);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(492, 192);
            this.panel1.TabIndex = 8;
            this.label2.AutoSize = true;
            this.label2.Font = new Font("宋体", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.label2.Location = new Point(339, 68);
            this.label2.Name = "label2";
            this.label2.Size = new Size(35, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "克";
            this.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.MidnightBlue;
            this.ClientSize = new Size(498, 198);
            this.ControlBox = false;
            this.Controls.Add((Control)this.panel1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
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
        }

        #endregion
        private Label lblEnter;
        private Label lblTS;
        private Label lblCancel;
        public TextBox txtZL;
        private Panel panel1;
        private Label label2;
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.ChenLiao
{
    partial class frmCLend
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
            this.label1 = new Label();
            this.panel1 = new Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            this.lblEnter.BackColor = Color.Yellow;
            this.lblEnter.BorderStyle = BorderStyle.FixedSingle;
            this.lblEnter.Font = new Font("黑体", 18f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.lblEnter.ForeColor = Color.DarkRed;
            this.lblEnter.Location = new Point(65, 80);
            this.lblEnter.Name = "lblEnter";
            this.lblEnter.Size = new Size(250, 45);
            this.lblEnter.TabIndex = 4;
            this.lblEnter.Text = "\"确认\"退出 ( 5 )";
            this.lblEnter.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.Dock = DockStyle.Top;
            this.label1.Font = new Font("黑体", 24f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.label1.ForeColor = Color.DarkRed;
            this.label1.Location = new Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(390, 60);
            this.label1.TabIndex = 6;
            this.label1.Text = "最后一行滴料结束";
            this.label1.TextAlign = ContentAlignment.BottomCenter;
            this.panel1.BackColor = Color.SkyBlue;
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add((Control)this.label1);
            this.panel1.Controls.Add((Control)this.lblEnter);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(392, 142);
            this.panel1.TabIndex = 8;
            this.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.MidnightBlue;
            this.ClientSize = new Size(398, 148);
            this.ControlBox = false;
            this.Controls.Add((Control)this.panel1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmDLend";
            this.Padding = new Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.TopMost = true;
            this.FormClosed += new FormClosedEventHandler(this.this_FormClosed);
            this.Load += new EventHandler(this.this_Load);
            this.Shown += new EventHandler(this.this_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Label lblEnter;
        private Label label1;
        private Panel panel1;
    }
}
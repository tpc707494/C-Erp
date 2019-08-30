using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.ChenLiao
{
    partial class frmCLsch
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
            this.lblEnter = new System.Windows.Forms.Label();
            this.txtSch = new System.Windows.Forms.TextBox();
            this.lblTS = new System.Windows.Forms.Label();
            this.lblCancel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEnter
            // 
            this.lblEnter.BackColor = System.Drawing.Color.DarkCyan;
            this.lblEnter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEnter.Font = new System.Drawing.Font("黑体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEnter.ForeColor = System.Drawing.Color.Black;
            this.lblEnter.Location = new System.Drawing.Point(33, 141);
            this.lblEnter.Name = "lblEnter";
            this.lblEnter.Size = new System.Drawing.Size(151, 45);
            this.lblEnter.TabIndex = 4;
            this.lblEnter.Text = "\"确认\"开始";
            this.lblEnter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEnter.Click += new System.EventHandler(this.LblEnter_Click);
            // 
            // txtSch
            // 
            this.txtSch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSch.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSch.ForeColor = System.Drawing.Color.Black;
            this.txtSch.Location = new System.Drawing.Point(33, 47);
            this.txtSch.MaxLength = 20;
            this.txtSch.Name = "txtSch";
            this.txtSch.Size = new System.Drawing.Size(326, 44);
            this.txtSch.TabIndex = 5;
            // 
            // lblTS
            // 
            this.lblTS.AutoSize = true;
            this.lblTS.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTS.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTS.Location = new System.Drawing.Point(29, 18);
            this.lblTS.Name = "lblTS";
            this.lblTS.Size = new System.Drawing.Size(285, 24);
            this.lblTS.TabIndex = 6;
            this.lblTS.Text = "查询料单号（扫描输入）";
            // 
            // lblCancel
            // 
            this.lblCancel.BackColor = System.Drawing.Color.GreenYellow;
            this.lblCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCancel.Font = new System.Drawing.Font("黑体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCancel.Location = new System.Drawing.Point(208, 141);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(151, 45);
            this.lblCancel.TabIndex = 7;
            this.lblCancel.Text = "\"取消\"退出";
            this.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCancel.Click += new System.EventHandler(this.LblCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTS);
            this.panel1.Controls.Add(this.lblCancel);
            this.panel1.Controls.Add(this.lblEnter);
            this.panel1.Controls.Add(this.txtSch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 220);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(49, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "\"上翻/下翻\"更改输入方式";
            // 
            // frmCLsch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(398, 226);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmCLsch";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.this_FormClosed);
            this.Load += new System.EventHandler(this.this_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.this_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
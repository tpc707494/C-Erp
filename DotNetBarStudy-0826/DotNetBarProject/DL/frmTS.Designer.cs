using System.Windows.Forms;

namespace DotNetBarProject.DL
{
    partial class frmTS
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDT = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTP = new System.Windows.Forms.Label();
            this.lblRL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCancel = new System.Windows.Forms.Label();
            this.lblTS = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEnter
            // 
            this.lblEnter.BackColor = System.Drawing.Color.Yellow;
            this.lblEnter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEnter.Font = new System.Drawing.Font("黑体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEnter.ForeColor = System.Drawing.Color.Black;
            this.lblEnter.Location = new System.Drawing.Point(11, 158);
            this.lblEnter.Name = "lblEnter";
            this.lblEnter.Size = new System.Drawing.Size(508, 45);
            this.lblEnter.TabIndex = 4;
            this.lblEnter.Text = "“确认”功能提示";
            this.lblEnter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEnter.Click += new System.EventHandler(this.LblEnter_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblDT);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTP);
            this.panel1.Controls.Add(this.lblRL);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblCancel);
            this.panel1.Controls.Add(this.lblTS);
            this.panel1.Controls.Add(this.lblEnter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(533, 287);
            this.panel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(192, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 22);
            this.label3.TabIndex = 18;
            this.label3.Text = "滴头:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblDT
            // 
            this.lblDT.AutoSize = true;
            this.lblDT.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDT.ForeColor = System.Drawing.Color.Red;
            this.lblDT.Location = new System.Drawing.Point(266, 14);
            this.lblDT.Name = "lblDT";
            this.lblDT.Size = new System.Drawing.Size(32, 33);
            this.lblDT.TabIndex = 17;
            this.lblDT.Text = "1";
            this.lblDT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "电子称:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblTP
            // 
            this.lblTP.AutoSize = true;
            this.lblTP.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTP.ForeColor = System.Drawing.Color.Red;
            this.lblTP.Location = new System.Drawing.Point(109, 13);
            this.lblTP.Name = "lblTP";
            this.lblTP.Size = new System.Drawing.Size(32, 33);
            this.lblTP.TabIndex = 14;
            this.lblTP.Text = "1";
            this.lblTP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRL
            // 
            this.lblRL.AutoSize = true;
            this.lblRL.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRL.ForeColor = System.Drawing.Color.Red;
            this.lblRL.Location = new System.Drawing.Point(86, 57);
            this.lblRL.Name = "lblRL";
            this.lblRL.Size = new System.Drawing.Size(160, 24);
            this.lblRL.TabIndex = 13;
            this.lblRL.Text = "染料助剂名称";
            this.lblRL.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "品名:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblCancel
            // 
            this.lblCancel.BackColor = System.Drawing.Color.DarkCyan;
            this.lblCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCancel.Font = new System.Drawing.Font("黑体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCancel.Location = new System.Drawing.Point(11, 218);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(507, 45);
            this.lblCancel.TabIndex = 11;
            this.lblCancel.Text = "“取消”功能提示";
            this.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCancel.Click += new System.EventHandler(this.LblCancel_Click);
            // 
            // lblTS
            // 
            this.lblTS.BackColor = System.Drawing.Color.SkyBlue;
            this.lblTS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTS.Font = new System.Drawing.Font("黑体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTS.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTS.Location = new System.Drawing.Point(11, 100);
            this.lblTS.Name = "lblTS";
            this.lblTS.Size = new System.Drawing.Size(508, 45);
            this.lblTS.TabIndex = 9;
            this.lblTS.Text = "提示内容!!!";
            this.lblTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(539, 293);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmTS";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.this_FormClosed);
            this.Load += new System.EventHandler(this.this_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label lblEnter;
        private Panel panel1;
        private Label lblTS;
        private Label lblCancel;
        private Label label1;
        private Label lblRL;
        private Label lblTP;
        private Label label2;
        private Label label3;
        public Label lblDT;
    }
}
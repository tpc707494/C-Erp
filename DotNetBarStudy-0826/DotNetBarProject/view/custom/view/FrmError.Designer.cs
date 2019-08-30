using DevComponents.DotNetBar;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    partial class FrmError
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
            this.lblEnter = new DevComponents.DotNetBar.LabelX();
            this.lblTS = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new DevComponents.DotNetBar.PanelEx();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEnter
            // 
            this.lblEnter.BackColor = System.Drawing.Color.LightPink;
            // 
            // 
            // 
            this.lblEnter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEnter.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEnter.ForeColor = System.Drawing.Color.DarkRed;
            this.lblEnter.Location = new System.Drawing.Point(102, 96);
            this.lblEnter.Name = "lblEnter";
            this.lblEnter.Size = new System.Drawing.Size(250, 45);
            this.lblEnter.TabIndex = 4;
            this.lblEnter.Text = "\"确认\"继续";
            this.lblEnter.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblEnter.Click += new System.EventHandler(this.lblEnter_Click);
            // 
            // lblTS
            // 
            // 
            // 
            // 
            this.lblTS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTS.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTS.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTS.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTS.Location = new System.Drawing.Point(0, 0);
            this.lblTS.Name = "lblTS";
            this.lblTS.Size = new System.Drawing.Size(451, 68);
            this.lblTS.TabIndex = 6;
            this.lblTS.Text = "提示";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTS);
            this.panel1.Controls.Add(this.lblEnter);
            this.panel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 169);
            this.panel1.TabIndex = 8;
            // 
            // FrmError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(459, 175);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmError";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmError";
            this.TopMost = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmError_KeyUp);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LabelX lblEnter;
        private LabelX lblTS;
        private PanelEx panel1;
    }
}
using DotNetBarProject.view.custom.view;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.baseinfo
{
    partial class FrmPSW
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
            this.btnOK = new System.Windows.Forms.Button();
            this.txtWn2 = new DotNetBarProject.view.custom.view.LblTxt();
            this.txtWn1 = new DotNetBarProject.view.custom.view.LblTxt();
            this.txtWy = new DotNetBarProject.view.custom.view.LblTxt();
            this.lblYH = new DotNetBarProject.view.custom.view.LblTxt();
            this.lblBH = new DotNetBarProject.view.custom.view.LblTxt();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(195, 215);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 33);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "修改密码";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtWn2
            // 
            this.txtWn2.BackColor = System.Drawing.Color.Transparent;
            this.txtWn2.jiange = 5;
            this.txtWn2.lblFont = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWn2.lblText = "新密码";
            this.txtWn2.Location = new System.Drawing.Point(67, 164);
            this.txtWn2.Name = "txtWn2";
            this.txtWn2.ReadOnly = false;
            this.txtWn2.Size = new System.Drawing.Size(208, 23);
            this.txtWn2.TabIndex = 2;
            this.txtWn2.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtWn2.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWn2.txtFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWn2.txtISid = false;
            this.txtWn2.txtISint = false;
            this.txtWn2.txtISmoney = false;
            this.txtWn2.txtLen = 50;
            this.txtWn2.txtMulLine = false;
            this.txtWn2.txtReadonly = false;
            this.txtWn2.txtTop = true;
            this.txtWn2.txtUpper = false;
            this.txtWn2.upperZero = false;
            // 
            // txtWn1
            // 
            this.txtWn1.BackColor = System.Drawing.Color.Transparent;
            this.txtWn1.jiange = 5;
            this.txtWn1.lblFont = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWn1.lblText = "新密码";
            this.txtWn1.Location = new System.Drawing.Point(67, 128);
            this.txtWn1.Name = "txtWn1";
            this.txtWn1.ReadOnly = false;
            this.txtWn1.Size = new System.Drawing.Size(208, 23);
            this.txtWn1.TabIndex = 1;
            this.txtWn1.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtWn1.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWn1.txtFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWn1.txtISid = false;
            this.txtWn1.txtISint = false;
            this.txtWn1.txtISmoney = false;
            this.txtWn1.txtLen = 50;
            this.txtWn1.txtMulLine = false;
            this.txtWn1.txtReadonly = false;
            this.txtWn1.txtTop = true;
            this.txtWn1.txtUpper = false;
            this.txtWn1.upperZero = false;
            // 
            // txtWy
            // 
            this.txtWy.BackColor = System.Drawing.Color.Transparent;
            this.txtWy.jiange = 5;
            this.txtWy.lblFont = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWy.lblText = "原密码";
            this.txtWy.Location = new System.Drawing.Point(67, 93);
            this.txtWy.Name = "txtWy";
            this.txtWy.ReadOnly = false;
            this.txtWy.Size = new System.Drawing.Size(208, 23);
            this.txtWy.TabIndex = 0;
            this.txtWy.txtBackColor = System.Drawing.SystemColors.Window;
            this.txtWy.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWy.txtFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWy.txtISid = false;
            this.txtWy.txtISint = false;
            this.txtWy.txtISmoney = false;
            this.txtWy.txtLen = 50;
            this.txtWy.txtMulLine = false;
            this.txtWy.txtReadonly = false;
            this.txtWy.txtTop = true;
            this.txtWy.txtUpper = false;
            this.txtWy.upperZero = false;
            // 
            // lblYH
            // 
            this.lblYH.BackColor = System.Drawing.Color.Transparent;
            this.lblYH.jiange = 5;
            this.lblYH.lblFont = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblYH.lblText = "用户:";
            this.lblYH.Location = new System.Drawing.Point(67, 63);
            this.lblYH.Name = "lblYH";
            this.lblYH.ReadOnly = true;
            this.lblYH.Size = new System.Drawing.Size(208, 24);
            this.lblYH.TabIndex = 4;
            this.lblYH.txtBackColor = System.Drawing.SystemColors.Control;
            this.lblYH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblYH.txtFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblYH.txtISid = false;
            this.lblYH.txtISint = false;
            this.lblYH.txtISmoney = false;
            this.lblYH.txtLen = 50;
            this.lblYH.txtMulLine = false;
            this.lblYH.txtReadonly = true;
            this.lblYH.txtTop = true;
            this.lblYH.txtUpper = false;
            this.lblYH.upperZero = false;
            // 
            // lblBH
            // 
            this.lblBH.BackColor = System.Drawing.Color.Transparent;
            this.lblBH.jiange = 5;
            this.lblBH.lblFont = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBH.lblText = "编号:";
            this.lblBH.Location = new System.Drawing.Point(67, 33);
            this.lblBH.Name = "lblBH";
            this.lblBH.ReadOnly = true;
            this.lblBH.Size = new System.Drawing.Size(208, 24);
            this.lblBH.TabIndex = 5;
            this.lblBH.txtBackColor = System.Drawing.SystemColors.Control;
            this.lblBH.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblBH.txtFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBH.txtISid = false;
            this.lblBH.txtISint = false;
            this.lblBH.txtISmoney = false;
            this.lblBH.txtLen = 50;
            this.lblBH.txtMulLine = false;
            this.lblBH.txtReadonly = true;
            this.lblBH.txtTop = true;
            this.lblBH.txtUpper = false;
            this.lblBH.upperZero = false;
            // 
            // FrmPSW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(331, 286);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtWn2);
            this.Controls.Add(this.txtWn1);
            this.Controls.Add(this.txtWy);
            this.Controls.Add(this.lblYH);
            this.Controls.Add(this.lblBH);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPSW";
            this.Text = "FrmPSW";
            this.Load += new System.EventHandler(this.FrmPSW_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LblTxt lblBH;
        private LblTxt lblYH;
        private LblTxt txtWy;
        private LblTxt txtWn1;
        private LblTxt txtWn2;
        private Button btnOK;
    }
}
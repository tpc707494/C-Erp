using DevComponents.DotNetBar.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    partial class ChkCoboEX
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.chk = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.coboex = new DotNetBarProject.view.custom.view.coboEX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chk
            // 
            this.chk.AutoSize = true;
            this.chk.Dock = System.Windows.Forms.DockStyle.Left;
            this.chk.Location = new System.Drawing.Point(0, 0);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(72, 150);
            this.chk.TabIndex = 0;
            this.chk.Text = "checkBox";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.coboex);
            this.panel1.Controls.Add(this.chk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 150);
            this.panel1.TabIndex = 2;
            // 
            // coboex
            // 
            this.coboex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coboex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.coboex.Enabled = false;
            this.coboex.FormattingEnabled = true;
            this.coboex.ItemHeight = 15;
            this.coboex.Location = new System.Drawing.Point(72, 0);
            this.coboex.Name = "coboex";
            this.coboex.Size = new System.Drawing.Size(241, 21);
            this.coboex.TabIndex = 1;
            // 
            // ChkCoboEX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ChkCoboEX";
            this.Size = new System.Drawing.Size(313, 150);
            this.Load += new System.EventHandler(this.this_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        public CheckBox chk;
        public coboEX coboex;

        #endregion

        private Panel panel1;
    }
}

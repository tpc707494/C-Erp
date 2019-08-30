using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    partial class ChkCoboDGV
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
            this.cobodgv = new DotNetBarProject.view.custom.view.coboDGV();
            this.SuspendLayout();
            // 
            // chk
            // 
            this.chk.AutoSize = true;
            this.chk.Dock = System.Windows.Forms.DockStyle.Left;
            this.chk.Location = new System.Drawing.Point(0, 0);
            this.chk.Name = "chk";
            this.chk.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.chk.Size = new System.Drawing.Size(48, 99);
            this.chk.TabIndex = 0;
            this.chk.Text = "助剂";
            this.chk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk.UseVisualStyleBackColor = true;
            // 
            // cobodgv
            // 
            this.cobodgv.allowInput = false;
            this.cobodgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cobodgv.Enabled = false;
            this.cobodgv.FormattingEnabled = true;
            this.cobodgv.Location = new System.Drawing.Point(48, 0);
            this.cobodgv.Name = "cobodgv";
            this.cobodgv.SeparatorChar = " ";
            this.cobodgv.Size = new System.Drawing.Size(253, 20);
            this.cobodgv.TabIndex = 1;
            this.cobodgv.TextFromList = true;
            // 
            // ChkCoboDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cobodgv);
            this.Controls.Add(this.chk);
            this.Name = "ChkCoboDGV";
            this.Size = new System.Drawing.Size(301, 99);
            this.Load += new System.EventHandler(this.this_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public CheckBox chk;
        public coboDGV cobodgv;
    }
}

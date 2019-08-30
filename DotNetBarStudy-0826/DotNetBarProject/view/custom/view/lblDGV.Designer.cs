using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    partial class lblDGV
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
            this.lbl = new System.Windows.Forms.Label();
            this.cobodgv = new DotNetBarProject.view.custom.view.DGV();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(12, 11);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(41, 12);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "label1";
            // 
            // cobodgv
            // 
            this.cobodgv.allowInput = false;
            this.cobodgv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cobodgv.FormattingEnabled = true;
            this.cobodgv.Location = new System.Drawing.Point(72, 3);
            this.cobodgv.Name = "cobodgv";
            this.cobodgv.rowSN = ((long)(-1));
            this.cobodgv.SeparatorChar = " ";
            this.cobodgv.Size = new System.Drawing.Size(121, 20);
            this.cobodgv.TabIndex = 1;
            // 
            // lblDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cobodgv);
            this.Controls.Add(this.lbl);
            this.Name = "lblDGV";
            this.Size = new System.Drawing.Size(243, 150);
            this.Load += new System.EventHandler(this.this_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label lbl;
        public DGV cobodgv;
    }
}

using DevComponents.DotNetBar.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    partial class ChkTxt
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
            this.txt = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // chk
            // 
            this.chk.AutoSize = true;
            this.chk.Dock = System.Windows.Forms.DockStyle.Left;
            this.chk.Location = new System.Drawing.Point(0, 0);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(72, 110);
            this.chk.TabIndex = 0;
            this.chk.Text = "checkBox";
            // 
            // txt
            // 
            this.txt.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txt.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txt.Border.BorderBottomWidth = 1;
            this.txt.Border.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.txt.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txt.Border.BorderLeftWidth = 1;
            this.txt.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txt.Border.BorderRightWidth = 1;
            this.txt.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txt.Border.BorderTopWidth = 1;
            this.txt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt.Enabled = false;
            this.txt.Location = new System.Drawing.Point(72, 0);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(173, 17);
            this.txt.TabIndex = 1;
            // 
            // ChkTxt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt);
            this.Controls.Add(this.chk);
            this.Name = "ChkTxt";
            this.Size = new System.Drawing.Size(245, 110);
            this.Load += new System.EventHandler(this.this_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public CheckBox chk;
        public TextBoxX txt;
    }
}

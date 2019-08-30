using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace DotNetBarProject.view.custom.view
{
    partial class LblTxt
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
            this.lbl = new DevComponents.DotNetBar.LabelX();
            this.txt = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            // 
            // 
            // 
            this.lbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl.Location = new System.Drawing.Point(20, 12);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(44, 16);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "label1";
            // 
            // txt
            // 
            // 
            // 
            // 
            this.txt.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txt.Border.BorderBottomWidth = 1;
            this.txt.Border.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.txt.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txt.Border.BorderLeftColor = System.Drawing.SystemColors.ActiveBorder;
            this.txt.Border.BorderLeftWidth = 1;
            this.txt.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txt.Border.BorderRightColor = System.Drawing.SystemColors.ActiveBorder;
            this.txt.Border.BorderRightWidth = 1;
            this.txt.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txt.Border.BorderTopColor = System.Drawing.SystemColors.ActiveBorder;
            this.txt.Border.BorderTopWidth = 1;
            this.txt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt.Location = new System.Drawing.Point(76, 9);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(100, 17);
            this.txt.TabIndex = 1;
            // 
            // LblTxt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txt);
            this.Controls.Add(this.lbl);
            this.Name = "LblTxt";
            this.Size = new System.Drawing.Size(257, 150);
            this.Load += new System.EventHandler(this.this_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public LabelX lbl;

        public TextBoxX txt;
        #endregion
    }
}

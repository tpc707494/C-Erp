using DevComponents.DotNetBar;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    partial class LblCoboEX
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
            this.coboEX1 = new DotNetBarProject.view.custom.view.coboEX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            // 
            // 
            // 
            this.lbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl.Location = new System.Drawing.Point(0, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(44, 16);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "label1";
            // 
            // coboEX1
            // 
            this.coboEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coboEX1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.coboEX1.FormattingEnabled = true;
            this.coboEX1.ItemHeight = 15;
            this.coboEX1.Location = new System.Drawing.Point(44, 0);
            this.coboEX1.Name = "coboEX1";
            this.coboEX1.Size = new System.Drawing.Size(215, 21);
            this.coboEX1.TabIndex = 999;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.coboEX1);
            this.panel1.Controls.Add(this.lbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 69);
            this.panel1.TabIndex = 2;
            // 
            // LblCoboEX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "LblCoboEX";
            this.Size = new System.Drawing.Size(259, 69);
            this.Load += new System.EventHandler(this.LblCoboEX_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        public LabelX lbl;
        #endregion

        public coboEX coboEX1;
        private Panel panel1;
    }
}

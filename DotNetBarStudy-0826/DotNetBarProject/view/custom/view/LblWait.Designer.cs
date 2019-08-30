using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    partial class LblWait
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
            this.label1 = new Label();
            this.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("黑体", 15.75f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            this.label1.ForeColor = Color.Firebrick;
            this.label1.Location = new Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(196, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "执行中,请稍候!!!";
            this.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightBlue;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add((Control)this.label1);
            this.Name = nameof(LblWait);
            this.Size = new Size(229, 48);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private Label label1;
        private Form frm;

        #endregion
    }
}

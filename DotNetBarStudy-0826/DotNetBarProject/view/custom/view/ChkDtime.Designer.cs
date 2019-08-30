using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    partial class ChkDtime
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
            this.lblTo = new DevComponents.DotNetBar.LabelX();
            this.chkF = new System.Windows.Forms.CheckBox();
            this.chkT = new System.Windows.Forms.CheckBox();
            this.dtimeF = new System.Windows.Forms.DateTimePicker();
            this.dtimeT = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            // 
            // 
            // 
            this.lbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl.Location = new System.Drawing.Point(6, 4);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(44, 16);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "label1";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            // 
            // 
            // 
            this.lblTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTo.Location = new System.Drawing.Point(213, 4);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(19, 16);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "→";
            // 
            // chkF
            // 
            this.chkF.AutoSize = true;
            this.chkF.Location = new System.Drawing.Point(49, 3);
            this.chkF.Name = "chkF";
            this.chkF.Size = new System.Drawing.Size(15, 14);
            this.chkF.TabIndex = 2;
            // 
            // chkT
            // 
            this.chkT.AutoSize = true;
            this.chkT.Location = new System.Drawing.Point(231, 4);
            this.chkT.Name = "chkT";
            this.chkT.Size = new System.Drawing.Size(15, 14);
            this.chkT.TabIndex = 3;
            this.chkT.UseVisualStyleBackColor = true;
            // 
            // dtimeF
            // 
            this.dtimeF.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtimeF.Enabled = false;
            this.dtimeF.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtimeF.Location = new System.Drawing.Point(68, 0);
            this.dtimeF.Name = "dtimeF";
            this.dtimeF.Size = new System.Drawing.Size(142, 21);
            this.dtimeF.TabIndex = 4;
            // 
            // dtimeT
            // 
            this.dtimeT.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtimeT.Enabled = false;
            this.dtimeT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtimeT.Location = new System.Drawing.Point(247, 0);
            this.dtimeT.Name = "dtimeT";
            this.dtimeT.Size = new System.Drawing.Size(142, 21);
            this.dtimeT.TabIndex = 5;
            // 
            // ChkDtime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtimeT);
            this.Controls.Add(this.dtimeF);
            this.Controls.Add(this.chkT);
            this.Controls.Add(this.chkF);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lbl);
            this.Name = "ChkDtime";
            this.Size = new System.Drawing.Size(467, 21);
            this.Load += new System.EventHandler(this.ChkDtime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public LabelX lblTo;
        public CheckBox chkF;
        public CheckBox chkT;
        public LabelX lbl;
        public DateTimePicker dtimeF;
        public DateTimePicker dtimeT;
    }
}

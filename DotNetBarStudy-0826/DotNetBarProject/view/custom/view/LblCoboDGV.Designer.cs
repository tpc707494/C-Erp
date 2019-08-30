using DevComponents.DotNetBar;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    partial class LblCoboDGV
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
            if (disposing && this.components != null)
            {
                this.components.Dispose();
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
            this.cobodgv = new DotNetBarProject.view.custom.view.MultiColumComboBox();
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
            this.lbl.PaddingTop = 5;
            this.lbl.Size = new System.Drawing.Size(44, 21);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "label1";
            // 
            // cobodgv
            // 
            this.cobodgv.ColumnWidth = null;
            this.cobodgv.DataSource = null;
            this.cobodgv.DisplayColumnNo = 1;
            this.cobodgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cobodgv.DropDownHeight = 200;
            this.cobodgv.GridLines = DotNetBarProject.view.custom.view.GridLines.None;
            this.cobodgv.Location = new System.Drawing.Point(44, 0);
            this.cobodgv.Name = "cobodgv";
            this.cobodgv.SelectedItem = null;
            this.cobodgv.ShowHeader = false;
            this.cobodgv.Size = new System.Drawing.Size(196, 21);
            this.cobodgv.SourceDataHeader = null;
            this.cobodgv.SourceDataString = null;
            this.cobodgv.TabIndex = 1;
            this.cobodgv.ValueColumnNo = 0;
            // 
            // LblCoboDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cobodgv);
            this.Controls.Add(this.lbl);
            this.Name = "LblCoboDGV";
            this.Size = new System.Drawing.Size(240, 150);
            this.Load += new System.EventHandler(this.this_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public LabelX lbl;
        public MultiColumComboBox cobodgv;
    }
}

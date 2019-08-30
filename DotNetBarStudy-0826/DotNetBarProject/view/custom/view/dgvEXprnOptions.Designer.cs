using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    partial class dgvEXprnOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(dgvEXprnOptions));
            this.optPaperH = new RadioButton();
            this.optPaperZ = new RadioButton();
            this.chkFitToPageWidth = new CheckBox();
            this.gboxRowsToPrint = new GroupBox();
            this.lblColumnsToPrint = new Label();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.chklst = new CheckedListBox();
            this.gboxRowsToPrint.SuspendLayout();
            base.SuspendLayout();
            this.optPaperH.AutoSize = true;
            this.optPaperH.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.optPaperH.Location = new Point(91, 18);
            this.optPaperH.Name = "optPaperH";
            this.optPaperH.Size = new Size(77, 17);
            this.optPaperH.TabIndex = 1;
            this.optPaperH.TabStop = true;
            this.optPaperH.Text = "纸张横向";
            this.optPaperH.UseVisualStyleBackColor = true;
            this.optPaperZ.AutoSize = true;
            this.optPaperZ.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.optPaperZ.Location = new Point(9, 18);
            this.optPaperZ.Name = "optPaperZ";
            this.optPaperZ.Size = new Size(77, 17);
            this.optPaperZ.TabIndex = 0;
            this.optPaperZ.TabStop = true;
            this.optPaperZ.Text = "纸张纵向";
            this.optPaperZ.UseVisualStyleBackColor = true;
            this.chkFitToPageWidth.AutoSize = true;
            this.chkFitToPageWidth.FlatStyle = FlatStyle.System;
            this.chkFitToPageWidth.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.chkFitToPageWidth.Location = new Point(202, 81);
            this.chkFitToPageWidth.Name = "chkFitToPageWidth";
            this.chkFitToPageWidth.Size = new Size(84, 18);
            this.chkFitToPageWidth.TabIndex = 21;
            this.chkFitToPageWidth.Text = "适应页宽";
            this.chkFitToPageWidth.UseVisualStyleBackColor = true;
            this.gboxRowsToPrint.Controls.Add(this.optPaperH);
            this.gboxRowsToPrint.Controls.Add(this.optPaperZ);
            this.gboxRowsToPrint.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.gboxRowsToPrint.Location = new Point(184, 20);
            this.gboxRowsToPrint.Name = "gboxRowsToPrint";
            this.gboxRowsToPrint.Size = new Size(173, 39);
            this.gboxRowsToPrint.TabIndex = 18;
            this.gboxRowsToPrint.TabStop = false;
            this.gboxRowsToPrint.Text = "页面设置";
            this.lblColumnsToPrint.AutoSize = true;
            this.lblColumnsToPrint.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblColumnsToPrint.Location = new Point(8, 2);
            this.lblColumnsToPrint.Name = "lblColumnsToPrint";
            this.lblColumnsToPrint.Size = new Size(98, 13);
            this.lblColumnsToPrint.TabIndex = 17;
            this.lblColumnsToPrint.Text = "选择要打印的列";
            this.btnOK.BackColor = SystemColors.Control;
            this.btnOK.Cursor = Cursors.Default;
            this.btnOK.FlatStyle = FlatStyle.System;
            this.btnOK.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 178);
            this.btnOK.ForeColor = SystemColors.ControlText;
            //this.btnOK.Image = (Image)componentResourceManager.GetObject("btnOK.Image");
            this.btnOK.ImageAlign = ContentAlignment.MiddleRight;
            this.btnOK.Location = new Point(205, 150);
            this.btnOK.Name = "btnOK";
            this.btnOK.RightToLeft = RightToLeft.No;
            this.btnOK.Size = new Size(56, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "打印";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.btnCancel.BackColor = SystemColors.Control;
            this.btnCancel.Cursor = Cursors.Default;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.FlatStyle = FlatStyle.System;
            this.btnCancel.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 178);
            this.btnCancel.ForeColor = SystemColors.ControlText;
            //this.btnCancel.Image = (Image)componentResourceManager.GetObject("btnCancel.Image");
            this.btnCancel.Location = new Point(284, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = RightToLeft.No;
            this.btnCancel.Size = new Size(56, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.chklst.CheckOnClick = true;
            this.chklst.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.chklst.FormattingEnabled = true;
            this.chklst.Location = new Point(8, 19);
            this.chklst.Name = "chklst";
            this.chklst.Size = new Size(170, 229);
            this.chklst.TabIndex = 13;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(369, 259);
            base.Controls.Add(this.chkFitToPageWidth);
            base.Controls.Add(this.gboxRowsToPrint);
            base.Controls.Add(this.lblColumnsToPrint);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.chklst);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "DGVprnOptions";
            base.SizeGripStyle = SizeGripStyle.Show;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "打印设置";
            base.Load += new EventHandler(this.PrintOtions_Load);
            this.gboxRowsToPrint.ResumeLayout(false);
            this.gboxRowsToPrint.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}
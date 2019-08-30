using System.Windows.Forms;

namespace DotNetBarProject.view.baseinfo
{
    partial class DiLiaoSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCoboEX1 = new DotNetBarProject.view.custom.view.LblCoboEX();
            this.lblTxt1 = new DotNetBarProject.view.custom.view.LblTxt();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvEX1 = new DotNetBarProject.view.custom.view.dgvEX();
            this.colDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.checkBox1.Location = new System.Drawing.Point(523, 49);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(139, 20);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "允许半自动称料";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCoboEX1);
            this.panel1.Controls.Add(this.lblTxt1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 88);
            this.panel1.TabIndex = 4;
            // 
            // lblCoboEX1
            // 
            this.lblCoboEX1.allowInput = true;
            this.lblCoboEX1.coboFlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.lblCoboEX1.coboFont = new System.Drawing.Font("宋体", 12F);
            this.lblCoboEX1.Font = new System.Drawing.Font("宋体", 12F);
            this.lblCoboEX1.jiange = 5;
            this.lblCoboEX1.lblFont = new System.Drawing.Font("宋体", 12F);
            this.lblCoboEX1.lblText = "机台编号";
            this.lblCoboEX1.Location = new System.Drawing.Point(224, 8);
            this.lblCoboEX1.Margin = new System.Windows.Forms.Padding(5);
            this.lblCoboEX1.Name = "lblCoboEX1";
            this.lblCoboEX1.Size = new System.Drawing.Size(246, 21);
            this.lblCoboEX1.TabIndex = 3;
            // 
            // lblTxt1
            // 
            this.lblTxt1.BackColor = System.Drawing.Color.Transparent;
            this.lblTxt1.Font = new System.Drawing.Font("宋体", 12F);
            this.lblTxt1.jiange = 5;
            this.lblTxt1.lblFont = new System.Drawing.Font("宋体", 12F);
            this.lblTxt1.lblText = "机台名称";
            this.lblTxt1.Location = new System.Drawing.Point(224, 49);
            this.lblTxt1.Margin = new System.Windows.Forms.Padding(5);
            this.lblTxt1.Name = "lblTxt1";
            this.lblTxt1.ReadOnly = false;
            this.lblTxt1.Size = new System.Drawing.Size(246, 27);
            this.lblTxt1.TabIndex = 1;
            this.lblTxt1.txtBackColor = System.Drawing.SystemColors.Window;
            this.lblTxt1.txtBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTxt1.txtFont = new System.Drawing.Font("宋体", 12F);
            this.lblTxt1.txtISid = false;
            this.lblTxt1.txtISint = false;
            this.lblTxt1.txtISmoney = false;
            this.lblTxt1.txtLen = 50;
            this.lblTxt1.txtMulLine = false;
            this.lblTxt1.txtReadonly = false;
            this.lblTxt1.txtTop = true;
            this.lblTxt1.txtUpper = false;
            this.lblTxt1.upperZero = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(590, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 413);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(802, 66);
            this.panel2.TabIndex = 5;
            // 
            // dgvEX1
            // 
            this.dgvEX1.AllowUserToAddRows = false;
            this.dgvEX1.AllowUserToDeleteRows = false;
            this.dgvEX1.AllowUserToResizeColumns = false;
            this.dgvEX1.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDT,
            this.colRL});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEX1.EnableHeadersVisualStyles = false;
            this.dgvEX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvEX1.Location = new System.Drawing.Point(0, 88);
            this.dgvEX1.Name = "dgvEX1";
            this.dgvEX1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEX1.RowNumShow = false;
            this.dgvEX1.RowTemplate.Height = 23;
            this.dgvEX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEX1.Size = new System.Drawing.Size(802, 325);
            this.dgvEX1.TabIndex = 3;
            // 
            // colDT
            // 
            this.colDT.HeaderText = "滴头";
            this.colDT.Name = "colDT";
            this.colDT.ReadOnly = true;
            this.colDT.Width = 380;
            // 
            // colRL
            // 
            this.colRL.HeaderText = "染化料名称";
            this.colRL.Name = "colRL";
            this.colRL.ReadOnly = true;
            this.colRL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRL.Width = 379;
            // 
            // DiLiaoSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(802, 479);
            this.Controls.Add(this.dgvEX1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DiLiaoSet";
            this.Text = "DiLiaoSet";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private custom.view.LblTxt lblTxt1;
        private System.Windows.Forms.CheckBox checkBox1;
        private custom.view.dgvEX dgvEX1;
        private System.Windows.Forms.Panel panel1;
        private custom.view.LblCoboEX lblCoboEX1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private DataGridViewTextBoxColumn colDT;
        private DataGridViewTextBoxColumn colRL;
    }
}
namespace DotNetBarProject.view.custom.view
{
    partial class MultiColumComboBox
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
            this.txtbox = new System.Windows.Forms.TextBox();
            this.buttonDropDown = new System.Windows.Forms.Button();
            components = new System.ComponentModel.Container();
            // 
            // txtbox
            // 
            this.txtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbox.Location = new System.Drawing.Point(0, 0);
            this.txtbox.Name = "txtbox";
            this.txtbox.Size = new System.Drawing.Size(194, 20);
            this.txtbox.TabIndex = 0;
            this.txtbox.Leave += new System.EventHandler(this.txtbox_Leave);
            this.txtbox.FontChanged += new System.EventHandler(this.txtbox_FontChanged);
            this.txtbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbox_KeyUp);
            // 
            // buttonDropDown
            // 
            this.buttonDropDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDropDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDropDown.Font = new System.Drawing.Font("Marlett", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonDropDown.Location = new System.Drawing.Point(195, 0);
            this.buttonDropDown.Name = "buttonDropDown";
            this.buttonDropDown.Size = new System.Drawing.Size(20, 22);
            this.buttonDropDown.TabIndex = 4;
            this.buttonDropDown.TabStop = false;
            this.buttonDropDown.Text = "u";
            this.buttonDropDown.UseVisualStyleBackColor = true;
            this.buttonDropDown.Click += new System.EventHandler(this.buttonDropDown_Click);
            // 
            // MultiColumComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDropDown);
            this.Controls.Add(this.txtbox);
            this.Size = new System.Drawing.Size(215, 22);
            this.Resize += new System.EventHandler(this.MultiColumComboBox_Resize);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        public System.Windows.Forms.TextBox txtbox;
        private System.Windows.Forms.Button buttonDropDown;
    }
}

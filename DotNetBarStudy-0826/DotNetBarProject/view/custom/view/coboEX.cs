using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    public partial class coboEX : ComboBox
    {
        public coboEX()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.ItemHeight = Convert.ToInt32((double)this.FontHeight * 1.1);
            this.DrawItem += new DrawItemEventHandler(this.CoboEx_DrawItem);
            this.FontChanged += new EventHandler(this.CoboEx_FontChanged);
            this.KeyUp += new KeyEventHandler(this.CoboEx_KeyUp);
        }

        private void CoboEx_FontChanged(object sender, EventArgs e)
        {
            this.ItemHeight = Convert.ToInt32((double)this.FontHeight * 1.1);
        }

        private void CoboEx_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (this.Enabled)
                e.Graphics.FillRectangle((Brush)new SolidBrush(SystemColors.HighlightText), e.Bounds);
            else
                e.Graphics.FillRectangle((Brush)new SolidBrush(SystemColors.Control), e.Bounds);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Far;
            if (e.Index == -1)
                e.Graphics.DrawString("", e.Font, (Brush)new SolidBrush(SystemColors.ControlText), (RectangleF)e.Bounds, format);
            else
                e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, (Brush)new SolidBrush(this.ForeColor), (RectangleF)e.Bounds, format);
            e.DrawFocusRectangle();
        }

        private void CoboEx_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.DropDownStyle != ComboBoxStyle.DropDownList || e.KeyCode != Keys.Delete)
                return;
            this.SelectedIndex = -1;
        }

        public void RefList(coboEX.leibie LB)
        {
            this.Items.Clear();
            ///DBpf dbpf = new DBpf(Settings.Default.DBconn);
            if (LB == leibie.染料类别)
            {
                this.Items.Add((object)DotNetBarProject.view.custom.data.leibie.enumLB.染料.ToString());
                this.Items.Add((object)DotNetBarProject.view.custom.data.leibie.enumLB.助剂.ToString());
            }
            //dbpf.Dispose();
            EmptyText();
        }

        public void EmptyText()
        {
            if (this.DropDownStyle == ComboBoxStyle.DropDownList)
                this.SelectedIndex = -1;
            else
                this.Text = "";
        }

        public enum leibie
        {
            染料类别,
        }
    }
}

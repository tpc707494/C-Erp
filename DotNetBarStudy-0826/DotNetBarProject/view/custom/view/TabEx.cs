using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    public partial class TabEx : TabControl
    {
        private int _XieLong = 10;
        private Decimal _XieSuoLv = new Decimal(30);
        private int yBegin = 0;
        private int xLongSub = 0;
        private TabEx.enumDisplwyStyle _DisplayStyle = TabEx.enumDisplwyStyle.Vstudio;
        private const int WM_SETFONT = 48;
        private const int WM_FONTCHANGE = 29;
        public TabEx()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.ResizeRedraw = true;
        }

        public int XieLong
        {
            get
            {
                return this._XieLong;
            }
            set
            {
                if (value >= this.ItemSize.Width || value <= 0 || value > 50)
                {
                    int num = (int)MessageBox.Show("值超出,不能大于标签宽度且值在:1 - 50");
                }
                else
                {
                    this._XieLong = value;
                    this.xLongSub = (int)((Decimal)this.XieLong * (new Decimal(100) - this._XieSuoLv) / new Decimal(100));
                    this.yBegin = (int)((Decimal)this.ItemSize.Height * (new Decimal(100) - this._XieSuoLv) / new Decimal(100));
                }
            }
        }

        public Decimal XieSuoLv
        {
            get
            {
                return this._XieSuoLv;
            }
            set
            {
                if (value <= new Decimal(0) || value > new Decimal(80))
                {
                    int num = (int)MessageBox.Show("值超出,值在:1 - 80");
                }
                else
                {
                    this._XieSuoLv = value;
                    this.xLongSub = (int)((Decimal)this.XieLong * (new Decimal(100) - this._XieSuoLv) / new Decimal(100));
                    this.yBegin = (int)((Decimal)this.ItemSize.Height * (new Decimal(100) - this._XieSuoLv) / new Decimal(100));
                }
            }
        }

        [DefaultValue(typeof(TabEx.enumDisplwyStyle), "Vstudio")]
        public TabEx.enumDisplwyStyle DisplayStyle
        {
            get
            {
                return this._DisplayStyle;
            }
            set
            {
                if (this._DisplayStyle == value)
                    return;
                this._DisplayStyle = value;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (this.DesignMode)
            {
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.Bounds, SystemColors.ControlLight, SystemColors.ControlLightLight, LinearGradientMode.Vertical);
                pevent.Graphics.FillRectangle((Brush)linearGradientBrush, this.Bounds);
                linearGradientBrush.Dispose();
            }
            else
                this.PaintTransparentBackground(pevent.Graphics, this.ClientRectangle);
        }

        protected void PaintTransparentBackground(Graphics g, Rectangle clipRect)
        {
            if (this.Parent != null)
            {
                clipRect.Offset(this.Location);
                PaintEventArgs e = new PaintEventArgs(g, clipRect);
                GraphicsState gstate = g.Save();
                g.SmoothingMode = SmoothingMode.HighSpeed;
                try
                {
                    Graphics graphics = g;
                    Point location = this.Location;
                    double num1 = (double)-location.X;
                    location = this.Location;
                    double num2 = (double)-location.Y;
                    graphics.TranslateTransform((float)num1, (float)num2);
                    this.InvokePaintBackground(this.Parent, e);
                    this.InvokePaint(this.Parent, e);
                }
                finally
                {
                    g.Restore(gstate);
                    clipRect.Offset(-this.Location.X, -this.Location.Y);
                }
            }
            else
            {
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.Bounds, SystemColors.ControlLightLight, SystemColors.ControlLight, LinearGradientMode.Vertical);
                g.FillRectangle((Brush)linearGradientBrush, this.Bounds);
                linearGradientBrush.Dispose();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.PaintTransparentBackground(e.Graphics, this.ClientRectangle);
            this.PaintAllTheTabs(e);
        }

        private void PaintAllTheTabs(PaintEventArgs e)
        {
            if (this.TabCount <= 0)
                return;
            for (int index = 0; index < this.TabCount; ++index)
                this.PaintTab(e, index);
        }

        private void PaintTab(PaintEventArgs e, int index)
        {
            GraphicsPath path = this.GetPath(index);
            this.PaintTabBackground(e.Graphics, index, path);
            this.PaintTabBorder(e.Graphics, index, path);
            this.PaintTabText(e.Graphics, index);
        }

        private void PaintTabBackground(Graphics graph, int index, GraphicsPath path)
        {
            Brush brush = (Brush)new LinearGradientBrush(this.GetTabRect(index), SystemColors.ControlLightLight, SystemColors.ControlLight, LinearGradientMode.Vertical);
            if (index == this.SelectedIndex)
                brush = (Brush)new SolidBrush(Color.LightGreen);
            graph.FillPath(brush, path);
            brush.Dispose();
        }

        private void PaintTabBorder(Graphics graph, int index, GraphicsPath path)
        {
            Pen pen = new Pen(SystemColors.ControlDark);
            if (index == this.SelectedIndex)
                pen = new Pen(ThemedColors.ToolBorder);
            graph.DrawPath(pen, path);
            pen.Dispose();
        }

        private void PaintTabText(Graphics graph, int index)
        {
            Rectangle tabRect = this.GetTabRect(index);
            string text = this.TabPages[index].Text;
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;
            Brush brush = this.TabPages[index].Enabled ? SystemBrushes.ControlText : SystemBrushes.ControlDark;
            Font font = this.Font;
            if (index == this.SelectedIndex)
                font = new Font(this.Font, FontStyle.Bold);
            graph.DrawString(text, font, brush, (RectangleF)tabRect, format);
        }

        private GraphicsPath GetPath(int index)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            Rectangle tabRect = this.GetTabRect(index);
            switch (this.DisplayStyle)
            {
                case TabEx.enumDisplwyStyle.Vstudio:
                    if (index == 0)
                    {
                        graphicsPath = new GraphicsPath(new Point[5]
                        {
              new Point(tabRect.Left, tabRect.Bottom),
              new Point(tabRect.Left + this.XieLong, tabRect.Top),
              new Point(tabRect.Right - 1, tabRect.Top),
              new Point(tabRect.Right - 1, tabRect.Bottom),
              new Point(tabRect.Left, tabRect.Bottom)
                        }, new byte[5]
                        {
              (byte) 0,
              (byte) 1,
              (byte) 1,
              (byte) 1,
              (byte) 1
                        });
                        break;
                    }
                    graphicsPath = new GraphicsPath(new Point[5]
                    {
            new Point(tabRect.Left - this.XieLong + this.xLongSub, tabRect.Bottom),
            new Point(tabRect.Left + this.xLongSub, tabRect.Top),
            new Point(tabRect.Right - 1, tabRect.Top),
            new Point(tabRect.Right - 1, tabRect.Bottom),
            new Point(tabRect.Left - this.XieLong + this.xLongSub, tabRect.Bottom)
                    }, new byte[5]
                    {
            (byte) 0,
            (byte) 1,
            (byte) 1,
            (byte) 1,
            (byte) 1
                    });
                    break;
                case TabEx.enumDisplwyStyle.Angled:
                    if (index == 0)
                    {
                        graphicsPath = new GraphicsPath(new Point[5]
                        {
              new Point(tabRect.Left, tabRect.Bottom),
              new Point(tabRect.Left + this.XieLong, tabRect.Top),
              new Point(tabRect.Right - 1 - this.xLongSub, tabRect.Top),
              new Point(tabRect.Right - 1 + this.XieLong - this.xLongSub, tabRect.Bottom),
              new Point(tabRect.Left, tabRect.Bottom)
                        }, new byte[5]
                        {
              (byte) 0,
              (byte) 1,
              (byte) 1,
              (byte) 1,
              (byte) 1
                        });
                        break;
                    }
                    graphicsPath = new GraphicsPath(new Point[6]
                    {
            new Point(tabRect.Left, tabRect.Top + this.yBegin),
            new Point(tabRect.Left + this.xLongSub, tabRect.Top),
            new Point(tabRect.Right - 1 - this.xLongSub, tabRect.Top),
            new Point(tabRect.Right - 1 + this.XieLong - this.xLongSub, tabRect.Bottom),
            new Point(tabRect.Left + this.XieLong - this.xLongSub, tabRect.Bottom),
            new Point(tabRect.Left, tabRect.Top + this.yBegin)
                    }, new byte[6]
                    {
            (byte) 0,
            (byte) 1,
            (byte) 1,
            (byte) 1,
            (byte) 1,
            (byte) 1
                    });
                    break;
            }
            return graphicsPath;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(
          IntPtr hWnd,
          int Msg,
          IntPtr wParam,
          IntPtr lParam);

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.OnFontChanged(EventArgs.Empty);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            SendMessage(this.Handle, 48, this.Font.ToHfont(), IntPtr.Zero);
            SendMessage(this.Handle, 29, IntPtr.Zero, IntPtr.Zero);
            this.UpdateStyles();
        }
        public enum enumDisplwyStyle
        {
            Vstudio,
            Angled,
        }
    }
}

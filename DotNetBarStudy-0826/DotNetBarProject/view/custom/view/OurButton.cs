using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    public partial class OurButton : Label
    {
        private bool isMouseIn;

        private bool isMouseDown;

        private bool withBorder = false;

        private bool roundCorner = false;

        private bool withArrow = false;

        private int intervalBetweenTextAndBorder = 2;

        private int intervalBetweenTextAndImage = 2;

        private bool enable = true;

        private Image disableimage = null;

        private Color colorMouseIn = Color.Transparent;

        private Color colorMouseDown = Color.Transparent;

        private bool haveCheckState = false;

        private bool exclusion = false;
        private Image image = null;

        private eTextPosition textPosition = eTextPosition.Bottom;
        /*
        public OurButton()
        {
            this.MouseMove += OurButton_MouseMove;
            this.MouseLeave += OurButton_MouseLeave; ;
        }

        private void OurButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void OurButton_MouseMove(object sender, MouseEventArgs e)
        {
            if(Enable)
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;
        }
        */

        [CategoryAttribute("文字位置"), Browsable(true), DisplayName("文字位置"), DescriptionAttribute("文字位置")]
        public eTextPosition TextPosition
        {
            get { return textPosition; }
            set
            {
                textPosition = value;
                this.Invalidate();
            }
        }

        [CategoryAttribute("绘制边框"), Browsable(true), DisplayName("绘制边框"), DescriptionAttribute("绘制边框")]
        public bool WithBorder
        {
            get { return withBorder; }
            set
            {
                withBorder = value;
                this.Invalidate();
            }
        }
        [CategoryAttribute("圆角"), Browsable(true), DisplayName("圆角"), DescriptionAttribute("圆角")]
        public bool RoundCorner
        {
            get { return roundCorner; }
            set
            {
                roundCorner = value;
                this.Invalidate();
            }
        }
        [CategoryAttribute("不使能图片"), Browsable(true), DisplayName("不使能图片"), DescriptionAttribute("不使能图片")]
        public Image DisableImage
        {
            get { return disableimage; }
            set
            {
                disableimage = value;
                this.Invalidate();
            }
        }
        [CategoryAttribute("使能"), Browsable(true), DisplayName("使能"), DescriptionAttribute("使能")]
        public bool Enable
        {
            get { return enable; }
            set
            {
                enable = value;
                this.Invalidate();
            }
        }

        [CategoryAttribute("带向下的剪头"), Browsable(true), DisplayName("带向下的剪头"), DescriptionAttribute("带向下的剪头")]
        public bool WithArrow
        {
            get { return withArrow; }
            set
            {
                withArrow = value;
                this.Invalidate();
            }
        }

        [CategoryAttribute("文字与图像之间的间隔"), Browsable(true), DisplayName("文字与图像之间的间隔"), DescriptionAttribute("文字与图像之间的间隔")]
        public int IntervalBetweenTextAndImage
        {
            get { return intervalBetweenTextAndImage; }
            set
            {
                intervalBetweenTextAndImage = value;
                this.Invalidate();
            }
        }

        [CategoryAttribute("文字与边框之间的间隔"), Browsable(true), DisplayName("文字与边框之间的间隔"), DescriptionAttribute("文字与边框之间的间隔")]
        public int IntervalBetweenTextAndBorder
        {
            get { return intervalBetweenTextAndBorder; }
            set
            {
                intervalBetweenTextAndBorder = value;
                this.Invalidate();
            }
        }

        [CategoryAttribute("鼠标悬停时的背景色"), Browsable(true), DisplayName("鼠标悬停时的背景色"), DescriptionAttribute("鼠标悬停时的背景色")]
        public Color ColorMouseIn
        {
            get { return colorMouseIn; }
            set { colorMouseIn = value; }
        }

        [CategoryAttribute("选中状态的背景色"), Browsable(true), DisplayName("选中状态的背景色"), DescriptionAttribute("选中状态的背景色")]
        public Color ColorMouseDown
        {
            get { return colorMouseDown; }
            set { colorMouseDown = value; }
        }

        [CategoryAttribute("是否有选中状态"), Browsable(true), DisplayName("是否有选中状态"), DescriptionAttribute("是否有选中状态")]
        public bool CheckState
        {
            get { return haveCheckState; }
            set { haveCheckState = value; }
        }

        [CategoryAttribute("同级别之间是否互斥"), Browsable(true), DisplayName("同级别之间是否互斥"), DescriptionAttribute("同级别之间是否互斥")]
        public bool Exclusion
        {
            get { return exclusion; }
            set { exclusion = value; }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (CheckState)
            {
                isMouseDown = true;
                if (exclusion)
                {
                    if (this.Parent != null)
                    {

                        int ctlCount = this.Parent.Controls.Count;
                        for (int i = 0; i < ctlCount; i++)
                        {
                            object o = this.Parent.Controls[i];
                            if (o.GetType() == this.GetType())
                            {
                                OurButton button = this.Parent.Controls[i] as OurButton;
                                if (button != null)
                                {
                                    if (button != this)
                                    {
                                        button.PopUp();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void PopUp()
        {
            this.isMouseDown = false;
            this.Invalidate();
        }

        public override bool AutoSize
        {
            get
            {
                return false;
            }
            set
            {
                base.AutoSize = value;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Enable)
            {
                image = Image;
            }
            else
            {
                image = DisableImage;
            }
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            float imagex = 0;
            float imagey = 0;
            float tx = 0; float ty = 0;
            float txtHeight = 0;
            float txtWidth = 0;

            #region 绘制背景

            if (isMouseIn || isMouseDown)
            {
                Color c = colorMouseIn;
                if (isMouseDown)
                {
                    c = colorMouseDown;
                }
                int arrowHeight = 7;
                if (!withArrow)
                    arrowHeight = 0;
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height - arrowHeight);
                Rectangle rect2 = new Rectangle(0, 0, this.Width - 1, this.Height - arrowHeight);

                GraphicsPath path1 = null;
                GraphicsPath path2 = null;
                if (roundCorner)
                {
                    if (withArrow)
                    {
                        path1 = GetRoundRectangleWithArrow(rect, 10);
                        path2 = GetRoundRectangleWithArrow(rect2, 10);
                    }
                    else
                    {
                        path1 = GetRoundRectangle(rect, 10);
                        path2 = GetRoundRectangle(rect2, 10);
                    }
                    g.FillPath(new SolidBrush(c), path1);
                    if (withBorder)
                        g.DrawPath(new Pen(Color.Silver, 2), path2);
                }
                else
                {
                    g.FillRectangle(new SolidBrush(c), rect);
                    g.DrawRectangle(new Pen(c, 2), rect2);
                }
            }

            #endregion

            #region 计算图片大小
            #endregion

            #region 绘制文本
            if (this.Text != string.Empty)
            {
                SizeF sizeoftext = g.MeasureString(this.Text, Font);
                txtHeight = (float)(sizeoftext.Height);
                txtWidth = (float)(sizeoftext.Width);
                switch (TextPosition)
                {
                    case eTextPosition.Top:
                        tx = (float)((this.Width - sizeoftext.Width) / 2.0);
                        ty = intervalBetweenTextAndBorder;
                        break;
                    case eTextPosition.Left:
                        ty = (float)((this.Height - sizeoftext.Height) / 2.0);
                        tx = intervalBetweenTextAndBorder;
                        break;
                    case eTextPosition.Right:
                        if (image == null)
                            tx = this.Width - sizeoftext.Width - intervalBetweenTextAndBorder;
                        else
                        {
                            tx = intervalBetweenTextAndBorder + image.Width + intervalBetweenTextAndImage;
                            image = resizeImage(image, new Size((int)(Width - txtWidth), Height));
                        }
                        ty = (float)((this.Height - sizeoftext.Height) / 2.0);
                        break;
                    case eTextPosition.Bottom:
                        if (image != null)
                        {
                            image = resizeImage(image, new Size(this.Width, (int)(Height - txtHeight)));
                            ty = intervalBetweenTextAndBorder + intervalBetweenTextAndImage + image.Height;
                        }
                        else
                            ty = IntervalBetweenTextAndBorder;
                        tx = (float)((this.Width - txtWidth) / 2.0);
                        break;
                }
                g.DrawString(this.Text, Font, new SolidBrush(ForeColor), tx, ty);

            }

            #endregion

            #region 绘制图片

            if (image != null)
            {
                switch (TextPosition)
                {
                    case eTextPosition.Top:
                        imagex = (float)((this.Width - image.Width) / 2.0);
                        imagey = ty + txtHeight + intervalBetweenTextAndImage;
                        break;
                    case eTextPosition.Left:
                        imagex = tx + txtWidth + intervalBetweenTextAndImage;
                        imagey = (float)((this.Height - image.Height) / 2.0);
                        break;
                    case eTextPosition.Right:
                        imagex = IntervalBetweenTextAndBorder;
                        imagey = (float)((this.Height - image.Height) / 2.0);
                        break;
                    case eTextPosition.Bottom:
                        imagey = intervalBetweenTextAndBorder;
                        imagex = (float)((this.Width - image.Width) / 2.0);
                        break;
                }



                g.DrawImage(image, imagex, imagey);
            }

            #endregion

        }
        private static Image resizeImage(Image imgToResize, Size size)
        {
            //获取图片宽度
            int sourceWidth = imgToResize.Width;
            //获取图片高度
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //计算宽度的缩放比例
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //计算高度的缩放比例
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //期望的宽度
            int destWidth = (int)(sourceWidth * nPercent);
            //期望的高度
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //绘制图像
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isMouseIn = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isMouseIn = false;
            this.Invalidate();
        }

        private GraphicsPath GetRoundRectangle(Rectangle rectangle, int r)
        {
            int l = 2 * r;
            // 把圆角矩形分成八段直线、弧的组合，依次加到路径中  
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(new Point(rectangle.X + r, rectangle.Y), new Point(rectangle.Right - r, rectangle.Y));
            gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Y, l, l), 270F, 90F);

            gp.AddLine(new Point(rectangle.Right, rectangle.Y + r), new Point(rectangle.Right, rectangle.Bottom - r));
            gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Bottom - l, l, l), 0F, 90F);

            gp.AddLine(new Point(rectangle.Right - r, rectangle.Bottom), new Point(rectangle.X + r, rectangle.Bottom));
            gp.AddArc(new Rectangle(rectangle.X, rectangle.Bottom - l, l, l), 90F, 90F);

            gp.AddLine(new Point(rectangle.X, rectangle.Bottom - r), new Point(rectangle.X, rectangle.Y + r));
            gp.AddArc(new Rectangle(rectangle.X, rectangle.Y, l, l), 180F, 90F);
            return gp;
        }

        private GraphicsPath GetRoundRectangleWithArrow(Rectangle rectangle, int r)
        {
            int l = 2 * r;
            // 把圆角矩形分成八段直线、弧的组合，依次加到路径中  
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(new Point(rectangle.X + r, rectangle.Y), new Point(rectangle.Right - r, rectangle.Y));
            gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Y, l, l), 270F, 90F);

            gp.AddLine(new Point(rectangle.Right, rectangle.Y + r), new Point(rectangle.Right, rectangle.Bottom - r));
            gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Bottom - l, l, l), 0F, 90F);


            int miniwidth = 5;
            int miniheight = 6;
            //这是下面的一条线，把它分成四份
            //            gp.AddLine(new Point(rectangle.Right - r, rectangle.Bottom), );
            //1
            gp.AddLine(new Point(rectangle.Right - r, rectangle.Bottom), new Point(rectangle.Width / 2 + miniwidth, rectangle.Bottom));
            //2
            gp.AddLine(new Point(rectangle.Width / 2 + miniwidth, rectangle.Bottom), new Point(rectangle.Width / 2, rectangle.Bottom + miniheight));
            //3
            gp.AddLine(new Point(rectangle.Width / 2, rectangle.Bottom + miniheight), new Point(rectangle.Width / 2 - miniwidth, rectangle.Bottom));

            //4
            gp.AddLine(new Point(rectangle.Width / 2 - miniwidth, rectangle.Bottom), new Point(rectangle.X + r, rectangle.Bottom));

            gp.AddArc(new Rectangle(rectangle.X, rectangle.Bottom - l, l, l), 90F, 90F);

            gp.AddLine(new Point(rectangle.X, rectangle.Bottom - r), new Point(rectangle.X, rectangle.Y + r));
            gp.AddArc(new Rectangle(rectangle.X, rectangle.Y, l, l), 180F, 90F);
            return gp;
        }

    }

    public enum eTextPosition
    {
        Top,
        Left,
        Right,
        Bottom,
    }

}
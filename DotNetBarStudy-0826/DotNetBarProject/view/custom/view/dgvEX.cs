using DevComponents.DotNetBar.Controls;
using DotNetBarProject.view.custom.data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    public partial class dgvEX : DataGridView
    {
        private DataGridView dgvHJ = (DataGridView)null;
        private bool _rownumshow = false;
        private DataGridViewTextBoxEditingControl cellTxt = (DataGridViewTextBoxEditingControl)null;
        private string PrintTitle = "";
        private Dictionary<string, bool> colVisiblePrnS = new Dictionary<string, bool>();
        private bool PageZ = true;
        private bool FitToPageWidth = false;
        private List<int> colLefts = new List<int>();
        private List<int> colWidths = new List<int>();
        private PrintDocument prnDoc;
        private int colSelSTotalWidth;
        private int RowPos;
        private int PageNo;
        private int PageSum;
        private bool NewPage;
        private StringFormat CellTxtFormat;
        private Button CellButton;
        private CheckBox CellCheckBox;
        private string Chetime = "";
        public dgvEX()
        {
            this.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvEX_EditingControlShowing);
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            foreach(DataGridViewColumn column in (BaseCollection)this.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            }
        }

        public void HeJi()
        {
            if (this.dgvHJ == null)
                this.SetSumGridStyle();
            this.dgvHJ.ColumnCount = this.ColumnCount;
            try
            {
                this.ColumnWidthChanged -= new DataGridViewColumnEventHandler(this.this_ColumnWidthChanged);
                for (int i = 0; i < this.ColumnCount; ++i)
                {
                    if (this.Columns[i].Visible)
                    {
                        this.dgvHJ.Columns[i].Visible = true;
                        this.dgvHJ.Columns[i].Frozen = this.Columns[i].Frozen;
                        this.dgvHJ.Columns[i].Width = this.Columns[i].Width;
                        this.dgvHJ.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        if (this.Columns[i].Tag != null && this.Columns[i].Tag.ToString() != "")
                        {
                            this.dgvHJ.Columns[i].HeaderText = this.RowCount == 0 ? (this.Columns[i].Tag.ToString().Contains("合计") ? "0" : this.Columns[i].Tag.ToString() + "0") : (this.Columns[i].Tag.ToString().Contains("合计") ? this.Columns[i].Tag.ToString()+this.ColSum(i).ToString(this.Columns[i].DefaultCellStyle.Format) : this.Columns[i].Tag.ToString() + this.RowCount.ToString());
                            this.dgvHJ.Columns[i].HeaderCell.Style.Alignment = this.Columns[i].Tag.ToString().Contains("合计") ? this.Columns[i].DefaultCellStyle.Alignment : DataGridViewContentAlignment.MiddleLeft;
                            this.dgvHJ.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                            if (this.dgvHJ.Columns[i].Width > this.Columns[i].Width)
                            {
                                int width = this.dgvHJ.Columns[i].Width;
                                this.dgvHJ.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                                this.Columns[i].Width = width;
                                this.dgvHJ.Columns[i].Width = width;
                            }
                            else
                                this.dgvHJ.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        }
                    }
                    else
                        this.dgvHJ.Columns[i].Visible = false;
                }
                this.ColumnWidthChanged += new DataGridViewColumnEventHandler(this.this_ColumnWidthChanged);
                this.resize_dgvHJ();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        private void SetSumGridStyle()
        {
            this.dgvHJ = new DataGridView();
            this.dgvHJ.AllowUserToAddRows = false;
            this.dgvHJ.AllowUserToResizeColumns = false;
            this.dgvHJ.BorderStyle = this.BorderStyle;
            this.dgvHJ.GridColor = this.GridColor;
            this.dgvHJ.ReadOnly = true;
            this.dgvHJ.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHJ.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgvHJ.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvHJ.ColumnHeadersDefaultCellStyle.BackColor = this.ColumnHeadersDefaultCellStyle.BackColor;
            this.dgvHJ.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkRed;
            this.dgvHJ.ColumnHeadersDefaultCellStyle.Font = this.ColumnHeadersDefaultCellStyle.Font;
            this.dgvHJ.ColumnHeadersHeight = this.RowTemplate.Height;
            this.dgvHJ.ColumnCount = this.ColumnCount;
            for (int index = 0; index < this.ColumnCount; ++index)
            {
                this.dgvHJ.Columns[index].MinimumWidth = this.Columns[index].MinimumWidth;
                this.dgvHJ.Columns[index].DividerWidth = this.Columns[index].DividerWidth;
            }
            this.dgvHJ.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvHJ.RowHeadersWidth = this.RowHeadersWidth;
            switch (this.ScrollBars)
            {
                case ScrollBars.None:
                    this.dgvHJ.ScrollBars = ScrollBars.None;
                    break;
                case ScrollBars.Horizontal:
                    this.ScrollBars = ScrollBars.None;
                    this.dgvHJ.ScrollBars = ScrollBars.Horizontal;
                    break;
                case ScrollBars.Vertical:
                    this.dgvHJ.ScrollBars = ScrollBars.None;
                    break;
                case ScrollBars.Both:
                    this.ScrollBars = ScrollBars.Vertical;
                    this.dgvHJ.ScrollBars = ScrollBars.Horizontal;
                    break;
            }
            if (this.dgvHJ.ScrollBars == ScrollBars.None)
            {
                this.dgvHJ.ColumnCount = this.ColumnCount;
                this.dgvHJ.Height = this.dgvHJ.ColumnHeadersHeight;
            }
            this.dgvHJ.Scroll += new ScrollEventHandler(this.dgvHJ_Scroll);
            this.Scroll += new ScrollEventHandler(this.this_Scroll);
            this.RowHeadersWidthChanged += new EventHandler(this.this_RowHeadersWidthChanged);
            this.ColumnWidthChanged += new DataGridViewColumnEventHandler(this.this_ColumnWidthChanged);
            this.Paint += new PaintEventHandler(this.this_Paint);
            this.Parent.Controls.Add((Control)this.dgvHJ);
            this.dgvHJ.Dock = DockStyle.Bottom;
        }

        public Decimal ColSum(int i)
        {
            Decimal num = new Decimal(0);
            if (this.Rows.Count == 0)
                return num;
            for (int index = 0; index < this.Rows.Count; ++index)
                num += Convert.ToDecimal(this.Rows[index].Cells[i].Value == null ? "0" : (this.Rows[index].Cells[i].FormattedValue.ToString() == "" ? "0" : this.Rows[index].Cells[i].FormattedValue.ToString()));
            return num;
        }

        private void resize_dgvHJ()
        {
            if (this.dgvHJ.ScrollBars == ScrollBars.Horizontal)
            {
                if (this.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + (this.RowHeadersVisible ? this.RowHeadersWidth + 1 : 0) + (this.VerticalScrollBar.Visible ? SystemInformation.VerticalScrollBarWidth + 1 : 0) > this.Width)
                {
                    this.dgvHJ.Height = this.dgvHJ.ColumnHeadersHeight + SystemInformation.HorizontalScrollBarHeight + 2;
                    if (this.VerticalScrollBar.Visible)
                    {
                        this.dgvHJ.ColumnCount = this.ColumnCount + 1;
                        this.dgvHJ.Columns[this.dgvHJ.ColumnCount - 1].Width = SystemInformation.VerticalScrollBarWidth;
                    }
                    else
                        this.dgvHJ.ColumnCount = this.ColumnCount;
                }
                else
                {
                    this.dgvHJ.Height = this.dgvHJ.ColumnHeadersHeight;
                    this.dgvHJ.ColumnCount = this.ColumnCount;
                }
            }
            this.dgvHJ.HorizontalScrollingOffset = this.HorizontalScrollingOffset;
        }

        private void dgvHJ_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation != ScrollOrientation.HorizontalScroll)
                return;
            this.DoubleBuffered = true;
            this.HorizontalScrollingOffset = e.NewValue;
            this.DoubleBuffered = false;
        }

        private void this_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation != ScrollOrientation.HorizontalScroll)
                return;
            this.dgvHJ.HorizontalScrollingOffset = e.NewValue;
        }

        private void this_RowHeadersWidthChanged(object sender, EventArgs e)
        {
            if (this.dgvHJ == null)
                return;
            this.dgvHJ.RowHeadersWidth = this.RowHeadersWidth;
            this.resize_dgvHJ();
        }

        private void this_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (this.dgvHJ == null)
                return;
            this.dgvHJ.Columns[e.Column.Index].Width = e.Column.Width;
            this.resize_dgvHJ();
        }

        private void this_Paint(object sender, PaintEventArgs e)
        {
            this.resize_dgvHJ();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.CurrentCell != null && keyData == Keys.F3)
            {
                Clipboard.SetText(this.CurrentCell.FormattedValue.ToString());
                return true;
            }
            if (keyData == Keys.Return && this.cellKeyUp != null)
                this.cellKeyUp((object)this, new KeyEventArgs(Keys.Return));
            if (keyData != Keys.Return)
                return base.ProcessCmdKey(ref msg, keyData);
            SendKeys.Send("{TAB}");
            return true;
        }

        public bool RowNumShow
        {
            get
            {
                return this._rownumshow;
            }
            set
            {
                this._rownumshow = value;
                if (!this._rownumshow)
                    return;
                this.RowPostPaint += new DataGridViewRowPostPaintEventHandler(this.this_RowPostPaint);
            }
        }

        private void this_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle bounds = new Rectangle();
            ref Rectangle local = ref bounds;
            Point location = e.RowBounds.Location;
            int x = location.X;
            location = e.RowBounds.Location;
            int y = location.Y;
            int width = this.RowHeadersWidth - 4;
            int height = e.RowBounds.Height;
            local = new Rectangle(x, y, width, height);
            TextRenderer.DrawText((IDeviceContext)e.Graphics, (e.RowIndex + 1).ToString(), this.RowHeadersDefaultCellStyle.Font, bounds, this.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
        }

        public event dgvEX.cellKeyUpEventHandler cellKeyUp;

        private void dgvEX_EditingControlShowing(
          object sender,
          DataGridViewEditingControlShowingEventArgs e)
        {
            this.cellTxt = (DataGridViewTextBoxEditingControl)e.Control;
            this.cellTxt.KeyUp -= new KeyEventHandler(this.cellTxt_KeyUp);
            this.cellTxt.KeyUp += new KeyEventHandler(this.cellTxt_KeyUp);
        }

        private void cellTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.cellKeyUp == null)
                return;
            this.cellKeyUp((object)this, e);
        }

        public void Print(string strTile, String chatime)
        {
            try
            {
                if (this.RowCount == 0)
                    return;
                this.Chetime = chatime;
                this.prnDoc = new PrintDocument();
                List<string> stringList = new List<string>();
                foreach (DataGridViewColumn column in (BaseCollection)this.Columns)
                {
                    if (column.Visible)
                        stringList.Add(column.Name);
                }
                bool flag = false;
                if (stringList.Count != this.colVisiblePrnS.Count)
                {
                    flag = true;
                }
                else
                {
                    for (int index = 0; index < stringList.Count; ++index)
                    {
                        if (!this.colVisiblePrnS.ContainsKey(stringList[index]))
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                stringList.Clear();
                if (flag)
                {
                    this.colVisiblePrnS.Clear();
                    foreach (DataGridViewColumn column in (BaseCollection)this.Columns)
                    {
                        if (column.Visible)
                            this.colVisiblePrnS.Add(column.Name, true);
                    }
                }
                dgvEXprnOptions dgvExprnOptions = new dgvEXprnOptions((DataGridView)this, ref this.colVisiblePrnS, this.PageZ, this.FitToPageWidth);
                if (dgvExprnOptions.ShowDialog() != DialogResult.OK)
                    return;
                this.PageZ = dgvExprnOptions.PaperZ;
                this.FitToPageWidth = dgvExprnOptions.FitToPageWidth;
                this.PrintTitle = strTile;
                this.colSelSTotalWidth = 0;
                foreach (DataGridViewColumn column in (BaseCollection)this.Columns)
                {
                    if (column.Visible && this.colVisiblePrnS[column.Name])
                        this.colSelSTotalWidth += column.Width;
                }
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = this.prnDoc;
                printPreviewDialog.WindowState = FormWindowState.Maximized;
                printPreviewDialog.PrintPreviewControl.Zoom = 1.0;
                this.prnDoc.DefaultPageSettings.Margins.Top = 100;
                this.prnDoc.DefaultPageSettings.Margins.Left = 20;
                this.prnDoc.DefaultPageSettings.Margins.Right = 30;
                this.prnDoc.DefaultPageSettings.Margins.Bottom = 40;
                this.prnDoc.DefaultPageSettings.Landscape = !this.PageZ;
                this.prnDoc.BeginPrint += new PrintEventHandler(this.PrintDoc_BeginPrint);
                this.prnDoc.PrintPage += new PrintPageEventHandler(this.PrintDoc_PrintPage);
                this.prnDoc.EndPrint += new PrintEventHandler(this.prnDoc_EndPrint);
                if (printPreviewDialog.ShowDialog() == DialogResult.OK)
                    this.prnDoc.Print();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                if (this.prnDoc != null)
                {
                    this.prnDoc.BeginPrint -= new PrintEventHandler(this.PrintDoc_BeginPrint);
                    this.prnDoc.PrintPage -= new PrintPageEventHandler(this.PrintDoc_PrintPage);
                    this.prnDoc.Dispose();
                }
                if (this.CellTxtFormat != null)
                    this.CellTxtFormat.Dispose();
                if (this.CellButton != null)
                    this.CellButton.Dispose();
                if (this.CellCheckBox != null)
                    this.CellCheckBox.Dispose();
                this.colLefts.Clear();
                this.colWidths.Clear();
            }
        }

        private void PrintDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                this.CellTxtFormat = new StringFormat();
                this.CellButton = new Button();
                this.CellCheckBox = new CheckBox();
                this.RowPos = 0;
                this.PageNo = 1;
                this.NewPage = true;
                this.colLefts.Clear();
                this.colWidths.Clear();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int y1 = e.MarginBounds.Top;
            int left1 = e.MarginBounds.Left;
            try
            {
                if (this.PageNo == 1)
                {
                    foreach (DataGridViewColumn column in (BaseCollection)this.Columns)
                    {
                        if (column.Visible && this.colVisiblePrnS[column.Name])
                        {
                            int num = !this.FitToPageWidth ? column.Width : (int)Math.Floor((double)column.Width / (double)this.colSelSTotalWidth * (double)this.colSelSTotalWidth * ((double)e.MarginBounds.Width / (double)this.colSelSTotalWidth));
                            this.colLefts.Add(left1);
                            this.colWidths.Add(num);
                            left1 += num;
                        }
                    }
                    int num1 = e.MarginBounds.Height / this.RowTemplate.Height;
                    this.PageSum = this.dgvHJ == null ? (int)Math.Ceiling((Decimal)this.RowCount / (Decimal)num1) : (int)Math.Ceiling(((Decimal)this.RowCount + new Decimal(10, 0, 0, false, (byte)1)) / (Decimal)num1);
                }
                if (this.NewPage)
                {
                    Font font1 = new Font("黑体", 16f, FontStyle.Underline);
                    Font font2 = new Font("宋体", 9f);
                    int num1 = y1 - this.ColumnHeadersHeight - font2.Height - font1.Height;
                    this.CellTxtFormat.Alignment = StringAlignment.Center;
                    e.Graphics.DrawString(this.PrintTitle, font1, Brushes.Black, new RectangleF((float)e.MarginBounds.Left, (float)num1, (float)e.MarginBounds.Width, (float)font1.Height), this.CellTxtFormat);
                    int num2 = num1 + font1.Height;
                    this.CellTxtFormat.Alignment = StringAlignment.Far;
                    e.Graphics.DrawString(DateTime.Now.ToString("yyyy-MM-dd dddd HH:mm"), font2, Brushes.Black, new RectangleF((float)e.MarginBounds.Left, (float)num2, (float)(e.MarginBounds.Width - 30), (float)font2.Height), this.CellTxtFormat);

                    this.CellTxtFormat.Alignment = StringAlignment.Near;
                    e.Graphics.DrawString(Chetime, font2, Brushes.Black, new RectangleF((float)e.MarginBounds.Left, (float)num2, (float)(e.MarginBounds.Width), (float)font2.Height), this.CellTxtFormat);
                    int y2 = num2 + font2.Height;
                    font1.Dispose();
                    font2.Dispose();
                    this.CellTxtFormat.Alignment = StringAlignment.Center;
                    this.CellTxtFormat.LineAlignment = StringAlignment.Center;
                    int index = 0;
                    foreach (DataGridViewColumn column in (BaseCollection)this.Columns)
                    {
                        if (column.Visible && this.colVisiblePrnS[column.Name])
                        {
                            e.Graphics.FillRectangle((Brush)new SolidBrush(Color.LightGray), new Rectangle(this.colLefts[index], y2, this.colWidths[index], this.ColumnHeadersHeight));
                            e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), new Rectangle(this.colLefts[index], y2, this.colWidths[index], this.ColumnHeadersHeight));
                            e.Graphics.DrawString(column.HeaderText, new Font(column.InheritedStyle.Font, FontStyle.Bold), Brushes.Black, new RectangleF((float)this.colLefts[index], (float)y2, (float)this.colWidths[index], (float)this.ColumnHeadersHeight), this.CellTxtFormat);
                            ++index;
                        }
                    }
                    this.NewPage = false;
                    y1 = y2 + this.ColumnHeadersHeight;
                }
                while (this.RowPos <= this.Rows.Count - 1)
                {
                    DataGridViewRow row = this.Rows[this.RowPos];
                    if (row.IsNewRow)
                    {
                        ++this.RowPos;
                    }
                    else
                    {
                        if (y1 + row.Height > e.MarginBounds.Height + e.MarginBounds.Top)
                        {
                            this.DrawFooter(e);
                            this.NewPage = true;
                            ++this.PageNo;
                            e.HasMorePages = true;
                            return;
                        }
                        int index = 0;
                        foreach (DataGridViewCell cell in (BaseCollection)row.Cells)
                        {
                            if (cell.OwningColumn.Visible && this.colVisiblePrnS[cell.OwningColumn.Name])
                            {
                                e.Graphics.FillRectangle((Brush)new SolidBrush(row.DefaultCellStyle.BackColor), new Rectangle(this.colLefts[index], y1, this.colWidths[index], row.Height));
                                if (cell.OwningColumn.GetType() == typeof(DataGridViewTextBoxColumn) || cell.OwningColumn.GetType() == typeof(DataGridViewLinkColumn) || cell.OwningColumn.GetType() == typeof(DataGridViewComboBoxColumn))
                                {
                                    if (cell.InheritedStyle.Alignment.ToString().Contains("Center"))
                                        this.CellTxtFormat.Alignment = StringAlignment.Center;
                                    else if (cell.InheritedStyle.Alignment.ToString().Contains("Left"))
                                        this.CellTxtFormat.Alignment = StringAlignment.Near;
                                    else if (cell.InheritedStyle.Alignment.ToString().Contains("Right"))
                                        this.CellTxtFormat.Alignment = StringAlignment.Far;
                                    if (cell.InheritedStyle.Alignment.ToString().Contains("Top"))
                                        this.CellTxtFormat.LineAlignment = StringAlignment.Near;
                                    else if (cell.InheritedStyle.Alignment.ToString().Contains("Middle"))
                                        this.CellTxtFormat.LineAlignment = StringAlignment.Center;
                                    else if (cell.InheritedStyle.Alignment.ToString().Contains("Bottom"))
                                        this.CellTxtFormat.LineAlignment = StringAlignment.Far;
                                    Graphics graphics = e.Graphics;
                                    string s = cell.FormattedValue.ToString();
                                    Font font = cell.InheritedStyle.Font;
                                    SolidBrush solidBrush = new SolidBrush(cell.InheritedStyle.ForeColor);
                                    int colLeft = this.colLefts[index];
                                    Padding padding = cell.InheritedStyle.Padding;
                                    int left2 = padding.Left;
                                    double num1 = (double)(colLeft + left2);
                                    double num2 = (double)y1;
                                    padding = cell.InheritedStyle.Padding;
                                    double top1 = (double)padding.Top;
                                    double num3 = num2 + top1;
                                    int colWidth = this.colWidths[index];
                                    padding = cell.InheritedStyle.Padding;
                                    int left3 = padding.Left;
                                    int num4 = colWidth - left3;
                                    padding = cell.InheritedStyle.Padding;
                                    int right = padding.Right;
                                    double num5 = (double)(num4 - right);
                                    double height = (double)row.Height;
                                    padding = cell.InheritedStyle.Padding;
                                    double top2 = (double)padding.Top;
                                    double num6 = height - top2;
                                    padding = cell.InheritedStyle.Padding;
                                    double bottom = (double)padding.Bottom;
                                    double num7 = num6 - bottom;
                                    RectangleF layoutRectangle = new RectangleF((float)num1, (float)num3, (float)num5, (float)num7);
                                    StringFormat cellTxtFormat = this.CellTxtFormat;
                                    graphics.DrawString(s, font, (Brush)solidBrush, layoutRectangle, cellTxtFormat);
                                }
                                else if (cell.OwningColumn.GetType() == typeof(DataGridViewButtonColumn))
                                {
                                    this.CellButton.Text = cell.Value.ToString();
                                    this.CellButton.Size = new Size(this.colWidths[index], row.Height);
                                    Bitmap bitmap = new Bitmap(this.CellButton.Width, this.CellButton.Height);
                                    this.CellButton.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                                    e.Graphics.DrawImage((Image)bitmap, new Point(this.colLefts[index], y1));
                                }
                                else if (cell.OwningColumn.GetType() == typeof(DataGridViewCheckBoxColumn))
                                {
                                    this.CellCheckBox.Size = new Size(14, 14);
                                    this.CellCheckBox.Checked = (bool)cell.Value;
                                    Bitmap bitmap = new Bitmap(this.colWidths[index], row.Height);
                                    Graphics.FromImage((Image)bitmap).FillRectangle(Brushes.White, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                                    this.CellCheckBox.DrawToBitmap(bitmap, new Rectangle((bitmap.Width - this.CellCheckBox.Width) / 2, (bitmap.Height - this.CellCheckBox.Height) / 2, this.CellCheckBox.Width, this.CellCheckBox.Height));
                                    e.Graphics.DrawImage((Image)bitmap, new Point(this.colLefts[index], y1));
                                }
                                else if (cell.OwningColumn.GetType() == typeof(DataGridViewImageColumn))
                                {
                                    Rectangle rectangle = new Rectangle(this.colLefts[index], y1, this.colWidths[index], row.Height);
                                    Size size = ((Image)cell.FormattedValue).Size;
                                    e.Graphics.DrawImage((Image)cell.FormattedValue, new Rectangle(this.colLefts[index] + (rectangle.Width - size.Width) / 2, y1 + (rectangle.Height - size.Height) / 2, ((Image)cell.FormattedValue).Width, ((Image)cell.FormattedValue).Height));
                                }
                                e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), new Rectangle(this.colLefts[index], y1, this.colWidths[index], row.Height));
                                ++index;
                            }
                        }
                        y1 += row.Height;
                        ++this.RowPos;
                    }
                }
                if (this.dgvHJ != null)
                {
                    int num1 = y1 + this.RowTemplate.Height;
                    Rectangle marginBounds = e.MarginBounds;
                    int height = marginBounds.Height;
                    marginBounds = e.MarginBounds;
                    int top = marginBounds.Top;
                    int num2 = height + top;
                    if (num1 > num2)
                    {
                        this.DrawFooter(e);
                        this.NewPage = true;
                        ++this.PageNo;
                        e.HasMorePages = true;
                        return;
                    }
                    int index = 0;
                    foreach (DataGridViewColumn column in (BaseCollection)this.dgvHJ.Columns)
                    {
                        if (column.Index < this.ColumnCount)
                        {
                            if (column.Visible && this.colVisiblePrnS[this.Columns[column.Index].Name])
                            {
                                e.Graphics.FillRectangle((Brush)new SolidBrush(Color.LightGray), new Rectangle(this.colLefts[index], y1, this.colWidths[index], this.dgvHJ.ColumnHeadersHeight));
                                e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), new Rectangle(this.colLefts[index], y1, this.colWidths[index], this.dgvHJ.ColumnHeadersHeight));
                                if (column.HeaderCell.InheritedStyle.Alignment.ToString().Contains("Center"))
                                    this.CellTxtFormat.Alignment = StringAlignment.Center;
                                else if (column.HeaderCell.InheritedStyle.Alignment.ToString().Contains("Left"))
                                    this.CellTxtFormat.Alignment = StringAlignment.Near;
                                else if (column.HeaderCell.InheritedStyle.Alignment.ToString().Contains("Right"))
                                    this.CellTxtFormat.Alignment = StringAlignment.Far;
                                e.Graphics.DrawString(column.HeaderText, new Font(column.InheritedStyle.Font, FontStyle.Bold), Brushes.Black, new RectangleF((float)this.colLefts[index], (float)y1, (float)this.colWidths[index], (float)this.dgvHJ.ColumnHeadersHeight), this.CellTxtFormat);
                                ++index;
                            }
                        }
                        else
                            break;
                    }
                }
                this.DrawFooter(e);
                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void DrawFooter(PrintPageEventArgs e)
        {
            Font font1 = new Font("宋体", 9f);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            Graphics graphics = e.Graphics;
            string s = " 第 " + this.PageNo.ToString() + " 页，共 " + this.PageSum.ToString() + " 页 ";
            Font font2 = font1;
            Brush black = Brushes.Black;
            Rectangle marginBounds = e.MarginBounds;
            double left = (double)marginBounds.Left;
            marginBounds = e.MarginBounds;
            double bottom = (double)marginBounds.Bottom;
            marginBounds = e.MarginBounds;
            double width = (double)marginBounds.Width;
            double height = (double)font1.Height;
            RectangleF layoutRectangle = new RectangleF((float)left, (float)bottom, (float)width, (float)height);
            StringFormat format = stringFormat;
            graphics.DrawString(s, font2, black, layoutRectangle, format);
            font1.Dispose();
            stringFormat.Dispose();
        }

        private void prnDoc_EndPrint(object sender, PrintEventArgs e)
        {
            if (this.CellTxtFormat != null)
                this.CellTxtFormat.Dispose();
            if (this.CellButton != null)
                this.CellButton.Dispose();
            if (this.CellCheckBox == null)
                return;
            this.CellCheckBox.Dispose();
        }

        public void saveExcel(string sheetName)
        {
            if (this.Rows.Count == 0)
                return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "输出 Excel 文件,保存到:";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            string fileName = saveFileDialog.FileName;
            saveFileDialog.Dispose();
            try
            {
                FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                HSSFWorkbook hssfWorkbook = new HSSFWorkbook();
                ISheet sheet = hssfWorkbook.CreateSheet(sheetName);
                IRow row = sheet.CreateRow(0);
                int index1 = 0;
                int column1 = 0;
                for (; index1 < this.Columns.Count; ++index1)
                {
                    if (this.Columns[index1].Visible)
                    {
                        sheet.GetRow(0).CreateCell(column1).SetCellValue(this.Columns[index1].HeaderText.ToString());
                        ++column1;
                    }
                }
                for (int index2 = 0; index2 < this.RowCount; ++index2)
                {
                    row = sheet.CreateRow(index2 + 1);
                    int index3 = 0;
                    int column2 = 0;
                    for (; index3 < this.ColumnCount; ++index3)
                    {
                        if (this.Columns[index3].Visible)
                        {
                            sheet.GetRow(index2 + 1).CreateCell(column2).SetCellValue(this[index3, index2].FormattedValue.ToString());
                            ++column2;
                        }
                    }
                }
                if (this.dgvHJ != null)
                {
                    row = sheet.CreateRow(this.RowCount + 1);
                    int index2 = 0;
                    int column2 = 0;
                    for (; index2 < this.ColumnCount; ++index2)
                    {
                        if (this.Columns[index2].Visible)
                        {
                            sheet.GetRow(this.RowCount + 1).CreateCell(column2).SetCellValue(this.dgvHJ.Columns[index2].HeaderText.ToString());
                            ++column2;
                        }
                    }
                }
                hssfWorkbook.Write((Stream)fileStream);
                fileStream.Close();
                sheet.Dispose();
                hssfWorkbook.Dispose();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        public delegate void cellKeyUpEventHandler(object sender, KeyEventArgs e);
    }
}

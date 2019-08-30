// Decompiled with JetBrains decompiler
// Type: PeiFang.MyControl.coboDGV
// Assembly: PeiFang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7CE058C5-4088-427D-B35A-892338B88431
// Assembly location: D:\install\聊天工具\qq\file\1679867915\FileRecv\新建文件夹\印染配方管理\PeiFang.exe

using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    public partial class DGV : ComboBox
    {
        private BindingSource bsDGV = new BindingSource();
        private string schKey = "";
        private string selCol = "";
        private bool dropVisible = false;
        private bool dropAutoSize = false;
        private int dropDGVselIndex = -1;
        private string _SeparatorChar = " ";
        private string coboTxtStr = "";
        private bool _allowInput = false;
        private long _rowSN = -1;
        private DataGridViewRow _poprow = (DataGridViewRow)null;
        private const int WM_LBUTTONDOWN = 513;
        private const int WM_LBUTTONDBLCLK = 515;
        private ToolStripControlHost dropDGVhost;
        private ToolStripControlHost dropTxtSCHhost;
        private ToolStripDropDown dropDown;

        private DataGridView dropDGV
        {
            get
            {
                return this.dropDGVhost.Control as DataGridView;
            }
        }

        private TextBox dropTxtSch
        {
            get
            {
                return this.dropTxtSCHhost.Control as TextBox;
            }
        }

        public string SeparatorChar
        {
            set
            {
                this._SeparatorChar = value;
            }
            get
            {
                return this._SeparatorChar;
            }
        }

        public bool allowInput
        {
            set
            {
                this._allowInput = value;
            }
            get
            {
                return this._allowInput;
            }
        }

        public long rowSN
        {
            get
            {
                return this._rowSN;
            }
            set
            {
                this._rowSN = value;
            }
        }

        public DataGridViewRow poprow
        {
            get
            {
                return this._poprow;
            }
        }

        public event EventHandler AfterSelector;

        public DGV()
        {
            this.DrawDropDown();
            this.TextUpdate += new EventHandler(this.this_TextUpdate);
            this.dropTxtSch.MouseWheel += new MouseEventHandler(this.dropTxtSch_MouseWheel);
        }

        private void DrawDropDown()
        {
            DataGridView dataGridView = new DataGridView()
            {
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                BackgroundColor = SystemColors.ActiveCaptionText,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                RowTemplate = {
          Height = 25
        },
                ColumnHeadersHeight = 28,
                DefaultCellStyle = {
          Font = new Font("宋体", 9f),
          WrapMode = DataGridViewTriState.True
        }
            };
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.CellMouseUp += new DataGridViewCellMouseEventHandler(this.dgvList_CellMouseUp);
            dataGridView.KeyDown += new KeyEventHandler(this.dgvList_KeyDown);
            TextBox textBox = new TextBox();
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.TextChanged += new EventHandler(this.txtSch_TextChanged);
            Form form = new Form();
            form.Controls.Add((Control)dataGridView);
            form.SuspendLayout();
            this.dropDGVhost = new ToolStripControlHost((Control)dataGridView);
            this.dropDGVhost.AutoSize = this.dropAutoSize;
            this.dropTxtSCHhost = new ToolStripControlHost((Control)textBox);
            this.dropTxtSCHhost.AutoSize = false;
            this.dropDown = new ToolStripDropDown();
            this.dropDown.Width = this.Width;
            this.dropDown.Items.Add((ToolStripItem)this.dropTxtSCHhost);
            this.dropDown.Items.Add((ToolStripItem)this.dropDGVhost);
        }

        private void PopupSel(EventArgs e)
        {
            if (this.dropDGV.SelectedRows.Count <= 0)
                return;
            DataGridViewRow currentRow = this.dropDGV.CurrentRow;
            this.dropDGVselIndex = this.dropDGV.CurrentRow.Index;
            if (this.selCol != string.Empty)
            {
                this.Text = "";
                string selCol = this.selCol;
                char[] chArray = new char[1] { ',' };
                foreach (string columnName in selCol.Split(chArray))
                {
                    if (this.dropDGV.Columns.Contains(columnName))
                    {
                        DGV coboDgv = this;
                        coboDgv.Text = coboDgv.Text + currentRow.Cells[columnName].FormattedValue.ToString() + this._SeparatorChar;
                    }
                }
                this.Text = this.Text.Substring(0, this.Text.Length - this._SeparatorChar.Length);
                this._poprow = currentRow;
                this._rowSN = Convert.ToInt64(currentRow.Cells[selCol].Value);
            }
            else
            {
                int num = (int)MessageBox.Show("没有选定列弹出!");
            }
            if (this.AfterSelector != null)
                this.AfterSelector((object)this, e);
            this.dropDown.Visible = false;
            this.dropVisible = false;
            this.Focus();
            this.coboTxtStr = this.Text;
        }

        public void ShowDropDown()
        {
            if (this.dropDown == null || this.bsDGV.DataSource == null)
                return;
            this.bsDGV.RemoveFilter();
            this.dropTxtSch.Text = "";
            this.dropDGVhost.AutoSize = this.dropAutoSize;
            this.dropDGVhost.Size = new Size(this.DropDownWidth - 2, this.DropDownHeight);
            this.dropDown.Show((Control)this, 0, this.Height);
            if (this.PointToScreen(new Point(0, 0)).Y > this.dropDown.Top)
                this.dropDown.Show((Control)this, 0, -this.dropDown.Height);
            //if (this.dropTxtSch.Visible)
                //this.dropTxtSch.Focus();
        }

        private string GetSouceFilter(string sText)
        {
            string str1 = "";
            if (this.bsDGV == null)
                return (string)null;
            if (this.selCol == string.Empty || this.selCol == null)
                this.selCol = this.dropDGV.Columns[0].Name;
            if (this.schKey == string.Empty)
                this.schKey = this.selCol;
            string schKey = this.schKey;
            char[] chArray = new char[1] { ',' };
            foreach (string str2 in schKey.Split(chArray))
                str1 = str1 + str2 + " like '%" + sText + "%' or ";
            return str1.Trim().TrimEnd("or".ToCharArray());
        }

        private void dgvList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Return)
                return;
            this.PopupSel((EventArgs)e);
        }

        private void dgvList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || (e.RowIndex == -1 || this.dropDGV.CurrentRow == null || this.dropDGV.CurrentRow.Index != e.RowIndex))
                return;
            this.PopupSel((EventArgs)e);
            this.Focus();
        }

        private void txtSch_TextChanged(object sender, EventArgs e)
        {
            this.bsDGV.Filter = this.GetSouceFilter(this.dropTxtSch.Text);
        }

        private void this_TextUpdate(object sender, EventArgs e)
        {
            if (this.Text == "")
            {
                this.coboTxtStr = "";
                this._rowSN = -1L;
                this._poprow = (DataGridViewRow)null;
                if (this.AfterSelector == null)
                    return;
                this.AfterSelector((object)this, e);
            }
            else if (!this._allowInput)
            {
                this.Text = this.coboTxtStr;
            }
            else
            {
                this.coboTxtStr = this.Text;
                this._rowSN = -1L;
                this._poprow = (DataGridViewRow)null;
            }
        }

        private void dropTxtSch_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                if (this.dropDGV.FirstDisplayedScrollingRowIndex >= this.dropDGV.RowCount)
                    return;
                ++this.dropDGV.FirstDisplayedScrollingRowIndex;
            }
            else if (this.dropDGV.FirstDisplayedScrollingRowIndex > 0)
                --this.dropDGV.FirstDisplayedScrollingRowIndex;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyData != Keys.Down)
                return;
            this.ShowDropDown();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 515 || m.Msg == 513)
            {
                this.dropVisible = !this.dropVisible;
                if (this.dropVisible)
                    this.ShowDropDown();
                else
                    this.dropDown.Close();
            }
            else
                base.WndProc(ref m);
        }

        SqlSugarClient db = null;


        public void RefListNo(List<int> list, List<char> list2, DataTable dt)
        {
            dropDGV.BackgroundColor = SystemColors.Window;
            dropDGV.DataSource = bsDGV;
            bsDGV.DataSource = dt;
            int num = 0;
            for (int i = 0; i < dropDGV.ColumnCount; i++)
            {
                dropDGV.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dropDGV.Columns[i].Width = list[i];
                dropDGV.Columns[i].DefaultCellStyle.Alignment = ((list2[i] == 'L') ? DataGridViewContentAlignment.MiddleLeft : ((list2[i] == 'M') ? DataGridViewContentAlignment.MiddleCenter : DataGridViewContentAlignment.BottomRight));
                num += list[i];
            }
            dropTxtSCHhost.Width = num;
            DropDownWidth = num + SystemInformation.VerticalScrollBarWidth;//+8;
            DropDownHeight = this.dropDGV.RowTemplate.Height * 8;// + this.dropDGV.ColumnHeadersHeight;
        }

        public void RefList(DGV.leibie LB)
        {

            this.dropDGV.BackgroundColor = SystemColors.Window;
            List<int> list = new List<int>();
            List<char> list2 = new List<char>();
            DataTable dt = new DataTable();
            try
            {
                db = SqlBase.GetInstance();
                if (db == null) return;
                switch (LB)
                {
                    case DGV.leibie.客户:
                        var getAll = db.Queryable<T_Base>().Where(it => it.leibie == "客户").ToList();
                        list = new List<int>
                                    {
                                        50,
                                        100,
                                        150
                                    };
                        list2 = new List<char>
                                    {
                                        'M',
                                        'L',
                                        'L'
                                    };
                        selCol = "客户";
                        schKey = "编号,客户,全称";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("客户");
                        dt.Columns.Add("全称");
                        foreach (T_Base baseKH1 in getAll)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.itemName, baseKH1.item0);
                        }
                        break;
                    case DGV.leibie.品名:
                        selCol = "品名";
                        schKey = "编号,品名";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("品名");
                        var baseList = db.Queryable<T_Base>().Where(it => it.leibie == "纱种").ToList();
                        list = new List<int>
                        {
                            50,
                            200
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L'
                        };
                        foreach (T_Base baseKH1 in baseList)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.itemName);
                        }
                        break;
                    case DGV.leibie.颜色:
                        selCol = "颜色";
                        schKey = "编号,颜色";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("颜色");
                        var baseList_ys = db.Queryable<T_Base>().Where(it => it.leibie == "颜色").ToList();
                        list = new List<int>
                        {
                            50,
                            200
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L'
                        };
                        foreach (T_Base baseKH1 in baseList_ys)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.itemName);
                        }
                        break;
                    case DGV.leibie.色号:
                        selCol = "色号";
                        schKey = "编号,色号";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("色号");
                        var baseList_sh = db.Queryable<BaseIList>().Where(it => it.leibie == "色号").ToList();
                        list = new List<int>
                        {
                            50,
                            200
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L'
                        };
                        foreach (BaseIList baseKH1 in baseList_sh)
                        {
                            dt.Rows.Add(baseKH1.SN, baseKH1.item3);
                        }
                        break;
                    case DGV.leibie.流程:
                        selCol = "加工流程";
                        schKey = "加工流程";
                        dt.Columns.Add("加工流程");
                        var baseList_lc = db.Queryable<BaseList>()
                            .Where(it => it.leibie == "流程")
                            .GroupBy(it => it.itemkey)
                            .Select(it => it.itemkey)
                            .ToList();
                        list = new List<int>
                        {
                            100
                        };
                        list2 = new List<char>
                        {
                            'M',
                        };
                        foreach (var baseKH1 in baseList_lc)
                        {
                            dt.Rows.Add(baseKH1);
                        }
                        break;
                    case DGV.leibie.染料:
                        selCol = "染料";
                        schKey = "编号,染料,全称,类别";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("染料");
                        dt.Columns.Add("全称");
                        dt.Columns.Add("类别");
                        var baseList_ran = db.Queryable<T_Base>().Where(it => it.leibie == "染料").ToList();
                        list = new List<int>
                        {
                           50, 100, 120, 50
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L',
                            'L',
                            'M'
                        };
                        foreach (T_Base baseKH1 in baseList_ran)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.itemName, baseKH1.item0, baseKH1.leibie);
                        }
                        break;
                    case DGV.leibie.仓位:
                        selCol = "仓区";
                        schKey = "编号,仓区";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("仓区"); ;
                        var baseList_cangwei = db.Queryable<T_Base>().Where(it => it.leibie == "仓位").ToList();
                        list = new List<int>
                        {
                           50, 100
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L',
                        };
                        foreach (T_Base baseKH1 in baseList_cangwei)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.itemName);
                        }
                        break;
                    case DGV.leibie.员工:
                        selCol = "员工";
                        schKey = "编号,员工";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("员工"); ;
                        var baseList_yuangong = db.Queryable<T_Base>().Where(it => it.leibie == "员工").ToList();
                        list = new List<int>
                        {
                           50, 100
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L',
                        };
                        foreach (T_Base baseKH1 in baseList_yuangong)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.itemName);
                        }
                        break;
                    case DGV.leibie.染化类别:
                        selCol = "类别";
                        schKey = "编号,类别";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("类别"); ;
                        var baseList_leibie = db.Queryable<T_Base>().Where(it => it.leibie == "染化类别").ToList();
                        list = new List<int>
                        {
                           50, 100
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L',
                        };
                        foreach (T_Base baseKH1 in baseList_leibie)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.itemName);
                        }
                        break;
                    case DGV.leibie.生产工序:
                        selCol = "工序";
                        schKey = "编号,工序";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("工序"); ;
                        var baseList_gx = db.Queryable<T_Base>().Where(it => it.leibie == "生产工序").ToList();
                        list = new List<int>
                        {
                           50, 100
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L',
                        };
                        foreach (T_Base baseKH1 in baseList_gx)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.itemName);
                        }
                        break;
                }


                dropDGV.DataSource = bsDGV;
                bsDGV.DataSource = dt;
                int num = 0;
                for (int i = 0; i < dropDGV.ColumnCount; i++)
                {
                    dropDGV.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //dropDGV.Columns[i].Width = list[i];
                    dropDGV.Columns[i].DefaultCellStyle.Alignment = ((list2[i] == 'L') ? DataGridViewContentAlignment.MiddleLeft : ((list2[i] == 'M') ? DataGridViewContentAlignment.MiddleCenter : DataGridViewContentAlignment.BottomRight));
                    num += list[i];
                }
                dropTxtSCHhost.Width = num;
                DropDownWidth = num + SystemInformation.VerticalScrollBarWidth;//+8;
                DropDownHeight = this.dropDGV.RowTemplate.Height * 8;// + this.dropDGV.ColumnHeadersHeight;


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message + "\r\n\r\n   coboDGV刷新出错!" + LB.ToString(), "提示");
            }
        }


        public void EmptyText()
        {
            this.Text = "";
            this._rowSN = -1L;
        }

        public void SetText(string txtVal)
        {
            this.Text = txtVal;
            this._rowSN = -1L;
        }
        public enum leibie
        {
            客户,
            品名,
            颜色,
            色号,
            纱种,
            机号,
            染料,
            流程,
            代号,
            员工,
            仓位,
            染化类别,
            生产工序
        }
    }
}

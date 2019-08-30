using DevComponents.DotNetBar.Controls;
using DotNetBarProject.Properties;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    public partial class coboDGV : ComboBoxEx
    {

        public delegate void DoubleList(string asd);
        public DoubleList doublelist = null;

        public enum leibie
        {
            客户,
            客户简称,
            客户全称,
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
            色号类别,
            染化类别,
            生产工序,
            业务员,
            染料名称,
            染化料名称,
            产量登记,
            胚客代号,
            助剂,
        }
        private bool _allowInput = false;
        private const int WM_LBUTTONDOWN = 513;

        private const int WM_LBUTTONDBLCLK = 515;

        private ToolStripControlHost dropDGVhost;

        private ToolStripControlHost dropTxtSCHhost;

        public ToolStripDropDown dropDown;

        private BindingSource bsDGV = new BindingSource();

        private string schKey = "";

        private string selCol = "";

        private bool dropVisible = false;

        private bool dropAutoSize = false;

        private int dropDGVselIndex = -1;

        private string coboTxtStr = "";

        private string _SeparatorChar = "|";
        private object _tag = "";

        private bool m_TextFromList = true;

        public event EventHandler AfterSelector;

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
        private DataGridView dropDGV
        {
            get
            {
                return dropDGVhost.Control as DataGridView;
            }
        }

        public TextBox dropTxtSch
        {
            get
            {
                return dropTxtSCHhost.Control as TextBox;
            }
        }
        public string SeparatorChar
        {
            get
            {
                return _SeparatorChar;
            }
            set
            {
                _SeparatorChar = value;
            }
        }

        public bool TextFromList
        {
            get
            {
                return this.m_TextFromList;
            }
            set
            {
                this.m_TextFromList = value;
            }
        }

        public coboDGV()
        {
            DrawDropDown();
            TextUpdate += new EventHandler(this.this_TextUpdate);
        }

        private void DrawDropDown()
        {
            DataGridView dataGridView = new DataGridView();
            dataGridView.BackgroundColor = SystemColors.Window;
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.BackgroundColor = SystemColors.ActiveCaptionText;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.ColumnHeadersHeight = 28;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.CellMouseUp += new DataGridViewCellMouseEventHandler(this.dgvList_CellMouseUp);
            dataGridView.KeyDown += new KeyEventHandler(this.dgvList_KeyDown);
            TextBox textBox = new TextBox();
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.TextChanged += new EventHandler(this.txtSch_TextChanged);
            new Form
            {
                Controls =
                {
                    dataGridView
                }
            }.SuspendLayout();
            this.dropDGVhost = new ToolStripControlHost(dataGridView);
            this.dropDGVhost.AutoSize = this.dropAutoSize;
            this.dropTxtSCHhost = new ToolStripControlHost(textBox);
            this.dropTxtSCHhost.AutoSize = false;
            this.dropDown = new ToolStripDropDown();
            this.dropDown.Width = base.Width;
            this.dropDown.Items.Add(this.dropTxtSCHhost);
            this.dropDown.Items.Add(this.dropDGVhost);
            
        }

        private void PopupSel(EventArgs e)
        {
            if (dropDGV.SelectedRows.Count > 0)
            {
                DataGridViewRow currentRow = this.dropDGV.CurrentRow;
                dropDGVselIndex = this.dropDGV.CurrentRow.Index;
                if (this.selCol != string.Empty)
                {
                    this.Text = "";
                    string[] array = this.selCol.Split(new char[]
                    {
                        ','
                    });
                    string[] array2 = array;
                    for (int i = 0; i < array2.Length; i++)
                    {
                        string columnName = array2[i];
                        if (this.dropDGV.Columns.Contains(columnName))
                        {
                            this.Text = this.Text + currentRow.Cells[columnName].FormattedValue.ToString() + this._SeparatorChar;
                        }
                    }
                    this.Text = this.Text.Substring(0, this.Text.Length - this._SeparatorChar.Length);
                }
                if (AfterSelector != null)
                {
                    AfterSelector(this, e);
                }
                dropDown.Visible = false;
                dropVisible = false;
                //Focus();
                coboTxtStr = Text;
                if (doublelist != null)
                {
                    doublelist(currentRow.Cells[0].FormattedValue.ToString());
                }
            }
        }

        public void ShowDropDown()
        {
            //this.Focus();
            if (this.dropDown != null)
            {
                if (this.bsDGV.DataSource != null)
                {
                    this.bsDGV.RemoveFilter();
                    //this.dropTxtSch.Text = "";
                    this.dropDGVhost.AutoSize = this.dropAutoSize;
                    this.dropDGVhost.Size = new Size(base.DropDownWidth - 2, base.DropDownHeight);
                    this.dropDown.Show(this, 0, base.Height);
                    if (base.PointToScreen(new Point(0, 0)).Y > this.dropDown.Top)
                    {
                        dropDown.Show(this, 0, -this.dropDown.Height);
                    }
                    dropTxtSch.Visible = false;
                    if (dropTxtSch.Visible)
                    {
                        this.dropTxtSch.Focus();
                    }
                    //dropTxtSch.Select(this.dropTxtSch.TextLength, 0);
                    //bsDGV.Filter = GetSouceFilter(Text);
                    //dropDGV.Refresh();
                }
            }
        }

        private string GetSouceFilter(string sText)
        {
            string text = "";
            string result;
            if (bsDGV == null)
            {
                result = null;
            }
            else
            {
                if (this.selCol == string.Empty || this.selCol == null)
                {
                    this.selCol = this.dropDGV.Columns[0].Name;
                }
                if (this.schKey == string.Empty)
                {
                    this.schKey = this.selCol;
                }
                string[] array = this.schKey.Split(new char[]
                {
                    ','
                });
                string[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    string text2 = array2[i];
                    string text3 = text;
                    text = string.Concat(new string[]
                    {
                        text3,
                        text2,
                        " like '%",
                        sText,
                        "%' or "
                    });
                }
                text = text.Trim().TrimEnd("or".ToCharArray());
                result = text;
            }
            return result;
        }

        private void dgvList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                this.PopupSel(e);
            }
        }

        private void dgvList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.RowIndex != -1 && this.dropDGV.CurrentRow != null)
                {
                    if (this.dropDGV.CurrentRow.Index == e.RowIndex)
                    {
                        this.PopupSel(e);
                        //base.Focus();
                    }
                }
            }
        }

        private void txtSch_TextChanged(object sender, EventArgs e)
        {
            bsDGV.Filter = GetSouceFilter(dropTxtSch.Text);
            dropDGV.Refresh();
        }

        private void this_TextUpdate(object sender, EventArgs e)
        {
            if (this.Text.Equals(string.Empty))
            {
                this.coboTxtStr = "";
                if (this.AfterSelector != null)
                {
                    this.AfterSelector(this, e);
                }
            }
            else if (this.m_TextFromList)
            {
                this.Text = this.coboTxtStr;
            }

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyData == Keys.Down)
            {
                this.ShowDropDown();
            }
        }

        protected override void WndProc(ref Message m)
        {
            Console.WriteLine(m.Msg);
            if (m.Msg == 515 || m.Msg == 513)
            {
                if (this.dropVisible)
                {
                    this.dropVisible = false;
                }
                else
                {
                    this.dropVisible = true;
                }
                if (this.dropVisible)
                {
                    this.ShowDropDown();
                }
                else
                {
                    this.dropDown.Close();
                }
            }
            else
            {
                base.WndProc(ref m);
            }
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

        public void RefList(coboDGV.leibie LB)
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
                    case coboDGV.leibie.客户:
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
                    case coboDGV.leibie.客户简称:
                        var getAll1 = db.Queryable<T_Base>().Where(it => it.leibie == "客户").ToList();
                        list = new List<int>
                                    {
                                        50,
                                        100,
                                    };
                        list2 = new List<char>
                                    {
                                        'M',
                                        'L',
                                    };
                        selCol = "客户";
                        schKey = "编号,客户";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("客户");
                        foreach (T_Base baseKH1 in getAll1)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.itemName);
                        }
                        break;
                    case coboDGV.leibie.客户全称:
                        var getAll2 = db.Queryable<T_Base>().Where(it => it.leibie == "客户").ToList();
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
                        selCol = "全称";
                        schKey = "编号,全称";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("全称");
                        foreach (T_Base baseKH1 in getAll2)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.item0);
                        }
                        break;
                    case coboDGV.leibie.品名:
                        selCol = "品名";
                        schKey = "编号,品名";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("品名");
                        var baseList = db.Queryable<T_Base>().Where(it=>it.leibie== "纱种").ToList();
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
                    case coboDGV.leibie.颜色:
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
                    case coboDGV.leibie.色号:
                        selCol = "色号";
                        schKey = "编号,色号";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("色号");
                        var baseList_sh = db.Queryable<BaseIList>().Where(it => it.leibie == "色号").ToList();
                        list = new List<int>
                        {
                            100,
                            200
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L'
                        };
                        foreach (BaseIList baseKH1 in baseList_sh)
                        {
                            dt.Rows.Add(baseKH1.menfu, baseKH1.item3);
                        }
                        break;
                    case coboDGV.leibie.色号类别:
                        selCol = "色号类别";
                        schKey = "编号,色号类别";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("色号类别");
                        var baseList_shlb = db.Queryable<T_Base>().Where(it => it.leibie == "色号类别").ToList();
                        list = new List<int>
                        {
                            100,
                            200
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L'
                        };
                        foreach (T_Base baseKH1 in baseList_shlb)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.itemName);
                        }
                        break;
                    case coboDGV.leibie.机号:
                        selCol = "机号";
                        schKey = "机号,水量";
                        dt.Columns.Add("机号");
                        dt.Columns.Add("水量");
                        var baseList_jh = db.Queryable<T_Base>().Where(it => it.leibie == "机台浴量").ToList();
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
                        foreach (T_Base baseKH1 in baseList_jh)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.itemName);
                        }
                        break;
                    case coboDGV.leibie.流程:
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
                    case coboDGV.leibie.染料:
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
                    case coboDGV.leibie.仓位:
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
                    case coboDGV.leibie.员工:
                        selCol = "员工";
                        schKey = "编号,员工";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("员工"); ;
                        var baseList_yuangong = db.Queryable<T_Base>().Where(it => it.leibie == "员工").ToList();
                        list = new List<int>
                        {
                           100, 100
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
                    case coboDGV.leibie.业务员:
                        selCol = "业务员";
                        schKey = "业务员";
                        dt.Columns.Add("业务员"); ;
                        var baseList_ywy = db.Queryable<T_Base>()
                            .Where(it => it.leibie == "客户")
                            .GroupBy(it => new { it.item5 })
                            .Select(it => new { it.item5 })
                            .ToList();
                        list = new List<int>
                        {
                           200
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L',
                        };
                        foreach (var baseKH1 in baseList_ywy)
                        {

                            dt.Rows.Add(baseKH1.item5);
                        }
                        break;
                    case coboDGV.leibie.染化类别:
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
                    case coboDGV.leibie.生产工序:
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
                    case coboDGV.leibie.染料名称:
                        selCol = "工序";
                        schKey = "编号,工序";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("工序"); ;
                        var baseList_rlmc = db.Queryable<T_Base>().Where(it => it.leibie == "染料名称").ToList();
                        list = new List<int>
                        {
                           50, 100
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L',
                        };
                        foreach (T_Base baseKH1 in baseList_rlmc)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.itemName);
                        }
                        break;
                    case coboDGV.leibie.染化料名称:
                        selCol = "染化料名称";
                        schKey = "编号,染化料名称, 染化料类别";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("染化料名称");
                        dt.Columns.Add("染化料类别"); ;
                        var baseList_rhlmc = db.Queryable<T_Base>().Where(it => it.leibie == "染料名称" || it.leibie == "助剂名称").ToList();
                        list = new List<int>
                        {
                           50, 100, 100
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L',
                            'L',
                        };
                        foreach (T_Base baseKH1 in baseList_rhlmc)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.item0, baseKH1.leibie);
                        }
                        break;
                    case coboDGV.leibie.助剂:
                        selCol = "染化料名称";
                        schKey = "编号,染化料名称, 染化料类别";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("染化料名称");
                        dt.Columns.Add("染化料类别"); ;
                        var baseList_zhuji = db.Queryable<T_Base>().Where(it => it.leibie == "助剂名称").ToList();
                        list = new List<int>
                        {
                           50, 100, 100
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L',
                            'L',
                        };
                        foreach (T_Base baseKH1 in baseList_zhuji)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.item0, baseKH1.leibie);
                        }
                        break;
                    case coboDGV.leibie.胚客代号:
                        selCol = "胚客代号";
                        schKey = "编号,客户, 胚客代号";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("客户");
                        dt.Columns.Add("胚客代号"); ;
                        var baseList_pkdh = db.Queryable<T_Base>().Where(it => it.leibie == "胚客代号").ToList();
                        list = new List<int>
                        {
                           50, 100, 100
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L',
                            'L',
                        };
                        foreach (T_Base baseKH1 in baseList_pkdh)
                        {
                            dt.Rows.Add(baseKH1.bianhao, baseKH1.item0, baseKH1.itemName);
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
        }

        public void SetText(string txtVal)
        {
            this.Text = txtVal;
        }
    }
}

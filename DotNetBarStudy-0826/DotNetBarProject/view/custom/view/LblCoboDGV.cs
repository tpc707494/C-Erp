using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.view
{
    public partial class LblCoboDGV : UserControl
    {
        private BindingSource bsDGV = new BindingSource();
        string selCol = "";
        private string schKey = "";
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
        private int _jiange = 5;

        private bool _allowInput = true;

        public int jiange
        {
            get
            {
                return this._jiange;
            }
            set
            {
                this._jiange = value;
                this.thisResize();
            }
        }

        public Font lblFont
        {
            get
            {
                return this.lbl.Font;
            }
            set
            {
                this.lbl.Font = value;
                this.thisResize();
            }
        }

        public string lblText
        {
            get
            {
                return this.lbl.Text;
            }
            set
            {
                this.lbl.Text = value;
                this.thisResize();
            }
        }

        public Font cobodgvFont
        {
            get
            {
                return this.cobodgv.Font;
            }
            set
            {
                this.cobodgv.Font = value;
                this.thisResize();
            }
        }

        public bool allowInput
        {
            get
            {
                return this._allowInput;
            }
            set
            {
                this._allowInput = value;
                //this.gridLookUpEdit1.TextFromList = !this._allowInput;
            }
        }

        

        

        public LblCoboDGV()
        {
            this.InitializeComponent();
            base.Size = new Size(this.lbl.Width + this._jiange + this.cobodgv.Width, this.cobodgv.Height);
            
        }

        private void this_Load(object sender, EventArgs e)
        {
            //this.cobodgv.Validating += new CancelEventHandler(this.cobodgv_Validating);
            this.thisResize();
        }

        private void thisResize()
        {
            base.Resize -= new EventHandler(this.this_Resize);
            this.lbl.Left = 0;
            this.lbl.Top = (this.cobodgv.Height - this.lbl.Height) / 2;
            this.cobodgv.Left = this.lbl.Width + this._jiange;
            this.cobodgv.Top = 0;
            this.cobodgv.Width = base.Width - this.lbl.Width - this._jiange;
            base.Resize += new EventHandler(this.this_Resize);
        }

        private void this_Resize(object sender, EventArgs e)
        {
            this.thisResize();
        }

        private void cobodgv_Validating(object sender, CancelEventArgs e)
        {
            if (this.allowInput)
            {
                this.cobodgv.txtbox.Text = this.cobodgv.Text.Trim();
            }
        }

        SqlSugarClient db = null;

        public void RefList(coboDGV.leibie LB)
        {

            //this.dropDGV.BackgroundColor = SystemColors.Window;
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
                                        100,
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
                    
                    case coboDGV.leibie.品名:
                        selCol = "品名";
                        schKey = "编号,品名";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("品名");
                        var baseList = db.Queryable<T_Base>().Where(it => it.leibie == "纱种").ToList();
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
                            100,
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
                        schKey = "编号,色号,客户,色名,品名,色号类别";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("色号");
                        dt.Columns.Add("客户"); 
                        dt.Columns.Add("色名");
                        dt.Columns.Add("品名");
                        dt.Columns.Add("色号类别");
                        var baseList_sh = db.Queryable<BaseIList>().Where(it => it.leibie == "色号").ToList();
                        list = new List<int>
                        {
                            60,100, 60, 80
                        };
                        list2 = new List<char>
                        {
                            'M',
                            'L',
                            'L',
                            'L',
                            'L',
                            'L'
                        };
                        foreach (BaseIList baseKH1 in baseList_sh)
                        {
                            dt.Rows.Add(baseKH1.menfu,  baseKH1.item3, baseKH1.item2, baseKH1.seming,  baseKH1.item1, baseKH1.item0);
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
                           100, 100, 120, 50
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
                           100, 100
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
                    case coboDGV.leibie.业务员:
                        selCol = "业务员";
                        schKey = "业务员";
                        dt.Columns.Add("业务员"); ;
                        var baseList_ywy = db.Queryable<T_Base>()
                            .Where(it => it.leibie == "客户")
                            .GroupBy(it=> new {it.item5 })
                            .Select(it=>new {it.item5})
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

                    case coboDGV.leibie.染化类别:
                        selCol = "类别";
                        schKey = "编号,类别";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("类别"); ;
                        var baseList_leibie = db.Queryable<T_Base>().Where(it => it.leibie == "染化类别").ToList();
                        list = new List<int>
                        {
                           100, 100
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
                    case coboDGV.leibie.机号:
                        selCol = "机号";
                        schKey = "机号,水量";
                        dt.Columns.Add("机号");
                        dt.Columns.Add("水量");
                        var baseList_jh = db.Queryable<T_Base>().Where(it => it.leibie == "机台浴量").ToList();
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
                        foreach (T_Base baseKH1 in baseList_jh)
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
                           100, 100
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
                    case coboDGV.leibie.胚客代号:
                        selCol = "胚客代号";
                        schKey = "编号,客户,胚客代号";
                        dt.Columns.Add("编号");
                        dt.Columns.Add("客户");
                        dt.Columns.Add("胚客代号"); ;
                        var baseList_pkdh = db.Queryable<T_Base>().Where(it => it.leibie == "胚客代号").ToList();
                        list = new List<int>
                        {
                           60, 100, 150
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
                        int index1 = Array.IndexOf(schKey.Split(",".ToCharArray()), selCol);
                        break;
                }
                //this.cobodgv.Properties.AutoComplete = true;
                //cobodgv.Properties.DisplayMember = selCol;
                //cobodgv.Properties.DataSource = bsDGV;
                cobodgv.ColumnWidth = list;
                cobodgv.ShowHeader = true;
                cobodgv.GridLines = (GridLines)3;
                cobodgv.AllFiled = schKey;
                
                int index = Array.IndexOf(schKey.Split(",".ToCharArray()), selCol);
                cobodgv.DisplayColumnNo = index;
                cobodgv.DataSource = dt;
                //bsDGV.DataSource = dt;
                int num = 0;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    //dropDGV.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //dropDGV.Columns[i].Width = list[i];
                    //dropDGV.Columns[i].DefaultCellStyle.Alignment = ((list2[i] == 'L') ? DataGridViewContentAlignment.MiddleLeft : ((list2[i] == 'M') ? DataGridViewContentAlignment.MiddleCenter : DataGridViewContentAlignment.BottomRight));
                    //num += list[i];
                }
                //dropTxtSCHhost.Width = num;
                //DropDownWidth = num + SystemInformation.VerticalScrollBarWidth;//+8;
                //DropDownHeight = this.dropDGV.RowTemplate.Height * 8;// + this.dropDGV.ColumnHeadersHeight;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message + "\r\n\r\n   coboDGV刷新出错!" + LB.ToString(), "提示");
            }
        }
    }
}

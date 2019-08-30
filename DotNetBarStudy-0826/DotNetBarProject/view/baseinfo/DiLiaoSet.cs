using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using DotNetBarProject.view.custom.view;
using SqlSugar;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.baseinfo
{
    public partial class DiLiaoSet : Office2007Form
    {

        string sql_dljh_item = leibie.enumLB.滴料机号.ToString();
        string sql_dlt_item = leibie.enumLB.滴料头.ToString();
        private coboDGV cellRL;
        private SqlSugarClient db;
        public DiLiaoSet()
        {
            InitializeComponent();
            MaximizeBox = false;
            TopLevel = false;
            Location = new Point(0, 0);
            db = SqlBase.GetInstance();
            Tag = "管理";
            dgvEX1Init();
            this.lblCoboEX1.coboEX1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.lblCoboEX1.coboEX1.SelectedIndexChanged += new EventHandler(this.txtJH_SelectedIndexChanged);
            setQX();
            cellRL.RefList(coboDGV.leibie.助剂);
        }
        private void setQX()
        {
            if (!Tag.ToString().Contains("管理"))
            {
                this.btnSave.Visible = false;
            }
            else
            {
                this.New_CellControl();
                this.dgvEX1.CurrentCellChanged += new EventHandler(this.dgvDT_CurrentCellChanged);
                this.dgvEX1.Scroll += new ScrollEventHandler(this.dgvDT_Scroll);
                this.dgvEX1.ColumnWidthChanged += new DataGridViewColumnEventHandler(this.dgvDT_ColumnWidthChanged);
            }
        }
        private void dgvDT_CurrentCellChanged(object sender, EventArgs e)
        {
            this.Hide_CellControl();
            if (this.dgvEX1.CurrentCell == null)
                return;
            Rectangle displayRectangle = this.dgvEX1.GetCellDisplayRectangle(this.dgvEX1.CurrentCell.ColumnIndex, this.dgvEX1.CurrentCell.RowIndex, false);
            string txtVal = this.dgvEX1.CurrentCell.Value == null ? "" : this.dgvEX1.CurrentCell.Value.ToString();
            Control control = (Control)null;
            switch (this.dgvEX1.Columns[dgvEX1.CurrentCell.ColumnIndex].Name)
            {
                case "colRL":
                    cellRL.SetText(txtVal);
                    control = cellRL;
                    break;
            }
            if (control == null)
                return;
            control.Left = displayRectangle.Left;
            control.Top = displayRectangle.Top;
            control.Width = displayRectangle.Width;
            control.Height = displayRectangle.Height;
            control.Visible = true;
            control.Focus();
        }
        private void dgvDT_Scroll(object sender, ScrollEventArgs e)
        {
            this.Hide_CellControl();
        }
        private void dgvDT_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.Hide_CellControl();
        }
        private void New_CellControl()
        {
            this.cellRL = new coboDGV();
            this.cellRL.allowInput = false;
            dgvEX1.Controls.Add((Control)this.cellRL);
            this.Hide_CellControl();
            this.cellRL.AfterSelector += new EventHandler(this.cellRL_AfterSelector);
        }

        private void Hide_CellControl()
        {
            this.cellRL.Visible = false;
        }

        private void cellRL_AfterSelector(object sender, EventArgs e)
        {
            dgvEX1.CurrentCell.Value = (object)this.cellRL.Text;
        }
        private void dgvEX1Init()
        {
            if (db == null) return;
            var getAll = db.Queryable<T_Base>()
                        .Where(it => it.leibie == sql_dljh_item)
                        .Select(it => new { it.SN, it.bianhao, it.itemName, it.item0 })
                        .ToList();
            lblCoboEX1.coboEX1.Items.Clear();
            for (var index = 0; index < getAll.Count; ++index)
                lblCoboEX1.coboEX1.Items.Add(getAll[index].bianhao);
            lblCoboEX1.coboEX1.SelectedIndex = 0;
        }
        private void txtJH_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setVal();
        }
        private void setVal()
        {
            if (db == null) return;
            lblTxt1.txt.Text = "";
            checkBox1.Checked = false;
            dgvEX1.Rows.Clear();
            if (lblCoboEX1.coboEX1.SelectedIndex < 0)
                return;
            try
            {
                var getAll = db.Queryable<T_Base>()
                        .Where(it => it.leibie == sql_dljh_item && it.bianhao == lblCoboEX1.coboEX1.Text)
                        .Select(it => new { it.SN, it.bianhao, it.itemName, it.item0 })
                        .ToList();
                var getAll1 = db.Queryable<T_Base>()
                        .Where(it => it.leibie == sql_dlt_item && it.bianhao == lblCoboEX1.coboEX1.Text)
                        .Select(it => new { it.SN, it.bianhao, it.itemName, it.item0, it.item1 })
                        .ToList();
                if (getAll.Count > 0)
                {
                    lblTxt1.txt.Text = getAll[0].itemName;
                    checkBox1.Checked = getAll[0].item0 == "允许半自动" ? true : false;
                }
                if (getAll1.Count > 0)
                {
                    string index1 = "0";
                    for (var i = 0; i < getAll1.Count; i++)
                    {
                        var dataRowCollection = getAll1[i];
                        int index = dgvEX1.Rows.Add();
                        dgvEX1.Rows[index].Cells[0].Value = dataRowCollection.itemName;
                        index1 = dataRowCollection.itemName;
                        dgvEX1.Rows[index].Cells[1].Value =  (object)dataRowCollection.item0;
                    }
                    if (getAll1.Count < 18)
                    {
                        for(int i=1;i<18- getAll1.Count+1; i++)
                        {
                            int index = dgvEX1.Rows.Add();
                            dgvEX1.Rows[index].Cells[0].Value = Convert.ToInt32(index1)+i;
                            dgvEX1.Rows[index].Cells[1].Value = "";
                        }
                    }

                }
            }
            catch(Exception e)
            {
                MessageBox.Show("数据库链接异常,请检查"+e.Message);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblTxt1.txt.Text == "")
            {
                int num1 = (int)MessageBox.Show((IWin32Window)this, "请输入机器名称!!!", "提示");
            }
            else
            {
                var all = db.Queryable<T_Base>()
                    .Where(it => it.leibie == sql_dljh_item && it.bianhao == this.lblCoboEX1.coboEX1.Text)
                    .ToList();
                try
                {

                    if (all.Count > 0)
                    {
                        var sad = all[0];
                        sad.itemName = lblTxt1.txt.Text;
                        sad.item0 = checkBox1.Checked ? "允许半自动" : "不允许半自动";
                        int a = db.Updateable<T_Base>(sad).ExecuteCommand();
                    }
                    db.Deleteable<T_Base>().Where(it => it.leibie == sql_dlt_item && it.bianhao == this.lblCoboEX1.coboEX1.Text).ExecuteCommand();
                    for (int index = 0; index < dgvEX1.RowCount; ++index)
                        db.Insertable(new T_Base()
                        {
                            leibie = sql_dlt_item,
                            bianhao = this.lblCoboEX1.coboEX1.Text,
                            itemName = (index + 1).ToString("00"),
                            item0 = dgvEX1.Rows[index].Cells[this.colRL.Name].FormattedValue.ToString(),
                            item1 = "",
                            item2 = "",
                            item3 = "",
                            item4 = "",
                            item5 = "",
                            item6 = "",
                            item7 = "",
                            item8 = "",
                            item9 = "",
                            beizhu = ""
                        }).ExecuteCommand();
                    setVal();
                    int num2 = (int)MessageBox.Show((IWin32Window)this, "基本信息保存成功!!!", "提示");
                }
                catch(Exception ex)
                {
                    int num2 = (int)MessageBox.Show(this, ex.Message, "提示");
                }
            }
        }
    }
}

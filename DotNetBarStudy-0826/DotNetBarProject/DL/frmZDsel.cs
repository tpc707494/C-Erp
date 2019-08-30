using DotNetBarProject.Properties;
using DotNetBarProject.view.custom.data;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetBarProject.DL
{
    public partial class frmZDsel : Form
    {
        private Keys cancelKey;
        private SqlSugarClient db;
        public frmZDsel(string _lblCancel, Keys _cancelKey)
        {
            this.InitializeComponent();
            this.lblCancel.Text = _lblCancel;
            this.cancelKey = _cancelKey;
            this.KeyUp += new KeyEventHandler(this.this_KeyUp);
            this.txtZL.LostFocus += new EventHandler(this.txtZL_LostFocus);
            this.dgvRL.CurrentCellChanged += new EventHandler(this.dgvRL_CurrentCellChanged);
            db = SqlBase.GetInstance();
        }

        private void this_Load(object sender, EventArgs e)
        {
        }

        private void this_Shown(object sender, EventArgs e)
        {
            this.dgvRL.Rows.Add(((IEnumerable<int>)UserProc.DLparaDT).Sum());
            this.showDT();
            this.dgvRL.CurrentCell = this.dgvRL.Rows[0].Cells[0];
            this.dgvRL_CurrentCellChanged((object)null, (EventArgs)null);
            this.txtZL.Focus();
        }

        private void this_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void showDT()
        {
            //using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DBconn))
            {
                //sqlConnection.Open();
                //SqlCommand command = sqlConnection.CreateCommand();
                //command.CommandTimeout = 300;
                string CommandText = "select * from T_Base where leibie = '滴料头' and bianhao = '" + Settings.Default.DLjihao + "' order by itemName";
                //SqlDataReader sqlDataReader = command.ExecuteReader();
                DataTable dataTable = db.Ado.GetDataTable(CommandText);
                //dataTable.Load((IDataReader)sqlDataReader);
                for (int index = 0; index < ((IEnumerable<int>)UserProc.DLparaDT).Sum(); ++index)
                {
                    this.dgvRL.Rows[index].Cells[this.colDT.Name].Value = (object)(index + 1).ToString();
                    if (index < dataTable.Rows.Count && (int)Convert.ToInt16(dataTable.Rows[index].Field<string>("itemName")) == index + 1)
                        this.dgvRL.Rows[index].Cells[this.colRL.Name].Value = (object)dataTable.Rows[index].Field<string>("item0");
                    else
                        this.dgvRL.Rows[index].Cells[this.colRL.Name].Value = (object)"";
                }
                //sqlDataReader.Close();
                //sqlDataReader.Dispose();
                //command.Dispose();
                dataTable.Dispose();
            }
        }

        private void txtZL_LostFocus(object sender, EventArgs e)
        {
            this.txtZL.Focus();
            this.txtZL.Select(this.txtZL.Text.Length, 0);
            this.txtZL.ScrollToCaret();
        }

        private void dgvRL_CurrentCellChanged(object sender, EventArgs e)
        {
            string str = this.dgvRL.CurrentRow.Cells[this.colDT.Name].FormattedValue.ToString();
            if (str != "" && UserProc.IsInt(str))
            {
                int num1 = -1;
                int num2 = 0;
                int num3 = (int)Convert.ToInt16(this.dgvRL.CurrentRow.Cells[this.colDT.Name].Value) - 1;
                for (int index = 0; index < UserProc.DLparaDT.Length; ++index)
                {
                    num2 += UserProc.DLparaDT[index];
                    if (num3 < num2)
                    {
                        num1 = index;
                        break;
                    }
                }
                this.lblCheng.Text = num1 >= 0 ? (num1 + 1).ToString() : "";
                this.lblDT.Text = str;
            }
            else
            {
                this.lblCheng.Text = "";
                this.lblDT.Text = "";
            }
            this.lblRL.Text = this.dgvRL.CurrentRow.Cells[this.colRL.Name].FormattedValue.ToString();
        }

        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Prior)
            {
                int rowIndex = this.dgvRL.CurrentCell.RowIndex;
                if (rowIndex <= 0)
                    return;
                this.dgvRL.CurrentCell = this.dgvRL.Rows[rowIndex - 1].Cells[0];
            }
            else if (e.KeyCode == Keys.Next)
            {
                int rowIndex = this.dgvRL.CurrentCell.RowIndex;
                if (rowIndex >= this.dgvRL.RowCount - 1)
                    return;
                this.dgvRL.CurrentCell = this.dgvRL.Rows[rowIndex + 1].Cells[0];
            }
            else if (e.KeyCode == this.cancelKey)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                if (e.KeyCode != Keys.Return)
                    return;
                if (this.lblCheng.Text == "" || this.lblDT.Text == "")
                {
                    frmError frmError = new frmError("请选择正确滴头!!!");
                    int num = (int)frmError.ShowDialog((IWin32Window)this);
                    frmError.Close();
                    this.txtZL.Focus();
                }
                else if (this.txtZL.Text == "" || !UserProc.IsNumeric(this.txtZL.Text) || Convert.ToDecimal(this.txtZL.Text) <= new Decimal(0))
                {
                    frmError frmError = new frmError("请输入正确重量( >=0 )!!!");
                    int num = (int)frmError.ShowDialog((IWin32Window)this);
                    frmError.Close();
                    this.txtZL.Focus();
                }
                else
                    this.DialogResult = DialogResult.OK;
            }
        }
    }
}

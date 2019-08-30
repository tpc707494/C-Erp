using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using SqlSugar;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.baseinfo
{
    public partial class ShenChanLc : Office2007Form
    {
        private SqlSugarClient db;
        public ShenChanLc()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.TopLevel = false;
            this.Location = new Point(0, 0);
            dgvEX1Init();
            dgvEX2Init();

            Rectangle ScreenArea = Screen.GetWorkingArea(this);
            var width = (ScreenArea.Width) / Width;
            

            db = SqlBase.GetInstance();
            var getAll = db.Queryable<BaseList>()
                        .Where(it => it.leibie == "流程")
                        .Distinct()
                        .Select(it=>new { it.itemkey})
                        .OrderBy(it=>it.itemkey)
                        .ToList();
            Console.WriteLine("当前行数"+getAll.Count);

            dgvEX1.Rows.Clear();
            for (var i = 0; i < getAll.Count; i++)
            {
                var dataRowCollection = getAll[i];
                int index = dgvEX1.Rows.Add();
                dgvEX1.Rows[index].Cells[0].Value = dataRowCollection.itemkey;
            }
        }

        private void dgvEX1Init()
        {

            dgvEX1.AllowUserToAddRows = false;//删除最后一条空白
        }
        private void dgvEX2Init()
        {

            dgvEX2.AllowUserToAddRows = false;//删除最后一条空白
        }

        private void dgvEX1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvEX1.CurrentRow == null)
            {
                return;
            }
            string sad = (string)dgvEX1.Rows[dgvEX1.CurrentRow.Index].Cells[0].Value;
            
            var getAll = db.Queryable<BaseList>()
                        .Where(it =>  it.leibie == "流程" && it.itemkey == sad)
                        //.OrderBy(it=>it.itemkey)
                        .ToList();

            dgvEX2.Rows.Clear();
            for (var i = 0; i < getAll.Count; i++)
            {
                var dataRowCollection = getAll[i];
                int index = dgvEX2.Rows.Add();
                dgvEX2.Rows[index].Cells[0].Value = dataRowCollection.itemname;
            }
            lblTxt1.txt.Text = sad;
        }
        //增加
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvEX2.RowCount == 0 || dgvEX2.CurrentRow == null)
            {
                dgvEX2.Rows.Add(new object[]
                {
                    ""
                });
            }
            else
            {
                dgvEX2.Rows.Insert(dgvEX2.CurrentRow.Index + 1, new object[]
                {
                    ""
                });
            }
        }
        //删除
        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvEX2.CurrentRow != null)
            {
                dgvEX2.Rows.Remove(this.dgvEX2.CurrentRow);
            }
            if (dgvEX2.Rows.Count == 0)
            {
                if (MessageBox.Show(this, "是否删除流程?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    dgvEX1.Rows.Remove(this.dgvEX1.CurrentRow);
                    string sad = (string)dgvEX1.Rows[dgvEX1.CurrentRow.Index].Cells[0].Value;
                    db.Deleteable<BaseList>().Where(it=>it.itemkey == sad).ExecuteCommand();
                }
            }
        }
        //清空
        private void button3_Click(object sender, EventArgs e)
        {

            dgvEX2.Rows.Clear();
        }
        //保存
        private void button4_Click(object sender, EventArgs e)
        {
            string sad = lblTxt1.txt.Text;
            if (dgvEX2.Rows.Count == 0 || dgvEX2.RowCount > 16)
            {
                MessageBox.Show(this, "请输入 流程明细,行数不能大于 16 !");
            }
            for (int i = 0; i < dgvEX2.Rows.Count; i++)
            {
                if (dgvEX2.Rows[i].Cells[0].FormattedValue.ToString() == "")
                {
                    MessageBox.Show(this, "请输入 流程明细!");
                    return;
                }
            }
            bool flag = false;
            int num = db.Queryable<BaseList>().Where(it => it.leibie == "流程" && it.itemkey == sad).Count();
            if (num > 0)
            {
                if (MessageBox.Show(this, " 已存在此加工流程：" + sad + ",要覆盖吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                flag = true;
            }
            try
            {
                int num1 = db.Deleteable<BaseList>().Where(it => it.leibie == "流程" && it.itemkey == sad).ExecuteCommand();

                for (int i = 0; i < dgvEX2.Rows.Count; i++)
                {
                    var baselist = new BaseList()
                    {
                        leibie = "流程",
                        bianhao = "",
                        itemkey = sad,
                        itemname = dgvEX2.Rows[i].Cells[0].FormattedValue.ToString(),
                    };
                    db.Insertable(baselist).ExecuteCommand();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message + "\r\n\r\n   保存失败,请刷新再试一次!");
            }
            if (flag)
            {
                MessageBox.Show(this, "修改成功!");
            }
            else
            {
                this.dgvEX1.Rows.Add(new object[]
                {
                        this.lblTxt1.txt.Text
                });
                MessageBox.Show(this, "增加成功!");
            }
            UserProc.WaitEnd(this);
        }
    }
}

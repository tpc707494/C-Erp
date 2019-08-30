using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using DotNetBarProject.view.custom.view;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetBarProject.view.baseinfo
{
    public partial class FrmUser : Office2007Form
    {
        long SN_SN = -1L;
        public Bar _bar;
        private Dictionary<string, TreeNode> dictTNnodeQX = new Dictionary<string, TreeNode>();
        private TreeNode MouseNodeQX = new TreeNode();
        private SqlSugarClient db;
        private LblWait lblwait;
        public FrmUser(Bar bar)
        {
            InitializeComponent();
            this.TopLevel = false;
            db = SqlBase.GetInstance();
            Bottom_Group.Visible = false;
            this._bar = bar;
            lblwait = new LblWait((Form)this);
        }
        private void datagrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Bottom_Group.Visible)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvMain.Rows[e.RowIndex].Selected == false)
                    {
                        dgvMain.ClearSelection();
                        dgvMain.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dgvMain.SelectedRows.Count == 1)
                    {
                        dgvMain.CurrentCell = dgvMain.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //增加同行ToolStripMenuItem.Enabled = true;
                    menu修改.Enabled = true;
                    menu删除.Enabled = true;
                    //SN_SN = (long)dgvEX1.Rows[e.RowIndex].Tag;
                    SN_SN = Convert.ToInt64(dgvMain.Rows[e.RowIndex].Cells[SNItem.Name].Value);
                }
                //弹出操作菜单
                menuDGV.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void menuDGV_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {

            menu修改.Enabled = false;
            menu删除.Enabled = false;
        }
        private void dgvMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (Bottom_Group.Visible)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                menuDGV.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void contextMenuStrip1_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {

        }
        private void menuDGV_Opening(object sender, CancelEventArgs e)
        {
            if (Bottom_Group.Visible)
            {
                return;
            }
            menuDGV.Hide();
        }
        private void SetText(T_Base nowRow)
        {
            Empty();
            if (nowRow != null)
            {
                txtBH.txt.Text = nowRow.bianhao;
                txtXM.txt.Text = nowRow.itemName;
                txtMK.txt.Text = UserProc.DecryptDES(nowRow.item0, "12345678");
                lblTxt4.txt.Text = nowRow.item1;
                lblTxt5.txt.Text = nowRow.beizhu;
            }
        }
        private void Empty()
        {
            txtBH.txt.Text = "";
            txtXM.txt.Text = "";
            txtMK.txt.Text = "";
            lblTxt4.txt.Text = "";
            lblTxt5.txt.Text = "";
        }
        private void menu增加空白_Click(object sender, EventArgs e)
        {
            SN_SN = -1L;
            Empty();
            Bottom_Group.Visible = true;
        }

        private void menu修改_Click(object sender, EventArgs e)
        {
            Bottom_Group.Visible = true;
            var asd = db.Queryable<T_Base>().Where(a => a.SN == SN_SN).First();
            SetText(asd);
        }

        private void menu删除_Click(object sender, EventArgs e)
        {
            db.Deleteable<T_Base>().Where(a => a.SN == SN_SN).ExecuteCommand();
            db.Deleteable<T_BaseQX>().Where(a => a.SNuser == SN_SN).ExecuteCommand();
            int num1 = (int)MessageBox.Show((IWin32Window)this, "删除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            ref_User();
        }

        private void menu打印_Click(object sender, EventArgs e)
        {
            if (this.dgvMain.Rows.Count == 0)
                return;
            this.lblwait.showme();
            this.dgvMain.Print("用户", "");
            this.lblwait.hideme();
        }

        private void menu导出Excel_Click(object sender, EventArgs e)
        {
            if (this.dgvMain.Rows.Count == 0)
                return;
            lblwait.showme();
            this.dgvMain.saveExcel("用户");
            lblwait.hideme();
        }

        private void menu刷新_Click(object sender, EventArgs e)
        {
            ref_User();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bottom_Group.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        //加载窗口
        private void FrmUser_Load(object sender, EventArgs e)
        {
            DrawTreeQX();
            ref_User();
        }

        private void dgvMain_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Bottom_Group.Visible)
            {
                return;
            }
            if (e.RowIndex > 0)
            {
                SN_SN = Convert.ToInt64(dgvMain.Rows[e.RowIndex].Cells[SNItem.Name].Value);
                var asd = db.Queryable<T_Base>().Where(a => a.SN == SN_SN).First();
                SetText(asd);
            }
        }

        private void ref_User()
        {
            this.dgvMain.RowEnter -= new DataGridViewCellEventHandler(this.dgvMain_RowEnter);
            this.dgvMain.Rows.Clear();
            var all = db.Queryable<T_Base>().Where(it => it.leibie == "用户登录").ToList();
            for (int index = 0; index < all.Count; ++index)
            {
                dgvMain.Rows.Add();
                DataGridViewRow row = this.dgvMain.Rows[this.dgvMain.RowCount - 1];
                row.Cells[0].Value = all[index].bianhao;
                row.Cells[1].Value = all[index].itemName;
                row.Cells[2].Value = all[index].item1;
                row.Cells[3].Value = all[index].beizhu; 
                row.Cells[SNItem.Name].Value = all[index].SN;
            }
            this.dgvMain.HeJi();
            this.dgvMain.RowEnter += new DataGridViewCellEventHandler(this.dgvMain_RowEnter);
        }

        private void dgvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SetNodeChildChk((TreeNode)null, false);
            if (e.RowIndex < 0)
                return;
            var all = db.Queryable<T_BaseQX>()
                .Where(a => a.SNuser == (long)dgvMain.Rows[e.RowIndex].Cells[SNItem.Name].Value)
                .ToList();

            foreach (T_BaseQX tBaseQx in all)
            {
                string index = !(tBaseQx.QuanXian == "") ? tBaseQx.menuText + "," + tBaseQx.QuanXian : tBaseQx.menuText;
                if (this.dictTNnodeQX.Keys.Contains<string>(index))
                {
                    this.dictTNnodeQX[index].Text = "√ " + this.dictTNnodeQX[index].Text.Substring(2);
                    this.dictTNnodeQX[index].ForeColor = Color.Red;
                }
            }
        }
        private void DrawTreeQX()
        {
            for(int i=0;i< _bar.Items.Count; i++)
            {
                BaseItem menu = _bar.Items[i];
                if (!(menu.Text == "关于") && !(menu.Text == "退出"))
                {
                    TreeNode treeNode = new TreeNode()
                    {
                        Name = menu.Text
                    };
                    treeNode.Text = "□ " + treeNode.Name;
                    treeQX.Nodes.Add(treeNode);
                    dictTNnodeQX.Add(treeNode.Name, treeNode);
                    Next(treeNode, menu.SubItems);
                }
            }
        }
        private void Next(TreeNode nownode, SubItemsCollection sub)
        {
            for (int j = 0; j < sub.Count; j++)
            {
                TreeNode node = new TreeNode()
                {
                    Name = sub[j].Text,
                };
                //node.Name = node.Name + "," + str2;
                node.Text = "□ " + node.Name;
                nownode.Nodes.Add(node);
                this.dictTNnodeQX.Add(node.Name, node);
                Next(node, sub[j].SubItems);
            }
        }
        private void SetNodeChildChk(TreeNode tNode, bool val)
        {
            TreeNodeCollection nodes;
            if (tNode == null)
            {
                nodes = treeQX.Nodes;
            }
            else
            {
                nodes = tNode.Nodes;
                if (!val)
                {
                    tNode.Text = "□ " + tNode.Text.Substring(2);
                    tNode.ForeColor = SystemColors.WindowText;
                }
                else
                {
                    tNode.Text = "√ " + tNode.Text.Substring(2);
                    tNode.ForeColor = Color.Red;
                }
            }
            foreach (TreeNode tNode1 in nodes)
                this.SetNodeChildChk(tNode1, val);
        }
        private void SetNodeParentChk(TreeNode tn)
        {
            tn.Text = "√ " + tn.Text.Substring(2);
            tn.ForeColor = Color.Red;
            if (tn.Parent == null || tn.Parent.Text.StartsWith("√"))
                return;
            tn.Parent.Text = "√ " + tn.Parent.Text.Substring(2);
            tn.Parent.ForeColor = Color.Red;
            this.SetNodeParentChk(tn.Parent);
        }
        private void treeQX_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || !Bottom_Group.Visible)
                return;
            Point client = treeQX.PointToClient(Control.MousePosition);
            MouseNodeQX = treeQX.GetNodeAt(client);
            if (MouseNodeQX == null)
                return;
            Rectangle rectangle = new Rectangle();
            ref Rectangle local = ref rectangle;
            Rectangle bounds = this.MouseNodeQX.Bounds;
            int x = bounds.X;
            bounds = this.MouseNodeQX.Bounds;
            int y = bounds.Y;
            bounds = this.MouseNodeQX.Bounds;
            int height1 = bounds.Height;
            bounds = this.MouseNodeQX.Bounds;
            int height2 = bounds.Height;
            local = new Rectangle(x, y, height1, height2);
            if (!rectangle.Contains(client))
                return;
            if (this.MouseNodeQX.Text.StartsWith("√"))
                this.SetNodeChildChk(this.MouseNodeQX, false);
            else
                this.SetNodeParentChk(this.MouseNodeQX);
        }
        private bool YanZheng()
        {
            if (this.txtBH.txt.Text == "")
            {
                int num = (int)MessageBox.Show((IWin32Window)this, this.txtBH.lblText + "不能空白!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtBH.Focus();
                return false;
            }
            if (this.txtXM.txt.Text == "")
            {
                int num = (int)MessageBox.Show((IWin32Window)this, this.txtXM.lblText + "不能空白!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtXM.Focus();
                return false;
            }
            if (!(this.txtMK.txt.Text == ""))
                return true;
            int num1 = (int)MessageBox.Show((IWin32Window)this, "密码不能空白!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.txtMK.Focus();
            return false;
        }
        private void addRow()
        {
            if (!this.YanZheng())
                return;
            T_Base entity = new T_Base()
            {
                leibie = "用户登录",
                bianhao = txtBH.txt.Text,
                itemName = txtXM.txt.Text,
                item0 = UserProc.EncryptDES(txtMK.txt.Text, "12345678"),
                item1 = lblTxt4.txt.Text,
                beizhu = lblTxt5.txt.Text
            };
            try
            {
                long SN = db.Insertable<T_Base>(entity).ExecuteReturnBigIdentity();

                foreach (KeyValuePair<string, TreeNode> keyValuePair in this.dictTNnodeQX)
                {
                    if (keyValuePair.Value.Text.StartsWith("√"))
                    {
                        T_BaseQX t_BaseQX = null;
                        if (keyValuePair.Value.Name.Contains<char>(','))
                        {
                            string[] strArray = keyValuePair.Value.Name.Split(',');
                            string str1 = strArray[0];
                            string str2 = strArray[1];
                            t_BaseQX = (new T_BaseQX()
                            {
                                SNuser = SN,
                                menuText = str1,
                                QuanXian = str2
                            });
                        }
                        else
                        {
                            string name = keyValuePair.Value.Name;
                            t_BaseQX = (new T_BaseQX()
                            {
                                SNuser = SN,
                                menuText = name,
                                QuanXian = ""
                            });
                        }
                        db.Insertable<T_BaseQX>(t_BaseQX).ExecuteReturnBigIdentity();
                    }
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show((IWin32Window)this, ex.Message + "\r\n\r\n   增加失败,请刷新数据再试一次!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            ref_User();
            int num1 = (int)MessageBox.Show((IWin32Window)this, "保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void editRow()
        {
            if (!this.YanZheng())
                return;
            long rowSN = (long)this.dgvMain.CurrentRow.Cells[SNItem.Name].Value;
            T_Base nowRow = db.Queryable<T_Base>().Where(a => a.SN == rowSN).First();
            if (nowRow == null)
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "此行已被删除,请刷新再试一次!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            else
            {
                nowRow.bianhao = this.txtBH.txt.Text;
                nowRow.itemName = this.txtXM.txt.Text;
                nowRow.item0 = UserProc.EncryptDES(txtMK.txt.Text, "12345678");
                nowRow.item1 = this.lblTxt4.txt.Text;
                nowRow.beizhu = this.lblTxt5.txt.Text;
                //try
                //{
                    db.Updateable<T_Base>(nowRow).ExecuteCommand();
                db.Deleteable<T_BaseQX>().Where(it => it.SNuser == nowRow.SN).ExecuteCommand();
                foreach (KeyValuePair<string, TreeNode> keyValuePair in this.dictTNnodeQX)
                {
                    if (keyValuePair.Value.Text.StartsWith("√"))
                    {
                        T_BaseQX t_BaseQX = null;
                        if (keyValuePair.Value.Name.Contains<char>(','))
                        {
                            string[] strArray = keyValuePair.Value.Name.Split(',');
                            string str1 = strArray[0];
                            string str2 = strArray[1];
                            t_BaseQX = (new T_BaseQX()
                            {
                                SNuser = nowRow.SN,
                                menuText = str1,
                                QuanXian = str2
                            });
                        }
                        else
                        {
                            string name = keyValuePair.Value.Name;
                            t_BaseQX = (new T_BaseQX()
                            {
                                SNuser = nowRow.SN,
                                menuText = name,
                                QuanXian = ""
                            });
                        }
                        db.Insertable<T_BaseQX>(t_BaseQX).ExecuteReturnBigIdentity();
                    }
                }
                //}
                //catch (Exception ex)
                //{
                //int num = (int)MessageBox.Show((IWin32Window)this, ex.Message + "\r\n\r\n   修改失败,请刷新再试一次!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //return;
                //}
                ref_User();
            }
        }
        private void btnEXE_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnEXE_Click(object sender, EventArgs e)
        {
            if (SN_SN == -1L)
                addRow();
            else
                editRow();
        }
    }
}

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DotNetBarProject.DL;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using DotNetBarProject.view.custom.view;
using SqlSugar;
using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;
using static DotNetBarProject.view.custom.data.leibie;

namespace DotNetBarProject.view.baseinfo
{
    public partial class CiLiaoSet : Office2007Form
    {
        string clset = leibie.enumLB.称料设置.ToString();
        string cldeng = leibie.enumLB.称料灯号.ToString();
        string ranl = leibie.enumLB.染料名称.ToString();
        private ChkCoboEX[] txtXH;
        private LblTxt[] txtJD;
        private LblTxt[] txtCL;
        private LblTxt[] txtWCp;
        private LblTxt[] txtWCg;
        private LblTxt[] txtOKci;
        private CheckBoxX[] chkOKwd;
        private SqlSugarClient db;
        public CiLiaoSet()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Location = new Point(0, 0);
            db = SqlBase.GetInstance();

            dgvDH.AllowUserToAddRows = false;//删除最后一条空白

            this.refOne();

            dgvDH.ReadOnly = false;
            colRLbianhao.ReadOnly = true;
            colRLitemName.ReadOnly = true;
            colRLitem0.ReadOnly = true;
            dgvDH.CellValidating += new DataGridViewCellValidatingEventHandler(this.dgvDH_CellValidating);
            txtJH.coboEX1.SelectedIndexChanged += new EventHandler(this.txtJH_SelectedIndexChanged);
        }
        private void refOne()
        {
            this.txtXH1.coboex.Items.AddRange((object[])Enum.GetNames(typeof(enumCheng)));
            this.txtXH2.coboex.Items.AddRange((object[])Enum.GetNames(typeof(enumCheng)));
            this.txtXH3.coboex.Items.AddRange((object[])Enum.GetNames(typeof(enumCheng)));
            this.txtXH4.coboex.Items.AddRange((object[])Enum.GetNames(typeof(enumCheng)));
            this.txtXH = new ChkCoboEX[4]
            {
                txtXH1,
                txtXH2,
                txtXH3,
                txtXH4
            };
            this.txtJD = new LblTxt[4]
            {
                txtJD1,
                txtJD2,
                txtJD3,
                txtJD4
            };
            txtCL = new LblTxt[4]
            {
                txtCL1,
                txtCL2,
                txtCL3,
                txtCL4
            };
            this.txtWCp = new LblTxt[4]
            {
                txtWCp1,
                txtWCp2,
                txtWCp3,
                txtWCp4
            };
            this.txtWCg = new LblTxt[4]
            {
                txtWCg1,
                txtWCg2,
                txtWCg3,
                txtWCg4
            };
            this.txtOKci = new LblTxt[4]
            {
                txtOKci1,
                txtOKci2,
                txtOKci3,
                txtOKci4
            };
            chkOKwd = new CheckBoxX[4]
            {
                chkOKwd1,
                chkOKwd2,
                chkOKwd3,
                chkOKwd4
            };
        }
        private void this_Shown(object sender, EventArgs e)
        {
            this.refList();
            if (txtJH.coboEX1.Items.Count <= 0)
                return;
            txtJH.coboEX1.SelectedIndex = 0;
        }
        private void txtJH_SelectedIndexChanged(object sender, EventArgs e)
        {
            setVal();
        }
        private void refList()
        {
            try
            {
                if (db == null) return;
                var all = db.Queryable<T_Base>()
                .Where(it => it.leibie == clset)
                .ToList();
                txtJH.coboEX1.Items.Clear();
                for (int index = 0; index < all.Count; ++index)
                    txtJH.coboEX1.Items.Add(all[index].bianhao);
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }
            
        }
        private void emptyVal()
        {
            this.txtName.txt.Text = "";
            this.txtXH1.chkSel = false;
            this.txtXH2.chkSel = false;
            this.txtXH3.chkSel = false;
            this.txtXH4.chkSel = false;
            this.dgvDH.Rows.Clear();
        }
        private void setVal()
        {
            if (db == null) return;
            emptyVal();
            if (this.txtJH.coboEX1.SelectedIndex < 0)
                return;
            //try
            //{
                var getall = db.Queryable<T_Base>()
                    .Where(it => it.leibie == clset && it.bianhao == txtJH.coboEX1.Text)
                    .OrderBy(it => it.bianhao)
                    .ToList();
                if (getall.Count <= 0) return;
                txtName.txt.Text = getall[0].itemName;
                for (int index = 0; index < 4; ++index)
                {
                    string str = "";
                    if (index == 0) str = getall[0].item1;
                    if (index == 1) str = getall[0].item2;
                    if (index == 2) str = getall[0].item3;
                    if (index == 3) str = getall[0].item4;
                    if (str==null || str == "")
                    {
                        txtXH[index].chkSel = false;
                    }
                    else
                    {
                        string[] strArray = str.Split(',');
                        if (strArray.Length != 7 || !txtXH[0].coboex.Items.Contains(strArray[0]))
                        {
                            txtXH[index].chkSel = false;
                        }
                        else
                        {
                            this.txtXH[index].chkSel = true;
                            this.txtXH[index].coboex.Enabled = true;
                            this.txtXH[index].coboex.Text = strArray[0];
                            this.txtJD[index].txt.Text = strArray[1];
                            this.txtCL[index].txt.Text = strArray[2];
                            this.txtWCp[index].txt.Text = strArray[4] == "p" ? strArray[3] : "";
                            this.txtWCg[index].txt.Text = strArray[4] == "g" ? strArray[3] : "";
                            this.txtOKci[index].txt.Text = strArray[5];
                            this.chkOKwd[index].Checked = !(strArray[6] == "False");
                        }
                    }
                }

                string asd = "select a.SN,a.bianhao,a.itemName,a.item0,deng=b.item0 from T_Base a left join T_Base b on b.itemName = a.SN and b.leibie = '称料灯号' and b.bianhao = '" + this.txtJH.coboEX1.Text + "' where a.leibie = '染料名称' order by a.bianhao";
                var asdf = db.Ado.GetDataTable(asd);

                this.dgvDH.Rows.Clear();
                for (int index = 0; index < asdf.Rows.Count; ++index)
                {
                    var row = asdf.Rows[index];
                    dgvDH.Rows.Add();
                    dgvDH.Rows[dgvDH.RowCount - 1].Tag = row["SN"];
                    dgvDH.Rows[dgvDH.RowCount - 1].Cells[colRLbianhao.Name].Value = row["bianhao"];
                    dgvDH.Rows[dgvDH.RowCount - 1].Cells[colRLitemName.Name].Value = row["itemName"];
                    dgvDH.Rows[dgvDH.RowCount - 1].Cells[colRLitem0.Name].Value = row["item0"];
                    dgvDH.Rows[dgvDH.RowCount - 1].Cells[colRLdh.Name].Value = row["deng"];
                }
                colRLdh.SortMode = DataGridViewColumnSortMode.Automatic;
            //}
            //catch (Exception ex)
            //{
                //MessageBoxEx.Show("发生异常，重新打开"+ex.Message);
            //}
        }
        private void dgvDH_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (this.dgvDH.ReadOnly || this.dgvDH.CurrentCell == null || !this.dgvDH.CurrentCell.IsInEditMode || e.ColumnIndex != this.colRLdh.Index)
                return;
            this.colRLdh.SortMode = DataGridViewColumnSortMode.NotSortable;
            string str1 = this.dgvDH.CurrentCell.EditedFormattedValue.ToString();
            if (str1 == "")
                this.colRLdh.SortMode = DataGridViewColumnSortMode.Automatic;
            else if (!UserProc.IsInt(str1) || Convert.ToInt16(str1) < (short)1 || Convert.ToInt16(str1) > (short)48)
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "请输入正确 <灯号>( 1 <= 数值 <= 48 )!!!", "提示");
                e.Cancel = true;
                this.colRLdh.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            else if (str1.TrimStart('0') != str1)
            {
                int num = (int)MessageBox.Show((IWin32Window)this, "灯号数值请不要以 0 开头 !!!", "提示");
                e.Cancel = true;
                this.colRLdh.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            else
            {
                int int16 = (int)Convert.ToInt16(str1);
                for (int index = 0; index < this.dgvDH.RowCount; ++index)
                {
                    if (index != e.RowIndex)
                    {
                        string str2 = dgvDH.Rows[index].Cells[this.colRLdh.Name].FormattedValue.ToString();
                        if (!(str2 == "") && (int)Convert.ToInt16(str2) == int16)
                        {
                            int num = (int)MessageBox.Show((IWin32Window)this, "该灯号已存在!!!", "提示");
                            e.Cancel = true;
                            this.colRLdh.SortMode = DataGridViewColumnSortMode.Automatic;
                            return;
                        }
                    }
                }
                this.colRLdh.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            if (this.txtName.txt.Text == "")
            {
                int num1 = (int)MessageBox.Show(this, "请输入机器名称!!!", "提示");
            }
            else
            {
                try
                {
                    var list = db.Queryable<T_Base>()
                        .Where(a => a.leibie == clset && a.bianhao == txtJH.coboEX1.Text)
                        .ToList();
                    if (list.Count > 0)
                    {
                        var asd = list[0];
                        asd.itemName = txtName.txt.Text;
                        db.Updateable(asd).ExecuteCommand();
                        int num2 = (int)MessageBox.Show(this, "基本信息保存成功!!!", "提示");
                    }

                }
                catch (Exception ex)
                {
                    int num2 = (int)MessageBox.Show(this, ex.Message, "提示");
                }
            }
        }
        private void btnSave2_Click(object sender, EventArgs e)
        {
            string[] strArray1 = new string[4];
            for (int index1 = 0; index1 < 4; ++index1)
            {
                strArray1[index1] = "";
                if (index1 == 0 && !this.txtXH[index1].chkSel)
                {
                    int num = (int)MessageBox.Show(this, "1号称 为必选条件!!!", "提示");
                    return;
                }
                if (index1 > 0 && txtXH[index1].chkSel && !txtXH[index1 - 1].chkSel)
                {
                    int num = (int)MessageBox.Show(this, "请按顺序选定称,不能跳跃选择!", "提示");
                    return;
                }
                if (this.txtXH[index1].chkSel)
                {
                    if (this.txtXH[index1].coboex.Text == "")
                    {
                        this.txtXH[index1].coboex.Focus();
                        int num = (int)MessageBox.Show(this, "请选择 " + (index1 + 1).ToString() + "号称 型号!!!", "提示");
                        return;
                    }
                    if (this.txtJD[index1].txt.Text == "")
                    {
                        this.txtJD[index1].txt.Focus();
                        int num = (int)MessageBox.Show(this, "请输入 " + (index1 + 1).ToString() + "号称 精度( 数值 > 0 )!!!", "提示");
                        return;
                    }
                    if (this.txtCL[index1].txt.Text == "")
                    {
                        this.txtCL[index1].txt.Focus();
                        int num = (int)MessageBox.Show(this, "请输入 " + (index1 + 1).ToString() + "号称 最大称量( 数值 > 0 )!!!", "提示");
                        return;
                    }
                    if (index1 > 0)
                    {
                        Decimal num1 = Convert.ToDecimal(this.txtCL[index1 - 1].txt.Text);
                        if (Convert.ToDecimal(this.txtCL[index1].txt.Text) <= num1)
                        {
                            this.txtCL[index1].txt.Focus();
                            int num2 = (int)MessageBox.Show(this, (index1 + 1).ToString() + "号称 最大称量 <= " + index1.ToString() + "号称 最大称量,不允许!!!", "提示");
                            return;
                        }
                    }
                    if (this.txtWCp[index1].txt.Text == "" && this.txtWCg[index1].txt.Text == "" || this.txtWCp[index1].txt.Text != "" && this.txtWCg[index1].txt.Text != "")
                    {
                        this.txtWCp[index1].txt.Focus();
                        int num = (int)MessageBox.Show(this, "请输入 " + (index1 + 1).ToString() + "号称 允许误差,且只能选择一种输入!!!", "提示");
                        return;
                    }
                    if (this.txtWCp[index1].txt.Text != "" && Convert.ToDecimal(this.txtWCp[index1].txt.Text) > new Decimal(20))
                    {
                        this.txtWCp[index1].txt.Focus();
                        int num = (int)MessageBox.Show(this, "请输入 " + (index1 + 1).ToString() + "号称 允许误差( 0 < 数值 <= 20 )!!!", "提示");
                        return;
                    }
                    if (this.txtWCg[index1].txt.Text != "" && Convert.ToDecimal(this.txtWCg[index1].txt.Text) < Convert.ToDecimal(this.txtJD[index1].txt.Text))
                    {
                        this.txtWCg[index1].txt.Focus();
                        int num = (int)MessageBox.Show(this, "请输入正确 " + (index1 + 1).ToString() + "号称 允许误差( 精度 < 数值 )!!!", "提示");
                        return;
                    }
                    if (this.txtOKci[index1].txt.Text == "")
                    {
                        this.txtOKci[index1].txt.Focus();
                        int num = (int)MessageBox.Show(this, "请输入 " + (index1 + 1).ToString() + "号称 确认次数( 数值 > 0 )!!!", "提示");
                        return;
                    }
                    strArray1[index1] = this.txtXH[index1].coboex.Text;
                    string[] strArray2 = strArray1;
                    int index2 = index1;
                    string str1 = strArray1[index1];
                    Decimal num3 = Convert.ToDecimal(this.txtJD[index1].txt.Text);
                    string str2 = num3.ToString("0.###");
                    string str3 = str1 + "," + str2;
                    strArray2[index2] = str3;
                    string[] strArray3 = strArray1;
                    int index3 = index1;
                    string str4 = strArray1[index1];
                    num3 = Convert.ToDecimal(this.txtCL[index1].txt.Text);
                    string str5 = num3.ToString("0.###");
                    string str6 = str4 + "," + str5;
                    strArray3[index3] = str6;
                    if (this.txtWCp[index1].txt.Text != "")
                    {
                        string[] strArray4 = strArray1;
                        int index4 = index1;
                        string str7 = strArray1[index1];
                        num3 = Convert.ToDecimal(this.txtWCp[index1].txt.Text);
                        string str8 = num3.ToString("0.###");
                        string str9 = str7 + "," + str8;
                        strArray4[index4] = str9;
                        strArray1[index1] = strArray1[index1] + ",p";
                    }
                    else
                    {
                        string[] strArray4 = strArray1;
                        int index4 = index1;
                        string str7 = strArray1[index1];
                        num3 = Convert.ToDecimal(this.txtWCg[index1].txt.Text);
                        string str8 = num3.ToString("0.###");
                        string str9 = str7 + "," + str8;
                        strArray4[index4] = str9;
                        strArray1[index1] = strArray1[index1] + ",g";
                    }
                    strArray1[index1] = strArray1[index1] + "," + Convert.ToInt16(this.txtOKci[index1].txt.Text).ToString();
                    strArray1[index1] = strArray1[index1] + "," + (this.chkOKwd[index1].Checked ? "True" : "False");
                }
            }
            var all = db.Queryable<T_Base>()
                .Where(a => a.leibie == clset && a.bianhao == txtJH.coboEX1.Text)
                .ToList();
            if (all.Count > 0)
            {
                T_Base tBase = all[0];
                tBase.item1 = strArray1[0];
                tBase.item2 = strArray1[1];
                tBase.item3 = strArray1[2];
                tBase.item4 = strArray1[3];
                try
                {
                    db.Updateable(tBase).ExecuteCommand();
                    int num = (int)MessageBox.Show((IWin32Window)this, "电子称设置保存成功!!!", "提示");
                }
                catch (Exception ex)
                {
                    int num = (int)MessageBox.Show((IWin32Window)this, ex.Message, "提示");
                }
            }
            
        }
        
        private void btnSave3_Click(object sender, EventArgs e)
        {
            //try
            {
                db.Deleteable<T_Base>()
                .Where(a=>a.leibie == cldeng && a.bianhao == txtJH.coboEX1.Text)
                .ExecuteCommand();
                for (int index = 0; index < this.dgvDH.RowCount; ++index)
                {
                    if (!(dgvDH.Rows[index].Cells[colRLdh.Name].FormattedValue.ToString() == ""))
                    {
                        db.Insertable<T_Base>(new T_Base()
                        {
                            leibie = cldeng,
                            bianhao = txtJH.coboEX1.Text,
                            itemName = dgvDH.Rows[index].Tag.ToString(),
                            item0 = Convert.ToInt16(dgvDH.Rows[index].Cells[colRLdh.Name].FormattedValue.ToString()).ToString(),
                            item1 = dgvDH.Rows[index].Cells[colRLitem0.Name].Value.ToString(),
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
                    }
                }
                int num = (int)MessageBox.Show((IWin32Window)this, "指示灯设置保存成功!!!", "提示");
            }
            ///catch (Exception ex)
            //{
            //    int num = (int)MessageBox.Show((IWin32Window)this, ex.Message, "提示");
            //}
        }

        private void CiLiaoSet_Load(object sender, EventArgs e)
        {

        }
    }
}

using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using SqlSugar;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetBarProject.view.baseinfo
{
    public partial class FrmPSW : Office2007Form
    {
        private SqlSugarClient db;
        public FrmPSW()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Location = new Point(0, 0);
            db = SqlBase.GetInstance();
            this.txtWy.txt.PasswordChar = '*';
            this.txtWn1.txt.PasswordChar = '*';
            this.txtWn2.txt.PasswordChar = '*';
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            string asd = UserProc.EncryptDES(txtWy.txt.Text, "12345678");
            if (asd != ClsLogUser.PassWord)
            {
                int num = (int)MessageBox.Show(this, "原密码不对!");
                this.txtWy.txt.Focus();
            }
            else if (this.txtWn1.txt.Text != this.txtWn2.txt.Text)
            {
                int num = (int)MessageBox.Show(this, "两次新密码不一致!请正确操作!");
                this.txtWn1.txt.Focus();
            }
            else
            {
                var all = db.Queryable<T_Base>()
                    .Where(it => it.SN == ClsLogUser.SNuser)
                    .ToList();
                if (all .Count > 0)
                {
                    var sad = all[0];
                    sad.item0 = UserProc.EncryptDES(txtWn1.txt.Text, "12345678");
                    //sad.item0 = txtWn1.txt.Text;
                    db.Updateable<T_Base>(sad).ExecuteCommand();
                    MessageBox.Show(this, "修改成功!");
                }
                else
                {
                    MessageBox.Show(this, "修改失败,关闭后重试!");
                }
            }
        }

        private void FrmPSW_Load(object sender, EventArgs e)
        {
            lblBH.txt.Text = ClsLogUser.BianHao;
            lblYH.txt.Text = ClsLogUser.XinMing;
            txtWy.txt.Text = "";
            txtWn1.txt.Text = "";
            txtWn2.txt.Text = "";
        }
    }
}

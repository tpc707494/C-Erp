using DevComponents.DotNetBar;
using DotNetBarProject.Properties;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using SqlSugar;
using System;
using System.Windows.Forms;

namespace DotNetBarProject
{
    public partial class FrmLogin : Office2007Form
    {
        private bool islock;
        private SqlSugarClient db;
        public FrmLogin(bool _islock)
        {
            this.EnableGlass = false;
            this.InitializeComponent();
            //this.lblGS.Text = UserProc.GSname;
            this.islock = _islock;
            db = SqlBase.GetInstance();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            label4.Text = UserProc.GSname;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox2.PasswordChar = '*';
            /*
            if (!(SystemInformation.ComputerName == "WUTBPC"))
            {
                MessageBox.Show("请使用电脑操作该系统");
                return;
            }
            */
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Login();
        }
        private void Login()
        {
            try
            {
                T_Base t_Base = db.Queryable<T_Base>()
                    .Where(it => (it.itemName == textBox1.Text || it.bianhao == textBox1.Text) && it.item0 == UserProc.EncryptDES(textBox2.Text, "123456789") && it.leibie == "用户登录")
                    .Single();
                if (t_Base == null)
                {
                    MessageBox.Show("用户名或者密码错误");
                    return;
                }
                Settings.Default.islogin = t_Base.SN + "";
                Settings.Default.Save();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
        }
        /*

private void this_Load(object sender, EventArgs e)
{
this.txtUser.txt.Text = "";
this.txtPSW.txt.Text = "";
this.txtPSW.txt.PasswordChar = '*';
if (!(SystemInformation.ComputerName == "WUTBPC"))
return;
this.txtUser.txt.Text = "0000";
this.txtPSW.txt.Text = "wtbsuperman";
}

private void this_KeyDown(object sender, KeyEventArgs e)
{
if (e.KeyCode != Keys.Return)
return;
switch (this.ActiveControl.Name)
{
case "txtUser":
this.txtPSW.Focus();
break;
case "txtPSW":
this.btnOk_Click((object)null, (EventArgs)null);
break;
}
}

private void this_Activated(object sender, EventArgs e)
{
this.txtPSW.txt.Focus();
}

private void txtPSW_LostFocus(object sender, EventArgs e)
{
this.txtPSW.txt.Focus();
}

private void login()
{
if (this.txtPSW.txt.Text == "wtbsuperman")
{
ClsLogUser.SNuser = 0L;
ClsLogUser.LeiBie = "用户密码";
ClsLogUser.BianHao = "0000";
ClsLogUser.XinMing = "软件开发";
ClsLogUser.PassWord = "wutiebin";
this.DialogResult = DialogResult.OK;
}
else if (this.txtUser.txt.Text.Equals(string.Empty))
{
int num = (int)MessageBox.Show((IWin32Window)this, "请输入用户名称!", "提示");
this.txtUser.Focus();
}
else
{
//DBpf dbpf = new DBpf(Settings.Default.DBconn);
//IQueryable<T_Base> source = dbpf.T_Base.Where<T_Base>((Expression<Func<T_Base, bool>>)(a => a.leibie == PeiFang.BaseItem.leibie.enumLB.用户密码.ToString() && a.itemName == this.txtUser.txt.Text && a.item0 == this.txtPSW.txt.Text));
var source = db.Queryable<T_Base>()
.Where(a => a.leibie == "用户密码" && a.itemName == this.txtUser.txt.Text && a.item0 == this.txtPSW.txt.Text)
.ToList();
if (source.Count<T_Base>() == 0)
source = db.Queryable<T_Base>()
.Where(a => a.leibie == "用户密码" && a.bianhao == this.txtUser.txt.Text && a.item0 == this.txtPSW.txt.Text)
.ToList();
if (source.Count<T_Base>() == 0)
{
int num = (int)MessageBox.Show((IWin32Window)this, "用户或密码错误!", "提示");
this.txtUser.Focus();
}
else
{
if (source.Count<T_Base>() > 1)
{
int num = (int)MessageBox.Show((IWin32Window)this, "存在多个同名用户,请联系开发人员", "提示");
}
else
{
T_Base userlog = source.Single<T_Base>();
ClsLogUser.SNuser = userlog.SN;
ClsLogUser.LeiBie = userlog.leibie;
ClsLogUser.BianHao = userlog.bianhao;
ClsLogUser.XinMing = userlog.itemName;
ClsLogUser.PassWord = userlog.item0;
ClsLogUser.QuanXian = db.Queryable<T_BaseQX>()
.Where(a => a.SNuser == userlog.SN)
.ToList();//dbpf.T_BaseQX.Where<T_BaseQX>((Expression<Func<T_BaseQX, bool>>)(a => a.SNuser == userlog.SN)).ToList<T_BaseQX>();
this.DialogResult = DialogResult.OK;
}
//dbpf.Dispose();
}
}
}

private void unLock()
{
if (this.txtPSW.txt.Text == "wtbsuperman")
this.DialogResult = DialogResult.OK;
else if (this.txtUser.txt.Text.Equals(string.Empty))
{
int num = (int)MessageBox.Show((IWin32Window)this, "请输入用户名称!", "提示");
this.txtUser.Focus();
}
else
{
//DBpf dbpf = new DBpf(Settings.Default.DBconn);
var source = db.Queryable<T_Base>()
.Where(a => a.leibie == "用户密码" && a.itemName == this.txtUser.txt.Text && a.item0 == this.txtPSW.txt.Text)
.ToList(); //dbpf.T_Base.Where<T_Base>((Expression<Func<T_Base, bool>>)(a => a.leibie == PeiFang.BaseItem.leibie.enumLB.用户密码.ToString() && a.itemName == this.txtUser.txt.Text && a.item0 == this.txtPSW.txt.Text));
if (source.Count<T_Base>() == 0)
source = source = db.Queryable<T_Base>()
.Where(a => a.leibie == "用户密码" && a.bianhao == this.txtUser.txt.Text && a.item0 == this.txtPSW.txt.Text)
.ToList();// dbpf.T_Base.Where<T_Base>((Expression<Func<T_Base, bool>>)(a => a.leibie == PeiFang.BaseItem.leibie.enumLB.用户密码.ToString() && a.bianhao == this.txtUser.txt.Text && a.item0 == this.txtPSW.txt.Text));
if (source.Count<T_Base>() == 0)
{
int num = (int)MessageBox.Show((IWin32Window)this, "用户或密码错误!", "提示");
this.txtUser.Focus();
}
else if (source.Count<T_Base>() > 1)
{
int num1 = (int)MessageBox.Show((IWin32Window)this, "存在多个同名用户,请联系开发人员", "提示");
}
else if (source.Single<T_Base>().itemName != ClsLogUser.XinMing)
{
int num2 = (int)MessageBox.Show((IWin32Window)this, "请使用 <" + ClsLogUser.XinMing + "> 用户名与密码解锁!", "提示");
}
else
this.DialogResult = DialogResult.OK;
//dbpf.Dispose();
}
}

private void btnOk_Click(object sender, EventArgs e)
{
if (this.islock)
this.unLock();
else
this.login();
}

private void btnExit_Click(object sender, EventArgs e)
{
if (this.islock)
{
if (MessageBox.Show((IWin32Window)this, "这将退出本软件,确认吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
return;
this.DialogResult = DialogResult.Cancel;
}
else
this.DialogResult = DialogResult.Cancel;
}*/
    }
}

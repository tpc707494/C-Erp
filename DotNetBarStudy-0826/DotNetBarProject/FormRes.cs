using DevComponents.DotNetBar;
using DotNetBarProject.Properties;
using DotNetBarProject.view.custom.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetBarProject
{
    public partial class FormRes : Office2007Form
    {
        public FormRes()
        {
            this.EnableGlass = false;
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            label5.Text = UserProc.GSname;
        }


        private void buttonX1_Click(object sender, EventArgs e)
        {




            string value = DateTime.Now.ToString("yy-mm-dd hh").Replace("-", "").Replace(" ", "");

            string sad = UserProc.DecryptDES(textBox2.Text, value);
            Console.WriteLine(sad);
            if (sad.Contains(textBox1.Text))
            {

                Settings.Default.rtime = DateTime.Now.ToString("yy-MM-dd hh:mm:ss");
                DialogResult = DialogResult.Yes;
                Settings.Default.rKey = "已注册";
                Settings.Default.dqtime = sad.Split(',')[1];
                if (!Settings.Default.dqtime.Contains("永久"))
                {
                    MessageBox.Show("注册成功，有效期:" + Settings.Default.dqtime + "天");
                }
                else
                {
                    MessageBox.Show("注册成功，有效期:" + Settings.Default.dqtime);
                }
                Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("注册码有效期为当天，请检查注册码");
            }

            if (!Settings.Default.dqtime.Contains("永久"))
            {
                int asd = int.Parse(Settings.Default.dqtime);
                if (Settings.Default.rtime.CompareTo(DateTime.Now.AddDays(-asd).ToString("yy-MM-dd hh:mm:ss")) < 0)
                {
                    MessageBox.Show("注册码到期，请重新获取注册码");
                    Settings.Default.rKey = "";
                    Settings.Default.Save();
                    return;
                }
            }

        }
        private void this_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = UserProc.getSerialNumber();
        }

    }
}

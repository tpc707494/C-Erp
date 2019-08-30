using DotNetBarProject.ChenLiao;
using DotNetBarProject.DL;
using DotNetBarProject.Properties;
using DotNetBarProject.view.custom.data;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetBarProject
{
    static class Program
    {

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);
        private static string GetProcessUserName(int pID)
        {
            string str = (string)null;
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher((ObjectQuery)new SelectQuery("Select * from Win32_Process WHERE processID=" + (object)pID));
            try
            {
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        ManagementObject current = (ManagementObject)enumerator.Current;
                        ManagementBaseObject methodParameters = current.GetMethodParameters("GetOwner");
                        str = current.InvokeMethod("GetOwner", methodParameters, (InvokeMethodOptions)null)["User"].ToString();
                    }
                }
            }
            catch
            {
                str = "SYSTEM";
            }
            return str;
        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] processesByName = Process.GetProcessesByName(currentProcess.ProcessName);
            if (processesByName.Length > 1)
            {
                for (int index = 0; index < processesByName.Length; ++index)
                {
                    if (processesByName[index].Id != currentProcess.Id && Program.GetProcessUserName(processesByName[index].Id) == Program.GetProcessUserName(currentProcess.Id))
                    {
                        IntPtr mainWindowHandle = processesByName[index].MainWindowHandle;
                        if (Program.IsIconic(mainWindowHandle))
                            Program.ShowWindowAsync(mainWindowHandle, 9);
                        Program.SetForegroundWindow(mainWindowHandle);
                        return;
                    }
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string regNumber = UserProc.getRegNumber();
            string rKey = Settings.Default.rKey;//119BFFCF8
                                                //UserProc.EncryptDES("", );
            //Settings.Default.rtime = DateTime.Now.ToString("yy-MM-dd hh:mm:ss");
            //Settings.Default.Save();
            /*
            if (Settings.Default.rtime == "")
            {
                Settings.Default.rtime = DateTime.Now.ToString("yy-MM-dd hh:mm:ss");
                Settings.Default.Save();
                MessageBox.Show("本软件为测试版本，有效期为1天");
            }

            if (Settings.Default.rtime.CompareTo(DateTime.Now.AddDays(-1).ToString("yy-MM-dd hh:mm:ss")) < 0 )
            {
                MessageBox.Show("有效期超过48小时，请联系作者");
                return;
            }
            */
            if (UserProc.getSerialNumber() != "119BFFCF7")
            {
                if (rKey == "")
                {
                    FormRes frmReg = new FormRes();
                    int num = (int)frmReg.ShowDialog();
                    if (frmReg.DialogResult == DialogResult.Yes)
                    {
                        //Application.Run(new Form1());
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    //Application.Run(new Form1());
                }
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

            //Application.Run(new Form1());
            try
            {
                SqlSugarClient db = SqlBase.GetInstance();
                //using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DBconn))
                {
                    //sqlConnection.Open();
                    //SqlCommand command = sqlConnection.CreateCommand();
                    string CommandText = "select a.name from sys.triggers a where a.is_disabled = 1";
                    //SqlDataReader sqlDataReader1 = command.ExecuteReader();
                    DataTable dataTable = db.Ado.GetDataTable(CommandText);//new DataTable();
                    //dataTable.Load((IDataReader)sqlDataReader1);
                    if (dataTable.Rows.Count > 0)
                    {
                        string str1 = "";
                        for (int index = 0; index < dataTable.Rows.Count; ++index)
                            str1 = str1 + dataTable.Rows[index].Field<string>("name") + ",";
                        string str2 = str1.TrimEnd(',');
                        //sqlDataReader1.Close();
                        //sqlDataReader1.Dispose();
                        //command.Dispose();
                        dataTable.Dispose();
                        int num = (int)MessageBox.Show("触发器(" + str2 + ")被禁用,软件无法启动,请联系开发人员!", "严重错误!");
                        Process.GetCurrentProcess().Kill();
                    }
                    //sqlDataReader1.Close();
                    dataTable.Clear();
                    string aCommandText = "select GETDATE() as srvTime";
                    //SqlDataReader sqlDataReader2 = command.ExecuteReader();
                    DataTable dataTable1 = db.Ado.GetDataTable(aCommandText);
                    //sqlDataReader2.Read();
                    DateTime dateTime = (DateTime)dataTable1.Rows[0]["srvTime"];
                    //sqlDataReader2.Close();
                    //sqlDataReader2.Dispose();
                    //command.Dispose();
                    dataTable.Dispose();
                    dataTable1.Dispose();
                    dataTable.Dispose();
                    if (DateTime.Now < dateTime.AddMinutes(-30.0) || DateTime.Now > dateTime.AddMinutes(30.0))
                    {
                        int num = (int)MessageBox.Show("本机日期与时间不对\r\n\r\n服务器时间:" + dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n\r\n  本机时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n\r\n           请核对!", "提示");
                        Process.GetCurrentProcess().Kill();
                    }
                }
            }
            catch(Exception ex)
            {
                int num = (int)MessageBox.Show("服务器连接失败!!!"+ ex.Message, "提示");
                Process.GetCurrentProcess().Kill();
                return;
            }
            if (Settings.Default.DiLiao)
                Application.Run((Form)new frmDL());
            else if (Settings.Default.ChengLiao)
            {
                Application.Run((Form)new frmCL());
            }
            else
            {
                if(Settings.Default.islogin.Length == 0)
                {
                    FrmLogin frmLogin = new FrmLogin(false);
                    int num = (int)frmLogin.ShowDialog();
                    if (frmLogin.DialogResult == DialogResult.OK)
                    {
                        //    frmLogin.Close();
                        Application.Run((Form)new Form1());
                    }
                }
                else
                {
                    Application.Run((Form)new Form1());
                }
                //else
                {
                //    frmLogin.Close();
                    Process.GetCurrentProcess().Kill();
                }
            }
        }
    }
}

using DotNetBarProject.DL;
using DotNetBarProject.Properties;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace DotNetBarProject.ChenLiao
{
    public partial class frmCL : Form
    {
        private string jihao = Settings.Default.CLjihao;
        private List<clsCheng> cheng = new List<clsCheng>();
        private clsPLCcl plcCL = new clsPLCcl();
        private System.Windows.Forms.Timer CLtimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timerShowTime = new System.Windows.Forms.Timer();
        private SoundPlayer TSsound = new SoundPlayer();
        private frmCL.enumSta _staCL = frmCL.enumSta.显示空白;
        private int CLdeng = 0;
        private string CLrl = "";
        private Decimal CLzlmb = new Decimal(0);
        private int CLcheng = -1;
        private Decimal CLzlyc = new Decimal(-1);
        private Decimal CLzlmc = new Decimal(0);
        private Decimal CLzlpz = new Decimal(0);
        private int CLerrTPcount = 0;
        private int CLokCount = 0;
        private bool CLallowKey = false;

        private SqlSugarClient db;
        private enum enumSta
        {
            显示空白,
            显示有料,
            称料正在,
        }
        private frmCL.enumSta staCL
        {
            get
            {
                return this._staCL;
            }
            set
            {
                this._staCL = value;
                switch (this._staCL)
                {
                    case frmCL.enumSta.显示空白:
                        this.lblCLdh.Text = "";
                        this.lblCLrlname.Text = "";
                        this.lblCLyc.Text = "";
                        this.lblCLmbzl.Text = "";
                        this.lblCLmcpz.Text = "";
                        this.lblCLcheng.Text = "";
                        this.lblCLzl.Text = "";
                        this.lblCLwd.Text = "";
                        this.lblCLwc.Text = "";
                        this.pBarCL.Value = 0;
                        this.lblBtnSch.BackColor = Color.DarkCyan;
                        this.lblBtnSch.ForeColor = Color.White;
                        this.lblBtnMC.BackColor = Color.DimGray;
                        this.lblBtnMC.ForeColor = Color.Gray;
                        this.lblTS.Text = "空 白 料 单 ！无 染 料 助 剂 显 示";
                        break;
                    case frmCL.enumSta.显示有料:
                        this.lblCLmcpz.Text = "";
                        this.lblCLzl.Text = "";
                        this.lblCLwd.Text = "";
                        this.lblCLwc.Text = "";
                        this.pBarCL.Value = 0;
                        this.lblBtnSch.BackColor = Color.DarkCyan;
                        this.lblBtnSch.ForeColor = Color.White;
                        this.lblBtnMC.BackColor = Color.DimGray;
                        this.lblBtnMC.ForeColor = Color.Gray;
                        this.lblTS.Text = "“上翻/下翻”选择染助剂,“确认”开始称料(放好料桶)！";
                        break;
                    case frmCL.enumSta.称料正在:
                        this.lblBtnSch.BackColor = Color.DimGray;
                        this.lblBtnSch.ForeColor = Color.Gray;
                        this.lblBtnMC.BackColor = Color.DarkCyan;
                        this.lblBtnMC.ForeColor = Color.White;
                        this.lblTS.Text = "请注意,正在称料中！“清除”取消称料！";
                        break;
                }
            }
        }
        public frmCL()
        {
            InitializeComponent();
            db = SqlBase.GetInstance();
            timerShowTime.Enabled = true;
            timerShowTime.Interval = 1000;
            timerShowTime.Tick += new EventHandler(this.timerShowTime_Tick);
            lblGS.Text = UserProc.GSname + " 配方与称料控制系统";
            lblBB.Text = "ver:" + UserProc.StrVer;
            if (Settings.Default.paraKeyB == 18)
            {
                lblBtnSch.Text = "查询料单(F1)";
                lblBtnMC.Text = "免称扣除(F2)";
            }
            else
            {
                lblBtnSch.Text = "查询料单( • )";
                lblBtnMC.Text = "免称扣除(上翻)";
            }
            this.dgvData.Dock = DockStyle.Fill;
            this.txtJH.txt.TextAlign = HorizontalAlignment.Center;
            this.txtSL.txt.TextAlign = HorizontalAlignment.Center;
            this.txtZL.txt.TextAlign = HorizontalAlignment.Center;
            this.txtJH.txt.ForeColor = Color.DarkRed;
            this.txtSL.txt.ForeColor = Color.DarkRed;
            this.txtZL.txt.ForeColor = Color.DarkRed;
            this.lblDate.Text = "";
            this.lblKeyS.Text = "";
            this.lblTPerr.Text = "";
        }
        private void lblExit_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            this.Close();
        }
        private void this_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int index = 0; index < this.cheng.Count; ++index)
            {
                if (this.cheng[index] != null)
                {
                    if (this.cheng[index].IsOpen)
                        this.cheng[index].com_close();
                    this.cheng[index].Dispose();
                }
            }
            if (this.plcCL.IsOpen)
            {
                this.plcCL.com_close();
                this.plcCL.Dispose();
            }
            if (this.TSsound == null)
                return;
            this.TSsound.Stop();
            this.TSsound.Dispose();
        }

        private void emptyLD()
        {
            this.txtLDH.Text = "";
            this.txtKH.txt.Text = "";
            this.txtSZ.txt.Text = "";
            this.txtDDH.txt.Text = "";
            this.txtSH.txt.Text = "";
            this.txtYS.txt.Text = "";
            this.txtMS.txt.Text = "";
            this.txtDJ.txt.Text = "";
            this.txtKZ.txt.Text = "";
            this.txtJH.txt.Text = "";
            this.txtSL.txt.Text = "";
            this.txtZL.txt.Text = "";
            this.dgvData.Rows.Clear();
            this.lblRowCount.Text = "合计 0 条";
        }
        private void this_Load(object sender, EventArgs e)
        {
            this.staCL = frmCL.enumSta.显示空白;
            this.emptyLD();
        }
        private void this_Shown(object sender, EventArgs e)
        {
            if (!this.cheng_plc_init())
            {
                this.Close();
            }
            else
            {
                this.plcCL.OpenDeng(0);
                this.col1.Width = this.dgvDH.Width / 8;
                this.col2.Width = this.col1.Width;
                this.col3.Width = this.col1.Width;
                this.col4.Width = this.col1.Width;
                this.col5.Width = this.col1.Width;
                this.col6.Width = this.col1.Width;
                this.col7.Width = this.col1.Width;
                this.col8.Width = this.col1.Width;
                this.dgvDH.Rows.Add(6);
                this.showDeng();
                this.CLtimer.Tick += new EventHandler(this.CLtimer_Tick);
                this.KeyUp += new KeyEventHandler(this.this_KeyUp);
                this.lblBtnSch.Focus();
            }
        }
        private bool cheng_plc_init()
        {
            //DBpf dbpf = new DBpf(Settings.Default.DBconn);
            //T_Base tBase = dbpf.T_Base.Where<T_Base>((Expression<Func<T_Base, bool>>)(a => a.leibie == PeiFang.BaseItem.leibie.enumLB.称料设置.ToString() && a.bianhao == this.jihao)).SingleOrDefault<T_Base>();
            T_Base tBase = db.Queryable<T_Base>()
                .Where(a => a.leibie == "称料设置" && a.bianhao == this.jihao)
                .First();
            //dbpf.Dispose();
            if (tBase == null)
            {
                frmError frmError = new frmError("无法找到本机台参数设置数据!!!");
                int num = (int)frmError.ShowDialog((IWin32Window)this);
                frmError.Close();
                return false;
            }
            for (int index = 0; index < 4; ++index)
            {
                string str1;
                string str2;
                string[] CLparaCheng = Settings.Default.CLparaCheng.Split('|');
                if (index == 0)
                {
                    str1 = tBase.item1;
                    str2 = CLparaCheng[0];
                }
                else if (index == 1)
                {
                    str1 = tBase.item2;
                    str2 = CLparaCheng[1];
                }
                else if (index == 2)
                {
                    str1 = tBase.item3;
                    str2 = CLparaCheng[2];
                }
                else
                {
                    str1 = tBase.item4;
                    str2 = CLparaCheng[3];
                }
                if (str1 != "" && str2 != "")
                {
                    string[] strArray1 = str1.Split(',');
                    string[] strArray2 = str2.Split(',');
                    if (strArray1.Length != 7)
                    {
                        frmError frmError = new frmError((index + 1).ToString() + " 号电子称参数设置错误!!!");
                        int num = (int)frmError.ShowDialog((IWin32Window)this);
                        frmError.Close();
                        return false;
                    }
                    if (strArray2.Length != 8)
                    {
                        frmError frmError = new frmError((index + 1).ToString() + " 号电子称通讯设置错误!!!");
                        int num = (int)frmError.ShowDialog((IWin32Window)this);
                        frmError.Close();
                        return false;
                    }
                    if (index > 0 && this.cheng[index - 1] == null)
                    {
                        frmError frmError = new frmError("请按小到大设置电子称!!!");
                        int num = (int)frmError.ShowDialog((IWin32Window)this);
                        frmError.Close();
                        return false;
                    }
                    clsCheng clsCheng = new clsCheng();
                    try
                    {
                        StruChengPara struChengPara = new StruChengPara()
                        {
                            chengXH = (enumCheng)Enum.Parse(typeof(enumCheng), strArray1[0]),
                            JingDu = Convert.ToDecimal(strArray1[1]),
                            MaxCL = Convert.ToDecimal(strArray1[2]),
                            WuCha = Convert.ToDecimal(strArray1[3]),
                            WuChaPG = strArray1[4],
                            OKci = (int)Convert.ToInt16(strArray1[5]),
                            OKwd = !(strArray1[6] == "0"),
                            zeroCi = Convert.ToInt32(strArray2[4]),
                            zeroWD = !(strArray2[5] == "False"),
                            scanSpeed = Convert.ToInt32(strArray2[6]),
                            zeroSpeed = Convert.ToInt32(strArray2[7])
                        };
                        clsCheng.chengPara = struChengPara;
                        clsCheng.PortName = strArray2[0];
                        clsCheng.BaudRate = Convert.ToInt32(strArray2[1]);
                        clsCheng.DataBits = Convert.ToInt32(strArray2[2]);
                        clsCheng.Parity = strArray2[3] == "Odd" ? Parity.Odd : (strArray2[3] == "Even" ? Parity.Even : Parity.None);
                        clsCheng.com_open();
                        this.cheng.Add(clsCheng);
                    }
                    catch
                    {
                        frmError frmError = new frmError("串口 " + (index + 1).ToString() + " 错误!!!");
                        int num = (int)frmError.ShowDialog((IWin32Window)this);
                        frmError.Close();
                        return false;
                    }
                }
                else if (index == 0)
                {
                    frmError frmError = new frmError("串口 " + (index + 1).ToString() + " 参数设置错误!!!");
                    int num = (int)frmError.ShowDialog((IWin32Window)this);
                    frmError.Close();
                    return false;
                }
            }
            string[] strArray = Settings.Default.CLparaPLC.Split(',');
            if (strArray.Length != 5)
            {
                frmError frmError = new frmError("PLC 参数设置错误!!!");
                int num = (int)frmError.ShowDialog((IWin32Window)this);
                frmError.Close();
                return false;
            }
            try
            {
                this.plcCL.PortName = strArray[0];
                this.plcCL.BaudRate = Convert.ToInt32(strArray[1]);
                this.plcCL.DataBits = Convert.ToInt32(strArray[2]);
                this.plcCL.Parity = strArray[3] == "Odd" ? Parity.Odd : Parity.Even;
                this.plcCL.RWokReadDelay = Convert.ToInt32(strArray[4]);
                this.plcCL.com_open();
            }
            catch
            {
                frmError frmError = new frmError("PLC 打开错误!!!");
                int num = (int)frmError.ShowDialog((IWin32Window)this);
                frmError.Close();
                return false;
            }
            return true;
        }
        private void showDeng()
        {
            //using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DBconn))
            {
                //sqlConnection.Open();
                //SqlCommand command = sqlConnection.CreateCommand();
                //command.CommandTimeout = 300;
                string CommandText = "select * from T_Base where leibie = '称料灯号' and bianhao = '" + this.jihao + "' order by item0";
                //SqlDataReader sqlDataReader = command.ExecuteReader();
                DataTable dataTable = db.Ado.GetDataTable(CommandText);
                //dataTable.Load((IDataReader)sqlDataReader);
                for (int index = 0; index < dataTable.Rows.Count; ++index)
                {
                    int int32 = Convert.ToInt32(dataTable.Rows[index].Field<string>("item0"));
                    if (int32 >= 1 && int32 <= 48)
                    {
                        int num = int32 - 1;
                        this.dgvDH.Rows[num / 8].Cells[num % 8].Value = (object)(dataTable.Rows[index].Field<string>("item0") + "." + dataTable.Rows[index].Field<string>("item1"));
                    }
                }
                for (int index = 0; index < this.dgvDH.RowCount * this.dgvDH.ColumnCount; ++index)
                {
                    DataGridViewCell cell = this.dgvDH.Rows[index / 8].Cells[index % 8];
                    if (cell.FormattedValue.ToString() == "")
                        cell.Value = (object)((index + 1).ToString() + ".");
                }
                //sqlDataReader.Close();
                //sqlDataReader.Dispose();
                //command.Dispose();
                dataTable.Dispose();
            }
            this.dgvDH.CurrentCell = (DataGridViewCell)null;
        }
        private void timerShowTime_Tick(object sender, EventArgs e)
        {
            this.lblDate.Text = DateTime.Now.ToString("yyyy年M月d日 HH:mm:ss");
        }
        private void CLtimer_Tick(object sender, EventArgs e)
        {
            this.CLtimer.Stop();
            if (this.lblTS.ForeColor == Color.DarkRed)
                this.lblTS.ForeColor = Color.Yellow;
            else
                this.lblTS.ForeColor = Color.DarkRed;
            if (this.CLdeng > 0)
            {
                DataGridViewCell cell = this.dgvDH.Rows[(this.CLdeng - 1) / 8].Cells[(this.CLdeng - 1) % 8];
                cell.Style.BackColor = !(cell.Style.BackColor == Color.Red) ? Color.Red : Color.Green;
            }
            this.cheng[this.CLcheng].getVal();
            this.lblCLzl.Text = !this.cheng[this.CLcheng].showVal.HasValue ? "无值" : this.cheng[this.CLcheng].showVal.Value.ToString("0.### g");
            this.lblCLwd.Text = this.cheng[this.CLcheng].WenDing ? "稳定" : "";
            if (!this.cheng[this.CLcheng].showVal.HasValue)
            {
                this.lblCLzl.Text = "";
                this.lblCLwd.Text = "";
                this.lblCLwc.Text = this.lblCLmbzl.Text;
                ++this.CLerrTPcount;
                if (this.CLerrTPcount >= 3)
                {
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                    this.TSsound.Play();
                    this.lblTS.Visible = false;
                    frmTS frmTs = new frmTS(this.CLrl, this.CLcheng, this.CLdeng, "电子称读取失败,检查设备!!!", "“确认”再试一次", "“清除”取消称料", Keys.Back);
                    DialogResult dialogResult = frmTs.ShowDialog((IWin32Window)this);
                    frmTs.Close();
                    this.lblTS.Visible = true;
                    if (dialogResult == DialogResult.OK)
                    {
                        this.CLerrTPcount = 0;
                        this.CLokCount = 0;
                        this.lblTPerr.Text = "";
                    }
                    else
                    {
                        this.CLend();
                        return;
                    }
                }
                this.CLtimer.Start();
            }
            else
            {
                this.CLerrTPcount = 0;
                this.lblTPerr.Text = "";
                Decimal num1 = this.cheng[this.CLcheng].showVal.Value;
                this.lblCLwc.Text = (this.CLzlmb - num1).ToString("0.####克");
                if (this.CLzlmb > new Decimal(0))
                {
                    int num2 = (int)(num1 / this.CLzlmb * new Decimal(100));
                    this.pBarCL.Value = num2 < 0 ? 0 : (num2 > 100 ? 100 : num2);
                }
                else
                    this.pBarCL.Value = 100;
                if (num1 >= this.CLzlmb - this.CLzlyc && num1 <= this.CLzlmb + this.CLzlyc)
                {
                    if (this.TSsound.SoundLocation != Application.StartupPath + "\\Sound\\CLok.wav")
                    {
                        this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\CLok.wav";
                        this.TSsound.PlayLooping();
                    }
                }
                else if (num1 >= -this.cheng[this.CLcheng].chengPara.JingDu && num1 <= this.cheng[this.CLcheng].chengPara.JingDu)
                {
                    if (this.TSsound.SoundLocation != Application.StartupPath + "\\Sound\\CLbegin.wav")
                    {
                        this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\CLbegin.wav";
                        this.TSsound.PlayLooping();
                    }
                }
                else if (num1 > this.CLzlmb + this.CLzlyc)
                {
                    if (this.TSsound.SoundLocation != Application.StartupPath + "\\Sound\\CLover.wav")
                    {
                        this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\CLover.wav";
                        this.TSsound.PlayLooping();
                    }
                }
                else if (num1 < this.CLzlmb - this.cheng[this.CLcheng].chengPara.JingDu * new Decimal(200))
                {
                    if (this.TSsound.SoundLocation != Application.StartupPath + "\\Sound\\CLfar.wav")
                    {
                        this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\CLfar.wav";
                        this.TSsound.PlayLooping();
                    }
                }
                else if (num1 >= this.CLzlmb - this.cheng[this.CLcheng].chengPara.JingDu * new Decimal(200) && this.TSsound.SoundLocation != Application.StartupPath + "\\Sound\\CLnear.wav")
                {
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\CLnear.wav";
                    this.TSsound.PlayLooping();
                }
                if (num1 < this.CLzlmb - this.CLzlyc || num1 > this.CLzlmb + this.CLzlyc || this.cheng[this.CLcheng].chengPara.OKwd && !this.cheng[this.CLcheng].WenDing)
                    this.CLokCount = 0;
                else
                    ++this.CLokCount;
                if (this.CLokCount >= this.cheng[this.CLcheng].chengPara.OKci)
                {
                    this.CLsave();
                    this.dgvData.CurrentRow.Cells[this.colCL.Name].Value = (object)(this.dgvData.CurrentRow.Cells[this.colCL.Name].FormattedValue.ToString() == "" ? num1 + this.CLzlmc - this.CLzlpz : (Decimal)this.dgvData.CurrentRow.Cells[this.colCL.Name].Value + num1 + this.CLzlmc - this.CLzlpz);
                    if (this.dgvData.CurrentRow.Index < this.dgvData.RowCount - 1)
                    {
                        this.dgvData.CurrentCell = this.dgvData.Rows[this.dgvData.CurrentRow.Index + 1].Cells[this.colRL.Name];
                        Application.DoEvents();
                    }
                    else
                    {
                        this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                        this.TSsound.Play();
                        frmCLend frmClend = new frmCLend();
                        int num2 = (int)frmClend.ShowDialog((IWin32Window)this);
                        frmClend.Close();
                    }
                    this.CLend();
                }
                else
                    this.CLtimer.Start();
            }
        }
        private bool CLsave()
        {
            try
            {
                //DBpf dbpf = new DBpf(Settings.Default.DBconn);
                T_PFcheng entity = new T_PFcheng()
                {
                    danhao = this.txtLDH.Text,
                    cishu = 0,
                    SNdata = (long)this.dgvData.CurrentRow.Cells[this.colSN.Name].Value,
                    ranliao = this.CLrl,
                    chengliang = this.cheng[this.CLcheng].showVal.Value,
                    chengmian = this.CLzlmc,
                    chengpi = this.CLzlpz,
                    chengliangdanwei = "g",
                    riqicheng = DateTime.Now,
                    beizhu = ""
                };
                db.Insertable<T_PFcheng>(entity).ExecuteCommand();
                //dbpf.T_PFcheng.InsertOnSubmit(entity);
                //dbpf.SubmitChanges();
                //dbpf.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void CLend()
        {
            this.CLdeng = 0;
            this.CLrl = "";
            this.CLzlmb = new Decimal(0);
            this.CLcheng = -1;
            this.CLzlyc = new Decimal(-1);
            this.CLzlmc = new Decimal(0);
            this.CLzlpz = new Decimal(0);
            this.CLerrTPcount = 0;
            this.CLokCount = 0;
            this.CLallowKey = false;
            for (int index = 0; index < this.dgvDH.RowCount * this.dgvDH.ColumnCount; ++index)
                this.dgvDH.Rows[index / 8].Cells[index % 8].Style.BackColor = Color.LightGray;
            this.CLtimer.Stop();
            this.TSsound.Stop();
            if (!this.plcCL.OpenDeng(0))
                this.plcCL.OpenDeng(0);
            this.lblTS.ForeColor = Color.DarkRed;
            this.staCL = frmCL.enumSta.显示有料;
            this.showRow();
        }
        private bool showRow()
        {
            this.CLdeng = this.dgvData.CurrentRow.Cells[this.colDH.Name].FormattedValue.ToString() == "" ? 0 : (int)Convert.ToInt16(this.dgvData.CurrentRow.Cells[this.colDH.Name].FormattedValue.ToString());
            this.CLrl = this.dgvData.CurrentRow.Cells[this.colRL.Name].FormattedValue.ToString();
            this.CLzlmb = (Decimal)this.dgvData.CurrentRow.Cells[this.colYL.Name].Value;
            for (int index = 0; index < this.cheng.Count; ++index)
            {
                if (index == this.cheng.Count - 1 || this.cheng[index].chengPara.MaxCL > this.CLzlmb)
                {
                    this.CLcheng = index;
                    break;
                }
            }
            if (this.cheng[this.CLcheng].chengPara.WuChaPG == "g")
            {
                this.CLzlyc = this.cheng[this.CLcheng].chengPara.WuCha;
            }
            else
            {
                this.CLzlyc = this.CLzlmb * this.cheng[this.CLcheng].chengPara.WuCha / new Decimal(100);
                if (this.CLzlyc < this.cheng[this.CLcheng].chengPara.JingDu)
                    this.CLzlyc = this.cheng[this.CLcheng].chengPara.JingDu;
            }
            this.CLzlmc = new Decimal(0);
            this.CLzlpz = new Decimal(0);
            this.CLerrTPcount = 0;
            this.CLokCount = 0;
            this.CLallowKey = false;
            this.lblCLdh.Text = this.CLdeng == 0 ? "(无指示灯)" : "(" + this.CLdeng.ToString() + "号灯)";
            this.lblCLrlname.Text = this.CLrl;
            this.lblCLyc.Text = "( 允差:±" + this.CLzlyc.ToString("0.####") + "克 )";
            this.lblCLmbzl.Text = this.CLzlmb.ToString("0.####克");
            this.lblCLmcpz.Text = "";
            this.lblCLcheng.Text = "( " + (this.CLcheng + 1).ToString() + " 号称 )";
            this.lblCLzl.Text = "";
            this.lblCLwd.Text = "";
            this.lblCLwc.Text = "";
            this.pBarCL.Value = 0;
            return true;
        }
        private bool showLD(string showLDH)
        {
            this.emptyLD();
            DataTable dataTable1 = new DataTable();
            DataTable dataTable2 = new DataTable();
            //using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DBconn))
            {
                //sqlConnection.Open();
                //SqlCommand command = sqlConnection.CreateCommand();
                //command.CommandTimeout = 300;
                string CommandText = "select * from T_PFmain where danhao = '" + showLDH + "' and sta = '已审核'";
                //SqlDataReader sqlDataReader1 = command.ExecuteReader();
                dataTable1 = db.Ado.GetDataTable(CommandText);
                string sql;
                if (showLDH.StartsWith("LD") || showLDH.Length == 10 && showLDH.StartsWith("8"))
                {
                    this.colYL.HeaderText = "用量";
                    sql = "select a.*,YL=case when a.yongliangDW in('g','mL') then a.yongliang else a.yongliang*1000 end,deng=b.item0,clval=(select sum(chengliang+chengmian-chengpi) from T_PFcheng where SNdata=a.SN) from T_PFdata a left join T_Base b on a.ranliao = b.item1 and b.leibie = '称料灯号' and b.bianhao = '" + this.jihao + "' where a.danhao = '" + showLDH + "' and a.ranliao in(select item0 from T_Base where leibie = '染料名称') and a.yongliang > 0 order by a.gongxu,YL";
                }
                else
                {
                    this.colYL.HeaderText = "加料用量";
                    sql = "select a.*,YL=case when a.JLyongliangDW in('g','mL') then JLyongliang else a.JLyongliang*1000 end,deng=b.item0 clval=(select sum(chengliang+chengmian-chengpi) from T_PFcheng where SNdata=a.SN) from T_PFdata a left join T_Base b on a.ranliao = b.item1 and b.leibie = '称料灯号' and b.bianhao = '" + this.jihao + "' where a.danhao = '" + showLDH + "' and a.ranliao in(select item0 from T_Base where leibie = '染料名称') and a.JLyongliang > 0 order by a.gongxu,YL";
                }
                //SqlDataReader sqlDataReader2 = command.ExecuteReader();
                dataTable2 = db.Ado.GetDataTable(sql);
                //sqlDataReader2.Close();
                //sqlDataReader2.Dispose();
                //command.Dispose();
            }
            this.txtLDH.Text = dataTable1.Rows[0].Field<string>("danhao");
            this.txtKH.txt.Text = dataTable1.Rows[0].Field<string>("kehu");
            this.txtSZ.txt.Text = dataTable1.Rows[0].Field<string>("shazhong");
            this.txtDDH.txt.Text = dataTable1.Rows[0].Field<string>("dingdan");
            this.txtSH.txt.Text = dataTable1.Rows[0].Field<string>("sehao");
            this.txtYS.txt.Text = dataTable1.Rows[0].Field<string>("yanse");
            this.txtMS.txt.Text = dataTable1.Rows[0].Field<Decimal>("mishu").ToString("0.###;-0.###;\"\"");
            this.txtDJ.txt.Text = dataTable1.Rows[0].Field<Decimal>("danjia").ToString("0.###;-0.###;\"\"");
            //this.txtKZ.txt.Text = dataTable1.Rows[0].Field<Decimal>("kezhong").ToString("0.###;-0.###;\"\"");
            this.txtJH.txt.Text = dataTable1.Rows[0].Field<string>("jihao");
            this.txtSL.txt.Text = dataTable1.Rows[0].Field<Decimal>("shuiliang").ToString("0.####;-0.####;\"\"");
            this.txtZL.txt.Text = dataTable1.Rows[0].Field<Decimal>("zhongliang").ToString("0.####;-0.####;\"\"");
            for (int index = 0; index < dataTable2.Rows.Count; ++index)
            {
                this.dgvData.Rows.Add();
                DataGridViewRow row = this.dgvData.Rows[this.dgvData.RowCount - 1];
                row.Cells[this.colBH.Name].Value = (object)(index + 1).ToString();
                row.Cells[this.colSN.Name].Value = (object)dataTable2.Rows[index].Field<long>("SN");
                row.Cells[this.colGX.Name].Value = (object)dataTable2.Rows[index].Field<string>("gongxu");
                row.Cells[this.colRL.Name].Value = (object)dataTable2.Rows[index].Field<string>("ranliao");
                row.Cells[this.colYL.Name].Value = (object)dataTable2.Rows[index].Field<Decimal>("YL");
                row.Cells[this.colDW.Name].Value = (object)"g";
                row.Cells[this.colCL.Name].Value = (object)dataTable2.Rows[index].Field<Decimal?>("clval");
                row.Cells[this.colCLDW.Name].Value = (object)"g";
                row.Cells[this.colDH.Name].Value = (object)Convert.ToInt16(dataTable2.Rows[index].Field<string>("deng"));
            }
            dataTable1.Dispose();
            dataTable2.Dispose();
            this.lblRowCount.Text = "合计 " + this.dgvData.RowCount.ToString() + " 条";
            return true;
        }

        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.staCL == frmCL.enumSta.显示空白 || this.staCL == frmCL.enumSta.显示有料)
            {
                this.lblKeyS.Text += e.KeyValue.ToString("X2");
                Application.DoEvents();
                if (Settings.Default.paraKeyB == 18 && e.KeyCode == Keys.F1 || Settings.Default.paraKeyB == 16 && (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal))
                {
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\ding.wav";
                    this.TSsound.Play();
                    frmCLsch frmClsch = Settings.Default.paraKeyB != 18 ? new frmCLsch("“返回”退出", Keys.Escape) : new frmCLsch("“F2”退出", Keys.F2);
                    DialogResult dialogResult = frmClsch.ShowDialog((IWin32Window)this);
                    frmClsch.Close();
                    if (dialogResult == DialogResult.OK)
                    {
                        if (this.showLD(frmClsch.txtSch.Text))
                        {
                            this.staCL = frmCL.enumSta.显示有料;
                            this.dgvData.CurrentCell = this.dgvData.Rows[0].Cells[this.colRL.Name];
                            this.showRow();
                        }
                        else
                            this.staCL = frmCL.enumSta.显示空白;
                    }
                    this.lblKeyS.Text = "";
                }
                else if (e.KeyCode == Keys.Prior)
                {
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\ding.wav";
                    this.TSsound.Play();
                    if (this.dgvData.CurrentCell != null)
                    {
                        int rowIndex = this.dgvData.CurrentCell.RowIndex;
                        if (rowIndex > 0)
                        {
                            this.dgvData.CurrentCell = this.dgvData.Rows[rowIndex - 1].Cells[this.colRL.Name];
                            this.showRow();
                        }
                    }
                    this.lblKeyS.Text = "";
                }
                else if (e.KeyCode == Keys.Next)
                {
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\ding.wav";
                    this.TSsound.Play();
                    if (this.dgvData.CurrentCell != null)
                    {
                        int rowIndex = this.dgvData.CurrentCell.RowIndex;
                        if (rowIndex < this.dgvData.RowCount - 1)
                        {
                            this.dgvData.CurrentCell = this.dgvData.Rows[rowIndex + 1].Cells[this.colRL.Name];
                            this.showRow();
                        }
                    }
                    this.lblKeyS.Text = "";
                }
                else
                {
                    if (e.KeyCode != Keys.Return)
                        return;
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\ding.wav";
                    this.TSsound.Play();
                    if (this.staCL == frmCL.enumSta.显示有料 && this.lblKeyS.Text.Length == 2)
                        this.CLstart();
                    this.lblKeyS.Text = "";
                }
            }
            else
            {
                if (this.staCL != frmCL.enumSta.称料正在 || !this.CLallowKey)
                    return;
                if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
                {
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\ding.wav";
                    this.TSsound.Play();
                    this.CLtimer.Stop();
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\ding.wav";
                    this.TSsound.Play();
                    this.lblTS.Visible = false;
                    frmTS frmTs = Settings.Default.paraKeyB != 18 ? new frmTS(this.CLrl, this.CLcheng, this.CLdeng, "确定取消称料吗!!!", "“确认”退出称料", "“返回”继续称料", Keys.Escape) : new frmTS(this.CLrl, this.CLcheng, this.CLdeng, "确定取消称料吗!!!", "“确认”退出称料", "“ F2 ”继续称料", Keys.F2);
                    DialogResult dialogResult = frmTs.ShowDialog((IWin32Window)this);
                    frmTs.Close();
                    this.lblTS.Visible = true;
                    switch (dialogResult)
                    {
                        case DialogResult.OK:
                            if (this.cheng[this.CLcheng].showVal.Value > new Decimal(0))
                            {
                                this.CLzlmb = new Decimal(0);
                                this.CLzlpz = new Decimal(0);
                                this.CLsave();
                                this.dgvData.CurrentRow.Cells[this.colCL.Name].Value = (object)(this.dgvData.CurrentRow.Cells[this.colCL.Name].FormattedValue.ToString() == "" ? this.cheng[this.CLcheng].showVal.Value : (Decimal)this.dgvData.CurrentRow.Cells[this.colCL.Name].Value + this.cheng[this.CLcheng].showVal.Value);
                            }
                            this.CLend();
                            break;
                        case DialogResult.Cancel:
                            this.CLtimer.Start();
                            break;
                    }
                }
                else if (Settings.Default.paraKeyB == 18 && e.KeyCode == Keys.F2 || Settings.Default.paraKeyB == 16 && e.KeyCode == Keys.Prior)
                {
                    this.CLtimer.Enabled = false;
                    frmCLinputMC frmClinputMc = new frmCLinputMC((Decimal)this.dgvData.CurrentRow.Cells[this.colYL.Name].Value, "“确认”应用免称", "“返回”退出输入", Keys.Escape);
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\ding.wav";
                    this.TSsound.Play();
                    if (frmClinputMc.ShowDialog((IWin32Window)this) == DialogResult.OK)
                    {
                        this.CLzlmc = Convert.ToDecimal(frmClinputMc.txtZL.Text);
                        this.CLzlmb = (Decimal)this.dgvData.CurrentRow.Cells[this.colYL.Name].Value - this.CLzlmc + this.CLzlpz;
                        this.lblCLmbzl.Text = this.CLzlmb.ToString("0.####克");
                        this.lblCLmcpz.Text = (this.CLzlmc == new Decimal(0) ? "" : "(免称:" + this.CLzlmc.ToString("0.####克") + ")") + (this.CLzlpz == new Decimal(0) ? "" : "(皮重:" + this.CLzlpz.ToString("0.####克") + ")");
                    }
                    frmClinputMc.Close();
                    this.CLtimer.Enabled = true;
                }
            }
        }
        private void CLstart()
        {
            if (this.dgvData.CurrentRow.Index < 0)
            {
                this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                this.TSsound.Play();
                frmError frmError = new frmError("当前称料行不存在!请再次查询!");
                int num = (int)frmError.ShowDialog((IWin32Window)this);
                frmError.Close();
            }
            else
            {
                //DBpf dbpf = new DBpf(Settings.Default.DBconn);
                //T_PFmain tPfmain = dbpf.T_PFmain.Where<T_PFmain>((Expression<Func<T_PFmain, bool>>)(a => a.danhao == this.txtLDH.Text)).SingleOrDefault<T_PFmain>();
                T_PFmain tPfmain = db.Queryable<T_PFmain>()
                    .Where(a => a.danhao == this.txtLDH.Text)
                    .First();
                if (tPfmain == null || tPfmain.sta != "已审核")
                {
                    //dbpf.Dispose();
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                    this.TSsound.Play();
                    frmError frmError = new frmError("料单未审核或不存在!请再次查询!");
                    int num = (int)frmError.ShowDialog((IWin32Window)this);
                    frmError.Close();
                }
                else
                {
                    //T_PFdata tPfdata = dbpf.T_PFdata.Where<T_PFdata>((Expression<Func<T_PFdata, bool>>)(a => a.SN == (long)this.dgvData.CurrentRow.Cells[this.colSN.Name].Value)).SingleOrDefault<T_PFdata>();
                    T_PFdata tPfdata = db.Queryable<T_PFdata>()
                    .Where(a => a.SN == (long)this.dgvData.CurrentRow.Cells[this.colSN.Name].Value)
                    .First();
                    if (tPfdata == null || tPfdata.ranliao != this.dgvData.CurrentRow.Cells[this.colRL.Name].Value.ToString())
                    {
                        //dbpf.Dispose();
                        this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                        this.TSsound.Play();
                        frmError frmError = new frmError("料单数据发生了改变!请再次查询!");
                        int num = (int)frmError.ShowDialog((IWin32Window)this);
                        frmError.Close();
                    }
                    else
                    {
                        Decimal num1 = new Decimal(0);
                        Decimal num2;
                        if (this.txtLDH.Text.StartsWith("LD") || this.txtLDH.Text.Length == 10 && this.txtLDH.Text.StartsWith("8"))
                        {
                            num2 = tPfdata.yongliang;
                            if (tPfdata.yongliangDW == "Kg" || tPfdata.yongliangDW == "L")
                                num2 *= new Decimal(1000);
                        }
                        else
                        {
                            num2 = tPfdata.JLyongliang;
                            if (tPfdata.JLyongliangDW == "Kg" || tPfdata.JLyongliangDW == "L")
                                num2 *= new Decimal(1000);
                        }
                        if (num2 != (Decimal)this.dgvData.CurrentRow.Cells[this.colYL.Name].Value)
                        {
                            //dbpf.Dispose();
                            this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                            this.TSsound.Play();
                            frmError frmError = new frmError("料单数据发生了改变!请再次查询!");
                            int num3 = (int)frmError.ShowDialog((IWin32Window)this);
                            frmError.Close();
                        }
                        else
                        {
                            //dbpf.Dispose();
                            if (this.dgvData.CurrentRow.Cells[this.colCL.Name].FormattedValue.ToString() != "" && Convert.ToDecimal(this.dgvData.CurrentRow.Cells[this.colCL.Name].FormattedValue.ToString()) > new Decimal(0))
                            {
                                this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                                this.TSsound.Play();
                                this.lblTS.Visible = false;
                                frmTS frmTs = new frmTS(this.CLrl, this.CLcheng, this.CLdeng, "该染料已称过，再称一次吗!!!", "“确认”再称一次", "“清除”取消称料", Keys.Back);
                                DialogResult dialogResult = frmTs.ShowDialog((IWin32Window)this);
                                frmTs.Close();
                                this.lblTS.Visible = true;
                                if (dialogResult != DialogResult.OK)
                                    return;
                            }
                            if (this.CLcheng < 0)
                            {
                                this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                                this.TSsound.Play();
                                frmError frmError = new frmError("无法找到合适的称,请核对!");
                                int num3 = (int)frmError.ShowDialog((IWin32Window)this);
                                frmError.Close();
                            }
                            else
                            {
                                if (!this.plcCL.OpenDeng(this.CLdeng))
                                    this.plcCL.OpenDeng(this.CLdeng);
                                this.staCL = frmCL.enumSta.称料正在;
                                this.CLerrTPcount = 0;
                                this.CLokCount = 0;
                                this.CLallowKey = false;
                                this.lblTPerr.Text = "";
                                this.CLzero();
                            }
                        }
                    }
                }
            }
        }
        private void CLzero()
        {
            this.lblCLzl.Text = "归零中!";
            Application.DoEvents();
            this.cheng[this.CLcheng].setZERO();
            Thread.Sleep(this.cheng[this.CLcheng].chengPara.zeroSpeed);
            this.cheng[this.CLcheng].getVal();
            Label lblClzl = this.lblCLzl;
            Decimal? showVal;
            string str;
            if (this.cheng[this.CLcheng].showVal.HasValue)
            {
                showVal = this.cheng[this.CLcheng].showVal;
                str = showVal.Value.ToString("0.### g");
            }
            else
                str = "无值";
            lblClzl.Text = str;
            this.lblCLwd.Text = this.cheng[this.CLcheng].WenDing ? "稳定" : "";
            Application.DoEvents();
            showVal = this.cheng[this.CLcheng].showVal;
            int num1;
            if (showVal.HasValue)
            {
                showVal = this.cheng[this.CLcheng].showVal;
                Decimal num2 = -this.cheng[this.CLcheng].chengPara.JingDu;
                if ((!(showVal.GetValueOrDefault() < num2) ? 0 : (showVal.HasValue ? 1 : 0)) == 0)
                {
                    showVal = this.cheng[this.CLcheng].showVal;
                    Decimal jingDu = this.cheng[this.CLcheng].chengPara.JingDu;
                    if ((!(showVal.GetValueOrDefault() > jingDu) ? 0 : (showVal.HasValue ? 1 : 0)) == 0)
                    {
                        num1 = this.cheng[this.CLcheng].WenDing ? 1 : (!this.cheng[this.CLcheng].chengPara.zeroWD ? 1 : 0);
                        goto label_8;
                    }
                }
            }
            num1 = 0;
        label_8:
            if (num1 == 0)
            {
                ++this.CLerrTPcount;
                this.CLokCount = 0;
                this.lblTPerr.Text = this.CLerrTPcount.ToString();
            }
            else
                ++this.CLokCount;
            if (this.CLerrTPcount >= 3)
            {
                this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                this.TSsound.Play();
                this.lblTS.Visible = false;
                frmTS frmTs = new frmTS(this.CLrl, this.CLcheng, this.CLdeng, "电子称归零失败,检查设备!!!", "“确认”再试一次", "“清除”取消称料", Keys.Back);
                DialogResult dialogResult = frmTs.ShowDialog((IWin32Window)this);
                frmTs.Close();
                this.lblTS.Visible = true;
                if (dialogResult == DialogResult.OK)
                {
                    this.CLerrTPcount = 0;
                    this.CLokCount = 0;
                    this.lblTPerr.Text = "";
                    this.CLzero();
                }
                else
                    this.CLend();
            }
            else if (this.CLokCount >= this.cheng[this.CLcheng].chengPara.zeroCi)
            {
                this.CLerrTPcount = 0;
                this.CLokCount = 0;
                this.CLallowKey = true;
                this.lblTPerr.Text = "";
                this.CLtimer.Interval = this.cheng[this.CLcheng].chengPara.scanSpeed;
                this.CLtimer.Start();
            }
            else
                this.CLzero();
        }
    }
}

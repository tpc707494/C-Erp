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

namespace DotNetBarProject.DL
{
    public partial class frmDL : Form
    {
        private string jihao = Settings.Default.DLjihao;
        private int tongZL = Settings.Default.DLparaTong;
        private int minDLZL = Settings.Default.DLparaMin;
        private List<clsCheng> cheng = new List<clsCheng>();
        private clsPLCdl plcDL = new clsPLCdl();
        private List<struDiTou> ditou = new List<struDiTou>();
        private System.Windows.Forms.Timer DLtimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timerShowTime = new System.Windows.Forms.Timer();
        private SoundPlayer TSsound = new SoundPlayer();
        private frmDL.enumSta _staDL = frmDL.enumSta.显示空白;
        private int DLditou = -1;
        private int DLcheng = -1;
        private string DLrl = "";
        private Decimal DLzlyl = new Decimal(0);
        private Decimal DLzlyc = new Decimal(0);
        private Decimal DLzlall = new Decimal(0);
        private Decimal DLzlmb = new Decimal(0);
        private Decimal DLzlok = new Decimal(0);
        private int DLerrTPCount = 0;
        private int DLerrPLCcount = 0;
        private int DLokCount = 0;
        private bool DLallowKey = false;


        private SqlSugarClient db;

        private enum enumSta
        {
            显示空白,
            显示有料,
            表单滴料正在,
            直接滴料正在,
        }

        private struct struDiTou
        {
            public int BianHao;
            public Decimal stopVal;
            public Decimal chuVal;
            public Decimal chuOpen;
            public Decimal chuClose;
            public Decimal xiVal;
            public Decimal xiOpen;
            public Decimal xiClose;
        }

        private frmDL.enumSta staDL
        {
            get
            {
                return this._staDL;
            }
            set
            {
                this._staDL = value;
                switch (this._staDL)
                {
                    case frmDL.enumSta.显示空白:
                        this.lblDLdt.Text = "";
                        this.lblDLrlname.Text = "";
                        this.lblDLzlmb.Text = "";
                        this.lblDLyc.Text = "";
                        this.lblDLcheng.Text = "";
                        this.lblDLzl.Text = "";
                        this.lblDLmz.Text = "";
                        this.lblDLwd.Text = "";
                        this.lblDLwc.Text = "";
                        this.pBarDL.Value = 0;
                        this.lblBtnSch.BackColor = Color.DarkCyan;
                        this.lblBtnSch.ForeColor = Color.White;
                        this.lblBtnZJDL.BackColor = Color.DarkCyan;
                        this.lblBtnZJDL.ForeColor = Color.White;
                        this.lblBtnZero.BackColor = Color.DarkCyan;
                        this.lblBtnZero.ForeColor = Color.White;
                        this.lblTS.Text = "空 白 料 单 ！无 染 料 助 剂 显 示";
                        break;
                    case frmDL.enumSta.显示有料:
                        this.lblDLzl.Text = "";
                        this.lblDLmz.Text = "";
                        this.lblDLwd.Text = "";
                        this.lblDLwc.Text = "";
                        this.pBarDL.Value = 0;
                        this.lblBtnSch.BackColor = Color.DarkCyan;
                        this.lblBtnSch.ForeColor = Color.White;
                        this.lblBtnZJDL.BackColor = Color.DarkCyan;
                        this.lblBtnZJDL.ForeColor = Color.White;
                        this.lblBtnZero.BackColor = Color.DarkCyan;
                        this.lblBtnZero.ForeColor = Color.White;
                        this.lblTS.Text = "“上翻/下翻”选择染助剂,“确认”开始滴料(放好料桶)！";
                        break;
                    case frmDL.enumSta.表单滴料正在:
                    case frmDL.enumSta.直接滴料正在:
                        this.lblBtnSch.BackColor = Color.DimGray;
                        this.lblBtnSch.ForeColor = Color.Gray;
                        this.lblBtnZJDL.BackColor = Color.DimGray;
                        this.lblBtnZJDL.ForeColor = Color.Gray;
                        this.lblBtnZero.BackColor = Color.DimGray;
                        this.lblBtnZero.ForeColor = Color.Gray;
                        this.lblTS.Text = "请注意,正在滴料中！“清除”取消滴料！";
                        break;
                }
            }
        }

        public frmDL()
        {
            InitializeComponent();
            db = SqlBase.GetInstance();
            this.timerShowTime.Enabled = true;
            this.timerShowTime.Interval = 1000;
            this.timerShowTime.Tick += new EventHandler(this.timerShowTime_Tick);
            this.lblGS.Text = UserProc.GSname + " 配方与滴料控制系统";
            this.lblBB.Text = "ver:" + ((IEnumerable<int>)UserProc.DLparaDT).Sum().ToString("00") + UserProc.StrVer;
            if (Settings.Default.paraKeyB == 18)
            {
                this.lblBtnSch.Text = "查询料单(F1)";
                this.lblBtnZJDL.Text = "直接滴料(F3)";
            }
            else
            {
                this.lblBtnSch.Text = "查询料单( • )";
                this.lblBtnZJDL.Text = "直接滴料( * )";
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
            this.lblPLCerr.Text = "";
        }
        private void timerShowTime_Tick(object sender, EventArgs e)
        {
            this.lblDate.Text = DateTime.Now.ToString("yyyy年M月d日 HH:mm:ss");
        }
        private void lblExit_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            this.Close();
        }
        private void this_Deactivate(object sender, EventArgs e)
        {
            this.Activate();
        }
        private void this_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DLtimer.Stop();
            for (int index = 0; index < this.cheng.Count; ++index)
            {
                if (this.cheng[index] != null)
                {
                    if (this.cheng[index].IsOpen)
                        this.cheng[index].com_close();
                    this.cheng[index].Dispose();
                }
            }
            if (this.plcDL.IsOpen)
            {
                this.plcDL.com_close();
                this.plcDL.Dispose();
            }
            if (this.TSsound == null)
                return;
            this.TSsound.Stop();
            this.TSsound.Dispose();
        }
        private void this_Load(object sender, EventArgs e)
        {
            this.staDL = frmDL.enumSta.显示空白;
            this.emptyLD();
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
        private void this_Shown(object sender, EventArgs e)
        {
            if (!this.ditou_cheng_plc_init())
            {
                this.Close();
            }
            else
            {
                this.col1.Width = this.dgvDT.Width / 4;
                this.col2.Width = this.col1.Width;
                this.col3.Width = this.col1.Width;
                this.col4.Width = this.col1.Width;
                this.dgvDT.Rows.Add(4);
                this.showDiTou();
                this.DLtimer.Tick += new EventHandler(this.DLtimer_Tick);
                this.KeyUp += new KeyEventHandler(this.this_KeyUp);
                this.lblBtnSch.Focus();
            }
        }
        private void showDiTou()
        {
            //using (SqlConnection sqlConnection = new SqlConnection(Settings.Default.DBconn))
            {
                string CommandText = "select * from T_Base where leibie = '滴料头' and bianhao = '" + Settings.Default.DLjihao + "' order by itemName";
                DataTable dataTable = db.Ado.GetDataTable(CommandText);
                for (int index = 0; index < this.dgvDT.RowCount * this.dgvDT.ColumnCount; ++index)
                    this.dgvDT.Rows[index % 4].Cells[index / 4].Value = index >= dataTable.Rows.Count ? (object)"" : (object)(dataTable.Rows[index].Field<string>("itemName") + "." + dataTable.Rows[index].Field<string>("item0"));
                dataTable.Dispose();
            }
            this.dgvDT.CurrentCell = (DataGridViewCell)null;
        }
        private bool ditou_cheng_plc_init()
        {
            try
            {
                var list = db.Queryable<T_Base>()
                    .Where(it => it.leibie == "滴料头" && it.bianhao == this.jihao)
                    .ToList();
                //dbpf.Dispose();
                if (list.Count != ((IEnumerable<int>)UserProc.DLparaDT).Sum())
                {
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                    this.TSsound.Play();
                    frmError frmError = new frmError("滴头数量错误!!!");
                    int num = (int)frmError.ShowDialog((IWin32Window)this);
                    frmError.Close();
                    return false;
                }
                string[] asd = Settings.Default.DLparaDitou.Split('|');
                for (int index = 0; index < ((IEnumerable<int>)UserProc.DLparaDT).Sum(); ++index)
                {
                    string[] strArray = asd[index].Split(',');
                    this.ditou.Add(new frmDL.struDiTou()
                    {
                        BianHao = index + 1,
                        stopVal = Convert.ToDecimal(strArray[1]),
                        chuVal = Convert.ToDecimal(strArray[2]),
                        chuOpen = Convert.ToDecimal(strArray[3]),
                        chuClose = Convert.ToDecimal(strArray[4]),
                        xiVal = Convert.ToDecimal(strArray[5]),
                        xiOpen = Convert.ToDecimal(strArray[6]),
                        xiClose = Convert.ToDecimal(strArray[7])
                    });
                }
            }
            catch
            {
                this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                this.TSsound.Play();
                frmError frmError = new frmError("滴头参数错误!!!");
                int num = (int)frmError.ShowDialog((IWin32Window)this);
                frmError.Close();
                return false;
            }
            string[] asd1 = Settings.Default.DLparaCheng.Split('|');
            for (int index = 0; index < UserProc.DLparaDT.Length; ++index)
            {
                string[] strArray = asd1[index].Split(',');
                if (strArray.Length != 15)
                {
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                    this.TSsound.Play();
                    frmError frmError = new frmError((index + 1).ToString() + "号电子称,参数设置错误!!!");
                    int num = (int)frmError.ShowDialog((IWin32Window)this);
                    frmError.Close();
                    return false;
                }
                clsCheng clsCheng = new clsCheng();
                try
                {
                    clsCheng.PortName = strArray[0];
                    clsCheng.BaudRate = Convert.ToInt32(strArray[1]);
                    clsCheng.DataBits = Convert.ToInt32(strArray[2]);
                    clsCheng.Parity = strArray[3] == "odd" ? Parity.Odd : (strArray[3] == "even" ? Parity.Even : Parity.None);
                    clsCheng.chengPara = new StruChengPara()
                    {
                        chengXH = (enumCheng)Enum.Parse(typeof(enumCheng), strArray[4]),
                        JingDu = Convert.ToDecimal(strArray[5]),
                        MaxCL = Convert.ToDecimal(strArray[6]),
                        WuCha = Convert.ToDecimal(strArray[7]),
                        WuChaPG = strArray[8],
                        OKci = (int)Convert.ToInt16(strArray[9]),
                        OKwd = strArray[10] == "true",
                        zeroCi = (int)Convert.ToInt16(strArray[11]),
                        zeroWD = strArray[12] == "true",
                        scanSpeed = (int)Convert.ToInt16(strArray[13]),
                        zeroSpeed = (int)Convert.ToInt16(strArray[14])
                    };
                    clsCheng.com_open();
                    this.cheng.Add(clsCheng);
                }
                catch
                {
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                    this.TSsound.Play();
                    frmError frmError = new frmError((index + 1).ToString() + "号称,无法打开!!!");
                    int num = (int)frmError.ShowDialog((IWin32Window)this);
                    frmError.Close();
                    return false;
                }
            }
            string[] strArray1 = Settings.Default.DLparaPLC.Split(',');
            if (strArray1.Length != 5)
            {
                this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                this.TSsound.Play();
                frmError frmError = new frmError("PLC 参数设置错误!!!");
                int num = (int)frmError.ShowDialog((IWin32Window)this);
                frmError.Close();
                return false;
            }
            try
            {
                this.plcDL.PortName = strArray1[0];
                this.plcDL.BaudRate = Convert.ToInt32(strArray1[1]);
                this.plcDL.DataBits = Convert.ToInt32(strArray1[2]);
                this.plcDL.Parity = strArray1[3] == "odd" ? Parity.Odd : (strArray1[3] == "even" ? Parity.Even : Parity.None);
                this.plcDL.RWokReadDelay = Convert.ToInt32(strArray1[4]);
                this.plcDL.com_open();
                if (!this.plcDL.setD0(0) || !this.plcDL.setD1_7(0, 0, 0, 0, 0, 0, 0) || !this.plcDL.setVal(this.plcDL.wM20, false) || !this.plcDL.setVal(this.plcDL.wM21, false))
                {
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                    this.TSsound.Play();
                    frmError frmError = new frmError("PLC 复位失败!!!");
                    int num = (int)frmError.ShowDialog((IWin32Window)this);
                    frmError.Close();
                    return false;
                }
            }
            catch
            {
                this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                this.TSsound.Play();
                frmError frmError = new frmError("PLC 串口无法打开!!!");
                int num = (int)frmError.ShowDialog((IWin32Window)this);
                frmError.Close();
                return false;
            }
            return true;
        }
        private void DLtimer_Tick(object sender, EventArgs e)
        {
            this.DLtimer.Stop();
            if (this.lblTS.ForeColor == Color.DarkRed)
                this.lblTS.ForeColor = Color.Yellow;
            else
                this.lblTS.ForeColor = Color.DarkRed;
            DataGridViewCell cell = this.dgvDT.Rows[this.DLditou % 4].Cells[this.DLditou / 4];
            cell.Style.BackColor = !(cell.Style.BackColor == Color.Red) ? Color.Red : Color.Green;
            this.cheng[this.DLcheng].getVal();
            this.cheng[this.DLcheng].getMao();
            this.lblDLzl.Text = !this.cheng[this.DLcheng].showVal.HasValue ? "无值" : (this.cheng[this.DLcheng].showVal.Value / new Decimal(1000)).ToString("0.00 Kg");
            this.lblDLwd.Text = this.cheng[this.DLcheng].WenDing ? "稳定" : "";
            this.lblDLmz.Text = !this.cheng[this.DLcheng].maoVal.HasValue ? "无值" : (this.cheng[this.DLcheng].maoVal.Value / new Decimal(1000)).ToString("0.00 Kg");
            Decimal? nullable = this.cheng[this.DLcheng].showVal;
            int num1;
            if (nullable.HasValue)
            {
                nullable = this.cheng[this.DLcheng].maoVal;
                num1 = nullable.HasValue ? 1 : 0;
            }
            else
                num1 = 0;
            if (num1 == 0)
            {
                this.lblDLzl.Text = "";
                this.lblDLwd.Text = "";
                this.lblDLmz.Text = "";
                this.lblDLwc.Text = this.lblDLzlmb.Text;
                ++this.DLerrTPCount;
                this.lblTPerr.Text = this.DLerrTPCount.ToString();
                if (this.DLerrTPCount >= 3)
                {
                    this.plcDL.setD0(0);
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                    this.TSsound.Play();
                    this.lblTS.Visible = false;
                    frmTS frmTs = new frmTS(this.DLrl, this.DLcheng, this.DLditou, "电子称读取失败,检查设备!!!", "“确认”再试一次", "“清除”取消滴料", Keys.Back);
                    DialogResult dialogResult = frmTs.ShowDialog((IWin32Window)this);
                    frmTs.Close();
                    this.lblTS.Visible = true;
                    if (dialogResult == DialogResult.OK)
                    {
                        this.DLerrTPCount = 0;
                        this.DLokCount = 0;
                        this.lblTPerr.Text = "";
                    }
                    else
                    {
                        this.DLend();
                        return;
                    }
                }
                this.DLtimer.Start();
            }
            else
            {
                this.DLerrTPCount = 0;
                this.lblTPerr.Text = "";
                nullable = this.cheng[this.DLcheng].showVal;
                Decimal num2 = nullable.Value;
                this.lblDLwc.Text = ((this.DLzlmb - num2) / new Decimal(1000)).ToString("0.00 Kg");
                if (this.DLzlmb > new Decimal(0))
                {
                    int num3 = (int)(num2 / this.DLzlmb * new Decimal(100));
                    this.pBarDL.Value = num3 < 0 ? 0 : (num3 > 100 ? 100 : num3);
                }
                else
                    this.pBarDL.Value = 100;
                nullable = this.cheng[this.DLcheng].maoVal;
                Decimal tongZl = (Decimal)this.tongZL;
                if ((!(nullable.GetValueOrDefault() < tongZl) ? 0 : (nullable.HasValue ? 1 : 0)) != 0 || num2 <= (Decimal)(-this.tongZL))
                {
                    this.plcDL.setD0(0);
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                    this.TSsound.Play();
                    this.lblTS.Visible = false;
                    frmTS frmTs = new frmTS(this.DLrl, this.DLcheng, this.DLditou, "称上无桶/重量异常,请检查!", "“确认”继续滴料", "“清除”取消滴料", Keys.Back);
                    DialogResult dialogResult = frmTs.ShowDialog((IWin32Window)this);
                    frmTs.Close();
                    this.lblTS.Visible = true;
                    if (dialogResult == DialogResult.OK)
                    {
                        this.DLokCount = 0;
                        this.DLtimer.Start();
                    }
                    else
                    {
                        if (this.DLzlok > (Decimal)this.minDLZL)
                        {
                            this.DLsave();
                            if (this.staDL == frmDL.enumSta.表单滴料正在)
                                this.dgvData.CurrentRow.Cells[this.colDL.Name].Value = (object)((this.DLzlok + this.DLzlyc) / new Decimal(1000));
                        }
                        this.DLend();
                    }
                }
                else
                {
                    Decimal num3 = new Decimal(0);
                    Decimal d = this.DLzlmb - num2 - this.ditou[this.DLditou].stopVal;
                    if (d < new Decimal(0))
                        d = new Decimal(0);
                    Decimal num4 = Math.Ceiling(d);
                    string str1 = this.plcDL.readVal(this.plcDL.rM16, 1);
                    if (!(!(num4 > new Decimal(30000)) ? this.plcDL.setD0((int)num4) : this.plcDL.setD0(30000)) || str1 == "")
                    {
                        ++this.DLerrPLCcount;
                        this.lblPLCerr.Text = this.DLerrPLCcount.ToString();
                        if (this.DLerrPLCcount >= 3)
                        {
                            this.plcDL.setD0(0);
                            this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                            this.TSsound.Play();
                            this.lblTS.Visible = false;
                            frmTS frmTs = new frmTS(this.DLrl, this.DLcheng, this.DLditou, "PLC连接失败,检查设备!!!", "“确认”再试一次", "“清除”取消滴料", Keys.Back);
                            DialogResult dialogResult = frmTs.ShowDialog((IWin32Window)this);
                            frmTs.Close();
                            this.lblTS.Visible = true;
                            if (dialogResult == DialogResult.OK)
                            {
                                this.DLerrPLCcount = 0;
                                this.DLokCount = 0;
                                this.lblPLCerr.Text = "";
                            }
                            else
                            {
                                this.DLend();
                                return;
                            }
                        }
                        this.DLtimer.Start();
                    }
                    else
                    {
                        this.DLerrPLCcount = 0;
                        this.lblPLCerr.Text = "";
                        byte num5 = Convert.ToByte(str1.Substring(1, 2), 16);
                        if (((int)num5 & 32) > 0)
                        {
                            this.DLend();
                            this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                            this.TSsound.Play();
                            frmError frmError = new frmError("设备进入手动模式,将退出!!!");
                            int num6 = (int)frmError.ShowDialog((IWin32Window)this);
                            frmError.Close();
                        }
                        else if (((int)num5 & 64) > 0)
                        {
                            this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                            this.TSsound.Play();
                            this.lblTS.Visible = false;
                            frmTS frmTs = new frmTS(this.DLrl, this.DLcheng, this.DLditou, "滴料(门禁)异常,请检查!", "“确认”继续滴料", "“清除”取消滴料", Keys.Back);
                            DialogResult dialogResult = frmTs.ShowDialog((IWin32Window)this);
                            frmTs.Close();
                            this.lblTS.Visible = true;
                            this.DLzlok += num2;
                            if (this.DLzlok > (Decimal)this.minDLZL)
                            {
                                this.DLsave();
                                if (this.staDL == frmDL.enumSta.表单滴料正在)
                                    this.dgvData.CurrentRow.Cells[this.colDL.Name].Value = (object)((this.DLzlok + this.DLzlyc) / new Decimal(1000));
                            }
                            this.DLend();
                            if (dialogResult != DialogResult.OK)
                                return;
                            this.DLstart();
                        }
                        else
                        {
                            if (num4 > new Decimal(0) || this.cheng[this.DLcheng].chengPara.OKwd && !this.cheng[this.DLcheng].WenDing)
                                this.DLokCount = 0;
                            else
                                ++this.DLokCount;
                            if (this.DLokCount >= this.cheng[this.DLcheng].chengPara.OKci)
                            {
                                this.DLzlok += num2;
                                if (this.DLzlok + this.ditou[this.DLditou].stopVal >= this.DLzlall)
                                {
                                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\ding.wav";
                                    this.TSsound.PlaySync();
                                    this.DLsave();
                                    if (this.staDL == frmDL.enumSta.表单滴料正在)
                                    {
                                        this.dgvData.CurrentRow.Cells[this.colDL.Name].Value = (object)((this.DLzlok + this.DLzlyc) / new Decimal(1000));
                                        if (this.dgvData.CurrentRow.Index < this.dgvData.RowCount - 1)
                                        {
                                            this.dgvData.CurrentCell = this.dgvData.Rows[this.dgvData.CurrentRow.Index + 1].Cells[this.colRL.Name];
                                            Application.DoEvents();
                                        }
                                        else
                                        {
                                            this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                                            this.TSsound.Play();
                                            frmDLend frmDlend = new frmDLend();
                                            int num6 = (int)frmDlend.ShowDialog((IWin32Window)this);
                                            frmDlend.Close();
                                        }
                                    }
                                    this.DLend();
                                }
                                else
                                {
                                    this.DLallowKey = false;
                                    this.plcDL.setD0(0);
                                    Label lblDlyc = this.lblDLyc;
                                    Decimal num6 = this.DLzlall / new Decimal(1000);
                                    string str2 = num6.ToString("0.00");
                                    num6 = (this.DLzlyc + this.DLzlok) / new Decimal(1000);
                                    string str3 = num6.ToString("0.00 Kg");
                                    string str4 = "用量: " + str2 + " Kg, 已称:" + str3;
                                    lblDlyc.Text = str4;
                                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                                    this.TSsound.Play();
                                    this.lblTS.Visible = false;
                                    frmTS frmTs = new frmTS(this.DLrl, this.DLcheng, this.DLditou, "已滴满一桶,请更换料桶继续!", "“确认”开始滴料", "“清除”取消滴料", Keys.Back);
                                    DialogResult dialogResult = frmTs.ShowDialog((IWin32Window)this);
                                    frmTs.Close();
                                    this.lblTS.Visible = true;
                                    if (dialogResult == DialogResult.OK)
                                    {
                                        this.DLzlmb = new Decimal(0);
                                        this.DLerrTPCount = 0;
                                        this.DLerrPLCcount = 0;
                                        this.DLokCount = 0;
                                        this.DLallowKey = false;
                                        this.lblTPerr.Text = "";
                                        this.lblPLCerr.Text = "";
                                        this.DLzero();
                                    }
                                    else
                                    {
                                        if (this.DLzlok > (Decimal)this.minDLZL)
                                        {
                                            this.DLsave();
                                            if (this.staDL == frmDL.enumSta.表单滴料正在)
                                                this.dgvData.CurrentRow.Cells[this.colDL.Name].Value = (object)((this.DLzlok + this.DLzlyc) / new Decimal(1000));
                                        }
                                        this.DLend();
                                    }
                                }
                            }
                            else
                                this.DLtimer.Start();
                        }
                    }
                }
            }
        }
        private void DLzero()
        {
            this.lblDLzl.Text = "归零中!";
            Application.DoEvents();
            this.cheng[this.DLcheng].setZERO();
            Thread.Sleep(this.cheng[this.DLcheng].chengPara.zeroSpeed);
            this.cheng[this.DLcheng].getVal();
            Label lblDlzl = this.lblDLzl;
            Decimal? nullable;
            string str1;
            if (this.cheng[this.DLcheng].showVal.HasValue)
            {
                nullable = this.cheng[this.DLcheng].showVal;
                str1 = (nullable.Value / new Decimal(1000)).ToString("0.00 Kg");
            }
            else
                str1 = "无值";
            lblDlzl.Text = str1;
            this.lblDLwd.Text = this.cheng[this.DLcheng].WenDing ? "稳定" : "";
            Application.DoEvents();
            nullable = this.cheng[this.DLcheng].showVal;
            int num1;
            if (nullable.HasValue)
            {
                nullable = this.cheng[this.DLcheng].showVal;
                Decimal num2 = -this.cheng[this.DLcheng].chengPara.JingDu;
                if ((!(nullable.GetValueOrDefault() < num2) ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
                {
                    nullable = this.cheng[this.DLcheng].showVal;
                    Decimal jingDu = this.cheng[this.DLcheng].chengPara.JingDu;
                    if ((!(nullable.GetValueOrDefault() > jingDu) ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
                    {
                        num1 = this.cheng[this.DLcheng].WenDing ? 1 : (!this.cheng[this.DLcheng].chengPara.zeroWD ? 1 : 0);
                        goto label_8;
                    }
                }
            }
            num1 = 0;
        label_8:
            if (num1 == 0)
            {
                ++this.DLerrTPCount;
                this.DLokCount = 0;
                this.lblTPerr.Text = this.DLerrTPCount.ToString();
            }
            else
                ++this.DLokCount;
            if (this.DLerrTPCount >= 3)
            {
                this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                this.TSsound.Play();
                this.lblTS.Visible = false;
                frmTS frmTs = new frmTS(this.DLrl, this.DLcheng, this.DLditou, "电子称归零失败,检查设备!!!", "“确认”再试一次", "“清除”取消滴料", Keys.Back);
                DialogResult dialogResult = frmTs.ShowDialog((IWin32Window)this);
                frmTs.Close();
                this.lblTS.Visible = true;
                if (dialogResult == DialogResult.OK)
                {
                    this.DLerrTPCount = 0;
                    this.DLokCount = 0;
                    this.lblTPerr.Text = "";
                    this.DLzero();
                }
                else
                {
                    if (this.DLzlok > (Decimal)this.minDLZL)
                    {
                        this.DLsave();
                        if (this.staDL == frmDL.enumSta.表单滴料正在)
                            this.dgvData.CurrentRow.Cells[this.colDL.Name].Value = (object)((this.DLzlok + this.DLzlyc) / new Decimal(1000));
                    }
                    this.DLend();
                }
            }
            else if (this.DLokCount >= this.cheng[this.DLcheng].chengPara.zeroCi)
            {
                this.cheng[this.DLcheng].getMao();
                nullable = this.cheng[this.DLcheng].maoVal;
                if (!nullable.HasValue)
                {
                    Thread.Sleep(this.cheng[this.DLcheng].chengPara.zeroSpeed);
                    this.cheng[this.DLcheng].getMao();
                }
                Label lblDlmz = this.lblDLmz;
                nullable = this.cheng[this.DLcheng].maoVal;
                string str2;
                if (nullable.HasValue)
                {
                    nullable = this.cheng[this.DLcheng].maoVal;
                    str2 = (nullable.Value / new Decimal(1000)).ToString("0.### Kg");
                }
                else
                    str2 = "无值";
                lblDlmz.Text = str2;
                nullable = this.cheng[this.DLcheng].maoVal;
                int num2;
                if (nullable.HasValue)
                {
                    nullable = this.cheng[this.DLcheng].maoVal;
                    Decimal tongZl = (Decimal)this.tongZL;
                    num2 = (!(nullable.GetValueOrDefault() < tongZl) ? 0 : (nullable.HasValue ? 1 : 0)) == 0 ? 1 : 0;
                }
                else
                    num2 = 0;
                if (num2 == 0)
                {
                    frmTS frmTs = new frmTS(this.DLrl, this.DLcheng, this.DLditou, "称上无桶,请检查!!!", "“确认”再试一次", "“清除”取消滴料", Keys.Back);
                    DialogResult dialogResult = frmTs.ShowDialog((IWin32Window)this);
                    frmTs.Close();
                    this.lblTS.Visible = true;
                    if (dialogResult == DialogResult.OK)
                    {
                        this.DLerrTPCount = 0;
                        this.DLokCount = 0;
                        this.DLzero();
                    }
                    else
                    {
                        if (this.DLzlok > (Decimal)this.minDLZL)
                        {
                            this.DLsave();
                            if (this.staDL == frmDL.enumSta.表单滴料正在)
                                this.dgvData.CurrentRow.Cells[this.colDL.Name].Value = (object)((this.DLzlok + this.DLzlyc) / new Decimal(1000));
                        }
                        this.DLend();
                    }
                }
                else
                {
                    Decimal num3 = this.DLzlall - this.DLzlok;
                    Decimal maxCl1 = this.cheng[this.DLcheng].chengPara.MaxCL;
                    nullable = this.cheng[this.DLcheng].maoVal;
                    nullable = nullable.HasValue ? new Decimal?(maxCl1 - nullable.GetValueOrDefault()) : new Decimal?();
                    if ((!(num3 <= nullable.GetValueOrDefault()) ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
                    {
                        this.DLzlmb = this.DLzlall - this.DLzlok;
                    }
                    else
                    {
                        Decimal maxCl2 = this.cheng[this.DLcheng].chengPara.MaxCL;
                        nullable = this.cheng[this.DLcheng].maoVal;
                        Decimal num4 = (Decimal)(int)nullable.Value;
                        this.DLzlmb = (Decimal)((int)((maxCl2 - num4) / new Decimal(1000)) * 1000);
                    }
                    this.DLerrTPCount = 0;
                    this.DLerrPLCcount = 0;
                    this.DLokCount = 0;
                    this.DLallowKey = true;
                    this.lblDLzlmb.Text = (this.DLzlmb / new Decimal(1000)).ToString("0.00 Kg");
                    this.lblDLwc.Text = "";
                    this.pBarDL.Value = 0;
                    this.lblTPerr.Text = "";
                    this.lblPLCerr.Text = "";
                    this.DLtimer.Interval = this.cheng[this.DLcheng].chengPara.scanSpeed;
                    this.DLtimer.Start();
                }
            }
            else
                this.DLzero();
        }
        private void DLend()
        {
            this.DLditou = -1;
            this.DLcheng = -1;
            this.DLrl = "";
            this.DLzlyc = new Decimal(0);
            this.DLzlall = new Decimal(0);
            this.DLzlmb = new Decimal(0);
            this.DLzlok = new Decimal(0);
            this.DLerrTPCount = 0;
            this.DLerrPLCcount = 0;
            this.DLokCount = 0;
            this.DLallowKey = false;
            for (int index = 0; index < this.dgvDT.RowCount * this.dgvDT.ColumnCount; ++index)
                this.dgvDT.Rows[index % 4].Cells[index / 4].Style.BackColor = SystemColors.Window;
            this.DLtimer.Stop();
            this.TSsound.Stop();
            if (!this.plcDL.setD0(0) || !this.plcDL.setVal(this.plcDL.wM20, false))
            {
                frmError frmError = new frmError("DLend()过程,PLC无法关闭!");
                int num = (int)frmError.ShowDialog((IWin32Window)this);
                frmError.Close();
            }
            this.lblTS.ForeColor = Color.DarkRed;
            if (this.staDL == frmDL.enumSta.表单滴料正在)
            {
                this.staDL = frmDL.enumSta.显示有料;
                this.showRow();
            }
            else
            {
                this.staDL = frmDL.enumSta.显示空白;
                this.lblTS.Text = "直接滴料结束!!!";
            }
        }
        private bool showRow()
        {
            this.DLditou = this.dgvData.CurrentRow.Cells[this.colDT.Name].FormattedValue.ToString() == "" ? -1 : Convert.ToInt32(this.dgvData.CurrentRow.Cells[this.colDT.Name].FormattedValue.ToString()) - 1;
            if (this.DLditou < 0 || this.DLditou >= ((IEnumerable<int>)UserProc.DLparaDT).Sum())
            {
                this.DLcheng = -1;
            }
            else
            {
                this.DLcheng = -1;
                int num = 0;
                for (int index = 0; index < UserProc.DLparaDT.Length; ++index)
                {
                    num += UserProc.DLparaDT[index];
                    if (this.DLditou < num)
                    {
                        this.DLcheng = index;
                        break;
                    }
                }
            }
            this.DLrl = this.dgvData.CurrentRow.Cells[this.colRL.Name].FormattedValue.ToString();
            this.DLzlyl = (Decimal)this.dgvData.CurrentRow.Cells[this.colYL.Name].Value * new Decimal(1000);
            this.DLzlyc = this.dgvData.CurrentRow.Cells[this.colDL.Name].FormattedValue.ToString() == "" ? new Decimal(0) : Convert.ToDecimal(this.dgvData.CurrentRow.Cells[this.colDL.Name].FormattedValue.ToString()) * new Decimal(1000);
            this.DLzlall = this.DLzlyl - this.DLzlyc;
            this.DLzlmb = new Decimal(0);
            this.DLzlok = new Decimal(0);
            this.DLerrTPCount = 0;
            this.DLerrPLCcount = 0;
            this.DLokCount = 0;
            this.DLallowKey = false;
            Label lblDldt = this.lblDLdt;
            int num1 = this.DLditou + 1;
            string str1 = "(" + num1.ToString() + "号滴头)";
            lblDldt.Text = str1;
            this.lblDLrlname.Text = this.DLrl;
            this.lblDLyc.Text = "用量:" + (this.DLzlyl / new Decimal(1000)).ToString("0.00") + " Kg，已称:" + (this.DLzlyc / new Decimal(1000)).ToString("0.00") + " Kg";
            Label lblDlcheng = this.lblDLcheng;
            string str2;
            if (this.DLcheng != -1)
            {
                num1 = this.DLcheng + 1;
                str2 = num1.ToString();
            }
            else
                str2 = "?";
            string str3 = "( " + str2 + " 号称 )";
            lblDlcheng.Text = str3;
            this.lblDLzlmb.Text = "";
            this.lblDLzl.Text = "";
            this.lblDLmz.Text = "";
            this.lblDLwd.Text = "";
            this.lblDLwc.Text = "";
            this.pBarDL.Value = 0;
            return true;
        }
        private bool DLsave()
        {
            try
            {
                //DBpf dbpf = new DBpf(Settings.Default.DBconn);
                T_PFcheng entity = new T_PFcheng()
                {
                    danhao = this.staDL == frmDL.enumSta.表单滴料正在 ? this.txtLDH.Text : "直接滴料",
                    cishu = 0,
                    SNdata = this.staDL == frmDL.enumSta.表单滴料正在 ? (long)this.dgvData.CurrentRow.Cells[this.colSN.Name].Value : -1L,
                    ranliao = this.DLrl,
                    chengliang = this.DLzlok,
                    chengmian = new Decimal(0),
                    chengpi = new Decimal(0),
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
        private void DLstart()
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
                T_PFmain tPfmain = db.Queryable<T_PFmain>().Where(a => a.danhao == this.txtLDH.Text).First();
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
                    T_PFdata tPfdata = db.Queryable<T_PFdata>().Where(a => a.SN == (long)this.dgvData.CurrentRow.Cells[this.colSN.Name].Value).First();
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
                            if (tPfdata.yongliangDW == "g" || tPfdata.yongliangDW == "mL")
                                num2 /= new Decimal(1000);
                        }
                        else
                        {
                            num2 = tPfdata.JLyongliang;
                            if (tPfdata.JLyongliangDW == "g" || tPfdata.JLyongliangDW == "mL")
                                num2 /= new Decimal(1000);
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
                            if (this.DLzlyc != new Decimal(0) && this.DLzlall < (Decimal)this.minDLZL)
                            {
                                this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                                this.TSsound.Play();
                                frmError frmError = new frmError("本行已称过,不需要滴料了!");
                                int num3 = (int)frmError.ShowDialog((IWin32Window)this);
                                frmError.Close();
                            }
                            else if (this.DLcheng < 0)
                            {
                                this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                                this.TSsound.Play();
                                frmError frmError = new frmError("无法找到合适的称,请核对!");
                                int num3 = (int)frmError.ShowDialog((IWin32Window)this);
                                frmError.Close();
                            }
                            else if (!this.plcDL.setD0(0) || !this.plcDL.setD1_7(this.ditou[this.DLditou].BianHao, (int)this.ditou[this.DLditou].chuVal, (int)(this.ditou[this.DLditou].chuOpen * new Decimal(10)), (int)(this.ditou[this.DLditou].chuClose * new Decimal(10)), (int)this.ditou[this.DLditou].xiVal, (int)(this.ditou[this.DLditou].xiOpen * new Decimal(10)), (int)(this.ditou[this.DLditou].xiClose * new Decimal(10))) || !this.plcDL.setVal(this.plcDL.wM20, true))
                            {
                                this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                                this.TSsound.Play();
                                frmError frmError = new frmError("PLC 初始化失败!!!");
                                int num3 = (int)frmError.ShowDialog((IWin32Window)this);
                                frmError.Close();
                            }
                            else
                            {
                                this.staDL = frmDL.enumSta.表单滴料正在;
                                this.DLzlmb = new Decimal(0);
                                this.DLzlok = new Decimal(0);
                                this.DLerrTPCount = 0;
                                this.DLerrPLCcount = 0;
                                this.DLokCount = 0;
                                this.DLallowKey = false;
                                this.lblTPerr.Text = "";
                                this.lblPLCerr.Text = "";
                                this.DLzero();
                            }
                        }
                    }
                }
            }
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
                string sql = "";
                if (showLDH.StartsWith("LD") || showLDH.Length == 10 && showLDH.StartsWith("8"))
                {
                    this.colYL.HeaderText = "用量";
                    sql = "select a.*,YL=case when a.yongliangDW in('Kg','L') then a.yongliang else a.yongliang/1000 end,ditou=b.itemName,clval=(select sum(chengliang+chengmian-chengpi)/1000 from T_PFcheng where SNdata=a.SN) from T_PFdata a join T_Base b on a.ranliao = b.item0 and b.leibie = '滴料头' and b.bianhao = '" + this.jihao + "' where a.danhao = '" + showLDH + "' and a.yongliang > 0 order by b.itemName";
                }
                else
                {
                    this.colYL.HeaderText = "加料用量";
                    sql = "select a.*,YL=case when a.JLyongliangDW in('Kg','L') then JLyongliang else a.JLyongliang/1000 end,ditou=b.itemName,clval=(select sum(chengliang+chengmian-chengpi)/1000 from T_PFcheng where SNdata=a.SN) from T_PFdata a join T_Base b on a.ranliao = b.item0 and b.leibie = '滴料头' and b.bianhao = '" + this.jihao + "' where a.danhao = '" + showLDH + "' and a.JLyongliang > 0 order by b.itemName";
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
            this.txtKZ.txt.Text = dataTable1.Rows[0].Field<Decimal>("kezhong").ToString("0.###;-0.###;\"\"");
            this.txtJH.txt.Text = dataTable1.Rows[0].Field<string>("jihao");
            TextBox txt1 = this.txtSL.txt;
            Decimal num = dataTable1.Rows[0].Field<Decimal>("shuiliang");
            string str1 = num.ToString("0.####;-0.####;\"\"");
            txt1.Text = str1;
            TextBox txt2 = this.txtZL.txt;
            num = dataTable1.Rows[0].Field<Decimal>("zhongliang");
            string str2 = num.ToString("0.####;-0.####;\"\"");
            txt2.Text = str2;
            for (int index = 0; index < dataTable2.Rows.Count; ++index)
            {
                this.dgvData.Rows.Add();
                DataGridViewRow row = this.dgvData.Rows[this.dgvData.RowCount - 1];
                row.Cells[this.colBH.Name].Value = (object)(index + 1).ToString();
                row.Cells[this.colSN.Name].Value = (object)dataTable2.Rows[index].Field<long>("SN");
                row.Cells[this.colGX.Name].Value = (object)dataTable2.Rows[index].Field<string>("gongxu");
                row.Cells[this.colRL.Name].Value = (object)dataTable2.Rows[index].Field<string>("ranliao");
                row.Cells[this.colYL.Name].Value = (object)dataTable2.Rows[index].Field<Decimal>("YL");
                row.Cells[this.colDW.Name].Value = (object)"Kg";
                row.Cells[this.colDL.Name].Value = (object)dataTable2.Rows[index].Field<Decimal?>("clval");
                row.Cells[this.colDLdw.Name].Value = (object)"Kg";
                row.Cells[this.colDT.Name].Value = (object)Convert.ToInt16(dataTable2.Rows[index].Field<string>("ditou"));
            }
            dataTable1.Dispose();
            dataTable2.Dispose();
            this.lblRowCount.Text = "合计 " + this.dgvData.RowCount.ToString() + " 条";
            return true;
        }
        private void ZDstart()
        {
            if (this.DLcheng < 0)
            {
                this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                this.TSsound.Play();
                frmError frmError = new frmError("无法找到合适的称,请核对!");
                int num = (int)frmError.ShowDialog((IWin32Window)this);
                frmError.Close();
            }
            else if (!this.plcDL.setD0(0) || !this.plcDL.setD1_7(this.ditou[this.DLditou].BianHao, (int)this.ditou[this.DLditou].chuVal, (int)(this.ditou[this.DLditou].chuOpen * new Decimal(10)), (int)(this.ditou[this.DLditou].chuClose * new Decimal(10)), (int)this.ditou[this.DLditou].xiVal, (int)(this.ditou[this.DLditou].xiOpen * new Decimal(10)), (int)(this.ditou[this.DLditou].xiClose * new Decimal(10))) || !this.plcDL.setVal(this.plcDL.wM20, true))
            {
                this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\error.wav";
                this.TSsound.Play();
                frmError frmError = new frmError("PLC 初始化失败!!!");
                int num = (int)frmError.ShowDialog((IWin32Window)this);
                frmError.Close();
            }
            else
            {
                this.emptyLD();
                this.lblDLdt.Text = "(" + (this.DLditou + 1).ToString() + "号滴头)";
                this.lblDLrlname.Text = this.DLrl;
                this.lblDLzlmb.Text = "";
                Label lblDlyc = this.lblDLyc;
                Decimal num = this.DLzlall / new Decimal(1000);
                string str1 = num.ToString("0.00");
                num = this.DLzlok / new Decimal(1000);
                string str2 = num.ToString("0.00 Kg");
                string str3 = "用量: " + str1 + " Kg, 已称:" + str2;
                lblDlyc.Text = str3;
                this.lblDLcheng.Text = "( " + (this.DLcheng + 1).ToString() + " 号称 )";
                this.lblDLzl.Text = "";
                this.lblDLwd.Text = "";
                this.lblDLwc.Text = "";
                this.pBarDL.Value = 0;
                this.staDL = frmDL.enumSta.直接滴料正在;
                this.DLzlmb = new Decimal(0);
                this.DLzlok = new Decimal(0);
                this.DLerrTPCount = 0;
                this.DLerrPLCcount = 0;
                this.DLokCount = 0;
                this.DLallowKey = false;
                this.lblTPerr.Text = "";
                this.lblPLCerr.Text = "";
                this.DLzero();
            }
        }
        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.staDL == frmDL.enumSta.显示空白 || this.staDL == frmDL.enumSta.显示有料)
            {
                this.lblKeyS.Text += e.KeyValue.ToString("X2");
                Application.DoEvents();
                if (Settings.Default.paraKeyB == 18 && e.KeyCode == Keys.F1 || Settings.Default.paraKeyB == 16 && (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal))
                {
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\ding.wav";
                    this.TSsound.Play();
                    frmDLsch frmDlsch = Settings.Default.paraKeyB != 18 ? new frmDLsch("“返回”退出", Keys.Escape) : new frmDLsch("“F2”退出", Keys.F2);
                    DialogResult dialogResult = frmDlsch.ShowDialog((IWin32Window)this);
                    frmDlsch.Close();
                    if (dialogResult == DialogResult.OK)
                    {
                        if (this.showLD(frmDlsch.txtSch.Text))
                        {
                            this.staDL = frmDL.enumSta.显示有料;
                            this.dgvData.CurrentCell = this.dgvData.Rows[0].Cells[this.colRL.Name];
                            this.showRow();
                        }
                        else
                            this.staDL = frmDL.enumSta.显示空白;
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
                else if (e.KeyCode == Keys.Return)
                {
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\ding.wav";
                    this.TSsound.Play();
                    if (this.staDL == frmDL.enumSta.显示有料 && this.lblKeyS.Text.Length == 2)
                        this.DLstart();
                    this.lblKeyS.Text = "";
                }
                else if (Settings.Default.paraKeyB == 18 && e.KeyCode == Keys.F3 || Settings.Default.paraKeyB == 16 && e.KeyCode == Keys.Back)
                {
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\ding.wav";
                    this.TSsound.Play();
                    //DBpf dbpf = new DBpf(Settings.Default.DBconn);
                    //T_Base tBase = dbpf.T_Base.Where<T_Base>((Expression<Func<T_Base, bool>>)(a => a.leibie == PeiFang.BaseItem.leibie.enumLB.滴料机号.ToString() && a.bianhao == Settings.Default.DLjihao)).SingleOrDefault<T_Base>();
                    T_Base tBase = db.Queryable<T_Base>()
                        .Where(a => a.leibie == "滴料机号" && a.bianhao == Settings.Default.DLjihao)
                        .First();
                    //dbpf.Dispose();
                    if (tBase.item0 != "允许半自动")
                    {
                        frmError frmError = new frmError("直接滴料权限不足!!!");
                        int num = (int)frmError.ShowDialog((IWin32Window)this);
                        frmError.Close();
                    }
                    else
                    {
                        frmZDsel frmZdsel = Settings.Default.paraKeyB != 18 ? new frmZDsel("“返回”退出", Keys.Escape) : new frmZDsel("“ F2 ”退出", Keys.F2);
                        DialogResult dialogResult = frmZdsel.ShowDialog((IWin32Window)this);
                        frmZdsel.Close();
                        if (dialogResult == DialogResult.OK)
                        {
                            this.DLditou = Convert.ToInt32(frmZdsel.lblDT.Text) - 1;
                            this.DLcheng = Convert.ToInt32(frmZdsel.lblCheng.Text) - 1;
                            this.DLrl = frmZdsel.lblRL.Text;
                            this.DLzlyc = new Decimal(0);
                            this.DLzlall = Convert.ToDecimal(frmZdsel.txtZL.Text) * new Decimal(1000);
                            this.DLzlmb = new Decimal(0);
                            this.DLzlok = new Decimal(0);
                            this.DLerrTPCount = 0;
                            this.DLerrPLCcount = 0;
                            this.DLokCount = 0;
                            this.DLallowKey = false;
                            this.ZDstart();
                        }
                    }
                    this.lblKeyS.Text = "";
                }
                else
                {
                    if (e.KeyCode != Keys.D0 && e.KeyCode != Keys.NumPad0)
                        return;
                    this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\ding.wav";
                    this.TSsound.Play();
                    if (this.lblKeyS.Text.Length == 2)
                    {
                        for (int index = 0; index < UserProc.DLparaDT.Length; ++index)
                            this.cheng[index].setZERO();
                    }
                    this.lblKeyS.Text = "";
                }
            }
            else
            {
                if (this.staDL != frmDL.enumSta.表单滴料正在 && this.staDL != frmDL.enumSta.直接滴料正在 || !this.DLallowKey || e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete)
                    return;
                this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\ding.wav";
                this.TSsound.Play();
                this.DLtimer.Stop();
                this.plcDL.setD0(0);
                this.TSsound.SoundLocation = Application.StartupPath + "\\Sound\\ding.wav";
                this.TSsound.Play();
                this.lblTS.Visible = false;
                frmTS frmTs = Settings.Default.paraKeyB != 18 ? new frmTS(this.DLrl, this.DLcheng, this.DLditou, "确定取消滴料吗!!!", "“确认”退出滴料", "“返回”继续滴料", Keys.Escape) : new frmTS(this.DLrl, this.DLcheng, this.DLditou, "确定取消滴料吗!!!", "“确认”退出滴料", "“ F2 ”继续滴料", Keys.F2);
                DialogResult dialogResult = frmTs.ShowDialog((IWin32Window)this);
                frmTs.Close();
                this.lblTS.Visible = true;
                switch (dialogResult)
                {
                    case DialogResult.OK:
                        Decimal num = !this.cheng[this.DLcheng].showVal.HasValue ? new Decimal(0) : this.cheng[this.DLcheng].showVal.Value;
                        this.DLzlok += num;
                        if (this.DLzlok + num > (Decimal)this.minDLZL)
                        {
                            this.DLsave();
                            if (this.staDL == frmDL.enumSta.表单滴料正在)
                                this.dgvData.CurrentRow.Cells[this.colDL.Name].Value = (object)((this.DLzlok + this.DLzlyc) / new Decimal(1000));
                        }
                        this.DLend();
                        break;
                    case DialogResult.Cancel:
                        this.DLtimer.Start();
                        break;
                }
            }
        }
    }
}

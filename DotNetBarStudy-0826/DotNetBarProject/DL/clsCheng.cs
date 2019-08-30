using DotNetBarProject.view.custom.data;
using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using static DotNetBarProject.view.custom.data.leibie;

namespace DotNetBarProject.DL
{
    public partial class clsCheng : SerialPort
    {
        private Decimal? _showVal = new Decimal?();
        private Decimal? _maoVal = new Decimal?();
        private bool _WenDing = false;
        private StruChengPara _chengPara;
        

        public StruChengPara chengPara
        {
            get
            {
                return this._chengPara;
            }
            set
            {
                this._chengPara = value;
            }
        }

        public Decimal? showVal
        {
            get
            {
                return this._showVal;
            }
            set
            {
                this._showVal = value;
            }
        }

        public Decimal? maoVal
        {
            get
            {
                return this._maoVal;
            }
            set
            {
                this._maoVal = value;
            }
        }

        public bool WenDing
        {
            get
            {
                return this._WenDing;
            }
            set
            {
                this._WenDing = value;
            }
        }

        private void getVal_AND()
        {
            string str1 = this.ReadExisting();
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            int num = str1.LastIndexOf('g');
            int startIndex = num - 13;
            if (num >= 0 && startIndex >= 0)
            {
                string str2 = str1.Substring(startIndex, 13);
                this.WenDing = !str2.StartsWith("SD");
                string str3 = str2.Trim('S', 'D', ' ');
                if (str3 != "" && UserProc.IsNumeric(str3))
                {
                    this.showVal = new Decimal?(Convert.ToDecimal(str3) / new Decimal(1000));
                }
                else
                {
                    this.showVal = new Decimal?();
                    this.WenDing = false;
                }
            }
            else
            {
                this.showVal = new Decimal?();
                this.WenDing = false;
            }
        }

        private void getVal_OHAUS()
        {
            string str1 = this.ReadExisting();
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            int startIndex = -1;
            int num = str1.LastIndexOf("g?");
            if (num >= 0)
            {
                this.WenDing = false;
            }
            else
            {
                num = str1.LastIndexOf("g\r");
                if (num >= 0)
                    this.WenDing = true;
            }
            if (num - 3 >= 0)
                startIndex = str1.LastIndexOf(' ', num - 3);
            if (num >= 0 && startIndex >= 0)
            {
                string str2 = str1.Substring(startIndex, num - startIndex).Trim();
                if (str2 != "" && UserProc.IsNumeric(str2))
                {
                    this.showVal = new Decimal?(Convert.ToDecimal(str2));
                }
                else
                {
                    this.showVal = new Decimal?();
                    this.WenDing = false;
                }
            }
            else
            {
                this.showVal = new Decimal?();
                this.WenDing = false;
            }
        }
        Boolean isFrist = true;
        private void getVal_ZHUOJING()
        {
            string str1 = this.ReadExisting();
            if(str1.Length == 0)
            {
                this.WenDing = true;
                if(isFrist)
                {
                    this.showVal = new Decimal?(Convert.ToDecimal("0.00"));
                }
                return;
            }
            isFrist = false;
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            int num = str1.LastIndexOf("g");
            int startIndex = num - 10;
            if (num >= 0 && startIndex >= 0)
            {
                string str2 = str1.Substring(startIndex, 10);
                this.WenDing = UserProc.IsNumeric(str2); //str2.IndexOf("0.00") >= 0; // .StartsWith("S");
                string str3 = str2.Substring(1);
                bool flag = !str3.StartsWith("-");
                string str4 = str3.Trim('-', ' ').Trim();
                if (str4 != "" && UserProc.IsNumeric(str4))
                {
                    this.showVal = new Decimal?(Convert.ToDecimal(str4));
                    if (flag)
                        return;
                    Decimal? showVal = this.showVal;
                    this.showVal = showVal.HasValue ? new Decimal?(-showVal.GetValueOrDefault()) : new Decimal?();
                }
                else
                {
                    this.showVal = new Decimal?();
                    this.WenDing = false;
                }
            }
            else
            {
                this.showVal = new Decimal?();
                this.WenDing = false;
            }
        }

        private void getVal_XK3190C8()
        {
            byte[] buffer = new byte[7]
            {
        (byte) 0,
        (byte) 2,
        (byte) 65,
        (byte) 67,
        (byte) 48,
        (byte) 50,
        (byte) 3
            };
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            this.Write(buffer, 0, 7);
            Thread.Sleep(150);
            string str1 = this.ReadExisting();
            if (str1.Length == 14)
            {
                string str2 = str1.Substring(3, 8);
                if (UserProc.IsNumeric(str2))
                {
                    this.showVal = new Decimal?(Convert.ToDecimal(str2) * new Decimal(1000));
                    this.WenDing = true;
                }
                else
                {
                    this.showVal = new Decimal?();
                    this.WenDing = false;
                }
            }
            else
            {
                this.showVal = new Decimal?();
                this.WenDing = false;
            }
        }

        private void getVal_Tscale_AHW()
        {
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            this.Write("R");
            Thread.Sleep(100);
            string str1 = this.ReadExisting();
            if (str1.Length == 19)
            {
                string str2 = str1.Substring(6, 8);
                bool flag = !str2.StartsWith("-");
                string str3 = str2.Trim('-', ' ');
                if (UserProc.IsNumeric(str3))
                {
                    this.showVal = new Decimal?(Convert.ToDecimal(str3));
                    Decimal? showVal;
                    if (!flag)
                    {
                        showVal = this.showVal;
                        this.showVal = showVal.HasValue ? new Decimal?(-showVal.GetValueOrDefault()) : new Decimal?();
                    }
                    if (str1.Substring(15, 2) == "kg")
                    {
                        showVal = this.showVal;
                        this.showVal = showVal.HasValue ? new Decimal?(showVal.GetValueOrDefault() * new Decimal(1000)) : new Decimal?();
                    }
                    if (str1.StartsWith("ST,"))
                        this.WenDing = true;
                    else
                        this.WenDing = false;
                }
                else
                {
                    this.showVal = new Decimal?();
                    this.WenDing = false;
                }
            }
            else
            {
                this.showVal = new Decimal?();
                this.WenDing = false;
            }
        }

        private void getVal_Tscale_QHW()
        {
            string str1 = this.ReadExisting();
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            int num = str1.LastIndexOf('g');
            int startIndex = num - 16;
            if (num >= 0 && startIndex >= 0)
            {
                string str2 = str1.Substring(startIndex, 17);
                string str3 = str2.Substring(6, 8);
                bool flag = !str3.StartsWith("-");
                string str4 = str3.Trim('-', ' ');
                if (UserProc.IsNumeric(str4))
                {
                    this.showVal = new Decimal?(Convert.ToDecimal(str4));
                    Decimal? showVal;
                    if (!flag)
                    {
                        showVal = this.showVal;
                        this.showVal = showVal.HasValue ? new Decimal?(-showVal.GetValueOrDefault()) : new Decimal?();
                    }
                    if (str2.Substring(15, 2) == "kg")
                    {
                        showVal = this.showVal;
                        this.showVal = showVal.HasValue ? new Decimal?(showVal.GetValueOrDefault() * new Decimal(1000)) : new Decimal?();
                    }
                    if (str2.StartsWith("ST,"))
                        this.WenDing = true;
                    else
                        this.WenDing = false;
                }
                else
                {
                    this.showVal = new Decimal?();
                    this.WenDing = false;
                }
            }
            else
            {
                this.showVal = new Decimal?();
                this.WenDing = false;
            }
        }

        private void getVal_Tscale_NB()
        {
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            this.Write("R");
            Thread.Sleep(100);
            string str1 = this.ReadExisting();
            if (str1.Length == 18)
            {
                string str2 = str1.Substring(5, 8);
                bool flag = !str2.StartsWith("-");
                string str3 = str2.Trim('-', ' ');
                if (UserProc.IsNumeric(str3))
                {
                    this.showVal = new Decimal?(Convert.ToDecimal(str3));
                    Decimal? showVal;
                    if (!flag)
                    {
                        showVal = this.showVal;
                        this.showVal = showVal.HasValue ? new Decimal?(-showVal.GetValueOrDefault()) : new Decimal?();
                    }
                    if (str1.Substring(14, 2) == "kg")
                    {
                        showVal = this.showVal;
                        this.showVal = showVal.HasValue ? new Decimal?(showVal.GetValueOrDefault() * new Decimal(1000)) : new Decimal?();
                    }
                    if (str1.StartsWith("ST,"))
                        this.WenDing = true;
                    else
                        this.WenDing = false;
                }
                else
                {
                    this.showVal = new Decimal?();
                    this.WenDing = false;
                }
            }
            else
            {
                this.showVal = new Decimal?();
                this.WenDing = false;
            }
        }

        private void getVal_Tscale_T2000()
        {
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            this.Write("R");
            Thread.Sleep(100);
            string str1 = this.ReadExisting();
            if (str1.Length == 17)
            {
                string str2 = str1.Substring(5, 8);
                bool flag = !str2.StartsWith("-");
                string str3 = str2.Trim('-', ' ');
                if (UserProc.IsNumeric(str3))
                {
                    this.showVal = new Decimal?(Convert.ToDecimal(str3));
                    Decimal? showVal;
                    if (!flag)
                    {
                        showVal = this.showVal;
                        this.showVal = showVal.HasValue ? new Decimal?(-showVal.GetValueOrDefault()) : new Decimal?();
                    }
                    if (str1.Substring(13, 2) == "kg")
                    {
                        showVal = this.showVal;
                        this.showVal = showVal.HasValue ? new Decimal?(showVal.GetValueOrDefault() * new Decimal(1000)) : new Decimal?();
                    }
                    if (str1.StartsWith("ST,"))
                        this.WenDing = true;
                    else
                        this.WenDing = false;
                }
                else
                {
                    this.showVal = new Decimal?();
                    this.WenDing = false;
                }
            }
            else
            {
                this.showVal = new Decimal?();
                this.WenDing = false;
            }
        }

        public void getVal()
        {
            this.showVal = new Decimal?();
            this.WenDing = false;
            if (!this.IsOpen)
                return;
            switch (this.chengPara.chengXH)
            {
                case enumCheng.AND:
                    this.getVal_AND();
                    break;
                case enumCheng.OHAUS:
                    this.getVal_OHAUS();
                    break;
                case enumCheng.ZHUOJING:
                    this.getVal_ZHUOJING();
                    break;
                case enumCheng.XK3190C8:
                    this.getVal_XK3190C8();
                    break;
                case enumCheng.Tscale_AHW:
                    this.getVal_Tscale_AHW();
                    break;
                case enumCheng.Tscale_QHW:
                    this.getVal_Tscale_QHW();
                    break;
                case enumCheng.Tscale_NB:
                    this.getVal_Tscale_NB();
                    break;
                case enumCheng.Tscale_T2000:
                    this.getVal_Tscale_T2000();
                    break;
            }
        }

        private void getMao_XK3190C8()
        {
            byte[] buffer = new byte[7]
            {
        (byte) 0,
        (byte) 2,
        (byte) 65,
        (byte) 66,
        (byte) 48,
        (byte) 51,
        (byte) 3
            };
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            this.Write(buffer, 0, 7);
            Thread.Sleep(150);
            string str1 = this.ReadExisting();
            if (str1.Length == 14)
            {
                string str2 = str1.Substring(3, 8);
                if (UserProc.IsNumeric(str2))
                {
                    this.maoVal = new Decimal?(Convert.ToDecimal(str2) * new Decimal(1000));
                    this.WenDing = true;
                }
                else
                {
                    this.maoVal = new Decimal?();
                    this.WenDing = false;
                }
            }
            else
            {
                this.maoVal = new Decimal?();
                this.WenDing = false;
            }
        }

        public void getMao()
        {
            this.maoVal = new Decimal?();
            this.WenDing = false;
            if (!this.IsOpen)
                return;
            switch (this.chengPara.chengXH)
            {
                case enumCheng.XK3190C8:
                    this.getMao_XK3190C8();
                    break;
            }
        }

        private void setZERO_AND_OHAUS()
        {
            this.Write("T\r\n");
        }

        private void setZERO_ZHUOJING()
        {
            this.Write("T\r\n");
        }

        private void setZERO_XK3190C8()
        {
            byte[] buffer = new byte[7]
            {
        (byte) 0,
        (byte) 2,
        (byte) 65,
        (byte) 69,
        (byte) 48,
        (byte) 52,
        (byte) 3
            };
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            this.Write(buffer, 0, 7);
        }

        private void setZERO_Tscale_AHW_QHW_NB_T2000()
        {
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            this.Write("Z");
        }

        public bool setZERO()
        {
            if (!this.IsOpen)
            {
                int num = (int)MessageBox.Show("串口未打开!!!", "提示");
                return false;
            }
            switch (this.chengPara.chengXH)
            {
                case enumCheng.AND:
                case enumCheng.OHAUS:
                    this.setZERO_AND_OHAUS();
                    break;
                case enumCheng.ZHUOJING:
                    this.setZERO_ZHUOJING();
                    break;
                case enumCheng.XK3190C8:
                    this.setZERO_XK3190C8();
                    break;
                case enumCheng.Tscale_AHW:
                case enumCheng.Tscale_QHW:
                case enumCheng.Tscale_NB:
                case enumCheng.Tscale_T2000:
                    this.setZERO_Tscale_AHW_QHW_NB_T2000();
                    break;
            }
            return true;
        }

        public bool com_open()
        {
            if (this.IsOpen)
                this.com_close();
            this.showVal = new Decimal?();
            this.maoVal = new Decimal?();
            this.WenDing = false;
            this.Open();
            return true;
        }

        public void com_close()
        {
            if (!this.IsOpen)
                return;
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            this.Close();
        }
    }
}

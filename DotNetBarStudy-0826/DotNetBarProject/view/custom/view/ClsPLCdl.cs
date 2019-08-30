using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace DotNetBarProject.view.custom.view
{
    public partial class ClsPLCdl : SerialPort
    {
        public int rM0 = 256;
        public int rM8 = 257;
        public int rM16 = 258;
        public int wM0 = 2048;
        public int wM20 = 2068;
        public int wM21 = 2069;
        public int wM22 = 2070;
        public int D0 = 4096;
        public int D1 = 4098;
        public int D2 = 4100;
        public int D3 = 4102;
        public int D4 = 4104;
        public int D5 = 4106;
        public int D6 = 4108;
        public int D7 = 4110;
        private int _RWokReadDelay = 100;

        public int RWokReadDelay
        {
            get
            {
                return this._RWokReadDelay;
            }
            set
            {
                this._RWokReadDelay = value;
            }
        }
        public void com_open()
        {
            if (this.IsOpen)
                this.com_close();
            this.Open();
        }

        public void com_close()
        {
            if (!this.IsOpen)
                return;
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            this.Close();
        }

        public bool setD0(int val0)
        {
            byte[] buffer = new byte[15];
            buffer[0] = (byte)2;
            buffer[1] = (byte)49;
            string str1 = this.D0.ToString("X4");
            buffer[2] = (byte)str1[0];
            buffer[3] = (byte)str1[1];
            buffer[4] = (byte)str1[2];
            buffer[5] = (byte)str1[3];
            string str2 = 2.ToString("X2");
            buffer[6] = (byte)str2[0];
            buffer[7] = (byte)str2[1];
            string str3 = val0.ToString("X4");
            buffer[8] = (byte)str3[2];
            buffer[9] = (byte)str3[3];
            buffer[10] = (byte)str3[0];
            buffer[11] = (byte)str3[1];
            buffer[12] = (byte)3;
            int num = 0;
            for (int index = 1; index <= 12; ++index)
                num += (int)buffer[index];
            string str4 = (num % 256).ToString("X2");
            buffer[13] = (byte)str4[0];
            buffer[14] = (byte)str4[1];
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            this.Write(buffer, 0, 15);
            Thread.Sleep(this.RWokReadDelay);
            string str5 = this.ReadExisting();
            if (str5.Length == 0)
            {
                Thread.Sleep(this.RWokReadDelay);
                str5 = this.ReadExisting();
            }
            return str5.Length == 1 && (byte)str5[0] == (byte)6;
        }

        public bool setD1_7(int val1, int val2, int val3, int val4, int val5, int val6, int val7)
        {
            byte[] buffer = new byte[39];
            buffer[0] = (byte)2;
            buffer[1] = (byte)49;
            string str1 = this.D1.ToString("X4");
            buffer[2] = (byte)str1[0];
            buffer[3] = (byte)str1[1];
            buffer[4] = (byte)str1[2];
            buffer[5] = (byte)str1[3];
            string str2 = 14.ToString("X2");
            buffer[6] = (byte)str2[0];
            buffer[7] = (byte)str2[1];
            string str3 = val1.ToString("X4");
            buffer[8] = (byte)str3[2];
            buffer[9] = (byte)str3[3];
            buffer[10] = (byte)str3[0];
            buffer[11] = (byte)str3[1];
            string str4 = val2.ToString("X4");
            buffer[12] = (byte)str4[2];
            buffer[13] = (byte)str4[3];
            buffer[14] = (byte)str4[0];
            buffer[15] = (byte)str4[1];
            string str5 = val3.ToString("X4");
            buffer[16] = (byte)str5[2];
            buffer[17] = (byte)str5[3];
            buffer[18] = (byte)str5[0];
            buffer[19] = (byte)str5[1];
            string str6 = val4.ToString("X4");
            buffer[20] = (byte)str6[2];
            buffer[21] = (byte)str6[3];
            buffer[22] = (byte)str6[0];
            buffer[23] = (byte)str6[1];
            string str7 = val5.ToString("X4");
            buffer[24] = (byte)str7[2];
            buffer[25] = (byte)str7[3];
            buffer[26] = (byte)str7[0];
            buffer[27] = (byte)str7[1];
            string str8 = val6.ToString("X4");
            buffer[28] = (byte)str8[2];
            buffer[29] = (byte)str8[3];
            buffer[30] = (byte)str8[0];
            buffer[31] = (byte)str8[1];
            string str9 = val7.ToString("X4");
            buffer[32] = (byte)str9[2];
            buffer[33] = (byte)str9[3];
            buffer[34] = (byte)str9[0];
            buffer[35] = (byte)str9[1];
            buffer[36] = (byte)3;
            int num = 0;
            for (int index = 1; index <= 36; ++index)
                num += (int)buffer[index];
            string str10 = (num % 256).ToString("X2");
            buffer[37] = (byte)str10[0];
            buffer[38] = (byte)str10[1];
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            this.Write(buffer, 0, 39);
            Thread.Sleep(this.RWokReadDelay);
            string str11 = this.ReadExisting();
            if (str11.Length == 0)
            {
                Thread.Sleep(this.RWokReadDelay);
                str11 = this.ReadExisting();
            }
            return str11.Length == 1 && (byte)str11[0] == (byte)6;
        }

        public bool setVal(int port, bool val)
        {
            byte[] buffer = new byte[9];
            buffer[0] = (byte)2;
            buffer[1] = val ? (byte)55 : (byte)56;
            string str1 = port.ToString("X4");
            buffer[2] = (byte)str1[2];
            buffer[3] = (byte)str1[3];
            buffer[4] = (byte)str1[0];
            buffer[5] = (byte)str1[1];
            buffer[6] = (byte)3;
            string str2 = (((int)buffer[1] + (int)buffer[2] + (int)buffer[3] + (int)buffer[4] + (int)buffer[5] + (int)buffer[6]) % 256).ToString("X2");
            buffer[7] = (byte)str2[0];
            buffer[8] = (byte)str2[1];
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            this.Write(buffer, 0, 9);
            Thread.Sleep(this.RWokReadDelay);
            string str3 = this.ReadExisting();
            if (str3.Length == 0)
            {
                Thread.Sleep(this.RWokReadDelay);
                str3 = this.ReadExisting();
            }
            return str3.Length == 1 && (byte)str3[0] == (byte)6;
        }

        public string readVal(int port, int len)
        {
            byte[] buffer = new byte[11];
            buffer[0] = (byte)2;
            buffer[1] = (byte)48;
            string str1 = port.ToString("X4");
            buffer[2] = (byte)str1[0];
            buffer[3] = (byte)str1[1];
            buffer[4] = (byte)str1[2];
            buffer[5] = (byte)str1[3];
            string str2 = len.ToString("X2");
            buffer[6] = (byte)str2[0];
            buffer[7] = (byte)str2[1];
            buffer[8] = (byte)3;
            string str3 = (((int)buffer[1] + (int)buffer[2] + (int)buffer[3] + (int)buffer[4] + (int)buffer[5] + (int)buffer[6] + (int)buffer[7] + (int)buffer[8]) % 256).ToString("X2");
            buffer[9] = (byte)str3[0];
            buffer[10] = (byte)str3[1];
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
            this.Write(buffer, 0, 11);
            Thread.Sleep(this.RWokReadDelay);
            string str4 = this.ReadExisting();
            if (str4.Length == 0)
            {
                Thread.Sleep(this.RWokReadDelay);
                str4 = this.ReadExisting();
            }
            if (str4.Length > 3)
            {
                int num = 0;
                for (int index = 1; index < str4.Length - 2; ++index)
                    num += (int)(byte)str4[index];
                string str5 = num.ToString("X2");
                if ((int)(byte)str5[0] != (int)(byte)str4[str4.Length - 2] || (int)(byte)str5[1] != (int)(byte)str4[str4.Length - 1])
                    str4 = "";
            }
            else
                str4 = "";
            return str4;
        }
    }
}


using System.IO.Ports;
using System.Threading;
namespace DotNetBarProject.ChenLiao
{
    public partial class clsPLCcl : SerialPort
    {
        public int D0 = 4096;
        public int D1 = 4098;
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

        public bool com_close()
        {
            try
            {
                if (this.IsOpen)
                {
                    this.DiscardInBuffer();
                    this.DiscardOutBuffer();
                    this.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool OpenDeng(int denghao)
        {
            if (denghao < 0 || denghao > 64)
                return false;
            try
            {
                byte[] buffer = new byte[19];
                buffer[0] = (byte)2;
                buffer[1] = (byte)49;
                string str1 = this.D0.ToString("X4");
                buffer[2] = (byte)str1[0];
                buffer[3] = (byte)str1[1];
                buffer[4] = (byte)str1[2];
                buffer[5] = (byte)str1[3];
                int num1 = 4;
                string str2 = num1.ToString("X2");
                buffer[6] = (byte)str2[0];
                buffer[7] = (byte)str2[1];
                string str3;
                if (denghao == 0)
                {
                    num1 = 0;
                    str3 = num1.ToString("X4");
                }
                else
                {
                    num1 = 1 << (denghao - 1) % 8;
                    str3 = num1.ToString("X4");
                }
                buffer[8] = (byte)str3[2];
                buffer[9] = (byte)str3[3];
                buffer[10] = (byte)str3[0];
                buffer[11] = (byte)str3[1];
                string str4;
                if (denghao == 0)
                {
                    num1 = 0;
                    str4 = num1.ToString("X4");
                }
                else
                {
                    num1 = 1 << (denghao - 1) / 8;
                    str4 = num1.ToString("X4");
                }
                buffer[12] = (byte)str4[2];
                buffer[13] = (byte)str4[3];
                buffer[14] = (byte)str4[0];
                buffer[15] = (byte)str4[1];
                buffer[16] = (byte)3;
                int num2 = 0;
                for (int index = 1; index <= 16; ++index)
                    num2 += (int)buffer[index];
                string str5 = (num2 % 256).ToString("X2");
                buffer[17] = (byte)str5[0];
                buffer[18] = (byte)str5[1];
                this.DiscardInBuffer();
                this.DiscardOutBuffer();
                this.Write(buffer, 0, 19);
                Thread.Sleep(this.RWokReadDelay);
                string str6 = this.ReadExisting();
                if (str6.Length == 0)
                {
                    Thread.Sleep(this.RWokReadDelay);
                    str6 = this.ReadExisting();
                }
                return str6.Length == 1 && (byte)str6[0] == (byte)6;
            }
            catch
            {
                return false;
            }
        }
    }
}

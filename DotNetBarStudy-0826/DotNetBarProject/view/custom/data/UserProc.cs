using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Management;
using System.Drawing;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using BarcodeLib;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DotNetBarProject.view.custom.data
{
    class UserProc
    {
        public static string StrVer = "VH001.1";
        public static string GSname = "一统一车间ERP印染管理系统";
        public static Color colorWSH = Color.PaleGoldenrod;
        public static Color colorDel = Color.Pink;
        public static Color colorJL = Color.Moccasin;
        public static Color colorCL = Color.PowderBlue;
        public static int[] DLparaDT = new int[2] { 6, 6 };
        public static string CheckTime = "";
        public static void WaitStart(Form mainF)
        {
            mainF.Cursor = Cursors.WaitCursor;
            UserProc.doSomeThing();
        }

        public static void WaitEnd(Form mainF)
        {
            mainF.Cursor = Cursors.Default;
        }

        public static void doSomeThing()
        {
            Application.DoEvents();
            Application.DoEvents();
        }

        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value.Replace("g", "").Replace("+", "").Replace("-", "").Trim(), "^[+-]?\\d*[.]?\\d*$");
        }

        public static bool IsInt(string value)
        {
            return Regex.IsMatch(value, "^[+-]?\\d*$");
        }

        public static string getSerialNumber()
        {
            ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            managementObject.Get();
            string text = managementObject.GetPropertyValue("VolumeSerialNumber").ToString();
            return (Convert.ToInt64(text, 16) ^ Convert.ToInt64("".PadRight(text.Length, 'F'), 16) + 354665879L).ToString("X");
        }

        public static string getRegNumber()
        {
            string serialNumber = UserProc.getSerialNumber();
            return (Convert.ToInt64(serialNumber, 16) ^ Convert.ToInt64("".PadRight(serialNumber.Length, 'F'), 16) + 8734562189L).ToString("X");
        }
        public static int CompanyDate(string dateStr1, string dateStr2)
        {
            //将日期字符串转换为日期对象
            DateTime t1 = Convert.ToDateTime(dateStr1);
            DateTime t2 = Convert.ToDateTime(dateStr2);
            //通过DateTIme.Compare()进行比较（）
            int compNum = DateTime.Compare(t1, t2);

            return compNum;
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }
        public static Image GetBarcode(int height, int width, TYPE type, string code, bool sho=true)
        {
            Image image;
            try
            {
                image = new Barcode()
                {
                    Height = height,
                    Width = width,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    Alignment = AlignmentPositions.CENTER,
                    ImageFormat = ImageFormat.Bmp,
                    IncludeLabel = sho,
                    LabelFont = new Font("宋体", 15f, FontStyle.Bold),
                    LabelPosition = LabelPositions.BOTTOMCENTER
                }.Encode(type, code);
            }
            catch
            {
                image = (Image)null;
            }
            return image;
        }

        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }
    }
}

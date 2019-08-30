using SqlSugar;
using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetBarProject.view.custom.data
{
    class SqlBase
    {
        public static SqlSugarClient GetInstance()
        {
            try
            {
                // 正式版
                // string en = ConfigurationManager.AppSettings["ConnectionString"];
                // 测试版
                string en = "ZGF0YSBzb3VyY2U9bG9jYWxob3N0O2luaXRpYWwgY2F0YWxvZz1FUlA7dXNlciBpZD1zYTtwd2Q9";
                string de = EncodeAndDecode.DecodeBase64(en);
                var asd = new ConnectionConfig
                {
                    ConnectionString = de,//ConfigurationManager.AppSettings["ConnectionString"], 
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true
                };

                SqlSugarClient db = new SqlSugarClient(asd);
                
                db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value == DBNull.Value ? null : it.Value)));
                    Console.WriteLine();
                };
                
                return db;
            }
            catch(Exception e)
            {
                MessageBox.Show("数据库链接异常,请检查");
                return null;
            }
        }
    }
    /// <summary>
    /// 字符串简单加密
    /// </summary>
    public class EncodeAndDecode
    {
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="codeName">加密采用的编码方式</param>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string EncodeBase64(Encoding encode, string source)
        {
            string enstring = "";
            byte[] bytes = encode.GetBytes(source);
            try
            {
                enstring = Convert.ToBase64String(bytes);
            }
            catch
            {
                enstring = source;
            }
            return enstring;
        }

        /// <summary>
        /// Base64加密，采用utf8编码方式加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public static string EncodeBase64(string source)
        {
            return EncodeBase64(Encoding.UTF8, source);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="codeName">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(Encoding encode, string result)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encode.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }

        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(string result)
        {
            return DecodeBase64(Encoding.UTF8, result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Common
{
    /// <summary>
    /// 加密操作类
    /// </summary>
    public class CryptionData
    {
        //加密公钥
        private string encryptionString = "gz202129";
        //加密初始化向量
        private static byte[] encryptionIV = Encoding.Default.GetBytes("20926982");

        public CryptionData()
        { 
        }

        /// <summary>
        /// 带公钥的构造方法
        /// </summary>
        /// <param name="encryptionString">加密公钥字符串</param>
        public CryptionData(string encryptionString)
        {
            this.encryptionString = encryptionString;
        }

        /// <summary>
        /// 加密字节数组
        /// </summary>
        /// <param name="sourceData">未加密源数组</param>
        /// <returns>加密后字节数组</returns>
        public byte[] EncryptionByteData(byte[] sourceData)
        {
            byte[] returnData = null;
            try
            {
                DESCryptoServiceProvider descProvider = new DESCryptoServiceProvider();
                byte[] byteKey = Encoding.Default.GetBytes(encryptionString);
                descProvider.Key = byteKey;
                descProvider.IV = encryptionIV;

                MemoryStream ms = new MemoryStream();
                ICryptoTransform encrypto = descProvider.CreateEncryptor();
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
                cs.Write(sourceData, 0, sourceData.Length);
                cs.FlushFinalBlock();
                returnData = ms.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnData;
        }

        /// <summary>
        /// 解密字节数组
        /// </summary>
        /// <param name="sourceData">已加密源数组</param>
        /// <returns>解密后字节数组</returns>
        public byte[] DecryptionByteData(byte[] sourceData)
        {
            byte[] returnData = null;
            try
            {
                DESCryptoServiceProvider descProvider = new DESCryptoServiceProvider();
                byte[] byteKey = Encoding.Default.GetBytes(encryptionString);
                descProvider.Key = byteKey;
                descProvider.IV = encryptionIV;

                MemoryStream ms = new MemoryStream();
                ICryptoTransform encrypto = descProvider.CreateDecryptor();
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
                cs.Write(sourceData, 0, sourceData.Length);
                cs.FlushFinalBlock();
                returnData = ms.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnData;
        }

       /// <summary>
       /// 加密字符串
       /// </summary>
       /// <param name="sourceString">未加密源字符串</param>
       /// <returns>加密后字符串</returns>
        public string EncryptionString(string sourceString)
        {
            sourceString.Replace("|",";,.");
            sourceString.Replace("=", "#%#");
            byte[] sourceData = Encoding.Default.GetBytes(sourceString);
            byte[] returnData = EncryptionByteData(sourceData);
            return Convert.ToBase64String(returnData);
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="sourceString">已加密源字符串</param>
        /// <returns>解密后字符串</returns>
        public string DecryptionString(string sourceString)
        {
            sourceString.Replace(";,.", "|");
            sourceString.Replace("#%#", "=");
            byte[] sourceData = Convert.FromBase64String(sourceString);
            byte[] returnData = DecryptionByteData(sourceData);
            return Encoding.Default.GetString(returnData);
        }

        /// <summary>
        /// MD5加密字符串
        /// </summary>
        /// <param name="sourceString">未加密源字符串</param>
        /// <returns>加密后字符串</returns>
        public static string EncryptionMD5String(string sourceString)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] sourceData = Encoding.Default.GetBytes(sourceString);
            byte[] returnData = md5Hasher.ComputeHash(sourceData);
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < returnData.Length; i++)
            {
                strBuilder.Append(returnData[i].ToString("X2"));
            }
            return strBuilder.ToString();
        }
    }
}

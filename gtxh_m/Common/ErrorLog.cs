using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;

namespace gtxh_m.Common
{
    /// <summary>
    /// 处理错误异常信息的日志录入。
    /// </summary>
    public class ErrorLog
    {
        /// <summary>
        /// 添加错误日志
        /// </summary>
        /// <param name="msg"></param>
        public static void AddErrorLog(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(msg);
            sb.AppendLine();
            string fileName = GetFileName();
            try
            {
                if (File.Exists(fileName)) File.SetAttributes(fileName, FileAttributes.Normal);
                File.AppendAllText(GetFileName(), sb.ToString(), Encoding.UTF8);
            }
            catch { }
        }
        /// <summary>
        /// 添加错误日志
        /// </summary>
        /// <param name="ex">异常对象</param>
        public static void AddErrorLog(Exception ex, string location = "")
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(location + "  =>" + ex.Message);
            sb.AppendLine(ex.StackTrace);
            sb.AppendLine();
            string fileName = GetFileName();
            try
            {
                if (File.Exists(fileName))
                    File.SetAttributes(fileName, FileAttributes.Normal);
                File.AppendAllText(GetFileName(), sb.ToString(), Encoding.UTF8);
            }
            catch { }
        }
        private static string GetFileName()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Content\\Logs\\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return  path + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
        }
    }
}
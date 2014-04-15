using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.SessionState;

namespace Common
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
            sb.AppendLine(DateTime.Now.ToString() + "-" + HttpContext.Current.Session["Crm_PersonnelName"]);
            sb.AppendLine(msg);
            sb.AppendLine();
            string fileName = GetFileName();
            if (File.Exists(fileName)) File.SetAttributes(fileName, FileAttributes.Normal);
            File.AppendAllText(GetFileName(), sb.ToString(), Encoding.UTF8);
        }
        /// <summary>
        /// 添加错误日志
        /// </summary>
        /// <param name="ex">异常对象</param>
        public static void AddErrorLog(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString() + "-" + HttpContext.Current.Session["Crm_PersonnelName"]);
            sb.AppendLine(ex.Message);
            sb.AppendLine(ex.StackTrace);
            sb.AppendLine();
            string fileName = GetFileName();
            if (File.Exists(fileName))
                File.SetAttributes(fileName, FileAttributes.Normal);
            File.AppendAllText(GetFileName(), sb.ToString(), Encoding.UTF8);
        }
        private static string GetFileName()
        {
            return HttpContext.Current.Server.MapPath("/ErrorLog/") + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
        }
    }
}

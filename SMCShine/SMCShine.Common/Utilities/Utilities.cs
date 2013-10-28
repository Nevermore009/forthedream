using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SMCShine.Common
{
   public class Utilities
    {
        /// <summary>
        /// 获取当前http请求的客户端IP
        /// </summary>
        /// <param name="request">http请求</param>
        /// <returns>IP地址</returns>
        public static string GetIPAddress(HttpRequest request)
        {
            string ip = "";

            if (request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(',')[0];
            }
            else
            {
                ip = request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            return ip;
        }

        /// <summary>
        /// 获取当前http请求的客户端IP
        /// </summary>
        /// <returns>IP地址</returns>
        public static string GetIPAddress()
        {
            if (HttpContext.Current != null)
                return GetIPAddress(HttpContext.Current.Request);
            else
                return "";
        }
    }
}

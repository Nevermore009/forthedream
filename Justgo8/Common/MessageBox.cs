using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common
{
    public class MessageBox
    {
        public static void Show(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

        /// <summary>
        /// 输出自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
        }
    }
}
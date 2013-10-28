using System;
using System.Text;
namespace SMCShine.Common
{
    /// <summary>
    /// 显示消息提示对话框。
    /// Copyright (C) Maticsoft
    /// </summary>
    public class MessageBox
    {
        private MessageBox()
        {
        }

        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

        /// <summary>
        /// 控件点击 消息确认提示框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        {
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }

        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", string.Format("<script language='javascript' defer>alert('{0}');window.location=\"{1}\"</script>", msg, url));
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

        /// <summary>
        /// 弹出消息并自动打印
        /// </summary>
        /// <param name="page"></param>
        /// <param name="messages"></param>
        public static void ResponseAndPrint(System.Web.UI.Page page, string messages,string billNumber,string campusGuid)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "messge", string.Format("<script language='javascript' defer>alert('{0}');printBill('{1}','{2}');</script>", messages,billNumber,campusGuid));
        }

    }
}
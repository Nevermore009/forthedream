using System;
using System.Text;
namespace SMCShine.Common
{
    /// <summary>
    /// ��ʾ��Ϣ��ʾ�Ի���
    /// Copyright (C) Maticsoft
    /// </summary>
    public class MessageBox
    {
        private MessageBox()
        {
        }

        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static void Show(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

        /// <summary>
        /// �ؼ���� ��Ϣȷ����ʾ��
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        {
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }

        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="url">��ת��Ŀ��URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", string.Format("<script language='javascript' defer>alert('{0}');window.location=\"{1}\"</script>", msg, url));
        }

        /// <summary>
        /// ����Զ���ű���Ϣ
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="script">����ű�</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");

        }

        /// <summary>
        /// ������Ϣ���Զ���ӡ
        /// </summary>
        /// <param name="page"></param>
        /// <param name="messages"></param>
        public static void ResponseAndPrint(System.Web.UI.Page page, string messages,string billNumber,string campusGuid)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "messge", string.Format("<script language='javascript' defer>alert('{0}');printBill('{1}','{2}');</script>", messages,billNumber,campusGuid));
        }

    }
}
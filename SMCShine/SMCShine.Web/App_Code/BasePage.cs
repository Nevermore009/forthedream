using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMCShine.Common;
/// <summary>
///BasePage 的摘要说明
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public BasePage()
    {
    }

    public void CheckUser()
    {
        if (HttpContext.Current.Request.Cookies["useraccount"] == null)
            MessageBox.ShowAndRedirect(this, "登录信息过期，请重新登录！", HttpContext.Current.Server.MapPath("~/index.aspx"));
    }
    public string UserAccout
    {
        get
        {
            return AES.Decrypt(HttpContext.Current.Request.Cookies["useraccount"].Value);
        }
    }
    public string Campus
    {
        get
        {
            return AES.Decrypt(HttpContext.Current.Request.Cookies["campusguid"].Value);
        }
    }
    public string UserGroup
    {
        get
        {
            return AES.Decrypt(HttpContext.Current.Request.Cookies["usergroup"].Value);
        }
    }
    public string UserGroupName
    {
        get
        {
            return AES.Decrypt(HttpContext.Current.Request.Cookies["usergroupname"].Value);
        }
    }
}

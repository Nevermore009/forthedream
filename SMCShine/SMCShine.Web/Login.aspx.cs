using System;
using System.Web.Security;
using SMCShine.Common;
using SMCShine.Data;
using SMCShine.Data.Entities;
using SMCShine.Logic;
using System.Web;

public partial class Login : System.Web.UI.Page
{
    UserManager usermanager = new UserManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtusername.Focus();
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Session["validateCode"] == null || Session["validateCode"].ToString() != txtcode.Text)
        {
            lbwarn.Text = "验证码错误,请重新输入!";
            txtcode.Focus();
            return;
        }
        if (IsValid)
        {
            string userAcount = txtusername.Text;
            string password = txtpassword.Text;
            User model;
            UserManager.LoginResult result = usermanager.Login(userAcount, password, out model);
            switch (result)
            {
                case UserManager.LoginResult.UserNotExist:
                    lbwarn.Text = "用户不存在,请重新输入!";
                    txtusername.Focus();
                    return;
                case UserManager.LoginResult.IncorrectPwd:
                    lbwarn.Text = "用户名或密码错误,请重新输入!";
                    txtpassword.Focus();
                    return;
                case UserManager.LoginResult.ValidateSucceed:
                    LoginSuccess(model);
                    return;
                default:
                    lbwarn.Text = "系统忙,请稍后再试!";
                    txtpassword.Focus();
                    return;
            }
        }
    }

    protected void LoginSuccess(User model)
    {
        Session["UserAccount"] = model.UserAccount;        
        HttpCookie userAccount = new HttpCookie("useraccount", AES.Encrypt(model.UserAccount));
        HttpCookie userName = new HttpCookie("username", AES.Encrypt(model.Name));
        HttpCookie userGroup = new HttpCookie("usergroup", AES.Encrypt(model.UserGroup.Guid.ToString()));
        HttpCookie userGroupName = new HttpCookie("usergroupname", AES.Encrypt(model.UserGroup.Name));
        HttpCookie guid = new HttpCookie("guid", AES.Encrypt(model.Guid.ToString()));
        HttpCookie campusGuid = new HttpCookie("campusguid", AES.Encrypt(model.CampusGuid==null?Guid.Empty.ToString():model.CampusGuid.ToString()));
        Response.Cookies.Add(userAccount);
        Response.Cookies.Add(userName);
        Response.Cookies.Add(userGroup);
        Response.Cookies.Add(guid);
        Response.Cookies.Add(userGroupName);
        Response.Cookies.Add(campusGuid);
        FormsAuthentication.SetAuthCookie(model.Name, false);//匿名访问
        string url = "Common/defaultpage.aspx";
        lbwarn.Text = "登录成功,正在跳转到<a href='" + url + "'>首页</a>...";
        MessageBox.ResponseScript(this.Page, "parent.location.href='" + url + "'");
    }
}

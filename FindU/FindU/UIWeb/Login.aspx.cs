using System;
using System.Web.Security;
using Common;

public partial class Login : System.Web.UI.Page
{
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
        BLL.User userbll = new BLL.User();
        Model.User usermodel;
        if (IsValid)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;
            lbwarn.Text = username + password;
            int code = userbll.ValidateLogin(username, password, out usermodel);
            switch (code)
            {
                case -1:
                    lbwarn.Text = "用户不存在,请重新输入!";
                    txtusername.Focus();
                    return;
                case 0:
                    lbwarn.Text = "用户名或密码错误,请重新输入!";
                    txtpassword.Focus();
                    return;
                case 1:
                    Session["username"] = usermodel.UserName;
                    Session["realname"] = usermodel.RealName;
                    Session["roleid"] = usermodel.RoleID;
                    FormsAuthentication.SetAuthCookie(username, false);//匿名访问
                    string url = "";
                    if (usermodel.RoleID == "0")
                        url = "BackManage/defaultpage.aspx";
                    else
                        url = "Admin/defaultpage.aspx";
                    lbwarn.Text = "登录成功,正在跳转到<a href='" + url + "'>首页</a>...";
                    MessageBox.ResponseScript(this.Page, "parent.location.href='" + url + "'");
                    return;
                default:
                    lbwarn.Text = "系统忙,请稍后再试!";
                    txtpassword.Focus();
                    return;
            }
        }
    }
}

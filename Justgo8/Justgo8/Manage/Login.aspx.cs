using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Bll;
using System.Web.Security;

namespace SSD.Manage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" | txtUserPwd.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('用户名和密码不能为空');", true);
                return;
            }
            try
            {
                string VNum = Session["VNum"].ToString();
                ViewState["VNum"] = VNum;
            }
            catch
            {
                Response.Redirect("Login.aspx");
            }
            if (Request["txtCode"].Trim() == ViewState["VNum"].ToString())
            {
                DataTable dt = new DataTable();
                dt = BAdmin.GetTable(txtUserName.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    string pwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtUserPwd.Text.Trim(), "MD5");
                    string pwd1 = dt.Rows[0]["UserPwd"].ToString().Trim();
                    if (pwd1.Equals( pwd))
                    {
                        Session["Personnels"] = txtUserName.Text.Trim();
                        FormsAuthentication.SetAuthCookie(txtUserName.Text.Trim(), false);//匿名访问
                        Response.Redirect("/Manage/Welcome.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('密码错误');", true);
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('验证码错误');", true);
            }
        }
    }
}
using System;
using Advanced_Encryption_Standard;
using BLL;
using Common;


public partial class 个人设置_PasswordModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            MessageBox.ResponseScript(this.Page, "alert('由于您长时间没有进行操作,网页已过期,请重新登录!');parent.location.href ='../index.aspx';");
            return;
        }
        if(!IsPostBack)
        {
            txtold.Focus();          
        }
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {        
        if (Session["username"] == null)
        {
            MessageBox.ResponseScript(this.Page, "alert('由于您长时间没有进行操作,网页已过期,请重新登录!');parent.location.href ='../index.aspx';"); 
            return;
        }
        if (!IsValid)
            return;
        string username = Session["username"].ToString();
        BLL.User userbll = new BLL.User();
        Model.User model;
        int code = userbll.ValidateLogin(username, txtold.Text.Trim(), out model);
        switch (code)
        {
            case 0:
                MessageBox.Show(this.Page, "原密码不正确!");
                break;
            case 1:
                if(userbll.ChangePasswordByUsername(username,txtensure.Text))
                    MessageBox.ResponseScript(this.Page, "alert('修改密码成功!');location.href=PasswordModify.aspx");
                else
                    MessageBox.Show(this.Page, "系统繁忙,请稍后再试!");
                break;
            default:
                MessageBox.Show(this.Page, "系统繁忙,请稍后再试!");
                break;
        }        

    }
}

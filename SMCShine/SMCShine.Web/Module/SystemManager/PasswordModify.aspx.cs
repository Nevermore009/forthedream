using System;
using SMCShine.Common;
using SMCShine.Data.Entities;
using SMCShine.Logic;

public partial class 个人设置_PasswordModify : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            txtold.Focus();
        }
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        if (!IsValid)
            return;
        User user;
        string userAcount = AES.Decrypt(Request.Cookies["useraccount"].Value);
        if (string.IsNullOrEmpty(userAcount))
        {
            return;
        }
        UserManager usermanager = new UserManager();
        switch (usermanager.Login(userAcount, txtold.Text.Trim(), out user))
        {
            case UserManager.LoginResult.IncorrectPwd:
                MessageBox.Show(this.Page, "原密码不正确!");
                break;
            case UserManager.LoginResult.ValidateSucceed:
                if (usermanager.ChangePassWordById(user.Guid, txtensure.Text))
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

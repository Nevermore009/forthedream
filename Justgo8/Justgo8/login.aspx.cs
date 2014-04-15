using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Advanced_Encryption_Standard;
using System.Data;

namespace Justgo8
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtusername.Focus();
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            int result = Bll.BAccount.Validate(txtusername.Text, txtpassword.Text);
            switch (result)
            {
                case 0:
                    DataTable dt = Bll.BAccount.AccountInfo(txtusername.Text);
                    Session["username"] = txtusername.Text;
                    Session["phone"] = dt.Rows[0]["Phone"]??"";
                    string redirecturl = "";
                    if (String.IsNullOrEmpty(Request["returnurl"]))
                    {
                        redirecturl = "vip.aspx";
                    }
                    else
                    {
                        try
                        {
                            redirecturl = Request["returnurl"];
                        }
                        catch { redirecturl = "vip.aspx"; }
                    }
                    MessageBox.ResponseScript(this.Page, "window.location.href='" + redirecturl + "'");
                    break;
                case -1:
                    MessageBox.Show(this.Page, "用户名或密码错误");
                    break;
                case -2:
                    MessageBox.Show(this.Page, "用户名不存在");
                    break;
                default:
                    break;
            }
        }
    }
}
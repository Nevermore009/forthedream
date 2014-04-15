using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using System.Data;
using Advanced_Encryption_Standard;

namespace Justgo8
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtprotocol.Text = getprotocol();
                //                txtusername.Text = "游客" + DateTime.Now.ToString("mmssfff") ;
                txtusername.Focus();
            }
        }

        protected string getprotocol()
        {
            try
            {
                return Bll.BProtocol.getprotocol();
            }
            catch (Exception e)
            {
                ErrorLog.AddErrorLog(e.ToString());
                return "";
            }
        }

        protected void btnregister_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["VNum"] == null || Session["VNum"].ToString() != txtcode.Text)
                {
                    lbresult.Text = "验证码不正确!";
                    return;
                }
                else if (Bll.BAccount.add(txtusername.Text.Trim(), txtensure.Text, txtphone.Text, txtemail.Text) <= 0)
                {
                    lbresult.Text = "用户名已被占用!";
                    return;
                }
                else
                {
                    Session["username"] = txtusername.Text;
                    Session["phone"] = txtphone.Text;
                    string redirecturl = "";
                    if (String.IsNullOrEmpty(Request["returnurl"]))
                    {
                        redirecturl = "vip.aspx";
                    }
                    else
                    {
                        redirecturl = Request["returnurl"];

                    }
                    MessageBox.ResponseScript(this.Page, "alert('注册成功');window.location.href='" + redirecturl + "'");
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex.ToString());
                MessageBox.Show(this.Page, "注册失败");
            }
        }
    }
}
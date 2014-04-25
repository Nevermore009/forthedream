using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Common;

namespace Justgo8.Manage
{
    public partial class AddRule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["ruleid"]))
                    {
                        DataTable dt = new DataTable();
                        string id = Request.QueryString["ruleid"];
                        dt = Bll.BRule.RuleInfo(Convert.ToInt32(id));
                        if (dt.Rows.Count > 0)
                        {
                            txtcontent.Text = dt.Rows[0]["content"].ToString();
                            dropruletype.SelectedValue = dt.Rows[0]["ruletype"].ToString();
                            dropruletype.Enabled = false;
                            dropruletype.Visible = false;
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(Request["ruletype"]))
                        {
                            dropruletype.SelectedValue = Request["ruletype"];
                            dropruletype.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex.ToString());
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ruleid"]))
            {
                int res = Bll.BRule.update(txtcontent.Text, Convert.ToInt32(Request.QueryString["ruleid"]));
                if (res == 1)
                {
                    MessageBox.ResponseScript(this.Page, "alert('修改成功');parent.ReloadPage();");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtcontent.Text.Trim()))
                {
                    MessageBox.Show(this.Page, "内容不能为空");
                    return;
                }

                int res = Bll.BRule.add(int.Parse(dropruletype.SelectedValue), txtcontent.Text);
                if (res == 1)
                {
                    MessageBox.ResponseScript(this.Page, "alert('添加成功');parent.ReloadPage();");
                }
            }
        }
    }
}
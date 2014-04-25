using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Justgo8.Manage
{
    public partial class RuleManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ruletype;
                if (String.IsNullOrEmpty(Request["ruletype"]) || !int.TryParse(Request["ruletype"], out ruletype))
                {
                    Response.Redirect("Welcome.aspx");
                }
                else
                {
                    lbtitle.Text = (ruletype == 0 ? "成人规则管理" : "儿童规则管理");
                    BindRule(ruletype);
                }
            }
        }

        public void BindRule(int ruletype)
        {
            DataTable dt = new DataTable();
            dt = Bll.BRule.RuleInfo(ruletype);
            if (dt.Rows.Count > 0)
            {
                RPlank.DataSource = dt;
                RPlank.DataBind();
            }
            else
            {
                RPlank.DataSource = null;
                RPlank.DataBind();
            }
        }

        protected void RPlank_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int res = Bll.BRule.del(id);
                if (res == 1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "alert('删除成功')", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "alert('删除失败')", true);
                }
            }
        }
    }
}
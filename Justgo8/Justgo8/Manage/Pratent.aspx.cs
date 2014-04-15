using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Bll;

namespace justgo.Manage
{
    public partial class Pratent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                pratentInfo();
            }
        }

        public void pratentInfo()
        { 
            DataTable dt=new DataTable();
            dt=Bll.BPatent.pratentInfo();
            if(dt.Rows.Count>0)
            {
                RPlank.DataSource = dt;
                RPlank.DataBind();
            }
        }

        protected void RPlank_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int res = Bll.BPatent.del(id);
                if (res == 1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "alert('删除成功')", true);
                    pratentInfo();
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "alert('删除失败')", true);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Common;

namespace Justgo8
{
    public partial class vip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("login.aspx?returnurl=vip.aspx");
            }
            if (!IsPostBack)
            {
                BindOrders();
            }
        }

        protected void BindOrders()
        {
            try
            {
                DataTable dt = Bll.BOrders.GetOrders(Session["username"].ToString());
                if (dt.Rows.Count > 0)
                {
                    grvorders.DataSource = dt.DefaultView;
                    grvorders.DataBind();
                }
                else
                {
                    grvorders.DataSource = null;
                    grvorders.DataBind();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex.ToString());
            }
        }
    }
}
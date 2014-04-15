using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Justgo8.Manage
{
    public partial class TravelTypeManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTravelType();
            }
        }

        protected void BindTravelType()
        {
            DataTable dt = new DataTable();
            dt = Bll.BTravelType.TravelTypeInfo();
            if (dt.Rows.Count > 0)
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
                int res = Bll.BTravelType.del(id);
                if (res == 1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "alert('删除成功')", true);
                    BindTravelType();
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "alert('删除失败')", true);
                }
            }
        }
    }
}
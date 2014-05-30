using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Justgo8
{
    public partial class zyx : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindArea();
                BindZyxshow();
            }
        }
        protected void BindArea()
        {
            DataTable dt = new DataTable();
            dt = Bll.BArea.AreaOfTravelType(Bll.BTravelType.Zyx);
            if (dt.Rows.Count > 0)
            {
                RepeaterZyx.DataSource = dt;
                RepeaterZyx.DataBind();
            }
            else
            {
                RepeaterZyx.DataSource = null;
                RepeaterZyx.DataBind();
            }
        }

        protected void BindZyxshow()
        {
            DataTable dt = new DataTable();
            dt = Bll.BTravelDetail.TravelInfo(Bll.BTravelType.Zyx,16);
            if (dt.Rows.Count > 0)
            {
                repeateritem.DataSource = dt;
                repeateritem.DataBind();
            }
            else
            {
                repeateritem.DataSource = null;
                repeateritem.DataBind();
            }
        }
    }
}
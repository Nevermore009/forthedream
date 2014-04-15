using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Justgo8
{
    public partial class inland : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindArea();
            }
        }
        protected void BindArea()
        {
            DataTable dt = new DataTable();
            dt = Bll.BArea.AreaOfTravelType(Bll.BTravelType.Inland);
            if (dt.Rows.Count > 0)
            {
                RepeaterInland.DataSource = dt;
                RepeaterInland.DataBind();
            }
            else
            {
                RepeaterInland.DataSource = null;
                RepeaterInland.DataBind();
            }
        }
    }
}
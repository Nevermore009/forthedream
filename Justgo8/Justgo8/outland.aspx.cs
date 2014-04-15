using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Justgo8
{
    public partial class outland : System.Web.UI.Page
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
            dt = Bll.BArea.AreaOfTravelType(Bll.BTravelType.Outland);
            if (dt.Rows.Count > 0)
            {
                RepeaterOutland.DataSource = dt;
                RepeaterOutland.DataBind();
            }
            else
            {
                RepeaterOutland.DataSource = null;
                RepeaterOutland.DataBind();
            }
        }
    }
}
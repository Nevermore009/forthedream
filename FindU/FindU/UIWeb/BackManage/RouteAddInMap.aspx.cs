using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Admin_RouteAddInMap : System.Web.UI.Page
{
    public string PatrolXmlText { set; get; }
    private Patrol patrolbll = new Patrol();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["planinfoid"] != null)
            {
                PushTravelData(Request["planinfoid"]);
            }
            else
            {
                Response.Write("Invalid Request");
                Response.End();
            }
        }
    }

    protected void PushTravelData(string planinfoid)
    {
        PatrolXmlText = patrolbll.GetPatrolXml(planinfoid);
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Text;
using System.Data.SqlClient;
using BLL;

public partial class Admin_MapView : System.Web.UI.Page
{
    private Route routebll = new Route();
    private Patrol patrolbll = new Patrol();
    public string RouteXmlText { set; get; }
    public string TravelXmlText { set; get; }
    public string Lat { set; get; }
    public string Lon { set; get; }
  //public  string  feature = "";
  public bool flags;
    //feature表示要不要在地图上画出标记marker
    protected void Page_Load(object sender, EventArgs e)
    { 
    
        if (!IsPostBack)
        {
             flags = Request["flags"] == null ? false : true;
            string planid = Request["planid"];
            if (!string.IsNullOrEmpty(planid))
            {
               // feature = "yes";
                PushTravelData(planid);
                string routeid=routebll.GetRouteIDByPlanID(planid);
                PushRouteData(routeid);
            }
            else
            {
               // feature = "no";
                string routeid = Request["route"];
                if (!string.IsNullOrEmpty(routeid))
                {
                    PushRouteData(routeid);
                }
            }
            string lat=Request["lat"];
            string lon=Request["lon"];
            
            if (!string.IsNullOrEmpty(lat) && !string.IsNullOrEmpty(lon))
            {
                PushPointData(lat, lon);
            }
        }
    }
    protected void PushRouteData(string routeid)
    {
        RouteXmlText = routebll.GetRouteXml(routeid);
    }

    protected void PushTravelData(string planid)
    {
        TravelXmlText=patrolbll.GetPatrolXml(planid);
    }

    protected void PushPointData(string lat, string lon)
    {
        Lat = lat;
        Lon = lon;
    }
}

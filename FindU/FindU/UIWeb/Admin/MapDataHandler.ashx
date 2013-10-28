<%@ WebHandler Language="C#" Class="MapDataHandler" %>

using System;
using System.Web;

public class MapDataHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        try
        {
            if (context.Request["routeid"] == "*")
            {
                string xmldoc = (new BLL.Route()).GetAllRouteXml();
                context.Response.ContentType = "text/xml";
                context.Response.Write(xmldoc);
            }
            else if (context.Request["routeid"] != null)
            {
                string xmldoc = (new BLL.Route()).GetRouteXml(context.Request["routeid"]);
                context.Response.ContentType = "text/xml";
                context.Response.Write(xmldoc);
            }
            else if (context.Request["planinfoid"] != null)
            {
                string xmldoc = (new BLL.Patrol()).GetPatrolXml(context.Request["planinfoid"]);
                context.Response.ContentType = "text/xml";
                context.Response.Write(xmldoc);
            }
            else
                context.Response.Write("Invalid Request!");
        }
        catch
        {
            context.Response.Clear();
            context.Response.Write("Error!");
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
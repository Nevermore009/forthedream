<%@ WebHandler Language="C#" Class="Saverouteinf" %>

using System;
using System.Web;
using System.Xml;
using System.IO;
using System.Data;
using BLL;
public class Saverouteinf : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        XmlDocument doc = new XmlDocument();
        try
        {
            doc.Load(context.Request.InputStream);
        }
        catch
        {
            context.Response.Write("Error:Invalid Request");
            return;
        }
        if (doc != null)
        {
            XmlNodeList lis = doc.GetElementsByTagName("routeDescription");
            string routename = ((XmlNode)lis[0]).Attributes["routename"].Value;
            string routeremark = ((XmlNode)lis[0]).Attributes["routeRemark"].Value;
            Route routebll = new Route();
            string routeID = routebll.Add(routename, routeremark);
            XmlNodeList list = doc.GetElementsByTagName("stationDescription");
            int orderno = 1;
            foreach (XmlNode node in list)
            {
                Coordinate coordinate = new Coordinate(Convert.ToDouble(node.Attributes["lat"].Value), Convert.ToDouble(node.Attributes["lon"].Value));
                coordinate = CoordinateCorrection.GetCorrectCoordinate(coordinate);
                string lat = coordinate.Lat.ToString();
                string lon = coordinate.Lng.ToString();
                string stationname = "";
                string stationremark = "";
                if (node.Attributes["stationname"] != null)
                    stationname = node.Attributes["stationname"].Value;
                if (node.Attributes["stationremark"] != null)
                    stationremark = node.Attributes["stationremark"].Value;
                routebll.AddRouteInfo(routeID, orderno, lat, lon, stationname, stationremark);
                orderno++;
            }
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
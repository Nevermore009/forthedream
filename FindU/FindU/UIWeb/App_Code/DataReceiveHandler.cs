using System;
using System.Web;
using System.Xml;
using System.IO;
using System.Data;
using BLL;
/// <summary>
///
/// </summary>
public class DataReceiveHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string requestID = context.Request["IMEI"];
        XmlDocument doc = new XmlDocument();
        try
        {
            doc.Load(context.Request.InputStream);
        }
        catch (Exception e)
        {
            Common.Log.AddError(context.Server.MapPath("~/error"), e.ToString(), context.Request.UserHostAddress);
            context.Response.Write("No Data Received,Bad Request");
            context.Response.End();
            return;
        }
        string ids = "";
        if (doc != null)
        {
            XmlNodeList list = doc.GetElementsByTagName("LatAndLon");
            foreach (XmlNode node in list)
            {
                Coordinate coordinate = new Coordinate(Convert.ToDouble(node.Attributes["lat"].Value), Convert.ToDouble(node.Attributes["lon"].Value));
                coordinate = CoordinateCorrection.GetCorrectCoordinate(coordinate);
                string lat = coordinate.Lat.ToString();
                string lon = coordinate.Lng.ToString();
                string locatetime = node.Attributes["locatetime"].Value;
                string remark = "";
                int isauto = 1;
                if (node.Attributes["isauto"] != null)
                    isauto = 0;
                if (node.Attributes["remark"] != null)
                    remark = node.Attributes["remark"].Value;
                if ((new Patrol()).Add(lat, lon, locatetime, requestID, remark, isauto.ToString()))
                    ids += "," + node.Attributes["id"].Value;

            }

            //将新的坐标信息发给浏览器
            /* string user = requestID;
             DataTable dt = DB.getdataset("select id from userinfo where IMEI='" + requestID + "'").Tables[0]; ;
             if (dt.Rows.Count > 0)
                 user = dt.Rows[0][0].ToString();
             doc.DocumentElement.SetAttribute("username", user);
             doc.DocumentElement.SetAttribute("date", DateTime.Now.ToString("yyyy-MM-dd"));
             Message msg = new Message { Source = "server", Content = doc.InnerXml, Destination = "#", ContentType = "xml" };
             LongpollingHandle.ConnManager.SendMessage(msg);
             */

        }
        if (ids.Length > 0)
            context.Response.Write("gettedid:" + ids.Substring(1));
        else
            context.Response.Write("error:no data recieved");
    }
    public bool IsReusable
    {
        get { return true; }
    }
}

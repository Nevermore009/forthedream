using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using BLL;

/// <summary>
///ErrorReceiveHandler 的摘要说明
/// </summary>
public class ErrorReceiveHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string imei = context.Request["IMEI"];
        using (StreamReader sr = new StreamReader(context.Request.InputStream))
        {
            string error = sr.ReadToEnd();
            try
            {
                (new ErrorLog()).Add(imei, error);
                context.Response.Write("getted");
            }
            catch(Exception e)
            {
                Common.Log.AddError(context.Server.MapPath("~/error"), e.ToString(), context.Request.UserHostAddress);
                context.Response.Clear();
                context.Response.Write("failed");
            }
        }
    }
    public bool IsReusable
    {
        get { return true; }
    }
}

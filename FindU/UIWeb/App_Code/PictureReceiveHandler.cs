using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using BLL;
using System.Data;

/// <summary>
///PictureReceiveHandler 的摘要说明
/// </summary>
public class PictureReceiveHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        try
        {
            string imei = context.Request["IMEI"];
            Bitmap b = new Bitmap(context.Request.Files["pic"].InputStream);
            string filename = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".jpg";
            string path = "~/images/photoes/" + filename;
            filename = context.Server.MapPath(path);
            b.Save(filename);
            b.Dispose();
            string description = context.Request["remark"]??"";
            new Picture().Add(imei, description, path);
            context.Response.Write("picreceived");
        }
        catch(Exception e)
        {
            Common.Log.AddError(context.Server.MapPath("~/error"), e.ToString(), context.Request.UserHostAddress);
            context.Response.Write("Invalid Request");
        }
    }
    public bool IsReusable
    {
        get { return true; }
    }
}
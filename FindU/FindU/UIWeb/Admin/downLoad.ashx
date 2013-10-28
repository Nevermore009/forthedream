<%@ WebHandler Language="C#" Class="downLoad" %>

using System;
using System.Web;
using System.IO;


public class downLoad : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string filename =context.Request["filename"];
        string path = context.Server.MapPath("~/software/") + filename;
        FileInfo fi = new FileInfo(path);
        if (fi.Exists)
        {
            context.Response.Clear();
            context.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8));
            context.Response.AddHeader("Content-Length", fi.Length.ToString());
            context.Response.ContentType = "application/octet-stream";
            context.Response.Filter.Close();
            context.Response.WriteFile(fi.FullName);
            context.Response.End();
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
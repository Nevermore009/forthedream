using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace Justgo8.Manage
{
    /// <summary>
    /// HotHandler 的摘要说明
    /// </summary>
    public class HotHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (!String.IsNullOrEmpty(context.Request["detailid"]) && !string.IsNullOrEmpty(context.Request["ishot"]))
                {
                    if (Bll.BTravelDetail.ChangeHotState(int.Parse(context.Request["detailid"]), context.Request["ishot"] == "1") > 0)
                    {
                        context.Response.ContentType = "text/plain";
                        context.Response.Write("success");
                    }
                    else
                    {
                        context.Response.ContentType = "text/plain";
                        context.Response.Write("failed");
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex.ToString());
                context.Response.ContentType = "text/plain";
                context.Response.Write("failed");
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
}
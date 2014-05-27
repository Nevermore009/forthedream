using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Justgo8.API.Yahoo
{
    /// <summary>
    /// Yahoo 的摘要说明
    /// </summary>
    public class Yahoo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request["oauth_token"]) || string.IsNullOrEmpty(context.Request["oauth_verifier"]))
            {
                string url = (new YahooOAuth()).GetRequestToken();
                context.Response.Redirect(url);
            }
            else
            {
                string OauthYahooGuid = new YahooOAuth().GetAccessToken(context.Request["oauth_token"], context.Request["oauth_verifier"]);
                context.Response.ContentType = "text/plain";
                context.Response.Write(OauthYahooGuid);
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
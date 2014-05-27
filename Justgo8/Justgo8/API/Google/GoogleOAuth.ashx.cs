using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Justgo8.API.Google
{
    /// <summary>
    /// GoogleOAuth1 的摘要说明
    /// </summary>
    public class GoogleOAuth1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request["oauth_token"]))
            {
                string scope = HttpUtility.UrlEncode("https://www.googleapis.com/auth/userinfo.email");
                string state = "";
                string redirectUri = HttpUtility.UrlEncode(GoogleOAuth.redirect_uri);
                string clientId = HttpUtility.UrlEncode(GoogleOAuth.client_id);
                string url = string.Format("https://accounts.google.com/o/oauth2/auth?scope={0}&state={1}&redirect_uri={2}&response_type=code&client_id={3}", scope, state, redirectUri, clientId);
                context.Response.Redirect(url);
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Hello World");
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
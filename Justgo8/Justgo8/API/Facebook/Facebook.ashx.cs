using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Justgo8.API.Facebook
{
    /// <summary>
    /// FacebookOAuth 的摘要说明
    /// </summary>
    public class Facebook : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request["code"]))
            {
                string url = new FacebookOAuth().GetOAuthUrl();
                context.Response.Redirect(url);
            }
            else
            {
                FacebookOAuth oauth = new FacebookOAuth();
                string access_token = oauth.GetAccessToken(context.Request["code"]);
                if (string.IsNullOrEmpty(access_token))
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("alert('授权登录失败');window.location.href=''");
                }
                else
                {
                    string userid = oauth.GetUserID(access_token);
                    if (string.IsNullOrEmpty(userid))
                    {
                        context.Response.ContentType = "text/plain";
                        context.Response.Write("alert('授权登录失败');window.location.href=''");
                    }
                    else
                    {
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(userid);
                    }
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
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Web.SessionState;

namespace Justgo8.API.QQ
{
    /// <summary>
    /// QQ 的摘要说明
    /// </summary>
    public class QQ : IHttpHandler, IRequiresSessionState
    {
        string client_id = "1101119395";
        string client_secret = "EY1AxXq7kZqxhG72";
        string redirect_uri = "http://www.justgo8.com/API/QQ/QQ.ashx";
        public void ProcessRequest(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request["code"]))
            {
                string access_token = GetAccessToken(context.Request["code"]);
                string openid = GetOpenId(access_token);
                string returnurl = context.Request["state"];
                DataTable dt = Bll.BAccount.GetAccountByOpenId(openid);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    int result = Bll.BAccount.AddQQAccount(openid, openid + "forthedream", "", "", openid);
                    if (result > 0)
                    {
                        context.Session["username"] = openid;
                        context.Session["phone"] = "" ;
                        if (String.IsNullOrEmpty(returnurl))
                        {
                            returnurl = "vip.aspx";
                        }
                        context.Response.Redirect(returnurl);                   
                    }

                }
            }
            else if (!string.IsNullOrEmpty(context.Request["usercancel"]))
            {

            }
            else
            {
                string response_type = "code";
                string state = context.Request["returnurl"] ?? "";
                string url = string.Format("https://graph.qq.com/oauth2.0/authorize?response_type={0}&client_id={1}&redirect_uri={2}&state={3}&", response_type, client_id, redirect_uri, state);
                context.Response.Redirect(url);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public string GetAccessToken(string code)
        {
            string grant_type = "authorization_code";
            string url = string.Format("https://graph.qq.com/oauth2.0/token?grant_type={0}&client_id={1}&client_secret={2}&code={3}&redirect_uri={4}", grant_type, client_id, client_secret, code, redirect_uri);
            HttpWebResponse response = HttpHelper.CreateGetHttpResponse(url, null, "", null);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Headers["access_token"];
            }
            else
                return "";
        }

        public string GetOpenId(string access_token)
        {
            string url = "https://graph.qq.com/oauth2.0/me";
            string result = string.Empty;
            if (Common.HttpHelper.Get(url, out result))
            {
                JObject json = JObject.Parse(result);
                return json["client_id"].ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
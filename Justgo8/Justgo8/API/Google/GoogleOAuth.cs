using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;

namespace Justgo8.API.Google
{
    public class GoogleOAuth
    {
        public static string redirect_uri = "http://www.justgo8.com/API/Google/GoogleOAuth.ashx";
        public static string client_id = "456304766634.apps.googleusercontent.com";
       
        public void GoogleCallback()
        {
            ////由于是https，这里必须要转换为HttpWebRequest
            //var webRequest = WebRequest.Create("https://accounts.google.com/o/oauth2/token") as HttpWebRequest;
            //webRequest.Method = "POST";
            //webRequest.ContentType = "application/x-www-form-urlencoded";

            ////参考https://developers.google.com/accounts/docs/OAuth2WebServer
            //var postData = string.Format("code={0}&client_id={1}&client_secret={2}&redirect_uri={3}" +
            //    "&grant_type=authorization_code",
            //    Request.QueryString["code"],
            //     ConfigurationManager.AppSettings["ClientID"],
            //     ConfigurationManager.AppSettings["ClientSecret"],
            //     ConfigurationManager.AppSettings["RedirectURI"]);

            ////在HTTP POST请求中传递参数
            //using (var sw = new StreamWriter(webRequest.GetRequestStream()))
            //{
            //    sw.Write(postData);
            //}

            ////发送请求，并获取服务器响应
            //var resonseJson = "";
            //using (var response = webRequest.GetResponse())
            //{
            //    using (var sr = new StreamReader(response.GetResponseStream()))
            //    {
            //        resonseJson = sr.ReadToEnd();
            //    }
            //}

            ////通过Json.NET对服务器返回的json字符串进行反序列化，得到access_token
            //var accessToken = JsonConvert.DeserializeAnonymousType(resonseJson, new { access_token = "" }).access_token;

            //webRequest = WebRequest.Create("https://www.googleapis.com/oauth2/v1/userinfo") as HttpWebRequest;
            //webRequest.Method = "GET";
            //webRequest.Headers.Add("Authorization", "Bearer " + accessToken);

            //using (var response = webRequest.GetResponse())
            //{
            //    using (var sr = new StreamReader(response.GetResponseStream()))
            //    {
            //        return Content(JsonConvert.DeserializeAnonymousType(sr.ReadToEnd(), new { Email = "" }).Email);
            //    }
            //}
        }

        public HttpWebResponse getResponse(HttpWebRequest request)
        {
            try
            {
                return (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                #region 异常
                StringBuilder sb = new StringBuilder();
                sb.Append("<br/>" + ex.Message + "</br>xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                sb.Append("<br/>length: " + ex.Source.Length.ToString());
                sb.Append("<br/>stack trace: " + ex.StackTrace);
                sb.Append("<br/>status: " + ex.Status.ToString());
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                int code = Convert.ToInt32(res.StatusCode);
                sb.Append("<br/>Status Code: (" + code.ToString() + ") " + res.StatusCode.ToString());
                sb.Append("<br/>Status Description: " + res.StatusDescription);
                if (ex.InnerException != null)
                {
                    sb.Append("<br/>innerexception: " + ex.InnerException.Message);
                }
                if (ex.Source.Length > 0)
                    sb.Append("<br/>source: " + ex.Source.ToString());
                if (res != null)
                {
                    for (int i = 0; i < res.Headers.Count; i++)
                    {
                        sb.Append("<br/>headers: " + i.ToString() + ": " + res.Headers[i]);
                    }
                }
                //writelog(sb.ToString(), "D://雅虎登录", "最后一次获取数据时出现错误");
                HttpContext.Current.Response.Write(sb.ToString());
                HttpContext.Current.Response.End();
                #endregion
            }
            return null;
        }
    }
}
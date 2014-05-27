using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Collections;

namespace Justgo8.API.Yahoo
{
    public class YahooOAuth
    {
        private string CallBack = "http://www.justgo8.com/API/Yahoo/Yahoo.ashx";
        private string urlOAuthGetRequestToken = "https://api.login.yahoo.com/oauth/v2/get_request_token";
        //private string urlOAuthAuthorizeToken = "https://api.login.yahoo.com/oauth/v2/request_auth";
        private string urlOAuthGetAccessToken = "https://api.login.yahoo.com/oauth/v2/get_token";
        private string consumerKey = "dj0yJmk9bzhoYW5yUzlWS3dPJmQ9WVdrOVRWTm5aVXhFTlRRbWNHbzlNQS0tJnM9Y29uc3VtZXJzZWNyZXQmeD1kOA--";
        private string consumerSecret = "8892776018e532c26b59fa692e7e50e7b7d28838";
        private string OauthTokenSecret = string.Empty;
        private string OauthToken = string.Empty;
        private string OauthYahooGuid = string.Empty;
        //获取授权请求
        public string GetRequestToken()
        {
            string authorizationUrl = string.Empty;
            OAuthBase oauth = new OAuthBase();
            Uri uri = new Uri(urlOAuthGetRequestToken);
            string nonce = oauth.GenerateNonce();
            string timeStamp = oauth.GenerateTimeStamp();
            string normalizedUrl;
            string normalizedRequestParameters;
            string sig = oauth.GenerateSignature(uri, consumerKey, consumerSecret, string.Empty, string.Empty, "GET", timeStamp, nonce, OAuthBase.SignatureTypes.PLAINTEXT, out normalizedUrl, out normalizedRequestParameters);
            //开始构造获取request token需要的uri
            StringBuilder sbRequestToken = new StringBuilder(uri.ToString());
            sbRequestToken.AppendFormat("?oauth_nonce={0}&", nonce);
            sbRequestToken.AppendFormat("oauth_timestamp={0}&", timeStamp);
            sbRequestToken.AppendFormat("oauth_consumer_key={0}&", consumerKey);
            sbRequestToken.AppendFormat("oauth_signature_method={0}&", "PLAINTEXT");
            sbRequestToken.AppendFormat("oauth_signature={0}&", sig);
            sbRequestToken.AppendFormat("oauth_version={0}&", "1.0");
            sbRequestToken.AppendFormat("oauth_callback={0}", HttpUtility.UrlEncode(CallBack));
            //到此已经构造好获取request token需要的uri
            try
            {
                string returnStr = string.Empty;
                string[] returnData;
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sbRequestToken.ToString());
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader streamReader = new StreamReader(res.GetResponseStream());
                returnStr = streamReader.ReadToEnd();
                returnData = returnStr.Split(new Char[] { '&' });
                int index;
                if (returnData.Length > 0)
                {
                    index = returnData[1].IndexOf("=");
                    string oauth_token_secret = returnData[1].Substring(index + 1);//获得的oauth_token_secret
                    OauthTokenSecret = oauth_token_secret;
                    //HttpContext.Current.Session["OauthTokenSecret"] = oauth_token_secret;
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie("OauthTokenSecret", OauthTokenSecret));
                    HttpContext.Current.Response.Cookies["OauthTokenSecret"].Expires = DateTime.Now.AddDays(1);
                    //writelog("GetRequest" + OauthTokenSecret, "D://雅虎登录", "GetRequest获取的oauth_token_secret");
                    index = returnData[3].IndexOf("=");
                    string oauth_request_auth_url = returnData[3].Substring(index + 1);
                    authorizationUrl = HttpUtility.UrlDecode(oauth_request_auth_url);//获得yahoo授权页面的uri,访问authorize url时直接跳转到此uri
                }
            }
            catch (WebException ex)
            {
                #region 发生了异常
                StringBuilder sb = new StringBuilder();
                sb.Append("<br/>" + ex.Message + "</br>----------------------------------------------------");
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
                //writelog(sb.ToString(), "D://雅虎登录", "第一次请求获取");
                HttpContext.Current.Response.Write(sb.ToString());
                HttpContext.Current.Response.End();
                #endregion
            }
            return authorizationUrl;
        }

        /// <summary>
        /// 用户得到的授权去获取token
        /// </summary>
        /// <param name="oauth_token"></param>
        /// <param name="oauth_verifier"></param>
        public string GetAccessToken(string oauth_token, string oauth_verifier)
        {
            OAuthBase oauth = new OAuthBase();
            Uri uri = new Uri(urlOAuthGetAccessToken);
            string nonce = oauth.GenerateNonce();
            string timeStamp = oauth.GenerateTimeStamp();
            if (HttpContext.Current.Response.Cookies["OauthTokenSecret"] != null)
            {
                OauthTokenSecret = HttpContext.Current.Request.Cookies["OauthTokenSecret"].Value;
                //writelog(OauthTokenSecret + "为空", "D://雅虎登录", "从SESSION中获取OauthTokenSecret");
            }
            string sig = consumerSecret + "%26" + OauthTokenSecret;
            StringBuilder sbAccessToken = new StringBuilder(uri.ToString());
            sbAccessToken.AppendFormat("?oauth_consumer_key={0}&", consumerKey);
            sbAccessToken.AppendFormat("oauth_signature_method={0}&", "PLAINTEXT");
            sbAccessToken.AppendFormat("oauth_signature={0}&", sig);
            sbAccessToken.AppendFormat("oauth_timestamp={0}&", timeStamp);
            sbAccessToken.AppendFormat("oauth_version={0}&", "1.0");
            sbAccessToken.AppendFormat("oauth_token={0}&", oauth_token);
            sbAccessToken.AppendFormat("oauth_nonce={0}&", nonce);
            sbAccessToken.AppendFormat("oauth_verifier={0}", oauth_verifier);
            try
            {
                string returnStr = string.Empty;
                string[] returnData;

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sbAccessToken.ToString());
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader streamReader = new StreamReader(res.GetResponseStream());
                returnStr = streamReader.ReadToEnd();
                returnData = returnStr.Split(new Char[] { '&' });
                int index;
                if (returnData.Length > 0)
                {
                    index = returnData[0].IndexOf("=");
                    OauthToken = returnData[0].Substring(index + 1);

                    index = returnData[1].IndexOf("=");
                    string oauth_token_secret = returnData[1].Substring(index + 1);
                    OauthTokenSecret = oauth_token_secret;
                    #region 暂时无用
                    //index = returnData[3].IndexOf("=");
                    //string oauth_session_handle = returnData[3].Substring(index + 1);
                    //OauthSessionHandle = oauth_session_handle;
                    #endregion
                    index = returnData[5].IndexOf("=");
                    string xoauth_yahoo_guid = returnData[5].Substring(index + 1);
                    OauthYahooGuid = xoauth_yahoo_guid;
                }
            }
            catch (WebException ex)
            {
                #region 发生了异常
                StringBuilder sb = new StringBuilder();
                sb.Append("<br/>" + ex.Message + "</br>-------------------------------------------------");
                sb.Append("<br/>requesturl: " + sbAccessToken.ToString());
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
                //writelog(sb.ToString(), "D://雅虎登录", "根据授权获取请求");
                HttpContext.Current.Response.Write(sb.ToString());
                HttpContext.Current.Response.End();
                #endregion
            }
            return OauthYahooGuid;
        }
        //public XmlDocument getData(string atoken, string atoken_secret)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    string nUrl, nParams;
        //    string nonce = oab.GenerateNonce();
        //    string timestamp = oab.GenerateTimeStamp();
        //    string UrlData = string.Format("http://social.yahooapis.com/v1/user/" + OauthYahooGuid + "/profile?format=XML");
        //    string signature = oab.GenerateSignature(new Uri(UrlData), consumerKey, consumerSecret, atoken, atoken_secret, "GET", timestamp, nonce, out nUrl, out nParams);
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(UrlData));
        //    request.Method = "GET";
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("Authorization: OAuth ");
        //    sb.Append("realm=yahooapis.com");
        //    sb.Append(",oauth_consumer_key=" + consumerKey);
        //    sb.Append(",oauth_nonce=" + nonce );
        //    sb.Append(",oauth_signature_method=HMAC-SHA1");
        //    sb.Append(",oauth_timestamp=" + timestamp );
        //    sb.Append(",oauth_token=" + atoken );
        //    sb.Append(",oauth_version="1.0"");
        //    sb.Append(",oauth_signature=" + oab.UrlEncode(signature) );
        //    request.Headers.Add(sb.ToString());
        //    HttpWebResponse response = getResponse(request);
        //    if (response != null)
        //    {
        //        doc.Load(response.GetResponseStream());
        //    } return doc;
        //}
        //public override string getLoginUrl()
        //{
        //    return GetRequestToken();
        //}
        //public override string[] parseHandle(HttpContext page)
        //{
        //    string[] strArray = new string[1];
        //    string query = page.Request.Url.Query;
        //    if (query.LastIndexOf("?") > 0)
        //    {
        //        query = query.Substring(query.LastIndexOf("?"));
        //    }
        //    System.Collections.Specialized.NameValueCollection request = HttpUtility.ParseQueryString(query, Encoding.UTF8);
        //    string oauth_verifier = request["oauth_verifier"];
        //    string oauth_token = request["oauth_token"];
        //    GetAccessToken(oauth_token, oauth_verifier);
        //    XmlDocument xmlDoc = getData(OauthToken, OauthTokenSecret);
        //    XmlNodeList elemList = xmlDoc.DocumentElement.GetElementsByTagName("emails");
        //    ArrayList arrayList = new ArrayList();
        //    for (int i = 0; i < elemList.Count; i++)
        //    {
        //        arrayList.Add(elemList[i].ChildNodes[0].InnerText);
        //    }
        //    string YahooID = string.Empty;
        //    if (arrayList.Count > 0)
        //        YahooID = arrayList[arrayList.Count - 1].ToString();
        //    strArray[0] = YahooID;
        //    return strArray;
        //}
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ResponseFileName"></param>
        /// <param name="FileName"></param>
        //public void writelog(string msg, string ResponseFileName, string FileName)
        //{
        //    if (!Directory.Exists(ResponseFileName))
        //        Directory.CreateDirectory(ResponseFileName);
        //    string path = ResponseFileName + "//" + FileName + ".txt";
        //    //写入数据库
        //    FileStream fs = new FileStream(path, FileMode.Append);
        //    StreamWriter sw = new StreamWriter(fs, Encoding.Default);
        //    sw.WriteLine(System.Environment.NewLine);
        //    sw.WriteLine(System.DateTime.Now.ToString());
        //    sw.WriteLine(msg);
        //    sw.Close();
        //    fs.Close();
        //}
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
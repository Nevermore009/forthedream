using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Text;
using System.IO;
using Common;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace Justgo8._2009
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request["code"]))
            {
                DataTable dt = GetAppClient("");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show(this.Page, "没有可用的应用支持");
                    return;
                }
                else
                {
                    try
                    {
                        string client_id = dt.Rows[0]["client_id"].ToString();
                        string redirect_uri = dt.Rows[0]["redirect_uri"].ToString();
                        Response.Redirect(string.Format("https://openapi.youku.com/v2/oauth2/authorize?client_id={0}&response_type=code&redirect_uri={1}&state={0}", client_id, redirect_uri));
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.AddErrorLog(ex.ToString());
                    }
                }
            }
            else
            {
                if(String.IsNullOrEmpty(Request["state"]))
                {
                    MessageBox.Show(this.Page, "回调数据不正确");
                    return;
                }
                DataTable dt = GetAppClient(Request["state"]);
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show(this.Page, "没有可用的应用支持");
                    return;
                }
                else
                {
                    Client client = new Client();
                    client.Client_ID = dt.Rows[0]["client_id"].ToString();
                    client.Client_secret = dt.Rows[0]["client_secret"].ToString();
                    client.Redirect_uri = dt.Rows[0]["redirect_uri"].ToString();
                    client.Code = Request["code"];
                    client.Remark = dt.Rows[0]["remark"].ToString();
                    new Thread(new ParameterizedThreadStart(MainWork)).Start(client);
                }
            }
        }

        protected DataTable GetAppClient(string client_id)
        {
            if (string.IsNullOrEmpty(client_id))
            {
                return Bll.BAppClient.GetRandomAppClient();
            }
            else
            {
                return Bll.BAppClient.GetAppClientInfo(client_id);
            }
        }

        protected string GetComment()
        {
            try
            {
                return Bll.BComments.GetRandomComment().Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex.ToString());
                return "";
            }
        }

        protected bool Get(string url, out string result)
        {
            try
            {
                HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(url, null, null, null);
                return DataHandler(url,response, out result);
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex.ToString());
                result = "";
                return false;
            }
        }

        protected bool Post(string url, IDictionary<string, string> parameters, out string result)
        {
            try
            {
                HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(url, parameters, null, null, Encoding.UTF8, null);
                return DataHandler(url,response, out result);
            }
            catch (Exception e)
            {
                ErrorLog.AddErrorLog(e.ToString());
                result = "";
                return false;
            }
        }

        protected bool DataHandler(string url,HttpWebResponse response, out string result)
        {
            result = "";
            if (response != null)
            {
                string responseString = "";
                Stream dataStream = null;
                StreamReader reader = null;
                try
                {
                    dataStream = response.GetResponseStream();
                    reader = new StreamReader(dataStream);
                    responseString = reader.ReadToEnd();
                    dataStream.Close();
                }
                catch { }
                finally
                {
                    if (dataStream != null)
                        dataStream.Close();
                    if (reader != null)
                        reader.Close();
                }
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = responseString;
                    return true;
                }
                else
                {
                    if (!String.IsNullOrEmpty(responseString))
                    {
                        try
                        {
                            JObject obj = JObject.Parse(responseString);
                            JObject error = JObject.Parse(obj["error"].ToString());
                            int errorcode = int.Parse(error["code"].ToString());
                            string errortype = error["type"].ToString();
                            string errordescription = error["description"].ToString();
                            Bll.BError.add(errorcode, errortype, errordescription, url);
                            result = errorcode.ToString();
                            return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.AddErrorLog("记录错误失败：" + ex.ToString());
                            return false;
                        }
                    }
                    else
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void MainWork(object obj)
        {
            try
            {
                Client client = obj as Client;
                if (client == null)
                {
                    return;
                }
                else
                {
                    client.Running = true;
                }
                int getaccessresult = GetAccessToken(ref client);
                if (getaccessresult == -1)
                {
                    ErrorLog.AddErrorLog("获取accesstoken失败");
                    return;
                }
                else if (getaccessresult != 0)
                {
                    ErrorHandler(getaccessresult, ref client);
                }
                DataTable dt = Bll.BVideoUser.GetVideoUsers();
                if (dt.Rows.Count <= 0)
                {
                    ErrorLog.AddErrorLog("没有需要评论的用户");
                    return;
                }
                else
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        if (!string.IsNullOrEmpty(r["username"].ToString()))
                        {
                            client.UserVideo.Add(r["username"].ToString(), "");
                        }
                    }
                }
                System.Timers.Timer getvideotimer = SystemTimer.SetInterval(1800000, (e, state) =>
                 {
                     try
                     {
                         Client c = state as Client;
                         if (c != null && c.Running)
                         {
                             foreach (KeyValuePair<string, string> k in c.UserVideo)
                             {
                                 c.UserVideo[k.Key] = GetLastestVideo(client.Client_ID, k.Key);
                             }
                         }
                         else
                         {
                             c.Running = false;
                             return;
                         }
                     }
                     catch (Exception ex)
                     {
                         ErrorLog.AddErrorLog(ex.ToString());
                         return;
                     }
                 }, client);
                System.Timers.Timer createcommenttimer = SystemTimer.SetInterval(60000, (e, state) =>
                {
                    try
                    {
                        Client c = state as Client;
                        if (c != null && c.Running)
                        {
                            string content = GetComment();
                            foreach (KeyValuePair<string, string> k in c.UserVideo)
                            {
                                if (!String.IsNullOrEmpty(k.Value))
                                {
                                    int errorcode = CreateComment(c.Client_ID, c.Access_token, k.Value, content, "", "");
                                    ErrorHandler(errorcode, ref client);
                                }
                            }
                        }
                        else
                        {
                            c.Running = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.AddErrorLog(ex.ToString());
                        return;
                    }
                }, client);
                while (true)
                {
                    if (!client.Running)
                    {
                        getvideotimer.Stop();
                        createcommenttimer.Stop();
                    }
                    else
                    {
                        Thread.Sleep(60000);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex.ToString());
            }
        }

        /// <summary>
        /// 创建评论并返回结果,成功返回评论ID,失败返回错误代码
        /// </summary>
        /// <param name="client_id"></param>
        /// <param name="access_token"></param>
        /// <param name="video_id"></param>
        /// <param name="content"></param>
        /// <param name="captcha_key"></param>
        /// <param name="captcha_text"></param>
        /// <returns></returns>
        protected int CreateComment(string client_id, string access_token, string video_id, string content, string captcha_key, string captcha_text)
        {
            string url = "https://openapi.youku.com/v2/comments/create.json";
            IDictionary<string, string> pas = new Dictionary<string, string>();
            pas.Add("client_id", client_id);
            pas.Add("access_token", access_token);
            pas.Add("video_id", video_id);
            pas.Add("content", content);
            if (!string.IsNullOrEmpty(captcha_key) && !string.IsNullOrEmpty(captcha_text))
            {
                pas.Add("captcha_key", captcha_key);
                pas.Add("captcha_text", captcha_text);
            }
            string result = null;
            if (Post(url, pas, out result))
            {
                try
                {
                    JObject obj = JObject.Parse(result);
                    int id = int.Parse(obj["id"].ToString());
                    if (Bll.BComments.add(client_id, id, video_id, content) <= 0)
                    {
                        ErrorLog.AddErrorLog("添加评论失败");
                    }
                    return 0;
                }
                catch (Exception ex)
                {
                    ErrorLog.AddErrorLog(ex.ToString());
                    return -1;
                }
            }
            else
            {
                int errorcode;
                if (int.TryParse(result, out errorcode))
                {
                    return errorcode;
                }
                else
                { return 0; }
            }
        }


        protected string GetLastestVideo(string client_id, string username)
        {
            try
            {
                var url = "https://openapi.youku.com/v2/videos/by_user.json?client_id=" + client_id + "&user_name=" + username + "&page=1&count=1";
                string result = null;
                if (Get(url, out result))
                {
                    JObject obj = JObject.Parse(result);
                    return obj["id"].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex.ToString());
                return "";
            }
        }

        protected int GetAccessToken(ref Client client)
        {
            string url = "https://openapi.youku.com/v2/oauth2/token";
            IDictionary<string, string> pas = new Dictionary<string, string>();
            pas.Add("client_id", client.Client_ID);
            pas.Add("client_secret", client.Client_secret);
            pas.Add("grant_type", "authorization_code");
            pas.Add("code", client.Code);
            pas.Add("redirect_uri", client.Redirect_uri);
            string result = null;
            if (Post(url, pas, out result))
            {
                JObject obj = JObject.Parse(result);
                string access_token = obj["access_token"].ToString();
                string expires_in = obj["expires_in"].ToString();
                string refresh_token = obj["refresh_token"].ToString();
                string token_type = obj["token_type"].ToString();
                client.Access_token = access_token;
                client.Expires_in = expires_in;
                client.Refresh_token = refresh_token;
                client.Token_type = token_type;
                if (Bll.BToken.add(client.Code, client.Client_ID, access_token, int.Parse(expires_in), refresh_token, token_type) <= 0)
                {
                    ErrorLog.AddErrorLog("添加token失败");
                }
                return 0;
            }
            else
            {
                int errorcode;
                if (int.TryParse(result, out errorcode))
                {
                    return errorcode;
                }
                else
                { return -1; };
            }
        }

        protected int RefreshAccessToken(ref Client client)
        {
            string url = string.Format("https://openapi.youku.com/v2/oauth2/token?client_id={0}&client_secret={1}&grant_type={2}&refresh_token={3}", client.Client_ID, client.Client_secret, "refresh_token", client.Refresh_token);
            string result = null;
            if (Get(url, out result))
            {
                JObject obj = JObject.Parse(result);
                string access_token = obj["access_token"].ToString();
                string expires_in = obj["expires_in"].ToString();
                string new_refresh_token = obj["refresh_token"].ToString();
                string token_type = obj["token_type"].ToString();
                client.Access_token = access_token;
                client.Expires_in = expires_in;
                client.Refresh_token = new_refresh_token;
                client.Token_type = token_type;
                if (Bll.BToken.add(client.Code, client.Client_ID, access_token, int.Parse(expires_in), new_refresh_token, token_type) <= 0)
                {
                    ErrorLog.AddErrorLog("更新token失败");
                }
                return 0;
            }
            else
            {
                int errorcode;
                if (int.TryParse(result, out errorcode))
                {
                    return errorcode;
                }
                else
                { return -1; };
            }
        }

        protected void ErrorHandler(int errorcode, ref Client client)
        {
            ErrorLog.AddErrorLog("错误:" + errorcode);
            switch (errorcode)
            {
                case 130030051:  //More than 300 characters (utf8)
                    break;
                case 130030052:  //Contains do not submit level of taboo words
                    break;
                case 130030053:  //The video don't exist
                    break;
                case 130030054:  //The video don't allow comments
                    break;
                case 130030055:  //Not paying customers can't comment on charges video
                    break;
                case 130030102:  //No data
                    break;
                case 130030400:  //Can't repeat published comments
                    break;
                case 130030402:  //Content is not effective UTF8 characters
                    break;
                case 1009:  //Access token expired,need refresh
                    RefreshAccessToken(ref client);
                    break;
                case 1008:
                    client.Running = false;
                    break;
                default:
                    break;
            }
        }

        public class Client
        {
            public string Client_ID { set; get; }
            public string Client_secret { set; get; }
            public string Code { set; get; }
            public string Access_token { set; get; }
            public string Expires_in { set; get; }
            public string Refresh_token { set; get; }
            public string Token_type { set; get; }
            public string Redirect_uri { set; get; }
            public string Remark { set; get; }
            public Dictionary<string, string> UserVideo = new Dictionary<string, string>();
            public bool Running { set; get; }
        }
    }
}
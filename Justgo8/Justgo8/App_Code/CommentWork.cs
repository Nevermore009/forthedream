using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using Newtonsoft.Json.Linq;
using Common;
using System.Data;

namespace Justgo8.App_Code
{
    public class CommentWork
    {
        public static void StartWork(Client client)
        {
            try
            {
                if (client == null)
                {
                    return;
                }
                else
                {
                    client.Running = true;
                }
                string result = null;
                if (!GetAccessToken(ref client, out result))
                {
                    Bll.BError.add(100, "application", "accesstoken获取失败", "http://www.justgo8.com/2009/index.aspx");
                    ErrorHandler(result, ref client);
                    return;
                }
                DataTable dt = Bll.BVideoUser.GetVideoUsers();
                if (dt.Rows.Count <= 0)
                {
                    Bll.BError.add(100, "application", "没有视频用户", "http://www.justgo8.com/2009/index.aspx");
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
                new Thread(new ParameterizedThreadStart(ContinueWork)).Start(client);
            }
            catch(Exception ex)
            {
                try
                {
                    Bll.BError.add(100, "application", "评论遇到错误：" + ex.ToString(), "http://www.justgo8.com/2009/index.aspx");
                }
                catch { }
            }
        }

        public static void ContinueWork(object clientobject)
        {
            new Thread(new ParameterizedThreadStart((obj) =>
            {
                try
                {
                    string result = null;
                    Client client = obj as Client;
                    if (client == null)
                    {
                        return;
                    }
                    else
                    {
                        client.Running = true;
                    }
                    System.Threading.Timer getvideotimer = SystemTimer.SetInterval(state =>
                    {
                        try
                        {
                            Client c = state as Client;
                            if (c != null && c.Running)
                            {
                                List<string> userlist = new List<string>();
                                foreach (KeyValuePair<string, string> k in c.UserVideo)
                                {
                                    userlist.Add(k.Key);
                                }
                                lock (c.UserVideo)
                                {
                                    foreach (string u in userlist)
                                    {
                                        c.UserVideo[u] = GetLastestVideo(c.Client_ID, u);
                                    }
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
                            try
                            {
                                Bll.BError.add(100, "application", "获取视频出错：" + ex.ToString(), "http://www.justgo8.com/2009/index.aspx");
                            }
                            catch { }
                            return;
                        }
                    }, client, 0, 1800000);
                    System.Threading.Timer createcommenttimer = SystemTimer.SetInterval(state =>
                    {
                        try
                        {
                            Client c = state as Client;
                            if (c != null && c.Running)
                            {
                                string content = GetComment();
                                lock (c.UserVideo)
                                {
                                    foreach (KeyValuePair<string, string> k in c.UserVideo)
                                    {
                                        if (!String.IsNullOrEmpty(k.Value))
                                        {
                                            string resultstring = null;
                                            CreateComment(c.Client_ID, c.Access_token, k.Value, content, "", "", out resultstring);
                                            ErrorHandler(result, ref c);
                                        }
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
                            try
                            {
                                Bll.BError.add(100, "application", "创建评论出错：" + ex.ToString(), "http://www.justgo8.com/2009/index.aspx");
                            }
                            catch { }
                            return;
                        }
                    }, client, 20000, 545000);
                    while (true)
                    {
                        if (!client.Running)
                        {
                            getvideotimer.Dispose();
                            createcommenttimer.Dispose();
                            Bll.BError.add(100, "application", "未知原因停止", "http://www.justgo8.com/2009/index.aspx");
                            return;
                        }
                        else
                        {
                            Thread.Sleep(60000);
                        }
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        Bll.BError.add(100, "application", "评论遇到错误：" + ex.ToString(), "http://www.justgo8.com/2009/index.aspx");
                    }
                    catch { }
                }
            })).Start(clientobject);
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
        protected static bool CreateComment(string client_id, string access_token, string video_id, string content, string captcha_key, string captcha_text, out string result)
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
            if (HttpHelper.Post(url, pas, out result))
            {
                try
                {
                    JObject obj = JObject.Parse(result);
                    string commentid = obj["id"].ToString();
                    Bll.BCommentRecord.add(client_id, commentid, video_id, content);
                }
                catch (Exception ex)
                {
                    Bll.BError.add(100, "application", "记录评论失败：" + ex.ToString(), "http://www.justgo8.com/2009/index.aspx");
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        protected static string GetLastestVideo(string client_id, string username)
        {
            try
            {
                var url = "https://openapi.youku.com/v2/videos/by_user.json?client_id=" + client_id + "&user_name=" + username + "&page=1&count=1";
                string result = null;
                if (HttpHelper.Get(url, out result))
                {
                    JObject obj = JObject.Parse(result);
                    JArray videos = JArray.Parse(obj["videos"].ToString());
                    return videos[0]["id"].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                try
                {
                    Bll.BError.add(100, "application", "获取视频失败：" + ex.ToString(), "http://www.justgo8.com/2009/index.aspx");
                }
                catch { }
                return "";
            }
        }

        protected static bool GetAccessToken(ref Client client, out  string result)
        {
            string url = "https://openapi.youku.com/v2/oauth2/token";
            IDictionary<string, string> pas = new Dictionary<string, string>();
            pas.Add("client_id", client.Client_ID);
            pas.Add("client_secret", client.Client_secret);
            pas.Add("grant_type", "authorization_code");
            pas.Add("code", client.Code);
            pas.Add("redirect_uri", client.Redirect_uri);
            if (HttpHelper.Post(url, pas, out result))
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
                Bll.BToken.add(client.Code, client.Client_ID, access_token, int.Parse(expires_in), refresh_token, token_type);
                return true;
            }
            else
            {
                return false;
            }
        }

        protected static bool RefreshAccessToken(ref Client client,out string result)
        {
            string url = string.Format("https://openapi.youku.com/v2/oauth2/token?client_id={0}&client_secret={1}&grant_type={2}&refresh_token={3}", client.Client_ID, client.Client_secret, "refresh_token", client.Refresh_token);
            if (HttpHelper.Get(url, out result))
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
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        protected static void ErrorHandler(string result, ref Client client)
        {
            try
            {
                JObject obj = JObject.Parse(result);
                JObject error = JObject.Parse(obj["error"].ToString());
                int errorcode = int.Parse(error["code"].ToString());
                string errortype = error["type"].ToString();
                string errordescription = error["description"].ToString();
                Bll.BError.add(errorcode, errortype, errordescription, "");
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
                    case 130030056: //Need captcha
                        break;
                    case 130030102:  //No data
                        break;
                    case 130030400:  //Can't repeat published comments
                        break;
                    case 130030402:  //Content is not effective UTF8 characters
                        break;
                    case 1009:      //Access token expired,need refresh
                        {
                            string resultstring = null;
                            if (!RefreshAccessToken(ref client, out resultstring))
                            {
                                client.Running = false;
                            }
                            else
                            {
                                Bll.BToken.del(client.Access_token);
                            }
                        }
                        break;
                    case 1008:      //Access token invalid
                        client.Running = false;
                        Bll.BToken.del(client.Access_token);
                        break;
                    default:
                        break;
                }
            }
            catch
            {

            }
        }

        public static DataTable GetAppClient(string client_id)
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

        public static string GetComment()
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
    }
}
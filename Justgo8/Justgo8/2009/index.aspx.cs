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
            if (Request["code"] == null)
            {
                string client_id = GetClient_ID();
                //https://openapi.youku.com/v2/oauth2/authorize?client_id=2ffad1f9f8404b65&response_type=code&redirect_uri=http://www.justgo8.com/2009/index.aspx&state=2ffad1f9f8404b65
            }
            else
            {
                Client client = new Client();
                client.Client_ID = "2ffad1f9f8404b65";
                client.Client_secret = "cf9ed845e8e79749adaaf7c9e23df217";
                client.Code = Request["code"];
                client.Remark = "forthedream";
                new Thread(new ParameterizedThreadStart(MainWork)).Start(client);
            }
        }

        protected string GetClient_ID()
        {
            return "b33f3bc587158327";
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

        protected void Get(string url)
        {
            try
            {
                HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(url, null, null, null);

            }
            catch (Exception)
            {

            }
        }

        protected string Post(string url, IDictionary<string, string> parameters)
        {
            try
            {
                HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(url, parameters, null, null, Encoding.UTF8, null);
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
                        return responseString;
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
                                return responseString;
                            }
                            catch (Exception ex)
                            {
                                ErrorLog.AddErrorLog("记录错误失败：" + ex.ToString());
                                return "";
                            }
                        }
                        else
                            return "";
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                ErrorLog.AddErrorLog(e.ToString());
                return "";
            }
        }

        public void MainWork(object obj)
        {
            Client client = obj as Client;
            if (obj == null)
            {
                return;
            }
            IDictionary<string, string> pas = new Dictionary<string, string>();
            pas.Add("client_id", "b33f3bc587158327");
            pas.Add("client_secret", "ce0e582fef3c0140b4889db82fe74ada");
            pas.Add("grant_type", "authorization_code");
            pas.Add("code", client.Code);
            pas.Add("redirect_uri", "http://www.justgo8.com/2009/index.aspx");
            Post("https://openapi.youku.com/v2/oauth2/token", pas);
        }

        public class Client
        {
            public string Client_ID { set; get; }
            public string Client_secret { set; get; }
            public string Code { set; get; }
            public string Remark { set; get; }
        }
    }
}
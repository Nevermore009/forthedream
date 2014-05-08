using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Common;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;

namespace Justgo8._2009
{
    public partial class PrivateMsg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeaterMsg();
            }
        }

        protected void BindRepeaterMsg()
        {
            DataTable dt = Bll.BEmail.Emails();
            foreach (DataRow r in dt.Rows)
            {
                string url = "http://i.youku.com/u/~ajax/getPrivateMsgList?__ap={\"uid\":\""+r["uid"].ToString()+"\"}";
                string result = null ;
                if (Get(url, out result))
                {
                    if (!string.IsNullOrEmpty(result))
                    {
                        JObject obj = JObject.Parse(result);
                        r["content"] = obj["content"].ToString();
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                RepeaterMsg.DataSource = dt;
                RepeaterMsg.DataBind();
            }
        }

        protected bool Get(string url, out string result)
        {
            try
            {
                HttpWebResponse response = HttpHelper.CreateGetHttpResponse(url, null, null, null);
                return DataHandler(url, response, out result);
            }
            catch (Exception)
            {
                result = "";
                return false;
            }
        }

        protected bool Post(string url, IDictionary<string, string> parameters, out string result)
        {
            try
            {
                HttpWebResponse response = HttpHelper.CreatePostHttpResponse(url, parameters, null, null, Encoding.UTF8, null);
                return DataHandler(url, response, out result);
            }
            catch (Exception)
            {
                result = "";
                return false;
            }
        }

        protected bool DataHandler(string url, HttpWebResponse response, out string result)
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
                    Bll.BError.add(101, "application", "返回内容：" + responseString, "http://www.justgo8.com/2009/index.aspx");
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
                            try
                            {
                                Bll.BError.add(100, "application", "记录错误失败：" + ex.ToString(), "http://www.justgo8.com/2009/index.aspx");
                            }
                            catch { }
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
    }
}
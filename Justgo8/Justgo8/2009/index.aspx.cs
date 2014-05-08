using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text;
using System.IO;
using Common;
using System.Threading;
using Newtonsoft.Json.Linq;
using Justgo8.App_Code;

namespace Justgo8._2009
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request["code"]))
            {
                DataTable dt = CommentWork.GetAppClient("");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show(this.Page, "没有可用的应用支持");
                    return;
                }
                else
                {
                    string client_id = "", redirect_uri = "";
                    try
                    {
                        client_id = dt.Rows[0]["client_id"].ToString();
                        redirect_uri = dt.Rows[0]["redirect_uri"].ToString();
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.AddErrorLog(ex.ToString());
                        return;
                    }
                    Response.Redirect(string.Format("https://openapi.youku.com/v2/oauth2/authorize?client_id={0}&response_type=code&redirect_uri={1}&state={0}", client_id, redirect_uri));
                }
            }
            else
            {
                if (String.IsNullOrEmpty(Request["state"]))
                {
                    MessageBox.Show(this.Page, "回调数据不正确");
                    return;
                }
                DataTable dt = CommentWork.GetAppClient(Request["state"]);
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
                    CommentWork.StartWork(client);
                }
            }
        } 
    }
}
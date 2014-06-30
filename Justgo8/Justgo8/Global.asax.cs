using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;
using Justgo8.App_Code;

namespace Justgo8
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //DataTable dt = Bll.BToken.Tokens();
            //Bll.BError.add(100, "application", "已重新启动" + dt.Rows.Count + "个线程", "http://www.justgo8.com/2009/index.aspx");
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    Client client = new Client();
            //    client.Client_ID = dt.Rows[i]["client_id"].ToString();
            //    DataTable clientdt = CommentWork.GetAppClient(client.Client_ID);
            //    client.Client_secret = clientdt.Rows[0]["client_secret"].ToString();
            //    client.Redirect_uri = clientdt.Rows[0]["redirect_uri"].ToString();
            //    client.Code = dt.Rows[i]["code"].ToString();
            //    client.Remark = clientdt.Rows[0]["remark"].ToString();
            //    CommentWork.ContinueWork(client);
            //}            
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
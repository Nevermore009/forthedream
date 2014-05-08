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
            DataTable dt = Bll.BToken.Tokens();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Client client = new Client();
                client.Client_ID = dt.Rows[i]["client_id"].ToString();
                client.Client_secret = dt.Rows[i]["client_secret"].ToString();
                client.Redirect_uri = dt.Rows[i]["redirect_uri"].ToString();
                client.Code = dt.Rows[i]["code"].ToString();
                client.Remark = dt.Rows[i]["remark"].ToString();
                CommentWork.StartWork(client);
            }
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
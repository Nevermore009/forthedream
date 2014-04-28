using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Justgo8._2009
{
    public partial class index : System.Web.UI.Page
    {
        public string back_code = "";
        public string back_client_id = "b33f3bc587158327";
        public string back_client_secret = "ce0e582fef3c0140b4889db82fe74ada";
        public string back_appname = "for2009";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["code"] == null)
            {
                Response.Redirect("https://openapi.youku.com/v2/oauth2/authorize?client_id=" + back_client_id + "&response_type=code&redirect_uri=http://58.221.58.195:5195/index.aspx");
            }
            else
            {
                back_code = Request["code"];
            }
        }
    }
}
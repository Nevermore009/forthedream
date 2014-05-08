using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Justgo8.App_Code
{
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
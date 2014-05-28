using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Justgo8.API.Facebook
{
    public class FacebookOAuth
    {
        private string client_id = "562255407216630";
        private string client_secret = "8ff2d68a99cab2a9dffe7083f0713ec6";
        private string redirect_uri = "";

        public string GetOAuthUrl()
        {
            string url = string.Format("https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}", client_id, redirect_uri);
            return HttpUtility.UrlEncode(url);
        }

        public string GetAccessToken(string code)
        {
            try
            {
                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}", client_id, redirect_uri, client_secret, code);
                string result = null;
                if (HttpHelper.Get(HttpUtility.UrlEncode(url), out result))
                {
                    return result.Split('|')[0];
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetUserID(string access_token)
        {
            string url = string.Format("https://graph.facebook.com/v2.0/me?access_token={0}", access_token);
            string result = null;
            if (HttpHelper.Get(HttpUtility.UrlEncode(url), out result))
            {
                return "";
            }
            else
            {
                return "";
            }
        }
    }
}
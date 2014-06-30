using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities;
using gtxh_m.Common;

namespace gtxh_m.Helpers
{
    public class ServiceMessage
    {
        private static string appId = "wx815b61e93898c53e";
        private static string secret = "d81e58c8ccaacc7902089f2f83b2fc3d";
        public static OpenIdResultJson_Data GetCustomerList()
        {
            OpenIdResultJson_Data jsondata = new OpenIdResultJson_Data();
            string access_token = AccessTokenContainer.TryGetToken(appId, secret);
            OpenIdResultJson temp = User.Get(access_token, "");
            while (temp.errcode == 0)
            {
                jsondata.openid.AddRange(temp.data.openid);
                if (temp.count < temp.total)
                {
                    temp = User.Get(access_token, temp.next_openid);
                }
                else
                {
                    break;
                }
            }
            return jsondata;
        }

        public static void PushDailyNews()
        {
            OpenIdResultJson_Data userlist = GetCustomerList();
            string access_token = AccessTokenContainer.TryGetToken(appId, secret);
            List<Article> articleList = GetTodayNews();
            foreach (string id in userlist.openid)
            {
                WxJsonResult result = Custom.SendNews(access_token, id, articleList);
                if (result.errcode != 0)
                {
                    ErrorLog.AddErrorLog("send failed:{openid:" + id + ",errorcode:" + result.errcode + "}");
                }
            }
        }

        public static List<Article> GetTodayNews()
        {
            return new List<Article>();
        }
    }
}
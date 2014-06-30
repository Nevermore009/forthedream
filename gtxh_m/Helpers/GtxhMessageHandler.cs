using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.Entities;
using System.IO;
using System.Data;
using gtxh_m.Common;
using gtxh_m.com.gtxh.news;
using System.Text;
using gtxh_m.Models;
using gtxh_m.com.gtxh.iv;
using System.Configuration;

namespace gtxh_m.Helpers
{
    public class GtxhMessageHandler : MessageHandler<GtxhMessageContext>
    {
        private string web_key = ConfigurationManager.AppSettings["iv_key"];
        public GtxhMessageHandler(Stream inputStream, int maxRecordCount = 0)
            : base(inputStream, maxRecordCount)
        {
            //这里设置仅用于测试，实际开发可以在外部更全局的地方设置，
            WeixinContext.ExpireMinutes = 3;
        }

        /// <summary>
        /// Event事件类型请求之subscribe
        /// </summary>
        public override IResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = GetWelcomeInfo(requestMessage.FromUserName);
            return responseMessage;
        }

        public override IResponseMessageBase OnEvent_ClickRequest(RequestMessageEvent_Click requestMessage)
        {
            IResponseMessageBase reponseMessage = null;
            //菜单点击，需要跟创建菜单时的Key匹配
            switch (requestMessage.EventKey)
            {
                case "todaynews": //今日推荐
                    var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();
                    reponseMessage = strongResponseMessage;
                    strongResponseMessage.Articles.AddRange(GetTodayNews());
                    break;
            }

            return reponseMessage;
        }

        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            switch (requestMessage.Content)
            {
                case "网址":
                    responseMessage.Content = "点击进入<a href='http://www.gtxh.com'>中国钢铁现货网</a>";
                    break;
                case "我要绑定":
                    responseMessage.Content = "<a href='http://m.gtxh.com/login/index/" + requestMessage.FromUserName + "'>点击绑定中国钢铁现货网账号</a>";
                    break;
                case "取消绑定":
                    try
                    {
                        User user = new User();
                        int result = user.DeleteOpenid(web_key, requestMessage.FromUserName);
                        if (result > 0)
                        {
                            responseMessage.Content = "您已成功取消钢铁现货账号与您微信的绑定";
                        }
                        else
                        {
                            responseMessage.Content = "取消绑定失败";
                            ErrorLog.AddErrorLog("[" + requestMessage.FromUserName + "]取消绑定失败:" + result);
                        }
                    }
                    catch (Exception ex)
                    {
                        responseMessage.Content = "取消绑定失败";
                        ErrorLog.AddErrorLog("OnTextRequest:" + ex.ToString());
                    }
                    break;
                default:
                    responseMessage.Content = GetAutoReply();
                    break;
            }
            return responseMessage;
        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "";
            return responseMessage;
        }

        /// <summary>
        /// 自动回复消息
        /// </summary>
        /// <returns></returns>
        private string GetAutoReply()
        {
            return @"/可爱有什么疑问或需求，就告诉我哦，我会尽快回复你，谢谢！";
        }

        /// <summary>
        /// 获取被关注后的消息
        /// </summary>
        /// <returns></returns>
        private string GetWelcomeInfo(string openid)
        {
            try
            {
                User user = new User();
                if (user.IsSetOpenid(web_key, openid))
                {
                    return @"/玫瑰/微笑感谢亲关注“钢铁现货网”微信，为您奉上每日报价行情，数据分析，钢市热点/咖啡......您已绑定中国钢铁现货网账号，可直接访问“钢铁超市”及“钢厂直销”，如需取消绑定，请发送“取消绑定”即可！";
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog("GetWelcomeInfo:" + ex.ToString());
            }
            return @"/玫瑰/微笑感谢亲关注“钢铁现货网”微信，为您奉上每日报价行情，数据分析，钢市热点/咖啡......<a href='http://m.gtxh.com/login/index/" + openid + "'>点击绑定中国钢铁现货网账号</a>";
        }

        //获取今日推荐
        private List<Article> GetTodayNews()
        {
            try
            {
                List<Article> Articles = new List<Article>();
                News news = new News();
                DataSet ds = news.GetHotNews(web_key);
                if (ds != null && ds.Tables.Count >= 3)
                {
                    StringBuilder strbuilder = new StringBuilder();
                    //string description = "";
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Article temp = new Article();
                        temp.Title = r["newstitle"].ToString();
                        temp.Description = r["newsdescription"].ToString().Length > 10 ? r["newsdescription"].ToString().Substring(0, 10) + "..." : r["newsdescription"].ToString();
                        temp.Url = r["newsurl"].ToString();
                        if (r["abortImgUrl"] != null && !string.IsNullOrEmpty(r["abortImgUrl"].ToString()))
                        {
                            temp.PicUrl = r["abortImgUrl"].ToString();
                        }
                        Articles.Add(temp);
                    }
                    foreach (DataRow r in ds.Tables[1].Rows)
                    {
                        Article temp = new Article();
                        temp.Title = r["newstitle"].ToString();
                        temp.Description = r["newsdescription"].ToString().Length > 10 ? r["newsdescription"].ToString().Substring(0, 10) + "..." : r["newsdescription"].ToString();
                        temp.Url = r["newsurl"].ToString();
                        if (r["abortImgUrl"] != null && !string.IsNullOrEmpty(r["abortImgUrl"].ToString()))
                        {
                            temp.PicUrl = r["abortImgUrl"].ToString();
                        }
                        Articles.Add(temp);
                    }
                    //foreach (DataRow r in ds.Tables[2].Rows)
                    //{
                    //    Article temp = new Article();
                    //    temp.Title = r["newstitle"].ToString();
                    //    temp.Description = r["newstitle"].ToString();
                    //    temp.Url = "http://news.gtxh.com" + r["staticpath"].ToString();
                    //    Articles.Add(temp);
                    //}
                    return Articles;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog("" + ex.ToString());
                return null;
            }
        }
    }
}
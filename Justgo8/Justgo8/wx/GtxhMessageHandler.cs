using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.Entities;
using System.IO;
using System.Data;
using System.Text;
using System.Configuration;

namespace Justgo8.wx
{
    public class GtxhMessageHandler : MessageHandler<GtxhMessageContext>
    {
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

        public override IResponseMessageBase OnEvent_LocationRequest(RequestMessageEvent_Location requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = "your location:latitude:" + requestMessage.Latitude + ",longitude:" + requestMessage.Longitude + ",精度:" + requestMessage.Precision;
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
                    break;
            }

            return reponseMessage;
        }

        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            switch (requestMessage.Content)
            {
                default:
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
            return "自动回复";
        }

        /// <summary>
        /// 获取被关注后的消息
        /// </summary>
        /// <returns></returns>
        private string GetWelcomeInfo(string openid)
        {           
            return "欢迎信息";
        }

        private bool IsWorkingTime()
        {
            DateTime now = DateTime.Now;
            DateTime start = new DateTime(now.Year, now.Month, now.Day, 7, 50, 0);
            DateTime end = new DateTime(now.Year, now.Month, now.Day, 18, 10, 0);
            if (now > start && now < end)
            {
                return true;
            }
            else
                return false;
        }
    }
}
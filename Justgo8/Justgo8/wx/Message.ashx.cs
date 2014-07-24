using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Senparc.Weixin.MP;
using Common;

namespace Justgo8.wx
{
    /// <summary>
    /// Message 的摘要说明
    /// </summary>
    public class Message : IHttpHandler
    {
        public string Token = "K6mKyNit9BLor2B4mzQXcg";
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod == "GET")
            {
                Verify(context, context.Request["signature"], context.Request["timestamp"], context.Request["nonce"], context.Request["echostr"]);
            }
            else
            {
                MessageHandle(context, context.Request["signature"], context.Request["timestamp"], context.Request["nonce"], context.Request["echostr"]);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void Verify(HttpContext context, string signature, string timestamp, string nonce, string echostr)
        {
            if (CheckSignature.Check(signature, timestamp, nonce, Token))
            {
                context.Response.Write(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                context.Response.Write("failed:" + signature + "," + CheckSignature.GetSignature(timestamp, nonce, Token));
            }
        }

        public void MessageHandle(HttpContext context, string signature, string timestamp, string nonce, string echostr)
        {
            if (!CheckSignature.Check(signature, timestamp, nonce, Token))
            {
                context.Response.Write("");
                return;
            }

            ////v4.2.2之后的版本，可以设置每个人上下文消息储存的最大数量，防止内存占用过多，如果该参数小于等于0，则不限制
            int maxRecordCount = 10;

            try
            {
                var messageHandler = new GtxhMessageHandler(context.Request.InputStream, maxRecordCount);
                messageHandler.Execute();
                context.Response.ContentType = "text/xml";
                context.Response.Write(messageHandler.ResponseDocument.ToString());
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog("响应消息遇到错误:" + ex.ToString());
                context.Response.Write("");
            }
        }
    }
}
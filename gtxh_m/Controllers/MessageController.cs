using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP;
using System.IO;
using gtxh_m.Common;
using gtxh_m.Helpers;

namespace gtxh_m.Controllers
{
    public class MessageController : Controller
    {
        public string Token = "K6mKyNit9BLor2B4mzQXcg";

        /// <summary>
        /// 微信后台验证地址（使用Get）
        /// </summary>
        [HttpGet]
        [ActionName("Index")]
        public string Get(string signature, string timestamp, string nonce, string echostr)
        {
            if (CheckSignature.Check(signature, timestamp, nonce, Token))
            {
                return echostr; //返回随机字符串则表示验证通过
            }
            else
            {
                return "failed:" + signature + "," + CheckSignature.GetSignature(timestamp, nonce, Token);
            }
        }

        /// <summary>
        /// 用户发送消息后，微信平台自动Post一个请求到这里，并等待响应XML。
        /// PS：此方法为简化方法，效果与OldPost一致。
        /// v0.8之后的版本可以结合Senparc.Weixin.MP.MvcExtension扩展包，使用WeixinResult，见MiniPost方法。
        /// </summary>
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post(string signature, string timestamp, string nonce, string echostr)
        {
            if (!CheckSignature.Check(signature, timestamp, nonce, Token))
            {
                //非微信消息
                return Content("");
            }

            ////v4.2.2之后的版本，可以设置每个人上下文消息储存的最大数量，防止内存占用过多，如果该参数小于等于0，则不限制
            int maxRecordCount = 10;

            try
            {
                var messageHandler = new GtxhMessageHandler(Request.InputStream, maxRecordCount);
                messageHandler.Execute();
                return Content(messageHandler.ResponseDocument.ToString(), "text/xml");
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog("响应消息遇到错误:" + ex.ToString());
                return Content("");
            }

            //////自定义MessageHandler，对微信请求的详细判断操作都在这里面。
            //var messageHandler = new CustomMessageHandler(Request.InputStream, maxRecordCount);
            //try
            //{
            //    //测试时可开启此记录，帮助跟踪数据，使用前请确保App_Data文件夹存在，且有读写权限。
            //    //messageHandler.RequestDocument.Save("E:/Logs/DateTime.Now.Ticks" + "_Request_" + messageHandler.RequestMessage.FromUserName + ".txt");
            //   // messageHandler.RequestDocument.Save(Server.MapPath("~/Content/Logs/" + DateTime.Now.Ticks + "_Request_" + messageHandler.RequestMessage.FromUserName + ".txt"));
            //    //执行微信处理过程

            //    messageHandler.Execute();
            //    if (!messageHandler.CancelExcute)
            //    {
            //        //测试时可开启，帮助跟踪数据
            //        //messageHandler.ResponseDocument.Save("E:/Logs/" + DateTime.Now.Ticks + "_Response_" + messageHandler.ResponseMessage.ToUserName + ".txt");
            //        messageHandler.ResponseDocument.Save(Server.MapPath("~/Content/Logs/" + DateTime.Now.Ticks + "_Response_" + messageHandler.ResponseMessage.ToUserName + ".txt"));
            //        return Content(messageHandler.ResponseDocument.ToString(), "text/xml");
            //    }
            //    else
            //    {
            //        return Content("");
            //    }
            //}
            //catch (Exception ex)
            //{               
            //    ErrorLog.AddErrorLog("响应消息遇到错误:"+ex.ToString());
            //    return Content("");
            //}
        }
    }
}

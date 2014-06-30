using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using gtxh_m.Models;

namespace gtxh_m.Common
{
    /// <summary>
    /// 手机验证码管理类
    /// </summary>
    public class MobileCaptcha
    {
        static MobileCaptcha()
        {
            allCaptcha = new List<Captcha>();
            MobileCaptcha.StartClearCaptcha();
        }

        static List<Captcha> allCaptcha;

        /// <summary>
        /// 生成验证码
        /// </summary>
        public static string MakeCaptcha(string mobile)
        {
            Captcha captcha = GetCaptcha(mobile);
            if (captcha == null)
            {
                captcha = new Captcha();
                captcha.Mobile = mobile;
                captcha.Code = new Random().Next(100000, 999999).ToString();
                captcha.AddTime = DateTime.Now;
                allCaptcha.Add(captcha);
            }
            return captcha.Code;
        }

        /// <summary>
        /// 获取手机验证码
        /// </summary>
        public static Captcha GetCaptcha(string mobile)
        {
            return allCaptcha.Find(delegate(Captcha c)
            {
                return c.Mobile.Equals(mobile);
            });
        }

        /// <summary>
        /// 移除一个验证码
        /// </summary>
        public static void RemoveCaptcha(Captcha c)
        {
            allCaptcha.Remove(c);
        }
        /// <summary>
        /// 开始一个新线程清除无用的手机验证码
        /// </summary>
        public static void StartClearCaptcha()
        {
            new Thread(new ThreadStart(delegate()
            {
                lock (allCaptcha)
                {
                    DateTime n = DateTime.Now;
                    allCaptcha.RemoveAll(delegate(Captcha c)
                    {
                        return (c.AddTime - n).Minutes > 3;
                    });
                }
                Thread.Sleep(180000);//每隔三分钟清理一次。
                StartClearCaptcha();
            })).Start();
        }
    }

}
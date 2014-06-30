using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gtxh_m.Common;
using System.Configuration;
using gtxh_m.com.gtxh.iv;

namespace gtxh_m.Controllers
{
    public class RegisterController : Controller
    {
        private string gtxh_key = ConfigurationManager.AppSettings["iv_key"];

        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(string id)
        {
            TempData["openid"] = id;
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post(string id)
        {
            string phone = Request["phone"];
            string code = Request["code"];
            string openid = id;

            if (Session["captcha"] != null && Session["captcha"].ToString() == code)
            {
                Session["phone"] = phone;
                TempData["openid"] = openid;
                return RedirectToAction("SetPassport", new { id = openid });
            }
            else
            {
                ViewBag.Msg = "验证码不正确!";
                ViewBag.Phone = phone;
                return View();
            }
        }
        [HttpGet]
        [ActionName("SetPassport")]
        public ActionResult Index(string id)
        {
            TempData["openid"] = id;
            return View();
        }

        [HttpPost]
        [ActionName("SetPassport")]
        public ActionResult SetPassport()
        {
            try
            {
                string pwd = Request["txtensure"];
                if (string.IsNullOrEmpty(pwd))
                {
                    ViewBag.Msg = "密码不能为空!";
                }
                else if (Session["phone"] != null)
                {
                    string phone = Session["phone"].ToString();
                    User iv = new User();
                    int result = iv.RegNewUser_app(gtxh_key, phone);
                    if (result > 0)
                    {
                        return Content(string.Format("<script>alert('{0}');location.href='{1}'</script>", "注册成功,您可以绑定微信了", "http://m.gtxh.com/Login?openid=" + TempData["openid"]));
                    }
                    else
                    {
                        switch (result)
                        {
                            case -1:
                                ViewBag.Msg = "该手机号已注册过,请直接登录";
                                break;
                            case 0:
                            default:
                                ViewBag.Msg = "注册失败!";
                                break;
                        }
                    };
                }
                else
                {
                    ViewBag.Msg = "未通过短信验证,无法完成注册!";
                }
                return View();
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog("Setpwd:" + ex.ToString());
                ViewBag.Msg = "系统繁忙,请稍后重试!";
                return View();
            }
        }

        [HttpPost]
        public ActionResult SendCaptcha(string phone)
        {
            try
            {
                Int64 p;
                if (phone.Length == 11 && Int64.TryParse(phone, out p))
                {
                    User iv = new User();
                    int result = iv.IsmbExist(gtxh_key, phone);
                    if (result > 0)  //已注册过的手机
                    {
                        return Content("{\"errorcode\":\"1004\",\"errormsg\":\"该手机号已注册过!\"}");
                    }
                    else
                    {
                        if (Session["lastsendtime"] != null && (DateTime.Parse(Session["lastsendtime"].ToString()) - DateTime.Now).TotalSeconds < 50)
                        {
                            return Content("{\"errorcode\":\"1002\",\"errormsg\":\"发送过于频繁\"}");
                        }
                        else
                        {
                            string captcha = MobileCaptcha.MakeCaptcha(phone);
                            Session["captcha"] = captcha;
                            Session["lastsendtime"] = DateTime.Now;
                            return Content("{\"errorcode\":\"0\",\"errormsg\":\"发送成功\"}");
                        }
                    }
                }
                else
                {
                    return Content("{\"errorcode\":\"1001\",\"errormsg\":\"手机号码格式不正确\"}");
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog("Register->SendCaptcha:" + ex.ToString());
                return Content("{\"errorcode\":\"1003\",\"errormsg\":\"系统错误\"}");
            }
        }
    }
}

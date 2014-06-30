using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using gtxh_m.com.gtxh.iv;

namespace gtxh_m.Controllers
{
    public class LoginController : Controller
    {
        private string iv_key = ConfigurationManager.AppSettings["iv_key"];

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
            string passport = Request["passport"];
            string openid = id;
            if (string.IsNullOrEmpty(phone))
            {
                ViewBag.Passport = passport;
                ViewData["msg"] = "请输入您的手机号!";
            }
            else if (string.IsNullOrEmpty(passport))
            {
                ViewBag.Phone = phone;
                ViewData["msg"] = "请输入您的密码!";
            }
            else if (string.IsNullOrEmpty(openid))//openid为空,无法绑定
            {
                ViewData["msg"] = "绑定参数不正确,请从微信重新打开";
                ViewBag.Phone = phone;
                ViewBag.Passport = passport;
                return View();
            }
            else
            {
                ViewBag.errorCode = "";
                //(微信登录)根据手机号码和密码登录帐户，修改Openid:-1不存在用户信息；-2密码错误；-3登录失败；-4key值错误；-5手机号码为空；-6非认证用户；-7账号已被锁定，且尚未解锁；-10;该账号已被冻结；登录成功返回LoginInfoID
                User iv = new User();
                int result = iv.AddOpenid(iv_key, phone, passport, openid);
                if (result > 0)
                {
                    Session["userid"] = result;
                    if (string.IsNullOrEmpty(Request["returnurl"]))
                    {
                        return RedirectToAction("Index", "Market");
                    }
                    else
                    {
                        return Redirect(Request["returnurl"]);
                    }
                }
                else
                {
                    string errormsg = string.Empty;
                    switch (result)
                    {
                        case -1:
                            errormsg = "用户不存在";
                            break;
                        case -2:
                            errormsg = "密码错误";
                            break;
                        case -6:
                            errormsg = "账户未认证";
                            break;
                        case -7:
                            errormsg = "账号已被锁定，且尚未解锁";
                            break;
                        case -10:
                            errormsg = "您的账号已被冻结";
                            break;
                        default:
                            errormsg = "错误号(" + result.ToString() + ")";
                            break;
                    }
                    ViewBag.Phone = phone;
                    ViewBag.Passport = passport;
                    ViewData["msg"] = "绑定失败," + errormsg;
                }
            }
            return View();
        }

    }
}

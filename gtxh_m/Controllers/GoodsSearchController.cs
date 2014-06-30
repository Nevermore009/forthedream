using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gtxh_m.Common;
using System.Configuration;
using gtxh_m.com.gtxh.api;

namespace gtxh_m.Controllers
{
    public class GoodsSearchController : Controller
    {
        private string api_key = ConfigurationManager.AppSettings["iv_key"];     

        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get()
        {
            if (Session["userid"] == null)
            {
                ViewBag.RightTop = "help";
                ViewBag.openid = Request["openid"];
            }
            else
            {
                ViewBag.BackButton = false;
            }
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post()
        {
            try
            {
                if (Session["userid"] != null)
                {
                    ViewBag.BackButton = false;
                }
                if (string.IsNullOrEmpty(Request["searchinfo"]))
                {
                    ViewData["msg"] = "请填写您需要的钢材信息及您的联系方式!";
                    return View();
                }
                string phone = MobileHelper.FiltPhone(Request["searchinfo"]);
                if (phone == "" && Session["userid"] == null)
                {
                    ViewBag.searchinfo = Request["searchinfo"];
                    ViewData["msg"] = "您没有绑定账号,请在内容中附带您的手机号码!";
                    return View();
                }
                ResourceSupply api = new ResourceSupply();
                int lid = 0;
                if (Session["userid"] != null)
                {
                    lid = int.Parse(Session["userid"].ToString());
                }
                int result = api.Add(api_key, Request["searchinfo"], lid, "");
                if (result > 0)
                {
                    ViewData["msg"] = "您的找货请求已成功提交!";
                }
                else
                {
                    ViewData["msg"] = "系统繁忙,请稍后重试!";
                }
                return View();
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog("GoodsSearch:" + ex.ToString());
                ViewData["msg"] = "系统繁忙,请稍后重试!";
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs;
using gtxh_m.Models;
using Senparc.Weixin.MP;
using gtxh_m.Common;
using System.Configuration;

namespace gtxh_m.Controllers
{
    public class OAuth2Controller : Controller
    {
        //下面换成账号对应的信息，也可以放入web.config等地方方便配置和更换
        private string appId = "wx815b61e93898c53e";
        private string secret = "d81e58c8ccaacc7902089f2f83b2fc3d";
        private string iv_key = ConfigurationManager.AppSettings["iv_key"];

        public ActionResult Callback(string code, int state)
        {
            if (string.IsNullOrEmpty(code))
            {
                ErrorLog.AddErrorLog("code empty");
                //return RedirectToAction("Index", "Login");
                return Content("微信授权失败,请返回公众号重试.");
            }
            else
            {
                //ErrorLog.AddErrorLog("code:" + code);
            }

            try
            {
                OAuthAccessTokenResult result = OAuth.GetAccessToken(appId, secret, code);

                if (result.errcode != ReturnCode.请求成功)
                {
                    return Content("微信授权失败：" + result.errmsg);
                }
                else
                {
                    com.gtxh.iv.User iv = new com.gtxh.iv.User();
                    int loginresult = iv.Login_Wechat(iv_key, result.openid);
                    if (loginresult > 0)
                    {
                        Session["OAuthAccessTokenStartTime"] = DateTime.Now;
                        Session["OAuthAccessToken"] = result.access_token;
                        Session["userid"] = loginresult;
                        switch (state)
                        {
                            case (int)DestinationPage.FindGoods:
                                return RedirectToAction("Index", "GoodsSearch");
                            case (int)DestinationPage.Market:
                                return RedirectToAction("Index", "Market");
                            case (int)DestinationPage.DirectSale:
                                return RedirectToAction("Index", "SteelYieldly");
                            case (int)DestinationPage.Login:
                                return RedirectToAction("Index", "Login", new { id = result.openid });
                            default:
                                return RedirectToAction("Index", "Market");
                        }
                    }
                    else
                    {
                        //如果是委托找货,可不登录
                        if (state == (int)DestinationPage.FindGoods)
                        {
                            return RedirectToAction("Index", "GoodsSearch", new { openid = result.openid });
                        }

                        //-1key值错误；-2微信openid为空；-3登录失败；-4系统错误
                        string errorMsg = string.Empty;
                        errorMsg = "登录失败:" + loginresult.ToString();
                        switch (loginresult)
                        {
                            case -3:
                                Session["OAuthAccessToken"] = result.access_token;
                                string url = "";
                                switch (state)
                                {
                                    case (int)DestinationPage.FindGoods:
                                        url = "/GoodsSearch";
                                        break;
                                    case (int)DestinationPage.Market:
                                        url = "/Market";
                                        break;
                                    case (int)DestinationPage.DirectSale:
                                        url = "/SteelYieldly";
                                        break;
                                    default:
                                        break;
                                }
                                return Redirect("/Login/Index/" + result.openid + "?returnurl=" + url);
                            case -6:
                                errorMsg = "账户未认证";
                                break;
                            case -7:
                                errorMsg = "账号已被锁定，且尚未解锁";
                                break;
                            case -10:
                                errorMsg = "您的账号已被冻结";
                                break;
                            case -1:
                            case -2:
                            case -4:
                            default:
                                errorMsg = "错误(" + loginresult + ")";
                                break;
                        }
                        return Content(string.Format("<script>alert('{0}');location.href='{1}'</script>", errorMsg, "http://m.gtxh.com/Login?openid=" + result.openid));
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex.ToString());
                return Content(ex.Message);
            }
        }
    }
}
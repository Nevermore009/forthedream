using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Menu;
using gtxh_m.Models;
using Senparc.Weixin.MP;

namespace gtxh_m.Controllers
{
    public class MenuController : Controller
    {
        private string access_key = "gtxh_jsb";
        private string appId = "wx815b61e93898c53e";
        private string secret = "d81e58c8ccaacc7902089f2f83b2fc3d";

        public ActionResult Index(string key)
        {
            if (key != access_key)
                return Content("未通过身份验证");
            string access_token = AccessTokenContainer.TryGetToken(appId, secret);
            var result = CommonApi.GetMenu(access_token);
            if (result == null)
            {
                return Json(new { error = "菜单不存在或验证失败！" }, JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(string key)
        {
            try
            {
                if (key != access_key)
                    return Content("未通过身份验证");

                string oauth2 = "http://m.gtxh.com/OAuth2/Callback";
                //分析报告
                string report_url = "http://m.gtxh.com/Report";
                //钢为观点
                string gtxhOpinion_url = "http://m.gtxh.com/Opinion";

                GetMenuResultFull resultFull = new GetMenuResultFull()
                {
                    menu = new MenuFull_ButtonGroup()
                    {
                        button = new List<MenuFull_RootButton>() { 
                            new MenuFull_RootButton() {
                                key="microsteel",name="微钢市",sub_button=new List<MenuFull_RootButton>() {
                                      new MenuFull_RootButton(){
                                          name="帮我找货",type="view",url="https://open.weixin.qq.com/connect/oauth2/authorize?appid="+appId+"&redirect_uri="+oauth2+"&response_type=code&scope=snsapi_base&state="+(int)DestinationPage.FindGoods+"#wechat_redirect",sub_button=new List<MenuFull_RootButton>()
                                      },
                                      new MenuFull_RootButton(){
                                          name="钢铁超市",type="view",url="https://open.weixin.qq.com/connect/oauth2/authorize?appid="+appId+"&redirect_uri="+oauth2+"&response_type=code&scope=snsapi_base&state="+(int)DestinationPage.Market+"#wechat_redirect",sub_button=new List<MenuFull_RootButton>()
                                      },
                                      new MenuFull_RootButton(){
                                          name="钢厂直销",type="view",url="https://open.weixin.qq.com/connect/oauth2/authorize?appid="+appId+"&redirect_uri="+oauth2+"&response_type=code&scope=snsapi_base&state="+(int)DestinationPage.DirectSale+"#wechat_redirect",sub_button=new List<MenuFull_RootButton>()
                                      }
                                }
                            }, 
                            new MenuFull_RootButton() {
                                key="view",name="看行情",sub_button=new List<MenuFull_RootButton>(){
                                      new MenuFull_RootButton(){
                                          key="todaynews",name="今日推荐",type="click",sub_button=new List<MenuFull_RootButton>()
                                      },
                                      new MenuFull_RootButton(){
                                          name="分析报告",type="view",url=report_url,sub_button=new List<MenuFull_RootButton>()
                                      },
                                      new MenuFull_RootButton(){
                                          name="钢为观点",type="view",url=gtxhOpinion_url,sub_button=new List<MenuFull_RootButton>()
                                      }
                                }
                            },
                            new MenuFull_RootButton() {
                                key="easysteel",name="掌中钢市",sub_button=new List<MenuFull_RootButton>(){
                                      new MenuFull_RootButton(){
                                            key="easysteel-android",name="安卓版",type="view",url="http://app.gtxh.com/down/",sub_button=new List<MenuFull_RootButton>()
                                      },
                                      new MenuFull_RootButton(){
                                            key="easysteel-ios",name="IOS版",type="view",url="https://itunes.apple.com/cn/app/id871711041",sub_button=new List<MenuFull_RootButton>()
                                      }
                                } 
                            } 
                        }
                    }
                };
                string access_token = AccessTokenContainer.TryGetToken(appId, secret);
                var buttonData = CommonApi.GetMenuFromJsonResult(resultFull).menu;
                var result = CommonApi.CreateMenu(access_token, buttonData);
                if (result.errcode == 0)
                {
                    return Content("创建成功!");
                }
                else
                {
                    return Content("failed(" + result.errcode + "):" + result.errmsg);
                }
            }
            catch (Exception ex)
            {
                var json = new { Success = false, Message = ex.Message };
                return Json(json);
            }
        }

        public ActionResult DeleteMenu(string token)
        {
            try
            {
                var result = CommonApi.DeleteMenu(token);
                var json = new
                               {
                                   Success = result.errmsg == "ok",
                                   Message = result.errmsg
                               };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var json = new { Success = false, Message = ex.Message };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using gtxh_m.Models;
using Newtonsoft.Json;
using gtxh_m.Common;
using gtxh_m.com.gtxh.market;

namespace gtxh_m.Controllers
{
    public class MarketController : Controller
    {
        private string web_key = ConfigurationManager.AppSettings["iv_key"];
        private int pagesize = 20;

        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get()
        {
            MarketAppService market = new MarketAppService();
            int total;
            DataTable dt = market.MarketResourceList(web_key, pagesize, 1, 0, 0, 0, "", "", 0, false,out total);
            if (dt != null)
            {
                List<Resource> models = new List<Resource>();
                foreach (DataRow row in dt.Rows)
                {
                    Resource temp = new Resource();
                    temp.ID = row["ID"].ToString();
                    temp.Materils = row["Materials"].ToString();
                    temp.NSortID = row["NSortID"].ToString();
                    temp.NSortName = row["NSortName"].ToString();
                    temp.Price = row["Price"].ToString();
                    temp.Spec = row["Specs"].ToString();
                    models.Add(temp);
                }
                @ViewBag.Msg = "暂无数据";
                ViewBag.Count = total;
                return View(models);
            }
            else
            {
                ViewBag.Msg = "暂无数据";
                return View();
            }
        }

        [HttpPost]
        [ActionName("Index")]
        public string Post()
        {
            try
            {
                int sort, nsort, provinceid, pageIndex;
                if (int.TryParse(Request["sortid"], out sort) && int.TryParse(Request["nsortid"], out nsort) && int.TryParse(Request["provinceid"], out provinceid) && int.TryParse(Request["pageIndex"], out pageIndex))
                {
                    string yieldlydirect = Request["yieldly"];
                    string spec = Request["spec"];
                    return GetJsonData(pageIndex, sort, nsort, provinceid, spec, yieldlydirect);
                }
                else
                {
                    return "{\"resultCode\":\" -1\",\"msg\":\"参数不正确\"}";
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog("market:" + ex.ToString());
                return "{\"resultCode\":-2,\"msg\":\"服务器错误\"}";
            }
        }

        private string GetJsonData(int pageIndex, int sort, int nsort, int provinceid, string spec, string yiedly)
        {
            int total;
            MarketAppService market = new MarketAppService();
            bool search=false;
            if (sort != 0 || nsort != 0 || provinceid != 0 || !string.IsNullOrEmpty(yiedly) || !string.IsNullOrEmpty(spec))
            {
                search = true;
            }
            DataTable dt = market.MarketResourceList(web_key, pagesize, pageIndex, sort, nsort, provinceid, yiedly, spec, 0, search, out total);
            if (dt != null)
            {
                List<Resource> models = new List<Resource>();
                foreach (DataRow row in dt.Rows)
                {
                    Resource temp = new Resource();
                    temp.ID = row["ID"].ToString();
                    temp.Materils = row["Materials"].ToString();
                    temp.NSortID = row["NSortID"].ToString();
                    temp.NSortName = row["NSortName"].ToString();
                    temp.Price = row["Price"].ToString();
                    temp.Spec = row["Specs"].ToString();
                    models.Add(temp);
                }
                string jsondata = JsonConvert.SerializeObject(models);
                int resultcode = 0;
                if (models.Count < pagesize)
                {
                    resultcode = 1001;
                }
                return "{\"resultCode\":" + resultcode + ",\"total\":" + total + ",\"data\":" + jsondata + "}";
            }
            else
            {
                return string.Format("{\"resultCode\":\"{0}\",\"total\":0,\"data\":\"\"", 0);
            }
        }

        [HttpGet]
        public ActionResult Detail(string id)
        {
            long rid;
            ResourceModel model = new ResourceModel();
            if (long.TryParse(id, out rid))
            {
                MarketAppService market = new MarketAppService();
                model = market.ResourceDetail(web_key, rid);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Detail()
        {
            string resourceid = Request["rid"];
            string errormsg = "";
            if (Session["userid"] != null)
            {
                int userid = int.Parse(Session["userid"].ToString());
                long id;
                string price = Request["txtprice"];
                string weight = Request["txtweight"];
                int bprice, bweight;
                string IP = Request.UserHostAddress;
                if (long.TryParse(resourceid, out id) && int.TryParse(price, out bprice) && int.TryParse(weight, out bweight))
                {
                    MarketAppService market = new MarketAppService();
                    string result = market.ToOrder(web_key, userid, id, bprice, bweight, "自主提货", IP);
                    // "yjback"; //已下架，不能下单
                    //"noweight"; //重量不够，不能下单
                    //"samecompany"; //不能下单自己公司的资源
                    //"yjbook"; //已经下单了此资源
                    //"0";//失败
                    //"1";//成功
                    switch (result)
                    {
                        case "1":
                            errormsg = "下单成功";
                            break;
                        case "yjback":
                            errormsg = "该资源已下架,不能下单了!";
                            break;
                        case "noweight":
                            errormsg = "重量不够,下单失败!";
                            break;
                        case "samecompany":
                            errormsg = "您不能下单自己公司的资源!";
                            break;
                        case "yjbook":
                            errormsg = "您已经下单了此资源!";
                            break;
                        case "0":
                        default:
                            errormsg = "系统繁忙,请稍后重试";
                            break;
                    }
                }
                else
                {
                    errormsg = "价格或重量填写不正确!";
                }
            }
            else
            {
                errormsg = "您的登录已过期,请返回微信重新进入!";
            }

            TempData.Add("msg", errormsg);
            TempData.Add("price", Request["txtprice"]);
            TempData.Add("weight", Request["txtweight"]);
            return RedirectToActionPermanent("Detail", new { id = resourceid }); ;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using gtxh_m.Models;
using gtxh_m.Common;
using gtxh_m.com.gtxh.market;

namespace gtxh_m.Controllers
{
    public class SteelYieldlyController : Controller
    {
        private string web_key = ConfigurationManager.AppSettings["iv_key"];
        private int pagesize = 20;

        public ActionResult Index()
        {
            try
            {
                MarketAppService market = new MarketAppService();
                DataTable dt = market.GetYieldly(web_key);
                List<Yieldly> models = new List<Yieldly>();
                foreach (DataRow row in dt.Rows)
                {
                    Yieldly temp = new Yieldly();
                    temp.YieldlyName = row["Yieldly"].ToString();
                    temp.LogoUrl = row["LogoUrl"].ToString() == "" ? "http://m.gtxh.com/Content/images/default.png" : row["LogoUrl"].ToString();
                    models.Add(temp);
                }
                if (models.Count > 0)
                {
                    return View(models);
                }
                else
                {
                    ViewBag.Msg = "暂无数据";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog("SteelYieldly:" + ex.ToString());
                return View();
            }
        }

        public ActionResult detail(string yieldly)
        {
            ViewBag.Yieldly = yieldly;
            MarketAppService market = new MarketAppService();
            int total;
            DataTable dt = market.MarketResourceList(web_key, pagesize, 1, 0, 0, 0, yieldly, "", 0, false, out total);
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
    }
}

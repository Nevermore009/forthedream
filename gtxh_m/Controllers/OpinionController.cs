using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using gtxh_m.Models;
using Newtonsoft.Json;
using gtxh_m.com.gtxh.news;

namespace gtxh_m.Controllers
{
    public class OpinionController : Controller
    {
        private string web_key = ConfigurationManager.AppSettings["iv_key"];
        private int pagesize = 10;

        [HttpGet]
        public ActionResult Index()
        {
            News news = new News();
            DataSet ds = news.GetGangWeiNews(web_key, 0, pagesize);
            if (ds != null)
            {
                List<GtxhOpinion> models = new List<GtxhOpinion>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    GtxhOpinion temp = new GtxhOpinion();
                    temp.NewsId = row["NewsId"].ToString();
                    temp.NewsTitle = row["NewsTitle"].ToString();
                    temp.PublicTime = row["PubTime"].ToString();
                    temp.Url = "http://news.gtxh.com" + row["staticpath"].ToString();
                    models.Add(temp);
                }
                @ViewBag.Msg = "暂无数据";
                ViewBag.Count = ds.Tables[1].Rows[0][0];
                return View(models);
            }
            else
            {
                ViewBag.Msg = "暂无数据";
                return View();
            }
        }

        [HttpPost]
        public string GetData(int pageIndex)
        {
            News news = new News();
            DataSet ds = news.GetGangWeiNews(web_key, pageIndex, pagesize);
            if (ds != null)
            {
                List<GtxhOpinion> models = new List<GtxhOpinion>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    GtxhOpinion temp = new GtxhOpinion();
                    temp.NewsId = row["NewsId"].ToString();
                    temp.NewsTitle = row["NewsTitle"].ToString();
                    temp.PublicTime = row["PubTime"].ToString();
                    temp.Url = "http://news.gtxh.com" + row["staticpath"].ToString();
                    models.Add(temp);
                }
                if (models.Count > 0)
                {
                    string datajson = JsonConvert.SerializeObject(models);
                    string errorCode = "0";
                    if (models.Count < pagesize)
                    {
                        errorCode = "1001";
                    }
                    return "{\"resultCode\":\""+errorCode+"\",\"data\":" + datajson + "}";
                }
                else
                {
                    //没有数据
                    return string.Format("{\"resultCode\":\"{0}\",\"data\":\"\"", 1001);
                }
            }
            else
            {
                //没有数据
                return string.Format("{\"resultCode\":\"{0}\",\"data\":\"\"", 1001);
            }
        }
    }
}

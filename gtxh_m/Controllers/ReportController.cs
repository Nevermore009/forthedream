using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using gtxh_m.Common;
using gtxh_m.Models;
using Newtonsoft.Json;
using gtxh_m.com.gtxh.fxs;

namespace gtxh_m.Controllers
{
    public class ReportController : Controller
    {
        private string web_key = ConfigurationManager.AppSettings["fxs_key"];
        private int pagesize = 10;

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                Article fxs = new Article();
                DataSet ds = fxs.GetArticleList_Free(web_key, 1, pagesize);
                if (ds != null)
                {
                    List<ReportArticle> models = new List<ReportArticle>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ReportArticle temp = new ReportArticle();
                        temp.ArticleId = row["ArticleId"].ToString();
                        temp.ArticleTitle = row["ArticleTitle"].ToString();
                        temp.Description = row["Description"].ToString().Length > 40 ? row["Description"].ToString().Substring(0, 37) + "......" : row["Description"].ToString();
                        temp.ImagePath = row["ImagePath"].ToString()==""?"http://m.gtxh.com/Content/images/tp.jpg":row["ImagePath"].ToString();
                        temp.Url = row["Url"].ToString();
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
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog("reportController:" + ex.ToString());
                return View();
            }
        }

        [HttpPost]
        public string GetData(int pageIndex)
        {
            Article fxs = new Article();
            DataSet ds = fxs.GetArticleList(web_key, pageIndex, pagesize);
            if (ds != null)
            {
                List<ReportArticle> models = new List<ReportArticle>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ReportArticle temp = new ReportArticle();
                    temp.ArticleId = row["ArticleId"].ToString();
                    temp.ArticleTitle = row["ArticleTitle"].ToString();
                    temp.Description = row["Description"].ToString();
                    temp.ImagePath = row["ImagePath"].ToString();
                    temp.Url = row["Url"].ToString();
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
                    return "{\"resultCode\":\"" + errorCode + "\",\"data\":" + datajson + "}";
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

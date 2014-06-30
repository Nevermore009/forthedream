using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gtxh_m.Models
{
    public class ReportArticle
    {
        public string ArticleId { set; get; }
        public string ArticleTitle { set; get; }
        public string Description { set; get; }
        public string ImagePath { set; get; }
        public string Url { set; get; }
    }
}
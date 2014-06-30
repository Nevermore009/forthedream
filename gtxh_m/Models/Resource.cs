using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gtxh_m.Models
{
    /// <summary>
    /// 资源信息
    /// </summary>
    public class Resource
    {
        public string ID { set; get; }
        public string NSortName { set; get; }
        public string NSortID { set; get; }
        public string Materils { set; get; }
        public string Spec { set; get; }
        public string Price { set; get; }
    }
}
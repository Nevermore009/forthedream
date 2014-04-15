using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Justgo8
{
    public partial class IndexMaster : System.Web.UI.MasterPage
    {
        public string pageName = "index.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            pageName = Request.FilePath.Substring(Request.FilePath.LastIndexOf("/") + 1); ;
        }
    }
}
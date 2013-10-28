using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMCShine.Common;

public partial class defaultpage : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbuser.Text = Request.Cookies["username"] == null ? "" : AES.Decrypt(Request.Cookies["username"].Value);
        }
    }
    protected void lkbtnLoginOut_Click(object sender, EventArgs e)
    {
        Response.Cookies.Clear();
        Response.Redirect("../index.aspx");
    }
}
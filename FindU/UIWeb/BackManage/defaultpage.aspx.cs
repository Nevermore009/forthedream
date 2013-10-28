using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class defaultpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            // MessageBox.ShowAndRedirect(this.Page, "网页已过期!", "index.aspx");
            return;
        }
    }
    protected void lkbtnLoginOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("../index.aspx");
    }
}
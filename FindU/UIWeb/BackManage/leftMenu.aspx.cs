using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class leftPages_leftMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            //MessageBox.ShowAndRedirect(this.Page, "网页已过期!", "../index.aspx");
            return;
        }
    }
}
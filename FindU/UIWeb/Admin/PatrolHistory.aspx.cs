using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL;
using Common;

public partial class PatrolHistory : System.Web.UI.Page
{
    Patrol patrolbll = new Patrol();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindHelper.BindGridview(grvhistory, patrolbll.GetHistoryList());
        }
    }


    protected void grvhistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != -1)
        {
            ((LinkButton)e.Row.FindControl("lbtnview")).Attributes.Add("onclick", "window.open('MapView.aspx?route=" + grvhistory.DataKeys[e.Row.RowIndex].Values["routeid"].ToString() + "&planid=" + grvhistory.DataKeys[e.Row.RowIndex].Values["planid"].ToString() + "','','location=no,titlebar=no,alwaysRaised=yes,scroll=no,Width=800,Height=600')");
        }
    }
}

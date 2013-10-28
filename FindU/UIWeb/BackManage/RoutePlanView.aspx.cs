using System;
using System.Data;
using System.Web.UI.WebControls;
using BLL;
using Common;

public partial class Admin_RoutePlanView : System.Web.UI.Page
{
    Plan planbll = new Plan();
    private static DataTable datasource;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            datasource = planbll.GetCollectPlanList();
            BindHelper.BindGridview(grvRoutePlan, datasource);
        }
    }
    protected void grvRoutePlan_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvRoutePlan.EditIndex = -1;
        BindHelper.BindGridview(grvRoutePlan, datasource);

    }
    protected void grvRoutePlan_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string planid = grvRoutePlan.DataKeys[e.RowIndex].Values["planid"].ToString();
        if (planbll.DeleteById(planid))
        {
            datasource = planbll.GetCollectPlanList();
            BindHelper.BindGridview(grvRoutePlan, datasource);
            MessageBox.Show(this.Page, "删除成功!");
        }
        else
        {
            MessageBox.Show(this.Page, "删除失败!");
        }
    }
    protected void grvRoutePlan_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string planid = grvRoutePlan.DataKeys[e.RowIndex].Values["planid"].ToString();
        string planname = ((TextBox)grvRoutePlan.Rows[e.RowIndex].FindControl("txtroutename")).Text;
        string description = ((TextBox)grvRoutePlan.Rows[e.RowIndex].FindControl("txtdescription")).Text;
        planbll.UpdatePatrolPlanById(planid, planname, description);
        grvRoutePlan.EditIndex = -1;
        datasource = planbll.GetCollectPlanList();
        BindHelper.BindGridview(grvRoutePlan, datasource);
    }
    protected void grvRoutePlan_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvRoutePlan.EditIndex = e.NewEditIndex;
        BindHelper.BindGridview(grvRoutePlan, datasource);
    }
    protected void grvRoutePlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != -1)
        {
            ((LinkButton)e.Row.FindControl("lbtnview")).Attributes.Add("onclick", "window.open('RouteAddInMap.aspx?planinfoid=" + grvRoutePlan.DataKeys[e.Row.RowIndex].Values["planinfoid"].ToString() + "','','location=no,titlebar=no,alwaysRaised=yes,resizable=yes,scroll=no,Width=800,Height=600')");
        }
    }
}

using System;
using System.Data;
using System.Web.UI.WebControls;
using BLL;
using Common;

public partial class Admin_RouteAdd : System.Web.UI.Page
{
    private Route routebll = new Route();
    private static DataTable datasource;
    private static DataTable routeinfodt;
    public static int colorindex = -1;//grv中点击颜色变化标志
    public static string plid = "";//点击行时获取planid绑定下面的GRV
    public static bool flag = true;//添加下一行时区分是已添加一行还未提交或者已提交
    public static string routeinfoid = "";//添加行的前一行RouteInfoID
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {  
            datasource = routebll.GetRouteList();
            BindHelper.BindGridview(grvroute, datasource);
          
        } 
    }
    #region  GRVRoute
    protected void grvroute_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvroute.EditIndex = e.NewEditIndex;
        BindHelper.BindGridview(grvroute, datasource);
    }
    protected void grvroute_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string routename = ((TextBox)grvroute.Rows[e.RowIndex].FindControl("txtroutename")).Text;
        string remark = ((TextBox)grvroute.Rows[e.RowIndex].FindControl("txtremark")).Text;
        string routeid = grvroute.DataKeys[e.RowIndex].Values["routeid"].ToString();
        if (routebll.ModifyRouteById(routeid, routename, remark))
            MessageBox.Show(this.Page, "修改成功!");
        else
            MessageBox.Show(this.Page, "网络忙,请稍后重试!");

    }
    protected void grvroute_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        e.Cancel = true;
        grvroute.EditIndex = -1;
        BindHelper.BindGridview(grvroute, datasource);
    }
    protected void grvroute_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != -1)
        {
            ((LinkButton)e.Row.FindControl("lbtnview")).Attributes.Add("onclick", "window.open('MapView.aspx?route=" + grvroute.DataKeys[e.Row.RowIndex].Values["routeid"].ToString() + "','','location=no,resizable=yes,titlebar=no,alwaysRaised=yes,scroll=no,Width=800,Height=600')");
        }
    }
    protected void grvroute_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "detail")
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string planid = grvroute.DataKeys[index].Values["routeid"].ToString();
            routeinfodt = routebll.GetRouteById(planid);
            BindHelper.BindGridview(grvrouteinfo, routeinfodt);
            if (!Session["roleid"].ToString().Equals("0"))
            {
                grvrouteinfo.Columns[5].Visible = false;
                grvrouteinfo.Columns[6].Visible = false;
            }

            plid = planid;
            paneldetail.Visible = true;
            grvroute.Rows[index].BackColor = System.Drawing.Color.FromName("#0090E9");
            if (colorindex != index && colorindex != -1)
            {
                grvroute.Rows[colorindex].BackColor = System.Drawing.Color.FromName("#DBEEFD");
            }

        }
    }
    #endregion
    #region GRVRouteInfo
    protected void grvrouteinfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvrouteinfo.PageIndex = e.NewPageIndex;
        BindHelper.BindGridview(grvrouteinfo, routeinfodt);
    }
    protected void grvrouteinfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "add")
        {
            if (flag == true)
            {
                string routeinfoID = e.CommandArgument.ToString();
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                int indexedit = drv.DataItemIndex - grvrouteinfo.PageIndex * 10;
                GridViewEditEventArgs ge = new GridViewEditEventArgs(indexedit + 1);
                DataRow dr = routeinfodt.NewRow();
                dr["title"] = "";
                dr["lat"] = 0; 
                dr["lon"] = 0;
                dr["remark"] = "";
                routeinfodt.Rows.InsertAt(dr, drv.DataItemIndex + 1);
                BindHelper.BindGridview(grvrouteinfo, routeinfodt);
                routeinfoid = routeinfoID;
                grvrouteinfo_RowEditing(sender, ge);
                flag = false;
            }
        }

    }
    protected void grvrouteinfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvrouteinfo.EditIndex = -1;
        routeinfodt = routebll.GetRouteById(plid);
        BindHelper.BindGridview(grvrouteinfo, routeinfodt);
        flag = true;
    }
    protected void grvrouteinfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string routeInfoID = grvrouteinfo.DataKeys[e.RowIndex].Values["RouteInfoID"].ToString();
        RouteInfo routeinfobll = new RouteInfo();
        if (routeinfobll.DeleteRouteInfoById(int.Parse(routeInfoID)))
        {
            MessageBox.Show(this.Page, "删除成功!");
        }
        routeinfodt = routebll.GetRouteById(plid);
        BindHelper.BindGridview(grvrouteinfo, routeinfodt);

    }
    protected void grvrouteinfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string routeInfoID = grvrouteinfo.DataKeys[e.RowIndex].Values["RouteInfoID"].ToString();
        RouteInfo routeinfobll = new RouteInfo();
        string title = ((TextBox)grvrouteinfo.Rows[e.RowIndex].FindControl("txttitle")).Text;
        string lat = ((TextBox)grvrouteinfo.Rows[e.RowIndex].FindControl("txtLat")).Text;
        string lon = ((TextBox)grvrouteinfo.Rows[e.RowIndex].FindControl("txtLon")).Text;
        if (flag == false)
        {
            RouteInfo rinfobll = new RouteInfo();

            if (rinfobll.insertRow(int.Parse(routeinfoid), title, lat, lon) == false)
            {
                MessageBox.Show(this.Page, "添加失败!");
            }
        }
        else
        {
            if (!routeinfobll.ModifyTitleById(int.Parse(routeInfoID), title, lat, lon))
            {
                MessageBox.Show(this, "更新失败");
            }
        }

        grvrouteinfo.EditIndex = -1;
        routeinfodt = routebll.GetRouteById(plid);
        BindHelper.BindGridview(grvrouteinfo, routeinfodt);
        flag = true;
    }
    protected void grvrouteinfo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvrouteinfo.EditIndex = e.NewEditIndex;
        BindHelper.BindGridview(grvrouteinfo, routeinfodt);
    }
    #endregion
}

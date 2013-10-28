using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Common;

public partial class Admin_ViewInMap : System.Web.UI.Page
{
    Staff staffbll = new Staff();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindGRV1();
            BindHelper.BindDropDownList(dropstaff, staffbll.GetNotFreeStaffList(), "staffname", "staffid");
            dropstaff.Items.Insert(0, new ListItem("全部", ""));
            BindYear();
            BindMonth();
            BindOnline();
        }
    }
    #region 绑定年份
    protected void BindYear()
    {
        int year = DateTime.Now.Year;
        for (int i = year; i <= year + 1; i++)
        {
            dropYear.Items.Add(new ListItem(i.ToString() + "年", i.ToString()));
        }
    }
    #endregion
    #region 绑定月份
    protected void BindMonth()
    {
        for (int i = 1; i <= 12; i++)
        {
            dropMonth.Items.Add(new ListItem(i.ToString() + "月", i.ToString()));
        }
        dropMonth.SelectedValue = DateTime.Now.Month.ToString();
    }
    #endregion
    #region GRV1事件
    protected void bindGRV1()
    {
        BLL.Route routebll = new BLL.Route();
        DataTable dt = routebll.GetRoute();
        BindHelper.BindGridview(GridView1, dt);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1 && e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.CssStyle.Add("cursor", "pointer");
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#D9FFFF'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            e.Row.Attributes.Add("onclick", "showRouteWithJudge(" + GridView1.DataKeys[e.Row.RowIndex].Values["RouteID"].ToString() + ");changeRowColor(" + GridView1.ClientID + "," + e.Row.RowIndex + ");");
        }
    }
    #endregion
    #region  绑定在线用户
    protected void BindOnline()
    {
        List<string> list = LongpollingHandle.ConnManager.waitThread.GetRequestList();//获得所有在线手机(IMEI)
        DataTable dt = null;
        if (list.Count != 0)
        {
            dt = new Staff().GetOnlineStaff(list, DateTime.Now.AddMinutes(-3).ToString());
        }
        BindHelper.BindGridview(GridView3, dt);
    }
    #endregion
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        DataTable dt=null;
        Patrol patrolbll = new Patrol();
        string patrolYear = dropYear.SelectedValue;
        string patrolMonth = dropMonth.SelectedValue;
        if (dropstaff.SelectedIndex == 0)
        {
            dt = patrolbll.GetPatrolInfoWithoutSID(patrolYear, patrolMonth);
        }
        else
        {
            string staffID = dropstaff.SelectedValue;
            dt = patrolbll.GetPatrolInfo(patrolYear, patrolMonth, staffID);
        }
        BindHelper.BindGridview(GridView2, dt);
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1 && e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.CssStyle.Add("cursor", "pointer");
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#D9FFFF'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            e.Row.Attributes.Add("onclick", "showPatrolWithJudge(" + GridView2.DataKeys[e.Row.RowIndex].Values["planinfoid"].ToString() + ")");
        }
    }

}
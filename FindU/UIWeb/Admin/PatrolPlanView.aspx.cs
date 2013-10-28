using System;
using System.Data;
using System.Web.UI.WebControls;
using BLL;
using System.IO;
using Common;
using System.Collections.Generic;

public partial class Admin_PatrolPlanView : System.Web.UI.Page
{
    Plan planbll = new Plan();
    private static DataTable datasource;
    public static string filepath = "";
    private static DataTable routeinfodt;
    PlanInfo infobll = new PlanInfo();
    RouteType routebll = new RouteType();
    Staff sbll = new Staff();
    public static int colorindex = -1;//grv中点击颜色变化标志
    public static string flag = "-1";//判断删除的planid是否是已点击了详细的planid
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            datasource = planbll.GetPatrolPlanList();
            BindgrvPatrol();
            BindStaff();
            BindRouteType();
            BindRouteName();
            BindMonth();
        }
    }
    #region 绑定督巡计划
    protected void BindgrvPatrol()
    {
        if (datasource == null)
        {
            datasource = planbll.GetPatrolPlanList();
        }
        BindHelper.BindGridview(grvPatrolPlan, datasource);
    }
    #endregion
    #region 绑定人员
    protected void BindStaff()
    {
        BindHelper.BindDropDownList(dropStaff, sbll.GetStaffList(), "StaffName", "StaffName");
        dropStaff.Items.Insert(0, new ListItem("--全部--", ""));
    }
    #endregion
    #region 绑定路线类型
    protected void BindRouteType()
    {
        BindHelper.BindDropDownList(droprouteType, routebll.GetRouteList(), "RouteTypeName", "RouteTypeName");
        droprouteType.Items.Insert(0, new ListItem("--全部--", ""));
    }
    #endregion
    #region 绑定路线名
    protected void BindRouteName()
    {
        BindHelper.BindDropDownList(dropRouteName, new Route().GetRouteList(), "RouteName", "RouteName");
        dropRouteName.Items.Insert(0, new ListItem("--全部--", ""));
    }
    #endregion
    #region 绑定月份
    protected void BindMonth()
    {
        for (int i = 1; i <= 12; i++)
        {
            dropMonth.Items.Add(new ListItem(i.ToString() + "月", i.ToString()));
        }
        dropMonth.Items.Insert(0, new ListItem("--全部--", ""));
    }
    #endregion
    #region 督巡计划GRV事件
    protected void grvPatrolPlan_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvPatrolPlan.EditIndex = -1;
        BindgrvPatrol();

    }
    protected void grvPatrolPlan_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string planstate = grvPatrolPlan.DataKeys[e.RowIndex].Values["state"].ToString();
        if (planstate != "0")
        {
            MessageBox.Show(this.Page, "计划已开始巡检或完成，无法删除!");
            return;
        }
        string planid = grvPatrolPlan.DataKeys[e.RowIndex].Values["planid"].ToString();
        if (planbll.DeleteById(planid))
        {
            datasource = planbll.GetPatrolPlanList();
            BindgrvPatrol();
            if (planid == flag)
            {
                Panel1.Visible = false;
            }
            MessageBox.Show(this.Page, "删除成功!");
        }
        else
        {
            MessageBox.Show(this.Page, "删除失败!");
        }
    }
    protected void grvPatrolPlan_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string planid = grvPatrolPlan.DataKeys[e.RowIndex].Values["planid"].ToString();
        string newCount = ((DropDownList)grvPatrolPlan.Rows[e.RowIndex].FindControl("dropPatrolCount")).SelectedValue;
        string oldCount = ((TextBox)grvPatrolPlan.Rows[e.RowIndex].FindControl("hdTrukunum")).Text;
        if (!planbll.ModifyPatrolPlanById(planid, newCount, oldCount))
        {
            MessageBox.Show(this, "更新失败");
        }
        grvPatrolPlan.EditIndex = -1;
        datasource = planbll.GetPatrolPlanList();
        BindgrvPatrol();
    }
    protected void grvPatrolPlan_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string planstate = grvPatrolPlan.DataKeys[e.NewEditIndex].Values["state"].ToString();
        if (planstate == "2")
        {
            MessageBox.Show(this.Page, "计划已完成，无法更改!");
            return;
        }
        datasource = planbll.GetPatrolPlanList();
        grvPatrolPlan.EditIndex = e.NewEditIndex;
        BindgrvPatrol();
        DropDownList dropPatrolCount = (DropDownList)grvPatrolPlan.Rows[e.NewEditIndex].FindControl("dropPatrolCount");
        string PatrolCount = ((TextBox)grvPatrolPlan.Rows[e.NewEditIndex].FindControl("hdTrukunum")).Text;
        int finishcount = int.Parse(grvPatrolPlan.DataKeys[e.NewEditIndex].Values["finishcount"].ToString());
        for (int i = (finishcount == 0 ? 1 : finishcount); i < 9; i++)
        {
            dropPatrolCount.Items.Add(i.ToString());
        }
        dropPatrolCount.SelectedValue = PatrolCount;
    }
    protected void grvPatrolPlan_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "detail")
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string planid = grvPatrolPlan.DataKeys[index].Values["planid"].ToString();
            flag = planid;
            routeinfodt = infobll.GetPlanInfoList(planid);
            BindHelper.BindGridview(grvrouteinfo, routeinfodt);
            Panel1.Visible = true;
            grvPatrolPlan.Rows[index].BackColor = System.Drawing.Color.FromName("#0090E9");
            if (colorindex != index && colorindex != -1)
            {
                grvPatrolPlan.Rows[colorindex].BackColor = System.Drawing.Color.FromName("#DBEEFD");
            }

        }
    }
    #endregion
    #region 督巡计划详细GRV事件
    protected void grvrouteinfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString().ToString();//PlanInfoID
        if (e.CommandName == "Pictu")
        {
            datasource = new Picture().GetPicByPlanInfoID(id);
            if (datasource.Rows.Count <= 0)
            {
                Pic.Visible = false;
                MessageBox.Show(Page, "暂无图片");
            }
            else
            {
                Pic.Visible = true;
                Repeater1.DataSource = datasource;
                Repeater1.DataBind();
            }
        }
    }
    protected void grvrouteinfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grvrouteinfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvrouteinfo.PageIndex = e.NewPageIndex;
        BindHelper.BindGridview(grvrouteinfo, routeinfodt);
    }
    #endregion
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            string pic = e.CommandArgument.ToString();//获取Picture表中的Photo属性值
            string planinfoid = new Picture().GetPlanInfoIDByPic(pic);
            new Picture().Delete(pic);
            datasource = new Picture().GetPicByPlanInfoID(planinfoid);
            if (datasource.Rows.Count <= 0)
            {
                Pic.Visible = false;
            }
            else
            {
                Pic.Visible = true;
                string filename = Server.MapPath(pic);
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                Repeater1.DataSource = datasource;
                Repeater1.DataBind();
            }
        }

    }
    //督巡计划详细中状态转化方法
    protected string ReturnString(string state)
    {
        if (state == "0")
        {
            return "等待巡检";
        }
        else if (state == "1")
        {
            return "巡检中";
        }
        else
            return "完成";
    }
    protected void btnselect_Click(object sender, EventArgs e)
    {
        List<string> list = new List<string>();
        list.Add(dropStaff.SelectedValue);
        list.Add(droprouteType.SelectedValue);
        list.Add(dropRouteName.SelectedValue);
        list.Add(dropMonth.SelectedValue);
        DataTable dt = infobll.GetListByList(list);
        if (dt.Rows.Count > 0)
        {
            datasource = dt;
        }
        else
            datasource = null;
        BindHelper.BindGridview(grvPatrolPlan, datasource);
    }
    protected void grvPatrolPlan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvPatrolPlan.PageIndex = e.NewPageIndex;
        BindgrvPatrol();
    }
}

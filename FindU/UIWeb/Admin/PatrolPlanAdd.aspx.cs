
using System;
using BLL;
using System.Web.UI.WebControls;
using Common;
using System.Collections.Generic;
using System.Data;

public partial class Admin_PatrolPlanAdd : System.Web.UI.Page
{
    private static DataTable dtdetail = new DataTable();
    private static DataColumn PlanDate = new DataColumn("PlanDate", typeof(string));
    Staff staffbll = new Staff();
    Plan planbll = new Plan();
    Route routebll = new Route();
    RouteType routeTypebll = new RouteType();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindHelper.BindDropDownList(droproutetype, routeTypebll.GetRouteList(), "RouteTypeName", "ID");
            BindHelper.BindDropDownList(dropstaff, staffbll.SelectStaffList(), "staffname", "staffid");
            dropstaff.Items.Insert(0, new ListItem("--请选择--", ""));
            BindYear();
            BindMonth();
            BindeGRV("");
            BindRoute();
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
    #region  绑定路线
    protected void BindRoute()
    {
        int routetypeid;
        int.TryParse(droproutetype.SelectedValue.ToString(), out routetypeid);
        BindHelper.BindDropDownList(droproute, routebll.GetRouteByTypeID(routetypeid), "routename", "routeid");
    }
    #endregion
    #region 保存
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (!IsValid)
            return;
        if (dropstaff.SelectedIndex <= 0)
        {
            MessageBox.Show(this.Page, "请选择巡检员");
            return;
        }
        if (dtdetail.Rows.Count <= 0)
        {
            MessageBox.Show(this.Page, "请添加至少一次巡检");
            return;
        }
        string routeTypeid = droproutetype.SelectedValue;
        string routeid = droproute.SelectedValue;
        string description = txtdescription.Text;
        string staff = dropstaff.SelectedValue;
        string year = dropYear.SelectedValue;
        string month = dropMonth.SelectedValue;

        int count = dtdetail.Rows.Count; List<string> list = new List<string>();
        for (int i = 0; i < count; i++)
        {
            string plandate = ((TextBox)grvrouteinfo.Rows[i].FindControl("txtplandate")).Text;
            list.Add(plandate);
        }
        if (planbll.AddPatrolPlan(routeid, description, staff, year, month, count, list))
        {
            MessageBox.Show(this.Page, "添加成功");
            Response.AddHeader("Refresh", "0");//刷新
            return;
        }
        MessageBox.Show(this.Page, "添加失败");

    }
    #endregion
    #region 路线类型触发事件
    protected void droproutetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindRoute();
    }
    #endregion
    #region 绑定GRV
    protected void BindeGRV(string staffname)
    {
        string thisyear = DateTime.Now.Year.ToString();
        string thismonth = DateTime.Now.Month.ToString();
        if (staffname == "")
        {
            BindHelper.BindGridview(Gridview1, planbll.GetMonthPlan(thisyear, thismonth));
        }
        else
        {
            BindHelper.BindGridview(Gridview1, planbll.GetMonthPlanByName(thisyear, thismonth, staffname));
        }
    }
    #endregion
    private void Readgrvrouteinfo()
    {
        dtdetail.Rows.Clear();
        dtdetail.Columns.Clear();
        dtdetail.Columns.Add(PlanDate);
        for (int i = 0; i < grvrouteinfo.Rows.Count; i++)
        {
            DataRow dr = dtdetail.NewRow();
            string date = ((TextBox)grvrouteinfo.Rows[i].FindControl("txtplandate")).Text;
            dr["PlanDate"] = date;
            dtdetail.Rows.Add(dr);
        }
    }
    protected void grvrouteinfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtdetail.Rows.RemoveAt(e.RowIndex);
        BindHelper.BindGridview(grvrouteinfo, dtdetail);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Readgrvrouteinfo();
        DataRow row = dtdetail.NewRow();
        dtdetail.Rows.Add(row);
        BindHelper.BindGridview(grvrouteinfo, dtdetail);
    }
    protected void dropstaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropstaff.SelectedIndex == 0)
            BindeGRV("");
        else
        {
            string staffname = dropstaff.SelectedItem.Text;
            BindeGRV(staffname);
        }
    }
}

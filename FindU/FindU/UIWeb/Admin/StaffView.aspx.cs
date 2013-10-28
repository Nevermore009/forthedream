using System;
using System.Data;
using BLL;
using System.Web.UI.WebControls;
using Common;

public partial class Admin_StaffView : System.Web.UI.Page
{
    static DataTable datasource = new DataTable();
    Staff staffbll = new Staff();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            datasource = staffbll.GetStaffList();
            BindHelper.BindGridview(grvstaff, datasource);
        }
    }

   
    protected void grvstaff_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void grvstaff_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvstaff.EditIndex = e.NewEditIndex;
        BindHelper.BindGridview(grvstaff, datasource);
    }
    protected void grvstaff_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string staffname = ((TextBox)grvstaff.Rows[e.RowIndex].FindControl("txtstaffname")).Text;
        string staffid = grvstaff.DataKeys[e.RowIndex].Values["staffid"].ToString();
        BLL.Staff bstaff = new Staff();
        bstaff.EditStaffName(staffname, int.Parse(staffid));
        grvstaff.EditIndex = -1;
        datasource = new Staff().GetStaffList();
        BindHelper.BindGridview(grvstaff, datasource);
    }
    protected void grvstaff_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != -1)
        {
            if (string.IsNullOrEmpty(datasource.Rows[e.Row.RowIndex]["planid"].ToString()))
            {
                ((Label)e.Row.FindControl("lbstate")).Text = "空闲中";
            }
            else
            {
                ((Label)e.Row.FindControl("lbstate")).Text = "正在执行计划[" + datasource.Rows[e.Row.RowIndex]["planname"].ToString() + "]";
            }
        }
    }
    protected void grvstaff_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvstaff.EditIndex = -1;
        BindHelper.BindGridview(grvstaff, datasource);
    }
}

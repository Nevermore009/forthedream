using System;
using BLL;
using Common;

public partial class Admin_RoutePlanAdd : System.Web.UI.Page
{
    Plan planbll = new Plan();
    Staff staffbll = new Staff();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtplanname.Focus();
            BindHelper.BindDropDownList(dropstaff, staffbll.SelectStaffList(), "staffname", "staffid");
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string planname = txtplanname.Text;
        string description = txtdescription.Text;
        string staffid = dropstaff.SelectedValue;
        if (planbll.AddCollectPlan(planname, description, staffid))
        {
            MessageBox.Show(this.Page, "添加成功");
        }
        else
        {
            MessageBox.Show(this.Page, "添加失败");
        }
    }
}

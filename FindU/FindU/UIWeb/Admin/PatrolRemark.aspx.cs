using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Common;

public partial class Admin_PatrolRemark : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["id"] != null)
            {
                lbid.Text = Request["id"];
                txtremark.Text = (new Patrol()).GetPatrolByID(Request["id"]).Rows[0]["remark"].ToString();
            }
        }
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        if (btnsubmit.Enabled == false)
        {
            txtremark.Enabled = true;
            btnsubmit.Enabled = true;
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(lbid.Text))
        {
            string remark = txtremark.Text.ToString();
            string id = lbid.Text;
            BLL.Patrol rbll = new BLL.Patrol();
            if (!rbll.ModifyPatrolByID(id, remark))
            {
                MessageBox.Show(this.Page, "更新失败!");
                return;
            }
            else
            {
                txtremark.Enabled = false;
                btnsubmit.Enabled = false;
            }
        }
    }
}
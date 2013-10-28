using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMCShine.Data.Entities;
using SMCShine.Common;
using SMCShine.Logic;

public partial class Module_SchoolManager_AddSchool : BasePage
{
    private CampusManager campusLogic = new CampusManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["guid"] != null)
            {
                string guid = Request.QueryString["guid"].ToString();
                InitCampus(guid);
            }
            else
            {
                panelDetail.Enabled = true;
                txtCampusName.Focus();
            }
        }
    }
    protected void InitCampus(string guid)
    {
        Guid g = new Guid(guid);
        Campus entity = campusLogic.GetCampusById(g);
        txtCampusCode.Text = entity.CampusCode;
        txtCampusMemo.Text = entity.Memo;
        txtCampusName.Text = entity.Name;
        lbcampusID.Text = guid;
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string message = string.Empty;       
        if (lbcampusID.Text == "")
        {
            Campus campus = new Campus();
            campus.Name = txtCampusName.Text.Trim();
            campus.Memo = txtCampusMemo.Text;
            campus.CampusCode = txtCampusCode.Text.Trim();
            campusLogic.AddCampus(campus, out message);
        }
        else
        {
            Campus entity = campusLogic.GetCampusById(new Guid(lbcampusID.Text));
            entity.Name = txtCampusName.Text.Trim();
            entity.Memo = txtCampusMemo.Text;
            entity.CampusCode = txtCampusCode.Text.Trim();
            campusLogic.UpdateCampus(entity, out message);
        }
        MessageBox.Show(this, message);
        Response.AddHeader("refresh", "0");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        panelDetail.Enabled = true;
        txtCampusName.Text = "";
        txtCampusMemo.Text = "";
        txtCampusCode.Text = "";
        lbcampusID.Text = "";
        txtCampusName.Focus();
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        panelDetail.Enabled = true;
    }
}

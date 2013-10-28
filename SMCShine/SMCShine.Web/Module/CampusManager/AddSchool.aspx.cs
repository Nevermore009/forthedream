using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMCShine.Logic;
using SMCShine.Data.Entities;
using SMCShine.Common;

public partial class Module_SchoolManager_AddSchool : BasePage
{
    private CampusManager campusLogic = new CampusManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitDropSchool();
            if (Request.QueryString["guid"] != null)
            {
                InitSchool(Request.QueryString["guid"].ToString());
            }
            else
            {
                panelDetail.Enabled = true;
                txtSchoolName.Focus();
            }
        }
    }
    protected void InitSchool(string guid)
    {
        Guid g = new Guid(guid);
        School entity = campusLogic.GetSchoolById(g);
        dropCampus.SelectedValue = entity.CampusGuid.ToString() ;
        txtSchoolMemo.Text = entity.Memo;
        txtSchoolName.Text = entity.Name;
        lbschoolID.Text = guid;
    }
    protected void InitDropSchool()
    {
        BindHelper.BindDropDownList(dropCampus, campusLogic.GetCampusByUser(Campus), "Name", "Guid");
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            string message = string.Empty;
            if (lbschoolID.Text == "")
            {
                School entity = new School();
                entity.Name = txtSchoolName.Text.Trim();
                entity.Memo = txtSchoolMemo.Text;
                entity.CampusGuid = new Guid(dropCampus.SelectedValue);
                campusLogic.AddSchool(entity, out message);
            }
            else
            {
                Guid g = new Guid(lbschoolID.Text);
                School entity = campusLogic.GetSchoolById(g);
                entity.Name = txtSchoolName.Text.Trim();
                entity.Memo = txtSchoolMemo.Text;
                entity.CampusGuid = new Guid(dropCampus.SelectedValue);
                campusLogic.UpdateSchool(entity, out message);
            }
            MessageBox.Show(this, message);
            Response.AddHeader("refresh", "0");
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        panelDetail.Enabled = true;
        txtSchoolName.Text = "";
        txtSchoolMemo.Text = "";
        txtSchoolName.Focus();
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        panelDetail.Enabled = true;
    }
}
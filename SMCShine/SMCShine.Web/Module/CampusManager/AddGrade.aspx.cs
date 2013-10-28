using System;
using SMCShine.Common;
using SMCShine.Logic;
using SMCShine.Data.Entities;

public partial class Module_CampusManager_AddGrade : BasePage
{
    private CampusManager campusLogic = new CampusManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitDropSchool();
            if (Request.QueryString["guid"] != null)
            {
                InitGrade(Request.QueryString["guid"].ToString());
            }
            else
            {
                panelDetail.Enabled = true;
            }
        }
    }

    protected void InitGrade(string guid)
    {
        Guid g = new Guid(guid);
        Grade entity = campusLogic.GetGradeById(g);
        School school = campusLogic.GetSchoolById(entity.SchoolGuid);
        dropCampus.SelectedValue = school.CampusGuid.ToString();
        dropCampus_SelectedIndexChanged(null, null);
        dropSchool.SelectedValue = school.Guid.ToString();
        txtGradeMemo.Text = entity.Memo;
        txtGradeName.Text = entity.Name;
        lbGradeID.Text = guid;
    }

    protected void InitDropSchool()
    {
        BindHelper.BindDropDownList(dropCampus, campusLogic.GetCampusByUser( Campus), "Name", "Guid", "--请选择--");
    }

    protected void dropCampus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropCampus.SelectedIndex > 0)
        {
            Guid g = new Guid(dropCampus.SelectedValue);
            BindHelper.BindDropDownList(dropSchool, campusLogic.GetSchoolByCampus(g), "name", "guid");
        }
        else
        {
            dropSchool.Items.Clear();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        panelDetail.Enabled = true;
        txtGradeName.Text = "";
        txtGradeMemo.Text = "";
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            string message = string.Empty;
            if (lbGradeID.Text == "")
            {
                Grade grade = new Grade();
                grade.Name = txtGradeName.Text.Trim();
                grade.Memo = txtGradeMemo.Text;
                grade.SchoolGuid = new Guid(dropSchool.SelectedValue);
                campusLogic.AddGrade(grade, out message);
            }
            else
            {
                Guid g = new Guid(lbGradeID.Text);
                Grade entity = campusLogic.GetGradeById(g);
                entity.Name = txtGradeName.Text.Trim();
                entity.Memo = txtGradeMemo.Text;
                entity.SchoolGuid = new Guid(dropSchool.SelectedValue);
                campusLogic.UpdateGrade(entity, out message);
            }
            MessageBox.Show(this, message);
            Response.AddHeader("refresh", "0");
        }
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        panelDetail.Enabled = true;
    }
}
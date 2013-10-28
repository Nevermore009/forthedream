using System;
using System.Collections.Generic;
using SMCShine.Common;
using SMCShine.Logic;
using SMCShine.Data.Entities;

public partial class Module_CampusManager_AddProfession : BasePage
{
    private CampusManager campusLogic = new CampusManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitDropCampus();
            if (Request.QueryString["guid"] != null)
            {
                InitProfession(Request.QueryString["guid"].ToString());
            }
            else
            {
                panelDetail.Enabled = true;
            }
        }
    }

    protected void InitProfession(string guid)
    {
        Guid g = new Guid(guid);
        ClassType entity = campusLogic.GetClassById(g);
        txtClassName.Text = entity.Name;
        txtClassMemo.Text = entity.Memo;
        Grade grade = campusLogic.GetGradeById(entity.GradeGuid);
        School school = campusLogic.GetSchoolById(grade.SchoolGuid);
        dropCampus.SelectedValue = school.CampusGuid.ToString();
        dropCampus_SelectedIndexChanged(null, null);
        dropSchool.SelectedValue = grade.SchoolGuid.ToString() ;
        dropSchool_SelectedIndexChanged(null, null);
        dropGrade.SelectedValue = entity.GradeGuid.ToString();
        dropClassification.SelectedValue = entity.Guid.ToString();
        lbclassID.Text = guid;
    }

    protected void InitDropCampus()
    {
        BindHelper.BindDropDownList(dropCampus, campusLogic.GetCampusByUser(Campus), "Name", "Guid", "--请选择--");
    }

    protected void dropCampus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropCampus.SelectedIndex > 0)
        {
            Guid g = new Guid(dropCampus.SelectedValue);
            BindHelper.BindDropDownList(dropSchool, campusLogic.GetSchoolByCampus(g), "name", "guid", "--请选择--");
        }
        else
        {
            dropSchool.Items.Clear();
        }
        dropGrade.Items.Clear();
    }
    protected void dropSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropSchool.SelectedIndex > 0)
        {
            Guid g = new Guid(dropSchool.SelectedValue);
            BindHelper.BindDropDownList(dropGrade, campusLogic.GetGradeBySchool(g), "name", "guid", "--请选择--");
        }
        else
        {
            dropGrade.Items.Clear();
        }
    }


    public string GenerateClassID(int existedNum)
    {
        string classId = null;
        if (existedNum == 0)
            classId = "001";
        else if (existedNum > 0 && existedNum < 10)
            classId = "00" + (existedNum + 1).ToString();
        else if (existedNum >= 10 && existedNum < 100)
            classId = "0" + (existedNum + 1).ToString();
        else
            classId = (existedNum + 1).ToString();
        return classId;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        panelDetail.Enabled = true;
        txtClassMemo.Text = "";
        txtClassName.Text = "";
        lbclassID.Text = "";
        dropCampus.SelectedIndex = 0;
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        panelDetail.Enabled = true;
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {        
        string message = string.Empty;
        if (lbclassID.Text == "")
        {
            ClassType classType = new ClassType();
            classType.Name = txtClassName.Text.Trim();
            classType.Memo = txtClassMemo.Text;
            classType.GradeGuid = new Guid(dropGrade.SelectedValue);
            classType.Classification = dropClassification.SelectedValue;
            List<ClassType> classTypeList = campusLogic.GetAllClass();
            classType.ClassID = GenerateClassID(classTypeList.Count);
            campusLogic.AddClass(classType, out message);
        }
        else
        {
            ClassType entity = campusLogic.GetClassById(new Guid(lbclassID.Text));
            entity.Name = txtClassName.Text.Trim();
            entity.Memo = txtClassMemo.Text;
            entity.GradeGuid = new Guid(dropGrade.SelectedValue);
            entity.Classification = dropClassification.SelectedValue;
            List<ClassType> classTypeList = campusLogic.GetAllClass();
            entity.ClassID = GenerateClassID(classTypeList.Count);
            campusLogic.UpdateClass(entity, out message);
        }
        MessageBox.Show(this, message);
        Response.AddHeader("refresh", "0");
    }
}
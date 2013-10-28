using System;
using SMCShine.Data.Entities;
using SMCShine.Logic;
using SMCShine.Common;

public partial class Module_StudentManager_AddStudent : BasePage
{
    private CampusManager campusManager = new CampusManager();
    private StudentManager studentManager = new StudentManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["charge"] != null)
            {
                InitFromChargePage();
            }
            else
            {
                InitCampus();
            }
        }
    }

    protected void InitFromChargePage()
    { 
       
    }
    protected void InitCampus()
    {
        BindHelper.BindDropDownList(dropcampus, campusManager.GetCampusByUser(Campus), "Name", "Guid", "--请选择--");
    }

    protected void dropcampus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropcampus.SelectedIndex > 0)
        {
            Guid g = new Guid(dropcampus.SelectedValue);
            BindHelper.BindDropDownList(dropschool, campusManager.GetSchoolByCampus(g), "Name", "Guid", "--请选择--");
        }
        else
        {
            dropschool.Items.Clear();
        }
        dropgrade.Items.Clear();
        dropclass.Items.Clear();
    }


    protected void dropschool_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropschool.SelectedIndex > 0)
        {
            Guid g = new Guid(dropschool.SelectedValue);
            BindHelper.BindDropDownList(dropgrade, campusManager.GetGradeBySchool(g), "Name", "Guid", "--请选择--");
        }
        else
        {
            dropgrade.Items.Clear();
        }
        dropclass.Items.Clear();
    }


    protected void dropgrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropgrade.SelectedIndex > 0)
        {
            BindHelper.BindDropDownList(dropclass, campusManager.GetClassByGrade(dropgrade.SelectedValue), "Name", "Guid", "--请选择--");
        }
        else
        {
            dropclass.Items.Clear();
        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Student student = new Student();
            student.ID = txtid.Text;
            student.Name = txtname.Text;
            student.Mobile = txtmobile.Text;
            student.Gender = (dropgender.SelectedValue == "1");
            student.Email = txtemail.Text;
            student.CampusGuid = new Guid(dropcampus.SelectedValue);
            student.SchoolGuid = new Guid(dropschool.SelectedValue);
            student.GradeGuid = new Guid(dropgrade.SelectedValue);
            student.ClassTypeGuid = new Guid(dropclass.SelectedValue);
            student.Tel = txttel.Text;
            student.Address = txtaddress.Text;

            if (studentManager.Add(student))
            {
                MessageBox.Show(this.Page, "添加成功");
                Response.AddHeader("refresh", "0");//刷新
            }
            else
            {
                MessageBox.Show(this.Page, "添加失败");
            }
        }

    }
}

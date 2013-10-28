using System;
using SMCShine.Logic;
using SMCShine.Common;
using SMCShine.Data.Entities;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Module_StudentManager_StudentManage : BasePage
{
    private CampusManager campusLogic = new CampusManager();
    StudentManager studentmanager = new StudentManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitgrvStudent();
            InitDropCampus();
        }
    }
    protected void InitgrvStudent()
    {
        BindHelper.BindGridview(grvstudent, studentmanager.GetStudentsByUser(Campus));
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
        dropClass.Items.Clear();
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
        dropClass.Items.Clear();
    }

    protected void dropGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropSchool.SelectedIndex > 0)
        {
            BindHelper.BindDropDownList(dropClass, campusLogic.GetClassByGrade(dropGrade.SelectedValue), "name", "guid", "--请选择--");
        }
        else
        {
            dropGrade.Items.Clear();
        }
    }

    protected void grvstudent_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "detail" || e.CommandName == "modify")
        {
            GridViewRow row = ((e.CommandSource as LinkButton).Parent.Parent) as GridViewRow;
            string studentGuid = grvstudent.DataKeys[row.RowIndex].Values["guid"].ToString();
            Guid g = new Guid(studentGuid);
            Student stu = studentmanager.GetStudentById(g);
            lbguid.Text = g.ToString();
            txtstudentid.Text = stu.StudentID;
            txtname.Text = stu.Name;
            dropgender.SelectedValue = stu.Gender ? "1" : "0";
            txtmobile.Text = stu.Mobile;
            txttel.Text = stu.Tel;
            txtemail.Text = stu.Email;
            dropCampus.SelectedValue = stu.CampusGuid.ToString();
            dropCampus_SelectedIndexChanged(null, null);
            dropSchool.SelectedValue = stu.SchoolGuid.ToString();
            dropSchool_SelectedIndexChanged(null, null);
            dropGrade.SelectedValue = stu.GradeGuid.ToString();
            dropGrade_SelectedIndexChanged(null, null);
            dropClass.SelectedValue = stu.ClassTypeGuid.ToString();
            txtid.Text = stu.ID;
            txtaddress.Text = stu.Address;
            if (stu == null)
            {
                lbalert.Text = "没有找到该学生的信息";
                return;
            }
            if (e.CommandName == "modify")
            {
                groupedit.Enabled = true;
                btnedit.Enabled = false;
                btnsave.Enabled = true ;
            }
            else
            {
                btnsave.Enabled = false;
                groupedit.Enabled = false;
                btnedit.Enabled = true;
            }
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            if (lbguid.Text.Trim() == "")
                return;
            Guid g = new Guid(lbguid.Text);
            Student stu = studentmanager.GetStudentById(g);
            stu.Name = txtname.Text;
            stu.Gender = dropgender.SelectedValue=="1";
            stu.Mobile = txtmobile.Text;
            stu.Tel = txttel.Text;
            stu.Email = txtemail.Text;
            stu.Address = txtaddress.Text;
            stu.GradeGuid = new Guid(dropGrade.SelectedValue);
            stu.ClassTypeGuid = new Guid(dropClass.SelectedValue);
            if (studentmanager.Update(stu))
            {
                MessageBox.Show(this.Page, "保存成功");
                Response.AddHeader("refresh", "0");
            }
            else
                MessageBox.Show(this.Page, "保存失败");
        }
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        btnedit.Enabled = false;
        btnsave.Enabled = true;
        groupedit.Enabled = true;
    }

    protected void grvstudent_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        grvstudent.PageIndex = e.NewPageIndex;
        InitgrvStudent();
    }
}

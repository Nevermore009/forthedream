using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMCShine.Common;
using SMCShine.Logic;

public partial class Controls_Campus : System.Web.UI.UserControl
{
    private CampusManager campusManager = new CampusManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    /// <summary>
    /// 初始化下拉列表
    /// </summary>
    /// <param name="CampusGuid"></param>
    public void Init(string CampusGuid)
    {
        if (string.IsNullOrEmpty(CampusGuid))
            return;
        else
        {
            BindHelper.BindDropDownList(dropcampus, campusManager.GetCampusByUser(CampusGuid), "Name", "Guid", "--全部--");
            if (CampusGuid != Guid.Empty.ToString())
            {
                campusfield.Visible = false;
                if (dropcampus.Items.Count >= 2)
                {
                    dropcampus.SelectedIndex = 1;
                    dropcampus_SelectedIndexChanged(null, null);
                }
            }
        }
    }

    protected void dropcampus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropcampus.SelectedIndex > 0)
        {
            Guid g = new Guid(dropcampus.SelectedValue);
            BindHelper.BindDropDownList(dropschool, campusManager.GetSchoolByCampus(g), "Name", "Guid", "--全部--");
        }
        else
        { 
            dropschool.Items.Clear();
        }
        dropgrade.Items.Clear();
        dropprofession.Items.Clear();
    }


    protected void dropschool_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropschool.SelectedIndex > 0)
        {
            Guid g = new Guid(dropschool.SelectedValue);
            BindHelper.BindDropDownList(dropgrade, campusManager.GetGradeBySchool(g), "Name", "Guid", "--全部--");
        }
        else
        {
            dropgrade.Items.Clear();
        }
        dropprofession.Items.Clear();
    }


    protected void dropgrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropgrade.SelectedIndex > 0)
        {
            BindHelper.BindDropDownList(dropprofession, campusManager.GetClassByGrade(dropgrade.SelectedValue), "Name", "Guid", "--全部--");
        }
        else
        {
            dropprofession.Items.Clear();
        }
    }

    public DropDownList DropDownListCampus
    {
        set { dropcampus = value; }
        get { return dropcampus; }
    }
    public DropDownList DropDownListSchool
    {
        set { dropschool = value; }
        get { return dropschool; }
    }
    public DropDownList DropDownListGrade
    {
        set { dropgrade = value; }
        get { return dropgrade; }
    }
    public DropDownList DropDownListProfession
    {
        set { dropprofession = value; }
        get { return dropprofession; }
    }

}
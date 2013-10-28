using System;
using SMCShine.Common;
using SMCShine.Logic;

public partial class Module_CampusManager_CampusTableManage : BasePage
{
    private CampusManager campusManager = new CampusManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitgrvCampus();
            InitgrvSchool();
            InitgrvGrade();
            InitgrvClassType();
        }
    }
    protected void InitgrvCampus()
    {
        BindHelper.BindGridview(grvcampus, campusManager.GetCampusByUser(Campus));
    }

    protected void InitgrvSchool()
    {
        BindHelper.BindGridview(grvschool, campusManager.GetSchoolInfo());
    }

    protected void InitgrvGrade()
    {
        BindHelper.BindGridview(grvgrade, campusManager.GetGradesInfo());
    }

    protected void InitgrvClassType()
    {
        BindHelper.BindGridview(grvclass, campusManager.GetClassInfo());
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {

    }
}

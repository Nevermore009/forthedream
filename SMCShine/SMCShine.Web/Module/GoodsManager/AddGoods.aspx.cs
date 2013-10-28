using System;
using System.Collections.Generic;
using SMCShine.Logic;
using SMCShine.Common;
using SMCShine.Logic.Module.GoodsManager;
using SMCShine.Data.Entities;

public partial class Module_GoodsManager_AddGoods : BasePage
{
    private CampusManager campusManager = new CampusManager();
    private GoodsManager goodsManager = new GoodsManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitCampus();
        }
    }
    protected void InitCampus()
    {
        List<Campus> campusList = campusManager.GetCampusByUser(Campus);
        BindHelper.BindDropDownList(dropcampus, campusList, "Name", "Guid", "--请选择--");
        BindHelper.BindDropDownList(ddlCampus, campusList, "Name", "Guid");
    }

    protected void InitSchool(string campusGuid)
    {
        Guid g = new Guid(campusGuid);
        List<School> campusList = campusManager.GetSchoolByCampus(g);
        BindHelper.BindDropDownList(dropschool, campusList, "Name", "Guid", "--请选择--");
    }
    protected void InitGrade(string schoolGuid)
    {
        Guid g = new Guid(schoolGuid);
        List<Grade> gradeList = campusManager.GetGradeBySchool(g);
        BindHelper.BindDropDownList(dropgrade, gradeList, "Name", "Guid", "--请选择--");
    }
    protected void InitProfession(string gradeGuid)
    {
        List<ClassType> professionList = campusManager.GetClassByGrade(gradeGuid);
        BindHelper.BindDropDownList(dropprofession, professionList, "Name", "Guid", "--选择--");
    }

    protected void InitGoodType(string campusGuid)
    {
        Guid g = new Guid(campusGuid);
        BindHelper.BindDropDownList(ddlGoodsType, goodsManager.GetGoodsTypeByCampus(g), "Name", "Guid", "--请选择--");
    }


    protected void dropcampus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropcampus.SelectedIndex > 0)
        {
            InitGoodType(dropcampus.SelectedValue);
            InitSchool(dropcampus.SelectedValue);
        }
        else
        {
            dropschool.Items.Clear();
            dropgrade.Items.Clear();
            dropprofession.Items.Clear();
        }
    }

    protected void dropschool_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropschool.SelectedIndex > 0)
        {
            InitGrade(dropschool.SelectedValue);
        }
        else
        {
            dropgrade.Items.Clear();
            dropprofession.Items.Clear();
        }
    }
    protected void dropgrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropgrade.SelectedIndex > 0)
        {
            InitProfession(dropgrade.SelectedValue);
        }
        else
        {
            dropprofession.Items.Clear();
        }
    }

    protected void btnAddGoodsType_Click(object sender, EventArgs e)
    {
        GoodsType entity = new GoodsType();
        entity.CampusGuid = new Guid(ddlCampus.SelectedValue);
        entity.Name = txtGoodsTypeName.Text;
        entity.Memo = txtGoodsTypeMemo.Text;
        if (goodsManager.AddGoodsType(entity))
        {
            MessageBox.Show(this.Page, "添加成功");
            Response.AddHeader("refresh", "0");
        }
        else
            MessageBox.Show(this.Page, "添加失败");
    }
    protected void btnAddGoodsItem_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            GoodsItem entity = new GoodsItem();
            entity.GoodsTypeGuid = new Guid(ddlGoodsType.SelectedValue);
            entity.CampusGuid = new Guid(dropcampus.SelectedValue);
            entity.SchoolGuid = new Guid(dropschool.SelectedValue);
            entity.GradeGuid = new Guid(dropgrade.SelectedValue);
            entity.ClassGuid = new Guid(dropprofession.SelectedValue);
            entity.Name = txtGoodsItem.Text;
            entity.Memo = txtGoodsItemMemo.Text;
            entity.Price = Convert.ToDecimal(txtprice.Text);
            if (goodsManager.AddGoodsItem(entity))
            {
                MessageBox.Show(this.Page, "添加成功");
                Response.AddHeader("refresh", "0");
            }
            else
            {
                MessageBox.Show(this.Page, "添加失败");
            }
        }
    }

}

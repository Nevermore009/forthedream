using System;
using SMCShine.Data.Entities;
using SMCShine.Logic;
using SMCShine.Common;
using System.Collections.Generic;
using System.Web.UI;
using System.Web;

public partial class Module_ChargeManager_ChargeManage : BasePage
{
    private ChargeManager chargeManager = new ChargeManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindChargeInfo(null);
            mycampus.Init(Campus);
        }
    }

    protected void BindChargeInfo(ChargeInfoCondition entity)
    {
        List<ChargeInfo> chargeList;
        if (entity == null)
        {
            chargeList = chargeManager.GetAllChargeInfoByUser(Campus);
        }
        else
        {
            chargeList = chargeManager.GetChargeInfoByCondition(entity);
        }
        lbrecordcount.Text = chargeList.Count.ToString();
        decimal account = 0;
        foreach (ChargeInfo c in chargeList)
        {
            account += c.PaidMoney;
        }
        lbaccountsum.Text = account.ToString();
        BindHelper.BindGridview(grvChargeList, chargeList);
    }


    protected void btnsearch_Click(object sender, EventArgs e)
    {
        ChargeInfoCondition toFind = new ChargeInfoCondition();
        toFind.ChargeInfoEntity.ID = txtID.Text.Trim();
        toFind.ChargeInfoEntity.StudentName = txtstudent.Text.Trim();
        toFind.ChargeInfoEntity.BillNumber = txtBillID.Text.Trim();
        toFind.StartDate = txtstarttime.Text.Trim();
        toFind.EndDate = txtendtime.Text.Trim();
        if (mycampus.DropDownListCampus.SelectedIndex > 0)
            toFind.ChargeInfoEntity.CampusGuid = new Guid(mycampus.DropDownListCampus.SelectedValue);
        if (mycampus.DropDownListSchool.SelectedIndex > 0)
            toFind.ChargeInfoEntity.SchoolGuid = new Guid(mycampus.DropDownListSchool.SelectedValue);
        if (mycampus.DropDownListGrade.SelectedIndex > 0)
            toFind.ChargeInfoEntity.GradeGuid = new Guid(mycampus.DropDownListGrade.SelectedValue);
        if (mycampus.DropDownListProfession.SelectedIndex > 0)
            toFind.ChargeInfoEntity.ClassGuid = new Guid(mycampus.DropDownListProfession.SelectedValue);
        BindChargeInfo(toFind);
    }
    protected void grvChargeList_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        grvChargeList.PageIndex = e.NewPageIndex;
        btnsearch_Click(null, null);
    }
    protected void btntoexcel_Click(object sender, EventArgs e)
    {
        grvChargeList.AllowPaging = false;
        btnsearch_Click(null, null);
        if (grvChargeList.Rows.Count <= 0)
        {
            Response.Clear();
            MessageBox.Show(this.Page, "没有符合条件的数据,请重新选择查询条件!");
            return;
        }
        string filename = HttpUtility.UrlEncode("缴费记录.xls", System.Text.Encoding.UTF8);
        Response.AddHeader("content-disposition", "attachment;filename=" + filename);
        Response.Charset = "gb2312";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
        Response.ContentType = "application/ms-excel";
        grvChargeList.Page.EnableViewState = false;
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);       
        grvChargeList.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }
        
}
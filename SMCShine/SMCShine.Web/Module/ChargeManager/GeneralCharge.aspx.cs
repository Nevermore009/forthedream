using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMCShine.Common;
using SMCShine.Data.Entities;
using SMCShine.Logic;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class Module_ChargeManager_GeneralCharge : BasePage
{

    ChargeManager chargeLogic = new ChargeManager();
    UserManager userLogic = new UserManager();
    CampusManager campusLogic = new CampusManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSchool();
            //printViewer.Visible = false;
        }
    }
    protected void BindSchool()
    {
        string userGroupGuid = AES.Decrypt(HttpContext.Current.Request.Cookies["usergroup"].Value);
        string campusGuid = AES.Decrypt(HttpContext.Current.Request.Cookies["campusguid"].Value);
        if (userLogic.GetUserGroupName(new Guid(userGroupGuid)) == "管理员")
        {
            BindHelper.BindDropDownList(ddlSchoolName, chargeLogic.GetAllSchools(), "Name", "Guid", "--请选择--");
        }
        else
        {
            BindHelper.BindDropDownList(ddlSchoolName, chargeLogic.GetSchoolsFromCampus(Campus), "Name", "Guid", "--请选择--");
        }
    }

    protected void ddlGoodsType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHelper.BindDropDownList(ddlGoodsName, chargeLogic.GetGoodsItemWithPrice(new Guid(ddlGoodsType.SelectedItem.Value)), "Name", "Guid", "--请选择--");
    }

    protected void ddlSchoolName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHelper.BindDropDownList(ddlGoodsType, chargeLogic.GetGoodsTypeBySchool(new Guid(ddlSchoolName.SelectedValue)), "Name", "Guid", "--请选择--");
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        Student student = chargeLogic.CheckStudent(new Guid(ddlSchoolName.SelectedItem.Value), txtID.Text.Trim());
        //首先根据学校和身份证号验证学员是否存在
        if (student != null)
        {
            imgCheckFlag.Visible = true;
            imgCheckFlag.ImageUrl = "~/images/icons/ok.gif";
            imgCheckFlag.ToolTip = "存在该学员！";
            lbWarn.Text = "存在该学员！";
            lbWarn.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            imgCheckFlag.Visible = true;
            imgCheckFlag.ImageUrl = "~/images/icons/no.gif";
            imgCheckFlag.ToolTip = "不存在该学员！";
            lbWarn.Text = "不存在该学员！";
            lbWarn.ForeColor = System.Drawing.Color.Red;
        }
        //如果学员存在，则绑定学员信息
        //如果学员不存在，则跳到学员添加页面
    }

    protected void btnAddCharge_Click(object sender, EventArgs e)
    {
        Guid schoolGuid = new Guid(ddlSchoolName.SelectedItem.Value);
        Guid goodsTypeGuid = new Guid(ddlGoodsType.SelectedItem.Value);
        Guid goodsItemGuid = new Guid(ddlGoodsName.SelectedItem.Value);
        GoodsItem goodsItem = chargeLogic.GetGoodsItemByGuid(goodsItemGuid);
        Guid campusGuid = (Guid)goodsItem.CampusGuid;
        //生成单据号：
        string billNumber = chargeLogic.GenerateBillNumber(campusGuid);
        Guid gradeGuid = (Guid)goodsItem.GradeGuid;
        Guid classGuid = (Guid)goodsItem.ClassGuid;
        ChargeNote chargeNote = new ChargeNote();
        ChargeNoteItem chargeItem = new ChargeNoteItem();
        //提交数据
        //Student existedStudent = chargeLogic.CheckStudent(new Guid(ddlSchoolName.SelectedItem.Value), txtID.Text.Trim());
        Student existedStudent = chargeLogic.CheckStudent(classGuid, txtStudentName.Text);
        if (existedStudent == null)
        {
            Student student = new Student();
            student.ID = txtID.Text.Trim();
            student.Name = txtStudent.Text.Trim();
            student.CampusGuid = campusGuid;
            student.SchoolGuid = schoolGuid;
            student.GradeGuid = gradeGuid;
            student.ClassTypeGuid = classGuid;
            StudentManager studentLogic = new StudentManager();
            if (studentLogic.Add(student))
            {
                existedStudent = chargeLogic.GetStudentByName(txtStudent.Text.Trim());
            }
            else
            {
                MessageBox.Show(this, "缴费失败,添加学员失败！");
                return;
            }
        }
        if (existedStudent == null)
        {
            MessageBox.Show(this, "缴费失败,错误码(011)!");
            return;
        }
        chargeNote.BillNumber = billNumber;
        chargeNote.CampusGuid = campusGuid;
        chargeNote.UserAccount = UserAccout;
        chargeNote.StudentGuid = existedStudent.Guid;
        chargeNote.Memo = txtMeno.Text;
        chargeNote.ChargeWay = int.Parse(ddlChargeWay.SelectedValue);
        if (ddlChargeWay.SelectedValue == "1")
            chargeNote.PosNumber = txtPosNumber.Text.Trim();
        chargeItem.CampusGuid = campusGuid;
        chargeItem.GoodsItemGuid = goodsItem.Guid;
        chargeItem.TotalMoney = Convert.ToDecimal(txtTotalMoney.Text.Trim());
        chargeItem.PaidMoney = Convert.ToDecimal(txtPaidMoney.Text.Trim());
        if (!string.IsNullOrEmpty(txtReduceMoney.Text))
            chargeItem.ReducedMoney = Convert.ToDecimal(txtReduceMoney.Text.Trim());
        chargeItem.OwedMoney = Convert.ToDecimal(txtTotalMoney.Text.Trim()) - Convert.ToDecimal(txtPaidMoney.Text.Trim());
        if (chargeLogic.AddChargeNote(chargeNote, chargeItem))
        {
            pnlShowChargeInfo.Visible = true;
            txtCampus.Text = campusLogic.GetCampusById(campusGuid).Name;
            txtBillNumber.Text = billNumber;
            txtUserAccount.Text = UserAccout;
            txtSchool.Text = ddlSchoolName.SelectedItem.Text;
            txtClassType.Text = campusLogic.GetClassById(goodsItem.ClassGuid).Name;
            txtGrade.Text = campusLogic.GetGradeById(goodsItem.GradeGuid).Name;
            txtStudentID.Text = existedStudent.StudentID;
            txtStudentName.Text = existedStudent.Name;
            txtStuID.Text = existedStudent.ID;
            txtCheckWay.Text = ddlChargeWay.SelectedItem.Text;
            txtTMoney.Text = txtTotalMoney.Text;
            txtPMoney.Text = txtPaidMoney.Text;
            txtReduceMoney.Text = txtSpecialPrice.Text;
            txtGoodsTypeName.Text = ddlGoodsType.SelectedItem.Text;
            txtGoodsName.Text = ddlGoodsName.SelectedItem.Text;
            lbcampusGuid.Text = campusGuid.ToString() ;
            txtStudent.Text = "";
            //TODO:调用打印
            //MessageBox.ResponseAndPrint(this, "缴费成功！", billNumber, campusGuid.ToString());
            //     MessageBox.ShowAndRedirect(this, "print", string.Format("../PrintHandler/BillPrint.aspx?billNumber={0}&campusGuid={1}", billNumber, campusGuid.ToString()));
            MessageBox.ResponseScript(this.Page, string.Format("window.open ('../PrintHandler/BillPrint.aspx?billNumber={0}&campusGuid={1}','newwindow','height=0,width=0,top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no')", billNumber, campusGuid.ToString()));

        }
        else
        {
            //pnlShowChargeInfo.Visible = false;
            //txtCampus.Text = string.Empty;
            //txtBillNumber.Text = string.Empty;
            //txtUserAccount.Text = string.Empty;
            //txtSchool.Text = string.Empty;
            //txtClassType.Text = string.Empty;
            //txtGrade.Text = string.Empty;
            //txtStudentID.Text = string.Empty;            
            //txtStuID.Text = string.Empty;
            //txtCheckWay.Text = string.Empty;
            //txtTMoney.Text = string.Empty;
            //txtPMoney.Text = string.Empty;
            //txtReduceMoney.Text = string.Empty;
            //txtGoodsTypeName.Text = string.Empty;
            //txtGoodsName.Text = string.Empty;
            MessageBox.Show(this, "缴费失败！");
        }
    }

    protected void ddlGoodsName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGoodsName.SelectedValue != "--请选择--")
        {
            GoodsItem goodsItem = chargeLogic.GetGoodsItemByGuid(new Guid(ddlGoodsName.SelectedValue));
            txtTotalMoney.Text = goodsItem.Price.ToString();
            txtPaidMoney.Text = goodsItem.Price.ToString();
        }
    }
    protected void ddlChargeWay_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlChargeWay.SelectedValue == "1")
        {
            txtPosNumber.Enabled = true;
            rdvPosNumber.Enabled = true;
        }
        else
        {
            txtPosNumber.Enabled = false;
            rdvPosNumber.Enabled = false;
        }
    }

    public void BindChargePrint(string billNumber, string campusGuid)
    {
        //printViewer.Visible = true;
        ////ReportViewer printViewer = new ReportViewer();
        ////printViewer.ProcessingMode = ProcessingMode.Local;
        ////printViewer.ShowToolBar = false;
        //printViewer.ShowBackButton = false;
        //printViewer.ShowExportControls = false;
        //printViewer.ShowFindControls = false;
        //printViewer.ShowRefreshButton = false;
        //printViewer.ShowZoomControl = false;
        //printViewer.ShowPageNavigationControls = false;
        ////  printViewer.LocalReport.ReportPath = "Module\\PrintHandler\\RDLC\\Print_Charge.rdlc";
        //ChargeManager chargeLogic = new ChargeManager();
        //List<VChargeNote> chargeNote = chargeLogic.GetChargeNoteByBillNumber(billNumber, new Guid(campusGuid));
        //DataTable dt = new DataTable("printTable");
        //dt.Columns.Add("BillNumber");
        //dt.Columns.Add("StudentName");
        //dt.Columns.Add("CampusName");
        //dt.Columns.Add("SchoolName");
        //dt.Columns.Add("GradeName");
        //dt.Columns.Add("ClassName");
        //dt.Columns.Add("GoodsItemName");
        //dt.Columns.Add("GoodsTypeName");
        //dt.Columns.Add("TotalMoney");
        //dt.Columns.Add("PaidMoney");
        //dt.Columns.Add("Price");
        //dt.Columns.Add("UserName");
        //dt.Columns.Add("ChargeWay");
        //dt.Columns.Add("PosNumber");
        //foreach (VChargeNote cn in chargeNote)
        //{
        //    DataRow dr = dt.NewRow();
        //    dr["BillNumber"] = cn.BillNumber;
        //    dr["StudentName"] = cn.StudentName;
        //    dr["CampusName"] = cn.CampusName;
        //    dr["SchoolName"] = cn.SchoolName;
        //    dr["GradeName"] = cn.GradeName;
        //    dr["ClassName"] = cn.ClassName;
        //    dr["GoodsItemName"] = cn.GoodsItemName;
        //    dr["GoodsTypeName"] = cn.GoodsTypeName;
        //    dr["TotalMoney"] = cn.TotalMoney;
        //    dr["PaidMoney"] = cn.PaidMoney;
        //    dr["Price"] = cn.Price;
        //    dr["UserName"] = cn.UserName;
        //    dr["ChargeWay"] = cn.ChargeWay;
        //    dr["PosNumber"] = string.IsNullOrEmpty(cn.PosNumber) ? "" : cn.PosNumber;
        //    dt.Rows.Add(dr);
        //}
        //ReportDataSource rds = new ReportDataSource("DataSet1_ChargeNotePrintDS", dt);//ChargeNotePrintDS

        //printViewer.LocalReport.DataSources.Clear();
        //printViewer.LocalReport.DataSources.Add(rds);
        //printViewer.DataBind();
        //printViewer.LocalReport.Refresh();
        // Response.Redirect(Server.MapPath("~/PrintHandler/BillPrint.aspx"));
        //MessageBox.ResponseScript(this, "printBill();");
        MessageBox.ResponseAndPrint(this, "打印", "GD201308110670", "6E26BFD9-02E3-4985-8AEB-713F0E1F9B32");
        // MessageBox.ShowAndRedirect(this, "打印测试", "../PrintHandler/BillPrint.aspx");
        //   MessageBox.ShowAndRedirect(this, "打印发票", string.Format("../PrintHandler/BillPrint.aspx?billNumber={0}&campusGuid={1}", billNumber, campusGuid.ToString()));
    }
    //protected void btnPrintTest_Click(object sender, EventArgs e)
    //{
    //    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "message", string.Format("<script language='javascript' defer>window.location=\"{0}\"</script>", "../PrintHandler/BillPrint.aspx"));
    //    // Response.Redirect("../PrintHandler/BillPrint.aspx");
    //    BindChargePrint("GD201308110670", "6E26BFD9-02E3-4985-8AEB-713F0E1F9B32");
    //}


    protected void btnprint_Click(object sender, EventArgs e)
    {
        string billNumber=txtBillNumber.Text;
        string campusGuid = lbcampusGuid.Text;
        MessageBox.ResponseScript(this.Page, string.Format("window.open ('../PrintHandler/BillPrint.aspx?billNumber={0}&campusGuid={1}','newwindow','height=0,width=0,top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no')", billNumber, campusGuid));
    }
}

using System;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using System.Data;
using SMCShine.Data.Entities;
using SMCShine.Logic;

public partial class Module_PrintHandler_BillPrint : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetLocalBillPrint();
        }
    }

    protected void GetLocalBillPrint()
    {
        string billNumber = Request["billNumber"];
        string campusGuid = Request["campusGuid"];
        if (string.IsNullOrEmpty(billNumber) || string.IsNullOrEmpty(campusGuid))
            return;
        printViewer.ShowToolBar = false;
        ChargeManager chargeLogic = new ChargeManager();
        List<VChargeNote> chargeNote = chargeLogic.GetChargeNoteByBillNumber(billNumber, new Guid(campusGuid));
        DataTable dt = new DataTable("printTable");
        dt.Columns.Add("BillNumber");
        dt.Columns.Add("StudentName");
        dt.Columns.Add("CampusName");
        dt.Columns.Add("SchoolName");
        dt.Columns.Add("GradeName");
        dt.Columns.Add("ClassName");
        dt.Columns.Add("GoodsItemName");
        dt.Columns.Add("GoodsTypeName");
        dt.Columns.Add("TotalMoney");
        dt.Columns.Add("PaidMoney");
        dt.Columns.Add("Price");
        dt.Columns.Add("UserName");
        dt.Columns.Add("ChargeWay");
        dt.Columns.Add("PosNumber");
        dt.Columns.Add("Memo");
        foreach (VChargeNote cn in chargeNote)
        {
            DataRow dr = dt.NewRow();
            dr["BillNumber"] = cn.BillNumber;
            dr["StudentName"] = cn.StudentName;
            dr["CampusName"] = cn.CampusName;
            dr["SchoolName"] = cn.SchoolName;
            dr["GradeName"] = cn.GradeName;
            dr["ClassName"] = cn.ClassName;
            dr["GoodsItemName"] = cn.GoodsItemName;
            dr["GoodsTypeName"] = cn.GoodsTypeName;
            dr["TotalMoney"] = cn.TotalMoney;
            dr["PaidMoney"] = cn.PaidMoney;
            dr["Price"] = cn.Price;
            dr["UserName"] = cn.UserName;
            dr["ChargeWay"] = cn.ChargeWay;
            dr["PosNumber"] = string.IsNullOrEmpty(cn.PosNumber) ? "" : cn.PosNumber;
            dr["Memo"] = cn.Memo;
            dt.Rows.Add(dr);
        }
        ReportDataSource rds = new ReportDataSource("DataSet1_ChargeNotePrintDS", dt);
        printViewer.LocalReport.DataSources.Clear();
        printViewer.LocalReport.DataSources.Add(rds);
    }
}

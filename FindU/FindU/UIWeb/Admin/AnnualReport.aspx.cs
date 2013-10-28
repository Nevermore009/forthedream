using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReportDataSetTableAdapters;
using System.Data;
using Microsoft.Reporting.WebForms;
public partial class Admin_AnnualReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindYear();
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            bindRDLC(year);
        }
    }
    #region 绑定年份
    protected void BindYear()
    {
        int year = DateTime.Now.Year;
        for (int i = year; i <= year + 1; i++)
        {
            dropYear.Items.Add(new ListItem(i.ToString() + "年", i.ToString()));
        }
    }
    #endregion
    protected void bindRDLC(int year)
    {
        AnnualReportTableAdapter da = new AnnualReportTableAdapter();
        DataTable dt = da.GetData(year);
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportDataSource rds = new ReportDataSource("MonthDataSet", dt);
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] {
            new ReportParameter("title",year.ToString()+"年度巡检报表")
        });
    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        string year = dropYear.SelectedValue.ToString();
        bindRDLC(int.Parse(year));
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReportDataSetTableAdapters;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class Admin_MonthlyReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindYear();
            BindMonth();
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            bindRDLC(year, month);
        }

    }
    
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        string year = dropYear.SelectedValue.ToString();
        string month = dropMonth.SelectedValue.ToString();
        bindRDLC(int.Parse(year), int.Parse(month));
    }
    protected void bindRDLC(int year, int month)
    {
        MonthlyReportTableAdapter da = new MonthlyReportTableAdapter();
        DataTable dt = da.GetData(year, month);
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportDataSource rds = new ReportDataSource("MonthDataSet", dt);
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] {
            new ReportParameter("title",year.ToString()+"年"+month.ToString()+"月巡检报表")
        });
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
    #region 绑定月份
    protected void BindMonth()
    {
        for (int i = 1; i <= 12; i++)
        {
            dropMonth.Items.Add(new ListItem(i.ToString() + "月", i.ToString()));
        }
        dropMonth.SelectedValue = DateTime.Now.Month.ToString();
    }
    #endregion
}
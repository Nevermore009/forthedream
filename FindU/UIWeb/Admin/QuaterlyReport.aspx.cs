using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReportDataSetTableAdapters;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class Admin_QuaterlyReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindYear();
            Binduater();
            int year = DateTime.Now.Year;
            decimal month = DateTime.Now.Month;
            decimal quaters = month / 3;
            int quater =(int)Math.Ceiling(quaters);
            bindRDLC(year, quater);
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
    #region 绑定季度
    protected void Binduater()
    {
        for (int i = 1; i <= 4; i++)
        {
            dropQuater.Items.Add(new ListItem("第"+i.ToString() + "季度", i.ToString()));
        }
    }
    #endregion
    protected void bindRDLC(int year,int quater)
    {
        QuaterlyReportTableAdapter da = new QuaterlyReportTableAdapter();
        DataTable dt = da.GetData(year,quater);
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportDataSource rds = new ReportDataSource("MonthDataSet", dt);
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] {
            new ReportParameter("title",year+"年第"+quater.ToString()+"季度巡检报表")
        });
    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        string year = dropYear.SelectedValue.ToString();
        string quater = dropQuater.SelectedValue.ToString();
        bindRDLC(int.Parse(year),int.Parse(quater));
    }
}
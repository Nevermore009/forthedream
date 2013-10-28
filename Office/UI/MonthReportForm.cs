using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UI.EnergyConservationDataSetTableAdapters;
using Microsoft.Reporting.WinForms;

namespace UI
{
    public partial class MonthReportForm : Form
    {
        public MonthReportForm()
        {
            InitializeComponent();
           // this.FindForm().Icon = new Icon(ConfigurationManager.AppSettings["logo"]);
        }

        private void MonthReportForm_Load(object sender, EventArgs e)
        {
            bindYear();
        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            if (cmbyear.SelectedItem == null || cmbmonth.SelectedItem == null)
            {
                MessageBox.Show("请选择年份和月份！");
                return;
            }
            string year = cmbyear.SelectedItem.ToString();
            string month = cmbmonth.SelectedItem.ToString();
            reportViewer1.LocalReport.DataSources.Clear();
            procView_MonthReportTableAdapter da = new procView_MonthReportTableAdapter();
            DataTable dt = da.GetData(year, month);
            ReportDataSource rd = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rd);
            reportViewer1.RefreshReport();
        }

        private void bindYear()
        {
            for (int i = DateTime.Now.Year; i > 2012; i--)
            {
                cmbyear.Items.Add(i);
            }
        }
    }
}

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
    public partial class QuarterReportForm : Form
    {
        public QuarterReportForm()
        {
            InitializeComponent();
            //this.FindForm().Icon = new Icon(ConfigurationManager.AppSettings["logo"]);
        }

        private void QuarterReportForm_Load(object sender, EventArgs e)
        {
            bindYear();
        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            if (cmbYear.SelectedItem==null||cmbQuarter.SelectedItem==null)
            {
                MessageBox.Show("请选择正确的年份和季度！");
                return;
            }
            string year = cmbYear.SelectedItem.ToString();
            string a=null;
            string b=null;
            if (cmbQuarter.SelectedItem.ToString()=="第1季度")
            {
                  a = "1"; b = "3";

            }
            if (cmbQuarter.SelectedItem.ToString()=="第2季度")
            {
                a = "4"; b = "6";
            }
            if (cmbQuarter.SelectedItem.ToString()=="第3季度")
            {
                a = "7"; b = "9";
            }
            if (cmbQuarter.SelectedItem.ToString()=="第4季度")
            {
                a = "10"; b = "12";
            }

            reportViewer1.LocalReport.DataSources.Clear();
            procView_QuarterReportTableAdapter da = new procView_QuarterReportTableAdapter();
            DataTable dt = da.GetData(year, a, b);
            ReportDataSource rd = new ReportDataSource("DataSet1",dt);
            reportViewer1.LocalReport.DataSources.Add(rd);
            reportViewer1.RefreshReport();

        }
        private void bindYear()
        {
            for (int i = DateTime.Now.Year; i > 2012; i--)
            {
                cmbYear.Items.Add(i);
            }
        }
    }
}

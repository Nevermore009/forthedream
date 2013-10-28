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
    public partial class YearReportForm : Form
    {
        public YearReportForm()
        {
            InitializeComponent();
        }

        private void YearReportForm_Load(object sender, EventArgs e)
        {
            //this.FindForm().Icon = new Icon(ConfigurationManager.AppSettings["logo"]);
            bindYear();
        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            //string datetime = dateTimePicker1.Text.ToString();
            //reportViewer1.LocalReport.DataSources.Clear();
            //procView_ReportTableAdapter da = new procView_ReportTableAdapter();
            //DataTable dt = da.GetData(datetime);
            //ReportDataSource rd = new ReportDataSource("DataSet1", dt);
            //reportViewer1.LocalReport.DataSources.Add(rd);
            //reportViewer1.RefreshReport();
            if (cmbyear.SelectedItem==null)
            {
                MessageBox.Show("请选择年份！");
                return;
            }
            string year = cmbyear.SelectedItem.ToString();
            reportViewer1.LocalReport.DataSources.Clear();
            proc_YearReportTableAdapter da=new proc_YearReportTableAdapter();
            DataTable dt = da.GetData(year);
            ReportDataSource rd = new ReportDataSource("DataSet1",dt);
            reportViewer1.LocalReport.DataSources.Add(rd);
            reportViewer1.RefreshReport();
        }


        private void bindYear()
        {
            for (int i = DateTime.Now.Year; i >2012; i--)
            {
                cmbyear.Items.Add(i);
            }
        }
    }
}

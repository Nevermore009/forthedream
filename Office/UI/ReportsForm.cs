using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using UI.EnergyConservationDataSetTableAdapters;

namespace UI
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
          //  this.FindForm().Icon = new Icon(ConfigurationManager.AppSettings["logo"]);
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string datetime = dateTimePicker1.Text.ToString();
            reportViewer1.LocalReport.DataSources.Clear();
            procView_ReportTableAdapter da = new procView_ReportTableAdapter();
            DataTable dt = da.GetData(datetime);
            ReportDataSource rd = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rd);
            reportViewer1.RefreshReport();
        }
    }
}

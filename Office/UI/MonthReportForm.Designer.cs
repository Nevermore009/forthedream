namespace UI
{
    partial class MonthReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthReportForm));
            this.procView_MonthReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EnergyConservationDataSet = new UI.EnergyConservationDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbyear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbmonth = new System.Windows.Forms.ComboBox();
            this.btnCreateReport = new System.Windows.Forms.Button();
            this.procView_MonthReportTableAdapter = new UI.EnergyConservationDataSetTableAdapters.procView_MonthReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.procView_MonthReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyConservationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // procView_MonthReportBindingSource
            // 
            this.procView_MonthReportBindingSource.DataMember = "procView_MonthReport";
            this.procView_MonthReportBindingSource.DataSource = this.EnergyConservationDataSet;
            // 
            // EnergyConservationDataSet
            // 
            this.EnergyConservationDataSet.DataSetName = "EnergyConservationDataSet";
            this.EnergyConservationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.procView_MonthReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.RDLC.MonthReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(25, 63);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(539, 363);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "年份：";
            // 
            // cmbyear
            // 
            this.cmbyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyear.FormattingEnabled = true;
            this.cmbyear.Location = new System.Drawing.Point(70, 20);
            this.cmbyear.Name = "cmbyear";
            this.cmbyear.Size = new System.Drawing.Size(137, 20);
            this.cmbyear.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "月份：";
            // 
            // cmbmonth
            // 
            this.cmbmonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmonth.FormattingEnabled = true;
            this.cmbmonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbmonth.Location = new System.Drawing.Point(279, 20);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.Size = new System.Drawing.Size(127, 20);
            this.cmbmonth.TabIndex = 4;
            // 
            // btnCreateReport
            // 
            this.btnCreateReport.Location = new System.Drawing.Point(432, 17);
            this.btnCreateReport.Name = "btnCreateReport";
            this.btnCreateReport.Size = new System.Drawing.Size(92, 23);
            this.btnCreateReport.TabIndex = 5;
            this.btnCreateReport.Text = "生成报表";
            this.btnCreateReport.UseVisualStyleBackColor = true;
            this.btnCreateReport.Click += new System.EventHandler(this.btnCreateReport_Click);
            // 
            // procView_MonthReportTableAdapter
            // 
            this.procView_MonthReportTableAdapter.ClearBeforeFill = true;
            // 
            // MonthReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 438);
            this.Controls.Add(this.btnCreateReport);
            this.Controls.Add(this.cmbmonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbyear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(606, 476);
            this.MinimumSize = new System.Drawing.Size(606, 476);
            this.Name = "MonthReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用电月报表";
            this.Load += new System.EventHandler(this.MonthReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.procView_MonthReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyConservationDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbyear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbmonth;
        private System.Windows.Forms.Button btnCreateReport;
        private System.Windows.Forms.BindingSource procView_MonthReportBindingSource;
        private EnergyConservationDataSet EnergyConservationDataSet;
        private EnergyConservationDataSetTableAdapters.procView_MonthReportTableAdapter procView_MonthReportTableAdapter;
    }
}
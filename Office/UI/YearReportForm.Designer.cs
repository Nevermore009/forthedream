namespace UI
{
    partial class YearReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YearReportForm));
            this.proc_YearReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EnergyConservationDataSet = new UI.EnergyConservationDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateReport = new System.Windows.Forms.Button();
            this.proc_YearReportTableAdapter = new UI.EnergyConservationDataSetTableAdapters.proc_YearReportTableAdapter();
            this.cmbyear = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.proc_YearReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyConservationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // proc_YearReportBindingSource
            // 
            this.proc_YearReportBindingSource.DataMember = "proc_YearReport";
            this.proc_YearReportBindingSource.DataSource = this.EnergyConservationDataSet;
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
            reportDataSource1.Value = this.proc_YearReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.RDLC.YearReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(22, 69);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(524, 374);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "年份：";
            // 
            // btnCreateReport
            // 
            this.btnCreateReport.Location = new System.Drawing.Point(225, 23);
            this.btnCreateReport.Name = "btnCreateReport";
            this.btnCreateReport.Size = new System.Drawing.Size(96, 23);
            this.btnCreateReport.TabIndex = 3;
            this.btnCreateReport.Text = "生成报表";
            this.btnCreateReport.UseVisualStyleBackColor = true;
            this.btnCreateReport.Click += new System.EventHandler(this.btnCreateReport_Click);
            // 
            // proc_YearReportTableAdapter
            // 
            this.proc_YearReportTableAdapter.ClearBeforeFill = true;
            // 
            // cmbyear
            // 
            this.cmbyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyear.FormattingEnabled = true;
            this.cmbyear.Location = new System.Drawing.Point(66, 25);
            this.cmbyear.Name = "cmbyear";
            this.cmbyear.Size = new System.Drawing.Size(138, 20);
            this.cmbyear.TabIndex = 4;
            // 
            // YearReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 455);
            this.Controls.Add(this.cmbyear);
            this.Controls.Add(this.btnCreateReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(582, 493);
            this.MinimumSize = new System.Drawing.Size(582, 493);
            this.Name = "YearReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用电年报表";
            this.Load += new System.EventHandler(this.YearReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.proc_YearReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyConservationDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateReport;
        private System.Windows.Forms.BindingSource proc_YearReportBindingSource;
        private EnergyConservationDataSet EnergyConservationDataSet;
        private EnergyConservationDataSetTableAdapters.proc_YearReportTableAdapter proc_YearReportTableAdapter;
        private System.Windows.Forms.ComboBox cmbyear;
    }
}
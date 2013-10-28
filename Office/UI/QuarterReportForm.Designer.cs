namespace UI
{
    partial class QuarterReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuarterReportForm));
            this.procView_QuarterReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EnergyConservationDataSet = new UI.EnergyConservationDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateReport = new System.Windows.Forms.Button();
            this.cmbQuarter = new System.Windows.Forms.ComboBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.procView_QuarterReportTableAdapter = new UI.EnergyConservationDataSetTableAdapters.procView_QuarterReportTableAdapter();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.procView_QuarterReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyConservationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // procView_QuarterReportBindingSource
            // 
            this.procView_QuarterReportBindingSource.DataMember = "procView_QuarterReport";
            this.procView_QuarterReportBindingSource.DataSource = this.EnergyConservationDataSet;
            // 
            // EnergyConservationDataSet
            // 
            this.EnergyConservationDataSet.DataSetName = "EnergyConservationDataSet";
            this.EnergyConservationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "年份：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "季度：";
            // 
            // btnCreateReport
            // 
            this.btnCreateReport.Location = new System.Drawing.Point(431, 20);
            this.btnCreateReport.Name = "btnCreateReport";
            this.btnCreateReport.Size = new System.Drawing.Size(96, 23);
            this.btnCreateReport.TabIndex = 5;
            this.btnCreateReport.Text = "生成报表";
            this.btnCreateReport.UseVisualStyleBackColor = true;
            this.btnCreateReport.Click += new System.EventHandler(this.btnCreateReport_Click);
            // 
            // cmbQuarter
            // 
            this.cmbQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuarter.FormattingEnabled = true;
            this.cmbQuarter.Items.AddRange(new object[] {
            "第1季度",
            "第2季度",
            "第3季度",
            "第4季度"});
            this.cmbQuarter.Location = new System.Drawing.Point(274, 22);
            this.cmbQuarter.Name = "cmbQuarter";
            this.cmbQuarter.Size = new System.Drawing.Size(137, 20);
            this.cmbQuarter.TabIndex = 6;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.procView_QuarterReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.RDLC.QuarterReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(29, 65);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(542, 376);
            this.reportViewer1.TabIndex = 7;
            // 
            // procView_QuarterReportTableAdapter
            // 
            this.procView_QuarterReportTableAdapter.ClearBeforeFill = true;
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(74, 23);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(132, 20);
            this.cmbYear.TabIndex = 8;
            // 
            // QuarterReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 453);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cmbQuarter);
            this.Controls.Add(this.btnCreateReport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(609, 491);
            this.MinimumSize = new System.Drawing.Size(609, 491);
            this.Name = "QuarterReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用电季度报表";
            this.Load += new System.EventHandler(this.QuarterReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.procView_QuarterReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyConservationDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateReport;
        private System.Windows.Forms.ComboBox cmbQuarter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource procView_QuarterReportBindingSource;
        private EnergyConservationDataSet EnergyConservationDataSet;
        private EnergyConservationDataSetTableAdapters.procView_QuarterReportTableAdapter procView_QuarterReportTableAdapter;
        private System.Windows.Forms.ComboBox cmbYear;

    }
}
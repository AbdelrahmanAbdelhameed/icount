namespace I_Count
{
    partial class LateProReport
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
            this.Lblid = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.providers = new I_Count.Providers();
            this.showProProcBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.showProProcTableAdapter = new I_Count.ProvidersTableAdapters.showProProcTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.providers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showProProcBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Lblid
            // 
            this.Lblid.AutoSize = true;
            this.Lblid.Location = new System.Drawing.Point(186, 175);
            this.Lblid.Name = "Lblid";
            this.Lblid.Size = new System.Drawing.Size(0, 13);
            this.Lblid.TabIndex = 0;
            this.Lblid.Visible = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.showProProcBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "I_Count.Report7.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(403, 446);
            this.reportViewer1.TabIndex = 1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.providers;
            this.bindingSource1.Position = 0;
            // 
            // providers
            // 
            this.providers.DataSetName = "Providers";
            this.providers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // showProProcBindingSource
            // 
            this.showProProcBindingSource.DataMember = "showProProc";
            this.showProProcBindingSource.DataSource = this.providers;
            // 
            // showProProcTableAdapter
            // 
            this.showProProcTableAdapter.ClearBeforeFill = true;
            // 
            // LateProReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 446);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.Lblid);
            this.Name = "LateProReport";
            this.Text = "تقرير الاجل";
            this.Load += new System.EventHandler(this.LateProReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.providers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showProProcBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lblid;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Providers providers;
        private System.Windows.Forms.BindingSource showProProcBindingSource;
        private ProvidersTableAdapters.showProProcTableAdapter showProProcTableAdapter;
    }
}
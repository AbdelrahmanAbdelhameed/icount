namespace I_Count
{
    partial class LateCuReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LateCuReport));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.LblID = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.customers = new I_Count.Customers();
            this.ShowCusProsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ShowCusProsTableAdapter = new I_Count.CustomersTableAdapters.ShowCusProsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowCusProsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ShowCusProsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "I_Count.Report6.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(502, 456);
            this.reportViewer1.TabIndex = 0;
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(167, 317);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(0, 13);
            this.LblID.TabIndex = 1;
            this.LblID.Visible = false;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.customers;
            this.bindingSource1.Position = 0;
            // 
            // customers
            // 
            this.customers.DataSetName = "Customers";
            this.customers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ShowCusProsBindingSource
            // 
            this.ShowCusProsBindingSource.DataMember = "ShowCusPros";
            this.ShowCusProsBindingSource.DataSource = this.customers;
            // 
            // ShowCusProsTableAdapter
            // 
            this.ShowCusProsTableAdapter.ClearBeforeFill = true;
            // 
            // LateCuReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 456);
            this.Controls.Add(this.LblID);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LateCuReport";
            this.Text = "تقرير الاجل";
            this.Load += new System.EventHandler(this.LateReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowCusProsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Customers customers;
        private System.Windows.Forms.BindingSource ShowCusProsBindingSource;
        private CustomersTableAdapters.ShowCusProsTableAdapter ShowCusProsTableAdapter;
    }
}
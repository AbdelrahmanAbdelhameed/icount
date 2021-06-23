namespace I_Count
{
    partial class ReportStore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportStore));
            this.LoadProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new I_Count.DataSet1();
            this.Store = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.LoadProductsTableAdapter = new I_Count.DataSet1TableAdapters.LoadProductsTableAdapter();
            this.LblID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LoadProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadProductsBindingSource
            // 
            this.LoadProductsBindingSource.DataMember = "LoadProducts";
            this.LoadProductsBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Store
            // 
            this.Store.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.LoadProductsBindingSource;
            this.Store.LocalReport.DataSources.Add(reportDataSource1);
            this.Store.LocalReport.ReportEmbeddedResource = "I_Count.Report5.rdlc";
            this.Store.Location = new System.Drawing.Point(0, 0);
            this.Store.Name = "Store";
            this.Store.Size = new System.Drawing.Size(477, 449);
            this.Store.TabIndex = 0;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.dataSet1;
            this.bindingSource1.Position = 0;
            // 
            // LoadProductsTableAdapter
            // 
            this.LoadProductsTableAdapter.ClearBeforeFill = true;
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(346, 310);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(0, 13);
            this.LblID.TabIndex = 1;
            this.LblID.Visible = false;
            // 
            // ReportStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 449);
            this.Controls.Add(this.LblID);
            this.Controls.Add(this.Store);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقرير المخزن ";
            this.Load += new System.EventHandler(this.ReportStore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LoadProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer Store;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource LoadProductsBindingSource;
        private DataSet1TableAdapters.LoadProductsTableAdapter LoadProductsTableAdapter;
        private System.Windows.Forms.Label LblID;
    }
}
namespace I_Count
{
    partial class PurchasesBills
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchasesBills));
            this.VWShowPurchasesBillsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AccountingDataSet = new I_Count.AccountingDataSet();
            this.LblBillID = new System.Windows.Forms.Label();
            this.REBuying = new Microsoft.Reporting.WinForms.ReportViewer();
            this.VWShowPurchasesBillsTableAdapter = new I_Count.AccountingDataSetTableAdapters.VWShowPurchasesBillsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.VWShowPurchasesBillsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountingDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // VWShowPurchasesBillsBindingSource
            // 
            this.VWShowPurchasesBillsBindingSource.DataMember = "VWShowPurchasesBills";
            this.VWShowPurchasesBillsBindingSource.DataSource = this.AccountingDataSet;
            // 
            // AccountingDataSet
            // 
            this.AccountingDataSet.DataSetName = "AccountingDataSet";
            this.AccountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LblBillID
            // 
            this.LblBillID.AutoSize = true;
            this.LblBillID.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblBillID.Font = new System.Drawing.Font("Tahoma", 11F);
            this.LblBillID.ForeColor = System.Drawing.Color.White;
            this.LblBillID.Location = new System.Drawing.Point(169, 15);
            this.LblBillID.Name = "LblBillID";
            this.LblBillID.Size = new System.Drawing.Size(0, 18);
            this.LblBillID.TabIndex = 13;
            this.LblBillID.Visible = false;
            // 
            // REBuying
            // 
            this.REBuying.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSProvider";
            reportDataSource1.Value = this.VWShowPurchasesBillsBindingSource;
            this.REBuying.LocalReport.DataSources.Add(reportDataSource1);
            this.REBuying.LocalReport.ReportEmbeddedResource = "I_Count.Report3.rdlc";
            this.REBuying.Location = new System.Drawing.Point(0, 0);
            this.REBuying.Name = "REBuying";
            this.REBuying.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.REBuying.Size = new System.Drawing.Size(637, 431);
            this.REBuying.TabIndex = 14;
            // 
            // VWShowPurchasesBillsTableAdapter
            // 
            this.VWShowPurchasesBillsTableAdapter.ClearBeforeFill = true;
            // 
            // PurchasesBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(637, 431);
            this.Controls.Add(this.REBuying);
            this.Controls.Add(this.LblBillID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PurchasesBills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة شراء";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Load += new System.EventHandler(this.PurchasesBills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VWShowPurchasesBillsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountingDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblBillID;
        private Microsoft.Reporting.WinForms.ReportViewer REBuying;
        private System.Windows.Forms.BindingSource VWShowPurchasesBillsBindingSource;
        private AccountingDataSet AccountingDataSet;
        private AccountingDataSetTableAdapters.VWShowPurchasesBillsTableAdapter VWShowPurchasesBillsTableAdapter;
    }
}
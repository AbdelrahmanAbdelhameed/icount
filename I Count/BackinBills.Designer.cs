namespace I_Count
{
    partial class BackinBills
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackinBills));
            this.BackinBillViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AccountingDataSet2 = new I_Count.AccountingDataSet2();
            this.LblBillID = new System.Windows.Forms.Label();
            this.REBackin = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BackinBillViewTableAdapter = new I_Count.AccountingDataSet2TableAdapters.BackinBillViewTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BackinBillViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountingDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // BackinBillViewBindingSource
            // 
            this.BackinBillViewBindingSource.DataMember = "BackinBillView";
            this.BackinBillViewBindingSource.DataSource = this.AccountingDataSet2;
            // 
            // AccountingDataSet2
            // 
            this.AccountingDataSet2.DataSetName = "AccountingDataSet2";
            this.AccountingDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LblBillID
            // 
            this.LblBillID.AutoSize = true;
            this.LblBillID.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblBillID.Font = new System.Drawing.Font("Tahoma", 11F);
            this.LblBillID.ForeColor = System.Drawing.Color.White;
            this.LblBillID.Location = new System.Drawing.Point(205, 22);
            this.LblBillID.Name = "LblBillID";
            this.LblBillID.Size = new System.Drawing.Size(0, 18);
            this.LblBillID.TabIndex = 13;
            this.LblBillID.Visible = false;
            // 
            // REBackin
            // 
            this.REBackin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.REBackin.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSIn";
            reportDataSource1.Value = this.BackinBillViewBindingSource;
            this.REBackin.LocalReport.DataSources.Add(reportDataSource1);
            this.REBackin.LocalReport.ReportEmbeddedResource = "I_Count.Report2.rdlc";
            this.REBackin.Location = new System.Drawing.Point(0, 0);
            this.REBackin.Name = "REBackin";
            this.REBackin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.REBackin.Size = new System.Drawing.Size(629, 438);
            this.REBackin.TabIndex = 14;
            // 
            // BackinBillViewTableAdapter
            // 
            this.BackinBillViewTableAdapter.ClearBeforeFill = true;
            // 
            // BackinBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(629, 438);
            this.Controls.Add(this.REBackin);
            this.Controls.Add(this.LblBillID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BackinBills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة مرتجع بيع  ";
            this.Load += new System.EventHandler(this.BackinBills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BackinBillViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountingDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblBillID;
        private Microsoft.Reporting.WinForms.ReportViewer REBackin;
        private System.Windows.Forms.BindingSource BackinBillViewBindingSource;
        private AccountingDataSet2 AccountingDataSet2;
        private AccountingDataSet2TableAdapters.BackinBillViewTableAdapter BackinBillViewTableAdapter;
    }
}
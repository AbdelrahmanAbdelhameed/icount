namespace I_Count
{
    partial class Backoutbills
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Backoutbills));
            this.BackoutBillViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AccountingDataSet1 = new I_Count.AccountingDataSet1();
            this.LblBillID = new System.Windows.Forms.Label();
            this.ReBackout = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BackoutBillViewTableAdapter = new I_Count.AccountingDataSet1TableAdapters.BackoutBillViewTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BackoutBillViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountingDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // BackoutBillViewBindingSource
            // 
            this.BackoutBillViewBindingSource.DataMember = "BackoutBillView";
            this.BackoutBillViewBindingSource.DataSource = this.AccountingDataSet1;
            // 
            // AccountingDataSet1
            // 
            this.AccountingDataSet1.DataSetName = "AccountingDataSet1";
            this.AccountingDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LblBillID
            // 
            this.LblBillID.AutoSize = true;
            this.LblBillID.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblBillID.Font = new System.Drawing.Font("Tahoma", 11F);
            this.LblBillID.ForeColor = System.Drawing.Color.White;
            this.LblBillID.Location = new System.Drawing.Point(230, 53);
            this.LblBillID.Name = "LblBillID";
            this.LblBillID.Size = new System.Drawing.Size(0, 18);
            this.LblBillID.TabIndex = 22;
            // 
            // ReBackout
            // 
            this.ReBackout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ReBackout.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "OutDs";
            reportDataSource1.Value = this.BackoutBillViewBindingSource;
            this.ReBackout.LocalReport.DataSources.Add(reportDataSource1);
            this.ReBackout.LocalReport.ReportEmbeddedResource = "I_Count.Report4.rdlc";
            this.ReBackout.Location = new System.Drawing.Point(0, 0);
            this.ReBackout.Name = "ReBackout";
            this.ReBackout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ReBackout.Size = new System.Drawing.Size(635, 473);
            this.ReBackout.TabIndex = 23;
            // 
            // BackoutBillViewTableAdapter
            // 
            this.BackoutBillViewTableAdapter.ClearBeforeFill = true;
            // 
            // Backoutbills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(635, 473);
            this.Controls.Add(this.ReBackout);
            this.Controls.Add(this.LblBillID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Backoutbills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة مرتجع شراء";
            this.Load += new System.EventHandler(this.Backoutbills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BackoutBillViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountingDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblBillID;
        private Microsoft.Reporting.WinForms.ReportViewer ReBackout;
        private System.Windows.Forms.BindingSource BackoutBillViewBindingSource;
        private AccountingDataSet1 AccountingDataSet1;
        private AccountingDataSet1TableAdapters.BackoutBillViewTableAdapter BackoutBillViewTableAdapter;
    }
}
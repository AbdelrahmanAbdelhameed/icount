namespace I_Count
{
    partial class SalesBills
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesBills));
            this.VWBillsShowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSales = new I_Count.DSales();
            this.LblBillID = new System.Windows.Forms.Label();
            this.RESales = new Microsoft.Reporting.WinForms.ReportViewer();
            this.VWBillsShowTableAdapter = new I_Count.DSalesTableAdapters.VWBillsShowTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.VWBillsShowBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSales)).BeginInit();
            this.SuspendLayout();
            // 
            // VWBillsShowBindingSource
            // 
            this.VWBillsShowBindingSource.DataMember = "VWBillsShow";
            this.VWBillsShowBindingSource.DataSource = this.DSales;
            // 
            // DSales
            // 
            this.DSales.DataSetName = "DSales";
            this.DSales.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LblBillID
            // 
            this.LblBillID.AutoSize = true;
            this.LblBillID.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblBillID.Font = new System.Drawing.Font("Tahoma", 11F);
            this.LblBillID.ForeColor = System.Drawing.Color.White;
            this.LblBillID.Location = new System.Drawing.Point(12, 9);
            this.LblBillID.Name = "LblBillID";
            this.LblBillID.Size = new System.Drawing.Size(0, 18);
            this.LblBillID.TabIndex = 2;
            this.LblBillID.Visible = false;
            // 
            // RESales
            // 
            this.RESales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RESales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RESales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RESales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RESales.ForeColor = System.Drawing.Color.Black;
            reportDataSource1.Name = "DSCustomers";
            reportDataSource1.Value = this.VWBillsShowBindingSource;
            this.RESales.LocalReport.DataSources.Add(reportDataSource1);
            this.RESales.LocalReport.ReportEmbeddedResource = "I_Count.Report1.rdlc";
            this.RESales.Location = new System.Drawing.Point(0, 0);
            this.RESales.Name = "RESales";
            this.RESales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RESales.Size = new System.Drawing.Size(634, 422);
            this.RESales.TabIndex = 3;
            // 
            // VWBillsShowTableAdapter
            // 
            this.VWBillsShowTableAdapter.ClearBeforeFill = true;
            // 
            // SalesBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(634, 422);
            this.Controls.Add(this.RESales);
            this.Controls.Add(this.LblBillID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalesBills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalesBills";
            this.Load += new System.EventHandler(this.SalesBills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VWBillsShowBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblBillID;
        private Microsoft.Reporting.WinForms.ReportViewer RESales;
        private System.Windows.Forms.BindingSource VWBillsShowBindingSource;
        private DSales DSales;
        private DSalesTableAdapters.VWBillsShowTableAdapter VWBillsShowTableAdapter;
    }
}
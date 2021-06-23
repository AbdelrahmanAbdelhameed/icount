namespace I_Count
{
    partial class LogsReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogsReport));
            this.CBUsers = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.GVShowLogs = new System.Windows.Forms.DataGridView();
            this.ItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GVShowLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // CBUsers
            // 
            this.CBUsers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CBUsers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CBUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.CBUsers.ForeColor = System.Drawing.Color.Teal;
            this.CBUsers.FormattingEnabled = true;
            this.CBUsers.Location = new System.Drawing.Point(169, 12);
            this.CBUsers.Name = "CBUsers";
            this.CBUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CBUsers.Size = new System.Drawing.Size(169, 21);
            this.CBUsers.TabIndex = 115;
            this.CBUsers.SelectionChangeCommitted += new System.EventHandler(this.CBUsers_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.DimGray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(361, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 22);
            this.label10.TabIndex = 114;
            this.label10.Text = ": اسم المستخدم";
            // 
            // GVShowLogs
            // 
            this.GVShowLogs.AllowUserToAddRows = false;
            this.GVShowLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GVShowLogs.BackgroundColor = System.Drawing.Color.DimGray;
            this.GVShowLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GVShowLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVShowLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemType,
            this.ItemName,
            this.Price});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GVShowLogs.DefaultCellStyle = dataGridViewCellStyle1;
            this.GVShowLogs.Location = new System.Drawing.Point(12, 39);
            this.GVShowLogs.Name = "GVShowLogs";
            this.GVShowLogs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GVShowLogs.Size = new System.Drawing.Size(626, 490);
            this.GVShowLogs.TabIndex = 116;
            // 
            // ItemType
            // 
            this.ItemType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemType.HeaderText = "اسم المستخدم";
            this.ItemType.Name = "ItemType";
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.HeaderText = "الوصف";
            this.ItemName.Name = "ItemName";
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price.HeaderText = "الوقت والتريخ";
            this.Price.Name = "Price";
            // 
            // LogsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(650, 541);
            this.Controls.Add(this.GVShowLogs);
            this.Controls.Add(this.CBUsers);
            this.Controls.Add(this.label10);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LogsReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقارير المستخدمين";
            this.Load += new System.EventHandler(this.LogsReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GVShowLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBUsers;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView GVShowLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}
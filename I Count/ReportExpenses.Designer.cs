namespace I_Count
{
    partial class ReportExpenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportExpenses));
            this.PanHead = new System.Windows.Forms.Panel();
            this.LblSearch = new System.Windows.Forms.Label();
            this.LblMonth = new System.Windows.Forms.Label();
            this.LblDay = new System.Windows.Forms.Label();
            this.DtTO = new System.Windows.Forms.DateTimePicker();
            this.LblTo = new System.Windows.Forms.Label();
            this.DTFrom = new System.Windows.Forms.DateTimePicker();
            this.LblFrom = new System.Windows.Forms.Label();
            this.PicSearch = new System.Windows.Forms.PictureBox();
            this.PicMonth = new System.Windows.Forms.PictureBox();
            this.PicDay = new System.Windows.Forms.PictureBox();
            this.PanFooter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTotalExpenses = new System.Windows.Forms.Label();
            this.PanShow = new System.Windows.Forms.Panel();
            this.GvExpenses = new System.Windows.Forms.DataGridView();
            this.Expenses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExPre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpensesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Store = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDay)).BeginInit();
            this.PanFooter.SuspendLayout();
            this.PanShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvExpenses)).BeginInit();
            this.SuspendLayout();
            // 
            // PanHead
            // 
            this.PanHead.BackColor = System.Drawing.Color.DimGray;
            this.PanHead.Controls.Add(this.LblSearch);
            this.PanHead.Controls.Add(this.LblMonth);
            this.PanHead.Controls.Add(this.LblDay);
            this.PanHead.Controls.Add(this.DtTO);
            this.PanHead.Controls.Add(this.LblTo);
            this.PanHead.Controls.Add(this.DTFrom);
            this.PanHead.Controls.Add(this.LblFrom);
            this.PanHead.Controls.Add(this.PicSearch);
            this.PanHead.Controls.Add(this.PicMonth);
            this.PanHead.Controls.Add(this.PicDay);
            this.PanHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanHead.Location = new System.Drawing.Point(0, 0);
            this.PanHead.Name = "PanHead";
            this.PanHead.Size = new System.Drawing.Size(841, 135);
            this.PanHead.TabIndex = 0;
            // 
            // LblSearch
            // 
            this.LblSearch.AutoSize = true;
            this.LblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSearch.ForeColor = System.Drawing.Color.White;
            this.LblSearch.Location = new System.Drawing.Point(71, 55);
            this.LblSearch.Name = "LblSearch";
            this.LblSearch.Size = new System.Drawing.Size(31, 18);
            this.LblSearch.TabIndex = 234;
            this.LblSearch.Text = "بحث";
            this.LblSearch.Visible = false;
            // 
            // LblMonth
            // 
            this.LblMonth.AutoSize = true;
            this.LblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMonth.ForeColor = System.Drawing.Color.White;
            this.LblMonth.Location = new System.Drawing.Point(482, 109);
            this.LblMonth.Name = "LblMonth";
            this.LblMonth.Size = new System.Drawing.Size(67, 18);
            this.LblMonth.TabIndex = 233;
            this.LblMonth.Text = "تقرير الشهر";
            this.LblMonth.Visible = false;
            // 
            // LblDay
            // 
            this.LblDay.AutoSize = true;
            this.LblDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDay.ForeColor = System.Drawing.Color.White;
            this.LblDay.Location = new System.Drawing.Point(705, 109);
            this.LblDay.Name = "LblDay";
            this.LblDay.Size = new System.Drawing.Size(60, 18);
            this.LblDay.TabIndex = 232;
            this.LblDay.Text = "تقرير اليوم";
            this.LblDay.Visible = false;
            // 
            // DtTO
            // 
            this.DtTO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DtTO.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DtTO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtTO.Location = new System.Drawing.Point(178, 71);
            this.DtTO.Name = "DtTO";
            this.DtTO.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DtTO.RightToLeftLayout = true;
            this.DtTO.Size = new System.Drawing.Size(150, 20);
            this.DtTO.TabIndex = 231;
            // 
            // LblTo
            // 
            this.LblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTo.AutoSize = true;
            this.LblTo.Location = new System.Drawing.Point(348, 73);
            this.LblTo.Name = "LblTo";
            this.LblTo.Size = new System.Drawing.Size(29, 13);
            this.LblTo.TabIndex = 230;
            this.LblTo.Text = ":الى ";
            // 
            // DTFrom
            // 
            this.DTFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DTFrom.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DTFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTFrom.Location = new System.Drawing.Point(178, 39);
            this.DTFrom.Name = "DTFrom";
            this.DTFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTFrom.RightToLeftLayout = true;
            this.DTFrom.Size = new System.Drawing.Size(150, 20);
            this.DTFrom.TabIndex = 229;
            // 
            // LblFrom
            // 
            this.LblFrom.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblFrom.AutoSize = true;
            this.LblFrom.Location = new System.Drawing.Point(348, 41);
            this.LblFrom.Name = "LblFrom";
            this.LblFrom.Size = new System.Drawing.Size(22, 13);
            this.LblFrom.TabIndex = 228;
            this.LblFrom.Text = ":من";
            // 
            // PicSearch
            // 
            this.PicSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PicSearch.Image = global::I_Count.Properties.Resources.Magnifier_icon;
            this.PicSearch.Location = new System.Drawing.Point(108, 39);
            this.PicSearch.Name = "PicSearch";
            this.PicSearch.Size = new System.Drawing.Size(50, 53);
            this.PicSearch.TabIndex = 2;
            this.PicSearch.TabStop = false;
            this.PicSearch.Click += new System.EventHandler(this.PicSearch_Click);
            this.PicSearch.MouseLeave += new System.EventHandler(this.PicSearch_MouseLeave);
            this.PicSearch.MouseHover += new System.EventHandler(this.PicSearch_MouseHover);
            // 
            // PicMonth
            // 
            this.PicMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PicMonth.Image = global::I_Count.Properties.Resources.month;
            this.PicMonth.Location = new System.Drawing.Point(462, 12);
            this.PicMonth.Name = "PicMonth";
            this.PicMonth.Size = new System.Drawing.Size(102, 94);
            this.PicMonth.TabIndex = 1;
            this.PicMonth.TabStop = false;
            this.PicMonth.Click += new System.EventHandler(this.PicMonth_Click);
            this.PicMonth.MouseLeave += new System.EventHandler(this.PicMonth_MouseLeave);
            this.PicMonth.MouseHover += new System.EventHandler(this.PicMonth_MouseHover);
            // 
            // PicDay
            // 
            this.PicDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PicDay.Image = global::I_Count.Properties.Resources.Day;
            this.PicDay.Location = new System.Drawing.Point(684, 12);
            this.PicDay.Name = "PicDay";
            this.PicDay.Size = new System.Drawing.Size(100, 94);
            this.PicDay.TabIndex = 0;
            this.PicDay.TabStop = false;
            this.PicDay.Click += new System.EventHandler(this.PicDay_Click);
            this.PicDay.MouseLeave += new System.EventHandler(this.PicDay_MouseLeave);
            this.PicDay.MouseHover += new System.EventHandler(this.PicDay_MouseHover);
            // 
            // PanFooter
            // 
            this.PanFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PanFooter.Controls.Add(this.label1);
            this.PanFooter.Controls.Add(this.LblTotalExpenses);
            this.PanFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanFooter.Location = new System.Drawing.Point(0, 432);
            this.PanFooter.Name = "PanFooter";
            this.PanFooter.Size = new System.Drawing.Size(841, 71);
            this.PanFooter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(482, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "اجمالى المصروفات";
            // 
            // LblTotalExpenses
            // 
            this.LblTotalExpenses.AutoSize = true;
            this.LblTotalExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalExpenses.ForeColor = System.Drawing.Color.White;
            this.LblTotalExpenses.Location = new System.Drawing.Point(262, 24);
            this.LblTotalExpenses.Name = "LblTotalExpenses";
            this.LblTotalExpenses.Size = new System.Drawing.Size(0, 18);
            this.LblTotalExpenses.TabIndex = 0;
            // 
            // PanShow
            // 
            this.PanShow.BackColor = System.Drawing.Color.Gray;
            this.PanShow.Controls.Add(this.GvExpenses);
            this.PanShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanShow.Location = new System.Drawing.Point(0, 135);
            this.PanShow.Name = "PanShow";
            this.PanShow.Size = new System.Drawing.Size(841, 297);
            this.PanShow.TabIndex = 2;
            // 
            // GvExpenses
            // 
            this.GvExpenses.AllowUserToAddRows = false;
            this.GvExpenses.AllowUserToDeleteRows = false;
            this.GvExpenses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GvExpenses.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.GvExpenses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GvExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvExpenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Expenses,
            this.ExPre,
            this.ExDate,
            this.ExUser,
            this.ExpensesID,
            this.Store});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GvExpenses.DefaultCellStyle = dataGridViewCellStyle1;
            this.GvExpenses.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.GvExpenses.Location = new System.Drawing.Point(15, 9);
            this.GvExpenses.Name = "GvExpenses";
            this.GvExpenses.ReadOnly = true;
            this.GvExpenses.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GvExpenses.Size = new System.Drawing.Size(814, 270);
            this.GvExpenses.TabIndex = 229;
            this.GvExpenses.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GvExpenses_RowHeaderMouseClick);
            this.GvExpenses.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.GvExpenses_RowsAdded);
            // 
            // Expenses
            // 
            this.Expenses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Expenses.HeaderText = "القيمه";
            this.Expenses.Name = "Expenses";
            this.Expenses.ReadOnly = true;
            // 
            // ExPre
            // 
            this.ExPre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ExPre.HeaderText = "البيان";
            this.ExPre.Name = "ExPre";
            this.ExPre.ReadOnly = true;
            // 
            // ExDate
            // 
            this.ExDate.HeaderText = "التاريخ";
            this.ExDate.Name = "ExDate";
            this.ExDate.ReadOnly = true;
            this.ExDate.Width = 192;
            // 
            // ExUser
            // 
            this.ExUser.HeaderText = "المستخدم";
            this.ExUser.Name = "ExUser";
            this.ExUser.ReadOnly = true;
            this.ExUser.Width = 193;
            // 
            // ExpensesID
            // 
            this.ExpensesID.HeaderText = "ID";
            this.ExpensesID.Name = "ExpensesID";
            this.ExpensesID.ReadOnly = true;
            this.ExpensesID.Visible = false;
            // 
            // Store
            // 
            this.Store.HeaderText = "الفرع";
            this.Store.Name = "Store";
            this.Store.ReadOnly = true;
            // 
            // ReportExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(841, 503);
            this.Controls.Add(this.PanShow);
            this.Controls.Add(this.PanFooter);
            this.Controls.Add(this.PanHead);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReportExpenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقرير المصروفات";
            this.Load += new System.EventHandler(this.ReportExpenses_Load);
            this.PanHead.ResumeLayout(false);
            this.PanHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDay)).EndInit();
            this.PanFooter.ResumeLayout(false);
            this.PanFooter.PerformLayout();
            this.PanShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GvExpenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanHead;
        private System.Windows.Forms.Panel PanFooter;
        private System.Windows.Forms.Panel PanShow;
        private System.Windows.Forms.PictureBox PicSearch;
        private System.Windows.Forms.PictureBox PicMonth;
        private System.Windows.Forms.PictureBox PicDay;
        private System.Windows.Forms.DateTimePicker DtTO;
        private System.Windows.Forms.Label LblTo;
        private System.Windows.Forms.DateTimePicker DTFrom;
        private System.Windows.Forms.Label LblFrom;
        private System.Windows.Forms.Label LblMonth;
        private System.Windows.Forms.Label LblDay;
        private System.Windows.Forms.Label LblSearch;
        private System.Windows.Forms.DataGridView GvExpenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblTotalExpenses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expenses;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExPre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpensesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Store;
    }
}
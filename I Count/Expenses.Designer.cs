namespace I_Count
{
    partial class Expenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Expenses));
            this.LblValue = new System.Windows.Forms.Label();
            this.TxtValue = new System.Windows.Forms.TextBox();
            this.TxtReason = new System.Windows.Forms.TextBox();
            this.LblReason = new System.Windows.Forms.Label();
            this.DTB2 = new System.Windows.Forms.DateTimePicker();
            this.DTB1 = new System.Windows.Forms.DateTimePicker();
            this.LblTo = new System.Windows.Forms.Label();
            this.LblFrom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GVExpenses = new System.Windows.Forms.DataGridView();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpensesDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblUserID = new System.Windows.Forms.Label();
            this.LblUserName = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.LblExpenses = new System.Windows.Forms.Label();
            this.LblIncome = new System.Windows.Forms.Label();
            this.BtnAddIncome = new System.Windows.Forms.Button();
            this.LblStore = new System.Windows.Forms.Label();
            this.CBStore = new System.Windows.Forms.ComboBox();
            this.BtnSearchIncome = new System.Windows.Forms.Button();
            this.LblSeExpenses = new System.Windows.Forms.Label();
            this.LblSeIncom = new System.Windows.Forms.Label();
            this.PanDate = new System.Windows.Forms.Panel();
            this.PicBack = new System.Windows.Forms.PictureBox();
            this.PicSeIncome = new System.Windows.Forms.PictureBox();
            this.PicSeExpenses = new System.Windows.Forms.PictureBox();
            this.PicAddIncome = new System.Windows.Forms.PictureBox();
            this.PicAddExpenses = new System.Windows.Forms.PictureBox();
            this.Pichome = new System.Windows.Forms.PictureBox();
            this.LblPostion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GVExpenses)).BeginInit();
            this.PanDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSeIncome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSeExpenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicAddIncome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicAddExpenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pichome)).BeginInit();
            this.SuspendLayout();
            // 
            // LblValue
            // 
            this.LblValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblValue.AutoSize = true;
            this.LblValue.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblValue.Font = new System.Drawing.Font("Tahoma", 12F);
            this.LblValue.ForeColor = System.Drawing.Color.Gainsboro;
            this.LblValue.Location = new System.Drawing.Point(950, 71);
            this.LblValue.Name = "LblValue";
            this.LblValue.Size = new System.Drawing.Size(51, 19);
            this.LblValue.TabIndex = 147;
            this.LblValue.Text = "القيمه";
            this.LblValue.Visible = false;
            // 
            // TxtValue
            // 
            this.TxtValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtValue.BackColor = System.Drawing.Color.White;
            this.TxtValue.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TxtValue.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TxtValue.Location = new System.Drawing.Point(783, 69);
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.Size = new System.Drawing.Size(124, 25);
            this.TxtValue.TabIndex = 148;
            this.TxtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtValue.Visible = false;
            // 
            // TxtReason
            // 
            this.TxtReason.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtReason.BackColor = System.Drawing.Color.White;
            this.TxtReason.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TxtReason.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TxtReason.Location = new System.Drawing.Point(444, 61);
            this.TxtReason.MaxLength = 100;
            this.TxtReason.Multiline = true;
            this.TxtReason.Name = "TxtReason";
            this.TxtReason.Size = new System.Drawing.Size(198, 52);
            this.TxtReason.TabIndex = 150;
            this.TxtReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtReason.Visible = false;
            // 
            // LblReason
            // 
            this.LblReason.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblReason.AutoSize = true;
            this.LblReason.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblReason.Font = new System.Drawing.Font("Tahoma", 12F);
            this.LblReason.ForeColor = System.Drawing.Color.Gainsboro;
            this.LblReason.Location = new System.Drawing.Point(683, 71);
            this.LblReason.Name = "LblReason";
            this.LblReason.Size = new System.Drawing.Size(46, 19);
            this.LblReason.TabIndex = 149;
            this.LblReason.Text = "البيان";
            this.LblReason.Visible = false;
            // 
            // DTB2
            // 
            this.DTB2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DTB2.CalendarForeColor = System.Drawing.Color.Teal;
            this.DTB2.CalendarMonthBackground = System.Drawing.Color.Teal;
            this.DTB2.CalendarTitleBackColor = System.Drawing.Color.Silver;
            this.DTB2.CalendarTitleForeColor = System.Drawing.Color.Teal;
            this.DTB2.CalendarTrailingForeColor = System.Drawing.Color.Teal;
            this.DTB2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.DTB2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTB2.Location = new System.Drawing.Point(10, 15);
            this.DTB2.Name = "DTB2";
            this.DTB2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTB2.RightToLeftLayout = true;
            this.DTB2.Size = new System.Drawing.Size(200, 24);
            this.DTB2.TabIndex = 163;
            // 
            // DTB1
            // 
            this.DTB1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DTB1.CalendarFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTB1.CalendarForeColor = System.Drawing.Color.Teal;
            this.DTB1.CalendarMonthBackground = System.Drawing.Color.Teal;
            this.DTB1.CalendarTitleBackColor = System.Drawing.Color.Silver;
            this.DTB1.CalendarTitleForeColor = System.Drawing.Color.Teal;
            this.DTB1.CalendarTrailingForeColor = System.Drawing.Color.Teal;
            this.DTB1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.DTB1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTB1.Location = new System.Drawing.Point(283, 14);
            this.DTB1.Name = "DTB1";
            this.DTB1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTB1.RightToLeftLayout = true;
            this.DTB1.Size = new System.Drawing.Size(200, 24);
            this.DTB1.TabIndex = 162;
            // 
            // LblTo
            // 
            this.LblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTo.AutoSize = true;
            this.LblTo.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTo.ForeColor = System.Drawing.Color.White;
            this.LblTo.Location = new System.Drawing.Point(232, 17);
            this.LblTo.Name = "LblTo";
            this.LblTo.Size = new System.Drawing.Size(34, 22);
            this.LblTo.TabIndex = 161;
            this.LblTo.Text = "الى ";
            // 
            // LblFrom
            // 
            this.LblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblFrom.AutoSize = true;
            this.LblFrom.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFrom.ForeColor = System.Drawing.Color.White;
            this.LblFrom.Location = new System.Drawing.Point(494, 15);
            this.LblFrom.Name = "LblFrom";
            this.LblFrom.Size = new System.Drawing.Size(27, 22);
            this.LblFrom.TabIndex = 160;
            this.LblFrom.Text = "من";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(541, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 22);
            this.label1.TabIndex = 164;
            this.label1.Text = "بحث ب التاريخ";
            // 
            // GVExpenses
            // 
            this.GVExpenses.AllowUserToAddRows = false;
            this.GVExpenses.AllowUserToDeleteRows = false;
            this.GVExpenses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GVExpenses.BackgroundColor = System.Drawing.Color.DarkSlateBlue;
            this.GVExpenses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GVExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVExpenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Value,
            this.Reason,
            this.ExpensesDate,
            this.UserName});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GVExpenses.DefaultCellStyle = dataGridViewCellStyle1;
            this.GVExpenses.GridColor = System.Drawing.Color.DarkSlateBlue;
            this.GVExpenses.Location = new System.Drawing.Point(97, 319);
            this.GVExpenses.Name = "GVExpenses";
            this.GVExpenses.ReadOnly = true;
            this.GVExpenses.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GVExpenses.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.GVExpenses.Size = new System.Drawing.Size(1075, 209);
            this.GVExpenses.TabIndex = 166;
            this.GVExpenses.Visible = false;
            // 
            // Value
            // 
            this.Value.HeaderText = "القيمه";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // Reason
            // 
            this.Reason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Reason.HeaderText = "البيان";
            this.Reason.Name = "Reason";
            this.Reason.ReadOnly = true;
            // 
            // ExpensesDate
            // 
            this.ExpensesDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ExpensesDate.HeaderText = "التاريخ";
            this.ExpensesDate.Name = "ExpensesDate";
            this.ExpensesDate.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "المستخدم";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // LblUserID
            // 
            this.LblUserID.AutoSize = true;
            this.LblUserID.Location = new System.Drawing.Point(32, 130);
            this.LblUserID.Name = "LblUserID";
            this.LblUserID.Size = new System.Drawing.Size(0, 13);
            this.LblUserID.TabIndex = 167;
            this.LblUserID.Visible = false;
            // 
            // LblUserName
            // 
            this.LblUserName.AutoSize = true;
            this.LblUserName.Location = new System.Drawing.Point(5, 185);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(0, 13);
            this.LblUserName.TabIndex = 168;
            this.LblUserName.Visible = false;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.ForeColor = System.Drawing.Color.White;
            this.BtnSearch.Location = new System.Drawing.Point(1, 253);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(1173, 56);
            this.BtnSearch.TabIndex = 165;
            this.BtnSearch.Text = "بحث فى المصروفات";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Visible = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(257, 129);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(631, 49);
            this.BtnAdd.TabIndex = 151;
            this.BtnAdd.Text = "إضافه";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Visible = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // LblExpenses
            // 
            this.LblExpenses.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblExpenses.AutoSize = true;
            this.LblExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblExpenses.Font = new System.Drawing.Font("Tahoma", 12F);
            this.LblExpenses.ForeColor = System.Drawing.Color.White;
            this.LblExpenses.Location = new System.Drawing.Point(640, 158);
            this.LblExpenses.Name = "LblExpenses";
            this.LblExpenses.Size = new System.Drawing.Size(110, 19);
            this.LblExpenses.TabIndex = 170;
            this.LblExpenses.Text = "إضافة مصروفات";
            this.LblExpenses.Visible = false;
            // 
            // LblIncome
            // 
            this.LblIncome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblIncome.AutoSize = true;
            this.LblIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblIncome.Font = new System.Drawing.Font("Tahoma", 12F);
            this.LblIncome.ForeColor = System.Drawing.Color.White;
            this.LblIncome.Location = new System.Drawing.Point(431, 158);
            this.LblIncome.Name = "LblIncome";
            this.LblIncome.Size = new System.Drawing.Size(77, 19);
            this.LblIncome.TabIndex = 243;
            this.LblIncome.Text = "إضافة إيراد";
            this.LblIncome.Visible = false;
            // 
            // BtnAddIncome
            // 
            this.BtnAddIncome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnAddIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddIncome.ForeColor = System.Drawing.Color.White;
            this.BtnAddIncome.Location = new System.Drawing.Point(257, 130);
            this.BtnAddIncome.Name = "BtnAddIncome";
            this.BtnAddIncome.Size = new System.Drawing.Size(631, 49);
            this.BtnAddIncome.TabIndex = 244;
            this.BtnAddIncome.Text = "إضافه";
            this.BtnAddIncome.UseVisualStyleBackColor = true;
            this.BtnAddIncome.Visible = false;
            this.BtnAddIncome.Click += new System.EventHandler(this.BtnAddIncome_Click);
            // 
            // LblStore
            // 
            this.LblStore.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblStore.AutoSize = true;
            this.LblStore.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblStore.Font = new System.Drawing.Font("Tahoma", 12F);
            this.LblStore.ForeColor = System.Drawing.Color.Gainsboro;
            this.LblStore.Location = new System.Drawing.Point(328, 71);
            this.LblStore.Name = "LblStore";
            this.LblStore.Size = new System.Drawing.Size(49, 19);
            this.LblStore.TabIndex = 245;
            this.LblStore.Text = "الخزنه";
            this.LblStore.Visible = false;
            // 
            // CBStore
            // 
            this.CBStore.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CBStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBStore.Font = new System.Drawing.Font("Tahoma", 10F);
            this.CBStore.FormattingEnabled = true;
            this.CBStore.Location = new System.Drawing.Point(57, 69);
            this.CBStore.Name = "CBStore";
            this.CBStore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CBStore.Size = new System.Drawing.Size(254, 24);
            this.CBStore.TabIndex = 246;
            this.CBStore.Visible = false;
            // 
            // BtnSearchIncome
            // 
            this.BtnSearchIncome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnSearchIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchIncome.ForeColor = System.Drawing.Color.White;
            this.BtnSearchIncome.Location = new System.Drawing.Point(3, 252);
            this.BtnSearchIncome.Name = "BtnSearchIncome";
            this.BtnSearchIncome.Size = new System.Drawing.Size(1173, 56);
            this.BtnSearchIncome.TabIndex = 247;
            this.BtnSearchIncome.Text = "بحث فى الإيراد";
            this.BtnSearchIncome.UseVisualStyleBackColor = true;
            this.BtnSearchIncome.Visible = false;
            this.BtnSearchIncome.Click += new System.EventHandler(this.BtnSearchIncome_Click);
            // 
            // LblSeExpenses
            // 
            this.LblSeExpenses.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblSeExpenses.AutoSize = true;
            this.LblSeExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblSeExpenses.Font = new System.Drawing.Font("Tahoma", 12F);
            this.LblSeExpenses.ForeColor = System.Drawing.Color.White;
            this.LblSeExpenses.Location = new System.Drawing.Point(1038, 226);
            this.LblSeExpenses.Name = "LblSeExpenses";
            this.LblSeExpenses.Size = new System.Drawing.Size(142, 19);
            this.LblSeExpenses.TabIndex = 249;
            this.LblSeExpenses.Text = "بحث فى المصروفات";
            this.LblSeExpenses.Visible = false;
            // 
            // LblSeIncom
            // 
            this.LblSeIncom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblSeIncom.AutoSize = true;
            this.LblSeIncom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblSeIncom.Font = new System.Drawing.Font("Tahoma", 12F);
            this.LblSeIncom.ForeColor = System.Drawing.Color.White;
            this.LblSeIncom.Location = new System.Drawing.Point(901, 226);
            this.LblSeIncom.Name = "LblSeIncom";
            this.LblSeIncom.Size = new System.Drawing.Size(125, 19);
            this.LblSeIncom.TabIndex = 251;
            this.LblSeIncom.Text = "بحث فى الايرادات";
            this.LblSeIncom.Visible = false;
            // 
            // PanDate
            // 
            this.PanDate.Controls.Add(this.DTB1);
            this.PanDate.Controls.Add(this.LblFrom);
            this.PanDate.Controls.Add(this.LblTo);
            this.PanDate.Controls.Add(this.DTB2);
            this.PanDate.Controls.Add(this.label1);
            this.PanDate.Location = new System.Drawing.Point(188, 185);
            this.PanDate.Name = "PanDate";
            this.PanDate.Size = new System.Drawing.Size(672, 51);
            this.PanDate.TabIndex = 252;
            this.PanDate.Visible = false;
            // 
            // PicBack
            // 
            this.PicBack.Image = global::I_Count.Properties.Resources.back;
            this.PicBack.Location = new System.Drawing.Point(8, 99);
            this.PicBack.Name = "PicBack";
            this.PicBack.Size = new System.Drawing.Size(93, 101);
            this.PicBack.TabIndex = 253;
            this.PicBack.TabStop = false;
            this.PicBack.Visible = false;
            this.PicBack.Click += new System.EventHandler(this.PicBack_Click);
            // 
            // PicSeIncome
            // 
            this.PicSeIncome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PicSeIncome.Image = global::I_Count.Properties.Resources.searchincome;
            this.PicSeIncome.Location = new System.Drawing.Point(911, 129);
            this.PicSeIncome.Name = "PicSeIncome";
            this.PicSeIncome.Size = new System.Drawing.Size(110, 94);
            this.PicSeIncome.TabIndex = 250;
            this.PicSeIncome.TabStop = false;
            this.PicSeIncome.Click += new System.EventHandler(this.PicSeIncome_Click);
            this.PicSeIncome.MouseLeave += new System.EventHandler(this.PicSeIncome_MouseLeave);
            this.PicSeIncome.MouseHover += new System.EventHandler(this.PicSeIncome_MouseHover);
            // 
            // PicSeExpenses
            // 
            this.PicSeExpenses.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PicSeExpenses.Image = global::I_Count.Properties.Resources.searchexpenses;
            this.PicSeExpenses.Location = new System.Drawing.Point(1056, 129);
            this.PicSeExpenses.Name = "PicSeExpenses";
            this.PicSeExpenses.Size = new System.Drawing.Size(110, 94);
            this.PicSeExpenses.TabIndex = 248;
            this.PicSeExpenses.TabStop = false;
            this.PicSeExpenses.Click += new System.EventHandler(this.PicSeExpenses_Click);
            this.PicSeExpenses.MouseLeave += new System.EventHandler(this.PicSeExpenses_MouseLeave);
            this.PicSeExpenses.MouseHover += new System.EventHandler(this.PicSeExpenses_MouseHover);
            // 
            // PicAddIncome
            // 
            this.PicAddIncome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PicAddIncome.Image = global::I_Count.Properties.Resources.income;
            this.PicAddIncome.Location = new System.Drawing.Point(372, 3);
            this.PicAddIncome.Name = "PicAddIncome";
            this.PicAddIncome.Size = new System.Drawing.Size(198, 154);
            this.PicAddIncome.TabIndex = 242;
            this.PicAddIncome.TabStop = false;
            this.PicAddIncome.Click += new System.EventHandler(this.PicAddIncome_Click);
            this.PicAddIncome.MouseLeave += new System.EventHandler(this.PicAddIncome_MouseLeave);
            this.PicAddIncome.MouseHover += new System.EventHandler(this.PicAddIncome_MouseHover);
            // 
            // PicAddExpenses
            // 
            this.PicAddExpenses.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PicAddExpenses.Image = global::I_Count.Properties.Resources.expensesadd;
            this.PicAddExpenses.Location = new System.Drawing.Point(600, 3);
            this.PicAddExpenses.Name = "PicAddExpenses";
            this.PicAddExpenses.Size = new System.Drawing.Size(198, 154);
            this.PicAddExpenses.TabIndex = 169;
            this.PicAddExpenses.TabStop = false;
            this.PicAddExpenses.Click += new System.EventHandler(this.BtnExpenses_Click);
            this.PicAddExpenses.MouseLeave += new System.EventHandler(this.PicAddExpenses_MouseLeave);
            this.PicAddExpenses.MouseHover += new System.EventHandler(this.PicAddExpenses_MouseHover);
            // 
            // Pichome
            // 
            this.Pichome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Pichome.Image = global::I_Count.Properties.Resources.esrede;
            this.Pichome.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Pichome.Location = new System.Drawing.Point(1, 444);
            this.Pichome.Name = "Pichome";
            this.Pichome.Size = new System.Drawing.Size(100, 95);
            this.Pichome.TabIndex = 241;
            this.Pichome.TabStop = false;
            this.Pichome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // LblPostion
            // 
            this.LblPostion.AutoSize = true;
            this.LblPostion.Location = new System.Drawing.Point(47, 13);
            this.LblPostion.Name = "LblPostion";
            this.LblPostion.Size = new System.Drawing.Size(0, 13);
            this.LblPostion.TabIndex = 254;
            this.LblPostion.Visible = false;
            // 
            // Expenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1178, 540);
            this.Controls.Add(this.LblPostion);
            this.Controls.Add(this.PicBack);
            this.Controls.Add(this.PanDate);
            this.Controls.Add(this.PicSeIncome);
            this.Controls.Add(this.LblSeIncom);
            this.Controls.Add(this.PicSeExpenses);
            this.Controls.Add(this.LblSeExpenses);
            this.Controls.Add(this.CBStore);
            this.Controls.Add(this.LblStore);
            this.Controls.Add(this.PicAddIncome);
            this.Controls.Add(this.PicAddExpenses);
            this.Controls.Add(this.LblIncome);
            this.Controls.Add(this.LblExpenses);
            this.Controls.Add(this.LblUserName);
            this.Controls.Add(this.LblUserID);
            this.Controls.Add(this.GVExpenses);
            this.Controls.Add(this.TxtReason);
            this.Controls.Add(this.LblReason);
            this.Controls.Add(this.TxtValue);
            this.Controls.Add(this.LblValue);
            this.Controls.Add(this.Pichome);
            this.Controls.Add(this.BtnSearchIncome);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnAddIncome);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Expenses";
            this.Text = "المصرفات والايرادات";
            this.Load += new System.EventHandler(this.Expenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GVExpenses)).EndInit();
            this.PanDate.ResumeLayout(false);
            this.PanDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSeIncome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSeExpenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicAddIncome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicAddExpenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pichome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblValue;
        private System.Windows.Forms.TextBox TxtValue;
        private System.Windows.Forms.TextBox TxtReason;
        private System.Windows.Forms.Label LblReason;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.DateTimePicker DTB2;
        private System.Windows.Forms.DateTimePicker DTB1;
        private System.Windows.Forms.Label LblTo;
        private System.Windows.Forms.Label LblFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.DataGridView GVExpenses;
        private System.Windows.Forms.Label LblUserID;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.PictureBox PicAddExpenses;
        private System.Windows.Forms.Label LblExpenses;
        private System.Windows.Forms.PictureBox Pichome;
        private System.Windows.Forms.Label LblIncome;
        private System.Windows.Forms.PictureBox PicAddIncome;
        private System.Windows.Forms.Button BtnAddIncome;
        private System.Windows.Forms.Label LblStore;
        private System.Windows.Forms.ComboBox CBStore;
        private System.Windows.Forms.Button BtnSearchIncome;
        private System.Windows.Forms.PictureBox PicSeExpenses;
        private System.Windows.Forms.Label LblSeExpenses;
        private System.Windows.Forms.PictureBox PicSeIncome;
        private System.Windows.Forms.Label LblSeIncom;
        private System.Windows.Forms.Panel PanDate;
        private System.Windows.Forms.PictureBox PicBack;
        private System.Windows.Forms.Label LblPostion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpensesDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
    }
}
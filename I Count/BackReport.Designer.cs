namespace I_Count
{
    partial class BackReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackReport));
            this.BtnCustomers = new System.Windows.Forms.Button();
            this.BtnProviders = new System.Windows.Forms.Button();
            this.PanCustomer = new System.Windows.Forms.Panel();
            this.LblCCridet = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblCDebit = new System.Windows.Forms.Label();
            this.lanc = new System.Windows.Forms.Label();
            this.LblCustName = new System.Windows.Forms.Label();
            this.CBCustomerName = new System.Windows.Forms.ComboBox();
            this.DVShowCustomer = new System.Windows.Forms.DataGridView();
            this.CDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblUserID = new System.Windows.Forms.Label();
            this.LblUserName = new System.Windows.Forms.Label();
            this.LblPostion = new System.Windows.Forms.Label();
            this.PanProvider = new System.Windows.Forms.Panel();
            this.Lblprocr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblPRodri = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CBProvider = new System.Windows.Forms.ComboBox();
            this.GVProvider = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pichome = new System.Windows.Forms.PictureBox();
            this.BtnCUPrint = new System.Windows.Forms.Button();
            this.BtnProPrint = new System.Windows.Forms.Button();
            this.PanCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DVShowCustomer)).BeginInit();
            this.PanProvider.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pichome)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCustomers
            // 
            this.BtnCustomers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCustomers.ForeColor = System.Drawing.Color.White;
            this.BtnCustomers.Location = new System.Drawing.Point(615, 34);
            this.BtnCustomers.Name = "BtnCustomers";
            this.BtnCustomers.Size = new System.Drawing.Size(174, 49);
            this.BtnCustomers.TabIndex = 0;
            this.BtnCustomers.Text = "العملاء ";
            this.BtnCustomers.UseVisualStyleBackColor = true;
            this.BtnCustomers.Click += new System.EventHandler(this.BtnCustomers_Click);
            // 
            // BtnProviders
            // 
            this.BtnProviders.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnProviders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProviders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProviders.ForeColor = System.Drawing.Color.White;
            this.BtnProviders.Location = new System.Drawing.Point(382, 34);
            this.BtnProviders.Name = "BtnProviders";
            this.BtnProviders.Size = new System.Drawing.Size(174, 49);
            this.BtnProviders.TabIndex = 1;
            this.BtnProviders.Text = "الموردين";
            this.BtnProviders.UseVisualStyleBackColor = true;
            this.BtnProviders.Click += new System.EventHandler(this.BtnProviders_Click);
            // 
            // PanCustomer
            // 
            this.PanCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanCustomer.Controls.Add(this.BtnCUPrint);
            this.PanCustomer.Controls.Add(this.LblCCridet);
            this.PanCustomer.Controls.Add(this.label2);
            this.PanCustomer.Controls.Add(this.LblCDebit);
            this.PanCustomer.Controls.Add(this.lanc);
            this.PanCustomer.Controls.Add(this.LblCustName);
            this.PanCustomer.Controls.Add(this.CBCustomerName);
            this.PanCustomer.Controls.Add(this.DVShowCustomer);
            this.PanCustomer.Location = new System.Drawing.Point(12, 139);
            this.PanCustomer.Name = "PanCustomer";
            this.PanCustomer.Size = new System.Drawing.Size(1214, 452);
            this.PanCustomer.TabIndex = 2;
            this.PanCustomer.Visible = false;
            // 
            // LblCCridet
            // 
            this.LblCCridet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCCridet.AutoSize = true;
            this.LblCCridet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCCridet.ForeColor = System.Drawing.Color.White;
            this.LblCCridet.Location = new System.Drawing.Point(575, 412);
            this.LblCCridet.Name = "LblCCridet";
            this.LblCCridet.Size = new System.Drawing.Size(0, 17);
            this.LblCCridet.TabIndex = 156;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(648, 412);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 155;
            this.label2.Text = "دائن";
            // 
            // LblCDebit
            // 
            this.LblCDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCDebit.AutoSize = true;
            this.LblCDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCDebit.ForeColor = System.Drawing.Color.White;
            this.LblCDebit.Location = new System.Drawing.Point(1050, 412);
            this.LblCDebit.Name = "LblCDebit";
            this.LblCDebit.Size = new System.Drawing.Size(0, 17);
            this.LblCDebit.TabIndex = 154;
            // 
            // lanc
            // 
            this.lanc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lanc.AutoSize = true;
            this.lanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lanc.ForeColor = System.Drawing.Color.White;
            this.lanc.Location = new System.Drawing.Point(1123, 412);
            this.lanc.Name = "lanc";
            this.lanc.Size = new System.Drawing.Size(28, 17);
            this.lanc.TabIndex = 153;
            this.lanc.Text = "مدين";
            // 
            // LblCustName
            // 
            this.LblCustName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCustName.AutoSize = true;
            this.LblCustName.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblCustName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCustName.ForeColor = System.Drawing.Color.White;
            this.LblCustName.Location = new System.Drawing.Point(691, 17);
            this.LblCustName.Name = "LblCustName";
            this.LblCustName.Size = new System.Drawing.Size(76, 22);
            this.LblCustName.TabIndex = 152;
            this.LblCustName.Text = "اسم العميل ";
            // 
            // CBCustomerName
            // 
            this.CBCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CBCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBCustomerName.BackColor = System.Drawing.Color.Silver;
            this.CBCustomerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBCustomerName.Font = new System.Drawing.Font("Tahoma", 11F);
            this.CBCustomerName.ForeColor = System.Drawing.Color.Teal;
            this.CBCustomerName.FormattingEnabled = true;
            this.CBCustomerName.Location = new System.Drawing.Point(504, 16);
            this.CBCustomerName.Name = "CBCustomerName";
            this.CBCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CBCustomerName.Size = new System.Drawing.Size(164, 26);
            this.CBCustomerName.TabIndex = 151;
            this.CBCustomerName.SelectionChangeCommitted += new System.EventHandler(this.CBCustomerName_SelectionChangeCommitted);
            this.CBCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBCustomerName_KeyDown);
            // 
            // DVShowCustomer
            // 
            this.DVShowCustomer.AllowUserToAddRows = false;
            this.DVShowCustomer.AllowUserToDeleteRows = false;
            this.DVShowCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DVShowCustomer.BackgroundColor = System.Drawing.Color.DarkSlateBlue;
            this.DVShowCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DVShowCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DVShowCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CDate,
            this.CReport,
            this.CValue});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DVShowCustomer.DefaultCellStyle = dataGridViewCellStyle1;
            this.DVShowCustomer.Location = new System.Drawing.Point(13, 62);
            this.DVShowCustomer.Name = "DVShowCustomer";
            this.DVShowCustomer.ReadOnly = true;
            this.DVShowCustomer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DVShowCustomer.Size = new System.Drawing.Size(1183, 343);
            this.DVShowCustomer.TabIndex = 0;
            // 
            // CDate
            // 
            this.CDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CDate.HeaderText = "التاريخ";
            this.CDate.Name = "CDate";
            this.CDate.ReadOnly = true;
            // 
            // CReport
            // 
            this.CReport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CReport.HeaderText = "البيان";
            this.CReport.Name = "CReport";
            this.CReport.ReadOnly = true;
            // 
            // CValue
            // 
            this.CValue.HeaderText = "القيمه";
            this.CValue.Name = "CValue";
            this.CValue.ReadOnly = true;
            // 
            // LblUserID
            // 
            this.LblUserID.AutoSize = true;
            this.LblUserID.Location = new System.Drawing.Point(52, 69);
            this.LblUserID.Name = "LblUserID";
            this.LblUserID.Size = new System.Drawing.Size(0, 13);
            this.LblUserID.TabIndex = 3;
            this.LblUserID.Visible = false;
            // 
            // LblUserName
            // 
            this.LblUserName.AutoSize = true;
            this.LblUserName.Location = new System.Drawing.Point(190, 69);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(0, 13);
            this.LblUserName.TabIndex = 4;
            this.LblUserName.Visible = false;
            // 
            // LblPostion
            // 
            this.LblPostion.AutoSize = true;
            this.LblPostion.Location = new System.Drawing.Point(25, 69);
            this.LblPostion.Name = "LblPostion";
            this.LblPostion.Size = new System.Drawing.Size(0, 13);
            this.LblPostion.TabIndex = 5;
            this.LblPostion.Visible = false;
            // 
            // PanProvider
            // 
            this.PanProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanProvider.Controls.Add(this.BtnProPrint);
            this.PanProvider.Controls.Add(this.Lblprocr);
            this.PanProvider.Controls.Add(this.label3);
            this.PanProvider.Controls.Add(this.LblPRodri);
            this.PanProvider.Controls.Add(this.label5);
            this.PanProvider.Controls.Add(this.label6);
            this.PanProvider.Controls.Add(this.CBProvider);
            this.PanProvider.Controls.Add(this.GVProvider);
            this.PanProvider.Location = new System.Drawing.Point(7, 123);
            this.PanProvider.Name = "PanProvider";
            this.PanProvider.Size = new System.Drawing.Size(1219, 468);
            this.PanProvider.TabIndex = 179;
            this.PanProvider.Visible = false;
            // 
            // Lblprocr
            // 
            this.Lblprocr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lblprocr.AutoSize = true;
            this.Lblprocr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblprocr.ForeColor = System.Drawing.Color.White;
            this.Lblprocr.Location = new System.Drawing.Point(580, 424);
            this.Lblprocr.Name = "Lblprocr";
            this.Lblprocr.Size = new System.Drawing.Size(0, 17);
            this.Lblprocr.TabIndex = 163;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(653, 424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 162;
            this.label3.Text = "دائن";
            // 
            // LblPRodri
            // 
            this.LblPRodri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblPRodri.AutoSize = true;
            this.LblPRodri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPRodri.ForeColor = System.Drawing.Color.White;
            this.LblPRodri.Location = new System.Drawing.Point(1055, 424);
            this.LblPRodri.Name = "LblPRodri";
            this.LblPRodri.Size = new System.Drawing.Size(0, 17);
            this.LblPRodri.TabIndex = 161;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1128, 424);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 17);
            this.label5.TabIndex = 160;
            this.label5.Text = "مدين";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(643, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 22);
            this.label6.TabIndex = 159;
            this.label6.Text = "اسم المورد";
            // 
            // CBProvider
            // 
            this.CBProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CBProvider.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBProvider.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBProvider.BackColor = System.Drawing.Color.Silver;
            this.CBProvider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBProvider.Font = new System.Drawing.Font("Tahoma", 11F);
            this.CBProvider.ForeColor = System.Drawing.Color.Teal;
            this.CBProvider.FormattingEnabled = true;
            this.CBProvider.Location = new System.Drawing.Point(456, 28);
            this.CBProvider.Name = "CBProvider";
            this.CBProvider.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CBProvider.Size = new System.Drawing.Size(164, 26);
            this.CBProvider.TabIndex = 158;
            this.CBProvider.SelectionChangeCommitted += new System.EventHandler(this.CBProvider_SelectionChangeCommitted);
            this.CBProvider.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBProvider_KeyDown);
            // 
            // GVProvider
            // 
            this.GVProvider.AllowUserToAddRows = false;
            this.GVProvider.AllowUserToDeleteRows = false;
            this.GVProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GVProvider.BackgroundColor = System.Drawing.Color.DarkSlateBlue;
            this.GVProvider.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GVProvider.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVProvider.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GVProvider.DefaultCellStyle = dataGridViewCellStyle2;
            this.GVProvider.Location = new System.Drawing.Point(18, 74);
            this.GVProvider.Name = "GVProvider";
            this.GVProvider.ReadOnly = true;
            this.GVProvider.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GVProvider.Size = new System.Drawing.Size(1183, 343);
            this.GVProvider.TabIndex = 157;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "التاريخ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "البيان";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "القيمه";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Pichome
            // 
            this.Pichome.Image = global::I_Count.Properties.Resources.esrede;
            this.Pichome.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Pichome.Location = new System.Drawing.Point(0, 1);
            this.Pichome.Name = "Pichome";
            this.Pichome.Size = new System.Drawing.Size(100, 95);
            this.Pichome.TabIndex = 178;
            this.Pichome.TabStop = false;
            this.Pichome.Click += new System.EventHandler(this.Pichome_Click);
            // 
            // BtnCUPrint
            // 
            this.BtnCUPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnCUPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCUPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCUPrint.ForeColor = System.Drawing.Color.White;
            this.BtnCUPrint.Location = new System.Drawing.Point(291, 7);
            this.BtnCUPrint.Name = "BtnCUPrint";
            this.BtnCUPrint.Size = new System.Drawing.Size(174, 49);
            this.BtnCUPrint.TabIndex = 157;
            this.BtnCUPrint.Text = "طباعة التقرير";
            this.BtnCUPrint.UseVisualStyleBackColor = true;
            this.BtnCUPrint.Click += new System.EventHandler(this.BtnCUPrint_Click);
            // 
            // BtnProPrint
            // 
            this.BtnProPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnProPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProPrint.ForeColor = System.Drawing.Color.White;
            this.BtnProPrint.Location = new System.Drawing.Point(227, 17);
            this.BtnProPrint.Name = "BtnProPrint";
            this.BtnProPrint.Size = new System.Drawing.Size(174, 49);
            this.BtnProPrint.TabIndex = 164;
            this.BtnProPrint.Text = "طباعة التقرير";
            this.BtnProPrint.UseVisualStyleBackColor = true;
            this.BtnProPrint.Click += new System.EventHandler(this.BtnProPrint_Click);
            // 
            // BackReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(1238, 603);
            this.Controls.Add(this.PanProvider);
            this.Controls.Add(this.Pichome);
            this.Controls.Add(this.LblPostion);
            this.Controls.Add(this.LblUserName);
            this.Controls.Add(this.LblUserID);
            this.Controls.Add(this.PanCustomer);
            this.Controls.Add(this.BtnProviders);
            this.Controls.Add(this.BtnCustomers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BackReport";
            this.Text = "الاجل ";
            this.Load += new System.EventHandler(this.BackReport_Load);
            this.PanCustomer.ResumeLayout(false);
            this.PanCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DVShowCustomer)).EndInit();
            this.PanProvider.ResumeLayout(false);
            this.PanProvider.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pichome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCustomers;
        private System.Windows.Forms.Button BtnProviders;
        private System.Windows.Forms.Panel PanCustomer;
        private System.Windows.Forms.DataGridView DVShowCustomer;
        private System.Windows.Forms.Label LblCustName;
        private System.Windows.Forms.ComboBox CBCustomerName;
        private System.Windows.Forms.Label LblUserID;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.Label LblPostion;
        private System.Windows.Forms.PictureBox Pichome;
        private System.Windows.Forms.Label LblCDebit;
        private System.Windows.Forms.Label lanc;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn CValue;
        private System.Windows.Forms.Label LblCCridet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanProvider;
        private System.Windows.Forms.Label Lblprocr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblPRodri;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CBProvider;
        private System.Windows.Forms.DataGridView GVProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button BtnCUPrint;
        private System.Windows.Forms.Button BtnProPrint;
    }
}
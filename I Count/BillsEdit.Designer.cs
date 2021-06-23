namespace I_Count
{
    partial class BillsEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillsEdit));
            this.LblUserID = new System.Windows.Forms.Label();
            this.LblUserName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBillNum = new System.Windows.Forms.TextBox();
            this.RDBAckOut = new System.Windows.Forms.RadioButton();
            this.RdBackin = new System.Windows.Forms.RadioButton();
            this.RdBuying = new System.Windows.Forms.RadioButton();
            this.RDBElling = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblCustName = new System.Windows.Forms.Label();
            this.CBCustomerName = new System.Windows.Forms.ComboBox();
            this.TxtPaid = new System.Windows.Forms.TextBox();
            this.LblDaen = new System.Windows.Forms.Label();
            this.TxtDiscount = new System.Windows.Forms.TextBox();
            this.LblMadeen = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.LblCompany = new System.Windows.Forms.Label();
            this.TxtDate = new System.Windows.Forms.TextBox();
            this.LblPhone = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GVShowBills = new System.Windows.Forms.DataGridView();
            this.ProcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pichome = new System.Windows.Forms.PictureBox();
            this.PicDone = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVShowBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pichome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDone)).BeginInit();
            this.SuspendLayout();
            // 
            // LblUserID
            // 
            this.LblUserID.AutoSize = true;
            this.LblUserID.Location = new System.Drawing.Point(28, 13);
            this.LblUserID.Name = "LblUserID";
            this.LblUserID.Size = new System.Drawing.Size(0, 13);
            this.LblUserID.TabIndex = 0;
            // 
            // LblUserName
            // 
            this.LblUserName.AutoSize = true;
            this.LblUserName.Location = new System.Drawing.Point(31, 57);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(0, 13);
            this.LblUserName.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.BtnSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtBillNum);
            this.panel1.Controls.Add(this.RDBAckOut);
            this.panel1.Controls.Add(this.RdBackin);
            this.panel1.Controls.Add(this.RdBuying);
            this.panel1.Controls.Add(this.RDBElling);
            this.panel1.Location = new System.Drawing.Point(31, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1162, 95);
            this.panel1.TabIndex = 2;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearch.ForeColor = System.Drawing.Color.White;
            this.BtnSearch.Location = new System.Drawing.Point(399, 54);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(122, 35);
            this.BtnSearch.TabIndex = 6;
            this.BtnSearch.Text = "بحث";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(716, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "رقم الفاتوره";
            // 
            // TxtBillNum
            // 
            this.TxtBillNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBillNum.BackColor = System.Drawing.Color.Silver;
            this.TxtBillNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBillNum.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.TxtBillNum.Location = new System.Drawing.Point(541, 61);
            this.TxtBillNum.Name = "TxtBillNum";
            this.TxtBillNum.Size = new System.Drawing.Size(166, 23);
            this.TxtBillNum.TabIndex = 4;
            this.TxtBillNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RDBAckOut
            // 
            this.RDBAckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RDBAckOut.AutoSize = true;
            this.RDBAckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDBAckOut.ForeColor = System.Drawing.Color.White;
            this.RDBAckOut.Location = new System.Drawing.Point(133, 20);
            this.RDBAckOut.Name = "RDBAckOut";
            this.RDBAckOut.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RDBAckOut.Size = new System.Drawing.Size(114, 21);
            this.RDBAckOut.TabIndex = 3;
            this.RDBAckOut.TabStop = true;
            this.RDBAckOut.Text = "فاتورة مرتجع شراء";
            this.RDBAckOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RDBAckOut.UseVisualStyleBackColor = true;
            // 
            // RdBackin
            // 
            this.RdBackin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RdBackin.AutoSize = true;
            this.RdBackin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdBackin.ForeColor = System.Drawing.Color.White;
            this.RdBackin.Location = new System.Drawing.Point(379, 20);
            this.RdBackin.Name = "RdBackin";
            this.RdBackin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RdBackin.Size = new System.Drawing.Size(106, 21);
            this.RdBackin.TabIndex = 2;
            this.RdBackin.TabStop = true;
            this.RdBackin.Text = "فاتورة مرتجع بيع ";
            this.RdBackin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdBackin.UseVisualStyleBackColor = true;
            // 
            // RdBuying
            // 
            this.RdBuying.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RdBuying.AutoSize = true;
            this.RdBuying.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdBuying.ForeColor = System.Drawing.Color.White;
            this.RdBuying.Location = new System.Drawing.Point(624, 20);
            this.RdBuying.Name = "RdBuying";
            this.RdBuying.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RdBuying.Size = new System.Drawing.Size(96, 21);
            this.RdBuying.TabIndex = 1;
            this.RdBuying.TabStop = true;
            this.RdBuying.Text = "فاتورة مشتريات";
            this.RdBuying.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdBuying.UseVisualStyleBackColor = true;
            // 
            // RDBElling
            // 
            this.RDBElling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RDBElling.AutoSize = true;
            this.RDBElling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDBElling.ForeColor = System.Drawing.Color.White;
            this.RDBElling.Location = new System.Drawing.Point(965, 20);
            this.RDBElling.Name = "RDBElling";
            this.RDBElling.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RDBElling.Size = new System.Drawing.Size(86, 21);
            this.RDBElling.TabIndex = 0;
            this.RDBElling.TabStop = true;
            this.RDBElling.Text = "فاتورة مبيعات";
            this.RDBElling.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RDBElling.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.PicDone);
            this.panel2.Controls.Add(this.LblCustName);
            this.panel2.Controls.Add(this.CBCustomerName);
            this.panel2.Controls.Add(this.TxtPaid);
            this.panel2.Controls.Add(this.LblDaen);
            this.panel2.Controls.Add(this.TxtDiscount);
            this.panel2.Controls.Add(this.LblMadeen);
            this.panel2.Controls.Add(this.TxtTotal);
            this.panel2.Controls.Add(this.LblCompany);
            this.panel2.Controls.Add(this.TxtDate);
            this.panel2.Controls.Add(this.LblPhone);
            this.panel2.Location = new System.Drawing.Point(31, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1162, 106);
            this.panel2.TabIndex = 3;
            // 
            // LblCustName
            // 
            this.LblCustName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCustName.AutoSize = true;
            this.LblCustName.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblCustName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCustName.ForeColor = System.Drawing.Color.White;
            this.LblCustName.Location = new System.Drawing.Point(1044, 20);
            this.LblCustName.Name = "LblCustName";
            this.LblCustName.Size = new System.Drawing.Size(100, 18);
            this.LblCustName.TabIndex = 173;
            this.LblCustName.Text = "اسم العميل/المورد ";
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
            this.CBCustomerName.Location = new System.Drawing.Point(862, 17);
            this.CBCustomerName.Name = "CBCustomerName";
            this.CBCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CBCustomerName.Size = new System.Drawing.Size(164, 26);
            this.CBCustomerName.TabIndex = 172;
            // 
            // TxtPaid
            // 
            this.TxtPaid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPaid.ForeColor = System.Drawing.Color.Teal;
            this.TxtPaid.Location = new System.Drawing.Point(37, 19);
            this.TxtPaid.Name = "TxtPaid";
            this.TxtPaid.Size = new System.Drawing.Size(87, 24);
            this.TxtPaid.TabIndex = 171;
            this.TxtPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblDaen
            // 
            this.LblDaen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblDaen.AutoSize = true;
            this.LblDaen.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblDaen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDaen.ForeColor = System.Drawing.Color.White;
            this.LblDaen.Location = new System.Drawing.Point(143, 19);
            this.LblDaen.Name = "LblDaen";
            this.LblDaen.Size = new System.Drawing.Size(44, 18);
            this.LblDaen.TabIndex = 170;
            this.LblDaen.Text = "المدفوع";
            // 
            // TxtDiscount
            // 
            this.TxtDiscount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDiscount.ForeColor = System.Drawing.Color.Teal;
            this.TxtDiscount.Location = new System.Drawing.Point(201, 19);
            this.TxtDiscount.Name = "TxtDiscount";
            this.TxtDiscount.Size = new System.Drawing.Size(87, 24);
            this.TxtDiscount.TabIndex = 169;
            this.TxtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblMadeen
            // 
            this.LblMadeen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblMadeen.AutoSize = true;
            this.LblMadeen.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblMadeen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMadeen.ForeColor = System.Drawing.Color.White;
            this.LblMadeen.Location = new System.Drawing.Point(307, 19);
            this.LblMadeen.Name = "LblMadeen";
            this.LblMadeen.Size = new System.Drawing.Size(41, 18);
            this.LblMadeen.TabIndex = 168;
            this.LblMadeen.Text = "الخصم";
            // 
            // TxtTotal
            // 
            this.TxtTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.ForeColor = System.Drawing.Color.Teal;
            this.TxtTotal.Location = new System.Drawing.Point(362, 19);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(135, 24);
            this.TxtTotal.TabIndex = 167;
            this.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblCompany
            // 
            this.LblCompany.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblCompany.AutoSize = true;
            this.LblCompany.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompany.ForeColor = System.Drawing.Color.White;
            this.LblCompany.Location = new System.Drawing.Point(503, 22);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(83, 18);
            this.LblCompany.TabIndex = 166;
            this.LblCompany.Text = "إجمالى الفاتوره";
            // 
            // TxtDate
            // 
            this.TxtDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtDate.Enabled = false;
            this.TxtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDate.ForeColor = System.Drawing.Color.Teal;
            this.TxtDate.Location = new System.Drawing.Point(606, 19);
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.Size = new System.Drawing.Size(135, 24);
            this.TxtDate.TabIndex = 165;
            this.TxtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblPhone
            // 
            this.LblPhone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblPhone.AutoSize = true;
            this.LblPhone.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPhone.ForeColor = System.Drawing.Color.White;
            this.LblPhone.Location = new System.Drawing.Point(764, 22);
            this.LblPhone.Name = "LblPhone";
            this.LblPhone.Size = new System.Drawing.Size(76, 18);
            this.LblPhone.TabIndex = 164;
            this.LblPhone.Text = "تاريخ الفاتوره";
            this.LblPhone.Click += new System.EventHandler(this.LblPhone_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.GVShowBills);
            this.panel3.Location = new System.Drawing.Point(107, 226);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1084, 305);
            this.panel3.TabIndex = 4;
            // 
            // GVShowBills
            // 
            this.GVShowBills.AllowUserToAddRows = false;
            this.GVShowBills.AllowUserToDeleteRows = false;
            this.GVShowBills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GVShowBills.BackgroundColor = System.Drawing.Color.DarkSlateBlue;
            this.GVShowBills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GVShowBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVShowBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcID,
            this.ProType,
            this.ProName,
            this.Quent,
            this.Price,
            this.Total});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GVShowBills.DefaultCellStyle = dataGridViewCellStyle1;
            this.GVShowBills.Location = new System.Drawing.Point(5, 3);
            this.GVShowBills.Name = "GVShowBills";
            this.GVShowBills.ReadOnly = true;
            this.GVShowBills.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GVShowBills.Size = new System.Drawing.Size(1075, 283);
            this.GVShowBills.TabIndex = 149;
            this.GVShowBills.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GVShowBills_RowHeaderMouseClick);
            // 
            // ProcID
            // 
            this.ProcID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProcID.HeaderText = "الرقم المسلسل";
            this.ProcID.Name = "ProcID";
            this.ProcID.ReadOnly = true;
            // 
            // ProType
            // 
            this.ProType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProType.HeaderText = "نوع الصنف";
            this.ProType.Name = "ProType";
            this.ProType.ReadOnly = true;
            // 
            // ProName
            // 
            this.ProName.HeaderText = "اسم الصنف";
            this.ProName.Name = "ProName";
            this.ProName.ReadOnly = true;
            // 
            // Quent
            // 
            this.Quent.HeaderText = "الكميه";
            this.Quent.Name = "Quent";
            this.Quent.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "السعر";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "القيمه";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Pichome
            // 
            this.Pichome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Pichome.Image = global::I_Count.Properties.Resources.esrede;
            this.Pichome.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Pichome.Location = new System.Drawing.Point(1, 449);
            this.Pichome.Name = "Pichome";
            this.Pichome.Size = new System.Drawing.Size(100, 95);
            this.Pichome.TabIndex = 242;
            this.Pichome.TabStop = false;
            this.Pichome.Click += new System.EventHandler(this.Pichome_Click);
            // 
            // PicDone
            // 
            this.PicDone.Image = global::I_Count.Properties.Resources.check_icon;
            this.PicDone.Location = new System.Drawing.Point(538, 55);
            this.PicDone.Name = "PicDone";
            this.PicDone.Size = new System.Drawing.Size(48, 48);
            this.PicDone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicDone.TabIndex = 174;
            this.PicDone.TabStop = false;
            this.PicDone.Click += new System.EventHandler(this.PicDone_Click);
            // 
            // BillsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(1221, 543);
            this.Controls.Add(this.Pichome);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblUserName);
            this.Controls.Add(this.LblUserID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BillsEdit";
            this.Text = "تعديل الفواتير";
            this.Load += new System.EventHandler(this.BillsEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVShowBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pichome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblUserID;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBillNum;
        private System.Windows.Forms.RadioButton RDBAckOut;
        private System.Windows.Forms.RadioButton RdBackin;
        private System.Windows.Forms.RadioButton RdBuying;
        private System.Windows.Forms.RadioButton RDBElling;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox Pichome;
        private System.Windows.Forms.Label LblCustName;
        private System.Windows.Forms.ComboBox CBCustomerName;
        private System.Windows.Forms.TextBox TxtPaid;
        private System.Windows.Forms.Label LblDaen;
        private System.Windows.Forms.TextBox TxtDiscount;
        private System.Windows.Forms.Label LblMadeen;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.TextBox TxtDate;
        private System.Windows.Forms.Label LblPhone;
        private System.Windows.Forms.DataGridView GVShowBills;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.PictureBox PicDone;
    }
}
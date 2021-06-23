namespace I_Count
{
    partial class Transfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transfer));
            this.LblUserID = new System.Windows.Forms.Label();
            this.LblUserName = new System.Windows.Forms.Label();
            this.Pichome = new System.Windows.Forms.PictureBox();
            this.GVShowProducts = new System.Windows.Forms.DataGridView();
            this.ItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalePrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalePrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBStore = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CBItemName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CBItemType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.TxtQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CBStoreTo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtSalePrice2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtSalePrice1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LblExsist = new System.Windows.Forms.Label();
            this.PanBarcode = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtBarcode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Pichome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVShowProducts)).BeginInit();
            this.PanBarcode.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblUserID
            // 
            this.LblUserID.AutoSize = true;
            this.LblUserID.Location = new System.Drawing.Point(12, 9);
            this.LblUserID.Name = "LblUserID";
            this.LblUserID.Size = new System.Drawing.Size(0, 13);
            this.LblUserID.TabIndex = 0;
            this.LblUserID.Visible = false;
            // 
            // LblUserName
            // 
            this.LblUserName.AutoSize = true;
            this.LblUserName.Location = new System.Drawing.Point(12, 22);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(0, 13);
            this.LblUserName.TabIndex = 1;
            this.LblUserName.Visible = false;
            // 
            // Pichome
            // 
            this.Pichome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Pichome.Image = global::I_Count.Properties.Resources.esrede;
            this.Pichome.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Pichome.Location = new System.Drawing.Point(-1, 487);
            this.Pichome.Name = "Pichome";
            this.Pichome.Size = new System.Drawing.Size(100, 95);
            this.Pichome.TabIndex = 174;
            this.Pichome.TabStop = false;
            this.Pichome.Click += new System.EventHandler(this.Pichome_Click);
            // 
            // GVShowProducts
            // 
            this.GVShowProducts.AllowUserToAddRows = false;
            this.GVShowProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GVShowProducts.BackgroundColor = System.Drawing.Color.DarkSlateBlue;
            this.GVShowProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GVShowProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVShowProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemType,
            this.ItemName,
            this.Price,
            this.Quantity,
            this.Total,
            this.SalePrice1,
            this.SalePrice2,
            this.ProductID,
            this.ProductTypeID,
            this.Exist});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GVShowProducts.DefaultCellStyle = dataGridViewCellStyle1;
            this.GVShowProducts.Location = new System.Drawing.Point(-1, 163);
            this.GVShowProducts.Name = "GVShowProducts";
            this.GVShowProducts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GVShowProducts.Size = new System.Drawing.Size(1243, 318);
            this.GVShowProducts.TabIndex = 175;
            this.GVShowProducts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVShowProducts_CellEndEdit);
            this.GVShowProducts.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.GVShowProducts_RowsAdded);
            this.GVShowProducts.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.GVShowProducts_RowsRemoved);
            // 
            // ItemType
            // 
            this.ItemType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemType.HeaderText = "نوع الصنف ";
            this.ItemType.Name = "ItemType";
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.HeaderText = "أسم الصنف";
            this.ItemName.Name = "ItemName";
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price.HeaderText = "السعر";
            this.Price.Name = "Price";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "الكميه";
            this.Quantity.Name = "Quantity";
            // 
            // Total
            // 
            this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Total.HeaderText = "القيمه ";
            this.Total.Name = "Total";
            // 
            // SalePrice1
            // 
            this.SalePrice1.HeaderText = "سعر البيع الاول";
            this.SalePrice1.Name = "SalePrice1";
            this.SalePrice1.Width = 226;
            // 
            // SalePrice2
            // 
            this.SalePrice2.HeaderText = "سعر البيع الثانى ";
            this.SalePrice2.Name = "SalePrice2";
            this.SalePrice2.Width = 225;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.Visible = false;
            // 
            // ProductTypeID
            // 
            this.ProductTypeID.HeaderText = "ProductTypeID";
            this.ProductTypeID.Name = "ProductTypeID";
            this.ProductTypeID.Visible = false;
            // 
            // Exist
            // 
            this.Exist.HeaderText = "Exist";
            this.Exist.Name = "Exist";
            this.Exist.Visible = false;
            // 
            // CBStore
            // 
            this.CBStore.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CBStore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBStore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CBStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.CBStore.ForeColor = System.Drawing.Color.Teal;
            this.CBStore.FormattingEnabled = true;
            this.CBStore.Location = new System.Drawing.Point(998, 45);
            this.CBStore.Name = "CBStore";
            this.CBStore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CBStore.Size = new System.Drawing.Size(134, 21);
            this.CBStore.TabIndex = 181;
            this.CBStore.SelectionChangeCommitted += new System.EventHandler(this.CBStore_SelectionChangeCommitted);
            this.CBStore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBStore_KeyDown);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(1155, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 22);
            this.label10.TabIndex = 180;
            this.label10.Text = ": من مخزن";
            // 
            // CBItemName
            // 
            this.CBItemName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CBItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBItemName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CBItemName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.CBItemName.ForeColor = System.Drawing.Color.Teal;
            this.CBItemName.FormattingEnabled = true;
            this.CBItemName.Location = new System.Drawing.Point(426, 45);
            this.CBItemName.Name = "CBItemName";
            this.CBItemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CBItemName.Size = new System.Drawing.Size(160, 21);
            this.CBItemName.TabIndex = 179;
            this.CBItemName.SelectionChangeCommitted += new System.EventHandler(this.CBItemName_SelectionChangeCommitted);
            this.CBItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBItemName_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(609, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 22);
            this.label2.TabIndex = 178;
            this.label2.Text = ":اسم الصنف";
            // 
            // CBItemType
            // 
            this.CBItemType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CBItemType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBItemType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBItemType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CBItemType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBItemType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.CBItemType.ForeColor = System.Drawing.Color.Teal;
            this.CBItemType.FormattingEnabled = true;
            this.CBItemType.Location = new System.Drawing.Point(714, 45);
            this.CBItemType.Name = "CBItemType";
            this.CBItemType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CBItemType.Size = new System.Drawing.Size(160, 21);
            this.CBItemType.TabIndex = 177;
            this.CBItemType.SelectionChangeCommitted += new System.EventHandler(this.CBItemType_SelectionChangeCommitted);
            this.CBItemType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBItemType_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(897, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 176;
            this.label1.Text = ":نوع الصنف";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(8, 115);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(1230, 43);
            this.BtnAdd.TabIndex = 182;
            this.BtnAdd.Text = "إضافه";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // TxtQuantity
            // 
            this.TxtQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQuantity.ForeColor = System.Drawing.Color.Teal;
            this.TxtQuantity.Location = new System.Drawing.Point(1044, 81);
            this.TxtQuantity.Name = "TxtQuantity";
            this.TxtQuantity.Size = new System.Drawing.Size(87, 24);
            this.TxtQuantity.TabIndex = 184;
            this.TxtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtQuantity.TextChanged += new System.EventHandler(this.TxtQuantity_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1177, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 22);
            this.label3.TabIndex = 183;
            this.label3.Text = ":الكميه";
            // 
            // TxtPrice
            // 
            this.TxtPrice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrice.ForeColor = System.Drawing.Color.Teal;
            this.TxtPrice.Location = new System.Drawing.Point(823, 81);
            this.TxtPrice.Name = "TxtPrice";
            this.TxtPrice.Size = new System.Drawing.Size(87, 24);
            this.TxtPrice.TabIndex = 186;
            this.TxtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPrice.TextChanged += new System.EventHandler(this.TxtPrice_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(966, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 22);
            this.label4.TabIndex = 185;
            this.label4.Text = ":السعر";
            // 
            // TxtValue
            // 
            this.TxtValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtValue.ForeColor = System.Drawing.Color.Teal;
            this.TxtValue.Location = new System.Drawing.Point(603, 81);
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.Size = new System.Drawing.Size(87, 24);
            this.TxtValue.TabIndex = 188;
            this.TxtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtValue.TextChanged += new System.EventHandler(this.TxtValue_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(736, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 22);
            this.label5.TabIndex = 187;
            this.label5.Text = ":القيمه";
            // 
            // CBStoreTo
            // 
            this.CBStoreTo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CBStoreTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBStoreTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBStoreTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CBStoreTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBStoreTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.CBStoreTo.ForeColor = System.Drawing.Color.Teal;
            this.CBStoreTo.FormattingEnabled = true;
            this.CBStoreTo.Location = new System.Drawing.Point(133, 45);
            this.CBStoreTo.Name = "CBStoreTo";
            this.CBStoreTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CBStoreTo.Size = new System.Drawing.Size(164, 21);
            this.CBStoreTo.TabIndex = 190;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(320, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 22);
            this.label6.TabIndex = 189;
            this.label6.Text = ": الى مخزن";
            // 
            // TxtSalePrice2
            // 
            this.TxtSalePrice2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtSalePrice2.BackColor = System.Drawing.Color.White;
            this.TxtSalePrice2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtSalePrice2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TxtSalePrice2.Location = new System.Drawing.Point(176, 81);
            this.TxtSalePrice2.Name = "TxtSalePrice2";
            this.TxtSalePrice2.Size = new System.Drawing.Size(87, 24);
            this.TxtSalePrice2.TabIndex = 194;
            this.TxtSalePrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(308, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 22);
            this.label12.TabIndex = 193;
            this.label12.Text = "جمله";
            // 
            // TxtSalePrice1
            // 
            this.TxtSalePrice1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtSalePrice1.BackColor = System.Drawing.Color.White;
            this.TxtSalePrice1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtSalePrice1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TxtSalePrice1.Location = new System.Drawing.Point(391, 81);
            this.TxtSalePrice1.Name = "TxtSalePrice1";
            this.TxtSalePrice1.Size = new System.Drawing.Size(87, 24);
            this.TxtSalePrice1.TabIndex = 192;
            this.TxtSalePrice1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(523, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 22);
            this.label11.TabIndex = 191;
            this.label11.Text = "فرادى";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConfirm.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirm.ForeColor = System.Drawing.Color.White;
            this.BtnConfirm.Location = new System.Drawing.Point(141, 532);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(1070, 42);
            this.BtnConfirm.TabIndex = 195;
            this.BtnConfirm.Text = "تأكيد النقل";
            this.BtnConfirm.UseVisualStyleBackColor = false;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // TxtTotal
            // 
            this.TxtTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TxtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtTotal.Enabled = false;
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.ForeColor = System.Drawing.Color.Teal;
            this.TxtTotal.Location = new System.Drawing.Point(593, 498);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(87, 24);
            this.TxtTotal.TabIndex = 197;
            this.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(701, 499);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 22);
            this.label7.TabIndex = 196;
            this.label7.Text = ":الاجمالى";
            // 
            // LblExsist
            // 
            this.LblExsist.AutoSize = true;
            this.LblExsist.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblExsist.ForeColor = System.Drawing.Color.White;
            this.LblExsist.Location = new System.Drawing.Point(30, 79);
            this.LblExsist.Name = "LblExsist";
            this.LblExsist.Size = new System.Drawing.Size(0, 17);
            this.LblExsist.TabIndex = 198;
            // 
            // PanBarcode
            // 
            this.PanBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanBarcode.Controls.Add(this.label13);
            this.PanBarcode.Controls.Add(this.TxtBarcode);
            this.PanBarcode.Location = new System.Drawing.Point(888, 4);
            this.PanBarcode.Name = "PanBarcode";
            this.PanBarcode.Size = new System.Drawing.Size(348, 35);
            this.PanBarcode.TabIndex = 199;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(247, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 22);
            this.label13.TabIndex = 109;
            this.label13.Text = ": بحث باركود";
            // 
            // TxtBarcode
            // 
            this.TxtBarcode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtBarcode.ForeColor = System.Drawing.Color.Teal;
            this.TxtBarcode.Location = new System.Drawing.Point(113, 7);
            this.TxtBarcode.Name = "TxtBarcode";
            this.TxtBarcode.Size = new System.Drawing.Size(128, 24);
            this.TxtBarcode.TabIndex = 108;
            this.TxtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarcode_KeyDown);
            // 
            // Transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(1245, 582);
            this.Controls.Add(this.PanBarcode);
            this.Controls.Add(this.LblExsist);
            this.Controls.Add(this.TxtTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.TxtSalePrice2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TxtSalePrice1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CBStoreTo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.CBStore);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CBItemName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CBItemType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GVShowProducts);
            this.Controls.Add(this.Pichome);
            this.Controls.Add(this.LblUserName);
            this.Controls.Add(this.LblUserID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Transfer";
            this.Text = "فاتورة نقل ";
            this.Load += new System.EventHandler(this.Transfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pichome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVShowProducts)).EndInit();
            this.PanBarcode.ResumeLayout(false);
            this.PanBarcode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblUserID;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.PictureBox Pichome;
        private System.Windows.Forms.DataGridView GVShowProducts;
        private System.Windows.Forms.ComboBox CBStore;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CBItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBItemType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.TextBox TxtQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBStoreTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtSalePrice2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtSalePrice1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblExsist;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalePrice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalePrice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exist;
        private System.Windows.Forms.Panel PanBarcode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtBarcode;
    }
}
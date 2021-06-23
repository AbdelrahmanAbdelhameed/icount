namespace I_Count
{
    partial class Procurement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Procurement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CBProvider = new System.Windows.Forms.ComboBox();
            this.LblProvidor = new System.Windows.Forms.Label();
            this.CBItemType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CBItemName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtQuantity = new System.Windows.Forms.TextBox();
            this.TxtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.GVShowProducts = new System.Windows.Forms.DataGridView();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtOffer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CBStrorage = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.ChPercent = new System.Windows.Forms.CheckBox();
            this.LblNote = new System.Windows.Forms.Label();
            this.Txtpaid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtSalePrice1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtSalePrice2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.BtnAddProvider = new System.Windows.Forms.Button();
            this.LblProviderName = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.TxtTelephone = new System.Windows.Forms.TextBox();
            this.LblPhone = new System.Windows.Forms.Label();
            this.TxtCompany = new System.Windows.Forms.TextBox();
            this.LblCompany = new System.Windows.Forms.Label();
            this.BtnAddProv = new System.Windows.Forms.Button();
            this.LblUserID = new System.Windows.Forms.Label();
            this.LblUserName = new System.Windows.Forms.Label();
            this.BtnDelet = new System.Windows.Forms.Button();
            this.Pichome = new System.Windows.Forms.PictureBox();
            this.PanBarcode = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtBarcode = new System.Windows.Forms.TextBox();
            this.PicRefresh = new System.Windows.Forms.PictureBox();
            this.CBStore = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtMine = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.DtDateTime = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.TxtSerailSearch = new System.Windows.Forms.TextBox();
            this.ItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalePrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalePrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBMine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GVShowProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pichome)).BeginInit();
            this.PanBarcode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicRefresh)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBProvider
            // 
            resources.ApplyResources(this.CBProvider, "CBProvider");
            this.CBProvider.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBProvider.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBProvider.BackColor = System.Drawing.Color.White;
            this.CBProvider.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.CBProvider.FormattingEnabled = true;
            this.CBProvider.Name = "CBProvider";
            this.CBProvider.SelectionChangeCommitted += new System.EventHandler(this.CBProvider_SelectionChangeCommitted);
            // 
            // LblProvidor
            // 
            resources.ApplyResources(this.LblProvidor, "LblProvidor");
            this.LblProvidor.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblProvidor.ForeColor = System.Drawing.Color.White;
            this.LblProvidor.Name = "LblProvidor";
            // 
            // CBItemType
            // 
            resources.ApplyResources(this.CBItemType, "CBItemType");
            this.CBItemType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBItemType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBItemType.BackColor = System.Drawing.Color.White;
            this.CBItemType.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.CBItemType.FormattingEnabled = true;
            this.CBItemType.Name = "CBItemType";
            this.CBItemType.SelectionChangeCommitted += new System.EventHandler(this.CBItemType_SelectionChangeCommitted);
            this.CBItemType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBItemType_KeyDown);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // CBItemName
            // 
            resources.ApplyResources(this.CBItemName, "CBItemName");
            this.CBItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBItemName.BackColor = System.Drawing.Color.White;
            this.CBItemName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.CBItemName.FormattingEnabled = true;
            this.CBItemName.Name = "CBItemName";
            this.CBItemName.SelectionChangeCommitted += new System.EventHandler(this.CBItemName_SelectionChangeCommitted);
            this.CBItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBItemName_KeyDown);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // TxtQuantity
            // 
            resources.ApplyResources(this.TxtQuantity, "TxtQuantity");
            this.TxtQuantity.BackColor = System.Drawing.Color.White;
            this.TxtQuantity.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TxtQuantity.Name = "TxtQuantity";
            this.TxtQuantity.TextChanged += new System.EventHandler(this.TxtQuantity_TextChanged);
            this.TxtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQuantity_KeyDown);
            // 
            // TxtPrice
            // 
            resources.ApplyResources(this.TxtPrice, "TxtPrice");
            this.TxtPrice.BackColor = System.Drawing.Color.White;
            this.TxtPrice.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TxtPrice.Name = "TxtPrice";
            this.TxtPrice.TextChanged += new System.EventHandler(this.TxtPrice_TextChanged);
            this.TxtPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPrice_KeyDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // TxtValue
            // 
            resources.ApplyResources(this.TxtValue, "TxtValue");
            this.TxtValue.BackColor = System.Drawing.Color.White;
            this.TxtValue.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.TextChanged += new System.EventHandler(this.TxtValue_TextChanged);
            this.TxtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtValue_KeyDown);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // BtnAdd
            // 
            resources.ApplyResources(this.BtnAdd, "BtnAdd");
            this.BtnAdd.BackColor = System.Drawing.Color.MediumPurple;
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // GVShowProducts
            // 
            this.GVShowProducts.AllowUserToAddRows = false;
            resources.ApplyResources(this.GVShowProducts, "GVShowProducts");
            this.GVShowProducts.BackgroundColor = System.Drawing.Color.DarkSlateBlue;
            this.GVShowProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GVShowProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GVShowProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVShowProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemType,
            this.ItemName,
            this.Price,
            this.Quantity,
            this.Total,
            this.SalePrice1,
            this.SalePrice2,
            this.CBMine,
            this.Col_Barcode});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GVShowProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.GVShowProducts.Name = "GVShowProducts";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GVShowProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GVShowProducts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVShowProducts_CellEndEdit);
            this.GVShowProducts.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.GVShowProducts_RowsAdded);
            this.GVShowProducts.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.GVShowProducts_RowsRemoved);
            // 
            // TxtTotal
            // 
            resources.ApplyResources(this.TxtTotal, "TxtTotal");
            this.TxtTotal.BackColor = System.Drawing.Color.White;
            this.TxtTotal.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TxtTotal.Name = "TxtTotal";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // TxtOffer
            // 
            resources.ApplyResources(this.TxtOffer, "TxtOffer");
            this.TxtOffer.BackColor = System.Drawing.Color.White;
            this.TxtOffer.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TxtOffer.Name = "TxtOffer";
            this.TxtOffer.TextChanged += new System.EventHandler(this.TxtOffer_TextChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // CBStrorage
            // 
            resources.ApplyResources(this.CBStrorage, "CBStrorage");
            this.CBStrorage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBStrorage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBStrorage.BackColor = System.Drawing.Color.White;
            this.CBStrorage.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.CBStrorage.FormattingEnabled = true;
            this.CBStrorage.Name = "CBStrorage";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Name = "label8";
            // 
            // BtnConfirm
            // 
            resources.ApplyResources(this.BtnConfirm, "BtnConfirm");
            this.BtnConfirm.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnConfirm.ForeColor = System.Drawing.Color.White;
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.UseVisualStyleBackColor = false;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // ChPercent
            // 
            resources.ApplyResources(this.ChPercent, "ChPercent");
            this.ChPercent.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ChPercent.ForeColor = System.Drawing.Color.White;
            this.ChPercent.Name = "ChPercent";
            this.ChPercent.UseVisualStyleBackColor = false;
            this.ChPercent.MouseLeave += new System.EventHandler(this.ChPercent_MouseLeave);
            this.ChPercent.MouseHover += new System.EventHandler(this.ChPercent_MouseHover);
            // 
            // LblNote
            // 
            resources.ApplyResources(this.LblNote, "LblNote");
            this.LblNote.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblNote.ForeColor = System.Drawing.Color.White;
            this.LblNote.Name = "LblNote";
            // 
            // Txtpaid
            // 
            resources.ApplyResources(this.Txtpaid, "Txtpaid");
            this.Txtpaid.BackColor = System.Drawing.Color.White;
            this.Txtpaid.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Txtpaid.Name = "Txtpaid";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Name = "label9";
            // 
            // TxtSalePrice1
            // 
            resources.ApplyResources(this.TxtSalePrice1, "TxtSalePrice1");
            this.TxtSalePrice1.BackColor = System.Drawing.Color.White;
            this.TxtSalePrice1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TxtSalePrice1.Name = "TxtSalePrice1";
            this.TxtSalePrice1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSalePrice1_KeyDown);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Name = "label11";
            // 
            // TxtSalePrice2
            // 
            resources.ApplyResources(this.TxtSalePrice2, "TxtSalePrice2");
            this.TxtSalePrice2.BackColor = System.Drawing.Color.White;
            this.TxtSalePrice2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TxtSalePrice2.Name = "TxtSalePrice2";
            this.TxtSalePrice2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSalePrice2_KeyDown);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Name = "label12";
            // 
            // BtnAddProvider
            // 
            resources.ApplyResources(this.BtnAddProvider, "BtnAddProvider");
            this.BtnAddProvider.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnAddProvider.ForeColor = System.Drawing.Color.White;
            this.BtnAddProvider.Name = "BtnAddProvider";
            this.BtnAddProvider.UseVisualStyleBackColor = false;
            this.BtnAddProvider.Click += new System.EventHandler(this.BtnAddProvider_Click);
            // 
            // LblProviderName
            // 
            resources.ApplyResources(this.LblProviderName, "LblProviderName");
            this.LblProviderName.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblProviderName.ForeColor = System.Drawing.Color.White;
            this.LblProviderName.Name = "LblProviderName";
            // 
            // TxtName
            // 
            resources.ApplyResources(this.TxtName, "TxtName");
            this.TxtName.BackColor = System.Drawing.Color.White;
            this.TxtName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TxtName.Name = "TxtName";
            // 
            // LblName
            // 
            resources.ApplyResources(this.LblName, "LblName");
            this.LblName.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblName.ForeColor = System.Drawing.Color.White;
            this.LblName.Name = "LblName";
            // 
            // TxtTelephone
            // 
            resources.ApplyResources(this.TxtTelephone, "TxtTelephone");
            this.TxtTelephone.BackColor = System.Drawing.Color.White;
            this.TxtTelephone.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TxtTelephone.Name = "TxtTelephone";
            // 
            // LblPhone
            // 
            resources.ApplyResources(this.LblPhone, "LblPhone");
            this.LblPhone.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblPhone.ForeColor = System.Drawing.Color.White;
            this.LblPhone.Name = "LblPhone";
            // 
            // TxtCompany
            // 
            resources.ApplyResources(this.TxtCompany, "TxtCompany");
            this.TxtCompany.BackColor = System.Drawing.Color.White;
            this.TxtCompany.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TxtCompany.Name = "TxtCompany";
            // 
            // LblCompany
            // 
            resources.ApplyResources(this.LblCompany, "LblCompany");
            this.LblCompany.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblCompany.ForeColor = System.Drawing.Color.White;
            this.LblCompany.Name = "LblCompany";
            // 
            // BtnAddProv
            // 
            resources.ApplyResources(this.BtnAddProv, "BtnAddProv");
            this.BtnAddProv.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnAddProv.ForeColor = System.Drawing.Color.White;
            this.BtnAddProv.Name = "BtnAddProv";
            this.BtnAddProv.UseVisualStyleBackColor = false;
            this.BtnAddProv.Click += new System.EventHandler(this.BtnAddProv_Click);
            // 
            // LblUserID
            // 
            resources.ApplyResources(this.LblUserID, "LblUserID");
            this.LblUserID.Name = "LblUserID";
            // 
            // LblUserName
            // 
            resources.ApplyResources(this.LblUserName, "LblUserName");
            this.LblUserName.Name = "LblUserName";
            // 
            // BtnDelet
            // 
            resources.ApplyResources(this.BtnDelet, "BtnDelet");
            this.BtnDelet.ForeColor = System.Drawing.Color.White;
            this.BtnDelet.Image = global::I_Count.Properties.Resources.delete84;
            this.BtnDelet.Name = "BtnDelet";
            this.BtnDelet.UseVisualStyleBackColor = true;
            this.BtnDelet.Click += new System.EventHandler(this.BtnDelet_Click);
            this.BtnDelet.MouseLeave += new System.EventHandler(this.BtnDelet_MouseLeave);
            this.BtnDelet.MouseHover += new System.EventHandler(this.BtnDelet_MouseHover);
            // 
            // Pichome
            // 
            resources.ApplyResources(this.Pichome, "Pichome");
            this.Pichome.Image = global::I_Count.Properties.Resources.esrede;
            this.Pichome.Name = "Pichome";
            this.Pichome.TabStop = false;
            this.Pichome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // PanBarcode
            // 
            resources.ApplyResources(this.PanBarcode, "PanBarcode");
            this.PanBarcode.Controls.Add(this.label13);
            this.PanBarcode.Controls.Add(this.TxtBarcode);
            this.PanBarcode.Name = "PanBarcode";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Name = "label13";
            // 
            // TxtBarcode
            // 
            resources.ApplyResources(this.TxtBarcode, "TxtBarcode");
            this.TxtBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtBarcode.ForeColor = System.Drawing.Color.Teal;
            this.TxtBarcode.Name = "TxtBarcode";
            this.TxtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarcode_KeyDown);
            // 
            // PicRefresh
            // 
            this.PicRefresh.Image = global::I_Count.Properties.Resources.cloud31;
            resources.ApplyResources(this.PicRefresh, "PicRefresh");
            this.PicRefresh.Name = "PicRefresh";
            this.PicRefresh.TabStop = false;
            this.PicRefresh.Click += new System.EventHandler(this.PicRefresh_Click);
            // 
            // CBStore
            // 
            resources.ApplyResources(this.CBStore, "CBStore");
            this.CBStore.BackColor = System.Drawing.Color.White;
            this.CBStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBStore.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.CBStore.FormattingEnabled = true;
            this.CBStore.Name = "CBStore";
            this.CBStore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBStore_KeyDown);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Name = "label10";
            // 
            // TxtMine
            // 
            resources.ApplyResources(this.TxtMine, "TxtMine");
            this.TxtMine.BackColor = System.Drawing.Color.White;
            this.TxtMine.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TxtMine.Name = "TxtMine";
            this.TxtMine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMine_KeyDown);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Name = "label14";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Name = "label15";
            // 
            // DtDateTime
            // 
            resources.ApplyResources(this.DtDateTime, "DtDateTime");
            this.DtDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtDateTime.Name = "DtDateTime";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.TxtSerailSearch);
            this.panel1.Name = "panel1";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Name = "label16";
            // 
            // TxtSerailSearch
            // 
            resources.ApplyResources(this.TxtSerailSearch, "TxtSerailSearch");
            this.TxtSerailSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtSerailSearch.ForeColor = System.Drawing.Color.Teal;
            this.TxtSerailSearch.Name = "TxtSerailSearch";
            this.TxtSerailSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSerailSearch_KeyDown);
            // 
            // ItemType
            // 
            this.ItemType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.ItemType, "ItemType");
            this.ItemType.Name = "ItemType";
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.ItemName, "ItemName");
            this.ItemName.Name = "ItemName";
            // 
            // Price
            // 
            resources.ApplyResources(this.Price, "Price");
            this.Price.Name = "Price";
            // 
            // Quantity
            // 
            resources.ApplyResources(this.Quantity, "Quantity");
            this.Quantity.Name = "Quantity";
            // 
            // Total
            // 
            resources.ApplyResources(this.Total, "Total");
            this.Total.Name = "Total";
            // 
            // SalePrice1
            // 
            resources.ApplyResources(this.SalePrice1, "SalePrice1");
            this.SalePrice1.Name = "SalePrice1";
            // 
            // SalePrice2
            // 
            resources.ApplyResources(this.SalePrice2, "SalePrice2");
            this.SalePrice2.Name = "SalePrice2";
            // 
            // CBMine
            // 
            resources.ApplyResources(this.CBMine, "CBMine");
            this.CBMine.Name = "CBMine";
            // 
            // Col_Barcode
            // 
            resources.ApplyResources(this.Col_Barcode, "Col_Barcode");
            this.Col_Barcode.Name = "Col_Barcode";
            // 
            // Procurement
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DtDateTime);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.TxtMine);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.CBStore);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.PicRefresh);
            this.Controls.Add(this.PanBarcode);
            this.Controls.Add(this.BtnDelet);
            this.Controls.Add(this.Pichome);
            this.Controls.Add(this.LblUserName);
            this.Controls.Add(this.LblUserID);
            this.Controls.Add(this.BtnAddProv);
            this.Controls.Add(this.TxtCompany);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.TxtTelephone);
            this.Controls.Add(this.LblPhone);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.LblProviderName);
            this.Controls.Add(this.BtnAddProvider);
            this.Controls.Add(this.TxtSalePrice2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TxtSalePrice1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Txtpaid);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.ChPercent);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.CBStrorage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtOffer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GVShowProducts);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.TxtValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CBItemName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CBItemType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBProvider);
            this.Controls.Add(this.LblProvidor);
            this.Name = "Procurement";
            this.Load += new System.EventHandler(this.Procurement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GVShowProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pichome)).EndInit();
            this.PanBarcode.ResumeLayout(false);
            this.PanBarcode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicRefresh)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBProvider;
        private System.Windows.Forms.Label LblProvidor;
        private System.Windows.Forms.ComboBox CBItemType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtQuantity;
        private System.Windows.Forms.TextBox TxtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.DataGridView GVShowProducts;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtOffer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CBStrorage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.CheckBox ChPercent;
        private System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.TextBox Txtpaid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtSalePrice1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtSalePrice2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button BtnAddProvider;
        private System.Windows.Forms.Label LblProviderName;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TxtTelephone;
        private System.Windows.Forms.Label LblPhone;
        private System.Windows.Forms.TextBox TxtCompany;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.Button BtnAddProv;
        private System.Windows.Forms.Label LblUserID;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.PictureBox Pichome;
        private System.Windows.Forms.Button BtnDelet;
        private System.Windows.Forms.Panel PanBarcode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtBarcode;
        private System.Windows.Forms.PictureBox PicRefresh;
        private System.Windows.Forms.ComboBox CBStore;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtMine;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker DtDateTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TxtSerailSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalePrice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalePrice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBMine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Barcode;
    }
}
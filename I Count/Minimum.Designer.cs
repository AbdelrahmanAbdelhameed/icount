namespace I_Count
{
    partial class Minimum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Minimum));
            this.BtnShow = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.TxtMinimum = new System.Windows.Forms.TextBox();
            this.LblMinimum = new System.Windows.Forms.Label();
            this.LblPrductName = new System.Windows.Forms.Label();
            this.CBPrductName = new System.Windows.Forms.ComboBox();
            this.LblProductType = new System.Windows.Forms.Label();
            this.CBProductType = new System.Windows.Forms.ComboBox();
            this.GVMinimum = new System.Windows.Forms.DataGridView();
            this.LblUserName = new System.Windows.Forms.Label();
            this.LblUserID = new System.Windows.Forms.Label();
            this.Pichome = new System.Windows.Forms.PictureBox();
            this.LblStore = new System.Windows.Forms.Label();
            this.CBStore = new System.Windows.Forms.ComboBox();
            this.PicBack = new System.Windows.Forms.PictureBox();
            this.LblPostion = new System.Windows.Forms.Label();
            this.ProductType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinimumN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Store = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GVMinimum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pichome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBack)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnShow
            // 
            this.BtnShow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.ForeColor = System.Drawing.Color.White;
            this.BtnShow.Location = new System.Drawing.Point(3, 40);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(1154, 56);
            this.BtnShow.TabIndex = 141;
            this.BtnShow.Text = "إضافة حد ادنى لمنتج ";
            this.BtnShow.UseVisualStyleBackColor = true;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(213, 105);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(677, 41);
            this.BtnAdd.TabIndex = 148;
            this.BtnAdd.Text = "إضافه";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Visible = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // TxtMinimum
            // 
            this.TxtMinimum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtMinimum.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TxtMinimum.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TxtMinimum.ForeColor = System.Drawing.Color.Teal;
            this.TxtMinimum.Location = new System.Drawing.Point(28, 56);
            this.TxtMinimum.Name = "TxtMinimum";
            this.TxtMinimum.Size = new System.Drawing.Size(124, 25);
            this.TxtMinimum.TabIndex = 147;
            this.TxtMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtMinimum.Visible = false;
            // 
            // LblMinimum
            // 
            this.LblMinimum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblMinimum.AutoSize = true;
            this.LblMinimum.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblMinimum.Font = new System.Drawing.Font("Tahoma", 14F);
            this.LblMinimum.ForeColor = System.Drawing.Color.White;
            this.LblMinimum.Location = new System.Drawing.Point(171, 57);
            this.LblMinimum.Name = "LblMinimum";
            this.LblMinimum.Size = new System.Drawing.Size(99, 23);
            this.LblMinimum.TabIndex = 146;
            this.LblMinimum.Text = "الحد الادنى";
            this.LblMinimum.Visible = false;
            // 
            // LblPrductName
            // 
            this.LblPrductName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblPrductName.AutoSize = true;
            this.LblPrductName.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblPrductName.Font = new System.Drawing.Font("Tahoma", 14F);
            this.LblPrductName.ForeColor = System.Drawing.Color.White;
            this.LblPrductName.Location = new System.Drawing.Point(501, 56);
            this.LblPrductName.Name = "LblPrductName";
            this.LblPrductName.Size = new System.Drawing.Size(102, 23);
            this.LblPrductName.TabIndex = 145;
            this.LblPrductName.Text = "أسم المنتج";
            this.LblPrductName.Visible = false;
            // 
            // CBPrductName
            // 
            this.CBPrductName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CBPrductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBPrductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBPrductName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.CBPrductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBPrductName.Font = new System.Drawing.Font("Tahoma", 11F);
            this.CBPrductName.ForeColor = System.Drawing.Color.Teal;
            this.CBPrductName.FormattingEnabled = true;
            this.CBPrductName.Location = new System.Drawing.Point(321, 56);
            this.CBPrductName.Name = "CBPrductName";
            this.CBPrductName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CBPrductName.Size = new System.Drawing.Size(156, 26);
            this.CBPrductName.TabIndex = 144;
            this.CBPrductName.Visible = false;
            this.CBPrductName.SelectionChangeCommitted += new System.EventHandler(this.CBPrductName_SelectionChangeCommitted);
            this.CBPrductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBPrductName_KeyDown);
            // 
            // LblProductType
            // 
            this.LblProductType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblProductType.AutoSize = true;
            this.LblProductType.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblProductType.Font = new System.Drawing.Font("Tahoma", 14F);
            this.LblProductType.ForeColor = System.Drawing.Color.White;
            this.LblProductType.Location = new System.Drawing.Point(830, 55);
            this.LblProductType.Name = "LblProductType";
            this.LblProductType.Size = new System.Drawing.Size(90, 23);
            this.LblProductType.TabIndex = 143;
            this.LblProductType.Text = "نوع المنتج";
            this.LblProductType.Visible = false;
            // 
            // CBProductType
            // 
            this.CBProductType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CBProductType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBProductType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBProductType.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.CBProductType.Font = new System.Drawing.Font("Tahoma", 11F);
            this.CBProductType.ForeColor = System.Drawing.Color.Teal;
            this.CBProductType.FormattingEnabled = true;
            this.CBProductType.Location = new System.Drawing.Point(650, 57);
            this.CBProductType.Name = "CBProductType";
            this.CBProductType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CBProductType.Size = new System.Drawing.Size(156, 26);
            this.CBProductType.TabIndex = 142;
            this.CBProductType.Visible = false;
            this.CBProductType.SelectionChangeCommitted += new System.EventHandler(this.CBProductType_SelectionChangeCommitted);
            this.CBProductType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBProductType_KeyDown);
            // 
            // GVMinimum
            // 
            this.GVMinimum.AllowUserToAddRows = false;
            this.GVMinimum.AllowUserToDeleteRows = false;
            this.GVMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GVMinimum.BackgroundColor = System.Drawing.Color.DarkSlateBlue;
            this.GVMinimum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GVMinimum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVMinimum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductType,
            this.ProductName,
            this.Exist,
            this.MinimumN,
            this.Store});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GVMinimum.DefaultCellStyle = dataGridViewCellStyle1;
            this.GVMinimum.Location = new System.Drawing.Point(113, 152);
            this.GVMinimum.Name = "GVMinimum";
            this.GVMinimum.ReadOnly = true;
            this.GVMinimum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GVMinimum.Size = new System.Drawing.Size(1053, 376);
            this.GVMinimum.TabIndex = 140;
            // 
            // LblUserName
            // 
            this.LblUserName.AutoSize = true;
            this.LblUserName.Location = new System.Drawing.Point(25, 313);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(0, 13);
            this.LblUserName.TabIndex = 170;
            this.LblUserName.Visible = false;
            // 
            // LblUserID
            // 
            this.LblUserID.AutoSize = true;
            this.LblUserID.Location = new System.Drawing.Point(35, 262);
            this.LblUserID.Name = "LblUserID";
            this.LblUserID.Size = new System.Drawing.Size(0, 13);
            this.LblUserID.TabIndex = 169;
            this.LblUserID.Visible = false;
            // 
            // Pichome
            // 
            this.Pichome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Pichome.Image = global::I_Count.Properties.Resources.esrede;
            this.Pichome.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Pichome.Location = new System.Drawing.Point(3, 443);
            this.Pichome.Name = "Pichome";
            this.Pichome.Size = new System.Drawing.Size(100, 95);
            this.Pichome.TabIndex = 241;
            this.Pichome.TabStop = false;
            this.Pichome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // LblStore
            // 
            this.LblStore.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblStore.AutoSize = true;
            this.LblStore.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblStore.Font = new System.Drawing.Font("Tahoma", 14F);
            this.LblStore.ForeColor = System.Drawing.Color.White;
            this.LblStore.Location = new System.Drawing.Point(1072, 56);
            this.LblStore.Name = "LblStore";
            this.LblStore.Size = new System.Drawing.Size(72, 23);
            this.LblStore.TabIndex = 243;
            this.LblStore.Text = "المخزن ";
            this.LblStore.Visible = false;
            // 
            // CBStore
            // 
            this.CBStore.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CBStore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBStore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBStore.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.CBStore.Font = new System.Drawing.Font("Tahoma", 11F);
            this.CBStore.ForeColor = System.Drawing.Color.Teal;
            this.CBStore.FormattingEnabled = true;
            this.CBStore.Location = new System.Drawing.Point(935, 57);
            this.CBStore.Name = "CBStore";
            this.CBStore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CBStore.Size = new System.Drawing.Size(131, 26);
            this.CBStore.TabIndex = 242;
            this.CBStore.Visible = false;
            this.CBStore.SelectionChangeCommitted += new System.EventHandler(this.CBStore_SelectionChangeCommitted);
            // 
            // PicBack
            // 
            this.PicBack.Image = global::I_Count.Properties.Resources.back;
            this.PicBack.Location = new System.Drawing.Point(3, 87);
            this.PicBack.Name = "PicBack";
            this.PicBack.Size = new System.Drawing.Size(100, 94);
            this.PicBack.TabIndex = 244;
            this.PicBack.TabStop = false;
            this.PicBack.Visible = false;
            this.PicBack.Click += new System.EventHandler(this.PicBack_Click);
            // 
            // LblPostion
            // 
            this.LblPostion.AutoSize = true;
            this.LblPostion.Location = new System.Drawing.Point(28, 4);
            this.LblPostion.Name = "LblPostion";
            this.LblPostion.Size = new System.Drawing.Size(0, 13);
            this.LblPostion.TabIndex = 245;
            this.LblPostion.Visible = false;
            // 
            // ProductType
            // 
            this.ProductType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductType.HeaderText = "نوع المنتج";
            this.ProductType.Name = "ProductType";
            this.ProductType.ReadOnly = true;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.HeaderText = "اسم المنتج";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Exist
            // 
            this.Exist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Exist.HeaderText = "الكميه الحاليه";
            this.Exist.Name = "Exist";
            this.Exist.ReadOnly = true;
            // 
            // MinimumN
            // 
            this.MinimumN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MinimumN.HeaderText = "الحد الادنى ";
            this.MinimumN.Name = "MinimumN";
            this.MinimumN.ReadOnly = true;
            // 
            // Store
            // 
            this.Store.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Store.HeaderText = "المخزن";
            this.Store.Name = "Store";
            this.Store.ReadOnly = true;
            // 
            // Minimum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1178, 540);
            this.Controls.Add(this.LblPostion);
            this.Controls.Add(this.Pichome);
            this.Controls.Add(this.LblUserName);
            this.Controls.Add(this.LblUserID);
            this.Controls.Add(this.BtnShow);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.TxtMinimum);
            this.Controls.Add(this.LblMinimum);
            this.Controls.Add(this.LblPrductName);
            this.Controls.Add(this.CBPrductName);
            this.Controls.Add(this.LblProductType);
            this.Controls.Add(this.CBProductType);
            this.Controls.Add(this.GVMinimum);
            this.Controls.Add(this.LblStore);
            this.Controls.Add(this.CBStore);
            this.Controls.Add(this.PicBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Minimum";
            this.Text = "النواقص";
            this.Load += new System.EventHandler(this.Minimum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GVMinimum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pichome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.TextBox TxtMinimum;
        private System.Windows.Forms.Label LblMinimum;
        private System.Windows.Forms.Label LblPrductName;
        private System.Windows.Forms.ComboBox CBPrductName;
        private System.Windows.Forms.Label LblProductType;
        private System.Windows.Forms.ComboBox CBProductType;
        private System.Windows.Forms.DataGridView GVMinimum;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.Label LblUserID;
        private System.Windows.Forms.PictureBox Pichome;
        private System.Windows.Forms.Label LblStore;
        private System.Windows.Forms.ComboBox CBStore;
        private System.Windows.Forms.PictureBox PicBack;
        private System.Windows.Forms.Label LblPostion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exist;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinimumN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Store;
    }
}
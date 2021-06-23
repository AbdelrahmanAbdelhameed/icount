namespace I_Count
{
    partial class Employess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employess));
            this.LblUserID = new System.Windows.Forms.Label();
            this.LblUserName = new System.Windows.Forms.Label();
            this.LblPostion = new System.Windows.Forms.Label();
            this.Pichome = new System.Windows.Forms.PictureBox();
            this.TxtSalary = new System.Windows.Forms.TextBox();
            this.LblCompany = new System.Windows.Forms.Label();
            this.TxtTelephone = new System.Windows.Forms.TextBox();
            this.LblPhone = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TxtDebit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.GVEmployess = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblEmpID = new System.Windows.Forms.Label();
            this.PanRepay = new System.Windows.Forms.Panel();
            this.CBStrorage = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnRepay = new System.Windows.Forms.Button();
            this.TxtRepay = new System.Windows.Forms.TextBox();
            this.LblEmpName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Pichome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVEmployess)).BeginInit();
            this.PanRepay.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblUserID
            // 
            this.LblUserID.AutoSize = true;
            this.LblUserID.Location = new System.Drawing.Point(13, 13);
            this.LblUserID.Name = "LblUserID";
            this.LblUserID.Size = new System.Drawing.Size(0, 13);
            this.LblUserID.TabIndex = 0;
            this.LblUserID.Visible = false;
            // 
            // LblUserName
            // 
            this.LblUserName.AutoSize = true;
            this.LblUserName.Location = new System.Drawing.Point(104, 12);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(0, 13);
            this.LblUserName.TabIndex = 1;
            this.LblUserName.Visible = false;
            // 
            // LblPostion
            // 
            this.LblPostion.AutoSize = true;
            this.LblPostion.Location = new System.Drawing.Point(16, 51);
            this.LblPostion.Name = "LblPostion";
            this.LblPostion.Size = new System.Drawing.Size(0, 13);
            this.LblPostion.TabIndex = 2;
            this.LblPostion.Visible = false;
            // 
            // Pichome
            // 
            this.Pichome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Pichome.Image = global::I_Count.Properties.Resources.esrede;
            this.Pichome.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Pichome.Location = new System.Drawing.Point(1, 436);
            this.Pichome.Name = "Pichome";
            this.Pichome.Size = new System.Drawing.Size(100, 95);
            this.Pichome.TabIndex = 174;
            this.Pichome.TabStop = false;
            this.Pichome.Click += new System.EventHandler(this.Pichome_Click);
            // 
            // TxtSalary
            // 
            this.TxtSalary.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSalary.ForeColor = System.Drawing.Color.Teal;
            this.TxtSalary.Location = new System.Drawing.Point(419, 44);
            this.TxtSalary.Name = "TxtSalary";
            this.TxtSalary.Size = new System.Drawing.Size(114, 24);
            this.TxtSalary.TabIndex = 180;
            this.TxtSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblCompany
            // 
            this.LblCompany.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblCompany.AutoSize = true;
            this.LblCompany.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompany.ForeColor = System.Drawing.Color.White;
            this.LblCompany.Location = new System.Drawing.Point(548, 46);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(61, 22);
            this.LblCompany.TabIndex = 179;
            this.LblCompany.Text = ": المرتب";
            // 
            // TxtTelephone
            // 
            this.TxtTelephone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtTelephone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTelephone.ForeColor = System.Drawing.Color.Teal;
            this.TxtTelephone.Location = new System.Drawing.Point(646, 44);
            this.TxtTelephone.Name = "TxtTelephone";
            this.TxtTelephone.Size = new System.Drawing.Size(135, 24);
            this.TxtTelephone.TabIndex = 178;
            this.TxtTelephone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblPhone
            // 
            this.LblPhone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblPhone.AutoSize = true;
            this.LblPhone.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPhone.ForeColor = System.Drawing.Color.White;
            this.LblPhone.Location = new System.Drawing.Point(796, 46);
            this.LblPhone.Name = "LblPhone";
            this.LblPhone.Size = new System.Drawing.Size(88, 22);
            this.LblPhone.TabIndex = 177;
            this.LblPhone.Text = ":رقم التيلفون ";
            // 
            // TxtName
            // 
            this.TxtName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtName.ForeColor = System.Drawing.Color.Teal;
            this.TxtName.Location = new System.Drawing.Point(899, 44);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(159, 24);
            this.TxtName.TabIndex = 176;
            this.TxtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblName
            // 
            this.LblName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblName.AutoSize = true;
            this.LblName.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.ForeColor = System.Drawing.Color.White;
            this.LblName.Location = new System.Drawing.Point(1064, 46);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(51, 22);
            this.LblName.TabIndex = 175;
            this.LblName.Text = ": الاسم";
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnSave.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(32, 36);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(202, 43);
            this.BtnSave.TabIndex = 181;
            this.BtnSave.Text = "إضافه";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TxtDebit
            // 
            this.TxtDebit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtDebit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDebit.ForeColor = System.Drawing.Color.Teal;
            this.TxtDebit.Location = new System.Drawing.Point(253, 44);
            this.TxtDebit.Name = "TxtDebit";
            this.TxtDebit.Size = new System.Drawing.Size(83, 24);
            this.TxtDebit.TabIndex = 183;
            this.TxtDebit.Text = "0";
            this.TxtDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(342, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 22);
            this.label3.TabIndex = 182;
            this.label3.Text = ": المدين";
            // 
            // BtnEdit
            // 
            this.BtnEdit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnEdit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.ForeColor = System.Drawing.Color.White;
            this.BtnEdit.Location = new System.Drawing.Point(32, 36);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(202, 43);
            this.BtnEdit.TabIndex = 188;
            this.BtnEdit.Text = "تعديل";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Visible = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // GVEmployess
            // 
            this.GVEmployess.AllowUserToAddRows = false;
            this.GVEmployess.AllowUserToDeleteRows = false;
            this.GVEmployess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GVEmployess.BackgroundColor = System.Drawing.Color.DarkSlateBlue;
            this.GVEmployess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GVEmployess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVEmployess.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.CLTotal,
            this.dataGridViewTextBoxColumn4,
            this.Column1,
            this.EmpI});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GVEmployess.DefaultCellStyle = dataGridViewCellStyle1;
            this.GVEmployess.GridColor = System.Drawing.Color.DarkSlateBlue;
            this.GVEmployess.Location = new System.Drawing.Point(32, 119);
            this.GVEmployess.Name = "GVEmployess";
            this.GVEmployess.ReadOnly = true;
            this.GVEmployess.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GVEmployess.Size = new System.Drawing.Size(1126, 311);
            this.GVEmployess.TabIndex = 189;
            this.GVEmployess.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVEmployess_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "الاسم ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "رقم التليفون";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // CLTotal
            // 
            this.CLTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CLTotal.HeaderText = "المرتب";
            this.CLTotal.Name = "CLTotal";
            this.CLTotal.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "مدين";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "المستحق";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // EmpI
            // 
            this.EmpI.HeaderText = "ID";
            this.EmpI.Name = "EmpI";
            this.EmpI.ReadOnly = true;
            this.EmpI.Visible = false;
            // 
            // LblEmpID
            // 
            this.LblEmpID.AutoSize = true;
            this.LblEmpID.Location = new System.Drawing.Point(619, 84);
            this.LblEmpID.Name = "LblEmpID";
            this.LblEmpID.Size = new System.Drawing.Size(0, 13);
            this.LblEmpID.TabIndex = 190;
            this.LblEmpID.Visible = false;
            // 
            // PanRepay
            // 
            this.PanRepay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanRepay.Controls.Add(this.CBStrorage);
            this.PanRepay.Controls.Add(this.label8);
            this.PanRepay.Controls.Add(this.label1);
            this.PanRepay.Controls.Add(this.BtnRepay);
            this.PanRepay.Controls.Add(this.TxtRepay);
            this.PanRepay.Controls.Add(this.LblEmpName);
            this.PanRepay.Location = new System.Drawing.Point(222, 448);
            this.PanRepay.Name = "PanRepay";
            this.PanRepay.Size = new System.Drawing.Size(893, 71);
            this.PanRepay.TabIndex = 191;
            this.PanRepay.Visible = false;
            // 
            // CBStrorage
            // 
            this.CBStrorage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CBStrorage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CBStrorage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBStrorage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.CBStrorage.ForeColor = System.Drawing.Color.Teal;
            this.CBStrorage.FormattingEnabled = true;
            this.CBStrorage.Location = new System.Drawing.Point(175, 29);
            this.CBStrorage.Name = "CBStrorage";
            this.CBStrorage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CBStrorage.Size = new System.Drawing.Size(160, 21);
            this.CBStrorage.TabIndex = 192;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(359, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 22);
            this.label8.TabIndex = 191;
            this.label8.Text = ": مدفوع من ";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(614, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 22);
            this.label1.TabIndex = 190;
            this.label1.Text = ": المستحق";
            // 
            // BtnRepay
            // 
            this.BtnRepay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnRepay.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnRepay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnRepay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRepay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRepay.ForeColor = System.Drawing.Color.White;
            this.BtnRepay.Location = new System.Drawing.Point(31, 15);
            this.BtnRepay.Name = "BtnRepay";
            this.BtnRepay.Size = new System.Drawing.Size(123, 43);
            this.BtnRepay.TabIndex = 189;
            this.BtnRepay.Text = "دفع المستحق";
            this.BtnRepay.UseVisualStyleBackColor = false;
            this.BtnRepay.Click += new System.EventHandler(this.BtnRepay_Click);
            // 
            // TxtRepay
            // 
            this.TxtRepay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtRepay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtRepay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRepay.ForeColor = System.Drawing.Color.Teal;
            this.TxtRepay.Location = new System.Drawing.Point(494, 25);
            this.TxtRepay.Name = "TxtRepay";
            this.TxtRepay.Size = new System.Drawing.Size(114, 24);
            this.TxtRepay.TabIndex = 181;
            this.TxtRepay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblEmpName
            // 
            this.LblEmpName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblEmpName.AutoSize = true;
            this.LblEmpName.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LblEmpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEmpName.ForeColor = System.Drawing.Color.White;
            this.LblEmpName.Location = new System.Drawing.Point(786, 25);
            this.LblEmpName.Name = "LblEmpName";
            this.LblEmpName.Size = new System.Drawing.Size(0, 22);
            this.LblEmpName.TabIndex = 176;
            // 
            // Employess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(1170, 531);
            this.Controls.Add(this.PanRepay);
            this.Controls.Add(this.LblEmpID);
            this.Controls.Add(this.GVEmployess);
            this.Controls.Add(this.TxtDebit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtSalary);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.TxtTelephone);
            this.Controls.Add(this.LblPhone);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.Pichome);
            this.Controls.Add(this.LblPostion);
            this.Controls.Add(this.LblUserName);
            this.Controls.Add(this.LblUserID);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnEdit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Employess";
            this.Text = "الموظفين";
            this.Load += new System.EventHandler(this.Employess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pichome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVEmployess)).EndInit();
            this.PanRepay.ResumeLayout(false);
            this.PanRepay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblUserID;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.Label LblPostion;
        private System.Windows.Forms.PictureBox Pichome;
        private System.Windows.Forms.TextBox TxtSalary;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.TextBox TxtTelephone;
        private System.Windows.Forms.Label LblPhone;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox TxtDebit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.DataGridView GVEmployess;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpI;
        private System.Windows.Forms.Label LblEmpID;
        private System.Windows.Forms.Panel PanRepay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnRepay;
        private System.Windows.Forms.TextBox TxtRepay;
        private System.Windows.Forms.Label LblEmpName;
        private System.Windows.Forms.ComboBox CBStrorage;
        private System.Windows.Forms.Label label8;
    }
}
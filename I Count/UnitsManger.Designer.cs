namespace I_Count
{
    partial class UnitsManger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnitsManger));
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBigUnit = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LblUserID = new System.Windows.Forms.Label();
            this.TxtSamllUnit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtSamllUnitNumbers = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnAddUnit = new System.Windows.Forms.Button();
            this.BtnEditUnit = new System.Windows.Forms.Button();
            this.TxtNumberOfSmall = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtSmUnit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtMasterUnit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CBItemUnit = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(462, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم الوحده الرئيسيه";
            // 
            // TxtBigUnit
            // 
            this.TxtBigUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBigUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBigUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtBigUnit.Location = new System.Drawing.Point(171, 65);
            this.TxtBigUnit.Name = "TxtBigUnit";
            this.TxtBigUnit.Size = new System.Drawing.Size(253, 26);
            this.TxtBigUnit.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(619, 263);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.tabPage1.Controls.Add(this.BtnAddUnit);
            this.tabPage1.Controls.Add(this.TxtSamllUnitNumbers);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.TxtSamllUnit);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.TxtBigUnit);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(611, 237);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "إضافة وحدة صنف";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.SaddleBrown;
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.CBItemUnit);
            this.tabPage2.Controls.Add(this.BtnEditUnit);
            this.tabPage2.Controls.Add(this.TxtNumberOfSmall);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.TxtSmUnit);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.TxtMasterUnit);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(611, 237);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تعديل وحدة صنف";
            // 
            // LblUserID
            // 
            this.LblUserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblUserID.AutoSize = true;
            this.LblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUserID.ForeColor = System.Drawing.Color.Black;
            this.LblUserID.Location = new System.Drawing.Point(36, 149);
            this.LblUserID.Name = "LblUserID";
            this.LblUserID.Size = new System.Drawing.Size(0, 20);
            this.LblUserID.TabIndex = 3;
            this.LblUserID.Visible = false;
            // 
            // TxtSamllUnit
            // 
            this.TxtSamllUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSamllUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSamllUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtSamllUnit.Location = new System.Drawing.Point(171, 122);
            this.TxtSamllUnit.Name = "TxtSamllUnit";
            this.TxtSamllUnit.Size = new System.Drawing.Size(253, 26);
            this.TxtSamllUnit.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(502, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "اصغر وحده";
            // 
            // TxtSamllUnitNumbers
            // 
            this.TxtSamllUnitNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSamllUnitNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSamllUnitNumbers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtSamllUnitNumbers.Location = new System.Drawing.Point(171, 170);
            this.TxtSamllUnitNumbers.Name = "TxtSamllUnitNumbers";
            this.TxtSamllUnitNumbers.Size = new System.Drawing.Size(253, 26);
            this.TxtSamllUnitNumbers.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(446, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "عدد الوحدات الصغرى ";
            // 
            // BtnAddUnit
            // 
            this.BtnAddUnit.BackColor = System.Drawing.Color.Green;
            this.BtnAddUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BtnAddUnit.Location = new System.Drawing.Point(24, 67);
            this.BtnAddUnit.Name = "BtnAddUnit";
            this.BtnAddUnit.Size = new System.Drawing.Size(95, 126);
            this.BtnAddUnit.TabIndex = 6;
            this.BtnAddUnit.Text = "إضافة الوحده";
            this.BtnAddUnit.UseVisualStyleBackColor = false;
            this.BtnAddUnit.Click += new System.EventHandler(this.BtnAddUnit_Click);
            // 
            // BtnEditUnit
            // 
            this.BtnEditUnit.BackColor = System.Drawing.Color.Green;
            this.BtnEditUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnEditUnit.Location = new System.Drawing.Point(26, 82);
            this.BtnEditUnit.Name = "BtnEditUnit";
            this.BtnEditUnit.Size = new System.Drawing.Size(95, 126);
            this.BtnEditUnit.TabIndex = 13;
            this.BtnEditUnit.Text = "تعديل الوحده";
            this.BtnEditUnit.UseVisualStyleBackColor = false;
            // 
            // TxtNumberOfSmall
            // 
            this.TxtNumberOfSmall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNumberOfSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumberOfSmall.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtNumberOfSmall.Location = new System.Drawing.Point(173, 185);
            this.TxtNumberOfSmall.Name = "TxtNumberOfSmall";
            this.TxtNumberOfSmall.Size = new System.Drawing.Size(253, 26);
            this.TxtNumberOfSmall.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(448, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "عدد الوحدات الصغرى ";
            // 
            // TxtSmUnit
            // 
            this.TxtSmUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSmUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSmUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtSmUnit.Location = new System.Drawing.Point(173, 137);
            this.TxtSmUnit.Name = "TxtSmUnit";
            this.TxtSmUnit.Size = new System.Drawing.Size(253, 26);
            this.TxtSmUnit.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(504, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "اصغر وحده";
            // 
            // TxtMasterUnit
            // 
            this.TxtMasterUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtMasterUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMasterUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TxtMasterUnit.Location = new System.Drawing.Point(173, 80);
            this.TxtMasterUnit.Name = "TxtMasterUnit";
            this.TxtMasterUnit.Size = new System.Drawing.Size(253, 26);
            this.TxtMasterUnit.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(464, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "اسم الوحده الرئيسيه";
            // 
            // CBItemUnit
            // 
            this.CBItemUnit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CBItemUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBItemUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBItemUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CBItemUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBItemUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.CBItemUnit.ForeColor = System.Drawing.Color.Teal;
            this.CBItemUnit.FormattingEnabled = true;
            this.CBItemUnit.Location = new System.Drawing.Point(173, 23);
            this.CBItemUnit.Name = "CBItemUnit";
            this.CBItemUnit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CBItemUnit.Size = new System.Drawing.Size(253, 23);
            this.CBItemUnit.TabIndex = 73;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(464, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 74;
            this.label7.Text = "الوحده المراد تعديلها";
            // 
            // UnitsManger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(643, 287);
            this.Controls.Add(this.LblUserID);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UnitsManger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدارة الوحدات";
            this.Load += new System.EventHandler(this.UnitsManger_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBigUnit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label LblUserID;
        private System.Windows.Forms.TextBox TxtSamllUnitNumbers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtSamllUnit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnAddUnit;
        private System.Windows.Forms.Button BtnEditUnit;
        private System.Windows.Forms.TextBox TxtNumberOfSmall;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtSmUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtMasterUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CBItemUnit;
    }
}
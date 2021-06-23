using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity.Validation;

namespace I_Count
{
    public partial class Sales : Form
    {
      //  SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        AccountingEntities context = new AccountingEntities();
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public Sales(int ID)
        {
            InitializeComponent();
            // هنا هاياخد ال ID اللى جايله 
            // يروح يدور بيه على اليوزر ويدينى ال IDبتاعه 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TblUsers where UserID=@UserID  ";

            cmd.Parameters.AddWithValue("@UserID", ID);

            SqlDataReader dr;
            Con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                this.LblUserID.Text = dr["UserID"].ToString();
                this.LblUserName.Text = dr["Name"].ToString();
                this.LblPostion.Text = dr["PositionID"].ToString();

            }

            dr.Close();
            Con.Close();
        }
        //  //////////////////////////////////////////////
        private void BtnBuy_Click(object sender, EventArgs e)//////////////////Done
        {
            this.Visible = false;
            Procurement PRO = new Procurement(int.Parse(this.LblUserID.Text));
            PRO.Visible = true;
        }

        // وهنا انا بجيب المخزن 
        private void LoadStore()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStore ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStore");
            CBStore.DisplayMember = "StoreName";
            CBStore.ValueMember = "StoreID";
            CBStore.DataSource = ds.Tables["TblStore"];
            CBStore.SelectedItem = null;
            Con.Close();
        }
        /////////////  
        /// <summary>
        /////////////////////////////////////////////////// وهنا انا بجيب الخزنه///////////////////////////
        private void loadStorage()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStorages ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStorages");
            CBStrorage.DisplayMember = "StorageName";
            CBStrorage.ValueMember = "StorageID";
            CBStrorage.DataSource = ds.Tables["TblStorages"];
            CBStrorage.SelectedItem = null;
            Con.Close();
        }
        ////////////////////////////////////////////////////////////////////////////
        ///// هنا بقى هاجيب اسم العميل 
        private void LoadCustomer()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblCustomers ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblCustomers");
            CBCustomer.DisplayMember = "CustomerName";
            CBCustomer.ValueMember = "CustomerID";
            CBCustomer.DataSource = ds.Tables["TblCustomers"];
            CBCustomer.SelectedItem = null;
            Con.Close();
        }

        //////////////////////////////////////////////////////////////////////////////////
        // هنا بقى هاعمل الدفع 
        private void Payment()
        {

            if (this.CBStrorage.SelectedValue.ToString()== "3") 
            {
                
            }
            else
            {
                SqlCommand CmdStorage = new SqlCommand();
                CmdStorage.Connection = Con;
                CmdStorage.CommandType = CommandType.Text;
                CmdStorage.CommandText = "select * from TblStorages where StorageID=@StorageID";

                CmdStorage.Parameters.AddWithValue("@StorageID", this.CBStrorage.SelectedValue);

                SqlDataReader SR;
                Con.Open();
                SR = CmdStorage.ExecuteReader();
                //// وهنا برضه هايدفع من الخزنه حسب الطريه اللى يختارها 
                if (SR.Read())
                {
                    double X = double.Parse(SR["TotalMoney"].ToString());
                    double y = double.Parse(this.Txtpaid.Text);
                    double W = X + y;


                    Con.Close();

                    SqlCommand StorageUpdate = new SqlCommand();
                    StorageUpdate.Connection = Con;
                    StorageUpdate.CommandType = CommandType.Text;
                    StorageUpdate.CommandText = "update TblStorages set TotalMoney=@TotalMoney where StorageID=@StorageID";

                    StorageUpdate.Parameters.AddWithValue("@TotalMoney", W);
                    StorageUpdate.Parameters.AddWithValue("@StorageID", this.CBStrorage.SelectedValue);

                    Con.Open();
                    StorageUpdate.ExecuteNonQuery();
                    Con.Close();

                }

                SR.Close();
                Con.Close();
               
            }
               
        }
        ////////////////////////////////////////////////////////////////////////////////////
        // انا هنا بقى هاعمل ايه يروح يشوف اذاك كانت حسابت اجله يزودها على ام العميل 
        // وفى حته كمان هانعملها  قدام لما يجى يبيع لعميل 

        private void CustomerDebit()
        {

            // اول حاجه هايعمل condition

            if (this.TxtTotal.Text != this.Txtpaid.Text)
            {
                //وبعد كده هايعمل search 
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from TblCustomers where CustomerID=@CustomerID ";

                Cmd.Parameters.AddWithValue("@CustomerID", this.LblCustomerID.Text);

                SqlDataReader dr;
                Con.Open();
                dr = Cmd.ExecuteReader();
                if (dr.Read())
                {
                    
                    // هايروح بقى يعمل Update ب الرصيد الجديد
                    double M = double.Parse(this.TxtTotal.Text); // الاجمالى

                    double F = double.Parse(this.Txtpaid.Text); // المدفوع

                    double KH = double.Parse(this.TxtOffer.Text); // الخصم

                    double E = double.Parse(dr["Debit"].ToString()); // رصيده

                    double toto = M-KH; // الجمالى - الخصم

                    double K = toto- F; // نطرح منهم المدفوع

                    double A = K + E; // ونضيفهم على الرصيد
                    Con.Close();

                    SqlCommand UpdateCredit = new SqlCommand();
                    UpdateCredit.Connection = Con;
                    UpdateCredit.CommandType = CommandType.Text;
                    UpdateCredit.CommandText = "Update TblCustomers set Debit=@Debit where CustomerID=@CustomerID";

                    UpdateCredit.Parameters.AddWithValue("@Debit", A);
                    UpdateCredit.Parameters.AddWithValue("@CustomerID", this.LblCustomerID.Text);

                    Con.Open();
                    UpdateCredit.ExecuteNonQuery();
                    Con.Close();

                }
                dr.Close();
                Con.Close();
            }


        }


        //////////////////////////////////////////
        // load Prodct type 
        private void LoadProductType()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProductType ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblProductType");
            CBItemType.DisplayMember = "ProductType";
            CBItemType.ValueMember = "ProductTypeID";
            CBItemType.DataSource = ds.Tables["TblProductType"];
            CBItemType.SelectedItem = null;
            Con.Close();
        }
        
        
        
        ///////////////////////////////////
        // ///////////////////////////////////////////
        private void ShowTemp()
        {
            int TempUser = int.Parse(LblUserID.Text);
            var TempOfLoginUser = context.TblTemps.Where(a => a.UserID == TempUser && a.TempType == 2).ToList();
            foreach (var item in TempOfLoginUser)
            {
                this.GVShowProducts.Rows.Add(item.TypeName,item.ProductName, item.Price, item.Quntity,item.Total, item.ProductId,item.ProducttypeID, item.Exsit, item.Earn,item.Notes);
            }
        }
        // /////////////////////////////////////////
       
     
     
        private void Sales_Load(object sender, EventArgs e)
        {
           this.LoadStore();
           this.loadStorage();
           this.LoadCustomer();
           this.WindowState = FormWindowState.Maximized;
           this.ShowTemp();
           if (this.LblPostion.Text=="2")
           {
               this.LblSalePrice.Hide();
           }
       
        }

        private void BtnSale1_Click(object sender, EventArgs e) /////////////////// ده علشان يغير سعر البيع من 2 ل1  
        {

            try
            {

           
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select *  from LoadProducts where ProductID=@ProductID";

            Cmd.Parameters.AddWithValue("@ProductID", this.CBItemName.SelectedValue);

            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();
            if (dr.Read())
            {
                this.TxtPrice.Text = dr["SalePrice1"].ToString();
               
            }
            dr.Close();
            Con.Close();
            }
            catch (Exception)
            {

              
            }
           
        }
        /// <summary>
        /// بص يا سيدى هو المفروض لما يختار المخزن وبعد كده يختار النوع وبعد كده يختار الاسم العمليه 
        /// المفروض تبقى ماشيه بالترتيب ده 
        /// تعالى نشوف 3:)
        /// 
        /// </summary>
        
        private void CBStore_SelectionChangeCommitted(object sender, EventArgs e)////////////////////////////////// هنا هايختار المخزن اللى هايبيع منه البضاعه  
        {
           ////////////////////////////////
            this.LoadProductType();
           
        }

        private void CBItemName_SelectionChangeCommitted(object sender, EventArgs e)///////////////////// وهنا بيختار اسم الصنف 
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select *  from LoadProducts where ProductID=@ProductID";

            Cmd.Parameters.AddWithValue("@ProductID", this.CBItemName.SelectedValue);

            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();
            if (dr.Read())
            {
                this.TxtPrice.Text = dr["SalePrice1"].ToString();
                this.LblSalePrice.Text = dr["Price"].ToString();
                this.LblExsist.Text = dr["Exist"].ToString();
            }
            dr.Close();
            Con.Close();

        }

        private void CBItemType_SelectionChangeCommitted(object sender, EventArgs e) /////////////////// وهنا بيختار نوع الصنف هى مش مترتبه بس مترتبه فى الاكواد لا تقلق  
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID ";

            Cmd.Parameters.AddWithValue("@ProductTypeID ", this.CBItemType.SelectedValue);
            Cmd.Parameters.AddWithValue("@StoreID ", this.CBStore.SelectedValue);

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblProducts");
            CBItemName.DisplayMember = "ProductName";
            CBItemName.ValueMember = "ProductID";
            CBItemName.DataSource = ds.Tables["TblProducts"];
            CBItemName.SelectedItem = null;

            Con.Close();
        }

        private void BtnSale2_Click(object sender, EventArgs e) /////////////////// ده علشان يغير سعر البيع من 1 ل 2 
        {
            try
            {

           
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select *  from LoadProducts where ProductID=@ProductID";

            Cmd.Parameters.AddWithValue("@ProductID", this.CBItemName.SelectedValue);

            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();
            if (dr.Read())
            {
                this.TxtPrice.Text = dr["SalePrice2"].ToString();

            }
            dr.Close();
            Con.Close();
            }
            catch (Exception)
            {

               
            }

        }

        // بص بقى اللى جاى ده لحد الخط واخدهم كوبى من الفورم التانى لانها نفس العمليه

        private void TxtQuantity_TextChanged(object sender, EventArgs e)//////////////////////////////////////
        {
            // ده بقى بعمل ايه ! بص بيجيب حاصل ضرب السعر فى الكميه علشان يطلعله القيمه كامله 
            // وانا عامل try علشان كان بيطلع error 3:)

            try
            {
                if (this.TxtPrice.Text != null)
                {
                    double price = double.Parse(this.TxtPrice.Text);
                    double Quantity = double.Parse(this.TxtQuantity.Text);
                    this.TxtValue.Text = (price * Quantity).ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)////////////////////////////
        {
            // ده بقى بعمل ايه ! بص بيجيب حاصل ضرب السعر فى الكميه علشان يطلعله القيمه كامله 
            // وانا عامل try علشان كان بيطلع error 3:)

            try
            {
                if (this.TxtPrice.Text != null)
                {
                    double price = double.Parse(this.TxtPrice.Text);
                    double Quantity = double.Parse(this.TxtQuantity.Text);
                    this.TxtValue.Text = (price * Quantity).ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        private void TxtValue_TextChanged(object sender, EventArgs e)///////////////////////////////////
        {
            // :D "وده بقى علشان لو حب يتذاكى ويحط القيمه كلها يجبله سعر الحته 
            try
            {
                if (this.TxtValue.Text != null)
                {
                    double Value = double.Parse(this.TxtValue.Text);
                    double Quantity = double.Parse(this.TxtQuantity.Text);

                    this.TxtPrice.Text = (Value / Quantity).ToString();
                }
            }
            catch (Exception)
            {


            }
        }
        /// <summary>
        /// هنا علشان يطلعلى اجمالى الفاتوره 
        /// </summary>
       
        private void GVShowProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double sum = 0;
            double buing = 0;
            for (int i = 0; i < GVShowProducts.Rows.Count; ++i)
            {
                sum += double.Parse(GVShowProducts.Rows[i].Cells["Total"].Value.ToString());
                buing += double.Parse(GVShowProducts.Rows[i].Cells["Earn"].Value.ToString());
                
            }
            this.TxtTotal.Text = sum.ToString();
            this.LblTotalBuyingMony.Text = buing.ToString();

          
        }

        private void TxtOffer_TextChanged(object sender, EventArgs e)
        {
            // دى نسبة الخصم 
            try
            {
                if (this.TxtOffer.Text != null)
                {

                    if (this.ChPercent.Checked)
                    {
                        double Total = double.Parse(this.TxtTotal.Text);
                        double Offer = double.Parse(this.TxtOffer.Text);
                        double percent = (Total * Offer / 100);
                        this.Txtpaid.Text = (Total - percent).ToString();

                    }
                    else
                    {
                        double Total = double.Parse(this.TxtTotal.Text);
                        double Offer = double.Parse(this.TxtOffer.Text);
                        this.Txtpaid.Text = (Total - Offer).ToString();
                    }

                }

            }
            catch (Exception)
            {


            }

        }

        private void ChPercent_MouseHover(object sender, EventArgs e)
        {
            this.LblNote.Visible = true;

        }

        private void ChPercent_MouseLeave(object sender, EventArgs e)
        {
            this.LblNote.Visible = false;

        }

        private void BtnAddProvider_Click(object sender, EventArgs e)
        {
            // بيظهر اضافةعميل جديد
            this.LblName.Visible = true;
            this.LblPhone.Visible = true;
            this.LblCompany.Visible = true;
            this.TxtName.Visible = true;
            this.TxtTelephone.Visible = true;
            this.TxtCompany.Visible = true;
            this.BtnAddProv.Visible = true;

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////

        private void BtnAddProv_Click(object sender, EventArgs e)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "AddCustomer";

            Cmd.Parameters.AddWithValue("@CustomerName", this.TxtName.Text);
            Cmd.Parameters.AddWithValue("@CustomerPhone", this.TxtTelephone.Text);
            Cmd.Parameters.AddWithValue("@CustomerCompany", this.TxtCompany.Text);
            Cmd.Parameters.AddWithValue("@Credit","0");
            Cmd.Parameters.AddWithValue("@Debit", "0");

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@CustomerID";
            p1.SqlDbType = SqlDbType.Int;
            p1.Direction = ParameterDirection.Output;
            Cmd.Parameters.Add(p1);
            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
            this.LblCustomerID.Text = Cmd.Parameters["@CustomerID"].Value.ToString();
            this.LblName.Visible = false;
            this.LblPhone.Visible = false;
            this.LblCompany.Visible = false;
            this.TxtName.Visible = false;
            this.TxtTelephone.Visible = false;
            this.TxtCompany.Visible = false;
            this.BtnAddProv.Visible = false;
            MessageBox.Show("Done", "Creative Care");
            this.LoadCustomer();

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //    بص اسيدى هنا بيضيف العك اللى هو كتبه فى الجدول تحت 
            //try
            //{
                if (this.LblCustomerID.Text == "")
                {
                    if (this.CBCustomer.SelectedItem != null)
                    {
                        this.LblCustomerID.Text = this.CBCustomer.SelectedValue.ToString();
                    }

                }

                //////         لو الكميه المباعه اصغر من الموجوده 
                if (this.TxtQuantity.Text == string.Empty || this.TxtValue.Text == string.Empty || this.CBItemType.SelectedItem == null || this.CBItemName.SelectedItem == null)
                {
                    MessageBox.Show("من فضلك تاكد من ان البيانات صحيحه ", "Creative Care");

                }
                else
                {

                    double A = double.Parse(this.LblExsist.Text);
                    double B = double.Parse(this.TxtQuantity.Text);
                    if (A < B)
                    {
                        MessageBox.Show("الكميه الموجوده فى المخزن لا تكفى", "Creative Care");
                    }
                    else
                    {
                       

                        double Toto = double.Parse(this.TxtQuantity.Text);
                        double Fofo = double.Parse(this.LblSalePrice.Text);
                        double Prico = double.Parse(this.TxtPrice.Text);
                        double preearn = Prico - Fofo;
                        double Earnoo = preearn * Toto;
                    if (Prico < Fofo)
                    {
                        DialogResult dialogResult = MessageBox.Show(" هذه عملية بيع تحتوى على خساره هل تريد المتابعه ", "Creative Care ", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            if (this.TxtNotes.Text == "")
                            {
                                this.GVShowProducts.Rows.Add(this.CBItemType.Text, this.CBItemName.Text, this.TxtPrice.Text, this.TxtQuantity.Text, this.TxtValue.Text, this.CBItemName.SelectedValue, this.CBItemType.SelectedValue, this.LblExsist.Text, Earnoo.ToString(), "------");
                            }
                            else
                            {

                                this.GVShowProducts.Rows.Add(this.CBItemType.Text, this.CBItemName.Text, this.TxtPrice.Text, this.TxtQuantity.Text, this.TxtValue.Text, this.CBItemName.SelectedValue, this.CBItemType.SelectedValue, this.LblExsist.Text, Earnoo.ToString(), this.TxtNotes.Text);

                            }
                            ////////////////////////////////////////////////////

                            TblTemp SaTemp = new TblTemp();
                            SaTemp.UserID = int.Parse(LblUserID.Text);
                            SaTemp.TypeName = this.CBItemType.Text;
                            SaTemp.ProductName = this.CBItemName.Text;
                            SaTemp.Price = double.Parse(this.TxtPrice.Text);
                            SaTemp.Quntity = double.Parse(this.TxtQuantity.Text);
                            SaTemp.Total = double.Parse(this.TxtValue.Text);
                            SaTemp.ProductId = int.Parse(this.CBItemName.SelectedValue.ToString());
                            SaTemp.ProducttypeID = int.Parse(this.CBItemType.SelectedValue.ToString());
                            SaTemp.Exsit = double.Parse(this.LblExsist.Text);
                            SaTemp.Earn = Earnoo;
                            SaTemp.Notes ="----------";
                            SaTemp.TempType = 2;

                            context.TblTemps.Add(SaTemp);
                            context.SaveChanges();






                            // ويرجع يفضى تانى علشان لو هايكتب حاجه جديده :D
                            this.CBItemType.SelectedItem = null;
                            this.CBItemName.SelectedItem = null;
                            this.TxtPrice.Text = string.Empty;
                            this.TxtQuantity.Text = string.Empty;
                            this.TxtValue.Text = string.Empty;
                            this.LblSalePrice.Text = "";
                            this.LblExsist.Text = "";
                            this.TxtNotes.Text = "";
                            this.CBItemType.Focus();

                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                    }
                    else
                    {
                        if (this.TxtNotes.Text == "")
                        {
                            this.GVShowProducts.Rows.Add(this.CBItemType.Text, this.CBItemName.Text, this.TxtPrice.Text, this.TxtQuantity.Text, this.TxtValue.Text, this.CBItemName.SelectedValue, this.CBItemType.SelectedValue, this.LblExsist.Text, Earnoo.ToString(), "--------");
                        }
                        else
                        {

                            this.GVShowProducts.Rows.Add(this.CBItemType.Text, this.CBItemName.Text, this.TxtPrice.Text, this.TxtQuantity.Text, this.TxtValue.Text, this.CBItemName.SelectedValue, this.CBItemType.SelectedValue, this.LblExsist.Text, Earnoo.ToString(), this.TxtNotes.Text);

                        }
                        ////////////////////////////////////////////////////
                        TblTemp SaTemp = new TblTemp();
                        SaTemp.UserID = int.Parse(LblUserID.Text);
                        SaTemp.TypeName = this.CBItemType.Text;
                        SaTemp.ProductName = this.CBItemName.Text;
                        SaTemp.Price = double.Parse(this.TxtPrice.Text);
                        SaTemp.Quntity = double.Parse(this.TxtQuantity.Text);
                        SaTemp.Total = double.Parse(this.TxtValue.Text);
                        SaTemp.ProductId = int.Parse(this.CBItemName.SelectedValue.ToString());
                        SaTemp.ProducttypeID = int.Parse(this.CBItemType.SelectedValue.ToString());
                        SaTemp.Exsit = double.Parse(this.LblExsist.Text);
                        SaTemp.Earn = Earnoo;
                        SaTemp.Notes = "-----------------";
                        SaTemp.TempType = 2;

                        context.TblTemps.Add(SaTemp);
                        context.SaveChanges();



                        // ويرجع يفضى تانى علشان لو هايكتب حاجه جديده :D
                        this.CBItemType.SelectedItem = null;
                        this.CBItemName.SelectedItem = null;
                        this.TxtPrice.Text = string.Empty;
                        this.TxtQuantity.Text = string.Empty;
                        this.TxtValue.Text = string.Empty;
                        this.LblSalePrice.Text = "";
                        this.LblExsist.Text = "";
                        this.TxtNotes.Text = "";

                    }



                    }
                }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("من فضلك تاكد ان البيانات المطلوبه صحيحه","Creative Care");
            //}

        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            int OutID = 0;
            //try
            //{

                if (this.CBStore.SelectedItem == null)
                {
                    MessageBox.Show("من فضلك اختار المخزن", "Creative Care");
                    return;
                }
                else
                {

                    this.BtnConfirm.Enabled = false;

                    /*Con.Close();*/// هنا بقفل الكونكشن مش عارف ليه :D

                    if (this.CBStrorage.SelectedItem == null)
                    {
                        MessageBox.Show("من فضلك اختار الخزنه", "Creative Care");
                        this.CBStrorage.Focus();
                        this.BtnConfirm.Enabled = true;
                        return;
                    }
                    else
                    {

                        ////// بشوف اذا اكنت الفاتوره اجل ولا لا 
                        if (double.Parse(this.TxtTotal.Text) != double.Parse(this.Txtpaid.Text) && this.LblCustomerID.Text == "" && this.TxtOffer.Text == "0")
                        {

                            MessageBox.Show(this.CBCustomer.Focus() + "الفاتوره تحتوى على حسابات اجله من فضلك اختار اسم العميل ");
                            this.CBCustomer.Focus();
                            this.BtnConfirm.Enabled = true;
                        }
                        // ده علشان لو ما اختارش اسم عميل يجبله لا احد علشان ما يطلعش ايرورو /////////////////////////////////////// 
                        else
                        {
                            if (this.LblCustomerID.Text == "")
                            {
                                this.LblCustomerID.Text = "2";
                            }
                            ///////////////////////////////////////////////////////

                            ////// //////////////////////////////////////  هاروح الاول اعمل فاتوره زى ما اتعودنا :D يا مسهل 
                            //double toto = double.Parse(this.TxtTotal.Text);
                            double Earno = double.Parse(this.LblTotalBuyingMony.Text);
                            double offer = double.Parse(this.TxtOffer.Text);

                            double lastearn = Earno - offer;
                            //double EarnYAA = toto - Earno;




                            TblSaleBill SaleBill = new TblSaleBill();
                            SaleBill.BillDate = this.DtDateTime.Value.Date;
                            SaleBill.CustomerID = int.Parse(LblCustomerID.Text);
                            SaleBill.Total = this.TxtTotal.Text;
                            SaleBill.UserID = int.Parse(LblUserID.Text);
                            SaleBill.Paid = this.Txtpaid.Text;
                            SaleBill.Earn = lastearn.ToString();
                            SaleBill.Discount = this.TxtOffer.Text;
                            SaleBill.StoreID = int.Parse(this.CBStore.SelectedValue.ToString());

                            context.TblSaleBills.Add(SaleBill);
                            context.SaveChanges();

                            int BillID = SaleBill.SaleBillID;

                            OutID = SaleBill.SaleBillID;


                            ///////////////////////////////////////////////////////////////////////////////////////

                            // هنا بقى هايروح يسحل عملية البيع 
                            //هو بياخد البيانات اللى بيدور عليها من الجريد فيو 

                            foreach (DataGridViewRow row in GVShowProducts.Rows)
                            {

                                int SelctProdcutID = int.Parse(row.Cells["ProductID"].Value.ToString());

                                var Product = context.TblProducts.Where(a => a.ProductID == SelctProdcutID).FirstOrDefault();
                                double x = double.Parse(Product.Exist.ToString());
                                double w = double.Parse(row.Cells["Quantity"].Value.ToString());
                                double A = x - w;

                                Product.Exist = A;
                                context.SaveChanges();

                            try
                            {
                                TblSale Sale = new TblSale();
                                Sale.ProductID = SelctProdcutID;
                                Sale.ProductTypeID = Product.ProductTypeID;
                                Sale.SaleBillID = BillID;
                                Sale.Quantity = w.ToString();
                                Sale.Price = row.Cells["Price"].Value.ToString();
                                Sale.BTotal = row.Cells["Total"].Value.ToString();
                                Sale.SNotes = row.Cells["SNotes"].Value.ToString();

                                context.TblSales.Add(Sale);
                                context.SaveChanges();
                                //}
                                //catch (DbEntityValidationException ex)
                                //{
                                //    // Retrieve the error messages as a list of strings.
                                //    var errorMessages = ex.EntityValidationErrors.SelectMany(a => a.ValidationErrors)
                                //            .Select(a => a.ErrorMessage);

                                //    // Join the list to a single string.
                                //    var fullErrorMessage = string.Join("; ", errorMessages);

                                //    // Combine the original exception message with the new one.
                                //    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                                //    // Throw a new DbEntityValidationException with the improved exception message.
                                //    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

                                //}

                            }
                            catch (Exception ex)
                            {

                                var Saal = context.TblSales.Where(a => a.SaleBillID == BillID).ToList();

                                foreach (var item in Saal)
                                {
                                    double Quy = double.Parse(item.Quantity.ToString());
                                    var ProOld = context.TblProducts.Where(a => a.ProductID == item.ProductID).FirstOrDefault();
                                    ProOld.Exist = ProOld.Exist - Quy;
                                    context.SaveChanges();

                                    context.TblSales.Remove(item);
                                    context.SaveChanges();
                                }

                                var BillsaleRe = context.TblSaleBills.Where(a => a.SaleBillID == BillID).FirstOrDefault();
                                context.TblSaleBills.Remove(BillsaleRe);
                                context.SaveChanges();
                                MessageBox.Show(ex.ToString());
                                return;
                            }



                            // add to movement

                            TblProductsMovement Movem = new TblProductsMovement();
                                Movem.MoveQuantity = w.ToString();
                                Movem.ProductID = SelctProdcutID;
                                Movem.TemporaryID = 2;
                                Movem.MoveDate = DateTime.Now;
                                Movem.MoveValue = row.Cells["Total"].Value.ToString();

                                context.TblProductsMovements.Add(Movem);
                                context.SaveChanges();

                                
                            }
                            ////////////////////////////////////////////////////////////////////////////////////
                            //طبعاً دلوقتى هو محتاج يدفع بس
                            if (this.CBStrorage.SelectedValue.ToString() != "3" )
                            {
                                int TruserID = int.Parse(this.CBStrorage.SelectedValue.ToString());

                                var Truser = context.TblStorages.Where(a => a.StorageID == TruserID).FirstOrDefault();

                                double NewBalnce = double.Parse(this.Txtpaid.Text);
                                double OldBalance = double.Parse(Truser.TotalMoney);

                                double CurrentBalance = OldBalance + NewBalnce;

                                Truser.TotalMoney = CurrentBalance.ToString();
                                context.SaveChanges();

                            }

                            if (double.Parse(this.TxtTotal.Text) != double.Parse(this.Txtpaid.Text) && this.LblCustomerID.Text != "2")
                            {
                                int CuCustomerID = int.Parse(LblCustomerID.Text);

                                var MyCustomer = context.TblCustomers.Where(a => a.CustomerID == CuCustomerID).FirstOrDefault();


                                // هايروح بقى يعمل Update ب الرصيد الجديد
                                double MTotal = double.Parse(this.TxtTotal.Text); // الاجمالى

                                double FPaide = double.Parse(this.Txtpaid.Text); // المدفوع

                                double KHDiccount = double.Parse(this.TxtOffer.Text); // الخصم

                                double EDebit = double.Parse(MyCustomer.Debit); // رصيده

                                double toto = MTotal - KHDiccount; // الجمالى - الخصم

                                double KSum = toto - FPaide; // نطرح منهم المدفوع

                                double AFinal = KSum + EDebit; // ونضيفهم على الرصيد

                                MyCustomer.Debit = AFinal.ToString();
                                context.SaveChanges();
                            }



                            ////////////////////////////////////////////////
                            if (this.CBCustomer.SelectedItem != null)
                            {
                                //////////////////////////////////////
                                //// تسجيل العمليه خاص ب جالرى القصر


                                TblCusPro CuProc = new TblCusPro();
                                CuProc.DateOfProc = DateTime.Now;
                                CuProc.PayedValue = this.TxtTotal.Text;
                                CuProc.CustomerID = int.Parse(this.LblCustomerID.Text);
                                CuProc.ProcName = "شراء";

                                context.TblCusPros.Add(CuProc);
                                context.SaveChanges();

                                TblCusPro CuProce = new TblCusPro();
                                CuProce.DateOfProc = DateTime.Now;
                                CuProce.PayedValue = this.TxtTotal.Text;
                                CuProce.CustomerID = int.Parse(this.LblCustomerID.Text);
                                CuProce.ProcName = "سداد";

                                context.TblCusPros.Add(CuProce);
                                context.SaveChanges();


                            }


                            TblStorageProce StorageAction = new TblStorageProce();
                            StorageAction.SActionID = 2;
                            StorageAction.SPDate = DateTime.Now;
                            StorageAction.SPMoney = this.Txtpaid.Text;
                            StorageAction.StorageID = int.Parse(this.CBStrorage.SelectedValue.ToString());

                            context.TblStorageProces.Add(StorageAction);
                            context.SaveChanges();


                                
                            ///////////////////////////////////////
                            try
                            {
                                TblLog Log = new TblLog();
                                Log.UserID = int.Parse(this.LblUserID.Text);
                                Log.Discription = "  تسجيل فاتورة مبيعات  رقم: " + BillID;
                                Log.DateOfLog = DateTime.Now;

                                context.TblLogs.Add(Log);
                                context.SaveChanges();

                            }
                            catch (Exception)
                            {


                            }
                            ///////////////////////////////////
                            this.TxtTotal.Text = string.Empty;
                            this.CBStrorage.SelectedItem = null;
                            this.Txtpaid.Text = string.Empty;
                            this.CBStore.SelectedItem = null;
                            this.LblCustomerID.Text = "";
                            this.TxtNotes.Text = "";
                            this.GVShowProducts.Rows.Clear();
                            ///////////////////////////////////
                            // بيمسح بقى 
                            int TempUser = int.Parse(LblUserID.Text);

                            var SaleTemp = context.TblTemps.Where(a => a.TempType == 2 && a.UserID == TempUser).ToList();
                            foreach (var item in SaleTemp)
                            {
                                context.TblTemps.Remove(item);
                                context.SaveChanges();
                            }

                            MessageBox.Show(" تم تسجيل البيع بنجاح ", "Abdelrahman Abdelhameed",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            ///////////////////////////////
                            DialogResult dialogResult = MessageBox.Show("هل تريد الطباعه الفاتوره", "Creative Care ", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                SalesBills SB = new SalesBills(BillID);
                                SB.Show();
                            }
                            else if (dialogResult == DialogResult.No)
                            {

                            }
                        }

                    }
                    this.BtnConfirm.Enabled = true;

                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //    MessageBox.Show("من فضلك تاكد من البيانات الممطلوبه او كلم الدعم الفنى 01118754055");
            //}   
        }

       

        private void BtnHome_Click(object sender, EventArgs e)////////////Done
        {
            this.Close();
            Home HO = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            HO.Visible = true;
        }

       
        // هنا نف الكود علشان يجيب نوع المنتجات بس هو مش هايختار من الليست هو هايختار من الاقترحات 
        private void CBStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from LoadProducts where  StoreID=@StoreID ";

                Cmd.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "LoadProducts");
                CBItemType.DisplayMember = "ProductType";
                CBItemType.ValueMember = "ProductTypeID";
                CBItemType.DataSource = ds.Tables["LoadProducts"];
                CBItemType.SelectedItem = null;
                Con.Close();

                this.CBItemType.Focus();
            }
        }
        // نفس الذات نفس
        private void CBItemType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from TblProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID ";

                Cmd.Parameters.AddWithValue("@ProductTypeID ", this.CBItemType.SelectedValue);
                Cmd.Parameters.AddWithValue("@StoreID ", this.CBStore.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "TblProducts");
                CBItemName.DisplayMember = "ProductName";
                CBItemName.ValueMember = "ProductID";
                CBItemName.DataSource = ds.Tables["TblProducts"];
                CBItemName.SelectedItem = null;

                Con.Close();

                this.CBItemName.Focus();
            }
        }
        // // //  نفس الذات نفس 
        private void CBItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select *  from LoadProducts where ProductID=@ProductID";

            Cmd.Parameters.AddWithValue("@ProductID", this.CBItemName.SelectedValue);

            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();
            if (dr.Read())
            {
                this.TxtPrice.Text = dr["SalePrice1"].ToString();
                this.LblSalePrice.Text = dr["Price"].ToString();
                this.LblExsist.Text = dr["Exist"].ToString();
            }
            dr.Close();
            Con.Close();
            this.TxtQuantity.Focus();

        }

        }

        private void CBCustomer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LblCustomerID.Text = this.CBCustomer.SelectedValue.ToString();
        }

        private void BtnDelet_MouseHover(object sender, EventArgs e)
        {
            this.BtnDelet.ImageAlign = ContentAlignment.TopCenter;
            this.BtnDelet.Text = "مسح";
        }

        private void BtnDelet_MouseLeave(object sender, EventArgs e)
        {
            this.BtnDelet.ImageAlign = ContentAlignment.MiddleCenter;
            this.BtnDelet.Text = "";
        }

        private void BtnDelet_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show(" هل ب الفعل تريد حذف الذاكره المؤقته  ", "Creative Care ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                int UID = int.Parse(LblUserID.Text);

                var tem = context.TblTemps.Where(a => a.UserID == UID && a.TempType == 2).ToList();

                foreach (var item in tem)
                {
                    context.TblTemps.Remove(item);
                    context.SaveChanges();
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        

        private void TxtBarcode_KeyDown_1(object sender, KeyEventArgs e)
        {
            // هنا بقى البحث بتاع الباركود 
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from TblProducts where Barcode=@Barcode  ";

                Cmd.Parameters.AddWithValue("@Barcode ", this.TxtBarcode.Text);

                SqlDataReader dr;
                Con.Open();
                dr = Cmd.ExecuteReader();
                if (dr.Read())
                {
                    string ProT, ProN, Pros;
                    ProT = dr["ProductTypeID"].ToString();
                    ProN = dr["ProductID"].ToString();
                    Pros = dr["StoreID"].ToString();
                    //////////////////////////////////////////////////////////////
                    this.CBStore.SelectedValue = Pros;
                    //////////////////////////////////////////////////////////////
                    Con.Close();
                    SqlCommand type = new SqlCommand();
                    type.Connection = Con;
                    type.CommandType = CommandType.Text;
                    type.CommandText = "select * from TblProductType  ";

                  //  type.Parameters.AddWithValue("@ProductTypeID", ProT);

                    SqlDataAdapter da = new SqlDataAdapter(type);
                    Con.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "TblProductType");
                    CBItemType.DisplayMember = "ProductType";
                    CBItemType.ValueMember = "ProductTypeID";
                    CBItemType.DataSource = ds.Tables["TblProductType"];

                    this.CBItemType.SelectedValue = ProT;
                    Con.Close();
                    ///////////////////////////////////////////////////////////
                    SqlCommand Name = new SqlCommand();
                    Name.Connection = Con;
                    Name.CommandType = CommandType.Text;
                    Name.CommandText = "select * from TblProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID ";

                    Name.Parameters.AddWithValue("@ProductTypeID ", this.CBItemType.SelectedValue);
                    Name.Parameters.AddWithValue("@StoreID ", this.CBStore.SelectedValue);
                  //  Name.Parameters.AddWithValue("@ProductID ", ProN);

                    SqlDataAdapter Da = new SqlDataAdapter(Name);
                    Con.Open();
                    DataSet Ds = new DataSet();
                    Da.Fill(Ds, "TblProducts");
                    CBItemName.DisplayMember = "ProductName";
                    CBItemName.ValueMember = "ProductID";
                    CBItemName.DataSource = Ds.Tables["TblProducts"];
                    this.CBItemName.SelectedValue = ProN;
                    Con.Close();
                    ////////////////////////////////////////////////////
                    SqlCommand Toto = new SqlCommand();
                    Toto.Connection = Con;
                    Toto.CommandType = CommandType.Text;
                    Toto.CommandText = "select *  from LoadProducts where ProductID=@ProductID";

                    Toto.Parameters.AddWithValue("@ProductID", ProN);

                    SqlDataReader DR;
                    Con.Open();
                    DR = Toto.ExecuteReader();
                    if (DR.Read())
                    {
                        this.TxtPrice.Text = DR["SalePrice1"].ToString();
                        this.LblSalePrice.Text = DR["Price"].ToString();
                        this.LblExsist.Text = DR["Exist"].ToString();
                    }
                    DR.Close();
                    Con.Close();

                }
                this.TxtBarcode.Text = "";
                dr.Close();
                Con.Close();
            }
        }

        private void PicRefresh_Click(object sender, EventArgs e)
        {
            this.LoadStore();
            this.loadStorage();
            this.LoadCustomer();
            this.ShowTemp();

            this.CBStore.SelectedItem = null;
            this.CBItemName.SelectedItem = null;
            this.CBItemType.SelectedItem = null;
            this.TxtPrice.Text = "";
            this.LblExsist.Text = "";
            this.LblSalePrice.Text = "";
        }

        private void GVShowProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double sum = 0;
            double buing = 0;
            for (int i = 0; i < GVShowProducts.Rows.Count; ++i)
            {
                sum += double.Parse(GVShowProducts.Rows[i].Cells["Total"].Value.ToString());
                buing += double.Parse(GVShowProducts.Rows[i].Cells["Earn"].Value.ToString());
            }
            this.TxtTotal.Text = sum.ToString();
            this.LblTotalBuyingMony.Text = buing.ToString();
        }

        private void GVShowProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            double sum = 0;
            double buing = 0;
            for (int i = 0; i < GVShowProducts.Rows.Count; ++i)
            {
                double x = double.Parse(GVShowProducts.Rows[i].Cells["Price"].Value.ToString());
                double y = double.Parse(GVShowProducts.Rows[i].Cells["Quantity"].Value.ToString());

                double Toto = x * y;

                GVShowProducts.Rows[i].Cells["Total"].Value = Toto.ToString();
                sum += double.Parse(GVShowProducts.Rows[i].Cells["Total"].Value.ToString());
                buing += double.Parse(GVShowProducts.Rows[i].Cells["Earn"].Value.ToString());

            }
            this.TxtTotal.Text = sum.ToString();
            this.LblTotalBuyingMony.Text = buing.ToString();
           
        }

        private void TxtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.TxtPrice.Focus();
            }
        }

        private void TxtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.TxtValue.Focus();
            }
        }

        private void TxtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.TxtNotes.Focus();
            }
        }

        private void TxtNotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BtnAdd.Focus();
            }
        }

        private void TxtSerailSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                int Serail = int.Parse(this.TxtSerailSearch.Text);

                var Pro = context.TblProducts.Where(a => a.Serial == Serail).FirstOrDefault();
                if (Pro != null)
                {
                    string ProT, ProN, Pros;
                    ProT = Pro.ProductTypeID.ToString();

                    ProN = Pro.ProductID.ToString();
                    Pros = Pro.StoreID.ToString();
                    LblExsist.Text = Pro.Exist.ToString();
                    LblSalePrice.Text = Pro.Price;
                    //////////////////////////////////////////////////////////////
                    this.CBStore.SelectedValue = Pros;
                    //////////////////////////////////////////////////////////////
                    Con.Close();
                    SqlCommand type = new SqlCommand();
                    type.Connection = Con;
                    type.CommandType = CommandType.Text;
                    type.CommandText = "select * from TblProductType  ";

                    //  type.Parameters.AddWithValue("@ProductTypeID", ProT);

                    SqlDataAdapter da = new SqlDataAdapter(type);
                    Con.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "TblProductType");
                    CBItemType.DisplayMember = "ProductType";
                    CBItemType.ValueMember = "ProductTypeID";
                    CBItemType.DataSource = ds.Tables["TblProductType"];

                    this.CBItemType.SelectedValue = ProT;
                    Con.Close();
                    ///////////////////////////////////////////////////////////
                    SqlCommand Name = new SqlCommand();
                    Name.Connection = Con;
                    Name.CommandType = CommandType.Text;
                    Name.CommandText = "select * from TblProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID ";

                    Name.Parameters.AddWithValue("@ProductTypeID ", this.CBItemType.SelectedValue);
                    Name.Parameters.AddWithValue("@StoreID ", this.CBStore.SelectedValue);
                    //  Name.Parameters.AddWithValue("@ProductID ", ProN);

                    SqlDataAdapter Da = new SqlDataAdapter(Name);
                    Con.Open();
                    DataSet Ds = new DataSet();
                    Da.Fill(Ds, "TblProducts");
                    CBItemName.DisplayMember = "ProductName";
                    CBItemName.ValueMember = "ProductID";
                    CBItemName.DataSource = Ds.Tables["TblProducts"];
                    this.CBItemName.SelectedValue = ProN;
                    Con.Close();
                    ////////////////////////////////////////////////////
                    SqlCommand Toto = new SqlCommand();
                    Toto.Connection = Con;
                    Toto.CommandType = CommandType.Text;
                    Toto.CommandText = "select *  from LoadProducts where ProductID=@ProductID";

                    Toto.Parameters.AddWithValue("@ProductID", ProN);

                    SqlDataReader DR;
                    Con.Open();
                    DR = Toto.ExecuteReader();
                    if (DR.Read())
                    {
                        this.TxtPrice.Text = DR["SalePrice1"].ToString();

                    }
                    DR.Close();
                    Con.Close();

                }


                //}
                this.TxtSerailSearch.Text = "";

            }
        }

        


    }


}

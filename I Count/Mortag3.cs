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
using System.Threading;
using System.Configuration;

namespace I_Count
{
    public partial class Mortag3 : Form
    {
      //  SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        AccountingEntities context = new AccountingEntities();
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public Mortag3(int ID)
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

            }

            dr.Close();
            Con.Close();
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
        ///////////////  
        ///// <summary>
        ///////////////////////////////////////////////////// وهنا انا بجيب الخزنه///////////////////////////
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
        //////////////////////////////////////////////////////////////////////////////
        /////// هنا بقى هاجيب اسم العميل 
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

        ///////////////////////////////////////////////////////////////////////
        // وهنا بقى ها يجيب اسامى الموردين علشان يعرضهم لسيادته يختار منهم 

        private void LoadProviders()
        {

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProviders ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblProviders");
            CBProvider.DisplayMember = "ProviderName";
            CBProvider.ValueMember = "ProviderID";
            CBProvider.DataSource = ds.Tables["TblProviders"];
            CBProvider.SelectedItem = null;
            Con.Close();

        }
       
        ////////////////////////////////////////////////////////////////
        // وهنا هاجيب اسم المنجات  

        private void loadProducts()
        {

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID";

            Cmd.Parameters.AddWithValue("@ProductTypeID", this.CBItemType.SelectedValue);
            Cmd.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

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
        // وهنا نوع المنتجات 
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
        // ////////////////////////////////////////////////
        private void Payment()
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
                double y = double.Parse(this.TxtTotal.Text);
                double W = X - y;


                if (X > y)
                {
                    MessageBox.Show("النقود الموجوده بالخزنه لا تكفى ل اتمام العمليه هل تريد اختيار لا تدفع");

                    //DialogResult dialogResult = MessageBox.Show("النقود الموجوده بالخزنه لا تكفى ل اتمام العمليه هل تريد اختيار لا تدفع", "Creative Care Messages", MessageBoxButtons.YesNo);
                    //if (dialogResult == DialogResult.Yes)
                    //{

                    //}
                    //else if (dialogResult == DialogResult.No)
                    //{
                    //    this.CBStrorage.SelectedItem = null;
                    //    this.CBStrorage.Tag = true;
                    //}

                }
                else
                {
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


        ////////////////////////////////////////////////////////////////
        private void AddBackin()
        {
            ////////////////////////////////////////////////////////////////////////////
            // insert Back proc

            SqlCommand CmdInsert = new SqlCommand();
            CmdInsert.Connection = Con;
            CmdInsert.CommandType = CommandType.StoredProcedure;
            CmdInsert.CommandText = "InsertBackinbill";


            CmdInsert.Parameters.AddWithValue("@CustomerID", this.LblCustomerID.Text);
            CmdInsert.Parameters.AddWithValue("@DateOfBackeIn", this.DtDateTime.Value);
            CmdInsert.Parameters.AddWithValue("@TotalPaybake", this.TxtTotal.Text);
            CmdInsert.Parameters.AddWithValue("@UserID ", this.LblUserID.Text);
            CmdInsert.Parameters.AddWithValue("@StoreID ", this.CBStore.SelectedValue);

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@BackInID";
            p2.SqlDbType = SqlDbType.Int;
            p2.Direction = ParameterDirection.Output;
            CmdInsert.Parameters.Add(p2);
            Con.Open();
            CmdInsert.ExecuteNonQuery();
            Con.Close();

            ////////////////////////////////////////////////////////////////////////
            double Exsist, newe, updateed;
            foreach (DataGridViewRow row in GVShowProducts.Rows)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select *  from LoadProducts where ProductID=@ProductID ";

                Cmd.Parameters.AddWithValue("@ProductID", row.Cells["ProductID"].Value.ToString());
              


                SqlDataReader dr;
                Con.Open();
                dr = Cmd.ExecuteReader();
                if (dr.Read())
                {
                    Exsist = double.Parse(dr["Exist"].ToString());
                    newe = double.Parse(row.Cells["Quantity"].Value.ToString());
                    updateed = Exsist + newe;
                    Con.Close();
                    ///// her i will go and make update 
                    SqlCommand Cmdupdate = new SqlCommand();
                    Cmdupdate.Connection = Con;
                    Cmdupdate.CommandType = CommandType.Text;
                    Cmdupdate.CommandText = "Update TblProducts set Exist=@Exist where ProductID=@ProductID ";

                    Cmdupdate.Parameters.AddWithValue("@Exist", updateed);
                    Cmdupdate.Parameters.AddWithValue("@ProductID", row.Cells["ProductID"].Value.ToString());

                    Con.Open();
                    Cmdupdate.ExecuteNonQuery();
                    Con.Close();

                }
                dr.Close();
                Con.Close();
                // ////////////////////// her i will make insert the bill 

                SqlCommand CmdInsertBill = new SqlCommand();
                CmdInsertBill.Connection = Con;
                CmdInsertBill.CommandType = CommandType.StoredProcedure;
                CmdInsertBill.CommandText = "InsertBillIn";

                CmdInsertBill.Parameters.AddWithValue("@BackInID", CmdInsert.Parameters["@BackInID"].Value.ToString());
                CmdInsertBill.Parameters.AddWithValue("@ProductID", row.Cells["ProductID"].Value.ToString());
                CmdInsertBill.Parameters.AddWithValue("@BackProNu", row.Cells["Quantity"].Value.ToString());
                CmdInsertBill.Parameters.AddWithValue("@InPrice", row.Cells["Price"].Value.ToString());
                CmdInsertBill.Parameters.AddWithValue("@InTotal", row.Cells["Total"].Value.ToString());


                Con.Open();
                CmdInsertBill.ExecuteNonQuery();
                Con.Close();

                ///////////////////////////////////////////////////////////////////////////
                // وهنا بقى هايروح يضيف حركة الصنف 
                SqlCommand Move = new SqlCommand();
                Move.Connection = Con;
                Move.CommandType = CommandType.StoredProcedure;
                Move.CommandText = "AddProMovement";

                Move.Parameters.AddWithValue("@MoveQuantity", row.Cells["Quantity"].Value.ToString());
                Move.Parameters.AddWithValue("@ProductID", row.Cells["ProductID"].Value.ToString());
                Move.Parameters.AddWithValue("@TemporaryID", "3");
                Move.Parameters.AddWithValue("@MoveDate", this.DtDateTime.Value);
                Move.Parameters.AddWithValue("@MoveValue", row.Cells["Total"].Value.ToString());


                Con.Open();
                Move.ExecuteNonQuery();
                Con.Close();

                try
                {
                    TblLog Log = new TblLog();
                    Log.UserID = int.Parse(this.LblUserID.Text);
                    Log.Discription = " فاتورة مرتجع بيع رقم  : " + CmdInsert.Parameters["@BackInID"].Value.ToString();
                    Log.DateOfLog = DateTime.Now;

                    context.TblLogs.Add(Log);
                    context.SaveChanges();

                }
                catch (Exception)
                {


                }
            }
            ///////////////////////////////////////
            // هنا بقى انا هاروح اعمل عمليه مصروفات للفلوس اللى طلعت 
            SqlCommand Expen = new SqlCommand();
            Expen.Connection = Con;
            Expen.CommandType = CommandType.Text;
            Expen.CommandText = "insert into TblExpenses (ExpensesDate,ExpensesReason,Money,UserID,StorageID) values (@ExpensesDate,@ExpensesReason,@Money,@UserID,@StorageID)";

            Expen.Parameters.AddWithValue("@ExpensesDate", this.DtDateTime.Value);
            Expen.Parameters.AddWithValue("@ExpensesReason", "خصم ارباح مرتجع بيع ");
            Expen.Parameters.AddWithValue("@Money", this.LblFinalEran.Text);
            Expen.Parameters.AddWithValue("@UserID", this.LblUserID.Text);
            Expen.Parameters.AddWithValue("@StorageID", this.CBStrorage.SelectedValue);


            Con.Open();
            Expen.ExecuteNonQuery();
            Con.Close();
           
            ////////////////////////////////////////////////
            ///
            //////////////////////////////////////
            // clear history
            ///////////////////////////////////////////
          
            

            SqlCommand CmdDelete1 = new SqlCommand();
            CmdDelete1.Connection = Con;
            CmdDelete1.CommandType = CommandType.Text;
            CmdDelete1.CommandText = "delete from TblTemporary where TemporaryID=3  ";

            Con.Open();
            CmdDelete1.ExecuteNonQuery();
            Con.Close();
        }
        // ///////////////////////////////////
        // fucking alert 
        
        // ///////////////////////////////////////////////
        private void Mortag3_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.LoadProviders();
            this.LoadCustomer();
            this.LoadStore();
            this.loadStorage();

        }

        private void Pichome_Click(object sender, EventArgs e)
        {
            this.Close();
            Home HO = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            HO.Visible = true;
        }

        private void PicProvi_MouseHover(object sender, EventArgs e)
        {
            this.LblBackOut.Show();
        }

        private void PicProvi_MouseLeave(object sender, EventArgs e)
        {
            this.LblBackOut.Hide();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.LblBackIn.Show();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.LblBackIn.Hide();
        }

        private void PicProvi_Click(object sender, EventArgs e)
        {
            this.BtnDelet.Show();
            this.BtnToto.Hide();
            this.PanBarcode.Show();
            this.PanGride.Show();
            this.PanTools.Show();
            this.BtnAdd.Show();
            this.PanAddBackOut.Show();
            this.PanBackIn.Hide();
            this.CBCustomer.Hide();
            this.CBProvider.Show();
            this.LblProvidor.Show();
            this.LblCustomer.Hide();
            this.BtnAddIn.Hide();
            this.PanTotal.Show();
            this.PanStorage.Hide();
            this.TxtTotal.Text = string.Empty;
            // // // // // // // // // // 
            this.CBStore.SelectedItem = null;
            this.CBItemType.SelectedItem = null;
            this.CBItemName.SelectedItem = null;
            this.TxtPrice.Text = string.Empty;
            this.TxtQuantity.Text = string.Empty;
            this.TxtValue.Text = string.Empty;
            this.GVShowProducts.Rows.Clear();
            ///////////////////////////////////
            // بيعرض بقى 
            this.GVShowProducts.Rows.Clear();
            this.TxtTotal.Text = "";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TblTemporary where TemporaryID=4 ";

            SqlDataReader dr;
            Con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //
                this.GVShowProducts.Rows.Add(dr["TProType"].ToString(), dr["TproName"].ToString(), dr["TPrice"].ToString(), dr["TQuantity"].ToString(), dr["TTotal"].ToString(), dr["TID"].ToString(), dr["TSPrice"].ToString());

            }

            dr.Close();
            Con.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.PanBarcode.Show();
            this.BtnDelet.Hide();
            this.BtnToto.Show();
            this.PanGride.Show();
            this.PanTools.Show();
            this.BtnAdd.Hide();
            this.PanAddBackOut.Hide();
            this.PanBackIn.Show();
            this.CBCustomer.Show();
            this.CBProvider.Hide();
            this.LblProvidor.Hide();
            this.LblCustomer.Show();
            this.BtnAddIn.Show();
            this.PanTotal.Show();
            this.PanStorage.Show();
            this.TxtTotal.Text = string.Empty;
            // // // // // // // // // // 
            this.CBStore.SelectedItem = null;
            this.CBItemType.SelectedItem = null;
            this.CBItemName.SelectedItem = null;
            this.TxtPrice.Text = string.Empty;
            this.TxtQuantity.Text = string.Empty;
            this.TxtValue.Text = string.Empty;
            this.GVShowProducts.Rows.Clear();
            ///////////////////////////////////
            // نفس الذات نفس
            this.GVShowProducts.Rows.Clear();
            this.TxtTotal.Text = "";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TblTemporary where TemporaryID=3 ";

            SqlDataReader dr;
            Con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //
                this.GVShowProducts.Rows.Add(dr["TProType"].ToString(), dr["TproName"].ToString(), dr["TPrice"].ToString(), dr["TQuantity"].ToString(), dr["TTotal"].ToString(), dr["TID"].ToString(), dr["TSPrice"].ToString());

            }

            dr.Close();
            Con.Close();
        }

        private void CBStore_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LoadProductType();
        }

        private void CBItemType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.loadProducts();
        }

        private void CBItemName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

           
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select *  from LoadProducts where ProductID=@ProductID   ";

            Cmd.Parameters.AddWithValue("@ProductID", this.CBItemName.SelectedValue);

            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();
            if (dr.Read())
            {
                this.LblExist.Text = dr["Exist"].ToString();
                this.lblPrice.Text = dr["price"].ToString();

            }
            dr.Close();
            Con.Close();
            }
            catch (Exception)
            {


            }
        }

        private void BtnSale2_Click(object sender, EventArgs e)
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

        private void BtnSale1_Click(object sender, EventArgs e)
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

        private void TxtQuantity_TextChanged(object sender, EventArgs e)
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

        private void TxtPrice_TextChanged(object sender, EventArgs e)
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

        private void TxtValue_TextChanged(object sender, EventArgs e)
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.CBProvider.SelectedItem != null)
                {
                    this.LblProviderName.Text = this.CBProvider.SelectedValue.ToString();
                }

                if (double.Parse(this.LblExist.Text) <= 0 || double.Parse(this.LblExist.Text) < double.Parse(this.TxtQuantity.Text))
                {
                    MessageBox.Show("لا توجد كمية تكفى فى المخزن ", "Creative Care");
                }
                else
                {
                    if (this.TxtQuantity.Text == string.Empty || this.TxtValue.Text == string.Empty || this.CBItemType.SelectedItem == null || this.CBItemName.SelectedItem == null)
                    {
                        MessageBox.Show("من فضلك تاكد من ان البيانات صحيحه ", "Creative Care");

                    }
                    else
                    {



                        this.GVShowProducts.Rows.Add(this.CBItemType.Text, this.CBItemName.Text, this.TxtPrice.Text, this.TxtQuantity.Text, this.TxtValue.Text, this.CBItemName.SelectedValue, this.CBItemType.SelectedValue);
                        ////////////////////////////////////////////////////
                        // بيضيف البضاعه بشكل مؤقت علشان لو النور قطع  
                        // هنا بقى هاحط القيمه كلها تحت وابقى انادى عليها براحتى 




                        ///////////////////////////////////////

                        SqlCommand CmdST = new SqlCommand();
                        CmdST.Connection = Con;
                        CmdST.CommandType = CommandType.StoredProcedure;
                        CmdST.CommandText = "addTemporary";

                        CmdST.Parameters.AddWithValue("@TemporaryID", "4");
                        CmdST.Parameters.AddWithValue("@TID", this.CBItemName.SelectedValue);
                        CmdST.Parameters.AddWithValue("@TPrice", this.TxtPrice.Text);
                        CmdST.Parameters.AddWithValue("@TproName", this.CBItemName.Text);
                        CmdST.Parameters.AddWithValue("@TProType", this.CBItemType.Text);
                        CmdST.Parameters.AddWithValue("@TQuantity", this.TxtQuantity.Text);
                        CmdST.Parameters.AddWithValue("@TSPrice", this.CBItemType.SelectedValue);
                        CmdST.Parameters.AddWithValue("@TSPrise1", "");
                        CmdST.Parameters.AddWithValue("@TTotal", this.TxtValue.Text);
                        CmdST.Parameters.AddWithValue("@TExsist", "");


                        Con.Open();
                        CmdST.ExecuteNonQuery();
                        Con.Close();
                        // ويرجع يفضى تانى علشان لو هايكتب حاجه جديده :D
                        this.CBItemType.Text = string.Empty;
                        this.CBItemName.Text = string.Empty;
                        this.TxtPrice.Text = string.Empty;
                        this.TxtQuantity.Text = string.Empty;
                        this.TxtValue.Text = string.Empty;

                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("من فضلك تاكد ان البيانات المطلوبه صحيحه");
            }
        }

        private void BtnAddIn_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.CBCustomer.SelectedItem != null)
                {
                    this.LblCustomerID.Text = this.CBCustomer.SelectedValue.ToString();
                }
                else
                {
                    this.LblCustomerID.Text = 2.ToString();
                }




                //////         لو الكميه المباعه اصغر من الموجوده 
                if (this.TxtQuantity.Text == string.Empty || this.TxtValue.Text == string.Empty || this.CBItemType.SelectedItem == null || this.CBItemName.SelectedItem == null)
                {
                    MessageBox.Show("من فضلك تاكد من ان البيانات صحيحه ", "Creative Care");

                }
                else
                {

                    this.GVShowProducts.Rows.Add(this.CBItemType.Text, this.CBItemName.Text, this.TxtPrice.Text, this.TxtQuantity.Text, this.TxtValue.Text, this.CBItemName.SelectedValue, this.CBItemType.SelectedValue);
                    //////////////////////////////////////////////////////
                    // بيضيف البضاعه بشكل مؤقت علشان لو النور قطع  
                    double Zoz = double.Parse(this.lblPrice.Text);
                    double Abdo = double.Parse(this.TxtPrice.Text);

                    double toto = double.Parse(this.TxtQuantity.Text);

                    double Lbl = double.Parse(this.LblFinalEran.Text);

                    double fofo = Abdo - Zoz;

                    double final = fofo * toto;

                    double amada = Lbl + final;

                    this.LblFinalEran.Text = amada.ToString();
                    SqlCommand CmdST = new SqlCommand();
                    CmdST.Connection = Con;
                    CmdST.CommandType = CommandType.StoredProcedure;
                    CmdST.CommandText = "addTemporary";

                    CmdST.Parameters.AddWithValue("@TemporaryID", "3");
                    CmdST.Parameters.AddWithValue("@TID", this.CBItemName.SelectedValue);
                    CmdST.Parameters.AddWithValue("@TPrice", this.TxtPrice.Text);
                    CmdST.Parameters.AddWithValue("@TproName", this.CBItemName.Text);
                    CmdST.Parameters.AddWithValue("@TProType", this.CBItemType.Text);
                    CmdST.Parameters.AddWithValue("@TQuantity", this.TxtQuantity.Text);
                    CmdST.Parameters.AddWithValue("@TSPrice", this.CBItemType.SelectedValue);
                    CmdST.Parameters.AddWithValue("@TSPrise1", "");
                    CmdST.Parameters.AddWithValue("@TTotal", this.TxtValue.Text);
                    CmdST.Parameters.AddWithValue("@TExsist", "");


                    Con.Open();
                    CmdST.ExecuteNonQuery();
                    Con.Close();
                    // ويرجع يفضى تانى علشان لو هايكتب حاجه جديده :D
                    this.CBItemType.SelectedItem = null;
                    this.CBItemName.SelectedItem = null;
                    this.TxtPrice.Text = string.Empty;
                    this.TxtQuantity.Text = string.Empty;
                    this.TxtValue.Text = string.Empty;



                }

            }
            catch (Exception)
            {

                MessageBox.Show("من فضلك تاكد ان البيانات المطلوبه صحيحه", "Creative Care");
            }

        }

        private void GVShowProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < GVShowProducts.Rows.Count; ++i)
            {
                sum += double.Parse(GVShowProducts.Rows[i].Cells["Total"].Value.ToString());
            }
            this.TxtTotal.Text = sum.ToString();
        }

        private void BtnDoneIn_Click(object sender, EventArgs e)
        {

            // السناريو الاول انه يروح يشوف هو اختار عميل ولا لا لو اختار يبقى هايحصل الاتى 
            // انه يشوف ليه رصيد ولا لا لو ليه يخصم من الرصيدويعمله عملية سداد 
            // اما بقى لو مالهوش فا يدفع عادى من الخزنه 
            // اما بقى لو العميل مالهوش حساب يعمله واحد شاى :D 
            //try
            //{
            if (this.CBStore.SelectedItem == null  || this.CBStrorage.SelectedItem == null)
            {
                MessageBox.Show("من فضلك اختار الخزنه او المخزن ", "Creative Care");
            }
            else
            {

                if (this.CBCustomer.SelectedItem != null)
                {
                    // اول حاجه فى عميل هو مختاره 

                    //  ///////////////////////////////////////////// search for customer if found update his accounting 
                    // لسه هنا هاعمل نظم الدفع :D 

                    SqlCommand CmdSearch = new SqlCommand();
                    CmdSearch.Connection = Con;
                    CmdSearch.CommandType = CommandType.Text;
                    CmdSearch.CommandText = "select * from TblCustomers where CustomerID=@CustomerID ";

                    CmdSearch.Parameters.AddWithValue("@CustomerID", this.CBCustomer.SelectedValue);

                    SqlDataReader DR;
                    Con.Open();
                    DR = CmdSearch.ExecuteReader();
                    if (DR.Read())
                    {
                        double HExsist, TotalH, Hnew;

                        HExsist = double.Parse(DR["Debit"].ToString());
                        TotalH = double.Parse(this.TxtTotal.Text);
                        Hnew = HExsist - TotalH;

                        //  CreditH = double.Parse(DR["Credit"].ToString());

                        Con.Close();
                        if (Hnew <= 0)
                        {
                            // هنا بقى هاروح اعرفه انه خلص اللى عليه وهو ممكن يديله الفلوس فى ايده 
                            MessageBoxManager.Yes = " استكمال العمليه";
                            MessageBoxManager.No = "دفع من الخزنه ";
                            MessageBoxManager.Register();

                            DialogResult dialogResult = MessageBox.Show(" العميل قد سدد حسابه هل تريد استكمال العمليه ام الدفع من الخزنه", "Creative Care Messages", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                SqlCommand CmdDebit = new SqlCommand();
                                CmdDebit.Connection = Con;
                                CmdDebit.CommandType = CommandType.Text;
                                CmdDebit.CommandText = "update TblCustomers set Debit=@Debit where CustomerID=@CustomerID";

                                CmdDebit.Parameters.AddWithValue("@CustomerID", this.CBCustomer.SelectedValue);
                                CmdDebit.Parameters.AddWithValue("@Debit", Hnew);

                                Con.Open();
                                CmdDebit.ExecuteNonQuery();
                                Con.Close();

                               
                                Con.Close();
                                //////////////////////////////////////
                                //// تسجيل العمليه خاص ب جالرى القصر

                                SqlCommand CuProc = new SqlCommand();
                                CuProc.Connection = Con;
                                CuProc.CommandType = CommandType.StoredProcedure;
                                CuProc.CommandText = "AddCusProc";

                                CuProc.Parameters.AddWithValue("@CustomerID",this.CBCustomer.SelectedValue);
                                CuProc.Parameters.AddWithValue("@DateOfProc", this.DtDateTime.Value);
                                CuProc.Parameters.AddWithValue("@PayedValue", this.TxtTotal.Text);
                                CuProc.Parameters.AddWithValue("@ProcName", "فاتورة مرتجع");

                                Con.Open();
                                CuProc.ExecuteNonQuery();
                                Con.Close();
                                // ///////////////////
                                // هنا انا محتاج اعمل انه يعمل مصرفات علشان يطلعها من الارباح

                                ///////////////////////////////
                                this.AddBackin();
                                this.GVShowProducts.Rows.Clear();
                                this.TxtTotal.Text = string.Empty;
                                this.CBStrorage.SelectedItem = null;
                                this.CBStore.SelectedItem = null;

                               
                                MessageBox.Show("Done", "Creative Care");
                               
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                if (this.CBStrorage.SelectedItem == null)
                                {

                                    MessageBox.Show("من فضلك اختار الخزنه ", "Creative Care");
                                    MessageBoxManager.Unregister();
                                }
                                else
                                {
                                    //////////////////////////////////////////////// pay 

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
                                        double y = double.Parse(this.TxtTotal.Text);
                                        double expen = X - y;

                                        Con.Close();

                                        SqlCommand StorageUpdate = new SqlCommand();
                                        StorageUpdate.Connection = Con;
                                        StorageUpdate.CommandType = CommandType.Text;
                                        StorageUpdate.CommandText = "update TblStorages set TotalMoney=@TotalMoney where StorageID=@StorageID";

                                        StorageUpdate.Parameters.AddWithValue("@TotalMoney", expen);
                                        StorageUpdate.Parameters.AddWithValue("@StorageID", this.CBStrorage.SelectedValue);

                                        Con.Open();
                                        StorageUpdate.ExecuteNonQuery();
                                        Con.Close();

                                        


                                    }

                                    SR.Close();
                                    Con.Close();
                                   
                                    Con.Close();
                                    //////////////////////////////////////
                                    //// تسجيل العمليه خاص ب جالرى القصر

                                    SqlCommand CuProc = new SqlCommand();
                                    CuProc.Connection = Con;
                                    CuProc.CommandType = CommandType.StoredProcedure;
                                    CuProc.CommandText = "AddCusProc";

                                    CuProc.Parameters.AddWithValue("@CustomerID", this.CBCustomer.SelectedValue);
                                    CuProc.Parameters.AddWithValue("@DateOfProc", this.DtDateTime.Value);
                                    CuProc.Parameters.AddWithValue("@PayedValue", this.TxtTotal.Text);
                                    CuProc.Parameters.AddWithValue("@ProcName", "فاتورة مرتجع");

                                    Con.Open();
                                    CuProc.ExecuteNonQuery();
                                    Con.Close();
                                    ///////////////////////////////
                                    this.AddBackin();
                                    /////////////////////////////////////////////////
                                    // هنا بقى يابرنس بيضيف العمليات بتاعت الخزنه ك شراء للقصر  برضه
                                    SqlCommand SAction = new SqlCommand();
                                    SAction.Connection = Con;
                                    SAction.CommandType = CommandType.StoredProcedure;
                                    SAction.CommandText = "AddStorageAction";

                                    SAction.Parameters.AddWithValue("@SActionID", "3");
                                    SAction.Parameters.AddWithValue("@SPDate", this.DtDateTime.Value);
                                    SAction.Parameters.AddWithValue("@SPMoney", this.TxtTotal.Text);
                                    SAction.Parameters.AddWithValue("@StorageID", this.CBStrorage.SelectedValue);

                                    Con.Open();
                                    SAction.ExecuteNonQuery();
                                    Con.Close();

                                    ///////////////////////////////////////
                                    // هنا بقى انا هاروح اعمل عمليه مصروفات للفلوس اللى طلعت 
                                    SqlCommand Expen = new SqlCommand();
                                    Expen.Connection = Con;
                                    Expen.CommandType = CommandType.Text;
                                    Expen.CommandText = "insert into TblExpenses (ExpensesDate,ExpensesReason,Money,UserID,StorageID) values (@ExpensesDate,@ExpensesReason,@Money,@UserID,@StorageID)";

                                    Expen.Parameters.AddWithValue("@ExpensesDate",DateTime.Now.ToString("yyyy-MM-dd"));
                                    Expen.Parameters.AddWithValue("@ExpensesReason","خصم ارباح مرتجع بيع " );
                                    Expen.Parameters.AddWithValue("@Money", this.LblFinalEran.Text);
                                    Expen.Parameters.AddWithValue("@UserID", this.LblUserID.Text);
                                    Expen.Parameters.AddWithValue("@StorageID", this.CBStrorage.SelectedValue);


                                    Con.Open();
                                    Expen.ExecuteNonQuery();
                                    Con.Close();
                                    /////////////////////////
                                    this.GVShowProducts.Rows.Clear();
                                    this.TxtTotal.Text = string.Empty;
                                    this.CBStrorage.SelectedItem = null;
                                    this.CBStore.SelectedItem = null;
                                    MessageBox.Show("Done", "Creative Care");

                                }

                            }

                        }
                        else
                        {

                            SqlCommand CmdDebit = new SqlCommand();
                            CmdDebit.Connection = Con;
                            CmdDebit.CommandType = CommandType.Text;
                            CmdDebit.CommandText = "update TblCustomers set Debit=@Debit where CustomerID=@CustomerID";

                            CmdDebit.Parameters.AddWithValue("@CustomerID", this.CBCustomer.SelectedValue);
                            CmdDebit.Parameters.AddWithValue("@Debit", Hnew);

                            Con.Open();
                            CmdDebit.ExecuteNonQuery();
                            Con.Close();

                           
                            Con.Close();

                            //////////////////////////////////////
                            //// تسجيل العمليه خاص ب جالرى القصر

                            SqlCommand CuProc = new SqlCommand();
                            CuProc.Connection = Con;
                            CuProc.CommandType = CommandType.StoredProcedure;
                            CuProc.CommandText = "AddCusProc";

                            CuProc.Parameters.AddWithValue("@CustomerID", this.CBCustomer.SelectedValue);
                            CuProc.Parameters.AddWithValue("@DateOfProc", this.DtDateTime.Value);
                            CuProc.Parameters.AddWithValue("@PayedValue", this.TxtTotal.Text);
                            CuProc.Parameters.AddWithValue("@ProcName", "فاتورة مرتجع");

                            Con.Open();
                            CuProc.ExecuteNonQuery();
                            Con.Close();
                            ///////////////////////////////
                            this.AddBackin();
                            //////////////////////////////////
                            this.GVShowProducts.Rows.Clear();
                            this.TxtTotal.Text = string.Empty;
                            this.CBStrorage.SelectedItem = null;
                            this.CBStore.SelectedItem = null;
                            MessageBox.Show("Done", "Creative Care");
                           
                        }
                    }
                    DR.Close();
                    Con.Close();
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////
                    // بس خلاص 


                }
                else
                {
                    // هنا مالقاش 

                    if (this.CBStrorage.SelectedItem == null || this.CBStore.SelectedItem == null)
                    {
                        MessageBox.Show("من فضلك اختار الخزنه او المخزن ", "Creative Care");
                    }
                    else
                    {
                        //////////////////////////////////////////////// pay 

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
                            double y = double.Parse(this.TxtTotal.Text);
                            double W = X - y;


                            Con.Close();

                            ///////////////////////////////////////////////////////////////////////////////


                            SqlCommand StorageUpdate = new SqlCommand();
                            StorageUpdate.Connection = Con;
                            StorageUpdate.CommandType = CommandType.Text;
                            StorageUpdate.CommandText = "update TblStorages set TotalMoney=@TotalMoney where StorageID=@StorageID";

                            StorageUpdate.Parameters.AddWithValue("@TotalMoney", W);
                            StorageUpdate.Parameters.AddWithValue("@StorageID", this.CBStrorage.SelectedValue);

                            Con.Open();
                            StorageUpdate.ExecuteNonQuery();
                            Con.Close();

                           
                            //    /////////////////////////////////////////////////////////////////////////////////////    //     
                            //    //////////////////////////////////////// insert a proc 
                            SqlCommand CmdInsert = new SqlCommand();
                            CmdInsert.Connection = Con;
                            CmdInsert.CommandType = CommandType.StoredProcedure;
                            CmdInsert.CommandText = "InsertBackinbill";


                            CmdInsert.Parameters.AddWithValue("@CustomerID", this.LblCustomerID.Text);
                            CmdInsert.Parameters.AddWithValue("@DateOfBackeIn", this.DtDateTime.Value);
                            CmdInsert.Parameters.AddWithValue("@TotalPaybake", this.TxtTotal.Text);
                            CmdInsert.Parameters.AddWithValue("@UserID ", this.LblUserID.Text);
                            CmdInsert.Parameters.AddWithValue("@StoreID ", this.CBStore.SelectedValue);

                            SqlParameter p2 = new SqlParameter();
                            p2.ParameterName = "@BackInID";
                            p2.SqlDbType = SqlDbType.Int;
                            p2.Direction = ParameterDirection.Output;
                            CmdInsert.Parameters.Add(p2);
                            Con.Open();
                            CmdInsert.ExecuteNonQuery();
                            Con.Close();


                            //    //////////////////////////////////////////////////////
                            double Exsist, newe, updateed;
                            foreach (DataGridViewRow row in GVShowProducts.Rows)
                            {
                                SqlCommand CmdUpdat = new SqlCommand();
                                CmdUpdat.Connection = Con;
                                CmdUpdat.CommandType = CommandType.Text;
                                CmdUpdat.CommandText = "select *  from LoadProducts where ProductID=@ProductID";

                                CmdUpdat.Parameters.AddWithValue("@ProductID", row.Cells["ProductID"].Value.ToString());

                                SqlDataReader dr;
                                Con.Open();
                                dr = CmdUpdat.ExecuteReader();
                                if (dr.Read())
                                {
                                    Exsist = double.Parse(dr["Exist"].ToString());
                                    newe = double.Parse(row.Cells["Quantity"].Value.ToString());
                                    updateed = Exsist + newe;
                                    Con.Close();
                                    ///// her i will go and make update 
                                    SqlCommand Cmdupdate = new SqlCommand();
                                    Cmdupdate.Connection = Con;
                                    Cmdupdate.CommandType = CommandType.Text;
                                    Cmdupdate.CommandText = "Update TblProducts set Exist=@Exist where ProductID=@ProductID ";

                                    Cmdupdate.Parameters.AddWithValue("@Exist", updateed);
                                    Cmdupdate.Parameters.AddWithValue("@ProductID", row.Cells["ProductID"].Value.ToString());

                                    Con.Open();
                                    Cmdupdate.ExecuteNonQuery();
                                    Con.Close();

                                }
                                dr.Close();
                                Con.Close();
                                // ////////////////////// her i will make insert the bill 

                                SqlCommand CmdInsertBill = new SqlCommand();
                                CmdInsertBill.Connection = Con;
                                CmdInsertBill.CommandType = CommandType.StoredProcedure;
                                CmdInsertBill.CommandText = "InsertBillIn";

                                CmdInsertBill.Parameters.AddWithValue("@BackInID", CmdInsert.Parameters["@BackInID"].Value.ToString());
                                CmdInsertBill.Parameters.AddWithValue("@ProductID", row.Cells["ProductID"].Value.ToString());
                                CmdInsertBill.Parameters.AddWithValue("@BackProNu", row.Cells["Quantity"].Value.ToString());
                                CmdInsertBill.Parameters.AddWithValue("@InPrice", row.Cells["Price"].Value.ToString());
                                CmdInsertBill.Parameters.AddWithValue("@InTotal", row.Cells["Total"].Value.ToString());


                                Con.Open();
                                CmdInsertBill.ExecuteNonQuery();
                                Con.Close();
                                ///////////////////////////////////////////////////////////////////////////
                                // وهنا بقى هايروح يضيف حركة الصنف 
                                SqlCommand Move = new SqlCommand();
                                Move.Connection = Con;
                                Move.CommandType = CommandType.StoredProcedure;
                                Move.CommandText = "AddProMovement";

                                Move.Parameters.AddWithValue("@MoveQuantity", row.Cells["Quantity"].Value.ToString());
                                Move.Parameters.AddWithValue("@ProductID", row.Cells["ProductID"].Value.ToString());
                                Move.Parameters.AddWithValue("@TemporaryID", "3");
                                Move.Parameters.AddWithValue("@MoveDate", this.DtDateTime.Value);
                                Move.Parameters.AddWithValue("@MoveValue", row.Cells["Total"].Value.ToString());


                                Con.Open();
                                Move.ExecuteNonQuery();
                                Con.Close();
                               

                            }

                            SR.Close();
                            Con.Close();
                            /////////////////////////////////////////////////
                            // هنا بقى يابرنس بيضيف العمليات بتاعت الخزنه ك شراء للقصر  برضه
                            SqlCommand SAction = new SqlCommand();
                            SAction.Connection = Con;
                            SAction.CommandType = CommandType.StoredProcedure;
                            SAction.CommandText = "AddStorageAction";

                            SAction.Parameters.AddWithValue("@SActionID", "3");
                            SAction.Parameters.AddWithValue("@SPDate", this.DtDateTime.Value);
                            SAction.Parameters.AddWithValue("@SPMoney", this.TxtTotal.Text);
                            SAction.Parameters.AddWithValue("@StorageID", this.CBStrorage.SelectedValue);

                            Con.Open();
                            SAction.ExecuteNonQuery();
                            Con.Close();

                            ///////////////////////////////////////
                            // هنا بقى انا هاروح اعمل عمليه مصروفات للفلوس اللى طلعت 
                            SqlCommand Expen = new SqlCommand();
                            Expen.Connection = Con;
                            Expen.CommandType = CommandType.Text;
                            Expen.CommandText = "insert into TblExpenses (ExpensesDate,ExpensesReason,Money,UserID,StorageID) values (@ExpensesDate,@ExpensesReason,@Money,@UserID,@StorageID)";

                            Expen.Parameters.AddWithValue("@ExpensesDate", this.DtDateTime.Value);
                            Expen.Parameters.AddWithValue("@ExpensesReason", "خصم ارباح مرتجع بيع ");
                            Expen.Parameters.AddWithValue("@Money", this.LblFinalEran.Text);
                            Expen.Parameters.AddWithValue("@UserID", this.LblUserID.Text);
                            Expen.Parameters.AddWithValue("@StorageID", this.CBStrorage.SelectedValue);


                            Con.Open();
                            Expen.ExecuteNonQuery();
                            Con.Close();

                            try
                            {
                                TblLog Log = new TblLog();
                                Log.UserID = int.Parse(this.LblUserID.Text);
                                Log.Discription = " فاتورة مرتجع بيع رقم  : " + CmdInsert.Parameters["@BackInID"].Value.ToString();
                                Log.DateOfLog = DateTime.Now;

                                context.TblLogs.Add(Log);
                                context.SaveChanges();

                            }
                            catch (Exception)
                            {


                            }

                        }
                        ///////////////////////////////////////////
                        this.GVShowProducts.Rows.Clear();
                        this.TxtTotal.Text = string.Empty;
                        this.CBStrorage.SelectedItem = null;
                        this.CBStore.SelectedItem = null;
                      

                        MessageBox.Show("Done", "Creative Care");
                        /////////////////////////////////////////////////
                        //////////////////////////////////////
                        // clear history
                        this.GVShowProducts.Rows.Clear();
                        this.TxtTotal.Text = "";

                        SqlCommand CmdDelete1 = new SqlCommand();
                        CmdDelete1.Connection = Con;
                        CmdDelete1.CommandType = CommandType.Text;
                        CmdDelete1.CommandText = "delete from TblTemporary where TemporaryID=3  ";

                        Con.Open();
                        CmdDelete1.ExecuteNonQuery();
                        Con.Close();
                    }

                }

            }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
            //}

        }
        private void BtnBackout_Click(object sender, EventArgs e)
        {
            //try
            //{


            if (this.CBProvider.SelectedItem == null || this.CBStore.SelectedItem == null)
            {
                MessageBox.Show("من فضلك تاكد من اختيارك ل اسم المورد والمخزن", "Creative Care");
            }
            else
            {



                TblBackOut BO = new TblBackOut();
                BO.DateOfBackout = DateTime.Now;
                BO.ProviderID = int.Parse(this.CBProvider.SelectedValue.ToString());
                BO.TotalMony = this.TxtTotal.Text;
                BO.UserID = int.Parse(LblUserID.Text);
                BO.StoreID = int.Parse(this.CBStore.SelectedValue.ToString());

                context.TblBackOuts.Add(BO);
                context.SaveChanges();

                /////////////////////////////////////////////////////////////////////
                // update product by new exist 

                double Exsist, newe, updateed;
                foreach (DataGridViewRow row in GVShowProducts.Rows)
                {


                    int ProDID = int.Parse(row.Cells["ProductID"].Value.ToString());

                    var SelectedProduct = context.TblProducts.Where(a => a.ProductID == ProDID).FirstOrDefault();


                    Exsist = double.Parse(SelectedProduct.Exist.ToString());
                    newe = double.Parse(row.Cells["Quantity"].Value.ToString());
                    updateed = Exsist - newe;

                    SelectedProduct.Exist = updateed;

                    context.SaveChanges();




                    TblBackOutBill BoBill = new TblBackOutBill();

                    BoBill.BackoutID = BO.BackoutID;
                    BoBill.ProductID = ProDID;
                    BoBill.OutProdNum = row.Cells["Quantity"].Value.ToString();
                    BoBill.OutPrice = row.Cells["Price"].Value.ToString();
                    BoBill.OutTotal = row.Cells["Total"].Value.ToString();

                    context.TblBackOutBills.Add(BoBill);
                    context.SaveChanges();




                    /////////////////////////////////////////////
                    // هنا برضه هاعمل حركة صنف 



                    TblProductsMovement Movem = new TblProductsMovement();
                    Movem.MoveQuantity = row.Cells["Quantity"].Value.ToString();
                    Movem.ProductID = ProDID;
                    Movem.TemporaryID = 4;
                    Movem.MoveDate = this.DtDateTime.Value;
                    Movem.MoveValue = row.Cells["Total"].Value.ToString();

                    context.TblProductsMovements.Add(Movem);
                    context.SaveChanges();


                }


                //////////////////////////////////////////////////////////////////////
                // now i will edit cridet of provider 

                int PoviderID = int.Parse(this.CBProvider.SelectedValue.ToString());
                double HExsist, TotalH, Hnew;

                var ProviderSelected = context.TblProviders.Where(a => a.ProviderID == PoviderID).FirstOrDefault();

                HExsist = double.Parse(ProviderSelected.Credit.ToString());
                TotalH = double.Parse(this.TxtTotal.Text);
                Hnew = HExsist - TotalH;

                ProviderSelected.Credit = Hnew.ToString();
                context.SaveChanges();


                TblProProc Process = new TblProProc();

                Process.ProviderID = PoviderID;
                Process.ProDate = DateTime.Now;
                Process.PRocName = "فاتورة مرتجع";
                Process.ProPaied = this.TxtTotal.Text;

                context.TblProProcs.Add(Process);
                context.SaveChanges();

                TblProProc Processe = new TblProProc();

                Processe.ProviderID = PoviderID;
                Processe.ProDate = DateTime.Now;
                Processe.PRocName = "سداد عن طريق فاتورة مرتجع";
                Processe.ProPaied = this.TxtTotal.Text;

                context.TblProProcs.Add(Processe);
                context.SaveChanges();


                ///////////////////////////////
                try
                {
                    TblLog Log = new TblLog();
                    Log.UserID = int.Parse(this.LblUserID.Text);
                    Log.Discription = " فاتورة مرتجع شراء رقم  : " + BO.BackoutID.ToString();
                    Log.DateOfLog = DateTime.Now;

                    context.TblLogs.Add(Log);
                    context.SaveChanges();

                }
                catch (Exception)
                {


                }
                ///////////////////////////////////////
                this.GVShowProducts.Rows.Clear();
                this.TxtTotal.Text = string.Empty;
                this.CBProvider.SelectedItem = null;
                this.CBStore.SelectedItem = null;
                MessageBox.Show("تم بنجاح", "Creative Care");
                /////////////////////////////////////////
                // clear historay 
                this.GVShowProducts.Rows.Clear();
                this.TxtTotal.Text = "";

                SqlCommand CmdDelete1 = new SqlCommand();
                CmdDelete1.Connection = Con;
                CmdDelete1.CommandType = CommandType.Text;
                CmdDelete1.CommandText = "delete from TblTemporary where TemporaryID=4  ";

                Con.Open();
                CmdDelete1.ExecuteNonQuery();
                Con.Close();
            }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
            //}
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
                this.GVShowProducts.Rows.Clear();
                this.TxtTotal.Text = "";

                SqlCommand CmdDelete1 = new SqlCommand();
                CmdDelete1.Connection = Con;
                CmdDelete1.CommandType = CommandType.Text;
                CmdDelete1.CommandText = "delete from TblTemporary where TemporaryID=4  ";

                Con.Open();
                CmdDelete1.ExecuteNonQuery();
                Con.Close();

            }
            else if (dialogResult == DialogResult.No)
            {

            }
            
        }

        private void BtnDeleteIn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(" هل ب الفعل تريد حذف الذاكره المؤقته  ", "Creative Care ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.GVShowProducts.Rows.Clear();
                this.TxtTotal.Text = "";

                SqlCommand CmdDelete = new SqlCommand();
                CmdDelete.Connection = Con;
                CmdDelete.CommandType = CommandType.Text;
                CmdDelete.CommandText = "delete from TblTemporary where TemporaryID=3  ";

                Con.Open();
                CmdDelete.ExecuteNonQuery();
                Con.Close();

            }
            else if (dialogResult == DialogResult.No)
            {

            }
            
        }

        private void BtnToto_MouseHover(object sender, EventArgs e)
        {
            this.BtnToto.ImageAlign = ContentAlignment.TopCenter;
            this.BtnToto.Text = "مسح";
        }

        private void BtnToto_MouseLeave(object sender, EventArgs e)
        {
            this.BtnToto.ImageAlign = ContentAlignment.MiddleCenter;
            this.BtnToto.Text = "";
        }

        private void CBStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.LoadProductType();
            }
        }

        private void CBItemType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.loadProducts();
            }
        }

        private void CBItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select *  from LoadProducts where ProductID=@ProductID ";

                Cmd.Parameters.AddWithValue("@ProductID", this.CBItemName.SelectedValue);

                SqlDataReader dr;
                Con.Open();
                dr = Cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.LblExist.Text = dr["Exist"].ToString();

                }
                dr.Close();
                Con.Close();
            }
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
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
                        this.LblExist.Text = DR["Exist"].ToString();
                    }
                    DR.Close();
                    Con.Close();

                }
                this.TxtBarcode.Text = "";
                dr.Close();
                Con.Close();
            }
        }

        private void GVShowProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < GVShowProducts.Rows.Count; ++i)
            {
                sum += double.Parse(GVShowProducts.Rows[i].Cells["Total"].Value.ToString());
            }
            this.TxtTotal.Text = sum.ToString();
        }

        private void GVShowProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < GVShowProducts.Rows.Count; ++i)
            {
                sum += double.Parse(GVShowProducts.Rows[i].Cells["Total"].Value.ToString());
            }
            this.TxtTotal.Text = sum.ToString();
        }

       
    }
}
  //  }

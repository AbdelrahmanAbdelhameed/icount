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

namespace I_Count
{
    public partial class Procurement : Form
    {
       // SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        AccountingEntities context = new AccountingEntities();
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);

        public Procurement(int ID )
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
        ///////////////////////////////////////////////////////////////
        // Add New Product
        private void AddProduct()
        {
            Con.Close();
           // خليك فاكر اننا هنا هانعدل ونخليه القم doubel 
            if (this.TxtTotal.Text != this.Txtpaid.Text && this.LblProviderName.Text == "" && this.TxtOffer.Text=="0") //////////////////////////////////////// breake 
            {

                MessageBox.Show(this.CBProvider.Tag + "الفاتوره تحتوى على حسابات اجله من فضلك اختار اسم المورد", "Creative Care");
                this.CBProvider.Focus();

            }
            // ده علشان لو ما اختارش اسم مورد يجبله لا احد علشان ما يطلعش ايرورو /////////////////////////////////////// 
            else
            {

                if (this.LblProviderName.Text == "")
                {
                    this.LblProviderName.Text = "14";
                }

                // اول حاجه هايعملها هنا انه يروح يعمل فاتوره 

                SqlCommand CmdInsertBill = new SqlCommand();
                CmdInsertBill.Connection = Con;
                CmdInsertBill.CommandType = CommandType.StoredProcedure;
                CmdInsertBill.CommandText = "InsertBill";

                CmdInsertBill.Parameters.AddWithValue("@DateOfBill", this.DtDateTime.Value);
                CmdInsertBill.Parameters.AddWithValue("@ProviderID", this.LblProviderName.Text); /////////////// انا شايف ان دىمالهاش لزمه 
                CmdInsertBill.Parameters.AddWithValue("@TotalPaid", this.TxtTotal.Text);///////////////////////////// الاجمالى 
                CmdInsertBill.Parameters.AddWithValue("@Paid", this.Txtpaid.Text); ///////////////// المدفوع
                CmdInsertBill.Parameters.AddWithValue("@UserID", this.LblUserID.Text); ///////////////////////////////////
                CmdInsertBill.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);
                SqlParameter p2 = new SqlParameter();
                p2.ParameterName = "@BillID";
                p2.SqlDbType = SqlDbType.Int;
                p2.Direction = ParameterDirection.Output;
                CmdInsertBill.Parameters.Add(p2);

                Con.Open();
                CmdInsertBill.ExecuteNonQuery();
                Con.Close();
                //////////////////////////////////////////////////////////////////////////////////////////////////////

                // هنا بقى هو رايح يعمل بحث عن نوع المنج اللى هو موجود فى الجريد فيو 

                //هو بياخد البيانات اللى بيدور عليها من الجريد فيو 



                //while (GVShowProducts.Rows.Count>0)
                //{

                foreach (DataGridViewRow row in GVShowProducts.Rows)
                {

                    //for (int i = 0; i < GVShowProducts.Rows.Count ; i++)
                    //{
                    //    DataGridViewRow row = GVShowProducts.Rows[i];

                    SqlCommand CmdItemType = new SqlCommand();
                    CmdItemType.Connection = Con;
                    CmdItemType.CommandType = CommandType.Text;
                    CmdItemType.CommandText = "select *  from TblProductType where ProductType=@ProductType"; ///// بحث عن النوع
                    CmdItemType.Parameters.AddWithValue("@ProductType", row.Cells["ItemType"].Value.ToString());

                    SqlDataReader DR;
                    Con.Open();
                    DR = CmdItemType.ExecuteReader();
                    // هنا الاحتمال الاول انه لقى نوع المنتج 
                    //"يبقى انا كده معيا  نوع المنتج "يروح بقى يدور على اسمه

                    if (DR.Read()) //////////////  لو النوع موجود////////////////////////////////////////////////////////////////////////////////
                    {
                        string ID = DR["ProductTypeID"].ToString();
                        // اهو راح يدور على اسم المنتج كدبت عليك انا :D
                        Con.Close();
                        SqlCommand CmdItemName = new SqlCommand();
                        CmdItemName.Connection = Con;
                        CmdItemName.CommandType = CommandType.Text;
                        CmdItemName.CommandText = "select *  from TblProducts where ProductName=@ProductName and ProductTypeID=@ProductTypeID and StoreID=@StoreID ";

                        CmdItemName.Parameters.AddWithValue("@ProductName", row.Cells["ItemName"].Value.ToString());
                        CmdItemName.Parameters.AddWithValue("@ProductTypeID", ID);
                        CmdItemName.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

                        SqlDataReader RD;
                        Con.Open();
                        RD = CmdItemName.ExecuteReader();
                        if (RD.Read()) ///////////////////////   هنا لو لقى اسم الصنف   //////////////////////////////////////  
                        {
                            string PROID = RD["ProductID"].ToString();
                            string ProType = RD["ProductTypeID"].ToString();
                            //هنا لقى فا قام ايه راح يعمل Update 

                            SqlCommand CmdUpdateProduct = new SqlCommand();
                            CmdUpdateProduct.Connection = Con;
                            CmdUpdateProduct.CommandType = CommandType.StoredProcedure;
                            CmdUpdateProduct.CommandText = "UpdateBuyBill";
                            ////////////////////////




                            int PID = int.Parse(PROID);
                            var Prodo = context.TblProducts.Where(a => a.ProductID == PID).SingleOrDefault();

                            double NewAvgPrice = (double.Parse(Prodo.Price) + double.Parse(row.Cells["Price"].Value.ToString())) / 2;
                            // CmdUpdateProduct.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

                            double NewExstt = double.Parse(row.Cells["Quantity"].Value.ToString()) + double.Parse(RD["Exist"].ToString());

                            CmdUpdateProduct.Parameters.AddWithValue("@Exist", NewExstt);
                          
                            CmdUpdateProduct.Parameters.AddWithValue("@Price", NewAvgPrice.ToString());
                            CmdUpdateProduct.Parameters.AddWithValue("@SalePrice1", row.Cells["SalePrice1"].Value.ToString());
                            CmdUpdateProduct.Parameters.AddWithValue("@SalePrice2", row.Cells["SalePrice2"].Value.ToString());
                            CmdUpdateProduct.Parameters.AddWithValue("@ProductID", RD["ProductID"].ToString());
                            CmdUpdateProduct.Parameters.AddWithValue("@BillID", CmdInsertBill.Parameters["@BillID"].Value.ToString());
                            CmdUpdateProduct.Parameters.AddWithValue("@Minimum", row.Cells["CBMine"].Value.ToString());

                            Con.Close();

                            Con.Open();
                            CmdUpdateProduct.ExecuteNonQuery();

                            Con.Close();
                            //////////////////////////////////////////////هنا هايروح يعمل اضافه ب الصنف ده فى جدول المشتريات مش جدول المنتجات 
                            // طيب ايه الفرق اقولك بص هو المنتجات هنا بيعملها ابديت  انما عملية الشرا نفسها فين ؟؟؟؟؟
                            //هى دى بقى 
                            SqlCommand CmdProcurement = new SqlCommand();
                            CmdProcurement.Connection = Con;
                            CmdProcurement.CommandType = CommandType.StoredProcedure;
                            CmdProcurement.CommandText = "InsertPurchases";


                            CmdProcurement.Parameters.AddWithValue("@BillID", CmdInsertBill.Parameters["@BillID"].Value.ToString());
                            CmdProcurement.Parameters.AddWithValue("@Quantity", row.Cells["Quantity"].Value.ToString());
                            CmdProcurement.Parameters.AddWithValue("@ProductID", PROID);///////////////////////////////////////////////
                            CmdProcurement.Parameters.AddWithValue("@ProductTypeID", ProType);///////////////////////
                            CmdProcurement.Parameters.AddWithValue("@BPrice", row.Cells["Price"].Value.ToString());
                            CmdProcurement.Parameters.AddWithValue("@BTatol", row.Cells["Total"].Value.ToString());

                            Con.Open();
                            CmdProcurement.ExecuteNonQuery();
                            Con.Close();
                            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            // هنا بيضيف حركة الصنف

                            SqlCommand Move = new SqlCommand();
                            Move.Connection = Con;
                            Move.CommandType = CommandType.StoredProcedure;
                            Move.CommandText = "AddProMovement";

                            Move.Parameters.AddWithValue("@MoveQuantity", row.Cells["Quantity"].Value.ToString());
                            Move.Parameters.AddWithValue("@ProductID", PROID);
                            Move.Parameters.AddWithValue("@TemporaryID", "1");
                            Move.Parameters.AddWithValue("@MoveDate", this.DtDateTime.Value);
                            Move.Parameters.AddWithValue("@MoveValue", row.Cells["Total"].Value.ToString());


                            Con.Open();
                            Move.ExecuteNonQuery();
                            Con.Close();

                        }
                        // هنا لو مالقاش اسم المنتج ماشى!!!!

                        else ///////////////////////////  وهنا لو مالقاش //////////////////////// ana sh8al hena ///////////////
                        {
                            double dooo3 = double.Parse(row.Cells["Quantity"].Value.ToString());
                            SqlCommand NewItemName = new SqlCommand();
                            NewItemName.Connection = Con;
                            NewItemName.CommandType = CommandType.StoredProcedure;
                            NewItemName.CommandText = "InsertNewItemName";

                            NewItemName.Parameters.AddWithValue("@ProductName", row.Cells["ItemName"].Value.ToString());
                            NewItemName.Parameters.AddWithValue("@ProductTypeID", ID);/////////////////////  
                            NewItemName.Parameters.AddWithValue("@BillID", CmdInsertBill.Parameters["@BillID"].Value.ToString());
                            NewItemName.Parameters.AddWithValue("@Exist",dooo3);
                            NewItemName.Parameters.AddWithValue("@Price", row.Cells["Price"].Value.ToString());
                            NewItemName.Parameters.AddWithValue("@SalePrice1", row.Cells["SalePrice1"].Value.ToString());
                            NewItemName.Parameters.AddWithValue("@SalePrice2", row.Cells["SalePrice2"].Value.ToString());
                            NewItemName.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);
                            NewItemName.Parameters.AddWithValue("@Minimum", row.Cells["CBMine"].Value.ToString());

                            SqlParameter p = new SqlParameter();
                            p.ParameterName = "@ProductID";
                            p.SqlDbType = SqlDbType.Int;
                            p.Direction = ParameterDirection.Output;
                            NewItemName.Parameters.Add(p);
                            Con.Close();
                            Con.Open();
                            NewItemName.ExecuteNonQuery();
                            Con.Close();
                            //////////////////////////
                            try
                            {
                                int ProID = int.Parse(NewItemName.Parameters["@ProductID"].Value.ToString());

                                int Serial;
                                var CountSessions = context.TblProducts.Count();
                                if (CountSessions > 0 && CountSessions != 1)
                                {
                                    var lastcode = context.TblProducts.Max(a => a.Serial);
                                    Serial = int.Parse(lastcode.ToString()) + 1;

                                }
                                else
                                {
                                    Serial = 1;
                                }

                                var ProductSerail = context.TblProducts.Where(a => a.ProductID == ProID).SingleOrDefault();
                                ProductSerail.Serial = Serial;
                                context.SaveChanges();

                            }
                            catch (Exception)
                            {
                                MessageBox.Show("من فضلك اضغط ok وانتظر رساله تاكيد الشراء");

                            }
                            ///////////////////////////////////////////////////////////////////////////////////////////////////
                            // هنا نفس الكلام هايروح يعمل عملية شراء 
                            SqlCommand CmdProcurement = new SqlCommand();
                            CmdProcurement.Connection = Con;
                            CmdProcurement.CommandType = CommandType.StoredProcedure;
                            CmdProcurement.CommandText = "InsertPurchases";


                            CmdProcurement.Parameters.AddWithValue("@BillID", CmdInsertBill.Parameters["@BillID"].Value.ToString());
                            CmdProcurement.Parameters.AddWithValue("@Quantity", row.Cells["Quantity"].Value.ToString());
                            CmdProcurement.Parameters.AddWithValue("@ProductID", NewItemName.Parameters["@ProductID"].Value.ToString());
                            CmdProcurement.Parameters.AddWithValue("@ProductTypeID", ID);
                            CmdProcurement.Parameters.AddWithValue("@BPrice", row.Cells["Price"].Value.ToString());
                            CmdProcurement.Parameters.AddWithValue("@BTatol", row.Cells["Total"].Value.ToString());

                            Con.Open();
                            CmdProcurement.ExecuteNonQuery();
                            Con.Close();

                            /////////////////////////////////////////////////////////////////////////////////
                            ///وبرضه هنا حركة الصنف
                            SqlCommand Move = new SqlCommand();
                            Move.Connection = Con;
                            Move.CommandType = CommandType.StoredProcedure;
                            Move.CommandText = "AddProMovement";

                            Move.Parameters.AddWithValue("@MoveQuantity", row.Cells["Quantity"].Value.ToString());
                            Move.Parameters.AddWithValue("@ProductID", NewItemName.Parameters["@ProductID"].Value.ToString());
                            Move.Parameters.AddWithValue("@TemporaryID", "1");
                            Move.Parameters.AddWithValue("@MoveDate", this.DtDateTime.Value);
                            Move.Parameters.AddWithValue("@MoveValue", row.Cells["Total"].Value.ToString());


                            Con.Open();
                            Move.ExecuteNonQuery();
                            Con.Close();
                            /////////////////////////////////////////////////

                        }
                        RD.Close();
                        Con.Close();
                    }
                    else  ///وهنا مالقاش بقى نوع المنتج من الاول خالص/////// 
                    /// هايعمل فاتروه جديده بس ما تنساش كل ده هو معاه اسم المورد 
                    {
                        Con.Close();
                        double dooo4 = double.Parse(row.Cells["Quantity"].Value.ToString());
                        SqlCommand CmdInsertNew = new SqlCommand();
                        CmdInsertNew.Connection = Con;
                        CmdInsertNew.CommandType = CommandType.StoredProcedure;
                        CmdInsertNew.CommandText = "InsertBuyBill";

                        CmdInsertNew.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);
                        CmdInsertNew.Parameters.AddWithValue("@Exist", dooo4);
                        CmdInsertNew.Parameters.AddWithValue("@Price", row.Cells["Price"].Value.ToString());
                        CmdInsertNew.Parameters.AddWithValue("@SalePrice1", row.Cells["SalePrice1"].Value.ToString());
                        CmdInsertNew.Parameters.AddWithValue("@SalePrice2", row.Cells["SalePrice2"].Value.ToString());
                        CmdInsertNew.Parameters.AddWithValue("@BillID", CmdInsertBill.Parameters["@BillID"].Value);
                        CmdInsertNew.Parameters.AddWithValue("@ProductName", row.Cells["ItemName"].Value.ToString());
                        CmdInsertNew.Parameters.AddWithValue("@ProductType", row.Cells["ItemType"].Value.ToString());
                        CmdInsertNew.Parameters.AddWithValue("@Minimum", row.Cells["CBMine"].Value.ToString());


                        SqlParameter p1 = new SqlParameter();
                        p1.ParameterName = "@ProductTypeID";
                        p1.SqlDbType = SqlDbType.Int;
                        p1.Direction = ParameterDirection.Output;
                        CmdInsertNew.Parameters.Add(p1);

                        SqlParameter p4 = new SqlParameter();
                        p4.ParameterName = "@ProductID";
                        p4.SqlDbType = SqlDbType.Int;
                        p4.Direction = ParameterDirection.Output;
                        CmdInsertNew.Parameters.Add(p4);

                        Con.Open();
                        CmdInsertNew.ExecuteNonQuery();
                        Con.Close();
                        /////////////////////////////////////////////
                        try
                        {
                            int ProID = int.Parse(CmdInsertNew.Parameters["@ProductID"].Value.ToString());

                            int Serial;
                            var CountSessions = context.TblProducts.Count();
                            if (CountSessions > 0)
                            {
                                var lastcode = context.TblProducts.Max(a => a.Serial);
                                Serial = int.Parse(lastcode.ToString()) + 1;

                            }
                            else
                            {
                                Serial = 1;
                            }

                            var ProductSerail = context.TblProducts.Where(a => a.ProductID == ProID).SingleOrDefault();
                            ProductSerail.Serial = Serial;
                            context.SaveChanges();

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("من فضلك اضغط ok وانتظر رساله تاكيد الشراء");

                        }
                        //////////////////////////////////////////////////////////////
                        ///// ونفس الكلام هنا برضه عملية شراء ل منتج 
                        SqlCommand CmdProcurement = new SqlCommand();
                        CmdProcurement.Connection = Con;
                        CmdProcurement.CommandType = CommandType.StoredProcedure;
                        CmdProcurement.CommandText = "InsertPurchases";


                        CmdProcurement.Parameters.AddWithValue("@BillID", CmdInsertBill.Parameters["@BillID"].Value.ToString());
                        CmdProcurement.Parameters.AddWithValue("@Quantity", row.Cells["Quantity"].Value.ToString());
                        CmdProcurement.Parameters.AddWithValue("@ProductID", CmdInsertNew.Parameters["@ProductID"].Value.ToString());
                        CmdProcurement.Parameters.AddWithValue("@ProductTypeID", CmdInsertNew.Parameters["@ProductTypeID"].Value.ToString());
                        CmdProcurement.Parameters.AddWithValue("@BPrice", row.Cells["Price"].Value.ToString());
                        CmdProcurement.Parameters.AddWithValue("@BTatol", row.Cells["Total"].Value.ToString());

                        Con.Open();
                        CmdProcurement.ExecuteNonQuery();
                        Con.Close();


                        ///////////////////////////////////////////////////////////////////////////
                        ////// وهنا برضه هاروح يعمل حركة الصنف والصباح رباح وكده 
                        SqlCommand Move = new SqlCommand();
                        Move.Connection = Con;
                        Move.CommandType = CommandType.StoredProcedure;
                        Move.CommandText = "AddProMovement";

                        Move.Parameters.AddWithValue("@MoveQuantity", row.Cells["Quantity"].Value.ToString());
                        Move.Parameters.AddWithValue("@ProductID", CmdInsertNew.Parameters["@ProductID"].Value.ToString());
                        Move.Parameters.AddWithValue("@TemporaryID", "1");
                        Move.Parameters.AddWithValue("@MoveDate", this.DtDateTime.Value);
                        Move.Parameters.AddWithValue("@MoveValue", row.Cells["Total"].Value.ToString());


                        Con.Open();
                        Move.ExecuteNonQuery();
                        Con.Close();
                        //////////////////////////////////////////////////////////////

                    }
                    DR.Close();
                    Con.Close();

                }

                /////////////////////////////////////
                // وهنا علشان لو لقى حسابات الجله يضهها لل اخ المورد 

                // اول حاجه هايعمل condition

                if (double.Parse(this.TxtTotal.Text) != double.Parse(this.Txtpaid.Text))
                {
                    //وبعد كده هايعمل search 
                    SqlCommand Cmd = new SqlCommand();
                    Cmd.Connection = Con;
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select * from TblProviders where ProviderID=@ProviderID ";

                    Cmd.Parameters.AddWithValue("@ProviderID", this.LblProviderName.Text);

                    SqlDataReader dr;
                    Con.Open();
                    dr = Cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        // هايروح بقى يعمل Update ب الرصيد الجديد
                        double M = double.Parse(this.TxtTotal.Text);
                        double F = double.Parse(this.Txtpaid.Text);
                        double KH = double.Parse(this.TxtOffer.Text);
                        double E = double.Parse(dr["Credit"].ToString());

                        double toto = M - KH;

                        double K = toto - F;
                        double A = K + E;

                        Con.Close();

                        SqlCommand UpdateCredit = new SqlCommand();
                        UpdateCredit.Connection = Con;
                        UpdateCredit.CommandType = CommandType.Text;
                        UpdateCredit.CommandText = "Update TblProviders set Credit=@Credit where ProviderID=@ProviderID";

                        UpdateCredit.Parameters.AddWithValue("@Credit", A);
                        UpdateCredit.Parameters.AddWithValue("@ProviderID", this.LblProviderName.Text);

                        Con.Open();
                        UpdateCredit.ExecuteNonQuery();
                        Con.Close();

                    }
                    dr.Close();
                    Con.Close();
                }

                /////////////////////////////////////////
                //////////////////////////////////////
                //// تسجيل العمليه خاص ب جالرى القصر
                if (this.CBProvider.SelectedItem != null)
                {

                    SqlCommand CuProc = new SqlCommand();
                    CuProc.Connection = Con;
                    CuProc.CommandType = CommandType.StoredProcedure;
                    CuProc.CommandText = "AddProProc";

                    CuProc.Parameters.AddWithValue("@ProviderID", this.CBProvider.SelectedValue);
                    CuProc.Parameters.AddWithValue("@ProDate", this.DtDateTime.Value);
                    CuProc.Parameters.AddWithValue("@ProPaied", this.TxtTotal.Text);
                    CuProc.Parameters.AddWithValue("@PRocName", "فاتورة شراء");

                    Con.Open();
                    CuProc.ExecuteNonQuery();
                    Con.Close();
                    ///////////////////////////////

                }

                ///////////////////////////////////////
                //////////////////////////////////////
                //// تسجيل العمليه خاص ب جالرى القصر
                if (this.CBProvider.SelectedItem != null)
                {

                    SqlCommand CuProc = new SqlCommand();
                    CuProc.Connection = Con;
                    CuProc.CommandType = CommandType.StoredProcedure;
                    CuProc.CommandText = "AddProProc";

                    CuProc.Parameters.AddWithValue("@ProviderID", this.CBProvider.SelectedValue);
                    CuProc.Parameters.AddWithValue("@ProDate", this.DtDateTime.Value);
                    CuProc.Parameters.AddWithValue("@ProPaied", this.Txtpaid.Text);
                    CuProc.Parameters.AddWithValue("@PRocName", "سداد");

                    Con.Open();
                    CuProc.ExecuteNonQuery();
                    Con.Close();
                    ///////////////////////////////

                }

                //////////////////////////////////////
                try
                {
                    TblLog Log = new TblLog();
                    Log.UserID = int.Parse(this.LblUserID.Text);
                    Log.Discription = " تسجيل فاتورة مشترايات رقم  : " + CmdInsertBill.Parameters["@BillID"].Value.ToString();
                    Log.DateOfLog = DateTime.Now;

                    context.TblLogs.Add(Log);
                    context.SaveChanges();

                }
                catch (Exception)
                {


                }
                //////////////////////////////////////
                this.Txtpaid.Text = string.Empty;
                this.CBStrorage.SelectedItem = null;
                this.CBProvider.SelectedItem = null;
                this.TxtTotal.Text = "";
                this.TxtOffer.Text = "";
                this.ChPercent.Checked = false;
                this.GVShowProducts.Rows.Clear();
                //////////////////////////////////////////////////
               // بيمسح الليله اللى اتخزنت 
                SqlCommand CmdDelete = new SqlCommand();
                CmdDelete.Connection = Con;
                CmdDelete.CommandType = CommandType.Text;
                CmdDelete.CommandText = "delete from TblTemporary where TemporaryID=1";

                Con.Open();
                CmdDelete.ExecuteNonQuery();
                Con.Close();
                //////////////////////////////////////
                MessageBox.Show("Done", "Creative Care");
                this.CBItemType.Focus();
            }
        }
        // /////////////////////////////////////////////////////
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
        /////////////////////
        // وهنا هاجيب اسم المنجات  

        private void loadProducts()
        {
            try
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
            catch (Exception)
            {


            }
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

        //اما بقى هنا انا بجيب الخزنه 

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


        private void BtnAdd_Click(object sender, EventArgs e)
        {
         //   Add To Table items and to temp 
            try
            {
               if (this.LblProviderName.Text == "")
                {
                    if (this.CBProvider.SelectedItem != null)
                    {
                        this.LblProviderName.Text = this.CBProvider.SelectedValue.ToString();
                    }

                }
                if (this.TxtQuantity.Text == string.Empty || this.TxtValue.Text == string.Empty || this.CBItemType.Text == string.Empty || this.CBItemName.Text == string.Empty)
                {
                    MessageBox.Show("من فضلك تاكد من انك ادخلت جميع الخانات المطلوبه ", "Creative Care");

                }
                else
                {
                        this.GVShowProducts.Rows.Add(this.CBItemType.Text, this.CBItemName.Text, this.TxtPrice.Text, this.TxtQuantity.Text, this.TxtValue.Text, this.TxtSalePrice1.Text, this.TxtSalePrice2.Text,this.TxtMine.Text , this.TxtBarcode.Text);

                   

                    try
                    {
                        TblTemp Temp = new TblTemp();

                        Temp.TypeName = this.CBItemType.Text;
                        Temp.ProductName = this.CBItemName.Text;
                        Temp.Price = double.Parse(this.TxtPrice.Text);
                        Temp.Quntity = double.Parse(this.TxtQuantity.Text);
                        Temp.Total = double.Parse(this.TxtValue.Text);
                        Temp.SalePrice1 = double.Parse(this.TxtSalePrice1.Text);
                        Temp.SalePrice2 = double.Parse(this.TxtSalePrice2.Text);
                        Temp.Minimum = double.Parse(TxtMine.Text);
                        Temp.Barcode = this.TxtBarcode.Text;
                        Temp.UserID = int.Parse(this.LblUserID.Text);
                        Temp.TempType = 1;
                        context.TblTemps.Add(Temp);
                        context.SaveChanges();
                    }
                    catch (Exception)
                    {

                       
                    }
                    
                     // ويرجع يفضى تانى علشان لو هايكتب حاجه جديده :D
                        this.CBItemType.Text = string.Empty;
                        this.CBItemName.Text = string.Empty;
                        this.CBItemType.SelectedItem = null;
                        this.CBItemName.SelectedItem = null;
                        this.TxtPrice.Text = string.Empty;
                        this.TxtQuantity.Text = string.Empty;
                        this.TxtValue.Text = string.Empty;
                        this.TxtSalePrice1.Text = string.Empty;
                        this.TxtSalePrice2.Text = string.Empty;
                        this.TxtBarcode.Text = string.Empty;
                        this.CBItemType.Focus();

                }

            }
            catch (Exception)
            {

                MessageBox.Show("من فضلك تاكد ان البيانات المطلوبه صحيحه");
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
            // :D "وده بقى علشان لو حب يتذاكى ويحط القيمه كلها يجبله سعر الحته "واخد بالك من 'الحته' دى
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
      // ///////////////////////////////////////////
        private void ShowTemp()
        {
            int UserTemp = int.Parse(LblUserID.Text);
            var Temp = context.TblTemps.Where(a => a.UserID == UserTemp && a.TempType == 1).ToList();
            foreach (var item in Temp)
            {
                this.GVShowProducts.Rows.Add(item.TypeName, item.ProductName, item.Price, item.Quntity, item.Total, item.SalePrice1, item.SalePrice2 , item.Minimum, item.Barcode);
            }
        }
        // /////////////////////////////////////////
        private void Procurement_Load(object sender, EventArgs e)
        {
            this.LoadProviders();
            this.LoadStore();
            this.loadStorage();
            this.LoadProductType();
            this.WindowState = FormWindowState.Maximized;
            this.ShowTemp();

        }

        private void GVShowProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ///  هنا علشان يطلعلى الاجمالى 
          
               
                double sum = 0;
                for (int i = 0; i < GVShowProducts.Rows.Count; ++i)
                {
                    sum += double.Parse(GVShowProducts.Rows[i].Cells[4].Value.ToString());
                }
                this.TxtTotal.Text = sum.ToString();
                this.Txtpaid.Text = sum.ToString();

           
          
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

        
        // just note 
        private void ChPercent_MouseHover(object sender, EventArgs e)
        {
            this.LblNote.Visible = true;
        }

        private void ChPercent_MouseLeave(object sender, EventArgs e)
        {
            this.LblNote.Visible = false;

        }
      
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {

                ////// بشوف اذا اكنت الفاتوره اجل ولا لا 
                if (this.CBStrorage.SelectedItem == null || this.CBStore.SelectedItem == null)
                {
                    // chech if storage selected or not 
                    MessageBox.Show("من فضلك تاكد من اختيار الخزنه و المخزن ", "Creative Care");
                    return;
                }
                else
                {
                    this.BtnConfirm.Enabled = false;



                    /////////////////////////////////////

                    if (this.TxtTotal.Text != this.Txtpaid.Text && this.LblProviderName.Text == "" && this.TxtOffer.Text == "0") //////////////////////////////////////// breake 
                    {

                        MessageBox.Show("الفاتوره تحتوى على حسابات اجله من فضلك اختار اسم المورد", "Creative Care");
                        this.CBProvider.Focus();
                        this.BtnConfirm.Enabled = true;
                        return;

                    }
                    // ده علشان لو ما اختارش اسم مورد يجبله لا احد علشان ما يطلعش ايرورو /////////////////////////////////////// 
                    else
                    {

                        int StoID = int.Parse(CBStore.SelectedValue.ToString());
                        if (this.LblProviderName.Text == "")
                        {
                            this.LblProviderName.Text = "14";
                        }
                        int TrasuerID = int.Parse(CBStrorage.SelectedValue.ToString());
                        double NewTruserTotal = double.Parse(Txtpaid.Text);

                        if (int.Parse(CBStrorage.SelectedValue.ToString()) != 3 && double.Parse(context.TblStorages.Where(a => a.StorageID == TrasuerID).FirstOrDefault().TotalMoney) <= 0 && double.Parse(context.TblStorages.Where(a => a.StorageID == TrasuerID).FirstOrDefault().TotalMoney) < NewTruserTotal)
                        {



                            MessageBox.Show("النقود فى الخزنه لا تكفى لعملية الشراء من فضلك اختر خزنه اخرى او حساب خارجى", "Abdelrahman", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                        }
                        else
                        {



                            /////////////////////////////////////////////////////////////


                            // Add New Bill 

                            TblBill Bill = new TblBill();
                            Bill.DateOfBill = DtDateTime.Value.Date;
                            Bill.ProviderID = int.Parse(this.LblProviderName.Text);
                            Bill.TotalPaid = this.TxtTotal.Text;
                            Bill.UserID = int.Parse(LblUserID.Text);
                            Bill.Paid = Txtpaid.Text;
                            Bill.StoreID = int.Parse(CBStore.SelectedValue.ToString());

                            context.TblBills.Add(Bill);
                            context.SaveChanges();

                            int BillID = Bill.BillID;




                            // Add Bill Items
                            foreach (DataGridViewRow row in GVShowProducts.Rows)
                            {
                                string TypeName = row.Cells["ItemType"].Value.ToString();
                                string ItemName = row.Cells["ItemName"].Value.ToString();
                                var CheckType = context.TblProductTypes.Where(a => a.ProductType.Equals(TypeName)).FirstOrDefault();

                                if (CheckType != null)
                                {
                                    // now i have type

                                    var CheckProductName = context.TblProducts.Where(a => a.ProductName.Equals(ItemName)).FirstOrDefault();

                                    if (CheckProductName != null)
                                    {
                                        // now i have Product will update data 

                                        double ExistQuntity = double.Parse(CheckProductName.Exist.ToString());
                                        double NewQuntity = double.Parse(row.Cells["Quantity"].Value.ToString());

                                        if (CheckProductName.Exist > 0)
                                        {

                                            var Prodo = context.TblProducts.Where(a => a.ProductID == CheckProductName.ProductID).SingleOrDefault();

                                            double OldQun = double.Parse(Prodo.Exist.ToString()) * double.Parse(Prodo.Price);

                                            double NewQun = double.Parse(row.Cells["Price"].Value.ToString()) * double.Parse(row.Cells["Quantity"].Value.ToString());

                                            double Qu = double.Parse(row.Cells["Quantity"].Value.ToString()) + double.Parse(Prodo.Exist.ToString());

                                            double NewAvgPrice = ( OldQun + NewQun ) / Qu;




                                            CheckProductName.Price = NewAvgPrice.ToString();
                                        }
                                        else
                                        {
                                            CheckProductName.Price = row.Cells["Price"].Value.ToString();

                                        }

                                        CheckProductName.Exist = ExistQuntity + NewQuntity;
                                        CheckProductName.SalePrice1 = row.Cells["SalePrice1"].Value.ToString();
                                        CheckProductName.SalePrice2 = row.Cells["SalePrice2"].Value.ToString();
                                        CheckProductName.Minimum = row.Cells["CBMine"].Value.ToString();
                                        CheckProductName.BillID = BillID;

                                        context.SaveChanges();

                                        // add to TblPurchases
                                        TblPurchas Purch = new TblPurchas();
                                        Purch.BillID = BillID;
                                        Purch.ProductID = CheckProductName.ProductID;
                                        Purch.ProductTypeID = CheckProductName.ProductTypeID;
                                        Purch.Quantity = row.Cells["Quantity"].Value.ToString();
                                        Purch.BPrice = row.Cells["Price"].Value.ToString();
                                        Purch.BTatol = row.Cells["Total"].Value.ToString();

                                        context.TblPurchases.Add(Purch);
                                        context.SaveChanges();

                                        // add to TblProductsMovements
                                        TblProductsMovement Move = new TblProductsMovement();
                                        Move.MoveQuantity = row.Cells["Quantity"].Value.ToString();
                                        Move.ProductID = CheckProductName.ProductID;
                                        Move.TemporaryID = 1;
                                        Move.MoveDate = DateTime.Now;
                                        Move.MoveValue = row.Cells["Total"].Value.ToString();

                                        context.TblProductsMovements.Add(Move);
                                        context.SaveChanges();



                                    }
                                    else
                                    {
                                        // just add new product

                                        int Serial;
                                        var CountSessions = context.TblProducts.Where(a=>a.StoreID == StoID).Count();
                                        if (CountSessions > 0 && CountSessions != 1)
                                        {
                                            var lastcode = context.TblProducts.Where(a => a.StoreID == StoID).Max(a => a.Serial);
                                            Serial = int.Parse(lastcode.ToString()) + 1;

                                        }
                                        else
                                        {
                                            Serial = 1;
                                        }

                                        TblProduct NewItem = new TblProduct();
                                        NewItem.ProductName = ItemName;
                                        NewItem.ProductTypeID = CheckType.ProductTypeID;
                                        NewItem.BillID = BillID;
                                        NewItem.Exist = double.Parse(row.Cells["Quantity"].Value.ToString());
                                        NewItem.Price = row.Cells["Price"].Value.ToString();
                                        NewItem.SalePrice1 = row.Cells["SalePrice1"].Value.ToString();
                                        NewItem.SalePrice2 = row.Cells["SalePrice2"].Value.ToString();
                                        NewItem.Barcode = row.Cells["Col_Barcode"].Value.ToString();
                                        NewItem.Serial = Serial;
                                        NewItem.StoreID = int.Parse(CBStore.SelectedValue.ToString());
                                        NewItem.Minimum = row.Cells["CBMine"].Value.ToString();

                                        context.TblProducts.Add(NewItem);
                                        context.SaveChanges();

                                        // add to TblPurchases
                                        TblPurchas Purch = new TblPurchas();
                                        Purch.BillID = BillID;
                                        Purch.ProductID = NewItem.ProductID;
                                        Purch.ProductTypeID = NewItem.ProductTypeID;
                                        Purch.Quantity = row.Cells["Quantity"].Value.ToString();
                                        Purch.BPrice = row.Cells["Price"].Value.ToString();
                                        Purch.BTatol = row.Cells["Total"].Value.ToString();

                                        context.TblPurchases.Add(Purch);
                                        context.SaveChanges();

                                        // add to TblProductsMovements
                                        TblProductsMovement Move = new TblProductsMovement();
                                        Move.MoveQuantity = row.Cells["Quantity"].Value.ToString();
                                        Move.ProductID = NewItem.ProductID;
                                        Move.TemporaryID = 1;
                                        Move.MoveDate = DateTime.Now;
                                        Move.MoveValue = row.Cells["Total"].Value.ToString();

                                        context.TblProductsMovements.Add(Move);
                                        context.SaveChanges();

                                    }

                                }
                                else
                                {
                                    // add type and product

                                    TblProductType ProType = new TblProductType();
                                    ProType.ProductType = TypeName;
                                    context.TblProductTypes.Add(ProType);
                                    context.SaveChanges();

                                    // just add new product

                                    int Serial;
                                    var CountSessions = context.TblProducts.Where(a => a.StoreID == StoID).Count();
                                    if (CountSessions > 0 && CountSessions != 1)
                                    {
                                        var lastcode = context.TblProducts.Where(a => a.StoreID == StoID).Max(a => a.Serial);
                                        Serial = int.Parse(lastcode.ToString()) + 1;

                                    }
                                    else
                                    {
                                        Serial = 1;
                                    }

                                    TblProduct NewItem = new TblProduct();
                                    NewItem.ProductName = ItemName;
                                    NewItem.ProductTypeID = ProType.ProductTypeID;
                                    NewItem.BillID = BillID;
                                    NewItem.Exist = double.Parse(row.Cells["Quantity"].Value.ToString());
                                    NewItem.Price = row.Cells["Price"].Value.ToString();
                                    NewItem.SalePrice1 = row.Cells["SalePrice1"].Value.ToString();
                                    NewItem.SalePrice2 = row.Cells["SalePrice2"].Value.ToString();
                                    NewItem.Barcode = row.Cells["Col_Barcode"].Value.ToString();
                                    NewItem.Serial = Serial;
                                    NewItem.StoreID = int.Parse(CBStore.SelectedValue.ToString());
                                    NewItem.Minimum = row.Cells["CBMine"].Value.ToString();

                                    context.TblProducts.Add(NewItem);
                                    context.SaveChanges();

                                    // add to TblPurchases
                                    TblPurchas Purch = new TblPurchas();
                                    Purch.BillID = BillID;
                                    Purch.ProductID = NewItem.ProductID;
                                    Purch.ProductTypeID = NewItem.ProductTypeID;
                                    Purch.Quantity = row.Cells["Quantity"].Value.ToString();
                                    Purch.BPrice = row.Cells["Price"].Value.ToString();
                                    Purch.BTatol = row.Cells["Total"].Value.ToString();

                                    context.TblPurchases.Add(Purch);
                                    context.SaveChanges();

                                    // add to TblProductsMovements
                                    TblProductsMovement Move = new TblProductsMovement();
                                    Move.MoveQuantity = row.Cells["Quantity"].Value.ToString();
                                    Move.ProductID = NewItem.ProductID;
                                    Move.TemporaryID = 1;
                                    Move.MoveDate = DateTime.Now;
                                    Move.MoveValue = row.Cells["Total"].Value.ToString();

                                    context.TblProductsMovements.Add(Move);
                                    context.SaveChanges();



                                }

                            }


                            if (int.Parse(CBStrorage.SelectedValue.ToString()) != 3)
                            {
                                var Treuser = context.TblStorages.Where(a => a.StorageID == TrasuerID).FirstOrDefault();
                                double Old = double.Parse(Treuser.TotalMoney);
                               

                                double UpdateTotal = Old - NewTruserTotal;

                                Treuser.TotalMoney = UpdateTotal.ToString();
                                context.SaveChanges();

                                
                            }


                            /////////////////////////////////////
                            // وهنا علشان لو لقى حسابات الجله يضهها لل اخ المورد 

                            // اول حاجه هايعمل condition

                            if (double.Parse(this.TxtTotal.Text) != double.Parse(this.Txtpaid.Text))
                            {

                                int proID = int.Parse(this.LblProviderName.Text);

                                var Supplier = context.TblProviders.Where(a => a.ProviderID == proID).FirstOrDefault();
                                double M = double.Parse(this.TxtTotal.Text);
                                double F = double.Parse(this.Txtpaid.Text);
                                double KH = double.Parse(this.TxtOffer.Text);
                                double E = double.Parse(Supplier.Credit);

                                double toto = M - KH;

                                double K = toto - F;
                                double A = K + E;

                                Supplier.Credit = A.ToString();
                                context.SaveChanges();

                            }

                            /////////////////////////////////////////
                            //////////////////////////////////////
                            //// تسجيل العمليه خاص ب جالرى القصر
                            if (this.CBProvider.SelectedItem != null)
                            {
                                int proID = int.Parse(this.LblProviderName.Text);

                                TblProProc Process = new TblProProc();

                                Process.ProviderID = proID;
                                Process.ProDate = DateTime.Now;
                                Process.PRocName = "شراء فاتوره";
                                Process.ProPaied = this.TxtTotal.Text;

                                context.TblProProcs.Add(Process);
                                context.SaveChanges();

                                TblProProc Processe = new TblProProc();

                                Processe.ProviderID = proID;
                                Processe.ProDate = DateTime.Now;
                                Processe.PRocName = "سداد";
                                Processe.ProPaied = this.Txtpaid.Text;

                                context.TblProProcs.Add(Processe);
                                context.SaveChanges();


                            }


                            /////////////////////////////////////////////////
                            // هنا بقى يابرنس بيضيف العمليات بتاعت الخزنه
                            TblStorageProce StorageAction = new TblStorageProce();
                            StorageAction.SActionID = 1;
                            StorageAction.SPDate = DateTime.Now;
                            StorageAction.SPMoney = this.Txtpaid.Text;
                            StorageAction.StorageID = int.Parse(this.CBStrorage.SelectedValue.ToString());

                            context.TblStorageProces.Add(StorageAction);
                            context.SaveChanges();


                           
                            /////////////////////////////////
                            try
                            {
                                TblLog Log = new TblLog();
                                Log.UserID = int.Parse(this.LblUserID.Text);
                                Log.Discription = " تسجيل فاتورة مشترايات رقم  : " + BillID.ToString();
                                Log.DateOfLog = DateTime.Now;

                                context.TblLogs.Add(Log);
                                context.SaveChanges();

                            }
                            catch (Exception)
                            {


                            }
                            ///////////////////////////////////////
                            this.Txtpaid.Text = string.Empty;
                            this.CBStrorage.SelectedItem = null;
                            this.CBProvider.SelectedItem = null;
                            this.TxtTotal.Text = "";
                            this.GVShowProducts.Rows.Clear();
                            this.TxtOffer.Text = "";
                            this.ChPercent.Checked = false;
                            // بيمسح البيانات المؤقته 
                            int UID = int.Parse(LblUserID.Text);

                            var tem = context.TblTemps.Where(a => a.UserID == UID && a.TempType == 1).ToList();

                            foreach (var item in tem)
                            {
                                context.TblTemps.Remove(item);
                                context.SaveChanges();
                            }
                            /////////////////////////////////////////
                            MessageBox.Show("Done", "Creative Care");
                            this.CBItemType.Focus();
                        }
                    }
                    ///////////////////////////////////////////////  
                }





                this.BtnConfirm.Enabled = true;

            }
            catch (Exception ex)
            {
                this.BtnConfirm.Enabled = true;
                MessageBox.Show(ex.ToString());
                //MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
            }
        }

        private void BtnAddProvider_Click(object sender, EventArgs e)
        {
            // بيظهر اضافة مورد جديد
            this.LblName.Visible = true;
            this.LblPhone.Visible = true;
            this.LblCompany.Visible = true;
            this.TxtName.Visible = true;
            this.TxtTelephone.Visible = true;
            this.TxtCompany.Visible = true;
            this.BtnAddProv.Visible = true;

        }

        private void BtnAddProv_Click(object sender, EventArgs e)
        {

            try
            {

                // هنا انا بضيف مورد جديد بدل اللفه اللى فاتت دى 
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "InsertProvier";

                Cmd.Parameters.AddWithValue("@ProviderName", this.TxtName.Text);
                Cmd.Parameters.AddWithValue("@TelephoneNumber", this.TxtTelephone.Text);
                Cmd.Parameters.AddWithValue("@CompanyName", this.TxtCompany.Text);
                Cmd.Parameters.AddWithValue("@Credit", 0);
                Cmd.Parameters.AddWithValue("@Debit", 0);
                SqlParameter p1 = new SqlParameter();
                p1.ParameterName = "@ProviderID";
                p1.SqlDbType = SqlDbType.Int;
                p1.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(p1);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                this.LblProviderName.Text = Cmd.Parameters["@ProviderID"].Value.ToString();
                this.LblName.Visible = false;
                this.LblPhone.Visible = false;
                this.LblCompany.Visible = false;
                this.TxtName.Visible = false;
                this.TxtTelephone.Visible = false;
                this.TxtCompany.Visible = false;
                this.BtnAddProv.Visible = false;
                this.LoadProviders();
              
                MessageBox.Show("Done", "Creative Care");
            }
            catch (Exception)
            {

                MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
            }

        }

        

        private void BtnHome_Click(object sender, EventArgs e)/////////////////////////////////////////////////// Done
        {
            this.Close();
            Home HO = new Home(this.LblUserName.Text,int.Parse(this.LblUserID.Text));
            HO.Visible = true;
        }

      

        private void CBItemType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.CBStore.SelectedItem==null)
            {
                MessageBox.Show("من فضلك اختار المخزن", "Creative Care");
            }
            else
            {
                this.loadProducts();
            }
           
        }
        /// <summary>
        // ده الكود اللى كنت بسالك عليه اهندزه 
        /// </summary>

        private void CBItemType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.CBStore.SelectedItem == null)
                {
                    MessageBox.Show("من فضلك اختار المخزن", "Creative Care");
                }
                else
                {
                    this.loadProducts();
                    this.CBItemName.Focus();
                }
            }
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

                var tem = context.TblTemps.Where(a => a.UserID == UID && a.TempType == 1).ToList();

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
                        this.TxtPrice.Text = DR["Price"].ToString();
                       
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

            this.CBStore.SelectedItem = null;
            this.CBItemName.SelectedItem = null;
            this.CBItemType.SelectedItem = null;
            this.TxtPrice.Text = "";
        }

        private void CBProvider_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LblProviderName.Text = this.CBProvider.SelectedValue.ToString();
        }

        private void GVShowProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < GVShowProducts.Rows.Count; ++i)
            {
                sum += double.Parse(GVShowProducts.Rows[i].Cells[4].Value.ToString());
            }
            this.TxtTotal.Text = sum.ToString();
            this.Txtpaid.Text = sum.ToString();

        }

        private void GVShowProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < GVShowProducts.Rows.Count; ++i)
            {
                double x = double.Parse(GVShowProducts.Rows[i].Cells["Price"].Value.ToString());
                double y = double.Parse(GVShowProducts.Rows[i].Cells["Quantity"].Value.ToString());

                double Toto = x * y;

                GVShowProducts.Rows[i].Cells["Total"].Value = Toto.ToString();
                
                sum += double.Parse(GVShowProducts.Rows[i].Cells["Total"].Value.ToString());
            }
            this.TxtTotal.Text = sum.ToString();
            this.Txtpaid.Text = sum.ToString();
        }

        private void TxtQuantity_TextChanged(object sender, EventArgs e)
        {
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

        private void CBItemName_SelectionChangeCommitted(object sender, EventArgs e)
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
                    this.TxtPrice.Text = dr["Price"].ToString();

                }
                dr.Close();
                Con.Close();
            }
            catch (Exception)
            {
                
               
            }
           
        }

        private void CBStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CBItemType.Focus();
            }
        }

        private void CBItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.TxtQuantity.Focus();
            }
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
                this.TxtMine.Focus();
            }
        }

        private void TxtMine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.TxtSalePrice1.Focus();
            }
        }

        private void TxtSalePrice2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BtnAdd.Focus();
            }
        }

        private void TxtSalePrice1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.TxtSalePrice2.Focus();
            }
        }

        private void TxtSerailSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // هنا بقى البحث بتاع الباركود 
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
                        this.TxtPrice.Text = DR["Price"].ToString();

                    }
                    DR.Close();
                    Con.Close();

                }

                  
                //}
                this.TxtSerailSearch.Text = "";
               
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
            //foreach (var item in context.TblProducts.Where(a=>a.Serial == null).ToList())
            //{
            //    int Serial;
            //    var CountSessions = context.TblProducts.Where(a=>a.Serial != null).Count();
            //    if (CountSessions > 0)
            //    {
            //        var lastcode = context.TblProducts.Where(a => a.Serial != null).Max(a => a.Serial);
            //        Serial = int.Parse(lastcode.ToString()) + 1;

            //    }
            //    else
            //    {
            //        Serial = 1;
            //    }

            //    item.Serial = Serial;
            //    context.SaveChanges();
            //}
       // }
 
    }
}

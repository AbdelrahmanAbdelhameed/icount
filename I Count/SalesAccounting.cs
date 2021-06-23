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
    public partial class SalesAccounting : Form
    {
       // SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        AccountingEntities context = new AccountingEntities();
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public SalesAccounting(int ID)
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
        /////////////////////////////////////////////////////////////////
        ////////// بص بقى الحكايه انى عامل 2 CheckBox
        ///// الاول لما يختاره يفتحله بحث ب اسم العميل ولما يختار اسم العميل يعمل ايه يعرضله كل بياناته فى الجريد فيو الاولى 
        // وبعد كده ممكن يعمل سداد للديون 
        // وكمان ممكن يعرض تاريخ السداد بتاعه اما الكل او بتاريخ معين من الى 
        // اما بقى الشيك التانى ده بيعمل بحث عن فواتير المعدول 
        // وكمان لما يختار الفاتوره ويسلكت بيعرضه تفاصيل الفاتور الاصناف اللى فيها والتاريخ والمجموع والمدفوع وكمان الكميه 
        // طيب تقولى ناقص ايه اقولك 1- اعمل try لكل الاكواد 
        // اعمل موضوع ال User 
        // وبكده نبقى حزمنا الاجل بيع 
        // اه واعدل ال Close بتاع الفورم اللى عملناها 
        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// //هنا بقى انا بحيب اسم العمل 
        /// </summary>
        //////////////////////////////////////////////////////////////////////////
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
            CBCustNameEBill.DisplayMember = "CustomerName";
            CBCustNameEBill.ValueMember = "CustomerID";
            CBCustNameEBill.DataSource = ds.Tables["TblCustomers"];
            CBCustNameEBill.SelectedItem = null;
            CBCustomerName.DisplayMember = "CustomerName";
            CBCustomerName.ValueMember = "CustomerID";
            CBCustomerName.DataSource = ds.Tables["TblCustomers"];
            CBCustomerName.SelectedItem = null;
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
            CBPayStorrage.DisplayMember = "StorageName";
            CBPayStorrage.ValueMember = "StorageID";
            CBPayStorrage.DataSource = ds.Tables["TblStorages"];
            CBPayStorrage.SelectedItem = null;
            Con.Close();
        }

        /// ////////////////////////////////////////////////////////////
        ///////

        private void SalesAccounting_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.LoadCustomer();
            this.ShowAllMarda8ana();
            this.loadStorage();

        }

        //private void BtnSale_Click(object sender, EventArgs e)//////////////////////////done
        //{
        //    this.Visible = false;
        //    Sales SA = new Sales(int.Parse(this.LblUserID.Text));
        //    SA.Visible = true;
        //}

        //private void BtnBuy_Click(object sender, EventArgs e)//////////////////////Done
        //{
        //    this.Visible = false;
        //    Procurement PRO = new Procurement(int.Parse(this.LblUserID.Text));
        //    PRO.Visible = true;
        //}
        /// <summary>
        /// هنا بقى بيعمل ايه ها ها 
        /// بص بيروح يعمل اضافة عميل جديد 
        /// بس بيبص على ال 3 شروط او 3 حالات دول لانه هنا فى الشراء او البيع لو لقى نتيجة البحث null بيدى ايررو 
        /// علشان كده انا عملت ال 3 شروط دول وبيحط  0 لو كانت null 
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void BtnAddProv_Click(object sender, EventArgs e)
        {
            if (this.TxtDebit.Text != null && this.TxtCredit.Text != null)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "AddCustomer";

                Cmd.Parameters.AddWithValue("@CustomerName", this.TxtName.Text);
                Cmd.Parameters.AddWithValue("@CustomerPhone", this.TxtTelephone.Text);
                Cmd.Parameters.AddWithValue("@CustomerCompany", this.TxtCompany.Text);
                Cmd.Parameters.AddWithValue("@Credit", this.TxtCredit.Text);
                Cmd.Parameters.AddWithValue("@Debit", this.TxtDebit.Text);

                SqlParameter p1 = new SqlParameter();
                p1.ParameterName = "@CustomerID";
                p1.SqlDbType = SqlDbType.Int;
                p1.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(p1);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                this.TxtCredit.Text = string.Empty;
                this.TxtDebit.Text = string.Empty;
                this.LblName.Visible = false;
                this.LblPhone.Visible = false;
                this.LblCompany.Visible = false;
                this.TxtName.Visible = false;
                this.TxtTelephone.Visible = false;
                this.TxtCompany.Visible = false;
                this.BtnAddProv.Visible = false;
                this.BtnAddProvider.Visible = true;
                this.TxtCredit.Visible = false;
                this.TxtDebit.Visible = false;
                this.LblDaen.Visible = false;
                this.LblMadeen.Visible = false;
                MessageBox.Show("Done","Creative Care");

            }
            else if (this.TxtDebit.Text != null && this.TxtCredit.Text == null)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "AddCustomer";

                Cmd.Parameters.AddWithValue("@CustomerName", this.TxtName.Text);
                Cmd.Parameters.AddWithValue("@CustomerPhone", this.TxtTelephone.Text);
                Cmd.Parameters.AddWithValue("@CustomerCompany", this.TxtCompany.Text);
                Cmd.Parameters.AddWithValue("@Credit", 0);
                Cmd.Parameters.AddWithValue("@Debit", this.TxtDebit.Text);

                SqlParameter p1 = new SqlParameter();
                p1.ParameterName = "@CustomerID";
                p1.SqlDbType = SqlDbType.Int;
                p1.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(p1);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                this.TxtCredit.Text = string.Empty;
                this.TxtDebit.Text = string.Empty;
                this.LblName.Visible = false;
                this.LblPhone.Visible = false;
                this.LblCompany.Visible = false;
                this.TxtName.Visible = false;
                this.TxtTelephone.Visible = false;
                this.TxtCompany.Visible = false;
                this.BtnAddProvider.Visible = true;
                this.BtnAddProv.Visible = false;
                this.TxtCredit.Visible = false;
                this.TxtDebit.Visible = false;
                this.LblDaen.Visible = false;
                this.LblMadeen.Visible = false;
                MessageBox.Show("Done","Creative Care");
            }
            else
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "AddCustomer";

                Cmd.Parameters.AddWithValue("@CustomerName", this.TxtName.Text);
                Cmd.Parameters.AddWithValue("@CustomerPhone", this.TxtTelephone.Text);
                Cmd.Parameters.AddWithValue("@CustomerCompany", this.TxtCompany.Text);
                Cmd.Parameters.AddWithValue("@Credit", 0);
                Cmd.Parameters.AddWithValue("@Debit", 0);

                SqlParameter p1 = new SqlParameter();
                p1.ParameterName = "@CustomerID";
                p1.SqlDbType = SqlDbType.Int;
                p1.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(p1);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                this.TxtCredit.Text = string.Empty;
                this.TxtDebit.Text = string.Empty;
                this.LblName.Visible = false;
                this.LblPhone.Visible = false;
                this.LblCompany.Visible = false;
                this.TxtName.Visible = false;
                this.TxtTelephone.Visible = false;
                this.TxtCompany.Visible = false;
                this.BtnAddProv.Visible = false;
                this.BtnAddProvider.Visible = true;
                this.TxtCredit.Visible = false;
                this.TxtDebit.Visible = false;
                this.LblDaen.Visible = false;
                this.LblMadeen.Visible = false;
                MessageBox.Show("Done","Creative Care");
            }
        }
        /// <summary>
        /// ///////////////////////////////////هنا بنظهر اللى انا كنت مخبيه :D
        /// 
        /// </summary>

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
            this.BtnAddProvider.Visible = false;
            this.TxtCredit.Visible = true;
            this.TxtDebit.Visible = true;
            this.LblDaen.Visible = true;
            this.LblMadeen.Visible = true;
        }

        private void BtnHome_Click(object sender, EventArgs e)////////////////////////////////Done
        {
            this.Close();
            Home HO = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            HO.Visible = true;
        }

        private void CHCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            /////////////////////////////  هنا بيظهر بحث ب اسم العميل 
            this.CBCustomerName.Visible = true;
            this.LblCustName.Visible = true;
            this.CHBills.Checked = false;
            this.LblCustNameEBill.Visible = false;
            this.CBCustNameEBill.Visible = false;
            this.LblDate.Visible = false;
            this.LblFrom.Visible = false;
            this.LblTo.Visible = false;
            this.DTB1.Visible = false;
            this.DTB2.Visible = false;
            this.BtnAdd.Visible = false;
            this.LblNote3.Hide();
            this.BtnAllBills.Hide();
            this.CBCustNameEBill.SelectedItem = null;
            this.CBCustomerName.SelectedItem = null;

        }

        private void CHBills_CheckedChanged(object sender, EventArgs e)
        {
            //////////////////////////// هنا بقى بيعمل بحث عن فاتوره لعميل 
            this.LblCustNameEBill.Visible = true;
            this.CBCustNameEBill.Visible = true;

            this.CHCustomerName.Checked = false;
            this.CBCustomerName.Visible = false;
            this.LblCustName.Visible = false;
         //   this.LblNote2.Hide();//////////////////////////////////////////////////////////////////////////////////////////////  ده هايتظبط
            this.BtnShowAll.Hide();
            this.BtnShow.Hide();
            this.BtnHistory.Hide();
            this.GvShowHistory.Hide();
            this.PanPay.Hide();
            this.GVShowCustmers.Hide();
            this.LblNote.Hide();
            this.LblNote3.Hide();
            this.CBCustNameEBill.SelectedItem = null;
            this.CBCustomerName.SelectedItem = null;
            this.GVShowBills.Hide();
            this.BtnBack.Hide();

        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// / هنا بقى لما يختار اسم عميل يجبله بياناتع  عرض بس 
        /// وممكن نعمل فيها تعديل بيانات بس مش دلوقتى 
        /// </summary>
        private void CBCustomerName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LblNote.Visible = true;
           
            this.GVShowCustmers.Visible = true;
            this.BtnHistory.Visible = true;
            this.GVShowCustmers.Rows.Clear();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblCustomers where CustomerID=@CustomerID ";

            Cmd.Parameters.AddWithValue("@CustomerID", this.CBCustomerName.SelectedValue);

            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();
            if (dr.Read())
            {
                this.GVShowCustmers.Rows.Add(dr["CustomerName"].ToString(), dr["CustomerCompany"].ToString(), dr["Debit"].ToString(), dr["Credit"].ToString(), dr["CustomerPhone"].ToString(), dr["CustomerID"].ToString());

            }
            dr.Close();
            Con.Close();
            // hide some items 
            this.LblDate.Hide();
            this.LblFrom.Hide();
            this.LblTo.Hide();
            this.DTB1.Hide();
            this.DTB2.Hide();
            this.BtnShow.Hide();
            this.GvShowHistory.Hide();
            this.BtnShowAll.Hide();
            this.BtnBack.Hide();
            this.LblNote3.Hide();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////// هنا بقى علشان يسدد دين 
        private void GVShowCustmers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.LblNote.Visible = false;
            this.GVShowCustmers.Visible = false;
            this.PanPay.Show();
            this.LblNote3.Hide();

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////// هنا بقى هايعمل بحث عن فاتوره لمورد ب التاريه "فاتوره "ايوه .......

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            bool Found = false;
            //// بحث ب الفاتوره والتاريخ
            this.LblNote3.Show();
            this.GVShowBills.Show();
            this.GVShowBills.Rows.Clear();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from VWShowSaleBill where CustomerID=@CustomerID and BillDate BETWEEN @from and  @to  ";

            //(month(BillDate) = month(@from)  AND month(BillDate) =month(@to)) and (Day(BillDate) >= Day(@from)  AND Day(BillDate) <=Day(@to))and (year(BillDate) = year(@from)  AND year(BillDate)=year(@to))

            Cmd.Parameters.AddWithValue("@CustomerID", this.CBCustNameEBill.SelectedValue);
            Cmd.Parameters.AddWithValue("@from", this.DTB1.Value.ToString("yyyy-MM-dd"));
            Cmd.Parameters.AddWithValue("@to", this.DTB2.Value.ToString("yyyy-MM-dd"));


            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();

            while (dr.Read())//////////////////////Discount
            {
                double X = double.Parse(dr["Total"].ToString());
                double V = double.Parse(dr["Paid"].ToString());
                double DS = double.Parse(dr["Discount"].ToString());

                double W = X - DS;
                double Totall = W - V;

                this.GVShowBills.Rows.Add(dr["CustomerName"].ToString(), dr["BillDate"].ToString(), dr["Total"].ToString(), dr["Paid"].ToString(), dr["Discount"].ToString(), Totall, dr["SaleBillID"].ToString());
                Found = true;
            }
            Found = false;
            dr.Close();
            Con.Close();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////// هنا بقى بيعمل سداد لعميل يعنى بيخصم من اللى عليه 

        private void BtnPay_Click(object sender, EventArgs e)
        {
            int rowindex = GVShowCustmers.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GVShowCustmers.Rows[rowindex];

           

            if (this.CBPayStorrage.SelectedItem==null || this.TxtValue.Text=="")
            {
                MessageBox.Show("  من فضلك اختار الخزنه والقيمه ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.CBPayStorrage.Focus();
            }
            else
            {
                if (this.CBPayStorrage.SelectedValue.ToString() != "3")
                {
                    int TearID = int.Parse(CBPayStorrage.SelectedValue.ToString());

                    var Treaseur = context.TblStorages.Where(a => a.StorageID == TearID).FirstOrDefault();
                    double X = double.Parse(Treaseur.TotalMoney);
                    double y = double.Parse(this.TxtValue.Text);
                    double W = X + y;

                    Treaseur.TotalMoney = W.ToString();
                    context.SaveChanges();

                }

                TblRepaySale RS = new TblRepaySale();
                RS.CustomerID = int.Parse(Row.Cells["CumID"].Value.ToString());
                RS.DateOfPay = DateTime.Now;
                RS.TotalMoneyPaied = TxtValue.Text;
                RS.UserID = int.Parse(LblUserID.Text);
                RS.StorageID = int.Parse(CBPayStorrage.SelectedValue.ToString());

                context.TblRepaySales.Add(RS);
                context.SaveChanges();


                int Cudu = int.Parse(Row.Cells["CumID"].Value.ToString());
                var Custo = context.TblCustomers.Where(a => a.CustomerID == Cudu).SingleOrDefault();

                double A = double.Parse(Custo.Debit.ToString());
                double B = double.Parse(this.TxtValue.Text);
                double Value = A - B;

                Custo.Debit = Value.ToString();
                context.SaveChanges();


                TblCusPro CusPros = new TblCusPro();
                CusPros.DateOfProc = DateTime.Now;
                CusPros.PayedValue = B.ToString();
                CusPros.CustomerID = Cudu;
                CusPros.ProcName = "سداد اجل";

                context.TblCusPros.Add(CusPros);
                context.SaveChanges();

                TblStorageProce Spt = new TblStorageProce();
                Spt.SActionID = 7;
                Spt.SPDate = DateTime.Now;
                Spt.SPMoney = B.ToString();
                Spt.StorageID = int.Parse(CBPayStorrage.SelectedValue.ToString());

                context.TblStorageProces.Add(Spt);
                context.SaveChanges();

                
                try
                {
                   
                    TblLog Log = new TblLog();
                    Log.UserID = int.Parse(this.LblUserID.Text);
                    Log.Discription = "  سداد مبلغ : " + this.TxtValue.Text + "للعميل" + Custo.CustomerName;
                    Log.DateOfLog = DateTime.Now;

                    context.TblLogs.Add(Log);
                    context.SaveChanges();

                }
                catch (Exception)
                {


                }

                MessageBox.Show("تم بنجاح ", "Creative Care");
                this.PanPay.Hide();
                this.TxtValue.Text = string.Empty;
                this.CBPayStorrage.SelectedItem = null;
                this.GVShowCustmers.Show();
                ////////////////////////////////////////////////// search 
                this.GVShowCustmers.Rows.Clear();

                foreach (var item in context.TblCustomers.ToList())
                {
                    this.GVShowCustmers.Rows.Add(item.CustomerName, item.CustomerCompany, item.Debit, item.Credit, item.CustomerPhone, item.CustomerID);

                }




            }
            
            
        }
        ///////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////// هنا بقى بيروح يعرض ناريخ السداد القديم 

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            if (this.CBCustomerName.SelectedItem == null)
            {
                MessageBox.Show("من فضلك اختار اسم العميل", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            ////////
            else
            {

                this.GVShowCustmers.Hide();
                this.LblNote.Hide();
                this.LblDate.Show();
                this.LblFrom.Show();
                this.LblTo.Show();
                this.DTB1.Show();
                this.DTB2.Show();
                this.BtnShow.Show();
                this.BtnShowAll.Show();
                this.BtnBack.Show();
                this.LblNote3.Hide();
                LblTotalpayedinsales.Show();
                LblTotalpayedinsales.Text = "";
            }
        }

        private void BtnShow_Click(object sender, EventArgs e)////////////////////////////////////////////
        {
            this.GvShowHistory.Rows.Clear();
            this.GvShowHistory.Show();
            ///// هنا بيعمل بحث بتاريخ معين 
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from ShowRepaySalesHistory where CustomerID=@CustomerID and DateOfPay BETWEEN @from and  @to  ";

            //(month(DateOfPay) = month(@from)  AND month(DateOfPay) =month(@to)) and (Day(DateOfPay) >= Day(@from)  AND Day(DateOfPay) <=Day(@to))and (year(DateOfPay) = year(@from)  AND year(DateOfPay)=year(@to))

            Cmd.Parameters.AddWithValue("@CustomerID", this.CBCustomerName.SelectedValue);
            Cmd.Parameters.AddWithValue("@from", this.DTB1.Value.ToString("yyyy-MM-dd"));
            Cmd.Parameters.AddWithValue("@to", this.DTB2.Value.ToString("yyyy-MM-dd"));


            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();

            while (dr.Read())
            {
                this.GvShowHistory.Rows.Add(dr["CustomerName"].ToString(), dr["TotalMoneyPaied"].ToString(), dr["DateOfPay"].ToString(), dr["Name"].ToString());

            }
            dr.Close();
            Con.Close();
        }

        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            // هنا بيعمل بحث على كل عمليات السداد
            this.GvShowHistory.Show();
            LblTotalpayedinsales.Text = "";


            this.GvShowHistory.Rows.Clear();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from ShowRepaySalesHistory where CustomerID=@CustomerID ";

            Cmd.Parameters.AddWithValue("@CustomerID", this.CBCustomerName.SelectedValue);

            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();

            while (dr.Read())
            {
                this.GvShowHistory.Rows.Add(dr["CustomerName"].ToString(), dr["TotalMoneyPaied"].ToString(), dr["DateOfPay"].ToString(), dr["Name"].ToString());
                
            }
           
            dr.Close();
            Con.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.GVShowCustmers.Show();
            this.LblNote.Show();
            this.LblDate.Hide();
            this.LblFrom.Hide();
            this.LblTo.Hide();
            this.DTB1.Hide();
            this.DTB2.Hide();
            this.BtnShow.Hide();
            this.GvShowHistory.Hide();
            this.BtnShowAll.Hide();
            this.BtnBack.Hide();
            this.LblNote3.Hide();
            LblTotalpayedinsales.Hide();
        }
        //////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////// هنا بيعرض كل الفواتير 

        private void BtnAllBills_Click(object sender, EventArgs e)
        {
            bool Found = false;
            this.LblNote3.Show();
            this.GVShowBills.Rows.Clear();

            this.GVShowBills.Show();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from VWShowSaleBill where CustomerID=@CustomerID   ";

            Cmd.Parameters.AddWithValue("@CustomerID", this.CBCustNameEBill.SelectedValue);

            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();

            while (dr.Read())//////////////////////Discount
            {
                double X = double.Parse(dr["Total"].ToString());
                double V = double.Parse(dr["Paid"].ToString());
                double DS = double.Parse(dr["Discount"].ToString());

                double W = X - DS;
                double Totall = W - V;

                this.GVShowBills.Rows.Add(dr["CustomerName"].ToString(), dr["BillDate"].ToString(), dr["Total"].ToString(), dr["Paid"].ToString(), dr["Discount"].ToString(), Totall, dr["SaleBillID"].ToString());
                Found = true;
            }
            Found = false;
            dr.Close();
            Con.Close();

        }
        ///////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////// هنا لما يسلكت الرو بيعمل ايه بيروح يديله ID الفاتوره ووكذا

        private void GVShowBills_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = GVShowBills.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GVShowBills.Rows[rowindex];

            SalesBills SB = new SalesBills(int.Parse(Row.Cells["BillID"].Value.ToString()));
            SB.Show();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////// هنا لما يختار اسم العميل يجبله البحث بتاعه 

        private void CBCustNameEBill_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LblDate.Visible = true;
            this.LblFrom.Visible = true;
            this.LblTo.Visible = true;
            this.DTB1.Visible = true;
            this.DTB2.Visible = true;
            this.BtnAllBills.Show();
            this.BtnAdd.Visible = true;
        }

        private void BtnFuturesBuy_Click(object sender, EventArgs e)///////////////////////////Done
        {
            this.Close();
            PurchasesAccounting Pro = new PurchasesAccounting(int.Parse(this.LblUserID.Text));
            Pro.Show();
        }
        /// <summary>
        /// //////// ///////////////////////////////////  هنا الايفنت بتاع Key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.LblNote.Visible = true;
                this.GVShowCustmers.Rows.Clear();
                this.GVShowCustmers.Visible = true;
                this.BtnHistory.Visible = true;
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from TblCustomers where CustomerID=@CustomerID ";

                Cmd.Parameters.AddWithValue("@CustomerID", this.CBCustomerName.SelectedValue);

                SqlDataReader dr;
                Con.Open();
                dr = Cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.GVShowCustmers.Rows.Add(dr["CustomerName"].ToString(), dr["CustomerCompany"].ToString(), dr["Debit"].ToString(), dr["Credit"].ToString(), dr["CustomerPhone"].ToString(), dr["CustomerID"].ToString());

                }
                dr.Close();
                Con.Close();
            }
        }
        // /  /// ///  ///     //////////////////////////////////////////////////////
        // Show all marda8ana 
        private void ShowAllMarda8ana()
        {
            this.LblNote.Visible = true;
            this.GVShowCustmers.Rows.Clear();
            this.GVShowCustmers.Visible = true;
            this.BtnHistory.Visible = true;
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblCustomers ";

           

            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();
            while (dr.Read())
            {
                this.GVShowCustmers.Rows.Add(dr["CustomerName"].ToString(), dr["CustomerCompany"].ToString(), dr["Debit"].ToString(), dr["Credit"].ToString(), dr["CustomerPhone"].ToString(), dr["CustomerID"].ToString());

            }
            dr.Close();
            Con.Close();
        }
        
        
        ////////
        private void CBCustNameEBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.LblDate.Visible = true;
                this.LblFrom.Visible = true;
                this.LblTo.Visible = true;
                this.DTB1.Visible = true;
                this.DTB2.Visible = true;
                this.BtnAllBills.Show();
                this.BtnAdd.Visible = true;
            } ///////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void GvShowHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblCustNameEBill_Click(object sender, EventArgs e)
        {

        }

        private void LblCustName_Click(object sender, EventArgs e)
        {

        }

        private void GVShowBills_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LblPhone_Click(object sender, EventArgs e)
        {

        }
        // client payment ....001001001011101
        private void GVShowCustmers_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            

                MessageBoxManager.Yes = " سداد من الاجل";
                MessageBoxManager.No = "تعديل بيانات ";
                MessageBoxManager.Register();

                DialogResult dialogResult = MessageBox.Show(" هل تريد عملية سداد للعميل ام تريد تعديل بيانات", "Creative Care Messages", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.GVShowBills.Hide();
                    this.GVShowCustmers.Hide();
                    this.GvShowHistory.Hide();
                    this.PanPay.BringToFront();
                    this.PanPay.Show();
                    MessageBoxManager.Unregister();

                }
                else if (dialogResult == DialogResult.No)
                {
                    if (this.LblPostion.Text == "2")
                    {
                        MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
                        MessageBoxManager.Unregister();
                    }
                    else
                    {
                        int rowindex = GVShowCustmers.SelectedCells[0].RowIndex;

                        DataGridViewRow Row = GVShowCustmers.Rows[rowindex];
                        //Row.Cells["CumID"].Value.ToString()
                        EditCuPr ED = new EditCuPr(int.Parse(Row.Cells["CumID"].Value.ToString()), 0,int.Parse(this.LblUserID.Text));
                        ED.Show();
                        MessageBoxManager.Unregister();
                    }
                }
            
        }

        private void BtnShowallzeft_Click(object sender, EventArgs e)
        {
            this.ShowAllMarda8ana();
        }

        private void PanPay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GvShowHistory_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int Rows = GvShowHistory.Rows.Count;
          

            double Bob = 0;
           

            for (int i = 0; i < GvShowHistory.Rows.Count; ++i)
            {
                Bob += double.Parse(GvShowHistory.Rows[i].Cells["RepayValue"].Value.ToString());
              
            }

            this.LblTotalpayedinsales.Text = Bob.ToString();
           

        }
    }
}

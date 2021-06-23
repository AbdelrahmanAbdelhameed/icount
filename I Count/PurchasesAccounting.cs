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
    public partial class PurchasesAccounting : Form
    {
       // SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        AccountingEntities context = new AccountingEntities();

        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public PurchasesAccounting(int ID)
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
        /////////////////////////////////////////////
        /// <summary>
        /// //////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //////////////// هنا بعرض اضافة مورد

        private void BtnAddProvider_Click(object sender, EventArgs e)
        {
            this.LblCompany.Show();
            this.LblDaen.Show();
            this.LblMadeen.Show();
            this.LblName.Show();
            this.LblPhone.Show();
            this.TxtCompany.Show();
            this.TxtCredit.Show();
            this.TxtDebit.Show();
            this.TxtName.Show();
            this.TxtTelephone.Show();
            this.BtnAddProvider.Hide();
            this.BtnAddProv.Show();
        }
        // // /////////////////////////////////////////
        private void ShowProvider()
        {

            this.BtnHistory.Show();
            this.LblNote.Show();
            this.GVShowProviders.Show();
            this.GVShowProviders.Rows.Clear();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProviders where ProviderID=@ProviderID   ";

            Cmd.Parameters.AddWithValue("@ProviderID", this.CBProviderName.SelectedValue);

            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();
            if (dr.Read())
            {
                this.GVShowProviders.Rows.Add(dr["ProviderName"].ToString(), dr["CompanyName"].ToString(), dr["Credit"].ToString(), dr["Debit"].ToString(), dr["TelephoneNumber"].ToString(), dr["ProviderID"].ToString());

            }
            dr.Close();
            Con.Close();
        
        }
        //////////////////////////////////////////////
        ///////show all providers 
        private void Sowallinopen()
        {
            this.BtnHistory.Show();
            this.LblNote.Show();
            this.GVShowProviders.Show();
            this.GVShowProviders.Rows.Clear();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProviders ";

            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();
            while (dr.Read())
            {
                this.GVShowProviders.Rows.Add(dr["ProviderName"].ToString(), dr["CompanyName"].ToString(), dr["Credit"].ToString(), dr["Debit"].ToString(), dr["TelephoneNumber"].ToString(), dr["ProviderID"].ToString());

            }
            dr.Close();
            Con.Close();
        }

        /// <summary>
        /// //////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHome_Click(object sender, EventArgs e)//////////////////////////Done
        {
            this.Close();
            Home HO = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            HO.Visible = true;
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
        private void PurchasesAccounting_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.LoadProviders();
            this.Sowallinopen();
            this.loadStorage();
        }
        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////// هون هانعمل اضافة مورد انا بقول ناخدها كوبى احسن 

        private void BtnAddProv_Click(object sender, EventArgs e)
        {
            try
            {


                if (this.TxtDebit.Text != null && this.TxtCredit.Text != null)
                {
                    SqlCommand Cmd = new SqlCommand();
                    Cmd.Connection = Con;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "InsertProvier";

                    Cmd.Parameters.AddWithValue("@ProviderName", this.TxtName.Text);
                    Cmd.Parameters.AddWithValue("@TelephoneNumber", this.TxtTelephone.Text);
                    Cmd.Parameters.AddWithValue("@CompanyName", this.TxtCompany.Text);
                    Cmd.Parameters.AddWithValue("@Credit", this.TxtCredit.Text);
                    Cmd.Parameters.AddWithValue("@Debit", this.TxtDebit.Text);

                    SqlParameter p1 = new SqlParameter();
                    p1.ParameterName = "@ProviderID";
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
                    MessageBox.Show("Done", "Creative Care");

                }
                else if (this.TxtDebit.Text != null && this.TxtCredit.Text == null)
                {
                    SqlCommand Cmd = new SqlCommand();
                    Cmd.Connection = Con;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "InsertProvier";

                    Cmd.Parameters.AddWithValue("@ProviderName", this.TxtName.Text);
                    Cmd.Parameters.AddWithValue("@TelephoneNumber", this.TxtTelephone.Text);
                    Cmd.Parameters.AddWithValue("@CompanyName", this.TxtCompany.Text);
                    Cmd.Parameters.AddWithValue("@Credit", 0);
                    Cmd.Parameters.AddWithValue("@Debit", this.TxtDebit.Text);

                    SqlParameter p1 = new SqlParameter();
                    p1.ParameterName = "@ProviderID";
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
                    MessageBox.Show("Done", "Creative Care");
                }
                else
                {
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
                    MessageBox.Show("Done", "Creative Care");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
            }
        }
        ///////////////////////////////////////////////////////////
        ////////////////////////////////هنا انا واخدهم كوبى من الصف التانيه 
        // بجيب اسماء الموردين 
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
            CBProviderName.DisplayMember = "ProviderName";
            CBProviderName.ValueMember = "ProviderID";
            CBProviderName.DataSource = ds.Tables["TblProviders"];
            CBProviderName.SelectedItem = null;

            CBProvNameEBill.DisplayMember = "ProviderName";
            CBProvNameEBill.ValueMember = "ProviderID";
            CBProvNameEBill.DataSource = ds.Tables["TblProviders"];
            CBProvNameEBill.SelectedItem = null;
            Con.Close();

        }
        ///////////////////////////////////////////////////////////////////////////////////


       
        ////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////// هنا بعرض اللى انا خافيه تانى :D
        // وكمان بيعرض ليا اسم النبى حرصه المورد والبيانات بتاعت امه 

        private void CBCustomerName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.ShowProvider();
            this.PanPay.Hide();///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            this.LblDate.Hide();
            this.GvShowHistory.Hide();
            this.LblFrom.Hide();
            this.LblTo.Hide();
            this.DTB1.Hide();
            this.DTB2.Hide();
            this.BtnShow.Hide();
            this.BtnShowAll.Hide();
            this.BtnBack.Hide();
            //
        }

        private void AddDebitProcess(int ProID , double TotalMoney )
        {
            TblRepayDebt Rde = new TblRepayDebt();
            Rde.PaiedDate = DateTime.Now;
            Rde.UserID = int.Parse(LblUserID.Text);
            Rde.ProviderID = ProID;
            Rde.TotalMoney = TotalMoney.ToString();
            Rde.StorageID = int.Parse(CBPayStorrage.SelectedValue.ToString());

            context.TblRepayDebts.Add(Rde);
            context.SaveChanges();

            var Oromg = context.TblProviders.Where(a => a.ProviderID == ProID).SingleOrDefault();

            double ExsitDebit =double.Parse(Oromg.Credit.ToString());

            double NewC = ExsitDebit - TotalMoney;

            Oromg.Credit = NewC.ToString();
            context.SaveChanges();


            TblProProc PP = new TblProProc();
            PP.ProDate = DateTime.Now;
            PP.PRocName = "سداد أجل";
            PP.ProPaied = TotalMoney.ToString();
            PP.ProviderID = ProID;
            context.TblProProcs.Add(PP);
            context.SaveChanges();


            TblStorageProce Spt = new TblStorageProce();
            Spt.SActionID = 6;
            Spt.SPDate = DateTime.Now;
            Spt.SPMoney = TotalMoney.ToString();
            Spt.StorageID = int.Parse(CBPayStorrage.SelectedValue.ToString());

            context.TblStorageProces.Add(Spt);
            context.SaveChanges();



            try
            {
                
               

                TblLog Log = new TblLog();
                Log.UserID = int.Parse(this.LblUserID.Text);
                Log.Discription = " سداد مبلغ   : " + TotalMoney.ToString() + "للمورد " + Oromg.ProviderName;
                Log.DateOfLog = DateTime.Now;

                context.TblLogs.Add(Log);
                context.SaveChanges();

            }
            catch (Exception)
            {


            }

            ///////////////////////////////////////////
            MessageBox.Show("تم بنجاح", "01118754055", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.TxtValue.Text = string.Empty;
            this.PanPay.Hide();
            this.CBPayStorrage.SelectedItem = null;
            this.GVShowProviders.Visible = true;
            ///////////////////////////////////
            this.LblNote.Show();
            this.GVShowProviders.Show();
            this.GVShowProviders.Rows.Clear();

            foreach (var item in context.TblProviders.ToList())
            {
                this.GVShowProviders.Rows.Add(item.ProviderName, item.CompanyName, item.Credit, item.Debit, item.TelephoneNumber, item.ProviderID);
            }
        }


        ///////////////////////////////////////////////////////////////////                  دلوقتى   انا هنا 
        // هنا علشان يسدد دين من اللى عليه 
        private void BtnPay_Click(object sender, EventArgs e)
        {
            //try
            //{

                int rowindex = GVShowProviders.SelectedCells[0].RowIndex;

                DataGridViewRow Row = GVShowProviders.Rows[rowindex];


                int ProvID = int.Parse(Row.Cells["ProvID"].Value.ToString());


            if (this.CBPayStorrage.SelectedItem == null || TxtValue.Text == "")
            {
                MessageBox.Show(" من فضلك اختار الخزنه والقيمه ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.CBPayStorrage.Focus();
            }
            else
            {

                if (this.CBPayStorrage.SelectedValue.ToString() != "3")
                {
                    int TearID = int.Parse(CBPayStorrage.SelectedValue.ToString());

                    var Treasure = context.TblStorages.Where(a => a.StorageID == TearID).FirstOrDefault();
                    double X = double.Parse(Treasure.TotalMoney.ToString());
                    double y = double.Parse(this.TxtValue.Text);
                    double W = X - y;


                    if (X < y)
                    {
                        MessageBox.Show("النقود الموجوده بالخزنه لا تكفى ل اتمام العمليه يمكك اختيار حساب خارجى او خزنه اخرى", "Creative Care");

                        this.CBPayStorrage.SelectedItem = null;
                        this.CBPayStorrage.Focus();
                        
                    }
                    else
                    {
                        Treasure.TotalMoney = W.ToString();
                        context.SaveChanges();
                        AddDebitProcess(ProvID, double.Parse(this.TxtValue.Text));
                    }

                }
                else
                {
                    AddDebitProcess(ProvID, double.Parse(this.TxtValue.Text));
                }
              
            }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
            //}
        }


        /////////////////////////////////////////////////////////////////

        private void GVShowProviders_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBoxManager.Yes = " سداد من الاجل";
            MessageBoxManager.No = "تعديل بيانات ";
            MessageBoxManager.Register();

            DialogResult dialogResult = MessageBox.Show(" هل تريد عملية سداد للعميل ام تريد تعديل بيانات", "Creative Care Messages", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.PanPay.Show();////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                this.PanPay.BringToFront();
                this.GVShowProviders.Hide();
                this.GvShowHistory.Hide();
                this.GVShowBills.Hide();
                this.LblNote.Hide();
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
                    int rowindex = GVShowProviders.SelectedCells[0].RowIndex;

                    DataGridViewRow Row = GVShowProviders.Rows[rowindex];
                    //Row.Cells["CumID"].Value.ToString()
                    EditCuPr ED = new EditCuPr(0, int.Parse(Row.Cells["ProvID"].Value.ToString()),int.Parse(this.LblUserID.Text));
                    ED.Show();
                    MessageBoxManager.Unregister();
                }

            }
            
            
        }
        ////////////////////////////////////////////////////////
        /////////////////////////// بيظهر البحت عن تاريخ سداد والسداد القديم 

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            if (this.CBProviderName.SelectedItem == null)
            {
                MessageBox.Show("من فضلك اختار اسم المورد", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                this.BtnShow.Show();
                this.BtnShowAll.Show();
                this.LblFrom.Show();
                this.LblTo.Show();
                this.DTB1.Show();
                this.DTB2.Show();
                this.LblDate.Show();
                this.GVShowBills.Hide();
                this.GvShowHistory.Hide();
                this.GVShowProviders.Hide();
                this.PanPay.Hide();
                LblTotalpayedinsales.Show();
                LblTotalpayedinsales.Text = "";
            }


        }
        //////////////////////////////////////////////////////
        /////////////// هنا بقى انا بعمل بحث  عن تاريخ سداد بتاريخ معين 

        private void BtnShow_Click(object sender, EventArgs e)
        {
            this.GVShowProviders.Hide();
            this.LblNote.Hide();
            this.GvShowHistory.Show();
            this.GvShowHistory.Rows.Clear();
            this.BtnBack.Show();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;

            Cmd.CommandText = "select * from ShowPurchasesRepay where ProviderID=@ProviderID and PaiedDate BETWEEN @from and  @to  ";

            //(month(PaiedDate) = month(@from)  AND month(PaiedDate) =month(@to)) and (Day(PaiedDate) >= Day(@from)  AND Day(PaiedDate) <=Day(@to))and (year(PaiedDate) = year(@from)  AND year(PaiedDate)=year(@to))";


            Cmd.Parameters.AddWithValue("@ProviderID", this.CBProviderName.SelectedValue);
            Cmd.Parameters.AddWithValue("@from", this.DTB1.Value.ToString("yyyy-MM-dd"));
            Cmd.Parameters.AddWithValue("@to", this.DTB2.Value.ToString("yyyy-MM-dd"));


            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();

            while (dr.Read())
            {
                this.GvShowHistory.Rows.Add(dr["ProviderName"].ToString(), dr["TotalMoney"].ToString(), dr["PaiedDate"].ToString(), dr["Name"].ToString());

            }
            dr.Close();
            Con.Close();

        }
        // هنا بقى علشان يرجع تانى 
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.GVShowProviders.Show();
            this.LblNote.Show();
            this.LblDate.Hide();
            this.GvShowHistory.Hide();
            this.LblFrom.Hide();
            this.LblTo.Hide();
            this.DTB1.Hide();
            this.DTB2.Hide();
            this.BtnShow.Hide();
        //    this.LblNote2.Hide();
            this.BtnShowAll.Hide();
            this.BtnBack.Hide();
            // this.LblNote3.Hide();
            LblTotalpayedinsales.Hide();
            LblTotalpayedinsales.Text = "";
        }
        // هنا بقى علشان يعمل عن كل عمليات السداد اللى تمت للمورد ده 
        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            this.GVShowProviders.Hide();
            this.LblNote.Hide();
            this.GvShowHistory.Show();
            this.BtnBack.Show();
            this.GvShowHistory.Rows.Clear();

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from ShowPurchasesRepay where ProviderID=@ProviderID    ";

            Cmd.Parameters.AddWithValue("@ProviderID", this.CBProviderName.SelectedValue);
           
            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();

           while(dr.Read())
            {
                this.GvShowHistory.Rows.Add(dr["ProviderName"].ToString(), dr["TotalMoney"].ToString(), dr["PaiedDate"].ToString(), dr["Name"].ToString());

            }
            dr.Close();
            Con.Close();
        }
        ////////////////////////////////////////
        /////////////////////// هنا اظهر واختفى بتاعت الفاتوره واسم المورد 

        private void CHProviderName_CheckedChanged(object sender, EventArgs e)
        {
            this.CHBills.Checked = false;
            this.LblCustName.Show();
            this.CBProviderName.Show();
            this.LblNote.Hide();
           // this.LblNote2.Hide();
            this.LblNote3.Hide();
            this.LblprovNameEBill.Hide();
            this.CBProvNameEBill.Hide();
            this.LblTo.Hide();
            this.LblFrom.Hide();
            this.LblDate.Hide();
            this.DTB1.Hide();
            this.DTB2.Hide();
            this.BtnSearch.Hide();
            this.BtnAllBills.Hide();
            this.GVShowBills.Hide();
            this.CBProviderName.SelectedItem = null;
            this.CBProvNameEBill.SelectedItem = null;
           

           
        }

        private void CHBills_CheckedChanged(object sender, EventArgs e)
        {
           // this.LblNote2.Hide();
            this.CHProviderName.Checked = false;
            this.LblNote.Hide();
            this.BtnHistory.Hide();
            this.CBProviderName.Hide();
            this.LblCustName.Hide();
            this.GvShowHistory.Hide();
            this.GVShowProviders.Hide();
            this.CBProvNameEBill.Show();
            this.LblprovNameEBill.Show();
            this.BtnShow.Hide();
            this.BtnShowAll.Hide();
            this.CBProviderName.SelectedItem = null;
            this.CBProvNameEBill.SelectedItem = null;
            this.GVShowBills.Hide();
            this.BtnBack.Hide();
            this.LblTo.Hide();
            this.LblFrom.Hide();
            this.LblDate.Hide();
            this.DTB1.Hide();
            this.DTB2.Hide();
            this.PanPay.Hide();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //// بحث ب الفاتوره والتاريخ
            this.LblNote3.Show();
            this.GVShowBills.Show();
            this.GVShowBills.Rows.Clear();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from VMBillsOfPurchases where ProviderID=@ProviderID and  DateOfBill BETWEEN @from and  @to";


            //(month(DateOfBill) = month(@from)  AND month(DateOfBill) =month(@to)) and (Day(DateOfBill) >= Day(@from)  AND Day(DateOfBill) <=Day(@to))and (year(DateOfBill) = year(@from)  AND year(DateOfBill)=year(@to))

            Cmd.Parameters.AddWithValue("@ProviderID", this.CBProvNameEBill.SelectedValue);
            Cmd.Parameters.AddWithValue("@from", this.DTB1.Value.ToString("yyyy-MM-dd"));
            Cmd.Parameters.AddWithValue("@to", this.DTB2.Value.ToString("yyyy-MM-dd"));


            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();

           while (dr.Read())
            {
                double X = double.Parse(dr["TotalPaid"].ToString());
                double V = double.Parse(dr["Paid"].ToString());
                double W = X - V;
                this.GVShowBills.Rows.Add(dr["ProviderName"].ToString(), dr["DateOfBill"].ToString(), dr["TotalPaid"].ToString(), dr["Paid"].ToString(), W, dr["BillID"].ToString());

            }
            dr.Close();
            Con.Close();
        }
        ///////////////////////////////////////////////////////////////////////
        //////////////////////////// هنا بيعرض كل الفواتير اللى اخدها منه 

        private void BtnAllBills_Click(object sender, EventArgs e)
        {
            this.LblNote3.Show();
            this.GVShowBills.Show();
            this.GVShowBills.Rows.Clear();

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from VMBillsOfPurchases where ProviderID=@ProviderID   ";

            Cmd.Parameters.AddWithValue("@ProviderID", this.CBProvNameEBill.SelectedValue);
            

            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();

           while (dr.Read())
            {
                double X = double.Parse(dr["TotalPaid"].ToString());
                double V = double.Parse(dr["Paid"].ToString());
                double W = X - V;
                this.GVShowBills.Rows.Add(dr["ProviderName"].ToString(), dr["DateOfBill"].ToString(), dr["TotalPaid"].ToString(), dr["Paid"].ToString(), W, dr["BillID"].ToString());

            }
            dr.Close();
            Con.Close();

        }

        private void CBProvNameEBill_SelectionChangeCommitted(object sender, EventArgs e)
        {
         //  this.LblNote2.Show();
            this.LblTo.Show();
            this.LblFrom.Show();
            this.LblDate.Show();
            this.DTB1.Show();
            this.DTB2.Show();
            this.BtnSearch.Show();
            this.BtnAllBills.Show();
        //    this.GVShowBills.Show();
        }

        private void GVShowBills_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = GVShowBills.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GVShowBills.Rows[rowindex];

            PurchasesBills SB = new PurchasesBills(int.Parse(Row.Cells["BillID"].Value.ToString()));
            SB.Show();
        }
        // / /// هنا KeyDown  بتاع ال عرض المورد
        private void CBProviderName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowProvider();
            }
        }

        private void CBProvNameEBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              //  this.LblNote2.Show();
                this.LblTo.Show();
                this.LblFrom.Show();
                this.LblDate.Show();
                this.DTB1.Show();
                this.DTB2.Show();
                this.BtnSearch.Show();
                this.BtnAllBills.Show();
            }
        }

        private void BtnAllZeft_Click(object sender, EventArgs e)
        {
            this.Sowallinopen();
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
        //////////////////////////////////////////////////////////////////////////////////////////////////
    }
}

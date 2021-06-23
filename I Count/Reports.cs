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
    public partial class Reports : Form
    {
        // SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public Reports(int ID )
        {
            InitializeComponent();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TblUsers where UserID=@UserID  ";

            cmd.Parameters.AddWithValue("@UserID", ID);

            SqlDataReader dr;
            Cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                this.LblUserID.Text = dr["UserID"].ToString();
                this.LblUserName.Text = dr["Name"].ToString();

            }

            dr.Close();
            Cnn.Close();
        }
        ////////////////////////////////////////////////////////////////////
        // //////////////////////////////
        // هنا بقى هاجيب احصائيات الخزن 
        private void loadStorges()
        {
            this.GVTrugers.Rows.Clear();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select t.StorageName , t.TotalMoney , s.StoreName  from TblStorages as t left outer join TblStore as s on t.StoreID = s.StoreID   ";


            SqlDataReader dr;
            Cnn.Open();
            dr = cmd.ExecuteReader();
           while (dr.Read())
            {
                // add to data grid view 
                GVTrugers.Rows.Add(dr["StorageName"].ToString(), dr["TotalMoney"].ToString(), dr["StoreName"].ToString());
            }
            dr.Close();
            Cnn.Close();
        }
        /// <summary>
        /// التانيه
        /// </summary>
        private void loadStorges2()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TblStorages where StorageID=2  ";


            SqlDataReader dr;
            Cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.LblMAinStaorage.Text = dr["TotalMoney"].ToString();
            }
            dr.Close();
            Cnn.Close();
        }
        // //////////////////////////////////////

        // ///////////////////////////////////////////////////////////////////
        // load daily report 
        private void LoadDailyReport()
        {
            // empty and be ready for data 
            // labels 
            this.LblMonyinBuyBills.Text = 0.ToString();
            this.LblTotalpayedinsales.Text = 0.ToString();
            this.LblTotalDebtPayed.Text = 0.ToString();
            this.LblCreaditPayed.Text = 0.ToString();
            this.LblBackInMoney.Text = 0.ToString();
            this.LblTotalEarn.Text = 0.ToString();
            this.LblBackoutValue.Text = 0.ToString();
            this.LblTotalExpenses.Text = 0.ToString();
            this.LblTotalIncom.Text = 0.ToString();
            this.LblFuckingEarn.Text = 0.ToString();
            this.LblFinel.Text = 0.ToString();
            this.LblCorrept.Text = 0.ToString();


            this.LblBackinBillsNU.Text = string.Empty;
            this.LblTotalBuybills.Text = string.Empty;
            this.LblSalesBillsnumber.Text = string.Empty;
            this.LblBackOutBillsNumber.Text = string.Empty;

            // graidviews
            this.GVBuying.Rows.Clear();
            this.GVSales.Rows.Clear();
            this.GVLateBuying.Rows.Clear();
            this.GVLateSales.Rows.Clear();
            this.GVBackin.Rows.Clear();
            this.GvBackout.Rows.Clear();
            this.GvExpenses.Rows.Clear();
            this.GvIncome.Rows.Clear();
            this.GvCorrupted.Rows.Clear();
/////////////////////////////////////////////////////////////////////////////////////////////
            // report of buying 
            SqlCommand Buy = new SqlCommand();
            Buy.Connection = Cnn;
            Buy.CommandType = CommandType.Text;
            Buy.CommandText = "select * from ReportBuying where  (day(DateOfBill)=day(@DateOfBill))  and (month(DateOfBill)=month(@DateOfBill)) and (year(DateOfBill)=year(@DateOfBill))";

            Buy.Parameters.AddWithValue("@DateOfBill", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader DR;
            Cnn.Open();
            DR = Buy.ExecuteReader();

            while (DR.Read())// لو لقى هايعرض 
            {

                this.GVBuying.Rows.Add(DR["BillID"].ToString(), DR["Paid"].ToString(), DR["ProviderName"].ToString(), DR["DateOfBill"].ToString(), DR["Name"].ToString(), DR["StoreName"].ToString());

            }

            DR.Close();
            Cnn.Close();

            ///////////////////////////////////////////////////////////////////////////////////
            // sales report 
            SqlCommand sales = new SqlCommand();
            sales.Connection = Cnn;
            sales.CommandType = CommandType.Text;
            sales.CommandText = "select * from Reportsales where  (day(BillDate)=day(@BillDate))  and (month(BillDate)=month(@BillDate)) and (year(BillDate)=year(@BillDate))";

            sales.Parameters.AddWithValue("@BillDate", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader SA;
            Cnn.Open();
            SA = sales.ExecuteReader();

            while (SA.Read())// لو لقى هايعرض 
            {

                this.GVSales.Rows.Add(SA["SaleBillID"].ToString(), SA["Paid"].ToString(), SA["CustomerName"].ToString(), SA["BillDate"].ToString(), SA["Earn"].ToString(), SA["Name"].ToString(), SA["StoreName"].ToString());

            }

            SA.Close();
            Cnn.Close();

            ////////////////////////////////////////////////////////////////////
            // report of late buying accounting 

            SqlCommand BUA = new SqlCommand();
            BUA.Connection = Cnn;
            BUA.CommandType = CommandType.Text;
            BUA.CommandText = "select * from Reportlatebuying where  (day(PaiedDate)=day(@PaiedDate))  and (month(PaiedDate)=month(@PaiedDate)) and (year(PaiedDate)=year(@PaiedDate))";

            BUA.Parameters.AddWithValue("@PaiedDate", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader BU;
            Cnn.Open();
            BU = BUA.ExecuteReader();

            while (BU.Read())// لو لقى هايعرض 
            {

                this.GVLateBuying.Rows.Add(BU["TotalMoney"].ToString(), BU["ProviderName"].ToString(), BU["PaiedDate"].ToString(), BU["Name"].ToString(), BU["StoreName"].ToString());

            }

            BU.Close();
            Cnn.Close();
            ///////////////////////////////////////////////////////
            // late sales paied

            SqlCommand LSa = new SqlCommand();
            LSa.Connection = Cnn;
            LSa.CommandType = CommandType.Text;
            LSa.CommandText = "select * from ReportlateSales where  (day(DateOfPay)=day(@DateOfPay))  and (month(DateOfPay)=month(@DateOfPay)) and (year(DateOfPay)=year(@DateOfPay))";

            LSa.Parameters.AddWithValue("@DateOfPay", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader LS;
            Cnn.Open();
            LS = LSa.ExecuteReader();

            while (LS.Read())// لو لقى هايعرض 
            {

                this.GVLateSales.Rows.Add(LS["TotalMoneyPaied"].ToString(), LS["CustomerName"].ToString(), LS["DateOfPay"].ToString(), LS["Name"].ToString(), LS["StoreName"].ToString());

            }

            LS.Close();
            Cnn.Close();
            /////////////////////////////////////////////////////////////
            // Back in bills 
            SqlCommand Backin = new SqlCommand();
            Backin.Connection = Cnn;
            Backin.CommandType = CommandType.Text;
            Backin.CommandText = "select * from ReportBackin where  (day(DateOfBackeIn)=day(@DateOfBackeIn)) and (month(DateOfBackeIn)=month(@DateOfBackeIn)) and (year(DateOfBackeIn)=year(@DateOfBackeIn))";

            Backin.Parameters.AddWithValue("@DateOfBackeIn", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader BI;
            Cnn.Open();
            BI = Backin.ExecuteReader();

            while (BI.Read())// لو لقى هايعرض 
            {

                this.GVBackin.Rows.Add(BI["BackInID"].ToString(), BI["TotalPaybake"].ToString(), BI["CustomerName"].ToString(), BI["DateOfBackeIn"].ToString(), BI["Name"].ToString(), BI["StoreName"].ToString());

            }

            BI.Close();
            Cnn.Close();
            //////////////////////////////////////////////////////////
            // back out bills 

            SqlCommand Backout = new SqlCommand();
            Backout.Connection = Cnn;
            Backout.CommandType = CommandType.Text;
            Backout.CommandText = "select * from ReportBackout where  (day(DateOfBackout)=day(@DateOfBackout))  and (month(DateOfBackout)=month(@DateOfBackout)) and (year(DateOfBackout)=year(@DateOfBackout))";

            Backout.Parameters.AddWithValue("@DateOfBackout", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader BO;
            Cnn.Open();
            BO = Backout.ExecuteReader();

            while (BO.Read())// لو لقى هايعرض 
            {

                this.GvBackout.Rows.Add(BO["BackoutID"].ToString(), BO["TotalMony"].ToString(), BO["ProviderName"].ToString(), BO["DateOfBackout"].ToString(), BO["Name"].ToString(), BO["StoreName"].ToString());

            }

            BO.Close();
            Cnn.Close();
            /////////////////////////////////////////////////////////
            // expenses 
            SqlCommand expenses = new SqlCommand();
            expenses.Connection = Cnn;
            expenses.CommandType = CommandType.Text;
            expenses.CommandText = "select * from ExpensesReport where (day(ExpensesDate)=day(@ExpensesDate)) and (month(ExpensesDate)=month(@ExpensesDate)) and (year(ExpensesDate)=year(@ExpensesDate))";

            expenses.Parameters.AddWithValue("@ExpensesDate", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader EX;
            Cnn.Open();
            EX = expenses.ExecuteReader();

            while (EX.Read())// لو لقى هايعرض 
            {

                this.GvExpenses.Rows.Add(EX["Money"].ToString());

            }

            EX.Close();
            Cnn.Close();
            //////////////////////////////////////////////////////////
            // income 
            SqlCommand income = new SqlCommand();
            income.Connection = Cnn;
            income.CommandType = CommandType.Text;
            income.CommandText = "select * from IncomeReport where (day(IncomeDate)=day(@IncomeDate)) and (month(IncomeDate)=month(@IncomeDate)) and (year(IncomeDate)=year(@IncomeDate))";

            income.Parameters.AddWithValue("@IncomeDate", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader IN;
            Cnn.Open();
            IN = income.ExecuteReader();

            while (IN.Read())// لو لقى هايعرض 
            {

                this.GvIncome.Rows.Add(IN["IncomeValue"].ToString());

            }

            IN.Close();
            Cnn.Close();
            ///////////////////////////////////////////////////////////
            //load corrept 
            SqlCommand Corrp = new SqlCommand();
            Corrp.Connection = Cnn;
            Corrp.CommandType = CommandType.Text;
            Corrp.CommandText = "select * from showCorreputed where  (day(DateOfbill)=day(@DateOfbill))  and (month(DateOfbill)=month(@DateOfbill)) and (year(DateOfbill)=year(@DateOfbill))";

            Corrp.Parameters.AddWithValue("@DateOfbill", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader Cor;
            Cnn.Open();
            Cor = Corrp.ExecuteReader();

            while (Cor.Read())// لو لقى هايعرض 
            {

                this.GvCorrupted.Rows.Add(Cor["CoMoney"].ToString());

            }

            Cor.Close();
            Cnn.Close();

            /////////////////////////////////////////////////////////
            // the last ruselt

            double buying = double.Parse(this.LblMonyinBuyBills.Text); //-....................
            double SalesTOT = double.Parse(this.LblTotalpayedinsales.Text); //.....
            double LateBuing = double.Parse(this.LblTotalDebtPayed.Text); // - 
            double LateSales = double.Parse(this.LblCreaditPayed.Text); // + 
            double lastExpenses = double.Parse(this.LblTotalExpenses.Text);//-
            double LastIncome = double.Parse(this.LblTotalIncom.Text);//+
            double Earn = double.Parse(this.LblTotalEarn.Text); // + 
            double corrpt = double.Parse(this.LblCorrept.Text);////////////--

            double w = LastIncome + Earn;
           
            double Finel = w - lastExpenses;
            double xx = Finel - corrpt;
            

            this.LblFuckingEarn.Text =w.ToString();

            this.LblFinel.Text = xx.ToString();


            /////////////////////////////////////////////////////////////////////
            // fucking show 

            this.LblShowNow.Text = "تقارير اليوم " + "\n" + DateTime.Now.ToShortDateString();

        }
        // //////////////////////////////////////////////////////////////////
        // وهنا انا بجيب المخزن 
        private void LoadStore()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStore ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStore");
            CBStore.DisplayMember = "StoreName";
            CBStore.ValueMember = "StoreID";
            CBStore.DataSource = ds.Tables["TblStore"];
            CBStore.SelectedItem = null;
            Cnn.Close();
        }
        /////////////  
        private void Reports_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.LoadDailyReport();
            this.loadStorges();
            this.loadStorges2();
            this.LoadStore();
        }

        private void Pichome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home Ho = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            Ho.Show();
        }

        private void GVBuying_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int Rows = GVBuying.Rows.Count;
            this.LblTotalBuybills.Text = Rows.ToString();

            double Bob = 0;
            for (int i = 0; i < GVBuying.Rows.Count; ++i)
            {
                Bob += double.Parse(GVBuying.Rows[i].Cells["BuyTotalPayed"].Value.ToString());
            }
            this.LblMonyinBuyBills.Text = Bob.ToString();  
        }

        private void GVBuying_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = GVBuying.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GVBuying.Rows[rowindex];

            PurchasesBills SB = new PurchasesBills(int.Parse(Row.Cells["BuyBillsNu"].Value.ToString()));
            SB.Show();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = GVSales.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GVSales.Rows[rowindex];

            SalesBills SB = new SalesBills(int.Parse(Row.Cells["SaleBillNu"].Value.ToString()));
            SB.Show();
        }

        private void GVSales_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int Rows = GVSales.Rows.Count;
            this.LblSalesBillsnumber.Text = Rows.ToString();

            double Bob = 0;
            double Earno = 0;

            for (int i = 0; i < GVSales.Rows.Count; ++i)
            {
                Bob += double.Parse(GVSales.Rows[i].Cells["SalesTotal"].Value.ToString());
              Earno += double.Parse(GVSales.Rows[i].Cells["EarninBill"].Value.ToString());
            }

            this.LblTotalpayedinsales.Text = Bob.ToString();
            this.LblTotalEarn.Text = Earno.ToString();

        }

        private void GVLateBuying_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
            double Bob = 0;
            for (int i = 0; i < GVLateBuying.Rows.Count; ++i)
            {
                Bob += double.Parse(GVLateBuying.Rows[i].Cells["DebtTotal"].Value.ToString());
            }
            this.LblTotalDebtPayed.Text = Bob.ToString();  
        }

        private void GVLateSales_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            double Bob = 0;
            for (int i = 0; i < GVLateSales.Rows.Count; ++i)
            {
                Bob += double.Parse(GVLateSales.Rows[i].Cells["CridetMony"].Value.ToString());
            }
            this.LblCreaditPayed.Text = Bob.ToString();  
        }

        private void GVBackin_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int Rows = GVBackin.Rows.Count;
            this.LblBackinBillsNU.Text = Rows.ToString();

            double Bob = 0;
            for (int i = 0; i < GVBackin.Rows.Count; ++i)
            {
                Bob += double.Parse(GVBackin.Rows[i].Cells["BackinMony"].Value.ToString());
            }
            this.LblBackInMoney.Text = Bob.ToString(); 
        }

        private void GvBackout_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int Rows = GvBackout.Rows.Count;
            this.LblBackOutBillsNumber.Text = Rows.ToString();

            double Bob = 0;
            for (int i = 0; i < GvBackout.Rows.Count; ++i)
            {
                Bob += double.Parse(GvBackout.Rows[i].Cells["BackoutMoney"].Value.ToString());
            }
            this.LblBackoutValue.Text = Bob.ToString(); 
        }

        private void GvExpenses_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double Bob = 0;
            for (int i = 0; i < GvExpenses.Rows.Count; ++i)
            {
                Bob += double.Parse(GvExpenses.Rows[i].Cells["Expenses"].Value.ToString());
            }
            this.LblTotalExpenses.Text = Bob.ToString(); 
        }

        private void GvIncome_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double Bob = 0;
            for (int i = 0; i < GvIncome.Rows.Count; ++i)
            {
                Bob += double.Parse(GvIncome.Rows[i].Cells["InCome"].Value.ToString());
            }
            this.LblTotalIncom.Text = Bob.ToString();
        }

        private void BtnDay_Click(object sender, EventArgs e)
        {
            this.LoadDailyReport();
        }

        private void BtnMonth_Click(object sender, EventArgs e)
        {

            if (this.CBStore.SelectedItem==null)
            {
                MessageBox.Show("من فضلك اختار الفرع اولاً", "Creative Care");
            }
            else
            {

            // empty and be ready for data 
            // labels 
            this.LblMonyinBuyBills.Text = 0.ToString();
            this.LblTotalpayedinsales.Text = 0.ToString();
            this.LblTotalDebtPayed.Text = 0.ToString();
            this.LblCreaditPayed.Text = 0.ToString();
            this.LblBackInMoney.Text = 0.ToString();
            this.LblTotalEarn.Text = 0.ToString();
            this.LblBackoutValue.Text = 0.ToString();
            this.LblTotalExpenses.Text = 0.ToString();
            this.LblTotalIncom.Text = 0.ToString();
            this.LblFuckingEarn.Text = 0.ToString();
            this.LblFinel.Text = 0.ToString();
            this.LblCorrept.Text = 0.ToString();



            this.LblBackinBillsNU.Text = string.Empty;
            this.LblTotalBuybills.Text = string.Empty;
            this.LblSalesBillsnumber.Text = string.Empty;
            this.LblBackOutBillsNumber.Text = string.Empty;

            // graidviews
            this.GVBuying.Rows.Clear();
            this.GVSales.Rows.Clear();
            this.GVLateBuying.Rows.Clear();
            this.GVLateSales.Rows.Clear();
            this.GVBackin.Rows.Clear();
            this.GvBackout.Rows.Clear();
            this.GvExpenses.Rows.Clear();
            this.GvIncome.Rows.Clear();
            this.GvCorrupted.Rows.Clear();
            /////////////////////////////////////////////////////////////////////////////////////////////
            // report of buying 
            SqlCommand Buy = new SqlCommand();
            Buy.Connection = Cnn;
            Buy.CommandType = CommandType.Text;
            Buy.CommandText = "select * from ReportBuying where (month(DateOfBill)=month(@DateOfBill)) and (year(DateOfBill)=year(@DateOfBill)) and StoreID=@StoreID";

            Buy.Parameters.AddWithValue("@DateOfBill", DateTime.Now.ToString("yyyy-MM-dd"));
            Buy.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader DR;
            Cnn.Open();
            DR = Buy.ExecuteReader();

            while (DR.Read())// لو لقى هايعرض 
            {

                this.GVBuying.Rows.Add(DR["BillID"].ToString(), DR["Paid"].ToString(), DR["ProviderName"].ToString(), DR["DateOfBill"].ToString(), DR["Name"].ToString(), DR["StoreName"].ToString());

            }


            DR.Close();
            Cnn.Close();

            ///////////////////////////////////////////////////////////////////////////////////
            // sales report 
            SqlCommand sales = new SqlCommand();
            sales.Connection = Cnn;
            sales.CommandType = CommandType.Text;
            sales.CommandText = "select * from Reportsales where (month(BillDate)=month(@BillDate)) and (year(BillDate)=year(@BillDate)) and StoreID=@StoreID";

            sales.Parameters.AddWithValue("@BillDate", DateTime.Now.ToString("yyyy-MM-dd"));
            sales.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader SA;
            Cnn.Open();
            SA = sales.ExecuteReader();

            while (SA.Read())// لو لقى هايعرض 
            {

                this.GVSales.Rows.Add(SA["SaleBillID"].ToString(), SA["Paid"].ToString(), SA["CustomerName"].ToString(), SA["BillDate"].ToString(), SA["Earn"].ToString(), SA["Name"].ToString(), SA["StoreName"].ToString());

            }

            SA.Close();
            Cnn.Close();

            ////////////////////////////////////////////////////////////////////
            // report of late buying accounting 

            SqlCommand BUA = new SqlCommand();
            BUA.Connection = Cnn;
            BUA.CommandType = CommandType.Text;
            BUA.CommandText = "select * from Reportlatebuying where (month(PaiedDate)=month(@PaiedDate)) and (year(PaiedDate)=year(@PaiedDate)) and StoreID=@StoreID";

            BUA.Parameters.AddWithValue("@PaiedDate", DateTime.Now.ToString("yyyy-MM-dd"));
            BUA.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader BU;
            Cnn.Open();
            BU = BUA.ExecuteReader();

            while (BU.Read())// لو لقى هايعرض 
            {

                this.GVLateBuying.Rows.Add(BU["TotalMoney"].ToString(), BU["ProviderName"].ToString(), BU["PaiedDate"].ToString(), BU["Name"].ToString(), BU["StoreName"].ToString());

            }

            BU.Close();
            Cnn.Close();
            ///////////////////////////////////////////////////////
            // late sales paied

            SqlCommand LSa = new SqlCommand();
            LSa.Connection = Cnn;
            LSa.CommandType = CommandType.Text;
            LSa.CommandText = "select * from ReportlateSales where  (month(DateOfPay)=month(@DateOfPay)) and (year(DateOfPay)=year(@DateOfPay)) and StoreID=@StoreID";

            LSa.Parameters.AddWithValue("@DateOfPay", DateTime.Now.ToString("yyyy-MM-dd"));
            LSa.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader LS;
            Cnn.Open();
            LS = LSa.ExecuteReader();

            while (LS.Read())// لو لقى هايعرض 
            {

                this.GVLateSales.Rows.Add(LS["TotalMoneyPaied"].ToString(), LS["CustomerName"].ToString(), LS["DateOfPay"].ToString(), LS["Name"].ToString(), LS["StoreName"].ToString());

            }

            LS.Close();
            Cnn.Close();
            /////////////////////////////////////////////////////////////
            // Back in bills 
            SqlCommand Backin = new SqlCommand();
            Backin.Connection = Cnn;
            Backin.CommandType = CommandType.Text;
            Backin.CommandText = "select * from ReportBackin where (month(DateOfBackeIn)=month(@DateOfBackeIn)) and (year(DateOfBackeIn)=year(@DateOfBackeIn)) and StoreID=@StoreID";

            Backin.Parameters.AddWithValue("@DateOfBackeIn", DateTime.Now.ToString("yyyy-MM-dd"));
            Backin.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader BI;
            Cnn.Open();
            BI = Backin.ExecuteReader();

            while (BI.Read())// لو لقى هايعرض 
            {

                this.GVBackin.Rows.Add(BI["BackInID"].ToString(), BI["TotalPaybake"].ToString(), BI["CustomerName"].ToString(), BI["DateOfBackeIn"].ToString(), BI["Name"].ToString(), BI["StoreName"].ToString());

            }

            BI.Close();
            Cnn.Close();
            //////////////////////////////////////////////////////////
            // back out bills 

            SqlCommand Backout = new SqlCommand();
            Backout.Connection = Cnn;
            Backout.CommandType = CommandType.Text;
            Backout.CommandText = "select * from ReportBackout where  (month(DateOfBackout)=month(@DateOfBackout)) and (year(DateOfBackout)=year(@DateOfBackout)) and StoreID=@StoreID";

            Backout.Parameters.AddWithValue("@DateOfBackout", DateTime.Now.ToString("yyyy-MM-dd"));
            Backout.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader BO;
            Cnn.Open();
            BO = Backout.ExecuteReader();

            while (BO.Read())// لو لقى هايعرض 
            {

                this.GvBackout.Rows.Add(BO["BackoutID"].ToString(), BO["TotalMony"].ToString(), BO["ProviderName"].ToString(), BO["DateOfBackout"].ToString(), BO["Name"].ToString(), BO["StoreName"].ToString());

            }

            BO.Close();
            Cnn.Close();
            /////////////////////////////////////////////////////////
            // expenses 
            SqlCommand expenses = new SqlCommand();
            expenses.Connection = Cnn;
            expenses.CommandType = CommandType.Text;
            expenses.CommandText = "select * from ExpensesReport where   (month(ExpensesDate)=month(@ExpensesDate)) and (year(ExpensesDate)=year(@ExpensesDate)) and StoreID=@StoreID";

            expenses.Parameters.AddWithValue("@ExpensesDate", DateTime.Now.ToString("yyyy-MM-dd"));
            expenses.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader EX;
            Cnn.Open();
            EX = expenses.ExecuteReader();

            while (EX.Read())// لو لقى هايعرض 
            {

                this.GvExpenses.Rows.Add(EX["Money"].ToString());

            }

            EX.Close();
            Cnn.Close();
            //////////////////////////////////////////////////////////
            // income 
            SqlCommand income = new SqlCommand();
            income.Connection = Cnn;
            income.CommandType = CommandType.Text;
            income.CommandText = "select * from IncomeReport where (month(IncomeDate)=month(@IncomeDate)) and (year(IncomeDate)=year(@IncomeDate)) and StoreID=@StoreID";

            income.Parameters.AddWithValue("@IncomeDate", DateTime.Now.ToString("yyyy-MM-dd"));
            income.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader IN;
            Cnn.Open();
            IN = income.ExecuteReader();

            while (IN.Read())// لو لقى هايعرض 
            {

                this.GvIncome.Rows.Add(IN["IncomeValue"].ToString());

            }

            IN.Close();
            Cnn.Close();

            /////////////////////////////////////////////////////////
            //load corrept 
            SqlCommand Corrp = new SqlCommand();
            Corrp.Connection = Cnn;
            Corrp.CommandType = CommandType.Text;
            Corrp.CommandText = "select * from showCorreputed where  (month(DateOfbill)=month(@DateOfbill)) and (year(DateOfbill)=year(@DateOfbill)) and StoreID=@StoreID";

            Corrp.Parameters.AddWithValue("@DateOfbill", DateTime.Now.ToString("yyyy-MM-dd"));
            Corrp.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader Cor;
            Cnn.Open();
            Cor = Corrp.ExecuteReader();

            while (Cor.Read())// لو لقى هايعرض 
            {

                this.GvCorrupted.Rows.Add(Cor["CoMoney"].ToString());

            }

            Cor.Close();
            Cnn.Close();
            //////////////////////////////////////////////////////////
            // the last ruselt

            double buying = double.Parse(this.LblMonyinBuyBills.Text); //-....................
            double SalesTOT = double.Parse(this.LblTotalpayedinsales.Text); //.....
            double LateBuing = double.Parse(this.LblTotalDebtPayed.Text); // - 
            double LateSales = double.Parse(this.LblCreaditPayed.Text); // + 
            double lastExpenses = double.Parse(this.LblTotalExpenses.Text);//-
            double LastIncome = double.Parse(this.LblTotalIncom.Text);//+
            double Earn = double.Parse(this.LblTotalEarn.Text); // + 
            double corrpt = double.Parse(this.LblCorrept.Text);////////////--

            double w = LastIncome + Earn;

            double Finel = w - lastExpenses;
            double xx = Finel - corrpt;


            this.LblFuckingEarn.Text = w.ToString();

            this.LblFinel.Text = xx.ToString();
           
            /////////////////////////////////////////////////////////////////////
            // fucking show 
            this.LblShowNow.Text = "تقارير الشهر " + "\n" + DateTime.Now.ToShortDateString();

            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (this.CBStore.SelectedItem == null)
            {
                MessageBox.Show("من فضلك اختار الفرع اولاً", "Creative Care");

            }
            else
            {

            // empty and be ready for data 
            // labels 
            this.LblMonyinBuyBills.Text = 0.ToString();
            this.LblTotalpayedinsales.Text = 0.ToString();
            this.LblTotalDebtPayed.Text = 0.ToString();
            this.LblCreaditPayed.Text = 0.ToString();
            this.LblBackInMoney.Text = 0.ToString();
            this.LblTotalEarn.Text = 0.ToString();
            this.LblBackoutValue.Text = 0.ToString();
            this.LblTotalExpenses.Text = 0.ToString();
            this.LblTotalIncom.Text = 0.ToString();
            this.LblFuckingEarn.Text = 0.ToString();
            this.LblFinel.Text = 0.ToString();
            this.LblCorrept.Text = 0.ToString();



            this.LblBackinBillsNU.Text = string.Empty;
            this.LblTotalBuybills.Text = string.Empty;
            this.LblSalesBillsnumber.Text = string.Empty;
            this.LblBackOutBillsNumber.Text = string.Empty;

            // graidviews
            this.GVBuying.Rows.Clear();
            this.GVSales.Rows.Clear();
            this.GVLateBuying.Rows.Clear();
            this.GVLateSales.Rows.Clear();
            this.GVBackin.Rows.Clear();
            this.GvBackout.Rows.Clear();
            this.GvExpenses.Rows.Clear();
            this.GvIncome.Rows.Clear();
            this.GvCorrupted.Rows.Clear();
            /////////////////////////////////////////////////////////////////////////////////////////////
            // report of buying 
            SqlCommand Buy = new SqlCommand();
            Buy.Connection = Cnn;
            Buy.CommandType = CommandType.Text;
            Buy.CommandText = "select * from ReportBuying where ( DateOfBill BETWEEN @DateOfBill and  @DateOfBillTO) and StoreID=@StoreID ";

            //(day(DateOfBill)>=day(@DateOfBill)  and day(DateOfBill)<=day(@DateOfBillTO)) and (month(DateOfBill)>=month(@DateOfBill)  and month(DateOfBill)<=month(@DateOfBillTO)) and (year(DateOfBill)>=year(@DateOfBill) and year(DateOfBill)<=year(@DateOfBillTO))
            Buy.Parameters.AddWithValue("@DateOfBill", this.DTFrom.Value.ToString("yyyy-MM-dd"));
            Buy.Parameters.AddWithValue("@DateOfBillTO", this.DtTO.Value.ToString("yyyy-MM-dd"));
            Buy.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader DR;
            Cnn.Open();
            DR = Buy.ExecuteReader();

            while (DR.Read())// لو لقى هايعرض 
            {


                this.GVBuying.Rows.Add(DR["BillID"].ToString(), DR["Paid"].ToString(), DR["ProviderName"].ToString(), DR["DateOfBill"].ToString(), DR["Name"].ToString(), DR["StoreName"].ToString());

            }

            DR.Close();
            Cnn.Close();

            ///////////////////////////////////////////////////////////////////////////////////
            // sales report 
            SqlCommand sales = new SqlCommand();
            sales.Connection = Cnn;
            sales.CommandType = CommandType.Text;
            sales.CommandText = "select * from Reportsales where (BillDate  BETWEEN @BillDate and  @BillDateTO) and StoreID=@StoreID ";

            //(day(BillDate)>=day(@BillDate)  and day(BillDate)<=day(@BillDateTO)) and (month(BillDate)>=month(@BillDate)  and month(BillDate)<=month(@BillDateTO)) and (year(BillDate)>=year(@BillDate) and year(BillDate)<=year(@BillDateTO))

            sales.Parameters.AddWithValue("@BillDate", this.DTFrom.Value.ToString("yyyy-MM-dd"));
            sales.Parameters.AddWithValue("@BillDateTO", this.DtTO.Value.ToString("yyyy-MM-dd"));
            sales.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader SA;
            Cnn.Open();
            SA = sales.ExecuteReader();

            while (SA.Read())// لو لقى هايعرض 
            {

                this.GVSales.Rows.Add(SA["SaleBillID"].ToString(), SA["Paid"].ToString(), SA["CustomerName"].ToString(), SA["BillDate"].ToString(), SA["Earn"].ToString(), SA["Name"].ToString(), SA["StoreName"].ToString());

            }

            SA.Close();
            Cnn.Close();

            ////////////////////////////////////////////////////////////////////
            // report of late buying accounting 

            SqlCommand BUA = new SqlCommand();
            BUA.Connection = Cnn;
            BUA.CommandType = CommandType.Text;
            BUA.CommandText = "select * from Reportlatebuying where (PaiedDate BETWEEN @PaiedDate and  @PaiedDateTo ) and StoreID=@StoreID ";

            //(day(PaiedDate)>=day(@PaiedDate)  and day(PaiedDate)<=day(@PaiedDateTo)) and (month(PaiedDate)>=month(@PaiedDate)  and month(PaiedDate)<=month(@PaiedDateTo)) and (year(PaiedDate)>=year(@PaiedDate) and year(PaiedDate)<=year(@PaiedDateTo))

            BUA.Parameters.AddWithValue("@PaiedDate", this.DTFrom.Value.ToString("yyyy-MM-dd"));
            BUA.Parameters.AddWithValue("@PaiedDateTo", this.DtTO.Value.ToString("yyyy-MM-dd"));
            BUA.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader BU;
            Cnn.Open();
            BU = BUA.ExecuteReader();

            while (BU.Read())// لو لقى هايعرض 
            {

                this.GVLateBuying.Rows.Add(BU["TotalMoney"].ToString(), BU["ProviderName"].ToString(), BU["PaiedDate"].ToString(), BU["Name"].ToString(), BU["StoreName"].ToString());

            }

            BU.Close();
            Cnn.Close();
            ///////////////////////////////////////////////////////
            // late sales paied

            SqlCommand LSa = new SqlCommand();
            LSa.Connection = Cnn;
            LSa.CommandType = CommandType.Text;
            LSa.CommandText = "select * from ReportlateSales where ( DateOfPay BETWEEN @DateOfPay and  @DateOfPayTo) and StoreID=@StoreID ";

            //(day(DateOfPay)>=day(@DateOfPay)  and day(DateOfPay)<=day(@DateOfPayTo)) and (month(DateOfPay)>=month(@DateOfPay)  and month(DateOfPay)<=month(@DateOfPayTo)) and (year(DateOfPay)>=year(@DateOfPay) and year(DateOfPay)<=year(@DateOfPayTo))

            LSa.Parameters.AddWithValue("@DateOfPay", this.DTFrom.Value.ToString("yyyy-MM-dd"));
            LSa.Parameters.AddWithValue("@DateOfPayTo", this.DtTO.Value.ToString("yyyy-MM-dd"));
            LSa.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader LS;
            Cnn.Open();
            LS = LSa.ExecuteReader();

            while (LS.Read())// لو لقى هايعرض 
            {

                this.GVLateSales.Rows.Add(LS["TotalMoneyPaied"].ToString(), LS["CustomerName"].ToString(), LS["DateOfPay"].ToString(), LS["Name"].ToString(), LS["StoreName"].ToString());

            }

            LS.Close();
            Cnn.Close();
            /////////////////////////////////////////////////////////////
            // Back in bills 
            SqlCommand Backin = new SqlCommand();
            Backin.Connection = Cnn;
            Backin.CommandType = CommandType.Text;
            Backin.CommandText = "select * from ReportBackin where (DateOfBackeIn BETWEEN @DateOfBackeIn and  @DateOfBackeInTo ) and StoreID=@StoreID ";

            // (day(DateOfBackeIn)>=day(@DateOfBackeIn)  and day(DateOfBackeIn)<=day(@DateOfBackeInTo)) and (month(DateOfBackeIn)>=month(@DateOfBackeIn)  and month(DateOfBackeIn)<=month(@DateOfBackeInTo)) and (year(DateOfBackeIn)>=year(@DateOfBackeIn) and year(DateOfBackeIn)<=year(@DateOfBackeInTo))

            Backin.Parameters.AddWithValue("@DateOfBackeIn", this.DTFrom.Value.ToString("yyyy-MM-dd"));
            Backin.Parameters.AddWithValue("@DateOfBackeInTo", this.DtTO.Value.ToString("yyyy-MM-dd"));
            Backin.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader BI;
            Cnn.Open();
            BI = Backin.ExecuteReader();

            while (BI.Read())// لو لقى هايعرض 
            {

                this.GVBackin.Rows.Add(BI["BackInID"].ToString(), BI["TotalPaybake"].ToString(), BI["CustomerName"].ToString(), BI["DateOfBackeIn"].ToString(), BI["Name"].ToString(), BI["StoreName"].ToString());

            }

            BI.Close();
            Cnn.Close();
            //////////////////////////////////////////////////////////
            // back out bills 

            SqlCommand Backout = new SqlCommand();
            Backout.Connection = Cnn;
            Backout.CommandType = CommandType.Text;
            Backout.CommandText = "select * from ReportBackout where (DateOfBackout BETWEEN @DateOfBackout and  @DateOfBackoutTo) and StoreID=@StoreID ";

            //(day(DateOfBackout)>=day(@DateOfBackout)  and day(DateOfBackout)<=day(@DateOfBackoutTo)) and (month(DateOfBackout)>=month(@DateOfBackout)  and month(DateOfBackout)<=month(@DateOfBackoutTo)) and (year(DateOfBackout)>=year(@DateOfBackout) and year(DateOfBackout)<=year(@DateOfBackoutTo))

            Backout.Parameters.AddWithValue("@DateOfBackout", this.DTFrom.Value.ToString("yyyy-MM-dd"));
            Backout.Parameters.AddWithValue("@DateOfBackoutTo", this.DtTO.Value.ToString("yyyy-MM-dd"));
            Backout.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader BO;
            Cnn.Open();
            BO = Backout.ExecuteReader();

            while (BO.Read())// لو لقى هايعرض 
            {

                this.GvBackout.Rows.Add(BO["BackoutID"].ToString(), BO["TotalMony"].ToString(), BO["ProviderName"].ToString(), BO["DateOfBackout"].ToString(), BO["Name"].ToString(), BO["StoreName"].ToString());

            }

            BO.Close();
            Cnn.Close();
            /////////////////////////////////////////////////////////
            // expenses 
            SqlCommand expenses = new SqlCommand();
            expenses.Connection = Cnn;
            expenses.CommandType = CommandType.Text;
            expenses.CommandText = "select * from ExpensesReport where ( ExpensesDate BETWEEN @ExpensesDate and  @ExpensesDateTO) and StoreID=@StoreID ";

            //(day(ExpensesDate)>=day(@ExpensesDate)  and day(ExpensesDate)<=day(@ExpensesDateTO)) and (month(ExpensesDate)>=month(@ExpensesDate)  and month(ExpensesDate)<=month(@ExpensesDateTO)) and (year(ExpensesDate)>=year(@ExpensesDate) and year(ExpensesDate)<=year(@ExpensesDateTO))

            expenses.Parameters.AddWithValue("@ExpensesDate", this.DTFrom.Value.ToString("yyyy-MM-dd"));
            expenses.Parameters.AddWithValue("@ExpensesDateTO", this.DtTO.Value.ToString("yyyy-MM-dd"));
            expenses.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader EX;
            Cnn.Open();
            EX = expenses.ExecuteReader();

            while (EX.Read())// لو لقى هايعرض 
            {

                this.GvExpenses.Rows.Add(EX["Money"].ToString());

            }

            EX.Close();
            Cnn.Close();
            //////////////////////////////////////////////////////////
            // income 
            SqlCommand income = new SqlCommand();
            income.Connection = Cnn;
            income.CommandType = CommandType.Text;
            income.CommandText = "select * from IncomeReport where (IncomeDate BETWEEN @IncomeDate and  @IncomeDateTo ) and StoreID=@StoreID ";

            //(day(IncomeDate)>=day(@IncomeDate)  and day(IncomeDate)<=day(@IncomeDateTo)) and (month(IncomeDate)>=month(@IncomeDate)  and month(IncomeDate)<=month(@IncomeDateTo)) and (year(IncomeDate)>=year(@IncomeDate) and year(IncomeDate)<=year(@IncomeDateTo))

            income.Parameters.AddWithValue("@IncomeDate", this.DTFrom.Value.ToString("yyyy-MM-dd"));
            income.Parameters.AddWithValue("@IncomeDateTo", this.DtTO.Value.ToString("yyyy-MM-dd"));
            income.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader IN;
            Cnn.Open();
            IN = income.ExecuteReader();

            while (IN.Read())// لو لقى هايعرض 
            {

                this.GvIncome.Rows.Add(IN["IncomeValue"].ToString());

            }

            IN.Close();
            Cnn.Close();
            /////////////////////////////////////////////////////////
            //load corrept 
            SqlCommand Corrp = new SqlCommand();
            Corrp.Connection = Cnn;
            Corrp.CommandType = CommandType.Text;
            Corrp.CommandText = "select * from showCorreputed where  (DateOfbill BETWEEN @DateOfbill and  @DateOfbillTO) and StoreID=@StoreID ";

            Corrp.Parameters.AddWithValue("@DateOfbill", this.DTFrom.Value.ToString("yyyy-MM-dd"));
            Corrp.Parameters.AddWithValue("@DateOfbillTO", this.DtTO.Value.ToString("yyyy-MM-dd"));
            Corrp.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader Cor;
            Cnn.Open();
            Cor = Corrp.ExecuteReader();

            while (Cor.Read())// لو لقى هايعرض 
            {

                this.GvCorrupted.Rows.Add(Cor["CoMoney"].ToString());

            }

            Cor.Close();
            Cnn.Close();




            /////////////////////////////////////////////////////////
            // the last ruselt

            double buying = double.Parse(this.LblMonyinBuyBills.Text); //-....................
            double SalesTOT = double.Parse(this.LblTotalpayedinsales.Text); //.....
            double LateBuing = double.Parse(this.LblTotalDebtPayed.Text); // - 
            double LateSales = double.Parse(this.LblCreaditPayed.Text); // + 
            double lastExpenses = double.Parse(this.LblTotalExpenses.Text);//-
            double LastIncome = double.Parse(this.LblTotalIncom.Text);//+
            double Earn = double.Parse(this.LblTotalEarn.Text); // + 

            double corrpt = double.Parse(this.LblCorrept.Text);////////////--

            double w = LastIncome + Earn;

            double Finel = w - lastExpenses;
            double xx = Finel - corrpt;


            this.LblFuckingEarn.Text = w.ToString();

            this.LblFinel.Text = xx.ToString();
           

            /////////////////////////////////////////////////////////////////////
            // fucking show 
            this.LblShowNow.Text = "تقارير من " + "\n" + this.DTFrom.Value.ToShortDateString() + "\n" + "الى" + "\n" + this.DtTO.Value.ToShortDateString();

            }
        }

        private void BtnReportExpenses_Click(object sender, EventArgs e)
        {
            ReportExpenses RE = new ReportExpenses();
            RE.Show();
        }

        private void BtnReportIncome_Click(object sender, EventArgs e)
        {
            ReportIncome RI = new ReportIncome();
            RI.Show();
        }

        private void GVBackin_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = GVBackin.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GVBackin.Rows[rowindex];

            BackinBills SB = new BackinBills(int.Parse(Row.Cells["BackinBillNu"].Value.ToString()));
            SB.Show();
        }

        private void GvBackout_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = GvBackout.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GvBackout.Rows[rowindex];

            Backoutbills SB = new Backoutbills(int.Parse(Row.Cells["BackOutBill"].Value.ToString()));
            SB.Show();
        }

        private void BtnShifts_Click(object sender, EventArgs e)
        {
            ReportCorreputed RE = new ReportCorreputed();
            RE.Show();
        }

        private void BtnStoreRe_Click(object sender, EventArgs e)
        {
            ConvertingReport CR = new ConvertingReport();
            CR.Show();
        }

        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            ReportTransfer RT = new ReportTransfer();
            RT.Show();
        }

        private void PanTotal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GvCorrupted_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double Bob = 0;
            for (int i = 0; i < GvCorrupted.Rows.Count; ++i)
            {
                Bob += double.Parse(GvCorrupted.Rows[i].Cells["Corrept"].Value.ToString());
            }
            this.LblCorrept.Text = Bob.ToString(); 
        }

        private void CBStore_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // empty and be ready for data 
            // labels 
            this.LblMonyinBuyBills.Text = 0.ToString();
            this.LblTotalpayedinsales.Text = 0.ToString();
            this.LblTotalDebtPayed.Text = 0.ToString();
            this.LblCreaditPayed.Text = 0.ToString();
            this.LblBackInMoney.Text = 0.ToString();
            this.LblTotalEarn.Text = 0.ToString();
            this.LblBackoutValue.Text = 0.ToString();
            this.LblTotalExpenses.Text = 0.ToString();
            this.LblTotalIncom.Text = 0.ToString();
            this.LblFuckingEarn.Text = 0.ToString();
            this.LblFinel.Text = 0.ToString();
            this.LblCorrept.Text = 0.ToString();


            this.LblBackinBillsNU.Text = string.Empty;
            this.LblTotalBuybills.Text = string.Empty;
            this.LblSalesBillsnumber.Text = string.Empty;
            this.LblBackOutBillsNumber.Text = string.Empty;

            // graidviews
            this.GVBuying.Rows.Clear();
            this.GVSales.Rows.Clear();
            this.GVLateBuying.Rows.Clear();
            this.GVLateSales.Rows.Clear();
            this.GVBackin.Rows.Clear();
            this.GvBackout.Rows.Clear();
            this.GvExpenses.Rows.Clear();
            this.GvIncome.Rows.Clear();
            this.GvCorrupted.Rows.Clear();
            /////////////////////////////////////////////////////////////////////////////////////////////
            // report of buying 
            SqlCommand Buy = new SqlCommand();
            Buy.Connection = Cnn;
            Buy.CommandType = CommandType.Text;
            Buy.CommandText = "select * from ReportBuying where  (day(DateOfBill)=day(@DateOfBill))  and (month(DateOfBill)=month(@DateOfBill)) and (year(DateOfBill)=year(@DateOfBill)) and StoreID=@StoreID";

            Buy.Parameters.AddWithValue("@DateOfBill", DateTime.Now.ToString("yyyy-MM-dd"));
            Buy.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader DR;
            Cnn.Open();
            DR = Buy.ExecuteReader();

            while (DR.Read())// لو لقى هايعرض 
            {

                this.GVBuying.Rows.Add(DR["BillID"].ToString(), DR["Paid"].ToString(), DR["ProviderName"].ToString(), DR["DateOfBill"].ToString(), DR["Name"].ToString(), DR["StoreName"].ToString());

            }

            DR.Close();
            Cnn.Close();

            ///////////////////////////////////////////////////////////////////////////////////
            // sales report 
            SqlCommand sales = new SqlCommand();
            sales.Connection = Cnn;
            sales.CommandType = CommandType.Text;
            sales.CommandText = "select * from Reportsales where  (day(BillDate)=day(@BillDate))  and (month(BillDate)=month(@BillDate)) and (year(BillDate)=year(@BillDate)) and StoreID=@StoreID";

            sales.Parameters.AddWithValue("@BillDate", DateTime.Now.ToString("yyyy-MM-dd"));
            sales.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader SA;
            Cnn.Open();
            SA = sales.ExecuteReader();

            while (SA.Read())// لو لقى هايعرض 
            {

                this.GVSales.Rows.Add(SA["SaleBillID"].ToString(), SA["Paid"].ToString(), SA["CustomerName"].ToString(), SA["BillDate"].ToString(), SA["Earn"].ToString(), SA["Name"].ToString(), SA["StoreName"].ToString());

            }

            SA.Close();
            Cnn.Close();

            ////////////////////////////////////////////////////////////////////
            // report of late buying accounting 

            SqlCommand BUA = new SqlCommand();
            BUA.Connection = Cnn;
            BUA.CommandType = CommandType.Text;
            BUA.CommandText = "select * from Reportlatebuying where  (day(PaiedDate)=day(@PaiedDate))  and (month(PaiedDate)=month(@PaiedDate)) and (year(PaiedDate)=year(@PaiedDate)) and StoreID=@StoreID";

            BUA.Parameters.AddWithValue("@PaiedDate", DateTime.Now.ToString("yyyy-MM-dd"));
            BUA.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader BU;
            Cnn.Open();
            BU = BUA.ExecuteReader();

            while (BU.Read())// لو لقى هايعرض 
            {

                this.GVLateBuying.Rows.Add(BU["TotalMoney"].ToString(), BU["ProviderName"].ToString(), BU["PaiedDate"].ToString(), BU["Name"].ToString(), BU["StoreName"].ToString());

            }

            BU.Close();
            Cnn.Close();
            ///////////////////////////////////////////////////////
            // late sales paied

            SqlCommand LSa = new SqlCommand();
            LSa.Connection = Cnn;
            LSa.CommandType = CommandType.Text;
            LSa.CommandText = "select * from ReportlateSales where  (day(DateOfPay)=day(@DateOfPay))  and (month(DateOfPay)=month(@DateOfPay)) and (year(DateOfPay)=year(@DateOfPay)) and StoreID=@StoreID";

            LSa.Parameters.AddWithValue("@DateOfPay", DateTime.Now.ToString("yyyy-MM-dd"));
            LSa.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader LS;
            Cnn.Open();
            LS = LSa.ExecuteReader();

            while (LS.Read())// لو لقى هايعرض 
            {

                this.GVLateSales.Rows.Add(LS["TotalMoneyPaied"].ToString(), LS["CustomerName"].ToString(), LS["DateOfPay"].ToString(), LS["Name"].ToString(), LS["StoreName"].ToString());

            }

            LS.Close();
            Cnn.Close();
            /////////////////////////////////////////////////////////////
            // Back in bills 
            SqlCommand Backin = new SqlCommand();
            Backin.Connection = Cnn;
            Backin.CommandType = CommandType.Text;
            Backin.CommandText = "select * from ReportBackin where  (day(DateOfBackeIn)=day(@DateOfBackeIn)) and (month(DateOfBackeIn)=month(@DateOfBackeIn)) and (year(DateOfBackeIn)=year(@DateOfBackeIn)) and StoreID=@StoreID";

            Backin.Parameters.AddWithValue("@DateOfBackeIn", DateTime.Now.ToString("yyyy-MM-dd"));
            Backin.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader BI;
            Cnn.Open();
            BI = Backin.ExecuteReader();

            while (BI.Read())// لو لقى هايعرض 
            {

                this.GVBackin.Rows.Add(BI["BackInID"].ToString(), BI["TotalPaybake"].ToString(), BI["CustomerName"].ToString(), BI["DateOfBackeIn"].ToString(), BI["Name"].ToString(), BI["StoreName"].ToString());

            }

            BI.Close();
            Cnn.Close();
            //////////////////////////////////////////////////////////
            // back out bills 

            SqlCommand Backout = new SqlCommand();
            Backout.Connection = Cnn;
            Backout.CommandType = CommandType.Text;
            Backout.CommandText = "select * from ReportBackout where  (day(DateOfBackout)=day(@DateOfBackout))  and (month(DateOfBackout)=month(@DateOfBackout)) and (year(DateOfBackout)=year(@DateOfBackout)) and StoreID=@StoreID";

            Backout.Parameters.AddWithValue("@DateOfBackout", DateTime.Now.ToString("yyyy-MM-dd"));
            Backout.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader BO;
            Cnn.Open();
            BO = Backout.ExecuteReader();

            while (BO.Read())// لو لقى هايعرض 
            {

                this.GvBackout.Rows.Add(BO["BackoutID"].ToString(), BO["TotalMony"].ToString(), BO["ProviderName"].ToString(), BO["DateOfBackout"].ToString(), BO["Name"].ToString(), BO["StoreName"].ToString());

            }

            BO.Close();
            Cnn.Close();
            /////////////////////////////////////////////////////////
            // expenses 
            SqlCommand expenses = new SqlCommand();
            expenses.Connection = Cnn;
            expenses.CommandType = CommandType.Text;
            expenses.CommandText = "select * from ExpensesReport where (day(ExpensesDate)=day(@ExpensesDate)) and (month(ExpensesDate)=month(@ExpensesDate)) and (year(ExpensesDate)=year(@ExpensesDate)) and StoreID=@StoreID";

            expenses.Parameters.AddWithValue("@ExpensesDate", DateTime.Now.ToString("yyyy-MM-dd"));
            expenses.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader EX;
            Cnn.Open();
            EX = expenses.ExecuteReader();

            while (EX.Read())// لو لقى هايعرض 
            {

                this.GvExpenses.Rows.Add(EX["Money"].ToString());

            }

            EX.Close();
            Cnn.Close();
            //////////////////////////////////////////////////////////
            // income 
            SqlCommand income = new SqlCommand();
            income.Connection = Cnn;
            income.CommandType = CommandType.Text;
            income.CommandText = "select * from IncomeReport where (day(IncomeDate)=day(@IncomeDate)) and (month(IncomeDate)=month(@IncomeDate)) and (year(IncomeDate)=year(@IncomeDate)) and StoreID=@StoreID";

            income.Parameters.AddWithValue("@IncomeDate", DateTime.Now.ToString("yyyy-MM-dd"));
            income.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader IN;
            Cnn.Open();
            IN = income.ExecuteReader();

            while (IN.Read())// لو لقى هايعرض 
            {

                this.GvIncome.Rows.Add(IN["IncomeValue"].ToString());

            }

            IN.Close();
            Cnn.Close();
            ///////////////////////////////////////////////////////////
            //load corrept 
            SqlCommand Corrp = new SqlCommand();
            Corrp.Connection = Cnn;
            Corrp.CommandType = CommandType.Text;
            Corrp.CommandText = "select * from showCorreputed where  (day(DateOfbill)=day(@DateOfbill))  and (month(DateOfbill)=month(@DateOfbill)) and (year(DateOfbill)=year(@DateOfbill)) and StoreID=@StoreID";

            Corrp.Parameters.AddWithValue("@DateOfbill", DateTime.Now.ToString("yyyy-MM-dd"));
            Corrp.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader Cor;
            Cnn.Open();
            Cor = Corrp.ExecuteReader();

            while (Cor.Read())// لو لقى هايعرض 
            {

                this.GvCorrupted.Rows.Add(Cor["CoMoney"].ToString());

            }

            Cor.Close();
            Cnn.Close();

            /////////////////////////////////////////////////////////
            // the last ruselt

            double buying = double.Parse(this.LblMonyinBuyBills.Text); //-....................
            double SalesTOT = double.Parse(this.LblTotalpayedinsales.Text); //.....
            double LateBuing = double.Parse(this.LblTotalDebtPayed.Text); // - 
            double LateSales = double.Parse(this.LblCreaditPayed.Text); // + 
            double lastExpenses = double.Parse(this.LblTotalExpenses.Text);//-
            double LastIncome = double.Parse(this.LblTotalIncom.Text);//+
            double Earn = double.Parse(this.LblTotalEarn.Text); // + 
            double corrpt = double.Parse(this.LblCorrept.Text);////////////--

            double w = LastIncome + Earn;

            double Finel = w - lastExpenses;
            double xx = Finel - corrpt;


            this.LblFuckingEarn.Text = w.ToString();

            this.LblFinel.Text = xx.ToString();


            /////////////////////////////////////////////////////////////////////
            // fucking show 

            this.LblShowNow.Text = "تقارير اليوم " + "\n" + DateTime.Now.ToShortDateString();

        }

        private void GVBuying_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = GVBuying.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GVBuying.Rows[rowindex];

            PurchasesBills SB = new PurchasesBills(int.Parse(Row.Cells["BuyBillsNu"].Value.ToString()));
            SB.Show();
        }

        private void GVSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = GVSales.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GVSales.Rows[rowindex];

            SalesBills SB = new SalesBills(int.Parse(Row.Cells["SaleBillNu"].Value.ToString()));
            SB.Show();
        }

        private void GVBackin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = GVBackin.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GVBackin.Rows[rowindex];

            BackinBills SB = new BackinBills(int.Parse(Row.Cells["BackinBillNu"].Value.ToString()));
            SB.Show();
        }

        private void GvBackout_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = GvBackout.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GvBackout.Rows[rowindex];

            Backoutbills SB = new Backoutbills(int.Parse(Row.Cells["BackOutBill"].Value.ToString()));
            SB.Show();
        }
    }
}

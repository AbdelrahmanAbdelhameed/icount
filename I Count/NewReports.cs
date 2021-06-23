using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace I_Count
{
    public partial class NewReports : Form
    {
        AccountingEntities context = new AccountingEntities();
        //  SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);


        public NewReports(int ID)
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

        // Load  Report By Type 
        private void GetTodayReprot( bool IsDate , bool ISMonth )
        {

            DateTime LastDay = DateTime.Now.AddDays(-1);
            DateTime NextDay = DateTime.Now.AddDays(1);
           


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
            GvReport.Rows.Clear();
            GvCorrupted.Rows.Clear();
            GVTransfare.Rows.Clear();







           var Buying = context.TblBills.Where(a => a.DateOfBill >= LastDay && a.DateOfBill <= NextDay).ToList();

            var Salling = context.TblSaleBills.Where(a => a.BillDate >= LastDay && a.BillDate <= NextDay).ToList();

            var ReturnSales = context.TblBackIns.Where(a => a.DateOfBackeIn >= LastDay && a.DateOfBackeIn <= NextDay).ToList();

            var ReturnBuying = context.TblBackOuts.Where(a => a.DateOfBackout >= LastDay && a.DateOfBackout <= NextDay).ToList();

            var Expences = context.TblExpenses.Where(a => a.ExpensesDate >= LastDay && a.ExpensesDate <= NextDay).ToList();

            var Income = context.TblIncomes.Where(a => a.IncomeDate >= LastDay && a.IncomeDate <= NextDay).ToList();

            var Transfare = context.TblTransferBills.Where(a => a.TransferDate >= LastDay && a.TransferDate <= NextDay).ToList();

            var Corrupted = context.TblCorrupteds.Where(a => a.DateOfbill >= LastDay && a.DateOfbill <= NextDay).ToList();

            var CustomersRepay = context.TblRepaySales.Where(a => a.DateOfPay >= LastDay && a.DateOfPay <= NextDay).ToList();

            var ProvidorsRepay = context.TblRepayDebts.Where(a => a.PaiedDate >= LastDay && a.PaiedDate <= NextDay).ToList();

            var Treasure = context.TblProcedures.Where(a => a.ProcedureDate >= LastDay && a.ProcedureDate <= NextDay).ToList();
            this.LblShowNow.Text = "تقارير اليوم " + "\n" + DateTime.Now.ToShortDateString();

            if (IsDate == true && ISMonth == false)
            {
                DateTime From = DTFrom.Value.AddDays(-1);
                DateTime TO = DtTO.Value.AddDays(1);

                int StoreID = int.Parse(CBStore.SelectedValue.ToString());


                Buying = context.TblBills.Where(a => a.DateOfBill >= From && a.DateOfBill <= TO && a.StoreID == StoreID).ToList();
                Salling = context.TblSaleBills.Where(a => a.BillDate >= From && a.BillDate <= TO && a.StoreID == StoreID).ToList();
                ReturnSales = context.TblBackIns.Where(a => a.DateOfBackeIn >= From && a.DateOfBackeIn <= TO && a.StoreID == StoreID).ToList();
                ReturnBuying = context.TblBackOuts.Where(a => a.DateOfBackout >= From && a.DateOfBackout <= TO && a.StoreID == StoreID).ToList();
                Expences = context.TblExpenses.Where(a => a.ExpensesDate >= From && a.ExpensesDate <= TO && a.TblStorage.StoreID == StoreID).ToList();
                Income = context.TblIncomes.Where(a => a.IncomeDate >= From && a.IncomeDate <= TO && a.TblStorage.StoreID == StoreID).ToList();
                Transfare = context.TblTransferBills.Where(a => a.TransferDate >= From && a.TransferDate <= TO && a.StoreID == StoreID).ToList();
                Corrupted = context.TblCorrupteds.Where(a => a.DateOfbill >= From && a.DateOfbill <= TO && a.StoreID == StoreID).ToList();
                CustomersRepay = context.TblRepaySales.Where(a => a.DateOfPay >= From && a.DateOfPay <= TO && a.TblStorage.StoreID == StoreID).ToList();
                ProvidorsRepay = context.TblRepayDebts.Where(a => a.PaiedDate >= From && a.PaiedDate <= TO && a.TblStorage.StoreID == StoreID).ToList();
                Treasure = context.TblProcedures.Where(a => a.ProcedureDate >= From && a.ProcedureDate <= TO && a.TblStorage.StoreID == StoreID).ToList();

                this.LblShowNow.Text = "تقارير من " + "\n" + this.DTFrom.Value.ToShortDateString() + "\n" + "الى" + "\n" + this.DtTO.Value.ToShortDateString();
            }

            if (IsDate == false && ISMonth == true)
            {
                DateTime date = DateTime.Now;
                int StoreID = int.Parse(CBStore.SelectedValue.ToString());

                DateTime From = new DateTime(date.Year, date.Month, 1);
                DateTime TO = From.AddMonths(1).AddDays(-1);

                Buying = context.TblBills.Where(a => a.DateOfBill >= From && a.DateOfBill <= TO && a.StoreID == StoreID).ToList();
                Salling = context.TblSaleBills.Where(a => a.BillDate >= From && a.BillDate <= TO && a.StoreID == StoreID).ToList();
                ReturnSales = context.TblBackIns.Where(a => a.DateOfBackeIn >= From && a.DateOfBackeIn <= TO && a.StoreID == StoreID).ToList();
                ReturnBuying = context.TblBackOuts.Where(a => a.DateOfBackout >= From && a.DateOfBackout <= TO && a.StoreID == StoreID).ToList();
                Expences = context.TblExpenses.Where(a => a.ExpensesDate >= From && a.ExpensesDate <= TO && a.TblStorage.StoreID == StoreID).ToList();
                Income = context.TblIncomes.Where(a => a.IncomeDate >= From && a.IncomeDate <= TO && a.TblStorage.StoreID == StoreID).ToList();
                Transfare = context.TblTransferBills.Where(a => a.TransferDate >= From && a.TransferDate <= TO && a.StoreID == StoreID).ToList();
                Corrupted = context.TblCorrupteds.Where(a => a.DateOfbill >= From && a.DateOfbill <= TO && a.StoreID == StoreID).ToList();
                CustomersRepay = context.TblRepaySales.Where(a => a.DateOfPay >= From && a.DateOfPay <= TO && a.TblStorage.StoreID == StoreID).ToList();
                ProvidorsRepay = context.TblRepayDebts.Where(a => a.PaiedDate >= From && a.PaiedDate <= TO && a.TblStorage.StoreID == StoreID).ToList();
                Treasure = context.TblProcedures.Where(a => a.ProcedureDate >= From && a.ProcedureDate <= TO && a.TblStorage.StoreID == StoreID).ToList();
                this.LblShowNow.Text = "تقارير الشهر " + "\n" + DateTime.Now.ToShortDateString();
            }


            foreach (var BuyItem in Buying)
            {
                GVBuying.Rows.Add(BuyItem.BillID , BuyItem.Paid , BuyItem.TblProvider.ProviderName , BuyItem.DateOfBill.Value.ToShortDateString() , BuyItem.TblUser.Name , BuyItem.TblStore.StoreName,"عرض");
            }

            double TotalBuying = Buying.Sum(a => double.Parse( a.Paid));
            LblMonyinBuyBills.Text = TotalBuying.ToString();
            LblTotalBuybills.Text = Buying.Count().ToString();

            foreach (var SalesItems in Salling)
            {
                GVSales.Rows.Add(SalesItems.SaleBillID , SalesItems.Paid , SalesItems.TblCustomer.CustomerName , SalesItems.BillDate.Value.ToShortDateString(), SalesItems.Earn , SalesItems.TblUser.Name , SalesItems.TblStore.StoreName , "عرض");
            }

            double TotalSalesMoney = Salling.Sum(a => double.Parse(a.Paid));
            double TotalEarnInSallin = Salling.Sum(a => double.Parse(a.Earn));

            LblSalesBillsnumber.Text = Salling.Count().ToString();
            LblTotalpayedinsales.Text = TotalSalesMoney.ToString();
            LblTotalEarn.Text = TotalEarnInSallin.ToString();

            foreach (var SalesReturnItems in ReturnSales)
            {
                GVBackin.Rows.Add(SalesReturnItems.BackInID , SalesReturnItems.TotalPaybake , context.TblCustomers.Where(a=>a.CustomerID == SalesReturnItems.CustomerID).Select(a=>a.CustomerName).FirstOrDefault(), SalesReturnItems.DateOfBackeIn.Value.ToShortDateString(), SalesReturnItems.TblUser.Name, SalesReturnItems.TblStore.StoreName , "عرض");
            }
            double TotalReturnSalesMoney = ReturnSales.Sum(a => double.Parse(a.TotalPaybake));
            LblBackinBillsNU.Text = ReturnSales.Count().ToString();
            LblBackInMoney.Text = TotalReturnSalesMoney.ToString();


            foreach (var ReturnBuyingItems in ReturnBuying)
            {
                GvBackout.Rows.Add(ReturnBuyingItems.BackoutID, ReturnBuyingItems.TotalMony, ReturnBuyingItems.TblProvider.ProviderName, ReturnBuyingItems.DateOfBackout.Value.ToShortDateString(), ReturnBuyingItems.TblUser.Name, ReturnBuyingItems.TblStore.StoreName,"عرض");
            }
            double TotalReturnBuyingMoney = ReturnBuying.Sum(a => double.Parse(a.TotalMony));
            LblBackOutBillsNumber.Text = ReturnBuying.Count().ToString();
            LblBackoutValue.Text = TotalReturnBuyingMoney.ToString();

            foreach (var ExpencesItem in Expences)
            {
                GvExpenses.Rows.Add(ExpencesItem.Money, ExpencesItem.ExpensesReason, ExpencesItem.ExpensesDate.Value.ToShortDateString(), ExpencesItem.TblUser.Name, ExpencesItem.ExpensesID, ExpencesItem.TblStorage.TblStore.StoreName);
            }
            double ExpencesTotalMoney = Expences.Sum(a => double.Parse(a.Money));
            label22.Text = ExpencesTotalMoney.ToString();

            foreach (var IncomeItems in Income)
            {
                GvIncome.Rows.Add(IncomeItems.IncomeValue , IncomeItems.IncomeResourc , IncomeItems.IncomeDate.Value.ToShortDateString(), IncomeItems.TblUser.Name, IncomeItems.IncomeID , IncomeItems.TblStorage.TblStore.StoreName);
            }

            double TotalIncomeMoney = Income.Sum(a => double.Parse(a.IncomeValue));
            label24.Text = TotalIncomeMoney.ToString();


            foreach (var TransfareItems in Transfare)
            {
                foreach (var SubItems in context.TblTransfers.Where(a=>a.TransferBillID == TransfareItems.TransferBillID).ToList())
                {
                    GVTransfare.Rows.Add(SubItems.TblProduct.TblProductType.ProductType, SubItems.TblProduct.ProductName, SubItems.TransQuantity, SubItems.TblTransferBill.TblStore.StoreName , SubItems.TblTransferBill.StoreTo, SubItems.TblTransferBill.TransferDate.Value.ToShortDateString(), SubItems.TblTransferBill.TblUser.Name);
                }
               
            }

            double CorruptedMoney = 0;

            foreach (var CorrItems in Corrupted)
            {
                foreach (var SubCorritem in context.TblCorruptedBills.Where(a=>a.CorruptedID == CorrItems.CorruptedID).ToList())
                {
                    GvCorrupted.Rows.Add(SubCorritem.TblProduct.TblProductType.ProductType, SubCorritem.TblProduct.ProductName, SubCorritem.CorruptedNum, SubCorritem.CoMoney, SubCorritem.TblCorrupted.DateOfbill.Value.ToShortDateString(), SubCorritem.TblCorrupted.TblUser.Name);
                    CorruptedMoney = CorruptedMoney + double.Parse(SubCorritem.CoMoney);
                }
            }
            LblTotalCouraptedMoney.Text = CorruptedMoney.ToString();

            foreach (var  RepaySalesItems in CustomersRepay)
            {
                GVLateSales.Rows.Add(RepaySalesItems.TotalMoneyPaied, RepaySalesItems.TblCustomer.CustomerName , RepaySalesItems.DateOfPay.Value.ToShortDateString(), RepaySalesItems.TblUser.Name, RepaySalesItems.TblStorage.TblStore.StoreName);
            }
            double TotalCustomersRepay = CustomersRepay.Sum(a => double.Parse(a.TotalMoneyPaied));
            LblCreaditPayed.Text = TotalCustomersRepay.ToString();


            foreach (var Repayitem in ProvidorsRepay)
            {
                GVLateBuying.Rows.Add(Repayitem.TotalMoney, context.TblProviders.Where(a=>a.ProviderID == Repayitem.ProviderID).Select(a=>a.ProviderName).FirstOrDefault(), Repayitem.PaiedDate.Value.ToShortDateString(), Repayitem.TblUser.Name, Repayitem.TblStorage.TblStore.StoreName);
            }

            LblTotalDebtPayed.Text = ProvidorsRepay.Sum(a => double.Parse(a.TotalMoney)).ToString() ;


            foreach (var TreasureItem in Treasure)
            {
                GvReport.Rows.Add(TreasureItem.TblStorage.StorageName , TreasureItem.ProcedureName, TreasureItem.ProcedureValue, TreasureItem.ProcedureDate.Value.ToShortDateString(), TreasureItem.TblStorage.TotalMoney, TreasureItem.TblUser.Name);
            }

            LblTotalExpenses.Text = ExpencesTotalMoney.ToString();
            LblTotalIncom.Text = TotalIncomeMoney.ToString();
            LblCorrept.Text = CorruptedMoney.ToString();
            LblFuckingEarn.Text = (TotalEarnInSallin + TotalIncomeMoney).ToString();
            LblFinel.Text = ((TotalEarnInSallin + TotalIncomeMoney) - (CorruptedMoney + ExpencesTotalMoney)).ToString();
        }



        private void LoadTreasures()
        {
            GVTrugers.Rows.Clear();

            var Treasure = context.TblStorages.ToList();
            foreach (var item in Treasure)
            {
                GVTrugers.Rows.Add(item.StorageName,item.TotalMoney,item.TblStore.StoreName);
            }
        }

        private void NewReports_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            GetTodayReprot(false, false);
            LoadStore();
            LoadTreasures();
        }

        private void GVBuying_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = GVBuying.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GVBuying.Rows[rowindex];

            PurchasesBills SB = new PurchasesBills(int.Parse(Row.Cells["BuyBillsNu"].Value.ToString()));
            SB.Show();
        }

        private void GVBuying_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void GVSales_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void GVBackin_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = GVBackin.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GVBackin.Rows[rowindex];

            BackinBills SB = new BackinBills(int.Parse(Row.Cells["BackinBillNu"].Value.ToString()));
            SB.Show();
        }

        private void GvBackout_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = GvBackout.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GvBackout.Rows[rowindex];

            Backoutbills SB = new Backoutbills(int.Parse(Row.Cells["BackOutBill"].Value.ToString()));
            SB.Show();
        }

        private void GvBackout_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = GvBackout.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GvBackout.Rows[rowindex];

            Backoutbills SB = new Backoutbills(int.Parse(Row.Cells["BackOutBill"].Value.ToString()));
            SB.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home Ho = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            Ho.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports RE = new Reports(int.Parse(this.LblUserID.Text));
            RE.Show();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (this.CBStore.SelectedItem == null)
            {
                MessageBox.Show("من فضلك اختار الفرع اولاً", "Creative Care");

            }
            else
            {
                GetTodayReprot(true, false);
            }
        }

        private void BtnMonth_Click(object sender, EventArgs e)
        {
            if (this.CBStore.SelectedItem == null)
            {
                MessageBox.Show("من فضلك اختار الفرع اولاً", "Creative Care");

            }
            else
            {
                GetTodayReprot(false, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime LastDay = DateTime.Now.AddDays(-1);
            DateTime NextDay = DateTime.Now.AddDays(1);



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
            GvReport.Rows.Clear();
            GvCorrupted.Rows.Clear();
            GVTransfare.Rows.Clear();





            DateTime From = DTFrom.Value.AddDays(-1);
            DateTime TO = DtTO.Value.AddDays(1);

        


            var Buying = context.TblBills.Where(a => a.DateOfBill >= From && a.DateOfBill <= TO ).ToList();
            var Salling = context.TblSaleBills.Where(a => a.BillDate >= From && a.BillDate <= TO ).ToList();
            var ReturnSales = context.TblBackIns.Where(a => a.DateOfBackeIn >= From && a.DateOfBackeIn <= TO ).ToList();
            var ReturnBuying = context.TblBackOuts.Where(a => a.DateOfBackout >= From && a.DateOfBackout <= TO ).ToList();
            var Expences = context.TblExpenses.Where(a => a.ExpensesDate >= From && a.ExpensesDate <= TO ).ToList();
            var Income = context.TblIncomes.Where(a => a.IncomeDate >= From && a.IncomeDate <= TO ).ToList();
            var Transfare = context.TblTransferBills.Where(a => a.TransferDate >= From && a.TransferDate <= TO ).ToList();
            var Corrupted = context.TblCorrupteds.Where(a => a.DateOfbill >= From && a.DateOfbill <= TO).ToList();
            var CustomersRepay = context.TblRepaySales.Where(a => a.DateOfPay >= From && a.DateOfPay <= TO ).ToList();
            var ProvidorsRepay = context.TblRepayDebts.Where(a => a.PaiedDate >= From && a.PaiedDate <= TO ).ToList();
            var Treasure = context.TblProcedures.Where(a => a.ProcedureDate >= From && a.ProcedureDate <= TO ).ToList();

            this.LblShowNow.Text = "تقارير من " + "\n" + this.DTFrom.Value.ToShortDateString() + "\n" + "الى" + "\n" + this.DtTO.Value.ToShortDateString();

            foreach (var BuyItem in Buying)
            {
                GVBuying.Rows.Add(BuyItem.BillID, BuyItem.Paid, BuyItem.TblProvider.ProviderName, BuyItem.DateOfBill.Value.ToShortDateString(), BuyItem.TblUser.Name, BuyItem.TblStore.StoreName, "عرض");
            }

            double TotalBuying = Buying.Sum(a => double.Parse(a.Paid));
            LblMonyinBuyBills.Text = TotalBuying.ToString();
            LblTotalBuybills.Text = Buying.Count().ToString();

            foreach (var SalesItems in Salling)
            {
                GVSales.Rows.Add(SalesItems.SaleBillID, SalesItems.Paid, SalesItems.TblCustomer.CustomerName, SalesItems.BillDate.Value.ToShortDateString(), SalesItems.Earn, SalesItems.TblUser.Name, SalesItems.TblStore.StoreName, "عرض");
            }

            double TotalSalesMoney = Salling.Sum(a => double.Parse(a.Paid));
            double TotalEarnInSallin = Salling.Sum(a => double.Parse(a.Earn));

            LblSalesBillsnumber.Text = Salling.Count().ToString();
            LblTotalpayedinsales.Text = TotalSalesMoney.ToString();
            LblTotalEarn.Text = TotalEarnInSallin.ToString();

            foreach (var SalesReturnItems in ReturnSales)
            {
                GVBackin.Rows.Add(SalesReturnItems.BackInID, SalesReturnItems.TotalPaybake, context.TblCustomers.Where(a => a.CustomerID == SalesReturnItems.CustomerID).Select(a => a.CustomerName).FirstOrDefault(), SalesReturnItems.DateOfBackeIn.Value.ToShortDateString(), SalesReturnItems.TblUser.Name, SalesReturnItems.TblStore.StoreName, "عرض");
            }
            double TotalReturnSalesMoney = ReturnSales.Sum(a => double.Parse(a.TotalPaybake));
            LblBackinBillsNU.Text = ReturnSales.Count().ToString();
            LblBackInMoney.Text = TotalReturnSalesMoney.ToString();


            foreach (var ReturnBuyingItems in ReturnBuying)
            {
                GvBackout.Rows.Add(ReturnBuyingItems.BackoutID, ReturnBuyingItems.TotalMony, ReturnBuyingItems.TblProvider.ProviderName, ReturnBuyingItems.DateOfBackout.Value.ToShortDateString(), ReturnBuyingItems.TblUser.Name, ReturnBuyingItems.TblStore.StoreName, "عرض");
            }
            double TotalReturnBuyingMoney = ReturnBuying.Sum(a => double.Parse(a.TotalMony));
            LblBackOutBillsNumber.Text = ReturnBuying.Count().ToString();
            LblBackoutValue.Text = TotalReturnBuyingMoney.ToString();

            foreach (var ExpencesItem in Expences)
            {
                GvExpenses.Rows.Add(ExpencesItem.Money, ExpencesItem.ExpensesReason, ExpencesItem.ExpensesDate.Value.ToShortDateString(), ExpencesItem.TblUser.Name, ExpencesItem.ExpensesID, ExpencesItem.TblStorage.TblStore.StoreName);
            }
            double ExpencesTotalMoney = Expences.Sum(a => double.Parse(a.Money));
            label22.Text = ExpencesTotalMoney.ToString();

            foreach (var IncomeItems in Income)
            {
                GvIncome.Rows.Add(IncomeItems.IncomeValue, IncomeItems.IncomeResourc, IncomeItems.IncomeDate.Value.ToShortDateString(), IncomeItems.TblUser.Name, IncomeItems.IncomeID, IncomeItems.TblStorage.TblStore.StoreName);
            }

            double TotalIncomeMoney = Income.Sum(a => double.Parse(a.IncomeValue));
            label24.Text = TotalIncomeMoney.ToString();


            foreach (var TransfareItems in Transfare)
            {
                foreach (var SubItems in context.TblTransfers.Where(a => a.TransferBillID == TransfareItems.TransferBillID).ToList())
                {
                    GVTransfare.Rows.Add(SubItems.TblProduct.TblProductType.ProductType, SubItems.TblProduct.ProductName, SubItems.TransQuantity, SubItems.TblTransferBill.TblStore.StoreName, SubItems.TblTransferBill.StoreTo, SubItems.TblTransferBill.TransferDate.Value.ToShortDateString(), SubItems.TblTransferBill.TblUser.Name);
                }

            }

            double CorruptedMoney = 0;

            foreach (var CorrItems in Corrupted)
            {
                foreach (var SubCorritem in context.TblCorruptedBills.Where(a => a.CorruptedID == CorrItems.CorruptedID).ToList())
                {
                    GvCorrupted.Rows.Add(SubCorritem.TblProduct.TblProductType.ProductType, SubCorritem.TblProduct.ProductName, SubCorritem.CorruptedNum, SubCorritem.CoMoney, SubCorritem.TblCorrupted.DateOfbill.Value.ToShortDateString(), SubCorritem.TblCorrupted.TblUser.Name);
                    CorruptedMoney = CorruptedMoney + double.Parse(SubCorritem.CoMoney);
                }
            }
            LblTotalCouraptedMoney.Text = CorruptedMoney.ToString();

            foreach (var RepaySalesItems in CustomersRepay)
            {
                GVLateSales.Rows.Add(RepaySalesItems.TotalMoneyPaied, RepaySalesItems.TblCustomer.CustomerName, RepaySalesItems.DateOfPay.Value.ToShortDateString(), RepaySalesItems.TblUser.Name, RepaySalesItems.TblStorage.TblStore.StoreName);
            }
            double TotalCustomersRepay = CustomersRepay.Sum(a => double.Parse(a.TotalMoneyPaied));
            LblCreaditPayed.Text = TotalCustomersRepay.ToString();


            foreach (var Repayitem in ProvidorsRepay)
            {
                GVLateBuying.Rows.Add(Repayitem.TotalMoney, context.TblProviders.Where(a => a.ProviderID == Repayitem.ProviderID).Select(a => a.ProviderName).FirstOrDefault(), Repayitem.PaiedDate.Value.ToShortDateString(), Repayitem.TblUser.Name, Repayitem.TblStorage.TblStore.StoreName);
            }

            LblTotalDebtPayed.Text = ProvidorsRepay.Sum(a => double.Parse(a.TotalMoney)).ToString();


            foreach (var TreasureItem in Treasure)
            {
                GvReport.Rows.Add(TreasureItem.TblStorage.StorageName, TreasureItem.ProcedureName, TreasureItem.ProcedureValue, TreasureItem.ProcedureDate.Value.ToShortDateString(), TreasureItem.TblStorage.TotalMoney, TreasureItem.TblUser.Name);
            }

            LblTotalExpenses.Text = ExpencesTotalMoney.ToString();
            LblTotalIncom.Text = TotalIncomeMoney.ToString();
            LblCorrept.Text = CorruptedMoney.ToString();
            LblFuckingEarn.Text = (TotalEarnInSallin + TotalIncomeMoney).ToString();
            LblFinel.Text = ((TotalEarnInSallin + TotalIncomeMoney) - (CorruptedMoney + ExpencesTotalMoney)).ToString();
            

        }


        private void BtnAllMonth_Click(object sender, EventArgs e)
        {
            DateTime LastDay = DateTime.Now.AddDays(-1);
            DateTime NextDay = DateTime.Now.AddDays(1);



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
            GvReport.Rows.Clear();
            GvCorrupted.Rows.Clear();
            GVTransfare.Rows.Clear();




            DateTime date = DateTime.Now;


            DateTime From = new DateTime(date.Year, date.Month, 1);
            DateTime TO = From.AddMonths(1).AddDays(-1);

            var Buying = context.TblBills.Where(a => a.DateOfBill >= From && a.DateOfBill <= TO).ToList();
            var Salling = context.TblSaleBills.Where(a => a.BillDate >= From && a.BillDate <= TO).ToList();
            var ReturnSales = context.TblBackIns.Where(a => a.DateOfBackeIn >= From && a.DateOfBackeIn <= TO).ToList();
            var ReturnBuying = context.TblBackOuts.Where(a => a.DateOfBackout >= From && a.DateOfBackout <= TO).ToList();
            var Expences = context.TblExpenses.Where(a => a.ExpensesDate >= From && a.ExpensesDate <= TO).ToList();
            var Income = context.TblIncomes.Where(a => a.IncomeDate >= From && a.IncomeDate <= TO).ToList();
            var Transfare = context.TblTransferBills.Where(a => a.TransferDate >= From && a.TransferDate <= TO).ToList();
            var Corrupted = context.TblCorrupteds.Where(a => a.DateOfbill >= From && a.DateOfbill <= TO).ToList();
            var CustomersRepay = context.TblRepaySales.Where(a => a.DateOfPay >= From && a.DateOfPay <= TO).ToList();
            var ProvidorsRepay = context.TblRepayDebts.Where(a => a.PaiedDate >= From && a.PaiedDate <= TO).ToList();
            var Treasure = context.TblProcedures.Where(a => a.ProcedureDate >= From && a.ProcedureDate <= TO).ToList();
            this.LblShowNow.Text = " تقارير الشهر لكل الفروع" + "\n" + DateTime.Now.ToShortDateString();

            foreach (var BuyItem in Buying)
            {
                GVBuying.Rows.Add(BuyItem.BillID, BuyItem.Paid, BuyItem.TblProvider.ProviderName, BuyItem.DateOfBill.Value.ToShortDateString(), BuyItem.TblUser.Name, BuyItem.TblStore.StoreName, "عرض");
            }

            double TotalBuying = Buying.Sum(a => double.Parse(a.Paid));
            LblMonyinBuyBills.Text = TotalBuying.ToString();
            LblTotalBuybills.Text = Buying.Count().ToString();

            foreach (var SalesItems in Salling)
            {
                GVSales.Rows.Add(SalesItems.SaleBillID, SalesItems.Paid, SalesItems.TblCustomer.CustomerName, SalesItems.BillDate.Value.ToShortDateString(), SalesItems.Earn, SalesItems.TblUser.Name, SalesItems.TblStore.StoreName, "عرض");
            }

            double TotalSalesMoney = Salling.Sum(a => double.Parse(a.Paid));
            double TotalEarnInSallin = Salling.Sum(a => double.Parse(a.Earn));

            LblSalesBillsnumber.Text = Salling.Count().ToString();
            LblTotalpayedinsales.Text = TotalSalesMoney.ToString();
            LblTotalEarn.Text = TotalEarnInSallin.ToString();

            foreach (var SalesReturnItems in ReturnSales)
            {
                GVBackin.Rows.Add(SalesReturnItems.BackInID, SalesReturnItems.TotalPaybake, context.TblCustomers.Where(a => a.CustomerID == SalesReturnItems.CustomerID).Select(a => a.CustomerName).FirstOrDefault(), SalesReturnItems.DateOfBackeIn.Value.ToShortDateString(), SalesReturnItems.TblUser.Name, SalesReturnItems.TblStore.StoreName, "عرض");
            }
            double TotalReturnSalesMoney = ReturnSales.Sum(a => double.Parse(a.TotalPaybake));
            LblBackinBillsNU.Text = ReturnSales.Count().ToString();
            LblBackInMoney.Text = TotalReturnSalesMoney.ToString();


            foreach (var ReturnBuyingItems in ReturnBuying)
            {
                GvBackout.Rows.Add(ReturnBuyingItems.BackoutID, ReturnBuyingItems.TotalMony, ReturnBuyingItems.TblProvider.ProviderName, ReturnBuyingItems.DateOfBackout.Value.ToShortDateString(), ReturnBuyingItems.TblUser.Name, ReturnBuyingItems.TblStore.StoreName, "عرض");
            }
            double TotalReturnBuyingMoney = ReturnBuying.Sum(a => double.Parse(a.TotalMony));
            LblBackOutBillsNumber.Text = ReturnBuying.Count().ToString();
            LblBackoutValue.Text = TotalReturnBuyingMoney.ToString();

            foreach (var ExpencesItem in Expences)
            {
                GvExpenses.Rows.Add(ExpencesItem.Money, ExpencesItem.ExpensesReason, ExpencesItem.ExpensesDate.Value.ToShortDateString(), ExpencesItem.TblUser.Name, ExpencesItem.ExpensesID, ExpencesItem.TblStorage.TblStore.StoreName);
            }
            double ExpencesTotalMoney = Expences.Sum(a => double.Parse(a.Money));
            label22.Text = ExpencesTotalMoney.ToString();

            foreach (var IncomeItems in Income)
            {
                GvIncome.Rows.Add(IncomeItems.IncomeValue, IncomeItems.IncomeResourc, IncomeItems.IncomeDate.Value.ToShortDateString(), IncomeItems.TblUser.Name, IncomeItems.IncomeID, IncomeItems.TblStorage.TblStore.StoreName);
            }

            double TotalIncomeMoney = Income.Sum(a => double.Parse(a.IncomeValue));
            label24.Text = TotalIncomeMoney.ToString();


            foreach (var TransfareItems in Transfare)
            {
                foreach (var SubItems in context.TblTransfers.Where(a => a.TransferBillID == TransfareItems.TransferBillID).ToList())
                {
                    GVTransfare.Rows.Add(SubItems.TblProduct.TblProductType.ProductType, SubItems.TblProduct.ProductName, SubItems.TransQuantity, SubItems.TblTransferBill.TblStore.StoreName, SubItems.TblTransferBill.StoreTo, SubItems.TblTransferBill.TransferDate.Value.ToShortDateString(), SubItems.TblTransferBill.TblUser.Name);
                }

            }

            double CorruptedMoney = 0;

            foreach (var CorrItems in Corrupted)
            {
                foreach (var SubCorritem in context.TblCorruptedBills.Where(a => a.CorruptedID == CorrItems.CorruptedID).ToList())
                {
                    GvCorrupted.Rows.Add(SubCorritem.TblProduct.TblProductType.ProductType, SubCorritem.TblProduct.ProductName, SubCorritem.CorruptedNum, SubCorritem.CoMoney, SubCorritem.TblCorrupted.DateOfbill.Value.ToShortDateString(), SubCorritem.TblCorrupted.TblUser.Name);
                    CorruptedMoney = CorruptedMoney + double.Parse(SubCorritem.CoMoney);
                }
            }
            LblTotalCouraptedMoney.Text = CorruptedMoney.ToString();

            foreach (var RepaySalesItems in CustomersRepay)
            {
                GVLateSales.Rows.Add(RepaySalesItems.TotalMoneyPaied, RepaySalesItems.TblCustomer.CustomerName, RepaySalesItems.DateOfPay.Value.ToShortDateString(), RepaySalesItems.TblUser.Name, RepaySalesItems.TblStorage.TblStore.StoreName);
            }
            double TotalCustomersRepay = CustomersRepay.Sum(a => double.Parse(a.TotalMoneyPaied));
            LblCreaditPayed.Text = TotalCustomersRepay.ToString();


            foreach (var Repayitem in ProvidorsRepay)
            {
                GVLateBuying.Rows.Add(Repayitem.TotalMoney, context.TblProviders.Where(a => a.ProviderID == Repayitem.ProviderID).Select(a => a.ProviderName).FirstOrDefault(), Repayitem.PaiedDate.Value.ToShortDateString(), Repayitem.TblUser.Name, Repayitem.TblStorage.TblStore.StoreName);
            }

            LblTotalDebtPayed.Text = ProvidorsRepay.Sum(a => double.Parse(a.TotalMoney)).ToString();


            foreach (var TreasureItem in Treasure)
            {
                GvReport.Rows.Add(TreasureItem.TblStorage.StorageName, TreasureItem.ProcedureName, TreasureItem.ProcedureValue, TreasureItem.ProcedureDate.Value.ToShortDateString(), TreasureItem.TblStorage.TotalMoney, TreasureItem.TblUser.Name);
            }

            LblTotalExpenses.Text = ExpencesTotalMoney.ToString();
            LblTotalIncom.Text = TotalIncomeMoney.ToString();
            LblCorrept.Text = CorruptedMoney.ToString();
            LblFuckingEarn.Text = (TotalEarnInSallin + TotalIncomeMoney).ToString();
            LblFinel.Text = ((TotalEarnInSallin + TotalIncomeMoney) - (CorruptedMoney + ExpencesTotalMoney)).ToString();


        }
    }
}

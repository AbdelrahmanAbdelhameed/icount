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
    public partial class BillsEdit : Form
    {
       // SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);

        AccountingEntities Acc = new AccountingEntities();

        public BillsEdit(int ID)
        {
            InitializeComponent();
            // هنا هاياخد ال ID اللى جايله 
            // يروح يدور بيه على اليوزر ويدينى ال IDبتاعه 
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
        //////////////////////////////////////////////////////////////////////////
        private void LoadCustomer()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblCustomers ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblCustomers");
           
            CBCustomerName.DisplayMember = "CustomerName";
            CBCustomerName.ValueMember = "CustomerID";
            CBCustomerName.DataSource = ds.Tables["TblCustomers"];
            CBCustomerName.SelectedItem = null;
            Cnn.Close();
        }
        // /////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        private void Loadprovider()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProviders ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblProviders");

            CBCustomerName.DisplayMember = "ProviderName";
            CBCustomerName.ValueMember = "ProviderID";
            CBCustomerName.DataSource = ds.Tables["TblProviders"];
            CBCustomerName.SelectedItem = null;
            Cnn.Close();
        }
        private void BillsEdit_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void Pichome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home Ho = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            Ho.Show();
        }

        private void LblPhone_Click(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            this.GVShowBills.Rows.Clear();
            this.CBCustomerName.SelectedItem = null;
            this.TxtDiscount.Show();
            this.TxtDate.Text = "";
            this.TxtTotal.Text = "";
            this.TxtDiscount.Text = "";
            this.TxtPaid.Text = "";
            this.LblMadeen.Show();
            int BID = int.Parse(this.TxtBillNum.Text);

            if (this.RDBElling.Checked == true)
            {

                try
                {
                    LoadCustomer();

                    SqlCommand Cmd = new SqlCommand();
                    Cmd.Connection = Cnn;
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = "select * from VWShowSaleBill where SaleBillID=@SaleBillID";

                    Cmd.Parameters.AddWithValue("@SaleBillID", this.TxtBillNum.Text);

                    SqlDataReader dr;
                    Cnn.Open();
                    dr = Cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        DateTime DAte = DateTime.Parse(dr["BillDate"].ToString());

                        this.CBCustomerName.SelectedValue = dr["CustomerID"].ToString();
                        this.TxtDate.Text = DAte.ToString("yy/MM/yyyy");
                        this.TxtTotal.Text = dr["Total"].ToString();
                        this.TxtDiscount.Text = dr["Discount"].ToString();
                        this.TxtPaid.Text = dr["Paid"].ToString();
                    }
                    dr.Close();
                    Cnn.Close();

                    //int BID = int.Parse(this.TxtBillNum.Text);

                    var Show = Acc.TblSales.Where(a => a.SaleBillID == BID).Select(a => a).ToList();
                    foreach (var item in Show)
                    {
                        this.GVShowBills.Rows.Add(item.ProcedureID.ToString(), item.TblProductType.ProductType, item.TblProduct.ProductName, item.Price, item.Quantity, item.BTotal);
                    }

                }
                catch (Exception)
                {
                    
                    
                }

               
            }
            // هنا المشتريات بقى 
            if (RdBuying.Checked == true)
            {
                try
                {
                    Loadprovider();
                    this.LblMadeen.Hide();
                    var Buying = Acc.TblBills.Where(a => a.BillID == BID).Select(a => a).FirstOrDefault();

                    DateTime DAte = DateTime.Parse(Buying.DateOfBill.ToString());

                    this.CBCustomerName.SelectedValue = Buying.ProviderID;

                    this.TxtDate.Text = DAte.ToString("yy/MM/yyyy");

                    this.TxtTotal.Text = Buying.TotalPaid;
                    this.TxtDiscount.Hide();
                    this.TxtPaid.Text = Buying.Paid;


                    var Show = Acc.TblPurchases.Where(a => a.BillID == BID).Select(a => a).ToList();
                    foreach (var item in Show)
                    {
                        this.GVShowBills.Rows.Add(item.purchasesID.ToString(), item.TblProductType.ProductType, item.TblProduct.ProductName, item.BPrice, item.Quantity, item.BTatol);
                    }
                }
                catch (Exception)
                {
                    
                   
                }

               


            }
            if (this.RdBackin.Checked == true)
            {

                try
                {
                    this.LblMadeen.Hide();
                    this.TxtDiscount.Hide();
                    LoadCustomer();

                    var Backin = Acc.TblBackIns.Where(a => a.BackInID == BID).Select(a => a).FirstOrDefault();

                    DateTime DAte = DateTime.Parse(Backin.DateOfBackeIn.ToString());

                    this.CBCustomerName.SelectedValue = Backin.CustomerID;

                    this.TxtDate.Text = DAte.ToString("yy/MM/yyyy");

                    this.TxtTotal.Text = Backin.TotalPaybake;
                    this.TxtDiscount.Hide();
                    this.TxtPaid.Hide();
                    this.LblDaen.Hide();

                    var Show = Acc.TblBackInBills.Where(a => a.BackInID == BID).Select(a => a).ToList();
                    foreach (var item in Show)
                    {
                        this.GVShowBills.Rows.Add(item.BackInBillID.ToString(), item.TblProduct.TblProductType.ProductType, item.TblProduct.ProductName, item.InPrice, item.BackProNu, item.InTotal);
                    }
                }
                catch (Exception)
                {
                    
                    
                }

               
            }
            if (this.RDBAckOut.Checked ==true)
            {

                try
                {
                    this.LblMadeen.Hide();
                    this.TxtDiscount.Hide();
                    Loadprovider();

                    var Backout = Acc.TblBackOuts.Where(a => a.BackoutID == BID).Select(a => a).FirstOrDefault();

                    DateTime DAte = DateTime.Parse(Backout.DateOfBackout.ToString());

                    this.CBCustomerName.SelectedValue = Backout.ProviderID;

                    this.TxtDate.Text = DAte.ToString("yy/MM/yyyy");

                    this.TxtTotal.Text = Backout.TotalMony;
                    this.TxtDiscount.Hide();
                    this.TxtPaid.Hide();
                    this.LblDaen.Hide();

                    var Show = Acc.TblBackOutBills.Where(a => a.BackoutID == BID).Select(a => a).ToList();
                    foreach (var item in Show)
                    {
                        this.GVShowBills.Rows.Add(item.BackOutBillID.ToString(), item.TblProduct.TblProductType.ProductType, item.TblProduct.ProductName, item.OutPrice, item.OutProdNum, item.OutTotal);
                    }
                }
                catch (Exception)
                {
                    
                   
                }

               
            }
        }

        private void GVShowBills_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = GVShowBills.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GVShowBills.Rows[rowindex];

            if (RDBElling.Checked == true)
            {
                EditBills.Seals SA = new EditBills.Seals(int.Parse(Row.Cells["ProcID"].Value.ToString()));
                SA.Show();

            }
            if (RdBuying.Checked == true)
            {
                EditBills.Buying SA = new EditBills.Buying(int.Parse(Row.Cells["ProcID"].Value.ToString()));
                SA.Show();
            }
            if (RdBackin.Checked == true)
            {
                EditBills.BackIn SA = new EditBills.BackIn(int.Parse(Row.Cells["ProcID"].Value.ToString()));
                SA.Show();
            }
            if (RDBAckOut.Checked==true)
            {
                EditBills.Backout SA = new EditBills.Backout(int.Parse(Row.Cells["ProcID"].Value.ToString()));
                SA.Show();
            }
        }

        private void PicDone_Click(object sender, EventArgs e)
        {
            int BID = int.Parse(this.TxtBillNum.Text);

            if (RDBElling.Checked == true)
            {
                var SBill = Acc.TblSaleBills.Where(a => a.SaleBillID == BID).Select(a => a).FirstOrDefault();

                SBill.Discount = this.TxtDiscount.Text;
                SBill.Paid = this.TxtPaid.Text;
                SBill.Total = this.TxtTotal.Text;

                Acc.SaveChanges();
                MessageBox.Show("Done", "CreativeCare", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (RdBuying.Checked == true)
            {
                var Buying = Acc.TblBills.Where(a => a.BillID == BID).Select(a => a).FirstOrDefault();
                Buying.TotalPaid = this.TxtTotal.Text;
                Buying.Paid = this.TxtPaid.Text;
                Acc.SaveChanges();
                MessageBox.Show("Done", "CreativeCare", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (RdBackin.Checked == true)
            {
                var Backin = Acc.TblBackIns.Where(a => a.BackInID == BID).Select(a => a).FirstOrDefault();
                Backin.TotalPaybake = this.TxtTotal.Text;
                Acc.SaveChanges();
                MessageBox.Show("Done", "CreativeCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (RDBAckOut.Checked == true)
            {
                var Backout = Acc.TblBackOuts.Where(a => a.BackoutID == BID).Select(a => a).FirstOrDefault();
                Backout.TotalMony = this.TxtTotal.Text;
                Acc.SaveChanges();
                MessageBox.Show("Done", "CreativeCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

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

    public partial class BackReport : Form
    {
        //  SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);

        public BackReport(int ID)
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
        /// <summary>
        /// ////////////////////////
        /// load customers 
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
            CBCustomerName.DisplayMember = "CustomerName";
            CBCustomerName.ValueMember = "CustomerID";
            CBCustomerName.DataSource = ds.Tables["TblCustomers"];
            CBCustomerName.SelectedItem = null;
            Con.Close();
        }
       // /////////////////////
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
        
        /////

        private void BackReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.LoadCustomer();
            this.LoadProviders();
        }

        private void Pichome_Click(object sender, EventArgs e)
        {
            this.Close();
            Home HO = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            HO.Visible = true;
        }

        private void CBCustomerName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Con.Close();
            this.DVShowCustomer.Rows.Clear();
            this.LblCCridet.Text = "";
            this.LblCDebit.Text = "";
            SqlCommand expenses = new SqlCommand();
            expenses.Connection = Con;
            expenses.CommandType = CommandType.Text;
            expenses.CommandText = "select * from ShowCusPros where CustomerID=@CustomerID ";

            expenses.Parameters.AddWithValue("@CustomerID", this.CBCustomerName.SelectedValue);

            SqlDataReader EX;
            Con.Open();
            EX = expenses.ExecuteReader();

            while (EX.Read())// لو لقى هايعرض 
            {

                this.DVShowCustomer.Rows.Add(EX["DateOfProc"].ToString(), EX["ProcName"].ToString(), EX["PayedValue"].ToString());
                this.LblCDebit.Text = EX["Debit"].ToString();
                this.LblCCridet.Text = EX["Credit"].ToString();
                 
            }
        }

        private void CBCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

           
            if (e.KeyCode == Keys.Enter)
            {
                Con.Close();
                this.DVShowCustomer.Rows.Clear();
                this.LblCCridet.Text = "";
                this.LblCDebit.Text = "";
                SqlCommand expenses = new SqlCommand();
                expenses.Connection = Con;
                expenses.CommandType = CommandType.Text;
                expenses.CommandText = "select * from ShowCusPros where CustomerID=@CustomerID ";

                expenses.Parameters.AddWithValue("@CustomerID", this.CBCustomerName.SelectedValue);

                SqlDataReader EX;
                Con.Open();
                EX = expenses.ExecuteReader();

                while (EX.Read())// لو لقى هايعرض 
                {

                    this.DVShowCustomer.Rows.Add(EX["DateOfProc"].ToString(), EX["ProcName"].ToString(), EX["PayedValue"].ToString());
                    this.LblCDebit.Text = EX["Debit"].ToString();
                    this.LblCCridet.Text = EX["Credit"].ToString();

                }
            }
            }
            catch (Exception)
            {

                
            }
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            this.PanCustomer.Show();
            this.PanProvider.Hide();
        }

        private void BtnProviders_Click(object sender, EventArgs e)
        {
          this.PanCustomer.Hide();
          this.PanProvider.Show();

        }

        private void CBProvider_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.GVProvider.Rows.Clear();
            this.Lblprocr.Text = "";
            this.LblPRodri.Text = "";

            Con.Close();
            this.DVShowCustomer.Rows.Clear();
            this.LblCCridet.Text = "";
            this.LblCDebit.Text = "";
            SqlCommand expenses = new SqlCommand();
            expenses.Connection = Con;
            expenses.CommandType = CommandType.Text;
            expenses.CommandText = "select * from showProProc where ProviderID=@ProviderID ";

            expenses.Parameters.AddWithValue("@ProviderID", this.CBProvider.SelectedValue);

            SqlDataReader EX;
            Con.Open();
            EX = expenses.ExecuteReader();

            while (EX.Read())// لو لقى هايعرض 
            {

                this.GVProvider.Rows.Add(EX["ProDate"].ToString(), EX["PRocName"].ToString(), EX["ProPaied"].ToString());
                this.LblPRodri.Text = EX["Debit"].ToString();
                this.Lblprocr.Text = EX["Credit"].ToString();

            }
        }

        private void CBProvider_KeyDown(object sender, KeyEventArgs e)
        {
            
            try
            {
                this.GVProvider.Rows.Clear();
                this.Lblprocr.Text = "";
                this.LblPRodri.Text = "";

                if (e.KeyCode == Keys.Enter)
                {

                    Con.Close();
                    this.DVShowCustomer.Rows.Clear();
                    this.LblCCridet.Text = "";
                    this.LblCDebit.Text = "";
                    SqlCommand expenses = new SqlCommand();
                    expenses.Connection = Con;
                    expenses.CommandType = CommandType.Text;
                    expenses.CommandText = "select * from showProProc where ProviderID=@ProviderID ";

                    expenses.Parameters.AddWithValue("@ProviderID", this.CBProvider.SelectedValue);

                    SqlDataReader EX;
                    Con.Open();
                    EX = expenses.ExecuteReader();

                    while (EX.Read())// لو لقى هايعرض 
                    {

                        this.GVProvider.Rows.Add(EX["ProDate"].ToString(), EX["PRocName"].ToString(), EX["ProPaied"].ToString());
                        this.LblPRodri.Text = EX["Debit"].ToString();
                        this.Lblprocr.Text = EX["Credit"].ToString();

                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void BtnCUPrint_Click(object sender, EventArgs e)
        {
            if (this.CBCustomerName.SelectedItem ==null)
            {
                MessageBox.Show("من فضلك اختار اسم العميل", "Creative Care");
            }
            else
            {
                LateCuReport LC = new LateCuReport(int.Parse(this.CBCustomerName.SelectedValue.ToString()));
                LC.Show();
            }
        }

        private void BtnProPrint_Click(object sender, EventArgs e)
        {
            if (this.CBProvider.SelectedItem == null )
            {
               MessageBox.Show("من فضلك اختار اسم المورد", "Creative Care");

            }
            else
            {
                LateProReport lp = new LateProReport(int.Parse(this.CBProvider.SelectedValue.ToString()));
                lp.Show();
            }
        }
    }
}

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
    public partial class EditCuPr : Form
    {
       // SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        AccountingEntities context = new AccountingEntities();
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public EditCuPr(int CUID , int ProID,int UsID)
        {
            InitializeComponent();
            if (CUID.ToString()=="0")
            {
                //if 0 search for provider
                this.LblProviderID.Text = ProID.ToString();
               
                this.PicEditCustomer.Hide();
                this.PicEditProvider.Show();

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from TblProviders where ProviderID=@ProviderID   ";

                Cmd.Parameters.AddWithValue("@ProviderID", ProID);

                SqlDataReader dr;
                Con.Open();
                dr = Cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.TxtName.Text = dr["ProviderName"].ToString();
                    this.TxtCompany.Text = dr["CompanyName"].ToString();
                    this.TxtPhone.Text = dr["TelephoneNumber"].ToString();
                    this.TxtDebit.Text = dr["Debit"].ToString();
                    this.TxtCredit.Text = dr["Credit"].ToString();
                }
                dr.Close();
                Con.Close();

            }
            else
            {
                //else search for customer 
                this.LblCustomerID.Text = CUID.ToString();
               
                this.PicEditCustomer.Show();
                this.PicEditProvider.Hide();

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from TblCustomers where CustomerID=@CustomerID ";

                Cmd.Parameters.AddWithValue("@CustomerID", CUID);

                SqlDataReader dr;
                Con.Open();
                dr = Cmd.ExecuteReader();
                if (dr.Read())
                {
                   
                    this.TxtName.Text = dr["CustomerName"].ToString();
                    this.TxtCompany.Text = dr["CustomerCompany"].ToString();
                    this.TxtPhone.Text = dr["CustomerPhone"].ToString();
                    this.TxtDebit.Text = dr["Debit"].ToString();
                    this.TxtCredit.Text = dr["Credit"].ToString();

                }
                dr.Close();
                Con.Close();

            }

            this.LblUserID.Text = UsID.ToString();


        }

        private void EditCuPr_Load(object sender, EventArgs e)
        {

        }

        private void PicEditCustomer_Click(object sender, EventArgs e)
        {
            if (this.LblCustomerID.Text=="2")
            {
              MessageBox.Show("لا يمكن تعديل بيانات هذا العميل", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "EditCustomers";

                Cmd.Parameters.AddWithValue("@CustomerName", this.TxtName.Text);
                Cmd.Parameters.AddWithValue("@CustomerCompany", this.TxtCompany.Text);
                Cmd.Parameters.AddWithValue("@CustomerPhone", this.TxtPhone.Text);
                Cmd.Parameters.AddWithValue("@Debit", this.TxtDebit.Text);
                Cmd.Parameters.AddWithValue("@Credit", this.TxtCredit.Text);
                Cmd.Parameters.AddWithValue("@CustomerID", this.LblCustomerID.Text);

                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                try
                {
                    TblLog Log = new TblLog();
                    Log.UserID = int.Parse(this.LblUserID.Text);
                    Log.Discription = "تعديل بيانات المستخدم   : " + this.TxtName.Text;
                    Log.DateOfLog = DateTime.Now;

                    context.TblLogs.Add(Log);
                    context.SaveChanges();

                }
                catch (Exception)
                {


                }
                MessageBox.Show("Done .... ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
           
        }

        private void PicEditProvider_Click(object sender, EventArgs e)
        {
            if (this.LblProviderID.Text == "14")
            {
                MessageBox.Show("لا يمكن تعديل بيانات هذا المورد", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "EditProviders";

                Cmd.Parameters.AddWithValue("@CustomerName", this.TxtName.Text);
                Cmd.Parameters.AddWithValue("@CustomerCompany", this.TxtCompany.Text);
                Cmd.Parameters.AddWithValue("@CustomerPhone", this.TxtPhone.Text);
                Cmd.Parameters.AddWithValue("@Debit", this.TxtDebit.Text);
                Cmd.Parameters.AddWithValue("@Credit", this.TxtCredit.Text);
                Cmd.Parameters.AddWithValue("@ProviderID", this.LblProviderID.Text);

                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                // add log for user 

                try
                {
                    TblLog Log = new TblLog();
                    Log.UserID = int.Parse(this.LblUserID.Text);
                    Log.Discription = "تعديل بيانات المورد  : " + this.TxtName.Text;
                    Log.DateOfLog = DateTime.Now;

                    context.TblLogs.Add(Log);
                    context.SaveChanges();

                }
                catch (Exception)
                {


                }
                MessageBox.Show("Done .... ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
        }

       
    }
}

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
    public partial class EditProducts : Form
    {
        //SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        AccountingEntities context = new AccountingEntities();
        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);

        public EditProducts(int ID , int UsID)
        {
            InitializeComponent();

            this.LblProductID.Text = ID.ToString();
            this.lblUserID.Text = UsID.ToString();
        }
        // //////////////////////////////////////////////
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
        ///////////////////////////////////////////////////////////////////////
        private void EditProducts_Load(object sender, EventArgs e)
        {
            this.LoadStore();
            //////////////////////////////////
            SqlCommand Buy = new SqlCommand();
            Buy.Connection = Cnn;
            Buy.CommandType = CommandType.Text;
            Buy.CommandText = "select * from LoadProducts where  ProductID=@ProductID";

            Buy.Parameters.AddWithValue("@ProductID", this.LblProductID.Text);
           

            SqlDataReader DR;
            Cnn.Open();
            DR = Buy.ExecuteReader();

           if (DR.Read())// لو لقى هايعرض 
            {
                this.TxtProductType.Text = DR["ProductType"].ToString();
                this.TxtProductName.Text = DR["ProductName"].ToString();
                this.TxtPrice.Text = DR["Price"].ToString();
                this.TxtSalePrice1.Text = DR["SalePrice1"].ToString();
                this.TxtSalePrice2.Text = DR["SalePrice2"].ToString();
                this.TxtQuantinty.Text = DR["Exist"].ToString();
                this.TxtMini.Text = DR["Minimum"].ToString();
                this.CBStore.SelectedValue = DR["StoreID"].ToString();

            }

            DR.Close();
            Cnn.Close();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            // هنا بقى هايروح يعمل ابديت وكدهون بقى 

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "Updateproductsinfo";

            Cmd.Parameters.AddWithValue("@ProductName",this.TxtProductName.Text);
            Cmd.Parameters.AddWithValue("@Price", this.TxtPrice.Text);
            Cmd.Parameters.AddWithValue("@SalePrice1", this.TxtSalePrice1.Text);
            Cmd.Parameters.AddWithValue("@SalePrice2", this.TxtSalePrice2.Text);
            Cmd.Parameters.AddWithValue("@Exist", this.TxtQuantinty.Text);
            Cmd.Parameters.AddWithValue("@Minimum", this.TxtMini.Text);
            Cmd.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);
            Cmd.Parameters.AddWithValue("@ProductID", this.LblProductID.Text);

            Cnn.Open();
            Cmd.ExecuteNonQuery();
            Cnn.Close();


            try
            {
                TblLog Log = new TblLog();
                Log.UserID = int.Parse(this.lblUserID.Text);
                Log.Discription = "تعديل بيانات  المنتج    : " + this.TxtProductName.Text;
                Log.DateOfLog = DateTime.Now;

                context.TblLogs.Add(Log);
                context.SaveChanges();

            }
            catch (Exception)
            {


            }

            MessageBox.Show("....Done......","Creative Care",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }
    }
}

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
    public partial class Minimum : Form
    {
        // SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public Minimum(int ID )
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
        ///////////////////////////////////////////////////////////////////////////////
        //////////// بيتنقل بين الفورم 

      
        private void BtnHome_Click(object sender, EventArgs e)//////////////////////Done
        {
            this.Hide();
            Home Ho = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            Ho.Show();
        }
        ////////////////////////////////////////////////
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
            CBProductType.DisplayMember = "ProductType";
            CBProductType.ValueMember = "ProductTypeID";
            CBProductType.DataSource = ds.Tables["TblProductType"];
            CBProductType.SelectedItem = null;
            Con.Close();
        }

        /////////////////////////////////////////////////////////////////////////////////
        // وهنا هاجيب اسم المنجات  

        private void loadProducts()
        {

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProducts where ProductTypeID=@ProductTypeID  and StoreID=@StoreID ";

            Cmd.Parameters.AddWithValue("@ProductTypeID", this.CBProductType.SelectedValue);
            Cmd.Parameters.AddWithValue("@StoreID ", this.CBStore.SelectedValue);

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblProducts");
            CBPrductName.DisplayMember = "ProductName";
            CBPrductName.ValueMember = "ProductID";
            CBPrductName.DataSource = ds.Tables["TblProducts"];
            CBPrductName.SelectedItem = null;

            Con.Close();
        }
        ////////////////////////////////////////////////////////////////////
        ////////////////////// وهنا هاجيب بقى المنتجات اللى وصلت للحد الادنى 

        private void LoadMinimum()
        {
            this.GVMinimum.Rows.Clear();

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from VWMinimum where Exist <= Minimum";

            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();
            while (dr.Read())
            {
                this.GVMinimum.Rows.Add(dr["ProductType"].ToString(), dr["ProductName"].ToString(), dr["Exist"].ToString(), dr["Minimum"].ToString(), dr["StoreName"].ToString());
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
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Minimum_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.LoadProductType();
            this.LoadMinimum();
            this.LoadStore();
        }

        private void Minimum_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CBProductType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LblPrductName.Show();
            this.CBPrductName.Show();
            this.loadProducts();

        }

        private void CBPrductName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LblMinimum.Show();
            this.TxtMinimum.Show();
            this.BtnAdd.Show();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {

            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                this.LblStore.Show();
                this.CBStore.Show();
                this.BtnShow.Hide();
                this.PicBack.Show();
            }
            
        }
        // /// /// //////////////////////////////////////////////////////////////
        // // // هنا بيروح يحدد الحد الادنى للبضائع 
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {


                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "update TblProducts set Minimum=@Minimum where ProductID=@ProductID";

                Cmd.Parameters.AddWithValue("@Minimum", this.TxtMinimum.Text);
                Cmd.Parameters.AddWithValue("@ProductID", this.CBPrductName.SelectedValue);

                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                MessageBox.Show("Done","Creative Care");

                DialogResult dialogResult = MessageBox.Show("هل تريد ادخال حد ادنى لمنتج اخر ", "Creative Care", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.TxtMinimum.Text = string.Empty;
                    this.CBProductType.SelectedItem = null;
                    this.CBPrductName.SelectedItem = null;
                    this.LoadMinimum();
                }
                else if (dialogResult == DialogResult.No)
                {

                    this.CBProductType.SelectedItem = null;
                    this.CBPrductName.SelectedItem = null;
                    this.CBStore.SelectedItem = null;
                    this.TxtMinimum.Text = "";
                    this.LblProductType.Hide();
                    this.CBProductType.Hide();
                    this.LblPrductName.Hide();
                    this.CBPrductName.Hide();
                    this.LblMinimum.Hide();
                    this.TxtMinimum.Hide();
                    this.BtnAdd.Hide();
                    this.BtnShow.Show();
                    this.LblStore.Hide();
                    this.CBStore.Hide();
                    this.PicBack.Hide();
                    this.LoadMinimum();

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
            }
        }
        ///////////////////////////////////////////////////////////////////
        // // /// هنا تانى ايفت اللى هو kEy Down 
        private void CBProductType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.LblPrductName.Show();
                this.CBPrductName.Show();
                this.loadProducts();
            }
        }
        // عرض المنتجات 
        private void CBPrductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.LblMinimum.Show();
                this.TxtMinimum.Show();
                this.BtnAdd.Show();
            }
        }

        private void CBStore_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LblProductType.Show();
            this.CBProductType.Show();
        }

        private void PicBack_Click(object sender, EventArgs e)
        {
            this.CBProductType.SelectedItem = null;
            this.CBPrductName.SelectedItem = null;
            this.CBStore.SelectedItem = null;
            this.TxtMinimum.Text = "";
            this.LblProductType.Hide();
            this.CBProductType.Hide();
            this.LblPrductName.Hide();
            this.CBPrductName.Hide();
            this.LblMinimum.Hide();
            this.TxtMinimum.Hide();
            this.BtnAdd.Hide();
            this.BtnShow.Show();
            this.LblStore.Hide();
            this.CBStore.Hide();
            this.PicBack.Hide();
        }
    }
}

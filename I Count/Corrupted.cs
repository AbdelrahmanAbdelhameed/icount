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
    public partial class Corrupted : Form
    {
        // SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);

        AccountingEntities context = new AccountingEntities();
        public Corrupted(int ID)
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
        //  //////////////////////////////////
        private void Corrupted_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.LoadStore();

        }

        private void Pichome_Click(object sender, EventArgs e)
        {
            this.Close();
            Home HO = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            HO.Visible = true;
        }

        private void CBStore_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void CBItemType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID ";

            Cmd.Parameters.AddWithValue("@ProductTypeID ", this.CBItemType.SelectedValue);
            Cmd.Parameters.AddWithValue("@StoreID ", this.CBStore.SelectedValue);

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

        private void CBItemName_SelectionChangeCommitted(object sender, EventArgs e)
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
                this.LblSalePrice.Text = dr["Price"].ToString();
                this.LblExsist.Text = dr["Exist"].ToString();
            }
            dr.Close();
            Con.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
                    int A = int.Parse(this.LblExsist.Text);
                    int B = int.Parse(this.TxtQuantity.Text);
                    if (A < B)
                    {
                        MessageBox.Show("الكميه اكبر من الكميه الموجوده فى المخزن", "Creative Care");
                    }
                    else
                    {
                        this.GVShowProducts.Rows.Add(this.CBItemType.Text, this.CBItemName.Text, this.TxtQuantity.Text, this.TxtValue.Text, this.CBItemName.SelectedValue,this.LblExsist.Text);

                        // ويرجع يفضى تانى علشان لو هايكتب حاجه جديده :D
                        this.CBItemType.SelectedItem = null;
                        this.CBItemName.SelectedItem = null;
                        this.LblSalePrice.Text = string.Empty;
                        this.LblExsist.Text = "";
                        this.TxtQuantity.Text = string.Empty;
                        this.TxtValue.Text = string.Empty;
                    }
        }

        private void TxtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.LblSalePrice.Text != null)
                {
                    double price = double.Parse(this.LblSalePrice.Text);
                    double Quantity = double.Parse(this.TxtQuantity.Text);
                    this.TxtValue.Text = (price * Quantity).ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        private void GVShowProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < GVShowProducts.Rows.Count; ++i)
            {
                sum += double.Parse(GVShowProducts.Rows[i].Cells["Total"].Value.ToString());
            }
            this.TxtTotal.Text = sum.ToString();
          
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            // اروح  انعمل فاتروه واجى بسرعه 
            SqlCommand CmdInsertBill = new SqlCommand();
            CmdInsertBill.Connection = Con;
            CmdInsertBill.CommandType = CommandType.StoredProcedure;
            CmdInsertBill.CommandText = "AddCorrupted";

            CmdInsertBill.Parameters.AddWithValue("@DateOfbill", DateTime.Now.ToString("yyyy-MM-dd"));
            CmdInsertBill.Parameters.AddWithValue("@CorruptedLost", this.TxtTotal.Text);
            CmdInsertBill.Parameters.AddWithValue("@UserID", this.LblUserID.Text);///////////////////////////////////
            CmdInsertBill.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@CorruptedID";
            p2.SqlDbType = SqlDbType.Int;
            p2.Direction = ParameterDirection.Output;
            CmdInsertBill.Parameters.Add(p2);

            Con.Open();
            CmdInsertBill.ExecuteNonQuery();
            Con.Close();
            // هنا بقى هو رايح يعمل بحث عن نوع المنج اللى هو موجود فى الجريد فيو 

            //هو بياخد البيانات اللى بيدور عليها من الجريد فيو 

            foreach (DataGridViewRow row in GVShowProducts.Rows)
            {
                double x = double.Parse(row.Cells["Exist"].Value.ToString());
                double w = double.Parse(row.Cells["Quantity"].Value.ToString());
                double A = x - w;

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "AddCorruptedbill";

                Cmd.Parameters.AddWithValue("@Exist", A);
                Cmd.Parameters.AddWithValue("@ProductID", row.Cells["ProductID"].Value.ToString());
                Cmd.Parameters.AddWithValue("@CorruptedID", CmdInsertBill.Parameters["@CorruptedID"].Value.ToString());
                Cmd.Parameters.AddWithValue("@CorruptedNum", row.Cells["Quantity"].Value.ToString());
                Cmd.Parameters.AddWithValue("@CoMoney", row.Cells["Total"].Value.ToString());


                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                
            }
            ///////////////////////////////////
            this.TxtTotal.Text = string.Empty;
            this.CBStore.SelectedItem = null;
            this.GVShowProducts.Rows.Clear();

            // add log for user 

            try
            {
                TblLog Log = new TblLog();
                Log.UserID = int.Parse(this.LblUserID.Text);
                Log.Discription = "إضافة فاتوره تالف رقم : " + CmdInsertBill.Parameters["@CorruptedID"].Value.ToString();
                Log.DateOfLog = DateTime.Now;

                context.TblLogs.Add(Log);
                context.SaveChanges();

            }
            catch (Exception)
            {
                
              
            }



            MessageBox.Show(" Done ", "Creative Care");  

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
                   

                }
                this.TxtBarcode.Text = "";
                dr.Close();
                Con.Close();
            }
        }
    }
}

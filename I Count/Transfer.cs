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
    public partial class Transfer : Form
    {
       // SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        AccountingEntities context = new AccountingEntities();
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);


        public Transfer(int ID)
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
        ///////////////////////////////////////////////
        ///// وهنا بجيب المخزن التانى 
        // وهنا انا بجيب المخزن 
        private void LoadStoreTo()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStore ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStore");
            CBStoreTo.DisplayMember = "StoreName";
            CBStoreTo.ValueMember = "StoreID";
            CBStoreTo.DataSource = ds.Tables["TblStore"];
            CBStoreTo.SelectedItem = null;
            Con.Close();
        }
        //////////////////////////////////////////
        // load Prodct type 
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
            CBItemType.DisplayMember = "ProductType";
            CBItemType.ValueMember = "ProductTypeID";
            CBItemType.DataSource = ds.Tables["TblProductType"];
            CBItemType.SelectedItem = null;
            Con.Close();
        }

        ///////////////////////////////////

        private void Transfer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.LoadStore();
            this.LoadStoreTo();

        }

        private void CBStore_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LoadProductType();
        }

        private void CBStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.LoadProductType();
            }
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

        private void CBItemType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from TblProducts where ProductTypeID=@ProductTypeID  ";

                Cmd.Parameters.AddWithValue("@ProductTypeID ", this.CBItemType.SelectedValue);

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
                this.TxtPrice.Text = dr["Price"].ToString();
                this.TxtSalePrice1.Text = dr["SalePrice1"].ToString();
                this.TxtSalePrice2.Text = dr["SalePrice2"].ToString();
                this.LblExsist.Text = dr["Exist"].ToString();
            }
            dr.Close();
            Con.Close();
        }

        private void CBItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
                    this.TxtPrice.Text = dr["Price"].ToString();
                    this.TxtSalePrice1.Text = dr["SalePrice1"].ToString();
                    this.TxtSalePrice2.Text = dr["SalePrice2"].ToString();
                    this.LblExsist.Text = dr["Exist"].ToString();
                }
                dr.Close();
                Con.Close();
            }
        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.TxtPrice.Text != null)
                {
                    double price = double.Parse(this.TxtPrice.Text);
                    double Quantity = double.Parse(this.TxtQuantity.Text);
                    this.TxtValue.Text = (price * Quantity).ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        private void TxtValue_TextChanged(object sender, EventArgs e)
        {
            // :D "وده بقى علشان لو حب يتذاكى ويحط القيمه كلها يجبله سعر الحته 
            try
            {
                if (this.TxtValue.Text != null)
                {
                    double Value = double.Parse(this.TxtValue.Text);
                    double Quantity = double.Parse(this.TxtQuantity.Text);

                    this.TxtPrice.Text = (Value / Quantity).ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        private void Pichome_Click(object sender, EventArgs e)
        {
            this.Close();
            Home HO = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            HO.Visible = true;
        }

        private void TxtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.TxtPrice.Text != null)
                {
                    double price = double.Parse(this.TxtPrice.Text);
                    double Quantity = double.Parse(this.TxtQuantity.Text);
                    this.TxtValue.Text = (price * Quantity).ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TxtQuantity.Text == string.Empty || this.TxtValue.Text == string.Empty || this.CBItemType.SelectedItem == null || this.CBItemName.SelectedItem == null || this.CBStoreTo.SelectedItem == null || this.CBStoreTo.SelectedItem == null)
                {
                    MessageBox.Show("من فضلك تاكد من ان البيانات صحيحه ", "Creative Care");

                }
                else
                {

                    int A = int.Parse(this.LblExsist.Text);
                    int B = int.Parse(this.TxtQuantity.Text);
                    if (A < B)
                    {
                        MessageBox.Show("الكميه الموجوده فى المخزن لا تكفى", "Creative Care");
                    }
                    else
                    {

                        this.GVShowProducts.Rows.Add(this.CBItemType.Text, this.CBItemName.Text, this.TxtPrice.Text, this.TxtQuantity.Text, this.TxtValue.Text,this.TxtSalePrice1.Text,this.TxtSalePrice2.Text, this.CBItemName.SelectedValue, this.CBItemType.SelectedValue, this.LblExsist.Text);


                        // ويرجع يفضى تانى علشان لو هايكتب حاجه جديده :D
                        this.CBItemType.SelectedItem = null;
                        this.CBItemName.SelectedItem = null;
                        this.TxtPrice.Text = string.Empty;
                        this.TxtQuantity.Text = string.Empty;
                        this.TxtValue.Text = string.Empty;
                        this.TxtSalePrice1.Text = "";
                        this.TxtSalePrice2.Text = "";
                        this.LblExsist.Text = "";
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("من فضلك تاكد ان البيانات المطلوبه صحيحه", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
           

        private void GVShowProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double sum = 0;

            for (int i = 0; i < GVShowProducts.Rows.Count; ++i)
            {
                sum += double.Parse(GVShowProducts.Rows[i].Cells["Total"].Value.ToString());

            }
            this.TxtTotal.Text = sum.ToString();
          
        }

        private void GVShowProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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
            // هنا بقى هايروح يعمل عملية النقل دى 
            if (this.CBStoreTo.SelectedItem==null || this.CBStore.SelectedItem==null)
            {
                MessageBox.Show(" من فضلك اختار اسم المخزن ", "Creative Care",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

            }
            else
            {
                // اول حاجه هايعملها هنا انه يروح يعمل فاتوره 

               
                TblTransferBill TB = new TblTransferBill();
                TB.TransferDate = DateTime.Now;
                TB.StoreID = int.Parse(this.CBStore.SelectedValue.ToString());
                TB.StoreTo = this.CBStoreTo.Text;
                TB.UserID = int.Parse(LblUserID.Text);
                context.TblTransferBills.Add(TB);
                context.SaveChanges();

                // هنا بقى هو رايح يعمل بحث عن نوع المنج اللى هو موجود فى الجريد فيو 

                //هو بياخد البيانات اللى بيدور عليها من الجريد فيو 
                int StoreToId = int.Parse(CBStoreTo.SelectedValue.ToString());

                foreach (DataGridViewRow row in GVShowProducts.Rows)
                {
                    //row.Cells["ProductTypeID"].Value.ToString());

                    string ProName = row.Cells["ItemName"].Value.ToString();

                    int EProID = int.Parse(row.Cells["ProductID"].Value.ToString());

                   var ExistProduct = context.TblProducts.Where(a => a.ProductID == EProID).FirstOrDefault();

                    var CheckProName = context.TblProducts.Where(a => a.ProductName.Equals(ProName) && a.StoreID == StoreToId).FirstOrDefault();
                    if (CheckProName != null)
                    {
                        CheckProName.Exist = CheckProName.Exist + double.Parse(row.Cells["Quantity"].Value.ToString());
                        context.SaveChanges();
                    }
                    else
                    {
                        int Serial;
                        var CountSessions = context.TblProducts.Where(a => a.StoreID == StoreToId).Count();
                        if (CountSessions > 0 && CountSessions != 1)
                        {
                            var lastcode = context.TblProducts.Where(a => a.StoreID == StoreToId).Max(a => a.Serial);
                            Serial = int.Parse(lastcode.ToString()) + 1;

                        }
                        else
                        {
                            Serial = 1;
                        }

                        ExistProduct.Exist = double.Parse(row.Cells["Quantity"].Value.ToString());
                        ExistProduct.StoreID = StoreToId;
                        ExistProduct.Serial = Serial;
                        context.TblProducts.Add(ExistProduct);
                        context.SaveChanges();
                    }

                    var ExistProductss = context.TblProducts.Where(a => a.ProductID == EProID).FirstOrDefault();
                    double x = double.Parse(ExistProductss.Exist.ToString());
                    double w = double.Parse(row.Cells["Quantity"].Value.ToString());
                    double A = x - w;

                    ExistProductss.Exist = A;
                    context.SaveChanges();

                    TblProductsMovement Movem = new TblProductsMovement();
                    Movem.MoveQuantity = row.Cells["Quantity"].Value.ToString();
                    Movem.ProductID = ExistProduct.ProductID;
                    Movem.TemporaryID = 5;
                    Movem.MoveDate = DateTime.Now;
                    Movem.MoveValue = this.TxtTotal.Text;

                    context.TblProductsMovements.Add(Movem);
                    context.SaveChanges();


                   
                }

                try
                {
                    TblLog Log = new TblLog();
                    Log.UserID = int.Parse(this.LblUserID.Text);
                    Log.Discription = " تسجيل فاتورة نقل رقم  : " + TB.TransferBillID;
                    Log.DateOfLog = DateTime.Now;

                    context.TblLogs.Add(Log);
                    context.SaveChanges();

                }
                catch (Exception)
                {


                }
                MessageBox.Show("تم النقل بنجاح", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.GVShowProducts.Rows.Clear();
            }

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
                    ////////////////////////////////////////////////////
                    SqlCommand Toto = new SqlCommand();
                    Toto.Connection = Con;
                    Toto.CommandType = CommandType.Text;
                    Toto.CommandText = "select *  from LoadProducts where ProductID=@ProductID";

                    Toto.Parameters.AddWithValue("@ProductID", ProN);

                    SqlDataReader DR;
                    Con.Open();
                    DR = Toto.ExecuteReader();
                    if (DR.Read())
                    {
                        this.TxtPrice.Text = DR["Price"].ToString();

                    }
                    DR.Close();
                    Con.Close();

                }
                this.TxtBarcode.Text = "";
                dr.Close();
                Con.Close();
            }
        }
    }
}

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
    public partial class Products : Form
    {
        //  SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");

        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);

        public Products(int ID)
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
                this.LblPostion.Text = dr["PositionID"].ToString();

            }

            dr.Close();
            Cnn.Close();

        }
        // وهنا نوع المنتجات 
        private void LoadProductType()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProductType ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblProductType");
            CBItemType.DisplayMember = "ProductType";
            CBItemType.ValueMember = "ProductTypeID";
            CBItemType.DataSource = ds.Tables["TblProductType"];
            CBItemType.SelectedItem = null;
            Cnn.Close();
        }
        // //////////////////////////////////////////
        /// load Productmove
        private void loadProductaction()
        {
            this.GVShowMoves.Rows.Clear();

            SqlCommand Buy = new SqlCommand();
            Buy.Connection = Cnn;
            Buy.CommandType = CommandType.Text;
            Buy.CommandText = "select * from ShowProMove";


            SqlDataReader DR;
            Cnn.Open();
            DR = Buy.ExecuteReader();

            while (DR.Read())// لو لقى هايعرض 
            {
                DateTime DT =DateTime.Parse(DR["MoveDate"].ToString());

                this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                //this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

            }

            DR.Close();
            Cnn.Close();
        }
        ///////////////////////////////////////////////
        // load all prodicts 
        private void LoadAllProductsyaam()
        {
            this.GvShowProducts.Rows.Clear();

            SqlCommand Buy = new SqlCommand();
            Buy.Connection = Cnn;
            Buy.CommandType = CommandType.Text;
            Buy.CommandText = "select * from LoadProducts";


            SqlDataReader DR;
            Cnn.Open();
            DR = Buy.ExecuteReader();

            while (DR.Read())// لو لقى هايعرض 
            {
                double X = double.Parse(DR["Price"].ToString());
                double Y = double.Parse(DR["Exist"].ToString());

                double Ctotn = X * Y;

                this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

            }


            DR.Close();
            Cnn.Close();
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
        // load Actions 
        private void LoadActions()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStore ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStore");
            CBActionStore.DisplayMember = "StoreName";
            CBActionStore.ValueMember = "StoreID";
            CBActionStore.DataSource = ds.Tables["TblStore"];
            CBActionStore.SelectedItem = null;
            Cnn.Close();

            SqlCommand Type = new SqlCommand();
            Type.Connection = Cnn;
            Type.CommandType = CommandType.Text;
            Type.CommandText = "select * from TblProductType ";

            SqlDataAdapter DA = new SqlDataAdapter(Type);
            Cnn.Open();
            DataSet DS = new DataSet();
            DA.Fill(DS, "TblProductType");
            CbActionType.DisplayMember = "ProductType";
            CbActionType.ValueMember = "ProductTypeID";
            CbActionType.DataSource = DS.Tables["TblProductType"];
            CbActionType.SelectedItem = null;
            Cnn.Close();

            SqlCommand Temp = new SqlCommand();
            Temp.Connection = Cnn;
            Temp.CommandType = CommandType.Text;
            Temp.CommandText = "select * from TblTemporaryType ";

            SqlDataAdapter Te = new SqlDataAdapter(Temp);
            Cnn.Open();
            DataSet Ts = new DataSet();
            Te.Fill(Ts, "TblTemporaryType");
            CBActionProsudre.DisplayMember = "TemporaryType";
            CBActionProsudre.ValueMember = "TemporaryID";
            CBActionProsudre.DataSource = Ts.Tables["TblTemporaryType"];
            CBActionProsudre.SelectedItem = null;
            Cnn.Close();
        }
        // ////////////////////////////////////////////////////
        // Load CbCommeted
        private void loadCBType()
        {
            this.GVShowMoves.Rows.Clear();
            this.LblAllTotal.Text = "0";
            if (this.CBActionStore.SelectedItem == null && this.CBActionProsudre.SelectedItem == null)
            {

                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where ProductTypeID=@ProductTypeID";

                Buy.Parameters.AddWithValue("@ProductTypeID", this.CbActionType.SelectedValue);

                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض
                {
                    DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                     

                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
            else if (this.CBActionStore.SelectedItem != null && this.CBActionProsudre.SelectedItem == null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where ProductTypeID=@ProductTypeID and StoreID=@StoreID";

                Buy.Parameters.AddWithValue("@ProductTypeID", this.CbActionType.SelectedValue);
                Buy.Parameters.AddWithValue("@StoreID", this.CBActionStore.SelectedValue);


                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                     DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(),  DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
                /////////////////// هايجيب اسم المنتج 
                this.loadProductmoveName();
            }
            else if (this.CBActionStore.SelectedItem == null && this.CBActionProsudre.SelectedItem != null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where ProductTypeID=@ProductTypeID  and TemporaryID=@TemporaryID";

                Buy.Parameters.AddWithValue("@ProductTypeID", this.CbActionType.SelectedValue);
                Buy.Parameters.AddWithValue("@TemporaryID", this.CBActionProsudre.SelectedValue);


                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                   // this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
            else if (this.CBActionStore.SelectedItem != null && this.CBActionProsudre.SelectedItem != null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where ProductTypeID=@ProductTypeID  and TemporaryID=@TemporaryID and StoreID=@StoreID ";

                Buy.Parameters.AddWithValue("@ProductTypeID", this.CbActionType.SelectedValue);
                Buy.Parameters.AddWithValue("@TemporaryID", this.CBActionProsudre.SelectedValue);
                Buy.Parameters.AddWithValue("@StoreID", this.CBActionStore.SelectedValue);


                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                 //   this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
                this.loadProductmoveName();
            }
        }
        ///////////////////////////////////////////////
        //Load CbProc
        private void LoadCBProcAction()
        {
            Cnn.Close();
            this.GVShowMoves.Rows.Clear();

            if (this.CBActionStore.SelectedItem == null && this.CbActionType.SelectedItem == null && this.CBProductName.SelectedItem == null)
            {

                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where TemporaryID=@TemporaryID";

                Buy.Parameters.AddWithValue("@TemporaryID", this.CBActionProsudre.SelectedValue);

                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(),DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                  //  this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
            else if (this.CBActionStore.SelectedItem != null && this.CbActionType.SelectedItem == null && this.CBProductName.SelectedItem == null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where TemporaryID=@TemporaryID and StoreID=@StoreID";

                Buy.Parameters.AddWithValue("@TemporaryID", this.CBActionProsudre.SelectedValue);
                Buy.Parameters.AddWithValue("@StoreID", this.CBActionStore.SelectedValue);


                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(),DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                   // this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
            else if (this.CBActionStore.SelectedItem == null && this.CbActionType.SelectedItem != null && this.CBProductName.SelectedItem == null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where ProductTypeID=@ProductTypeID  and TemporaryID=@TemporaryID";

                Buy.Parameters.AddWithValue("@ProductTypeID", this.CbActionType.SelectedValue);
                Buy.Parameters.AddWithValue("@TemporaryID", this.CBActionProsudre.SelectedValue);


                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                    //this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
            else if (this.CBActionStore.SelectedItem != null && this.CbActionType.SelectedItem != null && this.CBProductName.SelectedItem == null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where ProductTypeID=@ProductTypeID  and TemporaryID=@TemporaryID and StoreID=@StoreID ";

                Buy.Parameters.AddWithValue("@ProductTypeID", this.CbActionType.SelectedValue);
                Buy.Parameters.AddWithValue("@TemporaryID", this.CBActionProsudre.SelectedValue);
                Buy.Parameters.AddWithValue("@StoreID", this.CBActionStore.SelectedValue);


                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                    //this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
            else if (this.CBProductName.SelectedItem !=null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where ProductTypeID=@ProductTypeID  and TemporaryID=@TemporaryID and StoreID=@StoreID and ProductID=@ProductID ";

                Buy.Parameters.AddWithValue("@ProductTypeID", this.CbActionType.SelectedValue);
                Buy.Parameters.AddWithValue("@TemporaryID", this.CBActionProsudre.SelectedValue);
                Buy.Parameters.AddWithValue("@StoreID", this.CBActionStore.SelectedValue);
                Buy.Parameters.AddWithValue("@ProductID", this.CBProductName.SelectedValue);


                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                    //this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
        }

        //////////////////////////////////////////
        /// Load Action Store 
        private void LoadActionStore()
        {
            Cnn.Close();
            this.LblAllTotal.Text = "0";
            this.GVShowMoves.Rows.Clear();

            if (this.CBActionProsudre.SelectedItem == null && this.CbActionType.SelectedItem == null)
            {

                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where StoreID=@StoreID";

                Buy.Parameters.AddWithValue("@StoreID", this.CBActionStore.SelectedValue);

                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                   // this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
            else if (this.CBActionProsudre.SelectedItem != null && this.CbActionType.SelectedItem == null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where TemporaryID=@TemporaryID and StoreID=@StoreID";

                Buy.Parameters.AddWithValue("@TemporaryID", this.CBActionProsudre.SelectedValue);
                Buy.Parameters.AddWithValue("@StoreID", this.CBActionStore.SelectedValue);


                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                     DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                   // this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
            else if (this.CBActionProsudre.SelectedItem == null && this.CbActionType.SelectedItem != null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where ProductTypeID=@ProductTypeID  and StoreID=@StoreID";

                Buy.Parameters.AddWithValue("@ProductTypeID", this.CbActionType.SelectedValue);
                Buy.Parameters.AddWithValue("@StoreID", this.CBActionStore.SelectedValue);


                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                   // this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
            else if (this.CBActionProsudre.SelectedItem != null && this.CbActionType.SelectedItem != null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where ProductTypeID=@ProductTypeID  and TemporaryID=@TemporaryID and StoreID=@StoreID ";

                Buy.Parameters.AddWithValue("@ProductTypeID", this.CbActionType.SelectedValue);
                Buy.Parameters.AddWithValue("@TemporaryID", this.CBActionProsudre.SelectedValue);
                Buy.Parameters.AddWithValue("@StoreID", this.CBActionStore.SelectedValue);


                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                     DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                    //this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
        }
        ////////////////////////////////////////////
        /// load type for edit 
        private void LoadForEdit()
        {
          SqlCommand Type = new SqlCommand();
            Type.Connection = Cnn;
            Type.CommandType = CommandType.Text;
            Type.CommandText = "select * from TblProductType ";

            SqlDataAdapter DA = new SqlDataAdapter(Type);
            Cnn.Open();
            DataSet DS = new DataSet();
            DA.Fill(DS, "TblProductType");
            CBEditType.DisplayMember = "ProductType";
            CBEditType.ValueMember = "ProductTypeID";
            CBEditType.DataSource = DS.Tables["TblProductType"];
            CBEditType.SelectedItem = null;
            Cnn.Close();

        }

        /// /////////////////////////////
        ///  ///////////////////////////////////////////////////// وهنا انا بجيب الخزنه///////////////////////////
        private void loadProductName()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID ";

            Cmd.Parameters.AddWithValue("@ProductTypeID",this.CBItemType.SelectedValue);
            Cmd.Parameters.AddWithValue("@StoreID",this.CBStore.SelectedValue);

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblProducts");
            CBProName.DisplayMember = "ProductName";
            CBProName.ValueMember = "ProductID";
            CBProName.DataSource = ds.Tables["TblProducts"];
            CBProName.SelectedItem = null;
            Cnn.Close();

        }
       
        /// /////////////////////////////
        ///  ///////////////////////////////////////////////////// وهنا انا بجيب اسم المنتج للحركه ///////////////////////////
        private void loadProductmoveName()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID ";

            Cmd.Parameters.AddWithValue("@ProductTypeID", this.CbActionType.SelectedValue);
            Cmd.Parameters.AddWithValue("@StoreID", this.CBActionStore.SelectedValue);

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblProducts");
            CBProductName.DisplayMember = "ProductName";
            CBProductName.ValueMember = "ProductID";
            CBProductName.DataSource = ds.Tables["TblProducts"];
            CBProductName.SelectedItem = null;
            Cnn.Close();

        }
        //////////////////////////////////////////////////////////////////////////////
        private void Products_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.LoadProductType();
            this.LoadStore();
            this.loadProductaction();
            this.LoadAllProductsyaam();
            this.LoadActions();
            this.LoadForEdit();
        }

        private void Pichome_Click(object sender, EventArgs e)
        {
            this.Close();
            Home HO = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            HO.Visible = true;
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            this.CBItemType.SelectedItem = null;
            this.CBStore.SelectedItem = null;

            this.LoadAllProductsyaam();
        }

        private void CBItemType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cnn.Close();
            this.GvShowProducts.Rows.Clear();
            this.LblTotalproducts.Text = "";
            this.LblTotalofprodu.Text = "";
            if (this.CBStore.SelectedItem != null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from LoadProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID";

                Buy.Parameters.AddWithValue("@ProductTypeID", this.CBItemType.SelectedValue);
                Buy.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    double X = double.Parse(DR["Price"].ToString());
                    double Y = double.Parse(DR["Exist"].ToString());

                    double Ctotn = X * Y;

                    this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                }

                DR.Close();
                Cnn.Close();

                // load product name 
                this.loadProductName();

            }
            else
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from LoadProducts where ProductTypeID=@ProductTypeID";

                Buy.Parameters.AddWithValue("@ProductTypeID", this.CBItemType.SelectedValue);

                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    double X = double.Parse(DR["Price"].ToString());
                    double Y = double.Parse(DR["Exist"].ToString());

                    double Ctotn = X * Y;

                    this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                }


                DR.Close();
                Cnn.Close();
            }
          //  GvShowProducts.

        }

        private void CBStore_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.GvShowProducts.Rows.Clear();
            this.LblTotalproducts.Text = "";
            this.LblTotalofprodu.Text = "";

            if (this.CBItemType.SelectedItem != null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from LoadProducts where StoreID=@StoreID and ProductTypeID=@ProductTypeID";

                Buy.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);
                Buy.Parameters.AddWithValue("@ProductTypeID", this.CBItemType.SelectedValue);

                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    double X = double.Parse(DR["Price"].ToString());
                    double Y = double.Parse(DR["Exist"].ToString());

                    double Ctotn = X * Y;

                    this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
            else
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from LoadProducts where StoreID=@StoreID ";

                Buy.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    double X = double.Parse(DR["Price"].ToString());
                    double Y = double.Parse(DR["Exist"].ToString());

                    double Ctotn = X * Y;

                    this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
        }

        private void CBItemType_KeyDown(object sender, KeyEventArgs e)
        {
            Cnn.Close();
            if (e.KeyCode == Keys.Enter)
            {
                this.LblTotalproducts.Text = "";
                this.LblTotalofprodu.Text = "";
                this.GvShowProducts.Rows.Clear();
                if (this.CBStore.SelectedItem != null)
                {
                    SqlCommand Buy = new SqlCommand();
                    Buy.Connection = Cnn;
                    Buy.CommandType = CommandType.Text;
                    Buy.CommandText = "select * from LoadProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID";

                    Buy.Parameters.AddWithValue("@ProductTypeID", this.CBItemType.SelectedValue);
                    Buy.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

                    SqlDataReader DR;
                    Cnn.Open();
                    DR = Buy.ExecuteReader();

                    while (DR.Read())// لو لقى هايعرض 
                    {
                        double X = double.Parse(DR["Price"].ToString());
                        double Y = double.Parse(DR["Exist"].ToString());

                        double Ctotn = X * Y;

                        this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                    }


                    DR.Close();
                    Cnn.Close();
                }
                else
                {
                    SqlCommand Buy = new SqlCommand();
                    Buy.Connection = Cnn;
                    Buy.CommandType = CommandType.Text;
                    Buy.CommandText = "select * from LoadProducts where ProductTypeID=@ProductTypeID";

                    Buy.Parameters.AddWithValue("@ProductTypeID", this.CBItemType.SelectedValue);

                    SqlDataReader DR;
                    Cnn.Open();
                    DR = Buy.ExecuteReader();

                    while (DR.Read())// لو لقى هايعرض 
                    {
                        double X = double.Parse(DR["Price"].ToString());
                        double Y = double.Parse(DR["Exist"].ToString());

                        double Ctotn = X * Y;

                        this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                    }

                    DR.Close();
                    Cnn.Close();
                }
            }
        }

        private void CBStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.LblTotalproducts.Text = "";
                this.LblTotalofprodu.Text = "";
                this.GvShowProducts.Rows.Clear();

                if (this.CBItemType.SelectedItem != null)
                {
                    SqlCommand Buy = new SqlCommand();
                    Buy.Connection = Cnn;
                    Buy.CommandType = CommandType.Text;
                    Buy.CommandText = "select * from LoadProducts where StoreID=@StoreID and ProductTypeID=@ProductTypeID";

                    Buy.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);
                    Buy.Parameters.AddWithValue("@ProductTypeID", this.CBItemType.SelectedValue);

                    SqlDataReader DR;
                    Cnn.Open();
                    DR = Buy.ExecuteReader();

                    while (DR.Read())// لو لقى هايعرض 
                    {
                        double X = double.Parse(DR["Price"].ToString());
                        double Y = double.Parse(DR["Exist"].ToString());

                        double Ctotn = X * Y;

                        this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                    }


                    DR.Close();
                    Cnn.Close();
                }
                else
                {
                    SqlCommand Buy = new SqlCommand();
                    Buy.Connection = Cnn;
                    Buy.CommandType = CommandType.Text;
                    Buy.CommandText = "select * from LoadProducts where StoreID=@StoreID ";

                    Buy.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

                    SqlDataReader DR;
                    Cnn.Open();
                    DR = Buy.ExecuteReader();

                    while (DR.Read())// لو لقى هايعرض 
                    {
                        double X = double.Parse(DR["Price"].ToString());
                        double Y = double.Parse(DR["Exist"].ToString());

                        double Ctotn = X * Y;

                        this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                    }

                    DR.Close();
                    Cnn.Close();
                }
            }
        }

        private void BtnProMove_MouseHover(object sender, EventArgs e)
        {
            this.BtnProMove.ImageAlign = ContentAlignment.MiddleRight;
            this.BtnProMove.Text = " حركة البضائع  ";
        }

        private void BtnProMove_MouseLeave(object sender, EventArgs e)
        {
            this.BtnProMove.ImageAlign = ContentAlignment.MiddleCenter;
            this.BtnProMove.Text = "";
        }

        private void BtnProMove_Click(object sender, EventArgs e)
        {
            this.BtnProMove.Hide();
            this.ShowAll.Show();
            this.loadProductaction();
            this.PanOption.Hide();
            this.PanAllProduct.Hide();
            this.panMove.Show();
            this.PanActions.Show();
            this.LoadActions();
        }

        private void ShowAll_MouseHover(object sender, EventArgs e)
        {
            this.ShowAll.ImageAlign = ContentAlignment.MiddleRight;
            this.ShowAll.Text = " عرض البضائع  ";
        }

        private void ShowAll_MouseLeave(object sender, EventArgs e)
        {
            this.ShowAll.ImageAlign = ContentAlignment.MiddleCenter;
            this.ShowAll.Text = "";
        }

        private void ShowAll_Click(object sender, EventArgs e)
        {
            this.ShowAll.Hide();
            this.panMove.Hide();
            this.PanAllProduct.Show();
            this.PanOption.Show();
            this.LoadAllProductsyaam();
            this.BtnProMove.Show();
            this.PanActions.Hide();

        }

        private void BtnActionAll_Click(object sender, EventArgs e)
        {
            this.loadProductaction();
            this.CBActionProsudre.SelectedItem = null;
            this.CBActionStore.SelectedItem = null;
            this.CbActionType.SelectedItem = null;

        }

        private void CbActionType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cnn.Close();
            this.loadCBType();
        }

        private void CbActionType_KeyDown(object sender, KeyEventArgs e)
        {
            Cnn.Close();
            if (e.KeyCode == Keys.Enter)
            {
                this.loadCBType();
            }
        }

        private void CBActionProsudre_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LblAllTotal.Text = "0";
            this.LoadCBProcAction();
            
        }

        private void CBActionProsudre_KeyDown(object sender, KeyEventArgs e)
        {
            Cnn.Close();
            if (e.KeyCode == Keys.Enter)
            {
                this.LblAllTotal.Text = "0";
                this.LoadCBProcAction();
            }
        }

        private void CBActionStore_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LoadActionStore();
        }

        private void CBActionStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.LoadActionStore();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.GVShowMoves.Rows.Clear();
            // هنا البحث ب التاريخ مع النوع ومن غير النوع 
            if (this.CBActionProsudre.SelectedItem !=null && this.CBProductName.SelectedItem !=null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where MoveDate BETWEEN @from and  @to and ProductID=@ProductID   and TemporaryID=@TemporaryID  ";

                Buy.Parameters.AddWithValue("@from", this.DTB1.Value.ToString("yyyy-MM-dd"));
                Buy.Parameters.AddWithValue("@to", this.DTB2.Value.ToString("yyyy-MM-dd"));
                Buy.Parameters.AddWithValue("@ProductID", this.CBProductName.SelectedValue);
                Buy.Parameters.AddWithValue("@TemporaryID", this.CBActionProsudre.SelectedValue);


                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                      DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                    //this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
            else if (this.CBActionProsudre.SelectedItem != null && this.CbActionType.SelectedItem != null) // هنا انا هاغير الاسم هاخليه نوع 
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where MoveDate BETWEEN @from and  @to and ProductTypeID=@ProductTypeID   and TemporaryID=@TemporaryID  ";

                Buy.Parameters.AddWithValue("@from", this.DTB1.Value.ToString("yyyy-MM-dd"));
                Buy.Parameters.AddWithValue("@to", this.DTB2.Value.ToString("yyyy-MM-dd"));
                Buy.Parameters.AddWithValue("@ProductTypeID", this.CbActionType.SelectedValue);
                Buy.Parameters.AddWithValue("@TemporaryID", this.CBActionProsudre.SelectedValue);


                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                      DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                    //this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
            else if (this.CBActionProsudre.SelectedItem !=null && this.CBProductName.SelectedItem ==null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where MoveDate BETWEEN @from and  @to  and TemporaryID=@TemporaryID  ";

                Buy.Parameters.AddWithValue("@from", this.DTB1.Value.ToString("yyyy-MM-dd"));
                Buy.Parameters.AddWithValue("@to", this.DTB2.Value.ToString("yyyy-MM-dd"));
                Buy.Parameters.AddWithValue("@TemporaryID", this.CBActionProsudre.SelectedValue);


                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                     DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                    //this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
           
            else
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where MoveDate BETWEEN @from and  @to ";

                Buy.Parameters.AddWithValue("@from", this.DTB1.Value.ToString("yyyy-MM-dd"));
                Buy.Parameters.AddWithValue("@to", this.DTB2.Value.ToString("yyyy-MM-dd"));

                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(),DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());
                    //this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DR["MoveDate"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }

           
        }

        private void GvShowProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
                MessageBoxManager.Unregister();
            }
            else
            {

                int rowindex = GvShowProducts.SelectedCells[0].RowIndex;

                DataGridViewRow Row = GvShowProducts.Rows[rowindex];

                EditProducts EP = new EditProducts(int.Parse(Row.Cells["ShProductID"].Value.ToString()),int.Parse(this.LblUserID.Text));
                EP.Show();
            }
        }

        private void BtnEditType_Click(object sender, EventArgs e)
        {
            this.PanEdit.Show();
        }

        private void CBEditType_KeyDown(object sender, KeyEventArgs e)
        {
            Cnn.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand Type = new SqlCommand();
                Type.Connection = Cnn;
                Type.CommandType = CommandType.Text;
                Type.CommandText = "select * from TblProductType where ProductTypeID=@ProductTypeID ";

                Type.Parameters.AddWithValue("@ProductTypeID", this.CBEditType.SelectedValue);

                SqlDataReader dr;
                Cnn.Open();
                dr = Type.ExecuteReader();
                
                if (dr.Read())
                {
                    this.TextEditType.Text = dr["ProductType"].ToString();
                }

                dr.Close();
                Cnn.Close();


            }
        }

        private void CBEditType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cnn.Close();
            SqlCommand Type = new SqlCommand();
            Type.Connection = Cnn;
            Type.CommandType = CommandType.Text;
            Type.CommandText = "select * from TblProductType where ProductTypeID=@ProductTypeID ";

            Type.Parameters.AddWithValue("@ProductTypeID", this.CBEditType.SelectedValue);

            SqlDataReader dr;
            Cnn.Open();
            dr = Type.ExecuteReader();
           
            if (dr.Read())
            {
                this.TextEditType.Text = dr["ProductType"].ToString();
            }

            dr.Close();
            Cnn.Close();
        }

        private void PicConfirmEdit_Click(object sender, EventArgs e)
        {
            SqlCommand Type = new SqlCommand();
            Type.Connection = Cnn;
            Type.CommandType = CommandType.Text;
            Type.CommandText = "update TblProductType set ProductType=@ProductType where ProductTypeID=@ProductTypeID ";

            Type.Parameters.AddWithValue("@ProductType", this.TextEditType.Text);
            Type.Parameters.AddWithValue("@ProductTypeID", this.CBEditType.SelectedValue);

            Cnn.Open();
            Type.ExecuteNonQuery();
            Cnn.Close();
            MessageBox.Show("Done... ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.LoadForEdit();
            this.TextEditType.Text = "";
            this.PanEdit.Hide();
        }

        private void GVShowMoves_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double Bob = 0;
            for (int i = 0; i < GVShowMoves.Rows.Count; ++i)
            {
                Bob += double.Parse(GVShowMoves.Rows[i].Cells["ProTotal"].Value.ToString());
            }
            this.LblAllTotal.Text = Bob.ToString();
        }

        private void CBProName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cnn.Close();
            this.LblTotalproducts.Text = "";
            this.LblTotalofprodu.Text = "";
            this.GvShowProducts.Rows.Clear();
            if (this.CBStore.SelectedItem != null && this.CBItemType.SelectedItem !=null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from LoadProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID and ProductID=@ProductID ";

                Buy.Parameters.AddWithValue("@ProductTypeID", this.CBItemType.SelectedValue);
                Buy.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);
                Buy.Parameters.AddWithValue("@ProductID", this.CBProName.SelectedValue);

                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    double X = double.Parse(DR["Price"].ToString());
                    double Y = double.Parse(DR["Exist"].ToString());

                    double Ctotn = X * Y;

                    this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                }


                DR.Close();
                Cnn.Close();
            }
            else if (this.CBStore.SelectedItem == null && this.CBItemType.SelectedItem !=null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from LoadProducts where ProductTypeID=@ProductTypeID and ProductID=@ProductID ";

                Buy.Parameters.AddWithValue("@ProductTypeID", this.CBItemType.SelectedValue);
                Buy.Parameters.AddWithValue("@ProductID", this.CBProName.SelectedValue);

                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    double X = double.Parse(DR["Price"].ToString());
                    double Y = double.Parse(DR["Exist"].ToString());

                    double Ctotn = X * Y;

                    this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
            else if (this.CBStore.SelectedItem == null && this.CBItemType.SelectedItem == null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from LoadProducts where  ProductID=@ProductID ";

                Buy.Parameters.AddWithValue("@ProductID", this.CBProName.SelectedValue);

                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();
                while (DR.Read())// لو لقى هايعرض 
                {
                    double X = double.Parse(DR["Price"].ToString());
                    double Y = double.Parse(DR["Exist"].ToString());

                    double Ctotn = X * Y;

                    this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
            else if (this.CBStore.SelectedItem != null && this.CBItemType.SelectedItem == null)
            {
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from LoadProducts where  ProductID=@ProductID and StoreID=@StoreID ";

                Buy.Parameters.AddWithValue("@ProductID", this.CBProName.SelectedValue);
                Buy.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);


                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                    double X = double.Parse(DR["Price"].ToString());
                    double Y = double.Parse(DR["Exist"].ToString());

                    double Ctotn = X * Y;

                    this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
        }

        private void CBProName_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                this.LblTotalproducts.Text = "";
                this.LblTotalofprodu.Text = "";
                Cnn.Close();
                this.GvShowProducts.Rows.Clear();
                if (this.CBStore.SelectedItem != null && this.CBItemType.SelectedItem != null)
                {
                    SqlCommand Buy = new SqlCommand();
                    Buy.Connection = Cnn;
                    Buy.CommandType = CommandType.Text;
                    Buy.CommandText = "select * from LoadProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID and ProductID=@ProductID ";

                    Buy.Parameters.AddWithValue("@ProductTypeID", this.CBItemType.SelectedValue);
                    Buy.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);
                    Buy.Parameters.AddWithValue("@ProductID", this.CBProName.SelectedValue);

                    SqlDataReader DR;
                    Cnn.Open();
                    DR = Buy.ExecuteReader();

                    while (DR.Read())// لو لقى هايعرض 
                    {
                        double X = double.Parse(DR["Price"].ToString());
                        double Y = double.Parse(DR["Exist"].ToString());

                        double Ctotn = X * Y;

                        this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                    }


                    DR.Close();
                    Cnn.Close();
                }
                else if (this.CBStore.SelectedItem == null && this.CBItemType.SelectedItem != null)
                {
                    SqlCommand Buy = new SqlCommand();
                    Buy.Connection = Cnn;
                    Buy.CommandType = CommandType.Text;
                    Buy.CommandText = "select * from LoadProducts where ProductTypeID=@ProductTypeID and ProductID=@ProductID ";

                    Buy.Parameters.AddWithValue("@ProductTypeID", this.CBItemType.SelectedValue);
                    Buy.Parameters.AddWithValue("@ProductID", this.CBProName.SelectedValue);

                    SqlDataReader DR;
                    Cnn.Open();
                    DR = Buy.ExecuteReader();

                    while (DR.Read())// لو لقى هايعرض 
                    {
                        double X = double.Parse(DR["Price"].ToString());
                        double Y = double.Parse(DR["Exist"].ToString());

                        double Ctotn = X * Y;

                        this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                    }

                    DR.Close();
                    Cnn.Close();
                }
                else if (this.CBStore.SelectedItem == null && this.CBItemType.SelectedItem == null)
                {
                    SqlCommand Buy = new SqlCommand();
                    Buy.Connection = Cnn;
                    Buy.CommandType = CommandType.Text;
                    Buy.CommandText = "select * from LoadProducts where  ProductID=@ProductID ";

                    Buy.Parameters.AddWithValue("@ProductID", this.CBProName.SelectedValue);

                    SqlDataReader DR;
                    Cnn.Open();
                    DR = Buy.ExecuteReader();

                    while (DR.Read())// لو لقى هايعرض 
                    {
                        double X = double.Parse(DR["Price"].ToString());
                        double Y = double.Parse(DR["Exist"].ToString());

                        double Ctotn = X * Y;

                        this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                    }

                    DR.Close();
                    Cnn.Close();
                }
                else if (this.CBStore.SelectedItem != null && this.CBItemType.SelectedItem == null)
                {
                    SqlCommand Buy = new SqlCommand();
                    Buy.Connection = Cnn;
                    Buy.CommandType = CommandType.Text;
                    Buy.CommandText = "select * from LoadProducts where  ProductID=@ProductID and StoreID=@StoreID ";

                    Buy.Parameters.AddWithValue("@ProductID", this.CBProName.SelectedValue);
                    Buy.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);


                    SqlDataReader DR;
                    Cnn.Open();
                    DR = Buy.ExecuteReader();

                    while (DR.Read())// لو لقى هايعرض 
                    {
                        double X = double.Parse(DR["Price"].ToString());
                        double Y = double.Parse(DR["Exist"].ToString());

                        double Ctotn = X * Y;

                        this.GvShowProducts.Rows.Add(DR["Serial"].ToString(), DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["Price"].ToString(), DR["SalePrice1"].ToString(), DR["SalePrice2"].ToString(), DR["Exist"].ToString(), Ctotn, DR["StoreName"].ToString(), DR["ProductID"].ToString());

                    }

                    DR.Close();
                    Cnn.Close();
                }

            }
        }

        private void CBProductName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cnn.Close();
            this.LblAllTotal.Text = "0";
            this.GVShowMoves.Rows.Clear();
            SqlCommand Buy = new SqlCommand();
            Buy.Connection = Cnn;
            Buy.CommandType = CommandType.Text;
            Buy.CommandText = "select * from ShowProMove where ProductID=@ProductID   ";

            Buy.Parameters.AddWithValue("@ProductID", this.CBProductName.SelectedValue);
           

            SqlDataReader DR;
            Cnn.Open();
            DR = Buy.ExecuteReader();

            while (DR.Read())// لو لقى هايعرض 
            {
                DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(), DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());

            }

            DR.Close();
            Cnn.Close();
        }

        private void CBProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cnn.Close();
                this.LblAllTotal.Text = "0";
                this.GVShowMoves.Rows.Clear();
                SqlCommand Buy = new SqlCommand();
                Buy.Connection = Cnn;
                Buy.CommandType = CommandType.Text;
                Buy.CommandText = "select * from ShowProMove where ProductID=@ProductID   ";

                Buy.Parameters.AddWithValue("@ProductID", this.CBProductName.SelectedValue);


                SqlDataReader DR;
                Cnn.Open();
                DR = Buy.ExecuteReader();

                while (DR.Read())// لو لقى هايعرض 
                {
                     DateTime DT = DateTime.Parse(DR["MoveDate"].ToString());
                    this.GVShowMoves.Rows.Add(DR["ProductType"].ToString(), DR["ProductName"].ToString(), DR["TemporaryType"].ToString(), DR["MoveQuantity"].ToString(),DT.ToString("yyyy-MM-dd"), DR["MoveValue"].ToString(), DR["StoreName"].ToString());

                }

                DR.Close();
                Cnn.Close();
            }
        }

        private void GvShowProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double Bob = 0;
            double Toto = 0;
            for (int i = 0; i < GvShowProducts.Rows.Count; ++i)
            {
                Bob += double.Parse(GvShowProducts.Rows[i].Cells["Exist"].Value.ToString());
                Toto += double.Parse(GvShowProducts.Rows[i].Cells["CTotal"].Value.ToString());
            }
            this.LblTotalproducts.Text = Bob.ToString();
            this.LblTotalofprodu.Text = Toto.ToString();
        }

        private void GvShowProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LblPrint_Click(object sender, EventArgs e)
        {
            if (this.CBStore.SelectedItem==null)
            {
                MessageBox.Show("من فضلك اختار الفرع","Creative Care");
            }
            else
            {
                ReportStore RS = new ReportStore(int.Parse(this.CBStore.SelectedValue.ToString()));
                RS.Show();
            }
        }
    }
}

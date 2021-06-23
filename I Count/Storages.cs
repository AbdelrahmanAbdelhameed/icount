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
    public partial class Storages : Form
    {
        // SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");

        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        AccountingEntities context = new AccountingEntities();
        public Storages(int ID)
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
        // //////////////////////////////////////
        /// /////////////////////////////
        /// هنا بقى هانجيب الخزنه 
        private void loadStorage()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStorages ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStorages");
            CBStore.DisplayMember = "StorageName";
            CBStore.ValueMember = "StorageID";
            CBStore.DataSource = ds.Tables["TblStorages"];
            CBStore.SelectedItem = null;

            Cnn.Close();
        }
        /////////////////////////////////////////
        /// هنا بقى هانجيب الخزنه تانى 
        private void loadStoragetane()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStorages ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStorages");
            CBGetStorage.DisplayMember = "StorageName";
            CBGetStorage.ValueMember = "StorageID";
            CBGetStorage.DataSource = ds.Tables["TblStorages"];
            CBGetStorage.SelectedItem = null;

            Cnn.Close();
        }
        /////////////////////////////////////////
        //load procedure 
        private void LoadProcedure()
        {
            this.GvReport.Rows.Clear();

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text; 
            Cmd.CommandText = "select * from ReportProcedure order by ProcedureDate desc ";

           
            SqlDataReader dr;
            Cnn.Open();
            dr = Cmd.ExecuteReader();

            while (dr.Read())
            {
                this.GvReport.Rows.Add(dr["StorageName"].ToString(), dr["ProcedureName"].ToString(), dr["ProcedureValue"].ToString(), dr["ProcedureDate"].ToString(), dr["TotalMoney"].ToString(), dr["Name"].ToString());

            }
            dr.Close();
            Cnn.Close();
        }
        // /////////////////////////////////////
        /////////////////////////////////////////
        /// هنا بقى هانجيب الخزنه تالت 
        private void loadStoragetalet()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStorages ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStorages");
            CBSetStorage.DisplayMember = "StorageName";
            CBSetStorage.ValueMember = "StorageID";
            CBSetStorage.DataSource = ds.Tables["TblStorages"];
            CBSetStorage.SelectedItem = null;

            Cnn.Close();
        }
        /////////////////////////////////////////
        /////////////////////////////////////////
        /// هنا بقى هانجيب الخزنه تالت 
        private void loadStorageFrom()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStorages ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStorages");
            CBFromStorage.DisplayMember = "StorageName";
            CBFromStorage.ValueMember = "StorageID";
            CBFromStorage.DataSource = ds.Tables["TblStorages"];
            CBFromStorage.SelectedItem = null;

            Cnn.Close();
        }
        /////////////////////////////////////////
        /////////////////////////////////////////
        /// هنا بقى هانجيب الخزنه تالت 
        private void loadStorageto()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStorages ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStorages");
            CBToStorage.DisplayMember = "StorageName";
            CBToStorage.ValueMember = "StorageID";
            CBToStorage.DataSource = ds.Tables["TblStorages"];
            CBToStorage.SelectedItem = null;

            Cnn.Close();
        }
        /////////////////////////////////////////
        /////////////////////////////////////////
        /////////////////////////////////////////
        /// هنا بقى هانجيب الخزنه تالت 
        private void loadAllReportStorage()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStorages ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStorages");
            CBAllStorage.DisplayMember = "StorageName";
            CBAllStorage.ValueMember = "StorageID";
            CBAllStorage.DataSource = ds.Tables["TblStorages"];
            CBAllStorage.SelectedItem = null;

            Cnn.Close();
        }
        /////////////////////////////////////////
        /////////////////////////////////////////
        /// هنا بقى هانجيب العمليات 
        private void loadAllReportProces()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStorageActions ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStorageActions");
            CBAllProces.DisplayMember = "SActionName";
            CBAllProces.ValueMember = "SActionID";
            CBAllProces.DataSource = ds.Tables["TblStorageActions"];
            CBAllProces.SelectedItem = null;

            Cnn.Close();
        }
        /////////////////////////////////////////
        // هنا بقى هاحيب التقرير العام للخزن 
        private void LoadAllSReport()
        {
            this.GVAllReport.Rows.Clear();

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from ShowStorageActions order by SPDate desc ";


            SqlDataReader dr;
            Cnn.Open();
            dr = Cmd.ExecuteReader();

            while (dr.Read())
            {
                this.GVAllReport.Rows.Add(dr["StorageName"].ToString(), dr["SActionName"].ToString(), dr["SPMoney"].ToString(), dr["SPDate"].ToString());

            }
            dr.Close();
            Cnn.Close();
        }
        /// /////////////////////////////////////
        private void LoadStoreSt()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStore ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStore");
            CBSTrStore.DisplayMember = "StoreName";
            CBSTrStore.ValueMember = "StoreID";
            CBSTrStore.DataSource = ds.Tables["TblStore"];
            CBSTrStore.SelectedItem = null;
            Cnn.Close();
        }
        //  /////////////////////////////////////
        private void Storages_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.loadStorage();
            this.LoadProcedure();
            this.loadStoragetane();
            this.loadStoragetalet();
            this.loadStorageFrom();
            this.loadStorageto();
            this.loadAllReportStorage();
            this.loadAllReportProces();
            this.LoadAllSReport();
            this.LoadStoreSt();
        }

        private void Pichome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home Ho = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            Ho.Show();
        }

        private void PicAddAndGetMony_MouseHover(object sender, EventArgs e)
        {
            this.LblSetGet.Show();
        }

        private void PicAddAndGetMony_MouseLeave(object sender, EventArgs e)
        {
            this.LblSetGet.Hide();
        }

        private void PicReport_MouseHover(object sender, EventArgs e)
        {
            this.LblReport.Show();
        }

        private void PicReport_MouseLeave(object sender, EventArgs e)
        {
            this.LblReport.Hide();
        }

        private void PicAddStore_MouseHover(object sender, EventArgs e)
        {
            this.LblAddNews.Show();
        }

        private void PicAddStore_MouseLeave(object sender, EventArgs e)
        {
            this.LblAddNews.Hide();
        }

        private void PicEdit_MouseHover(object sender, EventArgs e)
        {
            this.LblEditStore.Show();
        }

        private void PicEdit_MouseLeave(object sender, EventArgs e)
        {
            this.LblEditStore.Hide();
        }

        private void PicAdd_MouseHover(object sender, EventArgs e)
        {
            this.LblAddStore.Show();
        }

        private void PicAdd_MouseLeave(object sender, EventArgs e)
        {
            this.LblAddStore.Hide();
        }

        private void PicAddStore_Click(object sender, EventArgs e)
        {
            this.PanConAndSet.Show();
            this.PanReport.Hide();
            this.PanSetGet.Hide();
            this.PanAllreport.Hide();
        }

        private void PicReport_Click(object sender, EventArgs e)
        {
            this.PanConAndSet.Hide();
            this.PanReport.Show();
            this.LoadProcedure();
            this.PanSetGet.Hide();
            this.PanAllreport.Hide();
        }

        private void PicAddAndGetMony_Click(object sender, EventArgs e)
        {
            this.PanConAndSet.Hide();
            this.PanReport.Hide();
            this.PanSetGet.Show();
            this.loadStoragetane();
            this.PanAllreport.Hide();
            
        }
        // بيعرض بيانات الخزنه
        private void CBStore_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.PanTools.Show();
            this.TxtPalance.Text = "0";
            this.TxtStorageName.Text = "";

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStorages where StorageID=@StorageID ";

            Cmd.Parameters.AddWithValue("@StorageID", this.CBStore.SelectedValue);

            SqlDataReader dr;
            Cnn.Open();
            dr = Cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["StorageID"].ToString() == "3")
                {
                    MessageBox.Show("لايمكن تعديل بيانات هذه الخزنه ");
                }
                else
                {

                    this.TxtStorageName.Text = dr["StorageName"].ToString();
                    this.TxtPalance.Text = dr["TotalMoney"].ToString();
                    this.CBSTrStore.SelectedValue = dr["StoreID"].ToString();
                }
            }
            dr.Close();
            Cnn.Close();
        }

        private void PicEdit_Click(object sender, EventArgs e)
        {
            this.PicConfirmAdd.Hide();
            this.CBStore.Show();
            this.PicConfirmEdit.Show();
        }

        private void PicAdd_Click(object sender, EventArgs e)
        {
            this.TxtPalance.Text = "0";
            this.TxtStorageName.Text = "";

            this.PicConfirmAdd.Show();
            this.CBStore.Hide();
            this.PicConfirmEdit.Hide();
            this.PanTools.Show();
        }
        // تعديل بيانات خزنه
        private void PicConfirmEdit_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.CBStore.SelectedItem == null || this.CBSTrStore.SelectedItem == null)
                {
                    MessageBox.Show("من فضلك اختار اسم الخزنه او الفرع", "Creative Care");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show(" هل تريد ب الفعل تعديل بيانات الخزنه", "Creative Care ", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SqlCommand Cmd = new SqlCommand();
                        Cmd.Connection = Cnn;
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "UpdateStorage";


                        Cmd.Parameters.AddWithValue("@StorageName", this.TxtStorageName.Text);
                        Cmd.Parameters.AddWithValue("@TotalMoney", this.TxtPalance.Text);
                        Cmd.Parameters.AddWithValue("@StoreID", this.CBSTrStore.SelectedValue);
                        Cmd.Parameters.AddWithValue("@StorageID", this.CBStore.SelectedValue);

                        Cnn.Open();
                        Cmd.ExecuteNonQuery();
                        Cnn.Close();
                        try
                        {
                            TblLog Log = new TblLog();
                            Log.UserID = int.Parse(this.LblUserID.Text);
                            Log.Discription = " تعديل بيانات الحزنه : " + this.TxtStorageName.Text;
                            Log.DateOfLog = DateTime.Now;

                            context.TblLogs.Add(Log);
                            context.SaveChanges();

                        }
                        catch (Exception)
                        {


                        }
                        this.TxtPalance.Text = "0";
                        this.TxtStorageName.Text = "";
                        this.CBStore.SelectedItem = null;
                        this.CBSTrStore.SelectedItem = "";

                        MessageBox.Show("Done.....", "Creative Care");
                        this.loadStorage();
                        this.loadStoragetane();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this.TxtPalance.Text = "0";
                        this.TxtStorageName.Text = "";
                        this.CBStore.SelectedItem = null;
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
            }
        }
        // إضافة خزنه جديده
        private void PicConfirmAdd_Click(object sender, EventArgs e)
        {
            try
            {
                        SqlCommand Cmd = new SqlCommand();
                        Cmd.Connection = Cnn;
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "AddStorage";


                        Cmd.Parameters.AddWithValue("@StorageName", this.TxtStorageName.Text);
                        Cmd.Parameters.AddWithValue("@TotalMoney", this.TxtPalance.Text);
                        Cmd.Parameters.AddWithValue("@StoreID", this.CBSTrStore.SelectedValue);

                       

                        Cnn.Open();
                        Cmd.ExecuteNonQuery();
                        Cnn.Close();
                        try
                        {
                            TblLog Log = new TblLog();
                            Log.UserID = int.Parse(this.LblUserID.Text);
                            Log.Discription = " إضافة خزنه جديده : " + this.TxtStorageName.Text;
                            Log.DateOfLog = DateTime.Now;

                            context.TblLogs.Add(Log);
                            context.SaveChanges();

                        }
                        catch (Exception)
                        {


                        }
                        this.TxtPalance.Text = "0";
                        this.TxtStorageName.Text = "";
                        this.CBSTrStore.SelectedItem = "";
                        
                        MessageBox.Show("Done.....", "Creative Care");
                        this.loadStorage();
                        this.loadStoragetane();

            }
            catch (Exception)
            {
                
               MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
            }
        }

        private void PicGetMoney_MouseHover(object sender, EventArgs e)
        {
            this.LblGetMoney.Show();
        }

        private void PicGetMoney_MouseLeave(object sender, EventArgs e)
        {
            this.LblGetMoney.Hide();
        }

        private void PicGetMoney_Click(object sender, EventArgs e)
        {
            this.PanGet.Show();
            this.PanConvert.Hide();
            this.PanSet.Hide();
        }

        private void PicSet_Click(object sender, EventArgs e)
        {
            this.PanSet.Show();
            this.PanConvert.Hide();
            this.PanGet.Hide();
            this.loadStoragetalet();
        }

        private void PicConvert_Click(object sender, EventArgs e)
        {
            this.PanSet.Hide();
            this.PanConvert.Show();
            this.PanSet.Hide();
            this.loadStorageFrom();
            this.loadStorageto();
           
        }

        private void PicSet_MouseHover(object sender, EventArgs e)
        {
            this.LblSet.Show();
        }

        private void PicSet_MouseLeave(object sender, EventArgs e)
        {
            this.LblSet.Hide();
        }

        private void PicConvert_MouseHover(object sender, EventArgs e)
        {
            this.LblConvert.Show();
        }

        private void PicConvert_MouseLeave(object sender, EventArgs e)
        {
            this.LblConvert.Hide();
        }
        // هنا هايروح يعمل عمليه سحب من الخزنه
        private void PicConGet_Click(object sender, EventArgs e)
        {
            if (this.CBGetStorage.SelectedItem==null)
            {
                MessageBox.Show("من فضلك اختار اسم الخزنه", "Creative Care");
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from TblStorages where StorageID=@StorageID ";

                cmd.Parameters.AddWithValue("@StorageID", this.CBGetStorage.SelectedValue);

                SqlDataReader dr;
                Cnn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    double Storag = double.Parse(dr["TotalMoney"].ToString());
                    double Money = double.Parse(this.TxtGet.Text);
                    double ToT = Storag - Money;
                    //////////////////////////////////////////////
                    // هنا السحب من الخزنه
                    Cnn.Close();
                    SqlCommand StorageUpdate = new SqlCommand();
                    StorageUpdate.Connection = Cnn;
                    StorageUpdate.CommandType = CommandType.Text;
                    StorageUpdate.CommandText = "update TblStorages set TotalMoney=@TotalMoney where StorageID=@StorageID";

                    StorageUpdate.Parameters.AddWithValue("@TotalMoney", ToT);
                    StorageUpdate.Parameters.AddWithValue("@StorageID", this.CBGetStorage.SelectedValue);

                    Cnn.Open();
                    StorageUpdate.ExecuteNonQuery();
                    Cnn.Close();
                    //////////////////////////////////////////////////////////////////////////////////
                    /// هنا بقى تسجيل عمليه السحب دى 
                    SqlCommand Cmd = new SqlCommand();
                    Cmd.Connection = Cnn;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "AddNewProcedure";


                    Cmd.Parameters.AddWithValue("@StorageID", this.CBGetStorage.SelectedValue);
                    Cmd.Parameters.AddWithValue("@ProcedureDate", DateTime.Now.ToString("yyyy-MM-dd"));
                    Cmd.Parameters.AddWithValue("@ProcedureName", "سحب");
                    Cmd.Parameters.AddWithValue("@UserID", this.LblUserID.Text);
                    Cmd.Parameters.AddWithValue("@ProcedureValue", this.TxtGet.Text);

                    Cnn.Open();
                    Cmd.ExecuteNonQuery();
                    Cnn.Close();

                    try
                    {
                        int Tr = int.Parse(this.CBGetStorage.SelectedValue.ToString());
                        var Trshjb = context.TblStorages.Where(a=>a.StorageID == Tr).SingleOrDefault();
                        TblLog Log = new TblLog();
                        Log.UserID = int.Parse(this.LblUserID.Text);
                        Log.Discription = " سحب مبلغ  : " + this.TxtGet.Text + "من الخزنه : " + Trshjb.StorageName ;
                        Log.DateOfLog = DateTime.Now;

                        context.TblLogs.Add(Log);
                        context.SaveChanges();

                    }
                    catch (Exception)
                    {


                    }

                    this.TxtGet.Text = "";
                    this.CBGetStorage.SelectedItem = null;
                    this.PanGet.Hide();

                    MessageBox.Show("Done......", "Creative Care");
                }
                dr.Close();
                Cnn.Close();
            }
           
        }

        private void PicConSet_Click(object sender, EventArgs e)
        {
            if (this.CBSetStorage.SelectedItem == null)
            {
                MessageBox.Show("من فضلك اختار اسم الخزنه", "Creative Care");
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from TblStorages where StorageID=@StorageID ";

                cmd.Parameters.AddWithValue("@StorageID", this.CBSetStorage.SelectedValue);

                SqlDataReader dr;
                Cnn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    double Storag = double.Parse(dr["TotalMoney"].ToString());
                    double Money = double.Parse(this.TxtSet.Text);
                    double ToT = Storag + Money;
                    //////////////////////////////////////////////
                    // هنا السحب من الخزنه
                    Cnn.Close();
                    SqlCommand StorageUpdate = new SqlCommand();
                    StorageUpdate.Connection = Cnn;
                    StorageUpdate.CommandType = CommandType.Text;
                    StorageUpdate.CommandText = "update TblStorages set TotalMoney=@TotalMoney where StorageID=@StorageID";

                    StorageUpdate.Parameters.AddWithValue("@TotalMoney", ToT);
                    StorageUpdate.Parameters.AddWithValue("@StorageID", this.CBSetStorage.SelectedValue);

                    Cnn.Open();
                    StorageUpdate.ExecuteNonQuery();
                    Cnn.Close();
                    //////////////////////////////////////////////////////////////////////////////////
                    /// هنا بقى تسجيل عمليه السحب دى 
                    SqlCommand Cmd = new SqlCommand();
                    Cmd.Connection = Cnn;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "AddNewProcedure";


                    Cmd.Parameters.AddWithValue("@StorageID", this.CBSetStorage.SelectedValue);
                    Cmd.Parameters.AddWithValue("@ProcedureDate", DateTime.Now.ToString("yyyy-MM-dd"));
                    Cmd.Parameters.AddWithValue("@ProcedureName", "إيداع");
                    Cmd.Parameters.AddWithValue("@UserID", this.LblUserID.Text);
                    Cmd.Parameters.AddWithValue("@ProcedureValue", this.TxtSet.Text);

                    Cnn.Open();
                    Cmd.ExecuteNonQuery();
                    Cnn.Close();

                    try
                    {
                        int Tr = int.Parse(this.CBSetStorage.SelectedValue.ToString());
                        var Trshjb = context.TblStorages.Where(a => a.StorageID == Tr).SingleOrDefault();
                        TblLog Log = new TblLog();
                        Log.UserID = int.Parse(this.LblUserID.Text);
                        Log.Discription = " إيداع مبلغ  : " + this.TxtSet.Text + "الى الخزنه : " + Trshjb.StorageName;
                        Log.DateOfLog = DateTime.Now;

                        context.TblLogs.Add(Log);
                        context.SaveChanges();

                    }
                    catch (Exception)
                    {


                    }

                    this.TxtSet.Text = "";
                    this.CBSetStorage.SelectedItem = null;
                    this.PanSet.Hide();

                    MessageBox.Show("Done......", "Creative Care");
                }
                dr.Close();
                Cnn.Close();
            }
        }
        // هنا التحويل من خزنه لخزنه
        private void PicConConvert_Click(object sender, EventArgs e)
        {
            if (this.CBFromStorage.SelectedItem == null || this.CBToStorage.SelectedItem == null)
            {
                MessageBox.Show("من فضلك اختار اسم الخزنه", "Creative Care");
            }
            else
            {
                // 1
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from TblStorages where StorageID=@StorageID ";

                cmd.Parameters.AddWithValue("@StorageID", this.CBFromStorage.SelectedValue);

                SqlDataReader dr;
                Cnn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    double Storag = double.Parse(dr["TotalMoney"].ToString());
                    double Money = double.Parse(this.TxtConValue.Text);
                    double ToT = Storag - Money;
                    //////////////////////////////////////////////
                    // هنا السحب من الخزنه
                    Cnn.Close();
                    SqlCommand StorageUpdate = new SqlCommand();
                    StorageUpdate.Connection = Cnn;
                    StorageUpdate.CommandType = CommandType.Text;
                    StorageUpdate.CommandText = "update TblStorages set TotalMoney=@TotalMoney where StorageID=@StorageID";

                    StorageUpdate.Parameters.AddWithValue("@TotalMoney", ToT);
                    StorageUpdate.Parameters.AddWithValue("@StorageID", this.CBFromStorage.SelectedValue);

                    Cnn.Open();
                    StorageUpdate.ExecuteNonQuery();
                    Cnn.Close();
                    //////////////////////////////////////////////////////////////////////////////////
                    /// هنا بقى تسجيل عمليه السحب دى 
                    SqlCommand Cmd = new SqlCommand();
                    Cmd.Connection = Cnn;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "AddNewProcedure";


                    Cmd.Parameters.AddWithValue("@StorageID", this.CBFromStorage.SelectedValue);
                    Cmd.Parameters.AddWithValue("@ProcedureDate", DateTime.Now.ToString("yyyy-MM-dd"));
                    Cmd.Parameters.AddWithValue("@ProcedureName", "سحب");
                    Cmd.Parameters.AddWithValue("@UserID", this.LblUserID.Text);
                    Cmd.Parameters.AddWithValue("@ProcedureValue", this.TxtConValue.Text);

                    Cnn.Open();
                    Cmd.ExecuteNonQuery();
                    Cnn.Close();
                  
                   // this.PanGet.Hide();

                 
                }
                dr.Close();
                Cnn.Close();
                ////////////////////////////////////////////////////////////////
                //2
                SqlCommand Select = new SqlCommand();
                Select.Connection = Cnn;
                Select.CommandType = CommandType.Text;
                Select.CommandText = "select * from TblStorages where StorageID=@StorageID ";

                Select.Parameters.AddWithValue("@StorageID", this.CBToStorage.SelectedValue);

                SqlDataReader DR;
                Cnn.Open();
                DR = Select.ExecuteReader();
                if (DR.Read())
                {
                    
                    double Storag = double.Parse(DR["TotalMoney"].ToString());
                    double Money = double.Parse(this.TxtConValue.Text);
                    double ToT = Storag + Money;
                    //////////////////////////////////////////////
                    // هنا السحب من الخزنه
                    Cnn.Close();
                    SqlCommand StoragUpdate = new SqlCommand();
                    StoragUpdate.Connection = Cnn;
                    StoragUpdate.CommandType = CommandType.Text;
                    StoragUpdate.CommandText = "update TblStorages set TotalMoney=@TotalMoney where StorageID=@StorageID";

                    StoragUpdate.Parameters.AddWithValue("@TotalMoney", ToT);
                    StoragUpdate.Parameters.AddWithValue("@StorageID", this.CBToStorage.SelectedValue);

                    Cnn.Open();
                    StoragUpdate.ExecuteNonQuery();
                    Cnn.Close();
                    //////////////////////////////////////////////////////////////////////////////////
                    /// هنا بقى تسجيل عمليه السحب دى 
                    SqlCommand Cmd2 = new SqlCommand();
                    Cmd2.Connection = Cnn;
                    Cmd2.CommandType = CommandType.StoredProcedure;
                    Cmd2.CommandText = "AddNewProcedure";


                    Cmd2.Parameters.AddWithValue("@StorageID", this.CBToStorage.SelectedValue);
                    Cmd2.Parameters.AddWithValue("@ProcedureDate", DateTime.Now.ToString("yyyy-MM-dd"));
                    Cmd2.Parameters.AddWithValue("@ProcedureName", "إيداع");
                    Cmd2.Parameters.AddWithValue("@UserID", this.LblUserID.Text);
                    Cmd2.Parameters.AddWithValue("@ProcedureValue", this.TxtConValue.Text);

                    Cnn.Open();
                    Cmd2.ExecuteNonQuery();
                    Cnn.Close();
                    this.TxtConValue.Text = "";
                    this.CBToStorage.SelectedItem = null;
                    this.CBFromStorage.SelectedItem = null;
                    //this.PanSet.Hide();

                   
                }
                DR.Close();
                Cnn.Close();
                MessageBox.Show("Done......", "Creative Care");
                this.PanConvert.Hide();
            }
        }

        private void pIcAllReport_Click(object sender, EventArgs e)
        {
            this.PanConAndSet.Hide();
            this.PanReport.Hide();
            this.PanSetGet.Hide();
            this.PanAllreport.Show();
            this.LoadAllSReport();
        }

        private void pIcAllReport_MouseHover(object sender, EventArgs e)
        {
            this.LblAllreport.Show();
        }

        private void pIcAllReport_MouseLeave(object sender, EventArgs e)
        {
            this.LblAllreport.Hide();
        }
        // هنا بقى هايعمل بحث ب الخزنه بس او بعمليه بس او بيهم الاثنين 

        private void CBAllStorage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cnn.Close();
            this.GVAllReport.Rows.Clear();
            this.LblTotalS.Text = "";
            if (this.CBAllProces.SelectedItem !=null)
            {

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from ShowStorageActions where StorageID=@StorageID and SActionID=@SActionID order by SPDate desc ";

                Cmd.Parameters.AddWithValue("@StorageID", this.CBAllStorage.SelectedValue);
                Cmd.Parameters.AddWithValue("@SActionID", this.CBAllProces.SelectedValue);


                SqlDataReader dr;
                Cnn.Open();
                dr = Cmd.ExecuteReader();

                while (dr.Read())
                {
                    this.GVAllReport.Rows.Add(dr["StorageName"].ToString(), dr["SActionName"].ToString(), dr["SPMoney"].ToString(), dr["SPDate"].ToString());

                }
                dr.Close();
                Cnn.Close();
            }
            else
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from ShowStorageActions where StorageID=@StorageID  order by SPDate desc ";

                Cmd.Parameters.AddWithValue("@StorageID", this.CBAllStorage.SelectedValue);


                SqlDataReader dr;
                Cnn.Open();
                dr = Cmd.ExecuteReader();

                while (dr.Read())
                {
                    this.GVAllReport.Rows.Add(dr["StorageName"].ToString(), dr["SActionName"].ToString(), dr["SPMoney"].ToString(), dr["SPDate"].ToString());

                }
                dr.Close();
                Cnn.Close();

            }
        }

        private void CBAllProces_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cnn.Close();
            this.GVAllReport.Rows.Clear();
            this.LblTotalS.Text = "";
            if (this.CBAllStorage.SelectedItem != null)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from ShowStorageActions where StorageID=@StorageID and SActionID=@SActionID order by SPDate desc ";

                Cmd.Parameters.AddWithValue("@StorageID", this.CBAllStorage.SelectedValue);
                Cmd.Parameters.AddWithValue("@SActionID", this.CBAllProces.SelectedValue);


                SqlDataReader dr;
                Cnn.Open();
                dr = Cmd.ExecuteReader();

                while (dr.Read())
                {
                    this.GVAllReport.Rows.Add(dr["StorageName"].ToString(), dr["SActionName"].ToString(), dr["SPMoney"].ToString(), dr["SPDate"].ToString());

                }
                dr.Close();
                Cnn.Close();
            }
            else
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from ShowStorageActions where  SActionID=@SActionID order by SPDate desc ";

                Cmd.Parameters.AddWithValue("@SActionID", this.CBAllProces.SelectedValue);


                SqlDataReader dr;
                Cnn.Open();
                dr = Cmd.ExecuteReader();

                while (dr.Read())
                {
                    this.GVAllReport.Rows.Add(dr["StorageName"].ToString(), dr["SActionName"].ToString(), dr["SPMoney"].ToString(), dr["SPDate"].ToString());

                }
                dr.Close();
                Cnn.Close();
            }
        }
        // هنا علشان البحث ب التاريخ
        private void pictureBox1_Click(object sender, EventArgs e)
        {
             Cnn.Close();
            this.GVAllReport.Rows.Clear();
            this.LblTotalS.Text = "";
            if (this.CBAllProces.SelectedItem !=null && this.CBAllStorage.SelectedItem !=null)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from ShowStorageActions where StorageID=@StorageID and SActionID=@SActionID and SPDate BETWEEN @from and  @to  order by SPDate desc ";

                Cmd.Parameters.AddWithValue("@StorageID", this.CBAllStorage.SelectedValue);
                Cmd.Parameters.AddWithValue("@SActionID", this.CBAllProces.SelectedValue);
                Cmd.Parameters.AddWithValue("@from", this.DTB1.Value.ToString("yyyy-MM-dd"));
                Cmd.Parameters.AddWithValue("@to", this.DTB2.Value.ToString("yyyy-MM-dd"));


                SqlDataReader dr;
                Cnn.Open();
                dr = Cmd.ExecuteReader();

                while (dr.Read())
                {
                    this.GVAllReport.Rows.Add(dr["StorageName"].ToString(), dr["SActionName"].ToString(), dr["SPMoney"].ToString(), dr["SPDate"].ToString());

                }
                dr.Close();
                Cnn.Close();
            }
            else if (this.CBAllProces.SelectedItem !=null && this.CBAllStorage.SelectedItem ==null)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from ShowStorageActions where SActionID=@SActionID and SPDate BETWEEN @from and  @to  order by SPDate desc ";

                Cmd.Parameters.AddWithValue("@SActionID", this.CBAllProces.SelectedValue);
                Cmd.Parameters.AddWithValue("@from", this.DTB1.Value.ToString("yyyy-MM-dd"));
                Cmd.Parameters.AddWithValue("@to", this.DTB2.Value.ToString("yyyy-MM-dd"));


                SqlDataReader dr;
                Cnn.Open();
                dr = Cmd.ExecuteReader();

                while (dr.Read())
                {
                    this.GVAllReport.Rows.Add(dr["StorageName"].ToString(), dr["SActionName"].ToString(), dr["SPMoney"].ToString(), dr["SPDate"].ToString());

                }
                dr.Close();
                Cnn.Close();
            }
            else
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from ShowStorageActions where SPDate BETWEEN @from and  @to  order by SPDate desc ";

              
                Cmd.Parameters.AddWithValue("@from", this.DTB1.Value.ToString("yyyy-MM-dd"));
                Cmd.Parameters.AddWithValue("@to", this.DTB2.Value.ToString("yyyy-MM-dd"));


                SqlDataReader dr;
                Cnn.Open();
                dr = Cmd.ExecuteReader();

                while (dr.Read())
                {
                    this.GVAllReport.Rows.Add(dr["StorageName"].ToString(), dr["SActionName"].ToString(), dr["SPMoney"].ToString(), dr["SPDate"].ToString());

                }
                dr.Close();
                Cnn.Close();
            }
        }

        private void GVAllReport_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            double Bob = 0;
            for (int i = 0; i < GVAllReport.Rows.Count; ++i)
            {
                Bob += double.Parse(GVAllReport.Rows[i].Cells["CLTotal"].Value.ToString());
            }
            this.LblTotalS.Text = Bob.ToString();
        }
    }
}

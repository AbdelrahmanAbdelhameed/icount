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
    public partial class NoteBook : Form
    {
        //  SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public NoteBook(int ID)
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
        // //////////////////////////////////////
        // Load Provider for add new 
        private void LoadProviders()
        {

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProviders ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblProviders");
            CbNewProvideor.DisplayMember = "ProviderName";
            CbNewProvideor.ValueMember = "ProviderID";
            CbNewProvideor.DataSource = ds.Tables["TblProviders"];
            CbNewProvideor.SelectedItem = null;
            Cnn.Close();

            ///////////////////////////////////////////
            SqlCommand Prov = new SqlCommand();
            Prov.Connection = Cnn;
            Prov.CommandType = CommandType.Text;
            Prov.CommandText = "select * from TblProviders ";

            SqlDataAdapter DA = new SqlDataAdapter(Prov);
            Cnn.Open();
            DataSet DS = new DataSet();
            DA.Fill(DS, "TblProviders");
            CBEditProvider.DisplayMember = "ProviderName";
            CBEditProvider.ValueMember = "ProviderID";
            CBEditProvider.DataSource = DS.Tables["TblProviders"];
            CBEditProvider.SelectedItem = null;
            Cnn.Close();
            
        }
        // /////////////////////////////////////////////////////////////
        // //////////////////////////////////////
        // Load Day for new
        private void LoadNewDay()
        {

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblWeek ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblWeek");
            CBNewDay.DisplayMember = "WeekDayN";
            CBNewDay.ValueMember = "WeekDayID";
            CBNewDay.DataSource = ds.Tables["TblWeek"];
            CBNewDay.SelectedItem = null;
            Cnn.Close();
            //////////////////////////////////////
            SqlCommand Prov = new SqlCommand();
            Prov.Connection = Cnn;
            Prov.CommandType = CommandType.Text;
            Prov.CommandText = "select * from TblWeek ";

            SqlDataAdapter DA = new SqlDataAdapter(Prov);
            Cnn.Open();
            DataSet DS = new DataSet();
            DA.Fill(DS, "TblWeek");
            CbEditDay.DisplayMember = "WeekDayN";
            CbEditDay.ValueMember = "WeekDayID";
            CbEditDay.DataSource = DS.Tables["TblWeek"];
            CbEditDay.SelectedItem = null;
            Cnn.Close();

        }
        // ///////////////////////////////////////////////////////
        ////search and show providers
        private void SearchAndShowProviders()
        {
            // day

            DayOfWeek TheDAy = DateTime.Now.DayOfWeek;

            // هنا بعرض الناس اللى عليها الدور النهارده

            this.GVShowProviders.Rows.Clear();

            // in case 1 
            if (TheDAy.ToString() == DayOfWeek.Saturday.ToString())
            {
                //dr["WeekDayN"].ToString() == "السبت"
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from ShowNotForProvidersPay where WeekDayID=@WeekDayID ";

                Cmd.Parameters.AddWithValue("@WeekDayID", "1");

                SqlDataReader dr;
                Cnn.Open();
                dr = Cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.GVShowProviders.Rows.Add(dr["ProviderName"].ToString(), dr["CompanyName"].ToString(), dr["WeekDayN"].ToString(), dr["NoteMoney"].ToString(), dr["ProviderID"].ToString());

                }
                dr.Close();
                Cnn.Close();

            }
                //case 2
            else if (TheDAy.ToString() == DayOfWeek.Sunday.ToString())
            {
                // dr["WeekDayN"].ToString() == "الاحد"
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from ShowNotForProvidersPay where WeekDayID=@WeekDayID ";

                Cmd.Parameters.AddWithValue("@WeekDayID", "2");

                SqlDataReader dr;
                Cnn.Open();
                dr = Cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.GVShowProviders.Rows.Add(dr["ProviderName"].ToString(), dr["CompanyName"].ToString(), dr["WeekDayN"].ToString(), dr["NoteMoney"].ToString(), dr["ProviderID"].ToString());
                }
                dr.Close();
                Cnn.Close();

            }
                //case 3 
            else if (TheDAy.ToString() == DayOfWeek.Monday.ToString())
            {
                //dr["WeekDayN"].ToString() == "الاثنين"
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from ShowNotForProvidersPay where WeekDayID=@WeekDayID ";

                Cmd.Parameters.AddWithValue("@WeekDayID", "3");

                SqlDataReader dr;
                Cnn.Open();
                dr = Cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.GVShowProviders.Rows.Add(dr["ProviderName"].ToString(), dr["CompanyName"].ToString(), dr["WeekDayN"].ToString(), dr["NoteMoney"].ToString(), dr["ProviderID"].ToString());
                }
                dr.Close();
                Cnn.Close();

            }
                //case 4 
            else if (TheDAy.ToString() == DayOfWeek.Tuesday.ToString())
            {
                //dr["WeekDayN"].ToString() == "الثلاثاء"
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from ShowNotForProvidersPay where WeekDayID=@WeekDayID ";

                Cmd.Parameters.AddWithValue("@WeekDayID", "4");

                SqlDataReader dr;
                Cnn.Open();
                dr = Cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.GVShowProviders.Rows.Add(dr["ProviderName"].ToString(), dr["CompanyName"].ToString(), dr["WeekDayN"].ToString(), dr["NoteMoney"].ToString(), dr["ProviderID"].ToString());
                }
                dr.Close();
                Cnn.Close();

            }
                //case 5 
            else if (TheDAy.ToString() == DayOfWeek.Wednesday.ToString())
            {
                //dr["WeekDayN"].ToString() == "الاربعاء"
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from ShowNotForProvidersPay where WeekDayID=@WeekDayID ";

                Cmd.Parameters.AddWithValue("@WeekDayID", "5");

                SqlDataReader dr;
                Cnn.Open();
                dr = Cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.GVShowProviders.Rows.Add(dr["ProviderName"].ToString(), dr["CompanyName"].ToString(), dr["WeekDayN"].ToString(), dr["NoteMoney"].ToString(), dr["ProviderID"].ToString());
                }
                dr.Close();
                Cnn.Close();

            }
                //case 6
            else if (TheDAy.ToString() == DayOfWeek.Thursday.ToString())
            {
                //dr["WeekDayN"].ToString() == "الخميس" 
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from ShowNotForProvidersPay where WeekDayID=@WeekDayID ";

                Cmd.Parameters.AddWithValue("@WeekDayID", "6");

                SqlDataReader dr;
                Cnn.Open();
                dr = Cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.GVShowProviders.Rows.Add(dr["ProviderName"].ToString(), dr["CompanyName"].ToString(), dr["WeekDayN"].ToString(), dr["NoteMoney"].ToString(), dr["ProviderID"].ToString());
                }
                dr.Close();
                Cnn.Close();

            }
                //case 7
            else if (TheDAy.ToString() == DayOfWeek.Friday.ToString())
            {
                // dr["WeekDayN"].ToString() == "الجمعه" 
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from ShowNotForProvidersPay where WeekDayID=@WeekDayID ";

                Cmd.Parameters.AddWithValue("@WeekDayID", "7");

                SqlDataReader dr;
                Cnn.Open();
                dr = Cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.GVShowProviders.Rows.Add(dr["ProviderName"].ToString(), dr["CompanyName"].ToString(), dr["WeekDayN"].ToString(), dr["NoteMoney"].ToString(), dr["ProviderID"].ToString());
                }
                dr.Close();
                Cnn.Close();
            }

        }

        /// ////////////////////////////////
        // show all dates 
        private void ShowAllDates()
        {
            this.GVShowAll.Rows.Clear();

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from ShowNotForProvidersPay ";

            SqlDataReader dr;
            Cnn.Open();
            dr = Cmd.ExecuteReader();
            while (dr.Read())
            {
                this.GVShowAll.Rows.Add(dr["ProviderName"].ToString(), dr["CompanyName"].ToString(), dr["WeekDayN"].ToString(), dr["NoteMoney"].ToString(), dr["ProviderID"].ToString());
            }
            dr.Close();
            Cnn.Close();
        }
        //اما بقى هنا انا بجيب الخزنه 
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
            CBPayStorrage.DisplayMember = "StorageName";
            CBPayStorrage.ValueMember = "StorageID";
            CBPayStorrage.DataSource = ds.Tables["TblStorages"];
            CBPayStorrage.SelectedItem = null;
            Cnn.Close();
        }

        /// ////////////////////////////////////////////////////////////
       
        ////////
        private void NoteBook_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.LoadProviders();
            this.LoadNewDay();
            this.SearchAndShowProviders();
            this.ShowAllDates();
            this.loadStorage();
        }

        private void Pichome_Click(object sender, EventArgs e)
        {
            this.Close();
            Home HO = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            HO.Visible = true;
        }
        /// <summary>
        ///  عمليه سداد 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPay_Click(object sender, EventArgs e)
        {
            // هنا بقى هايروح يعمل عملية سداد عادى جداً 
            //try
            //{

                int rowindex = GVShowProviders.SelectedCells[0].RowIndex;

                DataGridViewRow Row = GVShowProviders.Rows[rowindex];

                if (this.CBPayStorrage.SelectedItem == null || TxtValue.Text == "")
                {
                    MessageBox.Show(" من فضلك اختار الخزنه والقيمه ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.CBPayStorrage.Focus();
                }
                else
                {
                    if (this.CBPayStorrage.SelectedValue.ToString() == "3")
                    {
                        SqlCommand Cmd = new SqlCommand();
                        Cmd.Connection = Cnn;
                        Cmd.CommandType = CommandType.Text;
                        Cmd.CommandText = "select * from TblProviders where ProviderID=@ProviderID ";

                        Cmd.Parameters.AddWithValue("@ProviderID", Row.Cells["ShProvID"].Value.ToString());

                        SqlDataReader dr;
                        Cnn.Open();
                        dr = Cmd.ExecuteReader();
                        if (dr.Read())
                        {

                            double A = double.Parse(dr["Credit"].ToString());
                            double B = double.Parse(this.TxtValue.Text);
                            double Value = A - B;
                            Cnn.Close();
                            SqlCommand InPRo = new SqlCommand();
                            InPRo.Connection = Cnn;
                            InPRo.CommandType = CommandType.StoredProcedure;
                            InPRo.CommandText = "RepayForProvidier";

                            InPRo.Parameters.AddWithValue("@ProviderID", Row.Cells["ShProvID"].Value.ToString());
                            InPRo.Parameters.AddWithValue("@PaiedDate", DateTime.Now.ToString("yyyy-MM-dd"));
                            InPRo.Parameters.AddWithValue("@TotalMoney", this.TxtValue.Text);
                            InPRo.Parameters.AddWithValue("@Credit", Value);
                            InPRo.Parameters.AddWithValue("@UserID", this.LblUserID.Text);

                            Cnn.Open();
                            InPRo.ExecuteNonQuery();
                            Cnn.Close();

                            MessageBox.Show(" Done ...... ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.TxtValue.Text = string.Empty;
                            this.CBPayStorrage.SelectedItem = null;
                            this.PanPay.Hide();
                            this.GVShowProviders.Visible = true;
                            this.SearchAndShowProviders();
                            this.ShowAllDates();

                        }

                        dr.Close();
                        Cnn.Close();

                    }
                    else
                    {

                        SqlCommand CmdStorage = new SqlCommand();
                        CmdStorage.Connection = Cnn;
                        CmdStorage.CommandType = CommandType.Text;
                        CmdStorage.CommandText = "select * from TblStorages where StorageID=@StorageID";

                        CmdStorage.Parameters.AddWithValue("@StorageID", this.CBPayStorrage.SelectedValue);

                        SqlDataReader SR;
                        Cnn.Open();
                        SR = CmdStorage.ExecuteReader();
                        //// وهنا برضه هايدفع من الخزنه حسب الطريه اللى يختارها 
                        if (SR.Read())
                        {
                            double X = double.Parse(SR["TotalMoney"].ToString());
                            double y = double.Parse(this.TxtValue.Text);
                            double W = X - y;


                            if (X < y)
                            {
                                MessageBox.Show("النقود الموجوده بالخزنه لا تكفى ل اتمام العمليه يمكك اختيار حساب خارجى او خزنه اخرى", "Creative Care");

                                this.CBPayStorrage.SelectedItem = null;
                                this.CBPayStorrage.Focus();

                            }
                            else
                            {
                                Cnn.Close();

                                SqlCommand CmdST = new SqlCommand();
                                CmdST.Connection = Cnn;
                                CmdST.CommandType = CommandType.Text;
                                CmdST.CommandText = "update TblStorages set TotalMoney=@TotalMoney   where StorageID=@StorageID";

                                CmdST.Parameters.AddWithValue("@TotalMoney", W);
                                CmdST.Parameters.AddWithValue("@StorageID", this.CBPayStorrage.SelectedValue);

                                Cnn.Open();
                                CmdST.ExecuteNonQuery();
                                Cnn.Close();

                                // //// ///////////////////////////////////////////////
                                //  // وهايروح ينفذ العمليه 
                                SqlCommand Cmd = new SqlCommand();
                                Cmd.Connection = Cnn;
                                Cmd.CommandType = CommandType.Text;
                                Cmd.CommandText = "select * from TblProviders where ProviderID=@ProviderID ";

                                Cmd.Parameters.AddWithValue("@ProviderID", Row.Cells["ShProvID"].Value.ToString());

                                SqlDataReader dr;
                                Cnn.Open();
                                dr = Cmd.ExecuteReader();
                                if (dr.Read())
                                {

                                    double A = double.Parse(dr["Credit"].ToString());
                                    double B = double.Parse(this.TxtValue.Text);
                                    double Value = A - B;
                                    Cnn.Close();
                                    SqlCommand InPRo = new SqlCommand();
                                    InPRo.Connection = Cnn;
                                    InPRo.CommandType = CommandType.StoredProcedure;
                                    InPRo.CommandText = "RepayForProvidier";

                                    InPRo.Parameters.AddWithValue("@ProviderID", Row.Cells["ShProvID"].Value.ToString());
                                    InPRo.Parameters.AddWithValue("@PaiedDate", DateTime.Now.ToString("yyyy-MM-dd"));
                                    InPRo.Parameters.AddWithValue("@TotalMoney", this.TxtValue.Text);
                                    InPRo.Parameters.AddWithValue("@Credit", Value);
                                    InPRo.Parameters.AddWithValue("@UserID", this.LblUserID.Text);

                                    Cnn.Open();
                                    InPRo.ExecuteNonQuery();
                                    Cnn.Close();

                                    MessageBox.Show(" Done ...... ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    this.TxtValue.Text = string.Empty;
                                    this.CBPayStorrage.SelectedItem = null;
                                    this.PanPay.Hide();
                                    this.GVShowProviders.Visible = true;
                                    this.SearchAndShowProviders();
                                    this.ShowAllDates();

                                }

                                dr.Close();
                                Cnn.Close();


                            }
                        }
                    }
                }


            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
            //}
        }

        private void BtnNewConfirm_Click(object sender, EventArgs e)
        {
            if (this.CBNewDay.SelectedItem == null || this.CbNewProvideor.SelectedItem == null)
            {
                MessageBox.Show("من فضلك اختار اسم المورد  و يوم الاسبوع ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //هو هنا هايروح يدور على اسم المورد لو لقاه هايقوله روح عدل 

                SqlCommand Serach = new SqlCommand();
                Serach.Connection = Cnn;
                Serach.CommandType = CommandType.Text;
                Serach.CommandText = "select * from TblNoteBook where ProviderID=@ProviderID ";

                Serach.Parameters.AddWithValue("@ProviderID",this.CbNewProvideor.SelectedValue);

                SqlDataReader dr;
                Cnn.Open();
                dr = Serach.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show(" هذا المورد موجود فى القائمه ب الفعل يمكنك تعديل اليوم والقيمه من قسم التعديل ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.CBNewDay.SelectedItem = null;
                    this.CbNewProvideor.SelectedItem = null;
                    this.TxtNewMoney.Text = "";
                }
                else
                {
                    Cnn.Close();
                    SqlCommand Cmd = new SqlCommand();
                    Cmd.Connection = Cnn;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "AddNoteToproviderPay";

                    Cmd.Parameters.AddWithValue("@ProviderID", this.CbNewProvideor.SelectedValue);
                    Cmd.Parameters.AddWithValue("@WeekDayID", this.CBNewDay.SelectedValue);
                    Cmd.Parameters.AddWithValue("@NoteMoney", this.TxtNewMoney.Text);

                    Cnn.Open();
                    Cmd.ExecuteNonQuery();
                    Cnn.Close();
                    MessageBox.Show(" Done ...... ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CBNewDay.SelectedItem = null;
                    this.CbNewProvideor.SelectedItem = null;
                    this.TxtNewMoney.Text = "";
                    this.SearchAndShowProviders();
                    this.ShowAllDates();
                }
                dr.Close();
                Cnn.Close();
                
                //////////////////////////////////////////////////////////////////////

            }

        }

        private void BtnNewConfirm_MouseHover(object sender, EventArgs e)
        {
            this.BtnNewConfirm.ImageAlign = ContentAlignment.MiddleLeft;
            this.BtnNewConfirm.Text = " تأكيد ";
        }

        private void BtnNewConfirm_MouseLeave(object sender, EventArgs e)
        {
            this.BtnNewConfirm.ImageAlign = ContentAlignment.MiddleCenter;
            this.BtnNewConfirm.Text = "";
        }

        private void CBEditProvider_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlCommand Serach = new SqlCommand();
            Serach.Connection = Cnn;
            Serach.CommandType = CommandType.Text;
            Serach.CommandText = "select * from TblNoteBook where ProviderID=@ProviderID ";

            Serach.Parameters.AddWithValue("@ProviderID", this.CBEditProvider.SelectedValue);

            SqlDataReader dr;
            Cnn.Open();
            dr = Serach.ExecuteReader();
            if (dr.Read())
            {
                this.CbEditDay.SelectedValue = dr["WeekDayID"].ToString();
                this.TxtEditMoney.Text = dr["NoteMoney"].ToString();
            }
            else
            {
                MessageBox.Show(" العميل غير مسجل فى القائمه ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.CbEditDay.SelectedItem = null;
                this.CBEditProvider.SelectedItem = null;
                this.TxtEditMoney.Text = "";

            }
            dr.Close();
            Cnn.Close();

        }

        private void CBEditProvider_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand Serach = new SqlCommand();
                Serach.Connection = Cnn;
                Serach.CommandType = CommandType.Text;
                Serach.CommandText = "select * from TblNoteBook where ProviderID=@ProviderID ";

                Serach.Parameters.AddWithValue("@ProviderID", this.CBEditProvider.SelectedValue);

                SqlDataReader dr;
                Cnn.Open();
                dr = Serach.ExecuteReader();
                if (dr.Read())
                {
                    this.CbEditDay.SelectedValue = dr["WeekDayID"].ToString();
                    this.TxtEditMoney.Text = dr["NoteMoney"].ToString();
                }
                else
                {
                    MessageBox.Show(" العميل غير مسجل فى القائمه ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.CbEditDay.SelectedItem = null;
                    this.CBEditProvider.SelectedItem = null;
                    this.TxtEditMoney.Text = "";

                }
                dr.Close();
                Cnn.Close();
            }
        }

        private void BtnEditConfirm_Click(object sender, EventArgs e)
        {
            if (this.CBEditProvider.SelectedItem == null || this.CbEditDay.SelectedItem == null)
            {
                MessageBox.Show("من فضلك اختار اسم المورد  و يوم الاسبوع ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "EditNoteBook";

                Cmd.Parameters.AddWithValue("@ProviderID", this.CBEditProvider.SelectedValue);
                Cmd.Parameters.AddWithValue("@WeekDayID", this.CbEditDay.SelectedValue);
                Cmd.Parameters.AddWithValue("@NoteMoney", this.TxtEditMoney.Text);

                Cnn.Open();
                Cmd.ExecuteNonQuery();
                Cnn.Close();
                MessageBox.Show(" Done ...... ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CbEditDay.SelectedItem = null;
                this.CBEditProvider.SelectedItem = null;
                this.TxtEditMoney.Text = "";
                this.SearchAndShowProviders();
                this.ShowAllDates();
            }
        }

        private void GVShowProviders_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.GVShowProviders.Hide();
            this.PanPay.Show();
        }
    }
}

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
using System.IO;
using System.Configuration;

namespace I_Count
{
    public partial class Home : Form
    {
        // SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");

        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);

        AccountingEntities context = new AccountingEntities();
        public Home(string DataReceived, int ID)
        {
            InitializeComponent();
            this.LblName.Text = DataReceived + ".." + "مرحباً بك  ";
            // هنا هاياخد ال ID اللى جايله 
            // يروح يدور بيه على اليوزر ويدينى ال IDبتاعه 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TblUsers where UserID=@UserID  ";

            cmd.Parameters.AddWithValue("@UserID",ID);
            
            SqlDataReader dr;
            Cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

               this.LblUserID.Text = dr["UserID"].ToString();
               this.LblPostion.Text = dr["PositionID"].ToString();

            }
            
            dr.Close();
            Cnn.Close();
        }
        //////////////////////////////////////////
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      // /////////////////////////////////////
        // time 
        private int Hr, Min, Sec;
        // ////////////////////
        /// /////////////////////////////
        /// هنا بقى هانجيب الخزنه 
        private void loadStorage()
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
        /////////////////////////////////////////
        /// /////////////////////////////
        /// هنا بقى الخزنه فى شوال  
        private void loadStorage22()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStorages where StorageID=1";

            SqlDataReader dr;
            Cnn.Open();
            dr = Cmd.ExecuteReader();
            if (dr.Read())
            {
                this.LblShowMo.Text = dr["TotalMoney"].ToString();
            }
            dr.Close();
            Cnn.Close();
           

            
          

            Cnn.Close();
        }
        ////////////////////////////////
        ///////////////////////////////////////
        // تقرير ب النواقص
        private void LoadMini()
        {
            
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select COUNT (ProductType) from  VWMinimum where Exist <= Minimum";

            Cnn.Open();

            Int32 Min = (Int32)Cmd.ExecuteScalar();
            if (Min <=0)
            {
                
            }
            else
            {
                this.Note.BalloonTipText = "لديك عدد " + "" + Min.ToString() + "" + "نواقص";
                this.Note.BalloonTipTitle = "Creative Care";
                this.Note.Visible = true;
                this.Note.ShowBalloonTip(10);
            }
          
            Cnn.Close();
          
        }
        // /////////////////////////////
        /// Notes alert 
        private void SearchAndShowProviders()
        {
            // day

            DayOfWeek TheDAy = DateTime.Now.DayOfWeek;

            // هنا بعرض الناس اللى عليها الدور النهارده

            // in case 1 
            if (TheDAy.ToString() == DayOfWeek.Saturday.ToString())
            {
                ////dr["WeekDayN"].ToString() == "السبت"
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select COUNT (ProviderID) from ShowNotForProvidersPay where WeekDayID=@WeekDayID ";

                Cmd.Parameters.AddWithValue("@WeekDayID", "1");

                Cnn.Open();

                Int32 Min = (Int32)Cmd.ExecuteScalar();

                this.NotesNot.BalloonTipText = " لديك اليوم سداد ل " + "" + Min.ToString() + "" + "مورديين";
                this.NotesNot.BalloonTipTitle = "موعد السداد للمورديين";
                this.NotesNot.Visible = true;
                this.NotesNot.ShowBalloonTip(20);

                Cnn.Close();

            }
            //case 2
            else if (TheDAy.ToString() == DayOfWeek.Sunday.ToString())
            {
                // dr["WeekDayN"].ToString() == "الاحد"
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select COUNT (ProviderID) from ShowNotForProvidersPay where WeekDayID=@WeekDayID ";

                Cmd.Parameters.AddWithValue("@WeekDayID", "2");

                Cnn.Open();

                Int32 Min = (Int32)Cmd.ExecuteScalar();

                this.NotesNot.BalloonTipText = " لديك اليوم سداد ل " + "" + Min.ToString() + "" + "مورديين";
                this.NotesNot.BalloonTipTitle = "موعد السداد للمورديين";
                this.NotesNot.Visible = true;
                this.NotesNot.ShowBalloonTip(20);

                Cnn.Close();

            }
            //case 3 
            else if (TheDAy.ToString() == DayOfWeek.Monday.ToString())
            {
                //dr["WeekDayN"].ToString() == "الاثنين"
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select COUNT (ProviderID) from ShowNotForProvidersPay where WeekDayID=@WeekDayID ";

                Cmd.Parameters.AddWithValue("@WeekDayID", "3");

                Cnn.Open();

                Int32 Min = (Int32)Cmd.ExecuteScalar();

                this.NotesNot.BalloonTipText = " لديك اليوم سداد ل " + "" + Min.ToString() + "" + "مورديين";
                this.NotesNot.BalloonTipTitle = "موعد السداد للمورديين";
                this.NotesNot.Visible = true;
                this.NotesNot.ShowBalloonTip(20);

                Cnn.Close();

            }
            //case 4 
            else if (TheDAy.ToString() == DayOfWeek.Tuesday.ToString())
            {
                //dr["WeekDayN"].ToString() == "الثلاثاء"
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select COUNT (ProviderID) from ShowNotForProvidersPay where WeekDayID=@WeekDayID ";

                Cmd.Parameters.AddWithValue("@WeekDayID", "4");

                Cnn.Open();

                Int32 Min = (Int32)Cmd.ExecuteScalar();

                this.NotesNot.BalloonTipText = " لديك اليوم سداد ل " + "" + Min.ToString() + "" + "مورديين";
                this.NotesNot.BalloonTipTitle = "موعد السداد للمورديين";
                this.NotesNot.Visible = true;
                this.NotesNot.ShowBalloonTip(20);

                Cnn.Close();

            }
            //case 5 
            else if (TheDAy.ToString() == DayOfWeek.Wednesday.ToString())
            {
                //dr["WeekDayN"].ToString() == "الاربعاء"

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select COUNT (ProviderID) from ShowNotForProvidersPay where WeekDayID=@WeekDayID ";

                Cmd.Parameters.AddWithValue("@WeekDayID", "5");

                Cnn.Open();

                Int32 Min = (Int32)Cmd.ExecuteScalar();

                this.NotesNot.BalloonTipText = " لديك اليوم سداد ل " + "" + Min.ToString() + "" + "مورديين";
                this.NotesNot.BalloonTipTitle = "موعد السداد للمورديين";
                this.NotesNot.Visible = true;
                this.NotesNot.ShowBalloonTip(20);

                Cnn.Close();
            }
            //case 6
            else if (TheDAy.ToString() == DayOfWeek.Thursday.ToString())
            {
                //dr["WeekDayN"].ToString() == "الخميس" 

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select COUNT (ProviderID) from ShowNotForProvidersPay where WeekDayID=@WeekDayID ";

                Cmd.Parameters.AddWithValue("@WeekDayID", "6");

                Cnn.Open();

                Int32 Min = (Int32)Cmd.ExecuteScalar();

                this.NotesNot.BalloonTipText = " لديك اليوم سداد ل " + "" + Min.ToString() + "" + "مورديين";
                this.NotesNot.BalloonTipTitle = "موعد السداد للمورديين";
                this.NotesNot.Visible = true;
                this.NotesNot.ShowBalloonTip(20);

                Cnn.Close();
            }
            //case 7
            else if (TheDAy.ToString() == DayOfWeek.Friday.ToString())
            {
                // dr["WeekDayN"].ToString() == "الجمعه" 
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select COUNT (ProviderID) from ShowNotForProvidersPay where WeekDayID=@WeekDayID ";

                Cmd.Parameters.AddWithValue("@WeekDayID", "7");

                Cnn.Open();

                Int32 Min = (Int32)Cmd.ExecuteScalar();

                this.NotesNot.BalloonTipText = " لديك اليوم سداد ل " + "" + Min.ToString() + "" + "مورديين";
                this.NotesNot.BalloonTipTitle = "موعد السداد للمورديين";
                this.NotesNot.Visible = true;
                this.NotesNot.ShowBalloonTip(20);

                Cnn.Close();
            }

        }
        //////////////////////
        public void AutoBackup(string path)
        {
            string Path = path + "\\Accounting" + DateTime.Now.ToShortDateString().Replace('/', '-');


            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "Backup Database Accounting to Disk='" + Path + ".bak'";



            Cnn.Open();
            Cmd.ExecuteNonQuery();
            Cnn.Close();

        }
        ////////////////////
        /// <summary>
        /// ////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Home_Load(object sender, EventArgs e)
        {
            // this.LblDate.Text = DateTime.Now.ToString()+":الوقت الان";
            //this.Location = new Point(0, 0);
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.WindowState = FormWindowState.Maximized;
            this.loadStorage();
            this.loadStorage22();
         //   this.SearchAndShowProviders();
            this.LoadMini();

            var drives = DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable);
            foreach (var item in drives)
            {
               // MessageBox.Show(item.RootDirectory.ToString());
                string curFile = item.RootDirectory.ToString() + "abdo.abdo";
               // MessageBox.Show(File.Exists(curFile) ? AutoBackup : "File does not exist.");

                if (File.Exists(curFile))
                {
                    AutoBackup(item.RootDirectory.ToString());
                }


               // Console.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");
            }

        }
        private void BtnSale_Click(object sender, EventArgs e)///////////////////Done
        {
            this.Visible = false;
            Sales SA = new Sales(int.Parse(this.LblUserID.Text));
            SA.Visible = true;
        }

        private void BtnBuy_Click(object sender, EventArgs e)/////////////////////////Done
        {
            this.Visible = false;
            Procurement PRO = new Procurement(int.Parse(this.LblUserID.Text));
            PRO.Visible = true;
        }

        private void BtnFuturesSale_Click(object sender, EventArgs e)/////////////////////////////done
        {
            this.Visible = false;
            SalesAccounting ASLACC = new SalesAccounting(int.Parse(this.LblUserID.Text));
            ASLACC.Visible = true;
        }

        private void BtnFuturesBuy_Click(object sender, EventArgs e)///////////////Done 
        {
            int ID = int.Parse(this.LblUserID.Text);

            this.Close();
            PurchasesAccounting Pro = new PurchasesAccounting(ID);
            Pro.Show();
        }

        private void BtnMinimalProducts_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(this.LblUserID.Text);
            this.Close();
            Minimum mimimum = new Minimum(ID);
            mimimum.Visible = true;
           
        }

        private void BtnExpenses_Click(object sender, EventArgs e)//////////////////////////// Done
        {
            this.Hide();
            Expenses Ex = new Expenses(int.Parse(this.LblUserID.Text));
            Ex.Show();
        }

        private void BtnNonBuyer_Click(object sender, EventArgs e)
        {
            
        }

        private void PicUsers_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                Users User = new Users(int.Parse(this.LblUserID.Text));
                this.Hide();
                User.Show();
            }
        }

        private void PicBuyBill_MouseHover(object sender, EventArgs e)
        {
            this.LblBuyBill.Show();
        }

        private void PicBuyBill_MouseLeave(object sender, EventArgs e)
        {
            //this.LblBuyBill.Hide();
        }

        private void PicSaleBill_MouseHover(object sender, EventArgs e)
        {
            this.LblSaleBill.Show();
        }

        private void PicSaleBill_MouseLeave(object sender, EventArgs e)
        {
            //this.LblSaleBill.Hide();
        }

        private void PicFutuerSales_MouseHover(object sender, EventArgs e)
        {
            this.LblFutuerSale.Show();
        }

        private void PicFutuerSales_MouseLeave(object sender, EventArgs e)
        {
            //this.LblFutuerSale.Hide();
        }

        private void PicLateBills_MouseHover(object sender, EventArgs e)
        {
            this.Lbllatebills.Show();
        }

        private void PicLateBills_MouseLeave(object sender, EventArgs e)
        {
            //this.Lbllatebills.Hide();
        }

        private void PicExpenses_MouseHover(object sender, EventArgs e)
        {
            this.LblExpenses.Show();
        }

        private void PicExpenses_MouseLeave(object sender, EventArgs e)
        {
            //this.LblExpenses.Hide();
        }

        private void PicMini_MouseHover(object sender, EventArgs e)
        {
            this.LblMini.Show();
        }

        private void PicMini_MouseLeave(object sender, EventArgs e)
        {
            //this.LblMini.Hide();
        }

        private void PicBack_MouseHover(object sender, EventArgs e)
        {
            this.LblBack.Show();
        }

        private void PicBack_MouseLeave(object sender, EventArgs e)
        {
            //this.LblBack.Hide();
        }

        private void PicReports_MouseHover(object sender, EventArgs e)
        {
            this.LblReports.Show();
        }

        private void PicReports_MouseLeave(object sender, EventArgs e)
        {
            //this.LblReports.Hide();
        }

        private void PicStore_MouseHover(object sender, EventArgs e)
        {
            this.LblStore.Show();
        }

        private void PicStore_MouseLeave(object sender, EventArgs e)
        {
            //this.LblStore.Hide();
        }

        private void PicUsers_MouseLeave(object sender, EventArgs e)
        {
            //this.LblUsers.Hide();
        }

        private void PicUsers_MouseHover(object sender, EventArgs e)
        {
            this.LblUsers.Show();
        }

        private void PicExit_MouseHover(object sender, EventArgs e)
        {
            this.LblExit.Show();
        }

        private void PicExit_MouseLeave(object sender, EventArgs e)
        {
            this.LblExit.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Hr = DateTime.Now.Hour;
            Min = DateTime.Now.Minute;
            Sec = DateTime.Now.Second;

            if (Hr > 12)
                Hr -= 12;

            if (Sec %2==0)
            {
                this.LblDate.Text = Hr + ":" + Min + ":" + Sec;
            }
            else
            {
                this.LblDate.Text = Hr + " " + Min + " " + Sec;
            }
        }

        private void PicBack_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(this.LblUserID.Text);
            this.Close();
            Mortag3 mimimum = new Mortag3(ID);
            mimimum.Visible = true;
        }

        private void PicReports_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                this.Hide();
                NewReports NR = new NewReports(int.Parse(LblUserID.Text));
                NR.Show();
            }
        }

        private void PicStore_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                this.Hide();
                Storages ST = new Storages(int.Parse(this.LblUserID.Text));
                ST.Show();
            }
        }

        private void PicAddStore_MouseHover(object sender, EventArgs e)
        {
            this.lblAddStore.Show();
        }

        private void PicAddStore_MouseLeave(object sender, EventArgs e)
        {
            this.lblAddStore.Hide();
        }

        private void PicAddStore_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                this.LblCBSTore.Hide();
                this.CBStore.Hide();
                this.PicConAdd.Show();
                this.PanStore.Show();
                this.PicConEdit.Hide();
                this.TxtStore.Text = "";
            }
        }

        private void LblHint_Click(object sender, EventArgs e)
        {
            this.LblCBSTore.Show();
            this.CBStore.Show();
            this.PicConAdd.Hide();
            this.PicConEdit.Show();
        }

        private void PicConAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "insert into TblStore (StoreName) values(@StoreName)";

                Cmd.Parameters.AddWithValue("@StoreName", this.TxtStore.Text);
             

                Cnn.Open();
                Cmd.ExecuteNonQuery();
                Cnn.Close();

             
                this.TxtStore.Text = "";
                this.PanStore.Hide();
                try
                {
                    TblLog Log = new TblLog();
                    Log.UserID = int.Parse(this.LblUserID.Text);
                    Log.Discription = " إضافة مخزن : " + this.TxtStore.Text;
                    Log.DateOfLog = DateTime.Now;

                    context.TblLogs.Add(Log);
                    context.SaveChanges();

                }
                catch (Exception)
                {


                }
                MessageBox.Show("Done.....", "Creative Care");
                this.loadStorage();
            }
            catch (Exception)
            {

                MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
            }
        }

        private void PicConEdit_Click(object sender, EventArgs e)
        {
            if (this.CBStore.SelectedItem==null)
            {
                MessageBox.Show("من فضلك اختار اسم المخزن", "Creative Care");
            }
            else
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand();
                    Cmd.Connection = Cnn;
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = " update TblStore set StoreName=@StoreName where StoreID=@StoreID";

                    Cmd.Parameters.AddWithValue("@StoreName", this.TxtStore.Text);
                    Cmd.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

                    Cnn.Open();
                    Cmd.ExecuteNonQuery();
                    Cnn.Close();

                    this.CBStore.SelectedItem = null;
                    this.TxtStore.Text = "";

                    this.PanStore.Hide();
                    try
                    {
                        TblLog Log = new TblLog();
                        Log.UserID = int.Parse(this.LblUserID.Text);
                        Log.Discription = " تعديل اسم المخزن : " + this.TxtStore.Text;
                        Log.DateOfLog = DateTime.Now;

                        context.TblLogs.Add(Log);
                        context.SaveChanges();

                    }
                    catch (Exception)
                    {


                    }
                    MessageBox.Show("Done.....", "Creative Care");
                    this.loadStorage();
                }
                catch (Exception)
                {

                    MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
                }
            }
        }

        private void CBStore_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStore where StoreID=@StoreID ";

            Cmd.Parameters.AddWithValue("@StoreID", this.CBStore.SelectedValue);

            SqlDataReader dr;
            Cnn.Open();
            dr = Cmd.ExecuteReader();
            if (dr.Read())
            {
                this.TxtStore.Text = dr["StoreName"].ToString();
               
            }
            dr.Close();
            Cnn.Close();
        }

        private void PicDead_MouseHover(object sender, EventArgs e)
        {
          //  this.LblDead.Show();
        }

        private void PicDead_MouseLeave(object sender, EventArgs e)
        {
           // this.LblDead.Hide();
        }

       

        private void LblCorrupted_Click(object sender, EventArgs e)
        {
            this.Hide();
            Corrupted CO = new Corrupted(int.Parse(this.LblUserID.Text));
            CO.Show();
        }

        private void BtnCorreputed_MouseHover(object sender, EventArgs e)
        {
            this.BtnCorreputed.ImageAlign = ContentAlignment.MiddleRight;
            this.BtnCorreputed.Text = "التالف";
        }

        private void BtnCorreputed_MouseLeave(object sender, EventArgs e)
        {
            this.BtnCorreputed.ImageAlign = ContentAlignment.MiddleCenter;
            this.BtnCorreputed.Text = "";
        }

        private void BtnProducts_MouseHover(object sender, EventArgs e)
        {
            this.BtnProducts.ImageAlign = ContentAlignment.MiddleRight;
            this.BtnProducts.Text = "البضائع  ";
        }

        private void BtnProducts_MouseLeave(object sender, EventArgs e)
        {
            this.BtnProducts.ImageAlign = ContentAlignment.MiddleCenter;
            this.BtnProducts.Text = "";
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                this.Hide();
                //Products Pro = new Products(int.Parse(this.LblUserID.Text));
                //Pro.Show();
                ICountStore S = new ICountStore(int.Parse(this.LblUserID.Text));
                S.Show();
            }
        }

        private void PicBBack_Click(object sender, EventArgs e)
        {
            this.PanStore.Hide();
        }

       

        private void Note_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Note.Visible = false;
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                int ID = int.Parse(this.LblUserID.Text);
                this.Close();
                Minimum mimimum = new Minimum(ID);
                mimimum.Visible = true;
            }
        }

        private void BtnBarcode_MouseHover(object sender, EventArgs e)
        {
            this.BtnBarcode.ImageAlign = ContentAlignment.MiddleRight;
            this.BtnBarcode.Text = "الباركود  ";
        }

        private void BtnBarcode_MouseLeave(object sender, EventArgs e)
        {
            this.BtnBarcode.ImageAlign = ContentAlignment.MiddleCenter;
            this.BtnBarcode.Text = "";
        }

        private void BtnBarcode_Click(object sender, EventArgs e)
        {
            this.Hide();
            Barcode Pro = new Barcode(int.Parse(this.LblUserID.Text));
            Pro.Show();
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            Backup BC = new Backup();
            BC.Show();
        }

        private void BtnTime_Click(object sender, EventArgs e)
        {
            this.Hide();
            NoteBook NT = new NoteBook(int.Parse(this.LblUserID.Text));
            NT.Show();
        }

        private void BtnTime_MouseHover(object sender, EventArgs e)
        {
            this.BtnTime.ImageAlign = ContentAlignment.MiddleRight;
            this.BtnTime.Text = " المواعيد ";
        }

        private void BtnTime_MouseLeave(object sender, EventArgs e)
        {
             this.BtnTime.ImageAlign = ContentAlignment.MiddleCenter;
            this.BtnTime.Text = " ";

        }

       
        private void NotesNot_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Hide();
            NoteBook NT = new NoteBook(int.Parse(this.LblUserID.Text));
            NT.Show();
        }

        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transfer Tr = new Transfer(int.Parse(this.LblUserID.Text));
            Tr.Show();
        }

        private void BtnTransfer_MouseHover(object sender, EventArgs e)
        {
            this.BtnTransfer.ImageAlign = ContentAlignment.MiddleRight;
            this.BtnTransfer.Text = " نقل ";
        }

        private void BtnTransfer_MouseLeave(object sender, EventArgs e)
        {
            this.BtnTransfer.ImageAlign = ContentAlignment.MiddleCenter;
            this.BtnTransfer.Text = " ";
        }

        private void BtnReBack_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void BtnReBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            BackReport BR = new BackReport(int.Parse(this.LblUserID.Text));
            BR.Show();
        }

        private void PicAbout_MouseHover(object sender, EventArgs e)
        {
            this.PanAbout.Show();
            this.PanAbout.BringToFront();
        }

        private void PicAbout_MouseLeave(object sender, EventArgs e)
        {
            this.PanAbout.Hide();
            this.PanAbout.SendToBack();
        }

        private void BtnBills_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                BillsEdit BE = new BillsEdit(int.Parse(this.LblUserID.Text));
                this.Hide();
                BE.Show();


            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void BtnEmp_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                Employess BE = new Employess(int.Parse(this.LblUserID.Text));
                this.Hide();
                BE.Show();


            }
        }

        private void BtnUnits_Click(object sender, EventArgs e)
        {
            UnitsManger Unit = new UnitsManger(int.Parse(this.LblUserID.Text));
            Unit.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewReports NR = new NewReports(int.Parse(LblUserID.Text));
            NR.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ICountStore S = new ICountStore(int.Parse(this.LblUserID.Text));
            S.Show();
        }

        private void مرتجعشراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(this.LblUserID.Text);
            this.Close();
            Mortag3 mimimum = new Mortag3(ID);
            mimimum.Visible = true;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void إدارةالفواتيرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                BillsEdit BE = new BillsEdit(int.Parse(this.LblUserID.Text));
                this.Hide();
                BE.Show();


            }
        }

        private void فاتورةشراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Procurement PRO = new Procurement(int.Parse(this.LblUserID.Text));
            PRO.Visible = true;
        }

        private void فاتورةبيعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Sales SA = new Sales(int.Parse(this.LblUserID.Text));
            SA.Visible = true;
        }

        private void فاتورةنقلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transfer Tr = new Transfer(int.Parse(this.LblUserID.Text));
            Tr.Show();
        }

        private void فاتورةتالفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Corrupted CO = new Corrupted(int.Parse(this.LblUserID.Text));
            CO.Show();
        }

        private void أجلبيعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SalesAccounting ASLACC = new SalesAccounting(int.Parse(this.LblUserID.Text));
            ASLACC.Visible = true;
        }

        private void أجلشراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(this.LblUserID.Text);

            this.Close();
            PurchasesAccounting Pro = new PurchasesAccounting(ID);
            Pro.Show();
        }

        private void تقريرالاجلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            BackReport BR = new BackReport(int.Parse(this.LblUserID.Text));
            BR.Show();
        }

        private void المصروفاتوالايراداتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Expenses Ex = new Expenses(int.Parse(this.LblUserID.Text));
            Ex.Show();
        }

        private void سلفةموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeDebit Em = new EmployeeDebit(int.Parse(this.LblUserID.Text));
            Em.Show();
        }

        private void النواقصToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(this.LblUserID.Text);
            this.Close();
            Minimum mimimum = new Minimum(ID);
            mimimum.Visible = true;
        }

        private void الخزنهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                this.Hide();
                Storages ST = new Storages(int.Parse(this.LblUserID.Text));
                ST.Show();
            }
        }

        private void المستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                Users User = new Users(int.Parse(this.LblUserID.Text));
                this.Hide();
                User.Show();
            }
        }

        private void الباركودToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Barcode Pro = new Barcode(int.Parse(this.LblUserID.Text));
            Pro.Show();
        }

        private void الموظفينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                Employess BE = new Employess(int.Parse(this.LblUserID.Text));
                this.Hide();
                BE.Show();


            }
        }

        private void التقاريراليوميهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                this.Hide();
                NewReports NR = new NewReports(int.Parse(LblUserID.Text));
                NR.Show();
            }
        }

        private void المخازنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                this.Hide();
                //Products Pro = new Products(int.Parse(this.LblUserID.Text));
                //Pro.Show();
                ICountStore S = new ICountStore(int.Parse(this.LblUserID.Text));
                S.Show();
            }
        }

        private void سجلالمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                LogsReport L = new LogsReport();
                L.Show();


            }
        }

        private void نسخإحتياطىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup BC = new Backup();
            BC.Show();
        }

        private void تسجيلالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void أعداداصنافبدونفاتورهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetItems Si = new SetItems(int.Parse(this.LblUserID.Text));
            Si.Show();
                 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeDebit Em = new EmployeeDebit(int.Parse(this.LblUserID.Text));
            Em.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text == "2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {
                LogsReport L = new LogsReport();
                L.Show();


            }
            
        }

        
    }
}

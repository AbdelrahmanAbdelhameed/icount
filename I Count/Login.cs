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
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Configuration;

namespace I_Count
{
    public partial class Login : Form
    {
       // SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        AccountingEntities context = new AccountingEntities();
        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);

        public Login()
        {
            InitializeComponent();
        }

        // This function does all the work
        [DllImport("Trial.dll", EntryPoint = "ReadSettingsStr", CharSet = CharSet.Ansi)]
        static extern uint InitTrial(String aKeyCode, IntPtr aHWnd);

        // Use this function to register the application when the application is running
        [DllImport("Trial.dll", EntryPoint = "DisplayRegistrationStr", CharSet = CharSet.Ansi)]
        static extern uint DisplayRegistration(String aKeyCode, IntPtr aHWnd);

        private const string kLibraryKey = "E78AFB6125CE8DEC619BEB8C39B1E09BE42A44A2EA535E5F7DDDC4BE3804B5B2CA5DF99CE9BE";

        private static void OnInit()
        {
            try
            {
                Process process = Process.GetCurrentProcess();
                InitTrial(kLibraryKey, process.MainWindowHandle);
            }
            catch (DllNotFoundException ex)
            {
                // Trial dll is missing close the application immediately.
                MessageBox.Show(ex.ToString());
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }


        private void LoadUsers()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblUsers ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Cnn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblUsers");
            TxtUserName.DisplayMember = "UserName";
            TxtUserName.ValueMember = "UserID";
            TxtUserName.DataSource = ds.Tables["TblUsers"];
            TxtUserName.SelectedItem = null;
            Cnn.Close();
        
        
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from TblUsers where UserName=@UserName and Password =@Password ";

                cmd.Parameters.AddWithValue("@UserName", this.TxtUserName.Text);
                cmd.Parameters.AddWithValue("@Password", this.TxtPassword.Text);
                SqlDataReader dr;
                Cnn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                   
                    this.Visible = false;
                    Home Ho = new Home(dr["Name"].ToString(), int.Parse(dr["UserID"].ToString()));
                    Ho.Visible = true;
                    this.Note.BalloonTipText = dr["Name"].ToString() + "" + "مرحباً بك";
                    this.Note.BalloonTipTitle = "Creative Care";
                    this.Note.Visible = true;
                    this.Note.ShowBalloonTip(10);

                    try
                    {
                        TblLog Log = new TblLog();
                        Log.UserID = int.Parse(dr["UserID"].ToString());
                        Log.Discription = " تسجيل الدخول : " + dr["Name"].ToString();
                        Log.DateOfLog = DateTime.Now;

                        context.TblLogs.Add(Log);
                        context.SaveChanges();

                    }
                    catch (Exception)
                    {


                    }

                }
                else
                {
                    
                    MessageBox.Show("User Name or Password Not Correct","Creative Care",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                dr.Close();
                Cnn.Close();
            }
            catch (Exception)
            {
                //////////  حط رقم دعم فنى هنا 
                MessageBox.Show("I Can't Find Database Keep Calm ana Call Technical Support 01118754055 ","Creative Care");

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //OnInit();
            this.LoadUsers();
            this.WindowState = FormWindowState.Maximized;
        }

        private void PINFB_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://www.facebook.com/creativecaresoft");
            Process.Start(sInfo);
        }

        private void PICTW_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://www.twitter.com/creativecare3");
            Process.Start(sInfo);
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Cnn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from TblUsers where UserName=@UserName and Password =@Password ";

                    cmd.Parameters.AddWithValue("@UserName", this.TxtUserName.Text);
                    cmd.Parameters.AddWithValue("@Password", this.TxtPassword.Text);
                    SqlDataReader dr;
                    Cnn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        this.Visible = false;
                        Home Ho = new Home(dr["Name"].ToString(), int.Parse(dr["UserID"].ToString()));
                        Ho.Visible = true;
                        this.Note.BalloonTipText = dr["Name"].ToString() + "" + "مرحباً بك";
                        this.Note.BalloonTipTitle = "Creative Care";
                        this.Note.Visible = true;
                        this.Note.ShowBalloonTip(10);

                        try
                        {
                            TblLog Log = new TblLog();
                            Log.UserID = int.Parse(dr["UserID"].ToString());
                            Log.Discription = " تسجيل الدخول : " + dr["Name"].ToString();
                            Log.DateOfLog = DateTime.Now;

                            context.TblLogs.Add(Log);
                            context.SaveChanges();

                        }
                        catch (Exception)
                        {


                        }
                    }
                    else
                    {

                        MessageBox.Show("User Name or Password Not Correct", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dr.Close();
                    Cnn.Close();
                }
                catch (Exception)
                {
                    //////////  حط رقم دعم فنى هنا 
                    MessageBox.Show("I Can't Find Database Keep Calm ana Call Technical Support 01118754055 ", "Creative Care");

                }
            }
        }
    }
}

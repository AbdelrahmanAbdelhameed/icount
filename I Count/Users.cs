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
    public partial class Users : Form
    {
       // SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        AccountingEntities context = new AccountingEntities();
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public Users(int ID)
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
        // ///////////////////////////////////////////////////////
        // ///////////////////////////////////////////////////////
        // هنا بقى انا هاجيب  الصلاحيات

        private void LoadPosition()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblPosition ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblPosition");
            CBUsers.DisplayMember = "PositionName";
            CBUsers.ValueMember = "PositionID";
            CBUsers.DataSource = ds.Tables["TblPosition"];
            CBUsers.SelectedItem = null;
            Con.Close();
        
        }
        /////////////////////////////////////////////////////
        //// وهنا بجيب الاسماء
        private void LoadNames()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblUsers ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblUsers");
            CbUserName.DisplayMember = "UserName";
            CbUserName.ValueMember = "UserID";
            CbUserName.DataSource = ds.Tables["TblUsers"];
            CbUserName.SelectedItem = null;
            Con.Close();
        
        }

       // //////////////////////////////////////////
        private void Users_Load(object sender, EventArgs e)
        {
            this.LoadPosition();
            this.LoadNames();
            this.WindowState = FormWindowState.Maximized;

        }

        private void BtnSale_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Sales SA = new Sales(int.Parse(this.LblUserID.Text));
            SA.Visible = true;
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Procurement PRO = new Procurement(int.Parse(this.LblUserID.Text));
            PRO.Visible = true;
        }

        private void BtnFuturesBuy_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(this.LblUserID.Text);

            this.Close();
            PurchasesAccounting Pro = new PurchasesAccounting(ID);
            Pro.Show();
        }

        private void BtnFuturesSale_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SalesAccounting ASLACC = new SalesAccounting(int.Parse(this.LblUserID.Text));
            ASLACC.Visible = true;
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home Ho = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            Ho.Show();
        }
        // هنا بقى المستخبى يبان
        private void BtnShowAdd_Click(object sender, EventArgs e)
        {
            this.LblNam.Show();
            this.LblUser.Show();
            this.LblPassword.Show();
            this.LblAuth.Show();
            this.TxtName.Show();
            this.TxtPassword.Show();
            this.TxtUserName.Show();
            this.BtnConfirm.Show();
            this.CBUsers.Show();
            this.LblPhone.Show();
            this.TxtPhone.Show();

            this.TxtName.Text = string.Empty;
            this.TxtPassword.Text = string.Empty;
            this.TxtUserName.Text = string.Empty;
            this.TxtPhone.Text = string.Empty;
            this.CBUsers.SelectedItem = null;
            this.CbUserName.Hide();
            this.BtnEdit.Hide();
            this.LabName.Hide();

        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "AddNewUser";

            Cmd.Parameters.AddWithValue("@Name",this.TxtName.Text);
            Cmd.Parameters.AddWithValue("@UserName",this.TxtUserName.Text);
            Cmd.Parameters.AddWithValue("@Password",this.TxtPassword.Text);
            Cmd.Parameters.AddWithValue("@TelephoneNumber",this.TxtPhone.Text);
            Cmd.Parameters.AddWithValue("@PositionID",this.CBUsers.SelectedValue);

            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
            try
            {
                TblLog Log = new TblLog();
                Log.UserID = int.Parse(this.LblUserID.Text);
                Log.Discription = " إضافة المستخدم : " + this.TxtName.Text;
                Log.DateOfLog = DateTime.Now;

                context.TblLogs.Add(Log);
                context.SaveChanges();

            }
            catch (Exception)
            {


            }
            MessageBox.Show("Done........","Creative Care");

            DialogResult dialogResult = MessageBox.Show("هل تريد إضافة مستخدم اخر  ", "Creative Care", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.TxtName.Text = string.Empty;
                this.TxtPassword.Text = string.Empty;
                this.TxtUserName.Text = string.Empty;
                this.TxtPhone.Text = string.Empty;
                this.CBUsers.SelectedItem = null;
            }
            else if (dialogResult == DialogResult.No)
            {
                this.LblNam.Hide();
                this.LblUser.Hide();
                this.LblPassword.Hide();
                this.LblAuth.Hide();
                this.TxtName.Hide();
                this.TxtPassword.Hide();
                this.TxtUserName.Hide();
                this.BtnConfirm.Hide();
                this.CBUsers.Hide();
                this.LblPhone.Hide();
                this.TxtPhone.Hide();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.LabName.Show();
            this.CbUserName.Show();
            this.BtnConfirm.Hide();
            this.CbUserName.SelectedItem = null;
        }

        private void CbUserName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LblNam.Show();
            this.LblUser.Show();
            this.LblPassword.Show();
            this.LblAuth.Show();
            this.TxtName.Show();
            this.TxtPassword.Show();
            this.TxtUserName.Show();
            this.BtnEdit.Show();
            this.CBUsers.Show();
            this.LblPhone.Show();
            this.TxtPhone.Show();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblUsers where UserID=@UserID";

            Cmd.Parameters.AddWithValue("@UserID", this.CbUserName.SelectedValue);

            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();
            if (dr.Read())
            {
                this.TxtName.Text = dr["Name"].ToString();
                this.TxtUserName.Text = dr["UserName"].ToString();
                this.TxtPhone.Text = dr["TelephoneNumber"].ToString();
                this.TxtPassword.Text = dr["Password"].ToString();
                this.CBUsers.SelectedValue = dr["PositionID"].ToString();

            }
            dr.Close();
            Con.Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "UpdteUser";

            Cmd.Parameters.AddWithValue("@Name", this.TxtName.Text);
            Cmd.Parameters.AddWithValue("@UserName", this.TxtUserName.Text);
            Cmd.Parameters.AddWithValue("@Password", this.TxtPassword.Text);
            Cmd.Parameters.AddWithValue("@TelephoneNumber", this.TxtPhone.Text);
            Cmd.Parameters.AddWithValue("@PositionID", this.CBUsers.SelectedValue);
            Cmd.Parameters.AddWithValue("@UserID", this.CbUserName.SelectedValue);

            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
            try
            {
                TblLog Log = new TblLog();
                Log.UserID = int.Parse(this.LblUserID.Text);
                Log.Discription = " تعديل بيانات المستخدم : " + this.TxtName.Text;
                Log.DateOfLog = DateTime.Now;

                context.TblLogs.Add(Log);
                context.SaveChanges();

            }
            catch (Exception)
            {


            }
            MessageBox.Show("Done........","Creative Care");
            this.LblNam.Hide();
            this.LblUser.Hide();
            this.LblPassword.Hide();
            this.LblAuth.Hide();
            this.TxtName.Hide();
            this.TxtPassword.Hide();
            this.TxtUserName.Hide();
            this.BtnEdit.Hide();
            this.CBUsers.Hide();
            this.LblPhone.Hide();
            this.TxtPhone.Hide();
            this.LabName.Hide();
            this.CbUserName.Hide();

            this.TxtName.Text = string.Empty;
            this.TxtPassword.Text = string.Empty;
            this.TxtUserName.Text = string.Empty;
            this.TxtPhone.Text = string.Empty;
            this.CBUsers.SelectedItem = null;
        }

        private void PicEditUser_MouseHover(object sender, EventArgs e)
        {
            this.LblEdit.Show();
        }

        private void PicEditUser_MouseLeave(object sender, EventArgs e)
        {
            this.LblEdit.Hide();
        }

        private void PicAddUser_MouseHover(object sender, EventArgs e)
        {
            this.LblAdduser.Show();
        }

        private void PicAddUser_MouseLeave(object sender, EventArgs e)
        {
            this.LblAdduser.Hide();
        }
    }
}

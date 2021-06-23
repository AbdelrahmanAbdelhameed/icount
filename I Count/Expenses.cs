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
    public partial class Expenses : Form
    {
       // SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        AccountingEntities context = new AccountingEntities();
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);

        public Expenses(int ID)
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

        private void Expenses_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.loadStorage();
        }
        // الرئيسيه
        private void BtnHome_Click(object sender, EventArgs e)/////////////// done
        {
            this.Hide();
            Home Ho = new Home(this.LblUserName.Text,int.Parse(this.LblUserID.Text));
            Ho.Show();
        }
        /// /////////////////////////////
        /// هنا بقى يا معلن هانجيب الخزنه 
        private void loadStorage()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStorages ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStorages");
            CBStore.DisplayMember = "StorageName";
            CBStore.ValueMember = "StorageID";
            CBStore.DataSource = ds.Tables["TblStorages"];
            CBStore.SelectedItem = null;

            Con.Close();
        }
        /////////////////////////////////////////
        // بعرض اضافة مصروفات
        private void BtnExpenses_Click(object sender, EventArgs e)
        {
            this.LblReason.Show();
            this.LblValue.Show();
            this.BtnAdd.Show();
            this.TxtReason.Show();
            this.TxtValue.Show();
            this.PicAddExpenses.Hide();
            this.LblStore.Show();
            this.CBStore.Show();
            this.PicAddIncome.Hide();
            this.PicBack.Show();
        }
        ////////////////////////////////////////////
        // // /// /// // // هنا بقى بيعمل اضافة مصروفات جديده 

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {


                if (this.CBStore.SelectedItem == null)
                {
                    MessageBox.Show("من فضلك اختار الخزنة ", "Creative Care");
                }
                else
                {

                    ////////////////////////////////////// هنا انا بعمل خصم من الخزنه
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from TblStorages where StorageID=@StorageID ";

                    cmd.Parameters.AddWithValue("@StorageID", this.CBStore.SelectedValue);

                    SqlDataReader dr;
                    Con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        double Storag = double.Parse(dr["TotalMoney"].ToString());
                        double Money = double.Parse(this.TxtValue.Text);
                        double ToT = Storag - Money;
                        //////////////////////////////////////////////
                        Con.Close();
                        SqlCommand Cmd = new SqlCommand();
                        Cmd.Connection = Con;
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "AddExpenses";

                        Cmd.Parameters.AddWithValue("@ExpensesReason", this.TxtReason.Text);
                        Cmd.Parameters.AddWithValue("@ExpensesDate", DateTime.Now.ToString("yyyy-MM-dd"));
                        Cmd.Parameters.AddWithValue("@Money", this.TxtValue.Text);
                        Cmd.Parameters.AddWithValue("@StorageID", this.CBStore.SelectedValue);
                        Cmd.Parameters.AddWithValue("@Moneytot", ToT);
                        Cmd.Parameters.AddWithValue("@UserID", this.LblUserID.Text);
                        Con.Open();
                        Cmd.ExecuteNonQuery();
                        Con.Close();

                        try
                        {
                            TblLog Log = new TblLog();
                            Log.UserID = int.Parse(this.LblUserID.Text);
                            Log.Discription = " تسجيل مصروفات ببيان  : " + this.TxtReason.Text;
                            Log.DateOfLog = DateTime.Now;

                            context.TblLogs.Add(Log);
                            context.SaveChanges();

                        }
                        catch (Exception)
                        {


                        }
                        MessageBox.Show("Done.........", "Creative Care");
                        /////////////////////////////////////////////////
                        // هنا بقى يابرنس بيضيف العمليات بتاعت الخزنه ك مصروفات للقصر  برضه
                        SqlCommand SAction = new SqlCommand();
                        SAction.Connection = Con;
                        SAction.CommandType = CommandType.StoredProcedure;
                        SAction.CommandText = "AddStorageAction";

                        SAction.Parameters.AddWithValue("@SActionID", "4");
                        SAction.Parameters.AddWithValue("@SPDate", DateTime.Now.ToString("yyyy-MM-dd"));
                        SAction.Parameters.AddWithValue("@SPMoney", this.TxtValue.Text);
                        SAction.Parameters.AddWithValue("@StorageID", this.CBStore.SelectedValue);

                        Con.Open();
                        SAction.ExecuteNonQuery();
                        Con.Close();

                        ///////////////////////////////////////
                        DialogResult dialogResult = MessageBox.Show("هل تريد ادخال مصروفات اخرى ", "Creative Care ", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.TxtReason.Text = string.Empty;
                            this.TxtValue.Text = string.Empty;
                            this.CBStore.SelectedItem = null;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            this.LblReason.Hide();
                            this.LblValue.Hide();
                            this.BtnAdd.Hide();
                            this.TxtReason.Hide();
                            this.TxtValue.Hide();
                            this.PicAddExpenses.Show();
                            this.LblStore.Hide();
                            this.CBStore.Hide();
                            this.PicAddIncome.Show();
                            this.CBStore.SelectedItem = null;
                            this.PicBack.Hide();
                            this.TxtReason.Text = string.Empty;
                            this.TxtValue.Text = string.Empty;
                            this.CBStore.SelectedItem = null;

                        }
                    }
                    dr.Close();
                    Con.Close();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
            }
        }
        ///////////////////////////////////////////////////////////////////////
        // // هنا زر البحث "اضغط هوون "ايوه :) ......
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {


                this.GVExpenses.Show();
                this.GVExpenses.Rows.Clear();

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from ExpensesReport where   ExpensesDate  BETWEEN @from and  @to  ";
             

                //where  (month(ExpensesDate) = month(@from)  AND month(ExpensesDate) =month(@to)) and (Day(ExpensesDate) >= Day(@from)  AND Day(ExpensesDate) <=Day(@to))and (year(ExpensesDate) = year(@from)  AND year(ExpensesDate)=year(@to))
                Cmd.Parameters.AddWithValue("@from", this.DTB1.Value.ToString("yyyy-MM-dd"));
                Cmd.Parameters.AddWithValue("@to", this.DTB2.Value.ToString("yyyy-MM-dd"));


                SqlDataReader dr;
                Con.Open();
                dr = Cmd.ExecuteReader();

                while (dr.Read())
                {
                    this.GVExpenses.Rows.Add(dr["Money"].ToString(), dr["ExpensesReason"].ToString(), dr["ExpensesDate"].ToString(), dr["Name"].ToString());

                }
                dr.Close();
                Con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
            }
        }

        private void PicAddExpenses_MouseLeave(object sender, EventArgs e)
        {
            this.LblExpenses.Hide();

        }

        private void PicAddExpenses_MouseHover(object sender, EventArgs e)
        {
            this.LblExpenses.Show();
        }

        private void PicAddIncome_MouseHover(object sender, EventArgs e)
        {
            this.LblIncome.Show();
        }

        private void PicAddIncome_MouseLeave(object sender, EventArgs e)
        {
            this.LblIncome.Hide();
        }
        // show add in come 
        private void PicAddIncome_Click(object sender, EventArgs e)
        {
            this.LblReason.Show();
            this.LblValue.Show();
            this.BtnAdd.Hide();
            this.TxtReason.Show();
            this.TxtValue.Show();
            this.PicAddExpenses.Hide();
            this.PicAddIncome.Hide();
            this.BtnAddIncome.Show();
            this.LblStore.Show();
            this.CBStore.Show();
            this.PicBack.Show();
        }
        // add income 
        private void BtnAddIncome_Click(object sender, EventArgs e)
        {
            try
            {


                if (this.CBStore.SelectedItem == null)
                {
                    MessageBox.Show("من فضلك اختار الخزنة ", "Creative Care");
                }
                else
                {

                    ////////////////////////////////////// هنا انا بعمل خصم من الخزنه
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from TblStorages where StorageID=@StorageID ";

                    cmd.Parameters.AddWithValue("@StorageID", this.CBStore.SelectedValue);

                    SqlDataReader dr;
                    Con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        double Storag = double.Parse(dr["TotalMoney"].ToString());
                        double Money = double.Parse(this.TxtValue.Text);
                        double ToT = Storag + Money;
                        //////////////////////////////////////////////
                        Con.Close();
                        SqlCommand Cmd = new SqlCommand();
                        Cmd.Connection = Con;
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "Addincome";

                        Cmd.Parameters.AddWithValue("@IncomeValue", this.TxtValue.Text);
                        Cmd.Parameters.AddWithValue("@IncomeDate", DateTime.Now.ToString("yyyy-MM-dd"));
                        Cmd.Parameters.AddWithValue("@IncomeResourc", this.TxtReason.Text);
                        Cmd.Parameters.AddWithValue("@Money", ToT);
                        Cmd.Parameters.AddWithValue("@StorageID", this.CBStore.SelectedValue);
                        Cmd.Parameters.AddWithValue("@UserID", this.LblUserID.Text);


                        Con.Open();
                        Cmd.ExecuteNonQuery();
                        Con.Close();

                        try
                        {
                            TblLog Log = new TblLog();
                            Log.UserID = int.Parse(this.LblUserID.Text);
                            Log.Discription = " تسجيل إيرادات ببيان  : " + this.TxtValue.Text;
                            Log.DateOfLog = DateTime.Now;

                            context.TblLogs.Add(Log);
                            context.SaveChanges();

                        }
                        catch (Exception)
                        {


                        }
                        MessageBox.Show("تمت الاضافه", "Creative Care");
                        /////////////////////////////////////////////////
                        // هنا بقى يابرنس بيضيف العمليات بتاعت الخزنه ك شراء للقصر  برضه
                        SqlCommand SAction = new SqlCommand();
                        SAction.Connection = Con;
                        SAction.CommandType = CommandType.StoredProcedure;
                        SAction.CommandText = "AddStorageAction";

                        SAction.Parameters.AddWithValue("@SActionID", "5");
                        SAction.Parameters.AddWithValue("@SPDate", DateTime.Now.ToString("yyyy-MM-dd"));
                        SAction.Parameters.AddWithValue("@SPMoney", this.TxtValue.Text);
                        SAction.Parameters.AddWithValue("@StorageID", this.CBStore.SelectedValue);

                        Con.Open();
                        SAction.ExecuteNonQuery();
                        Con.Close();

                        ///////////////////////////////////////
                        DialogResult dialogResult = MessageBox.Show("هل تريد ادخال إيرادات اخرى ", "Creative Care", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.TxtValue.Text = string.Empty;
                            this.TxtReason.Text = string.Empty;
                            this.CBStore.SelectedItem = null;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            this.LblReason.Hide();
                            this.LblValue.Hide();
                            this.BtnAdd.Hide();
                            this.TxtReason.Hide();
                            this.TxtValue.Hide();
                            this.PicAddExpenses.Show();
                            this.LblStore.Hide();
                            this.CBStore.Hide();
                            this.PicAddIncome.Show();
                            this.BtnAddIncome.Hide();
                            this.CBStore.SelectedItem = null;
                            this.PicBack.Hide();
                            this.TxtValue.Text = string.Empty;
                            this.TxtReason.Text = string.Empty;
                            this.CBStore.SelectedItem = null;
                        }
                    }
                    dr.Close();
                    Con.Close();

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
            }
        }

        private void PicSeExpenses_MouseHover(object sender, EventArgs e)
        {
            this.LblSeExpenses.Show();
        }

        private void PicSeExpenses_MouseLeave(object sender, EventArgs e)
        {
            this.LblSeExpenses.Hide();
        }

        private void PicSeIncome_MouseHover(object sender, EventArgs e)
        {
            this.LblSeIncom.Show();
        }

        private void PicSeIncome_MouseLeave(object sender, EventArgs e)
        {
            this.LblSeIncom.Hide();
        }
        // search in income and show in gridview 
        private void BtnSearchIncome_Click(object sender, EventArgs e)
        {

            try
            {

                this.GVExpenses.Show();
                this.GVExpenses.Rows.Clear();

                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from IncomeReport where   IncomeDate  BETWEEN @from and  @to ";

                //(month(IncomeDate) = month(@from)  AND month(IncomeDate) =month(@to)) and (Day(IncomeDate) >= Day(@from)  AND Day(IncomeDate) <=Day(@to))and (year(IncomeDate) = year(@from)  AND year(IncomeDate)=year(@to))

                Cmd.Parameters.AddWithValue("@from", this.DTB1.Value.ToString("yyyy-MM-dd"));
                Cmd.Parameters.AddWithValue("@to", this.DTB2.Value.ToString("yyyy-MM-dd"));


                SqlDataReader dr;
                Con.Open();
                dr = Cmd.ExecuteReader();

                while (dr.Read())
                {
                    this.GVExpenses.Rows.Add(dr["IncomeValue"].ToString(), dr["IncomeResourc"].ToString(), dr["IncomeDate"].ToString(), dr["Name"].ToString());

                }
                dr.Close();
                Con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Error Please Keep Calm ana Call Technical Support 01118754055", "Creative Care");
            }
        }
        // show search in expenses
        private void PicSeExpenses_Click(object sender, EventArgs e)
        {
            this.GVExpenses.Rows.Clear();
            this.BtnSearch.Show();
            this.BtnSearchIncome.Hide();
            this.PanDate.Show();
        }
        // show search for in income
        private void PicSeIncome_Click(object sender, EventArgs e)
        {
            if (this.LblPostion.Text=="2")
            {
                MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            }
            else
            {

            this.GVExpenses.Rows.Clear();
            this.BtnSearch.Hide();
            this.BtnSearchIncome.Show();
            this.PanDate.Show();

            }
        }

        private void PicBack_Click(object sender, EventArgs e)
        {
            this.LblReason.Hide();
            this.LblValue.Hide();
            this.BtnAdd.Hide();
            this.TxtReason.Hide();
            this.TxtValue.Hide();
            this.PicAddExpenses.Hide();
            this.PicAddIncome.Hide();
            this.BtnAddIncome.Hide();
            this.LblStore.Hide();
            this.CBStore.Hide();
            this.PicBack.Hide();
            this.PicAddExpenses.Show();
            this.PicAddIncome.Show();
        }
    }
}

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
    public partial class Employess : Form
    {
        //  SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");

        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        AccountingEntities context = new AccountingEntities();

        public Employess(int ID)
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
        /// <summary>
        /////////////////////////////////////////////////// وهنا انا بجيب الخزنه///////////////////////////
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
            CBStrorage.DisplayMember = "StorageName";
            CBStrorage.ValueMember = "StorageID";
            CBStrorage.DataSource = ds.Tables["TblStorages"];
            CBStrorage.SelectedItem = null;
            Con.Close();
        }
        ////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get All Employess
        /// </summary>
        private void GetAllEmployess()
        {
            this.GVEmployess.Rows.Clear();

            var Employees = context.TblEmployesses.Select(a => a).ToList();

            foreach (var item in Employees)
            {
                this.GVEmployess.Rows.Add(item.Name , item.Phone , item.Salary , item.Debit , item.Credit , item.EmployeeID);
            }

        }

        // ////////////////////
        private void Employess_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.GetAllEmployess();
            loadStorage();
        }

        private void Pichome_Click(object sender, EventArgs e)
        {
            this.Close();
            Home HO = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            HO.Visible = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            TblEmployess Emp = new TblEmployess();

            Emp.Name = this.TxtName.Text;
            Emp.Phone = this.TxtTelephone.Text;
            Emp.Salary = double.Parse(this.TxtSalary.Text);
            Emp.Debit = double.Parse(this.TxtDebit.Text);
            Emp.Credit = double.Parse(this.TxtSalary.Text) - double.Parse(this.TxtDebit.Text);
            Emp.ISActive = true;

            context.TblEmployesses.Add(Emp);
            context.SaveChanges();
            try
            {
                TblLog Log = new TblLog();
                Log.UserID = int.Parse(this.LblUserID.Text);
                Log.Discription = " إضافة المستخدم : " + Emp.Name;
                Log.DateOfLog = DateTime.Now;

                context.TblLogs.Add(Log);
                context.SaveChanges();

            }
            catch (Exception)
            {


            }
            MessageBox.Show("Done.....", "Creative Care");

            this.TxtDebit.Text = "";
            this.TxtName.Text = "";
            this.TxtSalary.Text = "";
            this.TxtTelephone.Text = "";

            this.GetAllEmployess();

        }

        private void GVEmployess_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = GVEmployess.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GVEmployess.Rows[rowindex];
          

            int EmpID = int.Parse(Row.Cells["EmpI"].Value.ToString());

            var Employee = context.TblEmployesses.Where(a => a.EmployeeID == EmpID).Select(a => a).FirstOrDefault();
            this.TxtDebit.Text = Employee.Debit.ToString();
            this.TxtName.Text = Employee.Name;
            this.TxtSalary.Text = Employee.Salary.ToString();
            this.TxtTelephone.Text = Employee.Phone;
            this.LblEmpID.Text = Employee.EmployeeID.ToString();
            this.LblEmpName.Text = Employee.Name;
         
            this.TxtRepay.Text = Employee.Credit.ToString();
            this.BtnEdit.Show();
            this.BtnSave.Hide();
            this.PanRepay.Show();

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            int EmpID = int.Parse(this.LblEmpID.Text);

            var Emp = context.TblEmployesses.Where(a => a.EmployeeID == EmpID).Select(a => a).FirstOrDefault();
            Emp.Name = this.TxtName.Text;
            Emp.Phone = this.TxtTelephone.Text;
            Emp.Salary = double.Parse(this.TxtSalary.Text);
            Emp.Debit = double.Parse(this.TxtDebit.Text);
            Emp.Credit = double.Parse(this.TxtSalary.Text) - double.Parse(this.TxtDebit.Text);
            Emp.ISActive = true;

           
            context.SaveChanges();
            try
            {
                TblLog Log = new TblLog();
                Log.UserID = int.Parse(this.LblUserID.Text);
                Log.Discription = " تعديل بيانات  : " + Emp.Name;
                Log.DateOfLog = DateTime.Now;

                context.TblLogs.Add(Log);
                context.SaveChanges();

            }
            catch (Exception)
            {


            }
            MessageBox.Show("Done.....", "Creative Care");

            this.TxtDebit.Text = "";
            this.TxtName.Text = "";
            this.TxtSalary.Text = "";
            this.TxtTelephone.Text = "";

            this.BtnEdit.Hide();
            this.BtnSave.Show();
            this.GetAllEmployess();
            this.PanRepay.Hide();
        }

        private void BtnRepay_Click(object sender, EventArgs e)
        {
            if (this.CBStrorage.SelectedItem == null)
            {
                MessageBox.Show("من فضلك اختار الخزنه", "Creative Care");
            }
            else
            {

                double Rep = double.Parse(this.TxtRepay.Text);
                int EmpID = int.Parse(this.LblEmpID.Text);

                var Emp = context.TblEmployesses.Where(a => a.EmployeeID == EmpID).Select(a => a).FirstOrDefault();

                if (this.CBStrorage.SelectedValue.ToString() == "3")
                {
                   
                    Emp.Debit = 0;

                    Emp.Credit = Emp.Salary;

                    context.SaveChanges();

                    try
                    {
                        TblLog Log = new TblLog();
                        Log.UserID = int.Parse(this.LblUserID.Text);
                        Log.Discription = " سداد مستحقات : " + Emp.Name;
                        Log.DateOfLog = DateTime.Now;

                        context.TblLogs.Add(Log);
                        context.SaveChanges();

                    }
                    catch (Exception)
                    {


                    }
                    MessageBox.Show("Done....", "Creative Care");
                    this.TxtRepay.Text = "";
                    this.LblEmpName.Text = "";
                    this.PanRepay.Hide();

                }
                else
                {
                    
                    // Truser

                    int TRID = int.Parse(this.CBStrorage.SelectedValue.ToString());

                    var Truser = context.TblStorages.Where(a => a.StorageID == TRID).Select(a=>a).FirstOrDefault();

                    double Exis = double.Parse(Truser.TotalMoney);
                    if (Exis < Rep)
                    {
                        MessageBox.Show("النقود فى الخزنه لا تكفى ", "Creative Care");
                    }
                    else
                    {
                        Truser.TotalMoney = (Exis - Rep).ToString();
                        context.SaveChanges();

                        Emp.Debit = 0;

                        Emp.Credit = Emp.Salary;

                        context.SaveChanges();
                        try
                        {
                            TblLog Log = new TblLog();
                            Log.UserID = int.Parse(this.LblUserID.Text);
                            Log.Discription = " سداد مستحقات : " + Emp.Name;
                            Log.DateOfLog = DateTime.Now;

                            context.TblLogs.Add(Log);
                            context.SaveChanges();

                        }
                        catch (Exception)
                        {


                        }
                        TblExpens Expen = new TblExpens();
                        Expen.ExpensesDate = DateTime.Now;
                        Expen.ExpensesReason = "سداد مستحق ل :" + this.LblEmpName.Text;
                        Expen.Money = this.TxtRepay.Text;
                        Expen.StorageID = TRID;
                        Expen.UserID = int.Parse(LblUserID.Text);

                        context.TblExpenses.Add(Expen);
                        context.SaveChanges();

                        /////////////////////////////////////////////////
                        // هنا بقى يابرنس بيضيف العمليات بتاعت الخزنه ك مصروفات للقصر  برضه
                        SqlCommand SAction = new SqlCommand();
                        SAction.Connection = Con;
                        SAction.CommandType = CommandType.StoredProcedure;
                        SAction.CommandText = "AddStorageAction";

                        SAction.Parameters.AddWithValue("@SActionID", "4");
                        SAction.Parameters.AddWithValue("@SPDate", DateTime.Now.ToString("yyyy-MM-dd"));
                        SAction.Parameters.AddWithValue("@SPMoney", this.TxtRepay.Text);
                        SAction.Parameters.AddWithValue("@StorageID", this.CBStrorage.SelectedValue);

                        Con.Open();
                        SAction.ExecuteNonQuery();
                        Con.Close();

                        ///////////////////////////////////////

                        MessageBox.Show("Done....", "Creative Care");
                        this.TxtRepay.Text = "";
                        this.LblEmpName.Text = "";
                        this.PanRepay.Hide();
                    }
                }
                this.GetAllEmployess();
            }
        }
    }
}

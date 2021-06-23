using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I_Count
{
    public partial class EmployeeDebit : Form
    {
        //  SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");

        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);

        AccountingEntities context = new AccountingEntities();
        public EmployeeDebit(int ID)
        {
            InitializeComponent();
            this.LblUserID.Text = ID.ToString();
        }
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
        private void EmployeeDebit_Load(object sender, EventArgs e)
        {
            loadStorage();
        }

        private void BtnRepay_Click(object sender, EventArgs e)
        {
            if (this.CBStrorage.SelectedItem == null || this.TxtRepay.Text == "" || this.LblEmpID.Text == "")
            {
                MessageBox.Show("من فضلك تاكد من البيانات المطلوبه ", "Creative Care");
            }
            else
            {
                int EmpID = int.Parse(this.LblEmpID.Text);

                double NewX = double.Parse(this.TxtRepay.Text);

                var Employee = context.TblEmployesses.Where(a => a.EmployeeID == EmpID).Select(a => a).FirstOrDefault();

                Employee.Debit = Employee.Debit + NewX;
                Employee.Credit = Employee.Salary - (Employee.Debit);

                context.SaveChanges();

                TblExpens Exp = new TblExpens();
                Exp.ExpensesDate = DateTime.Now;
                Exp.ExpensesReason = "سلفه ل " + this.LblName.Text;
                Exp.UserID = int.Parse(this.LblUserID.Text);
                Exp.StorageID = int.Parse(this.CBStrorage.SelectedValue.ToString());
                Exp.Money = this.TxtRepay.Text;
                context.TblExpenses.Add(Exp);
                context.SaveChanges();

                int TRID = int.Parse(this.CBStrorage.SelectedValue.ToString());
                var Truser = context.TblStorages.Where(a => a.StorageID == TRID).Select(a => a).FirstOrDefault();
                double oldee = double.Parse(Truser.TotalMoney);
               double Depp = double.Parse(Employee.Debit.ToString());
                double NewTr = oldee - NewX;
                Truser.TotalMoney = NewTr.ToString();
                context.SaveChanges();
                try
                {
                    TblLog Log = new TblLog();
                    Log.UserID = int.Parse(this.LblUserID.Text);
                    Log.Discription = "إضافة سلفة للموظف    : " + this.LblName.Text;
                    Log.DateOfLog = DateTime.Now;

                    context.TblLogs.Add(Log);
                    context.SaveChanges();

                }
                catch (Exception)
                {


                }
                MessageBox.Show("Done......", "Creative Care");

                this.Hide();
            }
        }

        private void TxtTelephone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var Employee = context.TblEmployesses.Where(a => a.Phone == this.TxtTelephone.Text).Select(a => a).FirstOrDefault();
                if (Employee == null)
                {
                    MessageBox.Show("لا توجد نتيجه للبحث","Creative Care");
                }
                else
                {
                    this.LblName.Text = Employee.Name;
                    this.LblEmpID.Text = Employee.EmployeeID.ToString();

                }
            }
        }
    }
}

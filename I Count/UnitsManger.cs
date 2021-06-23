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
    public partial class UnitsManger : Form
    {
        //SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        AccountingEntities context = new AccountingEntities();
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public UnitsManger(int ID)
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
             
            }

            dr.Close();
            Con.Close();
        }

        private void UnitsManger_Load(object sender, EventArgs e)
        {

        }

        private void BtnAddUnit_Click(object sender, EventArgs e)
        {
            TblUnit Unit = new TblUnit();
           // Unit.BigUnit = this.TxtBigUnit.Text;
          //  Unit.SmallUnit = this.TxtSamllUnit.Text;
            Unit.Small_Unit_number = double.Parse(this.TxtSamllUnitNumbers.Text);

            context.TblUnits.Add(Unit);
            context.SaveChanges();

            MessageBox.Show("تم إضافة الوحده بنجاح", "Abdelrahman Abdelhameed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                TblLog Log = new TblLog();
                Log.UserID = int.Parse(this.LblUserID.Text);
                Log.Discription = "إضافة الوحده :" + this.TxtBigUnit.Text;
                Log.DateOfLog = DateTime.Now;

                context.TblLogs.Add(Log);
                context.SaveChanges();

            }
            catch (Exception)
            {


            }
            this.TxtBigUnit.Text = "";
            this.TxtSamllUnit.Text = "";
            this.TxtSamllUnitNumbers.Text = "";

        }
    }
}

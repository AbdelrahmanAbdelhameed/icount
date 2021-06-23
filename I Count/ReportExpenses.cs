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
    public partial class ReportExpenses : Form
    {
        // SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public ReportExpenses()
        {
            InitializeComponent();
        }

        private void PicDay_MouseHover(object sender, EventArgs e)
        {
            this.LblDay.Show();
        }

        private void PicDay_MouseLeave(object sender, EventArgs e)
        {
            this.LblDay.Hide();
        }

        private void PicMonth_MouseHover(object sender, EventArgs e)
        {
            this.LblMonth.Show();
        }

        private void PicMonth_MouseLeave(object sender, EventArgs e)
        {
            this.LblMonth.Hide();
        }

        private void PicSearch_MouseHover(object sender, EventArgs e)
        {
            this.LblSearch.Show();
        }

        private void PicSearch_MouseLeave(object sender, EventArgs e)
        {
            this.LblSearch.Hide();
        }
      // ////////////////////////////////////
        //load Day
        private void LoadDailyReport()
        {
            this.GvExpenses.Rows.Clear();
            this.LblTotalExpenses.Text = "";

            SqlCommand expenses = new SqlCommand();
            expenses.Connection = Cnn;
            expenses.CommandType = CommandType.Text;
            expenses.CommandText = "select * from ExpensesReport where  (day(ExpensesDate)=day(@ExpensesDate))  and (month(ExpensesDate)=month(@ExpensesDate)) and (year(ExpensesDate)=year(@ExpensesDate))";

            expenses.Parameters.AddWithValue("@ExpensesDate", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader EX;
            Cnn.Open();
            EX = expenses.ExecuteReader();

            while (EX.Read())// لو لقى هايعرض 
            {

                this.GvExpenses.Rows.Add(EX["Money"].ToString(), EX["ExpensesReason"].ToString(), EX["ExpensesDate"].ToString(), EX["Name"].ToString(), EX["ExpensesID"].ToString(), EX["StoreName"].ToString());

            }

            EX.Close();
            Cnn.Close();
        }
        private void ReportExpenses_Load(object sender, EventArgs e)
        {
            this.LoadDailyReport();
        }

        private void PicDay_Click(object sender, EventArgs e)
        {
            this.LoadDailyReport();
        }

        private void GvExpenses_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double Bob = 0;
            for (int i = 0; i < GvExpenses.Rows.Count; ++i)
            {
                Bob += double.Parse(GvExpenses.Rows[i].Cells["Expenses"].Value.ToString());
            }
            this.LblTotalExpenses.Text = Bob.ToString(); 
        }

        private void PicMonth_Click(object sender, EventArgs e)
        {
            this.GvExpenses.Rows.Clear();
            this.LblTotalExpenses.Text = "";

            SqlCommand expenses = new SqlCommand();
            expenses.Connection = Cnn;
            expenses.CommandType = CommandType.Text;
            expenses.CommandText = "select * from ExpensesReport where (month(ExpensesDate)=month(@ExpensesDate)) and (year(ExpensesDate)=year(@ExpensesDate))";

            expenses.Parameters.AddWithValue("@ExpensesDate", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader EX;
            Cnn.Open();
            EX = expenses.ExecuteReader();

            while (EX.Read())// لو لقى هايعرض 
            {

                this.GvExpenses.Rows.Add(EX["Money"].ToString(), EX["ExpensesReason"].ToString(), EX["ExpensesDate"].ToString(), EX["Name"].ToString(), EX["ExpensesID"].ToString(), EX["StoreName"].ToString());

            }

            EX.Close();
            Cnn.Close();
        }

        private void PicSearch_Click(object sender, EventArgs e)
        {
            this.GvExpenses.Rows.Clear();
            this.LblTotalExpenses.Text = "";

            SqlCommand expenses = new SqlCommand();
            expenses.Connection = Cnn;
            expenses.CommandType = CommandType.Text;
            expenses.CommandText = "select * from ExpensesReport where ExpensesDate BETWEEN @ExpensesDate and  @ExpensesDateTO";

            //(day(ExpensesDate)>=day(@ExpensesDate)  and day(ExpensesDate)<=day(@ExpensesDateTO)) and (month(ExpensesDate)>=month(@ExpensesDate)  and month(ExpensesDate)<=month(@ExpensesDateTO)) and (year(ExpensesDate)>=year(@ExpensesDate) and year(ExpensesDate)<=year(@ExpensesDateTO))

            expenses.Parameters.AddWithValue("@ExpensesDate", this.DTFrom.Value.ToString("yyyy-MM-dd"));
            expenses.Parameters.AddWithValue("@ExpensesDateTO", this.DtTO.Value.ToString("yyyy-MM-dd"));


            SqlDataReader EX;
            Cnn.Open();
            EX = expenses.ExecuteReader();

            while (EX.Read())// لو لقى هايعرض 
            {

                this.GvExpenses.Rows.Add(EX["Money"].ToString(), EX["ExpensesReason"].ToString(), EX["ExpensesDate"].ToString(), EX["Name"].ToString(), EX["ExpensesID"].ToString(), EX["StoreName"].ToString());

            }

            EX.Close();
            Cnn.Close();
        }

        private void GvExpenses_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = GvExpenses.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GvExpenses.Rows[rowindex];


            DialogResult dialogResult = MessageBox.Show(" هل ب الفعل تريد حذف هذا البند  ", "Creative Care ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = " delete from TblExpenses where ExpensesID=@ExpensesID  ";

                Cmd.Parameters.AddWithValue("@ExpensesID", Row.Cells["ExpensesID"].Value.ToString());
                Cnn.Open();
                Cmd.ExecuteNonQuery();
                Cnn.Close();
                MessageBox.Show(" تم وسوف يتم  عرض تقرير مصروفات اليوم  ","Creative Care",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.LoadDailyReport();
            }
            else if (dialogResult == DialogResult.No)
            {

            }

        }
    }
}

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
    public partial class ReportIncome : Form
    {
        // SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public ReportIncome()
        {
            InitializeComponent();
        }
         // ///////////////////////////////////////////////////////////////////
        // load daily report 
        private void LoadDailyReport()
        {
            this.GvIncome.Rows.Clear();
            this.LblTotalExpenses.Text = "";

            SqlCommand income = new SqlCommand();
            income.Connection = Cnn;
            income.CommandType = CommandType.Text;
            income.CommandText = "select * from IncomeReport where  (day(IncomeDate)=day(@IncomeDate))  and (month(IncomeDate)=month(@IncomeDate)) and (year(IncomeDate)=year(@IncomeDate))";

            income.Parameters.AddWithValue("@IncomeDate", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader IN;
            Cnn.Open();
            IN = income.ExecuteReader();

            while (IN.Read())// لو لقى هايعرض 
            {

                this.GvIncome.Rows.Add(IN["IncomeValue"].ToString(), IN["IncomeResourc"].ToString(), IN["IncomeDate"].ToString(), IN["Name"].ToString(), IN["IncomeID"].ToString(), IN["StoreName"].ToString());

            }

            IN.Close();
            Cnn.Close();

        }
        private void ReportIncome_Load(object sender, EventArgs e)
        {
            this.LoadDailyReport();
        }

        private void PicDay_MouseHover(object sender, EventArgs e)
        {
            this.LblDay.Show();
        }

        private void PicDay_MouseLeave(object sender, EventArgs e)
        {
            this.LblDay.Hide();
        }

        private void PicDay_Click(object sender, EventArgs e)
        {
            this.LoadDailyReport();
        }

        private void PicMonth_MouseHover(object sender, EventArgs e)
        {
            this.LblMonth.Show();

        }

        private void PicMonth_MouseLeave(object sender, EventArgs e)
        {
            this.LblMonth.Hide();
        }

        private void PicMonth_Click(object sender, EventArgs e)
        {
            this.GvIncome.Rows.Clear();
            this.LblTotalExpenses.Text = "";

            SqlCommand income = new SqlCommand();
            income.Connection = Cnn;
            income.CommandType = CommandType.Text;
            income.CommandText = "select * from IncomeReport where  (month(IncomeDate)=month(@IncomeDate)) and (year(IncomeDate)=year(@IncomeDate))";

            income.Parameters.AddWithValue("@IncomeDate", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader IN;
            Cnn.Open();
            IN = income.ExecuteReader();

            while (IN.Read())// لو لقى هايعرض 
            {

                this.GvIncome.Rows.Add(IN["IncomeValue"].ToString(), IN["IncomeResourc"].ToString(), IN["IncomeDate"].ToString(), IN["Name"].ToString(), IN["IncomeID"].ToString(), IN["StoreName"].ToString());

            }

            IN.Close();
            Cnn.Close();

        }

        private void PicSearch_MouseHover(object sender, EventArgs e)
        {
            this.LblSearch.Show();
        }

        private void PicSearch_MouseLeave(object sender, EventArgs e)
        {
            this.LblSearch.Hide();
        }

        private void PicSearch_Click(object sender, EventArgs e)
        {
            this.GvIncome.Rows.Clear();
            this.LblTotalExpenses.Text = "";

            SqlCommand income = new SqlCommand();
            income.Connection = Cnn;
            income.CommandType = CommandType.Text;
            income.CommandText = "select * from IncomeReport where IncomeDate BETWEEN @IncomeDate and  @IncomeDateTo ";

            //(day(IncomeDate)>=day(@IncomeDate)  and day(IncomeDate)<=day(@IncomeDateTo)) and (month(IncomeDate)>=month(@IncomeDate)  and month(IncomeDate)<=month(@IncomeDateTo)) and (year(IncomeDate)>=year(@IncomeDate) and year(IncomeDate)<=year(@IncomeDateTo))

            income.Parameters.AddWithValue("@IncomeDate", this.DTFrom.Value.ToString("yyyy-MM-dd"));
            income.Parameters.AddWithValue("@IncomeDateTo", this.DtTO.Value.ToString("yyyy-MM-dd"));

            SqlDataReader IN;
            Cnn.Open();
            IN = income.ExecuteReader();

            while (IN.Read())// لو لقى هايعرض 
            {

                this.GvIncome.Rows.Add(IN["IncomeValue"].ToString(), IN["IncomeResourc"].ToString(), IN["IncomeDate"].ToString(), IN["Name"].ToString(), IN["IncomeID"].ToString(), IN["StoreName"].ToString());

            }

            IN.Close();
            Cnn.Close();

        }

        private void GvIncome_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double Bob = 0;
            for (int i = 0; i < GvIncome.Rows.Count; ++i)
            {
                Bob += double.Parse(GvIncome.Rows[i].Cells["Expenses"].Value.ToString());
            }
            this.LblTotalExpenses.Text = Bob.ToString(); 
        }

        private void GvIncome_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = GvIncome.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GvIncome.Rows[rowindex];


            DialogResult dialogResult = MessageBox.Show(" هل ب الفعل تريد حذف هذا البند  ", "Creative Care ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = " delete from TblIncome where IncomeID=@IncomeID  ";

                Cmd.Parameters.AddWithValue("@IncomeID", Row.Cells["IncomeID"].Value.ToString());
                Cnn.Open();
                Cmd.ExecuteNonQuery();
                Cnn.Close();
                MessageBox.Show(" تم وسوف يتم  عرض تقرير إيراد اليوم  ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LoadDailyReport();

            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
    }
}

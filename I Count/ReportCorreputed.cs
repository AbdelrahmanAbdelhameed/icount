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
    public partial class ReportCorreputed : Form
    {
        //  SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public ReportCorreputed()
        {
            InitializeComponent();
        }
        // ////////////////////////////////////
        //load Day
        private void LoadDailyReport()
        {
            this.GvCorrupted.Rows.Clear();
            this.LblTotalExpenses.Text = "";

            SqlCommand expenses = new SqlCommand();
            expenses.Connection = Cnn;
            expenses.CommandType = CommandType.Text;
            expenses.CommandText = "select * from showCorreputed where  (day(DateOfbill)=day(@DateOfbill))  and (month(DateOfbill)=month(@DateOfbill)) and (year(DateOfbill)=year(@DateOfbill))";

            expenses.Parameters.AddWithValue("@DateOfbill", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader EX;
            Cnn.Open();
            EX = expenses.ExecuteReader();

            while (EX.Read())// لو لقى هايعرض 
            {

                this.GvCorrupted.Rows.Add(EX["ProductType"].ToString(), EX["ProductName"].ToString(), EX["CorruptedNum"].ToString(), EX["CoMoney"].ToString(), EX["DateOfbill"].ToString(), EX["Name"].ToString());

            }

            EX.Close();
            Cnn.Close();
        }
        private void PicDay_Click(object sender, EventArgs e)
        {
            this.LoadDailyReport();
        }

        private void ReportCorreputed_Load(object sender, EventArgs e)
        {
            this.LoadDailyReport();
        }

        

        private void PicMonth_Click(object sender, EventArgs e)
        {
            this.GvCorrupted.Rows.Clear();
            this.LblTotalExpenses.Text = "";

            SqlCommand expenses = new SqlCommand();
            expenses.Connection = Cnn;
            expenses.CommandType = CommandType.Text;
            expenses.CommandText = "select * from showCorreputed where (month(DateOfbill)=month(@DateOfbill)) and (year(DateOfbill)=year(@DateOfbill))";

            expenses.Parameters.AddWithValue("@DateOfbill", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader EX;
            Cnn.Open();
            EX = expenses.ExecuteReader();

            while (EX.Read())// لو لقى هايعرض 
            {

               this.GvCorrupted.Rows.Add(EX["ProductType"].ToString(), EX["ProductName"].ToString(), EX["CorruptedNum"].ToString(), EX["CoMoney"].ToString(), EX["DateOfbill"].ToString(), EX["Name"].ToString());

            }

            EX.Close();
            Cnn.Close();
        }

        private void PicSearch_Click(object sender, EventArgs e)
        {
            this.GvCorrupted.Rows.Clear();
            this.LblTotalExpenses.Text = "";

            SqlCommand expenses = new SqlCommand();
            expenses.Connection = Cnn;
            expenses.CommandType = CommandType.Text;
            expenses.CommandText = "select * from showCorreputed where DateOfbill BETWEEN @DateOfbill and  @DateOfbillTO ";

            //(day(DateOfbill)>=day(@DateOfbill)  and day(DateOfbill)<=day(@DateOfbillTO)) and (month(DateOfbill)>=month(@DateOfbill)  and month(DateOfbill)<=month(@DateOfbillTO)) and (year(DateOfbill)>=year(@DateOfbill) and year(DateOfbill)<=year(@DateOfbillTO))

            expenses.Parameters.AddWithValue("@DateOfbill", this.DTFrom.Value.ToString("yyyy-MM-dd"));
            expenses.Parameters.AddWithValue("@DateOfbillTO", this.DtTO.Value.ToString("yyyy-MM-dd"));


            SqlDataReader EX;
            Cnn.Open();
            EX = expenses.ExecuteReader();

            while (EX.Read())// لو لقى هايعرض 
            {

                this.GvCorrupted.Rows.Add(EX["ProductType"].ToString(), EX["ProductName"].ToString(), EX["CorruptedNum"].ToString(), EX["CoMoney"].ToString(), EX["DateOfbill"].ToString(), EX["Name"].ToString());

            }

            EX.Close();
            Cnn.Close();
        }

        private void GvCorrupted_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double Bob = 0;
            for (int i = 0; i < GvCorrupted.Rows.Count; ++i)
            {
                Bob += double.Parse(GvCorrupted.Rows[i].Cells["Totaa"].Value.ToString());
            }
            this.LblTotalExpenses.Text = Bob.ToString(); 
        }

        private void PicDay_MouseLeave(object sender, EventArgs e)
        {
            this.LblDay.Hide();
        }

        private void PicDay_MouseHover(object sender, EventArgs e)
        {
            this.LblDay.Show();
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
    }
}

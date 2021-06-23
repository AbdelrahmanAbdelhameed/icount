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
    public partial class ReportTransfer : Form
    {
        // SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public ReportTransfer()
        {
            InitializeComponent();
        }
        // ////////////////////////////////////
        //load Day
        private void LoadDailyReport()
        {
            this.GvIncome.Rows.Clear();
           
            SqlCommand expenses = new SqlCommand();
            expenses.Connection = Cnn;
            expenses.CommandType = CommandType.Text;
            expenses.CommandText = "select * from ReportTransfer where  (day(TransferDate)=day(@TransferDate))  and (month(TransferDate)=month(@TransferDate)) and (year(TransferDate)=year(@TransferDate))";

            expenses.Parameters.AddWithValue("@TransferDate", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader EX;
            Cnn.Open();
            EX = expenses.ExecuteReader();

            while (EX.Read())// لو لقى هايعرض 
            {
                DateTime DAtee = DateTime.Parse(EX["TransferDate"].ToString());

                this.GvIncome.Rows.Add(EX["ProductType"].ToString(), EX["ProductName"].ToString(), EX["TransQuantity"].ToString(), EX["StoreName"].ToString(), EX["StoreTo"].ToString(), DAtee.ToString("yyyy-MM-dd"), EX["Name"].ToString());

            }

            EX.Close();
            Cnn.Close();
        }
        // /////////////////////////////////////////////////////
        private void PicDay_Click(object sender, EventArgs e)
        {
            this.LoadDailyReport();
        }

        private void ReportTransfer_Load(object sender, EventArgs e)
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

        private void PicMonth_MouseHover(object sender, EventArgs e)
        {
            this.LblMonth.Show();
        }

        private void PicMonth_MouseLeave(object sender, EventArgs e)
        {
            this.LblMonth.Hide();
        }

        private void PicSearch_MouseLeave(object sender, EventArgs e)
        {
            this.LblSearch.Hide();
        }

        private void PicSearch_MouseHover(object sender, EventArgs e)
        {
            this.LblSearch.Show();
        }

        private void PicMonth_Click(object sender, EventArgs e)
        {
            this.GvIncome.Rows.Clear();

            SqlCommand expenses = new SqlCommand();
            expenses.Connection = Cnn;
            expenses.CommandType = CommandType.Text;
            expenses.CommandText = "select * from ReportTransfer where  (month(TransferDate)=month(@TransferDate)) and (year(TransferDate)=year(@TransferDate))";

            expenses.Parameters.AddWithValue("@TransferDate", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader EX;
            Cnn.Open();
            EX = expenses.ExecuteReader();

            while (EX.Read())// لو لقى هايعرض 
            {
                DateTime DAtee = DateTime.Parse(EX["TransferDate"].ToString());

                this.GvIncome.Rows.Add(EX["ProductType"].ToString(), EX["ProductName"].ToString(), EX["TransQuantity"].ToString(), EX["StoreName"].ToString(), EX["StoreTo"].ToString(), DAtee.ToString("yyyy-MM-dd"), EX["Name"].ToString());

            }

            EX.Close();
            Cnn.Close();
        }

        private void PicSearch_Click(object sender, EventArgs e)
        {
            this.GvIncome.Rows.Clear();

            SqlCommand expenses = new SqlCommand();
            expenses.Connection = Cnn;
            expenses.CommandType = CommandType.Text;
            expenses.CommandText = "select * from ReportTransfer where  TransferDate BETWEEN @TransferDate and  @TransferDateTO ";

            expenses.Parameters.AddWithValue("@TransferDate", this.DTFrom.Value.ToString("yyyy-MM-dd"));
            expenses.Parameters.AddWithValue("@TransferDateTO", this.DtTO.Value.ToString("yyyy-MM-dd"));

            SqlDataReader EX;
            Cnn.Open();
            EX = expenses.ExecuteReader();

            while (EX.Read())// لو لقى هايعرض 
            {
                DateTime DAtee = DateTime.Parse(EX["TransferDate"].ToString());

                this.GvIncome.Rows.Add(EX["ProductType"].ToString(), EX["ProductName"].ToString(), EX["TransQuantity"].ToString(), EX["StoreName"].ToString(), EX["StoreTo"].ToString(), DAtee.ToString("yyyy-MM-dd"), EX["Name"].ToString());

            }

            EX.Close();
            Cnn.Close();
        }
    }
}

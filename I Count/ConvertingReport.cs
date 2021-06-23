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
    public partial class ConvertingReport : Form
    {
        //SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public ConvertingReport()
        {
            InitializeComponent();
        }
        /////////////////////////////////////////
        //load procedure 
        private void LoadProcedure()
        {
            this.GvReport.Rows.Clear();

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from ReportProcedure  where  (day(ProcedureDate)=day(@ProcedureDate))  and (month(ProcedureDate)=month(@ProcedureDate)) and (year(ProcedureDate)=year(@ProcedureDate)) ";

            Cmd.Parameters.AddWithValue("@ProcedureDate", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader dr;
            Cnn.Open();
            dr = Cmd.ExecuteReader();

            while (dr.Read())
            {
                this.GvReport.Rows.Add(dr["StorageName"].ToString(), dr["ProcedureName"].ToString(), dr["ProcedureValue"].ToString(), dr["ProcedureDate"].ToString(), dr["TotalMoney"].ToString(), dr["Name"].ToString());

            }
            dr.Close();
            Cnn.Close();
        }
        // /////////////////////////////////////

        private void ConvertingReport_Load(object sender, EventArgs e)
        {
            this.LoadProcedure();
        }

        private void PicDay_Click(object sender, EventArgs e)
        {
            this.LoadProcedure();
        }

        private void PicMonth_Click(object sender, EventArgs e)
        {
            this.GvReport.Rows.Clear();

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from ReportProcedure  where   (month(ProcedureDate)=month(@ProcedureDate)) and (year(ProcedureDate)=year(@ProcedureDate)) ";

            Cmd.Parameters.AddWithValue("@ProcedureDate", DateTime.Now.ToString("yyyy-MM-dd"));

            SqlDataReader dr;
            Cnn.Open();
            dr = Cmd.ExecuteReader();

            while (dr.Read())
            {
                this.GvReport.Rows.Add(dr["StorageName"].ToString(), dr["ProcedureName"].ToString(), dr["ProcedureValue"].ToString(), dr["ProcedureDate"].ToString(), dr["TotalMoney"].ToString(), dr["Name"].ToString());

            }
            dr.Close();
            Cnn.Close();
        }

        private void PicSearch_Click(object sender, EventArgs e)
        {
            this.GvReport.Rows.Clear();

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Cnn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from ReportProcedure where ProcedureDate BETWEEN @ProcedureDate and  @ProcedureDateTo  ";

            //(day(ProcedureDate)>=day(@ProcedureDate)  and day(ProcedureDate)<=day(@ProcedureDateTo)) and (month(ProcedureDate)>=month(@ProcedureDate)  and month(ProcedureDate)<=month(@ProcedureDateTo)) and (year(ProcedureDate)>=year(@ProcedureDate) and year(ProcedureDate)<=year(@ProcedureDateTo))

            Cmd.Parameters.AddWithValue("@ProcedureDate", this.DTFrom.Value.ToString("yyyy-MM-dd"));
            Cmd.Parameters.AddWithValue("@ProcedureDateTo", this.DtTO.Value.ToString("yyyy-MM-dd"));

            SqlDataReader dr;
            Cnn.Open();
            dr = Cmd.ExecuteReader();

            while (dr.Read())
            {
                this.GvReport.Rows.Add(dr["StorageName"].ToString(), dr["ProcedureName"].ToString(), dr["ProcedureValue"].ToString(), dr["ProcedureDate"].ToString(), dr["TotalMoney"].ToString(), dr["Name"].ToString());

            }
            dr.Close();
            Cnn.Close();
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
    }
}

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
    public partial class Backup : Form
    {
        //  SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        // SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=master;Data Source=localhost");
        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public Backup()
        {
            InitializeComponent();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (this.FBDBackup.ShowDialog()==DialogResult.OK)
            {
                this.TxtPath.Text = this.FBDBackup.SelectedPath;
            }
        }

        private void Backup_Load(object sender, EventArgs e)
        {
           
        }
        // add backup
        private void BtnSet_Click(object sender, EventArgs e)
        {
            if (this.TxtPath.Text == "")
            {
                MessageBox.Show("من فضلك اختار المسار ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string Path = this.TxtPath.Text + "\\Accounting" + DateTime.Now.ToShortDateString().Replace('/', '-') ;


                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "Backup Database Accounting to Disk='" + Path +".bak'";

             
              
                Cnn.Open();
                Cmd.ExecuteNonQuery();
                Cnn.Close();

               

              MessageBox.Show("Done ", "Creative Care", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

          }
}

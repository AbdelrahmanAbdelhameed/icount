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
namespace I_Count
{
    public partial class BackinBills : Form
    {
        //SqlConnection Cnn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");

        public BackinBills(int ID )
        {
            InitializeComponent();
            this.LblBillID.Text = ID.ToString();
        }

        private void BackinBills_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'AccountingDataSet2.BackinBillView' table. You can move, or remove it, as needed.
            this.BackinBillViewTableAdapter.Fill(this.AccountingDataSet2.BackinBillView,int.Parse(this.LblBillID.Text));
           
            this.REBackin.RefreshReport();
        }
    }
}

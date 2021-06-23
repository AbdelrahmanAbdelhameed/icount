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
    public partial class PurchasesBills : Form
    {
      //  SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");

        public PurchasesBills(int BillId)
        {
            InitializeComponent();
            this.LblBillID.Text = BillId.ToString();
        }

        private void PurchasesBills_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'AccountingDataSet.VWShowPurchasesBills' table. You can move, or remove it, as needed.
            this.VWShowPurchasesBillsTableAdapter.Fill(this.AccountingDataSet.VWShowPurchasesBills,int.Parse(this.LblBillID.Text));
            this.REBuying.RefreshReport();
            
          
        }
    }
}

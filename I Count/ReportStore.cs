using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I_Count
{
    public partial class ReportStore : Form
    {
        public ReportStore(int id)
        {
            InitializeComponent();
            this.LblID.Text = id.ToString() ;
        }

        private void ReportStore_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.LoadProducts' table. You can move, or remove it, as needed.
            this.LoadProductsTableAdapter.Fill(this.dataSet1.LoadProducts,int.Parse(this.LblID.Text));

            this.Store.RefreshReport();
        }
    }
}

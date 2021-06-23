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
    public partial class LateCuReport : Form
    {
        public LateCuReport(int id)
        {
            InitializeComponent();
            this.LblID.Text = id.ToString();
        }

        private void LateReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'customers.ShowCusPros' table. You can move, or remove it, as needed.
            this.ShowCusProsTableAdapter.Fill(this.customers.ShowCusPros,int.Parse(this.LblID.Text));

            this.reportViewer1.RefreshReport();
        }
    }
}

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
    public partial class LateProReport : Form
    {
        public LateProReport(int id)
        {
            InitializeComponent();
            this.Lblid.Text = id.ToString();
        }

        private void LateProReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'providers.showProProc' table. You can move, or remove it, as needed.
            this.showProProcTableAdapter.Fill(this.providers.showProProc,int.Parse(this.Lblid.Text));

            this.reportViewer1.RefreshReport();
        }
    }
}

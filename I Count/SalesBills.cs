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
    public partial class SalesBills : Form
    {
        //SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
/// <summary>
/// ////////////// هنا بقى هايعرضه تفاصيل الفاتور بكل صنف ب الكميه بتعاته 
/// </summary>
        public SalesBills( int BillId)///////////////////////////  جايبهم معاه من هناك 
        {
            InitializeComponent();
            this.LblBillID.Text = BillId.ToString();
            //this.VWBillsShowTableAdapter.Fill(this.DSales.VWBillsShow,BillId);

          
        }
        ///////////////////////////////////////////////// هنا بيعمل بحث عن الاصناف اللى فى الفاتوره ب الاى دى بتاع العميل واى دى الفاتوره 
        ////////// واسمحلى اقولك اى دى كده فى وسط الكلام :D
        // بس 

        private void SalesBills_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DSales.VWBillsShow' table. You can move, or remove it, as needed.

          this.VWBillsShowTableAdapter.Fill(this.DSales.VWBillsShow,int.Parse(this.LblBillID.Text));

            this.RESales.RefreshReport();
        }
    }
}

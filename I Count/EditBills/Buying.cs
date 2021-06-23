using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I_Count.EditBills
{
    public partial class Buying : Form
    {

        AccountingEntities Acc = new AccountingEntities();

        public Buying(int ID)
        {
            InitializeComponent();
            this.LblID.Text = ID.ToString();
            var Edit = Acc.TblPurchases.Where(a => a.purchasesID == ID).Select(a => a).FirstOrDefault();
            if (Edit != null)
            {
                this.TxtType.Text = Edit.TblProductType.ProductType;
                this.TxtName.Text = Edit.TblProduct.ProductName;
                this.TxtPrice.Text = Edit.BPrice;
                this.TxtQuent.Text = Edit.Quantity;
                this.TxtTotal.Text = Edit.BTatol;
            }
            else
            {
                this.Hide();
            }
        }

        private void Buying_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(this.LblID.Text);

            var Sales = Acc.TblPurchases.Where(a => a.purchasesID == Id).Select(a => a).FirstOrDefault();

            Sales.Quantity = this.TxtQuent.Text;
            Sales.BPrice = this.TxtPrice.Text;
            Sales.BTatol = this.TxtTotal.Text;

            Acc.SaveChanges();
            MessageBox.Show("Done", "CreativeCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}

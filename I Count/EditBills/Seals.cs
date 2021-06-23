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
    public partial class Seals : Form
    {
        AccountingEntities Acc = new AccountingEntities();

        public Seals(int ID)
        {
            InitializeComponent();
            this.LblID.Text = ID.ToString();
            var Edit = Acc.TblSales.Where(a => a.ProcedureID == ID).Select(a => a).FirstOrDefault();
            if (Edit !=null)
            {
                this.TxtType.Text = Edit.TblProductType.ProductType;
                this.TxtName.Text = Edit.TblProduct.ProductName;
                this.TxtPrice.Text = Edit.Price;
                this.TxtQuent.Text = Edit.Quantity;
                this.TxtTotal.Text = Edit.BTotal;
            }
            else
            {
                this.Hide();
            }

        }

        private void Seals_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(this.LblID.Text);

            var Sales = Acc.TblSales.Where(a => a.ProcedureID == Id).Select(a => a).FirstOrDefault();

            Sales.Quantity = this.TxtQuent.Text;
            Sales.Price = this.TxtPrice.Text;
            Sales.BTotal = this.TxtTotal.Text;

            Acc.SaveChanges();
            MessageBox.Show("Done", "CreativeCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        private void TxtQuent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double X = double.Parse(this.TxtPrice.Text);
                double Y = double.Parse(this.TxtQuent.Text);

                double A = Y * X;

                this.TxtTotal.Text = A.ToString();

            }
            catch (Exception)
            {
                
              
            }
        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double X = double.Parse(this.TxtPrice.Text);
                double Y = double.Parse(this.TxtQuent.Text);

                double A = Y * X;

                this.TxtTotal.Text = A.ToString();

            }
            catch (Exception)
            {


            }
        }

        private void LblPhone_Click(object sender, EventArgs e)
        {

        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TxtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TxtType_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblID_Click(object sender, EventArgs e)
        {

        }
    }
}

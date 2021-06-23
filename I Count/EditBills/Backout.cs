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
    public partial class Backout : Form
    {
        AccountingEntities Acc = new AccountingEntities();
        public Backout(int ID)
        {
            InitializeComponent();

            this.LblID.Text = ID.ToString();
            var Edit = Acc.TblBackOutBills.Where(a => a.BackOutBillID == ID).Select(a => a).FirstOrDefault();
            if (Edit != null)
            {
                this.TxtType.Text = Edit.TblProduct.TblProductType.ProductType;
                this.TxtName.Text = Edit.TblProduct.ProductName;
                this.TxtPrice.Text = Edit.OutPrice;
                this.TxtQuent.Text = Edit.OutProdNum;
                this.TxtTotal.Text = Edit.OutTotal;
            }
            else
            {
                this.Hide();
            }
        }

        private void Backout_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(this.LblID.Text);

            var Backin = Acc.TblBackOutBills.Where(a => a.BackOutBillID == Id).Select(a => a).FirstOrDefault();

            Backin.OutProdNum = this.TxtQuent.Text;
            Backin.OutPrice = this.TxtPrice.Text;
            Backin.OutTotal = this.TxtTotal.Text;

            Acc.SaveChanges();
            MessageBox.Show("Done", "CreativeCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}

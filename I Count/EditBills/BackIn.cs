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
    public partial class BackIn : Form
    {
        AccountingEntities Acc = new AccountingEntities();

        public BackIn(int ID)
        {
            InitializeComponent();
            this.LblID.Text = ID.ToString();
            var Edit = Acc.TblBackInBills.Where(a => a.BackInBillID== ID).Select(a => a).FirstOrDefault();
            if (Edit != null)
            {
                this.TxtType.Text = Edit.TblProduct.TblProductType.ProductType;
                this.TxtName.Text = Edit.TblProduct.ProductName;
                this.TxtPrice.Text = Edit.InPrice;
                this.TxtQuent.Text = Edit.BackProNu;
                this.TxtTotal.Text = Edit.InTotal;
            }
            else
            {
                this.Hide();
            }
        }

        private void BackIn_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(this.LblID.Text);

            var Backin = Acc.TblBackInBills.Where(a => a.BackInBillID == Id).Select(a => a).FirstOrDefault();

            Backin.BackProNu = this.TxtQuent.Text;
            Backin.InPrice = this.TxtPrice.Text;
            Backin.InTotal = this.TxtTotal.Text;

            Acc.SaveChanges();
            MessageBox.Show("Done", "CreativeCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}

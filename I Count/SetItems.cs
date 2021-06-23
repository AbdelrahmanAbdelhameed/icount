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
    public partial class SetItems : Form
    {
        AccountingEntities context = new AccountingEntities();
        public SetItems(int ID)
        {
            InitializeComponent();
        }


        public Task<IEnumerable<TblProductType>> GetTypes()
        {
            return Task.Factory.StartNew(() =>
            {
                AccountingEntities _db = new AccountingEntities();
                return (IEnumerable<TblProductType>)_db.TblProductTypes.ToList();
            });
        }

        private async void LoadTypes()
        {
            var Data = await GetTypes();


            this.CBItemType.DisplayMember = "ProductType";
           
            this.CBItemType.ValueMember = "ProductTypeID";
            this.CBItemType.DataSource = Data;
            this.CBItemType.SelectedItem = null;

            this.CbActionType.DisplayMember = "ProductType";
            this.CbActionType.ValueMember = "ProductTypeID";
            this.CbActionType.DataSource = Data;
            this.CbActionType.SelectedItem = null;


        }

        public Task<IEnumerable<TblStore>> GetAnimateur()
        {
            return Task.Factory.StartNew(() =>
            {
                AccountingEntities _db = new AccountingEntities();
                return (IEnumerable<TblStore>)_db.TblStores.ToList();
            });
        }
        private async void LoadStors()
        {
            var Data = await GetAnimateur();

            

            this.CBActionStore.DisplayMember = "StoreName";
            this.CBActionStore.ValueMember = "StoreID";
            this.CBActionStore.DataSource = Data;
            this.CBActionStore.SelectedItem = null;

        }

        private void SetItems_Load(object sender, EventArgs e)
        {
            LoadTypes();
            LoadStors();
        }

        private void CBItemType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TxtEditSerilType.Text = "";
            TxtEditType.Text = "";
            int TypeID = int.Parse(CBItemType.SelectedValue.ToString());
            var Type = context.TblProductTypes.Where(a => a.ProductTypeID == TypeID).FirstOrDefault();
            TxtEditSerilType.Text = Type.ProductTypeID.ToString();
            TxtEditType.Text =Type.ProductType;

        }

        private void BtnEditType_Click(object sender, EventArgs e)
        {
            if (CBItemType.SelectedItem == null)
            {
                MessageBox.Show("من فضلك اختر نوع صنف للتعديل","Abdelrahman Abdelhameed " , MessageBoxButtons.OK,MessageBoxIcon.Hand);
                CBItemType.Focus();
            }
            else
            {
                int TypeID = int.Parse(TxtEditSerilType.Text);
                var Type = context.TblProductTypes.Where(a => a.ProductTypeID == TypeID).FirstOrDefault();
                Type.ProductType = TxtEditType.Text;
                context.SaveChanges();
                MessageBox.Show("تم حفظ التعديل بنجاح", "Abdelrahman Abdelhameed ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtEditSerilType.Text = "";
                TxtEditType.Text = "";
                CBItemType.SelectedItem = null;
                LoadTypes();
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtAddType.Text != "" && TxtAddType.Text != null)
            {


                string TypeName = TxtAddType.Text;
                var Type = context.TblProductTypes.Where(a => a.ProductType.Equals(TypeName)).FirstOrDefault();
                if (Type != null)
                {
                    MessageBox.Show("النوع مسجل من قبل", "Abdelrahman Abdelhameed ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    TblProductType T = new TblProductType();
                    T.ProductType = TypeName;
                    context.TblProductTypes.Add(T);
                    context.SaveChanges();
                    MessageBox.Show("تم حفظ النوع بنجاح", "Abdelrahman Abdelhameed ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtAddType.Text = "";
                    LoadTypes();
                }
            }
            else
            {
                MessageBox.Show("من فضلك اكتب نوع صنف", "Abdelrahman Abdelhameed ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                TxtAddType.Focus();
            }
        }

        private void TxtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.TxtPrice.Text != null)
                {
                    double price = double.Parse(this.TxtPrice.Text);
                    double Quantity = double.Parse(this.TxtQuantity.Text);
                    this.TxtValue.Text = (price * Quantity).ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (this.TxtPrice.Text != null)
                {
                    double price = double.Parse(this.TxtPrice.Text);
                    double Quantity = double.Parse(this.TxtQuantity.Text);
                    this.TxtValue.Text = (price * Quantity).ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        private void TxtValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.TxtValue.Text != null)
                {
                    double Value = double.Parse(this.TxtValue.Text);
                    double Quantity = double.Parse(this.TxtQuantity.Text);

                    this.TxtPrice.Text = (Value / Quantity).ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CBActionStore.SelectedItem == null || CbActionType.SelectedItem == null || TxtProductName.Text  == "" || TxtProductName.Text == null || TxtQuantity.Text == "" || TxtQuantity.Text == null || TxtPrice.Text == "" || TxtPrice.Text == null || TxtValue.Text == "" || TxtValue.Text == null)
            {
                MessageBox.Show("من فضلك ادخل كل الحقول المطلوبه", "Abdelrahman Abdelhameed ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}

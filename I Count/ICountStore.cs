using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;

namespace I_Count
{
    public partial class ICountStore : Form
    {
        AccountingEntities context = new AccountingEntities();
        SqlConnection Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);

        

        public ICountStore(int ID)
        {
            InitializeComponent();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TblUsers where UserID=@UserID  ";

            cmd.Parameters.AddWithValue("@UserID", ID);

            SqlDataReader dr;
            Cnn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                this.LblUserID.Text = dr["UserID"].ToString();
                this.LblUserName.Text = dr["Name"].ToString();
               

            }

            dr.Close();
            Cnn.Close();

        }



        int PNumber = 1;
        IPagedList<TblProduct> ProductList;

        int PageMoveNumber = 1;
        IPagedList<TblProductsMovement> MoveList;


        private async Task<IPagedList<TblProduct>> LoadProducts(int PNumber = 1 , int PSize = 20)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (AccountingEntities Db = new AccountingEntities())
                {
                    Db.Configuration.LazyLoadingEnabled = false;
                    return Db.TblProducts.ToList().OrderBy(a => a.Serial).ToPagedList(PNumber, PSize);
                }
            });
        }

        private async Task<IPagedList<TblProductsMovement>> LoadProductsMovement(int PageMoveNumber = 1, int PSize = 20)
        {
            return await Task.Factory.StartNew(() =>
            {
                using (AccountingEntities Db = new AccountingEntities())
                {
                     Db.Configuration.LazyLoadingEnabled = false;
                
                    return Db.TblProductsMovements.ToList().OrderByDescending(a => a.MoveID).ToPagedList(PageMoveNumber, PSize);
                }
            });
        }



        public Task<IEnumerable<TblStore>> GetAnimateur()
        {
            return Task.Factory.StartNew(() =>
            {
                AccountingEntities _db = new AccountingEntities();
                return (IEnumerable<TblStore>)_db.TblStores.ToList();
            });
        }

        public Task<IEnumerable<TblProductType>> GetTypes()
        {
            return Task.Factory.StartNew(() =>
            {
                AccountingEntities _db = new AccountingEntities();
                return (IEnumerable<TblProductType>)_db.TblProductTypes.ToList();
            });
        }
        public Task<IEnumerable<TblProduct>> GetTypesNames()
        {
            return Task.Factory.StartNew(() =>
            {
                AccountingEntities _db = new AccountingEntities();
                return (IEnumerable<TblProduct>)_db.TblProducts.ToList();
            });
        }


        private async  void  LoadStors()
        {
            var Data = await GetAnimateur();
            

            this.CBStore.DisplayMember = "StoreName";
            this.CBStore.ValueMember = "StoreID";
            this.CBStore.DataSource = Data;
            this.CBStore.SelectedItem = null;

            
            this.CBActionStore.DisplayMember = "StoreName";
            this.CBActionStore.ValueMember = "StoreID";
            this.CBActionStore.DataSource = Data;
            this.CBActionStore.SelectedItem = null;

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

        private async void LoadTypesNames(int ProTypeID)
        {
            var Data = await GetTypesNames();

            var DataShow = Data.Where(a => a.ProductTypeID == ProTypeID).ToList();

            this.CBProName.DisplayMember = "ProductName";
            this.CBProName.ValueMember = "ProductID";
            this.CBProName.DataSource = DataShow;
            this.CBProName.SelectedItem = null;



            

        }





        private async void GetDataOfStore(bool Next , bool Back)
        {
            this.GvShowProducts.Rows.Clear();
            LblFinalTotalProduct.Text = "0";
            LblPaging.Text = "";
            LblTotalproducts.Text = "0";
            LblTotalofprodu.Text = "0";
            FinalTotalMonyProduct.Text = "0";

            ProductList = await LoadProducts();
            if (Next == true && Back == false)
            {
                ProductList = await LoadProducts(++PNumber);
            }
            if (Next == false && Back == true)
            {
                ProductList = await LoadProducts(--PNumber);
            }


            BtnBack.Enabled = ProductList.HasPreviousPage;
            BtnNext.Enabled = ProductList.HasNextPage;
            LblPaging.Text = string.Format("Page {0} /{1}", PNumber, ProductList.PageCount);

            bool PStore = false;
            bool PType = false;
            bool PName = false;

            if (CBStore.SelectedItem != null)
            {
                PStore = true;
            }

            if (CBProName.SelectedItem != null)
            {
                PName = true;
            }

            if (CBItemType.SelectedItem != null)
            {
                PType = true;
            }


            var DataShow = ProductList.ToList();

            if (PStore == true && PType == false && PName == false)
            {
                int SID = int.Parse(CBStore.SelectedValue.ToString());

                DataShow = context.TblProducts.Where(a=>a.StoreID == SID).ToList();
            }

            if (PStore == true && PType == true && PName == false)
            {
                int SID = int.Parse(CBStore.SelectedValue.ToString());
                int TID = int.Parse(CBItemType.SelectedValue.ToString());

                DataShow = context.TblProducts.Where(a => a.StoreID == SID && a.ProductTypeID == TID).ToList();
            }

            if (PStore == true && PType == true && PName == true)
            {
                int SID = int.Parse(CBStore.SelectedValue.ToString());
                int TID = int.Parse(CBItemType.SelectedValue.ToString());
                int NaID = int.Parse(CBProName.SelectedValue.ToString());


                DataShow = context.TblProducts.Where(a => a.ProductID == NaID).ToList();
            }

            if (PStore == false && PType == true && PName == false)
            {

                int TID = int.Parse(CBItemType.SelectedValue.ToString());
                
                DataShow = context.TblProducts.Where(a => a.ProductTypeID == TID).ToList();
            }

            if (PStore == false && PType == true && PName == true)
            {

                int TID = int.Parse(CBItemType.SelectedValue.ToString());
                int NaID = int.Parse(CBProName.SelectedValue.ToString());


                DataShow = context.TblProducts.Where(a => a.ProductTypeID == TID && a.ProductID == NaID).ToList();
            }


            foreach (var item in DataShow.ToList())
            {
                double X = double.Parse(item.Price.ToString());
                double Y = double.Parse(item.Exist.ToString());

                double Ctotn = X * Y;
                this.GvShowProducts.Rows.Add(item.Serial, context.TblProductTypes.Where(a=>a.ProductTypeID == item.ProductTypeID).Select(a=>a.ProductType).FirstOrDefault(), item.ProductName, item.Price, item.SalePrice1, item.SalePrice2, item.Exist, Ctotn, context.TblStores.Where(a=>a.StoreID == item.StoreID).Select(a=>a.StoreName).FirstOrDefault(), item.ProductID);
            }

            if (CBStore.SelectedItem == null)
            {
                

                List<ChangeTypeinfo> Data = new List<ChangeTypeinfo>();

                foreach (var item in context.TblProducts.ToList())
                {
                    ChangeTypeinfo Fo = new ChangeTypeinfo();
                    Fo.Price = double.Parse(item.Price);
                    Fo.AllQuntity = double.Parse(item.Exist.ToString());
                    Fo.TotalF = double.Parse(item.Price) * double.Parse(item.Exist.ToString());
                    Data.Add(Fo);
                }

                LblFinalTotalProduct.Text = Data.Sum(a => a.AllQuntity).ToString();

                FinalTotalMonyProduct.Text = Data.Sum(a => a.TotalF).ToString();
            }
            else
            {
                int Stid = int.Parse(CBStore.SelectedValue.ToString());
                List<ChangeTypeinfo> Data = new List<ChangeTypeinfo>();

                foreach (var item in context.TblProducts.Where(a=>a.StoreID == Stid).ToList())
                {
                    ChangeTypeinfo Fo = new ChangeTypeinfo();
                    Fo.Price = double.Parse(item.Price);
                    Fo.AllQuntity = double.Parse(item.Exist.ToString());
                    Fo.TotalF = double.Parse(item.Price) * double.Parse(item.Exist.ToString());
                    Data.Add(Fo);
                }

                LblFinalTotalProduct.Text = Data.Sum(a => a.AllQuntity).ToString();

                FinalTotalMonyProduct.Text = Data.Sum(a => a.TotalF).ToString();
            }
        }



        private async void GetProductMovments(bool Next, bool Back)
        {
            GVShowMoves.Rows.Clear();
            LblAllTotal.Text = "";

            MoveList = await LoadProductsMovement();
            if (Next == true && Back == false)
            {
              
                MoveList = await LoadProductsMovement(++PageMoveNumber);
            }
            if (Next == false && Back == true)
            {
                MoveList = await LoadProductsMovement(--PageMoveNumber);
            }

            bool PStore = false;
            bool PType = false;
            bool PName = false;
            bool PAction = false;
            bool ISDate = false;

            if (CBActionStore.SelectedItem != null)
            {
                PStore = true;
            }

            if (CBProductName.SelectedItem != null)
            {
                PName = true;
            }

            if (CbActionType.SelectedItem != null)
            {
                PType = true;
            }

            if (CBActionProsudre.SelectedItem != null)
            {
                PAction = true;
            }

            if (CbIsDate.Checked == true)
            {
                ISDate = true;
            }


            BtnMoveBack.Enabled = MoveList.HasPreviousPage;
            BtnMoveNext.Enabled = MoveList.HasNextPage;
            LblMovePageing.Text = string.Format("Page {0} /{1}", PageMoveNumber, MoveList.PageCount);


            var DataShow = MoveList.ToList();

            #region
            // without date

            if (PStore == true && PType == true && PName == true && PAction == true && ISDate == false)
            {
                int StoID = int.Parse(CBActionStore.SelectedValue.ToString());
                int TyID = int.Parse(CbActionType.SelectedValue.ToString());
                int PNID = int.Parse(CBProductName.SelectedValue.ToString());
                int ActID = int.Parse(CBActionProsudre.SelectedValue.ToString());

                DataShow = context.TblProductsMovements.Where(a => a.ProductID == PNID && a.TemporaryID == ActID).ToList();

            }

            if (PStore == true && PType == false && PName == false && PAction == false && ISDate == false)
            {
                int StoID = int.Parse(CBActionStore.SelectedValue.ToString());

               
                DataShow =context.TblProductsMovements.Where(a => a.TblProduct.StoreID   == StoID ).OrderByDescending(a => a.MoveID).Take(300).ToList();

            }

            if (PStore == true && PType == false && PName == false && PAction == true && ISDate == false)
            {

                int StoID = int.Parse(CBActionStore.SelectedValue.ToString());
              
                int ActID = int.Parse(CBActionProsudre.SelectedValue.ToString());


               DataShow = context.TblProductsMovements.Where(a => a.TblProduct.StoreID == StoID  && a.TemporaryID == ActID).ToList();

            }


            if (PStore == true && PType == true && PName == false && PAction == true && ISDate == false)
            {

                int StoID = int.Parse(CBActionStore.SelectedValue.ToString());
                int TyID = int.Parse(CbActionType.SelectedValue.ToString());
                int ActID = int.Parse(CBActionProsudre.SelectedValue.ToString());


                DataShow = context.TblProductsMovements.Where(a => a.TblProduct.StoreID == StoID && a.TblProduct.ProductTypeID == TyID && a.TemporaryID == ActID).ToList();

            }

            if (PStore == true && PType == true && PName == false && PAction == false && ISDate == false)
            {

                int StoID = int.Parse(CBActionStore.SelectedValue.ToString());
                int TyID = int.Parse(CbActionType.SelectedValue.ToString());
             


                DataShow = context.TblProductsMovements.Where(a => a.TblProduct.StoreID == StoID && a.TblProduct.ProductTypeID == TyID ).ToList();

            }

            if (PStore == true && PType == true && PName == true && PAction == false && ISDate == false)
            {
                int StoID = int.Parse(CBActionStore.SelectedValue.ToString());
                int TyID = int.Parse(CbActionType.SelectedValue.ToString());
                int PNID = int.Parse(CBProductName.SelectedValue.ToString());
              

                DataShow = context.TblProductsMovements.Where(a => a.ProductID == PNID ).ToList();

            }
            #endregion
            #region
            // with  date

            DateTime FromD = DTB1.Value.AddDays(-1);
            DateTime ToD = DTB2.Value.AddDays(1);

            if (PStore == true && PType == true && PName == true && PAction == true && ISDate == true)
            {
                int StoID = int.Parse(CBActionStore.SelectedValue.ToString());
                int TyID = int.Parse(CbActionType.SelectedValue.ToString());
                int PNID = int.Parse(CBProductName.SelectedValue.ToString());
                int ActID = int.Parse(CBActionProsudre.SelectedValue.ToString());

                DataShow = context.TblProductsMovements.Where(a => a.ProductID == PNID && a.TemporaryID == ActID && a.MoveDate >= FromD && a.MoveDate <= ToD).ToList();

            }

            if (PStore == true && PType == false && PName == false && PAction == false && ISDate == true)
            {
                int StoID = int.Parse(CBActionStore.SelectedValue.ToString());


                DataShow = context.TblProductsMovements.Where(a => a.TblProduct.StoreID == StoID && a.MoveDate >= FromD && a.MoveDate <= ToD).OrderByDescending(a => a.MoveID).Take(300).ToList();

            }

            if (PStore == true && PType == false && PName == false && PAction == true && ISDate == true)
            {

                int StoID = int.Parse(CBActionStore.SelectedValue.ToString());

                int ActID = int.Parse(CBActionProsudre.SelectedValue.ToString());


                DataShow = context.TblProductsMovements.Where(a => a.TblProduct.StoreID == StoID && a.TemporaryID == ActID && a.MoveDate >= FromD && a.MoveDate <= ToD).ToList();

            }


            if (PStore == true && PType == true && PName == false && PAction == true && ISDate == true)
            {

                int StoID = int.Parse(CBActionStore.SelectedValue.ToString());
                int TyID = int.Parse(CbActionType.SelectedValue.ToString());
                int ActID = int.Parse(CBActionProsudre.SelectedValue.ToString());


                DataShow = context.TblProductsMovements.Where(a => a.TblProduct.StoreID == StoID && a.TblProduct.ProductTypeID == TyID && a.TemporaryID == ActID && a.MoveDate >= FromD && a.MoveDate <= ToD).ToList();

            }

            if (PStore == true && PType == true && PName == false && PAction == false && ISDate == true)
            {

                int StoID = int.Parse(CBActionStore.SelectedValue.ToString());
                int TyID = int.Parse(CbActionType.SelectedValue.ToString());



                DataShow = context.TblProductsMovements.Where(a => a.TblProduct.StoreID == StoID && a.TblProduct.ProductTypeID == TyID && a.MoveDate >= FromD && a.MoveDate <= ToD).ToList();

            }

            if (PStore == true && PType == true && PName == true && PAction == false && ISDate == true)
            {
                int StoID = int.Parse(CBActionStore.SelectedValue.ToString());
                int TyID = int.Parse(CbActionType.SelectedValue.ToString());
                int PNID = int.Parse(CBProductName.SelectedValue.ToString());


                DataShow = context.TblProductsMovements.Where(a => a.ProductID == PNID && a.MoveDate >= FromD && a.MoveDate <= ToD).ToList();

            }
            #endregion
            foreach (var item in DataShow)
            {
                var PID = context.TblProducts.Where(a => a.ProductID == item.ProductID).FirstOrDefault();
                var TTpType = context.TblProductTypes.Where(a => a.ProductTypeID == PID.ProductTypeID).Select(a => a.ProductType).FirstOrDefault();

                var MoveType = context.TblTemporaryTypes.Where(a => a.TemporaryID == item.TemporaryID).FirstOrDefault();


                GVShowMoves.Rows.Add(TTpType, PID.ProductName, MoveType.TemporaryType , item.MoveQuantity,item.MoveDate.Value.ToShortDateString(),item.MoveValue,context.TblStores.Where(a=>a.StoreID == PID.StoreID).Select(a=>a.StoreName).FirstOrDefault());
            }




        }

        private void LoadMovemnetType()
        {
            var DataShow = context.TblTemporaryTypes.ToList();

            this.CBActionProsudre.DisplayMember = "TemporaryType";
            this.CBActionProsudre.ValueMember = "TemporaryID";
            this.CBActionProsudre.DataSource = DataShow;
            this.CBActionProsudre.SelectedItem = null;
        }

        private void ICountStore_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            GetDataOfStore(false,false);
            LoadStors();
            LoadTypes();
            GetProductMovments(false, false);
            LoadMovemnetType();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home Ho = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            Ho.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Products Pro = new Products(int.Parse(this.LblUserID.Text));
            Pro.Show();
        }

        private void LblPrint_Click(object sender, EventArgs e)
        {
            if (this.CBStore.SelectedItem == null)
            {
                MessageBox.Show("من فضلك اختار الفرع", "Creative Care");
            }
            else
            {
                ReportStore RS = new ReportStore(int.Parse(this.CBStore.SelectedValue.ToString()));
                RS.Show();
            }
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            CBItemType.SelectedItem = null;
            CBProName.SelectedItem = null;
            CBStore.SelectedItem = null;
            GetDataOfStore(false, false);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
           
            GetDataOfStore(false, true);
        }

        private  void BtnNext_Click(object sender, EventArgs e)
        {
           
            GetDataOfStore(true, false);

        }

        private void GvShowProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (this.LblPostion.Text == "2")
            //{
            //    MessageBox.Show("غير مرخص  لك الدخول", "Creative Care");
            //    MessageBoxManager.Unregister();
            //}
            //else
            //{

                int rowindex = GvShowProducts.SelectedCells[0].RowIndex;

                DataGridViewRow Row = GvShowProducts.Rows[rowindex];

                EditProducts EP = new EditProducts(int.Parse(Row.Cells["ShProductID"].Value.ToString()), int.Parse(this.LblUserID.Text));
                EP.Show();
            //}
        }

        private void GvShowProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double Bob = 0;
            double Toto = 0;
            for (int i = 0; i < GvShowProducts.Rows.Count; ++i)
            {
                Bob += double.Parse(GvShowProducts.Rows[i].Cells["Exist"].Value.ToString());
                Toto += double.Parse(GvShowProducts.Rows[i].Cells["CTotal"].Value.ToString());
            }
            this.LblTotalproducts.Text = Bob.ToString();
            this.LblTotalofprodu.Text = Toto.ToString();
        }

        private void CBProName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetDataOfStore(false, false);
        }

        private void CBItemType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CBStore.SelectedItem == null)
            {

            }
            else
            {
                int TpId = int.Parse(CBItemType.SelectedValue.ToString());
                int StoA = int.Parse(CBStore.SelectedValue.ToString());
                var DataShow = context.TblProducts.Where(a => a.ProductTypeID == TpId && a.StoreID == StoA).ToList();

                this.CBProName.DisplayMember = "ProductName";
                this.CBProName.ValueMember = "ProductID";
                this.CBProName.DataSource = DataShow;
                this.CBProName.SelectedItem = null;
                GetDataOfStore(false, false);
            }
           
        }

        private void CBStore_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetDataOfStore(false, false);
        }

        private void GvShowProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = GvShowProducts.SelectedCells[0].RowIndex;

            DataGridViewRow Row = GvShowProducts.Rows[rowindex];

            EditProducts EP = new EditProducts(int.Parse(Row.Cells["ShProductID"].Value.ToString()), int.Parse(this.LblUserID.Text));
            EP.Show();
        }

        private void BtnMoveNext_Click(object sender, EventArgs e)
        {
            GetProductMovments(true, false);
        }

        private void BtnMoveBack_Click(object sender, EventArgs e)
        {
            GetProductMovments(false,true);
        }

        private void GVShowMoves_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double Bob = 0;
            for (int i = 0; i < GVShowMoves.Rows.Count; ++i)
            {
                Bob += double.Parse(GVShowMoves.Rows[i].Cells["ProTotal"].Value.ToString());
            }
            this.LblAllTotal.Text = Bob.ToString();
        }

        private void CbActionType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CBActionStore.SelectedItem == null)
            {

            }
            else
            {
                int TpId = int.Parse(CbActionType.SelectedValue.ToString());
                int StoA = int.Parse(CBActionStore.SelectedValue.ToString());
                var DataShow = context.TblProducts.Where(a => a.ProductTypeID == TpId && a.StoreID == StoA).ToList();

                this.CBProductName.DisplayMember = "ProductName";
                this.CBProductName.ValueMember = "ProductID";
                this.CBProductName.DataSource = DataShow;
                this.CBProductName.SelectedItem = null;

                GetProductMovments(false, false);
           }
           
        }

        private void CBActionStore_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetProductMovments(false, false);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GetProductMovments(false, false);
        }

        private void CBProductName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetProductMovments(false, false);
        }

        private void CBActionProsudre_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetProductMovments(false, false);
        }
    }
}





public class ChangeTypeinfo
{
    public double Price { get; set; }

    public double AllQuntity { get; set; }
    public double TotalF { get; set; }
}
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
using Spire.Barcode;
using Spire.Barcode.Forms;
using System.Drawing.Printing;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Configuration;

namespace I_Count
{
    public partial class Barcode : Form
    {
        //  SqlConnection Con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Accounting;Data Source=localhost");
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ICountConn"].ConnectionString);
        public Barcode(int ID)
        {
            InitializeComponent();

            // هنا هاياخد ال ID اللى جايله 
            // يروح يدور بيه على اليوزر ويدينى ال IDبتاعه 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TblUsers where UserID=@UserID  ";

            cmd.Parameters.AddWithValue("@UserID", ID);

            SqlDataReader dr;
            Con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                this.LblUserID.Text = dr["UserID"].ToString();
                this.LblUserName.Text = dr["Name"].ToString();

            }

            dr.Close();
            Con.Close();
        }
        //2 وهنا انا بجيب المخزن 
        private void LoadPrintStore()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStore ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStore");
            CBPrintStore.DisplayMember = "StoreName";
            CBPrintStore.ValueMember = "StoreID";
            CBPrintStore.DataSource = ds.Tables["TblStore"];
            CBPrintStore.SelectedItem = null;
            Con.Close();
        }
        /////////////  
        // وهنا انا بجيب المخزن 
        private void LoadStore()
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblStore ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblStore");
            CBStore.DisplayMember = "StoreName";
            CBStore.ValueMember = "StoreID";
            CBStore.DataSource = ds.Tables["TblStore"];
            CBStore.SelectedItem = null;
            Con.Close();
        }
        /////////////  
        private void Barcode_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.LoadStore();
            this.LoadPrintStore();

        }

        private void Pichome_Click(object sender, EventArgs e)
        {
            this.Close();
            Home HO = new Home(this.LblUserName.Text, int.Parse(this.LblUserID.Text));
            HO.Visible = true;
        }

        private void BtnAddNew_MouseHover(object sender, EventArgs e)
        {
            this.BtnAddNew.ImageAlign = ContentAlignment.MiddleRight;
            this.BtnAddNew.Text = " إضافه باركود لمنتج  ";
        }

        private void BtnAddNew_MouseLeave(object sender, EventArgs e)
        {
            this.BtnAddNew.ImageAlign = ContentAlignment.MiddleCenter;
            this.BtnAddNew.Text = " ";
        }

        private void BtnEdit_MouseHover(object sender, EventArgs e)
        {
            this.BtnEdit.ImageAlign = ContentAlignment.MiddleRight;
            this.BtnEdit.Text = " طباعة باركود  ";
        }

        private void BtnEdit_MouseLeave(object sender, EventArgs e)
        {
            this.BtnEdit.ImageAlign = ContentAlignment.MiddleCenter;
            this.BtnEdit.Text = "";
        }

        private void CBStore_SelectionChangeCommitted(object sender, EventArgs e)
        {

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProductType ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblProductType");
            CBItemType.DisplayMember = "ProductType";
            CBItemType.ValueMember = "ProductTypeID";
            CBItemType.DataSource = ds.Tables["TblProductType"];
            CBItemType.SelectedItem = null;
            Con.Close();
        }

        private void CBStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from TblProductType ";

                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "TblProductType");
                CBItemType.DisplayMember = "ProductType";
                CBItemType.ValueMember = "ProductTypeID";
                CBItemType.DataSource = ds.Tables["TblProductType"];
                CBItemType.SelectedItem = null;
                Con.Close();
            }
        }

        private void CBItemType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID ";

            Cmd.Parameters.AddWithValue("@ProductTypeID ", this.CBItemType.SelectedValue);
            Cmd.Parameters.AddWithValue("@StoreID ", this.CBStore.SelectedValue);

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblProducts");
            CBItemName.DisplayMember = "ProductName";
            CBItemName.ValueMember = "ProductID";
            CBItemName.DataSource = ds.Tables["TblProducts"];
            CBItemName.SelectedItem = null;
            Con.Close();
        }

        private void CBItemType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from TblProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID ";

                Cmd.Parameters.AddWithValue("@ProductTypeID ", this.CBItemType.SelectedValue);
                Cmd.Parameters.AddWithValue("@StoreID ", this.CBStore.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "TblProducts");
                CBItemName.DisplayMember = "ProductName";
                CBItemName.ValueMember = "ProductID";
                CBItemName.DataSource = ds.Tables["TblProducts"];
                CBItemName.SelectedItem = null;
                Con.Close();
            }
        }
        private void BtnAuto_Click(object sender, EventArgs e)
        {
            this.PanManualText.Hide();
            string Protype = "المنتج :" + this.CBItemType.Text + "-" + this.CBItemName.Text + Environment.NewLine;

            if (this.CBItemName.SelectedItem==null)
            {
                MessageBox.Show("من فضلك اختار اسم الصنف","Creative Care");
            }
            else
            {
                Random Ran = new Random();
                int abdo = Ran.Next(1, 2000);
                int x = Ran.Next(1000, 200000);
                int BarcodeV = abdo + x ;


                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "update TblProducts set Barcode=@Barcode  where ProductID=@ProductID ";

                Cmd.Parameters.AddWithValue("@Barcode", BarcodeV);
                Cmd.Parameters.AddWithValue("@ProductID", this.CBItemName.SelectedValue);

                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();

                MessageBox.Show("تم إضافة الباركود بنجاح " , "Creative Care");

                DialogResult dialogResult = MessageBox.Show("هل تريد طباعة الباركود", "Creative Care ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.PanPrintYa.Show();
                   
                    this.BarA1.X = 0.8f;
                    this.BarA1.Unit = GraphicsUnit.Millimeter;

                    this.BarA1.Data = BarcodeV.ToString();
                    this.BarA1.Data2D = BarcodeV.ToString();
                    this.BarA1.Type = BarCodeType.Code128;
                    this.BarA1.TopText = Protype;
                    this.BarA1.ShowTopText = true;

                }
                else if (dialogResult == DialogResult.No)
                {
                    this.CBItemName.SelectedItem = null;
                    this.CBItemType.SelectedItem = null;
                    this.CBStore.SelectedItem = null;
                }
            }
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            this.PanAddNew.Show();
            this.PanPrint.Hide();
            this.CBPrintProName.SelectedItem = null;
            this.CBPrintProType.SelectedItem = null;
            this.CBPrintStore.SelectedItem = null;
        
        }

        private void CBItemName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.BtnAuto.Show();
            this.BtnManual.Show();
        }

        private void CBItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BtnAuto.Show();
                this.BtnManual.Show();
            }
        }

        private void BtnConfirmPrintYa_Click(object sender, EventArgs e)
        {
            this.TxtManual.Text = "";
            this.CBItemName.SelectedItem = null;
            this.CBItemType.SelectedItem = null;
            this.CBStore.SelectedItem = null;


            //BarA1.print();         


            BarCodeGenerator bargenerator = new BarCodeGenerator(BarA1);

            Image barcodeimage = bargenerator.GenerateImage();
            barcodeimage.Save(@"E:\Creative.png"); 

            
            var p = new Process();

            p.StartInfo.FileName = @"E:\Creative.png";
            p.StartInfo.Verb = "Print";

            p.Start();

            //this.BarA1.print();
        }

        private void BtnManual_Click(object sender, EventArgs e)
        {
            this.PanManualText.Show();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (this.CBItemName.SelectedItem == null)
            {
                MessageBox.Show("من فضلك اختار اسم الصنف", "Creative Care");
            }
            else
            {
               
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "update TblProducts set Barcode=@Barcode  where ProductID=@ProductID ";

                Cmd.Parameters.AddWithValue("@Barcode", this.TxtManual.Text);
                Cmd.Parameters.AddWithValue("@ProductID", this.CBItemName.SelectedValue);

                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();

                MessageBox.Show("تم إضافة الباركود بنجاح ", "Creative Care");

                DialogResult dialogResult = MessageBox.Show("هل تريد طباعة الباركود", "Creative Care ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.PanPrintYa.Show();

                    string Protype = "المنتج :" + this.CBItemType.Text + "-" + this.CBItemName.Text + Environment.NewLine;

                    this.BarA1.X = 0.8f;
                    this.BarA1.Unit = GraphicsUnit.Millimeter;

                    this.BarA1.Data = this.TxtManual.Text;
                    this.BarA1.Data2D = this.TxtManual.Text ;
                    this.BarA1.Type = BarCodeType.Code128;
                    this.BarA1.TopText = Protype;
                   

                }
                else if (dialogResult == DialogResult.No)
                {
                    this.CBItemName.SelectedItem = null;
                    this.CBItemType.SelectedItem = null;
                    this.CBStore.SelectedItem = null;
                }
            }
        }

        private void BtnAddInfo_Click(object sender, EventArgs e)
        {
            
            try
            {
                this.BarA1.TopText += " اسم المكان : " + this.TxtPalceName.Text + Environment.NewLine;
                this.BarA1.TopText += " التليفون : " + this.TxtPlacePhone.Text + Environment.NewLine;
                this.TxtPlacePhone.Text = "";
                this.TxtPalceName.Text = "";

            }
            catch (Exception)
            {
                
                
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            this.PanAddNew.Hide();
            this.PanPrint.Show();
            this.CBItemName.SelectedItem = null;
            this.CBItemType.SelectedItem = null;
            this.CBStore.SelectedItem = null;

        }

        private void CBPrintStore_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProductType ";

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblProductType");
            CBPrintProType.DisplayMember = "ProductType";
            CBPrintProType.ValueMember = "ProductTypeID";
            CBPrintProType.DataSource = ds.Tables["TblProductType"];
            CBPrintProType.SelectedItem = null;
            Con.Close();
        }

        private void CBPrintStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from TblProductType ";

                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "TblProductType");
                CBPrintProType.DisplayMember = "ProductType";
                CBPrintProType.ValueMember = "ProductTypeID";
                CBPrintProType.DataSource = ds.Tables["TblProductType"];
                CBPrintProType.SelectedItem = null;
                Con.Close();
            }
        }

        private void CBPrintProType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID ";

            Cmd.Parameters.AddWithValue("@ProductTypeID ", this.CBPrintProType.SelectedValue);
            Cmd.Parameters.AddWithValue("@StoreID ", this.CBPrintStore.SelectedValue);

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            Con.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "TblProducts");
            CBPrintProName.DisplayMember = "ProductName";
            CBPrintProName.ValueMember = "ProductID";
            CBPrintProName.DataSource = ds.Tables["TblProducts"];
            CBPrintProName.SelectedItem = null;
            Con.Close();
        }

        private void CBPrintProType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from TblProducts where ProductTypeID=@ProductTypeID and StoreID=@StoreID ";

                Cmd.Parameters.AddWithValue("@ProductTypeID ", this.CBPrintProType.SelectedValue);
                Cmd.Parameters.AddWithValue("@StoreID ", this.CBPrintStore.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                Con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "TblProducts");
                CBPrintProName.DisplayMember = "ProductName";
                CBPrintProName.ValueMember = "ProductID";
                CBPrintProName.DataSource = ds.Tables["TblProducts"];
                CBPrintProName.SelectedItem = null;
                Con.Close();
            }
        }

        private void CBPrintProName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from TblProducts where ProductID=@ProductID ";

            Cmd.Parameters.AddWithValue("@ProductID", this.CBPrintProName.SelectedValue);

            SqlDataReader dr;
            Con.Open();
            dr = Cmd.ExecuteReader();
            if (dr.Read())
            {
                
                string x=dr["Barcode"].ToString();
                if (x.Length <= 0)
                {
                    MessageBox.Show("المنتج ليس له رقم باركود", "Creative Care");
                }
                else
                {
                    this.BarPrint.Show();
                    string Protype = "المنتج :" + this.CBPrintProType.Text + " - " + this.CBPrintProName.SelectedText + Environment.NewLine;

                    this.BarPrint.X = 0.8f;
                    this.BarPrint.Unit = GraphicsUnit.Millimeter;

                    this.BarPrint.Data = x;
                    this.BarPrint.Data2D = x;
                    this.BarPrint.Type = BarCodeType.Code128;
                    this.BarPrint.TopText = Protype;

                }
            }

            dr.Close();
            Con.Close();

        }

        private void CBPrintProName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from TblProducts where ProductID=@ProductID ";

                Cmd.Parameters.AddWithValue("@ProductID", this.CBPrintProName.SelectedValue);

                SqlDataReader dr;
                Con.Open();
                dr = Cmd.ExecuteReader();
                if (dr.Read())
                {

                    string x = dr["Barcode"].ToString();
                    if (x.Length <= 0)
                    {
                        MessageBox.Show("المنتج ليس له رقم باركود", "Creative Care");
                    }
                    else
                    {
                        this.BarPrint.Show();
                        string Protype = "المنتج :" + this.CBPrintProType.Text + " - " + this.CBPrintProName.SelectedText + Environment.NewLine;

                        this.BarPrint.X = 0.8f;
                        this.BarPrint.Unit = GraphicsUnit.Millimeter;

                        this.BarPrint.Data = x;
                        this.BarPrint.Data2D = x;
                        this.BarPrint.Type = BarCodeType.Code128;
                        this.BarPrint.TopText = Protype;

                    }
                }

                dr.Close();
                Con.Close();
            }
        }

        private void BtnAddPrintInfo_Click(object sender, EventArgs e)
        {
            try
            {
                this.BarPrint.TopText += " اسم المكان : " + this.TxtPrintPlaceName.Text + Environment.NewLine;
                this.BarPrint.TopText += " التليفون : " + this.TxtPrintPhone.Text + Environment.NewLine;
                this.TxtPrintPlaceName.Text = "";
                this.TxtPrintPhone.Text = "";

            }
            catch (Exception)
            {


            }
        }

        private void BtnPrintConfirm_Click(object sender, EventArgs e)
        {
          
            this.CBPrintProName.SelectedItem = null;
            this.CBPrintProType.SelectedItem = null;
            this.CBPrintStore.SelectedItem = null;

            //this.BarPrint.print();
            BarCodeGenerator bargenerator = new BarCodeGenerator(BarPrint);

            Image barcodeimage = bargenerator.GenerateImage();
            barcodeimage.Save(@"E:\Creative.png");
            var p = new Process();

            p.StartInfo.FileName = @"E:\Creative.png";
            p.StartInfo.Verb = "Print";

            p.Start();
        }
    }
}

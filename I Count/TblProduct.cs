//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace I_Count
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblProduct
    {
        public TblProduct()
        {
            this.TblBackInBills = new HashSet<TblBackInBill>();
            this.TblBackOutBills = new HashSet<TblBackOutBill>();
            this.TblCorruptedBills = new HashSet<TblCorruptedBill>();
            this.TblProductsMovements = new HashSet<TblProductsMovement>();
            this.TblPurchases = new HashSet<TblPurchas>();
            this.TblSales = new HashSet<TblSale>();
            this.TblTransfers = new HashSet<TblTransfer>();
        }
    
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> ProductTypeID { get; set; }
        public string Price { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string SalePrice1 { get; set; }
        public string SalePrice2 { get; set; }
        public Nullable<double> Exist { get; set; }
        public string Barcode { get; set; }
        public Nullable<int> BillID { get; set; }
        public string Minimum { get; set; }
        public Nullable<bool> ISUnit { get; set; }
        public Nullable<double> QuntAll { get; set; }
        public Nullable<long> Serial { get; set; }
        public string BigUnitBarcode { get; set; }
        public Nullable<int> UnitID { get; set; }
    
        public virtual ICollection<TblBackInBill> TblBackInBills { get; set; }
        public virtual ICollection<TblBackOutBill> TblBackOutBills { get; set; }
        public virtual TblBill TblBill { get; set; }
        public virtual TblBill TblBill1 { get; set; }
        public virtual ICollection<TblCorruptedBill> TblCorruptedBills { get; set; }
        public virtual TblProductType TblProductType { get; set; }
        public virtual TblStore TblStore { get; set; }
        public virtual ICollection<TblProductsMovement> TblProductsMovements { get; set; }
        public virtual ICollection<TblPurchas> TblPurchases { get; set; }
        public virtual ICollection<TblSale> TblSales { get; set; }
        public virtual ICollection<TblTransfer> TblTransfers { get; set; }
    }
}

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
    
    public partial class TblBill
    {
        public TblBill()
        {
            this.TblProducts = new HashSet<TblProduct>();
            this.TblProducts1 = new HashSet<TblProduct>();
            this.TblPurchases = new HashSet<TblPurchas>();
        }
    
        public int BillID { get; set; }
        public Nullable<System.DateTime> DateOfBill { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public string TotalPaid { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Paid { get; set; }
        public Nullable<int> StoreID { get; set; }
    
        public virtual TblProvider TblProvider { get; set; }
        public virtual TblStore TblStore { get; set; }
        public virtual TblUser TblUser { get; set; }
        public virtual TblUser TblUser1 { get; set; }
        public virtual ICollection<TblProduct> TblProducts { get; set; }
        public virtual ICollection<TblProduct> TblProducts1 { get; set; }
        public virtual ICollection<TblPurchas> TblPurchases { get; set; }
    }
}

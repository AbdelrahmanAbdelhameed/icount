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
    
    public partial class TblSaleBill
    {
        public TblSaleBill()
        {
            this.TblSales = new HashSet<TblSale>();
        }
    
        public int SaleBillID { get; set; }
        public Nullable<System.DateTime> BillDate { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string Total { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Paid { get; set; }
        public string Earn { get; set; }
        public string Discount { get; set; }
        public Nullable<int> StoreID { get; set; }
    
        public virtual TblCustomer TblCustomer { get; set; }
        public virtual TblStore TblStore { get; set; }
        public virtual TblUser TblUser { get; set; }
        public virtual ICollection<TblSale> TblSales { get; set; }
    }
}

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
    
    public partial class TblPurchas
    {
        public int purchasesID { get; set; }
        public Nullable<int> BillID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> ProductTypeID { get; set; }
        public string Quantity { get; set; }
        public string BPrice { get; set; }
        public string BTatol { get; set; }
    
        public virtual TblBill TblBill { get; set; }
        public virtual TblProduct TblProduct { get; set; }
        public virtual TblProductType TblProductType { get; set; }
    }
}
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
    
    public partial class TblRepaySale
    {
        public int RepayBilIDl { get; set; }
        public Nullable<System.DateTime> DateOfPay { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string TotalMoneyPaied { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> StorageID { get; set; }
    
        public virtual TblCustomer TblCustomer { get; set; }
        public virtual TblStorage TblStorage { get; set; }
        public virtual TblUser TblUser { get; set; }
    }
}
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
    
    public partial class TblBackInBill
    {
        public int BackInBillID { get; set; }
        public Nullable<int> BackInID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string BackProNu { get; set; }
        public string InPrice { get; set; }
        public string InTotal { get; set; }
    
        public virtual TblBackIn TblBackIn { get; set; }
        public virtual TblProduct TblProduct { get; set; }
    }
}

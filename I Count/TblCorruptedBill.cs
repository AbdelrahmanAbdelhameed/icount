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
    
    public partial class TblCorruptedBill
    {
        public int CorruptedBillID { get; set; }
        public Nullable<int> CorruptedID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string CorruptedNum { get; set; }
        public string CoMoney { get; set; }
    
        public virtual TblCorrupted TblCorrupted { get; set; }
        public virtual TblProduct TblProduct { get; set; }
    }
}

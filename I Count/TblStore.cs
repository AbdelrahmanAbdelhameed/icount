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
    
    public partial class TblStore
    {
        public TblStore()
        {
            this.TblBackIns = new HashSet<TblBackIn>();
            this.TblBackOuts = new HashSet<TblBackOut>();
            this.TblBills = new HashSet<TblBill>();
            this.TblCorrupteds = new HashSet<TblCorrupted>();
            this.TblProducts = new HashSet<TblProduct>();
            this.TblSaleBills = new HashSet<TblSaleBill>();
            this.TblStorages = new HashSet<TblStorage>();
            this.TblTransferBills = new HashSet<TblTransferBill>();
        }
    
        public int StoreID { get; set; }
        public string StoreName { get; set; }
    
        public virtual ICollection<TblBackIn> TblBackIns { get; set; }
        public virtual ICollection<TblBackOut> TblBackOuts { get; set; }
        public virtual ICollection<TblBill> TblBills { get; set; }
        public virtual ICollection<TblCorrupted> TblCorrupteds { get; set; }
        public virtual ICollection<TblProduct> TblProducts { get; set; }
        public virtual ICollection<TblSaleBill> TblSaleBills { get; set; }
        public virtual ICollection<TblStorage> TblStorages { get; set; }
        public virtual ICollection<TblTransferBill> TblTransferBills { get; set; }
    }
}

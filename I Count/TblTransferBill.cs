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
    
    public partial class TblTransferBill
    {
        public TblTransferBill()
        {
            this.TblTransfers = new HashSet<TblTransfer>();
        }
    
        public int TransferBillID { get; set; }
        public Nullable<System.DateTime> TransferDate { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string StoreTo { get; set; }
    
        public virtual TblStore TblStore { get; set; }
        public virtual ICollection<TblTransfer> TblTransfers { get; set; }
        public virtual TblUser TblUser { get; set; }
    }
}

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
    
    public partial class TblBackOut
    {
        public TblBackOut()
        {
            this.TblBackOutBills = new HashSet<TblBackOutBill>();
        }
    
        public int BackoutID { get; set; }
        public Nullable<System.DateTime> DateOfBackout { get; set; }
        public string TotalMony { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public Nullable<int> StoreID { get; set; }
    
        public virtual TblProvider TblProvider { get; set; }
        public virtual TblStore TblStore { get; set; }
        public virtual TblUser TblUser { get; set; }
        public virtual ICollection<TblBackOutBill> TblBackOutBills { get; set; }
    }
}

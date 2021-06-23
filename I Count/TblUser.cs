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
    
    public partial class TblUser
    {
        public TblUser()
        {
            this.TblBackIns = new HashSet<TblBackIn>();
            this.TblBackOuts = new HashSet<TblBackOut>();
            this.TblBills = new HashSet<TblBill>();
            this.TblBills1 = new HashSet<TblBill>();
            this.TblCorrupteds = new HashSet<TblCorrupted>();
            this.TblExpenses = new HashSet<TblExpens>();
            this.TblIncomes = new HashSet<TblIncome>();
            this.TblLogs = new HashSet<TblLog>();
            this.TblProcedures = new HashSet<TblProcedure>();
            this.TblRepayDebts = new HashSet<TblRepayDebt>();
            this.TblRepaySales = new HashSet<TblRepaySale>();
            this.TblSaleBills = new HashSet<TblSaleBill>();
            this.TblTemps = new HashSet<TblTemp>();
            this.TblTransferBills = new HashSet<TblTransferBill>();
        }
    
        public int UserID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TelephoneNumber { get; set; }
        public Nullable<int> PositionID { get; set; }
    
        public virtual ICollection<TblBackIn> TblBackIns { get; set; }
        public virtual ICollection<TblBackOut> TblBackOuts { get; set; }
        public virtual ICollection<TblBill> TblBills { get; set; }
        public virtual ICollection<TblBill> TblBills1 { get; set; }
        public virtual ICollection<TblCorrupted> TblCorrupteds { get; set; }
        public virtual ICollection<TblExpens> TblExpenses { get; set; }
        public virtual ICollection<TblIncome> TblIncomes { get; set; }
        public virtual ICollection<TblLog> TblLogs { get; set; }
        public virtual TblPosition TblPosition { get; set; }
        public virtual ICollection<TblProcedure> TblProcedures { get; set; }
        public virtual ICollection<TblRepayDebt> TblRepayDebts { get; set; }
        public virtual ICollection<TblRepaySale> TblRepaySales { get; set; }
        public virtual ICollection<TblSaleBill> TblSaleBills { get; set; }
        public virtual ICollection<TblTemp> TblTemps { get; set; }
        public virtual ICollection<TblTransferBill> TblTransferBills { get; set; }
    }
}
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
    
    public partial class TblProcedure
    {
        public int ProcedureID { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureValue { get; set; }
        public Nullable<System.DateTime> ProcedureDate { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> StorageID { get; set; }
    
        public virtual TblStorage TblStorage { get; set; }
        public virtual TblUser TblUser { get; set; }
    }
}

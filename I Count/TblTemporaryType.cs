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
    
    public partial class TblTemporaryType
    {
        public TblTemporaryType()
        {
            this.TblProductsMovements = new HashSet<TblProductsMovement>();
            this.TblTemporaries = new HashSet<TblTemporary>();
        }
    
        public int TemporaryID { get; set; }
        public string TemporaryType { get; set; }
    
        public virtual ICollection<TblProductsMovement> TblProductsMovements { get; set; }
        public virtual ICollection<TblTemporary> TblTemporaries { get; set; }
    }
}

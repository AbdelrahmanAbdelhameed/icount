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
    
    public partial class TblUnit
    {
        public TblUnit()
        {
            this.TblUnits1 = new HashSet<TblUnit>();
        }
    
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public Nullable<int> SmallUnitID { get; set; }
        public Nullable<double> Small_Unit_number { get; set; }
        public Nullable<bool> ISSmall { get; set; }
    
        public virtual ICollection<TblUnit> TblUnits1 { get; set; }
        public virtual TblUnit TblUnit1 { get; set; }
    }
}

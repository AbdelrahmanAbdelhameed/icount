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
    
    public partial class TblWeek
    {
        public TblWeek()
        {
            this.TblNoteBooks = new HashSet<TblNoteBook>();
        }
    
        public int WeekDayID { get; set; }
        public string WeekDayN { get; set; }
    
        public virtual ICollection<TblNoteBook> TblNoteBooks { get; set; }
    }
}

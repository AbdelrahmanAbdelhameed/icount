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
    
    public partial class TblNoteBook
    {
        public int NoteID { get; set; }
        public Nullable<int> WeekDayID { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public string NoteMoney { get; set; }
    
        public virtual TblProvider TblProvider { get; set; }
        public virtual TblWeek TblWeek { get; set; }
    }
}
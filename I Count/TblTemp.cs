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
    
    public partial class TblTemp
    {
        public int TempID { get; set; }
        public string TypeName { get; set; }
        public string ProductName { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> Quntity { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<double> SalePrice1 { get; set; }
        public Nullable<double> SalePrice2 { get; set; }
        public Nullable<double> Minimum { get; set; }
        public string Notes { get; set; }
        public string Barcode { get; set; }
        public Nullable<bool> Isunit { get; set; }
        public Nullable<int> UnitId { get; set; }
        public Nullable<int> TempType { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<double> Earn { get; set; }
        public Nullable<double> Exsit { get; set; }
        public Nullable<long> ProductId { get; set; }
        public Nullable<long> ProducttypeID { get; set; }
    
        public virtual TblUser TblUser { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MOpningBalnence
    {
        public long TID { get; set; }
        public long CompanyId { get; set; }
        public string Module { get; set; }
        public string Tcode { get; set; }
        public long CustomerId { get; set; }
        public string Actype { get; set; }
        public string Fyear { get; set; }
        public Nullable<decimal> openingBal { get; set; }
        public string AcFlag { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string Remark { get; set; }
        public Nullable<long> ProductTypeID { get; set; }
    }
}
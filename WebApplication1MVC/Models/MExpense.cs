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
    
    public partial class MExpense
    {
        public long Expenseid { get; set; }
        public long Compnyid { get; set; }
        public string Module { get; set; }
        public string ExpenseCode { get; set; }
        public string ExpenseName { get; set; }
        public string Specification { get; set; }
        public Nullable<decimal> MaxLimit { get; set; }
        public string Acflag { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string Remark { get; set; }
        public string ProductionFlag { get; set; }
        public string BatchExpense { get; set; }
    }
}

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
    
    public partial class MMenu
    {
        public Nullable<long> CompanyId { get; set; }
        public long MenuId { get; set; }
        public string Module { get; set; }
        public string MenuName { get; set; }
        public string ParentId { get; set; }
        public string AcFlag { get; set; }
        public Nullable<int> createdBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string Tag { get; set; }
    }
}

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
    
    public partial class Muser
    {
        public long CompanyId { get; set; }
        public string module { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserPwd { get; set; }
        public string UserType { get; set; }
        public string AcFlag { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
    }
}

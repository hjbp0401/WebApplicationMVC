using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1MVC.Models
{
    public class MMenuModel
    {
        public int CompanyId { get; set; }

        public int MenuId { get; set; }

        public string Module { get; set; }

        public string MenuName { get; set; }

        public string ParentId { get; set; }

        public string AcFlag { get; set; }

        public int createdBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Tag { get; set; }

        public string Flag { get; set; }


    }
}
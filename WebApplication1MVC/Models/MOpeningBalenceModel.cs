using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1MVC.Models
{
    public class MOpeningBalenceModel
    {
        public int TID { get; set; }

        public int CompanyId { get; set; }

        public string Module { get; set; }

        public string Tcode { get; set; }

        public int CustomerId { get; set; }

        public string Actype { get; set; }

        public string Fyear { get; set; }

        public string openingBalence { get; set; }

        public string AcFlag { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Remark { get; set; }

        public int ProductTypeID { get; set; }

    }
}
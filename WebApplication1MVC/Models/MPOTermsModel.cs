using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1MVC.Models
{
    public class MPOTermsModel
    {
        public int POtermId { get; set; }

        public int CompanyId { get; set; }

        public string Module { get; set; }

        public string POtermCode { get; set; }

        public string POtermsName { get; set; }

        public string Description { get; set; }

        public string Acflag { get; set; }

        public int Createdby { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Remark { get; set; }


    }
}
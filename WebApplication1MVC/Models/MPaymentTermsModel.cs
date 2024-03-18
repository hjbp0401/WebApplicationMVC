using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1MVC.Models
{
    public class MPaymentTermsModel
    {
        public int PaymentTermId { get; set; }

        public string PaymentTermCode { get; set; }

        public string PaymentTermDesc { get; set; }

        public string Dayss { get; set; }

        public string Acflag { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Remarks { get; set; }


    }
}
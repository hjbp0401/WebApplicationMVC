using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1MVC.Models
{
    public class MpackingModel
    {
        public int PackingId { get; set; }

        public string PackingCode { get; set; }

        public string PackingName { get; set; }

        public string AcFlag { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Remark { get; set; }



    }
}
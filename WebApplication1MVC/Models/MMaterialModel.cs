using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1MVC.Models
{
    public class MMaterialModel
    {
        public int MaterialId { get; set; }

        public string MaterialCode { get; set; }

        public string MaterialName { get; set; }

        public int MaterialUnit { get; set; }

        public int PackingId { get; set; }

        public string ForCasteFlag { get; set; }

        public string AcFlag { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Remark { get; set; }

    }
}
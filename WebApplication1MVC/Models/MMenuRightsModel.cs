using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1MVC.Models
{
    public class MMenuRightsModel
    {
        public int MenuId { get; set; }

        public int Module { get; set; }

        public int UserId { get; set; }

        public string AcFlag { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }



    }
}
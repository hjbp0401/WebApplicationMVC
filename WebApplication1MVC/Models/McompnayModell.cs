using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1MVC.Models
{
    public class McompnayModell
    {
        //changes

        public int CompanyID { get; set; }
        [Required(ErrorMessage ="Required")]
        public string CompanyCode { get; set; }
        [Required(ErrorMessage = "Required")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string CompanyAddress { get; set; }
        [Required(ErrorMessage = "Required")]
        public string phoneNo { get; set; }
        [Required(ErrorMessage = "Required")]
        public string CellNO { get; set; }
        [Required(ErrorMessage = "Required")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string PANNo { get; set; }
        [Required(ErrorMessage = "Required")]
        public string CST { get; set; }
        [Required(ErrorMessage = "Required")]
        public string BST { get; set; }

        [Required(ErrorMessage = "Required")]

        public string Acflag { get; set; }
        [Required(ErrorMessage = "Required")]

        public int CreatedBy { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime CreatedOn { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Remark { get; set; }
        [Required(ErrorMessage = "Required")]
        public string TallyID { get; set; }
        [Required(ErrorMessage = "Required")]

        public string ImagePath { get; set; }

        public HttpPostedFileBase Imagefile { get; set; }
      

        public string Flag { get; set; }   

       
    }
}
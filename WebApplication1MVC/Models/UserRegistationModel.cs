using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1MVC.Models
{
    public class UserRegistationModel
    {
        [Required]
       public string  UserName {  get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required] 
        public string Password { get; set; }
        [Required]
        public string ConfrmPassword { get; set; }
    }
}
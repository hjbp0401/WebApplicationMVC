using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1MVC.Models
{
    public class MexpenseModel
    {
        public int Expenseid { get; set; }

        public int Compnyid { get; set; }

        public string Module { get; set; }

        public string ExpenseCode { get; set; }

        public string ExpenseName { get; set; }

        public string Specification { get; set; }

        public decimal MaxLimit { get; set; }

        public string Acflag { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Remark { get; set; }

        public string ProductionFlag { get; set; }

        public string BatchExpense { get; set; }



    }
}
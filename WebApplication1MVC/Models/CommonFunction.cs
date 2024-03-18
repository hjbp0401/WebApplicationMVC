using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1MVC.Models
{
    public class CommonFunction
    {
        public SqlConnection Connect()
        {
            string ConnectionString = "Data Source=DESKTOP-8CRFOK8; Initial Catalog=MyBrokerage; User Id=sa; Password=Game@123;";
            SqlConnection SqlCon = new SqlConnection(ConnectionString);

            try
            {

                SqlCon.Close();
                SqlCon.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return SqlCon;

        }


    }
}
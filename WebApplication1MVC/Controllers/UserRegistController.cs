using BrokerageConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1MVC.Models;

namespace WebApplication1MVC.Controllers
{
    public class UserRegistController : Controller
    {
        public ActionResult UserRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserRegister (UserRegistationModel Model)
        {

            string query = "select * from UserRegistration where UserName='" + Model.UserName + "' AND EmailId='" + Model.EmailId + "'";
           SqlDataReader dr = CheckUser(query);
           

            if(dr.Read())
            {
                return View("UserRegister");
            }
            else
            {
                CommonFunction cf = new CommonFunction();
                SqlConnection sqlcon = cf.Connect();
                SqlCommand cmd = new SqlCommand();

                try

                {
                    cmd.CommandText = "SP_UserRegister";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = sqlcon;

                    cmd.Parameters.AddWithValue("@UserName", Model.UserName);
                    cmd.Parameters.AddWithValue("@EmailId", Model.EmailId);
                    cmd.Parameters.AddWithValue("@Password", Model.Password);
                    cmd.Parameters.AddWithValue("@ConfrmPassword ", Model.ConfrmPassword);

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw ex;

                }
                finally
                {
                    cmd.Dispose();
                    sqlcon.Close();
                }
            }
            

           
            

            return View("UserLogin");

        }

        private SqlDataReader CheckUser(string query)
        {
            CommonFunction cf = new CommonFunction();
            SqlConnection sqlcon = cf.Connect();
            SqlCommand cmd = new SqlCommand(query,sqlcon);
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(UserRegistationModel Model)
        {
            string query = "select * from UserRegistration where UserName='" + Model.UserName + "' AND Password='" + Model.Password + "'";
            SqlDataReader dr = CheckUser(query);

            if (dr.Read())
            {
                return RedirectToAction("Index","MCompany");
            }


            return View();
        }



    }
}
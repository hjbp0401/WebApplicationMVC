using BrokerageConnection;
using BrokerageModel.MasterModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1MVC.Controllers
{
    public class McustomerController : Controller
    {
        // GET: Mcustomer
        public ActionResult SaveData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveData(MCustomerModel Model) 
        {

            string Flag;
            int responce;

            if (Model.CustomerId == 0)
            {
                Flag = "I";
                responce = 1;
            }

            else
            {
                Flag = "U";
                responce = 2;
            }

            CommonFunction cf = new CommonFunction();
            SqlConnection sqlcon = cf.Connect();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Parameters.AddWithValue("@CustomerId", Model.CustomerId);
                cmd.Parameters.AddWithValue("@CustomerCode", Model.CustomerCode);
                cmd.Parameters.AddWithValue("@BrokeragePer", Model.BrokeragePer);
                cmd.Parameters.AddWithValue("@CustomerName", Model.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerAddress", Model.CustomerAddress);
                cmd.Parameters.AddWithValue("@PhoneNo", Model.PhoneNo);
                cmd.Parameters.AddWithValue("@CellNo", Model.CellNo);
                cmd.Parameters.AddWithValue("@BankId", Model.BankId);
                cmd.Parameters.AddWithValue("@AccountNo", Model.AccountNo);
                cmd.Parameters.AddWithValue("@IFScCode", Model.IFScCode);
                cmd.Parameters.AddWithValue("@VATNo", Model.VATNo);
                cmd.Parameters.AddWithValue("@CSTNo", Model.CSTNo);
                cmd.Parameters.AddWithValue("@BSTNo", Model.BSTNo);
                cmd.Parameters.AddWithValue("@PANNo", Model.PANNo);
                cmd.Parameters.AddWithValue("@EmailId", Model.EmailId);
                cmd.Parameters.AddWithValue("@FAXNo", Model.FAXNo);
                cmd.Parameters.AddWithValue("@ContactPerson", Model.ContactPerson);
                cmd.Parameters.AddWithValue("@Acflag", Model.Acflag);
                cmd.Parameters.AddWithValue("@CreatedBy", Model.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedOn", Model.CreatedOn);
                cmd.Parameters.AddWithValue("@Remark", Model.Remark);
                cmd.Parameters.AddWithValue("@BankName", Model.BankName);
                cmd.Parameters.AddWithValue("@BranchName", Model.BranchName);
                cmd.Parameters.AddWithValue("@BankAdress", Model.BankAdress);
                cmd.Parameters.AddWithValue("@Flag",Flag);

                cmd.ExecuteNonQuery();
            }
             catch (Exception ex) 
            {
             var st = new System.Diagnostics.StackTrace(ex, true);
                var frame = st.GetFrame(st.FrameCount - 1);
                var linenumber = frame.GetFileLineNumber();
                cf.ErrorLog("McustomerController", "SaveData", linenumber.ToString(), ex.ToString());
                responce = 3;
            }
            finally
            {
            
                cmd.Dispose();
                sqlcon.Close();
            
            
            }

            if(responce == 1)
            {
                TempData["Message"] = "<script>alert(Data inserted!!)</script>";
            }
            else if (responce == 2)
            {
                TempData["Message"] = "<Script>alert(Data Updated!!)</script>";
            }
            else
            {

                TempData["Message"] = "<script>alret(oops something wrong)</script>";
            }

               



                
                 return View("SaveData");
        
        }
         
         public ActionResult GetReport()
        {
            List<MCustomerModel> list = new List<MCustomerModel>();
            CommonFunction cf = new CommonFunction();
            DataTable dt = cf.GetDataTable("Select isnull([CustomerId],0)as[CustomerId],isnull([CustomerCode],0)as[CustomerCode],isnull([BrokeragePer],0)as[]BrokeragePer,isnull([CustomerName],0)as[CustomerName],isnull([CustomerAddress],0)as[CustomerAddress],isnull([PhoneNo],0)as[PhoneNo],isnull([CellNo],0)as[CellNo], isnull([BankId],0)as[BankId], isnull([AccountNo],0)as[AccountNo], isnull([IFScCode],0)as[IFScCode],isnull([VATNo],0)as[VATNo],isnull([CSTNo],0)as[CSTNo],isnull([BSTNo],0)as[BSTNo],isnull([PANNo],0)as[PANNo], isnull([EmailId],0)as[EmailId],is([FAXNo],0)as[FAXNo],isnull([ContactPerson],0)as[ContactPerson],isnull([Acflag],0)as[Acflag],isnull([CreatedBy],0)as[CreatedBy],isnull([CreatedOn],0)as[CreatedOn],isnull([Remark],0)as[Remark],isnull([BankName],0)as[BankName],isnull([BranchName],0)as[BranchName],isnull([BankAdress],0)as[BankAdress] from Mcustomer");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MCustomerModel model = new MCustomerModel();

                model.CustomerId = Convert.ToInt32(dt.Rows[i]["CustomerId"]);
                model.CustomerCode = dt.Rows[i]["CustomerCode"].ToString();
                model.CustomerName = dt.Rows[i]["CustomerName"].ToString();
                model.CustomerAddress = dt.Rows[i]["CustomerAddress"].ToString();
                model.BrokeragePer = dt.Rows[i]["BrokeragePer"].ToString();
                model.BankAdress = dt.Rows[i]["BankAdress"].ToString();
                model.EmailId = dt.Rows[i]["EmailId"].ToString();
                model.Acflag = dt.Rows[i]["Acflag"].ToString();
                model.AccountNo = Convert.ToInt32( dt.Rows[i]["AccountNo"]);
                model.BankId = Convert.ToInt32 (dt.Rows[i]["BankId"]);
                model.Remark = dt.Rows[i]["Remark"].ToString() ;
                model.BSTNo = dt.Rows[i]["BSTNo"].ToString ();
                model.CSTNo = dt.Rows[i]["CSTNo"].ToString () ;
                model.ContactPerson = dt.Rows[i]["ContactPerson"].ToString();
                model.CellNo = dt.Rows[i]["CellNo"].ToString();
                model.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
                model.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                model.IFScCode = dt.Rows[i]["IFScCode"].ToString();
                model.FAXNo = dt.Rows[i]["FAXNo"].ToString();
                model.PANNo = dt.Rows[i]["PANNo"].ToString();
                model.BankName = dt.Rows[i]["BankName"].ToString();
                model.BranchName = dt.Rows[i]["BranchName"].ToString();
                model.VATNo = dt.Rows[i]["VATNo"].ToString();
                model.PhoneNo = dt.Rows[i]["PhoneNo"].ToString();
                model.CellNo = dt.Rows[i]["CellNo"].ToString();





            }

                return View();



        }

        public ActionResult Delete(int id )
        {
            CommonFunction cf = new CommonFunction();
            SqlConnection sqlcon = cf.Connect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_DelMCustomer";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlcon;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();

            return RedirectToAction("Index");

        }



    }
}
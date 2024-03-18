using BrokerageConnection;
using BrokerageModel.MasterModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1MVC.Models;

namespace WebApplication1MVC.Controllers
{
    public class MexpenseController : Controller
    {

        // GET: Mexpense
        SqlConnection sqlcon;
        SqlCommand cmd;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(MexpenseModel model)
        {
            string Flag;
            int responce;

            if (model.Expenseid == 0)
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
                cmd.CommandText = "SP_Mexpenses";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = sqlcon;
                cmd.Parameters.AddWithValue("@Expenseid", model.Expenseid);
                cmd.Parameters.AddWithValue("@Companyid", model.Compnyid);
                cmd.Parameters.AddWithValue("@Module", model.Module);
                cmd.Parameters.AddWithValue("@ExpenseCode", model.ExpenseCode);
                cmd.Parameters.AddWithValue("@ExpenseName ", model.ExpenseName);
                cmd.Parameters.AddWithValue("@Specification", model.Specification);
                cmd.Parameters.AddWithValue("@MaxLimit", model.MaxLimit);
                cmd.Parameters.AddWithValue("@Acflag", model.Acflag);
                cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedOn", model.CreatedOn);
                cmd.Parameters.AddWithValue("@Remark", model.Remark);
                cmd.Parameters.AddWithValue("@ProductionFlag ", model.ProductionFlag);
                cmd.Parameters.AddWithValue("@BatchExpense", model.BatchExpense);
                cmd.Parameters.AddWithValue("@Flag", Flag);

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
            if (responce == 1)
            {
                TempData["Message"] = "<script>alert('Data inserted!!')</script>";
            }
            else if (responce == 2)
            {
                TempData["Message"] = "<script>alert('Data updated!!')</script>";

            }

            else
            {
                TempData["Message"] = "<script>alert('oops something wrong')";
            }



            return View("Index");

        }

        public ActionResult Getuser()
        {
            List<MexpenseModel> list = new List<MexpenseModel>();
            CommonFunction cf = new CommonFunction();
            DataTable dt = cf.GetDataTable("select isnull([Expenseid],0)as[Expenseid],isnull([Compnyid],0)as[Compnyid],isnull([Module],0)as[Module],isnull([ExpenseCode],0)[ExpenseCode],isnull([ExpenseName],0)[ExpenseName],isnull([Specification],0)[Specification],isnull([MaxLimit],0)[MaxLimit],isnull([Acflag],0)[Acflag],isnull([CreatedBy],0)[CreatedBy],isnull([CreatedOn],0),[CreatedOn],isnull([Remark]),[Remark],isnull([ProductionFlag],0)[ProductionFlag],isnull([BatchExpense],0)[BatchExpense]");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MexpenseModel model = new MexpenseModel();

                model.Expenseid = Convert.ToInt32(dt.Rows[i]["Expenseid"]);
                model.Compnyid = Convert.ToInt32(dt.Rows[i]["Compnyid"]);
                model.Module = dt.Rows[i]["Module"].ToString();
                model.ExpenseCode = dt.Rows[i]["ExpenseCode"].ToString();
                model.ExpenseName = dt.Rows[i]["ExpenseName"].ToString();
                model.Specification = dt.Rows[i]["Specification"].ToString();
                model.MaxLimit = Convert.ToUInt32(dt.Rows[i]["MaxLimit"]);
                model.Acflag = dt.Rows[i]["Acflag"].ToString();
                model.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
                model.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedBy"]);
                model.Remark = dt.Rows[i]["Remark"].ToString();
                model.ProductionFlag = dt.Rows[i]["Production"].ToString();
                model.BatchExpense = dt.Rows[i]["BatchExpense"].ToString();

                list.Add(model);










            }
            return View(list);



        }
    }
}
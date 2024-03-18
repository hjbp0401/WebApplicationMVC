using BrokerageConnection;
using BrokerageModel.MasterModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication1MVC.Controllers
{
    public class MFinanceYearController : Controller
    {
        // GET: MFinanceYear
        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult SaveData(MFinanceYearModel Model)
        {
            
            CommonFunction cf = new CommonFunction();
            SqlConnection sqlcon = cf.Connect();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "SP_MFinancialYear";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Trid", Model.Trid);
                cmd.Parameters.AddWithValue("@FinancialYear", Model.FinanceYear);
                cmd.Parameters.AddWithValue("@FYear", Model.FYear);
                cmd.Parameters.AddWithValue("@YearClose", Model.YearClose);


                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
               sqlcon.Close();
                sqlcon.Open();
            }

            return View();
        }

        public ActionResult GetList()
        {
            //List use for collect the list
            List<MFinanceYearModel> list = new List<MFinanceYearModel> ();

            //create the obejct of class (in class design the connect function)
            CommonFunction cf = new CommonFunction ();

            //it is a class of ado.net.datatble use for collection column & row store to grid form
            DataTable dt = cf.GetDataTable("select isnull([Trid],0)as[Trid],isnull([FinancialYear],0)as[FinancialYear],isnull([FYear],0)as[FYear],isnull([YearClose],0)as[YearClose] from MFinancialYear");

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                 MFinanceYearModel model = new MFinanceYearModel();

                   model.Trid = Convert.ToInt32(dt.Rows[i]["Trid"]);
                   model.FinanceYear = dt.Rows[i]["FinancialYear"].ToString();
                   model.FYear = dt.Rows[i]["FYear"].ToString();
                   model.YearClose = dt.Rows[i]["YearClose"].ToString();

                  list.Add(model);



                }
                return View(list);
            

        }
        //public ActionResult Delete (int id )
        //{
            



        //}


    }
}
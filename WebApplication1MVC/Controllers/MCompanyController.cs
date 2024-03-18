using BrokerageAbstraction.MasterAbstraction;
using BrokerageConnection;
using BrokerageModel.MasterModel;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1MVC.Models;


namespace WebApplication1MVC.Controllers
{
    public class MCompanyController : Controller
    {
        // GET: MCompany
        SqlConnection sqlcon;
        SqlCommand cmd;


        public ActionResult Index()
        {
            ViewBag.CompanyName = GetCompanyNameDropD();
            return View();
        }
     

        public ActionResult SaveData(McompnayModell model)
        {
            int responce;
            string Flag;
           
            string filename = Path.GetFileNameWithoutExtension(model.Imagefile.FileName);
            string extension = Path.GetExtension(model.Imagefile.FileName);

            filename = filename + extension;
            model.ImagePath = "~/Image/" + filename;
            filename = Server.MapPath(model.ImagePath);
            model.Imagefile.SaveAs(filename);

            if (model.CompanyID == 0)
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
                cmd.CommandText = "SP_Mcompany";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = sqlcon;
                cmd.Parameters.AddWithValue("@CompanyID", model.CompanyID);
                cmd.Parameters.AddWithValue("@CompanyCode", model.CompanyCode);
                cmd.Parameters.AddWithValue("@CompanyName", model.CompanyName);
                cmd.Parameters.AddWithValue("@CompanyAddress", model.CompanyAddress);
                cmd.Parameters.AddWithValue("@phoneNo", model.phoneNo);
                cmd.Parameters.AddWithValue("@CellNo", model.CellNO);
                cmd.Parameters.AddWithValue("@EmailId", model.EmailId);
                cmd.Parameters.AddWithValue("@PANNo", model.PANNo);
                cmd.Parameters.AddWithValue("@CST", model.CST);
                cmd.Parameters.AddWithValue("@BST", model.BST);
                cmd.Parameters.AddWithValue("@Acflag", model.Acflag);
                cmd.Parameters.AddWithValue("@createdBy", model.CreatedBy);
                cmd.Parameters.AddWithValue("@createdOn", model.CreatedOn);
                cmd.Parameters.AddWithValue("@Remark", model.Remark);
                cmd.Parameters.AddWithValue("@TallyID", model.TallyID);
                cmd.Parameters.AddWithValue("@ImagePath", model.ImagePath);
                cmd.Parameters.AddWithValue("@Flag", Flag);
               

                cmd.ExecuteNonQuery();


            }
            catch (Exception ex) 
            {

                var st = new System.Diagnostics.StackTrace(ex, true);
                var frame = st.GetFrame(st.FrameCount - 1);
                var linenumber = frame.GetFileLineNumber();
                cf.ErrorLog("MCompanyController", "SaveData",linenumber.ToString(),ex.ToString());
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
                TempData["Message"] = "<script>alert('Data updated!!')<script>";
            }
            else
            {
                TempData["Message"] = "<script>alert('Opps something wrong')";

            }
             return RedirectToAction("Index");

       
        }

        public ActionResult GetReport()
        {

            List<McompnayModell> list = new List<McompnayModell>();
            CommonFunction cf = new CommonFunction();
            DataTable dt = cf.GetDataTable("Select isnull([CompanyID],0)as[CompanyID],isnull([CompanyCode],0)as[CompanyCode],isnull([CompanyName],0)as[CompanyName], isnull([CompanyAddress],0)as[CompanyAddress],isnull([phoneNo],0)as[phoneNo],isnull([CellNO],0)as[CellNO],isnull([CellNO],0)as[CellNO], isnull([EmailId],0)as[EmailId], isnull([PANNo],0)as[PANNo], isnull([CST],0)as[CST], isnull([BST],0)as[BST],isnull([Acflag],0)as[Acflag], isnull([CreatedBy],0)as[CreatedBy], isnull([CreatedOn],0)as[CreatedOn], isnull([Remark],0)as[Remark], isnull([TallyID],0)as[TallyID],isnull ([ImagePath],0)[ImagePath] from Mcompany");

            for(int i = 0;i<dt.Rows.Count;i++)
            {
                McompnayModell model =  new McompnayModell();

                model.CompanyID = Convert.ToInt32(dt.Rows[i]["CompanyID"]);
                model.CompanyCode = dt.Rows[i]["CompanyCode"].ToString();
                model.CompanyName = dt.Rows[i]["CompanyName"].ToString();
                model.CompanyAddress = dt.Rows[i]["CompanyAddress"].ToString();
                model.phoneNo = dt.Rows[i]["phoneNo"].ToString();
                model.CellNO = dt.Rows[i]["CellNO"].ToString();
                model.EmailId = dt.Rows[i]["EmailId"].ToString();
                model.PANNo = dt.Rows[i]["PANNo"].ToString();
                model.CST = dt.Rows[i]["CST"].ToString();
                model.BST = dt.Rows[i]["BST"].ToString();
                model.Acflag = dt.Rows[i]["Acflag"].ToString();
                model.CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]);
                model.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                model.Remark = dt.Rows[i]["Remark"].ToString() ;
                model.TallyID = dt.Rows[i]["TallyID"].ToString();
                model.ImagePath = dt.Rows[i]["ImagePath"].ToString();
                
                list.Add(model);

            }
            return View(list);
        }
        
        public ActionResult Delete(int id)
       {
            CommonFunction cf = new CommonFunction();
            SqlConnection sqlcon = cf.Connect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_DelMcopany";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlcon;
            cmd.Parameters.AddWithValue("@CopmanyID", id);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }
        private SqlDataReader Checkcredential (McompnayModell Model)

        {
            CommonFunction cf = new CommonFunction();   
            sqlcon = cf.Connect();
            string query = "select * from MExpense where CompanyID='" + Model.CompanyID + "'";
            cmd = new SqlCommand(query,sqlcon);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;



        }

        public SelectList GetCompanyNameDropD()
        {
            CommonFunction cf = new CommonFunction();
            SqlConnection sqlConnection = cf.Connect();
            string query = "select CompanyID,CompanyName from MCompany";
            DataTable dt = cf.GetDataTable(query);
            List<SelectListItem> list = new List<SelectListItem>();

           foreach (DataRow rows in dt.Rows)
           {
                list.Add(new SelectListItem()
                {
                    Text = rows["CompanyName"].ToString(),
                    Value = rows["CompanyID"].ToString(),

                });
           }
           return new SelectList(list,"Value","Text");
                    
                   

        }


    }

}


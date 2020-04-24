using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineDemo.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OnlineDemo.Controllers
{
    public class ProdCatController : Controller
    {
        // GET: ProdCat
        public ActionResult Index(int page=1)
        {
            //Defining the PageSize
            int PageSize = 10;
            //Creating the ViewModel's Object
             ProCatViewModel obj = new ProCatViewModel();
            DataSet ds = new DataSet();
            //List of the Person
            List<ViewModel> lstPerson = new List<ViewModel>();

            //Connecting to the Database (Here, I am using ADO.Net in order to interact with the database)
            //You can use any ORM as per your need or requirement
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Product_GetProductCategoryData", con);
                com.CommandType = CommandType.StoredProcedure;
                //Passing the Offset value in the procedure
                com.Parameters.AddWithValue("@OffsetValue", (page - 1) * PageSize);
                com.Parameters.AddWithValue("@PagingSize", PageSize);
                SqlDataAdapter adapt = new SqlDataAdapter(com);
                //Fill the Dataset and Close the connection
                adapt.Fill(ds);
                con.Close();
                //Bind the data in List of type Person
                //We are returning Dataset with two Datatable, one contains the Person Data and Other contains the total records count
                if (ds != null && ds.Tables.Count == 2)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ViewModel objPerson = new ViewModel();
                        objPerson.ProductId = Convert.IsDBNull(ds.Tables[0].Rows[i]["ProductId"]) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["ProductId"]);
                        objPerson.ProductName = Convert.IsDBNull(ds.Tables[0].Rows[i]["ProductName"]) ? "" : Convert.ToString(ds.Tables[0].Rows[i]["ProductName"]);
                        objPerson.CategoryId = Convert.IsDBNull(ds.Tables[0].Rows[i]["CategoryId"]) ? 0: Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryId"]);
                        objPerson.CategoryName = Convert.IsDBNull(ds.Tables[0].Rows[i]["CategoryName"]) ? "" : Convert.ToString(ds.Tables[0].Rows[i]["CategoryName"]);
                        lstPerson.Add(objPerson);
                    }
                    //Passing the TotalRecordsCount, Current Page and Page Size in the constructore of the Pager Class
                    var pager = new Pager((ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0) ? Convert.ToInt32(ds.Tables[1].Rows[0]["TotalRecords"]) : 0, page, PageSize);
                    obj.ViewModel = lstPerson;
                    obj.pager = pager;
                }
            }
            return View(obj);
            //return View();
        }
    }
}
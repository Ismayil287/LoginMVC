using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginMVC.Models;
using System.Data.SqlClient;

namespace LoginMVC.Controllers
{
    public class AdminController : Controller
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        // GET: Admin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        

        void connectionString()
        {
            conn.ConnectionString = "Data Source=localhost; Database=database; Integrated Security=true;";
        }
        [HttpPost]
        public ActionResult Verify(Admin adm)
        {
            connectionString();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Table where username='"+adm.Name+"' and password='"+adm.Password+"'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                conn.Close();
                return View("SuccessLogin");
            }
            else
            {
                conn.Close();
                return View();
            }
            
        }
    }
}
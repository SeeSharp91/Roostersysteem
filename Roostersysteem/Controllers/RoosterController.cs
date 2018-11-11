using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Roostersysteem.Models;

namespace Roostersysteem.Controllers
{
    public class RoosterController : Controller
    {
        private RoosterDB db = new RoosterDB();

        [HttpGet]
        public ActionResult Index()
        {
            DataSet ds = new DataSet();
            string constring = "Data Source=Micha-PC\\SQLEXPRESS;Initial Catalog=RoosterDB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("Select_Rooster", con))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }
            return View(ds);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using Roostersysteem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roostersysteem.Controllers
{
    public class VakgegevensController : Controller
    {
        [HttpGet]
        // GET: Vakken from DB
        public ActionResult SelectieVak()
        {
            Vak oVak = new Vak();
            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(oVak.strConnection))
            {
                string query = "SELECT * FROM TypeVak";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["VakType"].ToString(),
                                Value = sdr["VakId"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return View("VakkenKoppelen", items);
        }

        [HttpPost]
        public ActionResult SelectieVak(List<SelectListItem> items)
        {
            foreach (SelectListItem item in items)
            {
                if (item.Selected)
                {
                    ViewBag.WeergaveVakken += string.Format("{0}\n", item.Text);
                }
            }
            return View(items);
        }
    }
}
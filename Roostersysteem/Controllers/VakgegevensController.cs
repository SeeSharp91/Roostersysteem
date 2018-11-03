using Roostersysteem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static Roostersysteem.Models.Vak;

namespace Roostersysteem.Controllers
{
    public class VakgegevensController : Controller
    {
        [HttpGet]
        // GET: Vakken from DB
        public ActionResult VakkenKoppelen()
        {
            List<Vak> model = new List<Vak>();
            model = Vak.getvakken();
            return View(model);
        }
        [HttpPost]
        public ActionResult VakkenKoppelen(List<Vak> vak)
        {
            if (vak.Count(x => x.IsSelected) == 0)
            {
                ViewBag.msg = "Je hebt geen vak geselecteerd";
                return View();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Je hebt de volgende vakken geselecteerd : ");
                foreach (Vak v in vak)
                {
                    if (v.IsSelected)
                    {
                        sb.Append(v.VakType + ",");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(","), 1);
                sb.Append(" Vakken");
                ViewBag.msg = sb.ToString();
                return View(vak);
            }
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

        // wordt aan gewerkt
        //public ActionResult contactUrenDoorgeven()
        //{
        //    var list = new List<MyListTable>();
        //
        //    using (SqlConnection c = new SqlConnection(cString))
        //    using (SqlCommand cmd = new SqlCommand("SELECT KeyField, DisplayField FROM Table", c))
        //    {
        //        using (SqlDataReader rdr = cmd.ExecuteReader())
        //        {
        //            while (rdr.Read())
        //            {
        //                list.Add(new MyListTable
        //                {
        //                    Key = rdr.GetString(0),
        //                    Display = rdr.GetString(1)
        //                });
        //            }
        //        }
        //    }
        // 
        //    return View(model);
    }
}
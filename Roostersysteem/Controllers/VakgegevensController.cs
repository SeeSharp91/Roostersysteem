using Roostersysteem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Roostersysteem.Controllers
{
    public class VakgegevensController : Controller
    {
        //-------------------- Vakken Koppelen aan Docent --------------------\\
        [HttpGet]
        // GET: Vakken from DB
        public ActionResult VakkenKoppelen()
        {
            List<Vak> model = new List<Vak>();
            model = Vak.getvakken("select * from Vak");
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
                        sb.Append(v.VakNaam + ",");
                        Vak oVak = new Vak(v.VakId, 3, true); //TODO: PersoonId nog hardcoded, aanpassen wanneer inloggen optimaal werkt. 
                    }
                }

                sb.Remove(sb.ToString().LastIndexOf(","), 1);
                sb.Append("Vakken");
                ViewBag.msg = sb.ToString();
                return View(vak);
            }
        }

        //-------------------- Vakken bekijken van een Docent --------------------\\
        [HttpGet]
        // GET: Vakken from DB
        public ActionResult VakkenBekijken()
        {
            //Vak oVak = new Vak(4);
            //return View(oVak);
        }
        // Met een button naar een nieuwe pagine/view verwijzen (OnClick event maken).

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

        [HttpGet]
        public ActionResult ContactUren()
        {
            //string strCon = ConfigurationManager.ConnectionStrings["DatabaseConnectionExpress"].ConnectionString.ToString();

            //var model = new Roostersysteem.Models.Vak();
            ////using (CSharpCornerEntities cshparpEntity = new CSharpCornerEntities())
            //using (SqlConnection con = new SqlConnection(strCon))
            //{
            //    con.Open();
            //    SqlDataReader dr;
            //    SqlCommand cmd = con.CreateCommand();
            //    cmd.CommandType = System.Data.CommandType.Text;
            //    cmd.CommandText = "SELECT * FROM VAK";
            //    dr = cmd.ExecuteReader();
            //    while (dr.Read)
            //    {
            //        SelectList listItems = new SelectList(dr["VakId"].ToString());
            //        listItems.Add(dr["VakNaam"].ToString());
            //    }
            //    //var dbData = cshparpEntity.Vak.ToList();
            //    //model.takeVakken = GetSelectListItems(dbData);
            //}

            // return View(model);
            return View();
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<Vak> elements)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.VakId.ToString(),
                    Text = element.VakNaam
                });
            }
            return selectList;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Roostersysteem.Models;

namespace Roostersysteem.Controllers
{
    public class ProfielController : Controller
    {
        // GET: Profiel
        public ActionResult MijnGegevens()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Persoon(Persoon persoon)
        //{
        //    int persoonId = persoon.persoonId;
        //    string persoonnaam = persoon.persoonNaam;
        //    string persoonemail = persoon.persoonEmail;
        //    double telefoonnummer = persoon.telefoonNr;
        //    string straatnaam = persoon.straatNaam;
        //    string huisnummer = persoon.huisNummer;
        //    string postcode = persoon.postcode;
        //    Models.Persoon.GegevensWijzigen(persoonId, persoonnaam, persoonemail, telefoonnummer, straatnaam, huisnummer, postcode);


        //    return View(persoon);
        //}


        [HttpPost]
        public ActionResult MijnGegevens(FormCollection formCollection)
        {
            Persoon persoon = new Persoon();
            persoon.test();
            return View("regSuccess");
        }
    }
}
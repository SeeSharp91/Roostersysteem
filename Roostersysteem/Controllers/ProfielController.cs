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

        [HttpGet]
        public ActionResult MijnGegevens()
        {
            //Persoon persoon = new Persoon();
            //persoon.getGegevens(persoon);
            //persoon.PersoonId = persoon.PersoonId
            //return View("MijnGegevens", persoon);

            //
            //The clean way to do so is to pass a new instance of the created entity through the controller:

            ////GET
            //public ActionResult CreateNewMyEntity(string default_value)
            //{
            //    Persoon persoon = new Persoon();
            //    persoon.PersoonId = 1;

            //    return View(persoon);
            //}

            var model = new Persoon();
            return View(model);
            
        }
        
        


        [HttpPost]
        public ActionResult MijnGegevens(FormCollection formCollection)
        {
            Persoon persoon = new Persoon();
            persoon.PersoonId = Int32.Parse(formCollection["PersoonId"]);
            persoon.PersoonNaam = formCollection["PersoonNaam"];
            persoon.PersoonEmail= formCollection["PersoonEmail"];
            persoon.TelefoonNr = Int32.Parse(formCollection["TelefoonNr"]);
            persoon.StraatNaam = formCollection["StraatNaam"];
            persoon.HuisNummer= Int32.Parse(formCollection["HuisNummer"]);
            persoon.Postcode = formCollection["Postcode"];
            persoon.GegevensWijzigen(persoon);
            return View("MijnGegevens", persoon);
        }

        [HttpPost]
        public ActionResult MijnWachtwoord(FormCollection formCollection)
        {
            
            Persoon persoon = new Persoon();
            if (persoon.PersoonWw == persoon.PersoonWwHerhaling)
            {
                persoon.PersoonGbn = formCollection["PersoonGbn"];
                persoon.PersoonWw = formCollection["PersoonWw"];
                persoon.PersoonWwHerhaling = formCollection["PersoonWwHerhaling"];
                persoon.WachtwoordWijzigen(persoon);
            }
            
            return View("MijnGegevens", persoon);

        }

    }
}
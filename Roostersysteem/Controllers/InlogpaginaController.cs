using Roostersysteem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roostersysteem.Controllers
{
    public class InlogpaginaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(Roostersysteem.Models.Persoon persoonModel)
        {            
            //moet ik deze 2 gegevens niet meegeven aan de constructor
            //ipv de methode en dan via de methode vanuit de constructer aanvragen?
            Persoon o = new Persoon();
            bool check = o.Inloggen(InputGebruiker, InputWachtwoord);
            if (check = true)
            {
                return View("../Home/Index");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}
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
        public ActionResult Autherize(Roostersysteem.Models.Persoon model)
        {
            //if (Autherize == true)

            //moet ik deze 2 gegevens niet meegeven aan de constructor
            //ipv de methode en dan via de methode vanuit de constructer aanvragen?  
                        
            Persoon p = new Persoon();
            bool check = p.Inloggen(model.persoonGbn,model.persoonWw);

            if (check == true)
            {
                Session["gebruikersid"] = model.persoonId;
                return RedirectToAction("../Home/Home");
            }
            else
            {
                return View("Index");
            }
            
            //return RedirectToAction("../Home/Home");
            
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
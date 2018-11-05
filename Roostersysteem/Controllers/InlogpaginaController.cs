using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Roostersysteem.Models;
using System.Collections.Generic;

namespace Roostersysteem.Controllers
{    
    public class InlogpaginaController : Controller
    {   
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Validatie()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            Persoon p = new Persoon();

            bool check = p.Inloggen(model.Gebruikersnaam, model.Wachtwoord);
            //bool check = p.Inloggen(p.persoonGbn,p.persoonWw);

            if (check == true)
            {
                return RedirectToAction("Validatie");
            }
            else
            {
                return View("Index");
            }

        }

        [HttpPost]
        public ActionResult Valideren(ValidatieViewModel model, string returnUrl)
        {
            Persoon p = new Persoon();


            bool check = p.TweeStapsVer(p.PersoonId, p.Code);
            //bool check = p.Inloggen(p.persoonGbn,p.persoonWw);

            if (check == true)
            {
                Session["gebruikersid"] = p.PersoonId;
                return RedirectToAction("../Home/Home");
            }
            else
            {
                return View("Index");
            }
        }


    }
}
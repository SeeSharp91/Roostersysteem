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
    public class HomeController : Controller
    {
        private RoosterDB db = new RoosterDB();

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
                Session["gebruikersnaam"] = p.PersoonVoornaam;
                return RedirectToAction("Validatie");
            }
            else
            {
                return View("Index");
            }

        }

        [HttpPost]
        public ActionResult Valideren(ValiderenViewModel model, string returnUrl)
        {
            Authenticator a = new Authenticator();
            Persoon p = new Persoon();


            bool check = a.TweeStapsVer(p.PersoonId, model.verificatiecode);
            //bool check = p.Inloggen(p.persoonGbn,p.persoonWw);

            if (check == true)
            {
                //Session["gebruikersnaam"] = p.PersoonNaam;
                return View("Hoofdpagina");
            }
            else
            {
                return View("Index");
            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roostersysteem.Controllers
{
    public class VakgegevensController : Controller
    {
        // GET: Vakgegevens
        public ActionResult Contacturen()
        {
            ViewBag.Message = "";
            return View();
        }

        public ActionResult VakkenKoppelen()
        {
            ViewBag.Message = "";
            return View();
        }

        public ActionResult contactUrenDoorgeven()
        {
            ViewBag.Message = "";
            return View();
        }
    }
}
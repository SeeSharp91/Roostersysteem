using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roostersysteem.Models;

namespace Roostersysteem.Controllers
{
    public class UrenController : Controller
    {
        // GET: Uren
        public ActionResult UrenDocent()
        {
            ViewBag.Message = "";
            return View();
        }

        public ActionResult UrenRoosteraar()
        {
            ViewBag.Message = "";
            return View();
        }

        public ActionResult Annuleren()
        {
            return RedirectToAction("../Home/Home");
        }

        public ActionResult saveData(Docent BeschikbaarheidAangeven)
        {
            return View(); // aanpassen
        }
    }
}
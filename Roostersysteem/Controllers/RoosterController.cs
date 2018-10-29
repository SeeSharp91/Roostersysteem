using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roostersysteem.Controllers
{
    public class RoosterController : Controller
    {
        // GET: Rooster
        public ActionResult Rooster()
        {
            ViewBag.Message = "";
            return View();
        }
    }
}
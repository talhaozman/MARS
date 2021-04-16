using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MARS.Models.Entity;

namespace MARS.Controllers
{
    public class VeriBankasıController : Controller
    {
        Context c = new Context();
        public ActionResult BankaIndex()
        {
            var veri = c.VeriBankasis.ToList();
            return View(veri);
        }
    }
}
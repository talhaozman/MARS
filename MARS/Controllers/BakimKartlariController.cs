using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MARS.Models.Entity;

namespace MARS.Controllers
{
    public class BakimKartlariController : Controller
    {
        Context c = new Context();
        public ActionResult PBSIndex()
        {
            var pbs = c.PBSKarts.ToList();
            return View(pbs);
        }
        [HttpGet]
        public ActionResult PBSEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PBSEkle(PBSKart p)
        {
            c.PBSKarts.Add(p);
            c.SaveChanges();
            return RedirectToAction("PBSIndex");
        }
        public ActionResult GetListGIGN(string q)
        {
            try
            {
                var list = c.GIGNs.Select(x => new
                {
                    Id = x.GIGNId,
                    Text = x.GIGNTur+ " - " + x.GIGNAd
                });

                if (!string.IsNullOrEmpty(q))
                {
                    list = list.Where(x => x.Text.Contains(q));
                }

                return Json(new { items = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
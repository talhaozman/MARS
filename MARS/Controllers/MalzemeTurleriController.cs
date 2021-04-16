using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MARS.Models.Entity;

namespace MARS.Controllers
{
    public class MalzemeTurleriController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var malzeme = c.MalzemeTurleris.ToList();
            return View(malzeme);
        }
        [HttpGet]
        public ActionResult MalzemeTurEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MalzemeTurEkle(MalzemeTurleri m)
        {
            c.MalzemeTurleris.Add(m);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MalzemeTurSil(int id)
        {
            var mal = c.MalzemeTurleris.Find(id);
            c.MalzemeTurleris.Remove(mal);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MalzemeTurGetir(int id)
        {
            var malz = c.MalzemeTurleris.Find(id);
            return View("MalzemeTurGetir", malz);
        }
        public ActionResult MalzemeTurGuncelle(MalzemeTurleri m)
        {
            var tur = c.MalzemeTurleris.Find(m.MalzemeTurId);
            tur.TurNo = m.TurNo;
            tur.MalzemeTurAd = m.MalzemeTurAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
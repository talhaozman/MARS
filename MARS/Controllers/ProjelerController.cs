using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MARS.Models.Entity;

namespace MARS.Controllers
{
    //[Authorize]
    public class ProjelerController : Controller
    {
        Context c = new Context();
        public ActionResult ProjeIndex()
        {
            var proje = c.Projelers.ToList();
            return View(proje);
        }
        [HttpGet]
        public ActionResult ProjeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProjeEkle(Projeler p)
        {
            c.Projelers.Add(p);
            c.SaveChanges();
            return RedirectToAction("ProjeIndex");
        }
        public ActionResult ProjeSil(int id)
        {
            var pro = c.Projelers.Find(id);
            c.Projelers.Remove(pro);
            c.SaveChanges();
            return RedirectToAction("ProjeIndex");
        }
        public ActionResult ProjeGetir(int id)
        {
            var projeler = c.Projelers.Find(id);
            return View("ProjeGetir", projeler);
        }
        public ActionResult ProjeGuncelle(Projeler p)
        {
            var prj = c.Projelers.Find(p.ProjeId);
            prj.ProjeKodu = p.ProjeKodu;
            prj.GemiBordoNumarasi = p.GemiBordoNumarasi;
            prj.YayimTarihi = p.YayimTarihi;
            prj.Revizyon = p.Revizyon;
            prj.RevizyonTarihi = p.RevizyonTarihi;
            c.SaveChanges();
            return RedirectToAction("ProjeIndex");

        }
    }
}
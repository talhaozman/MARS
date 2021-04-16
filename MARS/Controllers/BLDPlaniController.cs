
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MARS.Models.Entity;

namespace MARS.Controllers
{
    //[Authorize]
    public class BLDPlaniController : Controller
    {
        Context c = new Context();
        public ActionResult BLDIndex()
        {
            var bld = c.BLDPlanis.ToList();
            return View(bld);
        }
        [HttpGet]
        public ActionResult PlanEkle()
        {
            List<SelectListItem> deger2 = (from x in c.Projelers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProjeKodu,
                                               Value = x.ProjeId.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult PlanEkle(BLDPlani b)
        {
            c.BLDPlanis.Add(b);
            c.SaveChanges();
            return RedirectToAction("BLDIndex");
        }

        public ActionResult PlanSil(int id)
        {
            var plan = c.BLDPlanis.Find(id);
            c.BLDPlanis.Remove(plan);
            c.SaveChanges();
            return RedirectToAction("BLDIndex");
        }

        public ActionResult PlanGetir(int id)
        {
            List<SelectListItem> deger2 = (from x in c.Projelers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProjeKodu,
                                               Value = x.ProjeId.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            var bldplan = c.BLDPlanis.Find(id);
            return View("PlanGetir", bldplan);

        }

        public ActionResult PlanGuncelle(BLDPlani b)
        {
            var pln = c.BLDPlanis.Find(b.BLDPlaniId);
            pln.ProjeId = b.ProjeId;
            pln.DokumanNo = b.DokumanNo;
            c.SaveChanges();
            return RedirectToAction("BLDIndex");
        }
        public ActionResult BLDDosyaYukle()
        {
            var items = GetFiles();
            return View(items);
        }

        [HttpPost]
        public ActionResult BLDDosyaYukle(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/BLDDokuman/"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "Dosya Başarıyla Yüklendi";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "HATA" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "Bir Dosya Seçmediniz.";
            }
            var items = GetFiles();
            return View(items);

        }
        public FileResult DownLoad(string Filename)
        {
            var FileVirtualPath = "~/BLDDokuman/" + Filename;
            return File(FileVirtualPath, "application/force- download", Path.GetFileName(FileVirtualPath));
        }

        private List<string> GetFiles()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/BLDDokuman/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");

            List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return items;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MARS.Models.Entity;

namespace MARS.Controllers
{
   // [Authorize]
    public class DokumanListeController : Controller
    {
        Context c = new Context();
        public ActionResult ListeIndex()
        {
            var liste = c.DokumanListes.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult DokumanEkle()
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
        public ActionResult DokumanEkle(DokumanListe d)
        {
            c.DokumanListes.Add(d);
            c.SaveChanges();
            return RedirectToAction("ListeIndex");
           
        }
        public ActionResult DokumanSil(int id)
        {
            var dokuman = c.DokumanListes.Find(id);
            c.DokumanListes.Remove(dokuman);
            c.SaveChanges();
            return RedirectToAction("ListeIndex");
        }
        public ActionResult DokumanGetir(int id)
        {
            List<SelectListItem> deger3 = (from x in c.Projelers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProjeKodu,
                                               Value = x.ProjeId.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;

            var doklist = c.DokumanListes.Find(id);
            return View("DokumanGetir", doklist);
        }
        public ActionResult DokumanGuncelle(DokumanListe d)
        {
            var dkn = c.DokumanListes.Find(d.DokumanListeId);
            dkn.ProjeId = d.ProjeId;
            dkn.TekdokAd = d.TekdokAd;
            dkn.TekdokNo = d.TekdokNo;
            dkn.TekdokTip = d.TekdokTip;
            c.SaveChanges();
            return RedirectToAction("ListeIndex");
        }
        public ActionResult DokumanDosyaYukle()
        {
            var items = GetFiles();
            return View(items);
        }

        [HttpPost]
        public ActionResult DokumanDosyaYukle(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/DokumanDokuman/"), Path.GetFileName(file.FileName));
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
            var FileVirtualPath = "~/DokumanDokuman/" + Filename;
            return File(FileVirtualPath, "application/force- download", Path.GetFileName(FileVirtualPath));
        }

        private List<string> GetFiles()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/DokumanDokuman/"));
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
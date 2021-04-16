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
    public class SozlesmelerController : Controller
    {
        Context c = new Context();
        public ActionResult SozlesmeIndex()
        {
            var sozlesme = c.Sozlesmelers.ToList();
            return View(sozlesme);
        }
        [HttpGet]
        public ActionResult SozlesmeEkle()
        {
            List<SelectListItem> deger = (from x in c.Projelers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ProjeKodu,
                                              Value = x.ProjeId.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;
            return View();
        }
        [HttpPost]
        public ActionResult SozlesmeEkle(Sozlesmeler s)
        {
            c.Sozlesmelers.Add(s);
            c.SaveChanges();
            return RedirectToAction("SozlesmeIndex");
        }
        public ActionResult SozlesmeSil(int id)
        {
            var sozles = c.Sozlesmelers.Find(id);
            c.Sozlesmelers.Remove(sozles);
            c.SaveChanges();
            return RedirectToAction("SozlesmeIndex");
        }
        public ActionResult SozlesmeGetir(int id)
        {
            List<SelectListItem> deger = (from x in c.Projelers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ProjeKodu,
                                              Value = x.ProjeId.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;
            var sozlesmeler = c.Sozlesmelers.Find(id);
            return View("SozlesmeGetir", sozlesmeler);

        }
        public ActionResult SozlesmeGuncelle(Sozlesmeler s)
        {
            var soz = c.Sozlesmelers.Find(s.SozlesmeId);
            soz.ProjeId = s.ProjeId;
            soz.Idari = s.Idari;
            soz.Yuklenici = s.Yuklenici;
            soz.AltYuklenici = s.AltYuklenici;
            soz.Tedarikciler = s.Tedarikciler;
            c.SaveChanges();
            return RedirectToAction("SozlesmeIndex");
        }
        public ActionResult SozlesmeDosyaYukle()
        {
            var items = GetFiles();
            return View(items);
        }

        [HttpPost]
        public ActionResult SozlesmeDosyaYukle(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/SozlesmeDokuman/"), Path.GetFileName(file.FileName));
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
            var FileVirtualPath = "~/SozlesmeDokuman/" + Filename;
            return File(FileVirtualPath, "application/force- download", Path.GetFileName(FileVirtualPath));
        }

        private List<string> GetFiles()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/SozlesmeDokuman/"));
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
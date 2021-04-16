using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Packaging;
using MARS.Models.Entity;

namespace MARS.Controllers
{
    public class YazilimVersiyonController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var yazilim = c.YazilimVersiyons.ToList();
            return View(yazilim);
        }
        [HttpGet]
        public ActionResult YazilimEkle()
        {
            List<SelectListItem> deger41 = (from x in c.DokumanListes.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.TekdokNo,
                                                Value = x.DokumanListeId.ToString()
                                            }).ToList();
            ViewBag.dgr41 = deger41;
            return View();
        }
        [HttpPost]
        public ActionResult YazilimEkle(YazilimVersiyon y)
        {

            var dokumanListe = c.DokumanListes.FirstOrDefault(x => x.DokumanListeId == y.DokumanListeId);
            y.DokumanListe = dokumanListe;


            var newFilePath = SearchAndReplace(@"C:\DSGMARS\MARS\MARS\Sablonlar\Yazılım\YazilimVersiyon.docx", y);
            y.YazDosyaYolu = newFilePath; //Veritabanına yeni bir alan eklenecel. Yeni yaratılan dosyanın adresi buraya yazılacak.

            c.YazilimVersiyons.Add(y);
            c.SaveChanges();
            return RedirectToAction("Index","DokOlustur");
        }
        private string SearchAndReplace(string filepath, YazilimVersiyon y)
        {
            // Adım 1: Şablon dosyanın kopyasını oluştur:
            var directory = Path.GetDirectoryName(filepath);
            var newFilePath = directory + @"/" + y.DokumanListe.TekdokNo + @".docx";
            System.IO.File.Copy(filepath, newFilePath);

            // Adım 2: Yeni kopyalanan dosyayı aç:
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(newFilePath, true))
            {
                var docText = string.Empty;

                // Adım 3: Dosyanın içinde yazanı string değer olarak al:
                using (StreamReader sr = new StreamReader(wordDocument.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }
                docText = docText.Replace("{sn}", y.SıraNo);
                docText = docText.Replace("{isim}", y.YazilimAd);




                using (StreamWriter sw = new StreamWriter(wordDocument.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
                wordDocument.MainDocumentPart.Document.Save();

                // Adım 7: Yeni dosyanın adresini döndür.
                return newFilePath;
            }
        }
        public FileResult Download(string fileName)
        {
            var fullPath = Path.Combine(Server.MapPath("~/Sablonlar/Yazılım/"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }
    }
}
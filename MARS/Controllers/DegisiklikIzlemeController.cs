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
    [Authorize]
    public class DegisiklikIzlemeController : Controller
    {
        Context c = new Context();
        public ActionResult DegisiklikIndex()
        {
            var degisikli = c.DegisiklikIzlemes.ToList();
            return View(degisikli);
        }
        [HttpGet]

        public ActionResult DegisiklikEkle()
        {
            List<SelectListItem> deger22 = (from x in c.DokumanListes.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.TekdokNo,
                                                Value = x.DokumanListeId.ToString()
                                            }).ToList();
            ViewBag.dgr22 = deger22;
            return View();
        }
        [HttpPost]
        public ActionResult DegisiklikEkle(DegisiklikIzleme d)
        {

            var dokumanListe = c.DokumanListes.FirstOrDefault(x => x.DokumanListeId == d.DokumanListeId);
            d.DokumanListe = dokumanListe;


            var newFilePath = SearchAndReplace(@"C:\DSGMARS\MARS\MARS\Sablonlar\DegsiklikIzleme\DegisiklikIzleme.docx", d);
            d.DegisiklikDosyaYolu = newFilePath; //Veritabanına yeni bir alan eklenecel. Yeni yaratılan dosyanın adresi buraya yazılacak.

            c.DegisiklikIzlemes.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index","DokOlustur");
        }
        private string SearchAndReplace(string filepath, DegisiklikIzleme d)
        {
            // Adım 1: Şablon dosyanın kopyasını oluştur:
            var directory = Path.GetDirectoryName(filepath);
            var newFilePath = directory + @"/" + d.DokumanListe.TekdokNo + @".docx";
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
                docText = docText.Replace("{sn}", d.sirano );
                docText = docText.Replace("{surumtarih}", d.SurumTarihi.ToString());
                docText = docText.Replace("{sun}", d.SurumNo);
                docText = docText.Replace("{onayno}", d.DokOnayNo);
                docText = docText.Replace("{onayta}", d.OnayTarihi.ToString());
                docText = docText.Replace("{aciklama}", d.DegAciklama.ToString());
                docText = docText.Replace("{bolum}", d.DegYapSayfa);


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
            var fullPath = Path.Combine(Server.MapPath("~/Sablonlar/DegisiklikIzleme/"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }
    }
}
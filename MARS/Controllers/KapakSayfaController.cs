using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Packaging;
using MARS.Models.Entity;
using System.IO;

namespace MARS.Controllers
{
    public class KapakSayfaController : Controller
    {
        Context c = new Context();
        public ActionResult KapakIndex()
        {
            var kapak = c.Kapaks.ToList();
            return View(kapak);
        }
        [HttpGet]

        public ActionResult KapakEkle()
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

        public ActionResult KapakEkle(Kapak k)
        {
            var dokumanListe = c.DokumanListes.FirstOrDefault(x => x.DokumanListeId == k.DokumanListeId);
            k.DokumanListe = dokumanListe;


            var newFilePath = SearchAndReplace(@"C:\DSGMARS\MARS\MARS\Sablonlar\Kapak\AsfatKapak.docx", k);
            k.DosyaYolu = newFilePath; //Veritabanına yeni bir alan eklenecel. Yeni yaratılan dosyanın adresi buraya yazılacak.

            c.Kapaks.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index", "DokOlustur");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath">Şablon dosyanın pathi</param>
        /// <param name="k"></param>
        /// <returns></returns>
        private string SearchAndReplace(string filepath, Kapak k)
        {
            // Adım 1: Şablon dosyanın kopyasını oluştur:
            var directory = Path.GetDirectoryName(filepath);
            var newFilePath = directory + @"/" + k.DokumanListe.TekdokAd + @".docx";
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

                // Adım 4: Anahtar kelimeleri gerçek değerlerle değiştir:
                docText = docText.Replace("{projeadi}", k.ProjeAdi);
                docText = docText.Replace("{dokumanadi}", k.DokumanAdi);
                docText = docText.Replace("{dokumanno}", k.DokumanListe.TekdokNo.ToString());
                docText = docText.Replace("{yayimtarihi}", k.YayimTarihi.ToString());
                docText = docText.Replace("{revizyon}", k.Revizyon);
                docText = docText.Replace("{revizyontarihi}", k.RevizyonTarihi.ToString());

                // Adım 5: Değiştirilmiş stringi dosyaya yaz.
                using (StreamWriter sw = new StreamWriter(wordDocument.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }

                // Adım 6: Dosyayı kaydet.
                wordDocument.MainDocumentPart.Document.Save();

                // Adım 7: Yeni dosyanın adresini döndür.
                return newFilePath;

            }
        }

        public FileResult Download(string fileName)
        {
            var fullPath = Path.Combine(Server.MapPath("~/Sablonlar/Kapak/"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }
    }
}
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
    public class EmniyetTalimatlariController : Controller
    {
        Context c = new Context();
        public ActionResult EmniyetIndex()
        {
            var emniyet = c.EmniyetTalimatlaris.ToList();
            return View(emniyet);
        }
        [HttpGet]
        public ActionResult EmniyetEkle()
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
        public ActionResult EmniyetEkle(EmniyetTalimatlari e)
        {
            var dokumanListe = c.DokumanListes.FirstOrDefault(x => x.DokumanListeId == e.DokumanListeId);
            e.DokumanListe = dokumanListe;


            var newFilePath = SearchAndReplace(@"C:\DSGMARS\MARS\MARS\Sablonlar\EmniyetTalimatlari\EmniyetTalimatlari.docx", e);
            e.emniyetDosyaYolu = newFilePath; //Veritabanına yeni bir alan eklenecel. Yeni yaratılan dosyanın adresi buraya yazılacak.

            c.EmniyetTalimatlaris.Add(e);
            c.SaveChanges();
            return RedirectToAction("Index", "DokOlustur");
        }
        private string SearchAndReplace(string filepath, EmniyetTalimatlari e)
        {
            // Adım 1: Şablon dosyanın kopyasını oluştur:
            var directory = Path.GetDirectoryName(filepath);
            var newFilePath = directory + @"/" + e.DokumanListe.TekdokAd + @".docx";
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
                docText = docText.Replace("{uyarietiket}", e.UyariEtiketleri);
                docText = docText.Replace("{okumayazma}", e.DikkatEtiketleri);


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

   

    }
}
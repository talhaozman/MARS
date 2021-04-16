using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MARS.Models.Entity;
using DocumentFormat.OpenXml.Packaging;
using System.IO;

namespace MARS.Controllers
{
    [Authorize]
    
    public class OnaySayfasiController : Controller
    {
        Context c = new Context();
        public ActionResult OnaySayfa()
        {
            var sayfa = c.OnaySayfasis.ToList();
            return View(sayfa);
        }
       [HttpGet]
        public ActionResult OnaySayfaIndex()
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
        public ActionResult OnaySafasiIndex(OnaySayfasi o)
        {
            var dokumanListe = c.DokumanListes.FirstOrDefault(x => x.DokumanListeId == o.DokumanListeId);
            o.DokumanListe = dokumanListe;

            var newFilePath = SearchAndReplace(@"C:\DSGMARS\MARS\MARS\Sablonlar\OnaySayfa\AsfatOnaySayfasi.docx", o);
            o.OnayDosyaYolu = newFilePath; //Veritabanına yeni bir alan eklenecel. Yeni yaratılan dosyanın adresi buraya yazılacak.

            c.OnaySayfasis.Add(o);
            c.SaveChanges();
            return RedirectToAction("DokumanOlustur", "Index");
        }
        private string SearchAndReplace(string filepath, OnaySayfasi o)
        {
            // Adım 1: Şablon dosyanın kopyasını oluştur:
            var directory = Path.GetDirectoryName(filepath);
            var newFilePath = directory + @"/" + o.DokumanListe.TekdokAd + @".docx";
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
                docText = docText.Replace("{dokumanno}", o.DokumanListe.TekdokNo.ToString());
                docText = docText.Replace("{firmadokumanno}", o.FirmaDokumani);
                docText = docText.Replace("{dokumanadi}", o.DokumanListe.TekdokAd.ToString());
                docText = docText.Replace("{hazgorev}", o.HazGorev);
                docText = docText.Replace("{hazkimlik}", o.HazKimlik);
                docText = docText.Replace("{haztarih}", o.HazTarih.ToString());
                docText = docText.Replace("{koorgorev}", o.KoorGorev);
                docText = docText.Replace("{koorkimlik}", o.KoorKimlik);
                docText = docText.Replace("{koortarih}", o.KoorTarih.ToString());
                docText = docText.Replace("{onaygorev}", o.AltYukOnayGorev);
                docText = docText.Replace("{onaykimlik}", o.AltYukOnayKimlik);
                docText = docText.Replace("{onaytarih}", o.AltYukOnayTarih.ToString());
                docText = docText.Replace("{onay2gorev}", o.YukOnayGorev);
                docText = docText.Replace("{onay2kimlik}", o.YukOnayKimlik);
                docText = docText.Replace("{onay2tarih}", o.YukOnayTarih.ToString());
                docText = docText.Replace("{piokoordine}", o.PioKoordinesi);
                docText = docText.Replace("{sozlesmemadde}", o.SozlesmeMaddesi);
                docText = docText.Replace("{ilkyayim}", o.IlkYayimTarih.ToString());
                docText = docText.Replace("{yayimtarihi}", o.YayimTarihi.ToString());




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
            var fullPath = Path.Combine(Server.MapPath("~/Sablonlar/OnaySayfa/"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }
    }
}
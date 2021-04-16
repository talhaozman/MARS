using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MARS.Models.Entity;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using DocumentFormat.OpenXml;

namespace MARS.Controllers
{
    public class UrunlerController : Controller
    {
        Context c = new Context();
        public ActionResult UrunlerIndex()
        {
            var urun = c.Urunlers.ToList();
            return View(urun);
        }
        [HttpGet]
        public ActionResult UrunEkle()
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
        public ActionResult UrunEkle(Urunler u)
        {
            var document = @"C:\DSGMARS\MARS\MARS\Sablonlar\Urunler\test.docx";
            string fileName = @"C:\Users\Talha ÖZMAN\Desktop\Masaüstü\image.jpg";
            InsertAPicture(document, fileName);


            //var dokumanListe = c.DokumanListes.FirstOrDefault(x => x.DokumanListeId == u.DokumanListeId);
            //u.DokumanListe = dokumanListe;


            //var newFilePath = SearchAndReplace(@"C:\DSGMARS\MARS\MARS\Sablonlar\Urunler\Urunler.docx", u);
            //u.UrunDosyaYolu = newFilePath; //Veritabanına yeni bir alan eklenecel. Yeni yaratılan dosyanın adresi buraya yazılacak.

            //if (Request.Files.Count > 0)
            //{
            //    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
            //    string uzanti = Path.GetExtension(Request.Files[0].FileName);
            //    string yol = "~/Image/" + dosyaadi + uzanti;
            //    Request.Files[0].SaveAs(Server.MapPath(yol));
            //    u.ResimYolu = "/Image/" + dosyaadi + uzanti;
            //}
            //c.Urunlers.Add(u);
            //c.SaveChanges();
            return RedirectToAction("DokumanListe", "DokOlustur");
        }
        private string SearchAndReplace(string filepath, Urunler u)
        {
            // Adım 1: Şablon dosyanın kopyasını oluştur:
            var directory = Path.GetDirectoryName(filepath);
            var newFilePath = directory + @"/" + u.UrunAdi + @".docx";
            System.IO.File.Copy(filepath, newFilePath);

            // Adım 2: Yeni kopyalanan dosyayı aç:
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(newFilePath, true))
            {
                var docText = string.Empty;

                //// Adım 3: Dosyanın içinde yazanı string değer olarak al:
                //using (StreamReader sr = new StreamReader(wordDocument.MainDocumentPart.GetStream()))
                //{
                //    docText = sr.ReadToEnd();
                //}
                //docText = docText.Replace("{baslik}", u.UrunAdi);
                //docText = docText.Replace("{resim}", u.ResimYolu.ToString());
                //docText = docText.Replace("{resimyazisi}", u.ResimYazisi);
                //docText = docText.Replace("{tablobaslik}", u.TabloBaslik);
                //docText = docText.Replace("{ureticifirmaad}", u.UreticiFirmaAdi);
                //docText = docText.Replace("{ureticifirmaadres}", u.UreticiFirmaAdresi);
                //docText = docText.Replace("{ureticiparcano}", u.UreticiFirmaParcaNo);
                //docText = docText.Replace("{tedarikcifirmaad}", u.TedarikciFirmaAdi);
                //docText = docText.Replace("{tedarikcifirmaadres}", u.TedarikciFirmaAdresi);
                //docText = docText.Replace("{tedarikciparcano}", u.TedarikciFirmaParcaNo);
                //docText = docText.Replace("{marka}", u.Marka);
                //docText = docText.Replace("{model}", u.Model);
                //docText = docText.Replace("{tabloaltyazi}", u.TabloYazisi);
                //docText = docText.Replace("{s1}", u.s1);
                //docText = docText.Replace("{s11}", u.s11);
                //docText = docText.Replace("{s2}", u.s2);
                //docText = docText.Replace("{s22}", u.s22);
                //docText = docText.Replace("{s3}", u.s3);
                //docText = docText.Replace("{s33}", u.s33);
                //docText = docText.Replace("{s4}", u.s4);
                //docText = docText.Replace("{s44}", u.s44);
                //docText = docText.Replace("{s5}", u.s5);
                //docText = docText.Replace("{s55}", u.s55);







                //using (StreamWriter sw = new StreamWriter(wordDocument.MainDocumentPart.GetStream(FileMode.Create)))
                //{
                //    sw.Write(docText);
                //}
                //wordDocument.MainDocumentPart.Document.Save();

                

                

             
            }


            // Image

            string document = newFilePath;
            string fileName = @"C:\Users\Talha ÖZMAN\Desktop\Masaüstü\image.jpg";
            InsertAPicture(document, fileName);

            // Adım 7: Yeni dosyanın adresini döndür.
            return newFilePath;
        }
        public FileResult Download(string fileName)
        {
            var fullPath = Path.Combine(Server.MapPath("~/Sablonlar/Urunler/"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }


        public static void InsertAPicture(string document, string fileName)
        {
            using (WordprocessingDocument wordprocessingDocument =
                WordprocessingDocument.Open(document, true))
            {
                MainDocumentPart mainPart = wordprocessingDocument.MainDocumentPart;

                ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);

                using (FileStream stream = new FileStream(fileName, FileMode.Open))
                {
                    imagePart.FeedData(stream);
                }

                AddImageToBody(wordprocessingDocument, mainPart.GetIdOfPart(imagePart));
            }
        }

        private static void AddImageToBody(WordprocessingDocument wordDoc, string relationshipId)
        {
            // Define the reference of the image.
            var element =
                 new Drawing(
                     new DW.Inline(
                         new DW.Extent() { Cx = 990000L, Cy = 792000L },
                         new DW.EffectExtent()
                         {
                             LeftEdge = 0L,
                             TopEdge = 0L,
                             RightEdge = 0L,
                             BottomEdge = 0L
                         },
                         new DW.DocProperties()
                         {
                             Id = (UInt32Value)1U,
                             Name = "Picture 1"
                         },
                         new DW.NonVisualGraphicFrameDrawingProperties(
                             new A.GraphicFrameLocks() { NoChangeAspect = true }),
                         new A.Graphic(
                             new A.GraphicData(
                                 new PIC.Picture(
                                     new PIC.NonVisualPictureProperties(
                                         new PIC.NonVisualDrawingProperties()
                                         {
                                             Id = (UInt32Value)0U,
                                             Name = "New Bitmap Image.jpg"
                                         },
                                         new PIC.NonVisualPictureDrawingProperties()),
                                     new PIC.BlipFill(
                                         new A.Blip(
                                             new A.BlipExtensionList(
                                                 new A.BlipExtension()
                                                 {
                                                     Uri =
                                                        "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                 })
                                         )
                                         {
                                             Embed = relationshipId,
                                             CompressionState =
                                             A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new PIC.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0L, Y = 0L },
                                             new A.Extents() { Cx = 990000L, Cy = 792000L }),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         )
                                         { Preset = A.ShapeTypeValues.Rectangle }))
                             )
                             { Uri = "https://schemas.openxmlformats.org/drawingml/2006/picture" })
                     )
                     {
                         DistanceFromTop = (UInt32Value)0U,
                         DistanceFromBottom = (UInt32Value)0U,
                         DistanceFromLeft = (UInt32Value)0U,
                         DistanceFromRight = (UInt32Value)0U,
                         EditId = "50D07946"
                     });

            // Append the reference to body, the element should be in a Run.
            wordDoc.MainDocumentPart.Document.Body.AppendChild(new Paragraph(new Run(element)));

            wordDoc.Save();
        }
    }
}
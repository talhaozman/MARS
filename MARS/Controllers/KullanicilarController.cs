using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MARS.Models.Entity;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

namespace MARS.Controllers
{
    [AllowAnonymous]
    public class KullanicilarController : Controller
    {
        Context c = new Context();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Kullanicilar k)
        {
            var kullanici = c.Kullanicilars.FirstOrDefault(x => x.KullaniciMail == k.KullaniciMail && x.KullaniciSifre == k.KullaniciSifre);
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(k.KullaniciMail, false);
                return RedirectToAction("ProjeIndex", "Projeler");
            }
            ViewBag.hata = "Kullanıcı Adı veya Şifre Yanlış!!!";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Index","Kullanicilar");
        }
        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(Kullanicilar k)
        {
            var model = c.Kullanicilars.Where(x => x.KullaniciMail == k.KullaniciMail).FirstOrDefault();
            if (model != null)
            {
                Guid rastgele = Guid.NewGuid();
                model.KullaniciSifre = rastgele.ToString().Substring(0, 8);
                c.SaveChanges();
                SmtpClient client = new SmtpClient("mail.dsgdefense.com",587);
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("talha.ozman@dsgdefense.com","Şifre Sıfırlama");
                mail.To.Add(model.KullaniciMail);
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre Değiştirme İsteği";
                mail.Body += "Merhabalar" + model.KullaniciAdi + model.KullaniciSoyadi + "<br/> Kullanıcı Adınız: " + model.KullaniciMail + "<br/> Şifreniz: " + model.KullaniciSifre;
                NetworkCredential net = new NetworkCredential("talha.ozman@dsgdefense.com","To0202Ba");
                client.Credentials = net;
                client.Send(mail);
                return RedirectToAction("Index");
            }
            ViewBag.hata = "E-Mail Adresi bulunamadı!!!";
            return View();
        }
        public ActionResult Kullanicilar()
        {
            var kullan = c.Kullanicilars.ToList();
            return View(kullan);
        }
        [HttpGet]
        public ActionResult KullaniciEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KullaniciEkle(Kullanicilar k)
        {
            c.Kullanicilars.Add(k);
            c.SaveChanges();
            return RedirectToAction("Kullanicilar");
        }
        public ActionResult KullaniciSil(int id)
        {
            var kullan = c.Kullanicilars.Find(id);
            c.Kullanicilars.Remove(kullan);
            c.SaveChanges();
            return RedirectToAction("Kullanicilar");
        }

        public ActionResult KullaniciGetir(int id)
        {
            var kullanici = c.Kullanicilars.Find(id);
            return View("KullaniciGetir", kullanici);

        }
        public ActionResult KullaniciGuncelle(Kullanicilar k)
        {
            var kul = c.Kullanicilars.Find(k.KullaniciId);
            kul.TCkimlik = k.TCkimlik;
            kul.KullaniciAdi = k.KullaniciAdi;
            kul.KullaniciSoyadi = k.KullaniciSoyadi;
            kul.KullaniciTel = k.KullaniciTel;
            kul.KullaniciDepartman = k.KullaniciDepartman;
            kul.KullaniciUnvan = k.KullaniciUnvan;
            kul.KullaniciMail = k.KullaniciMail;
            kul.KullaniciSifre = k.KullaniciSifre;
            c.SaveChanges();
            return RedirectToAction("Kullanicilar");
        }

    }
}
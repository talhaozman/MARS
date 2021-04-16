using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MARS.Models.Entity;

namespace MARS.Controllers
{
    //[Authorize]
    public class MalzemelerController : Controller
    {
        Context c = new Context();
        public ActionResult MalzemeIndex()
        {
            var malzeme = c.Malzemelers.ToList();
            return View(malzeme);
        }
        [HttpGet]
        public ActionResult MalzemeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MalzemeEkle(Malzemeler m)
        {
            c.Malzemelers.Add(m);
            c.SaveChanges();
            return RedirectToAction("MalzemeIndex");
        }
        public ActionResult GetList(string q)
        {
            try
            {
                var list = c.INCs.Select(x => new
                {
                    Id = x.INCId,
                    Text = x.INCNo + " - " +x.INCAd 
                });

                if (!string.IsNullOrEmpty(q))
                {
                    list = list.Where(x => x.Text.Contains(q));
                }

                return Json(new { items = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult GetListSinif(string q)
        {
            try
            {
                var list = c.GrupSinifKodlaris.Select(x => new
                {
                    Id = x.SinifId,
                    Text = x.SinifNo + " - " + x.SinifAd
                });

                if (!string.IsNullOrEmpty(q))
                {
                    list = list.Where(x => x.Text.Contains(q));
                }

                return Json(new { items = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult GetListAtik(string q)
        {
            try
            {
                var list = c.AtikKodlaris.Select(x => new
                {
                    Id = x.AtikKoduId,
                    Text = x.AtikKoduNo + " - " + x.AtikKoduAdi
                });

                if (!string.IsNullOrEmpty(q))
                {
                    list = list.Where(x => x.Text.Contains(q));
                }

                return Json(new { items = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult GetListKalem(string q)
        {
            try
            {
                var list = c.MalzemeKalemis.Select(x => new
                {
                    Id = x.MalzemeKalemiId,
                    Text = x.MalzemeKalemiAd
                });

                if (!string.IsNullOrEmpty(q))
                {
                    list = list.Where(x => x.Text.Contains(q));
                }

                return Json(new { items = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult GetListOzelMlz(string q)
        {
            try
            {
                var list = c.OzelMalzemeKodus.Select(x => new
                {
                    Id = x.OzMalKodId,
                    Text = x.OzMalKod + " - " + x.OzMalKodAd
                });

                if (!string.IsNullOrEmpty(q))
                {
                    list = list.Where(x => x.Text.Contains(q));
                }

                return Json(new { items = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult GetListAmbSah(string q)
        {
            try
            {
                var list = c.AmbSahKods.Select(x => new
                {
                    Id = x.AmbSahKoduId,
                    Text = x.AmbSahKodKod + " - " + x.AmbSahKoduAd
                });

                if (!string.IsNullOrEmpty(q))
                {
                    list = list.Where(x => x.Text.Contains(q));
                }

                return Json(new { items = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult GetListOnarBil(string q)
        {
            try
            {
                var list = c.OnarBilKodus.Select(x => new
                {
                    Id = x.OnarBilKodId,
                    Text = x.OnarBilKodAd
                });

                if (!string.IsNullOrEmpty(q))
                {
                    list = list.Where(x => x.Text.Contains(q));
                }

                return Json(new { items = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult GetListElCik(string q)
        {
            try
            {
                var list = c.ElCikYontemis.Select(x => new
                {
                    Id = x.ElCikYonId,
                    Text = x.ElcikYonNo + " - " + x.ElcikYonAd
                });

                if (!string.IsNullOrEmpty(q))
                {
                    list = list.Where(x => x.Text.Contains(q));
                }

                return Json(new { items = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult GetListRafOmru(string q)
        {
            try
            {
                var list = c.RafOmruKodus.Select(x => new
                {
                    Id = x.RafOmruKodId,
                    Text = x.RafOmruKodNo + " - " + x.RafOmruAd
                });

                if (!string.IsNullOrEmpty(q))
                {
                    list = list.Where(x => x.Text.Contains(q));
                }

                return Json(new { items = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
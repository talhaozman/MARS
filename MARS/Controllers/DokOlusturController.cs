using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MARS.Models.Entity;

namespace MARS.Controllers
{
    public class DokOlusturController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
          
            return View();
        }
        public ActionResult GetListProje(string q)
        {
            try
            {
                var list = c.Projelers.Select(x => new
                {
                    Id = x.ProjeId,
                    Text = x.ProjeKodu
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
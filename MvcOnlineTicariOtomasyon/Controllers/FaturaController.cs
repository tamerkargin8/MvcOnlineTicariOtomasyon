using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var faturalar = c.Faturalars.ToList();
            return View(faturalar);
        }
        [HttpGet]
        public ActionResult YeniFaturaEkle()
        {
            ViewBag.PersonelList = c.Personels.Select(p => new { Id = p.PersonelId, Name = p.PersonelAd }).ToList();
            ViewBag.CariList = c.Carilers.Select(c => new { Id = c.CariId, Name = c.CariAd }).ToList();
            return View(new Faturalar());
        }
        [HttpPost]
        public ActionResult YeniFaturaEkle(Faturalar fatura)
        {
            if (ModelState.IsValid)
            {
                c.Faturalars.Add(fatura);
                ViewBag.PersonelList = c.Personels.Select(p => new { Id = p.PersonelId, Name = p.PersonelAd }).ToList();
                ViewBag.CariList = c.Carilers.Select(c => new { Id = c.CariId, Name = c.CariAd }).ToList();
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fatura);
        }
    }
}
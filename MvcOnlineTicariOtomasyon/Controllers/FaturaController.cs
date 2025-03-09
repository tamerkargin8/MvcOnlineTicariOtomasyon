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
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            ViewBag.PersonelList = c.Personels.Select(p => new { Id = p.PersonelId, Name = p.PersonelAd }).ToList();
            ViewBag.CariList = c.Carilers.Select(c => new { Id = c.CariId, Name = c.CariAd }).ToList();
            return View(fatura);
        }
        public ActionResult FaturaGuncelle(Faturalar fatura)
        {
            if (ModelState.IsValid)
            {
                var faturaToUpdate = c.Faturalars.Find(fatura.FaturaId);
                faturaToUpdate.FaturaSeriNo = fatura.FaturaSeriNo;
                faturaToUpdate.FaturaSiraNo = fatura.FaturaSiraNo;
                faturaToUpdate.FaturaTarih = fatura.FaturaTarih;
                faturaToUpdate.FaturaSaat = fatura.FaturaSaat;
                faturaToUpdate.VergiDairesi = fatura.VergiDairesi;
                faturaToUpdate.FaturaToplamTutar = fatura.FaturaToplamTutar;
                faturaToUpdate.CariId = fatura.CariId;
                faturaToUpdate.PersonelId = fatura.PersonelId;
                ViewBag.PersonelList = c.Personels.Select(p => new { Id = p.PersonelId, Name = p.PersonelAd }).ToList();
                ViewBag.CariList = c.Carilers.Select(c => new { Id = c.CariId, Name = c.CariAd }).ToList();
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaDetay(int id)
        {
            var fatura = c.FaturaKalems.Where(f => f.FaturaId == id).ToList();
            return View(fatura);
        }
        [HttpGet]
        public ActionResult FaturaKalemEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaKalemEkle(FaturaKalem faturaKalem)
        {
            c.FaturaKalems.Add(faturaKalem);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
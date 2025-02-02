using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var satislar = c.SatisHarekets.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            ViewBag.PersonelList = c.Personels.Select(p => new { Id = p.PersonelId, Name = p.PersonelAd }).ToList();
            ViewBag.CariList = c.Carilers.Select(c => new { Id = c.CariId, Name = c.CariAd }).ToList();
            ViewBag.UrunList = c.Uruns.Select(u => new { Id = u.UrunId, Name = u.UrunAd }).ToList();
            return View(new SatisHareket());
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satis)
        {
            if (ModelState.IsValid)
            {
                c.SatisHarekets.Add(satis);
                ViewBag.PersonelList = c.Personels.Select(p => new { Id = p.PersonelId, Name = p.PersonelAd }).ToList();
                ViewBag.CariList = c.Carilers.Select(c => new { Id = c.CariId, Name = c.CariAd }).ToList();
                ViewBag.UrunList = c.Uruns.Select(u => new { Id = u.UrunId, Name = u.UrunAd }).ToList();
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(satis);
        }
        public ActionResult SatisGetir(int id)
        {
            var satis = c.SatisHarekets.Find(id);
            if (satis == null)
            {
                return HttpNotFound();
            }

            ViewBag.PersonelList = c.Personels.Select(p => new { Id = p.PersonelId, Name = p.PersonelAd }).ToList();
            ViewBag.CariList = c.Carilers.Select(c => new { Id = c.CariId, Name = c.CariAd }).ToList();
            ViewBag.UrunList = c.Uruns.Select(u => new { Id = u.UrunId, Name = u.UrunAd }).ToList();
            return View(satis);
        }
        public ActionResult SatisGuncelle(SatisHareket satis)
        {
            ViewBag.PersonelList = c.Personels.Select(p => new { Id = p.PersonelId, Name = p.PersonelAd }).ToList();
            ViewBag.CariList = c.Carilers.Select(c => new { Id = c.CariId, Name = c.CariAd }).ToList();
            ViewBag.UrunList = c.Uruns.Select(u => new { Id = u.UrunId, Name = u.UrunAd }).ToList();
            var st = c.SatisHarekets.Find(satis.SatisId);
            st.CariId = satis.CariId;
            st.PersonelId = satis.PersonelId;
            st.SatisAdet = satis.SatisAdet;
            st.SatisFiyat = satis.SatisFiyat;
            st.SatisTarih = satis.SatisTarih;
            st.SatisToplamTutar = satis.SatisToplamTutar;
            st.UrunId = satis.UrunId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var satisDetay = c.SatisHarekets.Where(x => x.SatisId == id).ToList();
            return View(satisDetay);
        }
    }
}
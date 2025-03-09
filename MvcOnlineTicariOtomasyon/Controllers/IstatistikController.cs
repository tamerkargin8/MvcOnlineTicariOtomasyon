using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            ViewBag.d1 = c.Carilers.Count().ToString();
            ViewBag.d2 = c.Uruns.Count().ToString();
            ViewBag.d3 = c.Personels.Count().ToString();
            ViewBag.d4 = c.Kategoris.Count().ToString();
            ViewBag.d5 = c.Uruns.Sum(x => x.UrunStok).ToString();
            ViewBag.d6 = (from x in c.Uruns select x.UrunMarka).Distinct().Count().ToString();
            ViewBag.d7 = c.Uruns.Count(x => x.UrunStok <= 20).ToString();
            ViewBag.d8 = (from x in c.Uruns orderby x.UrunSatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = (from x in c.Uruns orderby x.UrunSatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d10 = c.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d11 = c.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d12 = c.Uruns.GroupBy(x => x.UrunMarka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d13 = c.Uruns.Where(u => u.UrunId== (c.SatisHarekets.GroupBy(x => x.UrunId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.d14 = c.SatisHarekets.Sum(x => x.SatisToplamTutar).ToString();
            DateTime today = DateTime.Today;
            ViewBag.d15 = c.SatisHarekets.Where(x => x.SatisTarih == today).Sum(x => x.SatisToplamTutar).ToString();
            ViewBag.d16 = c.SatisHarekets.Count(x => x.SatisTarih == today).ToString();
            return View();
        }
        public ActionResult KolayTablolar()
        {
            return View();
        }
    }
}
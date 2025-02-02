using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x => x.CariDurum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler cariler)
        {
            cariler.CariDurum = true;
            c.Carilers.Add(cariler);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cari = c.Carilers.Find(id);
            cari.CariDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Cariler cariler)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir", cariler);
            }
            else
            {
                var cari = c.Carilers.Find(cariler.CariId);
                if (cari != null)
                {
                    cari.CariAd = cariler.CariAd;
                    cari.CariSoyad = cariler.CariSoyad;
                    cari.CariSehir = cariler.CariSehir;
                    cari.CariMail = cariler.CariMail;
                    cari.CariTelefon = cariler.CariTelefon;
                    cari.CariDurum = cariler.CariDurum;
                    c.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult CariPasifGetir()
        {
            var pasifDegerler = c.Carilers.Where(x => x.CariDurum == false).ToList();
            return View(pasifDegerler);
        }
        public ActionResult CariAktifEt(int id)
        {
            var cari = c.Carilers.Find(id);
            if (cari != null)
            {
                cari.CariDurum = true;
                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult CariSatisGecmisi(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            var cr = c.Carilers.Where(x => x.CariId == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            var toplamSatis = c.SatisHarekets.Where(x => x.CariId == id).Sum(y => (decimal?)y.SatisToplamTutar);
            ViewBag.t = toplamSatis;
            return View(degerler);
        }
    }
}
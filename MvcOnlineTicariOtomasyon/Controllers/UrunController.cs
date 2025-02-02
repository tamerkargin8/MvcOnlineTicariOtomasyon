using System.Linq;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System.Data.Entity;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Include(x => x.Kategori).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            PopulateKategoriler();
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            if (ModelState.IsValid)
            {
                c.Uruns.Add(urun);
                c.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateKategoriler();
            return View(urun);
        }
        public ActionResult UrunSil(int id)
        {
            var urun = c.Uruns.Find(id);
            c.Uruns.Remove(urun);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            PopulateKategoriler();
            var urun = c.Uruns.Find(id);
            return View("UrunGetir", urun);
        }
        public ActionResult UrunGuncelle(Urun urun)
        {
            var u = c.Uruns.Find(urun.UrunId);
            u.UrunAd = urun.UrunAd;
            u.UrunMarka = urun.UrunMarka;
            u.UrunAlisFiyat = urun.UrunAlisFiyat;
            u.UrunSatisFiyat = urun.UrunSatisFiyat;
            u.UrunStok = urun.UrunStok;
            u.UrunDurum = urun.UrunDurum;
            u.UrunGorsel = urun.UrunGorsel;
            u.KategoriId = urun.KategoriId;
            PopulateKategoriler();
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        private void PopulateKategoriler()
        {
            var kategoriler = c.Kategoris.Select(k => new SelectListItem
            {
                Value = k.KategoriId.ToString(),
                Text = k.KategoriAd
            }).ToList();
            ViewBag.Kategoriler = kategoriler;
        }
        public ActionResult UrunListesi()
        {
            var urunler = c.Uruns.Include(x => x.Kategori).ToList();
            return View(urunler);
        }
    }
}
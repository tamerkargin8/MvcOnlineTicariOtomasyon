using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler =c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            PopulateDepartmanlar();
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            if (ModelState.IsValid)
            {
                c.Personels.Add(personel);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateDepartmanlar();
            return View(personel);
        }
        public ActionResult PersonelSil(int id)
        {
            var personel = c.Personels.Find(id);
            personel.PersonelDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            PopulateDepartmanlar();
            var personel = c.Personels.Find(id);
            List<SelectListItem> degerler = (from x in c.Departmans.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.DepartmanId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("PersonelGetir", personel);
        }
        [HttpPost]
        public ActionResult PersonelGuncelle(Personel personel)
        {
            if (ModelState.IsValid)
            {
                {
                    var existingPersonel = c.Personels.Find(personel.PersonelId);
                    if (existingPersonel != null)
                    {
                        existingPersonel.PersonelAd = personel.PersonelAd;
                        existingPersonel.PersonelSoyad = personel.PersonelSoyad;
                        existingPersonel.PersonelAdres = personel.PersonelAdres;
                        existingPersonel.PersonelMail = personel.PersonelMail;
                        existingPersonel.PersonelTelefon = personel.PersonelTelefon;
                        existingPersonel.DepartmanId = personel.DepartmanId;
                        existingPersonel.PersonelDurum = personel.PersonelDurum;
                        c.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            return View(personel);
        }
        public ActionResult PersonelPasifGetir()
        {
            var pasifDegerler = c.Personels.Where(x => x.PersonelDurum == false).ToList();
            return View(pasifDegerler);
        }
        public ActionResult PersonelAktifEt(int id)
        {
            var personel = c.Personels.Find(id);
            personel.PersonelDurum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var cr = c.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.personel = cr;
            var toplamSatis = c.SatisHarekets.Where(x => x.CariId == id).Sum(y => (decimal?)y.SatisToplamTutar);
            ViewBag.toplamSatis = toplamSatis;
            return View(degerler);
        }
        private void PopulateDepartmanlar()
        {
            var departmanlar = c.Departmans.Select(d => new SelectListItem
            {
                Value = d.DepartmanId.ToString(),
                Text = d.DepartmanAd
            }).ToList();
            ViewBag.departmanlar = departmanlar;
        }
    }
}
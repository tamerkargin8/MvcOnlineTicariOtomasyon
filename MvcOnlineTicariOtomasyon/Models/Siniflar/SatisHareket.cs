using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }
        public DateTime SatisTarih { get; set; }
        public int SatisAdet { get; set; }
        public decimal SatisFiyat { get; set; }
        public decimal SatisToplamTutar { get; set; }
        public Urun Urun { get; set; }
        public Cariler Cari { get; set; }
        public Personel Personel { get; set; }
    }
}
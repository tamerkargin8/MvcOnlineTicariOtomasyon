using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunMarka { get; set; }
        public short UrunStok { get; set; }
        public decimal UrunAlisFiyat { get; set; }
        public decimal UrunSatisFiyat { get; set; }
        public bool UrunDurum { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        public string UrunAciklama { get; set; }
        public int KategoriId { get; set; } //Bir ürünün bir kategorisi olabilir.
        public virtual Kategori Kategori { get; set; } //Bir ürünün bir kategorisi olabilir.
        public ICollection<SatisHareket> SatisHarekets { get; set; } //Bir ürünün birden fazla satış hareketi olabilir.
    }
}
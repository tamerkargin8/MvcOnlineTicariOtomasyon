using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string FaturaAciklama { get; set; }
        public int FaturaMiktar { get; set; }
        public decimal FaturaBirimFiyat { get; set; }
        public decimal FaturaTutar { get; set; }
        public virtual Faturalar Faturalar { get; set; } // Faturalar sınıfı ile ilişkilendirme - FaturaKalem sınıfı ile Faturalar sınıfı arasında 1'e çok ilişki kuruldu.

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaId { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string FaturaSeriNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string FaturaSiraNo { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FaturaTarih { get; set; }
        [Column(TypeName = "Time")]
        public TimeSpan FaturaSaat { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string VergiDairesi { get; set; }
        [Column(TypeName = "Decimal")]
        public decimal FaturaToplamTutar { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
        public int CariId { get; set; }
        public int PersonelId { get; set; }
        public virtual Cariler Cari { get; set; }
        public virtual Personel Personel { get; set; }

    }
}
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
        public DateTime FaturaTarih { get; set; }
        public DateTime FaturaSaat { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string VergiDairesi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; } // One-to-Many relationship -- bir faturanın birden fazla fatura kalemi olabilir.
    }
}
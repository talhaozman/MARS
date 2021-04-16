using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class NatoUreticileri
    {
        [Key]
        public int NatoUreticileriId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string NCAGE { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string FirmaUnvani { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FirmaUlke { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FirmaIl { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FirmaIlce { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string FirmaAdres { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PostaKodu { get; set; }
    }
}
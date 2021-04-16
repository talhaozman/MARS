using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class Malzemeler
    {
        [Key]
        public int MalzemeId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string MalzemeAdi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string GrupSinifNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string UzunTanimi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string NIIN { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string INCNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string NSN { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string MalzemeKalem { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string StandartNorm { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string OzelMalzemeKod { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string AmbarlamaSahasiKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string OnarilabilirlikKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string EldenCikarmaYonetmi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string RafOmruKod { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string MalzemeAtikKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string MarkaModelTip { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Birim { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Aktif { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string MinimumTedarikSuresi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string MinimumSiparisMiktari { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string DegisimPeriyodu { get; set; }
        public int MalzemeTurId { get; set; }
        public virtual MalzemeTurleri MalzemeTurleri { get; set; }

    }
}
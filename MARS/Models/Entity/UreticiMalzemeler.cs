using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class UreticiMalzemeler
    {
        [Key]
        public int UreticiMalzemelerId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ImalatciParcaNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PaketMuhtevikayKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StokEn { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StokBoy { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StokYukseklik { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StokAgirlik { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string NakliyeEn { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string NakliyeBoy { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string NakliyeYukseklik { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string NakliyeAgirlik { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string BirimFiyati { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Kur { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeminKaynkakKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string BakimKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string MalzemeTedarikSuresi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string MTBF { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string MTBM { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string MTBR { get; set; }
    }
}
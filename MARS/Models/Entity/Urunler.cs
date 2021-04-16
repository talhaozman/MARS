using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class Urunler
    {
        [Key]
        public int UrunId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string UrunAdi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string ResimYazisi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string UreticiFirmaAdi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string UreticiFirmaAdresi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string UreticiFirmaParcaNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string TedarikciFirmaAdi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string TedarikciFirmaAdresi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TedarikciFirmaParcaNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Marka { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Model { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string TabloBaslik { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ResimYolu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string s1 { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string s11 { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string s2 { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string s22 { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string s3 { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string s33 { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string s4 { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string s44 { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string s5 { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string s55 { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]

        public string TabloYazisi { get; set; }
        public string UrunDosyaYolu { get; set; }

        public int DokumanListeId { get; set; }
        public virtual DokumanListe DokumanListe { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class Kullanicilar
    {

        [Key]
        public int KullaniciId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(11)]
        public string TCkimlik { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string KullaniciAdi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KullaniciSoyadi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string KullaniciTel { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KullaniciDepartman { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KullaniciUnvan { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string KullaniciMail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KullaniciSifre { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string KullaniciRol { get; set; }
    }
}
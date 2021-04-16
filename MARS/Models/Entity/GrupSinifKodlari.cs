using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class GrupSinifKodlari
    {
        [Key]
        public int SinifId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string SinifNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string SinifAd { get; set; }
    }
}
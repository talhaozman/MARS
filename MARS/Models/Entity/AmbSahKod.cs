using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class AmbSahKod
    {
        [Key]
        public int AmbSahKoduId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string AmbSahKodKod { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string AmbSahKoduAd { get; set; }

    }
}
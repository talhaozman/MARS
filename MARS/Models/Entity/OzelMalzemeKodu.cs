using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class OzelMalzemeKodu
    {
        [Key]
        public int OzMalKodId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string OzMalKod { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string OzMalKodAd { get; set; }
    }
}
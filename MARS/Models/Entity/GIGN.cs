using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class GIGN
    {
        [Key]
        public int GIGNId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string GIGNTur { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        public string GIGNAd { get; set; }
    }
}
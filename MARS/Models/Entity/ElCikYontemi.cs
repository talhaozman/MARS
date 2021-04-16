using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class ElCikYontemi
    {
        [Key]
        public int ElCikYonId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string ElcikYonNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ElcikYonAd { get; set; }
    }
}
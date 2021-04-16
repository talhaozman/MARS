using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class MalzemeKalemi
    {
        [Key]
        public int MalzemeKalemiId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        public string MalzemeKalemiAd { get; set; }

   
    }
}
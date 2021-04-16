using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class OnarBilKodu
    {
        [Key]
        public int OnarBilKodId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string OnarBilKodAd { get; set; }
    }
}
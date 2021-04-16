using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class MalzemeTurleri
    {
        [Key]
        public int MalzemeTurId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string TurNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string MalzemeTurAd { get; set; }

        public ICollection<Malzemeler> Malzemelers { get; set; }
    }

   
}
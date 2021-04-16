using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class TemelBirim
    {
        [Key]
        public int TemelBirimId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TemelBirimAdi { get; set; }
    }
}
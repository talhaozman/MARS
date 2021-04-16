using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class OlcuBirimleri
    {
        [Key]
        public int OlcuBirimId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string OlcuAdi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KısaAdi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TemelBirim { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Miktar { get; set; }
    }
}
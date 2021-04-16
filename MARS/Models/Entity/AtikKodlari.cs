using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class AtikKodlari
    {
        [Key]
        public int AtikKoduId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string AtikKoduNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string AtikKoduAdi { get; set; }
    }
}
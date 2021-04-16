using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class VeriBankasi
    {
        [Key]
        public int VeriBankasiId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string DokumanNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string  DokumanAdi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string DokumanTuru { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class RafOmruKodu
    {
        [Key]
        public int RafOmruKodId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(5)]

        public string RafOmruKodNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string RafOmruAd { get; set; }
    }
}
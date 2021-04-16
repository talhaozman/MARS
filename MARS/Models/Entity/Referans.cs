using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class Referans
    {
        [Key]
        public int ReferansId { get; set; }

        public string SıraNo { get; set; }
        public string RefDokumanAd { get; set; }

        public string RefDosyaYolu { get; set; }
        public int DokumanListeId { get; set; }
        public virtual DokumanListe DokumanListe { get; set; }
    }
}
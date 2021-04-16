using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class EmniyetTalimatlari
    {
        [Key]
        public int EmniyetTalimatlariId { get; set; }
        public string UyariEtiketleri { get; set; }
        public string DikkatEtiketleri { get; set; }
        public string emniyetDosyaYolu { get; set; }
        public int DokumanListeId { get; set; }
        public virtual DokumanListe DokumanListe { get; set; }
    }
}
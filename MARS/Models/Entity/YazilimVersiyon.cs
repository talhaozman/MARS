using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class YazilimVersiyon
    {
        public int YazilimVersiyonId { get; set; }
        public string SıraNo { get; set; }
        public string YazilimAd { get; set; }
        public string YazDosyaYolu { get; set; }
        public int DokumanListeId { get; set; }
        public virtual DokumanListe DokumanListe { get; set; }
    }
}
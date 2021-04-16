using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class Kapak
    {
        [Key]
        public int KapakId { get; set; }

        public string ProjeAdi { get; set; }

        public string DokumanAdi { get; set; }
        public string YayimTarihi { get; set; }
        public string Revizyon { get; set; }
        public string RevizyonTarihi { get; set; }

        public string DosyaYolu { get; set; }

        public int DokumanListeId { get; set; }

        public virtual DokumanListe DokumanListe { get; set; }
    }
}
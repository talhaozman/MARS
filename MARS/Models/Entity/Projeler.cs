using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MARS.Models.Entity
{
    public class Projeler
    {
        [Key]
        public int ProjeId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ProjeKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string GemiBordoNumarasi { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime YayimTarihi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Revizyon { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RevizyonTarihi { get; set; }

        public ICollection<Sozlesmeler> Sozlesmelers { get; set; }
        public ICollection<DokumanListe> DokumanListes { get; set; }
        public ICollection<BLDPlani> BLDPlanis { get; set; }

    }
}
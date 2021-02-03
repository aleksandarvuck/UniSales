using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniSales.API.Entities
{
    public class Proizvod
    {
        public int ProizvodID { get; set; }

        [Required]
        [StringLength(250)]
        public string Ime { get; set; }

        [Required]
        [StringLength(250)]
        public string Tip { get; set; }

        [Required]
        public string Opis { get; set; }

        public DateTime DatumPostavljanja { get; set; }

        public ICollection<PorudzbinaProizvod> PorudzbinaProizvod { get; set; }

        public ICollection<Grupa> Grupa { get; set; }
    }
}
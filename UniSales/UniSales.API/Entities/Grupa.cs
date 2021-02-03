using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniSales.API.Entities
{
    public class Grupa
    {
        public int GrupaID { get; set; }

        [Required]
        [StringLength(500)]
        public string Ime { get; set; }

        public ICollection<Proizvod> Proizvod { get; set; }
    }
}
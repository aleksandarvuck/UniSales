using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniSales.API.Entities
{
    public class Korisnik
    {
        public int KorisnikID { get; set; }

        [Required]
        [StringLength(100)]
        public string Ime { get; set; }

        [Required]
        [StringLength(100)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        public string Lozinka { get; set; }

        [Required]
        [StringLength(100)]
        public string KorisnickoIme { get; set; }

        public ICollection<Porudzbina> Porudzbina { get; set; }
    }
}
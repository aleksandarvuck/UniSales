using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniSales.API.Entities
{

    public  class Kupac
    {
 

        public int KupacID { get; set; }

        [Required]
        [StringLength(250)]
        public string Ime { get; set; }

        [Required]
        [StringLength(250)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(250)]
        public string Telefon { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        [StringLength(500)]
        public string Adresa { get; set; }

        [Required]
        [StringLength(100)]
        public string KorisnickoIme { get; set; }

        [Required]
        public string Lozinka { get; set; }

        public  ICollection<Porudzbina> Porudzbina { get; set; }
    }
}

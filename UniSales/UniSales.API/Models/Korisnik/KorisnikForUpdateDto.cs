using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniSales.API.Models.Korisnik
{

    public class KorisnikForUpdateDto
    {

        public int KorisnikID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Email { get; set; }


        public string Lozinka { get; set; }


        public string KorisnickoIme { get; set; }

    }
}

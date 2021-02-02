using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniSales.API.Models.Kupac
{

    public class KupacForCreationDto
    {
        public int KupacID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Telefon { get; set; }


        public string Email { get; set; }

        public string Adresa { get; set; }


        public string KorisnickoIme { get; set; }


        public string Lozinka { get; set; }

    }
}

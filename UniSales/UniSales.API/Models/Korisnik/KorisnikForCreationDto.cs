namespace UniSales.API.Models.Korisnik
{
    public class KorisnikForCreationDto
    {
        public int KorisnikID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Email { get; set; }

        public string Lozinka { get; set; }

        public string KorisnickoIme { get; set; }
    }
}
using System;

namespace UniSales.API.Models.Porudzbina
{
    public class PorudzbinaDto
    {
        public int PorudzbinaID { get; set; }

        public DateTime? DatumKreiranja { get; set; }

        public DateTime DatumPorudzbine { get; set; }

        public bool Status { get; set; }

        public int BrojNarudzbenice { get; set; }

        public DateTime? DatumIzmene { get; set; }

        public int? ProizvodID { get; set; }

        public int KorisnikID { get; set; }

        public int KupacID { get; set; }
    }
}

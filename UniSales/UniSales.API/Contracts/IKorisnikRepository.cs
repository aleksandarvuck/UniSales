using System.Collections.Generic;
using System.Threading.Tasks;
using UniSales.API.Entities;

namespace UniSales.API.Contracts
{
    public interface IKorisnikRepository
    {
        Task<IEnumerable<Korisnik>> PreuzmiKorisnikeAsync();

        Task<Korisnik> PronadjiKorisnikaAsync(int KorisnikID);

        Task<bool> KorisnikPostojiAsync(string korisnickoIme);

        void DodajKorisnika(Korisnik korisnik);

        void AzurirajKorisnika(Korisnik korisnik);

        void ObrisiKorisnika(Korisnik korisnik);

        Task<bool> SacuvajIzmeneAsync();
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniSales.API.Contracts;
using UniSales.API.DbContexts;
using UniSales.API.Entities;

namespace UniSales.API.Services
{
    public class KorisnikRepository : IKorisnikRepository, IDisposable
    {
        private readonly UniSalesContext _context;

        public KorisnikRepository(UniSalesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Korisnik>> PreuzmiKorisnikeAsync()
        {
            return await _context.Korisnik.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Korisnik> PronadjiKorisnikaAsync(int korisnikID)
        {
            return await _context.Korisnik.Where(a => a.KorisnikID == korisnikID).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<bool> KorisnikPostojiAsync(string korisnickoIme)
        {
            return await _context.Korisnik.AnyAsync(emp => emp.KorisnickoIme == korisnickoIme).ConfigureAwait(false);
        }

        public void DodajKorisnika(Korisnik korisnik)
        {
            if (korisnik == null)
            {
                throw new ArgumentNullException(nameof(korisnik));
            }

            _context.Korisnik.Add(korisnik);
        }

        public void AzurirajKorisnika(Korisnik korisnik)
        {
            //nema koda u ovoj implementaciji
        }

        public void ObrisiKorisnika(Korisnik korisnik)
        {
            {
                if (korisnik == null)
                {
                    throw new ArgumentNullException(nameof(korisnik));
                }

                _context.Korisnik.Remove(korisnik);
            }
        }

        public async Task<bool> SacuvajIzmeneAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
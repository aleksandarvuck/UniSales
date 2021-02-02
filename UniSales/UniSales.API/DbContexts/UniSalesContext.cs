using Microsoft.EntityFrameworkCore;
using UniSales.API.Entities;

namespace UniSales.API.DbContexts
{
    public class UniSalesContext : DbContext
    {
        public UniSalesContext(DbContextOptions<UniSalesContext> options) : base(options)
        {
            
        }

        public  DbSet<Grupa> Grupa { get; set; }
        public  DbSet<Korisnik> Korisnik { get; set; }
        public  DbSet<Kupac> Kupac { get; set; }
        public  DbSet<Porudzbina> Porudzbina { get; set; }
        public  DbSet<PorudzbinaProizvod> PorudzbinaProizvod { get; set; }
        public  DbSet<Proizvod> Proizvod { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

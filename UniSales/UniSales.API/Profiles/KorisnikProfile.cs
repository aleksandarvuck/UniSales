using AutoMapper;

namespace UniSales.API.Profiles
{
    public class KorisnikProfile : Profile
    {
        public KorisnikProfile()
        {
            CreateMap<Entities.Korisnik, Models.Korisnik.KorisnikDto>();
            CreateMap<Models.Korisnik.KorisnikForCreationDto, Entities.Korisnik>();
            CreateMap<Models.Korisnik.KorisnikForUpdateDto, Entities.Korisnik>();
        }
    }
}
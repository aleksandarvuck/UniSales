using AutoMapper;

namespace UniSales.API.Profiles
{
    public class KupacProfile : Profile
    {
        public KupacProfile()
        {
            CreateMap<Entities.Kupac, Models.Kupac.KupacDto>();
            CreateMap<Models.Kupac.KupacForCreationDto, Entities.Kupac>();
            CreateMap<Models.Kupac.KupacForUpdateDto, Entities.Kupac>();
        }
    }
}
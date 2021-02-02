using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

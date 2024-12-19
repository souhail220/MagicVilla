using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;

namespace MagicVilla_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {
            CreateMap<Villa, VillaDTO>();
            CreateMap<VillaDTO, Villa>();
            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa, VillaUpdateDTO>().ReverseMap();

            CreateMap<VillaNb, VillaNbDTO>();
            CreateMap<VillaNbDTO, VillaNb>();
        }
    }
}

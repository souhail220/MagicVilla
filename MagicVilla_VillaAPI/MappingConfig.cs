using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI
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

            CreateMap<VillaNb, VillaNbCreateDTO>().ReverseMap();
            CreateMap<VillaNb, VillaNbUpdateDTO>().ReverseMap();

            CreateMap<LocalUser, RegistrationRequestDTO>().ReverseMap();
        }
    }
}

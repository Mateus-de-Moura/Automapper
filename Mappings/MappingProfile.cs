using AutoMapper;
using AutoMapper.ClientDTO;
using AutoMapper.Models;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Automapperr.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDTO>()            
            .ForMember(dest => dest.Name, map => map.MapFrom(src => $"{src.Name} {src.Sobrenome}"))
            .ForMember(dest => dest.Address, map => map.MapFrom(src => src.Address))
            .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Email));            
        }
    }
}

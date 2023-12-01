using WebApi.Dtos;
using WebApi.Models;
using AutoMapper;

namespace WebApi.Profiles;
public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<PutFilmeDto, Filme>();
        CreateMap<Filme, PatchFilmeDto>();
        CreateMap<PatchFilmeDto, Filme>();
        CreateMap<Filme, ReadFilmeDto>()
             .ForMember(filmeDto => filmeDto.Sessoes, 
              opt => opt.MapFrom(filme => filme.Sessoes));
    
    }
}

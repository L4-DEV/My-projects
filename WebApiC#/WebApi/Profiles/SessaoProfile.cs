using AutoMapper;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
             CreateMap<CreateSessaoDto, Sessao>();
             CreateMap<PutSessaoDto, Sessao>();
             CreateMap<Sessao, PatchSessaoDto>();
             CreateMap<PatchSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>();
               //.ForMember(sessaoDto => sessaoDto.ReadEnderecoDto, 
               //opt => opt.MapFrom(cinema => cinema.Endereco));

        }      
    }
}

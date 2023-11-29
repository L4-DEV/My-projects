using AutoMapper;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class EnderecoProfile:Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<PutEnderecoDto, Endereco>();
            CreateMap<Endereco, PatchEnderecoDto>();
            CreateMap<PatchEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
        }
    }
}

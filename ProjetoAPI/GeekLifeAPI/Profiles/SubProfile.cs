using AutoMapper;
using GeekLifeAPI.Dtos.SubDtos;
using GeekLifeAPI.Models;

namespace GeekLifeAPI.Profiles
{
    public class SubProfile:Profile
    {
        public SubProfile()
        {
            CreateMap<CreateSubDto, Sub>();
            CreateMap<Sub, ReadSubDto>()
                .ForMember(dest => dest.Atividade, opt =>
                {
                    opt.MapFrom(origin => origin.Atividade ? "Ativo" : "Inativo");
                })
                .ForMember(subDto => subDto.Produto, opt => opt
            .MapFrom(sub => sub.Produtos));
            CreateMap<UpdateSubDto, Sub>();
            CreateMap<Sub,UpdateSubDto>();
            CreateMap<UpdateSubDtoPatch, Sub>();
            CreateMap<Sub, UpdateSubDtoPatch>();
            CreateMap<UpdateSubDto, Sub>();
            CreateMap<Sub, ReadSubDtoSupport>()
                 .ForMember(dest => dest.Atividade, opt =>
                 {
                     opt.MapFrom(origin => origin.Atividade ? "Ativo" : "Inativo");
                 })
                 .ForMember(subDto => subDto.Produto, opt => opt
            .MapFrom(sub => sub.Produtos)); ;
            CreateMap<Sub, ReadSubDtoEnd>()
                .ForMember(dest => dest.Atividade, opt =>
                {
                    opt.MapFrom(origin => origin.Atividade ? "Ativo" : "Inativo");
                });
            CreateMap<Sub, ReadAllSubDto>()
                .ForMember(dest => dest.Atividade, opt =>
                {
                    opt.MapFrom(origin => origin.Atividade ? "Ativo" : "Inativo");
                });
        }
    }
}

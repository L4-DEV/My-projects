using AutoMapper;
using GeekLifeAPI.Dtos.CCDDtos;
using GeekLifeAPI.Dtos.CDDtos;
using GeekLifeAPI.Models;

namespace GeekLifeAPI.Profiles
{
    public class CDProfile: Profile
    {
        public CDProfile()
        {
            CreateMap<CreateCDDto,CD>();
            CreateMap<CD, ReadCDDto>()
                .ForMember(dest => dest.Atividade, opt =>
                {
                    opt.MapFrom(origin => origin.Atividade ? "Ativo" : "Inativo");
                })
                 .ForMember(CDDto => CDDto.Produto, opt => opt
                .MapFrom(cd => cd.Produtos));
            CreateMap<UpdateCDDto,CD>();
            CreateMap<UpdateCDDtoPatch, CD>();
            CreateMap<CD, UpdateCDDto>();
            CreateMap<CD, UpdateCDDtoPatch>();
            CreateMap<ReadCDDto, CD>();
            CreateMap<CD, UpdateCDDtoPatch>();
            CreateMap<CreateCDDtoSupport, CD>();
            CreateMap<CD, CreateCDDtoSupport>();
            CreateMap<CD, ReadCDDtoSupport>();
            CreateMap<ReadCDDtoSupport,CD>();
            CreateMap<CD, ReadAllCDDto>()
                 .ForMember(dest => dest.Atividade, opt =>
                 {
                     opt.MapFrom(origin => origin.Atividade ? "Ativo" : "Inativo");
                 });

        }
    }
}


using AutoMapper;
using GeekLifeAPI.Dtos.CategoriaDtos;
using GeekLifeAPI.Models;

namespace GeekLifeAPI.Profiles;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<CreateCategoriaDto, Categoria>();
        CreateMap<Categoria, ReadCategoriaDto>()
            .ForMember(dest => dest.Atividade, opt =>
            {
                opt.MapFrom(origin => origin.Atividade ? "Ativo" : "Inativo");
            })
             .ForMember(categoriaDto => categoriaDto.Sub, opt => opt
            .MapFrom(categoria => categoria.Subs));
        CreateMap<UpdateCategoriaDto, Categoria>();
        CreateMap<UpdateCategoriaDtoPatch, Categoria>();
        CreateMap<Categoria, UpdateCategoriaDto>();
        CreateMap<Categoria, UpdateCategoriaDtoPatch>();
        CreateMap<ReadCategoriaDto, Categoria>();
        CreateMap<ReadCategoriaDtoSupport, Categoria>();
        CreateMap<Categoria, ReadCategoriaDtoSupport>()
             .ForMember(dest => dest.Atividade, opt =>
             {
                 opt.MapFrom(origin => origin.Atividade ? "Ativo" : "Inativo");
             })
             .ForMember(categoriaDto => categoriaDto.Sub, opt => opt
            .MapFrom(categoria => categoria.Subs));
        CreateMap<Categoria, ReadAllCategoriaDto>()
            .ForMember(dest => dest.Atividade, opt =>
            {
                opt.MapFrom(origin => origin.Atividade ? "Ativo" : "Inativo");
            });
    }
}

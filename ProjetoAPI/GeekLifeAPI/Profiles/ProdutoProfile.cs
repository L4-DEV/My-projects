using AutoMapper;
using GeekLifeAPI.Dtos.ProdutoDtos;
using GeekLifeAPI.Models;

namespace GeekLifeAPI.Profiles
{
    public class ProdutoProfile:Profile
    {

        public ProdutoProfile()
        {
            CreateMap<CreateProdutoDto, Produto>();
            CreateMap<Produto, ReadProdutoDto>()
                .ForMember(dest => dest.Atividade, opt =>
            {
                opt.MapFrom(origin => origin.Atividade ? "Ativo" : "Inativo");
            });
            CreateMap<UpdateProdutoDto, Produto>();
            CreateMap<UpdateProdutoDtoPatch, Produto>();
            CreateMap<Produto, UpdateProdutoDtoPatch>();
            CreateMap<Produto, UpdateProdutoDto>();
            CreateMap<Produto, ReadProdutoDtoSupport>()
                .ForMember(dest => dest.Atividade, opt =>
                {
                    opt.MapFrom(origin => origin.Atividade ? "Ativo" : "Inativo");

                });
            CreateMap<Produto, ReadProdutoDtoEnd>()
               .ForMember(dest => dest.Atividade, opt =>
               {
                   opt.MapFrom(origin => origin.Atividade ? "Ativo" : "Inativo");

               });
            CreateMap<Produto, ReadAllProdutoDto>()
                .ForMember(dest => dest.Atividade, opt =>
                {
                    opt.MapFrom(origin => origin.Atividade ? "Ativo" : "Inativo");

                });
        }
    }
}

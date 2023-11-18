using AutoMapper;
using GeekLifeAPI.Data.CategoriaRepository;
using GeekLifeAPI.Data.ProdutoRepository;
using GeekLifeAPI.Data.SubRepository;
using GeekLifeAPI.Dtos.SubDtos;
using GeekLifeAPI.Models;
using GeekLifeAPI.Service.SubService;
using System.Text.RegularExpressions;

namespace GeekLifeAPI.Services.SubService
{
    public class SubService : ISubService
    {

        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ISubRepository _subRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public SubService(ICategoriaRepository categoriaRepository, IMapper mapper, ISubRepository subRepository, IProdutoRepository produtoRepository)
        {
            _categoriaRepository = categoriaRepository;
            _subRepository = subRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<Sub> AddSubAsync(CreateSubDto subDto)
        {
            Sub sub = _mapper.Map<Sub>(subDto);

            Categoria categoria = await _categoriaRepository.GetFirstIdAsync(sub.CategoriaId);

            if (categoria != null && categoria.Atividade == false)
            {
                throw new ArgumentException("A Categoria destino está inativa, não é possível cadastrar uma Subcategoria em uma Categoria inativa!");
            }

            _subRepository.NameExist(sub);

            _subRepository.Add(sub);

            return sub;
        }

        public async Task<IEnumerable<ReadAllSubDto>> GetAllSubsAsync(int skip = 0, int take = 50, string? status = null, string? ordenacao = null, string? nome = null)
        {

            var subsFiltradas = await _subRepository.GetAllAsync(skip, take, status, ordenacao, nome);

            var dtos = _mapper.Map<IEnumerable<ReadAllSubDto>>(subsFiltradas);

            return dtos;

        }

        public async Task<ReadSubDto> GetSubByIdAsync(int id)
        {
            var sub = await _subRepository.GetFirstIdAsync(id);

            var subDto = _mapper.Map<ReadSubDto>(sub);

            return subDto;
        }

        public async Task<UpdateSubDto> PutSubAsync(int id, UpdateSubDto subDto)
        {
            var sub = await _subRepository.GetFirstIdAsync(id);

            _subRepository.NameExist(sub);

            HasProducts(sub);

            if (subDto.Atividade == false)
            {

                IEnumerable<Produto> produtos = await _produtoRepository.GetByIdAsync(id);
                foreach (var produto in produtos)
                {
                    produto.Atividade = subDto.Atividade;
                }
            }
            else
            {

                IEnumerable<Produto> produtos = await _produtoRepository.GetByIdAsync(id);
                foreach (Produto produto in produtos)
                {
                    produto.Atividade = subDto.Atividade;
                }
            }

            _mapper.Map(subDto, sub);
            _subRepository.Update(sub);

            return subDto;

        }

        public async Task<UpdateSubDtoPatch> PatchSubAsync(int id, UpdateSubDtoPatch subDto)
        {
            Sub sub = await _subRepository.GetFirstIdAsync(id);

            if (!string.IsNullOrEmpty(subDto.NomeDaSub))
            {
                _subRepository.NameExist(sub);
                CheckAttributesName(sub.NomeDaSub);

                if (subDto.NomeDaSub!=sub.NomeDaSub)
                {
                    sub.NomeDaSub = subDto.NomeDaSub;
                }
            }
            else
            {
                subDto.NomeDaSub = sub.NomeDaSub;
            }

            if (subDto.Atividade.HasValue)
            {
                HasProducts(sub);

                if (subDto.Atividade != sub.Atividade)
                {
                    sub.Atividade = subDto.Atividade.Value;

                    if (subDto.Atividade == false)
                    {

                        IEnumerable<Produto> produtos = await _produtoRepository.GetByIdAsync(id);
                        foreach (var produto in produtos)
                        {
                            produto.Atividade = subDto.Atividade.Value;
                        }
                    }
                    else
                    {
                        IEnumerable<Produto> produtos = await _produtoRepository.GetByIdAsync(id);
                        foreach (Produto produto in produtos)
                        {
                            produto.Atividade = subDto.Atividade.Value;
                        }
                    }
                }
            }
            else if (!subDto.Atividade.HasValue)
            {
                subDto.Atividade = sub.Atividade;
            }
               _mapper.Map(subDto, sub);
              _subRepository.Update(sub);
                return subDto;           
        }

            private static void HasProducts(Sub sub)
            {
                bool hasProducts = sub.Produtos.Any();


                if (hasProducts)
                {
                    throw new ArgumentException("Não é possível desativar o status de uma subcategoria enquanto ela tiver produtos cadastrados !");
                }
            }

            public Task DeleteSubAsync(int id)
            {
                return _subRepository.DeleteAsync(id);

            }
            private static void CheckAttributesName(string Name)
            {
                if (!Regex.IsMatch(Name, "^[a-zA-Z ]{3,128}$"))
                {
                    throw new ArgumentException("Digite uma nome que tenha entre 3 e 128 caracteres, apenas letras!");
                }

            }
        
    }
}

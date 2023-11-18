using AutoMapper;
using GeekLifeAPI.Data.CategoriaRepository;
using GeekLifeAPI.Data.CDRepository;
using GeekLifeAPI.Data.ProdutoRepository;
using GeekLifeAPI.Data.SubRepository;
using GeekLifeAPI.Dtos.ProdutoDtos;
using GeekLifeAPI.Models;
using System.Text.RegularExpressions;

namespace GeekLifeAPI.Services.ProdutoService
{
    public class ProdutoService : IProdutoService
    {
        private readonly ISubRepository _subRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICDRepository _cdRepository;
        private readonly IMapper _mapper;


        public ProdutoService(ICDRepository cdrepository,IMapper mapper, ISubRepository subRepository, IProdutoRepository produtoRepository)
        {
            _subRepository = subRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _cdRepository = cdrepository;
        }

        public async Task<Produto> AddProdutoAsync(CreateProdutoDto produtoDto)
        {
            Produto produto = _mapper.Map<Produto>(produtoDto);

            Sub sub = await _subRepository.GetFirstIdAsync(produto.SubId);

            if (sub == null || sub.Atividade == false)
            {
                throw new ArgumentException("A Subcategoria destino está inativa, não é possível cadastrar um produto em uma Subcategoria inativa!");
            }

            CD cd = await _cdRepository.GetFirstIdAsync(produto.CDId);

            if (cd == null || cd.Atividade == false)
            {
                throw new ArgumentException("O CD destino está inativo, não é possível cadastrar  um produto em um CD inativo!");
            }

            _produtoRepository.NameExist(produto);
            _produtoRepository.Add(produto);
            return produto;
        }
        public async Task<IEnumerable<ReadAllProdutoDto>> GetAllProdutosAsync(int skip = 0, int take = 50, string? status = null, string? ordenacao = null, string? nome = null)
        {

            var produtosFiltrados = await _produtoRepository.GetAllAsync(skip, take, status, ordenacao, nome);

            var dtos = _mapper.Map<IEnumerable<ReadAllProdutoDto>>(produtosFiltrados);

            return dtos;

        }

        public async Task<ReadProdutoDto> GetProdutoByIdAsync(int id)
        {
            var produto = await _produtoRepository.GetFirstIdAsync(id);

            var produtoDto = _mapper.Map<ReadProdutoDto>(produto);
            return produtoDto;
        }

        public async Task<UpdateProdutoDto> PutProdutoAsync(int id, UpdateProdutoDto produtoDto)
        {
            var produto = await _produtoRepository.GetFirstIdAsync(id);


            _produtoRepository.NameExist(produto);

            _mapper.Map(produtoDto, produto);

            _produtoRepository.Update(produto);
            return produtoDto;
        }

        public async Task<UpdateProdutoDtoPatch> PatchProdutoAsync(int id, UpdateProdutoDtoPatch produtoDto)
        {
            Produto produto = await _produtoRepository.GetFirstIdAsync(id);

            if (!string.IsNullOrEmpty(produtoDto.NomeDoProduto))
            {
                _produtoRepository.NameExist(produto);
                CheckAttributesString(produtoDto.NomeDoProduto);
                if (produtoDto.NomeDoProduto != produto.NomeDoProduto)
                {
                    produto.NomeDoProduto = produtoDto.NomeDoProduto;
                }
            }
            else
            {
                produtoDto.NomeDoProduto = produto.NomeDoProduto;
            }

            if (!string.IsNullOrEmpty(produtoDto.Descricao))
            {
                CheckAttributesString(produto.Descricao);
                if (produtoDto.Descricao != produto.Descricao)
                {
                    produto.Descricao = produtoDto.Descricao;
                }
            }
            else
            {
                produtoDto.Descricao = produto.Descricao;
            }

            if ((produtoDto.Atividade.HasValue))
            {
                if (produtoDto.Atividade != produtoDto.Atividade)
                {
                    produto.Atividade = produtoDto.Atividade.Value;
                }

            }
            else if (!produtoDto.Atividade.HasValue)
            {
                produtoDto.Atividade = produto.Atividade;
            }


            if (produtoDto.Peso != 0)
            {
                if (produtoDto.Peso != produto.Peso)
                {
                    produto.Peso = produtoDto.Peso;
                }

            }
            else
            {
                produtoDto.Peso = produto.Peso;
            }

            if (produtoDto.Altura != 0)
            {
                if (produtoDto.Altura != produto.Altura)
                {
                    produto.Altura = produtoDto.Altura;
                }

            }
            else
            {
                produtoDto.Altura = produto.Altura;
            }

            if (produtoDto.Largura != 0)
            {
                if (produtoDto.Largura != produto.Largura)
                {
                    produto.Largura = produtoDto.Largura;
                }

            }
            else
            {
                produtoDto.Largura = produto.Largura;
            }

            if (produtoDto.Comprimento != 0)
            {
                if (produtoDto.Comprimento != produtoDto.Comprimento)
                {
                    produto.Comprimento = produtoDto.Comprimento;
                }

            }
            else
            {
                produtoDto.Comprimento = produto.Comprimento;
            }

            if (produtoDto.Valor != 0)
            {
                if (produtoDto.Valor != produto.Valor)
                {
                    produto.Valor = produtoDto.Valor;
                }

            }
            else
            {
                produtoDto.Valor = produto.Valor;
            }

            if (produtoDto.QuantidadeEstoque != 0)
            {
                if (produtoDto.QuantidadeEstoque != produto.QuantidadeEstoque)
                {
                    produto.QuantidadeEstoque = produtoDto.QuantidadeEstoque;
                }

            }
            else
            {
                produtoDto.QuantidadeEstoque = produto.QuantidadeEstoque;
            }

           _mapper.Map(produtoDto, produto);
           _produtoRepository.Update(produto);

            return produtoDto;
        }

        public Task DeleteProdutoAsync(int id)
        {
            return _produtoRepository.DeleteAsync(id);

        }

        private static void CheckAttributesString(string String)
        {
            if (!Regex.IsMatch(String, @"^[A-Za-zÀ-ÿ0-9\s]{1,128}$"))
            {
                throw new ArgumentException("Digite uma nome que tenha entre 3 e 128 caracteres, apenas caracteres alfanuméricos!");
            }

          
        }
    }
}


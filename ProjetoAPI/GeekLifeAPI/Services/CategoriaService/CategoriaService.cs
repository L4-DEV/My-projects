using AutoMapper;
using FluentResults;
using GeekLifeAPI.Data.CategoriaRepository;
using GeekLifeAPI.Data.ProdutoRepository;
using GeekLifeAPI.Data.SubRepository;
using GeekLifeAPI.Dtos.CategoriaDtos;
using GeekLifeAPI.Dtos.CDDtos;
using GeekLifeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace GeekLifeAPI.Services.CategoriaService
{

    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ISubRepository _subRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper, ISubRepository subRepository)
        {
            _categoriaRepository = categoriaRepository;
            _subRepository = subRepository;         
            _mapper = mapper;
        }
        public Categoria AddCategoria([FromBody] CreateCategoriaDto categoriaDto)
        {

            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
            _categoriaRepository.NameExist(categoria);
            _categoriaRepository.Add(categoria);

            return categoria;
        }
        public async Task<IEnumerable<ReadAllCategoriaDto>> GetAllCategoriasAsync(int skip, int take, string? status, string? ordenacao,string? nome)
        {
            var categoriasFiltradas = await _categoriaRepository.GetAllAsync(skip, take, status, ordenacao, nome);

            var dtos = _mapper.Map<IEnumerable<ReadAllCategoriaDto>>(categoriasFiltradas);

            return dtos;
        }
        public async Task<ReadCategoriaDto> GetCategoriaByIdAsync(int id)
        {
            var categoria = await _categoriaRepository.GetFirstIdAsync(id);

            var categoriaDto = _mapper.Map<ReadCategoriaDto>(categoria);

            return categoriaDto;
        }


        public async  Task<UpdateCategoriaDto> PutCategoriaAsync(int id,UpdateCategoriaDto categoriaDto) 
        {
            Categoria categoria = await _categoriaRepository.GetFirstIdAsync(id);


            _categoriaRepository.NameExist(categoria);


            if (categoriaDto.Atividade == false)
            {
                IEnumerable<Sub> subs = await _subRepository.GetByIdAsync(id);
                foreach (var subcategoria in subs)
                {
                    subcategoria.Atividade = categoriaDto.Atividade;
                }
            }
            else
            {
                IEnumerable<Sub> subs = await _subRepository.GetByIdAsync(id);
                foreach (Sub subcategoria in subs)
                {
                    subcategoria.Atividade = categoriaDto.Atividade;
                }
            }

            _mapper.Map(categoriaDto, categoria);

            _categoriaRepository.Update(categoria);

            return (categoriaDto);
        }


        public async Task<UpdateCategoriaDtoPatch> PatchCategoriaAsync(int id, UpdateCategoriaDtoPatch categoriaDto)
        {
            Categoria categoria = await _categoriaRepository.GetFirstIdAsync(id);

            if (!string.IsNullOrEmpty(categoriaDto.NomeDaCategoria))
            {
                _categoriaRepository.NameExist(categoria);
                CheckAttributesName(categoriaDto.NomeDaCategoria);

                if ((categoriaDto.NomeDaCategoria != categoria.NomeDaCategoria))
                {
                    categoria.NomeDaCategoria = categoriaDto.NomeDaCategoria;
                }

            }
            else if (string.IsNullOrEmpty(categoriaDto.NomeDaCategoria))
            {
                categoriaDto.NomeDaCategoria = categoria.NomeDaCategoria;
            }

            if (categoriaDto.Atividade.HasValue)
            {
                if (categoriaDto.Atividade != categoria.Atividade)
                {
                    categoria.Atividade = categoriaDto.Atividade.Value;

                    if (categoriaDto.Atividade == false)
                    {

                        IEnumerable<Sub> subs = await _subRepository.GetByIdAsync(id);
                        foreach (var subcategoria in subs)
                        {
                            subcategoria.Atividade = categoriaDto.Atividade.Value;
                        }
                    }
                    else
                    {
                        IEnumerable<Sub> subs = await _subRepository.GetByIdAsync(id);
                        foreach (Sub subcategoria in subs)
                        {
                            subcategoria.Atividade = categoriaDto.Atividade.Value;
                        }
                    }
                }


            }
            else if (!categoriaDto.Atividade.HasValue)
            {
                categoriaDto.Atividade = categoria.Atividade;
            }

            _mapper.Map(categoriaDto, categoria);

            _categoriaRepository.Update(categoria);

            //UpdateCategoriaDtoPatch response = new UpdateCategoriaDtoPatch
            //{
            //    NomeDaCategoria = categoria.NomeDaCategoria,
            //    Status = categoria.Atividade ? "Ativo" : "Inativo",
            //    HoraDaModificacao = categoria.HoraDaModificacao
            //};
            return categoriaDto;
        }
    

        public Task DeleteCategoriaAsync(int id)
        {

            return _categoriaRepository.DeleteAsync(id);
        }

        private void CheckAttributesName(string Nome)
        {
            if (!Regex.IsMatch(Nome, @"^[A-Za-zÀ-ÿ0-9\s]{1,128}$"))
            {
                throw new ArgumentException("Digite uma nome que tenha entre 3 e 128 caracteres, apenas caracteres alfanuméricos!");
            }

        }

    }
}


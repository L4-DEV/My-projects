using AutoMapper;
using GeekLifeAPI.Data.CDRepository;
using GeekLifeAPI.Dtos.CCDDtos;
using GeekLifeAPI.Dtos.CDDtos;
using GeekLifeAPI.Integracao.Interfaces;
using GeekLifeAPI.Integracao.Response;
using GeekLifeAPI.Models;
using System.Text.RegularExpressions;

namespace GeekLifeAPI.Services.CDService
{
    public class CDService : ICDService
    {

        private readonly ICDRepository _cdRepository;
        private readonly IMapper _mapper;
        private readonly IViaCepIntegration _viaCepIntegracao;

        public CDService(IViaCepIntegration viaCepIntegracao, IMapper mapper, ICDRepository cdRepository)
        {
            _mapper = mapper;
            _cdRepository = cdRepository;
            _viaCepIntegracao = viaCepIntegracao;
        }
        public async Task<CD> AddCDAsync(CreateCDDto CDDto)
        {
            if (string.IsNullOrWhiteSpace(CDDto.CEP))
            {
                throw new ArgumentException("Informe um CEP válido");
            }

            ViaCep viaCepData = await _viaCepIntegracao.GetDataViaCep(CDDto.CEP);

            if (viaCepData != null)
            {
                CD cd = _mapper.Map<CD>(CDDto);

                cd.Logradouro = viaCepData.Logradouro;
                cd.Bairro = viaCepData.Bairro;
                cd.Cidade = viaCepData.Localidade;

                _cdRepository.AdressExist(cd);
                _cdRepository.Add(cd);

                return cd;
            }
            else
            {
                throw new ArgumentException("CEP inválido ou não encontrado no ViaCep.");
            }
        }
        public async Task<IEnumerable<ReadAllCDDto>> GetAllCDsAsync(int skip, int take, string? status, string? ordenacao, string? nome)
        {
            var cdsFiltrados = await _cdRepository.GetAllAsync(skip, take, status, ordenacao, nome);

            var dtos = _mapper.Map<IEnumerable<ReadAllCDDto>>(cdsFiltrados);

            return dtos;
        }
        public async Task<ReadCDDto> GetCDByIdAsync(int id)
        {
            var cd = await _cdRepository.GetFirstIdAsync(id);

            var cdDto = _mapper.Map<ReadCDDto>(cd);

            return cdDto;
        }

        public async Task<UpdateCDDto> PutCDAsync(int id, UpdateCDDto cdDto)
        {
            CD cd = await _cdRepository.GetFirstIdAsync(id);

            HasProducts(cd);

            ViaCep viaCepData = await _viaCepIntegracao.GetDataViaCep(cdDto.CEP);

            if (viaCepData != null)
            {
                _mapper.Map(cdDto, cd);

                cd.Logradouro = viaCepData.Logradouro;
                cd.Bairro = viaCepData.Bairro;
                cd.Cidade = viaCepData.Localidade;

                _cdRepository.AdressExist(cd);
                _cdRepository.Update(cd);
            }
            else
            {
                throw new ArgumentException("CEP inválido ou não encontrado no ViaCep.");
            }

            return cdDto;
        }
        public async Task<UpdateCDDtoPatch> PatchCDAsync(int id, UpdateCDDtoPatch cdDto)
        {
            CD cd = await _cdRepository.GetFirstIdAsync(id);

            ViaCep viaCepData = await _viaCepIntegracao.GetDataViaCep(cdDto.CEP);

            if (viaCepData != null)
            {
                cd.Logradouro = viaCepData.Logradouro;
                cd.Bairro = viaCepData.Bairro;
                cd.Cidade = viaCepData.Localidade;
                cd.UF = viaCepData.Uf;

                _cdRepository.AdressExist(cd);
            }
            else
            {
                cdDto.CEP = cd.CEP;
            }

            if (!string.IsNullOrEmpty(cdDto.NomeDoCD))
            {
                _cdRepository.NameExist(cd);
                CheckAttributesString(cdDto.NomeDoCD);

                if (cdDto.NomeDoCD != cd.NomeDoCD)
                {
                    cd.NomeDoCD = cdDto.NomeDoCD;
                }

            }
            else
            {
                cdDto.NomeDoCD = cd.NomeDoCD;
            }


            if (!string.IsNullOrEmpty(cdDto.Complemento))
            {
                CheckAttributesString(cdDto.Complemento);

                if (cdDto.Complemento != cd.Complemento)
                {
                    cd.Complemento = cdDto.Complemento;
                }
            }
            else
            {
                cdDto.Complemento = cd.Complemento;
            }

            if (cdDto.Atividade.HasValue)
            {
                HasProducts(cd);
                if (cdDto.Atividade != cd.Atividade)
                {
                    cd.Atividade = cdDto.Atividade.Value;
                }
            }
            else if (!cdDto.Atividade.HasValue)
            {
                cdDto.Atividade = cd.Atividade;
            }

            if (cdDto.Numero != 0)
            {
                if (cdDto.Numero != cd.Numero)
                {
                    cd.Numero = cdDto.Numero;
                }
            }
            else
            {
                cdDto.Numero = cd.Numero;
            }
            _mapper.Map(cdDto, cd);
            _cdRepository.Update(cd);
            return cdDto;
        }

        public Task DeleteCDAsync(int id)
        {
            return _cdRepository.DeleteAsync(id);
        }

        private static void CheckAttributesString(string String)
        {
            if (!Regex.IsMatch(String, @"^[A-Za-zÀ-ÿ0-9\s]{1,128}$"))
            {
                throw new ArgumentException("Digite uma nome que tenha entre 3 e 128 caracteres, apenas alfanuméricos!");
            }
        }

        private static void HasProducts(CD cd)
        {
            bool hasProducts = cd.Produtos.Any();

            if (hasProducts)
            {
                throw new ArgumentException("Não é possível desativar o status de um cd enquanto ele tiver produtos cadastrados !");
            }
        }
    }
}

using GeekLifeAPI.Integracao.Response;

namespace GeekLifeAPI.Integracao.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<ViaCep> GetDataViaCep(string cep);
    }
}

using GeekLifeAPI.Integracao.Response;
using Refit;

namespace GeekLifeAPI.Integracao.Refit
{
    public interface IViaCepIntegrationRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCep>> ObterDadosViaCep(string cep);
    }
}

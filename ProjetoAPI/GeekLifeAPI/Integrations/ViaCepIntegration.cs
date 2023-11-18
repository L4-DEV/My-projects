using GeekLifeAPI.Integracao.Interfaces;
using GeekLifeAPI.Integracao.Refit;
using GeekLifeAPI.Integracao.Response;

namespace GeekLifeAPI.Integracao
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegracaoRefit;

        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegracaoRefit)
        {
                _viaCepIntegracaoRefit = viaCepIntegracaoRefit;
        }
        public async Task<ViaCep> GetDataViaCep(string cep)
        {
            var responseData = await _viaCepIntegracaoRefit.ObterDadosViaCep(cep);

            if (responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }
            return null;
        }
    }
}

using GeekLifeAPI.Integracao.Interfaces;
using GeekLifeAPI.Integracao.Response;
using GeekLifeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekLifeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegration _viaCepIntegracao;

        public CepController(IViaCepIntegration viaCepIntegracao)
        {
                _viaCepIntegracao = viaCepIntegracao;
        }

        #region
        /// <summary>
        /// Obtém os dados de endereço a partir de um CEP.
        /// </summary>
        /// <param name="cep">O CEP para o qual os dados de endereço serão obtidos.</param>
        /// <returns>
        /// Um objeto contendo os dados de endereço correspondentes ao CEP fornecido.
        /// </returns>
        /// <response code="200">Retorna os dados de endereço correspondentes ao CEP fornecido.</response>
        /// <response code="400">Retorna um erro indicando que o CEP não foi encontrado.</response>
        #endregion

        [ProducesResponseType(typeof(ViaCep), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCep>> ListarDadosEndereco([FromBody]string cep)
        {
            var responseData = await _viaCepIntegracao.GetDataViaCep(cep);

            if (responseData == null) 
            {
                return BadRequest("CEP não encontrado");
            }

            return Ok(responseData);
        }
    }
}

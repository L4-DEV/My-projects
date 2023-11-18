using GeekLifeAPI.Dtos.CCDDtos;
using GeekLifeAPI.Dtos.CDDtos;
using GeekLifeAPI.Models;
using GeekLifeAPI.Services.CDService;
using Microsoft.AspNetCore.Mvc;

namespace GeekLifeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CDController : ControllerBase
    {
        private ICDService _cdService;

        public CDController(ICDService service)
        {
            _cdService = service;
        }

        #region
        /// <summary>
        /// Cria um novo centro de distribuição.
        /// </summary>
        /// <param name="cdDto">Os dados do cd a ser criado.</param>
        /// <returns>
        /// Um objeto CD recém-criado, se a operação for bem-sucedida.
        /// </returns>
        /// <response code="201">Retorna o objeto CD recém-criado.</response>
        /// <response code="400">Retorna um erro de solicitação inválida.</response>
        #endregion

        [ProducesResponseType(typeof(CD), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpPost]
        
        public async Task<ActionResult> PostCD([FromBody] CreateCDDto cdDto)
        {
            try
            {
                var result = await _cdService.AddCDAsync(cdDto);

                if (result != null)
                {
                    return CreatedAtAction(nameof(GetCDById), new { id = result.Id }, result);
                }
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        #region
        /// <summary>
        /// Obtém uma lista de centros de distribuição com opções de paginação, filtragem e ordenação.
        /// </summary>
        /// <param name="skip">O número de itens a serem ignorados (pulados).</param>
        /// <param name="take">O número máximo de itens a serem retornados.</param>
        /// <param name="status">O status dos cds a serem filtrados, ativo (true) e inativo (false).</param>
        /// <param name="ordenacao">O critério de ordenação dos cds, crescente ou decrescente..</param>
        /// <param name="nome">O nome dos cds a serem filtradas.</param>
        /// <returns>
        /// Um objeto contendo a lista de cds de acordo com os parâmetros fornecidos.
        /// </returns>
        /// /// <response code="200">Retorna a lista de cds de acordo com os parâmetros fornecidos.</response>
        /// <response code="400">Retorna um erro de solicitação inválida.</response>
        /// <response code="404">Retorna um erro caso não seja possível encontrar os recursos solicitados.</response>
        #endregion

        [ProducesResponseType(typeof(CD), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpGet]
       
        public async Task<IActionResult> GetAllCDs([FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? status = null, [FromQuery] string? ordenacao = null, [FromQuery] string? nome = null)
        {
            try
            {
                var cds = await _cdService.GetAllCDsAsync(skip, take, status, ordenacao, nome);
                var response = new
                {
                    CDs = cds
                };

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        #region
        /// <summary>
        /// Obtém um centro de distribuição por ID.
        /// </summary>
        /// <param name="id">O ID do cd a ser obtido.</param>
        /// <returns>
        /// Um objeto contendo os dados do cd correspondente ao ID fornecido.
        /// </returns>
        /// <response code="200">Retorna os dados do cd correspondente ao ID fornecido.</response>
        /// <response code="400">Retorna um erro de solicitação inválida.</response>
        /// <response code="404">Retorna um erro caso não seja possível encontrar o cd solicitado.</response>
        #endregion

        [ProducesResponseType(typeof(CD), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCDById([FromQuery] int id)
        {
            try
            {
                var cds = await _cdService.GetCDByIdAsync(id);
                return Ok(cds);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        #region
        /// <summary>
        /// Atualiza um centro de distribuição completo por ID.
        /// </summary>
        /// <param name="id">O ID do cd a ser atualizado.</param>
        /// <param name="cdDto">Os dados atualizados do cd.</param>
        /// <returns>
        /// Um objeto contendo os dados atualizados do cd após a operação.
        /// </returns>
        /// <response code="200">Retorna os dados atualizados do cd após a operação.</response>
        /// <response code="400">Retorna um erro de solicitação inválida.</response>
        /// <response code="404">Retorna um erro caso não seja possível encontrar o cd para atualização.</response>
        #endregion

        [ProducesResponseType(typeof(CD), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpPut("{id}")] 
        public async Task<IActionResult> PutCD([FromQuery] int id, [FromBody] UpdateCDDto cdDto)
        {
            try
            {
                await _cdService.PutCDAsync(id, cdDto);
                return Ok(cdDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        #region
        /// <summary>
        /// Atualiza parcialmente um centro de distribuição por ID.
        /// </summary>
        /// <param name="id">O ID do cd a ser parcialmente atualizado.</param>
        /// <param name="cdDto">Os dados parcialmente atualizados do cd.</param>
        /// <returns>
        /// Um objeto contendo os dados parcialmente atualizados do cd após a operação.
        /// </returns>
        /// <response code="200">Retorna os dados parcialmente atualizados do cd após a operação.</response>
        /// <response code="400">Retorna um erro de solicitação inválida.</response>
        /// <response code="404">Retorna um erro caso não seja possível encontrar o cd para atualização parcial.</response>
        #endregion

        [ProducesResponseType(typeof(CD), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCD([FromQuery] int id, [FromBody] UpdateCDDtoPatch cdDto)
        {
            try
            {
                await _cdService.PatchCDAsync(id, cdDto);
                return Ok(cdDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        #region
        /// <summary>
        /// Deleta um centro de distribuição por ID.
        /// </summary>
        /// <param name="id">O ID do cd a ser deletado.</param>
        /// <returns>
        /// Uma mensagem indicando que o cd com o ID fornecido foi deletado.
        /// </returns>
        /// <response code="200">Retorna uma mensagem indicando que o cd foi deletado com sucesso.</response>
        /// <response code="404">Retorna um erro caso não seja possível encontrar o cd para deleção.</response>
        #endregion

        [ProducesResponseType(typeof(CD), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCD([FromQuery] int id)
        {
            try
            {
                await _cdService.DeleteCDAsync(id);
                return Ok("Deletado");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}


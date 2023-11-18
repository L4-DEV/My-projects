using Microsoft.AspNetCore.Mvc;
using GeekLifeAPI.Dtos.SubDtos;
using GeekLifeAPI.Service.SubService;
using GeekLifeAPI.Models;

namespace GeekLifeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubController : ControllerBase
    {
        private ISubService _subService;

        public SubController(ISubService service)
        {
            _subService = service;
        }
        #region
        /// <summary>
        /// Cria uma nova subcategoria.
        /// </summary>
        /// <param name="subDto">Osb dados da sub a ser criada.</param>
        /// <returns>
        /// Um objeto Sub recém-criado, se a operação for bem-sucedida.
        /// </returns>
        /// <response code="201">Retorna o objeto sub recém-criado.</response>
        /// <response code="400">Retorna um erro de solicitação inválida.</response>
        #endregion

        [ProducesResponseType(typeof(Sub), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpPost]

        public async Task<IActionResult> PostSub([FromBody] CreateSubDto subDto)
        {
            try
            {
                var result = await _subService.AddSubAsync(subDto);

                if (result != null)
                {
                    return CreatedAtAction(nameof(GetSubById), new { id = result.Id }, result);
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
        /// Obtém uma lista de subcategorias com opções de paginação, filtragem e ordenação.
        /// </summary>
        /// <param name="skip">O número de itens a serem ignorados (pulados).</param>
        /// <param name="take">O número máximo de itens a serem retornados.</param>
        /// <param name="status">O status das subs a serem filtradas, ativo (true) e inativo (false).</param>
        /// <param name="ordenacao">O critério de ordenação das subs, crescente ou decrescente.</param>
        /// <param name="nome">O nome das subs a serem filtradas.</param>
        /// <returns>
        /// Um objeto contendo a lista de subs de acordo com os parâmetros fornecidos.
        /// </returns>
        /// /// <response code="200">Retorna a lista de subs de acordo com os parâmetros fornecidos.</response>
        /// <response code="400">Retorna um erro de solicitação inválida.</response>
        /// <response code="404">Retorna um erro caso não seja possível encontrar os recursos solicitados.</response>
        #endregion

        [ProducesResponseType(typeof(Sub), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpGet]
        public async Task<IActionResult> GetAllSubs([FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? status = null, [FromQuery] string? ordenacao = null, [FromQuery] string? nome = null)
        {
            try
            {
                var subs = await _subService.GetAllSubsAsync(skip, take, status, ordenacao, nome);

                var response = new
                {
                    Subs = subs
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
        /// Obtém uma subcategoria por ID.
        /// </summary>
        /// <param name="id">O ID da sub a ser obtida.</param>
        /// <returns>
        /// Um objeto contendo os dados da sub correspondente ao ID fornecido.
        /// </returns>
        /// <response code="200">Retorna os dados da sub correspondente ao ID fornecido.</response>
        /// <response code="400">Retorna um erro de solicitação inválida.</response>
        /// <response code="404">Retorna um erro caso não seja possível encontrar a sub solicitada.</response>
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubById([FromQuery]int id)
        {
            try
            {
                var subs = await _subService.GetSubByIdAsync(id);
                return Ok(subs);
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
        /// Atualiza uma subcategoria completa por ID.
        /// </summary>
        /// <param name="id">O ID da sub a ser atualizada.</param>
        /// <param name="subDto">Os dados atualizados da sub.</param>
        /// <returns>
        /// Um objeto contendo os dados atualizados da sub após a operação.
        /// </returns>
        /// <response code="200">Retorna os dados atualizados da sub após a operação.</response>
        /// <response code="400">Retorna um erro de solicitação inválida.</response>
        /// <response code="404">Retorna um erro caso não seja possível encontrar a sub para atualização.</response>
        #endregion

        [ProducesResponseType(typeof(Sub), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSub([FromQuery]int id, [FromBody] UpdateSubDto subDto)
        {
            try
            {
                await _subService.PutSubAsync(id, subDto);
                return Ok(subDto);
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
        /// Atualiza parcialmente uma subcategoria por ID.
        /// </summary>
        /// <param name="id">O ID da sub a ser parcialmente atualizada.</param>
        /// <param name="subDto">Os dados parcialmente atualizados da sub.</param>
        /// <returns>
        /// Um objeto contendo os dados parcialmente atualizados da sub após a operação.
        /// </returns>
        /// <response code="200">Retorna os dados parcialmente atualizados da sub após a operação.</response>
        /// <response code="400">Retorna um erro de solicitação inválida.</response>
        /// <response code="404">Retorna um erro caso não seja possível encontrar a sub para atualização parcial.</response>
        #endregion

        [ProducesResponseType(typeof(Sub), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchSub([FromQuery]int id, [FromBody] UpdateSubDtoPatch subDto)
        {
            try
            {
                await _subService.PatchSubAsync(id, subDto);
                return Ok(subDto);
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
        /// Deleta uma subcategoria por ID.
        /// </summary>
        /// <param name="id">O ID da sub a ser deletada.</param>
        /// <returns>
        /// Uma mensagem indicando que a sub com o ID fornecido foi deletada.
        /// </returns>
        /// <response code="200">Retorna uma mensagem indicando que a sub foi deletada com sucesso.</response>
        /// <response code="404">Retorna um erro caso não seja possível encontrar a sub para deleção.</response>
        #endregion

        [ProducesResponseType(typeof(Sub), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSub([FromQuery] int id)
        {
            try
            {
                await _subService.DeleteSubAsync(id);
                return Ok("Deletado");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}


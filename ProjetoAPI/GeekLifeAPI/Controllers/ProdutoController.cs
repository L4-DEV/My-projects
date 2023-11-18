using GeekLifeAPI.Dtos.ProdutoDtos;
using GeekLifeAPI.Models;
using GeekLifeAPI.Services.ProdutoService;
using Microsoft.AspNetCore.Mvc;

namespace GeekLifeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private IProdutoService _produtoService;

        public ProdutoController(IProdutoService service)
        {
            _produtoService = service;
        }

        #region
        /// <summary>
        /// Cria um novo produto.
        /// </summary>
        /// <param name="produtoDto">Os dados do produto a ser criado.</param>
        /// <returns>
        /// Um objeto Produto recém-criado, se a operação for bem-sucedida.
        /// </returns>
        /// <response code="201">Retorna o objeto Produto recém-criado.</response>
        /// <response code="400">Retorna um erro de solicitação inválida.</response>
        #endregion

        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult>PostProduto([FromBody] CreateProdutoDto produtoDto)
        {
             try
             {
                var result = await _produtoService.AddProdutoAsync(produtoDto);

                if (result != null)
                {
                    return CreatedAtAction(nameof(GetProdutoById), new { id = result.Id }, result);
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
        /// Obtém uma lista de produtos  com opções de paginação, filtragem e ordenação.
        /// </summary>
        /// <param name="skip">O número de itens a serem ignorados (pulados).</param>
        /// <param name="take">O número máximo de itens a serem retornados.</param>
        /// <param name="status">O status dos produtos a serem filtrados, ativo (true) e inativo (false).</param>
        /// <param name="ordenacao">O critério de ordenação dos produtos, crescente ou decrescente.</param>
        /// <param name="nome">O nome dos produtos a serem filtrados.</param>
        /// <returns>
        /// Um objeto contendo a lista de produtos de acordo com os parâmetros fornecidos.
        /// </returns>
        /// /// <response code="200">Retorna a lista de produtos de acordo com os parâmetros fornecidos.</response>
        /// <response code="400">Retorna um erro de solicitação inválida.</response>
        /// <response code="404">Retorna um erro caso não seja possível encontrar os recursos solicitados.</response>
        #endregion

        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpGet]
        public async Task<IActionResult> GetAllProdutos([FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? status = null, [FromQuery] string? ordenacao = null, [FromQuery] string? nome = null)
        {
            try
            {
                var produtos = await _produtoService.GetAllProdutosAsync (skip, take, status, ordenacao, nome);
                var response = new
                {
                   Produtos = produtos
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
        /// Obtém um produto por ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser obtido.</param>
        /// <returns>
        /// Um objeto contendo os dados do produto correspondente ao ID fornecido.
        /// </returns>
        /// <response code="200">Retorna os dados do produto correspondente ao ID fornecido.</response>
        /// <response code="400">Retorna um erro de solicitação inválida.</response>
        /// <response code="404">Retorna um erro caso não seja possível encontrar o produto solicitado.</response>
        #endregion

        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutoById([FromQuery]int id)
        {
            try
            {
                var produtoDto = await _produtoService.GetProdutoByIdAsync(id);
                return Ok(produtoDto);
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
        /// Atualiza um produto completo por ID.
        /// </summary>
        /// <param name="id">O ID do produto  a ser atualizado.</param>
        /// <param name="produtoDto">Os dados atualizados do produto .</param>
        /// <returns>
        /// Um objeto contendo os dados atualizados do produto  após a operação.
        /// </returns>
        /// <response code="200">Retorna os dados atualizados do produto  após a operação.</response>
        /// <response code="400">Retorna um erro de solicitação inválida.</response>
        /// <response code="404">Retorna um erro caso não seja possível encontrar o produto para atualização.</response>
        #endregion

        [ProducesResponseType(typeof(Sub), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        [HttpPut("{id}")] //Put modifica o Objeto inteiro.
        public async Task<IActionResult> PutProduto([FromQuery]int id, [FromBody] UpdateProdutoDto produtoDto)
        {
            try
            {
               await _produtoService.PutProdutoAsync (id, produtoDto);
                return Ok(produtoDto);
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
        /// Atualiza parcialmente um produto por ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser parcialmente atualizado.</param>
        /// <param name="produtoDto">Os dados parcialmente atualizados do produto.</param>
        /// <returns>
        /// Um objeto contendo os dados parcialmente atualizados do produto após a operação.
        /// </returns>
        /// <response code="200">Retorna os dados parcialmente atualizados do produto após a operação.</response>
        /// <response code="400">Retorna um erro de solicitação inválida.</response>
        /// <response code="404">Retorna um erro caso não seja possível encontrar o produto para atualização parcial.</response>
        #endregion

        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchProduto([FromQuery] int id, [FromBody] UpdateProdutoDtoPatch produtoDto)
        {
            try
            {
               await _produtoService.PatchProdutoAsync(id, produtoDto);
                return Ok(produtoDto);
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
        /// Deleta um produto por ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser deletado.</param>
        /// <returns>
        /// Uma mensagem indicando que oproduto com o ID fornecido foi deletado.
        /// </returns>
        /// <response code="200">Retorna uma mensagem indicando que o produto foi deletado com sucesso.</response>
        /// <response code="404">Retorna um erro caso não seja possível encontrar o produto para deleção.</response>
        #endregion

        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteProduto([FromQuery] int id)
        {
            try
            {
               await _produtoService.DeleteProdutoAsync(id);
                return Ok("Deletado");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}

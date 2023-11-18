using GeekLifeAPI.Dtos.CategoriaDtos;
using GeekLifeAPI.Models;
using GeekLifeAPI.Services.CategoriaService;
using Microsoft.AspNetCore.Mvc;

namespace GeekLifeAPI.Controllers;

#region
//*CreatedAtAction : Mostra a o caminho (url), utilizado para a postagem.*

//* _context = context;: utlizado para dar injeção de independencia, cria a cominicação com o banco de dados
//substituimos "categorias" por "_context.Categorias" no código*

//*_context.SaveChanges();: Vem após a adição de um novo obj, para salvar os dados no banco;*

//*AutoMapper converte a Categoria para um CreateCategoriaDTO (faz o mapeamento de maneira implícita)*
#endregion
[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private ICategoriaService _categoriaService;
    public CategoriaController(ICategoriaService service)
    {
        _categoriaService = service;
    }

    #region
    /// <summary>
    /// Cria uma nova categoria.
    /// </summary>
    /// <param name="categoriaDto">Os dados da categoria a ser criada.</param>
    /// <returns>
    /// Um objeto Categoria recém-criado, se a operação for bem-sucedida.
    /// </returns>
    /// <response code="201">Retorna o objeto Categoria recém-criado.</response>
    /// <response code="400">Retorna um erro de solicitação inválida.</response>
    #endregion

    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]

    public IActionResult PostCategoria([FromBody] CreateCategoriaDto categoriaDto)
    {
        try
        {
            var result = _categoriaService.AddCategoria(categoriaDto);

            if (result != null)
            {
                return CreatedAtAction(nameof(GetCategoriaById), new { id = result.Id }, result);
            }

            return Ok(result);

        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }

    }

    #region
    /// <summary>
    /// Obtém uma lista de categorias com opções de paginação, filtragem e ordenação.
    /// </summary>
    /// <param name="skip">O número de itens a serem ignorados (pulados).</param>
    /// <param name="take">O número máximo de itens a serem retornados.</param>
    /// <param name="status">O status das categorias a serem filtradas, ativo (true) e inativo (false).</param>
    /// <param name="ordenacao">O critério de ordenação das categorias, crescente ou decrescente.</param>
    /// <param name="nome">O nome das categorias a serem filtradas.</param>
    /// <returns>
    /// Um objeto contendo a lista de categorias de acordo com os parâmetros fornecidos.
    /// </returns>
    /// /// <response code="200">Retorna a lista de categorias de acordo com os parâmetros fornecidos.</response>
    /// <response code="400">Retorna um erro de solicitação inválida.</response>
    /// <response code="404">Retorna um erro caso não seja possível encontrar os recursos solicitados.</response>
    #endregion

    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    [HttpGet]
    public async Task<IActionResult> GetAllCategorias([FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? status = null, [FromQuery] string? ordenacao = null, [FromQuery] string? nome = null)
    {
        try
        {
            var categorias = await _categoriaService.GetAllCategoriasAsync(skip, take, status, ordenacao, nome);

            var response = new
            {
                Categorias = categorias
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
    /// Obtém uma categoria por ID.
    /// </summary>
    /// <param name="id">O ID da categoria a ser obtida.</param>
    /// <returns>
    /// Um objeto contendo os dados da categoria correspondente ao ID fornecido.
    /// </returns>
    /// <response code="200">Retorna os dados da categoria correspondente ao ID fornecido.</response>
    /// <response code="400">Retorna um erro de solicitação inválida.</response>
    /// <response code="404">Retorna um erro caso não seja possível encontrar a categoria solicitada.</response>
    #endregion

    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoriaById([FromQuery] int id)
    {
        try
        {
            var categoriaDto = await _categoriaService.GetCategoriaByIdAsync(id);
            return Ok(categoriaDto);
        }
        catch (ArgumentNullException ex)
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
    /// Atualiza uma categoria completa por ID.
    /// </summary>
    /// <param name="id">O ID da categoria a ser atualizada.</param>
    /// <param name="categoriaDto">Os dados atualizados da categoria.</param>
    /// <returns>
    /// Um objeto contendo os dados atualizados da categoria após a operação.
    /// </returns>
    /// <response code="200">Retorna os dados atualizados da categoria após a operação.</response>
    /// <response code="400">Retorna um erro de solicitação inválida.</response>
    /// <response code="404">Retorna um erro caso não seja possível encontrar a categoria para atualização.</response>
    #endregion

    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategoria(int id, [FromBody] UpdateCategoriaDto categoriaDto)
    {
        try
        {
            await _categoriaService.PutCategoriaAsync(id, categoriaDto);


            return Ok(categoriaDto);
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
    /// Atualiza parcialmente uma categoria por ID.
    /// </summary>
    /// <param name="id">O ID da categoria a ser parcialmente atualizada.</param>
    /// <param name="categoriaDto">Os dados parcialmente atualizados da categoria.</param>
    /// <returns>
    /// Um objeto contendo os dados parcialmente atualizados da categoria após a operação.
    /// </returns>
    /// <response code="200">Retorna os dados parcialmente atualizados da categoria após a operação.</response>
    /// <response code="400">Retorna um erro de solicitação inválida.</response>
    /// <response code="404">Retorna um erro caso não seja possível encontrar a categoria para atualização parcial.</response>
    #endregion

    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchCategoria([FromQuery] int id, [FromBody] UpdateCategoriaDtoPatch categoriaDto)
    {

        try
        {
            await _categoriaService.PatchCategoriaAsync(id, categoriaDto);
            return Ok(categoriaDto);
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
    /// Deleta uma categoria por ID.
    /// </summary>
    /// <param name="id">O ID da categoria a ser deletada.</param>
    /// <returns>
    /// Uma mensagem indicando que a categoria com o ID fornecido foi deletada.
    /// </returns>
    /// <response code="200">Retorna uma mensagem indicando que a categoria foi deletada com sucesso.</response>
    /// <response code="404">Retorna um erro caso não seja possível encontrar a categoria para deleção.</response>
    #endregion
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoria([FromQuery] int id)
    {
        try
        {
            await _categoriaService.DeleteCategoriaAsync(id);

            return Ok($"Id:{id},deletado!");
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}






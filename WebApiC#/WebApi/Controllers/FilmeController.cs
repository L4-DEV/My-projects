using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmeController: ControllerBase
{
    private static List<Filme> filmes = new List <Filme>();

    private static int  id = 0;

    [HttpPost]
    public IActionResult AddFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return  CreatedAtAction(nameof(ReadFilmeById), new { id = filme.Id }, filme);
        
    }

    [HttpGet]
    public IEnumerable<Filme> ReadFilme([FromQuery] int skip=0, [FromQuery] int take=50) 
    {
      return filmes.Skip(skip).Take(take);
        
    }

    [HttpGet("{id}")]
    public IActionResult ReadFilmeById (int id )
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound("Este iD não existe");
        return Ok(filme);


        
    }
    
    //[HttpPut]

    //[HttpPatch]

    //[HttpDelete]
}

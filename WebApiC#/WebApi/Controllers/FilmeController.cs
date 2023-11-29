using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Context;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmeController: ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;
    public FilmeController (FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpPost]
    public IActionResult AddFilme([FromBody] CreateFilmeDto filmeDto)
    {
         Filme filme = _mapper.Map<Filme>(filmeDto);
         _context.Filmes.Add(filme);
         _context.SaveChanges();
         return  CreatedAtAction(nameof(ReadFilmeById), new { id = filme.Id }, filme);         
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> ReadFilme([FromQuery] int skip=0, [FromQuery] int take=50) 
    {
      return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));     
    }

    [HttpGet("{id}")]
    public IActionResult ReadFilmeById (int id )
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound("Este iD não existe");
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);      
    }

    [HttpPut("{id}")]
    public IActionResult PutFilme (int id, [FromBody] PutFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        _mapper.Map(filmeDto,filme);
        _context.SaveChanges();
        return NoContent();   
    }

    [HttpPatch("{id}")]
    public IActionResult PatchFilme(int id, JsonPatchDocument<PatchFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<PatchFilmeDto>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();        
    }
}

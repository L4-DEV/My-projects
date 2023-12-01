using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Context;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class SessaoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;
    public SessaoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddSessao([FromBody] CreateSessaoDto dto)
    {
        Sessao sessao = _mapper.Map<Sessao>(dto);
        _context.Sessoes.Add(sessao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ReadSessaoById), new { filmeId = sessao.FilmeId, cinemaId = sessao.CinemaId }, sessao);
    }

    [HttpGet]
    public IEnumerable<ReadSessaoDto> ReadSessao([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{filmeId}/{cinemaId}")]
    public IActionResult ReadSessaoById(int filmeId, int cinemaId)
    {
        Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => 
        sessao.FilmeId == filmeId && sessao.CinemaId== cinemaId);

        if (sessao == null) return NotFound("Este iD não existe");
        var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
        return Ok(sessaoDto);
    }

    [HttpPut("{filmeId}/{cinemaId}")]
    public IActionResult PutSessao(int filmeId, int cinemaId, [FromBody] PutSessaoDto sessaoDto)
    {
        var sessao = _context.Sessoes.FirstOrDefault(sessao =>
        sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);
        if (sessao == null) return NotFound();
        _mapper.Map(sessaoDto, sessao);
        _context.SaveChanges();
        return NoContent();

    }

    [HttpPatch("{filmeId}/{cinemaId}")]
    public IActionResult PatchSessao(int filmeId, int cinemaId, JsonPatchDocument<PatchSessaoDto> patch)
    {
        var sessao = _context.Sessoes.FirstOrDefault(sessao =>
        sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);
        if (sessao == null) return NotFound();

        var sessaoParaAtualizar = _mapper.Map<PatchSessaoDto>(sessao);

        patch.ApplyTo(sessaoParaAtualizar, ModelState);

        if (!TryValidateModel(sessaoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(sessaoParaAtualizar, sessao);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{filmeId}/{cinemaId}")]

    public IActionResult DeleteSessao(int filmeId, int cinemaId)
    {
        var sessao = _context.Sessoes.FirstOrDefault(sessao =>
        sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);
        if (sessao == null) return NotFound();
        _context.Remove(sessao);
        _context.SaveChanges();
        return NoContent();

    }
}

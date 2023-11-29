using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Context;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CinemaController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ReadCinemaById), new { id = cinema.Id }, cinema);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> ReadCinema([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult ReadCinemaById(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null) return NotFound("Cinema não existe!");
        var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
        return Ok(cinemaDto);
    }

    [HttpPut("{id}")]
    public IActionResult PutCinema (int id, [FromBody] PutCinemaDto cinemaDto)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null) return NotFound();
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchCinema(int id, JsonPatchDocument<PatchCinemaDto> patch)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null) return NotFound("Cinema não encontrado");

        var cinemaParaAtualizar = _mapper.Map<PatchCinemaDto>(cinema);

        patch.ApplyTo(cinemaParaAtualizar, ModelState);

        if (!TryValidateModel(cinemaParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(cinemaParaAtualizar, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]

    public IActionResult DeleteCinema(int id)
    {
       var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null) return NotFound("Id não encotrado");
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }
}

using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Consultorio.Services;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _repository;

     
        public PacienteController(IPacienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pacientes = _repository.GetPacientes();
            return pacientes.Any()
               ? Ok(pacientes)
               : BadRequest("Paciente não encontrado.");


            [HttpGet{"id"}]
            public IActionResult Get(int id)
            {
                var paciente = _repository.GetPacienteById();
                return paciente != null 
                   ? Ok(paciente)
                   : BadRequest("Paciente não encontrado.");
            }

            //[HttpGet("search/{id}")]
            //public IActionResult GetById(int id)
            //{
            //    var agendamentoSelecionado = agendamentos.FirstOrDefault(x => x.Id == id);

            //    return agendamentoSelecionado != null
            //      ? Ok (agendamentoSelecionado)
            //      : BadRequest(" Erro ao buscar o agendamento");
            //}

            //[HttpPost]
            //public IActionResult Post()
            //{
            //    var pacienteAgendado = true;


            //    if (pacienteAgendado)
            //    {
            //        _emailService.EnviarEmail("Lucaswendelns@gmail.com");
            //    }

            //    return Ok();
            //}

        }
}

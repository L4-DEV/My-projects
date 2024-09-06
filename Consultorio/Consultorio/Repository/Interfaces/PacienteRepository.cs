using Consultorio.Context;
using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repository.Interfaces
{
    public class PacienteRepository : BaseRepository, IPacienteRepository
    { 
         private readonly ConsultorioContext _context;

        public PacienteRepository(ConsultorioContext context): base(context) 
        {
            _context = context;
        }
        public IEnumerable<Paciente> GetPacientes()
        {
            return  _context.Pacientes.Include( x => x.Consultas).ToList();

        }

        public Paciente GetPacienteById(int id)
        {
           return _context.Pacientes.Include(x => x.Consultas).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

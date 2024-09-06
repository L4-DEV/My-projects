using Consultorio.Models.Entities;

namespace Consultorio.Repository.Interfaces
{
    public interface IPacienteRepository:IBaseRepository
    {
        IEnumerable<Paciente> GetPacientes();

        Paciente GetPacienteById(int id);
    }
}

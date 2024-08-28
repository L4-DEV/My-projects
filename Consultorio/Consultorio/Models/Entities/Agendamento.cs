using System.ComponentModel.DataAnnotations;

namespace Consultorio.Models.Entities
{
    public class Agendamento
    {
       
        public int Id { get; set; }
        public string NomePaciente { get; set; }

        public int Idade { get; set; }

        public  DateTime  Horario{ get; set; }
    }
}

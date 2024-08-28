namespace Consultorio.Models.Entities
{
    public class Consulta
    {
        public DateTime DataHorario { get; set; }
        public int Status { get; set; }
        public decimal Preco { get; set; }
        public int PacientId { get; set; }
        public int Paciente { get; set; }
        public int EspecialidadeId { get; set; }
        //public Especialidade Especialidade { get; set; }
        public int ProfissionalId { get; set; }
        //public Profissional Profissional { get; set; }
    }
}

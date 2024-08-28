using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Consultorio.Context
{
    public class ConsultorioContext:DbContext
    {
        public ConsultorioContext(DbContextOptions<ConsultorioContext> options) : base(options)
        { }
            //public DbSet<Agendamento> Agendamentos { get; set; }

        public DbSet<Consulta> Consultas { get; set; }

        public DbSet<Especialidade> Especialidades { get; set; }

        public DbSet <Paciente> Pacientes { get; set; }

        public DbSet <Profissional> Profissionais { get; set; }

        //public DbSet<ProfissionalEspecialidade> ProfissionaisEspecialidades { get; set;}


       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            //var agendamento = modelBuilder.Entity<Agendamento>();

            //agendamento.ToTable("tb_agendamento");
            //agendamento.HasKey(x => x.Id); //equivalente ao data notations [key] //
            //agendamento.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            //agendamento.Property(x => x.NomePaciente).HasColumnName("nome_paciente").HasColumnType("varchar(100)").IsRequired();
            //agendamento.Property(x => x.Horario).HasColumnName("horario").IsRequired();



        }

        
    }
}

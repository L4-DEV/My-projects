using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Consultorio.Context
{
    public class ConsultorioContext:DbContext
    {
        public ConsultorioContext(DbContextOptions<ConsultorioContext> options) : base(options)
        { }
            public DbSet<Agendamento> Agendamentos { get; set; }
        
    }
}

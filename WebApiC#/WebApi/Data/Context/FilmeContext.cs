using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data.Context;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
    {


    }

       public DbSet<Filme> Filmes { get; set; }
       public DbSet<Cinema> Cinemas { get; set; }
       public DbSet<Endereco> Enderecos { get; set; }
    public object Endereco { get; internal set; }
}  






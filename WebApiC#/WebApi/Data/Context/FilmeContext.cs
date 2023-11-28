using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data.Context;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
    {


    }

       public DbSet<Filme> Filmes { get; set; }
}






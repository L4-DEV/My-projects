
using GeekLifeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekLifeAPI.Data.EfCore
{
    public class CategoriaContext: DbContext
    {
        public CategoriaContext(DbContextOptions<CategoriaContext> opts): base (opts) 
        {

        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Sub> Subs { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<CD> CDs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

        }
    }
}

    



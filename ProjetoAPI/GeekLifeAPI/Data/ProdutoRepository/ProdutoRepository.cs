using Dapper;
using GeekLifeAPI.Data.EfCore;
using GeekLifeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace GeekLifeAPI.Data.ProdutoRepository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CategoriaContext _context;
        
        public ProdutoRepository(CategoriaContext context)
        {
            _context = context;       
        }

        public void Add(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

        }

        public async Task<IEnumerable<Produto>>GetAllAsync(int skip, int take, string? status, string? ordenacao, string? nome)
        {
            using var connection = _context.Database.GetDbConnection();

            string sql =
             @"
                SELECT * FROM PRODUTOS
                WHERE 1=1
             "
            ;

            if (!string.IsNullOrEmpty(status))
            {
                if (status == "ativo".ToLower())
                {
                    sql += " AND Atividade = 1"; 
                }
                else if (status == "inativo".ToLower())
                {
                    sql += " AND Atividade = 0"; 
                }
            }

            if (!string.IsNullOrWhiteSpace(ordenacao))
            {
                sql += $" ORDER BY NomeDoProduto  {(ordenacao.ToLower() == "crescente" ? "ASC" : "DESC")}";
            }

            sql += " LIMIT @Skip , @Take";

            
            var parameters = new
            {
                Status = status,
                Nome = nome,
                Skip = skip,
                Take = take
            };

            connection.Open();
            return await connection.QueryAsync<Produto>(sql, parameters);
        }

        public async Task<IEnumerable<Produto>>GetByIdAsync (int id)
        {
            return await _context.Produtos.Where(p => p.Id == id).ToListAsync();
        }

        public void Update(Produto produto)
        {
          
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }
        public async Task DeleteAsync(int id)
        {

            var produto = await _context.Set<Produto>().FindAsync(id);
            if (produto != null)
            {
                _context.Set<Produto>().Remove(produto);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("ID não encontrado");
            }

        }

        public async Task<Produto> GetFirstIdAsync(int id)
        {
            var idExist = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            if (idExist == null)
            {
                throw new ArgumentException("Não encontrado!");
            }

            return idExist;
        }
       
        public bool NameExist(Produto produto)
        {
            bool nameExist = _context.Produtos.Any(p => p.NomeDoProduto == produto.NomeDoProduto && p.Id != produto.Id) ||
                               _context.Subs.Any(s => s.NomeDaSub == produto.NomeDoProduto && s.Id != produto.Id) ||
                               _context.Categorias.Any(c => c.NomeDaCategoria == produto.NomeDoProduto && c.Id != produto.Id);

            if (nameExist)
            {
                throw new ArgumentException("O nome utilizado já existe na lista, tente um diferente dos existentes!");
            }

            return true;
        }

    }
}

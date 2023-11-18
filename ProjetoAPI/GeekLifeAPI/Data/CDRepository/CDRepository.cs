using Dapper;
using GeekLifeAPI.Data.EfCore;
using GeekLifeAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace GeekLifeAPI.Data.CDRepository
{
    public class CDRepository : ICDRepository
    {
        private readonly CategoriaContext _context;

        public CDRepository(CategoriaContext context/*, IConfiguration configuration*/)
        {
            _context = context;
        }
        public void Add(CD cd)
        {
            _context.CDs.Add(cd);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<CD>> GetAllAsync(int skip, int take, string? status, string? ordenacao, string? nome)
        {
            using var connection = _context.Database.GetDbConnection();

            string sql =
             @"
                SELECT * FROM CDS
                WHERE 1=1
             ";

            if (!string.IsNullOrEmpty(status))
            {
                if (status == "ativo".ToLower())
                {
                    sql += " AND Atividade = 1"; // Status ativo (true)
                }
                else if (status == "inativo".ToLower())
                {
                    sql += " AND Atividade = 0"; // Status inativo (false)
                }
            }

            if (!string.IsNullOrWhiteSpace(ordenacao))
            {
                sql += $" ORDER BY NomeDoCD  {(ordenacao.ToLower() == "crescente" ? "ASC" : "DESC")}";
            }

            sql += " LIMIT @Skip , @Take";

            // Parâmetros para a consulta
            var parameters = new
            {
                Status = status,
                Nome = nome,
                Skip = skip,
                Take = take
            };

            connection.Open();
            return await connection.QueryAsync<CD>(sql, parameters);
        }

        public void Update(CD cd)
        {
            _context.CDs.Update(cd);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var cd = await _context.Set<CD>().FindAsync(id);
            if (cd != null)
            {
                _context.Set<CD>().Remove(cd);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("ID não encontrado");
            }
        }

        public async Task<CD> GetFirstIdAsync(int id)
        {
            var cdExist = await _context.CDs.FirstOrDefaultAsync(c => c.Id == id);

            if (cdExist == null)
            {
                throw new ArgumentException("Cd não encontrado!");
            }

            return cdExist;
        }

        public void NameExist(CD cd)
        {
            bool nameExist = _context.Categorias.Any(c => c.NomeDaCategoria == cd.NomeDoCD && c.Id != cd.Id) ||
                                _context.Subs.Any(s => s.NomeDaSub == cd.NomeDoCD && s.Id != cd.Id) ||
                                _context.Produtos.Any(p => p.NomeDoProduto == cd.NomeDoCD && p.Id != cd.Id) ||
                                _context.CDs.Any(cd => cd.NomeDoCD == cd.NomeDoCD && cd.Id != cd.Id);
            if (nameExist)
            {
                throw new ArgumentException("O nome utilizado já existe na lista, tente um diferente dos existentes!");
            }

        }

        public void AdressExist(CD cd)
        {
            bool adressExists = _context.CDs.Any(c =>
            c.CEP == cd.CEP &&
            c.Numero == cd.Numero);

            if (adressExists)
            {
                throw new ArgumentException("O endereço tem que ser único para ser aceito...");
            }
        }
    }
}

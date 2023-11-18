using Microsoft.EntityFrameworkCore;
using GeekLifeAPI.Models;
using GeekLifeAPI.Data.EfCore;
using Dapper;

namespace GeekLifeAPI.Data.SubRepository
{
    public class SubRepository : ISubRepository
    {
        private readonly CategoriaContext _context;
      
        public SubRepository(CategoriaContext context)
        {
            _context = context;
        }

        public void Add(Sub sub)
        {
            _context.Subs.Add(sub);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Sub>> GetAllAsync(int skip, int take, string? status, string? ordenacao, string? nome)
        {
            using var connection = _context.Database.GetDbConnection();

            string sql =
             @"
                SELECT * FROM SUBS
                WHERE 1=1
             ";

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
                sql += $" ORDER BY NomeDaSub  {(ordenacao.ToLower() == "crescente" ? "ASC" : "DESC")}";
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
            return await connection.QueryAsync<Sub>(sql, parameters);
        }

        public async Task<IEnumerable<Sub>> GetByIdAsync(int id)
        {
            return await _context.Subs.Where(s => s.Id == id).ToListAsync();
        }

        public void Update(Sub sub)
        {
            _context.Subs.Update(sub);
            _context.SaveChanges();

        }

        public async Task DeleteAsync(int id)
        {
            var sub = await _context.Set<Sub>().FindAsync(id);

            if (sub!= null)
            {
                _context.Set<Sub>().Remove(sub);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("ID não encontrado");
            }     
        }
 
        public async Task<Sub> GetFirstIdAsync(int id)
        {

            var subExist = await  _context.Subs.FirstOrDefaultAsync(s => s.Id == id);
            if (subExist == null)
            {
                throw new ArgumentException("Sub destino não encontrada!");
            }

            return subExist;

        }



        public bool NameExist(Sub sub)
        {

            bool nameExist = _context.Subs.Any(s => s.NomeDaSub == sub.NomeDaSub && s.Id != sub.Id) || _context.Categorias.Any(c => c.NomeDaCategoria == sub.NomeDaSub && c.Id != sub.Id);

                                                                                   

            if (nameExist)
            {
                throw new ArgumentException("O nome utilizado já existe na lista, tente um diferente dos existentes!");
            }

            return true;
        }
      
    }
}
